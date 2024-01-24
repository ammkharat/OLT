using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class CommentDaoTest : AbstractDaoTest
    {
        private ICommentDao commentDao;

        protected override void TestInitialize()
        {
            commentDao = DaoRegistry.GetDao<ICommentDao>();
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void ShouldInsertCommentForTargetDefinition()
        {
            const long targetDefinitionId = TargetDefinitionFixture.TARGET_DEFINITION_FOR_ADDING_COMMENTS_ID;
            Comment comment = CommentFixture.CreateComment();
            Comment insertedComment =
                    commentDao.InsertTargetDefinitionComment(targetDefinitionId, comment);
            Assert.IsNotNull(insertedComment.Id);
            AssertComment(comment, insertedComment);
        }

        [Ignore] [Test]
        public void ShouldQueryCommentsByTargetDefinitionId()
        {
            const long targetDefinitionId = TargetDefinitionFixture.TARGET_DEFINITION_WITH_2_COMMENTS_ID;
            List<Comment> comments =
                    commentDao.QueryByTargetDefinitionId(targetDefinitionId);
            AssertComments(CommentFixture.GetCommentsForTargetDefinitionInDb(targetDefinitionId), comments);
        }

        [Ignore] [Test]
        public void ShouldInsertCommentForActionItemDefinition()
        {
            const long actionItemDefinitionId = ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_FOR_ADDING_COMMENTS_ID;
            Comment comment = CommentFixture.CreateComment();
            Comment insertedComment =
                    commentDao.InsertActionItemDefinitionComment(actionItemDefinitionId, comment);
            Assert.IsNotNull(insertedComment.Id);
            AssertComment(comment, insertedComment);
        }

        [Ignore] [Test]
        public void ShouldQueryCommentsByActionItemDefinitionId()
        {
            const long actionItemDefinitionId = ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_WITH_2_COMMENTS_ID;
            List<Comment> comments =
                    commentDao.QueryByActionItemDefinitionId(actionItemDefinitionId);
            AssertComments(CommentFixture.GetCommentsForActionItemDefinitionInDb(actionItemDefinitionId), comments);
        }

        [Ignore] [Test]
        public void QueryByIdShouldReturnCommentWithId()
        {
            Comment comment = commentDao.InsertComment(CommentFixture.CreateComment());
            Comment retrievedComment = commentDao.QueryById(comment.IdValue);
            Assert.AreEqual(comment.Id, retrievedComment.Id);
        }

        private void AssertComments(List<Comment> expectedComments,
                                    List<Comment> actualComments)
        {
            Assert.AreEqual(expectedComments.Count, actualComments.Count);
            actualComments.Sort();
            expectedComments.Sort();
            for(int i = 0; i < expectedComments.Count; i++)
            {
                AssertComment(expectedComments[i], actualComments[i]);
            }
        }

        private void AssertComment(Comment expectedComment, Comment actualComment)
        {
            Assert.AreEqual(expectedComment.Id, actualComment.Id);
            Assert.AreEqual(expectedComment.Text, actualComment.Text);
            Assert.AreEqual(expectedComment.CreatedDate, actualComment.CreatedDate);
            Assert.AreEqual(expectedComment.CreatedBy.Id, actualComment.CreatedBy.Id);
        }
    }
}