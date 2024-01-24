IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupsForLog')
    BEGIN
        DROP PROCEDURE [dbo].QueryCustomFieldByGroupsForLog
    END
GO

CREATE Procedure [dbo].QueryCustomFieldByGroupsForLog          
    (          
        @LogId bigint          
    )          
AS          
          
SELECT          
 cf.*, lcfg.CustomFieldGroupId, cfcfg.DisplayOrder, cfg.OriginCustomFieldGroupId,GreaterThanValue,        
LessThanValue,RangeGreaterThanValue,RangeLessThanValue,Substring (DBO.GetCustomFieldColour(@LogId,cf.Id),1,1) AS COLOR , cfwr.IsActive             
FROM          
 LogCustomFieldGroup lcfg          
 inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId          
 inner join CustomField cf on cf.Id = cfcfg.CustomFieldId          
 inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId          
 left join CustomFieldWithRange cfwr on cf.ID = cfwr. CustomFieldID   And cfwr.id = Substring (DBO.GetCustomFieldColour(@LogId,cf.Id),3,8)    
where lcfg.LogId = @LogId
GO

GRANT EXEC ON [QueryCustomFieldByGroupsForLog] TO PUBLIC
GO