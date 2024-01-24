using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitFortHillsService : IWorkPermitFortHillsService
    {
        private readonly IWorkPermitFortHillsDao workPermitDao;
        private readonly IWorkPermitFortHillsDTODao workPermitDtoDao;
        private readonly IWorkPermitFortHillsHazardDTODao workPermitHazardDtoDao;
        private readonly IWorkPermitFortHillsGroupDao groupDao;

        private readonly IWorkPermitFortHillsHistoryDao historyDao;
       

        private readonly IEditHistoryService editHistoryService;

        private readonly IActionItemDefinitionService actionItemDefinationService;
        private readonly ILogService logService;

        public WorkPermitFortHillsService(IWorkPermitFortHillsDao workPermitDao, IWorkPermitFortHillsDTODao workPermitDtoDao, IWorkPermitFortHillsHazardDTODao hazardDtoDao, IWorkPermitFortHillsGroupDao groupDao, IEditHistoryService historyService, IWorkPermitFortHillsHistoryDao historyDao, IActionItemDefinitionService actionItemDefinationService) //, ILogService logService,
        {
            this.workPermitDao = workPermitDao;
            this.workPermitDtoDao = workPermitDtoDao;
            workPermitHazardDtoDao = hazardDtoDao;
            this.groupDao = groupDao;
            editHistoryService = historyService;
            // this.logService = logService;
            this.actionItemDefinationService = actionItemDefinationService;
            this.historyDao = historyDao;

        }

        public WorkPermitFortHillsService()
            : this(
                DaoRegistry.GetDao<IWorkPermitFortHillsDao>(), DaoRegistry.GetDao<IWorkPermitFortHillsDTODao>(), DaoRegistry.GetDao<IWorkPermitFortHillsHazardDTODao>(),
                DaoRegistry.GetDao<IWorkPermitFortHillsGroupDao>(),
                new EditHistoryService(),  DaoRegistry.GetDao<IWorkPermitFortHillsHistoryDao>(), new ActionItemDefinitionService())
                //new LogService(),
        {
        }

        public List<NotifiedEvent> Insert(WorkPermitFortHills workPermit)
        {
            workPermitDao.Insert(workPermit, null);
            return TakeSnapshotAndNotifyEvents(workPermit);

        }

        public List<NotifiedEvent> InsertMergePermit(WorkPermitFortHills workPermit, List<long> mergeSourceIds)
        {
            workPermitDao.Insert(workPermit, null);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (long mergeSourceId in mergeSourceIds)
            {
                WorkPermitFortHills mergeSourcePermit = workPermitDao.QueryById(mergeSourceId);

                if (PermitRequestBasedWorkPermitStatus.Requested.Equals(mergeSourcePermit.WorkPermitStatus)
                    || PermitRequestBasedWorkPermitStatus.Pending.Equals(mergeSourcePermit.WorkPermitStatus))
                {
                    mergeSourcePermit.LastModifiedDateTime = workPermit.LastModifiedDateTime;
                    mergeSourcePermit.LastModifiedBy = workPermit.LastModifiedBy;
                        
                    mergeSourcePermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Merged;
                    notifiedEvents.AddRange(Update(mergeSourcePermit));
                }
            }

            notifiedEvents.AddRange(TakeSnapshotAndNotifyEvents(workPermit));

            return notifiedEvents;            
        }

        public List<NotifiedEvent> Update(WorkPermitFortHills workPermit)
        {
            workPermitDao.Update(workPermit);
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            editHistoryService.TakeSnapshot(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitFortHillsUpdate, workPermit));  // create an event for forthills 
            //AddEventsForForms(workPermit, notifiedEvents);
            return notifiedEvents;
        }

        public WorkPermitFortHills QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitFortHills permit)
        {
            return workPermitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(permit);
        }

        public List<NotifiedEvent> InsertWithPermitRequestEdmontonAssociation(WorkPermitFortHills workPermit, PermitRequestFortHills request)
        {
            workPermitDao.Insert(workPermit, request.Id);
            return TakeSnapshotAndNotifyEvents(workPermit);
        }

        public bool DoesPermitRequestFortHillsAssociationExist(List<PermitRequestFortHillsDTO> submittedRequests, Date workPermitStartDate)
        {
            if (submittedRequests.Count == 0)
            {
                return false;
            }

            UserShiftandIds collection = new UserShiftandIds();
           
            // Get all the Start DateTimes for each request that may have day and/or night times selected.
            // Then create the UserShift that the issued datetime would be in.
            foreach(PermitRequestFortHillsDTO request in submittedRequests)
            {
                if (request.RequestedStartTime != null)
                {
                    DateTime requestedStartDateTime = workPermitStartDate.CreateDateTime(request.RequestedStartTime);

                    UserShift userShift = WorkPermitFortHills.UserShift(requestedStartDateTime);
                    collection.Add(userShift, request.IdValue);
                }
                //if (request.RequestedStartTimeNight != null)
                //{
                //    DateTime requestedStartDateTime = workPermitStartDate.CreateDateTime(request.RequestedStartTimeNight);

                //    UserShift userShift = WorkPermitFortHills.UserShift(requestedStartDateTime);
                //    collection.Add(userShift, request.IdValue);
                //}
            }

            bool associationExists = false;
            foreach(UserShift userShift in collection.Keys)
            {
                associationExists = workPermitDao.DoesPermitRequestFortHillsAssociationExist(collection.GetIdsFor(userShift), userShift.DateTimeRangeWithoutPadding);
                if (associationExists)
                    break;
            }
            return associationExists;
        }

        public List<NotifiedEvent> Remove(WorkPermitFortHills permit)
        {
            workPermitDao.Remove(permit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitFortHillsRemove, permit)); // create an event for forthills /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitFortHills> workPermits, Dictionary<long, Log> permitIdToAssociatedLogMap)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (WorkPermitFortHills permit in workPermits)
            {
                notifiedEvents.AddRange(Update(permit));

                //if (permitIdToAssociatedLogMap.ContainsKey(permit.IdValue))
                //{
                //    Log associatedLog = permitIdToAssociatedLogMap[permit.IdValue];
                //    string text = BuildAssociatedLogComments(associatedLog, permit);
                //    associatedLog.PlainTextComments = text;
                //    associatedLog.RtfComments = text;
                //    /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
                //   notifiedEvents.AddRange(logService.InsertForWorkPermitFortHills(associatedLog, permit));
                //}
            }

            return notifiedEvents;
       }
        public List<NotifiedEvent> UpdateAndInsertActionItems(PermitRequestFortHills workPermits, ActionItemDefinition actionItemDefinition)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            //foreach (WorkPermitFortHills permit in workPermits)
            //{

            notifiedEvents.AddRange(actionItemDefinationService.Insert(actionItemDefinition, workPermits));
                
           // }

            return notifiedEvents;
        }
          
        //private string BuildAssociatedLogComments(Log log, WorkPermitFortHills permit)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    builder.Append(permit.DescriptionForLog);

        //    if (log.PlainTextComments.HasValue())
        //    {
        //        builder.AppendLine(string.Format(StringResources.WorkPermitEdmontonAndLubesAndMontrealCloseCommentForLog, log.PlainTextComments));
        //    }

        //    return builder.ToString();
        //}

        private string BuildAssociatedLogComments(ActionItemDefinition actionItemDefinition, WorkPermitFortHills permit)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(permit.DescriptionForLog);
            builder.AppendLine(string.Format(StringResources.WorkPermitEdmontonAndLubesAndMontrealCloseCommentForLog));
            //if (actionItemDefinition.PlainTextComments.HasValue())
            //{
            //    builder.AppendLine(string.Format(StringResources.WorkPermitEdmontonAndLubesAndMontrealCloseCommentForLog, log.PlainTextComments));
           // }

            return builder.ToString();
        }

        public WorkPermitFortHills QueryById(long id)
        {
            return workPermitDao.QueryById(id);
        }

        public DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId)
        {
            return workPermitDao.QueryLatestExpiryDateByPermitRequestId(permitRequestId);
        }

        public IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocsForTurnaround(Range<Date> dateRange, RootFlocSet flocSet)
        {
            return workPermitDtoDao.QueryByDateRangeAndFlocsAndPriorityIds(dateRange, flocSet, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, false);
        }

        public IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocsForAllButTurnaround(Range<Date> dateRange, RootFlocSet flocSet)
        {
            return workPermitDtoDao.QueryByDateRangeAndFlocsAndPriorityIds(dateRange, flocSet, new List<long> { WorkOrderPriority.P3.IdValue, WorkOrderPriority.P4.IdValue }, true);
        }

        public IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet flocSet)
        {
            return workPermitDtoDao.QueryByDateRangeAndFlocs(dateRange, flocSet);
        }

        private List<NotifiedEvent> TakeSnapshotAndNotifyEvents(WorkPermitFortHills workPermit)
        {
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            editHistoryService.TakeSnapshot(workPermit);
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitFortHillsCreate, workPermit));
          //  AddEventsForForms(workPermit, notifiedEvents);
            return notifiedEvents;
        }

        //private void AddEventsForForms(WorkPermitFortHills workPermit, List<NotifiedEvent> notifiedEvents)
        //{
        //    List<WorkPermitFortHillsHistory> histories = historyDao.GetById(workPermit.IdValue);
        //    histories.Sort(h => h.LastModifiedDate);
        //    histories.Reverse();
        //}

        
        public List<WorkPermitFortHillsGroup> QueryAllGroups()
        {
            return groupDao.QueryAll();
        }

        public List<WorkPermitFortHillsHazardDTO> QueryByFlocsAndStatuses(IFlocSet flocSet, List<PermitRequestBasedWorkPermitStatus> statuses)
        {
            return workPermitHazardDtoDao.QueryByFlocsAndStatus(flocSet, statuses);
        }
       
        //protected ActionItemDefinition GetAIObjectToInsert(WorkPermitFortHills workPermit, Site currentSite)
        //{
        //    List <FunctionalLocation> floc = null;
        //   // Site usersite = ;
        //    ISchedule schedule = new SingleSchedule(workPermit.RequestedStartDateTime.ToDate(), workPermit.RequestedStartDateTime.ToTime(), workPermit.ExpiredDateTime.ToTime(), currentSite);
        //    floc.Add(workPermit.FunctionalLocation);
        //    var now = Clock.Now;
        //    ActionItemDefinition actionItemDefinition =
        //        new ActionItemDefinition("Work Permit FortHills", null, ActionItemDefinitionStatus.Approved, null, workPermit.TaskDescription.TrimOrEmpty(), DataSource.PERMIT, false, true, false, null, now, workPermit.CreatedBy, now, floc, null, null, OperationalMode.Normal, WorkAssignment.NoneWorkAssignment, true, null, null, null, null);
        //    return actionItemDefinition;
        //}
    }
}
