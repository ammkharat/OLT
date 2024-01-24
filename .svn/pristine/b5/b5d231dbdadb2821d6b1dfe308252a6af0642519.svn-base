using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public interface IScheduledJobRunner
    {
        void Run(IScheduledJob job);
    }

    public class OltProcessSchedulingService : ISchedulingService, IScheduleHandler
    {
        private const int ExpireTime = 4;
        private static readonly ILog logger = GenericLogManager.GetLogger<OltProcessSchedulingService>();

        private readonly List<IScheduledJob> jobs;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IScheduledJobRunner scheduledJobRunner;

        private bool stopServiceRequested;

        public OltProcessSchedulingService()
            : this(new NonBatchingScheduler(),
                CreateJobs(SchedulerServiceRegistry.Instance.GetService<ISiteService>(),
                    SchedulerServiceRegistry.Instance.GetService<IShiftHandoverService>(),
                    SchedulerServiceRegistry.Instance.GetService<ISiteConfigurationService>()),
                SchedulerServiceRegistry.Instance.RemoteEventRepeater,
                new JobRunner()
                )
        {
        }

        public OltProcessSchedulingService(INonBatchingScheduler nonBatchingScheduler, List<IScheduledJob> jobs,
            IRemoteEventRepeater remoteEventRepeater, IScheduledJobRunner scheduledJobRunner)
        {
            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.jobs = jobs;
            this.scheduledJobRunner = scheduledJobRunner;

            remoteEventRepeater.ServerShiftHandoverEmailConfigurationCreated +=
                (sender, args) => HandleJobCreated(new ShiftHandoverEmailJob(args.SelectedItem));
            remoteEventRepeater.ServerShiftHandoverEmailConfigurationUpdated +=
                (sender, args) => HandleScheduleUpdated(args.SelectedItem.Schedule);
            remoteEventRepeater.ServerShiftHandoverEmailConfigurationRemoved +=
                (sender, args) => HandleJobRemoved(args.SelectedItem.Schedule);

            remoteEventRepeater.ServerSapAutoImportConfigurationEnabled += HandleSapAutoImportConfigurationEnabled;
            remoteEventRepeater.ServerSapAutoImportConfigurationUpdated +=
                (sender, args) => HandleScheduleUpdated(args.SelectedItem.Schedule);
            remoteEventRepeater.ServerSapAutoImportConfigurationDisabled +=
                (sender, args) => HandleJobRemoved(args.SelectedItem.Schedule);
        }

        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            var scheduledJob = FindJob(schedule);
            if (scheduledJob != null)
            {
                try
                {
                    if (stopServiceRequested)
                    {
                        logger.Info(String.Format("Stop {0} requested.", ScheduleName));
                        return;
                    }

                    logger.Debug(string.Format("Firing {0} Operator Log Tool process schedule", scheduledJob.Name));
                    scheduledJobRunner.Run(scheduledJob);
                }
                catch (Exception e)
                {
                    logger.Error("An error occured when firing Daily Operator Log Tool process was triggered", e);
                }
            }
        }

        public void LoadScheduler()
        {
            nonBatchingScheduler.StartInitialLoad();
            ScheduleAllJobs();
            nonBatchingScheduler.InitialLoadComplete();
        }

        public string ScheduleName
        {
            get { return "OLT Process Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }

        private static List<IScheduledJob> CreateJobs(ISiteService siteService,
            IShiftHandoverService shiftHandoverService, ISiteConfigurationService siteConfigurationService)
        {
            var oilsandsSite = siteService.QueryById(Site.OILSAND_ID);
            var lubesSite = siteService.QueryById(Site.LUBES_ID);
            var montrealSite = siteService.QueryById(Site.MONTREAL_ID);
            var sarniaSite = siteService.QueryById(Site.SARNIA_ID);

            long arbitraryId = -1;
            int opmRefreshRateMins;

            var now = Clock.Now;

            // If the value has not been specified in the config file use a default of 15 minutes
            if (Int32.TryParse(ConfigurationManager.AppSettings["OpmRefreshRateMins"], out opmRefreshRateMins) == false)
            {
                logger.Info("OpmRefreshRateMins not found in AppSettings, using default value of 15.");
                opmRefreshRateMins = 15;
            }
            else
            {
                logger.Info(string.Format("Using OpmRefreshRateMins {0} from AppSettings.", opmRefreshRateMins));
            }

            var tagSyncJob = new SynchronousJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite, now),
                "Tag Info Job Collection");

            var jobs = new List<IScheduledJob>
            {

                new ExpireLocksJob(ExpireTime, CreateRecurringHourlySchedule(arbitraryId--, oilsandsSite, now)),
                new DeleteInactivePendingWorkPermitsJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite,
                    now.AddMinutes(10))),
