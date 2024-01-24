IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormProcedureDeviationByFunctionalLocations')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormProcedureDeviationByFunctionalLocations
    END
GO

CREATE Procedure [dbo].QueryFormProcedureDeviationByFunctionalLocations
    (
			@CreatedByUserId bigint,
			@CsvFlocIds VARCHAR(MAX),
			@StartOfDateRange DateTime,
			@EndOfDateRange DateTime
    )
AS

WITH ProcedureDeviation_Id_Cte (ProcedureDeviationId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormProcedureDeviation f
  WHERE
    f.Deleted = 0 AND f.Id 
	  IN
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormProcedureDeviationId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormProcedureDeviationFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormProcedureDeviationId = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormProcedureDeviationId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormProcedureDeviationFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormProcedureDeviationId = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormProcedureDeviationId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormProcedureDeviationFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormProcedureDeviationId = f.Id
		UNION ALL
		-- All forms created by the user specified
		select ff.Id from FormProcedureDeviation ff
		WHERE ff.CreatedByUserId = @CreatedByUserId
	  )
)
SELECT
	f.Id as Id,	
	15 as FormTypeId,
	
	f.CreatedByUserId,
	f.CreatedDateTime,	

	f.LastModifiedByUserId,
	f.LastModifiedDateTime,
	f.ApprovedDateTime,

	f.ValidFromDateTime,
	f.ValidToDateTime,
	
	f.DeviationType,
	f.FormStatusId,

	f.PermanentRevisionRequired,
	f.RevertedBackToOriginal,
	f.NumberOfExtensions,
	
	f.OperatingProcedureNumber,
	f.OperatingProcedureTitle,
	f.OperatingProcedureLevel,
	
	f.Description,
	f.CauseDeterminationCategory,
	
	f.CancelledBy,
	f.CancelledDateTime,
	f.CancelledReason,
	
	createdByUser.LastName as CreatedByLastName,
	createdByUser.FirstName as CreatedByFirstName,
	createdByUser.UserName as CreatedByUserName,	

	lastModifiedByUser.LastName as LastModifiedByLastName,
	lastModifiedByUser.FirstName as LastModifiedByFirstName,
	lastModifiedByUser.UserName as LastModifiedByUserName,

	fl.FullHierarchy as FullHierarchy
	
FROM
  FormProcedureDeviation f
  INNER JOIN ProcedureDeviation_Id_Cte ON ProcedureDeviationId = f.Id
  INNER JOIN [FormProcedureDeviationFunctionalLocation] ffl on ffl.FormProcedureDeviationId = f.Id
  INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
  INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
  INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id
WHERE 
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange )
ORDER BY f.Id
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormProcedureDeviationByFunctionalLocations TO PUBLIC
GO