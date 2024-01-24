IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormGN1')
	BEGIN
		DROP  Procedure  RemoveFormGN1
	END

GO

CREATE Procedure [dbo].RemoveFormGN1
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormGN1
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormGN1 TO PUBLIC

GO