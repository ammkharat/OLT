IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetDefinitionAfterUnableToAccessTag')
	BEGIN
		DROP Procedure UpdateTargetDefinitionAfterUnableToAccessTag
	END
GO

CREATE Procedure [dbo].[UpdateTargetDefinitionAfterUnableToAccessTag]
(
	@Id bigint,
    @IsActive bit,	
	@LastModifiedUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE [TargetDefinition]
SET              
	[IsActive] = @IsActive,
	[LastModifiedUserId] = @LastModifiedUserId,
	[LastModifiedDateTime] = @LastModifiedDateTime

WHERE
	Id = @Id
GO

GRANT EXEC ON [dbo].[UpdateTargetDefinitionAfterUnableToAccessTag] TO PUBLIC
GO 