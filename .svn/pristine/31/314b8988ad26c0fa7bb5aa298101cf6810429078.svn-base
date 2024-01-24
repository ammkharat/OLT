IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupsForLogDefinition')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByGroupsForLogDefinition
    END
GO

CREATE Procedure [dbo].QueryCustomFieldByGroupsForLogDefinition
    (
        @LogDefinitionId bigint
    )
AS

SELECT
	cf.*, lcfg.CustomFieldGroupId, cfcfg.DisplayOrder, cfg.OriginCustomFieldGroupId
FROM
	LogDefinitionCustomFieldGroup lcfg
	inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId
	inner join CustomField cf on cf.Id = cfcfg.CustomFieldId
	inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId
where lcfg.LogDefinitionId = @LogDefinitionId
GO

GRANT EXEC ON [QueryCustomFieldByGroupsForLogDefinition] TO PUBLIC
GO