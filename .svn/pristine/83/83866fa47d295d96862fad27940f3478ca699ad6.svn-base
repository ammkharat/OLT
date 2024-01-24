IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOsByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOsByParentFlocListAndMarkedAsRead
    END
GO

CREATE Procedure [dbo].QueryLogDTOsByParentFlocListAndMarkedAsRead
    (
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFLOCIds varchar(max)
	)
AS
WITH Log_Id_CTE (LogId)
AS 
(
SELECT 
  DISTINCT l.Id 
FROM
  [Log] l
  INNER JOIN LogFunctionalLocation lfl ON lfl.LogId = l.Id
WHERE
    l.Deleted = 0 AND
	l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange
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
SELECT
    l.Id as LogId,
	l.LogType as LogType,
    floclist.FunctionalLocationList as FunctionalLocations,
    l.LogDateTime,
	l.CreatedDateTime,
	l.LastModifiedDateTime,
	l.PlainTextComments,
	
    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUserName,

    s.StartTime AS CreatedShiftStartDateTime,
    s.EndTime AS CreatedShiftEndDateTime,
    s.[id] AS CreatedShiftId,
    s.[Name] AS CreatedShiftName,

	sc.PreShiftPaddingInMinutes,
	sc.PostShiftPaddingInMinutes,
		
	readUser.LastName as ReadByLastName,
	readUser.FirstName as ReadByFirstName,
	readUser.UserName as ReadByUserName,
	r.[DateTime] as ReadByDateTime

FROM
    [Log] l	
    inner join Log_Id_CTE on Log_Id_CTE.LogId = l.Id
	inner join LogRead r on r.LogId = l.id
    INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id
	inner join [User] readUser on readUser.Id = r.Userid
	INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN [SiteConfiguration] sc on S.SiteId = sc.SiteId
OPTION (OPTIMIZE FOR UNKNOWN) 		

GO  

GRANT EXEC ON [QueryLogDTOsByParentFlocListAndMarkedAsRead] TO PUBLIC
GO