IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogByFlocDateRangeShiftAndWorkAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QuerySummaryLogByFlocDateRangeShiftAndWorkAssignment
    END
GO  
 
CREATE Procedure [dbo].QuerySummaryLogByFlocDateRangeShiftAndWorkAssignment    
 (    
  @StartOfDateRange DateTime,    
  @EndOfDateRange DateTime,           
  @CsvFLOCIds varchar(max),    
  @ShiftId bigint,    
  @WorkAssignmentId bigint = null,    
  @UserId bigint,  
  @IsFlexible bit = 0    
 )    
    
AS    
    
WITH SummaryLog_Id_Cte (SummaryLogId)    
AS    
(    
select distinct l.id    
  from     
    dbo.SummaryLog l    
  WHERE     
   l.Deleted = 0 AND    
   l.CreatedDateTime <= @EndOfDateRange AND    
   l.CreatedDateTime >= @StartOfDateRange AND  
   l.CreationuserShiftPatternId = case when  @IsFlexible = 0 then @ShiftId else l.CreationuserShiftPatternId end AND          
   --l.CreationuserShiftPatternId = @ShiftId AND    
   (    
    (@WorkAssignmentId is not null AND @WorkAssignmentId = l.WorkAssignmentId AND l.CreatedByUserId = @UserId) OR    
    (@WorkAssignmentId is null AND l.WorkAssignmentId is null AND l.CreatedByUserId = @UserId)    
   ) AND    
      (    
  EXISTS    
  (    
        -- Floc of Summary Log matches one of the passed in flocs    
        select lfl.SummaryLogId From IDSplitter(@CsvFLOCIds) ids    
        INNER JOIN SummaryLogFunctionalLocation lfl ON ids.Id = lfl.FunctionalLocationId    
        WHERE lfl.SummaryLogId = l.Id    
  )    
        OR EXISTS    
  (    
        -- Floc of Summary Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)    
        select lfl.SummaryLogId from FunctionalLocationAncestor a    
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
        INNER JOIN SummaryLogFunctionalLocation lfl ON a.Id = lfl.FunctionalLocationId    
        WHERE lfl.SummaryLogId = l.Id    
  )    
      )    
)    
select     
 l.*    
from SummaryLog l    
  INNER JOIN SummaryLog_Id_Cte ON SummaryLog_Id_Cte.SummaryLogId = l.Id    
OPTION (OPTIMIZE FOR UNKNOWN)      
  
GRANT EXEC ON QuerySummaryLogByFlocDateRangeShiftAndWorkAssignment TO PUBLIC  