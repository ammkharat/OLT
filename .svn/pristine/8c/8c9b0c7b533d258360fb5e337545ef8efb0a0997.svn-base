IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateActionItemCustomFieldEntry')
    BEGIN
        DROP PROCEDURE [dbo].UpdateActionItemCustomFieldEntry
    END
GO


CREATE Procedure [dbo].[UpdateActionItemCustomFieldEntry]
    (
    @Id bigint,
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null
    )
AS

update ActionItemCustomFieldEntry
set
	FieldEntry = @FieldEntry,
	NumericFieldEntry = @NumericFieldEntry
where Id = @Id

