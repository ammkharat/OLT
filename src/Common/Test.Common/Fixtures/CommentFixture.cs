using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class CommentFixture
    {
        public static Comment CreateComment()
        {
            return CreateComment(DateTimeFixture.DateTimeNow);
        }

        public static Comment CreateComment(DateTime createdDateTime)
        {
            return new Comment(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), createdDateTime, "Some Comment");
        }

        public static List<Comment> GetCommentsForTargetDefinitionInDb(long targetDefinitionId)
        {
            List<Comment> comments = new List<Comment>();

            if (targetDefinitionId == TargetDefinitionFixture.TARGET_DEFINITION_WITH_2_COMMENTS_ID)
            {
                comments.Add(CreateCommentWithId1InDb());
                comments.Add(CreateCommentWithId2InDb());
            }

            return comments;
        }

        public static Comment CreateCommentWithId1InDb()
        {
            return CreateComment(1, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                 new DateTime(2006, 1, 25, 17, 0, 0), "Id = 1, Some comment");
        }

        public static Comment CreateCommentWithId2InDb()
        {
            return CreateComment(2, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                 new DateTime(2006, 1, 26, 17, 0, 0), "Id = 2, Some comment");
        }

        public static List<Comment> GetCommentsForActionItemDefinitionInDb(long actionItemDefinitionId)
        {
            List<Comment> comments = new List<Comment>();

            if (actionItemDefinitionId == ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_WITH_2_COMMENTS_ID)
            {
                comments.Add(CreateCommentWithId3InDb());
                comments.Add(CreateCommentWithId4InDb());
            }

            return comments;
        }

        public static Comment CreateCommentWithId3InDb()
        {
            return CreateComment(3, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                 new DateTime(2006, 1, 27, 17, 0, 0), "Id = 3, Some comment");
        }

        public static Comment CreateCommentWithId4InDb()
        {
            return CreateComment(4, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                 new DateTime(2006, 1, 28, 17, 0, 0), "Id = 4, Some comment");
        }

        public static Comment CreateCommentWithId5InDb()
        {
            return CreateComment(5, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                 new DateTime(2006, 1, 29, 17, 0, 0), "Id = 5, comment for target alert response");
        }

        private static Comment CreateComment(long id, User createdBy, DateTime createdDate, string text)
        {
            Comment comment = new Comment(createdBy, createdDate, text);
            comment.Id = id;
            return comment;
        }

        public static List<Comment> CreateComments()
        {
            List<Comment> comments = new List<Comment>
                                         {
                                             CreateCommentWithId1InDb(),
                                             CreateCommentWithId2InDb(),
                                             CreateCommentWithId3InDb()
                                         };
            return comments;
        }
    }
}