 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldEntryBySummaryLogId')
	BEGIN
		DROP Procedure [dbo].QuerySummaryLogCustomFieldEntryBySummaryLogId
	END
GO

--CREATE Procedure dbo.QuerySummaryLogCustomFieldEntryBySummaryLogId
--	(
--	@SummaryLogId bigint
--	)
--AS

--SELECT 
--	*, SummaryLogCustomFieldName as CustomFieldName 
--FROM 
--	SummaryLogCustomFieldEntry 
--WHERE
--	SummaryLogId = @SummaryLogId

CREATE Procedure dbo.QuerySummaryLogCustomFieldEntryBySummaryLogId        
 (        
 @SummaryLogId bigint        
 )        
AS        
        
SELECT         
 slcfe.*, SummaryLogCustomFieldName as CustomFieldName ,GreaterThanValue,      
LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring (DBO.GetcustomfieldcolourForSummaryLog(@SummaryLogId,slcfe.CustomFieldId),1,1) AS COLOR, cfwr.IsActive      
FROM         
 SummaryLogCustomFieldEntry slcfe      
 Left Join CustomFieldWithRange cfwr       
 ON slcfe.CustomFieldId = cfwr.CustomFieldID  And cfwr.Id = Substring (DBO.GetcustomfieldcolourForSummaryLog(@SummaryLogId,slcfe.CustomFieldId),3,8)    
WHERE        
 SummaryLogId = @SummaryLogId  
GO

GRANT EXEC ON QuerySummaryLogCustomFieldEntryBySummaryLogId TO PUBLIC
GO