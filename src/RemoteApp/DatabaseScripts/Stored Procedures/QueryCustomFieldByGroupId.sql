IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldByGroupId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldByGroupId
	END
GO

CREATE Procedure dbo.QueryCustomFieldByGroupId                
 (                
  @CustomFieldGroupId bigint                
 )                
AS                
                
with cte as  
(  
SELECT   
  
 cf.*, cfcfg.DisplayOrder, @CustomFieldGroupId as CustomFieldGroupId, cfg.OriginCustomFieldGroupId,          
GreaterThanValue,    LessThanValue,RangeGreaterThanValue,RangeLessThanValue , 'B' as COLOR   , cfwr.IsActive ,cfwr.ID as cfwrid  
FROM   
  
CustomField cf               
inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldId = cf.Id                
inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId                
left join CustomFieldWithRange cfwr on cf.ID = cfwr. CustomFieldID   
WHERE cfcfg.[CustomFieldGroupId] = @CustomFieldGroupId    
)  
  
 
SELECT m1.*  
FROM cte m1 LEFT JOIN cte m2  
 ON (m1.ID = m2.Id AND m1.cfwrid < m2.cfwrid)  
WHERE m2.cfwrid IS NULL  
 
GO

GRANT EXEC ON QueryCustomFieldByGroupId TO PUBLIC
GO