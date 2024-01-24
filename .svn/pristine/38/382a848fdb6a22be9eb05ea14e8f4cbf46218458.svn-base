using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public sealed class SchedulerServiceRegistry : AbstractEventNotificationEnabledServiceRegistry
    {
        private static SchedulerServiceRegistry instance;

        private SchedulerServiceRegistry()
        {
        }

        public static SchedulerServiceRegistry Instance
        {
            get { return instance ?? (instance = new SchedulerServiceRegistry()); }
        }
    }
}