IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemCustomFieldEntryByActionItemId')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemCustomFieldEntryByActionItemId
    END
GO


CREATE Procedure [dbo].[QueryActionItemCustomFieldEntryByActionItemId]          
 (          
 @ActionItemId bigint          
 )          
AS          
SELECT         
 acfe.*, ActionItemCustomFieldName as CustomFieldName ,GreaterThanValue,      
LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring (DBO.GetcustomfieldcolourForSummaryLog(@ActionItemId,acfe.CustomFieldId),1,1) AS COLOR, cfwr.IsActive      
FROM         
 ActionItemCustomFieldEntry acfe      
 Left Join CustomFieldWithRange cfwr       
 ON acfe.CustomFieldId = cfwr.CustomFieldID  And cfwr.Id = Substring (DBO.GetcustomfieldcolourForSummaryLog(@ActionItemId,acfe.CustomFieldId),3,8)    
WHERE        
 ActionItemId = @ActionItemId  