  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogCustomFieldEntryHistory')
	BEGIN
		DROP  Procedure  InsertLogCustomFieldEntryHistory
	END
GO

CREATE Procedure [dbo].[InsertLogCustomFieldEntryHistory]
(
	@LogHistoryId bigint,
	@CustomFields varchar(max)
)
AS

INSERT INTO [LogCustomFieldEntryHistory]
(
	[LogHistoryId],
	[CustomFields]
)
VALUES
(
    @LogHistoryId,
	@CustomFields
)

GO

GRANT EXEC ON [InsertLogCustomFieldEntryHistory] TO PUBLIC
GO