using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    public class FormOilsandsService : IFormOilsandsService
    {
        private readonly IFormOilsandsTrainingDTODao formOilsandsTrainingDtoDao;
        private readonly IFormOilsandsTrainingDao formOilsandsTrainingDao;
        private readonly IFormOilsandsPriorityPageDTODao formOilsandsPriorityPageDtoDao;

        private readonly IEditHistoryService editHistoryService;
        private readonly ITimeService timeService;

        public FormOilsandsService()
        {
            formOilsandsTrainingDao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();
            formOilsandsTrainingDtoDao = DaoRegistry.GetDao<IFormOilsandsTrainingDTODao>();
            formOilsandsPriorityPageDtoDao = DaoRegistry.GetDao<IFormOilsandsPriorityPageDTODao>();

            editHistoryService = new EditHistoryService();
            timeService = new TimeService();
        }

        private Comparison<FormOilsandsPriorityPageDTO> SortByTrainingDateDescending()
        {
            return (dto1, dto2) => dto1.TrainingDate.CompareTo(dto2.TrainingDate) * -1;
        }

        private Comparison<FormOilsandsPriorityPageDTO> SortByTrainingDateAscending()
        {
            return (dto1, dto2) => dto1.TrainingDate.CompareTo(dto2.TrainingDate);
        } 

        public List<FormOilsandsPriorityPageDTO> QueryAllOilsandsFormsRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet, DateRange dateRange)
        {
            List<FormOilsandsPriorityPageDTO> forms = new List<FormOilsandsPriorityPageDTO>();

            forms.AddRange(formOilsandsPriorityPageDtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(flocSet, dateRange));
            
            forms.Sort(SortByTrainingDateAscending());

            return forms;
        }

        public List<FormOilsandsTraining> QueryFormOilsandsTrainingsByDatesAndUsersAndWorkAssignments(DateRange range, List<long> userIdList, List<long> workAssignmentIdList)
        {
            return formOilsandsTrainingDao.QueryByDateAndUsersAndWorkAssignments(range, userIdList, workAssignmentIdList);
        }

        public List<FormOilsandsTrainingDTO> QueryFormOilsandsTrainingsByFunctionalLocationsAndDateRange(IFlocSet flocSet, DateRange dateRange)
        {
            return formOilsandsTrainingDtoDao.QueryByFunctionalLocationsAndDateRange(flocSet, dateRange);
        }

        public List<NotifiedEvent> InsertFormOilsandsTraining(FormOilsandsTraining form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0].Site);
            formOilsandsTrainingDao.Insert(form);

            editHistoryService.TakeSnapshot(form);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsTrainingCreate, form));
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsCreate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateFormOilsandsTraining(FormOilsandsTraining form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0].Site);
            formOilsandsTrainingDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsTrainingUpdate, form));
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsUpdate, form));
            return notifiedEvents;
        }

        //ayman generic forms
        public FormOilsandsTraining QueryFormOilsandsTrainingByIdAndSiteId(long id,long siteid)
        {
            return formOilsandsTrainingDao.QueryByIdAndSiteId(id,siteid); 
        }
        
        
        public FormOilsandsTraining QueryFormOilsandsTrainingById(long id)
        {
            return formOilsandsTrainingDao.QueryById(id);
        }

        public List<NotifiedEvent> RemoveFormOilsandsTraining(FormOilsandsTraining form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0].Site);
            formOilsandsTrainingDao.Remove(form);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsTrainingRemove, form));
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOilsandsRemove, form));
            return notifiedEvents;
        }

        public long? QueryDateShiftAndAssignmentDuplicatesOnOtherFormOilsandTrainings(long? formId, Date trainingDate, ShiftPattern shiftPattern, WorkAssignment workAssignment, User currentUser)
        {
            return formOilsandsTrainingDao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(formId, trainingDate, shiftPattern, workAssignment, currentUser);
        }
        
        private DateTime GetCurrentTimeAtSite(Site site)
        {
            return timeService.GetTime(site.TimeZone);
        }
    }
}
