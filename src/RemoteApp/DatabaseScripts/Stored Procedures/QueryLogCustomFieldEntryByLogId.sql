IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogCustomFieldEntryByLogId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogCustomFieldEntryByLogId
	END
GO

--CREATE Procedure dbo.QueryLogCustomFieldEntryByLogId
--	(
--	@LogId bigint
--	)
--AS
--SELECT * FROM LogCustomFieldEntry WHERE LogId = @LogId

CREATE Procedure dbo.QueryLogCustomFieldEntryByLogId          
 (          
 @LogId bigint          
 )          
AS          
SELECT       
lcfe.*,Substring (DBO.GetCustomFieldColour(@LogId,lcfe.CustomFieldID),1,1) AS COLOR,      
  cfwr.IsActive,  
GreaterThanValue,LessThanValue,RangeGreaterThanValue,RangeLessThanValue,cfwr.ActiveFrom as RangeDate, lg.LogDateTime as LogDate           
FROM LogCustomFieldEntry lcfe       
 Left Join CustomFieldWithRange cfwr       
 ON  lcfe.CustomFieldID = cfwr.CustomFieldID  And cfwr.id = Substring (DBO.GetCustomFieldColour(@LogId,lcfe.CustomFieldID),3,8)    
 Left Join [Log] lg      
 ON lcfe.LogId = lg.Id       
 Where LogId = @LogId  
GO

GRANT EXEC ON QueryLogCustomFieldEntryByLogId TO PUBLIC
GO