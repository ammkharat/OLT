IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedDirectiveAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserMarkedDirectiveAsRead
	END
GO

CREATE Procedure [dbo].[QueryUserMarkedDirectiveAsRead]
(
	@DirectiveId bigint,
	@UserId bigint
)
AS

SELECT * 
FROM 
	[DirectiveRead]
WHERE
	DirectiveId = @DirectiveId AND
	UserId = @UserId
GO

GRANT EXEC ON [QueryUserMarkedDirectiveAsRead] TO PUBLIC
GO 