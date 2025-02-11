 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsNotRead ]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsNotRead]
GO   
Create  Procedure [dbo].QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsNotRead            
    (            
        @CsvFLOCIds varchar(max),       
          @StartOfDateRange DateTime,            
        @EndOfDateRange DateTime       
                 
    )     
As    
WITH q_cte (QuestionnaireId)            
AS            
(            
select distinct q.id            
  from dbo.ShiftHandoverQuestionnaire q            
  WHERE             
   (q.CreatedDateTime >= @StartOfDateRange and           
   q.CreatedDateTime <= @EndOfDateRange  and    IsFlexible=0 )                        
         
   AND            
 (             
  EXISTS            
  (            
  -- Floc of Shift Handover matches one of the passed in flocs            
  select qfl.ShiftHandoverQuestionnaireId From IDSplitter(@CsvFLOCIds) ids            
  INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON ids.Id = qfl.FunctionalLocationId            
  WHERE qfl.ShiftHandoverQuestionnaireId = q.Id            
  )            
  OR EXISTS            
  (            
    -- Floc of Shift Handover is child of one of the passed in flocs (look down the floc tree from my selected flocs)            
    select qfl.ShiftHandoverQuestionnaireId from FunctionalLocationAncestor a            
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid            
    INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON a.Id = qfl.FunctionalLocationId            
    WHERE qfl.ShiftHandoverQuestionnaireId = q.Id              
  )            
 )            
)    
Select * Into #TempAllReadUserId    
From    
 (SELECT            
          
    ReadUser.Id ,    
   CreateUser.LastName as CreatedByLastName,            
    CreateUser.FirstName as CreatedByFirstName,            
    CreateUser.UserName as CreatedByUserName,     
    f.FullHierarchy as FullHierarchy,
    q.ShiftHandOverConfigurationName,
    q.Id as Qid      
            
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
   LEFT JOIN WorkAssignment a ON q.WorkAssignmentId = a.Id)AS X    
   ;    
       
 With Log_Id_CTE (LogId)      
AS       
(      
SELECT       
  DISTINCT l.Id       
FROM      
  [Log] l      
  INNER JOIN LogFunctionalLocation lfl ON lfl.LogId = l.Id      
WHERE      
    l.Deleted = 0 AND      
  (l.CreatedDateTime  >= @StartOfDateRange and           
   l.CreatedDateTime <= @EndOfDateRange )    
 AND    
 (       
  EXISTS      
  (      
  -- Floc of Log matches one of the passed in flocs      
  select * From IDSplitter(@CsvFLOCIds) ids      
  WHERE lfl.FunctionalLocationId = ids.Id      
  )      
  OR EXISTS      
  (      
    -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)      
    select a.Id from FunctionalLocationAncestor a      
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid      
    WHERE lfl.FunctionalLocationId = a.Id      
  )      
 )      
),    
SummaryLog_Id_Cte (SummaryLogId)      
AS      
(      
select distinct l.id      
  from       
    dbo.SummaryLog l      
    INNER JOIN SummaryLogFunctionalLocation lfl on lfl.SummaryLogId = l.Id      
  WHERE       
    l.Deleted = 0 AND             
     (l.CreatedDateTime  >= @StartOfDateRange and           
     l.CreatedDateTime <= @EndOfDateRange )     
     AND          
    (      
    EXISTS      
    (      
          -- Floc of Summary Log matches one of the passed in flocs      
          select * From IDSplitter(@CsvFLOCIds) ids      
          WHERE ids.Id = lfl.FunctionalLocationId      
    )      
      OR EXISTS      
    (      
        -- Floc of Summary Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)      
       select * from FunctionalLocationAncestor a      
      INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid      
      WHERE a.Id = lfl.FunctionalLocationId      
    )      
  )     
  ) ,q_cte (QuestionnaireId)            
AS            
(            
select distinct q.id            
  from dbo.ShiftHandoverQuestionnaire q            
  WHERE             
   (q.CreatedDateTime>= @StartOfDateRange and           
   q.CreatedDateTime <= @EndOfDateRange  and IsFlexible=0)                     
         
   AND            
 (             
  EXISTS            
  (            
  -- Floc of Shift Handover matches one of the passed in flocs            
  select qfl.ShiftHandoverQuestionnaireId From IDSplitter(@CsvFLOCIds) ids            
  INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON ids.Id = qfl.FunctionalLocationId            
  WHERE qfl.ShiftHandoverQuestionnaireId = q.Id            
  )            
  OR EXISTS            
  (            
    -- Floc of Shift Handover is child of one of the passed in flocs (look down the floc tree from my selected flocs)            
    select qfl.ShiftHandoverQuestionnaireId from FunctionalLocationAncestor a            
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid            
    INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qfl ON a.Id = qfl.FunctionalLocationId            
    WHERE qfl.ShiftHandoverQuestionnaireId = q.Id              
  )            
 )    
 )    
     
       
  Select * Into #TempAllNotReadUserId    
  From    
  (    
   (SELECT      
   l.UserID As CreatedByUserID      
 FROM      
    [Log] l       
     INNER JOIN  Log_Id_CTE on Log_Id_CTE.LogId = l.Id      
    INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id       
   --INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id      
  -- INNER JOIN [SiteConfiguration] sc on S.SiteId = sc.SiteId     
 )    
       
   UNION ALL    
   (SELECT      
l.CreatedByUserID      
FROM       
  [SummaryLog] l             
  INNER JOIN SummaryLog_Id_Cte ON SummaryLog_Id_Cte.SummaryLogId = l.Id      
 -- INNER JOIN dbo.SummaryLogFunctionalLocationList floclist ON floclist.SummaryLogId = l.Id      
  --inner join [Shift] s on l.CreationUserShiftPatternId = s.Id      
 -- INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId     
 )    
      
  UNION ALL    
  (SELECT            
          
q.CreatedByUserID       
            
FROM            
    ShiftHandoverQuestionnaire q            
    INNER JOIN q_cte ON q_cte.QuestionnaireId = q.Id            
   -- INNER JOIN Shift s ON q.ShiftId = s.Id            
  -- INNER JOIN SiteConfiguration sc ON s.SiteId = sc.SiteId            
  --  INNER JOIN [User] CreateUser ON q.CreatedByUserId = CreateUser.Id             
  -- INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qf on qf.ShiftHandoverQuestionnaireId = q.Id            
  -- INNER JOIN FunctionalLocation f on qf.FunctionalLocationId = f.Id            
   --INNER JOIN ShiftHandoverQuestionnaireRead r on r.ShiftHandoverQuestionnaireId = q.id                    
  -- LEFT JOIN WorkAssignment a ON q.WorkAssignmentId = a.Id    
)    
   )AS Y    
       
   --Select * from #TempAllReadUserId    
       
   Select distinct( t.CreatedByUserID),u.userName,t2.ShiftHandOverConfigurationName,t2.Qid,t2.CreatedByFirstName,t2.CreatedByLastName,t2.CreatedByUserName
   --,#TempAllReadUserId.CreatedByLastName,#TempAllReadUserId.CreatedByFirstName,    
  -- #TempAllReadUserId.CreatedByUserName,#TempAllReadUserId.FullHierarchy    
    from #TempAllNotReadUserId t Join [User] u  on t.CreatedByUserID=u.Id , #TempAllReadUserId t2
   where t.CreatedByUserID not in (Select t2.Id from #TempAllReadUserId t2)    
       
   Drop Table #TempAllNotReadUserId    
   Drop Table #TempAllReadUserId    
   
       
GRANT EXEC ON QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsNotRead   TO PUBLIC    
    