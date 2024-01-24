IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormGN59')
	BEGIN
		DROP  Procedure  RemoveFormGN59
	END

GO

CREATE Procedure [dbo].RemoveFormGN59
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormGN59
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormGN59 TO PUBLIC

GO