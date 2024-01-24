IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOilsandsPriorityPageDTOsAwaitingApprovalByFunctionalLocationsAndDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormOilsandsPriorityPageDTOsAwaitingApprovalByFunctionalLocationsAndDateRange
    END
GO

CREATE Procedure [dbo].QueryFormOilsandsPriorityPageDTOsAwaitingApprovalByFunctionalLocationsAndDateRange
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange date,
        @EndOfDateRange date
    )
AS

WITH FormOilsandsTraining_Id_Cte (FormOilsandsTrainingId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormOilsandsTraining f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormOilsandsTrainingId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormOilsandsTrainingId = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormOilsandsTrainingId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormOilsandsTrainingId = f.Id
		UNION ALL   
		-- Floc of Formis child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormOilsandsTrainingId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormOilsandsTrainingId = f.Id
	  )
)
SELECT
    unioned_table.*
FROM
(

(
SELECT
    f.Id as Id,	
	0 as FormTypeId,

	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	
	f.TrainingDate as TrainingDate,
	f.FormStatusId,
	f.TotalHours,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,

    fl.FullHierarchy as FullHierarchy,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder,
	
	wa.Name as WorkAssignmentName,
	sh.Name as ShiftName
FROM
    FormOilsandsTraining f
    INNER JOIN FormOilsandsTraining_Id_Cte ON FormOilsandsTraining_Id_Cte.FormOilsandsTrainingId = f.Id
    INNER JOIN [FormOilsandsTrainingFunctionalLocation] ffl on ffl.FormOilsandsTrainingId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	INNER JOIN [Shift] sh on f.ShiftId = sh.Id
	LEFT OUTER JOIN [FormOilsandsTrainingApproval] a on a.FormOilsandsTrainingId = f.Id
	LEFT OUTER JOIN [WorkAssignment] wa on f.WorkAssignmentId = wa.Id
)

) 
unioned_table
WHERE
	TrainingDate <= @EndOfDateRange AND
    TrainingDate >= @StartOfDateRange AND
	ApprovedDateTime IS NULL
ORDER BY unioned_table.FormTypeId, unioned_table.Id, unioned_table.ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC on QueryFormOilsandsPriorityPageDTOsAwaitingApprovalByFunctionalLocationsAndDateRange TO PUBLIC
GO