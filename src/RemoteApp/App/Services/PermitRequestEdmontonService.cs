﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
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
    public class PermitRequestEdmontonService : IPermitRequestEdmontonService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<PermitRequestEdmontonService>();

        private readonly IEditHistoryService editHistoryService;

        private readonly IPermitRequestEdmontonDao permitRequestDao;
        private readonly IPermitRequestEdmontonDTODao permitRequestDtoDao;
        private readonly IPermitRequestEdmontonSAPImportDataDao permitRequestSAPImportDataDao;

        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly IUserService userService;

        private readonly ITimeService timeService;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;
        private readonly IAreaLabelDao areaLabelDao;

        private readonly WorkOrderImporter workOrderImporter;
        private readonly WorkOrderToWorkPermitRequestDataConverter<PermitRequestEdmonton> workPermitRequestDataConverter;
        private readonly IWorkPermitEdmontonGroupDao groupDao;
        private readonly ISiteDao siteDao;
        
        public PermitRequestEdmontonService()
        {
            editHistoryService = new EditHistoryService();
            workPermitService = new WorkPermitEdmontonService();

            permitRequestDao = DaoRegistry.GetDao<IPermitRequestEdmontonDao>();
            permitRequestDtoDao = DaoRegistry.GetDao<IPermitRequestEdmontonDTODao>();
            permitRequestSAPImportDataDao = DaoRegistry.GetDao<IPermitRequestEdmontonSAPImportDataDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            craftOrTradeDao = DaoRegistry.GetDao<ICraftOrTradeDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();

            timeService = new TimeService();
            userService = new UserService();

            workOrderImporter = new WorkOrderImporter(new WorkOrderImportSettings());
            workPermitRequestDataConverter = 
                new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);
        }

        public PermitRequestEdmontonService(IPermitRequestEdmontonDao permitRequestDao)
        {
            this.permitRequestDao = permitRequestDao;
        }

        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTurnaround(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, false);
        }

        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForAllButTurnaround(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, true);
        }

        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(IFlocSet flocSet, DateRange dateRange, string username)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocsForTemplate(flocSet, dateRange, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, true, username);
        }

        

        public List<PermitRequestEdmontonDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange);
        }

        public PermitRequestEdmonton QueryById(long id)
        {
            return permitRequestDao.QueryById(id);
        }

        public List<PermitRequestEdmontonDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestDtoDao.QueryByCompletenessAndGroupAndDateWithinRange(completionStatuses, groupId, date);
        }

        public List<NotifiedEvent> Insert(PermitRequestEdmonton request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            PermitRequestEdmonton inserted = permitRequestDao.Insert(request);
            editHistoryService.TakeSnapshot(inserted);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestEdmontonCreate, inserted));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(PermitRequestEdmonton request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            if (request.IsTemplate)
            {
                permitRequestDao.InsertTemplate(request);
                 
            }
            else
            {
                permitRequestDao.Update(request);
                editHistoryService.TakeSnapshot(request); 
            }
           
            
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestEdmontonUpdate, request));
            return notifiedEvents;
        }

        public PermitRequestEdmonton QueryByIdTemplate(long id, string templateName, string categories)
        {
            return permitRequestDao.QueryByIdTemplateEdmonton(id, templateName, categories);
        }
        

        public List<NotifiedEvent> Remove(PermitRequestEdmonton request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            permitRequestDao.Remove(request);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestEdmontonRemove, request));
            return notifiedEvents;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(PermitRequestEdmonton workPermit)
        {
            permitRequestDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestEdmontonRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(PermitRequestEdmonton workPermit)
        {
            if (workPermit.IsTemplate)
            {
                permitRequestDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestEdmontonUpdate, workPermit));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestEdmonton> permitRequests, User user)
        {
            DateTime? now = null;

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (PermitRequestEdmonton request in permitRequests)
            {
                if (now == null)
                {
                    now = timeService.GetTime(request.FunctionalLocation.Site.TimeZone);
                }

                if (request.RequestedStartTimeDay != null)
                {
                    DateTime startDateTime = request.RequestedStartDate.CreateDateTime(request.RequestedStartTimeDay);
                    SubmitPermit(workPermitDate, user, notifiedEvents, request, now.Value, startDateTime);
                }

                if (request.RequestedStartTimeNight != null)
                {
                    DateTime startDateTime = request.RequestedStartDate.CreateDateTime(request.RequestedStartTimeNight);
                    SubmitPermit(workPermitDate, user, notifiedEvents, request, now.Value, startDateTime);
                }
            }

            return notifiedEvents;
        }

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestEdmontonDTO> dtos, User user)
        {
            List<PermitRequestEdmonton> permitRequests = new List<PermitRequestEdmonton>();

            foreach (PermitRequestEdmontonDTO dto in dtos)
            {
                PermitRequestEdmonton request = permitRequestDao.QueryById(dto.IdValue);
                permitRequests.Add(request);
            }

            return Submit(workPermitDate, permitRequests, user);
        }

        public List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestEdmonton request, User user)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();


            if (request.IsInDatabase())
            {
                permitRequestDao.Update(request);
                // no need to add the 'update' event to our notified events list, as submitting will do that
            }
            else
            {
                PermitRequestEdmonton inserted = permitRequestDao.Insert(request);
                request.Id = inserted.Id;
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestCreate, request));
            }
            editHistoryService.TakeSnapshot(request);

            // Submit the Permit Request
            notifiedEvents.AddRange(Submit(workPermitDate, new List<PermitRequestEdmonton> { request }, user));

            return notifiedEvents;
        }

        private void SubmitPermit(Date workPermitDate, User user, List<NotifiedEvent> notifiedEvents,
                PermitRequestEdmonton request, DateTime now, DateTime startDateTime)
        {
            WorkPermitEdmonton workPermit = new WorkPermitEdmonton(DataSource.PERMIT_REQUEST,
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
                foreach (long plantId in plantIds)
                {
                    List<WorkOrderRecordList> workOrderRecordLists = workOrderImporter.ImportWorkOrders(@from, plantId, null);
                    records.AddRange(workOrderRecordLists);
                }
               
                logger.Debug(string.Format("Edmonton Permit Import: ({0}), {1} work order records were received from SAP.", from, records.Count));
                                
                List<PermitRequestImportRejection> importRejectList;
                Site site = siteDao.QueryById(Site.EDMONTON_ID);
                List<PermitRequestEdmonton> incomingPermitRequests = workPermitRequestDataConverter.ConvertToPermitRequests(records, user, site, out importRejectList);
                List<PermitRequestEdmontonSAPImportData> incomingEdmontonRequests = incomingPermitRequests.ConvertListToKnownSubType<PermitRequestEdmontonSAPImportData, PermitRequestEdmonton>();

                logger.Debug(string.Format("Edmonton Permit Import: ({0}), {1} Permit Requests were created from the SAP work orders (but have not yet been processed for insert or update)", from, incomingPermitRequests.Count));
                logger.Debug(string.Format("Edmonton Permit Import: ({0}), {1} Permit Requests were rejected due to validation or other errors after being converted from the work order list. ", from, importRejectList.Count));

                // Divide up all the incoming permit requests into Turnaround vs. Normal
                List<PermitRequestEdmontonSAPImportData> incomingTurnaroundPermits = incomingEdmontonRequests.FindAll(r => r.Group.IsTurnaround);
                List<PermitRequestEdmontonSAPImportData> incomingNormalPermitRequests = incomingEdmontonRequests.FindAll(r => !r.Group.IsTurnaround);

                // turnaround permits are batched in the db as opposed to being passed back and forth by the client, so we only need to remove imports for 'normal permit requests'
                RemoveImportsThatHaveAlreadyArrived(incomingNormalPermitRequests, importsFromCurrentSession);
                
                DateTime timeInEdmonton = timeService.GetTime(site.TimeZone);
                PersistTurnaroundImportData(incomingTurnaroundPermits, batchId, timeInEdmonton);

                List<PermitRequestEdmonton> incomingNormalPermitsAsPermitRequests = incomingNormalPermitRequests.ConvertListToBaseType<PermitRequestEdmonton, PermitRequestEdmontonSAPImportData>();
                                
                EdmontonPermitRequestPersistanceProcessor permitRequestPersistanceProcessor = new EdmontonPermitRequestPersistanceProcessor(permitRequestDao, incomingNormalPermitsAsPermitRequests);
                permitRequestPersistanceProcessor.Process();

                List<PermitRequestEdmonton> updateList = permitRequestPersistanceProcessor.UpdateList;
                updateList.ForEach(r => notifiedEvents.AddRange(Update(r)));
                logger.Debug(string.Format("Edmonton Permit Import: ({0}), {1} were updated.", from, updateList.Count));

//                List<PermitRequestEdmonton> insertList = permitRequestPersistanceProcessor.InsertList.ConvertListToKnownSubType<PermitRequestEdmonton, BasePermitRequest>();
                List<PermitRequestEdmonton> insertList = permitRequestPersistanceProcessor.InsertList;
                SetIsCompleteFlagOnPermitRequests(insertList);
                insertList.ForEach(r => notifiedEvents.AddRange(Insert(r)));
                logger.Debug(string.Format("Edmonton Permit Import: ({0}), {1} were inserted.", from, insertList.Count));

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

        private void PersistTurnaroundImportData(List<PermitRequestEdmontonSAPImportData> incomingTurnaroundPermits, long batchId, DateTime timeInEdmonton)
        {
            foreach (PermitRequestEdmontonSAPImportData item in incomingTurnaroundPermits)
            {
                item.BatchId = batchId;
                item.BatchItemCreatedAt = timeInEdmonton;

                permitRequestSAPImportDataDao.Insert(item);
            }
        }

        private List<IHasPermitKey> GetListOfProcessedWorkOrders(List<NotifiedEvent> notifiedEvents)
        {
            List<IHasPermitKey> resultList = new List<IHasPermitKey>();

            foreach (NotifiedEvent notifiedEvent in notifiedEvents)
            {
                PermitRequestEdmonton permitRequest = (PermitRequestEdmonton) notifiedEvent.DomainObject;

                foreach (PermitRequestWorkOrderSource workOrderSource in permitRequest.WorkOrderSourceList)
                {
                    PermitKeyData data = new PermitKeyData(workOrderSource);
                    resultList.Add(data);
                }
            }

            return resultList;
        }

        private void RemoveImportsThatHaveAlreadyArrived(List<PermitRequestEdmontonSAPImportData> incomingPermitRequests, List<IHasPermitKey> importsFromCurrentSession)
        {                        
            if (importsFromCurrentSession == null || importsFromCurrentSession.Count == 0)
            {
                return;
            }

            List<PermitRequestEdmontonSAPImportData> requestsToRemove = new List<PermitRequestEdmontonSAPImportData>();

            foreach (PermitRequestEdmontonSAPImportData incomingPermitRequest in incomingPermitRequests)
            {
                IHasPermitKey alreadyImported = importsFromCurrentSession.Find(ifcs => ifcs.MatchesByPermitKey(incomingPermitRequest));

                if (alreadyImported != null)
                {
                    requestsToRemove.Add(incomingPermitRequest);
                }
            }

            foreach (PermitRequestEdmontonSAPImportData requestToRemove in requestsToRemove)
            {
                incomingPermitRequests.Remove(requestToRemove);
            }
        }

        private void SetIsCompleteFlagOnPermitRequests(List<PermitRequestEdmonton> permitRequestList)
        {
            foreach (PermitRequestEdmonton request in permitRequestList)
            {
                request.CompletionStatus = request.DetectIsComplete();
            }
        }

        public EdmontonPermitRequestPostFinalizeResult FinalizeImport(Date from, Date to, List<IHasPermitKey> incomingWorkOrders, List<IHasPermitKey> rejectList, long batchId, User user)
        {
            Site edmontonSite = siteDao.QueryById(Site.EDMONTON_ID);
            DateTime timeInEdmonton = timeService.GetTime(edmontonSite.TimeZone);

            int numberOfTurnaroundItemsInsertedOrUpdated = 0;

            List<NotifiedEvent> notifiedEventsFromMissingExpectedWorkOrders = HandleNonTurnaroundImports(@from, to, incomingWorkOrders, rejectList, timeInEdmonton);
            List<NotifiedEvent> notifiedEventsFromTurnaroundImport = HandleTurnaroundImports(@from, to, batchId, user, timeInEdmonton, ref numberOfTurnaroundItemsInsertedOrUpdated);

            notifiedEventsFromMissingExpectedWorkOrders.AddRange(notifiedEventsFromTurnaroundImport);

            EdmontonPermitRequestPostFinalizeResult result = new EdmontonPermitRequestPostFinalizeResult(notifiedEventsFromMissingExpectedWorkOrders, numberOfTurnaroundItemsInsertedOrUpdated);
            return result;
        }

        private List<NotifiedEvent> HandleTurnaroundImports(Date fromDate, Date toDate, long batchId, User user, DateTime timeInEdmonton, ref int numberInsertedOrUpdated)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            List<PermitRequestEdmontonSAPImportData> data = permitRequestSAPImportDataDao.QueryByBatchId(batchId);
            data = PermitRequestEdmontonSAPImportData.RemoveDuplicateTurnaroundImports(data);

            data.ForEach(item => item.SetCreatedInfo(user, timeInEdmonton));
            data.ForEach(item => item.CompletionStatus = item.DetectIsComplete());
            
            List<PermitRequestEdmonton> incomingList = permitRequestDao.QueryByDateRangeAndDataSource(fromDate, toDate, DataSource.SAP);
            List<PermitRequestEdmonton> allExistingPermitRequests = incomingList.FindAll(r => r.Group.IsTurnaround);

            AbstractMergingPermitRequestPersistanceProcessor processor = 
                new EdmontonMergingPermitRequestPersistenceProcessor(allExistingPermitRequests.ConvertAll(i => (IMergeablePermitRequest) i), data.ConvertAll(d => (ISAPImportData) d), timeInEdmonton, user);

            processor.Process();

            List<PermitRequestEdmonton> insertList = processor.InsertList.ConvertAll(i => (PermitRequestEdmonton) i);
            SetIsCompleteFlagOnPermitRequests(insertList);
            insertList.ForEach(r => notifiedEvents.AddRange(Insert(r)));
            logger.Debug(string.Format("Edmonton Permit Import: {0} were inserted.", insertList.Count));

            List<PermitRequestEdmonton> updateList = processor.UpdateList.ConvertAll(i => (PermitRequestEdmonton)i);
            SetIsCompleteFlagOnPermitRequests(updateList);
            updateList.ForEach(r => notifiedEvents.AddRange(Update(r)));
            logger.Debug(string.Format("Edmonton Turnaround Permit Import: {0} were updated.", updateList.Count));

            List<PermitRequestEdmonton> removeList = processor.DeleteList.ConvertAll(i => (PermitRequestEdmonton)i);
            removeList.ForEach(r => notifiedEvents.AddRange(Remove(r)));
            logger.Debug(string.Format("Edmonton Turnaround Permit Import: {0} were removed.", removeList.Count));

            permitRequestSAPImportDataDao.Delete(batchId);

            numberInsertedOrUpdated = processor.NumberOfPermitRequestsProcessed;

            return notifiedEvents;
        }
      
        private List<NotifiedEvent> HandleNonTurnaroundImports(Date @from, Date to, List<IHasPermitKey> incomingWorkOrders, List<IHasPermitKey> rejectList, DateTime timeInEdmonton)
        {            
            List<PermitRequestEdmonton> incomingList = permitRequestDao.QueryByDateRangeAndDataSource(@from, to, DataSource.SAP);
            List<PermitRequestEdmonton> permitRequests = incomingList.FindAll(r => !r.Group.IsTurnaround);


            List<PermitRequestEdmonton> itemsToRemove = PermitRequestEdmonton.BuildImportRemovalList(permitRequests, incomingWorkOrders, rejectList);

            List<PermitRequestEdmonton> permitRequestsToRemove = new List<PermitRequestEdmonton>();
            List<PermitRequestEdmonton> permitRequestsOnWhichToUpdateTheStatus = new List<PermitRequestEdmonton>();

            User sapUser = userService.GetSAPUser();

            foreach (PermitRequestEdmonton request in itemsToRemove)
            {                
                if (request.IsSubmitted)
                {
                    request.LastModifiedDateTime = timeInEdmonton;
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
            logger.Debug(string.Format("Edmonton Permit Import: {0} permits were removed because they were expected but weren't received.", permitRequestsToRemove.Count));    
                      
            permitRequestsOnWhichToUpdateTheStatus.ForEach(r => notifiedEventsFromMissingExpectedWorkOrders.AddRange(Update(r)));
            logger.Debug(string.Format("Edmonton Permit Import: {0} permits had their status updated because they were expected but weren't received.", permitRequestsOnWhichToUpdateTheStatus.Count));

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

        public List<PermitRequestEdmonton> QueryByFormGN59Id(long id)
        {
            return permitRequestDao.QueryByFormGN59Id(id);
        }

        public List<PermitRequestEdmonton> QueryByFormGN6Id(long id)
        {
            return permitRequestDao.QueryByFormGN6Id(id);
        }

        public List<PermitRequestEdmonton> QueryByFormGN7Id(long id)
        {
            return permitRequestDao.QueryByFormGN7Id(id);
        }

        public List<PermitRequestEdmonton> QueryByFormGN24Id(long id)
        {
            return permitRequestDao.QueryByFormGN24Id(id);
        }

        public List<PermitRequestEdmonton> QueryByFormGN75AId(long id)
        {
            return permitRequestDao.QueryByFormGN75AId(id);
        }

        public List<PermitRequestEdmonton> QueryByFormGN1Id(long id)
        {
            return permitRequestDao.QueryByFormGN1Id(id);
        }
    }
}
