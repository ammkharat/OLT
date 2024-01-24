IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormMontrealCsd')
	BEGIN
		DROP  Procedure  RemoveFormMontrealCsd
	END

GO

CREATE Procedure [dbo].RemoveFormMontrealCsd
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormMontrealCsd
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormMontrealCsd TO PUBLIC

GO