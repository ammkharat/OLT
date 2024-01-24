using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICommentDao : IDao
    {
        Comment InsertComment(Comment comment);
        Comment QueryById(long id);

        Comment InsertTargetDefinitionComment(long targetDefinitionId, Comment comment);
        List<Comment> QueryByTargetDefinitionId(long targetDefinitionId);

        Comment InsertActionItemDefinitionComment(long actionItemDefinitionId, Comment comment);
        List<Comment> QueryByActionItemDefinitionId(long actionItemDefinitionId);

        Comment InsertDocumentSuggestionComment(long documentSuggestionId, Comment comment);
        List<Comment> QueryByDocumentSuggestionId(long documentSuggestionId);

        Comment InsertProcedureDeviationComment(long procedureDeviationId, Comment comment);
        List<Comment> QueryByProcedureDeviationId(long procedureDeviationId);
    }
}