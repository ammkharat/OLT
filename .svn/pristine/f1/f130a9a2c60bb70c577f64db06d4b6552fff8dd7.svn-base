IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionById
	END
GO

CREATE Procedure [dbo].QueryLogDefinitionById
	(
		@id int
	)
AS

SELECT
	*
FROM
	[LogDefinition] 
WHERE 
	ID = @id
GO

GRANT EXEC ON QueryLogDefinitionById TO PUBLIC
GO 