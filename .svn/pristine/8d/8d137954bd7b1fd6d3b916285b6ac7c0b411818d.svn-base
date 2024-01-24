using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Utilities;
using Com.Suncor.Olt.Remote.Wcf;
using Com.Suncor.Olt.Common.Extension;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PermitRequestFortHillsService : IPermitRequestFortHillsService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<PermitRequestFortHillsService>();

        private readonly IEditHistoryService editHistoryService;

        private readonly IPermitRequestFortHillsDao permitRequestDao;
        private readonly IPermitRequestFortHillsDTODao permitRequestDtoDao;
        private readonly IPermitRequestFortHillsSAPImportDataDao permitRequestSAPImportDataDao;

        private readonly IWorkPermitFortHillsService workPermitService;
        private readonly IUserService userService;

        private readonly ITimeService timeService;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;
        private readonly IAreaLabelDao areaLabelDao;

        private readonly WorkOrderImporter workOrderImporter;
        private readonly WorkOrderToWorkPermitRequestDataConverter<PermitRequestFortHills> workPermitRequestDataConverter;
        private readonly IWorkPermitFortHillsGroupDao groupDao;
        private readonly ISiteDao siteDao;
        private readonly IWorkPermitFortHillsService wpservice;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly IWorkPermitAutoAssignmentConfigurationService workAssignmentService;
        public PermitRequestFortHillsService()
        {
            editHistoryService = new EditHistoryService();
            workPermitService = new WorkPermitFortHillsService();
            businessCategoryService = new BusinessCategoryService();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestFortHillsDao>();
            permitRequestDtoDao = DaoRegistry.GetDao<IPermitRequestFortHillsDTODao>();
            permitRequestSAPImportDataDao = DaoRegistry.GetDao<IPermitRequestFortHillsSAPImportDataDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            craftOrTradeDao = DaoRegistry.GetDao<ICraftOrTradeDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitFortHillsGroupDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
            workAssignmentService = new WorkPermitAutoAssignmentConfigurationService();
            timeService = new TimeService();
            userService = new UserService();
            wpservice = new WorkPermitFortHillsService();
            workOrderImporter = new WorkOrderImporter(new WorkOrderImportSettings());
            workPermitRequestDataConverter = 
                new FortHillsWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);
        }

        public PermitRequestFortHillsService(IPermitRequestFortHillsDao permitRequestDao)
        {
            this.permitRequestDao = permitRequestDao;
        }

        public List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocsForTurnaround(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, false);
        }

        public List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocsForAllButTurnaround(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, true);
        }

        public List<PermitRequestFortHillsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange);
        }

        public PermitRequestFortHills QueryById(long id)
        {
            return permitRequestDao.QueryById(id);
        }

        public List<PermitRequestFortHillsDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestDtoDao.QueryByCompletenessAndGroupAndDateWithinRange(completionStatuses, groupId, date);
        }

        public List<NotifiedEvent> Insert(PermitRequestFortHills request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            PermitRequestFortHills inserted = permitRequestDao.Insert(request);
           
            editHistoryService.TakeSnapshot(inserted);
           
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestFortHillsCreate, inserted));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(PermitRequestFortHills request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            permitRequestDao.Update(request);
            
            editHistoryService.TakeSnapshot(request);
            
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestFortHillsUpdate, request));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(PermitRequestFortHills request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            permitRequestDao.Remove(request);
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestFortHillsRemove, request));
            return notifiedEvents;
        }


        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestFortHills> permitRequests, User user)
        {
            DateTime? now = null;

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (PermitRequestFortHills request in permitRequests)
            {
                if (now == null)
                {
                    now = timeService.GetTime(request.FunctionalLocation.Site.TimeZone);
                }

                if (request.RequestedStartTime != null)
                {
                    DateTime startDateTime = request.RequestedStartDate.CreateDateTime(request.RequestedStartTime);
                    SubmitPermit(workPermitDate, user, notifiedEvents, request, now.Value, startDateTime);
                    //create action item here 
                    if (request.LockBoxnumberChecked)
                        GetAIObjectToInsert(request, notifiedEvents);
                }
            }

            return notifiedEvents;
        }

        protected void GetAIObjectToInsert(PermitRequestFortHills workPermit, List<NotifiedEvent> notifiedEvents)
        {
            Site currentSite = siteDao.QueryById(Site.FORT_HILLS_ID);
            var currentTimeAtSite = timeService.GetTime(currentSite.TimeZone);
            var name = string.Format("Create a lock box for Permit Request Number - {0}", workPermit.IdValue);
            var aIDescription =
                string.Format(
                    "Create HEI Form and a lock box for equipment (equipment {0} from SAP) as per RGP0005A to ensure zero energy is achieved.", workPermit.Location);
            List<string> Sendmailto = new List<string>(0);
            List<FunctionalLocation> floc = new List<FunctionalLocation>();
            //FunctionalLocation floc = functionalLocationDao.QueryByFullHierarchy(importData.FunctionalLocation, site.IdValue);
           // List<DocumentLink> docLink = new List<DocumentLink>(0);
            var businessCategory = businessCategoryService.GetDefaultSAPWorkOrderCategory(currentSite.IdValue);
            WorkAssignment workAssignment = null;
           
            ISchedule schedule = new SingleSchedule(workPermit.RequestedStartDate, workPermit.RequestedStartTime, workPermit.RequestedEndTime, currentSite);
            floc.Add(workPermit.FunctionalLocation);
            var actionItemDefinition =
                new ActionItemDefinition(name, businessCategory, ActionItemDefinitionStatus.Approved, schedule, aIDescription.TrimOrEmpty(), DataSource.PERMIT, false, true, true, workPermit.CreatedBy, currentTimeAtSite, workPermit.CreatedBy, currentTimeAtSite, floc, new List<Common.DTO.TargetDefinitionDTO>(), new List<DocumentLink>(), OperationalMode.Normal, workAssignment, false, null, null, null, false, false, false, Sendmailto);

            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.ActionItemDefinitionCreate, service.UpdateAndInsertActionItems, workPermit, actionItemDefinition);
            notifiedEvents.AddRange(wpservice.UpdateAndInsertActionItems(workPermit,actionItemDefinition)); //|| add Action             
           // return notifiedEvents;
        }

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestFortHillsDTO> dtos, User user)
        {
            List<PermitRequestFortHills> permitRequests = new List<PermitRequestFortHills>();

            foreach (PermitRequestFortHillsDTO dto in dtos)
            {
                PermitRequestFortHills request = permitRequestDao.QueryById(dto.IdValue);
                permitRequests.Add(request);
            }

            return Submit(workPermitDate, permitRequests, user);
        }

        public List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestFortHills request, User user)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();


            if (request.IsInDatabase())
            {
                permitRequestDao.Update(request);
                // no need to add the 'update' event to our notified events list, as submitting will do that
            }
            else
            {
                PermitRequestFortHills inserted = permitRequestDao.Insert(request);
                request.Id = inserted.Id;
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestCreate, request));
            }
           
          
            editHistoryService.TakeSnapshot(request); 

            // Submit the Permit Request
           
            notifiedEvents.AddRange(Submit(workPermitDate, new List<PermitRequestFortHills> { request }, user));

            return notifiedEvents;
        }

        private void SubmitPermit(Date workPermitDate, User user, List<NotifiedEvent> notifiedEvents,
                PermitRequestFortHills request, DateTime now, DateTime startDateTime)
        {
            WorkPermitFortHills workPermit = new WorkPermitFortHills(DataSource.PERMIT_REQUEST,
                                                       PermitRequestBasedWorkPermitStatus.Requested,
                                                       request.WorkPermitType, now, user);

            workPermit.BuildPermitToSubmit(request, user, now, workPermitDate, startDateTime);

            request.LastModifiedBy = user;
            request.LastModifiedDateTime = now;
            request.LastSubmittedByUser = user;
            request.LastSubmittedDateTime = now;

            notifiedEvents.AddRange(workPermitService.InsertWithPermitRequestEdmontonAssociation(workPermit, request));
            notifiedEvents.AddRange(Update(request));
        }

        public long GetNewBatchId()
        {
            return permitRequestSAPImportDataDao.GetBatchId();
        }

        public PermitRequestImportResult Import(User user, Date from, List<FunctionalLocation> userDivisions, List<IHasPermitKey> importsFromCurrentSession, long batchId)
        {
            try
            {
                if (importsFromCurrentSession == null)
                {
                    importsFromCurrentSession = new List<IHasPermitKey>();
                }
               
                List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
                
                Set<long> plantIds = new Set<long>();
                userDivisions.ForEach(ud => plantIds.Add(ud.PlantId));

                List<WorkOrderRecordList> records = new List<WorkOrderRecordList>();
                //uncomment the code here...start
                foreach (long plantId in plantIds)
                {
                    List<WorkOrderRecordList> workOrderRecordLists = workOrderImporter.ImportWorkOrders(@from, plantId, null);
                    records.AddRange(workOrderRecordLists);
                }
                //uncomment the code here...end


                //Remove this code  start
                //12 july 2019 amit revert this sap code
                //List<WorkOrderRecordList> workOrderRecordLists = workOrderImporter.ImportWorkOrders(@from, 702, null);

                //if (workOrderRecordLists.Count > 1)
                //{
                //    workOrderRecordLists.RemoveRange(1, workOrderRecordLists.Count - 1);
                //}
                //workOrderRecordLists[0].WorkOrderDetails[0].FunctionalLocation = "FH1-P610-HTL1";
                //records.AddRange(workOrderRecordLists);
                //12 july 2019 amit revert this sap code
                //Remove this code  end
                

                logger.Debug(string.Format("FortHills Permit Import: ({0}), {1} work order records were received from SAP.", from, records.Count));
                                
                List<PermitRequestImportRejection> importRejectList;
                Site site = siteDao.QueryById(Site.FORT_HILLS_ID);
                List<PermitRequestFortHills> incomingPermitRequests = workPermitRequestDataConverter.ConvertToPermitRequests(records, user, site, out importRejectList);
                List<PermitRequestFortHillsSAPImportData> incomingEdmontonRequests = incomingPermitRequests.ConvertListToKnownSubType<PermitRequestFortHillsSAPImportData, PermitRequestFortHills>();

                logger.Debug(string.Format("FortHills Permit Import: ({0}), {1} Permit Requests were created from the SAP work orders (but have not yet been processed for insert or update)", from, incomingPermitRequests.Count));
                logger.Debug(string.Format("FortHills Permit Import: ({0}), {1} Permit Requests were rejected due to validation or other errors after being converted from the work order list. ", from, importRejectList.Count));

                // Divide up all the incoming permit requests into Turnaround vs. Normal
                //List<PermitRequestFortHillsSAPImportData> incomingTurnaroundPermits = incomingEdmontonRequests.FindAll(r => r.Group.IsTurnaround);
                List<PermitRequestFortHillsSAPImportData> incomingNormalPermitRequests = incomingEdmontonRequests; //.FindAll(r => !r.Group.IsTurnaround);

                // turnaround permits are batched in the db as opposed to being passed back and forth by the client, so we only need to remove imports for 'normal permit requests'
                RemoveImportsThatHaveAlreadyArrived(incomingNormalPermitRequests, importsFromCurrentSession);
                
                DateTime timeInFortHills = timeService.GetTime(site.TimeZone);
              //  PersistTurnaroundImportData(incomingTurnaroundPermits, batchId, timeInFortHills);

                List<PermitRequestFortHills> incomingNormalPermitsAsPermitRequests = incomingNormalPermitRequests.ConvertListToBaseType<PermitRequestFortHills, PermitRequestFortHillsSAPImportData>();
                                
                FortHillsPermitRequestPersistanceProcessor permitRequestPersistanceProcessor = new FortHillsPermitRequestPersistanceProcessor(permitRequestDao, incomingNormalPermitsAsPermitRequests);
                permitRequestPersistanceProcessor.Process();

                List<PermitRequestFortHills> updateList = permitRequestPersistanceProcessor.UpdateList;
                updateList.ForEach(r => notifiedEvents.AddRange(Update(r)));
                logger.Debug(string.Format("FortHills Permit Import: ({0}), {1} were updated.", from, updateList.Count));

                List<PermitRequestFortHills> insertList = permitRequestPersistanceProcessor.InsertList;
                SetIsCompleteFlagOnPermitRequests(insertList);
                insertList.ForEach(r => notifiedEvents.AddRange(Insert(r)));
                logger.Debug(string.Format("FortHills Permit Import: ({0}), {1} were inserted.", from, insertList.Count));

                List<IHasPermitKey> listOfWorkOrdersProcessedSuccessfully = GetListOfProcessedWorkOrders(notifiedEvents);                

                return new PermitRequestImportResult(notifiedEvents, importRejectList, listOfWorkOrdersProcessedSuccessfully);                
            }
            catch (WorkOrderSAPImportException sapImportException)
            {
                string message = string.Format(StringResources.PermitRequestImportServerError, sapImportException.HelpDeskErrorCode);
                return new PermitRequestImportResult(message);
            }
            catch (Exception e)
            {
                logger.Error("There was an unhandled exception while importing permit request data. Help desk error code: " +
                        ErrorCodes.WebMethodsPermitRequestImportUnhandledException, e);
                string message = string.Format(StringResources.PermitRequestImportServerError,
                    ErrorCodes.WebMethodsPermitRequestImportUnhandledException);
                return new PermitRequestImportResult(message);
            }
        }

        private void PersistTurnaroundImportData(List<PermitRequestFortHillsSAPImportData> incomingTurnaroundPermits, long batchId, DateTime timeInFortHills)
        {
            foreach (PermitRequestFortHillsSAPImportData item in incomingTurnaroundPermits)
            {
                item.BatchId = batchId;
                item.BatchItemCreatedAt = timeInFortHills;

                permitRequestSAPImportDataDao.Insert(item);
            }
        }

        private List<IHasPermitKey> GetListOfProcessedWorkOrders(List<NotifiedEvent> notifiedEvents)
        {
            List<IHasPermitKey> resultList = new List<IHasPermitKey>();

            foreach (NotifiedEvent notifiedEvent in notifiedEvents)
            {
                PermitRequestFortHills permitRequest = (PermitRequestFortHills) notifiedEvent.DomainObject;

                foreach (PermitRequestWorkOrderSource workOrderSource in permitRequest.WorkOrderSourceList)
                {
                    PermitKeyData data = new PermitKeyData(workOrderSource);
                    resultList.Add(data);
                }
            }

            return resultList;
        }

        private void RemoveImportsThatHaveAlreadyArrived(List<PermitRequestFortHillsSAPImportData> incomingPermitRequests, List<IHasPermitKey> importsFromCurrentSession)
        {                        
            if (importsFromCurrentSession == null || importsFromCurrentSession.Count == 0)
            {
                return;
            }

            List<PermitRequestFortHillsSAPImportData> requestsToRemove = new List<PermitRequestFortHillsSAPImportData>();

            foreach (PermitRequestFortHillsSAPImportData incomingPermitRequest in incomingPermitRequests)
            {
                IHasPermitKey alreadyImported = importsFromCurrentSession.Find(ifcs => ifcs.MatchesByPermitKey(incomingPermitRequest));

                if (alreadyImported != null)
                {
                    requestsToRemove.Add(incomingPermitRequest);
                }
            }

            foreach (PermitRequestFortHillsSAPImportData requestToRemove in requestsToRemove)
            {
                incomingPermitRequests.Remove(requestToRemove);
            }
        }

        private void SetIsCompleteFlagOnPermitRequests(List<PermitRequestFortHills> permitRequestList)
        {
            foreach (PermitRequestFortHills request in permitRequestList)
            {
                request.CompletionStatus = request.DetectIsComplete();
            }
        }

        public FortHillsPermitRequestPostFinalizeResult FinalizeImport(Date from, Date to, List<IHasPermitKey> incomingWorkOrders, List<IHasPermitKey> rejectList, long batchId, User user)
        {
            Site FortHillsSite = siteDao.QueryById(Site.FORT_HILLS_ID);
            DateTime timeInFortHills = timeService.GetTime(FortHillsSite.TimeZone);

            int numberOfTurnaroundItemsInsertedOrUpdated = 0;

            List<NotifiedEvent> notifiedEventsFromMissingExpectedWorkOrders = HandleNonTurnaroundImports(@from, to, incomingWorkOrders, rejectList, timeInFortHills);
           // List<NotifiedEvent> notifiedEventsFromTurnaroundImport = HandleTurnaroundImports(@from, to, batchId, user, timeInFortHills, ref numberOfTurnaroundItemsInsertedOrUpdated);

           // notifiedEventsFromMissingExpectedWorkOrders.AddRange(notifiedEventsFromTurnaroundImport);

            FortHillsPermitRequestPostFinalizeResult result = new FortHillsPermitRequestPostFinalizeResult(notifiedEventsFromMissingExpectedWorkOrders, numberOfTurnaroundItemsInsertedOrUpdated);
            return result;
        }

        private List<NotifiedEvent> HandleTurnaroundImports(Date fromDate, Date toDate, long batchId, User user, DateTime timeInFortHills, ref int numberInsertedOrUpdated)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            List<PermitRequestFortHillsSAPImportData> data = permitRequestSAPImportDataDao.QueryByBatchId(batchId);
            data = PermitRequestFortHillsSAPImportData.RemoveDuplicateTurnaroundImports(data);

            data.ForEach(item => item.SetCreatedInfo(user, timeInFortHills));
            data.ForEach(item => item.CompletionStatus = item.DetectIsComplete());
            
            List<PermitRequestFortHills> incomingList = permitRequestDao.QueryByDateRangeAndDataSource(fromDate, toDate, DataSource.SAP);
            List<PermitRequestFortHills> allExistingPermitRequests = incomingList.FindAll(r => r.Group.IsTurnaround);

            AbstractMergingPermitRequestPersistanceProcessor processor = 
                new EdmontonMergingPermitRequestPersistenceProcessor(allExistingPermitRequests.ConvertAll(i => (IMergeablePermitRequest) i), data.ConvertAll(d => (ISAPImportData) d), timeInFortHills, user);

            processor.Process();

            List<PermitRequestFortHills> insertList = processor.InsertList.ConvertAll(i => (PermitRequestFortHills) i);
            SetIsCompleteFlagOnPermitRequests(insertList);
            insertList.ForEach(r => notifiedEvents.AddRange(Insert(r)));
            logger.Debug(string.Format("FortHills Permit Import: {0} were inserted.", insertList.Count));

            List<PermitRequestFortHills> updateList = processor.UpdateList.ConvertAll(i => (PermitRequestFortHills)i);
            SetIsCompleteFlagOnPermitRequests(updateList);
            updateList.ForEach(r => notifiedEvents.AddRange(Update(r)));
            logger.Debug(string.Format("FortHills Turnaround Permit Import: {0} were updated.", updateList.Count));

            List<PermitRequestFortHills> removeList = processor.DeleteList.ConvertAll(i => (PermitRequestFortHills)i);
            removeList.ForEach(r => notifiedEvents.AddRange(Remove(r)));
            logger.Debug(string.Format("FortHills Turnaround Permit Import: {0} were removed.", removeList.Count));

            permitRequestSAPImportDataDao.Delete(batchId);

            numberInsertedOrUpdated = processor.NumberOfPermitRequestsProcessed;

            return notifiedEvents;
        }
      
        private List<NotifiedEvent> HandleNonTurnaroundImports(Date @from, Date to, List<IHasPermitKey> incomingWorkOrders, List<IHasPermitKey> rejectList, DateTime timeInFortHills)
        {            
            List<PermitRequestFortHills> incomingList = permitRequestDao.QueryByDateRangeAndDataSource(@from, to, DataSource.SAP);
            List<PermitRequestFortHills> permitRequests = incomingList.FindAll(r => !r.Group.IsTurnaround);


            List<PermitRequestFortHills> itemsToRemove = PermitRequestFortHills.BuildImportRemovalList(permitRequests, incomingWorkOrders, rejectList);

            List<PermitRequestFortHills> permitRequestsToRemove = new List<PermitRequestFortHills>();
            List<PermitRequestFortHills> permitRequestsOnWhichToUpdateTheStatus = new List<PermitRequestFortHills>();

            User sapUser = userService.GetSAPUser();

            foreach (PermitRequestFortHills request in itemsToRemove)
            {                
                if (request.IsSubmitted)
                {
                    request.LastModifiedDateTime = timeInFortHills;
                    request.LastModifiedBy = sapUser;
                    request.CompletionStatus = PermitRequestCompletionStatus.Incomplete;

                    DateTime? result = workPermitService.QueryLatestExpiryDateByPermitRequestId(request.IdValue);
                    if (result != null)
                    {
                        request.EndDate = new Date(result.Value);
                    }

                    permitRequestsOnWhichToUpdateTheStatus.Add(request);
                }
                else
                {
                    permitRequestsToRemove.Add(request);
                }
            }

            List<NotifiedEvent> notifiedEventsFromMissingExpectedWorkOrders = new List<NotifiedEvent>();

            permitRequestsToRemove.ForEach(r => notifiedEventsFromMissingExpectedWorkOrders.AddRange(Remove(r)));
            logger.Debug(string.Format("FortHills Permit Import: {0} permits were removed because they were expected but weren't received.", permitRequestsToRemove.Count));    
                      
            permitRequestsOnWhichToUpdateTheStatus.ForEach(r => notifiedEventsFromMissingExpectedWorkOrders.AddRange(Update(r)));
            logger.Debug(string.Format("FortHills Permit Import: {0} permits had their status updated because they were expected but weren't received.", permitRequestsOnWhichToUpdateTheStatus.Count));

            return notifiedEventsFromMissingExpectedWorkOrders;
        }

        public DateTime? GetLastImportDateTime()
        {
            DateTime? lastImportDateTime = permitRequestDao.QueryLastImportDateTime();

            if (lastImportDateTime != null)
            {
                return lastImportDateTime.Value.GetNetworkPortable();
            }

            return null;
        }

        //public List<PermitRequestFortHills> QueryByFormGN59Id(long id)
        //{
        //    return permitRequestDao.QueryByFormGN59Id(id);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN6Id(long id)
        //{
        //    return permitRequestDao.QueryByFormGN6Id(id);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN7Id(long id)
        //{
        //    return permitRequestDao.QueryByFormGN7Id(id);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN24Id(long id)
        //{
        //    return permitRequestDao.QueryByFormGN24Id(id);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN75AId(long id)
        //{
        //    return permitRequestDao.QueryByFormGN75AId(id);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN1Id(long id)
        //{
        //    return permitRequestDao.QueryByFormGN1Id(id);
        //}
    }
}
