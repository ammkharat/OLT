using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftDaoTest : AbstractDaoTest
    {
        private IShiftPatternDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryAllShiftsShouldReturnAListOfShifts()
        {
            Assert.IsTrue(dao.QueryAll().Count > 0);
        }

        [Ignore] [Test]
        public void QueryByIdShouldReturnAPopulatedShift()
        {
            ShiftPattern expectedShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern queriedShift = dao.QueryById(ShiftPatternFixture.SARNIA_12DA_ID);
            Assert.AreEqual(expectedShift.Name, queriedShift.Name);
            Assert.AreEqual(expectedShift.StartTime, queriedShift.StartTime);
            Assert.AreEqual(expectedShift.EndTime, queriedShift.EndTime);
        }

        [Ignore] [Test]
        public void InsertShift()
        {
            Time dayShiftStart = new Time(8, 0, 0);
            Time dayShiftEnd = new Time(20, 0, 0);
            DateTime createdDateTime = new DateTime(2000, 05, 05, 9, 0, 0);
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(dayShiftStart, dayShiftEnd, createdDateTime);
            ShiftPattern insertedShift = dao.Insert(dayShift);
            ShiftPattern retrievedShift = dao.QueryById(insertedShift.IdValue);
            Assert.IsNotNull(retrievedShift);
            Assert.AreEqual(createdDateTime, retrievedShift.CreatedDateTime);
            Assert.AreEqual(dayShift.Name, retrievedShift.Name);
            Assert.AreEqual(dayShift.StartTime, retrievedShift.StartTime);
            Assert.AreEqual(dayShift.EndTime, retrievedShift.EndTime);
            Assert.AreEqual(dayShift.Site, retrievedShift.Site);
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            long siteId = SiteFixture.Sarnia().IdValue;
            List<ShiftPattern> shiftPatterns = dao.QueryBySiteId(siteId);
            Assert.IsTrue(shiftPatterns.Count >= 2);
            foreach(ShiftPattern pattern in shiftPatterns)
            {
                Assert.AreEqual(siteId, pattern.Site.IdValue);
            }
        }
    }
}