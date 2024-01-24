IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonHistoriesById
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonHistoriesById
	(
	@Id bigint
	)
AS
SELECT * 
FROM PermitRequestEdmontonHistory 
WHERE Id=@Id 
ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryPermitRequestEdmontonHistoriesById] TO PUBLIC
GO