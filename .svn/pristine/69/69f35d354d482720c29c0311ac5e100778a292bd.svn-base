using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmToeDefinitionDaoTest : AbstractDaoTest
    {
        private IOpmToeDefinitionDao dao;


        [Ignore] [Test]
        public void ShouldGetByTagAndToeVersion()
        {
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            var saved = dao.Insert(opmToeDefinition);
            var requeried = dao.QueryByTagAndVersion(saved.HistorianTag, saved.ToeVersion);
        
            Assert.IsNotNull(requeried);
            
            Assert.AreEqual(opmToeDefinition.ToeVersion, requeried.ToeVersion);
            Assert.AreEqual(opmToeDefinition.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmToeDefinition.ToeVersionPublishDate.Date, requeried.ToeVersionPublishDate.Date);
            Assert.AreEqual(opmToeDefinition.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(opmToeDefinition.ToeName, requeried.ToeName);
            Assert.AreEqual(opmToeDefinition.ToeType, requeried.ToeType);
            Assert.AreEqual(opmToeDefinition.LimitValue, requeried.LimitValue);
            Assert.AreEqual(opmToeDefinition.CausesDescription, requeried.CausesDescription);
            Assert.AreEqual(opmToeDefinition.ConsequencesDescription, requeried.ConsequencesDescription);
            Assert.AreEqual(opmToeDefinition.CorrectiveActionDescription, requeried.CorrectiveActionDescription);
            Assert.AreEqual(opmToeDefinition.ReferencesDocuments, requeried.ReferencesDocuments);
            Assert.AreEqual(opmToeDefinition.UnitOfMeasure, requeried.UnitOfMeasure);
            Assert.AreEqual(opmToeDefinition.OpmToeHistoryUrl, requeried.OpmToeHistoryUrl);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            var saved = dao.Insert(opmToeDefinition);

            var requeried = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmToeDefinition.ToeVersion, requeried.ToeVersion);
            Assert.AreEqual(opmToeDefinition.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmToeDefinition.ToeVersionPublishDate.Date, requeried.ToeVersionPublishDate.Date);
            Assert.AreEqual(opmToeDefinition.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(opmToeDefinition.ToeName, requeried.ToeName);
            Assert.AreEqual(opmToeDefinition.ToeType, requeried.ToeType);
            Assert.AreEqual(opmToeDefinition.LimitValue, requeried.LimitValue);
            Assert.AreEqual(opmToeDefinition.CausesDescription, requeried.CausesDescription);
            Assert.AreEqual(opmToeDefinition.ConsequencesDescription, requeried.ConsequencesDescription);
            Assert.AreEqual(opmToeDefinition.CorrectiveActionDescription, requeried.CorrectiveActionDescription);
            Assert.AreEqual(opmToeDefinition.ReferencesDocuments, requeried.ReferencesDocuments);
            Assert.AreEqual(opmToeDefinition.UnitOfMeasure, requeried.UnitOfMeasure);
            Assert.AreEqual(opmToeDefinition.OpmToeHistoryUrl, requeried.OpmToeHistoryUrl);
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmToeDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}