IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemovePermitRequestLubes')
	BEGIN
		DROP  Procedure  RemovePermitRequestLubes
	END

GO

CREATE Procedure [dbo].RemovePermitRequestLubes
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	PermitRequestLubes
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemovePermitRequestLubes TO PUBLIC

GO