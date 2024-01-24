if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN75BTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN75BTemplate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[UpdateFormGN75BTemplate]
(
	@Id bigint,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(50),
	@ClosedDateTime datetime = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@EquipmentType VARCHAR(50),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint
)
AS

UPDATE 
	FormGN75BTemplate
SET 
	FormStatusId = @FormStatusId,
	FunctionalLocationId = @FunctionalLocationId,
	Location = @Location,
	ClosedDateTime = @ClosedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	EquipmentType = @EquipmentType,
	PathToSchematic = @PathToSchematic,
	SchematicImage = @SchematicImage
WHERE
	Id = @Id and siteid = @siteid
GRANT EXEC ON UpdateFormGN75BTemplate TO PUBLIC


