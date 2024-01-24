IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldForActionItems')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldForActionItems
	END
GO

CREATE Procedure [dbo].[QueryCustomFieldForActionItems]        

@ActionItemId bigint

AS        

declare @customfieldgroupid bigint
select @customfieldgroupid = CustomFieldGroupId from ActionItemDefinitionCustomFieldGroup where ActionItemDefinitionId = (select CreatedByActionItemDefinitionId from actionitem where id = @ActionItemId)

        
SELECT         
 distinct cf.*, cfcfg.DisplayOrder, cfg.Id as CustomFieldGroupId, cfg.OriginCustomFieldGroupId ,      
 cfg.OriginCustomFieldGroupId,GreaterThanValue,LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring(DBO.GetCustomFieldColour(null,cf.ID),1,1) AS COLOR, cfwr.IsActive      
FROM         
 CustomField cf        
 inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldId = cf.Id        
 inner join CustomFieldGroup cfg on cfcfg.CustomFieldGroupId = cfg.Id        
  left join CustomFieldWithRange cfwr on cf.ID = cfwr.CustomFieldID   and cfwr.ActiveTo is null  
where        
 cfg.AppliesToActionItems = 1 and cfg.id = @customfieldgroupid
  order by DisplayOrder

