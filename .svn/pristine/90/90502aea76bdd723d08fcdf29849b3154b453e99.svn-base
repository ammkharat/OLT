using System;
using System.Collections.Generic;
using System.Diagnostics;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class TargetSchedulingService : ISchedulingService, IScheduleHandler, IBatchHandler
    {
        private const string ERROR_ON = "An error occured when handling an target definition ";
        private const string ERROR_ON_CREATE = ERROR_ON + " creation";
        private const string ERROR_ON_REMOVE = ERROR_ON + " remove";
        private const string ERROR_ON_UPDATE = ERROR_ON + " update";

        private const string DateTimeFormat = "yy-MM-dd HH:mm:ss.ffff";

        private const int BatchForRemoteCall = 1000;

        private const string NoSitesConfiguredMessage =
            "There are no sites configured for the target scheduler. No target definitions will be loaded. " +
            "The parameter 'SitesToLoadTargets' must be configured in the App.config file for the target scheduler.";

        private readonly IBatchingScheduler batchScheduler;
        private readonly ILog logger;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IFunctionalLocationOperationalModeService operationalModeService;
        private readonly ILog perfLogger = LogManager.GetLogger("TargetSchedulerPerfLogger");
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IScheduleService scheduleService;

        private readonly List<long> sitesToLoadTargets = new List<long>();
        private readonly ITargetDefinitionService targetDefintionService;
        private readonly ITargetAlertService targetService;

        private bool stopServiceRequested;


        public TargetSchedulingService() : this(
            SchedulerServiceRegistry.Instance.GetService<ITargetAlertService>(),
            new NonBatchingScheduler(), // to re-enable batching, this needs to be changed to new BatchingScheduler()
            SchedulerServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
            SchedulerServiceRegistry.Instance.RemoteEventRepeater,
            SchedulerServiceRegistry.Instance.GetService<IScheduleService>(),
            GenericLogManager.GetLogger<TargetSchedulingService>(),
            SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>(),
            new List<long>(0))
        {
            sitesToLoadTargets.Clear();
            sitesToLoadTargets.AddRange(SitesToLoadTargetsFromConfiguration);
        }

        public TargetSchedulingService(ITargetAlertService targetAlertService, IBatchingScheduler batchScheduler,
            ITargetDefinitionService targetDefintionService,
            IRemoteEventRepeater remoteEventRepeater, IScheduleService scheduleService,
            ILog logger, IFunctionalLocationOperationalModeService operationalModeService,
            IEnumerable<long> sitesToLoadTargets)
        {
            this.logger = logger;
            this.scheduleService = scheduleService;
            targetService = targetAlertService;

            batchScheduler.BatchHandler = this;
            this.batchScheduler = batchScheduler;

            this.targetDefintionService = targetDefintionService;
            this.remoteEventRepeater = remoteEventRepeater;
            this.operationalModeService = operationalModeService;

            this.sitesToLoadTargets.Clear();
            this.sitesToLoadTargets.AddRange(sitesToLoadTargets);

            this.remoteEventRepeater.ServerTargetDefinitionCreated +=
                targetDefintionService_TargetDefintionCreated;
            this.remoteEventRepeater.ServerTargetDefinitionRemoved +=
                targetDefintionService_TargetDefintionRemoved;
            this.remoteEventRepeater.ServerTargetDefinitionUpdated +=
                targetDefintionService_TargetDefintionUpdated;
        }

        public TargetSchedulingService(ITargetAlertService targetAlertService,
            INonBatchingScheduler nonBatchingScheduler,
            ITargetDefinitionService targetDefintionService,
            IRemoteEventRepeater remoteEventRepeater, IScheduleService scheduleService,
            ILog logger, IFunctionalLocationOperationalModeService operationalModeService,
            IEnumerable<long> sitesToLoadTargets)
        {
            this.logger = logger;
            this.scheduleService = scheduleService;
            targetService = targetAlertService;

            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.targetDefintionService = targetDefintionService;
            this.remoteEventRepeater = remoteEventRepeater;
            this.operationalModeService = operationalModeService;

            this.sitesToLoadTargets.Clear();
            this.sitesToLoadTargets.AddRange(sitesToLoadTargets);

            this.remoteEventRepeater.ServerTargetDefinitionCreated +=
                targetDefintionService_TargetDefintionCreated;
            this.remoteEventRepeater.ServerTargetDefinitionRemoved +=
                targetDefintionService_TargetDefintionRemoved;
            this.remoteEventRepeater.ServerTargetDefinitionUpdated +=
                targetDefintionService_TargetDefintionUpdated;
        }

        private IEnumerable<long> SitesToLoadTargetsFromConfiguration
        {
            get
            {
                var siteIds = new List<long>(0);

                string commaSeparatedSiteList = null;

                try
                {
                    commaSeparatedSiteList = Constants.SitesToLoadTargets;
                    var siteIdStrings = commaSeparatedSiteList.BuildListFromCommaSeparatedList();
                    siteIds = siteIdStrings.ConvertAll(Convert.ToInt64);
                }
                catch (Exception e)
                {
                    commaSeparatedSiteList = commaSeparatedSiteList ?? "<nothing>";

                    var message = "There was an error locating the sites to load targets for. " +
                                  "This is likely due to a badly configured App.config file for the target scheduler. " +
                                  "The parameter 'SitesToLoadTargets' must be set to the site IDs to load target definitions for." +
                                  "The configuration parameter is currently set to: " + commaSeparatedSiteList;
                    logger.Error(message, e);
                }
                return siteIds;
            }
        }

        private IScheduler Scheduler
        {
            get
            {
                if (batchScheduler != null)
                    return batchScheduler;
                return nonBatchingScheduler;
            }
        }

        public void OnBatchTrigger(string batchingKey, List<ISchedule> schedulesFromBatch)
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.InfoFormat("Stop {0} requested. So ignoring ScheduleTrigger as we are shutting down.",
                        ScheduleName);
                    return;
                }
                // break into smaller items of 1000 or less so message to server-side isn't too big.
                for (var i = 0; i < schedulesFromBatch.Count; i += BatchForRemoteCall)
                {
                    var numberOfItems = Math.Min(BatchForRemoteCall, schedulesFromBatch.Count - i);
                    EvaluateBatch(batchingKey, schedulesFromBatch.GetRange(i, numberOfItems));
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Format("An error occured when batch {0} was triggered.", batchingKey), e);
            }
        }

        /// <summary>
        ///     Triggered by the scheduler. Evaluates target definition by taking a reading and seeing
        ///     if target alert should be raised/updated.
        /// </summary>
        /// <param name="schedule">Schedule to fire</param>
        /// <param name="intendedScheduleExecutionTime"></param>
        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            var actualTriggerTime = Clock.Now;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            TargetDefinition targetDefinition = null;
            try
            {
                if (stopServiceRequested)
                {
                    logger.InfoFormat("Stop {0} requested. So ignoring ScheduleTrigger as we are shutting down.",
                        ScheduleName);
                    return;
                }

                if (logger.IsDebugEnabled)
                    logger.Debug("Finding Target Definition for schedule id: " + schedule.Id);

                targetDefinition = targetDefintionService.QueryByScheduleId(schedule.Id);

                // This is strange to even happen.  Why would a Schedule exist, but not have a target?  Is it cause the target was deleted
                // and we didn't receive the message in time? Race condition?
                if (targetDefinition == null)
                {
                    if (Scheduler != null)
                    {
                        Scheduler.RemoveSchedule(schedule);
                    }

                    throw new ArgumentException(
                        string.Format("No target definition corresponding to schedule: {0} . Removing from scheduler.",
                            schedule.Id), "schedule");
                }

                if (!targetDefinition.IsInStateForGeneratingAlerts)
                {
                    if (logger.IsDebugEnabled)
                        logger.DebugFormat(
                            "Target {0} with ID {1} and status {2} not going to be evaluated since it is not in a state to be Evaluated (i.e. it is inactive or deleted.)",
                            targetDefinition.Name, targetDefinition.Id, targetDefinition.Status.Name);
                    return;
                }

                var operationalModeDTO = GetOperationalMode(targetDefinition.FunctionalLocation);

                if (targetDefinition.HasOperationalMode(operationalModeDTO.OperationalMode))
                {
                    logger.InfoFormat("Evaluating Target Definition with id:<{0}> name:<{1}>",
                        targetDefinition.Id, targetDefinition.Name);

                    targetService.EvaluateTarget(targetDefinition);

                    if (logger.IsDebugEnabled)
                        logger.DebugFormat("Done evaluating Target Definition with id:<{0}>", targetDefinition.Id);

                    // should we do this sooner?  Why wait until after evaluate to update this? 
                    scheduleService.Update(schedule);
                }
                else
                {
                    if (logger.IsDebugEnabled)
                        logger.DebugFormat(
                            "Target Scheduler did not evaluate the Target because the Target Definition's operational mode ({0}) and the Functional Location Operational Mode ({1}) are not the same",
                            targetDefinition.OperationalMode.Name, operationalModeDTO.OperationalMode.Name);
                }
            }
            catch (Exception e)
            {
                logger.Error(
                    "An error occured when target definition with schedule id " + schedule.Id + " was triggered", e);
            }
            finally
            {
                stopwatch.Stop();

                perfLogger.DebugFormat("{0}, {1}, {2}, {3}",
                    intendedScheduleExecutionTime == null
                        ? string.Empty
                        : intendedScheduleExecutionTime.Value.ToString(DateTimeFormat),
                    actualTriggerTime.ToString(DateTimeFormat), stopwatch.ElapsedMilliseconds,
                    targetDefinition != null && targetDefinition.TagInfo != null
                        ? targetDefinition.TagInfo.Name
                        : string.Empty);
            }
        }

        public void LoadScheduler()
        {
            if (logger.IsInfoEnabled)
                logger.Info("Start Loading Target Definitions");

            CheckSiteConfigurationAndWarnIfNoneConfigured();

            var schedulingList =
                targetDefintionService.QueryAllAvailableForScheduling(sitesToLoadTargets);

            foreach (var exception in schedulingList.ExceptionList)
            {
                logger.Warn(exception.Message, exception);
            }

            if (Scheduler != null)
            {
                Scheduler.StartInitialLoad();
            }
            foreach (var targetDefinition in schedulingList.DomainObjectList)
            {
                AddTargetDefinitionSchedule(targetDefinition);
            }
            logger.Debug("Loading Target Definitions Done");

            if (Scheduler != null)
            {
                Scheduler.InitialLoadComplete();
            }
        }

        public string ScheduleName
        {
            get { return "Target Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            if (Scheduler != null)
            {
                Scheduler.StopScheduler();
            }
        }


        private void targetDefintionService_TargetDefintionUpdated(object sender, DomainEventArgs<TargetDefinition> e)
        {
            try
            {
                var targetDefinition = e.SelectedItem;

                if (TargetIsInApplicableSite(targetDefinition))
                {
                    RemoveTargetDefinitionSchedule(targetDefinition);
                    AddTargetDefinitionSchedule(targetDefinition.IdValue);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_UPDATE, ex);
            }
        }

        private void targetDefintionService_TargetDefintionCreated(object sender, DomainEventArgs<TargetDefinition> e)
        {
            try
            {
                var targetDefinition = e.SelectedItem;

                if (TargetIsInApplicableSite(targetDefinition))
                {
                    AddTargetDefinitionSchedule(targetDefinition.IdValue);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_CREATE, ex);
            }
        }

        private void targetDefintionService_TargetDefintionRemoved(object sender, DomainEventArgs<TargetDefinition> e)
        {
            try
            {
                var targetDefinition = e.SelectedItem;

                if (TargetIsInApplicableSite(targetDefinition))
                {
                    RemoveTargetDefinitionSchedule(targetDefinition);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_REMOVE, ex);
            }
        }

        private bool TargetIsInApplicableSite(TargetDefinition targetDefinition)
        {
            return sitesToLoadTargets.IdIsInList(targetDefinition.FunctionalLocation.Site);
        }

        private void CheckSiteConfigurationAndWarnIfNoneConfigured()
        {
            if (sitesToLoadTargets.Count == 0)
            {
                logger.Warn(NoSitesConfiguredMessage);
            }
        }

        /// <summary>
        ///     Schedules a target definition to check for target alerts (based on its schedule). Attaches the procedure to invoke
        /// </summary>
        /// <param name="targetDefinition">Target Definition object to schedule</param>
        private void AddTargetDefinitionSchedule(TargetDefinition targetDefinition)
        {
            if (targetDefinition.IsInStateForGeneratingAlerts)
            {
                logger.Info("Adding schedule for target definition id: " + targetDefinition.Id);

                try
                {
                    var schedule = targetDefinition.Schedule;

                    if (Scheduler != null)
                    {
                        Scheduler.AddSchedule(schedule);
                    }

                    if (logger.IsDebugEnabled)
                        logger.DebugFormat("Added schedule for target definition id: {0} schedule: {1}",
                            targetDefinition.Id, schedule.Id);
                }
                catch (Exception e)
                {
                    var msg = "Unable to add a target definition id: " + targetDefinition.Id + "'s schedule";
                    logger.Error(msg, e);
                    // swallow the exception because we want to still allow the Scheduler to run even if there is a problem with certain TargetDefinitions or PhdProviders.
                }
            }
            else
            {
                if (logger.IsDebugEnabled)
                    logger.DebugFormat(
                        "Target {0} with ID {1} and status {2} is not being added since it is not in a valid state (i.e. it is inactive or deleted.)",
                        targetDefinition.Name, targetDefinition.Id, targetDefinition.Status.Name);
            }
        }

        /// <summary>
        ///     Creates a schedule for the target definition
        /// </summary>
        /// <param name="targetDefinitionId">ID of target definition to query</param>
        public void AddTargetDefinitionSchedule(long targetDefinitionId)
        {
            if (logger.IsDebugEnabled)
                logger.Debug("Received an Event to add schedule for target definition id: " + targetDefinitionId);

            var targetDefinition = targetDefintionService.QueryById(targetDefinitionId);
            AddTargetDefinitionSchedule(targetDefinition);
        }

        /// <summary>
        ///     Removes schedule related to target definition
        /// </summary>
        /// <param name="targetDefinition">Target definition related to schedule to remove</param>
        public void RemoveTargetDefinitionSchedule(TargetDefinition targetDefinition)
        {
            if (logger.IsDebugEnabled)
                logger.Debug("Removing schedule for target definition: " + targetDefinition.Id);

            var schedule = targetDefinition.Schedule;
            if (Scheduler != null)
            {
                Scheduler.RemoveSchedule(schedule);
            }
        }

        private void EvaluateBatch(string batchingKey, IList<ISchedule> schedulesFromBatch)
        {
            logger.DebugFormat("Requesting Target Definitions for {0} schedules associated to batching key {1}.",
                schedulesFromBatch.Count, batchingKey);
            // the start of batching...
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var targetDefinitions =
                targetDefintionService.QueryByScheduleIds(schedulesFromBatch.ConvertAll(schedule => schedule.IdValue));
            stopwatch.Stop();
            logger.DebugFormat("Request for Target Definitions took {0} seconds.", stopwatch.Elapsed.TotalSeconds);

            // Do some filtering out of those Target Definitions that shouldn't be evaluated.
            targetDefinitions.RemoveAll(td => !td.IsInStateForGeneratingAlerts);
            logger.DebugFormat("Starting Operational Mode match.");
            stopwatch.Reset();
            var countOfTargetDefinitionsBeforeOperationalModeCheck = targetDefinitions.Count;
            stopwatch.Start();
            RemoveAllWithOperationalModeNotMatchingFunctionalLocation(targetDefinitions);
            stopwatch.Stop();
            logger.DebugFormat(
                "Operational Mode match for {0} Targets took {1} seconds and removed {2} Target Definitions from Evaluation",
                targetDefinitions.Count,
                stopwatch.Elapsed.TotalSeconds,
                countOfTargetDefinitionsBeforeOperationalModeCheck - targetDefinitions.Count);

            stopwatch.Reset();
            stopwatch.Start();
            targetService.EvaluateTargets(targetDefinitions);
            stopwatch.Stop();
            logger.DebugFormat("Evaluate {0} Targets took {1} seconds", targetDefinitions.Count,
                stopwatch.Elapsed.TotalSeconds);

            stopwatch.Reset();
            stopwatch.Start();
            schedulesFromBatch.ForEach(schedule => scheduleService.Update(schedule));
            stopwatch.Stop();
            logger.DebugFormat("Updating the Schedule's LastInvoked DateTime for {0} Targets took {1} seconds",
                targetDefinitions.Count, stopwatch.Elapsed.TotalSeconds);
        }

        private void RemoveAllWithOperationalModeNotMatchingFunctionalLocation(List<TargetDefinition> targetDefinitions)
        {
            targetDefinitions.RemoveAll(targetDefinition =>
            {
                var operationalModeDTO = GetOperationalMode(targetDefinition.FunctionalLocation);
                return !targetDefinition.HasOperationalMode(operationalModeDTO.OperationalMode);
            });
        }

        private FunctionalLocationOperationalModeDTO GetOperationalMode(FunctionalLocation floc)
        {
            var operationalMode = operationalModeService.GetByFunctionalLocationId(floc.IdValue);

            if (operationalMode == null)
            {
                throw new ApplicationException("Could not find operational mode for functional location with id:<" +
                                               floc.Id + ">");
            }

            return operationalMode;
        }
    }
}