IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormOilsandsTraining')
	BEGIN
		DROP  Procedure  RemoveFormOilsandsTraining
	END

GO

CREATE Procedure [dbo].RemoveFormOilsandsTraining
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormOilsandsTraining
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormOilsandsTraining TO PUBLIC

GO