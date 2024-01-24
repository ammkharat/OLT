IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormLubesAlarmDisable')
	BEGIN
		DROP  Procedure  RemoveFormLubesAlarmDisable
	END

GO

CREATE Procedure [dbo].RemoveFormLubesAlarmDisable
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	FormLubesAlarmDisable
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveFormLubesAlarmDisable TO PUBLIC

GO