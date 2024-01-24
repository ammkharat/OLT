  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDirectiveDTOsByParentFlocListAndMarkedAsNotRead]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[QueryDirectiveDTOsByParentFlocListAndMarkedAsNotRead]
Go

CREATE Procedure [dbo].QueryDirectiveDTOsByParentFlocListAndMarkedAsNotRead  
    (  
      --  @StartOfDateRange DateTime,  
      --  @EndOfDateRange DateTime,  
  @CsvFlocIds varchar(max)  
 )  
AS  
WITH Directive_Id_CTE (DirectiveId)  
AS   
(  
SELECT   
  DISTINCT d.Id  
FROM  
  [Directive] d  
  INNER JOIN DirectiveFunctionalLocation dfl ON dfl.DirectiveId = d.Id  
WHERE  
    d.Deleted = 0 AND  
 d.ActiveFromDateTime > DATEADD(year,-1,GETDATE()) and  
   -- d.ActiveToDateTime >= @StartOfDateRange and  
 (   
  EXISTS  
  (  
  -- Floc of Directive matches one of the passed in flocs  
  select * From IDSplitter(@CsvFlocIds) ids  
  WHERE dfl.FunctionalLocationId = ids.Id  
  )  
  OR EXISTS  
  (  
    -- Floc of Directive is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
    select a.Id from FunctionalLocationAncestor a  
    INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid  
    WHERE dfl.FunctionalLocationId = a.Id  
  )  
 )  
)  
Select * Into #TempAllReadUserId
From
(SELECT  
  r.UserId    
  
FROM  
    [Directive] d  
    inner join Directive_Id_CTE on Directive_Id_CTE.DirectiveId = d.Id  
 inner join DirectiveRead r on r.DirectiveId = d.id  
 inner join DirectiveFunctionalLocation dfl on dfl.DirectiveId = d.Id  
 inner join FunctionalLocation fl on fl.Id = dfl.FunctionalLocationId  
 inner join [User] readUser on readUser.Id = r.Userid  
 inner join [User] createdByUser on createdByUser.Id = d.CreatedByUserId  
 INNER JOIN [User] lastModifiedUser on lastModifiedUser.Id = d.LastModifiedByUserId  
 left outer join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id  
 left outer join WorkAssignment wa on wa.Id = dwa.WorkAssignmentId )as X
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
 l.CreatedDateTime > DATEADD(year,-1,GETDATE())
 AND
 (   
  EXISTS  
  (  
  -- Floc of Log matches one of the passed in flocs  
  select * From IDSplitter(@CsvFlocIds) ids  
  WHERE lfl.FunctionalLocationId = ids.Id  
  )  
  OR EXISTS  
  (  
    -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
    select a.Id from FunctionalLocationAncestor a  
    INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid  
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
    l.CreatedDateTime > DATEADD(year,-1,GETDATE()) 
     AND      
    (  
    EXISTS  
    (  
          -- Floc of Summary Log matches one of the passed in flocs  
          select * From IDSplitter(@CsvFlocIds) ids  
          WHERE ids.Id = lfl.FunctionalLocationId  
    )  
      OR EXISTS  
    (  
        -- Floc of Summary Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
       select * from FunctionalLocationAncestor a  
      INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid  
      WHERE a.Id = lfl.FunctionalLocationId  
    )  
  ) 
  ) ,q_cte (QuestionnaireId)        
AS        
(        
select distinct q.id        
  from dbo.ShiftHandoverQuestionnaire q        
  WHERE         
   (q.CreatedDateTime >=  DATEADD(year,-1,GETDATE()) and IsFlexible=0)                 
     
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
 
   
  Select * Into #TempAllNotReadUserId
  From
  (
   (SELECT  
   l.UserID As CreatedByUserID  
 FROM  
    [Log] l   
     INNER JOIN  Log_Id_CTE on Log_Id_CTE.LogId = l.Id  
    INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id   
   INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id  
   INNER JOIN [SiteConfiguration] sc on S.SiteId = sc.SiteId )
   
   UNION ALL
   (SELECT  
l.CreatedByUserID  
FROM   
  [SummaryLog] l         
  INNER JOIN SummaryLog_Id_Cte ON SummaryLog_Id_Cte.SummaryLogId = l.Id  
  INNER JOIN dbo.SummaryLogFunctionalLocationList floclist ON floclist.SummaryLogId = l.Id  
  inner join [Shift] s on l.CreationUserShiftPatternId = s.Id  
  INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId  )
  
  UNION ALL
  (SELECT        
      
q.CreatedByUserID   
        
FROM        
    ShiftHandoverQuestionnaire q        
    INNER JOIN q_cte ON q_cte.QuestionnaireId = q.Id        
    INNER JOIN Shift s ON q.ShiftId = s.Id        
   INNER JOIN SiteConfiguration sc ON s.SiteId = sc.SiteId        
    INNER JOIN [User] CreateUser ON q.CreatedByUserId = CreateUser.Id         
   INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation qf on qf.ShiftHandoverQuestionnaireId = q.Id        
   INNER JOIN FunctionalLocation f on qf.FunctionalLocationId = f.Id        
   INNER JOIN ShiftHandoverQuestionnaireRead r on r.ShiftHandoverQuestionnaireId = q.id                
   LEFT JOIN WorkAssignment a ON q.WorkAssignmentId = a.Id)
   )AS Y
   
   --Select * from #TempAllReadUserId
   
   Select distinct( t.CreatedByUserID),u.userName
    from #TempAllNotReadUserId t Join [User] u  on t.CreatedByUserID=u.Id
   where t.CreatedByUserID not in (Select #TempAllReadUser.UserId from #TempAllReadUserId)
   
   Drop Table #TempAllNotReadUserId
   Drop Table #TempAllReadUserId


 
   Go
   GRANT EXEC ON QueryDirectiveDTOsByParentFlocListAndMarkedAsNotRead   TO PUBLIC 



