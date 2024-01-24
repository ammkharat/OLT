IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteLogCustomFieldEntries')
	BEGIN
		DROP  Procedure  DeleteLogCustomFieldEntries
	END

GO

CREATE Procedure [dbo].[DeleteLogCustomFieldEntries]
(
    @EntityId bigint,
	@CsvCustomFieldEntryIdsAssociatedToEntity varchar(max) 
)
AS

DELETE FROM LogCustomFieldEntry
WHERE LogId = @EntityId and Id NOT IN (select Id from IDSplitter(@CsvCustomFieldEntryIdsAssociatedToEntity))

GO
 