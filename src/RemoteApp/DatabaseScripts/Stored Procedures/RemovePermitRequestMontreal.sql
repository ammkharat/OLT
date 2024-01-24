IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemovePermitRequestMontreal')
	BEGIN
		DROP  Procedure  RemovePermitRequestMontreal
	END

GO

CREATE Procedure [dbo].RemovePermitRequestMontreal
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	PermitRequestMontreal
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemovePermitRequestMontreal TO PUBLIC

GO