IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFlexibleShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryFlexibleShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead
    END
GO
  
CREATE Procedure dbo.QueryFlexibleShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead  
 (  
        @CsvFLOCIds varchar(max),  
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
  ((( @StartOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate) OR ( @EndOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate)) and IsFlexible=1)               
  --(((q.FlexiShiftStartDate BETWEEN @StartOfDateRange AND @EndOfDateRange ) OR (q.FlexiShiftEndDate BETWEEN @StartOfDateRange AND @EndOfDateRange)) and q.IsFlexible=1)    
    and EXISTS  
  (  
   select ShiftHandoverQuestionnaireId  
   from ShiftHandoverQuestionnaireRead r  
   where r.ShiftHandoverQuestionnaireId = q.Id  
  )  
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
SELECT   
  a.*,   
  shq.[Text] as QuestionText ,
  shq.YesNo,
  shq.EmailList  
FROM   
  ShiftHandoverAnswer a  
  INNER JOIN q_cte ON q_cte.QuestionnaireId = a.ShiftHandoverQuestionnaireId  
  INNER JOIN ShiftHandoverQuestion shq ON a.ShiftHandoverQuestionId = shq.Id  
OPTION (OPTIMIZE FOR UNKNOWN)    


GRANT EXEC ON QueryFlexibleShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead TO PUBLIC
GO