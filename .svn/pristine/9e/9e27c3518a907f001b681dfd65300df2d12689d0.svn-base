IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupsForActionItemDefinition')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByGroupsForActionItemDefinition
    END
GO


CREATE Procedure [dbo].[QueryCustomFieldByGroupsForActionItemDefinition]
    (
        @ActionItemDefinitionId bigint
    )
AS

SELECT
	cf.*, acfg.CustomFieldGroupId, cfcfg.DisplayOrder, cfg.OriginCustomFieldGroupId
FROM
	ActionItemDefinitionCustomFieldGroup acfg
	inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = acfg.CustomFieldGroupId
	inner join CustomField cf on cf.Id = cfcfg.CustomFieldId
	inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId
where acfg.ActionItemDefinitionId = @ActionItemDefinitionId
