if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogCustomFieldEntry]
GO

CREATE Procedure [dbo].[InsertLogCustomFieldEntry]
    (
    @Id bigint Output,
	@CustomFieldId bigint,
    @LogId bigint,
    @CustomFieldName varchar(100),
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null,
    @DisplayOrder int,
	@TypeId tinyint,
	@PhdLinkTypeId tinyint
    )
AS

INSERT INTO LogCustomFieldEntry
(
    LogId,
	CustomFieldId,
	CustomFieldName,
	FieldEntry,
	NumericFieldEntry,
	DisplayOrder,
	TypeId,
	PhdLinkTypeId
)
VALUES
(
    @LogId,
	@CustomFieldId,
	@CustomFieldName,
	@FieldEntry,
	@NumericFieldEntry,
	@DisplayOrder,
	@TypeId,
	@PhdLinkTypeId
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertLogCustomFieldEntry TO PUBLIC
GO   