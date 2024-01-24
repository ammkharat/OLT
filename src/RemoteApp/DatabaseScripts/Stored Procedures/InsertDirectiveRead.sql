IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDirectiveRead')
	BEGIN
		DROP  Procedure  InsertDirectiveRead
	END

GO

CREATE Procedure [dbo].[InsertDirectiveRead]
(
	@DirectiveId bigint,
	@UserId bigint,
	@DateTime datetime
)
AS

INSERT INTO [DirectiveRead]
(
    [DirectiveId],
    [UserId], 
    [DateTime]
)
VALUES
(
    @DirectiveId,
    @UserId,
    @DateTime
)

GO
GRANT EXEC ON [InsertDirectiveRead] TO PUBLIC
GO
