  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogCustomFieldEntryHistory')
	BEGIN
		DROP  Procedure  InsertSummaryLogCustomFieldEntryHistory
	END
GO

CREATE Procedure [dbo].[InsertSummaryLogCustomFieldEntryHistory]
(
	@SummaryLogHistoryId bigint,
	@CustomFields varchar(max)
)
AS

INSERT INTO [SummaryLogCustomFieldEntryHistory]
(
	[SummaryLogHistoryId],
	[CustomFields]
)
VALUES
(
    @SummaryLogHistoryId,
	@CustomFields
)

GO

GRANT EXEC ON [InsertSummaryLogCustomFieldEntryHistory] TO PUBLIC
GO