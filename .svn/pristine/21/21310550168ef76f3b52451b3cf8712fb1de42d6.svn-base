IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRestrictionDefinition')
	BEGIN
		DROP  Procedure  RemoveRestrictionDefinition
	END

GO

CREATE Procedure [dbo].RemoveRestrictionDefinition
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE RestrictionDefinition 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveRestrictionDefinition TO PUBLIC

GO


