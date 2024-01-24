  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertTargetDefinitionReadWriteTagConfiguration')
	BEGIN
		DROP Procedure InsertTargetDefinitionReadWriteTagConfiguration
	END

GO

CREATE Procedure [dbo].[InsertTargetDefinitionReadWriteTagConfiguration]
	(
	@Id bigint Output,
	
	@MaxDirectionId bigint,
	@MaxTagId bigint = null,
	
	@MinDirectionId bigint,
	@MinTagId bigint = null, 
	
	@TargetDirectionId bigint, 
	@TargetTagId bigint= null, 
	
	@GapUnitValueDirectionId bigint, 
	@GapUnitValueTagId bigint = null,
	
	@TargetDefinitionId bigint
	)
AS

INSERT INTO [TargetDefinitionReadWriteTagConfiguration]
(
	[MaxDirectionId], 
	[MaxTagId],

	[MinDirectionId],
	[MinTagId],
	
	[TargetDirectionId],
	[TargetTagId],
	
	[GapUnitValueDirectionId],
	[GapUnitValueTagId],
	
	[TargetDefinitionId]
)
VALUES
(
	@MaxDirectionId,
	@MaxTagId,
	
	@MinDirectionId,
	@MinTagId, 	
	
	@TargetDirectionId,
	@TargetTagId,
	
	@GapUnitValueDirectionId,
	@GapUnitValueTagId,
	
	@TargetDefinitionId
)
	
SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertTargetDefinitionReadWriteTagConfiguration] TO PUBLIC
GO