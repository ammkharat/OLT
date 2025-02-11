using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ActionItemDefinitionService : IActionItemDefinitionService
    {
        private readonly IActionItemDefinitionDao dao;
        private readonly IActionItemDefinitionDTODao dtoDao;
        private readonly ISapWorkOrderOperationDao sapWorkOrderOperationDao;
        private readonly ITimeService timeService;
        private readonly IEditHistoryService editHistoryService;
        private readonly IActionItemService actionItemService;

        public ActionItemDefinitionService() : this(
            new TimeService(),
            new EditHistoryService(),
            new ActionItemService())
        {
        }

        public ActionItemDefinitionService(
            ITimeService timeService,
            IEditHistoryService editHistoryService,
            IActionItemService actionItemService)
        {
            dao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            dtoDao = DaoRegistry.GetDao<IActionItemDefinitionDTODao>();
            sapWorkOrderOperationDao = DaoRegistry.GetDao<ISapWorkOrderOperationDao>();

            this.timeService = timeService;
            this.editHistoryService = editHistoryService;
            this.actionItemService = actionItemService;
        }

        public int GetCountOfSAPSourced(string name, long siteId)
        {
            return dao.GetCountOfSAPSourced(name, siteId);
        }

        //ayman action item definition
        public List<ActionItemDefinitionDTO> QueryDTOByActionItemDefinitionIds(Site site, List<long> aidSet, List<long> readableVisibilityGroupIds)
        {
            return dtoDao.QueryByActionItemDefinitions(aidSet, readableVisibilityGroupIds);
        }
        
        public List<ActionItemDefinitionDTO> QueryDTOByFunctionalLocationsAndDateRange(Site site, IFlocSet flocSet, Range<Date> range, List<long> readableVisibilityGroupIds)
        {
            DateRange dateRange = new DateRange(range);
            return dtoDao.QueryByFunctionalLocations(flocSet, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, readableVisibilityGroupIds);
        }

        //ayman custom fields DMND0010030
        public void InsertActionItemCustomFieldGroup(ActionItemDefinition actionitemDefinition, CustomFieldGroup customFieldGroupId)
        {
          //  dao.InsertCustomFieldGroupForActionItem(actionitemDefinition, customFieldGroupId);
        }

        //ayman action item email
        public List<string> QueryMailingList(long actionitemdefId)
        {
            return dao.QueryActionItemDefSendEmailToByActionItemDefinitionId(actionitemdefId);
        }

        public ActionItemDefinition QueryById(long actionItemId)
        {
            return dao.QueryById(actionItemId);
        }

        public object QueryActionItemDefAutoPopulateByActionItemDefinitionId(long id)
        {
            return dao.QueryActionItemDefAutoPopulateByActionItemDefinitionId(id);
        }

        public object QueryActionItemDefReadingByActionItemDefinitionId(long id)
        {
            return dao.QueryActionItemDefReadingByActionItemDefinitionId(id);
        }

        public List<ActionItemDefinition> QueryActionItemDefReadingBySiteId(long id,Date startdate,Date enddate)
        {
            return dao.QueryReadingDefinitionsBySite(id,startdate,enddate);
        }

        public ActionItemDefinition QueryBySapOperationWorkOrderDetails(string workOrderNumber, string operationNumber, string subOperation)
        {
            subOperation = subOperation.EmptyToNull();

            SapWorkOrderOperation workOrderOperation =
                sapWorkOrderOperationDao.FindByKeys(workOrderNumber, operationNumber, subOperation, SapOperationType.ActionItemDefinition);

            if (workOrderOperation == null || !workOrderOperation.Id.HasValue)
            {
                return null;
            }

            return dao.QueryBySapOperationId(workOrderOperation.IdValue);
        }

        public List<ActionItemDefinition> QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(WorkAssignment assignment, IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds)
        {
            return dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(assignment, flocSet, todaysDate, readableVisibilityGroupIds);
        }

        public List<ActionItemDefinition> QueryActiveDtosByParentFunctionalLocations(IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds)
        {
            return dao.QueryActiveDtosByParentFunctionalLocations(flocSet, todaysDate, readableVisibilityGroupIds);
        }

        public List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition)
        {
            
            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);
            actionItemDefinition.LastModifiedDate = currentTimeAtSite;

            dao.Insert(actionItemDefinition);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionCreate, actionItemDefinition));
            return notifiedEvents;
        }

        //ayman custom fields DMND0010030
        public List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition,
                                           CustomFieldGroup customfieldsgroupid)
        {
            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);
            actionItemDefinition.LastModifiedDate = currentTimeAtSite;

            dao.InsertWithCustomFieldGroupID(actionItemDefinition,customfieldsgroupid);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionCreate, actionItemDefinition));
            return notifiedEvents;
        }

        public ActionItemDefinition Insert(ActionItemDefinition actionItemDefinition,
                                                   SapWorkOrderOperation workOrderOperation)
        {
            SapWorkOrderOperation newOperation = sapWorkOrderOperationDao.Insert(workOrderOperation);
            actionItemDefinition.SapOperationId = newOperation.Id;

            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);
            actionItemDefinition.LastModifiedDate = currentTimeAtSite;

            dao.Insert(actionItemDefinition);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionCreate, actionItemDefinition);
            return actionItemDefinition;
        }

        public List<NotifiedEvent> Remove(ActionItemDefinition actionItemDefinition)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            
            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);

            actionItemDefinition.LastModifiedDate = currentTimeAtSite;
            dao.Remove(actionItemDefinition);

            notifiedEvents.AddRange(actionItemService.RemoveAllUnrespondedToActionItemsForActionItemDefinition(actionItemDefinition));            
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionRemove, actionItemDefinition));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(ActionItemDefinition actionItemDefinition)
        {
            return Update(actionItemDefinition, false);
        }

        public List<NotifiedEvent> UpdateAndClearCurrentActionItems(ActionItemDefinition actionItemDefinition)
        {
            return Update(actionItemDefinition, true);
        }

        private List<NotifiedEvent> Update(ActionItemDefinition actionItemDefinition, bool removeCurrentActionItemsForDefinition)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);

            actionItemDefinition.LastModifiedDate = currentTimeAtSite;

            dao.Update(actionItemDefinition);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            if (removeCurrentActionItemsForDefinition)
            {
                notifiedEvents.AddRange(actionItemService.RemoveCurrentActionItemsForActionItemDefinition(actionItemDefinition, currentTimeAtSite));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionUpdate, actionItemDefinition));
            return notifiedEvents;            
        }

        public List<string> QueryForActionItemNameListByTargetDefinitionId(long? targetId)
        {
            List<string> actionItemNames = new List<string>();
            List<ActionItemDefinitionDTO> dtos = dtoDao.QueryByTargetDefinitionId(targetId);

            foreach (ActionItemDefinitionDTO dto in dtos)
            {
                actionItemNames.Add(dto.Name);
            }

            return actionItemNames;
        }

        public List<ActionItemDefinition> QueryAllAvailableForScheduling()
        {
            return dao.QueryAllAvailableForScheduling();
        }

        public int QueryCountByGN75BId(long id)
        {
            return dao.QueryCountByGN75BId(id);
        }

        public List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition, PermitRequestFortHills Permit)
        {

            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);
            actionItemDefinition.LastModifiedDate = currentTimeAtSite;

            dao.Insert(actionItemDefinition);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionCreate, actionItemDefinition));
            AddHandoverAssociation(actionItemDefinition);
            return notifiedEvents;
        }
        //Added by ppanigrahi
        public List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition, WorkPermitMuds Permit)
        {
            DateTime currentTimeAtSite = timeService.GetTime(actionItemDefinition.FunctionalLocations[0].Site.TimeZone);
            actionItemDefinition.LastModifiedDate = currentTimeAtSite;
           
            dao.Insert(actionItemDefinition);
            editHistoryService.TakeSnapshot(actionItemDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDefinitionCreate, actionItemDefinition));
            AddHandoverAssociation(actionItemDefinition);
            return notifiedEvents;

        }


        private void AddHandoverAssociation(ActionItemDefinition actionItemDefinition)
        {
            if (actionItemDefinition.FunctionalLocations != null)
            {
               // shiftHandoverAssociationDao.InsertLogAssocications(log);
            }
        }
        //public List<NotifiedEvent> InsertForWorkPermitFortHills(Log log, WorkPermitFortHills associatedWorkPermit)
        //{
        //    List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedWorkPermit));
        //    AddHandoverAssociation(log);
        //    return notifiedEvents;
        //}
    }
}
