using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CommentDao : AbstractManagedDao, ICommentDao
    {
        private const string INSERT_COMMENT_STORED_PROCEDURE = "InsertComment";
        private const string INSERT_TARGET_DEFINITION_COMMENT_STORED_PROCEDURE = "InsertTargetDefinitionComment";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryCommentById";
        private const string QUERY_BY_TARGET_DEFINITION_ID_STORED_PROCEDURE = "QueryCommentsByTargetDefinitionId";

        private const string INSERT_ACTION_ITEM_DEFINITION_COMMENT_STORED_PROCEDURE =
            "InsertActionItemDefinitionComment";

        private const string QUERY_BY_ACTION_ITEM_DEFINITION_ID_STORED_PROCEDURE =
            "QueryCommentsByActionItemDefinitionId";

        private const string INSERT_DOCUMENT_SUGGESTION_COMMENT_STORED_PROCEDURE =
            "InsertDocumentSuggestionComment";

        private const string QUERY_BY_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE =
            "QueryCommentsByDocumentSuggestionId";

        private const string INSERT_PROCEDURE_DEVIATION_COMMENT_STORED_PROCEDURE =
            "InsertProcedureDeviationComment";

        private const string QUERY_BY_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE =
            "QueryCommentsByProcedureDeviationId";

        private readonly IUserDao userDao;

        public CommentDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public Comment InsertComment(Comment comment)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(comment, SetCommonAttributes, INSERT_COMMENT_STORED_PROCEDURE);
            comment.Id = (long?) idParameter.Value;
            return comment;
        }

        public Comment QueryById(long id)
        {
            var command = ManagedCommand;
            var comment = command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            return comment;
        }

        public Comment InsertTargetDefinitionComment(long targetDefinitionId, Comment comment)
        {
            var command = ManagedCommand;
            command.AddParameter("@targetDefinitionId", targetDefinitionId);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(comment, SetCommonAttributes, INSERT_TARGET_DEFINITION_COMMENT_STORED_PROCEDURE);
            comment.Id = (long?) idParameter.Value;
            return comment;
        }

        public List<Comment> QueryByTargetDefinitionId(long targetDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@targetDefinitionId", targetDefinitionId);
            var comments =
                command.QueryForListResult(PopulateInstance, QUERY_BY_TARGET_DEFINITION_ID_STORED_PROCEDURE);
            return comments;
        }

        public Comment InsertActionItemDefinitionComment(long actionItemDefinitionId, Comment comment)
        {
            var command = ManagedCommand;
            command.AddParameter("@actionItemDefinitionId", actionItemDefinitionId);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(comment, SetCommonAttributes, INSERT_ACTION_ITEM_DEFINITION_COMMENT_STORED_PROCEDURE);
            comment.Id = (long?) idParameter.Value;
            return comment;
        }

        public List<Comment> QueryByActionItemDefinitionId(long actionItemDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@actionItemDefinitionId", actionItemDefinitionId);
            var comments =
                command.QueryForListResult(PopulateInstance, QUERY_BY_ACTION_ITEM_DEFINITION_ID_STORED_PROCEDURE);
            return comments;
        }

        public Comment InsertDocumentSuggestionComment(long documentSuggestionId, Comment comment)
        {
            var command = ManagedCommand;
            command.AddParameter("@DocumentSuggestionId", documentSuggestionId);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(comment, SetCommonAttributes, INSERT_DOCUMENT_SUGGESTION_COMMENT_STORED_PROCEDURE);
            comment.Id = (long?) idParameter.Value;
            return comment;
        }

        public List<Comment> QueryByDocumentSuggestionId(long documentSuggestionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@DocumentSuggestionId", documentSuggestionId);
            var comments =
                command.QueryForListResult(PopulateInstance, QUERY_BY_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE);
            return comments;
        }

        public Comment InsertProcedureDeviationComment(long procedureDeviationId, Comment comment)
        {
            var command = ManagedCommand;
            command.AddParameter("@ProcedureDeviationId", procedureDeviationId);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(comment, SetCommonAttributes, INSERT_PROCEDURE_DEVIATION_COMMENT_STORED_PROCEDURE);
            comment.Id = (long?) idParameter.Value;
            return comment;
        }

        public List<Comment> QueryByProcedureDeviationId(long procedureDeviationId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ProcedureDeviationId", procedureDeviationId);
            var comments =
                command.QueryForListResult(PopulateInstance, QUERY_BY_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE);
            return comments;
        }

        private void SetCommonAttributes(Comment comment, SqlCommand command)
        {
            command.AddParameter("@CreatedUserId", comment.CreatedBy.Id);
            command.AddParameter("@CreatedDate", comment.CreatedDate);
            command.AddParameter("@Text", comment.Text);
        }

        private Comment PopulateInstance(SqlDataReader reader)
        {
            var newId = reader.Get<long?>("Id");
            var createdBy = userDao.QueryById(reader.Get<long>("CreatedUserId"));
            var createdDate = reader.Get<DateTime>("CreatedDate");
            var text = reader.Get<string>("Text");

            var comment = new Comment(createdBy, createdDate, text) {Id = newId};
            return comment;
        }
    }
}