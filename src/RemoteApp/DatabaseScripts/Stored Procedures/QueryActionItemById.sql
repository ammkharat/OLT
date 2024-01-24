IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemById')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemById
	END
GO

CREATE Procedure dbo.QueryActionItemById
	(
	@id bigint
	)
AS


-- SELECT * FROM ActionItem WHERE Id=@Id     
  
--On 14-Oct-2016 Added below as require ActionItemDefinition Deleted status  
SELECT B.Deleted as 'IsActionItemDefinitionDeleted',A.* FROM ActionItem A    
Left Join ActionItemDefinition B On A.CreatedByActionItemDefinitionId = B.Id  
WHERE A.Id=@Id  
GO

GRANT EXEC ON QueryActionItemById TO PUBLIC
GO