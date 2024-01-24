using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class RestrictionSchedulingService : ISchedulingService, IScheduleHandler
    {
        private const string ERROR_ON = "An error occured when handling a restriction definition ";
        private const string ERROR_ON_CREATE = ERROR_ON + " creation";
        private const string ERROR_ON_REMOVE = ERROR_ON + " remove";

        private readonly IRestrictionDefinitionService defintionService;
        private readonly IDeviationAlertService deviationService;
        private readonly ILog logger;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly ITimeService timeService;

        private bool stopServiceRequested;

        public RestrictionSchedulingService() : this(
            GenericLogManager.GetLogger<RestrictionSchedulingService>(),
            SchedulerServiceRegistry.Instance.GetService<ITimeService>(),
            SchedulerServiceRegistry.Instance.GetService<IRestrictionDefinitionService>(),
            SchedulerServiceRegistry.Instance.GetService<IDeviationAlertService>(),
            SchedulerServiceRegistry.Instance.RemoteEventRepeater,
            new NonBatchingScheduler())
        {
        }

        public RestrictionSchedulingService(
            ILog logger,
            ITimeService timeService,
            IRestrictionDefinitionService defintionService,
            IDeviationAlertService deviationService,
            IRemoteEventRepeater remoteEventRepeater,
            INonBatchingScheduler nonBatchingScheduler)
        {
            this.logger = logger;
            this.timeService = timeService;
            this.defintionService = defintionService;
            this.deviationService = deviationService;
            this.remoteEventRepeater = remoteEventRepeater;

            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.remoteEventRepeater.ServerRestrictionDefinitionCreated += Repeater_DefintionCreated;
            this.remoteEventRepeater.ServerRestrictionDefinitionRemoved += Repeater_DefintionRemoved;
        }

        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.InfoFormat("Stop {0} requested. So ignoring ScheduleTrigger as we are shutting down.",
                        ScheduleName);
                }
                else
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("Processing restriction definitions for site: " + schedule.Site.Name);
                    }

                    var schedulingList = defintionService.QueryAllAvailableForScheduling();
                    foreach (var definition in schedulingList.DomainObjectList)
                    {
                        if (definition.FunctionalLocation.Site.Id == schedule.Site.Id)
                        {
                            Evaluate(definition, schedule.LastInvokedDateTime.Value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(
                    "An error occured when restriction definition schedule for site " + schedule.Site.Name +
                    " was triggered.", e);
            }
        }

        public void LoadScheduler()
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info("Start Loading Restriction Definitions");
            }

            nonBatchingScheduler.StartInitialLoad();

            CatchUpOnMissedAlertsAtStartup();

            UpdateScheduler();

            nonBatchingScheduler.InitialLoadComplete();

            logger.Debug("Loading Restriction Definitions Done");
        }

        public string ScheduleName
        {
            get { return "Restriction Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }

        private void Repeater_DefintionCreated(object sender, DomainEventArgs<RestrictionDefinition> e)
        {
            try
            {
                UpdateScheduler();
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_CREATE, ex);
            }
        }

        private void Repeater_DefintionRemoved(object sender, DomainEventArgs<RestrictionDefinition> e)
        {
            try
            {
                UpdateScheduler();
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_REMOVE, ex);
            }
        }

        private void CatchUpOnMissedAlertsAtStartup()
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.InfoFormat("Stop {0} requested. So ignoring CatchUpOnMissedAlerts as we are shutting down.",
                        ScheduleName);
                }
                else
                {
                    var nowServerTime = Clock.Now;
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("About to catch up on missed alerts on startup at server time: ." + nowServerTime);
                    }

                    var schedulingList = defintionService.QueryAllAvailableForScheduling();
                    foreach (var definition in schedulingList.DomainObjectList)
                    {
                        var siteTime = OltTimeZoneInfo.ConvertTime(nowServerTime,
                            nonBatchingScheduler.GetSchedulerTimeZone(), definition.FunctionalLocation.Site.TimeZone);

                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("Evaluating definition at site time: ." + siteTime);
                        }

                        Evaluate(definition, siteTime);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("An error occured when catching up on missed alerts on startup.", e);
            }
        }

        private void UpdateScheduler()
        {
            var schedulingList = defintionService.QueryAllAvailableForScheduling();
            foreach (var exception in schedulingList.ExceptionList)
            {
                logger.Warn(exception.Message, exception);
            }

            UpdateSchedulerRemoveSchedulesForDefinitionsThatDoNotExistAnymore(schedulingList.DomainObjectList);
            UpdateSchedulerAddDefinitionsThatAreNotAlreadyScheduled(schedulingList.DomainObjectList);
        }

        private void UpdateSchedulerRemoveSchedulesForDefinitionsThatDoNotExistAnymore(
            List<RestrictionDefinition> definitions)
        {
            var schedulesThatNeedToBeRemoved = new List<ISchedule>();

            foreach (var schedule in nonBatchingScheduler.Schedules)
            {
                if (
                    !definitions.Exists(definition => definition.FunctionalLocation.Site.Id == schedule.Schedule.Site.Id))
                {
                    schedulesThatNeedToBeRemoved.Add(schedule.Schedule);
                }
            }

            foreach (var schedule in schedulesThatNeedToBeRemoved)
            {
                logger.InfoFormat("Removing schedule for site: {0}", schedule.Site.Id);
                nonBatchingScheduler.RemoveSchedule(schedule);
            }
        }

        private void UpdateSchedulerAddDefinitionsThatAreNotAlreadyScheduled(
            IEnumerable<RestrictionDefinition> definitions)
        {
            foreach (var definition in definitions)
            {
                if (definition.Status.Equals(RestrictionDefinitionStatus.Valid))
                {
                    var site = definition.FunctionalLocation.Site;
                    logger.InfoFormat("Checking for existing schedule for restriction definition id: {0} at site {1}",
                        definition.Id, site.Id);

                    try
                    {
                        var existingScheduleAtSite =
                            nonBatchingScheduler.Schedules.Find(obj => obj.Schedule.Site.Id == site.Id);

                        if (existingScheduleAtSite == null)
                        {
                            logger.InfoFormat("Adding new schedule for restriction definition id: {0} at site {1}",
                                definition.Id, site.Id);

                            //// DMND0010124 mangesh ----
                            //int frequency = 0;
                            //if (!string.IsNullOrEmpty(definition.HourFrequency))
                            //{
                            //    frequency = Convert.ToInt32(definition.HourFrequency) * 60;
                            //}
                            //else
                            //{
                            //    frequency = 60;
                            //}
                            //int scheduleFrequencyInMinutes = frequency;
                            ////-----

                            const int scheduleFrequencyInMinutes = 60;

                            ISchedule schedule = new RoundTheClockSchedule(
                                site.IdValue,
                                new Date(timeService.GetTime(site.TimeZone)),
                                null,
                                Time.START_OF_DAY.Add(0, 0, 5),
                                // ensure that scheduler fires after the hour and never before
                                Time.END_OF_DAY,
                                scheduleFrequencyInMinutes,
                                null,
                                site);

                            nonBatchingScheduler.AddSchedule(schedule);
                            if (logger.IsDebugEnabled)
                            {
                                logger.DebugFormat("Added schedule for restriction definition id: {0} site: {1}.",
                                    definition.Id, site.Id);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        // swallow the exception because we want to still allow the Scheduler to run even 
                        // if there is a problem with one particular definition
                        var msg = "Unable to add a restriction definition id: " + definition.Id + "'s schedule";
                        logger.Error(msg, e);
                    }
                }
                else
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat(
                            "Not adding schedule for restriction definition id: {0} because its status is {1}.",
                            definition.Id, definition.Status.Name);
                    }
                }
            }
        }

        private void Evaluate(RestrictionDefinition definition, DateTime invocationDateTime)
        {
            DateTime? lastSuccessfulAlert;
            try
            {
                logger.InfoFormat(
                    "Evaluating Restriction Definition with id:<{0}> name:<{1}> at <{2}>",
                    definition.Id, definition.Name, invocationDateTime);
                lastSuccessfulAlert = deviationService.EvaluateDefinition(definition, invocationDateTime);
                logger.InfoFormat(
                    "Finished evaluation Restriction Definition with id:<{0}> name:<{1}> at <{2}>.  Last successful alert created for: <{3}>",
                    definition.Id, definition.Name, invocationDateTime, lastSuccessfulAlert);
            }
            catch (Exception e)
            {
                logger.Error("An error occured when restriction definition " + definition.Id + " was evaluated.", e);

                // Update the last invoked date time even if the evaluation failed above.  This prevents
                // unexpected and catastrophic (ie: exceptions) events from repeating over and over again 
                // because we try to catch up on missed alerts
                // in the evaluation logic.
                lastSuccessfulAlert = invocationDateTime;
            }

            try
            {
                if (lastSuccessfulAlert.HasValue)
                {
                    definition.LastInvokedDateTime = lastSuccessfulAlert;
                    defintionService.UpdateLastInvokedDateTime(definition);
                }
            }
            catch (Exception e)
            {
                logger.Error("An error occured when restriction definition " + definition.Id + " was updated.", e);
            }
        }
    }
}