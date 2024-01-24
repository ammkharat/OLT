IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCommentsByProcedureDeviationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCommentsByProcedureDeviationId
	END

GO

CREATE Procedure [dbo].QueryCommentsByProcedureDeviationId
(
	@ProcedureDeviationId bigint
)
AS

SELECT
    comment.*
FROM
    Comment comment
    JOIN FormProcedureDeviationComment procedureDeviationComment ON comment.Id = procedureDeviationComment.CommentId
WHERE
    procedureDeviationComment.FormProcedureDeviationId = @ProcedureDeviationId
GO

GRANT EXEC ON QueryCommentsByProcedureDeviationId TO PUBLIC
GO


  