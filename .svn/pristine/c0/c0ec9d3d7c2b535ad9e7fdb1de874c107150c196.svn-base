IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertDTOsByFLOCsAndStatuses')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertDTOsByFLOCsAndStatuses
	END
GO

CREATE Procedure [dbo].QueryTargetAlertDTOsByFLOCsAndStatuses
(
    @CsvFlocIds varchar(MAX),
    @CsvStatusIds varchar(MAX),
	@StartOfDateRange DateTime,
	@EndOfDateRange DateTime
)
AS

WITH TargetAlert_Id_Cte (TargetAlertId)
AS
(
select 
  TargetAlert.id
from 
    dbo.TargetAlert TargetAlert
    INNER JOIN dbo.FunctionalLocation f ON TargetAlert.FunctionalLocationId = f.Id
    INNER JOIN IDSplitter(@CsvStatusIds) StatusIds ON StatusIds.Id = TargetAlert.TargetAlertStatusID
WHERE 
    TargetAlert.CreatedDateTime <= @EndOfDateRange AND
	  TargetAlert.CreatedDateTime >= @StartOfDateRange AND
	(
    EXISTS
    (
      SELECT ids.Id
      FROM 
		IDSplitter(@CsvFlocIds) ids
      WHERE 
		ids.Id = f.Id
    )
    OR
    EXISTS
    (
  		SELECT ids.Id
	  	FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.AncestorId = ids.Id
		WHERE 
			a.Id = f.Id
	  )
  )
)

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
    INNER JOIN TargetAlert_Id_Cte On TargetAlert_Id_Cte.TargetAlertId = targetAlert.ID
    INNER JOIN FunctionalLocation floc ON floc.Id = targetAlert.FunctionalLocationID
	  INNER JOIN TargetDefinition td ON td.Id = targetAlert.TargetDefinitionId
	  INNER JOIN Tag t on t.Id = targetAlert.TagId
   LEFT OUTER JOIN WorkAssignment workAssignment
		ON td.WorkAssignmentId = WorkAssignment.[Id] and WorkAssignment.Deleted = 0
ORDER BY
    targetAlert.FunctionalLocationId
OPTION (OPTIMIZE FOR UNKNOWN)  		
GO 

GRANT EXEC ON QueryTargetAlertDTOsByFLOCsAndStatuses TO PUBLIC
GO