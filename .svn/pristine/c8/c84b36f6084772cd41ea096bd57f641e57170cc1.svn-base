IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormGN6')
	BEGIN
		DROP  Procedure  RemoveFormGN6
	END

GO

CREATE Procedure [dbo].RemoveFormGN6
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormGN6
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormGN6 TO PUBLIC

GO