IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCommentsByTargetDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCommentsByTargetDefinitionId
	END
GO

CREATE Procedure [dbo].QueryCommentsByTargetDefinitionId
	(
		@TargetDefinitionId bigint
	)
AS

SELECT
    comment.*
FROM
    Comment comment
    JOIN TargetDefinitionComment targetDefinitionComment ON comment.Id = targetDefinitionComment.CommentId
WHERE
    targetDefinitionComment.TargetDefinitionId = @TargetDefinitionId
GO

GRANT EXEC ON QueryCommentsByTargetDefinitionId TO PUBLIC
GO