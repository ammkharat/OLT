using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class LogSchedulingService : ISchedulingService, IScheduleHandler
    {
        private const string ERROR_ON = "An error occured when handling a log definition ";
        private const string ERROR_ON_CREATE = ERROR_ON + " creation";
        private const string ERROR_ON_CANCEL = ERROR_ON + " cancel";
        private const string ERROR_ON_UPDATE = ERROR_ON + " update";

        private readonly ILogDefinitionService logDefinitionService;
        private readonly ILogService logService;
        private readonly ILog logger;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IScheduleService scheduleService;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ITimeService timeService;
        private bool stopServiceRequested;

        public LogSchedulingService()
            : this(new NonBatchingScheduler(),
                SchedulerServiceRegistry.Instance.GetService<ILogDefinitionService>(),
                SchedulerServiceRegistry.Instance.GetService<ILogService>(),
                SchedulerServiceRegistry.Instance.GetService<IShiftPatternService>(),
                SchedulerServiceRegistry.Instance.GetService<IScheduleService>(),
                SchedulerServiceRegistry.Instance.RemoteEventRepeater,
                SchedulerServiceRegistry.Instance.GetService<ITimeService>(),
                GenericLogManager.GetLogger<LogSchedulingService>())
        {
        }

        public LogSchedulingService(
            INonBatchingScheduler nonBatchingScheduler,
            ILogDefinitionService logDefinitionService,
            ILogService logService,
            IShiftPatternService shiftPatternService,
            IScheduleService scheduleService,
            IRemoteEventRepeater remoteEventRepeater,
            ITimeService timeService,
            ILog logger)
        {
            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.logDefinitionService = logDefinitionService;
            this.shiftPatternService = shiftPatternService;
            this.remoteEventRepeater = remoteEventRepeater;
            this.logService = logService;
            this.scheduleService = scheduleService;
            this.timeService = timeService;
            this.logger = logger;
            this.remoteEventRepeater.ServerLogDefinitionCreated +=
                logService_LogDefinitionCreated;
            this.remoteEventRepeater.ServerLogDefinitionUpdated +=
                logService_LogDefinitionUpdated;
            this.remoteEventRepeater.ServerLogCancelledRecurringDefinition +=
                logService_LogDefinitionCanceled;
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

                logger.Debug("Log Scheduler firing schedule id: " + schedule.Id);
                var logDefinition = logDefinitionService.QueryByScheduleId(schedule.IdValue);

                var now = timeService.GetTime(logDefinition.FunctionalLocations[0].Site.TimeZone);

                var logsInserted = false;

                if (logDefinition.CreateALogForEachFunctionalLocation)
                {
                    foreach (var functionalLocation in logDefinition.FunctionalLocations)
                    {
                        logsInserted |= InsertLog(now, logDefinition, new List<FunctionalLocation> {functionalLocation});
                    }
                }
                else
                {
                    logsInserted = InsertLog(now, logDefinition, logDefinition.FunctionalLocations);
                }

                if (logsInserted)
                {
                    scheduleService.Update(schedule);
                }
            }
            catch (Exception e)
            {
                logger.Error("An error occured when log definition with schedule id " + schedule.Id + " was triggered",
                    e);
            }
        }

        public void LoadScheduler()
        {
            var logDefinitions = logDefinitionService.QueryAllForScheduling();

            nonBatchingScheduler.StartInitialLoad();
            foreach (var logDefinition in logDefinitions)
            {
                AddLogDefinition(logDefinition);
            }
            nonBatchingScheduler.InitialLoadComplete();
        }

        public string ScheduleName
        {
            get { return "Log Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }

        private void logService_LogDefinitionCanceled(object sender, DomainEventArgs<LogDefinition> e)
        {
            try
            {
                RemoveLogDefinitionSchedule(e.SelectedItem.IdValue);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_CANCEL, ex);
            }
        }

        private void logService_LogDefinitionCreated(object sender, DomainEventArgs<LogDefinition> e)
        {
            try
            {
                AddLogDefinitionSchedule(e.SelectedItem.IdValue);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_CREATE, ex);
            }
        }

        private void logService_LogDefinitionUpdated(object sender, DomainEventArgs<LogDefinition> e)
        {
            try
            {
                RemoveLogDefinitionSchedule(e.SelectedItem.IdValue);
                AddLogDefinitionSchedule(e.SelectedItem.IdValue);
            }
            catch (Exception ex)
            {
                logger.Error(ERROR_ON_UPDATE, ex);
            }
        }


        private void AddLogDefinition(LogDefinition logDefinition)
        {
            if (!logDefinition.Active)
            {
                return;
            }

            try
            {
                var schedule = logDefinition.Schedule;
                nonBatchingScheduler.AddSchedule(schedule);
            }
            catch (Exception e)
            {
                var msg = "Schedule: Unable to add a log definition id=" + logDefinition.Id + "'s schedule";
                logger.Error(msg, e);
                // swallow the error so that we can continue process all other log definitions
            }
        }


        private bool InsertLog(DateTime now, LogDefinition logDefinition,
            List<FunctionalLocation> logFunctionalLocations)
        {
            var logInserted = false;

            var anyFunctionalLocationOfDefinition = logFunctionalLocations[0];
            var shift = shiftPatternService.GetShiftBySiteAndDateTime(anyFunctionalLocationOfDefinition.Site,
                now);

            var links = new List<DocumentLink>();

            foreach (var link in logDefinition.DocumentLinks)
            {
                var newLink = new DocumentLink(link.Url, link.Title);
                links.Add(newLink);
            }

            var entries = new List<CustomFieldEntry>(logDefinition.CustomFieldEntries);
            var fields = new List<CustomField>(logDefinition.CustomFields);

            var log = new Log(null,
                null,
                logDefinition,
                DataSource.MANUAL,
                logFunctionalLocations,
                logDefinition.InspectionFollowUp,
                logDefinition.ProcessControlFollowUp,
                logDefinition.OperationsFollowUp,
                logDefinition.SupervisionFollowUp,
                logDefinition.EnvironmentalHealthSafetyFollowUp,
                logDefinition.OtherFollowUp,
                logDefinition.RtfComments,
                logDefinition.PlainTextComments,
                now,
                shift,
                logDefinition.LastModifiedBy,
                logDefinition.LastModifiedBy,
                now,
                now,
                false,
                logDefinition.IsOperatingEngineerLog,
                logDefinition.CreatedByRole,
                links,
                logDefinition.LogType,
                false,
                logDefinition.WorkAssignment,
                entries,
                fields);

            if (logService.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, now,
                new ExactFlocSet(logFunctionalLocations)))
            {
                logger.WarnFormat(
                    "Currently, at {0} there is already a log with flocs {1} for the definition {2}.  A new one will not be generated.",
                    now.ToLongDateAndTimeString(), logFunctionalLocations.FullHierarchyListToString(false, false),
                    logDefinition.Id);
            }
            else
            {
                logService.Insert(log);
                logInserted = true;
            }

            return logInserted;
        }

        public void AddLogDefinitionSchedule(long logDefinitionId)
        {
            var logDefinition = logDefinitionService.QueryById(logDefinitionId);
            AddLogDefinition(logDefinition);
        }

        public void RemoveLogDefinitionSchedule(long logDefinitionId)
        {
            var logDefinition = logDefinitionService.QueryById(logDefinitionId);
            nonBatchingScheduler.RemoveSchedule(logDefinition.Schedule);
        }
    }
}