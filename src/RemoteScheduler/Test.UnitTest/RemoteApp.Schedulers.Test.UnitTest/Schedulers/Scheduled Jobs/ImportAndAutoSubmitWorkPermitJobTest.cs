using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class ImportAndAutoSubmitWorkPermitJobTest
    {
        private long batchId = 42; // temp maybe
        private IFunctionalLocationService mockFlocService;
        private ILog mockLogger;
        private IPermitRequestEdmontonService mockPermitRequestService;
        private IWorkPermitEdmontonService mockPermitService;
        private IUserService mockUserService;

        [SetUp]
        public void Setup()
        {
            mockPermitRequestService = MockRepository.GenerateStub<IPermitRequestEdmontonService>();
            mockPermitService = MockRepository.GenerateStub<IWorkPermitEdmontonService>();
            mockUserService = MockRepository.GenerateStub<IUserService>();
            mockFlocService = MockRepository.GenerateStub<IFunctionalLocationService>();
            mockLogger = MockRepository.GenerateStub<ILog>();

            Clock.Freeze();
            Clock.Now = new DateTime(2012, 1, 1, 16, 0, 0);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test][Ignore]
        public void ShouldDealWithFirstDayRejection()
        {
            var job = new EdmontonSapAutoImportJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockPermitRequestService,
                mockPermitService, mockUserService, mockFlocService, mockLogger);

            var flocList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal("ED1")};

            mockFlocService.Stub(m => m.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID))
                .Return(flocList);
            var sapUser = UserFixture.CreateSAPUser();
            mockUserService.Stub(m => m.GetSAPUser()).Return(sapUser);

            var tomorrow = Clock.Now.ToDate();

            var emptyResult = new PermitRequestImportResult(new List<NotifiedEvent>(0),
                new List<PermitRequestImportRejection>(0));

            var notifiedEvent = new NotifiedEvent(ApplicationEvent.PermitRequestEdmontonCreate,
                PermitRequestEdmontonFixture.CreateValidCompletePermitRequest());
            var firstDayResult = new PermitRequestImportResult(new List<NotifiedEvent> {notifiedEvent},
                new List<PermitRequestImportRejection> {new PermitRequestImportRejection("Who cares")});


            mockPermitRequestService.Stub(m => m.Import(sapUser, tomorrow, flocList, new List<IHasPermitKey>(), batchId))
                .Return(firstDayResult);
            mockPermitRequestService.Stub(m => m.Import(null, null, null, null, 0))
                .IgnoreArguments()
                .Return(emptyResult);

            var importResults = new List<PermitRequestImportResult>
            {
                firstDayResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult
            };

            var importRequestDataList = importResults.GetProcessedWorkOrderData();

            mockPermitRequestService.Expect(
                m =>
                    m.FinalizeImport(tomorrow, tomorrow.AddDays(7), importRequestDataList,
                        importResults.GetKeysForRejectedPermitRequests(), batchId, sapUser));


            var permitRequestsForTomorrow = new List<PermitRequestEdmontonDTO>(0);

            mockPermitRequestService.Stub(m => m.QueryByFlocUnitAndBelow(null, null)).IgnoreArguments().Return(
                permitRequestsForTomorrow);

            mockPermitRequestService.Stub(m => m.Submit(tomorrow, permitRequestsForTomorrow, sapUser));

            job.Execute();

            mockPermitRequestService.VerifyAllExpectations();
        }

        [Test]
        public void ShouldImportForTheNextSevenDays()
        {
            var job = new EdmontonSapAutoImportJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockPermitRequestService,
                mockPermitService, mockUserService, mockFlocService, mockLogger);

            var flocList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal("ED1")};

            mockFlocService.Stub(m => m.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID))
                .Return(flocList);
            var sapUser = UserFixture.CreateSAPUser();
            mockUserService.Stub(m => m.GetSAPUser()).Return(sapUser);

            var today = Clock.Now.ToDate();

            var emptyResult = new PermitRequestImportResult(new List<NotifiedEvent>(0),
                new List<PermitRequestImportRejection>(0));

            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(1), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(2), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(3), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(4), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(5), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(6), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);
            mockPermitRequestService.Expect(
                m => m.Import(sapUser, today.AddDays(7), flocList, new List<IHasPermitKey>(), batchId))
                .Return(emptyResult);

            var importResults = new List<PermitRequestImportResult>
            {
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult
            };

            var importRequestDataList = importResults.GetProcessedWorkOrderData();

            mockPermitRequestService.Stub(
                m =>
                    m.FinalizeImport(today, today.AddDays(6), importRequestDataList,
                        importResults.GetKeysForRejectedPermitRequests(), batchId, sapUser));


            var permitRequestsForTomorrow = new List<PermitRequestEdmontonDTO>(0);

            mockPermitRequestService.Stub(m => m.QueryByFlocUnitAndBelow(null, null)).IgnoreArguments().Return(
                permitRequestsForTomorrow);

            mockPermitRequestService.Stub(m => m.Submit(today, permitRequestsForTomorrow, sapUser));

            mockPermitRequestService.Stub(m => m.GetNewBatchId()).Return(42);

            job.Execute();

            mockPermitRequestService.VerifyAllExpectations();
        }

        [Test]
        public void ShouldLogErrorsForFirstDayResults()
        {
            var job = new EdmontonSapAutoImportJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockPermitRequestService,
                mockPermitService, mockUserService, mockFlocService, mockLogger);

            var flocList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal("ED1")};

            mockFlocService.Stub(m => m.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID))
                .Return(flocList);
            var sapUser = UserFixture.CreateSAPUser();
            mockUserService.Stub(m => m.GetSAPUser()).Return(sapUser);

            var tomorrow = Clock.Now.ToDate();

            var emptyResult = new PermitRequestImportResult(new List<NotifiedEvent>(0),
                new List<PermitRequestImportRejection>(0));

            //NotifiedEvent notifiedEvent = new NotifiedEvent(ApplicationEvent.PermitRequestEdmontonCreate, PermitRequestEdmontonFixture.CreateValidCompletePermitRequest());
            var firstDayResult = new PermitRequestImportResult("Could not import cause SAP was down!");

            mockPermitRequestService.Stub(m => m.Import(sapUser, tomorrow, flocList, new List<IHasPermitKey>(), batchId))
                .Return(firstDayResult);
            mockPermitRequestService.Stub(m => m.Import(null, null, null, null, 0))
                .IgnoreArguments()
                .Return(emptyResult);

            var importResults = new List<PermitRequestImportResult>
            {
                firstDayResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult
            };

            mockLogger.Expect(m => m.Error(null)).IgnoreArguments();

            var importRequestDataList = importResults.GetProcessedWorkOrderData();

            mockPermitRequestService.Stub(
                m =>
                    m.FinalizeImport(tomorrow, tomorrow.AddDays(7), importRequestDataList,
                        importResults.GetKeysForRejectedPermitRequests(), batchId, sapUser));

            var permitRequestsForTomorrow = new List<PermitRequestEdmontonDTO>(0);

            mockPermitRequestService.Stub(m => m.QueryByFlocUnitAndBelow(null, null)).IgnoreArguments().Return(
                permitRequestsForTomorrow);

            mockPermitRequestService.Stub(m => m.Submit(tomorrow, permitRequestsForTomorrow, sapUser));

            job.Execute();

            mockLogger.VerifyAllExpectations();
        }


        [Test][Ignore]
        public void ShouldNotSubmitPermitThatAlreadyExistsForTheNextDay()
        {
            var job = new EdmontonSapAutoImportJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockPermitRequestService,
                mockPermitService, mockUserService, mockFlocService, mockLogger);

            var flocList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal("ED1")};

            mockFlocService.Stub(m => m.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID))
                .Return(flocList);
            var sapUser = UserFixture.CreateSAPUser();
            mockUserService.Stub(m => m.GetSAPUser()).Return(sapUser);

            var tomorrow = Clock.Now.ToDate();

            var emptyResult = new PermitRequestImportResult(new List<NotifiedEvent>(0),
                new List<PermitRequestImportRejection>(0));

            mockPermitRequestService.Stub(m => m.Import(null, null, null, null, 0))
                .IgnoreArguments()
                .Return(emptyResult);

            var importResults = new List<PermitRequestImportResult>
            {
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult
            };

            var importRequestDataList = importResults.GetProcessedWorkOrderData();
            mockPermitRequestService.Stub(
                m =>
                    m.FinalizeImport(tomorrow, tomorrow.AddDays(7), importRequestDataList,
                        importResults.GetKeysForRejectedPermitRequests(), batchId, sapUser));

            var permitRequestA =
                new PermitRequestEdmontonDTO(PermitRequestEdmontonFixture.CreateValidCompletePermitRequest());
            var permitRequestB =
                new PermitRequestEdmontonDTO(PermitRequestEdmontonFixture.CreateValidCompletePermitRequest());

            var permitRequestsForTomorrow = new List<PermitRequestEdmontonDTO> {permitRequestA, permitRequestB};

            mockPermitRequestService.Stub(m => m.QueryByFlocUnitAndBelow(null, null)).IgnoreArguments().Return(
                permitRequestsForTomorrow);

            mockPermitService.Stub(
                m =>
                    m.DoesPermitRequestEdmontonAssociationExist(new List<PermitRequestEdmontonDTO> {permitRequestA},
                        tomorrow)).Return(true);
            mockPermitService.Stub(
                m =>
                    m.DoesPermitRequestEdmontonAssociationExist(new List<PermitRequestEdmontonDTO> {permitRequestB},
                        tomorrow)).Return(false);

            mockPermitRequestService.Expect(
                m => m.Submit(tomorrow, new List<PermitRequestEdmontonDTO> {permitRequestB}, sapUser));

            job.Execute();

            mockPermitRequestService.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldSubmitOnlyCompletePermitsForTomorrow()
        {
            var job = new EdmontonSapAutoImportJob(
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                mockPermitRequestService,
                mockPermitService, mockUserService, mockFlocService, mockLogger);

            var flocList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal("ED1")};

            mockFlocService.Stub(m => m.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID))
                .Return(flocList);
            var sapUser = UserFixture.CreateSAPUser();
            mockUserService.Stub(m => m.GetSAPUser()).Return(sapUser);

            var tomorrow = Clock.Now.ToDate();

            var emptyResult = new PermitRequestImportResult(new List<NotifiedEvent>(0),
                new List<PermitRequestImportRejection>(0));

            mockPermitRequestService.Stub(m => m.Import(null, null, null, null, 0))
                .IgnoreArguments()
                .Return(emptyResult);

            var importResults = new List<PermitRequestImportResult>
            {
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult,
                emptyResult
            };

            var importRequestDataList = importResults.GetProcessedWorkOrderData();

            mockPermitRequestService.Stub(
                m =>
                    m.FinalizeImport(tomorrow, tomorrow.AddDays(7), importRequestDataList,
                        importResults.GetKeysForRejectedPermitRequests(), batchId, sapUser));


            var permitRequestA =
                new PermitRequestEdmontonDTO(PermitRequestEdmontonFixture.CreateValidCompletePermitRequest());

            var permitRequestNotComplete = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequestNotComplete.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            var permitRequestB = new PermitRequestEdmontonDTO(permitRequestNotComplete);

            var permitRequestsForTomorrow = new List<PermitRequestEdmontonDTO> {permitRequestA, permitRequestB};

            mockPermitRequestService.Stub(m => m.QueryByFlocUnitAndBelow(null, null)).IgnoreArguments().Return(
                permitRequestsForTomorrow);

            mockPermitService.Stub(m => m.DoesPermitRequestEdmontonAssociationExist(null, null))
                .IgnoreArguments()
                .Return(false);

            mockPermitRequestService.Expect(
                m => m.Submit(tomorrow, new List<PermitRequestEdmontonDTO> {permitRequestA}, sapUser));

            job.Execute();

            mockPermitRequestService.VerifyAllExpectations();
        }
    }
}