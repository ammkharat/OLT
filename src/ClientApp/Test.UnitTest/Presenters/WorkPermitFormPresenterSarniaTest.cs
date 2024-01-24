using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Presenters
{
    // Note: This could use some refactoring - with the introduction of the WorkPermitBinder & the 
    //   WorkPermitValidator, this presenter test has unfortunately fallen out of sync.  Additional tests
    //   should be added to verify that the validation is hooked and binding is hooked in properly.
    //   Moreover, a Denver flavor of this test should be created to address the subtle differences.
    //   Due to time constraints, we regretably can't undertake this at this time. 
    [TestFixture]
    public class WorkPermitFormPresenterSarniaTest
    {
        private Mockery mocks;
        private TestableWorkPermitFormPresenter presenter;
        private IWorkPermitFormViewSarnia viewMock;
        private IWorkPermitBinder workPermitBinderMock;
        private IWorkPermitService serviceMock;
        private IGasTestElementInfoService serviceGasTestElementInfoMock;
        private IContractorService contractorServiceMock;
        private IAuthorized authorizedMock;
        private ICraftOrTradeService craftOrTradeServiceMock;
        private IWorkAssignmentService workAssignmentServiceMock;
        private IWorkPermitAutoAssignmentConfigurationService autoAssignmentConfigurationServiceMock;
        private List<IGasTestElementDetails> mockGasTestElementDetailsList;
        private List<GasTestElementInfo> standardGasTestElementInfoList;
        private IFunctionalLocationService functionalLocationServiceMock;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());

            mocks = new Mockery();
            viewMock = mocks.NewMock<IWorkPermitFormViewSarnia>();
            serviceMock = mocks.NewMock<IWorkPermitService>();
            craftOrTradeServiceMock = mocks.NewMock<ICraftOrTradeService>();
            contractorServiceMock = mocks.NewMock<IContractorService>();
            workAssignmentServiceMock = mocks.NewMock<IWorkAssignmentService>();
            autoAssignmentConfigurationServiceMock = mocks.NewMock<IWorkPermitAutoAssignmentConfigurationService>();
            functionalLocationServiceMock = mocks.NewMock<IFunctionalLocationService>();
            

            serviceGasTestElementInfoMock = mocks.NewMock<IGasTestElementInfoService>();
            authorizedMock = mocks.NewMock<IAuthorized>();
            User currentUser = UserFixture.CreateSupervisor(SiteFixture.Sarnia());
            ClientSession.GetUserContext().User = currentUser;
            ClientSession.GetUserContext().UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences =
                UserWorkPermitDefaultTimePreferencesFixture.Create(TimeSpan.Zero, TimeSpan.Zero);
            ClientSession.GetUserContext().PlantIds = new List<long> { 4000 };
            ClientSession.GetUserContext().SetRole(
                RoleFixture.CreateRole(),
                UserRoleElementsFixture.CreateEmpty(),
                new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            standardGasTestElementInfoList = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;
            Expect.AtLeastOnce.On(serviceGasTestElementInfoMock).Method("QueryStandardElementInfosBySiteId")
                .With(currentUser.AvailableSites[0].IdValue).Will(Return.Value(standardGasTestElementInfoList));

            List<WorkAssignment> workAssignments = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(workAssignments));
            Stub.On(viewMock).SetProperty("WorkAssignmentSelectionList");
            Stub.On(viewMock).GetProperty("HasWorkAssignmentFunctionality").Will(Return.Value(true));
            Stub.On(viewMock).Method("ShowWaitScreenAndDisableForm");
            Stub.On(viewMock).Method("CloseWaitScreenAndEnableForm");
            
            workPermitBinderMock = mocks.NewMock<IWorkPermitBinder>();
            presenter = new TestableWorkPermitFormPresenter(
                viewMock, 
                null, 
                authorizedMock,
                workPermitBinderMock,
                serviceMock, 
                craftOrTradeServiceMock, 
                contractorServiceMock, 
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock, 
                functionalLocationServiceMock);
        }

        [TearDown]
        public void TearDown()
        {            
            Clock.UnFreeze();
        }      

        private static GasTestElement FindGasTestElementOfThisStandardInfo(List<GasTestElement> elementList, long standardInfoId)
        {
            return elementList.Find(e => e.ElementInfo.Id == standardInfoId);
        }

        private static GasTestElement FindNonStandardGasTestElement(List<GasTestElement> elementList)
        {
            return elementList.Find(e => e.ElementInfo.IsStandard == false);
        }

        private void SetWorkPermit(WorkPermit workPermit)
        {
            Expect.Once.On(workPermitBinderMock).Method("ToView");
            Expect.Once.On(viewMock).SetProperty("Author").To((workPermit.LastModifiedBy));
            SetWorkItemGasTests(workPermit.GasTests, workPermit.WorkPermitType, workPermit.Attributes);
        }

        private void SetWorkItemGasTests(WorkPermitGasTests gasTests, WorkPermitType workPermitType,
                                         WorkPermitAttributes attributes)
        {
            mockGasTestElementDetailsList = new List<IGasTestElementDetails>();
            List<GasTestElementInfo> standardGasTests = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;
            foreach (GasTestElementInfo info in standardGasTests)
            {
                var mockDetails = mocks.NewMock<IGasTestElementDetails>();
                Stub.On(mockDetails).GetProperty("GasTestElementInfoId").Will(Return.Value(info.Id));
                Stub.On(mockDetails).GetProperty("IsStandard").Will(Return.Value(info.IsStandard));
                GasTestElement expectedElement =
                    FindGasTestElementOfThisStandardInfo(gasTests.Elements, info.IdValue) ??
                    GasTestElement.CreateGasTestElement(info);
                SetGasTestElementDetail(mockDetails, expectedElement, workPermitType, attributes);
                mockGasTestElementDetailsList.Add(mockDetails);
            }

            var mockOtherDetails = mocks.NewMock<IGasTestElementDetails>();
            GasTestElement expectedOtherGasTestElement = FindNonStandardGasTestElement(gasTests.Elements);
            if (expectedOtherGasTestElement == null)
            {
                Site site = ClientSession.GetUserContext().User.AvailableSites[0];
                GasTestElementInfo otherInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                expectedOtherGasTestElement = GasTestElement.CreateGasTestElement(otherInfo);
            }
            Stub.On(mockOtherDetails).GetProperty("GasTestElementInfoId");
            Stub.On(mockOtherDetails).GetProperty("IsStandard").Will(Return.Value(false));
            SetGasTestElementDetail(mockOtherDetails, expectedOtherGasTestElement, workPermitType, attributes);
            mockGasTestElementDetailsList.Add(mockOtherDetails);
            Stub.On(viewMock).GetProperty("GasTestElementDetailsList").Will(Return.Value(mockGasTestElementDetailsList));
        }

        private static void SetGasTestElementDetail(IGasTestElementDetails details, GasTestElement expectedElement,
                                                    WorkPermitType workPermitType, WorkPermitAttributes attributes)
        {
            Expect.Once.On(details).SetProperty("GasTestElementInfoId").To(expectedElement.ElementInfo.Id);
            Expect.Once.On(details).SetProperty("ElementName").To(expectedElement.ElementInfo.Name);
            string expectedLimit;
            if (expectedElement.ElementInfo.IsStandard)
            {
                GasTestElementInfo info = expectedElement.ElementInfo;
                GasLimitRange range = info.GetLimitRange(workPermitType, attributes);
                expectedLimit = range.ToLimitStringWithUnit(info.IsRangedLimit, info.DecimalPlaceCount, info.Unit);
            }
            else
            {
                expectedLimit = expectedElement.ElementInfo.OtherLimits;
            }
            Expect.Once.On(details).SetProperty("Limits").To(expectedLimit);
            Expect.Once.On(details).SetProperty("ImmediateAreaTestResult").To(expectedElement.ImmediateAreaTestResult);
            Expect.Once.On(details).SetProperty("ConfinedSpaceTestResult").To(expectedElement.ConfinedSpaceTestResult);
            Expect.Once.On(details).SetProperty("ImmediateAreaTestRequired").To(
                expectedElement.ImmediateAreaTestRequired);
            Expect.Once.On(details).SetProperty("SystemEntryTestNotApplicable").To(
                expectedElement.SystemEntryTestNotApplicable);
            Expect.Once.On(details).SetProperty("ConfinedSpaceTestRequired").To(
                expectedElement.ConfinedSpaceTestRequired);
            Expect.Once.On(details).SetProperty("IsStandard").To(expectedElement.ElementInfo.IsStandard);
            Expect.Once.On(details).SetProperty("SystemEntryTestResult").To(expectedElement.SystemEntryTestResult);
        }

        private static void GetGasTestElementDetail(IGasTestElementDetails details, GasTestElement expectedElement)
        {
            Expect.AtLeastOnce.On(details).GetProperty("IsStandard").Will(
                Return.Value(expectedElement.ElementInfo.IsStandard));
            if (expectedElement.ImmediateAreaTestResult.HasValue)
            {
                Expect.Once.On(details).GetProperty("ImmediateAreaTestResult").Will(
                    Return.Value(expectedElement.ImmediateAreaTestResult));
            }
            else
            {
                Expect.Once.On(details).GetProperty("ImmediateAreaTestResult");
            }

            if (expectedElement.ConfinedSpaceTestResult.HasValue)
            {
                Expect.Once.On(details).GetProperty("ConfinedSpaceTestResult").Will(
                    Return.Value(expectedElement.ConfinedSpaceTestResult));
            }
            else
            {
                Expect.Once.On(details).GetProperty("ConfinedSpaceTestResult");
            }

            Expect.Once.On(details).GetProperty("ImmediateAreaTestRequired").Will(
                Return.Value(expectedElement.ImmediateAreaTestRequired));
            Expect.Once.On(details).GetProperty("ConfinedSpaceTestRequired").Will(
                Return.Value(expectedElement.ConfinedSpaceTestRequired));

            if (expectedElement.ElementInfo.IsStandard == false)
            {
                Expect.Once.On(details).GetProperty("ElementName").Will(Return.Value(expectedElement.ElementInfo.Name));
                Expect.Once.On(details).GetProperty("Limits").Will(Return.Value(expectedElement.ElementInfo.OtherLimits));
            }
            else
            {
                Expect.AtLeastOnce.On(details).GetProperty("GasTestElementInfoId").Will(
                    Return.Value(expectedElement.ElementInfo.Id));
            }
        }

        private void GetWorkPermitAttributes(WorkPermitAttributes attributes)
        {
            Expect.Once.On(viewMock).GetProperty("IsConfinedSpaceEntry").Will(Return.Value(attributes.IsConfinedSpaceEntry));
            Expect.Once.On(viewMock).GetProperty("IsVehicleEntry").Will(Return.Value(attributes.IsVehicleEntry));
            Expect.Once.On(viewMock).GetProperty("IsBurnOrOpenFlame").Will(Return.Value(attributes.IsBurnOrOpenFlame));
            Expect.Once.On(viewMock).GetProperty("IsAsbestos").Will(Return.Value(attributes.IsAsbestos));
            Expect.Once.On(viewMock).GetProperty("IsExcavation").Will(Return.Value(attributes.IsExcavation));
            Expect.Once.On(viewMock).GetProperty("IsRadiationRadiography").Will(Return.Value(attributes.IsRadiationRadiography));
        }

        private void VerifyFullViewEnabled(bool isFullyEnabled)
        {
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(WorkPermitSection.PermitType, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(WorkPermitSection.PermitAttributes,
                                                                                 true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.PermitTypeAndAttributes, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(WorkPermitSection.AdditionalForms, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.LocationJobSpecificsScope, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.EquipmentPreparationCondition, true && isFullyEnabled);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.JobWorksitePreparation, true && isFullyEnabled);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.RadiationInformation, true && isFullyEnabled);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.Asbestos, true && isFullyEnabled);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.FireConfinedSpaceRequirements, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.RespiratoryProtectionRequirements, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.SpecialPPERequirements, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.SpecialPrecautionsOrConsiderations, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(WorkPermitSection.GasTests,
                                                                                 true && isFullyEnabled);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(
                WorkPermitSection.NotificationAuthorization, true);
            Expect.Once.On(viewMock).Method("SetEnableOnWorkPermitSection").With(WorkPermitSection.Miscellaneous, true);
        }

        private void SetOnFormLoadExpectation(WorkPermit workPermit, bool isFullViewEnabled)
        {            
            presenter = new TestableWorkPermitFormPresenter(
                viewMock, 
                workPermit, 
                new Authorized(),
                workPermitBinderMock,
                serviceMock, 
                craftOrTradeServiceMock, 
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);
            //
            // Set general expectations:
            //
            var craftOrTradeList = new List<CraftOrTrade>();

            List<WorkAssignment> workAssignments = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(workAssignments));

            Expect.Once.On(viewMock).Method("InitializeStandardGasTestElementInfoList").With(
                standardGasTestElementInfoList);

            Expect.Once.On(craftOrTradeServiceMock).Method("QueryBySite").Will(Return.Value(craftOrTradeList));
            Expect.Once.On(viewMock).SetProperty("CraftOrTrades").To(craftOrTradeList);
            Expect.Once.On(contractorServiceMock).Method("QueryBySite");
            Expect.Once.On(viewMock).SetProperty("Contractors");
            Expect.Once.On(viewMock).SetProperty("AcidClothingTypes").To(AcidClothingType.All);
            Expect.Once.On(viewMock).Method("ExpandOrCollapseGroups").With(true);

            SetWorkPermit(workPermit);
            VerifyFullViewEnabled(isFullViewEnabled);
            Stub.On(viewMock).Method("UpdateTitleAsCreateOrEdit");
            Stub.On(viewMock).SetProperty("ViewEditHistoryEnabled");
            Stub.On(viewMock).GetProperty("CraftOrTrades").Will(Return.Value(craftOrTradeList));
            Stub.On(viewMock).SetProperty("EnableCraftOrTradeRadio");
            Stub.On(viewMock).SetProperty("ToggleInputBoxEnabled");
            Stub.On(viewMock).SetProperty("GasTestEventsEnabled");
            Stub.On(viewMock).SetProperty("EquipmentConditionPurgedMethodTextBoxEnabled");

            Expect.Once.On(viewMock).Method("SetInitialFocus");
            Expect.Once.On(viewMock).Method("RegisterUIEventHandlers");
            Stub.On(viewMock).SetProperty("StartTimeNotApplicable");
            
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void TestUpdateViewWithDefaultsShouldSetGetSiteConfigurationToSetDefaults(
            bool workPermitNotApplicableAutoSelected)
        {
            Stub.On(workPermitBinderMock);
            presenter = new TestableWorkPermitFormPresenter(
                viewMock, 
                null, 
                new Authorized(),
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);

            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(userContext.Site, SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected));
            OltStub.On(viewMock, craftOrTradeServiceMock, authorizedMock, contractorServiceMock);
            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ShouldLoadClonedWorkPermitInView(bool isFullViewEnabled)
        {
            if (isFullViewEnabled == false)
            {
                User user = UserFixture.CreatePermitScreener(1, "Tester", SiteFixture.Sarnia());
                user.WorkPermitDefaultTimePreferences = new UserWorkPermitDefaultTimePreferences(user.IdValue,
                                                                                                 new TimeSpan(0),
                                                                                                 new TimeSpan(0));
                ClientSession.GetUserContext().User = user;
                ClientSession.GetUserContext().SetRole(null, UserRoleElementsFixture.CreateRoleElementsForPermitScreener(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            }
            else
            {
                ClientSession.GetUserContext().SetRole(null, UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            }

            //
            // A cloned work permit is a permit object that has no ID. The presenter should load the
            // view with data from this object, rather than treat this as a new work permit and
            // load default values into the view instead.
            //
            WorkPermit clonedWorkPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            SetOnFormLoadExpectation(clonedWorkPermit, isFullViewEnabled);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ShouldLoadCorrectGasLimitForGasTestElementsOnLoad(WorkPermitType workPermitType)
        {
            WorkPermit permit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            ClientSession.GetUserContext().SetRole(null, UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            permit.WorkPermitType = workPermitType;
            permit.GasTests = WorkPermitGasTestsFixture.CreateGasTestsWithData(permit.FunctionalLocation.Site);
            SetOnFormLoadExpectation(permit, true);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ShouldDisableEnableRespiratoryCartridgeTypeTextBox(bool isRespiratoryFullFaceRespirator,
                                                                        bool isRespiratoryHalfFaceRespirator,
                                                                        bool expectedEnabled)
        {
            Expect.Once.On(viewMock).GetProperty("RespiratoryIsFullFaceRespirator").Will(
                Return.Value(isRespiratoryFullFaceRespirator));
            Expect.Once.On(viewMock).GetProperty("RespiratoryIsHalfFaceRespirator").Will(
                Return.Value(isRespiratoryHalfFaceRespirator));
            Expect.Once.On(viewMock).SetProperty("RespiratoryCartridgeTypeTextBoxEnabled").To(expectedEnabled);
            presenter.SetStateOfRespiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetExpectationForUpdatingGasTestElementLimits(WorkPermitType permitType,
                                                                   WorkPermitAttributes attributes)
        {
            WorkPermit permit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            permit.WorkPermitType = permitType;
            mockGasTestElementDetailsList = new List<IGasTestElementDetails>();
            List<GasTestElementInfo> standardGasTEstElementInfoList =
                GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;
            foreach (GasTestElementInfo info in standardGasTEstElementInfoList)
            {
                var mockDetails = mocks.NewMock<IGasTestElementDetails>();
                GasLimitRange limitRange = info.GetLimitRange(permitType, attributes);
                string expectedLimit = limitRange.ToLimitStringWithUnit(info.IsRangedLimit, info.DecimalPlaceCount,
                                                                        info.Unit);
                Expect.Once.On(mockDetails).GetProperty("GasTestElementInfoId").Will(Return.Value(info.Id));
                Expect.Once.On(mockDetails).GetProperty("IsStandard").Will(Return.Value(true));
                Expect.Once.On(mockDetails).SetProperty("Limits").To(expectedLimit);
                mockGasTestElementDetailsList.Add(mockDetails);
            }
            Expect.Once.On(viewMock).GetProperty("WorkPermitType").Will(Return.Value(permitType));
            GetWorkPermitAttributes(attributes);
            Expect.Once.On(viewMock).GetProperty("GasTestElementDetailsList").Will(
                Return.Value(mockGasTestElementDetailsList));
        }

        private void ShouldChangeGasTestElementLimitsBasedOnDifferentPermitType(WorkPermitType permitType)
        {
            var attributes = new WorkPermitAttributes();
            SetExpectationForUpdatingGasTestElementLimits(permitType, attributes);
            presenter = new TestableWorkPermitFormPresenter(
                viewMock,
                null, 
                new Authorized(),
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);

            presenter.OnWorkPermitTypeChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ShouldChangeGasTestElementLimitsBasedOnDifferentAttributes(WorkPermitAttributes attributes)
        {
            WorkPermitType permitType = WorkPermitType.HOT;
            SetExpectationForUpdatingGasTestElementLimits(permitType, attributes);
            presenter = new TestableWorkPermitFormPresenter(
                viewMock,
                null,
                new Authorized(),
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);

            presenter.HandleWorkAttributesChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LoadWorkPermitShouldDisablePrefinedCraftOrTradeControlsIfThereAreNoExistingPredefinedCraftOrTrades()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            var noCraftOrTrades = new List<CraftOrTrade>();
            Expect.Once.On(craftOrTradeServiceMock).Method("QueryBySite").Will(Return.Value(noCraftOrTrades));
            Expect.Once.On(viewMock).SetProperty("EnableCraftOrTradeRadio").To(false);
            Expect.Once.On(viewMock).SetProperty("ToggleInputBoxEnabled").To(true);
            OltStub.On(viewMock, serviceGasTestElementInfoMock, authorizedMock, craftOrTradeServiceMock,
                       contractorServiceMock);
            Expect.Once.On(workPermitBinderMock).Method("ToView");

            presenter = new TestableWorkPermitFormPresenter(
                viewMock, 
                permit, 
                authorizedMock,
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);

            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LoadWorkPermitShouldNotDisablePrefinedCraftOrTradeControlsIfThereAreExistingPredefinedCraftOrTrades()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            var craftOrTrades = new List<CraftOrTrade> { CraftOrTradeFixture.CreateCraftOrTradePipeFitter() };
            Expect.Once.On(craftOrTradeServiceMock).Method("QueryBySite").Will(Return.Value(craftOrTrades));
            Expect.Never.On(viewMock).SetProperty("EnableCraftOrTradeRadio");
            Expect.Never.On(viewMock).SetProperty("ToggleInputBoxEnabled");
            OltStub.On(viewMock, serviceGasTestElementInfoMock, authorizedMock, craftOrTradeServiceMock,
                       contractorServiceMock);
            Expect.Once.On(workPermitBinderMock).Method("ToView");
            presenter = new TestableWorkPermitFormPresenter(
                viewMock,
                permit, 
                authorizedMock,
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock,                 
                functionalLocationServiceMock);

            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldChangeGasTestElementLimitsOnChangingToColdType()
        {
            ShouldChangeGasTestElementLimitsBasedOnDifferentPermitType(WorkPermitType.COLD);
        }

        [Test]
        public void ShouldChangeGasTestElementLimitsOnChangingToHotType()
        {
            ShouldChangeGasTestElementLimitsBasedOnDifferentPermitType(WorkPermitType.HOT);
        }

        [Test]
        public void ShouldChangeGasTestElementLimitsWhenCSEIsSet()
        {
            var attributes = new WorkPermitAttributes {IsConfinedSpaceEntry = true};
            ShouldChangeGasTestElementLimitsBasedOnDifferentAttributes(attributes);
        }

        [Test]
        public void ShouldChangeGasTestElementLimitsWhenInertCSEIsSet()
        {
            var attributes = new WorkPermitAttributes {IsInertConfinedSpaceEntry = true};
            ShouldChangeGasTestElementLimitsBasedOnDifferentAttributes(attributes);
        }

        [Test]
        public void ShouldDisableViewEditHistoryForCreatingNewWorkPermit()
        {
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(false);
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateSiteConfiguration());

            OltStub.On(viewMock, authorizedMock, contractorServiceMock, craftOrTradeServiceMock);
            Expect.Once.On(workPermitBinderMock).Method("ToView");
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisAbleWhenBothIsRespiratoryFullFaceRespiratorAndIsRespiratoryHalfFaceRespiratorAreNotSet()
        {
            const bool isRespiratoryFullFaceRespirator = false;
            const bool isRespiratoryHalfFaceRespirator = false;
            const bool expectedEnabled = false;
            ShouldDisableEnableRespiratoryCartridgeTypeTextBox(isRespiratoryFullFaceRespirator,
                                                               isRespiratoryHalfFaceRespirator, expectedEnabled);
        }

        [Test]
        public void ShouldEnableViewEditHistoryForExistingWorkPermit()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(68);
            var existingPresenter = new TestableWorkPermitFormPresenter(
                viewMock,
                workPermit,
                new Authorized(),
                workPermitBinderMock,
                serviceMock,
                craftOrTradeServiceMock,
                contractorServiceMock,
                serviceGasTestElementInfoMock,
                workAssignmentServiceMock,
                autoAssignmentConfigurationServiceMock, 
                functionalLocationServiceMock);

            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(true);
            Stub.On(viewMock).GetProperty("GasTestElementDetailsList").Will(
                Return.Value(new List<IGasTestElementDetails>()));
            Stub.On(viewMock).GetProperty("CraftOrTrades").Will(
                Return.Value(CraftOrTradeFixture.GetListOfCraftOrTrades()));
            Stub.On(viewMock);
            Stub.On(craftOrTradeServiceMock).Method("QueryBySite").With(ClientSession.GetUserContext().Site).Will(
                Return.Value(new List<CraftOrTrade>()));
            Stub.On(contractorServiceMock);
            Expect.Once.On(workPermitBinderMock).Method("ToView");
            existingPresenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableWhenIsRespiratoryFullFaceRespiratorAndIsRespiratoryHalfFaceRespiratorAreSet()
        {
            const bool isRespiratoryFullFaceRespirator = true;
            const bool isRespiratoryHalfFaceRespirator = true;
            const bool expectedEnabled = true;
            ShouldDisableEnableRespiratoryCartridgeTypeTextBox(isRespiratoryFullFaceRespirator,
                                                               isRespiratoryHalfFaceRespirator, expectedEnabled);
        }

        [Test]
        public void ShouldEnableWhenJustIsRespiratoryFullFaceRespiratorIsSet()
        {
            const bool isRespiratoryFullFaceRespirator = true;
            const bool isRespiratoryHalfFaceRespirator = false;
            const bool expectedEnabled = true;
            ShouldDisableEnableRespiratoryCartridgeTypeTextBox(isRespiratoryFullFaceRespirator,
                                                               isRespiratoryHalfFaceRespirator, expectedEnabled);
        }

        [Test]
        public void ShouldEnableWhenJustIsRespiratoryHalfFaceRespiratorIsSet()
        {
            const bool isRespiratoryFullFaceRespirator = false;
            const bool isRespiratoryHalfFaceRespirator = true;
            const bool expectedEnabled = true;
            ShouldDisableEnableRespiratoryCartridgeTypeTextBox(isRespiratoryFullFaceRespirator,
                                                               isRespiratoryHalfFaceRespirator, expectedEnabled);
        }

        [Test]
        public void ShouldLoadClonedWorkPermitInFullView()
        {
            ShouldLoadClonedWorkPermitInView(true);
        }

        [Test]
        public void ShouldLoadClonedWorkPermitInViewWithPartialView()
        {
            ShouldLoadClonedWorkPermitInView(false);
        }

        [Test]
        public void ShouldLoadWorkPermitGasTestElemntsListOfColdWorkPermit()
        {
            ShouldLoadCorrectGasLimitForGasTestElementsOnLoad(WorkPermitType.COLD);
        }

        [Test]
        public void ShouldLoadWorkPermitGasTestElemntsListOfHotWorkPermit()
        {
            ShouldLoadCorrectGasLimitForGasTestElementsOnLoad(WorkPermitType.HOT);
        }

        [Test]
        public void UpdateViewWithDefaultsShouldSetGetSiteConfigurationToSetDefaultsToFalse()
        {
            TestUpdateViewWithDefaultsShouldSetGetSiteConfigurationToSetDefaults(false);
        }

        [Test]
        public void UpdateViewWithDefaultsShouldSetGetSiteConfigurationToSetDefaultsToTrue()
        {
            TestUpdateViewWithDefaultsShouldSetGetSiteConfigurationToSetDefaults(true);
        }

        class TestableWorkPermitFormPresenter : WorkPermitFormPresenter<IWorkPermitFormViewSarnia>
        {
            public TestableWorkPermitFormPresenter(IWorkPermitFormViewSarnia view, WorkPermit editItem) : base(view, editItem)
            {
            }

            public TestableWorkPermitFormPresenter(IWorkPermitFormViewSarnia view, WorkPermit editItem, IAuthorized authorized, IWorkPermitBinder workPermitBinder, IWorkPermitService service, ICraftOrTradeService serviceCraftOrTrade, IContractorService contractorService, IGasTestElementInfoService gasTestElementInfoService, IWorkAssignmentService workAssignmentService, IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfiguration, IFunctionalLocationService functionalLocationService) : base(view, editItem, authorized, workPermitBinder, service, serviceCraftOrTrade, contractorService, gasTestElementInfoService, workAssignmentService, workPermitAutoAssignmentConfiguration, functionalLocationService)
            {
            }

            protected override void LoadData(List<Action> loadDataDelegates)
            {
                foreach (Action loadDataDelegate in loadDataDelegates)
                {
                    loadDataDelegate();
                }

                AfterDataLoad();
            }
        }
    }
}