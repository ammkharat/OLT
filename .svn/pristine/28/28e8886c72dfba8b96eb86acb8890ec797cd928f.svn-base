IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionDTOsByFLOCIDsAndLogType')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDefinitionDTOsByFLOCIDsAndLogType
    END
GO

CREATE Procedure [dbo].QueryLogDefinitionDTOsByFLOCIDsAndLogType
    (
        @CsvIds VARCHAR(MAX),
        @LogType tinyint,
		@CsvVisibilityGroupIds varchar(max)
    )
AS
SELECT
    ld.[Id] LogId,
    ld.ScheduleId ,
    ld.CreatedBy,
    ld.CreatedDateTime,
	ld.PlainTextComments,
    FunctionalLocation.FullHierarchy FunctionalLocationName,
	ld.LastModifiedUserId,
    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUserName,
    ld.LogType,
    s.*,
	ld.IsOperatingEngineerLog,
	ld.CreatedByRoleId,
	ld.Active,
	vg.Name as VisibilityGroupName
FROM
    LogDefinition ld
    INNER JOIN Schedule s ON ld.ScheduleId = s.Id
	INNER JOIN LogDefinitionFunctionalLocation ldfl ON ldfl.LogDefinitionId = ld.Id
    INNER JOIN FunctionalLocation ON FunctionalLocation.[Id] = ldfl.FunctionalLocationId
    INNER JOIN [User] LastModifiedUser ON ld.LastModifiedUserId = LastModifiedUser.Id
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = ld.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
WHERE
    ld.Deleted = 0 AND
    ld.LogType = @LogType AND
	(
      ld.WorkAssignmentId is null or
	  @CsvVisibilityGroupIds is null or
	  EXISTS (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		where wavg.WorkAssignmentId = ld.WorkAssignmentId and
		      wavg.VisibilityType = 2
	    )
    )
    AND EXISTS
      (
        -- Floc of Log matches one of the passed in flocs
        select lfl.LogDefinitionId From IDSplitter(@CsvIds) ids
        INNER JOIN LogDefinitionFunctionalLocation lfl ON ids.Id = lfl.FunctionalLocationId
        WHERE lfl.LogDefinitionId = ld.Id
        UNION ALL
        -- Floc of Log is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
        select lfl.LogDefinitionId from FunctionalLocationAncestor a
        INNER JOIN IDSplitter(@CsvIds) ids ON ids.Id = a.Id
        INNER JOIN LogDefinitionFunctionalLocation lfl ON a.AncestorId = lfl.FunctionalLocationId
        WHERE lfl.LogDefinitionId = ld.Id
        UNION ALL   
        -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
        select lfl.LogDefinitionId from FunctionalLocationAncestor a
        INNER JOIN IDSplitter(@CsvIds) ids ON ids.Id = a.ancestorid
        INNER JOIN LogDefinitionFunctionalLocation lfl ON a.Id = lfl.FunctionalLocationId
        WHERE lfl.LogDefinitionId = ld.Id
      )
GO

GRANT EXEC ON QueryLogDefinitionDTOsByFLOCIDsAndLogType TO PUBLIC
GO