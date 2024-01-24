IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionDefinitionById
	END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionById
(
	@id int
)
AS

SELECT * FROM RestrictionDefinition 
WHERE ID=@id
GO

GRANT EXEC ON QueryRestrictionDefinitionById TO PUBLIC
GO