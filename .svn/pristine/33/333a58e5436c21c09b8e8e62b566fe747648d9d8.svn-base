
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75BTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75BTemplate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertFormGN75BTemplate]
(
	@CreatedDateTime datetime = NULL,
	@CreatedByUserId bigint,
	@Id bigint Output,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(100),
	@ClosedDateTime datetime = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@EquipmentType VARCHAR(50),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	select top 1 @NewFormId = id from formgn75btemplate order by id desc
	set @NewFormId = isnull(@NewFormId,0) + 1
END

INSERT INTO FormGN75BTemplate
(
	Id,
	FormStatusId, 
	FunctionalLocationId,
	[Location],
	ClosedDateTime,
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	EquipmentType,
	PathToSchematic,
	SchematicImage,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@FunctionalLocationId,
	@Location,
	@ClosedDateTime,
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@EquipmentType,
	@PathToSchematic,
	@SchematicImage,
	0,
	@siteid
);

SET @Id=@NewFormId; 

