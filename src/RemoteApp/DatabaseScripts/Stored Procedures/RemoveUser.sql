IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveUser')
	BEGIN
		DROP  Procedure  RemoveUser
	END

GO

CREATE Procedure [dbo].RemoveUser
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	[User] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveUser TO PUBLIC

GO 