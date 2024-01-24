IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDirectiveDTOByDateRangeAndFlocIdsForMergedSections')
    BEGIN
        DROP PROCEDURE [dbo].QueryDirectiveDTOByDateRangeAndFlocIdsForMergedSections
    END
GO

CREATE Procedure [dbo].[QueryDirectiveDTOByDateRangeAndFlocIdsForMergedSections]
      (
		@showDirectiveSection bigint,
		@showDirectiveLogSection bigint,
		@CsvFlocIds varchar(MAX),
		@StartOfDateRangeD DateTime,
		@EndOfDateRangeD DateTime,
		@StartOfDateRangeL DateTime,
		@EndOfDateRangeL DateTime,
		@CsvVisibilityGroupIds varchar(max),
		@ReadByUserId bigint = NULL,
		@LogType tinyint= 3  -- Daily Directive
    )
AS


IF OBJECT_ID('tempdb..#tblDirective') IS NOT NULL
BEGIN
DROP TABLE #tblDirective
END

IF OBJECT_ID('tempdb..#tblLog') IS NOT NULL
BEGIN
DROP TABLE #tblLog
END;


WITH Directive_Id_Cte (DirectiveId)
AS
(

select distinct d.id
  from 
    dbo.Directive d
  WHERE 
    d.ActiveFromDateTime <= @EndOfDateRangeD and
    d.ActiveToDateTime >= @StartOfDateRangeD and
    d.Deleted = 0 AND
	(
		EXISTS
		(
		-- Floc of Directive matches one of the passed in flocs
		select dfl.DirectiveId 
		from IDSplitter(@CsvFlocIds) ids
		INNER JOIN DirectiveFunctionalLocation dfl ON ids.Id = dfl.FunctionalLocationId
		WHERE dfl.DirectiveId = d.Id
		)
		OR EXISTS
		(
		  -- Floc of Directive is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select dfl.DirectiveId
		  from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.AncestorId
		  INNER JOIN DirectiveFunctionalLocation dfl ON a.Id = dfl.FunctionalLocationId
		  WHERE dfl.DirectiveId = d.Id
		)
		OR EXISTS
	    (
	      -- Floc of Directive is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		  select dfl.DirectiveId
		  from FunctionalLocationAncestor a
		  inner join IDSplitter(@CsvFlocIds) ids on ids.Id = a.Id
		  inner join DirectiveFunctionalLocation dfl on a.AncestorId = dfl.FunctionalLocationId
		  where dfl.DirectiveId = d.Id
	    )
	) AND
	(
	@CsvVisibilityGroupIds is null or
	EXISTS (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		inner join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id
		where wavg.WorkAssignmentId = dwa.WorkAssignmentId and
		      wavg.VisibilityType = 2
	    )
	or ((select count(*) from DirectiveWorkAssignment dwa where dwa.DirectiveId = d.Id) = 0)
    )
)

SELECT
	d.Id,	
	d.ActiveFromDateTime,
	d.ActiveToDateTime,
	d.PlainTextContent,
	fl.FullHierarchy as FunctionalLocation,
	wa.Name as WorkAssignment,
	d.CreatedByUserId,
	d.CreatedByRoleId,
	d.CreatedByWorkAssignmentName,
	d.LastModifiedByUserId,
	d.CreatedDateTime,
	createdByUser.Firstname as CreatedByFirstName,
	createdByUser.Lastname as CreatedByLastName,
	createdByUser.Username as CreatedByUsername,
	lastModifiedByUser.Firstname as LastModifiedByFirstName,
	lastModifiedByUser.Lastname as LastModifiedByLastName,
	lastModifiedByUser.Username as LastModifiedByUsername,
	dr.UserId as ReadByUserId

into #tblDirective

FROM
	Directive d
	INNER JOIN Directive_Id_Cte ON Directive_Id_Cte.DirectiveId = d.Id
	inner join DirectiveFunctionalLocation dfl on dfl.DirectiveId = d.Id
	inner join FunctionalLocation fl on fl.Id = dfl.FunctionalLocationId
	left outer join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id
	left outer join WorkAssignment wa on wa.Id = dwa.WorkAssignmentId
	inner join [User] createdByUser on createdByUser.Id = d.CreatedByUserId
	inner join [User] lastModifiedByUser on lastModifiedByUser.Id = d.LastModifiedByUserId
	left outer join DirectiveRead dr ON dr.DirectiveId = d.Id and dr.UserId = @ReadByUserId
where @showDirectiveSection = 1
order by d.ActiveToDateTime;



