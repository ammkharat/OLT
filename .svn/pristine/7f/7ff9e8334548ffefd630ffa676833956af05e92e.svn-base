using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class LabAlertSchedulingService : ISchedulingService, IScheduleHandler
    {
        private readonly Dictionary<long, DateTime> definitionIdToOriginalIntendedEvaluationDateTimeMap =
            new Dictionary<long, DateTime>();

        private readonly Dictionary<long, int> definitionIdToRetryCountMap = new Dictionary<long, int>();
        private readonly object fakeScheduleIdForRetryLockObject = new object();

        private readonly ILabAlertDefinitionService labAlertDefinitionService;
        private readonly ILabAlertService labAlertService;
        private readonly ILog logger;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IScheduleService scheduleService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ITimeService timeService;
        private readonly IUserService userService;

        private long fakeScheduleIdForRetries;

        private bool stopServiceRequested;

        public LabAlertSchedulingService()
            : this(
                GenericLogManager.GetLogger<LabAlertSchedulingService>(),
                new NonBatchingScheduler(),
                SchedulerServiceRegistry.Instance.RemoteEventRepeater,
                SchedulerServiceRegistry.Instance.GetService<ILabAlertDefinitionService>(),
                SchedulerServiceRegistry.Instance.GetService<ILabAlertService>(),
                SchedulerServiceRegistry.Instance.GetService<IScheduleService>(),
                SchedulerServiceRegistry.Instance.GetService<ITimeService>(),
                SchedulerServiceRegistry.Instance.GetService<IUserService>(),
                SchedulerServiceRegistry.Instance.GetService<ISiteConfigurationService>()
                )
        {
        }

        public LabAlertSchedulingService(
            ILog logger,
            INonBatchingScheduler nonBatchingScheduler,
            IRemoteEventRepeater remoteEventRepeater,
            ILabAlertDefinitionService labAlertDefinitionService,
            ILabAlertService labAlertService,
            IScheduleService scheduleService,
            ITimeService timeService,
            IUserService userService,
            ISiteConfigurationService siteConfigurationService)
        {
            this.logger = logger;

            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.remoteEventRepeater = remoteEventRepeater;
            this.labAlertDefinitionService = labAlertDefinitionService;
            this.labAlertService = labAlertService;
            this.scheduleService = scheduleService;
            this.timeService = timeService;
            this.userService = userService;
            this.siteConfigurationService = siteConfigurationService;

            this.remoteEventRepeater.ServerLabAlertDefinitionCreated += Repeater_DefinitionCreated;
            this.remoteEventRepeater.ServerLabAlertDefinitionRemoved += Repeater_DefinitionRemoved;
            this.remoteEventRepeater.ServerLabAlertDefinitionUpdated += Repeater_DefinitionUpdated;
        }

        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            Evaluate(schedule, intendedScheduleExecutionTime, false);
        }

        public void LoadScheduler()
        {
            logger.Info("Start Loading Lab Alert Definitions");

            var schedulingList = labAlertDefinitionService.QueryAllAvailableForScheduling();

            foreach (var exception in schedulingList.ExceptionList)
            {
                logger.Warn(exception.Message, exception);
            }

            nonBatchingScheduler.StartInitialLoad();

            CatchUpOnMissedSchedules(schedulingList.DomainObjectList);

            schedulingList = labAlertDefinitionService.QueryAllAvailableForScheduling();
            foreach (var definition in schedulingList.DomainObjectList)
            {
                AddLabAlertDefinitionSchedule(definition);
            }

            logger.Debug("Loading Lab Alert Definitions Done");

            nonBatchingScheduler.InitialLoadComplete();
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }

        public string ScheduleName
        {
            get { return "Lab Alert Scheduler"; }
        }

        private void CatchUpOnMissedSchedules(List<LabAlertDefinition> definitions)
        {
            definitions.Sort((d1, d2) => DateTime.Compare(d1.Schedule.StartDateTime, d2.Schedule.StartDateTime));

            foreach (var currentDefinition in definitions)
            {
                var currentTimeAtSite = timeService.GetTime(currentDefinition.FunctionalLocation.Site.TimeZone);

                var schedule = currentDefinition.Schedule;

                var nextInvokeDateTimes = schedule.NextInvokeDateTimes(currentTimeAtSite);

                foreach (var nextInvokeDateTime in nextInvokeDateTimes)
                {
                    Evaluate(schedule, nextInvokeDateTime, true);
                }
            }
        }

        private void Repeater_DefinitionCreated(object sender, DomainEventArgs<LabAlertDefinition> e)
        {
            AddLabAlertDefinitionSchedule(e.SelectedItem.IdValue);
        }

        private void Repeater_DefinitionRemoved(object sender, DomainEventArgs<LabAlertDefinition> e)
        {
            RemoveLabAlertDefinitionSchedule(e.SelectedItem);
        }

        private void Repeater_DefinitionUpdated(object sender, DomainEventArgs<LabAlertDefinition> e)
        {
            RemoveLabAlertDefinitionSchedule(e.SelectedItem);
            AddLabAlertDefinitionSchedule(e.SelectedItem.IdValue);
        }

        private void AddLabAlertDefinitionSchedule(long definitionId)
        {
            var definition = labAlertDefinitionService.QueryById(definitionId);
            AddLabAlertDefinitionSchedule(definition);
        }

        private void AddLabAlertDefinitionSchedule(LabAlertDefinition definition)
        {
            if (definition.IsActive)
            {
                logger.Info("Adding schedule for lab alert definition id: " + definition.Id);

                try
                {
                    var schedule = definition.Schedule;
                    AddSchedule(schedule, definition.Id);
                }
                catch (Exception e)
                {
                    var msg = "Unable to add a schedule for lab alert definition, id: " + definition.Id;
                    logger.Error(msg, e);
                    // swallow the exception because we want to still allow the Scheduler to run
                }
            }
            else
            {
                if (logger.IsDebugEnabled)
                {
                    logger.Debug("Not Adding schedule for lab alert definition id: " + definition.Id
                                 + " because it is not active");
                }
            }
        }

        private void AddSchedule(ISchedule schedule, long? definitionId)
        {
            nonBatchingScheduler.AddSchedule(schedule);

            if (logger.IsDebugEnabled)
            {
                var definitionIdString = definitionId != null ? definitionId.ToString() : StringResources.None;
                logger.DebugFormat("Added schedule for lab alert id: {0} schedule: {1}", definitionIdString, schedule.Id);
            }
        }

        private void RemoveLabAlertDefinitionSchedule(LabAlertDefinition definition)
        {
            logger.Debug("Removing schedule for lab alert definition: " + definition.Id);

            var schedule = definition.Schedule;
            nonBatchingScheduler.RemoveSchedule(schedule);

            RemoveAllRetrySchedulesForDefinition(definition);
            ClearRetryCountAndScheduleExecutionTime(definition.IdValue);
        }

        private void RemoveAllRetrySchedulesForDefinition(LabAlertDefinition definition)
        {
            var schedules = nonBatchingScheduler.Schedules;

            foreach (var potentialScheduleToRemove in schedules)
            {
                var sch = potentialScheduleToRemove.Schedule;
                if (sch != null &&
                    sch is LabAlertRetrySchedule &&
                    ((LabAlertRetrySchedule) sch).Definition.IdValue == definition.IdValue)
                {
                    nonBatchingScheduler.RemoveSchedule(sch);
                }
            }
        }

        private void Evaluate(ISchedule schedule, DateTime? intendedScheduleExecutionTime, bool isDoingCatchUp)
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.InfoFormat("Stop {0} requested. So ignoring ScheduleTrigger as we are shutting down.",
                        ScheduleName);
                    return;
                }

                if (logger.IsDebugEnabled)
                {
                    logger.Debug("Finding Lab Alert Definition for schedule id: " + schedule.Id);
                }

                var definition = GetDefinition(schedule);

                if (definition == null)
                {
                    nonBatchingScheduler.RemoveSchedule(schedule);
                    logger.Warn("No lab alert definition corresponding to schedule: " + schedule.Id +
                                ". Removing from scheduler.");
                    return;
                }

                logger.InfoFormat("Evaluating Lab Alert Definition with id:<{0}> name:<{1}>",
                    definition.Id, definition.Name);

                var scheduleExecutionTime =
                    GetOriginalIntendedScheduleExecutionTimeFromMap(definition.IdValue, intendedScheduleExecutionTime);

                var wasSuccesful = labAlertService.EvaluateDefinition(definition, scheduleExecutionTime);

                var currentTimeAtSite = timeService.GetTime(schedule.Site.TimeZone);

                if (wasSuccesful)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("Done evaluating Lab Alert Definition with id:<{0}>", definition.Id);
                    }

                    var scheduleToSave = GetScheduleToSave(schedule);

                    if (isDoingCatchUp)
                    {
                        // This gets set by the normal timer trigger, but has to be set manually if doing catch up.
                        logger.Debug("Catching up. Setting schedule's LastInvokedDateTime to: " + currentTimeAtSite);
                        scheduleToSave.LastInvokedDateTime = currentTimeAtSite;
                    }

                    scheduleService.Update(scheduleToSave);

                    ClearRetryCountAndScheduleExecutionTime(definition.IdValue);
                }
                else if (!isDoingCatchUp)
                {
                    var siteConfiguration =
                        siteConfigurationService.QueryBySiteId(definition.FunctionalLocation.Site.IdValue);

                    var maximumNumberOfRetries = siteConfiguration.LabAlertRetryAttemptLimit;
                    var retryCountValue = GetRetryCount(definition.IdValue);

                    if (retryCountValue >= maximumNumberOfRetries)
                    {
                        var originalExecutionTime = GetOriginalIntendedScheduleExecutionTimeFromMap(definition.IdValue);
                        CreateDataHistorianAccessErrorLabAlert(definition, originalExecutionTime, currentTimeAtSite);
                        ClearRetryCountAndScheduleExecutionTime(definition.IdValue);
                    }
                    else
                    {
                        var nextHour = intendedScheduleExecutionTime.Value.AddHours(1);
                        var retryDate = new Date(nextHour);
                        var retryTime = new Time(nextHour);
                        var nextRetrySchedule = CreateRetrySchedule(definition, schedule, retryDate, retryTime);
                        nextRetrySchedule.Id = GetNextFakeScheduleId();
                        AddSchedule(nextRetrySchedule, null);

                        IncrementRetryCount(definition.IdValue);
                    }

                    logger.DebugFormat("There was a problem evaluating the lab alert definition with id: <{0}>",
                        definition.Id);
                }
                else
                {
                    var originalScheduleExecutionTime =
                        GetOriginalIntendedScheduleExecutionTimeFromMap(definition.IdValue);
                    CreateDataHistorianAccessErrorLabAlert(definition, originalScheduleExecutionTime, currentTimeAtSite);
                }
            }
            catch (Exception e)
            {
                // Remove all the retry schedules from the scheduler.
                nonBatchingScheduler.RemoveMatchingSchedules(
                    s => s.Schedule != null && s.Schedule is LabAlertRetrySchedule);

                ClearAllRetryCountsAndScheduleExecutionTimes();

                logger.Error(
                    "An error occured when evaluating target definition with schedule id " + schedule.Id +
                    " was triggered", e);
            }
        }

        private static ISchedule GetScheduleToSave(ISchedule schedule)
        {
            if (schedule is LabAlertRetrySchedule)
            {
                return ((LabAlertRetrySchedule) schedule).OriginalSchedule;
            }

            return schedule;
        }

        private void CreateDataHistorianAccessErrorLabAlert(LabAlertDefinition definition,
            DateTime? intendedScheduleExecutionTime, DateTime currentTimeAtSite)
        {
            var systemUser = userService.GetRemoteAppUser();

            var labAlert =
                LabAlert.CreateLabAlertForTagFailure(
                    definition, intendedScheduleExecutionTime.Value, systemUser, currentTimeAtSite);

            labAlertService.InsertLabAlert(labAlert);
        }

        private static ISchedule CreateRetrySchedule(LabAlertDefinition definition, ISchedule schedule, Date retryDate,
            Time retryTime)
        {
            ISchedule originalSchedule;

            if (schedule is LabAlertRetrySchedule)
            {
                originalSchedule = ((LabAlertRetrySchedule) schedule).OriginalSchedule;
            }
            else
            {
                originalSchedule = schedule;
            }

            return new LabAlertRetrySchedule(definition, originalSchedule, retryDate, retryTime, retryTime,
                schedule.Site);
        }

        private LabAlertDefinition GetDefinition(ISchedule schedule)
        {
            if (schedule is LabAlertRetrySchedule)
            {
                return ((LabAlertRetrySchedule) schedule).Definition;
            }

            return labAlertDefinitionService.QueryByScheduleId(schedule.IdValue);
        }

        private int GetRetryCount(long definitionId)
        {
            if (!definitionIdToRetryCountMap.ContainsKey(definitionId))
            {
                definitionIdToRetryCountMap.Add(definitionId, 0);
            }

            return definitionIdToRetryCountMap[definitionId];
        }

        private void ClearRetryCountAndScheduleExecutionTime(long definitionId)
        {
            if (definitionIdToRetryCountMap.ContainsKey(definitionId))
            {
                definitionIdToRetryCountMap.Remove(definitionId);
            }

            if (definitionIdToOriginalIntendedEvaluationDateTimeMap.ContainsKey(definitionId))
            {
                definitionIdToOriginalIntendedEvaluationDateTimeMap.Remove(definitionId);
            }
        }

        private void ClearAllRetryCountsAndScheduleExecutionTimes()
        {
            try
            {
                definitionIdToRetryCountMap.Clear();
                definitionIdToOriginalIntendedEvaluationDateTimeMap.Clear();
            }
            catch (Exception e)
            {
                logger.Error("There was an error clearing state.", e);
            }
        }

        private void IncrementRetryCount(long definitionId)
        {
            var retryCount = GetRetryCount(definitionId);
            definitionIdToRetryCountMap[definitionId] = retryCount + 1;
        }

        private long GetNextFakeScheduleId()
        {
            lock (fakeScheduleIdForRetryLockObject)
            {
                fakeScheduleIdForRetries = fakeScheduleIdForRetries - 1;
                return fakeScheduleIdForRetries;
            }
        }

        private DateTime? GetOriginalIntendedScheduleExecutionTimeFromMap(long definitionId,
            DateTime? intendedScheduleExecutionTime)
        {
            if (!definitionIdToOriginalIntendedEvaluationDateTimeMap.ContainsKey(definitionId))
            {
                definitionIdToOriginalIntendedEvaluationDateTimeMap.Add(definitionId,
                    intendedScheduleExecutionTime.Value);
            }

            return definitionIdToOriginalIntendedEvaluationDateTimeMap[definitionId];
        }

        private DateTime? GetOriginalIntendedScheduleExecutionTimeFromMap(long definitionId)
        {
            if (!definitionIdToOriginalIntendedEvaluationDateTimeMap.ContainsKey(definitionId))
            {
                throw new OLTException(
                    "This is a serious error. This function should never be called unless there is an evaluation time in the map");
            }

            return definitionIdToOriginalIntendedEvaluationDateTimeMap[definitionId];
        }
    }
}