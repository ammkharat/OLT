IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemCustomFieldEntry')
    BEGIN
        DROP PROCEDURE [dbo].InsertActionItemCustomFieldEntry
    END
GO


CREATE Procedure [dbo].[InsertActionItemCustomFieldEntry]
    (
    @Id bigint Output,
	@CustomFieldId bigint,
    @ActionItemId bigint,
    @CustomFieldName varchar(100),
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null,
    @DisplayOrder int,
	@TypeId tinyint,
	@PhdLinkTypeId tinyint
    )
AS

INSERT INTO ActionItemCustomFieldEntry
(
    ActionItemId,
	CustomFieldId,
	ActionItemCustomFieldName,
	FieldEntry,
	NumericFieldEntry,
	DisplayOrder,
	TypeId,
	PhdLinkTypeId
)
VALUES
(
    @ActionItemId,
	@CustomFieldId,
	@CustomFieldName,
	@FieldEntry,
	@NumericFieldEntry,
	@DisplayOrder,
	@TypeId,
	@PhdLinkTypeId
)
SET @Id= IDENT_CURRENT('ActionItemCustomFieldEntry')
