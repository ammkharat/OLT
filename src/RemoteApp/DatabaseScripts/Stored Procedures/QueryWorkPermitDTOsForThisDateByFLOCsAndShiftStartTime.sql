IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime
	END
GO

CREATE Procedure [dbo].QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime
    (
        @CsvFlocIds VARCHAR(MAX),
        @CsvStatusIds varchar(MAX),
        @ShiftStartDateTime DATETIME,
        @ShiftEndDateTime DATETIME   
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
    INNER JOIN [User] LastModifiedUser ON WorkPermit.LastModifiedUserId = LastModifiedUser.Id
    LEFT OUTER JOIN CraftOrTrade ON WorkPermit.CraftOrTradeId = CraftOrTrade.ID
    LEFT OUTER JOIN [User] ApprovedByUser ON WorkPermit.ApprovedByUserId = ApprovedByUser.Id
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
      (@ShiftStartDateTime BETWEEN WorkPermit.StartDateTime AND WorkPermit.EndDateTime) 
		  OR(WorkPermit.StartDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime)
    )
OPTION (OPTIMIZE FOR UNKNOWN)	      	
GO   

GRANT EXEC ON [dbo].[QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime] TO PUBLIC
GO