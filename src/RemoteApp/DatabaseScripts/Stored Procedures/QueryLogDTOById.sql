IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOById')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOById
    END
GO

CREATE Procedure dbo.QueryLogDTOById
(
    @CsvLogIds varchar(max)
)
AS
SELECT
    l.Id AS LogId,
    l.RootLogId,
    l.ReplyToLogId,
    l.SourceId,
    floclist.FunctionalLocationList as FunctionalLocations,
    l.EHSFollowup,
    l.InspectionFollowUp,
    l.OperationsFollowUp,
    l.ProcessControlFollowUp,
    l.SupervISionFollowUp,
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
    l.HasChildren,
    ld.Id as LogDefinitionId,
	ld.Deleted as LogDefinitionDeleted,
	a.Name as WorkAssignmentName,
	vg.Name as VisibilityGroupName
FROM
    [Log] l
    INNER JOIN [User] createdByUser on l.UserId = createdByUser.Id
    INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN SiteConfiguration siteconfig ON s.SiteId = siteconfig.SiteId
	INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id
    LEFT JOIN [LogDefinition] ld ON l.LogDefinitionId = ld.Id 
    LEFT JOIN [Schedule] sc ON ld.ScheduleId = sc.Id
	LEFT OUTER JOIN [WorkAssignment] a ON a.id = l.WorkAssignmentId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = l.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
WHERE
    l.deleted = 0 AND
    (
	 EXISTS
        (SELECT Id FROM IDSplitter(@CsvLogIds) ids
         WHERE ids.Id = l.Id)
	)
OPTION (OPTIMIZE FOR UNKNOWN) 			
GO

GRANT EXEC ON QueryLogDTOById TO PUBLIC
GO