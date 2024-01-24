using System;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.Fixtures;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    [TestFixture]
    public class WorkOrderAdapterTest
    {
        private readonly Mockery mocks = new Mockery();
        private IActionItemDefinitionService mockActionItemDefinitionService;
        private IBusinessCategoryService mockBusinessCategoryService;
        private ICraftOrTradeService mockCraftOrTradeService;
        private IFunctionalLocationService mockFunctionalLocationService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private ISiteService mockSiteService;
        private ITimeService mockTimeService;
        private IUserService mockUserService;
        private IWorkAssignmentService mockWorkAssignmentService;
        private IWorkPermitAutoAssignmentConfigurationService mockWorkPermitAutoAssignmentConfigurationService;
        private IWorkPermitService mockWorkPermitService;

        [SetUp]
        public void Setup()
        {
            mockActionItemDefinitionService = mocks.NewMock<IActionItemDefinitionService>();
            mockWorkPermitService = mocks.NewMock<IWorkPermitService>();
            mockFunctionalLocationService = mocks.NewMock<IFunctionalLocationService>();
            mockCraftOrTradeService = mocks.NewMock<ICraftOrTradeService>();
            mockSiteService = mocks.NewMock<ISiteService>();
            mockUserService = mocks.NewMock<IUserService>();
            mockTimeService = mocks.NewMock<ITimeService>();
            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();
            mockBusinessCategoryService = mocks.NewMock<IBusinessCategoryService>();
            mockWorkAssignmentService = mocks.NewMock<IWorkAssignmentService>();
            mockWorkPermitAutoAssignmentConfigurationService =
                mocks.NewMock<IWorkPermitAutoAssignmentConfigurationService>();
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void CallingBuildWorkOrderDescriptionForActionItemDefinitionShouldCreateAString()
        {
            var workOrderDetail = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();
            var workOrderOperation = workOrderDetail.Operations[0];

            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var message = new ActionItemDefinitionBuilder(
                workOrderDetail,
                workOrderOperation,
                null,
                mockTimeService,
                UserFixture.CreateSAPUser(),
                mockBusinessCategoryService).BuildWorkOrderDescriptionForActionItemDefinition();

            Assert.IsTrue(message.Length > 0);
            Assert.IsTrue(message.Contains(workOrderDetail.WorkOrderNumber));
            Assert.IsTrue(message.Contains(workOrderDetail.ShortText));
            Assert.IsTrue(message.Contains(workOrderDetail.EquipmentNumber));
            Assert.IsTrue(message.Contains(workOrderOperation.LongText));
            Assert.IsTrue(message.Contains(workOrderOperation.OperationNumber));
            Assert.IsTrue(message.Contains(workOrderOperation.Suboperation));
        }

        [Test]
        public void CallingBuildWorkOrderDescriptionForWorkPermitShouldCreateAString()
        {
            var workOrderDetail = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();
            var workOrderOperation = workOrderDetail.Operations[0];

            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var builder = new WorkPermitBuilder(
                workOrderDetail,
                workOrderOperation,
                UserFixture.CreateSAPUser(),
                FunctionalLocationFixture.GetAny_Equip1(),
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService);

            var message = builder.BuildWorkOrderDescriptionForWorkPermit();

            Assert.IsTrue(message.Length > 0);
            Assert.IsTrue(message.Contains(workOrderDetail.ShortText));
            Assert.IsTrue(message.Contains(workOrderDetail.EquipmentNumber));
            Assert.IsTrue(message.Contains(workOrderOperation.OperationNumber));
            Assert.IsTrue(message.Contains(workOrderOperation.Suboperation));
        }

        [Test]
        public void
            CreateActionItemDefinitionFromWorkOrderShouldCreateOneActionItemIfWorkPermitAttributeIsEmptyOrWorkCenterOper
            ()
        {
            Stub.On(mockTimeService)
                .Method("GetTime")
                .WithAnyArguments()
                .Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(SiteFixture.Sarnia()));
            Stub.On(mockBusinessCategoryService)
                .Method("GetDefaultSAPWorkOrderCategory")
                .Will(Return.Value(BusinessCategoryFixture.GetEnvironmentalSafetyCategory()));

            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderDetail = WorkOrderDetailFixture.GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000();

            var actionItemDefinition = new ActionItemDefinitionBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                functionalLocation,
                mockTimeService,
                UserFixture.CreateSAPUser(),
                mockBusinessCategoryService).BuildForSAPWorkOrder();
            Assert.IsNotNull(actionItemDefinition);
            Assert.IsTrue(actionItemDefinition.FunctionalLocations.Count == 1);
            Assert.AreEqual(actionItemDefinition.FunctionalLocations[0], functionalLocation);
            Assert.AreEqual(new DateTime(2006, 1, 15, 9, 0, 0), actionItemDefinition.Schedule.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 1, 15, 9, 5, 10), actionItemDefinition.Schedule.EndDateTime);
            Assert.AreEqual(DataSource.SAP, actionItemDefinition.Source);
            Assert.AreEqual(ActionItemDefinitionStatus.Pending, actionItemDefinition.Status);
            Assert.IsNotNull(actionItemDefinition.Name);
            Assert.IsNotNull(actionItemDefinition.Description);
            Assert.IsNotNull(actionItemDefinition.Category);
            Assert.IsNotNull(actionItemDefinition.LastModifiedBy);
            Assert.IsNotNull(actionItemDefinition.LastModifiedDate);
        }

        [Test]
        public void CreateWorkPermitFromWorkOrderShouldCreateWorkPermit()
        {
            Stub.On(mockTimeService)
                .Method("GetTime")
                .WithAnyArguments()
                .Will(Return.Value(DateTimeFixture.DateTimeNow));
            var workOrderDetail = WorkOrderDetailFixture.GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000();

            Expect.Once.On(mockCraftOrTradeService).Method("QueryByWorkCenterOrName").Will(
                Return.Value(CraftOrTradeFixture.CreateCraftOrTradePipeFitter()));

            Expect.Once.On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));

            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var builder = new WorkPermitBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                UserFixture.CreateSAPUser(),
                functionalLocation,
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService);
            var workPermit = builder.Build();

            mocks.VerifyAllExpectationsHaveBeenMet();

            Assert.IsNotNull(workPermit);
            Assert.IsNotNull(workPermit.FunctionalLocation);
            Assert.AreEqual(workPermit.FunctionalLocation, functionalLocation);
            Assert.AreEqual(new DateTime(2006, 1, 15, 09, 00, 00), workPermit.Specifics.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 1, 16, 09, 05, 10), workPermit.Specifics.EndDateTime);
            Assert.AreEqual(DataSource.SAP, workPermit.Source);

            Assert.AreEqual(WorkPermitStatus.Pending, workPermit.WorkPermitStatus);
            Assert.IsNotNull(workPermit.Specifics.WorkOrderDescription);
            Assert.AreEqual(workPermit.Specifics.JobStepDescription, workOrderDetail.Operations[0].LongText);
            Assert.IsNotNull(workPermit.CreatedBy);
            Assert.IsNotNull(workPermit.LastModifiedDate);
            Assert.AreEqual(WorkPermitType.HOT, workPermit.WorkPermitType);
            Assert.AreEqual(WorkPermitTypeClassification.SPECIFIC, workPermit.WorkPermitTypeClassification);
            Assert.IsFalse(workPermit.Specifics.StartTimeNotApplicable);
        }

        [Test]
        public void CreateWorkPermitFromWorkOrderShouldInitializePermitUsingSiteConfiguration()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var siteConfiguration = SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(false);

            Expect.Once.On(mockSiteConfigurationService).Method("QueryBySiteId").
                With(functionalLocation.Site.Id).
                Will((Return.Value(siteConfiguration)));

            OltStub.On(mockTimeService);
            OltStub.On(mockCraftOrTradeService);

            var workOrderDetail =
                WorkOrderDetailFixture.GetWorkOrderWithOneOperation();
            var workPermit = new WorkPermitBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                UserFixture.CreateSAPUser(),
                functionalLocation,
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService).Build();

            // Just pick a N/A property to test... the rest are tested by more comprehensive tests:
            Assert.AreEqual(false, workPermit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable);
        }

        [Test]
        public void CreateWorkPermitFromWorkOrderShouldSetAttributesCorrectlyForWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            foreach (var workOrderAttribChar in WorkOrderWorkPermitAttribute.ALL)
            {
                Stub.On(mockTimeService)
                    .Method("GetTime")
                    .WithAnyArguments()
                    .Will(Return.Value(DateTimeFixture.DateTimeNow));
                Stub.On(mockCraftOrTradeService)
                    .Method("QueryByWorkCenterOrName")
                    .Will(Return.Value(CraftOrTradeFixture.CreateCraftOrTradePipeFitter()));
                Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").
                    Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));

                var workOrderDetail =
                    WorkOrderDetailFixture.GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000();
                var workPermitOperation = workOrderDetail.Operations[0];
                workPermitOperation.WorkPermitAttrib = WorkOrderDetailFixture.ToStringOfAttributes(workOrderAttribChar);

                var builder = new WorkPermitBuilder(
                    workOrderDetail,
                    workPermitOperation,
                    UserFixture.CreateSAPUser(),
                    functionalLocation,
                    workAssignmentConfigurationsForSite,
                    mockTimeService,
                    mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                    mockWorkAssignmentService);

                var workPermit = builder.Build();

                var expected = new WorkPermitAttributes
                {
                    IsConfinedSpaceEntry =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsConfinedSpaceEntry),
                    IsBurnOrOpenFlame =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsBurnOrOpenFlame),
                    IsSystemEntry =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsSystemEntry),
                    IsBreathingAirOrSCBA =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsBreathingAirOrSCBA),
                    IsVehicleEntry =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsVehicleEntry),
                    IsExcavation = (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsExcavation),
                    IsHotTap = (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsHotTap),
                    IsAsbestos = (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsAsbestos),
                    IsCriticalLift =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsCriticalLift),
                    IsRadiationSealed =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsRadiationSealed),
                    IsRadiationRadiography =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsRadiationRadiography),
                    IsElectricalWork =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.Is_ElectricalWork_Via_ElectricSwitching ||
                         workOrderAttribChar == WorkOrderWorkPermitAttribute.Is_ElectricalWork_Via_EnergizedElectrical),
                    IsInertConfinedSpaceEntry =
                        (workOrderAttribChar ==
                         WorkOrderWorkPermitAttribute.IsInertConfinedSpaceEntry),
                    IsLeadAbatement =
                        (workOrderAttribChar == WorkOrderWorkPermitAttribute.IsLeadAbatement)
                }; //WorkOrderWorkPermitAttribute.FromString(workOrderWorkPermitAttrib);

                var actual = workPermit.Attributes;
                Assert.AreEqual(expected, actual, "Failed when WorkOrderWorkPermitAttribute = " + workOrderAttribChar);
            }
        }

        [Test]
        public void CreateWorkPermitFromWorkOrderShouldSetStartAndEndDateTimesButWithUnfinalizedTimes()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            OltStub.On(mockTimeService);
            OltStub.On(mockCraftOrTradeService);
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));

            var workOrderDetail =
                WorkOrderDetailFixture.GetWorkOrderWithOneOperation("2006-2-3", "09:00:00",
                    "2006-2-4", "17:00:00");
            var workPermit = new WorkPermitBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                UserFixture.CreateSAPUser(),
                functionalLocation,
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService).Build();

            Assert.AreEqual(new DateTime(2006, 2, 3, 09, 00, 00), workPermit.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 2, 4, 17, 00, 00), workPermit.EndDateTime);
            Assert.IsFalse(workPermit.StartAndOrEndTimesFinalized);
            Assert.IsFalse(workPermit.Specifics.StartTimeNotApplicable);
        }

        [Test]
        public void CreateWorkPermitFromWorkOrderShouldSetStartTimeToNotApplicableInDenver()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Denver();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetReal_DN1_3003_0001();

            OltStub.On(mockTimeService);
            OltStub.On(mockCraftOrTradeService);
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));

            var workOrderDetail =
                WorkOrderDetailFixture.GetWorkOrderWithOneOperation("2006-2-3", "09:00:00",
                    "2006-2-4", "17:00:00");
            var workPermit = new WorkPermitBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                UserFixture.CreateSAPUser(),
                functionalLocation,
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService).Build();

            Assert.AreEqual(new DateTime(2006, 2, 3, 09, 00, 00), workPermit.StartDateTime);
            Assert.AreEqual(new DateTime(2006, 2, 4, 17, 00, 00), workPermit.EndDateTime);
            Assert.IsFalse(workPermit.StartAndOrEndTimesFinalized);
            Assert.IsTrue(workPermit.Specifics.StartTimeNotApplicable);
        }

        [Test]
        public void HandleAsActionItemDefinitionShouldReturnTrueIfWorkCentreIdentifierIsValid()
        {
            var operations = new Operations {WorkCenterName = WorkCentreName.OPRPR};

            var result = WorkOrderAdapter.HandleAsActionItemDefinition(operations);
            Assert.IsTrue(result);

            operations.WorkCenterName = WorkCentreName.PRTEC;
            result = WorkOrderAdapter.HandleAsActionItemDefinition(operations);
            Assert.IsTrue(result);

            operations.WorkCenterName = WorkCentreName.PRTEC2_C;
            result = WorkOrderAdapter.HandleAsActionItemDefinition(operations);
            Assert.IsTrue(result);

            operations.WorkCenterName = "X";
            result = WorkOrderAdapter.HandleAsActionItemDefinition(operations);
            Assert.IsFalse(result);
        }

        [Test]
        public void IntegrateWorkOrdersShouldInsertOneWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            workOrderWithWorkPermit.PlantID = "4000";
            workOrderWithWorkPermit.Operations[0].WorkPermitType = WorkOrderWorkPermitType.HOT_SAP_CODE;

            const WorkPermit existingWorkPermit = null;
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void IntegrateWorkOrdersToOperatorLogToolShouldIgnoreActionItemDefinitionForLevelOneFloc()
        {
            var floc = FunctionalLocationFixture.GetAny_Division();
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var workOrderDetails = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            workOrderDetails.Operations[0].WorkCenterName = "OPR";
            workOrderDetails.FunctionalLocation = floc.FullHierarchy;

            const ActionItemDefinition existingWorkOrderAID = null;
            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);

            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(currentSiteConfiguration);
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(floc, workOrderDetails);

            SetExpectationForProcessingWorkOrderAsAID(
                workOrderDetails, existingWorkOrderAID, expectedAIDToService, currentSiteConfiguration, false);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void IntegrateWorkOrdersToOperatorLogToolShouldIgnoreActionItemDefinitionForLevelTwoFloc()
        {
            var floc = FunctionalLocationFixture.GetAny_Section();
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var workOrderDetails = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            workOrderDetails.Operations[0].WorkCenterName = "OPR";
            workOrderDetails.FunctionalLocation = floc.FullHierarchy;

            const ActionItemDefinition existingWorkOrderAID = null;
            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);

            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(currentSiteConfiguration);
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(floc, workOrderDetails);

            SetExpectationForProcessingWorkOrderAsAID(
                workOrderDetails, existingWorkOrderAID, expectedAIDToService, currentSiteConfiguration, false);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void IntegrateWorkOrdersToOperatorLogToolShouldInsertActionItemDefinition()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Montreal();//SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderDetails = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            workOrderDetails.Operations[0].WorkCenterName = "OPR";

            const ActionItemDefinition existingWorkOrderAID = null;
            var dontAutoApproveSAPAID =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);

            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(dontAutoApproveSAPAID);
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderDetails);

            SetExpectationForProcessingWorkOrderAsAID(workOrderDetails, existingWorkOrderAID, expectedAIDToService,
                dontAutoApproveSAPAID, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void
            IntegrateWorkOrdersToOperatorLogToolShouldInsertOneActionItemTwoWorkPermitsForMultipleWorkOrdersAndOperations
            ()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithOneAID = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();
            var workOrderWithTwoWorkPermits = WorkOrderDetailFixture.GetWorkOrderWithTwoOperationsForWorkPermit();

            var workOrderDetailArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithOneAID,
                workOrderWithTwoWorkPermits);

            var dontAutoApproveSAPAID =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);

            const WorkPermit existingWorkOrderWorkPermit = null;
            var callCount = workOrderWithTwoWorkPermits.Operations.Length;

            var firstOperation = workOrderWithTwoWorkPermits.Operations[0];

            var returnedCraft = CraftOrTradeFixture.CreateCraftOrTradePipeFitter();

            Expect.Exactly(callCount)
                .On(mockCraftOrTradeService)
                .Method("QueryByWorkCenterOrName")
                .With(firstOperation.WorkCenterName, firstOperation.WorkCenterText, functionalLocation.Site.IdValue)
                .Will(Return.Value(returnedCraft));

            Expect.Exactly(callCount)
                .On(mockWorkPermitService)
                .Method("QueryBySapOperationWorkOrderDetails")
                .WithAnyArguments()
                .Will(Return.Value(existingWorkOrderWorkPermit));

            Expect.Exactly(callCount).On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(dontAutoApproveSAPAID));

            Expect.Exactly(callCount).On(mockWorkPermitService).Method("Insert").WithAnyArguments();

            const ActionItemDefinition existingWorkOrderAID = null;
            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(dontAutoApproveSAPAID);
            SetExpectationForProcessingWorkOrderAsAID(workOrderWithOneAID, existingWorkOrderAID, expectedAIDToService,
                dontAutoApproveSAPAID, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void IntegrateWorkOrdersToOperatorLogToolShouldInsertTwoActionItemDefinitionsForTwoOperations()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithTwoOperations = WorkOrderDetailFixture.GetWorkOrderWithTwoOperationsForWorkPermit();
            workOrderWithTwoOperations.Operations[0].WorkCenterName = WorkCentreName.OPRPR;
            workOrderWithTwoOperations.Operations[1].WorkCenterName = WorkCentreName.OPRPR;

            const ActionItemDefinition existingWorkOrderAID = null;
            var dontAutoApproveSAPAID =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);
            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(dontAutoApproveSAPAID);
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation,
                workOrderWithTwoOperations);

            SetExpectationForProcessingWorkOrderAsAID(workOrderWithTwoOperations, existingWorkOrderAID,
                expectedAIDToService, dontAutoApproveSAPAID, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void
            IntegrateWorkOrdersToOperatorLogToolShouldNotTryToInsertANewWorkPermitIfTheWorkOrderIsAnActionItemDefinition
            ()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithOneOperation = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();
            const ActionItemDefinition existingWorkOrderAID = null;
            var dontAutoApproveSAPAID =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);
            var expectedAIDToService = CreateWorkOrderAIDForSiteConfig(dontAutoApproveSAPAID);
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithOneOperation);

            SetExpectationForProcessingWorkOrderAsAID(workOrderWithOneOperation, existingWorkOrderAID,
                expectedAIDToService, dontAutoApproveSAPAID, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldChangeStatusToApprovedAndRequiresApprovalToFalseWhenAutoApproveIsTrue()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var expectedAIDToService = ActionItemDefinitionFixture.CreateActionItemDefinition();
            expectedAIDToService.RequiresApproval = false;
            expectedAIDToService.Status = ActionItemDefinitionStatus.Approved;
            expectedAIDToService.Source = DataSource.SAP;

            var workOrderWithOneAID = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();

            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);
            currentSiteConfiguration.AutoApproveWorkOrderActionItemDefinition = true;

            const ActionItemDefinition existingAID = null;
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithOneAID);

            SetExpectationForProcessingWorkOrderAsAID(workOrderWithOneAID, existingAID, expectedAIDToService,
                currentSiteConfiguration, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldChangeStatusToPendingAndRequiresApprovalToTrueWhenAutoApprovalIsFalse()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var expectedAIDToService = ActionItemDefinitionFixture.CreateActionItemDefinition();
            expectedAIDToService.Source = DataSource.SAP;
            expectedAIDToService.WaitForApproval();

            var workOrderWithOneAID = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForActionItemDefinition();

            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(currentSite);
            currentSiteConfiguration.AutoApproveWorkOrderActionItemDefinition = false;

            const ActionItemDefinition existingAID = null;
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithOneAID);

            SetExpectationForProcessingWorkOrderAsAID(workOrderWithOneAID, existingAID, expectedAIDToService,
                currentSiteConfiguration, true);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCreateWorkPermitWithUserSpecifiedCraftOrTradeIfNotSystemCraftOrTrade()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            Stub.On(mockTimeService)
                .Method("GetTime")
                .WithAnyArguments()
                .Will(Return.Value(DateTimeFixture.DateTimeNow));

            var workOrderDetail = WorkOrderDetailFixture.GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000();
            const string userWorkCenter = "my user-specific work center";
            workOrderDetail.Operations[0].WorkCenterText = userWorkCenter;

            // Expect looking up whether this craft/trade already exists in the system.
            // We are simulating the case where the craft/trade is NOT already in the system:
            Expect.Once.On(mockCraftOrTradeService)
                .Method("QueryByWorkCenterOrName")
                .WithAnyArguments()
                .Will(Return.Value(null));

            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));


            // Execute:
            var workPermit = new WorkPermitBuilder(
                workOrderDetail,
                workOrderDetail.Operations[0],
                UserFixture.CreateSAPUser(),
                functionalLocation,
                workAssignmentConfigurationsForSite,
                mockTimeService,
                mockSiteConfigurationService, mockCraftOrTradeService, mockFunctionalLocationService,
                mockWorkAssignmentService).Build();

            mocks.VerifyAllExpectationsHaveBeenMet();

            ICraftOrTrade expectedCraftOrTrade = new UserSpecifiedCraftOrTrade(userWorkCenter);
            var actualCraftOrTrade = workPermit.Specifics.CraftOrTrade;
            Assert.AreEqual(expectedCraftOrTrade, actualCraftOrTrade,
                "Work permit should have been created with a user-specified craft/trade.");
        }

        [Test]
        public void ShoultNotUpdateApprovedWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            var existingWorkPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Approved);

            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShoultNotUpdateCompletedWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            var existingWorkPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Complete);

            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShoultNotUpdateIssueddWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            var existingWorkPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Issued);

            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShoultNotUpdateRejecteddWorkPermit()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            var existingWorkPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Rejected);

            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void UpdateWorkPermitShouldUpdateAWorkPermitIfItsStatusIsPending()
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var workOrderWithWorkPermit = WorkOrderDetailFixture.GetWorkOrderWithOneOperationForWorkPermit();
            var existingWorkPermit = WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Pending);
            existingWorkPermit.Id = 9999;
            existingWorkPermit.LastModifiedBy = UserFixture.CreateSAPUser();
            var workOrderDetailsArray = IntegrateWorkOrderToOLTCommonSetUp(functionalLocation, workOrderWithWorkPermit);
            SetExpectationForProcessingWorkOrderAsWorkPermit(workOrderWithWorkPermit, existingWorkPermit);

            var adapter = new WorkOrderAdapter(
                workOrderDetailsArray,
                mockWorkPermitService,
                mockActionItemDefinitionService,
                mockFunctionalLocationService,
                mockSiteService,
                mockUserService,
                mockTimeService,
                mockSiteConfigurationService,
                mockCraftOrTradeService,
                mockBusinessCategoryService,
                mockWorkPermitAutoAssignmentConfigurationService,
                mockWorkAssignmentService);

            adapter.IntegrateWorkOrdersToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private WorkOrderDetails[] IntegrateWorkOrderToOLTCommonSetUp(FunctionalLocation floc,
            params WorkOrderDetails[] incomingWorkOrderDetails)
        {
            Stub.On(mockTimeService)
                .Method("GetTime")
                .WithAnyArguments()
                .Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(SiteFixture.Sarnia()));

            var workOrderDetailArray = incomingWorkOrderDetails;

            var callCount = workOrderDetailArray.Length;
            Expect.Exactly(callCount)
                .On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .WithAnyArguments()
                .Will(Return.Value(floc));

            return workOrderDetailArray;
        }

        private void SetExpectationForProcessingWorkOrderAsAID(WorkOrderDetails incomingWorkOrderDetails,
            ActionItemDefinition existingWorkOrderAID,
            ActionItemDefinition expectedAIDToService,
            SiteConfiguration currentSiteConfiguration,
            bool expectInsertActionItem)
        {
            if (expectInsertActionItem)
            {
                var callCount = incomingWorkOrderDetails.Operations.Length;
                Expect.Exactly(callCount)
                    .On(mockActionItemDefinitionService)
                    .Method("QueryBySapOperationWorkOrderDetails")
                    .Will(Return.Value(existingWorkOrderAID));

                Expect.Exactly(callCount).On(mockSiteConfigurationService).Method("QueryBySiteId").WithAnyArguments()
                    .Will((Return.Value(currentSiteConfiguration)));

                Stub.On(mockBusinessCategoryService).Method("GetDefaultSAPWorkOrderCategory").Will(Return.Value(
                    BusinessCategoryFixture.GetEnvironmentalSafetyCategory()));

                if (existingWorkOrderAID == null)
                {
                    var expectedRequiresApproval = expectedAIDToService.RequiresApproval;
                    var expectedStatus = expectedAIDToService.Status;

                    var expectedAIDProperties =
                        OltPropertyMatcher<ActionItemDefinition>.HasProperties(
                            new OltMatcherPropertyValuePair("Status", expectedStatus),
                            new OltMatcherPropertyValuePair("Source", DataSource.SAP),
                            new OltMatcherPropertyValuePair("RequiresApproval", expectedRequiresApproval));

                    Expect.Exactly(callCount).On(mockActionItemDefinitionService).Method("Insert")
                        .With(expectedAIDProperties, (Matcher) new AlwaysTrueMatcher());
                }
            }
            else
            {
                Expect.Exactly(0).On(mockActionItemDefinitionService).Method("QueryBySapOperationWorkOrderDetails");
                Expect.Exactly(0).On(mockSiteConfigurationService).Method("QueryBySiteId");
                Expect.Exactly(0).On(mockActionItemDefinitionService).Method("Insert");
            }
        }

        private static ActionItemDefinition CreateWorkOrderAIDForSiteConfig(SiteConfiguration configuration)
        {
            var autoApproveWorkOrderAID = configuration.AutoApproveWorkOrderActionItemDefinition;

            var expectedRequiresApproval = autoApproveWorkOrderAID ? false : true;
            var expectedStatus = autoApproveWorkOrderAID
                ? ActionItemDefinitionStatus.Approved
                : ActionItemDefinitionStatus.Pending;

            var ret = ActionItemDefinitionFixture.CreateActionItemDefinition();
            ret.RequiresApproval = expectedRequiresApproval;
            ret.Status = expectedStatus;
            ret.Source = DataSource.SAP;
            return ret;
        }

        private void SetExpectationForProcessingWorkOrderAsWorkPermit(WorkOrderDetails incomingWorkOrderDetails,
            WorkPermit existingWorkOrderWorkPermit)
        {
            var workAssignmentConfigurationsForSite =
                WorkAssignmentFixture.GetListOfSarniaAssignmentConfigurations(FunctionalLocationFixture.GetAny_Equip1());

            Stub.On(mockWorkPermitAutoAssignmentConfigurationService).Method("QueryBySite").WithAnyArguments().Will(
                Return.Value(workAssignmentConfigurationsForSite));
            Stub.On(mockWorkAssignmentService).Method("QueryById").WithAnyArguments().Will(
                Return.Value(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()));

            var currentSite = SiteFixture.Sarnia();

            Stub.On(mockSiteService).Method("QueryByPlantId").WithAnyArguments().Will(Return.Value(currentSite));
            Stub.On(mockUserService).Method("GetSAPUser").Will(Return.Value(UserFixture.CreateSAPUser()));

            var functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            var callCount = incomingWorkOrderDetails.Operations.Length;

            var firstOperation = incomingWorkOrderDetails.Operations[0];

            var returnedCraft = CraftOrTradeFixture.CreateCraftOrTradePipeFitter();

            Expect.Exactly(callCount)
                .On(mockCraftOrTradeService)
                .Method("QueryByWorkCenterOrName")
                .With(firstOperation.WorkCenterName, firstOperation.WorkCenterText, functionalLocation.Site.IdValue)
                .Will(Return.Value(returnedCraft));

            Expect.Exactly(callCount)
                .On(mockWorkPermitService)
                .Method("QueryBySapOperationWorkOrderDetails")
                .WithAnyArguments()
                .Will(Return.Value(existingWorkOrderWorkPermit));

            Expect.Exactly(callCount).On(mockSiteConfigurationService).Method("QueryBySiteId").
                Will(Return.Value(SiteConfigurationFixture.CreateSiteConfiguration()));

            if (existingWorkOrderWorkPermit == null)
                Expect.Exactly(callCount).On(mockWorkPermitService).Method("Insert").WithAnyArguments();
            else
            {
                if (existingWorkOrderWorkPermit.Is(WorkPermitStatus.Pending))
                {
                    Expect.Exactly(callCount).On(mockWorkPermitService).Method("Update").WithAnyArguments();
                }
            }
        }
    }
}