IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UndoRemoveUser')
	BEGIN
		DROP  Procedure UndoRemoveUser
	END

GO

CREATE Procedure [dbo].UndoRemoveUser
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	[User] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 0
	WHERE Id=@Id
GO


GRANT EXEC ON UndoRemoveUser TO PUBLIC

GO 