IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteActionItemCustomFieldEntries')
    BEGIN
        DROP PROCEDURE [dbo].DeleteActionItemCustomFieldEntries
    END
GO
CREATE Procedure [dbo].[DeleteActionItemCustomFieldEntries]
(
    @EntityId bigint,
	@CsvCustomFieldEntryIdsAssociatedToEntity varchar(max) 
)
AS

DELETE FROM ActionItemCustomFieldEntry
WHERE ActionItemId = @EntityId and Id NOT IN (select Id from IDSplitter(@CsvCustomFieldEntryIdsAssociatedToEntity))

