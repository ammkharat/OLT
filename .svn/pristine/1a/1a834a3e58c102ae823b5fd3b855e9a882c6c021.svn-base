using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Remote
{
    [TestFixture]
    public class RemoteEventRepeaterTest
    {
        private Mockery mocks;
        private IEventService mockEventService;
        private RemoteEventRepeater remoteEventRepeater;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockEventService = mocks.NewMock<IEventService>();
            remoteEventRepeater = new RemoteEventRepeater(mockEventService, "", Timeout.Infinite);
        }

        [Test]
        public void ShouldRefireServerFunctionalLocationOperationalModeUpdated()
        {
            TestEventHandler testEventHandler = new TestEventHandler();
            remoteEventRepeater.ServerFunctionalLocationOperationalModeUpdated += testEventHandler.HandleEvent;

            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Section();
            DomainEventArgs<DomainObject> eventArgs = new DomainEventArgs<DomainObject>(
                floc, ApplicationEvent.FunctionalLocationOperationalModeUpdate);

            remoteEventRepeater.Notify(eventArgs);
            remoteEventRepeater.TimerFiredCallback(null);
            Assert.AreEqual(floc, testEventHandler.HandledEventArg.SelectedItem);
        }

        private class TestEventHandler
        {
            public DomainEventArgs<FunctionalLocation> HandledEventArg { get; private set; }

            public void HandleEvent(object sender, DomainEventArgs<FunctionalLocation> e)
            {
                HandledEventArg = e;
            }
        }
    }
}