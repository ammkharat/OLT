  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogDefinitionCustomFieldEntryHistory')
	BEGIN
		DROP  Procedure  InsertLogDefinitionCustomFieldEntryHistory
	END
GO

CREATE Procedure [dbo].[InsertLogDefinitionCustomFieldEntryHistory]
(
	@LogDefinitionHistoryId bigint,
	@CustomFields varchar(max)
)
AS

INSERT INTO [LogDefinitionCustomFieldEntryHistory]
(
	[LogDefinitionHistoryId],
	[CustomFields]
)
VALUES
(
    @LogDefinitionHistoryId,
	@CustomFields
)

GO

GRANT EXEC ON [InsertLogDefinitionCustomFieldEntryHistory] TO PUBLIC
GO