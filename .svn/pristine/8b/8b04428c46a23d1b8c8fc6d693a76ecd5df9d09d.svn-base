IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupByLogDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldGroupByLogDefinitionId
	END
GO

CREATE Procedure dbo.QueryCustomFieldGroupByLogDefinitionId
	(
		@LogDefinitionId bigint
	)
AS

SELECT cfg.* 
FROM LogDefinitionCustomFieldGroup ldcfg
INNER JOIN CustomFieldGroup cfg on cfg.Id = ldcfg.CustomFieldGroupId	
where ldcfg.LogDefinitionId = @LogDefinitionId	
GO

GRANT EXEC ON [QueryCustomFieldGroupByLogDefinitionId] TO PUBLIC
GO