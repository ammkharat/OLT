IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogRead')
	BEGIN
		DROP  Procedure  InsertSummaryLogRead
	END

GO

CREATE Procedure [dbo].[InsertSummaryLogRead]
(
	@SummaryLogId bigint,
	@UserId bigint,
	@DateTime datetime
)
AS

INSERT INTO [SummaryLogRead]
(
    [SummaryLogId],
    [UserId], 
    [DateTime]
)
VALUES
(
    @SummaryLogId,
    @UserId,
    @DateTime
)

GO
GRANT EXEC ON [InsertSummaryLogRead] TO PUBLIC
GO
