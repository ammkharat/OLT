
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogByShiftHandover')
    BEGIN
        DROP PROCEDURE [dbo].QuerySummaryLogByShiftHandover
    END
GO   
CREATE Procedure [dbo].QuerySummaryLogByShiftHandover  
 (  
  @ShiftHandoverId bigint  
 )  
  
AS  
  
select   
 l.*  
from SummaryLog l  
  INNER JOIN ShiftHandoverQuestionnaireSummaryLog assoc ON assoc.SummaryLogId = l.Id  
  INNER JOIN ShiftHandoverQuestionnaire SHQ on SHQ.Id = assoc.ShiftHandoverQuestionnaireId
  
WHERE  
 l.Deleted = 0 and  
 assoc.ShiftHandoverQuestionnaireId = @ShiftHandoverId 
 AND l.CreatedByUserId = SHQ.CreatedByUserId
  
OPTION (OPTIMIZE FOR UNKNOWN)      
  
GRANT EXEC ON QuerySummaryLogByShiftHandover TO PUBLIC  