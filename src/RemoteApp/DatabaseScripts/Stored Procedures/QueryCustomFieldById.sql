IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldById')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldById
	END
GO

CREATE Procedure dbo.QueryCustomFieldById              
 (              
  @Id bigint              
 )              
AS              
              
SELECT cf.*, cfcfg.DisplayOrder, cfcfg.CustomFieldGroupId as CustomFieldGroupId, cfg.OriginCustomFieldGroupId,GreaterThanValue,            
LessThanValue,RangeGreaterThanValue,RangeLessThanValue , 'B' as COLOR    , cfwr.IsActive           
FROM CustomField cf              
inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldId = cf.Id              
inner join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId              
left join CustomFieldWithRange cfwr on cf.ID = cfwr. CustomFieldID   --And cfwr.ActiveTo is not null      
WHERE cf.Id = @Id    
Order by ActiveTo desc, ActiveFrom desc
GO

GRANT EXEC ON QueryCustomFieldById TO PUBLIC
GO