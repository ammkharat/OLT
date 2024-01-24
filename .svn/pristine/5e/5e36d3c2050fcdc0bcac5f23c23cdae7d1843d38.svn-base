using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmToeDefinitionCommentDaoTest : AbstractDaoTest
    {
        private IOpmToeDefinitionCommentDao dao;
        private IOpmToeDefinitionDao toeDefinitionDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            var insertedOpmToeDefinition = toeDefinitionDao.Insert(opmToeDefinition);
            var opmToeDefinitionComment = OpmToeDefinitionCommentFixture.CreateForInsert();
            opmToeDefinitionComment.OltToeDefinitionId = insertedOpmToeDefinition.IdValue;
            var saved = dao.Insert(opmToeDefinitionComment);
            var requeried = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmToeDefinitionComment.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.AreEqual(opmToeDefinitionComment.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmToeDefinitionComment.ToeName, requeried.ToeName);
            Assert.AreEqual(opmToeDefinitionComment.LastModifiedDateTime.Date, requeried.LastModifiedDateTime.Date);
            Assert.AreEqual(opmToeDefinitionComment.Comment, requeried.Comment);
            Assert.AreEqual(opmToeDefinitionComment.ToeVersion, requeried.ToeVersion);
        }

        [Ignore] [Test]
        public void ShouldQueryByOltToeDefinitionId()
        {
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            var insertedOpmToeDefinition = toeDefinitionDao.Insert(opmToeDefinition);
            var opmToeDefinitionComment = OpmToeDefinitionCommentFixture.CreateForInsert();
            opmToeDefinitionComment.OltToeDefinitionId = insertedOpmToeDefinition.IdValue;
            var saved = dao.Insert(opmToeDefinitionComment);

            var requeried = dao.QueryByOltToeDefinitionId(saved.OltToeDefinitionId);

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmToeDefinitionComment.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.AreEqual(opmToeDefinitionComment.ToeName, requeried.ToeName);
            Assert.AreEqual(opmToeDefinitionComment.HistorianTag, requeried.HistorianTag);
            Assert.AreEqual(opmToeDefinitionComment.LastModifiedDateTime.Date, requeried.LastModifiedDateTime.Date);
            Assert.AreEqual(opmToeDefinitionComment.Comment, requeried.Comment);
            Assert.AreEqual(opmToeDefinitionComment.ToeVersion, requeried.ToeVersion);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            var insertedOpmToeDefinition = toeDefinitionDao.Insert(opmToeDefinition);
            var opmToeDefinitionComment = OpmToeDefinitionCommentFixture.CreateForInsert();
            opmToeDefinitionComment.OltToeDefinitionId = insertedOpmToeDefinition.IdValue;
            var saved = dao.Insert(opmToeDefinitionComment);
            var requeried = dao.QueryById(saved.IdValue);
            requeried.Comment = "new comment";
            requeried.LastModifiedDateTime = Clock.Now.AddDays(10);

            dao.Update(requeried);
            var updated = dao.QueryById(saved.IdValue);

            Assert.IsNotNull(updated);
            Assert.AreEqual(requeried.HistorianTag, updated.HistorianTag);
            Assert.AreEqual(requeried.LastModifiedDateTime.Date, updated.LastModifiedDateTime.Date);
            Assert.AreEqual(requeried.Comment, updated.Comment);
            Assert.AreEqual(requeried.ToeVersion, updated.ToeVersion);
        }


        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmToeDefinitionCommentDao>();
            toeDefinitionDao = DaoRegistry.GetDao<IOpmToeDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}