IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionById
	END
GO

CREATE Procedure dbo.QueryActionItemDefinitionById
	(
	@id bigint
	)
AS
SELECT * FROM ActionItemDefinition ai

INNER JOIN Schedule s ON ai.ScheduleId = s.Id        --//RITM0265710 mangesh
  
WHERE ai.Id=@Id  
GO

GRANT EXEC ON QueryActionItemDefinitionById TO PUBLIC
GO