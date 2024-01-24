IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead
    END
GO
      
CREATE Procedure [dbo].QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead      
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
   q.CreatedDateTime <= @EndOfDateRange  and IsFlexible=0)               
   
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
    q.Id,      
 q.ShiftHandoverConfigurationName,      
 q.CreatedByUserId,      
 q.CreatedDateTime,      
 q.HasYesAnswer, 
 q.IsFlexible,
 q.FlexiShiftStartDate,
 q.FlexiShiftEndDate,     
      
 s.Id as ShiftId,      
 s.Name as ShiftName,      
 s.StartTime as ShiftStartTime,      
 s.EndTime as ShiftEndTime,      
      
 sc.PreShiftPaddingInMinutes as PreShiftPaddingInMinutes,      
 sc.PostShiftPaddingInMinutes as PostShiftPaddingInMinutes,      
      
 a.Name as AssignmentName,      
 a.Description as AssignmentDescription,      
      
    CreateUser.LastName as CreatedByLastName,      
    CreateUser.FirstName as CreatedByFirstName,      
    CreateUser.UserName as CreatedByUserName,      
      
 f.FullHierarchy as FullHierarchy,      
      
    ReadUser.LastName as ReadByLastName,      
    ReadUser.FirstName as ReadByFirstName,      
    ReadUser.UserName as ReadByUserName,      
 r.[DateTime] as ReadByDateTime      
      
FROM      
    ShiftHandoverQuestionnaire q      
    INNER JOIN q_cte ON q_cte.QuestionnaireId = q.Id      
    INNER JOIN Shift s ON q.ShiftId = s.Id      
   INNER JOIN SiteConfiguration sc ON s.SiteId = sc.SiteId      
    INNER JOIN [User] CreateUser ON q.CreatedByUserId = CreateUser.Id       
   INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qf on qf.ShiftHandoverQuestionnaireId = q.Id      
   INNER JOIN FunctionalLocation f on qf.FunctionalLocationId = f.Id      
   INNER JOIN ShiftHandoverQuestionnaireRead r on r.ShiftHandoverQuestionnaireId = q.id      
   INNER JOIN [User] ReadUser on ReadUser.Id = r.UserId      
   LEFT JOIN WorkAssignment a ON q.WorkAssignmentId = a.Id      
OPTION (OPTIMIZE FOR UNKNOWN) 

GRANT EXEC ON QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead TO PUBLIC
GO