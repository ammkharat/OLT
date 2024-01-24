using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class EventQueueItem
    {
        private readonly ApplicationEvent applicationEvent;
        private readonly DomainObject domainObject;
        private readonly InitiatingEventSink initiatingEventSink;

        public EventQueueItem(ApplicationEvent applicationEvent, DomainObject domainObject, InitiatingEventSink initiatingEventSink)
        {
            this.applicationEvent = applicationEvent;
            this.domainObject = domainObject;
            this.initiatingEventSink = initiatingEventSink;
        }

        public ApplicationEvent ApplicationEvent
        {
            get { return applicationEvent; }
        }

        public DomainObject DomainObject
        {
            get { return domainObject; }
        }

        public InitiatingEventSink InitiatingEventSink
        {
            get { return initiatingEventSink; }
        }
    }
}
