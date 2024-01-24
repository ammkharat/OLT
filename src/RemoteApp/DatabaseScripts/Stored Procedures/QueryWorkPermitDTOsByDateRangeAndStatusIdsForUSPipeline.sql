IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipeline')
BEGIN
    DROP  Procedure  QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipeline
END

GO

Create Procedure QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipeline 
 (  
  @CsvFlocIds VARCHAR(MAX),  
        @CsvStatusIds varchar(MAX),  
        @StartOfDateRange DATETIME,  
        @EndOfDateRange DATETIME = NULL,  
  @WorkAssignmentId bigint = NULL  
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
    WorkPermitUSPipeline.PermitConfinedSpaceEntry,
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
 INNER JOIN [User] LastModifiedUser ON WorkPermitUSPipeline.[LastModifiedUserId] = LastModifiedUser.[Id]  
 LEFT OUTER JOIN [CraftOrTrade] ON WorkPermitUSPipeline.[CraftOrTradeID] = [CraftOrTrade].[Id]  
    LEFT OUTER JOIN [User] ApprovedByUser ON WorkPermitUSPipeline.[ApprovedByUserId] = ApprovedByUser.[Id]  
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
  (@WorkAssignmentId is not null AND WorkPermitUSPipeline.WorkAssignmentId = @WorkAssignmentId)  
  OR   
  (@WorkAssignmentId is null)  
 )  
 AND  
 (  
        (WorkPermitUSPipeline.EndDateTime IS NULL AND @EndOfDateRange IS NULL AND WorkPermitUSPipeline.StartDateTime >= @StartOfDateRange)  
        OR  
        (WorkPermitUSPipeline.EndDateTime IS NULL AND @EndOfDateRange IS NOT NULL AND WorkPermitUSPipeline.StartDateTime <= @EndOfDateRange)  
        OR  
        -- Check that the WP StartTime is less than the EndOfDateRange and that the WP EndTime is greater than the DateRangeStart  
        (@EndOfDateRange IS NOT NULL AND WorkPermitUSPipeline.StartDateTime <= @EndOfDateRange AND WorkPermitUSPipeline.EndDateTime >= @StartOfDateRange)  
        OR  
        -- Check that the WP StartTime or EndTime is Greater than the StartOfDateRange  
        (@EndOfDateRange IS NULL AND (WorkPermitUSPipeline.StartDateTime >= @StartOfDateRange OR WorkPermitUSPipeline.EndDateTime >= @StartOfDateRange))  
    )  
OPTION (OPTIMIZE FOR UNKNOWN)   

GRANT EXEC ON QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipeline TO PUBLIC

GO       