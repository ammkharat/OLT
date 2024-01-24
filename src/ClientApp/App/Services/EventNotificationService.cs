using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EventNotificationService : IEventNotificationService
    {
        public void Notify(DomainEventArgs<DomainObject> e)
        {
            ClientServiceRegistry.Instance.RemoteEventRepeater.Notify(e);
        }
    }
}