IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByWorkAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByWorkAssignment
    END
GO

CREATE Procedure [dbo].QueryCustomFieldByWorkAssignment        
    (        
        @AssignmentId bigint,        
  @appliesToLogs bit = null,        
  @appliesToSummaryLogs bit = null,        
  @appliesToDailyDirectives bit = null          
    )        
AS        
        
SELECT         
 distinct cf.*, cfcfg.DisplayOrder, cfg.Id as CustomFieldGroupId, cfg.OriginCustomFieldGroupId ,      
 cfg.OriginCustomFieldGroupId,GreaterThanValue,LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring(DBO.GetCustomFieldColour(null,cf.ID),1,1) AS COLOR, cfwr.IsActive      
FROM         
 CustomField cf        
 inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldId = cf.Id        
 inner join CustomFieldGroup cfg on cfcfg.CustomFieldGroupId = cfg.Id        
 inner join CustomFieldGroupWorkAssignment cfgwa on cfgwa.CustomFieldGroupId = cfg.Id        
 left join CustomFieldWithRange cfwr on cf.ID = cfwr.CustomFieldID   and cfwr.ActiveTo is null  
where        
 cfgwa.WorkAssignmentId = @AssignmentId and        
 cfg.Deleted = 0       
 and         
   ((@appliesToLogs is not null AND cfg.AppliesToLogs = @appliesToLogs)        
   or (@appliesToSummaryLogs is not null AND cfg.AppliesToSummaryLogs = @appliesToSummaryLogs)        
   or (@appliesToDailyDirectives is not null AND cfg.AppliesToDailyDirectives = @appliesToDailyDirectives))  
GO

GRANT EXEC ON [QueryCustomFieldByWorkAssignment] TO PUBLIC
GO