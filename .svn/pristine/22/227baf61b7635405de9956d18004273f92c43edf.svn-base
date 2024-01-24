IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead
    END
GO

CREATE  Procedure dbo.QueryShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead  
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
  (q.CreatedDateTime >= @StartOfDateRange and  
  q.CreatedDateTime <= @EndOfDateRange and q.IsFlexible=0)   
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
  shq.[Text] as QuestionText,
  shq.YesNo,
  shq.EmailList  
FROM   
  ShiftHandoverAnswer a  
  INNER JOIN q_cte ON q_cte.QuestionnaireId = a.ShiftHandoverQuestionnaireId  
  INNER JOIN ShiftHandoverQuestion shq ON a.ShiftHandoverQuestionId = shq.Id  
OPTION (OPTIMIZE FOR UNKNOWN)    


GRANT EXEC ON QueryShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead TO PUBLIC
GO