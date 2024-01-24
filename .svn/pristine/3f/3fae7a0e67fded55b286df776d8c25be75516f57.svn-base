IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormGN24')
	BEGIN
		DROP  Procedure  RemoveFormGN24
	END

GO

CREATE Procedure [dbo].RemoveFormGN24
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormGN24
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormGN24 TO PUBLIC

GO