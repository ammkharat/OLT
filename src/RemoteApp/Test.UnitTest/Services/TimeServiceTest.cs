using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class TimeServiceTest
    {
        private ITimeDao mockTimeDao;
        readonly Mockery mock = new Mockery();
        ITimeService service;


        [SetUp]
        public void SetUp()
        {
            mockTimeDao = mock.NewMock<ITimeDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockTimeDao);

            service = new TimeService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldGetDateByTimeZoneInfo()
        {
            Date date = new Date(2006, 01, 23);
            Expect.Once.On(mockTimeDao).Method("GetDate").With(OltTimeZoneInfo.Local).Will(Return.Value(date));
            Assert.AreEqual(service.GetDate(OltTimeZoneInfo.Local), date);
        }

        [Ignore] [Test]
        public void ShouldGetTimeByTimeZoneInfo()
        {
            DateTime dateTime = new DateTime(1971, 08, 01, 6, 15, 0);
            Expect.Once.On(mockTimeDao).Method("GetTime").With(OltTimeZoneInfo.Local).Will(Return.Value(dateTime));
            Assert.AreEqual(service.GetTime(OltTimeZoneInfo.Local), dateTime);
        }
    }
}
