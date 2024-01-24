IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitMontreal')
	BEGIN
		DROP  Procedure  RemoveWorkPermitMontreal
	END

GO

CREATE Procedure [dbo].RemoveWorkPermitMontreal
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	WorkPermitMontreal
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveWorkPermitMontreal TO PUBLIC

GO