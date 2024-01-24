using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands
{
    public class DeleteInactivePendingWorkPermitsJob : AbstractScheduledJob
    {
        private const string JobName = "Delete Inactive Pending Work Permits Job";
        private readonly ILog logger;
        private readonly ISiteService siteService;
        private readonly IWorkPermitService workPermitService;

        public DeleteInactivePendingWorkPermitsJob(ISchedule jobSchedule)
            : this(
                jobSchedule, SchedulerServiceRegistry.Instance.GetService<ISiteService>(),
                SchedulerServiceRegistry.Instance.GetService<IWorkPermitService>(),
                GenericLogManager.GetLogger<DeleteInactivePendingWorkPermitsJob>())
        {
        }

        public DeleteInactivePendingWorkPermitsJob(ISchedule jobSchedule, ISiteService siteService,
            IWorkPermitService workPermitService, ILog logger)
            : base(jobSchedule)
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
                workPermitService.DeleteInactivePendingWorkPermitsBySiteConfiguration(site);
                logger.Info(string.Format("Finished: {0} for site {1}.", Name, site.Name));
            }
        }
    }
}