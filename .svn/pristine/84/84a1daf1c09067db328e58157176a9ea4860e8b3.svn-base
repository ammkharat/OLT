IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogDTOsByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP  Procedure  QuerySummaryLogDTOsByParentFlocListAndMarkedAsRead
    END
GO

CREATE Procedure [dbo].QuerySummaryLogDTOsByParentFlocListAndMarkedAsRead
    (        
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,      
		@CsvFLOCIds varchar(max)
    )
AS
WITH SummaryLog_Id_Cte (SummaryLogId)
AS
(
select distinct l.id
  from 
    dbo.SummaryLog l
    INNER JOIN SummaryLogFunctionalLocation lfl on lfl.SummaryLogId = l.Id
  WHERE 
    l.Deleted = 0 AND       
    l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange AND    
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
		    INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid
		    WHERE a.Id = lfl.FunctionalLocationId
	  	)
    )
)
SELECT
    l.Id as SummaryLogId,        
    l.LogDateTime,
	l.CreatedDateTime,
	l.PlainTextComments,
	l.RootLogId,
    l.ReplyToLogId,
    l.HasChildren,
	l.DataSourceId,
	
    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUserName,

    s.StartTime AS CreatedShiftStartDateTime,
    s.EndTime AS CreatedShiftEndDateTime,
    s.[id] AS CreatedShiftId,
    s.[Name] AS CreatedShiftName,

   	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes,
              
	floclist.FunctionalLocationList as FunctionalLocations,
	readUser.LastName as ReadByLastName,
	readUser.FirstName as ReadByFirstName,
	readUser.UserName as ReadByUserName,
	r.[DateTime] as ReadByDateTime

FROM	
  [SummaryLog] l       
  INNER JOIN SummaryLog_Id_Cte ON SummaryLog_Id_Cte.SummaryLogId = l.Id
  INNER JOIN dbo.SummaryLogFunctionalLocationList floclist ON floclist.SummaryLogId = l.Id
	inner join SummaryLogRead r on r.SummaryLogId = l.id
	inner join [User] readUser on readUser.Id = r.Userid
	inner join [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	inner join [Shift] s on l.CreationUserShiftPatternId = s.Id
 	INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
OPTION (OPTIMIZE FOR UNKNOWN) 		
GO  

GRANT EXEC ON QuerySummaryLogDTOsByParentFlocListAndMarkedAsRead TO PUBLIC
GO