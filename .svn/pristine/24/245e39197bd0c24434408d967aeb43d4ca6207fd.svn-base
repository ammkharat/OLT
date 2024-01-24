IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitDTOsByDateRangeAndStatusIds')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitDTOsByDateRangeAndStatusIds
	END
GO

CREATE Procedure [dbo].QueryWorkPermitDTOsByDateRangeAndStatusIds
	(
		@CsvFlocIds VARCHAR(MAX),
        @CsvStatusIds varchar(MAX),
        @StartOfDateRange DATETIME,
        @EndOfDateRange DATETIME = NULL,
		@WorkAssignmentId bigint = NULL
    )
AS

SELECT
    WorkPermit.[Id],
    WorkPermitStatusId,
    WorkOrderNumber,
    FunctionalLocation.FullHierarchy,
    PermitNumber,
    StartDateTime,
    EndDateTime,
    RevalidationDateTime,
    ExtensionDateTime,
    ExtensionRevalidationDateTime,
    JobStepDescription,
    WorkOrderDescription,
    WorkPermitTypeId,
    SourceId,
    WorkPermit.IsOperations,
    WorkPermit.PermitConfinedSpaceEntry,
    ISNULL(CraftOrTrade.Name, CraftOrTradeOther) AS CraftOrTradeName,
    LastModifiedUser.Id As LastModifiedUserId,
    -- Last modified
    LastModifiedUser.LastName AS LastModifiedLastName,
    LastModifiedUser.FirstName AS LastModifiedFirstName,
    LastModifiedUser.UserName AS LastModifiedUserName,
    -- Created by
    CreatedByUser.LastName AS CreatedByLastName,
    CreatedByUser.FirstName AS CreatedByFirstName,
    CreatedByUser.UserName AS CreatedByUserName,
    -- Approved by
    ApprovedByUser.LastName AS ApprovedByLastName,
    ApprovedByUser.FirstName AS ApprovedByFirstName,
    ApprovedByUser.UserName AS ApprovedByUserName,
	wa.Name as WorkAssignmentName
FROM
    WorkPermit 
	INNER JOIN FunctionalLocation ON WorkPermit.FunctionalLocationId = FunctionalLocation.[Id]     
	INNER JOIN [User] CreatedByUser ON WorkPermit.CreatedByUserId = CreatedByUser.Id 	
	INNER JOIN IDSplitter( @CsvStatusIds ) ids ON ids.Id = workPermit.WorkPermitStatusId
	INNER JOIN [User] LastModifiedUser ON WorkPermit.[LastModifiedUserId] = LastModifiedUser.[Id]
	LEFT OUTER JOIN [CraftOrTrade] ON WorkPermit.[CraftOrTradeID] = [CraftOrTrade].[Id]
    LEFT OUTER JOIN [User] ApprovedByUser ON WorkPermit.[ApprovedByUserId] = ApprovedByUser.[Id]
	LEFT OUTER JOIN WorkAssignment wa ON WorkPermit.WorkAssignmentId = wa.Id	
WHERE
    WorkPermit.Deleted = 0
	AND
	(
		EXISTS
		(
			-- Floc of permit matches one of the passed in flocs
			select ids.Id
			from IDSplitter(@CsvFlocIds) ids
			where ids.Id = FunctionalLocation.Id
		)
		OR EXISTS
		(
			-- Floc of permit is child of one of the passed in flocs (look down the floc tree from my selected flocs)
			select ids.Id
			from FunctionalLocationAncestor a
			inner join IDSplitter(@CsvFlocIds) ids on ids.Id = a.AncestorId
			where a.Id = FunctionalLocation.Id
		)
	)
	AND
	(
		(@WorkAssignmentId is not null AND WorkPermit.WorkAssignmentId = @WorkAssignmentId)
		OR 
		(@WorkAssignmentId is null)
	)
	AND
	(
        (workPermit.EndDateTime IS NULL AND @EndOfDateRange IS NULL AND workPermit.StartDateTime >= @StartOfDateRange)
        OR
        (workPermit.EndDateTime IS NULL AND @EndOfDateRange IS NOT NULL AND workPermit.StartDateTime <= @EndOfDateRange)
        OR
        -- Check that the WP StartTime is less than the EndOfDateRange and that the WP EndTime is greater than the DateRangeStart
        (@EndOfDateRange IS NOT NULL AND workPermit.StartDateTime <= @EndOfDateRange AND workPermit.EndDateTime >= @StartOfDateRange)
        OR
        -- Check that the WP StartTime or EndTime is Greater than the StartOfDateRange
        (@EndOfDateRange IS NULL AND (workPermit.StartDateTime >= @StartOfDateRange OR workPermit.EndDateTime >= @StartOfDateRange))
    )
OPTION (OPTIMIZE FOR UNKNOWN)	      	
GO

GRANT EXEC ON [dbo].[QueryWorkPermitDTOsByDateRangeAndStatusIds] TO PUBLIC
GO
