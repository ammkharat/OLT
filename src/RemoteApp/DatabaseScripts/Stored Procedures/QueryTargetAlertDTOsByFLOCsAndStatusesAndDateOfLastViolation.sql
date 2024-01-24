IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertDTOsByFLOCsAndStatusesAndDateOfLastViolation')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertDTOsByFLOCsAndStatusesAndDateOfLastViolation
	END
GO

CREATE Procedure [dbo].QueryTargetAlertDTOsByFLOCsAndStatusesAndDateOfLastViolation
(
    @CsvFlocIds varchar(MAX),
    @CsvStatusIds varchar(MAX),
	@StartOfDateRange DateTime,
	@EndOfDateRange DateTime
)
AS

SELECT
    targetAlert.Id,
    targetAlert.LastModifiedUserId,
    targetAlert.TargetName,
    floc.FullHierarchy AS FunctionalLocationName,
    targetAlert.TargetCategoryId,
    targetAlert.Description,
    targetAlert.TargetValueTypeId,
    targetAlert.TargetAlertValue,
    targetAlert.CreatedDateTime,	
	  targetAlert.AcknowledgedDateTime,
    targetAlert.TargetAlertStatusId,
    targetAlert.PriorityId,
    targetAlert.RequiresResponse,
	  td.[Name] as TargetDefinitionName,
	  td.IsActive as DefinitionIsActive,
	  td.Deleted as DefinitionDeleted,
	  t.[Name] as TagName,
	
	targetAlert.TypeOfViolationStatusId,
	targetAlert.LastViolatedDateTime,
	targetAlert.MaxAtEvaluation,
	targetAlert.MinAtEvaluation,
	targetAlert.NTEMaxAtEvaluation,
	targetAlert.NTEMinAtEvaluation,
	targetAlert.ActualValueAtEvaluation,
		
    -- To Calculate Losses
    targetAlert.NeverToExceedMax,
    targetAlert.MaxValue,
    targetAlert.MinValue,
    targetAlert.NeverToExceedMin,
    targetAlert.GapUnitValue,
    targetAlert.ActualValue,
	
	workAssignment.Name AS WorkAssignmentName
FROM
    TargetAlert targetAlert
    INNER JOIN FunctionalLocation floc ON floc.Id = targetAlert.FunctionalLocationID
	  INNER JOIN TargetDefinition td ON td.Id = targetAlert.TargetDefinitionId
	  INNER JOIN Tag t on t.Id = targetAlert.TagId
   LEFT OUTER JOIN WorkAssignment workAssignment
		ON td.WorkAssignmentId = WorkAssignment.[Id] and WorkAssignment.Deleted = 0
  WHERE 
    TargetAlert.LastViolatedDateTime <= @EndOfDateRange AND TargetAlert.LastViolatedDateTime >= @StartOfDateRange 
  AND EXISTS
  (
    SELECT * FROM IDSplitter(@CsvStatusIds) StatusIds WHERE StatusIds.Id = TargetAlert.TargetAlertStatusID
  )
  AND
	(
		EXISTS
		(
		-- Floc of target alert matches one of the passed in flocs
		SELECT ids.Id
		FROM 
			IDSplitter(@CsvFlocIds) ids
		WHERE 
			ids.Id = floc.Id
		)
		OR
		EXISTS
		(
		-- Floc of  target alert is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		SELECT ids.Id
		FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.AncestorId = ids.Id
		WHERE 
			a.Id = floc.Id
		  )
	)
ORDER BY
    targetAlert.FunctionalLocationId
OPTION (OPTIMIZE FOR UNKNOWN)  	
GO 

GRANT EXEC ON QueryTargetAlertDTOsByFLOCsAndStatusesAndDateOfLastViolation TO PUBLIC
GO