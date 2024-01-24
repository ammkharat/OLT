IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionStateById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionStateById
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionStateById
(
	@Id bigint
)
AS

SELECT * 
FROM 
	TargetDefinitionState 
WHERE 
	TargetDefinitionId = @Id
GO

GRANT EXEC ON QueryTargetDefinitionStateById TO PUBLIC
GO 