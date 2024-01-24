IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOByLoggedDateOrActualLoggedDateAndShift')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOByLoggedDateOrActualLoggedDateAndShift
    END
GO

CREATE Procedure [dbo].QueryLogDTOByLoggedDateOrActualLoggedDateAndShift
    (
        @CsvFlocIds VARCHAR(MAX),
        @CreatedShiftPatternId BIGINT,
        @StartOfDateRange DATETIME,
        @EndOfDateRange DATETIME,
		@CsvVisibilityGroupIds varchar(max)		
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
    l.deleted = 0 AND
    l.LogType = 1 AND
	l.CreationUserShiftPatternId = @CreatedShiftPatternId AND
	(
		(l.CreatedDateTime >= @StartOfDateRange AND l.CreatedDateTime <= @EndOfDateRange) 
		OR 
		(l.LogDateTime >= @StartOfDateRange AND l.LogDateTime <= @EndOfDateRange)
	) 
	AND
	(
      l.WorkAssignmentId is null or
	  @CsvVisibilityGroupIds is null or
	  EXISTS (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		where wavg.WorkAssignmentId = l.WorkAssignmentId and
		      wavg.VisibilityType = 2
	    )
    )
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
    l.RootLogId,
    l.ReplyToLogId,
    l.SourceId,
    floclist.FunctionalLocationList as FunctionalLocations,
    l.EHSFollowup,
    l.InspectionFollowUp,
    l.OperationsFollowUp,
    l.ProcessControlFollowUp,
    l.SupervisionFollowUp,
    l.OtherFollowUp,
    l.LogDateTime,	
	l.CreatedDateTime,
	l.LastModifiedDateTime,
	l.IsOperatingEngineerLog,
	l.CreatedByRoleId,
	l.RecommendForShiftSummary,
	l.UserId AS CreatedByUserId,
	l.PlainTextComments,

    createdByUser.LastName AS CreatedByLastName,
    createdByUser.FirstName AS CreatedByFirstName,
    createdByUser.UserName AS CreatedByUserName,

    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUserName,

    s.StartTime AS CreatedShiftStartDateTime,
    s.EndTime AS CreatedShiftEndDateTime,
    s.[id] AS CreatedShiftId,
    s.Name AS CreatedShiftName,

	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes,

    sc.*,
    HasChildren,
    ld.Id as LogDefinitionId,
    ld.Deleted as LogDefinitionDeleted,
	a.Name as WorkAssignmentName,
	vg.Name as VisibilityGroupName
FROM
	[Log] l 
  INNER JOIN Log_Id_CTE ON Log_Id_CTE.LogId = l.Id
  INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id
  INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
    INNER JOIN [User] createdByUser on l.UserId = createdByUser.Id
    INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
    LEFT OUTER JOIN [LogDefinition] ld ON l.LogDefinitionId = ld.Id
    LEFT OUTER JOIN [Schedule] sc ON ld.ScheduleId = sc.Id
	LEFT OUTER JOIN [WorkAssignment] a ON a.id = l.WorkAssignmentId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = l.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
OPTION (OPTIMIZE FOR UNKNOWN) 		
GO

GRANT EXEC ON QueryLogDTOByLoggedDateOrActualLoggedDateAndShift TO PUBLIC
GO