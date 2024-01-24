IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveLabAlertDefinition')
	BEGIN
		DROP  Procedure  RemoveLabAlertDefinition
	END

GO

CREATE Procedure [dbo].RemoveLabAlertDefinition
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE LabAlertDefinition 
	SET [LastModifiedByUserId] = @LastModifiedByUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveLabAlertDefinition TO PUBLIC

GO


