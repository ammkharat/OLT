IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionHistoriesById
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionHistoriesById
	(
	@Id bigint
	)
AS

SELECT * 
FROM 
	TargetDefinitionHistory 
WHERE 
	Id=@Id 
ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryTargetDefinitionHistoriesById TO PUBLIC
GO