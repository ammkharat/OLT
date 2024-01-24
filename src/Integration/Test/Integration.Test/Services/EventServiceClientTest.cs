using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class EventServiceClientTest
    {
        private IEventService eventService;

        [SetUp]
        public void SetUp()
        {
            eventService = GenericServiceRegistry.Instance.GetService<IEventService>();
        }

        [Test][Ignore]
        public void ShouldPublishEventToClientEventSinks()
        {
            const string clientAddress = "test address";
            eventService.Subscribe(clientAddress, new List<FunctionalLocation>(), new List<FunctionalLocation>(), new List<FunctionalLocation>(), null,
                SiteFixture.Sarnia().Id, "", EventConnectDisconnectReason.ApplicationExit);

            eventService.PublishEvent(new DomainEventArgs<DomainObject>(ApplicationEvent.LogCreate), null);

            // No assert here.  Just want to make sure that PublishEvent doesn't throw an exception back.

            eventService.Unsubscribe(clientAddress, EventConnectDisconnectReason.ApplicationExit);
        }

        [Test][Ignore]
        public void ShouldPublishEventToSchedulerEventSinks()
        {
            const string clientAddress = "test address";
            eventService.Subscribe(clientAddress, new List<FunctionalLocation>(), new List<FunctionalLocation>(),new List<FunctionalLocation>(), null,
                null, "", EventConnectDisconnectReason.ApplicationExit);

            eventService.PublishEvent(new DomainEventArgs<DomainObject>(ApplicationEvent.LogCreate), null);

            // No assert here.  Just want to make sure that PublishEvent doesn't throw an exception back.

            eventService.Unsubscribe(clientAddress, EventConnectDisconnectReason.ApplicationExit);
        }
    }
}