using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    public static class ServiceUtility
    {
        public static NotifiedEvent PushEventIntoQueue(ApplicationEvent applicationEvent, DomainObject domainObject)
        {
            return EventQueue.PushEventIntoQueue(applicationEvent, domainObject);
        } 

    }
}