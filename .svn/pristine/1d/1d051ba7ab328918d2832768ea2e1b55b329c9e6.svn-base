IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogRead')
	BEGIN
		DROP  Procedure  InsertLogRead
	END

GO

CREATE Procedure [dbo].[InsertLogRead]
(
	@LogId bigint,
	@UserId bigint,
	@DateTime datetime
)
AS

INSERT INTO [LogRead]
(
    [LogId],
    [UserId], 
    [DateTime]
)
VALUES
(
    @LogId,
    @UserId,
    @DateTime
)

GO
GRANT EXEC ON [InsertLogRead] TO PUBLIC
GO
