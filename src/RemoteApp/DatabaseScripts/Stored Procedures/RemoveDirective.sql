IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveDirective')
	BEGIN
		DROP Procedure RemoveDirective
	END

GO

CREATE Procedure [dbo].RemoveDirective
	(
		@Id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE Directive
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveDirective TO PUBLIC

GO