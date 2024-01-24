IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveCokerCard')
	BEGIN
		DROP  Procedure  RemoveCokerCard
	END

GO

CREATE Procedure [dbo].RemoveCokerCard
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	CokerCard
	SET LastModifiedByUserId = @LastModifiedByUserId, 
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveCokerCard TO PUBLIC

GO