﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.Integration;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class FormEdmontonServiceTest
    {
        private IEdmontonSwipeCardReader cardSwipeReader;
        private IEditHistoryService editHistoryService;
        private EventQueueTestWrapper eventQueue;
        private IFormEdmontonDTODao formDtoDao;
        private IFormEdmontonService formEdmontonService;
        private IFormGN1Dao formGN1Dao;

        private IFormGN24Dao formGN24Dao;
        private IFormGN59Dao formGN59Dao;
        private IFormGN6Dao formGN6Dao;
        private IFormGN75ADao formGN75ADao;
        private IFormGN75BDao formGN75BDao;
        private IFormGN7Dao formGN7Dao;
        private IFormOP14Dao formOP14Dao;

        ////ayman sarnia test
        //private IFormOP14SarniaDao formop14SarniaDao;

        private IPermitAssessmentDao permitAssessmentDao;
        private IPermitAssessmentDTODao permitAssessmentDTODao;
        private IFormTemplateDao formTemplateDao;
        private IFormEdmontonGN1DTODao gn1DTODao;
        private IFormEdmontonGN24DTODao gn24DTODao;
        private IFormEdmontonGN6DTODao gn6DTODao;
        private IFormEdmontonGN75ADTODao gn75ADTODao;
        private IFormEdmontonGN75BDTODao gn75BDTODao;
        private ILubesAlarmDisableDao lubesAlarmDisableDao;
        private ILubesAlarmDisableFormDTODao lubesAlarmDisableFormDTODao;
        private IFormLubesCsdDao lubesCsdDao;
        private ILubesCsdFormDTODao lubesCsdFormDTODao;
        private IMontrealCsdDTODao montrealCsdDTODao;
        private IMontrealCsdDao montrealCsdDao;
        //DMND0011225 CSD for WBR
        private IGenericCsdDTODao genericCsdDTODao;
        private IGenericCsdDao genericCsdDao;

        private IOnPremisePersonnelDtoDao onPremisePersonnelDtoDao;
        private IOnPremisePersonnelService onPremisePersonnelService;
        private IFormEdmontonOP14DTODao op14DtoDao;
        private IOvertimeFormDao overtimeFormDao;
        private IOvertimeFormDTODao overtimeFormDtoDao;
        private IPermitRequestEdmontonService permitRequestEdmontonService;

        private IShiftPatternService shiftPatternService;
        private ISiteService siteService;
        private ITimeService timeService;
        private IUserService userService;
        private IWorkPermitEdmontonService workPermitEdmontonService;

        private IDocumentSuggestionDao documentSuggestionDao;
        private IDocumentSuggestionDTODao documentSuggestionDTODao;

        private IProcedureDeviationDao procedureDeviationDao;
        private IProcedureDeviationDTODao procedureDeviationDTODao;

        private IFormGenericTemplateDao opGenericTemplateDao; //generic template - mangesh

   //RITM0268131 - mangesh
        private ITemporaryInstallationsMudsDao tempInstallationMudsDao;
        private ITemporaryInstallationsMudsDTODao tempInstallationMudsDTODao;


        [SetUp]
        public void SetUp()
        {
            eventQueue = new EventQueueTestWrapper();

            formGN7Dao = MockRepository.GenerateStub<IFormGN7Dao>();
            formGN59Dao = MockRepository.GenerateStub<IFormGN59Dao>();
            formOP14Dao = MockRepository.GenerateStub<IFormOP14Dao>();
            ////ayman sarnia test
            //formop14SarniaDao = MockRepository.GenerateStub<IFormOP14SarniaDao>();

            formGN24Dao = MockRepository.GenerateStub<IFormGN24Dao>();
            formGN6Dao = MockRepository.GenerateStub<IFormGN6Dao>();
            formGN75ADao = MockRepository.GenerateStub<IFormGN75ADao>();
            formGN75BDao = MockRepository.GenerateStub<IFormGN75BDao>();
            formGN1Dao = MockRepository.GenerateStub<IFormGN1Dao>();
            overtimeFormDao = MockRepository.GenerateStub<IOvertimeFormDao>();

            formDtoDao = MockRepository.GenerateStub<IFormEdmontonDTODao>();
            op14DtoDao = MockRepository.GenerateStub<IFormEdmontonOP14DTODao>();
            permitAssessmentDao = MockRepository.GenerateStub<IPermitAssessmentDao>();
            permitAssessmentDTODao = MockRepository.GenerateStub<IPermitAssessmentDTODao>();
            gn24DTODao = MockRepository.GenerateStub<IFormEdmontonGN24DTODao>();
            gn6DTODao = MockRepository.GenerateStub<IFormEdmontonGN6DTODao>();

            gn75ADTODao = MockRepository.GenerateStub<IFormEdmontonGN75ADTODao>();
            gn75BDTODao = MockRepository.GenerateStub<IFormEdmontonGN75BDTODao>();

            gn1DTODao = MockRepository.GenerateStub<IFormEdmontonGN1DTODao>();
            overtimeFormDtoDao = MockRepository.GenerateStub<IOvertimeFormDTODao>();
            onPremisePersonnelDtoDao = MockRepository.GenerateStub<IOnPremisePersonnelDtoDao>();

            formTemplateDao = MockRepository.GenerateStub<IFormTemplateDao>();
            timeService = MockRepository.GenerateStub<ITimeService>();
            userService = MockRepository.GenerateStub<IUserService>();

            lubesCsdDao = MockRepository.GenerateStub<IFormLubesCsdDao>();
            lubesCsdFormDTODao = MockRepository.GenerateStub<ILubesCsdFormDTODao>();

            lubesAlarmDisableDao = MockRepository.GenerateStub<ILubesAlarmDisableDao>();
            lubesAlarmDisableFormDTODao = MockRepository.GenerateStub<ILubesAlarmDisableFormDTODao>();

            //DMND0011225 CSD for WBR
            genericCsdDao = MockRepository.GenerateStub<IGenericCsdDao>();
            genericCsdDTODao = MockRepository.GenerateStub<IGenericCsdDTODao>();

            montrealCsdDao = MockRepository.GenerateStub<IMontrealCsdDao>();
            montrealCsdDTODao = MockRepository.GenerateStub<IMontrealCsdDTODao>();
            editHistoryService = MockRepository.GenerateStub<IEditHistoryService>();

            permitRequestEdmontonService = MockRepository.GenerateMock<IPermitRequestEdmontonService>();
            workPermitEdmontonService = MockRepository.GenerateMock<IWorkPermitEdmontonService>();

            onPremisePersonnelService = MockRepository.GenerateMock<IOnPremisePersonnelService>();
            cardSwipeReader = MockRepository.GenerateStub<IEdmontonSwipeCardReader>();

            shiftPatternService = MockRepository.GenerateStub<IShiftPatternService>();
            siteService = MockRepository.GenerateStub<ISiteService>();

            documentSuggestionDao = MockRepository.GenerateStub<IDocumentSuggestionDao>();
            documentSuggestionDTODao = MockRepository.GenerateStub<IDocumentSuggestionDTODao>();

            procedureDeviationDao = MockRepository.GenerateStub<IProcedureDeviationDao>();
            procedureDeviationDTODao = MockRepository.GenerateStub<IProcedureDeviationDTODao>();

            opGenericTemplateDao = MockRepository.GenerateStub<IFormGenericTemplateDao>(); //generic template - mangesh

 //RITM0268131 - mangesh
            tempInstallationMudsDao = MockRepository.GenerateStub<ITemporaryInstallationsMudsDao>();
            tempInstallationMudsDTODao = MockRepository.GenerateStub<ITemporaryInstallationsMudsDTODao>();
            formEdmontonService = new FormEdmontonService(formGN7Dao,
                formGN59Dao,
                formOP14Dao,
               
                permitAssessmentDao, 
                permitAssessmentDTODao, 
                formGN24Dao,
                formGN6Dao,
                formGN75ADao,
                formGN75BDao,
                formGN1Dao,
                overtimeFormDao,
                formDtoDao,
                op14DtoDao,
                gn24DTODao,
                gn6DTODao,
                gn75ADTODao,
                gn75BDTODao,
                gn1DTODao,
                overtimeFormDtoDao,
                lubesCsdDao,
                lubesCsdFormDTODao,
                lubesAlarmDisableDao,
                lubesAlarmDisableFormDTODao,
                onPremisePersonnelDtoDao,
                formTemplateDao,
                editHistoryService,
                permitRequestEdmontonService,
                workPermitEdmontonService,
                timeService,
                userService,
                null,
                onPremisePersonnelService,
                cardSwipeReader,
                shiftPatternService,
                siteService,
                montrealCsdDao,
                montrealCsdDTODao,
                documentSuggestionDao,
                documentSuggestionDTODao,
                procedureDeviationDao,
                procedureDeviationDTODao,
                opGenericTemplateDao,   //generic template add opGenericTemplateDao - mangesh
 tempInstallationMudsDao, //RITM0268131 - mangesh
                tempInstallationMudsDTODao, genericCsdDao, genericCsdDTODao);        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
        }

        [Ignore] [Test]
        public void ShouldDetermineIfAGn75AFormInTheInputListIsAssocaitedToAnIssuedPermit()
        {
            IWorkPermitEdmontonService workPermitEdmontonServiceStub = new WorkPermitEdmontonServiceStub();

            IFormEdmontonService formEdmontonServiceWithStubForThisTest
                = new FormEdmontonService(formGN7Dao,
                    formGN59Dao,
                    formOP14Dao,
                    
                    permitAssessmentDao, 
                    permitAssessmentDTODao, 
                    formGN24Dao,
                    formGN6Dao,
                    formGN75ADao,
                    formGN75BDao,
                    formGN1Dao,
                    overtimeFormDao,
                    formDtoDao,
                    op14DtoDao,
                    gn24DTODao,
                    gn6DTODao,
                    gn75ADTODao,
                    gn75BDTODao,
                    gn1DTODao,
                    overtimeFormDtoDao,
                    lubesCsdDao,
                    lubesCsdFormDTODao,
                    lubesAlarmDisableDao,
                    lubesAlarmDisableFormDTODao,
                    onPremisePersonnelDtoDao,
                    formTemplateDao,
                    editHistoryService,
                    permitRequestEdmontonService,
                    workPermitEdmontonServiceStub,
                    timeService,
                    userService,
                    null,
                    onPremisePersonnelService,
                    cardSwipeReader,
                    shiftPatternService,
                    siteService, montrealCsdDao, 
                    montrealCsdDTODao,
                    documentSuggestionDao,
                    documentSuggestionDTODao,
                    procedureDeviationDao,
                    procedureDeviationDTODao,
                    opGenericTemplateDao,  // generic template added opGenericTemplateDao - mangesh
 tempInstallationMudsDao, //RITM0268131 - mangesh
                    tempInstallationMudsDTODao, genericCsdDao, genericCsdDTODao);
            {
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).ClearMap();
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(1,
                    new List<WorkPermitEdmontonDTO>());
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(2,
                    new List<WorkPermitEdmontonDTO>());
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(3,
                    new List<WorkPermitEdmontonDTO>());

                Assert.IsFalse(
                    formEdmontonServiceWithStubForThisTest.GN75AIsAssociatedToAnIssuedWorkPermit(new List<long>
                    {
                        1,
                        2,
                        3
                    }));
            }
            {
                var permitA =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Complete);
                permitA.Id = 10;
                var permitB =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Pending);
                permitB.Id = 11;
                var permitC =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Pending);
                permitC.Id = 12;

                var dtoA = new WorkPermitEdmontonDTO(permitA);
                var dtoB = new WorkPermitEdmontonDTO(permitB);
                var dtoC = new WorkPermitEdmontonDTO(permitC);

                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).ClearMap();
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(1,
                    new List<WorkPermitEdmontonDTO>());
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(2,
                    new List<WorkPermitEdmontonDTO> {dtoA, dtoB});
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(3,
                    new List<WorkPermitEdmontonDTO> {dtoC});

                Assert.IsFalse(
                    formEdmontonServiceWithStubForThisTest.GN75AIsAssociatedToAnIssuedWorkPermit(new List<long>
                    {
                        1,
                        2,
                        3
                    }));
            }
            {
                var permitA =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Complete);
                permitA.Id = 10;
                var permitB =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Issued);
                permitB.Id = 11;
                var permitC =
                    WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                        PermitRequestBasedWorkPermitStatus.Pending);
                permitC.Id = 12;

                var dtoA = new WorkPermitEdmontonDTO(permitA);
                var dtoB = new WorkPermitEdmontonDTO(permitB);
                var dtoC = new WorkPermitEdmontonDTO(permitC);

                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).ClearMap();
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(1,
                    new List<WorkPermitEdmontonDTO>());
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(2,
                    new List<WorkPermitEdmontonDTO> {dtoA, dtoB});
                ((WorkPermitEdmontonServiceStub) workPermitEdmontonServiceStub).SetResponse(3,
                    new List<WorkPermitEdmontonDTO> {dtoC});
                Assert.IsTrue(
                    formEdmontonServiceWithStubForThisTest.GN75AIsAssociatedToAnIssuedWorkPermit(new List<long>
                    {
                        1,
                        2,
                        3
                    }));
            }
        }

        [Ignore] [Test]
        public void ShouldSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft_GN24()
        {
            RunTestForSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft<FormGN24>(
                (flocs, time, toTime) => FormGN24Fixture.CreateForInsert(flocs, time, toTime, FormStatus.Draft));
        }

        [Ignore] [Test]
        public void ShouldSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft_GN59()
        {
            RunTestForSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft<FormGN59>(
                (flocs, time, toTime) => FormGN59Fixture.CreateForInsert(flocs, time, toTime, FormStatus.Draft));
        }

        [Ignore] [Test]
        public void ShouldSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft_GN6()
        {
            RunTestForSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft<FormGN6>(
                (flocs, time, toTime) => FormGN6Fixture.CreateForInsert(flocs, time, toTime, FormStatus.Draft));
        }

        private delegate BaseEdmontonForm CreateFormForInsert(
            List<FunctionalLocation> flocs, DateTime fromTime, DateTime toTime);

        // This test is so time-consuming to write that I'm procrastinating it.
        //[Ignore] [Test]
        //public void ShouldRevalidateAssociatedPermitsIfTheFormGetsApproved_GN24()
        //{
        //    RunTestForRevalidatingPermitsandPermitRequestsIfAnAssociatedFormGetsApproved<FormGN24>((flocs, time, toTime) => FormGN24Fixture.CreateForInsert(flocs, time, toTime, FormStatus.Approved));
        //}

        // This tests what happens when a form was approved and then flips to draft.
        private void RunTestForSetAssociatedPermitsToRequestedStateIfTheyArePendingAndTheFormGoesToDraft<T>(
            CreateFormForInsert createFormDelegate)
            where T : BaseEdmontonForm
        {
            const int FORM_ID = 42;
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var flocs = new List<FunctionalLocation> {floc};

            var fromTime = new DateTime(2013, 10, 22);
            var toTime = new DateTime(2013, 10, 23);

            var form = (T) createFormDelegate(flocs, fromTime, toTime);
            form.Id = FORM_ID;

            // Work Permit setup
            {
                // this one should change to Requested
                var matchingWorkPermit_Pending = WorkPermitEdmontonFixture.CreateForInsert(floc);
                matchingWorkPermit_Pending.Id = 1;
                matchingWorkPermit_Pending.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

                // this one shouldn't change. Only "Pending" permits change status.
                var matchingWorkPermit_Requested = WorkPermitEdmontonFixture.CreateForInsert(floc);
                matchingWorkPermit_Requested.Id = 2;
                matchingWorkPermit_Requested.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Incomplete;

                var permits = new List<WorkPermitEdmonton> {matchingWorkPermit_Pending, matchingWorkPermit_Requested};
                StubWorkPermitEdmontonServiceQueryByFormId(typeof (T), FORM_ID, permits);

                var notifiedEvent = new NotifiedEvent(ApplicationEvent.WorkPermitEdmontonUpdate,
                    matchingWorkPermit_Pending);

                workPermitEdmontonService.Expect(
                    mock =>
                        mock.Update(
                            Arg<WorkPermitEdmonton>.Matches(
                                wpe =>
                                    wpe.Id == 1 &&
                                    wpe.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Requested))))
                    .Return(new List<NotifiedEvent> {notifiedEvent});
            }

            // Permit request setup
            {
                // P4 is turnaround, so the status of this permit should change to "For Review"
                var turnaroundPermitRequest_Complete = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL,
                    floc,
                    WorkPermitEdmontonGroupFixture.CreateP4());
                turnaroundPermitRequest_Complete.CompletionStatus = PermitRequestCompletionStatus.Complete;

                // P1 is not turnaround, so the status of this permit should change to "Incomplete"
                var runningUnitPermitRequest_Complete = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL,
                    floc,
                    WorkPermitEdmontonGroupFixture.CreateP1());
                runningUnitPermitRequest_Complete.CompletionStatus = PermitRequestCompletionStatus.Complete;

                var requests = new List<PermitRequestEdmonton>
                {
                    turnaroundPermitRequest_Complete,
                    runningUnitPermitRequest_Complete
                };
                StubPermitRequestEdmontonServiceQueryByFormId(typeof (T), FORM_ID, requests);

                {
                    var notifiedEvent = new NotifiedEvent(ApplicationEvent.PermitRequestEdmontonUpdate,
                        turnaroundPermitRequest_Complete);
                    permitRequestEdmontonService.Expect(
                        mock =>
                            mock.Update(
                                Arg<PermitRequestEdmonton>.Matches(
                                    wpe => wpe.CompletionStatus.Equals(PermitRequestCompletionStatus.ForReview))))
                        .Return(new List<NotifiedEvent> {notifiedEvent});
                }

                {
                    var notifiedEvent = new NotifiedEvent(ApplicationEvent.PermitRequestEdmontonUpdate,
                        runningUnitPermitRequest_Complete);
                    permitRequestEdmontonService.Expect(
                        mock =>
                            mock.Update(
                                Arg<PermitRequestEdmonton>.Matches(
                                    wpe => wpe.CompletionStatus.Equals(PermitRequestCompletionStatus.Incomplete))))
                        .Return(new List<NotifiedEvent> {notifiedEvent});
                }
            }

            CallUpdateOnForm(typeof (T), form);
            workPermitEdmontonService.VerifyAllExpectations();
            permitRequestEdmontonService.VerifyAllExpectations();
        }

        private void StubWorkPermitEdmontonServiceQueryByFormId(Type formType, long formIdToQuery,
            List<WorkPermitEdmonton> permitsToReturn)
        {
            if (formType == typeof (FormGN59))
            {
                workPermitEdmontonService.Stub(mock => mock.QueryByFormGN59Id(formIdToQuery)).Return(permitsToReturn);
            }
            else if (formType == typeof (FormGN24))
            {
                workPermitEdmontonService.Stub(mock => mock.QueryByFormGN24Id(formIdToQuery)).Return(permitsToReturn);
            }
            else if (formType == typeof (FormGN6))
            {
                workPermitEdmontonService.Stub(mock => mock.QueryByFormGN6Id(formIdToQuery)).Return(permitsToReturn);
            }
            else
            {
                throw new Exception("Add your FormType here");
            }
        }

        private void StubPermitRequestEdmontonServiceQueryByFormId(Type formType, long formIdToQuery,
            List<PermitRequestEdmonton> requestsToReturn)
        {
            if (formType == typeof (FormGN59))
            {
                permitRequestEdmontonService.Stub(mock => mock.QueryByFormGN59Id(formIdToQuery))
                    .Return(requestsToReturn);
            }
            else if (formType == typeof (FormGN24))
            {
                permitRequestEdmontonService.Stub(mock => mock.QueryByFormGN24Id(formIdToQuery))
                    .Return(requestsToReturn);
            }
            else if (formType == typeof (FormGN6))
            {
                permitRequestEdmontonService.Stub(mock => mock.QueryByFormGN6Id(formIdToQuery)).Return(requestsToReturn);
            }
            else
            {
                throw new Exception("Add your FormType here");
            }
        }

        private void CallUpdateOnForm(Type formType, BaseEdmontonForm form)
        {
            if (formType == typeof (FormGN59))
            {
                formEdmontonService.UpdateGN59((FormGN59) form, null);
            }
            else if (formType == typeof (FormGN24))
            {
                formEdmontonService.UpdateGN24((FormGN24) form, null);
            }
            else if (formType == typeof (FormGN6))
            {
                formEdmontonService.UpdateGN6((FormGN6) form, null);
            }
            else
            {
                throw new Exception("Add your FormType here");
            }
        }

        private class WorkPermitEdmontonServiceStub : IWorkPermitEdmontonService
        {
            private readonly Dictionary<long, List<WorkPermitEdmontonDTO>> dtoListMap =
                new Dictionary<long, List<WorkPermitEdmontonDTO>>();

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN75AId(long id)
            {
                return dtoListMap[id];
            }

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN1Id(long id)
            {
                return new List<WorkPermitEdmontonDTO>();
            }

            public List<NotifiedEvent> Insert(WorkPermitEdmonton workPermit)
            {
                return null;
            }

            public List<NotifiedEvent> InsertMergePermit(WorkPermitEdmonton workPermit, List<long> mergeSourceIds)
            {
                return null;
            }

            public WorkPermitEdmonton QueryById(long id)
            {
                return null;
            }

            public DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId)
            {
                return null;
            }

            public IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet flocSet)
            {
                return null;
            }

            public IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTurnaround(Range<Date> dateRange,
                RootFlocSet flocSet)
            {
                return null;
            }

            public IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForAllButTurnaround(Range<Date> dateRange,
                RootFlocSet rootFlocSet)
            {
                return null;
            }

            public List<NotifiedEvent> Update(WorkPermitEdmonton workPermit)
            {
                return null;
            }

            public WorkPermitEdmonton QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitEdmonton permit)
            {
                return null;
            }

            public List<NotifiedEvent> InsertWithPermitRequestEdmontonAssociation(WorkPermitEdmonton workPermit,
                PermitRequestEdmonton request)
            {
                return null;
            }

            public bool DoesPermitRequestEdmontonAssociationExist(List<PermitRequestEdmontonDTO> submittedRequests,
                Date workPermitStartDate)
            {
                return false;
            }

            public List<NotifiedEvent> Remove(WorkPermitEdmonton permit)
            {
                return null;
            }

            public List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitEdmonton> workPermits,
                Dictionary<long, Log> permitIdToAssociatedLogMap)
            {
                return null;
            }

            public List<WorkPermitEdmontonGroup> QueryAllGroups()
            {
                return null;
            }

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN59Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN7Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN24Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmontonDTO> QueryDtosByFormGN6Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN59Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN7Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN24Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN75AId(long id)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN6Id(long id)
            {
                return null;
            }

            public List<WorkPermitEdmontonHazardDTO> QueryByFlocsAndStatuses(IFlocSet flocSet,
                List<PermitRequestBasedWorkPermitStatus> statuses)
            {
                return null;
            }

            public List<WorkPermitEdmonton> QueryByFormGN1Id(long id)
            {
                return null;
            }

            public void ClearMap()
            {
                dtoListMap.Clear();
            }

            public void SetResponse(long id, List<WorkPermitEdmontonDTO> dtos)
            {
                dtoListMap.Add(id, dtos);
            }

            //Mukesh -DMND0010609-OLT - Work permit Scan and Index
            public void InsertWorkpermitScan(WorkpermitScan Scan)
            {
               
            }

            public List<WorkpermitScan> GetWorkpermitScan(string WorkpermitId, int SiteId)
            {
                return new List<WorkpermitScan>();
            }

            public List<ScanDocumentType> GetWorkPermitDocumentType(long siteId)
            {
                return new List<ScanDocumentType>();
            }
            public ScanCOnfiguration GetScanConfiguration(long siteId, string userlogin)
            {
                return new ScanCOnfiguration();
            }


            public int isPermitnumberExist(long siteId, string @PermitNumber)
            {
                return 0;
            }
            public List<string> GetAutoSearchWorkpermit(long siteid)
            {
                return new List<string>();
            }
            //End Mukesh -DMND0010609-OLT - Work permit Scan and Index


            public IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRange, RootFlocSet flocSet, string username)
            {
                return null;
            }


            public WorkPermitEdmonton QueryByIdTemplate(long id, string templateName, string categories)
            {
                return null;
            }


            public List<NotifiedEvent> RemoveTemplate(WorkPermitEdmonton permit)
            {
                return null;
            }


            public List<NotifiedEvent> UpdateTemplate(WorkPermitEdmonton workPermit)
            {
                return null;
            }
        }
    }

    public class OnPremisePersonnelServiceTest
    {
    }
}