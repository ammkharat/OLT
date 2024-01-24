using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class CloneWorkPermitFormPresenterTest
    {
        Mockery mocks;
        ICloneWorkPermitFormView mockView;
        IAuthorized mockAuthorized;
        CloneWorkPermitFormPresenter presenter;
        WorkPermit cloneFrom;
        User currentUser;
        private UserRoleElements userRoleElements;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            UserContext userContext = ClientSession.GetUserContext();

            currentUser = UserFixture.CreateUser();
            userContext.User = currentUser;
            
            userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userContext.SetRole(RoleFixture.CreateRole(), userRoleElements, new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            Site site = SiteFixture.Sarnia();
            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            userContext.UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();

            mocks = new Mockery();
            mockView = mocks.NewMock<ICloneWorkPermitFormView>();
            mockAuthorized = mocks.NewMock<IAuthorized>();
            presenter = new CloneWorkPermitFormPresenter(mockView, mockAuthorized);

            cloneFrom = WorkPermitFixture.CreateWorkPermitWithGivenId(1);
            
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test][Ignore]
        public void ShouldInitializeCloneOptionsToTrueForEnabledSections()
        {
            SetOnLoadExpectation();
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldEnableOnlySomeSectionsIfUserCannotCloneAllSections()
        {
            SetOnLoadExpectation(CloningPermission.CloneWithSomeRestriction);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableCommunicationMethodForSarnia()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Expect.Once.On(mockView).SetProperty("ShowCommunicationMethod").To(true);
            Stub.On(mockView);
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions").Will(Return.Value(false));
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction").Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableCommunicationMethodForSitesThatAreNotSarnia()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Firebag(), null);
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Expect.Once.On(mockView).SetProperty("ShowCommunicationMethod").To(false);
            Stub.On(mockView);
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions").Will(Return.Value(false));
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction").Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableToolsMethodForDenver()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Denver(), null);
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Expect.Once.On(mockView).SetProperty("ShowTools").To(true);
            Stub.On(mockView);
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions").Will(Return.Value(false));
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction").Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableShowToolsForSitesThatAreNotDenver()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Expect.Once.On(mockView).SetProperty("ShowTools").To(false);
            Stub.On(mockView);
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions").Will(Return.Value(false));
            Stub.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction").Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ShouldThrowExceptionIfUserCannotCloneWorkPermits()
        {
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            SetAuthorizationExpectations(false, false);
            Stub.On(mockView);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ShouldThrowExceptionIfUserHasBothNoRestrictionAndSomeRestriction()
        {
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            SetAuthorizationExpectations(true, true);
            Stub.On(mockView);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldClonePermitTypeAndAttributesOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.PermitTypeAndAttributes);
        }

        [Test][Ignore]
        public void ShouldCloneAdditionalFormsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.AdditionalForms);
        }

        [Test][Ignore]
        public void ShouldCloneLocationJobSpecificsScopIncludingCommunicationMethodOnCreateCloneIfSiteIsNotSarnia()
        {
            Site denver = SiteFixture.Denver();
            ClientSession.GetUserContext().SetSite(denver, SiteConfigurationFixture.CreateDefaultSiteConfiguration(denver));
            SetOnLoadExpectation();
            presenter.HandleFormLoad(null, EventArgs.Empty);

            SetWorkPermitSectionGetterExpectation(WorkPermitSection.LocationJobSpecificsScope);
            WorkPermit actual = presenter.CreateClone();
            Expect.Once.On(mockView).SetProperty("ClonedWorkPermit").To(actual);
            presenter.HandleCreateButtonClick(null, null);

            Assert.AreEqual(true, cloneFrom.CommunicationMethod.Equals(actual.CommunicationMethod));

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldCloneLocationJobSpecificsScopeExcludingCommunicationMethodOnCreateCloneIfSiteIsSarnia()
        {
            SetOnLoadExpectation();
            presenter.HandleFormLoad(null, EventArgs.Empty);

            SetWorkPermitSectionGetterExpectation(WorkPermitSection.LocationJobSpecificsScope);
            WorkPermit actual = presenter.CreateClone();
            Expect.Once.On(mockView).SetProperty("ClonedWorkPermit").To(actual);
            presenter.HandleCreateButtonClick(null, null);

            Assert.AreEqual(false, cloneFrom.CommunicationMethod.Equals(actual.CommunicationMethod));

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldCloneToolsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.Tools);
        }

        [Test][Ignore]
        public void ShouldCloneEquipmentPreparationConditionOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.EquipmentPreparationCondition);
        }

        [Test][Ignore]
        public void ShouldCloneJobWorkSitePreparationOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.JobWorksitePreparation);
        }

        [Test][Ignore]
        public void ShouldCloneRadiationInformationOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.RadiationInformation);
        }

        [Test][Ignore]
        public void ShouldCloneFireConfinedSpaceRequirementsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.FireConfinedSpaceRequirements);
        }

        [Test][Ignore]
        public void ShouldCloneRespiratoryProtectionRequirementsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.RespiratoryProtectionRequirements);
        }

        [Test][Ignore]
        public void ShouldCloneSpecialPPERequirementsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.SpecialPPERequirements);
        }

        [Test][Ignore]
        public void ShouldCloneSpecialPrecautionsOrConsiderationsOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.SpecialPrecautionsOrConsiderations);
        }

        [Test][Ignore]
        public void ShouldCloneNotificationAuthorizationOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.NotificationAuthorization);
        }

        [Test][Ignore]
        public void ShouldCloneCommunicationMethodOnCreateClone()
        {
            TestCloneSingleSection(WorkPermitSection.CommunicationMethod);
        }

        [Test][Ignore]
        public void ShouldCloneGasTestsOnCreateClone()
        {
            WorkPermitGasTests fromGasTests = cloneFrom.GasTests;

            // Make sure there are ID's on All original gas test elements and element-info's
            int id = -25000;
            foreach (GasTestElement gasTestElement in fromGasTests.Elements)
            {
                if (gasTestElement.Id.HasValue)
                    gasTestElement.Id = id++;

                if (gasTestElement.ElementInfo.Id.HasValue)
                    gasTestElement.ElementInfo.Id = id++;
            }
            
            TestCloneSingleSection(WorkPermitSection.GasTests);
        }

        [Test]
        public void ShouldCloneDocumentLinkssOnCreateClone()
        {            
            List<DocumentLink> links = DocumentLinkFixture.CreateDocumentListOfTwo();
            cloneFrom.DocumentLinks = links;
            
            Expect.Once.On(mockView).GetProperty("CloneMiscellaneous").Will(Return.Value(true));
            SetStubsForCloneOfDocumentLinks();
            
            presenter.HandleFormLoad(null, EventArgs.Empty);
            WorkPermit clonedPermit = presenter.CreateClone();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(links, clonedPermit.DocumentLinks);
        }

        [Test]
        public void ShouldNotCloneDocumentsWhenCloneDocumentLinksIsFalse()
        {
            List<DocumentLink> links = DocumentLinkFixture.CreateDocumentListOfTwo();
            cloneFrom.DocumentLinks = links;
            
            Expect.Once.On(mockView).GetProperty("CloneMiscellaneous").Will(Return.Value(false));
            SetStubsForCloneOfDocumentLinks();

            presenter.HandleFormLoad(null, EventArgs.Empty);
            WorkPermit clonedPermit = presenter.CreateClone();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(0, clonedPermit.DocumentLinks.Count);
        }

        private void SetStubsForCloneOfDocumentLinks()
        {
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Stub.On(mockView).SetProperty("WorkPermitNumber").To(cloneFrom.PermitNumber);
            SetAuthorizationExpectations(false, true);
            OltStub.On(mockView);
        }

        [Test]
        public void CloneWithoutPermitTypeSectionShouldProducePermitWithDefaultPermitType()
        {
            Expect.Once.On(mockView).GetProperty("ClonePermitTypeAttributes").Will(Return.Value(false));
            OltStub.On(mockView);
            
            WorkPermit clonedPermit = presenter.CreateClone();
            Assert.AreEqual(WorkPermitType.COLD, clonedPermit.WorkPermitType);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void CloneShouldSetPermitStartEndDateTimesToUserPreferenceForDenver()
        {
            OltStub.On(mockView);

            User denverUser = UserFixture.CreateUser(SiteFixture.Denver());
            ClientSession.GetUserContext().User = denverUser;
            UserShift userShift = UserShiftFixture.CreateUserShift();
            ClientSession.GetUserContext().UserShift = userShift;
            UserWorkPermitDefaultTimePreferences preferences =
                UserWorkPermitDefaultTimePreferencesFixture.Create(new TimeSpan(02, 00, 00), 
                                                                   new TimeSpan(01, 00, 00));
            denverUser.WorkPermitDefaultTimePreferences = preferences;

            WorkPermit clonedPermit = presenter.CreateClone();

            Assert.AreEqual(preferences.DefaultDateTimeRange(userShift), 
                            new Range<DateTime>(clonedPermit.StartDateTime, clonedPermit.EndDateTime.Value));
        }

        [Test]
        public void CloneShouldSetPermitStartDateTimeToNowAndEndDateTimesToUserPreferenceForSarnia()
        {
            OltStub.On(mockView);

            UserShift userShift = UserShiftFixture.CreateUserShift();
            ClientSession.GetUserContext().UserShift = userShift;
            UserWorkPermitDefaultTimePreferences preferences =
                UserWorkPermitDefaultTimePreferencesFixture.Create(new TimeSpan(02, 00, 00),
                                                                   new TimeSpan(01, 00, 00));
            currentUser.WorkPermitDefaultTimePreferences = preferences;

            WorkPermit clonedPermit = presenter.CreateClone();

            Range<DateTime> expectedRange = new Range<DateTime>(
                Clock.Now.BuildDateTimeWithNoSecondsOrMilliseconds(), userShift.EndDateTime.Subtract(preferences.PostShiftPadding));

            Assert.AreEqual(expectedRange,
                            new Range<DateTime>(clonedPermit.StartDateTime, clonedPermit.EndDateTime.Value));
        }

        [Test]
        public void CloneShouldInitializeJobWorkSitePreparationItemsWithNotApplicable()
        {
            SiteConfiguration siteConfiguration = 
                SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(false);
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(userContext.Site, siteConfiguration);

            Expect.Once.On(mockView).GetProperty("CloneJobWorksitePreparation").Will(Return.Value(false));

            OltStub.On(mockView);
            
            WorkPermit clonedPermit = presenter.CreateClone();
            Assert.AreEqual(false, clonedPermit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable);
        
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldSelectAllowedSections()
        {
            Stub.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            
            SetAuthorizationExpectations(true, false);
            SetSectionExpectations(true, false);

            Stub.On(mockView);

            presenter.HandleFormLoad(null, null);
            
            // Execute:
            presenter.SelectAllSections(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldDeselectAllowedSections()
        {
            SetSectionExpectations(false, false);

            // Execute:
            presenter.DeselectAllSections(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private enum CloningPermission
        {
            None,
            CloneWithSomeRestriction,
            CloneWithNoRestriction,
            RestrictedAndNotRestricted
        }

        private void TestCloneSingleSection(WorkPermitSection section)
        {
            SetOnLoadExpectation();
            presenter.HandleFormLoad(null, EventArgs.Empty);

            SetWorkPermitSectionGetterExpectation(section);
            WorkPermit actual = presenter.CreateClone();
            Expect.Once.On(mockView).SetProperty("ClonedWorkPermit").To(actual);
            presenter.HandleCreateButtonClick(null, null);

            Assert.IsNull(actual.Id);
            AssertClonedWorkPermit(cloneFrom, actual, section);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertClonedWorkPermit(WorkPermit expected, WorkPermit actual, WorkPermitSection section)
        {
            Assert.AreEqual(section == WorkPermitSection.PermitTypeAndAttributes, expected.WorkPermitType.Equals(actual.WorkPermitType));
            Assert.AreEqual(section == WorkPermitSection.PermitTypeAndAttributes, expected.WorkPermitTypeClassification.Equals(actual.WorkPermitTypeClassification));
            Assert.AreEqual(section == WorkPermitSection.PermitTypeAndAttributes, expected.Attributes.Equals(actual.Attributes));
            Assert.AreEqual(section == WorkPermitSection.AdditionalForms, expected.AdditionItemsRequired.Equals(actual.AdditionItemsRequired));
            Assert.AreEqual(section == WorkPermitSection.Tools, expected.Tools.Equals(actual.Tools));
            Assert.AreEqual(section == WorkPermitSection.EquipmentPreparationCondition, expected.EquipmentPreparationCondition.Equals(actual.EquipmentPreparationCondition));
            Assert.AreEqual(section == WorkPermitSection.JobWorksitePreparation, expected.JobWorksitePreparation.Equals(actual.JobWorksitePreparation));
            Assert.AreEqual(section == WorkPermitSection.RadiationInformation, expected.RadiationInformation.Equals(actual.RadiationInformation));
            Assert.AreEqual(section == WorkPermitSection.FireConfinedSpaceRequirements, expected.FireConfinedSpaceRequirements.Equals(actual.FireConfinedSpaceRequirements));
            Assert.AreEqual(section == WorkPermitSection.RespiratoryProtectionRequirements, expected.RespiratoryProtectionRequirements.Equals(actual.RespiratoryProtectionRequirements));
            Assert.AreEqual(section == WorkPermitSection.SpecialPPERequirements, expected.SpecialProtectionRequirements.Equals(actual.SpecialProtectionRequirements));
            Assert.AreEqual(section == WorkPermitSection.SpecialPrecautionsOrConsiderations, expected.SpecialPrecautionsOrConsiderations.Equals(actual.SpecialPrecautionsOrConsiderations));
            AssertSpecificsCopied(section == WorkPermitSection.LocationJobSpecificsScope, expected.Specifics, actual.Specifics);
            // Communication section can be part of the LocationJobSpecific (non-sarnia) or on it's own Communication Method section (sarnia).
            //   Should we have more of these differences, we can separate the Clone/Copy forms into their own respective forms base on site.
            //   For now, this is the only divergence. - Joe
            AssertCommunicationMethodCopied((section == WorkPermitSection.LocationJobSpecificsScope &&
                                            ClientSession.GetUserContext().Site != SiteFixture.Sarnia()) ||
                                            section == WorkPermitSection.CommunicationMethod,
                                            expected.CommunicationMethod, actual.CommunicationMethod);
            AssertGasTestsCopied(section == WorkPermitSection.GasTests, expected.GasTests, actual.GasTests);
            AssertNotificationAuthorization(section == WorkPermitSection.NotificationAuthorization, expected, actual);
        }

        private static void AssertCommunicationMethodCopied(bool shouldHaveCopied, WorkPermitCommunication expected, WorkPermitCommunication actual)
        {
            Assert.AreEqual(shouldHaveCopied, expected.Equals(actual));
        }

        private static void AssertSpecificsCopied(bool shouldHaveCopied, WorkPermitSpecifics expected, WorkPermitSpecifics actual)
        {
            Assert.AreEqual(shouldHaveCopied, expected.FunctionalLocation.Equals(actual.FunctionalLocation));
            Assert.AreEqual(shouldHaveCopied, expected.WorkOrderNumber.Equals(actual.WorkOrderNumber));
            Assert.AreEqual(shouldHaveCopied, expected.WorkOrderDescription.Equals(actual.WorkOrderDescription));
            Assert.AreEqual(shouldHaveCopied, expected.JobStepDescription.Equals(actual.JobStepDescription));
            Assert.AreEqual(shouldHaveCopied, expected.ContactName.Equals(actual.ContactName));
            Assert.AreEqual(shouldHaveCopied, expected.ContractorCompanyName.Equals(actual.ContractorCompanyName));
            Assert.AreEqual(shouldHaveCopied, expected.CraftOrTrade.Equals(actual.CraftOrTrade));
            // NOTE: Even though start and end date/time are part of the 'Specifics' section,
            //       they are excluded from the Work Permit copy process.
        }

        private void AssertGasTestsCopied(bool shouldHaveCopied, WorkPermitGasTests expected, WorkPermitGasTests actual)
        {
            if (shouldHaveCopied)
            {
                AssertGasTestsCopied(expected, actual);
            }
            else
            {
                Assert.AreEqual(false, expected.Equals(actual));
            }
        }

        private static void AssertGasTestsCopied(WorkPermitGasTests expected, WorkPermitGasTests actual)
        {
            Assert.IsNull(actual.Id);
            Assert.AreEqual(expected.FrequencyOrDuration, actual.FrequencyOrDuration);
            Assert.AreEqual(expected.ConstantMonitoringRequired, actual.ConstantMonitoringRequired);
            Assert.AreEqual(expected.Elements.Count, actual.Elements.Count);

            for (int i = 0; i < expected.Elements.Count; i++)
            {
                GasTestElement actualElement = actual.Elements[i];
                GasTestElement expectedElement = expected.Elements[i];

                Assert.IsNull(actualElement.Id);
                Assert.AreEqual(expectedElement.ImmediateAreaTestResult, actualElement.ImmediateAreaTestResult);
                Assert.AreEqual(expectedElement.ImmediateAreaTestRequired, actualElement.ImmediateAreaTestRequired);

                GasTestElementInfo actualInfo = actualElement.ElementInfo;
                GasTestElementInfo expectedInfo = expectedElement.ElementInfo;

                if (expectedInfo.IsStandard)
                {
                    Assert.AreEqual(expectedInfo.Id, actualInfo.Id);
                }
                else
                {
                    Assert.IsNull(actualInfo.Id);
                }

                Assert.AreEqual(expectedInfo.Name, actualInfo.Name);
                Assert.AreEqual(expectedInfo.OtherLimits, actualInfo.OtherLimits);
            }
        }

        private static void AssertNotificationAuthorization(bool shouldEqual, WorkPermit expected, WorkPermit actual)
        {
            Assert.AreEqual(shouldEqual, expected.IsCoauthorizationRequired.Equals(actual.IsCoauthorizationRequired));
            Assert.AreEqual(shouldEqual, expected.CoauthorizationDescription.Equals(actual.CoauthorizationDescription));
        }

        private void SetWorkPermitSectionGetterExpectation(WorkPermitSection sectionToCopy)
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("ClonePermitTypeAttributes").Will(Return.Value(sectionToCopy == WorkPermitSection.PermitTypeAndAttributes));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneAdditionalForms").Will(Return.Value(sectionToCopy == WorkPermitSection.AdditionalForms));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneLocationJobSpecifics").Will(Return.Value(sectionToCopy == WorkPermitSection.LocationJobSpecificsScope));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneCommunicationMethod").Will(Return.Value(sectionToCopy == WorkPermitSection.CommunicationMethod));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneTools").Will(Return.Value(sectionToCopy == WorkPermitSection.Tools));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneEquipmentPreparationCondition").Will(Return.Value(sectionToCopy == WorkPermitSection.EquipmentPreparationCondition));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneJobWorksitePreparation").Will(Return.Value(sectionToCopy == WorkPermitSection.JobWorksitePreparation));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneRadiationInformation").Will(Return.Value(sectionToCopy == WorkPermitSection.RadiationInformation));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneAsbestos").Will(Return.Value(sectionToCopy == WorkPermitSection.Asbestos));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneFireConfinedSpaceRequirements").Will(Return.Value(sectionToCopy == WorkPermitSection.FireConfinedSpaceRequirements));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneRespiratoryProtectionRequirements").Will(Return.Value(sectionToCopy == WorkPermitSection.RespiratoryProtectionRequirements));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneSpecialPPERequirements").Will(Return.Value(sectionToCopy == WorkPermitSection.SpecialPPERequirements));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneSpecialPrecautionsOrConsiderations").Will(Return.Value(sectionToCopy == WorkPermitSection.SpecialPrecautionsOrConsiderations));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneGasTests").Will(Return.Value(sectionToCopy == WorkPermitSection.GasTests));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneNotificationAuthorization").Will(Return.Value(sectionToCopy == WorkPermitSection.NotificationAuthorization));
            Expect.AtLeastOnce.On(mockView).GetProperty("CloneMiscellaneous").Will(Return.Value(sectionToCopy == WorkPermitSection.Miscellaneous));
        }

        private void SetOnLoadExpectation()
        {
            SetOnLoadExpectation(CloningPermission.CloneWithNoRestriction);
        }

        private void SetOnLoadExpectation(CloningPermission cloningPermission)
        {
            Expect.Once.On(mockView).GetProperty("OriginalWorkPermit").Will(Return.Value(cloneFrom));
            Expect.Once.On(mockView).SetProperty("WorkPermitNumber").To(cloneFrom.PermitNumber);
            Expect.Once.On(mockView).SetProperty("ShowCommunicationMethod").To(SiteFixture.Sarnia() == ClientSession.GetUserContext().Site);
            Expect.Once.On(mockView).SetProperty("ShowTools").To(SiteFixture.Denver() == ClientSession.GetUserContext().Site);
            Expect.Once.On(mockView).SetProperty("ShowAsbestos").To(SiteFixture.Sarnia() == ClientSession.GetUserContext().Site);
            Expect.Once.On(mockView).SetProperty("ShowRadiation").To(SiteFixture.Denver() == ClientSession.GetUserContext().Site);
            
            bool authorizedForBasicSections = cloningPermission == CloningPermission.CloneWithNoRestriction 
                || cloningPermission == CloningPermission.CloneWithSomeRestriction;

            Expect.Once.On(mockView).SetProperty("ClonePermitTypeAttributesEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneAdditionalFormsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneLocationJobSpecificsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneCommunicationMethodEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneToolsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneFireConfinedSpaceRequirementsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneRespiratoryProtectionRequirementsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneSpecialPPERequirementsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneSpecialPrecautionsOrConsiderationsEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneNotificationAuthorizationEnabled").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneMiscellaneousEnabled").To(authorizedForBasicSections);

            bool authorizedForRestrictedSections = cloningPermission == CloningPermission.CloneWithNoRestriction;
            Expect.Once.On(mockView).SetProperty("CloneEquipmentPreparationConditionEnabled").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneJobWorksitePreparationEnabled").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneRadiationInformationEnabled").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneAsbestosEnabled").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneGasTestsEnabled").To(authorizedForRestrictedSections);

            SetAuthorizationExpectations(cloningPermission == CloningPermission.CloneWithSomeRestriction || cloningPermission == CloningPermission.RestrictedAndNotRestricted,
                cloningPermission == CloningPermission.CloneWithNoRestriction || cloningPermission == CloningPermission.RestrictedAndNotRestricted);

            SetSectionExpectations(authorizedForBasicSections, authorizedForRestrictedSections);
        }

        private void SetAuthorizationExpectations(bool cloneWorkPermitWithSomeRestrictions, bool cloneWorkPermitWithNoRestrictions)
        {
            Expect.AtLeastOnce.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions")
                    .With(userRoleElements)
                    .Will(Return.Value(cloneWorkPermitWithSomeRestrictions));

            Expect.AtLeastOnce.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction")
                    .With(userRoleElements)
                    .Will(Return.Value(cloneWorkPermitWithNoRestrictions));
        }

        private void SetSectionExpectations(bool authorizedForBasicSections, bool authorizedForRestrictedSections)
        {
            Expect.Once.On(mockView).SetProperty("ClonePermitTypeAttributes").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneAdditionalForms").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneLocationJobSpecifics").To(authorizedForBasicSections);
            Stub.On(mockView).GetProperty("ShowCommunicationMethod").Will(Return.Value(ClientSession.GetUserContext().Site == SiteFixture.Sarnia()));
            Expect.Once.On(mockView).SetProperty("CloneCommunicationMethod").To(authorizedForBasicSections && ClientSession.GetUserContext().Site == SiteFixture.Sarnia());
            Expect.Once.On(mockView).SetProperty("CloneTools").To(authorizedForBasicSections && ClientSession.GetUserContext().Site == SiteFixture.Denver());
            Expect.Once.On(mockView).SetProperty("CloneFireConfinedSpaceRequirements").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneRespiratoryProtectionRequirements").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneSpecialPPERequirements").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneSpecialPrecautionsOrConsiderations").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneNotificationAuthorization").To(authorizedForBasicSections);
            Expect.Once.On(mockView).SetProperty("CloneMiscellaneous").To(authorizedForBasicSections);
            
            Expect.Once.On(mockView).SetProperty("CloneEquipmentPreparationCondition").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneJobWorksitePreparation").To(authorizedForRestrictedSections);
            Expect.Once.On(mockView).SetProperty("CloneRadiationInformation").To(authorizedForRestrictedSections && ClientSession.GetUserContext().Site == SiteFixture.Denver());
            Expect.Once.On(mockView).SetProperty("CloneAsbestos").To(authorizedForRestrictedSections && ClientSession.GetUserContext().Site == SiteFixture.Sarnia());
            Expect.Once.On(mockView).SetProperty("CloneGasTests").To(authorizedForRestrictedSections);            
        }
    }
}
