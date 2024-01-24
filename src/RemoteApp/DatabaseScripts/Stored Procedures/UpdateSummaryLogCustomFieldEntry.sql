if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateSummaryLogCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateSummaryLogCustomFieldEntry]
GO

CREATE Procedure [dbo].[UpdateSummaryLogCustomFieldEntry]
    (
    @Id bigint,
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null
    )
AS

update SummaryLogCustomFieldEntry
set
	FieldEntry = @FieldEntry,
	NumericFieldEntry = @NumericFieldEntry
where Id = @Id

GO 

GRANT EXEC ON UpdateSummaryLogCustomFieldEntry TO PUBLIC
GO   