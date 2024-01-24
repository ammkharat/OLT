using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TimeDaoTest
    {
        private ISiteDao mockSiteDao;

        private readonly Mockery mock = new Mockery();

        private ITimeDao timeDao;

        [SetUp]
        public void SetUp()
        {
            mockSiteDao = mock.NewMock<ISiteDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockSiteDao);
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void TimeServiceShouldReturnTheCurrentTimeOnTheServer()
        {
            timeDao = new TimeDao(TimeZoneFixture.GetMountainTimeZone().Id);

            DateTime localTimeRangeStart = DateTimeFixture.DateTimeNow;  // 17:34:58
            DateTime timeOnServer = timeDao.GetTime(TimeZoneFixture.GetSarniaTimeZone());  // 19:34:59
            DateTime localTimeRangeEnd = DateTimeFixture.DateTimeNow;  // 17:34:59

            Range<DateTime> localTimeRange = new Range<DateTime>(localTimeRangeStart, localTimeRangeEnd);
            DateTime timeOnServerAdjustedToLocal = timeOnServer.AddHours(-2);
            Assert.IsTrue(localTimeRange.ContainsInclusive(timeOnServerAdjustedToLocal));
        }
    }
}