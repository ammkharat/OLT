IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOilsandsTrainingDTOsByFunctionalLocationsAndDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormOilsandsTrainingDTOsByFunctionalLocationsAndDateRange
    END
GO

CREATE Procedure [dbo].QueryFormOilsandsTrainingDTOsByFunctionalLocationsAndDateRange
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
    f.Id as Id,	
	
	f.CreatedDateTime,
	f.LastModifiedDateTime,
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	
	f.TrainingDate,
	f.TotalHours,
	f.FormStatusId,
	f.CreatedByRoleId,
	
	sh.Name as ShiftName,
	
	wa.Name as WorkAssignmentName,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
    fl.FullHierarchy as FullHierarchy
FROM
    FormOilsandsTraining f
    INNER JOIN FormOilsandsTraining_Id_Cte ON FormOilsandsTraining_Id_Cte.FormOilsandsTrainingId = f.Id
    INNER JOIN [FormOilsandsTrainingFunctionalLocation] ffl on ffl.FormOilsandsTrainingId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	INNER JOIN [Shift] sh on f.ShiftId = sh.Id
	LEFT OUTER JOIN [FormOilsandsTrainingApproval] a on a.FormOilsandsTrainingId = f.Id
	LEFT OUTER JOIN [WorkAssignment] wa on wa.Id = f.WorkAssignmentId
WHERE 
	TrainingDate <= @EndOfDateRange AND
    TrainingDate >= @StartOfDateRange
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC on QueryFormOilsandsTrainingDTOsByFunctionalLocationsAndDateRange TO PUBLIC
GO