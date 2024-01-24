IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupByActionItemDefinitionId')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldGroupByActionItemDefinitionId
    END
GO

CREATE Procedure [dbo].[QueryCustomFieldGroupByActionItemDefinitionId]
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT cfg.* 
FROM ActionItemDefinitionCustomFieldGroup Adcfg
INNER JOIN CustomFieldGroup cfg on cfg.Id = Adcfg.CustomFieldGroupId	
where Adcfg.ActionItemDefinitionId = @ActionItemDefinitionId
