IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN75BNew')
BEGIN
drop procedure [dbo].[UpdateFormGN75BNew]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateFormGN75BNew]
(
	@Id bigint,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(50),
	@ClosedDateTime datetime = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@BlindsRequired bit,
	@EquipmentType VARCHAR(50),
    @LockBoxNumber varchar(30),
	@LockBoxLocation varchar(30),
	@DeadLeg bit,
	@DeadLegRisk bit,
	@SpecialPrecautions varchar(250),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint,
	@templateid bigint 
)
AS

UPDATE 
	FormGN75B
SET 
	FormStatusId = @FormStatusId,
	FunctionalLocationId = @FunctionalLocationId,
	Location = @Location,
	ClosedDateTime = @ClosedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	BlindsRequired = @BlindsRequired,
	EquipmentType = @EquipmentType,
    LockBoxNumber = @LockBoxNumber,
	LockBoxLocation = @LockBoxLocation,
	DeadlEG = @DeadLeg,
	DeadLegRisk = @DeadLegRisk,
	SpecialPrecautions = @SpecialPrecautions,
	PathToSchematic = @PathToSchematic,
	SchematicImage = @SchematicImage,
	templateid = @templateid
WHERE
	Id = @Id and siteid = @siteid

if @siteid = 1 and @templateid > 0 and @FormStatusId = 2
begin 
update FormGN75BTemplate set FormStatusId = 2 where Id = @templateid
end


GRANT EXEC ON UpdateFormGN75BNew TO PUBLIC



