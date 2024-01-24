using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Integration.Services
{
    public class IntegrationTestEventNotificationService : IEventNotificationService
    {
        public void Notify(DomainEventArgs<DomainObject> e)
        {
        }
    }
}