using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PermitRequestMudsService : IPermitRequestMudsService
    {
        private readonly IPermitRequestMudsDao permitRequestDao;
        private readonly IPermitRequestMudsDTODao permitRequestDtoDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly ITimeService timeService;
        private readonly IWorkPermitMudsService workPermitService;
        private readonly IShiftPatternDao shiftPatternDao;
        
        public PermitRequestMudsService()
        {
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestMudsDao>();
            permitRequestDtoDao = DaoRegistry.GetDao<IPermitRequestMudsDTODao>();
            editHistoryService = new EditHistoryService();
            timeService = new TimeService();
            workPermitService = new WorkPermitMudsService();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        public List<PermitRequestMudsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            
            return permitRequestDtoDao.QueryByFlocUnitAndBelow(flocSet, dateRange);
        }

        public List<PermitRequestMudsDTO> QueryByFlocUnitAndBelowForTemlate(IFlocSet flocSet, DateRange dateRange, string username)
        {
            return permitRequestDtoDao.QueryByFlocUnitAndBelowForTemplate(flocSet, dateRange, username);
        }

        

        public PermitRequestMuds QueryById(long id)
        {
            return permitRequestDao.QueryById(id);
        }
        public PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            return permitRequestDao.QueryByIdTemplate(id, templateName, categories);
        }

        public List<NotifiedEvent> Insert(PermitRequestMuds request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            PermitRequestMuds inserted = permitRequestDao.Insert(request);
            editHistoryService.TakeSnapshot(request);
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsCreate, inserted));
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertTemplate(PermitRequestMuds workPermit)
        {
            if (workPermit.IsTemplate)
            {
                permitRequestDao.InsertTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsTemplateCreate, workPermit));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(PermitRequestMuds request)
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

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsUpdate, request));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(PermitRequestMuds request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            permitRequestDao.Remove(request);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsRemove, request));
            return notifiedEvents;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(PermitRequestMuds workPermit)
        {
            permitRequestDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(PermitRequestMuds workPermit)
        {
            if (workPermit.IsTemplate)
            {
                permitRequestDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsUpdate, workPermit));
            return notifiedEvents;
        }

        public List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestMuds request, User user)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (request.IsInDatabase())
            {
                permitRequestDao.Update(request);
                // no need to add the 'update' event to our notified events list, as submitting will do that
            }
            else
            {
                PermitRequestMuds inserted = permitRequestDao.Insert(request);                
                request.Id = inserted.Id;
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestMudsCreate, request));
            }
            editHistoryService.TakeSnapshot(request);

            // Submit the Permit Request
            notifiedEvents.AddRange(Submit(workPermitDate, new List<PermitRequestMuds> { request }, user));
            
            return notifiedEvents;
        }

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMudsDTO> dtos, User user)
        {
            List<PermitRequestMuds> permitRequests = new List<PermitRequestMuds>();
            foreach (PermitRequestMudsDTO dto in dtos)
            {
                PermitRequestMuds permitRequest = permitRequestDao.QueryById(dto.IdValue);
                permitRequests.Add(permitRequest);
            }

            return Submit(workPermitDate, permitRequests, user);
        }

        private List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMuds> permitRequests, User user)
        {
            DateTime? now = null;
            ShiftPattern dayShift = null;

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (PermitRequestMuds request in permitRequests)
            {
                if (now == null)
                {
                    now = timeService.GetTime(request.FunctionalLocations[0].Site.TimeZone);
                }
                if (dayShift == null)
                {
                    List<ShiftPattern> shifts = shiftPatternDao.QueryBySiteId(request.FunctionalLocations[0].Site.IdValue);
                    dayShift = shifts.Find(obj => !obj.IsOverlappingADay);
                }

                DateTime start = workPermitDate.ToDateTimeAtStartOfDay();
                DateTime end = workPermitDate.ToDateTimeAtStartOfDay();
                if (dayShift != null)
                {
                    start = dayShift.StartTime.ToDateTime(workPermitDate);
                    end = dayShift.EndTime.ToDateTime(workPermitDate);
                }
                
                WorkPermitMuds permit = new WorkPermitMuds(
                    DataSource.PERMIT_REQUEST,                    
                    PermitRequestBasedWorkPermitStatus.Requested,
                    request.WorkPermitType, 
                    null,
                    start,
                    end,
                    request.FunctionalLocations,
                    request.WorkOrderNumber,
                    request.Trade,
                    request.Description,
                    now.Value, user, now.Value, user, request.RequestedByGroup, null, request.RequestedByGroupText,
                    request.NbTravail, request.Formation, request.Noms, request.Noms_1, request.Noms_2, request.Noms_3, request.Surveilant)// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                    {
                        RequestedByUser = user,
                        RequestedDateTime = now,
                        Company = request.Company,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                        Company_1 = request.Company_1,
                        Company_2 = request.Company_2,
                        Supervisor = request.Supervisor,
                        ExcavationNumber = request.ExcavationNumber,
                        StartDateTime = request.StartDateTime,
                        EndDateTime = request.EndDateTime
                        
                    };

                permit.Attributes.AddRange(request.Attributes);
                permit.DocumentLinks = request.DocumentLinks.ConvertAll(link => new DocumentLink(link.Url, link.Title));

                permit.ProtectionAuditive = true;

                if (!request.ExcavationNumber.IsNullOrEmptyOrWhitespace())
                {
                    //permit.DessinsRequis = new TernaryString(true, request.ExcavationNumber);
                }

                notifiedEvents.AddRange(workPermitService.InsertWithPermitRequestMudsAssociation(permit, request)); 

                request.LastModifiedBy = user;
                request.LastModifiedDateTime = now.Value;
                request.LastSubmittedByUser = user;
                request.LastSubmittedDateTime = now;
                notifiedEvents.AddRange(Update(request));
            }

            return notifiedEvents;
        }
    }
}