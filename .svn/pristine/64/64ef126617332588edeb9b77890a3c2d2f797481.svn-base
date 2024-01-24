IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteLogDefinitionCustomFieldEntries')
	BEGIN
		DROP  Procedure  DeleteLogDefinitionCustomFieldEntries
	END

GO

CREATE Procedure [dbo].[DeleteLogDefinitionCustomFieldEntries]
(
    @EntityId bigint,
	@CsvCustomFieldEntryIdsAssociatedToEntity varchar(max) 
)
AS

DELETE FROM LogDefinitionCustomFieldEntry
WHERE LogDefinitionId = @EntityId and Id NOT IN (select Id from IDSplitter(@CsvCustomFieldEntryIdsAssociatedToEntity))

GO
 