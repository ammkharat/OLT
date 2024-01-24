IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteSummaryLogCustomFieldEntries')
	BEGIN
		DROP  Procedure  DeleteSummaryLogCustomFieldEntries
	END

GO

CREATE Procedure [dbo].[DeleteSummaryLogCustomFieldEntries]
(
    @EntityId bigint,
	@CsvCustomFieldEntryIdsAssociatedToEntity varchar(max) 
)
AS

DELETE FROM SummaryLogCustomFieldEntry
WHERE SummaryLogId = @EntityId and Id NOT IN (select Id from IDSplitter(@CsvCustomFieldEntryIdsAssociatedToEntity))

GO
 