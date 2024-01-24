IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionCountByGN75BId')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionCountByGN75BId
	END
GO

CREATE Procedure dbo.QueryActionItemDefinitionCountByGN75BId(@gn75BId bigint)
AS
SELECT count(*) as ActionItemDefinitionCount FROM ActionItemDefinition 
WHERE 
	GN75BId = @gn75BId
	AND Deleted = 0;

GO

GRANT EXEC ON QueryActionItemDefinitionCountByGN75BId TO PUBLIC
GO