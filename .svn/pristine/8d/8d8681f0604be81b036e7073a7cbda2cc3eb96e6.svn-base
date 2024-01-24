IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormOP14')
	BEGIN
		DROP  Procedure  RemoveFormOP14
	END

GO

CREATE Procedure [dbo].RemoveFormOP14
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormOP14
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormOP14 TO PUBLIC

GO