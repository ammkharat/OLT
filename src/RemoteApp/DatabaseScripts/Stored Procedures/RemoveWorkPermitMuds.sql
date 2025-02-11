
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitMuds')
	BEGIN
		DROP Procedure [dbo].RemoveWorkPermitMuds
	END
Go

CREATE Procedure [dbo].[RemoveWorkPermitMuds]
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	WorkPermitMuds
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveWorkPermitMuds TO PUBLIC
GO
