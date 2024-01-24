using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class NotifiedEvent
    {
        private readonly ApplicationEvent applicationEvent;
        private readonly DomainObject domainObject;

        public NotifiedEvent(ApplicationEvent applicationEvent, DomainObject domainObject)
        {
            this.applicationEvent = applicationEvent;
            this.domainObject = domainObject;
        }

        public ApplicationEvent ApplicationEvent
        {
            get { return applicationEvent; }
        }

        public DomainObject DomainObject
        {
            get { return domainObject; }
        }
    }
}