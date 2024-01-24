IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemovePermitRequestEdmonton')
	BEGIN
		DROP  Procedure  RemovePermitRequestEdmonton
	END

GO

CREATE Procedure [dbo].RemovePermitRequestEdmonton
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	PermitRequestEdmonton
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemovePermitRequestEdmonton TO PUBLIC

GO