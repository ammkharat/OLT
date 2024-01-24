 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveLogDefinition')
	BEGIN
		DROP  Procedure  RemoveLogDefinition
	END

GO

CREATE Procedure [dbo].RemoveLogDefinition
	(
			@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime

	)
AS

UPDATE [LogDefinition] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO

GRANT EXEC ON RemoveLogDefinition TO PUBLIC

GO