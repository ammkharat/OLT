IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTargetDefinition')
	BEGIN
		DROP  Procedure  RemoveTargetDefinition
	END

GO

CREATE Procedure [dbo].RemoveTargetDefinition
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE TargetDefinition 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveTargetDefinition TO PUBLIC

GO


