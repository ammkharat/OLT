IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOsByWorkPermitLubes')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOsByWorkPermitLubes
    END
GO

CREATE Procedure [dbo].QueryLogDTOsByWorkPermitLubes
    (
	    @WorkPermitLubesId bigint
    )
AS
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
	l.PlainTextComments,
    l.LogDateTime,	
	l.CreatedDateTime,
	l.LastModifiedDateTime,
	l.IsOperatingEngineerLog,
	l.CreatedByRoleId,
	l.RecommendForShiftSummary,
	l.UserId AS CreatedByUserId,

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
    INNER JOIN [User] createdByUser on l.UserId = createdByUser.Id
    INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
    INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
	INNER JOIN [LogWorkPermitLubesAssociation] assoc on assoc.LogId = l.Id
	INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id
    LEFT JOIN [LogDefinition] ld ON l.LogDefinitionId = ld.Id
    LEFT JOIN [Schedule] sc ON ld.ScheduleId = sc.Id
	LEFT OUTER JOIN [WorkAssignment] a ON a.id = l.WorkAssignmentId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = l.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
WHERE
    l.deleted = 0 AND
    l.LogType = 1 AND
	assoc.WorkPermitLubesId = @WorkPermitLubesId
GO

GRANT EXEC ON QueryLogDTOsByWorkPermitLubes TO PUBLIC
GO