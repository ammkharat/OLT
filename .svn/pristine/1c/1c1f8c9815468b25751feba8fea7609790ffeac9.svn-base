using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class ExpireLocksJob : AbstractScheduledJob
    {
        private const string JobName = "Expire Locks Job";
        private readonly int expireTimeInHours;
        private readonly ILog logger;
        private readonly IObjectLockingService objectLockingService;

        public ExpireLocksJob(int expireTimeInHours, ISchedule jobSchedule)
            : this(
                jobSchedule, expireTimeInHours, SchedulerServiceRegistry.Instance.GetService<IObjectLockingService>(),
                GenericLogManager.GetLogger<ExpireLocksJob>())
        {
        }

        public ExpireLocksJob(ISchedule jobSchedule, int expireTimeInHours, IObjectLockingService objectLockingService,
            ILog logger) : base(jobSchedule)
        {
            this.expireTimeInHours = expireTimeInHours;
            this.objectLockingService = objectLockingService;
            this.logger = logger;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            logger.Info(string.Format("Started: {0} at {1} to look for items locked more than {2} hours.", Name,
                Clock.Now, expireTimeInHours));

            objectLockingService.ExpireLocks(expireTimeInHours*60);

            logger.Info(string.Format(
                "Finished: {0} at {1} that was looking for items locked more than {2} hours ago.", Name, Clock.Now,
                expireTimeInHours));
        }
    }
}