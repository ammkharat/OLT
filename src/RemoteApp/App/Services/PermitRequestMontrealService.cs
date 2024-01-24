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
    public class PermitRequestMontrealService : IPermitRequestMontrealService
    {
        private readonly IPermitRequestMontrealDao permitRequestDao;
        private readonly IPermitRequestMontrealDTODao permitRequestDtoDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly ITimeService timeService;
        private readonly IWorkPermitMontrealService workPermitService;
        private readonly IShiftPatternDao shiftPatternDao;
        
        public PermitRequestMontrealService()
        {
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestMontrealDao>();
            permitRequestDtoDao = DaoRegistry.GetDao<IPermitRequestMontrealDTODao>();
            editHistoryService = new EditHistoryService();
            timeService = new TimeService();
            workPermitService = new WorkPermitMontrealService();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        public List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            return permitRequestDtoDao.QueryByFlocUnitAndBelow(flocSet, dateRange);
        }

        public List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelowForTemlate(IFlocSet flocSet, DateRange dateRange, string username)
        {
            return permitRequestDtoDao.QueryByFlocUnitAndBelowForTemplate(flocSet, dateRange, username);
        }

        public PermitRequestMontreal QueryById(long id)
        {
            return permitRequestDao.QueryById(id);
        }

        public PermitRequestMontreal QueryByIdTemplate(long id, string templateName, string categories)
        {
            return permitRequestDao.QueryByIdTemplateMontreal(id, templateName, categories);
        }

        public List<NotifiedEvent> Insert(PermitRequestMontreal request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            PermitRequestMontreal inserted = permitRequestDao.Insert(request);
            editHistoryService.TakeSnapshot(request);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestCreate, inserted));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(PermitRequestMontreal request)
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
            

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestUpdate, request));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(PermitRequestMontreal request)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            permitRequestDao.Remove(request);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestRemove, request));
            return notifiedEvents;
        }
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(PermitRequestMontreal workPermit)
        {
            permitRequestDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(PermitRequestMontreal workPermit)
        {
            if (workPermit.IsTemplate)
            {
                permitRequestDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestUpdate, workPermit));
            return notifiedEvents;
        }


        public List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestMontreal request, User user)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (request.IsInDatabase())
            {
                permitRequestDao.Update(request);
                // no need to add the 'update' event to our notified events list, as submitting will do that
            }
            else
            {
                PermitRequestMontreal inserted = permitRequestDao.Insert(request);                
                request.Id = inserted.Id;
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.PermitRequestCreate, request));
            }
            editHistoryService.TakeSnapshot(request);

            // Submit the Permit Request
            notifiedEvents.AddRange(Submit(workPermitDate, new List<PermitRequestMontreal> { request }, user));
            
            return notifiedEvents;
        }

        public List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMontrealDTO> dtos, User user)
        {
            List<PermitRequestMontreal> permitRequests = new List<PermitRequestMontreal>();
            foreach (PermitRequestMontrealDTO dto in dtos)
            {
                PermitRequestMontreal permitRequest = permitRequestDao.QueryById(dto.IdValue);
                permitRequests.Add(permitRequest);
            }

            return Submit(workPermitDate, permitRequests, user);
        }

        private List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMontreal> permitRequests, User user)
        {
            DateTime? now = null;
            ShiftPattern dayShift = null;

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            foreach (PermitRequestMontreal request in permitRequests)
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
                
                WorkPermitMontreal permit = new WorkPermitMontreal(
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
                    now.Value, user, now.Value, user, request.RequestedByGroup, null)
                    {
                        RequestedByUser = user,
                        RequestedDateTime = now,
                        Company = request.Company,
                        Supervisor = request.Supervisor,
                        ExcavationNumber = request.ExcavationNumber
                    };

                permit.Attributes.AddRange(request.Attributes);
                permit.DocumentLinks = request.DocumentLinks.ConvertAll(link => new DocumentLink(link.Url, link.Title));

                if (!request.ExcavationNumber.IsNullOrEmptyOrWhitespace())
                {
                    permit.DessinsRequis = new TernaryString(true, request.ExcavationNumber);
                }

                notifiedEvents.AddRange(workPermitService.InsertWithPermitRequestMontrealAssociation(permit, request)); 

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