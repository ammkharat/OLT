using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Domain;
using System.Threading;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Services
{
    [TestFixture]
    public class TimeServiceCacheTest
    {
        private Mockery mocks;
        private ITimeService timeServiceMock;
        private TimeServiceCache timeServiceCache;
        private DateTime serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer;
        private TimeSpan delta;
        private TimeSpan policy;
        
        [SetUp]
        public void SetUp()
        {
            delta = new TimeSpan(24, 59, 59);  // almost 25 hours
            policy = new TimeSpan(0, 0, 3);
            serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer = DateTimeFixture.DateTimeNow.Add(delta);  // add 25 hours to the current time

            mocks = new Mockery();
            timeServiceMock = mocks.NewMock<ITimeService>();
            timeServiceCache = new TimeServiceCache(timeServiceMock, policy);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();   
        }

        [Test]
        public void TimeServiceShouldExpireDeltaWhenStale()
        {
            Expect.Once.On(timeServiceMock).Method("GetTime").With(OltTimeZoneInfo.Local).Will(Return.Value(serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer));
            timeServiceCache.GetTime(OltTimeZoneInfo.Local);
            timeServiceCache.GetTime(OltTimeZoneInfo.Local);

            Thread.Sleep(4000);

            Expect.Once.On(timeServiceMock).Method("GetTime").With(OltTimeZoneInfo.Local).Will(Return.Value(serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer));
            timeServiceCache.GetTime(OltTimeZoneInfo.Local);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetTimeWithTimeZoneInfoShouldInvokeGetTimeOnTimeService()
        {
            Expect.Once.On(timeServiceMock).Method("GetTime").With(OltTimeZoneInfo.Local).Will(Return.Value(serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer));
            Assert.AreEqual(delta.TotalSeconds, DateTimeFixture.DateTimeNow.Subtract(timeServiceCache.GetTime(OltTimeZoneInfo.Local)).Duration().TotalSeconds,1);
            Assert.AreEqual(delta.TotalSeconds, DateTimeFixture.DateTimeNow.Subtract(timeServiceCache.GetTime(OltTimeZoneInfo.Local)).Duration().TotalSeconds,1);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetDateWithTimeZoneInfoShouldInvokeGetTimeOnTimeService()
        {
            Expect.Once.On(timeServiceMock).Method("GetTime").With(OltTimeZoneInfo.Local).Will(
                Return.Value(serverDateTimeThatIs25HoursAheadOfTimeOnThisComputer));
            // This is a behavioral test that is testing the fact that we only call the TimeService 
            // once from the Caching service even though we call the Caching service twice.  
            // No assertions here on purpose.
            timeServiceCache.GetDate(OltTimeZoneInfo.Local);
            timeServiceCache.GetDate(OltTimeZoneInfo.Local);

            mocks.VerifyAllExpectationsHaveBeenMet();            
        }

        [Test]
        public void GetTimeZoneInfoShouldInvokeGetTimeZoneInfoOnTimeService()
        {
            const string timeZoneName = "timeZoneName";
            Expect.Once.On(timeServiceMock).Method("GetTimeZoneInfo").With(timeZoneName).Will(Return.Value(OltTimeZoneInfo.Local));
            Assert.AreEqual(OltTimeZoneInfo.Local, timeServiceCache.GetTimeZoneInfo(timeZoneName));
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetDateOrTimeShouldReturnCorrectDateTimeEvenIfClientMachineIsIncorrectlyFast()
        {
            Clock.Freeze();
            DateTime serverTime = Clock.Now.SubtractDays(2);
            Expect.AtLeastOnce.On(timeServiceMock).Method("GetTime").Will(Return.Value(serverTime));
            
            Date dateResult = timeServiceCache.GetDate(OltTimeZoneInfo.Local);
            DateTime timeResult = timeServiceCache.GetTime(OltTimeZoneInfo.Local);
            
            Assert.AreEqual(serverTime.ToDate(), dateResult);
            Assert.That(serverTime, new TimeConstraint(timeResult, 5000));
        }

        [Test]
        public void GetDateOrTimeShouldReturnCorrectDateTimeEvenIfClientMachineIsIncorrectlySlow()
        {
            Clock.Freeze();
            DateTime serverTime = Clock.Now.AddDays(2);
            Expect.Once.On(timeServiceMock).Method("GetTime").Will(Return.Value(serverTime));
            Date dateResult = timeServiceCache.GetDate(OltTimeZoneInfo.Local);
            DateTime timeResult = timeServiceCache.GetTime(OltTimeZoneInfo.Local);
            
            Assert.AreEqual(serverTime.ToDate(), dateResult);
            Assert.That(serverTime, new TimeConstraint(timeResult, 5000));
        }
    }
}
