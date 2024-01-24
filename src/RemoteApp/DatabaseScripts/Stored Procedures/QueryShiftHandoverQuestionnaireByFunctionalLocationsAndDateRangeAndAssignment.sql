IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignment
    END
GO
        
CREATE Procedure dbo.QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignment        
 (        
     @CsvFlocIds varchar(max),        
     @CsvAssignmentIds varchar(max),        
     @IncludeNullAssignment bit,        
     @StartOfDateRange DateTime,        
     @EndOfDateRange DateTime    
           
 )        
AS        
WITH q_cte (QuestionnaireId)        
AS        
(        
select distinct q.id        
  from dbo.ShiftHandoverQuestionnaire q        
  WHERE         
 ((q.CreatedDateTime >= @StartOfDateRange        
 and q.CreatedDateTime <= @EndOfDateRange       
  and IsFlexible=0)            
/*RITM RITM0185797 Flexi shift handover */            
/*Amit Shukla start*/            
 OR 
 ((( @StartOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate) OR ( @EndOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate)) and IsFlexible=1))           
 --(((q.FlexiShiftStartDate BETWEEN @StartOfDateRange AND @EndOfDateRange ) OR (q.FlexiShiftEndDate BETWEEN @StartOfDateRange AND @EndOfDateRange)) and IsFlexible=1)             
 /*Amit Shukla end*/       
  AND        
 (         
  EXISTS        
  (        
  -- Floc of Shift Handover matches one of the passed in flocs        
  select qfl.ShiftHandoverQuestionnaireId From IDSplitter(@CsvFlocIds) ids        
  INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON ids.Id = qfl.FunctionalLocationId        
  WHERE qfl.ShiftHandoverQuestionnaireId = q.Id        
  )        
  OR EXISTS        
  (        
    -- Floc of Shift Handover is child of one of the passed in flocs (look down the floc tree from my selected flocs)        
    select qfl.ShiftHandoverQuestionnaireId from FunctionalLocationAncestor a        
    INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid        
    INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON a.Id = qfl.FunctionalLocationId        
    WHERE qfl.ShiftHandoverQuestionnaireId = q.Id          
  )        
 )        
)        
SELECT q.*         
FROM        
 q_cte         
 INNER JOIN ShiftHandoverQuestionnaire q ON q.Id = q_cte.QuestionnaireId        
WHERE        
 (@IncludeNullAssignment = 1 and q.WorkAssignmentId is null) or        
 exists        
 (         
  select QueryAssignmentIds.Id        
  from IDSplitter(@CsvAssignmentIds) QueryAssignmentIds        
  where QueryAssignmentIds.Id = q.WorkAssignmentId     
 )        
OPTION (OPTIMIZE FOR UNKNOWN) 


GRANT EXEC ON QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignment TO PUBLIC
GO