using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class DeleteRejectedWorkPermitsJob : AbstractScheduledJob
    {
        private const string JobName = "Delete Rejected Work Permits Job";

        private readonly ILog logger;
        private readonly IWorkPermitService workPermitService;

        public DeleteRejectedWorkPermitsJob(ISchedule jobSchedule)
            : this(
                jobSchedule, SchedulerServiceRegistry.Instance.GetService<IWorkPermitService>(),
                GenericLogManager.GetLogger<DeleteRejectedWorkPermitsJob>())
        {
        }

        public DeleteRejectedWorkPermitsJob(ISchedule jobSchedule, IWorkPermitService workPermitService, ILog logger)
            : base(jobSchedule)
        {
            this.workPermitService = workPermitService;
            this.logger = logger;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            logger.Info(string.Format("Started: {0}.", Name));
            workPermitService.DeleteRejectedWorkPermits();
            logger.Info(string.Format("Finished: {0}.", Name));
        }
    }
}