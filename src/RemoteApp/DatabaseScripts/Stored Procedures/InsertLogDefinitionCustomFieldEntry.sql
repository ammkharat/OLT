﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogDefinitionCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogDefinitionCustomFieldEntry]
GO

CREATE Procedure [dbo].[InsertLogDefinitionCustomFieldEntry]
    (
    @Id bigint Output,
	@CustomFieldId bigint,
    @LogDefinitionId bigint,
    @CustomFieldName varchar(100),
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null,
    @DisplayOrder int,
	@TypeId tinyint,
	@PhdLinkTypeId tinyint
    )
AS

INSERT INTO LogDefinitionCustomFieldEntry
(
    LogDefinitionId,
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
    @LogDefinitionId,
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
GRANT EXEC ON InsertLogDefinitionCustomFieldEntry TO PUBLIC
GO   