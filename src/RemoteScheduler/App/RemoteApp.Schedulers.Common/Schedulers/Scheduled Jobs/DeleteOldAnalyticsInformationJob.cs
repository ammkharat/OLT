using System;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class DeleteOldAnalyticsInformationJob : AbstractScheduledJob
    {
        private const string JobName = "Delete Old Analytics Information Job";
        private static readonly ILog logger = GenericLogManager.GetLogger<DeleteOldAnalyticsInformationJob>();

        private readonly IAnalyticsService analyticsService;

        public DeleteOldAnalyticsInformationJob(ISchedule scheduleForJob, IAnalyticsService analyticsService)
            : base(scheduleForJob)
        {
            this.analyticsService = analyticsService;
        }

        public DeleteOldAnalyticsInformationJob(ISchedule scheduleForJob)
            : this(scheduleForJob, SchedulerServiceRegistry.Instance.GetService<IAnalyticsService>())
        {
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            var now = DateTime.Now;
            var sixMonthsAgo = now.AddMonths(-6);

            logger.InfoFormat("Deleting analytics created before {0}", sixMonthsAgo.ToShortDateAndTimeString());

            analyticsService.DeleteAnalyticsCreatedBeforeGivenDateTime(sixMonthsAgo);
        }
    }
}