using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class ArchiveClosedWorkPermitJob : AbstractScheduledJob
    {
        private const string JobName = "Archive Closed Work Permit Job";
        private readonly ILog logger;
        private readonly ISiteService siteService;
        private readonly IWorkPermitService workPermitService;


        public ArchiveClosedWorkPermitJob(ISchedule jobSchedule)
            : this(
                jobSchedule, SchedulerServiceRegistry.Instance.GetService<ISiteService>(),
                SchedulerServiceRegistry.Instance.GetService<IWorkPermitService>(),
                GenericLogManager.GetLogger<ArchiveClosedWorkPermitJob>())
        {
        }

        public ArchiveClosedWorkPermitJob(ISchedule jobSchedule, ISiteService siteService,
            IWorkPermitService workPermitService, ILog logger) : base(jobSchedule)
        {
            this.siteService = siteService;
            this.workPermitService = workPermitService;
            this.logger = logger;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            var sites = siteService.GetAll();

            foreach (var site in sites)
            {
                logger.Info(string.Format("Started: {0} for site {1}.", Name, site.Name));
                workPermitService.ArchiveCompletedWorkPermitsBySiteConfiguration(site);
                logger.Info(string.Format("Finished: {0} for site {1}.", Name, site.Name));
            }
        }
    }
}