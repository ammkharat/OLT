IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetDefinitionReadWriteTagConfiguration')
	BEGIN
		DROP  Procedure  UpdateTargetDefinitionReadWriteTagConfiguration
	END
GO

CREATE Procedure [dbo].[UpdateTargetDefinitionReadWriteTagConfiguration]
(
	@Id bigint,
	@MaxDirectionId bigint,
	@MaxTagId bigint = null,
	@MinDirectionId bigint,
	@MinTagId bigint= null, 
	@TargetDirectionId bigint, 
	@TargetTagId bigint= null, 
	@GapUnitValueDirectionId bigint, 
	@GapUnitValueTagId bigint= null
)
AS

UPDATE	[TargetDefinitionReadWriteTagConfiguration]	
	SET 
	[MaxDirectionId] = @MaxDirectionId,
	[MaxTagId] = @MaxTagId,
	[MinDirectionId] =  @MinDirectionId,
	[MinTagId] = @MinTagId,
	[TargetDirectionId] = @TargetDirectionId, 
	[TargetTagId] = @TargetTagId,
	[GapUnitValueDirectionId] = @GapUnitValueDirectionId,
	[GapUnitValueTagId] = @GapUnitValueTagId,
	[Deleted] = 0
	WHERE Id = @Id
GO

GRANT EXEC ON [UpdateTargetDefinitionReadWriteTagConfiguration] TO PUBLIC
GO


 