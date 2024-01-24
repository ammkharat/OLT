IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[InsertFormGN75BSarniaNew]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)  

DROP PROCEDURE dbo.InsertFormGN75BSarniaNew

GO 

SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO


GO
CREATE Procedure [dbo].[InsertFormGN75BSarniaNew]
(
	@Id bigint Output,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(50),
	@ClosedDateTime datetime = NULL,	
		
	@CreatedDateTime datetime = NULL,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@BlindsRequired bit,
	@EquipmentType VARCHAR(50),
    @LockBoxNumber varchar(255),
	@LockBoxLocation varchar(255),
	@DeadLeg bit,
	@DeadLegRisk bit,
	@SpecialPrecautions varchar(250),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint,
	@templateid bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	select top 1 @NewFormId = id from FormGN75BSarnia order by id desc
	set @NewFormId = isnull(@NewFormId,0) + 1
	-- @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormGN75BSarnia
(
	Id,
	FormStatusId,
	FunctionalLocationId,
	Location,
	ClosedDateTime,
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	BlindsRequired,
	DeadLeg,
	DeadLegRisk,
	SpecialPrecautions,
	LockBoxNumber,
	EquipmentType,
	LockBoxLocation,
	PathToSchematic,
	SchematicImage,
	Deleted,
	siteid,
	templateid
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
	@BlindsRequired,
	@DeadLeg,
	@DeadLegRisk,
	@SpecialPrecautions,
	@LockBoxNumber,
	@EquipmentType,
	@LockBoxLocation,
	@PathToSchematic,
	@SchematicImage,
	0,
	@siteid,
	@templateid
);

if @siteid = 1 and @templateid > 0 and @FormStatusId = 2
begin 
update FormGN75BTemplate set FormStatusId = 2 where Id = @templateid
end

SET @Id=@NewFormId; 
go
GRANT EXEC ON [InsertFormGN75BNew] TO PUBLIC
GO