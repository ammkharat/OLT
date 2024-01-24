-- exec QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift @UserId=9243,@WorkAssignmentId=2286,@ShiftId=19,@ShiftStartDateTime='2018-04-23 05:30:00',@ShiftEndDateTime='2018-04-23 19:30:00'
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift
    END
GO

CREATE Procedure dbo.QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift    
 (    
 @UserId bigint,    
 @WorkAssignmentId bigint = NULL,    
 @ShiftId bigint,    
 @ShiftStartDateTime datetime,    
 @ShiftEndDateTime datetime    
 )    
AS    
    
SELECT *     
FROM     
 ShiftHandoverQuestionnaire q    
WHERE     
 q.CreatedByUserId = @UserId    
 and     
 (    
  (@WorkAssignmentId is null and q.WorkAssignmentId is null) or    
  (@WorkAssignmentId = q.WorkAssignmentId)    
 )    
 -- and q.ShiftId =  @ShiftId    
 AND   
 ((q.ShiftId =  @ShiftId AND (q.CreatedDateTime >= @ShiftStartDateTime    
 AND q.CreatedDateTime <= @ShiftEndDateTime   AND IsFlexible=0)        
/*RITM RITM0185797 Flexi shift handover */        
/*Amit Shukla start*/        
 OR
 ((( @ShiftStartDateTime BETWEEN q.FlexiShiftStartDate AND q.FlexiShiftEndDate) OR 
 (@ShiftEndDateTime BETWEEN q.FlexiShiftStartDate AND q.FlexiShiftEndDate)) AND IsFlexible=1)))          


OPTION (OPTIMIZE FOR UNKNOWN) 

GRANT EXEC ON QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift TO PUBLIC
GO
        