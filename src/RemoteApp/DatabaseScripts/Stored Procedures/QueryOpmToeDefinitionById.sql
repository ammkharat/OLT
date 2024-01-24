IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmToeDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmToeDefinitionById
	END
GO

CREATE Procedure [dbo].QueryOpmToeDefinitionById
(
	@id bigint
)
AS

SELECT 
	def.*

FROM OpmToeDefinition def
WHERE def.ID=@id
GO

GRANT EXEC ON QueryOpmToeDefinitionById TO PUBLIC
GO