IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitUSPipelineDTOsForThisDateByFLOCsAndShiftStartTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitUSPipelineDTOsForThisDateByFLOCsAndShiftStartTime
	END
GO

CREATE Procedure [dbo].QueryWorkPermitUSPipelineDTOsForThisDateByFLOCsAndShiftStartTime
    (
        @CsvFlocIds VARCHAR(MAX),
        @CsvStatusIds varchar(MAX),
        @ShiftStartDateTime DATETIME,
        @ShiftEndDateTime DATETIME   
    )
AS

SELECT
    WorkPermitUSPipeline.[Id],
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
    WorkPermitUSPipeline.IsOperations,
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
    WorkPermitUSPipeline
    INNER JOIN FunctionalLocation ON WorkPermitUSPipeline.FunctionalLocationId = FunctionalLocation.[Id] 
    INNER JOIN [User] CreatedByUser ON WorkPermitUSPipeline.CreatedByUserId = CreatedByUser.Id 
    INNER JOIN IDSplitter( @CsvStatusIds ) ids ON ids.Id = WorkPermitUSPipeline.WorkPermitStatusId
    INNER JOIN [User] LastModifiedUser ON WorkPermitUSPipeline.LastModifiedUserId = LastModifiedUser.Id
    LEFT OUTER JOIN CraftOrTrade ON WorkPermitUSPipeline.CraftOrTradeId = CraftOrTrade.ID
    LEFT OUTER JOIN [User] ApprovedByUser ON WorkPermitUSPipeline.ApprovedByUserId = ApprovedByUser.Id
	  LEFT OUTER JOIN WorkAssignment wa ON WorkPermitUSPipeline.WorkAssignmentId = wa.Id	
WHERE
    WorkPermitUSPipeline.Deleted = 0
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
      (@ShiftStartDateTime BETWEEN WorkPermitUSPipeline.StartDateTime AND WorkPermitUSPipeline.EndDateTime) 
		  OR(WorkPermitUSPipeline.StartDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime)
    )
OPTION (OPTIMIZE FOR UNKNOWN)	      	

