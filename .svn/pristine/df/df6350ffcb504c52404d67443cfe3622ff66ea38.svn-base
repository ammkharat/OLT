IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionById
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionById
(
	@id int
)
AS

SELECT * 
FROM 
	TargetDefinition 
WHERE 
	ID = @id
GO

GRANT EXEC ON QueryTargetDefinitionById TO PUBLIC
GO