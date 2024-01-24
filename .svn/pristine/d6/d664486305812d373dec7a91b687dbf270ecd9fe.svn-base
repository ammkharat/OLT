if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLogCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLogCustomFieldEntry]
GO

CREATE Procedure [dbo].[UpdateLogCustomFieldEntry]
    (
    @Id bigint,
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null
    )
AS

update LogCustomFieldEntry
set
	FieldEntry = @FieldEntry,
	NumericFieldEntry = @NumericFieldEntry
where Id = @Id

GO 

GRANT EXEC ON UpdateLogCustomFieldEntry TO PUBLIC
GO   