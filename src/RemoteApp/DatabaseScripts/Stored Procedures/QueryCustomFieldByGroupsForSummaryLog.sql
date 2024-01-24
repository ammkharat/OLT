IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupsForSummaryLog')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByGroupsForSummaryLog
    END
GO

CREATE Procedure [dbo].QueryCustomFieldByGroupsForSummaryLog        
    (        
        @SummaryLogId bigint        
    )        
AS        
        
SELECT        
 cf.*, lcfg.CustomFieldGroupId, cfcfg.DisplayOrder, cfg.OriginCustomFieldGroupId  ,GreaterThanValue,      
LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring (DBO.GetcustomfieldcolourForSummaryLog(@SummaryLogId,cf.ID),1,1) AS COLOR, cfwr.IsActive      
FROM        
 SummaryLogCustomFieldGroup lcfg        
 inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId        
 inner join CustomField cf on cf.Id = cfcfg.CustomFieldId        
 inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId        
 left join CustomFieldWithRange cfwr on cf.Id = cfwr.CustomFieldID  and cfwr.Id = Substring (DBO.GetcustomfieldcolourForSummaryLog(@SummaryLogId,cf.ID),3,8)    
where lcfg.SummaryLogId = @SummaryLogId 
GO

GRANT EXEC ON [QueryCustomFieldByGroupsForSummaryLog] TO PUBLIC
GO