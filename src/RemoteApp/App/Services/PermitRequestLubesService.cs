using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PermitRequestLubesService : IPermitRequestLubesService
    {
        private readonly IPermitRequestLubesDao permitRequestDao;
        private readonly IPermitRequestLubesDTODao permitRequestDtoDao;

        private readonly ITimeService timeService;
        private readonly IWorkPermitLubesService workPermitService;
        private readonly IEditHistoryService editHistoryService;        

        public PermitRequestLubesService()
        {
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestLubesDao>();
            permitRequestDtoDao = DaoRegistry.GetDao<IPermitRequestLubesDTODao>();

            timeService = new TimeService();
            workPermitService = new WorkPermitLubesService();
            editHistoryService = new EditHistoryService();
        }

        public PermitRequestLubes QueryById(long id)
        {
            return permitRequestDao.QueryById(id);
        }

        public List<NotifiedEvent> Insert(PermitRequestLubes permitRequest)
        {
            permitRequestDao.Insert(permitRequest);
            return TakeSnapshotAndNotifyEventsForInsertion(permitRequest);
        }

        public List<NotifiedEvent> Update(PermitRequestLubes permitRequest)
        {
            permitRequestDao.Update(permitRequest);
            editHistoryService.TakeSnapshot(permitRequest);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestLubesUpdate, permitRequest));
            return notifiedEvents;            
        }

        public List<NotifiedEvent> Remove(PermitRequestLubes request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            permitRequestDao.Remove(request);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestLubesRemove, request));
            return notifiedEvents;
        }

        public List<PermitRequestLubesDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByDateRangeAndFlocs(flocSet, dateRange);
        }

        private List<NotifiedEvent> TakeSnapshotAndNotifyEventsForInsertion(PermitRequestLubes permitRequest)
        {
            editHistoryService.TakeSnapshot(permitRequest);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestLubesCreate, permitRequest));
            return notifiedEvents;
        }

        public List<PermitRequestLubesDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestDtoDao.QueryByCompletenessAndGroupAndDateWithinRange(completionStatuses, groupId, date);
        }

        private List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestLubes> permitRequests, User user)
        {
            DateTime? now = null;

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (PermitRequestLubes request in permitRequests)
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

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestLubesDTO> dtos, User user)
        {
            List<PermitRequestLubes> permitRequests = new List<PermitRequestLubes>();

            foreach (PermitRequestLubesDTO dto in dtos)
            {
                PermitRequestLubes request = permitRequestDao.QueryById(dto.IdValue);
                permitRequests.Add(request);
            }

            return Submit(workPermitDate, permitRequests, user);
        }

        private void SubmitPermit(Date workPermitDate, User user, List<NotifiedEvent> notifiedEvents, PermitRequestLubes request, DateTime now, DateTime startDateTime)
        {
            WorkPermitLubes workPermit = new WorkPermitLubes(now, user);
            workPermit.BuildPermitToSubmit(request, user, now, workPermitDate, startDateTime);

            request.LastModifiedBy = user;
            request.LastModifiedDateTime = now;
            request.LastSubmittedByUser = user;
            request.LastSubmittedDateTime = now;

            notifiedEvents.AddRange(workPermitService.InsertWithPermitRequestLubesAssociation(workPermit, request));
            notifiedEvents.AddRange(Update(request));
        }
    }
}