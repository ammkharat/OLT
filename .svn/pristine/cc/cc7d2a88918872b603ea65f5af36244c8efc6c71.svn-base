 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryUsersMarkedDirectiveAsNotRead]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[QueryUsersMarkedDirectiveAsNotRead]
Go
Create  Procedure [dbo].[QueryUsersMarkedDirectiveAsNotRead]    
(    
 @DirectiveId bigint ,  
 @CsvFLOCIds varchar(max)    
)    
AS 


--Declare @id varchar(10) = (SELECT SUBSTRING(@CsvFLOCIds,0,CHARINDEX(',',@CsvFLOCIds,0)))
Declare @id varchar(10) = (Select top 1 value from STRING_SPLIT(@CsvFLOCIds, ','))	
			
Declare @Val varchar(10)			
--Set @Val = (Select SUBSTRING(FullHierarchy,1,3)from FunctionalLocation where ID=@id)

Set @Val = (Select FullHierarchy from FunctionalLocation where ID=@id)
Set @Val = (Select top 1 value from STRING_SPLIT(@Val, '-')	)
		
Set @CsvFLOCIds = (Select id from FunctionalLocation where  FullHierarchy = @Val)

   
 Select * into #TempUserRead  
 From  
 (  
     SELECT     
        UserId    
     FROM     
      [DirectiveRead]    
     WHERE    
       DirectiveId =@DirectiveId  
)As X  
  
Select * into #TempUserNotRead  
From  
(  
  (SELECT    
   l.UserID As CreatedByUserID    
 FROM    
  [Log] l    
  INNER JOIN LogFunctionalLocation lfl ON lfl.LogId = l.Id    
WHERE    
    l.Deleted = 0 AND   
    l.CreatedDateTime >= DATEADD(year,-1,GETDATE())  
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
 )   
  
    UNION ALL  
    (  
     SELECT    
       l.CreatedByUserID    
     FROM     
     [SummaryLog] l  
     INNER JOIN SummaryLogFunctionalLocation lfl ON lfl.SummaryLogId=l.Id  
     Where  l.CreatedDateTime >= DATEADD(year,-1,GETDATE()) AND l.Deleted=0  
     AND  
      (  
        EXISTS  
        (  
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
    )  
    UNION ALL  
    (  
       SELECT          
         q.CreatedByUserID     
        FROM          
       ShiftHandoverQuestionnaire q  
       INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation lfl ON lfl.ShiftHandoverQuestionnaireId=q.Id  
       Where  (q.CreatedDateTime >= DATEADD(year,-1,GETDATE()))   
       AND  
       (  
       EXISTS  
       (  
       select * From IDSplitter(@CsvFLOCIds) ids   
       WHERE lfl.FunctionalLocationId=ids.Id  
       )  
       OR EXISTS  
       (  
           select a.Id from FunctionalLocationAncestor a    
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
        WHERE lfl.FunctionalLocationId = a.Id    
       )  
       )  
    
  )   
  )AS Y  
    
 Select distinct( t.CreatedByUserID) as Id,u.userName  
    from #TempUserNotRead t Join [User] u  on t.CreatedByUserID=u.Id  
   where t.CreatedByUserID not in (Select #TempUserRead.UserId from #TempUserRead)  
     
   Drop Table #TempUserNotRead  
   Drop Table #TempUserRead    
   
   Go
 GRANT EXEC ON QueryUsersMarkedDirectiveAsNotRead TO PUBLIC
      