using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TargetDefinitionService : ITargetDefinitionService
    {
        private readonly ITargetDefinitionDao dao;
        private readonly ITargetDefinitionStateDao stateDao;
        private readonly ITargetDefinitionDTODao dtoDao;
        private static readonly ILog logger = GenericLogManager.GetLogger<TargetDefinitionService>();
        private readonly IUserService userService;
        private readonly IEditHistoryService editHistoryService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ITargetAlertService targetAlertService;
        private readonly ITargetDefinitionHistoryDao targetDefinitionHistoryDao;
        private readonly ITimeService timeService;

        public TargetDefinitionService() : this(
            new TargetAlertService(), 
            new UserService(),
            new EditHistoryService(),
            new SiteConfigurationService(),
            new TimeService())
        {
        }

        public TargetDefinitionService(
            ITargetAlertService targetAlertService, 
            IUserService userService,
            IEditHistoryService editHistoryService,
            ISiteConfigurationService siteConfigurationService,
            ITimeService timeService)
        {
            dao = DaoRegistry.GetDao<ITargetDefinitionDao>();
            stateDao = DaoRegistry.GetDao<ITargetDefinitionStateDao>();
            dtoDao = DaoRegistry.GetDao<ITargetDefinitionDTODao>();
            targetDefinitionHistoryDao = DaoRegistry.GetDao<ITargetDefinitionHistoryDao>();
            this.userService = userService;
            this.editHistoryService = editHistoryService;
            this.siteConfigurationService = siteConfigurationService;
            this.targetAlertService = targetAlertService;
            this.timeService = timeService;            
        }

        public int GetCount(string name, long siteId)
        {
            return dao.GetCount(name, siteId);
        }

        public List<TargetDefinitionDTO> QueryDTOByFunctionalLocations(IFlocSet flocSet, Range<Date> dateRange)
        {
            return dtoDao.QueryByFunctionalLocations(flocSet, new DateRange(dateRange));
        }

        public TargetDefinition QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<TargetDefinition> QueryActiveByName(long siteId, string name)
        {
            return dao.QueryActiveByName(siteId, name);
        }

        public List<NotifiedEvent> Insert(TargetDefinition target)
        {
            dao.Insert(target);
            stateDao.Insert(new TargetDefinitionState(target.Id, false, null));
            editHistoryService.TakeSnapshot(target);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>
                                                     {
                                                         ServiceUtility.PushEventIntoQueue(ApplicationEvent.
                                                                                               TargetDefinitionCreate,
                                                                                           target)
                                                     };
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(TargetDefinition target)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            // Check that the Target isn't a child of another Target through a Target Association.
            List<string> parentTargetNames = dao.QueryParentTargets(target.IdValue);
            // If the Target is a child, throw an Exception
            if (parentTargetNames.Count > 0)
            {
                throw new ParentTargetExistsException(parentTargetNames);
            }
            TargetAlert associatedAlert = targetAlertService.QueryTargetAlertNeedingAttentionByTargetDefinition(target);
            if (associatedAlert != null)
            {
                associatedAlert.Status = TargetAlertStatus.Cleared;
                notifiedEvents.AddRange(targetAlertService.UpdateTargetAlert(associatedAlert));
            }

            dao.Remove(target);

            TargetDefinitionState targetDefinitionState = stateDao.QueryById(target.IdValue);
            targetDefinitionState.IsExceedingBoundary = false;
            targetDefinitionState.LastSuccessfulTagAccess = null;
            stateDao.Update(targetDefinitionState);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue( ApplicationEvent.TargetDefinitionRemove, target));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(TargetDefinition target, TagChangedState state)
        {
            SiteConfiguration siteConfiguration = siteConfigurationService.QueryBySiteId(target.FunctionalLocation.Site.IdValue);
            TargetDefinition targetDefBeforeChanges = QueryById(target.IdValue);
            target.UpdateStatusAfterChange(true, targetDefBeforeChanges,
                                           siteConfiguration.TargetDefinitionAutoReApprovalConfiguration);

            if (state.HasChanged)
            {
                TargetDefinitionState targetDefinitionState = stateDao.QueryById(target.IdValue);
                targetDefinitionState.Update(state);
                stateDao.Update(targetDefinitionState);
                
            }

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            notifiedEvents.AddRange(UpdateTargetAlertsNeedingAttention(target, targetDefBeforeChanges.OperationalMode));
            notifiedEvents.AddRange(UpdateTargetDefinitionCore(target));

            return notifiedEvents;

        }

        public List<NotifiedEvent> Reject(TargetDefinition target, User rejector, DateTime rejectedDateTime)
        {
            target.Reject(rejector, rejectedDateTime);
            return UpdateTargetDefinitionCore(target);
        }

        public List<NotifiedEvent> Approve(TargetDefinition targetDefinition, User approver, DateTime approvedDateTime)
        {
            targetDefinition.Approve(approver, approvedDateTime);
            return UpdateTargetDefinitionCore(targetDefinition);
        }

        private List<NotifiedEvent> UpdateTargetDefinitionCore(TargetDefinition targetDefinition)
        {
            dao.Update(targetDefinition);
            editHistoryService.TakeSnapshot(targetDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>
                                                     {
                                                         ServiceUtility.PushEventIntoQueue(ApplicationEvent.
                                                                                               TargetDefinitionUpdate,
                                                                                           targetDefinition)
                                                     };
            return notifiedEvents;
        }

        private List<NotifiedEvent> UpdateTargetAlertsNeedingAttention(TargetDefinition targetDefinition, OperationalMode oldOperationalMode)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            TargetAlert targetAlertNeedingAttention = targetAlertService.QueryTargetAlertNeedingAttentionByTargetDefinition(targetDefinition);
            if (targetAlertNeedingAttention != null)
            {
                CopyValuesToTargetAlert(targetDefinition, targetAlertNeedingAttention);
                targetAlertNeedingAttention.UpdateStatusWithNewTargetDefinitionOpMode(oldOperationalMode, targetDefinition.OperationalMode);
                targetAlertNeedingAttention.UpdateStatusWithTargetDefinitionIsActive(targetDefinition.IsActive);
                notifiedEvents.AddRange(targetAlertService.UpdateTargetAlert(targetAlertNeedingAttention));
            }

            return notifiedEvents;
        }

        private static void CopyValuesToTargetAlert(TargetDefinition targetDefinition, TargetAlert nonClosedTargetAlert)
        {
            nonClosedTargetAlert.NeverToExceedMaximum = targetDefinition.NeverToExceedMaximum;
            nonClosedTargetAlert.MaxValue = targetDefinition.MaxValue;
            nonClosedTargetAlert.MinValue = targetDefinition.MinValue;
            nonClosedTargetAlert.NeverToExceedMinimum = targetDefinition.NeverToExceedMinimum;
            nonClosedTargetAlert.TargetValue = targetDefinition.TargetValue;
            nonClosedTargetAlert.GapUnitValue = targetDefinition.GapUnitValue;
            nonClosedTargetAlert.Description = targetDefinition.Description;
        }

        public void CheckCircularDependencyCreated(TargetDefinition targetDefinition)
        {
            Stack<long> stack = new Stack<long>();
            stack.Push(targetDefinition.IdValue);
            CheckChildrenForCircularDependencies(targetDefinition, stack);
        }


        // TODO (Performance):  Stop returning data, iterating through it, and then doing Updates.  Just do it directly in the database?
        public void UpdateBoundaryExceededByUnitId(List<FunctionalLocation> unitFunctionalLocations,
                                                   bool isExceedingBoundry)
        {
            List<FunctionalLocation> forSureAUnitLevelFloc =
                unitFunctionalLocations.FindAll(floc => floc.Type == FunctionalLocationType.Level3);
            
            foreach (FunctionalLocation currentUnit in forSureAUnitLevelFloc)
            {
                List<TargetDefinitionState> targetDefs = stateDao.QueryAllTargetDefinitionStatesUnderAUnitId(currentUnit.IdValue);
                
                foreach (TargetDefinitionState currentTargetDef in targetDefs)
                {
                    currentTargetDef.IsExceedingBoundary = isExceedingBoundry;
                    stateDao.Update(currentTargetDef);
                }

            }
        }
        
        public Error IsValidWriteTag(long? targetDefinitionId, ISchedule schedule, TagInfo tagInfo)
        {
            List <TargetDefinition> targetsWithSameWriteTags = dao.QueryTargetDefinitionAlreadyUsingTag(targetDefinitionId, TagDirection.Write, tagInfo.IdValue);

            foreach (TargetDefinition target in targetsWithSameWriteTags)
            {
                if (target.Schedule.Overlaps(schedule))
                {
                    return new Error(string.Format(
                        "Target definition '{0}' at '{1}' with dates from {2} to {3} is already writing to Tag '{4}'",
                        target.Name,
                        target.FunctionalLocation.FullHierarchy, target.Schedule.StartDateTime,
                        target.Schedule.EndDateTime, tagInfo.Name));
                }
            }
            return Error.HasNoError;                                
        }

        /// <summary>
        /// Finds the schedule associated with the given schedule id
        /// </summary>
        /// <param name="scheduleId">Schedule id to query</param>
        /// <returns>Target definition associated to the schedule id</returns>
        public TargetDefinition QueryByScheduleId(long? scheduleId)
        {
            return dao.QueryByScheduleId(scheduleId);
        }

        public List<TargetDefinition> QueryByScheduleIds(IList<long> schedules)
        {
            return dao.QueryByScheduleIds(schedules);
        }

        /// <summary>
        /// Checks children Targets for Circular Dependencies.
        /// </summary>
        /// <param name="targetDefinition">Target Definition to check</param>
        /// <param name="stack">Contains the target ids up the tree of items.</param>
        private void CheckChildrenForCircularDependencies(TargetDefinition targetDefinition, Stack<long> stack)
        {
            foreach (TargetDefinitionDTO childTargetDTO in targetDefinition.AssociatedTargetDTOs)
            {
                // if the stack already has a child id, then a circular dependency has been found.
                if (stack.Contains(childTargetDTO.IdValue))
                {
                    stack.Push(childTargetDTO.IdValue);
                    TargetDefinition target = dao.QueryById(childTargetDTO.IdValue);
                    throw new LinkedTargetCircularReferenceException(stack.ToArray(), target);
                }
                stack.Push(childTargetDTO.IdValue);
                CheckChildrenForCircularDependencies(dao.QueryById(childTargetDTO.IdValue), stack);
            }
            // no circular dependencies found at the current level. So, pop the targetId off the stack
            // and return up a level.
            stack.Pop();
        }

        public bool HasLinkedActionItemDefinition(long? id)
        {
            return dao.QueryLinkedActionItemDefinitionCount(id) > 0;
        }
      
        public SchedulingList<TargetDefinition, OLTException> QueryAllAvailableForScheduling(List<long> siteIds)
        {
            return dao.QueryAllAvailableForScheduling(siteIds);
        }

        public List<TargetDefinitionHistory> GetHistory(long id)
        {
            return targetDefinitionHistoryDao.GetById(id);
        }

        public void UpdateStatusForValidTag(TagInfo tag, Site site)
        {
            List<TargetDefinition> targetDefinitionsWithTag = dao.QueryTargetDefinitionsWithInvalidTag(tag);
            if (targetDefinitionsWithTag.Count == 0) return;

            logger.DebugFormat("Found {0} target definitions associated with newly valid tag {1}.", targetDefinitionsWithTag.Count, tag);

            User systemUser = userService.GetRemoteAppUser();
            DateTime timeAtSite = timeService.GetTime(site.TimeZone);

            foreach (TargetDefinition targetDefinition in targetDefinitionsWithTag)
            {
                if (logger.IsDebugEnabled)
                    logger.DebugFormat(
                        "Target Definition {0} with ID {1} had status updated from Invalid Tag to Pending.",
                        targetDefinition.Name, targetDefinition.Id);

                targetDefinition.HasValidTag(systemUser, timeAtSite);
                dao.UpdateStatus(targetDefinition);

                TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetDefinition.Id, false, null);
                stateDao.Update(targetDefinitionState);

                editHistoryService.TakeSnapshot(targetDefinition);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetDefinitionUpdate, targetDefinition);
            }
        }

        public void UpdateStatusForInvalidTag(TagInfo tag, Site site)
        {
            List<TargetDefinition> targetDefinitionsWithTag = dao.QueryTargetDefinitionsWithValidTag(tag);            
            if (targetDefinitionsWithTag.Count == 0) return;

            if (logger.IsDebugEnabled)
                logger.DebugFormat("Found {0} target definitions associated with newly invalidated tag {1}.",
                                   targetDefinitionsWithTag.Count, tag);

            User systemUser = userService.GetRemoteAppUser();            
            DateTime timeAtSite = timeService.GetTime(site.TimeZone);

            foreach (TargetDefinition targetDefinition in targetDefinitionsWithTag)
            {
                logger.DebugFormat(
                    "Target Definition {0} with ID {1} had status updated to Invalid Tag.",
                    targetDefinition.Name, targetDefinition.Id);
                targetDefinition.HasInvalidTag(systemUser, timeAtSite);
                dao.UpdateStatus(targetDefinition);

                TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetDefinition.Id, false, null);
                stateDao.Update(targetDefinitionState);

                editHistoryService.TakeSnapshot(targetDefinition);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetDefinitionUpdate, targetDefinition);
            }
        }

        public Error IsValidName(string name, Site site, ISchedule schedule, TargetDefinition editObject)
        {
            long siteId = site.IdValue;

            if (GetCount(name, siteId) == 0)
            {
                return Error.HasNoError;
            }

            List<TargetDefinition> targetsWithSameName = dao.QueryByName(siteId, name);
            return TargetsOverlap(editObject, schedule, targetsWithSameName);            
        }

        public TargetDefinitionState QueryState(long id)
        {
            return stateDao.QueryById(id);
        }

        private static Error TargetsOverlap(TargetDefinition editObject, ISchedule schedule, IEnumerable<TargetDefinition> targetsWithSameName)
        {            
            StringBuilder errorMessage = new StringBuilder();
            
            foreach (TargetDefinition target in targetsWithSameName)
            {
                if (target.Schedule.Overlaps(schedule) && !target.HasSameIdAs(editObject))
                {
                    errorMessage.AppendLine(string.Format("Target '{0}' with date range {1} to {2} shares the same name", target.Name, target.Schedule.StartDateTime, target.Schedule.EndDateTime));                    
                }
            }
            
            return errorMessage.Length != 0 ? new Error(errorMessage.ToString()) : Error.HasNoError;
        }
    }
}
