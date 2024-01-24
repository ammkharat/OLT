IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetDefinitionStatus')
	BEGIN
		DROP Procedure UpdateTargetDefinitionStatus
	END
GO

CREATE Procedure [dbo].[UpdateTargetDefinitionStatus]
(
	@TargetDefinitionId BIGINT,
	@StatusId BIGINT,
	@IsActive BIT,
	@LastModifiedDateTime DATETIME,
	@LastModifiedUserId BIGINT
)
AS

UPDATE [TargetDefinition]
SET              
	TargetDefinitionStatusId = @StatusId,
	IsActive = @IsActive,	
	LastModifiedDateTime = @LastModifiedDateTime,
	LastModifiedUserId = @LastModifiedUserId	
WHERE
	Id = @TargetDefinitionId
GO

GRANT EXEC ON [dbo].[UpdateTargetDefinitionStatus] TO PUBLIC
GO 