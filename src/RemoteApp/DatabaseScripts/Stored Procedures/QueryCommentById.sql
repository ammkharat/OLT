 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCommentById')
	BEGIN
		DROP PROCEDURE [dbo].QueryCommentById
	END
GO

CREATE Procedure [dbo].QueryCommentById
	(
		@Id bigint
	)
AS

SELECT
    *
FROM
    Comment
WHERE
    Id = @Id
GO

GRANT EXEC ON QueryCommentById TO PUBLIC
GO


 