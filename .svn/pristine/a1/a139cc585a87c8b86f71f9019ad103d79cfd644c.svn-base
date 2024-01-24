using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmToeDefinitionCommentHistoryDaoTest : AbstractDaoTest
    {
        private IOpmToeDefinitionCommentHistoryDao dao;

        [Ignore] [Test]
        public void ShoudInsert()
        {
            var definitionComment = OpmToeDefinitionCommentFixture.CreateForInsert();
            definitionComment.Id = 1;
            definitionComment.LastModifiedDateTime = new DateTime(2013, 12, 5);
            definitionComment.LastModifiedDateTime = new DateTime(2013, 12, 5);
            var excursionResponseHistory = definitionComment.TakeSnapshot();

            dao.Insert(excursionResponseHistory);

            var excursionResponseHistories = dao.GetByToeName(definitionComment.ToeName);
            Assert.IsTrue(excursionResponseHistories.Count > 0);
            Assert.AreEqual(definitionComment.Comment, excursionResponseHistories[0].Comment);
            Assert.AreEqual(definitionComment.ToeName, excursionResponseHistories[0].ToeName);
            Assert.AreEqual(definitionComment.LastModifiedBy.IdValue,
                excursionResponseHistories[0].LastModifiedBy.IdValue);
            Assert.AreEqual(definitionComment.LastModifiedDateTime, excursionResponseHistories[0].LastModifiedDate);
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmToeDefinitionCommentHistoryDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}