//                 stagger the jobs touching the same table because I am parallelizing the jobs and want to avoid potential deadlocks
                new DeleteRejectedWorkPermitsJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite,
                    now.AddMinutes(30))),
                new CloseAllIssuedWorkPermitsJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite,
                    now.AddMinutes(50))),
                new ArchiveClosedWorkPermitJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite,
                    now.AddMinutes(70))),
                new RequireAdditionalApproversOnOutOfServiceFormOP14sJob(
                    CreateTwiceDailyAt6amAnd6pmSchedule(arbitraryId--, oilsandsSite, now)),
                new RequireAdditionalDirectorApprovalForLubeCsdsJob(
                    CreateRecurringHourlySchedule(arbitraryId--, lubesSite, now)),
                new RequireManagerOperationsApprovalForCsdsOutOfServiceMoreThan3DaysJob(
                    CreateRecurringHourlySchedule(arbitraryId--, montrealSite, now)),
                new RequireDirectorApprovalForMontrealCsdsOutOfServiceForMoreThan5Days(
                    CreateRecurringHourlySchedule(arbitraryId--, montrealSite, now)),
                new EdmontonCardSwipeReaderJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite,
                    now.AddMinutes(1))),
                new DeleteOldAnalyticsInformationJob(CreateDefaultDailySchedule(arbitraryId--, oilsandsSite, now)),
                tagSyncJob,
                new OpmExcursionImportJob(oilsandsSite,
                    CreateRecurringMinuteSchedule(arbitraryId--, oilsandsSite, now, opmRefreshRateMins))
            };

            var sites = siteService.GetAll();

            foreach (var site in sites)
            {
                if (site.IdValue == Site.LUBES_ID)
                {
                    var sapAutoImportConfiguration =
                        siteConfigurationService.QuerySapAutoImportConfiguration(Site.LUBES_ID);
                    if (sapAutoImportConfiguration != null && sapAutoImportConfiguration.Schedule != null)
                    {
                        jobs.Add(new LubesSapAutoImportJob(sapAutoImportConfiguration));
                    }
                }
                else if (site.IdValue == Site.EDMONTON_ID)
                {
                    var sapAutoImportConfiguration =
                        siteConfigurationService.QuerySapAutoImportConfiguration(Site.EDMONTON_ID);
                    if (sapAutoImportConfiguration != null && sapAutoImportConfiguration.Schedule != null)
                    {
                        jobs.Add(new EdmontonSapAutoImportJob(sapAutoImportConfiguration));
                    }
                }

                tagSyncJob.AddJob(new TagInformationJob(site, null));

                var shiftHandoverEmailConfigurations =
                    shiftHandoverService.QueryShiftHandoverEmailConfigurationsBySiteId(site.IdValue);
                foreach (var configuration in shiftHandoverEmailConfigurations)
                {
                    jobs.Add(new ShiftHandoverEmailJob(configuration));
                }
            }
            return jobs;
        }

        private static RecurringMinuteSchedule CreateRecurringMinuteSchedule(long id, Site siteOfScheduler,
            DateTime startDateTime, int frequencyMins)
        {
            var recurringMinuteSchedule = new RecurringMinuteSchedule(id, startDateTime.ToDate(), null,
                Time.START_OF_DAY, Time.END_OF_DAY, frequencyMins, null, siteOfScheduler);

            return recurringMinuteSchedule;
        }

        private static RecurringMinuteSchedule CreateRecurring15MinuteSchedule(long id, Site siteOfScheduler,
            DateTime startDateTime)
        {
            const int frequencyMins = 15;

            var recurringMinuteSchedule = new RecurringMinuteSchedule(id, startDateTime.ToDate(), null,
                Time.START_OF_DAY, Time.END_OF_DAY, frequencyMins, null, siteOfScheduler);

            return recurringMinuteSchedule;
        }

        private static RecurringHourlySchedule CreateRecurringHourlySchedule(long id, Site siteOfScheduler,
            DateTime startDateTime)
        {
            return new RecurringHourlySchedule(id, startDateTime.ToDate(), null, Time.START_OF_DAY, Time.END_OF_DAY, 1,
                null, siteOfScheduler);
        }

        private static RecurringHourlySchedule CreateTwiceDailyAt6amAnd6pmSchedule(long id, Site siteOfScheduler,
            DateTime startDateTime)
        {
            return new RecurringHourlySchedule(id, startDateTime.ToDate(), null, new Time(6, 0, 0), new Time(5, 59, 59),
                12, null, siteOfScheduler);
        }

        private static RecurringDailySchedule CreateDefaultDailySchedule(long id, Site siteOfScheduler,
            DateTime startDateTime)
        {
            return new RecurringDailySchedule(id, startDateTime.ToDate(), null, startDateTime.ToTime().AddMinutes(1),
                startDateTime.ToTime().AddMinutes(1), 1, null, siteOfScheduler);
        }

        private void ScheduleAllJobs()
        {
            foreach (var job in jobs)
            {
                ScheduleJob(job);
            }
        }

        private void ScheduleJob(IScheduledJob job)
        {
            var schedule = job.Schedule;
            nonBatchingScheduler.AddSchedule(schedule);
        }

        private void UnscheduleJob(ISchedule schedule)
        {
            nonBatchingScheduler.RemoveSchedule(schedule);
        }

        private IScheduledJob FindJob(ISchedule schedule)
        {
            return jobs.Find(job => job.Schedule.Id == schedule.IdValue);
        }

        private void HandleJobRemoved(ISchedule schedule)
        {
            UnscheduleJob(schedule);
            jobs.RemoveAll(job => job.Schedule.IdValue == schedule.IdValue);
        }

        private void HandleScheduleUpdated(ISchedule schedule)
        {
            UnscheduleJob(schedule);
            var scheduledJob = FindJob(schedule);
            scheduledJob.Schedule = schedule;
            ScheduleJob(scheduledJob);
        }

        private void HandleJobCreated(IScheduledJob job)
        {
            if (job != null)
            {
                jobs.Add(job);
                ScheduleJob(job);
            }
        }

        private void HandleSapAutoImportConfigurationEnabled(object sender,
            DomainEventArgs<SapAutoImportConfiguration> domainEventArgs)
        {
            var configuration = domainEventArgs.SelectedItem;
            if (configuration.SiteId == Site.LUBES_ID)
            {
                HandleJobCreated(new LubesSapAutoImportJob(configuration));
            }
            else if (configuration.SiteId == Site.EDMONTON_ID)
            {
                HandleJobCreated(new EdmontonSapAutoImportJob(configuration));
            }
        }

        private class BackgroundJobExecutor : IBackgroundingFriendly<string, string>
        {
            private readonly IScheduledJob job;

            public BackgroundJobExecutor(IScheduledJob job)
            {
                this.job = job;
            }

            public string DoWork(string argument)
            {
                job.Execute();
                return null;
            }

            public void BeforeDoingWork()
            {
            }

            public void AfterDoingWork()
            {
            }

            public void WorkSuccessfullyCompleted(string result)
            {
            }

            public void OnError(Exception e)
            {
                logger.Error("An error occured while running the process scheduler.", e);
            }

            public void WorkCompletedOrCancelled()
            {
            }
        }

        private class JobRunner : IScheduledJobRunner
        {
            public void Run(IScheduledJob scheduledJob)
            {
                new BackgroundHelper<string, string>(new BackgroundWorker(), new BackgroundJobExecutor(scheduledJob))
                    .Run(null);
            }
        }
    }
}