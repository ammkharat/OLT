if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLogDefinitionCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLogDefinitionCustomFieldEntry]
GO

CREATE Procedure [dbo].[UpdateLogDefinitionCustomFieldEntry]
    (
    @Id bigint,
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null
    )
AS

update LogDefinitionCustomFieldEntry
set
	FieldEntry = @FieldEntry,
	NumericFieldEntry = @NumericFieldEntry
where Id = @Id

GO 

GRANT EXEC ON UpdateLogDefinitionCustomFieldEntry TO PUBLIC
GO   