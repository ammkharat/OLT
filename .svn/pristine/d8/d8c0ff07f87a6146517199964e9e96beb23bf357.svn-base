IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupsForActionItem')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByGroupsForActionItem
    END
GO

CREATE Procedure [dbo].[QueryCustomFieldByGroupsForActionItem]        
    (        
        @ActionItemId bigint        
    )        
AS        
        
SELECT        
 cf.*, AIcfg.CustomFieldGroupId, cfcfg.DisplayOrder, cfg.OriginCustomFieldGroupId  ,GreaterThanValue,      
LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring (DBO.GetcustomfieldcolourForSummaryLog(@ActionItemId,cf.ID),1,1) AS COLOR, cfwr.IsActive      
FROM        
 ActionItemCustomFieldGroup AIcfg        
 inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = AIcfg.CustomFieldGroupId        
 inner join CustomField cf on cf.Id = cfcfg.CustomFieldId        
 inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId        
 left join CustomFieldWithRange cfwr on cf.Id = cfwr.CustomFieldID  and cfwr.Id = Substring (DBO.GetcustomfieldcolourForSummaryLog(@ActionItemId,cf.ID),3,8)    
where AIcfg.ActionItemId = @ActionItemId 

