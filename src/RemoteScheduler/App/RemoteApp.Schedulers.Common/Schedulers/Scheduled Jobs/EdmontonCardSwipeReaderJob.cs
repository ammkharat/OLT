using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class EdmontonCardSwipeReaderJob : AbstractScheduledJob
    {
        private const string JobName = "Get all Card Swipes from Edmonton Security System";

        private readonly IEdmontonSwipeCardService cardService;
        private readonly ILog logger = GenericLogManager.GetLogger<EdmontonCardSwipeReaderJob>();

        public EdmontonCardSwipeReaderJob(ISchedule scheduleForJob)
            : this(scheduleForJob, SchedulerServiceRegistry.Instance.GetService<IEdmontonSwipeCardService>())
        {
        }

        public EdmontonCardSwipeReaderJob(ISchedule scheduleForJob, IEdmontonSwipeCardService cardService)
            : base(scheduleForJob)
        {
            this.cardService = cardService;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            logger.Info("Starting Card Swipe Sync");
            cardService.SyncOltWithCardSwipeSystem();
            logger.Info("Finished Card Swipe Sync");
        }
    }
}