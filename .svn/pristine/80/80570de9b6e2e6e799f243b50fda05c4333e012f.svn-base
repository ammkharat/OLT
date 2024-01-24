using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class ActionItemSchedulingService : ISchedulingService, IScheduleHandler
    {
        private const string ERROR_ON = "An error occurred when handling an action item definition ";
        private const string ERROR_ON_CREATE = ERROR_ON + " creation";
        private const string ERROR_ON_REMOVE = ERROR_ON + " remove";
        private const string ERROR_ON_UPDATE = ERROR_ON + " update";

        private const string ERROR_ON_OP_MODE_UPDATED =
            "An error occured when handling a unit-level functional location's operational mode update";

        private readonly IActionItemService actionItemService;

        private readonly ILog logger;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IFunctionalLocationOperationalModeService operationalModeService;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IScheduleService scheduleService;
        private readonly IActionItemDefinitionService service;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ITargetDefinitionService targetDefinitionService;
        private readonly ITimeService timeService;
        private bool stopServiceRequested;


        public ActionItemSchedulingService() : this(
            new NonBatchingScheduler(),
            SchedulerServiceRegistry.Instance.GetService<IActionItemDefinitionService>(),
            SchedulerServiceRegistry.Instance.GetService<IActionItemService>(),
            SchedulerServiceRegistry.Instance.GetService<IShiftPatternService>(),
            SchedulerServiceRegistry.Instance.RemoteEventRepeater,
            SchedulerServiceRegistry.Instance.GetService<IScheduleService>(),
            SchedulerServiceRegistry.Instance.GetService<ITimeService>(),
            SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>(),
            SchedulerServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
            SchedulerServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
            GenericLogManager.GetLogger<ActionItemSchedulingService>())
        {
        }

        public ActionItemSchedulingService(INonBatchingScheduler nonBatchingScheduler,
            IActionItemDefinitionService actionItemDefintionService, IActionItemService actionItemService,
            IShiftPatternService shiftPatternService, IRemoteEventRepeater remoteEventRepeater,
            IScheduleService scheduleService,
            ITimeService timeService, IFunctionalLocationOperationalModeService operationalModeService,
            ITargetDefinitionService targetDefinitionService, ISiteConfigurationService siteConfigurationService,
            ILog logger)
        {
            this.logger = logger;

            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            service = actionItemDefintionService;
            this.actionItemService = actionItemService;
            this.remoteEventRepeater = remoteEventRepeater;
            this.shiftPatternService = shiftPatternService;
            this.scheduleService = scheduleService;
            this.timeService = timeService;
            this.operationalModeService = operationalModeService;
            this.targetDefinitionService = targetDefinitionService;
            this.siteConfigurationService = siteConfigurationService;

            this.remoteEventRepeater.ServerActionItemDefinitionCreated +=
                remoteEventRepeater_ServerActionItemDefinitionCreated;
            this.remoteEventRepeater.ServerActionItemDefinitionRemoved +=
                remoteEventRepeater_ServerActionItemDefinitionRemoved;
            this.remoteEventRepeater.ServerActionItemDefinitionUpdated +=
                remoteEventRepeater_ServerActionItemDefinitionUpdated;

            this.remoteEventRepeater.ServerFunctionalLocationOperationalModeUpdated +=
                remoteEventRepeater_ServerFunctionalLocationOperationalModeUpdated;
        }

        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.Debug(String.Format("Stop {0} requested.", ScheduleName));
                    return;
                }

                logger.Debug("Action Item Scheduler firing schedule id: " + schedule.Id);

                if (schedule is ActionItemDefinitionFLOCShiftAdjustedSchedule)
                {
                    var adjustedSchedule = (ActionItemDefinitionFLOCShiftAdjustedSchedule) schedule;
                    var actionItemDefinition = service.QueryById(adjustedSchedule.ActionItemDefinitionId);

                    var atLeastOneActionItemGenerated = GenerateActionItems(actionItemDefinition, adjustedSchedule);
                    if (atLeastOneActionItemGenerated)
                    {
                        // The Last Invoked Date Time has been updated by the Scheduler, so this needs to be persisted into the DB.
                        scheduleService.Update(adjustedSchedule.InternalSchedule);
                        logger.Debug(
                            string.Format(
                                "Action Item Scheduler calling Service Update for Action Item Definition (Id = {0}) with Schedule {1}",
                                actionItemDefinition.IdValue,
                                schedule.Id));
                    }
                    else
                    {
                        var noActionItemInsertedLogMessage =
                            string.Format(
                                "Action Item Scheduler did not insert any ActionItem as Action Item Definition (Id = {0})",
                                actionItemDefinition.IdValue);
                        logger.Debug(noActionItemInsertedLogMessage);
                    }

                    logger.Debug("Finished Firing Action Item Scheduler Id = " + schedule.Id);
                }
                else
                {
                    logger.Error("Schedule id " + schedule.Id + " is not triggered because it is not type of " +
                                 (typeof (ActionItemDefinitionFLOCShiftAdjustedSchedule)));
                }
            }
            catch (Exception e)
            {
                logger.Error(
                    "An error occured when action item definition with schedule id " + schedule.Id + " was triggered", e);
            }
        }

        public void LoadScheduler()
        {
            var actionItemDefinitions = service.QueryAllAvailableForScheduling();

            nonBatchingScheduler.StartInitialLoad();

            foreach (var actionItemDefinition in actionItemDefinitions)
            {
                AddActionItemDefinitionSchedule(actionItemDefinition);
            }

            nonBatchingScheduler.InitialLoadComplete();
        }

        public string ScheduleName
        {
            get { return "Action Item Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }

        private void remoteEventRepeater_ServerActionItemDefinitionUpdated(object sender,
            DomainEventArgs<ActionItemDefinition> e)
        {
            try
            {
                var aiDefinition = e.SelectedItem;
                RemoveActionItemDefinitionSchedule(aiDefinition);

                if (aiDefinition.Is(ActionItemDefinitionStatus.Approved))
                {
                    AddActionItemDefinitionSchedule(aiDefinition);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_UPDATE, ex);
            }
        }

        private void remoteEventRepeater_ServerActionItemDefinitionRemoved(object sender,
            DomainEventArgs<ActionItemDefinition>
                eventArgs)
        {
            try
            {
                var aid = eventArgs.SelectedItem;
                logger.Debug("Received Action Item Definition Remove Event for id " + aid.Id + " scheduleId = " +
                             aid.Schedule.Id);
                RemoveActionItemDefinitionSchedule(aid);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_REMOVE, ex);
            }
        }

        private void remoteEventRepeater_ServerActionItemDefinitionCreated(object sender,
            DomainEventArgs<ActionItemDefinition>
                eventArgs)
        {
            try
            {
                var aid = eventArgs.SelectedItem;
                logger.Debug("Recieved Action Item Definition Added Event for id " + aid.Id + " scheduleId = " +
                             aid.Schedule.Id);
                AddActionItemDefinitionSchedule(aid);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_CREATE, ex);
            }
        }

        private void remoteEventRepeater_ServerFunctionalLocationOperationalModeUpdated(object sender,
            DomainEventArgs<FunctionalLocation> e)
        {
            try
            {
                UnitOperationalModeChanged(e.SelectedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_OP_MODE_UPDATED, ex);
            }
        }

        public void AddActionItemDefinitionSchedule(ActionItemDefinition actionItemDefinition)
        {
            try
            {
                AdjustActionItemDefintionShiftTimeToBegingingOfShift(actionItemDefinition);
                logger.Debug("Finish adjusted schedule aid id = " + actionItemDefinition.Id + " scheduleId = " +
                             actionItemDefinition.Schedule.Id +
                             " status is " + actionItemDefinition.Status);
                if (actionItemDefinition.Is(ActionItemDefinitionStatus.Approved) && actionItemDefinition.Active)
                {
                    try
                    {
                        nonBatchingScheduler.AddSchedule(actionItemDefinition.Schedule);
                    }
                    catch (ExpectedNonDivisionLevelFLOCException)
                    {
                        var msg = "Unable to add a Action Item definition id=" + actionItemDefinition.Id +
                                  "'s schedule because it's set at a Division. Probable issue with Action Item sourced from SAP.";
                        logger.Warn(msg);
                    }
                    catch (Exception e)
                    {
                        var msg = "Unable to add a Action Item definition id=" + actionItemDefinition.Id + "'s schedule";
                        logger.Error(msg, e);
                        // swallow the error so that we can continue process all other log definitions
                    }
                }
            }
            catch (Exception e)
            {
                var msg = "Unable to add a Action Item definition id=" + actionItemDefinition.Id + "'s schedule";
                logger.Error(msg, e);
                // swallow the error so that we can continue process all other log definitions
            }
        }

        /// <summary>
        ///     When a unit-level floc's operational mode changes, we want to re-evaluate all action item definitions linked
        ///     to a floc that's part of that unit, because they might now fire due to the operational modes matching up.
        /// </summary>
        public void UnitOperationalModeChanged(FunctionalLocation unit)
        {
            var schedules = new List<TimeZoneConvertedSchedule>(nonBatchingScheduler.Schedules);

            foreach (var schedule in schedules)
            {
                var actionItemDefinitionSchedule = (ActionItemDefinitionFLOCShiftAdjustedSchedule) schedule.Schedule;

                if (actionItemDefinitionSchedule.IsAffectedByUnit(unit))
                {
                    var actionItemDefinition = service.QueryById(actionItemDefinitionSchedule.ActionItemDefinitionId);
                    remoteEventRepeater_ServerActionItemDefinitionUpdated(this,
                        new DomainEventArgs<ActionItemDefinition>(actionItemDefinition));
                }
            }
        }

        private bool AllAssociatedTargetDefinitionsAreExceedingThresholds(ActionItemDefinition actionItemDefinition)
        {
            var dtos = actionItemDefinition.TargetDefinitionDTOs;
            return dtos.TrueForAll(IsExceedingThresholds);
        }

        private bool GenerateActionItems(ActionItemDefinition actionItemDefinition,
            ActionItemDefinitionFLOCShiftAdjustedSchedule adjustedSchedule)
        {
            if (!actionItemDefinition.TargetDefinitionDTOs.IsEmpty() &&
                !AllAssociatedTargetDefinitionsAreExceedingThresholds(actionItemDefinition))
            {
                return false;
            }

            var atLeastOneActionItemGenerated = false;
           // -- Old comment  --  // There are some Action Items that come from SAP where the floc level is Level 1 or 2, ignore creating Action Items for these.
           // -- new comment --  // As per new request edmonton Enhancement changesallowing Action item to trigger from level 1 or 2 also  
            var unitOrBelowFlocs =
                actionItemDefinition.FunctionalLocations.FindAll(f => f.Type >= FunctionalLocationType.Level1);        

            if (actionItemDefinition.CreateAnActionItemForEachFunctionalLocation)
            {
                foreach (var floc in unitOrBelowFlocs)
                {
                    var flocOperationalModeDTO =
                        operationalModeService.GetByFunctionalLocationId(floc.IdValue);

                    if (flocOperationalModeDTO.OperationalMode.Equals(actionItemDefinition.OperationalMode))
                    {
                        InsertActionItem(actionItemDefinition, floc, adjustedSchedule);
                        atLeastOneActionItemGenerated = true;
                    }
                    else
                    {
                        DebugLogActionItemMessage("Action Item --NOT-- inserted.",
                            actionItemDefinition.IdValue,
                            actionItemDefinition.OperationalMode.Name,
                            floc.FullHierarchy,
                            flocOperationalModeDTO.OperationalMode.Name);
                    }
                }
            }
            else
            {
                var atLeastOneFlocMatchesDefinitionOperationMode =
                    AtLeastOneFlocMatchesDefinitionOperationMode(actionItemDefinition, unitOrBelowFlocs);
                if (atLeastOneFlocMatchesDefinitionOperationMode)
                {
                    InsertActionItem(actionItemDefinition, unitOrBelowFlocs, adjustedSchedule);
                    atLeastOneActionItemGenerated = true;
                }
                else
                {
                    DebugLogActionItemMessage("Action Item --NOT-- inserted.",
                        actionItemDefinition.IdValue,
                        actionItemDefinition.OperationalMode.Name,
                        unitOrBelowFlocs.FullHierarchyListToString(false, false),
                        "");
                }
            }

            return atLeastOneActionItemGenerated;
        }

        private bool IsExceedingThresholds(TargetDefinitionDTO targetDefinitionDto)
        {
            var targetDefinition = targetDefinitionService.QueryById(targetDefinitionDto.IdValue);
            if (!targetDefinition.IsInStateForGeneratingAlerts)
            {
                return false;
            }

            var state = targetDefinitionService.QueryState(targetDefinitionDto.IdValue);
            return state.IsExceedingBoundary;
        }

        private bool AtLeastOneFlocMatchesDefinitionOperationMode(ActionItemDefinition actionItemDefinition,
            IEnumerable<FunctionalLocation> unitOrBelowFlocs)
        {
            var operationModeDtos = new List<FunctionalLocationOperationalModeDTO>();

            foreach (var floc in unitOrBelowFlocs)
            {
                var flocOperationalModeDTO =
                    operationalModeService.GetByFunctionalLocationId(floc.IdValue);
                operationModeDtos.Add(flocOperationalModeDTO);

                if (flocOperationalModeDTO.OperationalMode.Equals(actionItemDefinition.OperationalMode))
                {
                    return true;
                }
            }

            var message = String.Format(
                "Action Item Definition (Id = {0})'s Operational mode = {1} does not match any of the modes for its Functional Locations:",
                actionItemDefinition.Id, actionItemDefinition.OperationalMode);
            foreach (var operationalModeDto in operationModeDtos)
            {
                message += Environment.NewLine +
                           String.Format(
                               "      Functional Location ({0})'s Operational Mode = {1}",
                               operationalModeDto.FullHierarchy,
                               operationalModeDto.OperationalMode.Name);
            }
            logger.Debug(message);

            return false;
        }

        private void InsertActionItem(ActionItemDefinition actionItemDefinition,
            FunctionalLocation flocForNewActionItem,
            ActionItemDefinitionFLOCShiftAdjustedSchedule adjustedSchedule)
        {
            InsertActionItem(actionItemDefinition, new List<FunctionalLocation> {flocForNewActionItem}, adjustedSchedule);
        }

        private void InsertActionItem(ActionItemDefinition actionItemDefinition,
            List<FunctionalLocation> flocs,
            ActionItemDefinitionFLOCShiftAdjustedSchedule adjustedSchedule)
        {
            //
            //  Create a new Document List so that it is not tight to original ActionItemDefinition

            //
            var newDocuments = new List<DocumentLink>();
            if (!actionItemDefinition.DocumentLinks.IsEmpty())
            {
                foreach (var documentLink in actionItemDefinition.DocumentLinks)
                {
                    var newDocument = (DocumentLink) documentLink.Clone();
                    newDocument.Id = null; //null the id so it is treated like a new object
                    newDocuments.Add(newDocument);
                }
            }

            var currentTimeAtSite = timeService.GetTime(flocs[0].Site.TimeZone);
            var siteConfiguration = siteConfigurationService.QueryBySiteId(flocs[0].Site.IdValue);

            var actionItem = new ActionItem(actionItemDefinition.Name,
                actionItemDefinition.Description,
                actionItemDefinition.ResponseRequired,
                ActionItemStatus.Current,
                actionItemDefinition.Priority,
                actionItemDefinition.Source,
                ScheduleHelper.GetScheduleInstanceStartDateTime(actionItemDefinition.Schedule, currentTimeAtSite,
                    siteConfiguration.PreShiftPaddingInMinutes),
                ScheduleHelper.GetScheduleInstanceEndDateTime(actionItemDefinition.Schedule, currentTimeAtSite,
                    siteConfiguration.PreShiftPaddingInMinutes),
                GetShiftAdjustedDateTimeToShiftEndTime(adjustedSchedule, currentTimeAtSite),
                adjustedSchedule.Type,
                flocs,
                actionItemDefinition.Category,
                actionItemDefinition.LastModifiedBy,
                currentTimeAtSite,
                newDocuments,
                null,
                actionItemDefinition,
                actionItemDefinition.Assignment,
                actionItemDefinition.AssociatedFormGN75BId,
                actionItemDefinition.AssociatedFormGN75BId1,  //mangesh - DMND0005327 Request 15
                actionItemDefinition.AssociatedFormGN75BId2,
                actionItemDefinition.VisGroupsStartingWith,actionItemDefinition.IdValue,
                new List<CustomFieldEntry>(),
                new List<CustomField>(),
                actionItemDefinition.Customfieldgroup,string.Empty,new List<ActionItemResponseTracker>(),actionItemDefinition.Reading);             //ayman visibility groups     ayman action item definition

            actionItemService.Insert(actionItem);

            DebugLogActionItemMessage(
                "Action Item inserted",
                actionItemDefinition.IdValue,
                actionItemDefinition.OperationalMode.Name,
                flocs.FullHierarchyListToString(false, false),
                actionItemDefinition.OperationalMode.Name);
        }

        private void RemoveActionItemDefinitionSchedule(ActionItemDefinition actionItemDefinition)
        {
            logger.DebugFormat("Removing schedule with id:<{0}>", actionItemDefinition.Schedule.Id);
            nonBatchingScheduler.RemoveSchedule(actionItemDefinition.Schedule);
        }

        private void AdjustActionItemDefintionShiftTimeToBegingingOfShift(ActionItemDefinition actionItemDefintion)
        {
            if (null == actionItemDefintion.FunctionalLocations || actionItemDefintion.FunctionalLocations.Count == 0)
            {
                var msg = "Action Item Defintion Id " + actionItemDefintion.Id +
                          " Action Item Defintion does not have corresponding functional location";
                logger.Warn(msg);
            }

            //
            // Upon logging in the user selects a shift.  Creating/Updating an AID, the user
            // is presented with the FLOC list based on the selected SHIFT to be selected for the AID.
            // Thus, all FLOCs in the AID belogns to a shift.
            //
            if (actionItemDefintion.FunctionalLocations != null)
            {
                var adjustedSchedule =
                    new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefintion.Schedule,
                        actionItemDefintion.FunctionalLocations[0],
                        actionItemDefintion.IdValue,
                        shiftPatternService);

                actionItemDefintion.Schedule = adjustedSchedule;
            }
        }


        public DateTime GetShiftAdjustedDateTimeToShiftEndTime(ActionItemDefinitionFLOCShiftAdjustedSchedule schedule,
            DateTime currentDateTimeAtSite)
        {
            var siteConfiguration = siteConfigurationService.QueryBySiteId(schedule.Site.IdValue);

            var instanceDateTime = ScheduleHelper.GetScheduleInstanceEndDateTime(schedule, currentDateTimeAtSite,
                siteConfiguration.PreShiftPaddingInMinutes);

            // TODO: Should make EndDate and EndDateTime Nullable<Date> and Nullable<DateTime> and then check that instead.
            if (instanceDateTime == DateTime.MaxValue)
                return DateTime.MaxValue;

            var shiftPattern = shiftPatternService.GetShiftBySiteAndDateTimeFavourEarlierShift(schedule.Site,
                instanceDateTime);
            return AdjustInitialDateTimeWithNewTime(instanceDateTime, shiftPattern.EndTime);
        }

        private static bool DoesIntitalDateTimeRollOverToNextDay(DateTime initialDateTime, Time newTime)
        {
            var initalTime = new Time(initialDateTime);
            return initalTime > newTime;
        }

        private static DateTime AdjustInitialDateTimeWithNewTime(DateTime initialDateTime, Time newTime)
        {
            var newDateTime = new DateTime(initialDateTime.Year, initialDateTime.Month, initialDateTime.Day,
                newTime.Hour, newTime.Minute, newTime.Second);

            if (DoesIntitalDateTimeRollOverToNextDay(initialDateTime, newTime) && newDateTime != DateTime.MaxValue)
            {
                newDateTime = newDateTime.AddDays(1);
            }
            return newDateTime;
        }

        private void DebugLogActionItemMessage(string logMessage, long actionItemDefinitionId, string aidOpModeName,
            string flocFullHierarchy, string flocOpModeName)
        {
            var actionItemInfoLogTemplate = logMessage +
                                            "--" +
                                            "Action Item Definition (Id = {0})'s Operational mode = {1} and " +
                                            "Functional Location ({2})'s Operational Mode = {3}";

            logMessage = string.Format(actionItemInfoLogTemplate,
                actionItemDefinitionId,
                aidOpModeName,
                flocFullHierarchy,
                flocOpModeName);
            logger.Debug(logMessage);
        }
    }
}