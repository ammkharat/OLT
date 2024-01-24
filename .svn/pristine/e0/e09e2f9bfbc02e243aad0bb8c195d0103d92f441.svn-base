IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireByWorkAssignmentAndShift')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireByWorkAssignmentAndShift
    END
GO
  
CREATE Procedure dbo.QueryShiftHandoverQuestionnaireByWorkAssignmentAndShift  
 (   
 @WorkAssignmentId bigint,  
 @ShiftId bigint,  
 @ShiftStartDateTime datetime,  
 @ShiftEndDateTime datetime  
 )  
AS  
  
SELECT * FROM ShiftHandoverQuestionnaire q  
WHERE    
 q.WorkAssignmentId = @WorkAssignmentId   
 and q.ShiftId =  @ShiftId  
 and 
 (q.CreatedDateTime >= @ShiftStartDateTime  and q.CreatedDateTime <= @ShiftEndDateTime  and IsFlexible=0) 
 
 /*     
/*RITM RITM0185797 Flexi shift handover */      
/*Amit Shukla start*/      
 OR      
 (((q.CreatedDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime ) OR (FlexiShiftEndDate BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime)) and IsFlexible=1)
 /*Amit Shukla end*/ 
 */
 
 OPTION (OPTIMIZE FOR UNKNOWN) 

GRANT EXEC ON QueryShiftHandoverQuestionnaireByWorkAssignmentAndShift TO PUBLIC
GO