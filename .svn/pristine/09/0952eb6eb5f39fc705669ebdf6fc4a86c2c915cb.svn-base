using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmExcursionResponseDaoTest : AbstractDaoTest
    {
        private IOpmExcursionResponseDao dao;
        private IOpmExcursionDao excursionDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {

            var opmExcursion = excursionDao.Insert(OpmExcursionFixture.CreateForInsert());
            var opmExcursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            opmExcursionResponse.OltExcursionId = opmExcursion.IdValue;

            var saved = dao.Insert(opmExcursionResponse);
            var requeried = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmExcursionResponse.OpmExcursionId, requeried.OpmExcursionId);
            Assert.AreEqual(opmExcursionResponse.OltExcursionId, requeried.OltExcursionId);
            Assert.AreEqual(opmExcursionResponse.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.AreEqual(opmExcursionResponse.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmExcursionResponse.LastModifiedDateTime.Date, requeried.LastModifiedDateTime.Date);
            Assert.AreEqual(opmExcursionResponse.Response, requeried.Response);
            Assert.AreEqual(opmExcursionResponse.ToeVersion, requeried.ToeVersion);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            var opmExcursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            var opmExcursion = excursionDao.Insert(OpmExcursionFixture.CreateForInsert());
            opmExcursionResponse.OltExcursionId = opmExcursion.IdValue;
            var saved = dao.Insert(opmExcursionResponse);
            var requeried = dao.QueryById(saved.IdValue);
            requeried.LastModifiedBy = UserFixture.CreateSupervisor();
            requeried.Response = "new response";
            requeried.LastModifiedDateTime = Clock.Now.AddDays(10);

            dao.Update(requeried);
            var updated = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(updated);
            Assert.AreEqual(requeried.OpmExcursionId, updated.OpmExcursionId);
            Assert.AreEqual(requeried.HistorianTag, updated.HistorianTag);
            Assert.AreEqual(requeried.LastModifiedDateTime.Date, updated.LastModifiedDateTime.Date);
            Assert.AreEqual(requeried.Response, updated.Response);
            Assert.AreEqual(requeried.ToeVersion, updated.ToeVersion);
        }

        [Ignore] [Test]
        public void ShouldQueryByExcursionId()
        {
            var opmExcursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            var opmExcursion = excursionDao.Insert(OpmExcursionFixture.CreateForInsert());
            opmExcursionResponse.OltExcursionId = opmExcursion.IdValue;
            var saved = dao.Insert(opmExcursionResponse);
            var requeried = dao.QueryById(saved.IdValue);
            requeried.LastModifiedBy = UserFixture.CreateSupervisor();
            requeried.Response = "new response";
            requeried.LastModifiedDateTime = Clock.Now.AddDays(10);

            dao.Update(requeried);
            var updated = dao.QueryByExcursionId(saved.OltExcursionId);

            Assert.IsNotNull(updated);
            Assert.AreEqual(requeried.OpmExcursionId, updated.OpmExcursionId);
            Assert.AreEqual(requeried.LastModifiedBy.IdValue, updated.LastModifiedBy.IdValue);
            Assert.AreEqual(requeried.HistorianTag, updated.HistorianTag);
            Assert.AreEqual(requeried.LastModifiedDateTime.Date, updated.LastModifiedDateTime.Date);
            Assert.AreEqual(requeried.Response, updated.Response);
            Assert.AreEqual(requeried.ToeVersion, updated.ToeVersion);
        }


        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmExcursionResponseDao>();
            excursionDao = DaoRegistry.GetDao<IOpmExcursionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}