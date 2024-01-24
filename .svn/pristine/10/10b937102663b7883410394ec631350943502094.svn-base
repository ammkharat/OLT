IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCommentsByActionItemDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCommentsByActionItemDefinitionId
	END

GO

CREATE Procedure [dbo].QueryCommentsByActionItemDefinitionId
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT
    comment.*
FROM
    Comment comment
    JOIN ActionItemDefinitionComment actionItemDefinitionComment ON comment.Id = actionItemDefinitionComment.CommentId
WHERE
    actionItemDefinitionComment.ActionItemDefinitionId = @ActionItemDefinitionId

GO

GRANT EXEC ON QueryCommentsByActionItemDefinitionId TO PUBLIC
GO


  