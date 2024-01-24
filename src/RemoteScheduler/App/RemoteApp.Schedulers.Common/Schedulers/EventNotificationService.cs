using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EventNotificationService : IEventNotificationService
    {
        public void Notify(DomainEventArgs<DomainObject> e)
        {
            SchedulerServiceRegistry.Instance.RemoteEventRepeater.Notify(e);
        }
    }
}