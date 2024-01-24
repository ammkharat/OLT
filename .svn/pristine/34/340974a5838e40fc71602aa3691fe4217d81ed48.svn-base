using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
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
    public class WorkPermitLubesService : IWorkPermitLubesService
    {
        private readonly IWorkPermitLubesDao workPermitDao;
        private readonly IWorkPermitLubesDTODao workPermitDTODao;
        private readonly IEditHistoryService editHistoryService;
        private readonly IWorkPermitLubesGroupDao groupDao;
        private readonly ILogService logService;

        public WorkPermitLubesService(IWorkPermitLubesDao workPermitDao, IWorkPermitLubesDTODao workPermitDTODao, IWorkPermitLubesGroupDao groupDao, IEditHistoryService editHistoryService, ILogService logService)
        {
            this.workPermitDao = workPermitDao;
            this.workPermitDTODao = workPermitDTODao;
            this.editHistoryService = editHistoryService;
            this.groupDao = groupDao;
            this.logService = logService;
        }

        public WorkPermitLubesService() 
            : this(DaoRegistry.GetDao<IWorkPermitLubesDao>(),
                   DaoRegistry.GetDao<IWorkPermitLubesDTODao>(),
                   DaoRegistry.GetDao<IWorkPermitLubesGroupDao>(),
                   new EditHistoryService(),
                   new LogService())
        {
        }

        public List<NotifiedEvent> Insert(WorkPermitLubes workPermit)
        {
            workPermitDao.Insert(workPermit, null);
            return TakeSnapshotAndNotifyEvents(workPermit);
        }

        public List<NotifiedEvent> Update(WorkPermitLubes workPermit)
        {
            workPermitDao.Update(workPermit);
            editHistoryService.TakeSnapshot(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitLubesUpdate, workPermit));
            return notifiedEvents;            
        }

        public List<NotifiedEvent> Remove(WorkPermitLubes workPermit)
        {
            workPermitDao.Remove(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitLubesRemove, workPermit));
            return notifiedEvents;            
        }

        private List<NotifiedEvent> TakeSnapshotAndNotifyEvents(WorkPermitLubes workPermit)
        {
            editHistoryService.TakeSnapshot(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitLubesCreate, workPermit));
            return notifiedEvents;
        }

        public WorkPermitLubes QueryById(long id)
        {
            return workPermitDao.QueryById(id);
        }

        public List<WorkPermitLubesGroup> QueryAllGroups()
        {
            return groupDao.QueryAll();
        }

        public List<WorkPermitLubesDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet rootFlocSet)
        {
            return workPermitDTODao.QueryByDateRangeAndFlocs(dateRange, rootFlocSet);
        }

        public WorkPermitLubes QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitLubes permit)
        {
            return workPermitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(permit);
        }

        public bool DoesPermitRequestLubesAssociationExist(List<PermitRequestLubesDTO> submittedRequests, Date workPermitStartDate)
        {
            if (submittedRequests.Count == 0)
            {
                return false;
            }

            UserShiftandIds collection = new UserShiftandIds();

            // Get all the Start DateTimes for each request that may have day and/or night times selected.
            // Then create the UserShift that the issued datetime would be in.
            foreach (PermitRequestLubesDTO request in submittedRequests)
            {
                if (request.RequestedStartTimeDay != null)
                {
                    DateTime requestedStartDateTime = workPermitStartDate.CreateDateTime(request.RequestedStartTimeDay);

                    UserShift userShift = WorkPermitLubes.UserShift(requestedStartDateTime);
                    collection.Add(userShift, request.IdValue);
                }
                if (request.RequestedStartTimeNight != null)
                {
                    DateTime requestedStartDateTime = workPermitStartDate.CreateDateTime(request.RequestedStartTimeNight);

                    UserShift userShift = WorkPermitLubes.UserShift(requestedStartDateTime);
                    collection.Add(userShift, request.IdValue);
                }
            }

            bool associationExists = false;
            foreach (UserShift userShift in collection.Keys)
            {
                associationExists = workPermitDao.DoesPermitRequestLubesAssociationExist(collection.GetIdsFor(userShift), userShift.DateTimeRangeWithoutPadding);
                if (associationExists)
                {
                    break;
                }
            }
            return associationExists;
        }

        public List<NotifiedEvent> InsertWithPermitRequestLubesAssociation(WorkPermitLubes workPermit, PermitRequestLubes request)
        {
            workPermitDao.Insert(workPermit, request.Id);
            return TakeSnapshotAndNotifyEvents(workPermit);
        }

        public List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitLubes> workPermits, Dictionary<long, Log> permitIdToAssociatedLogMap)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (WorkPermitLubes permit in workPermits)
            {
                notifiedEvents.AddRange(Update(permit));

                if (permitIdToAssociatedLogMap.ContainsKey(permit.IdValue))
                {
                    Log associatedLog = permitIdToAssociatedLogMap[permit.IdValue];
                    string text = BuildAssociatedLogComments(associatedLog, permit);
                    associatedLog.PlainTextComments = text;
                    associatedLog.RtfComments = text;
                    notifiedEvents.AddRange(logService.InsertForWorkPermitLubes(associatedLog, permit));
                }
            }

            return notifiedEvents;
        }

        private string BuildAssociatedLogComments(Log log, WorkPermitLubes permit)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(permit.DescriptionForLog);

            if (log.PlainTextComments.HasValue())
            {
                builder.AppendLine(string.Format(StringResources.WorkPermitEdmontonAndLubesAndMontrealCloseCommentForLog, log.PlainTextComments));
            }

            return builder.ToString();
        }
    }
}
