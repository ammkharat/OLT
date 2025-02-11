﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSummaryLogCustomFieldEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSummaryLogCustomFieldEntry]
GO

CREATE Procedure [dbo].[InsertSummaryLogCustomFieldEntry]
    (
    @Id bigint Output,
	@CustomFieldId bigint,
    @SummaryLogId bigint,
    @CustomFieldName varchar(100),
    @FieldEntry varchar(100) = null,
	@NumericFieldEntry decimal(18,6) = null,
    @DisplayOrder int,
	@TypeId tinyint,
	@PhdLinkTypeId tinyint
    )
AS

INSERT INTO SummaryLogCustomFieldEntry
(
    SummaryLogId,
	CustomFieldId,
	SummaryLogCustomFieldName,
	FieldEntry,
	NumericFieldEntry,
	DisplayOrder,
	TypeId,
	PhdLinkTypeId
)
VALUES
(
    @SummaryLogId,
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
GRANT EXEC ON InsertSummaryLogCustomFieldEntry TO PUBLIC
GO   