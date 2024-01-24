using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmExcursionDaoTest : AbstractDaoTest
    {
        private IOpmExcursionDao dao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var opmExcursion = OpmExcursionFixture.CreateForInsert();
            
            var saved = dao.Insert(opmExcursion);
            var requeried = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmExcursion.Average, requeried.Average);
            Assert.AreEqual(opmExcursion.Duration, requeried.Duration);
            Assert.AreEqual(opmExcursion.EndDateTime, requeried.EndDateTime);
            Assert.AreEqual(opmExcursion.EngineerComments, requeried.EngineerComments);
            Assert.AreEqual(opmExcursion.OpmExcursionId, requeried.OpmExcursionId);
            Assert.AreEqual(opmExcursion.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(opmExcursion.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmExcursion.IlpNumber, requeried.IlpNumber);
            Assert.AreEqual(opmExcursion.LastUpdatedDateTime.Date, requeried.LastUpdatedDateTime.Date);
            Assert.AreEqual(opmExcursion.OpmTrendUrl, requeried.OpmTrendUrl);
            Assert.AreEqual(opmExcursion.Peak, requeried.Peak);
            Assert.AreEqual(opmExcursion.ReasonCode, requeried.ReasonCode);
            Assert.AreEqual(opmExcursion.StartDateTime.Date, requeried.StartDateTime.Date);
            Assert.AreEqual(opmExcursion.Status, requeried.Status);
            Assert.AreEqual(opmExcursion.ToeName, requeried.ToeName);
            Assert.AreEqual(opmExcursion.ToeType, requeried.ToeType);
            Assert.AreEqual(opmExcursion.UnitOfMeasure, requeried.UnitOfMeasure);
            Assert.AreEqual(opmExcursion.ToeLimitValue, requeried.ToeLimitValue);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            var opmExcursion = OpmExcursionFixture.CreateForInsert();
            var saved = dao.Insert(opmExcursion);
            var requeried = dao.QueryById(saved.IdValue);
            requeried.EndDateTime = Clock.Now.AddSeconds(-33d);
            requeried.Average = 44323;
            requeried.Duration = 4323;
            requeried.Peak = 543999;
            requeried.IlpNumber = 3290132;
            requeried.EngineerComments = "new comments form an engineer";
            requeried.ReasonCode = "new reason code";
            requeried.LastUpdatedDateTime = Clock.Now;

            dao.Update(requeried);
            var updated = dao.QueryById(saved.IdValue);


            Assert.IsNotNull(updated);
            Assert.AreEqual(requeried.Average, updated.Average);
            Assert.AreEqual(requeried.Duration, updated.Duration);
            Assert.AreEqual(requeried.EndDateTime.ToDate(), updated.EndDateTime.ToDate());
            Assert.AreEqual(requeried.EngineerComments, updated.EngineerComments);
            Assert.AreEqual(requeried.OpmExcursionId, updated.OpmExcursionId);
            Assert.AreEqual(requeried.FunctionalLocation, updated.FunctionalLocation);
            Assert.AreEqual(requeried.HistorianTag, updated.HistorianTag);
            Assert.AreEqual(requeried.IlpNumber, updated.IlpNumber);
            Assert.AreEqual(requeried.LastUpdatedDateTime.Date, updated.LastUpdatedDateTime.Date);
            Assert.AreEqual(requeried.OpmTrendUrl, updated.OpmTrendUrl);
            Assert.AreEqual(requeried.Peak, updated.Peak);
            Assert.AreEqual(requeried.ReasonCode, updated.ReasonCode);
            Assert.AreEqual(requeried.StartDateTime.Date, updated.StartDateTime.Date);
            Assert.AreEqual(requeried.Status, updated.Status);
            Assert.AreEqual(requeried.ToeName, updated.ToeName);
            Assert.AreEqual(requeried.ToeType, updated.ToeType);
            Assert.AreEqual(requeried.UnitOfMeasure, updated.UnitOfMeasure);
            Assert.AreEqual(requeried.ToeLimitValue, updated.ToeLimitValue);
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmExcursionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}