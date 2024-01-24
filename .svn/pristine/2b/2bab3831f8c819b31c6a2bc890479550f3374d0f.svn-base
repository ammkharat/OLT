using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class TimeServiceClientTest
    {
        private ITimeService timeService;

        [SetUp]
        public void SetUp()
        {
            timeService = GenericServiceRegistry.Instance.GetService<ITimeService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void TestCallToTimeServiceShouldReturnServerTimeConvertedToLocalTime()
        {
            var clientTimeAccordingToServer = timeService.GetTime(TimeZoneFixture.GetSarniaTimeZone());
            var clientMachineDateTime = DateTimeFixture.DateTimeNow;

            var diff = DateTime.Compare(clientMachineDateTime, clientTimeAccordingToServer) > 0
                ? clientMachineDateTime.Subtract(clientTimeAccordingToServer)
                : clientTimeAccordingToServer.Subtract(clientMachineDateTime);

            Assert.IsTrue(diff < new TimeSpan(0, 2, 0, 1));
            Assert.IsTrue(diff > new TimeSpan(0, 1, 59, 59));
        }
    }
}