WITH Log_Id_CTE (LogId)
AS 
(
SELECT 
  DISTINCT l.Id 
FROM
  [Log] l
  INNER JOIN LogFunctionalLocation lfl on lfl.LogId = l.Id
WHERE
  l.deleted = 0 AND
  l.LogType = @LogType AND
  l.CreatedDateTime <= @EndOfDateRangeL AND
  l.CreatedDateTime >= @StartOfDateRangeL AND
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
  ) AND
  (
    EXISTS (
      -- Floc of Log matches one of the passed in flocs
      select * From IDSplitter(@CsvFLOCIds) ids
      WHERE lfl.FunctionalLocationId = ids.Id
    )
    OR EXISTS
    (
      -- Floc of Log is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
      select * from FunctionalLocationAncestor a
      INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
      WHERE a.AncestorId = lfl.FunctionalLocationId
    )
    OR EXISTS
    (
      -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
      select * from FunctionalLocationAncestor a
      INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
      WHERE a.Id = lfl.FunctionalLocationId
    )
  )
)
        
SELECT
    l.Id as LogId,
    l.RootLogId,
    l.ReplyToLogId,
    l.SourceId,
    lfll.FunctionalLocationList AS FunctionalLocations,
	a.[Name] AS WorkAssignmentName,
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
    s.[Name] AS CreatedShiftName,

	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes,

	sc.Id,sc.LastModifiedDateTime as LastModifiedDateTimeSC,sc.LastInvokedDateTime,sc.ScheduleTypeId,sc.StartDateTime,sc.EndDateTime,sc.FromTime,sc.ToTime,sc.DailyFrequency,sc.WeeklyFrequency,sc.Monday,sc.Tuesday,sc.Wednesday,sc.Thursday,sc.Friday,sc.Saturday,sc.Sunday,sc.DayOfMonth,sc.WeekOfMonth,sc.January,sc.February,sc.March,sc.April,sc.May,sc.June,sc.July,sc.August,sc.September,sc.October,sc.November,sc.December,sc.SiteId,sc.DayOfWeek,
    l.HasChildren,
    ld.Id as LogDefinitionId,
    ld.Deleted as LogDefinitionDeleted,

	logread.UserId as ReadByUserId,
	vg.Name as VisibilityGroupName

into #tbllog

FROM
    [Log] l
    INNER JOIN Log_Id_CTE ON Log_Id_CTE.LogId = l.Id
    INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
	INNER JOIN [User] createdByUser on l.UserId = createdByUser.Id
    INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	INNER JOIN LogFunctionalLocationList lfll on lfll.LogId = l.Id
    LEFT OUTER JOIN [LogDefinition] ld ON l.LogDefinitionId = ld.Id
    LEFT OUTER JOIN [Schedule] sc ON ld.ScheduleId = sc.Id
	LEFT OUTER JOIN [WorkAssignment] a ON a.id = l.WorkAssignmentId
	LEFT OUTER JOIN LogRead ON logread.LogId = l.Id and logread.UserId = @ReadByUserId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = l.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
where @showDirectiveLogSection = 1
order by l.LogDateTime desc

select 
'Directive' as [Type]
,ID
,ActiveFromDateTime
,ActiveToDateTime
,PlainTextContent
,FunctionalLocation
,WorkAssignment
,null
,d.CreatedByUserId
,d.CreatedByRoleId
,CreatedByWorkAssignmentName
,LastModifiedByUserId
,d.CreatedDateTime
,d.CreatedByFirstName
,d.CreatedByLastName
,d.CreatedByUsername
,d.LastModifiedByFirstName
,d.LastModifiedByLastName
,d.LastModifiedByUsername
,d.ReadByUserId
,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null
from #tblDirective d
union 
select 
'Standing Order' as [Type]
,LogId
,LastModifiedDateTime
,l.CreatedDateTime
,PlainTextComments
,FunctionalLocations
,WorkAssignmentName
,RecommendForShiftSummary
,l.CreatedByUserId
,l.CreatedByRoleId
,WorkAssignmentName
,RootLogId
,LogDateTime
,l.CreatedByLastName
,l.CreatedByFirstName
,l.CreatedByUserName
,l.LastModifiedByLastName
, l.LastModifiedByFirstName
,l.LastModifiedByUserName
,ReplyToLogId
,SourceId
,EHSFollowup
,InspectionFollowUp
,OperationsFollowUp
,ProcessControlFollowUp
,SupervisionFollowUp
,OtherFollowUp
,IsOperatingEngineerLog
,CreatedShiftStartDateTime
,CreatedShiftEndDateTime
,CreatedShiftId
,PreShiftPaddingInMinutes
,PostShiftPaddingInMinutes
,HasChildren,LogDefinitionId
,LogDefinitionDeleted
,l.ReadByUserId
,VisibilityGroupName 
from #tbllog l 



GO

GRANT EXEC ON QueryDirectiveDTOByDateRangeAndFlocIds TO PUBLIC
GO