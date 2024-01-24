IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOilsandsPermitAssessmentByFunctionalLocations')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormOilsandsPermitAssessmentByFunctionalLocations
    END
GO

CREATE Procedure [dbo].QueryFormOilsandsPermitAssessmentByFunctionalLocations
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS

WITH PermitAssessment_Id_Cte (PermitAssessmentId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormPermitAssessment f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormPermitAssessmentId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormPermitAssessmentFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormPermitAssessmentId = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormPermitAssessmentId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormPermitAssessmentFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormPermitAssessmentId = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormPermitAssessmentId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormPermitAssessmentFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormPermitAssessmentId = f.Id
	  )
)
SELECT
    f.Id as Id,	
	3 as FormTypeId,
	f.CreatedDateTime,	
	f.CreationUserShiftPatternId,
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	f.OverallFeedback,
	f.PermitNumber,
	f.TotalScoredPercentage,
	f.IsIlpRecommended,
	f.JobDescription,
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.FormStatusId,
	f.LastModifiedDateTime,
	f.OilsandsWorkPermitType,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,	
    
    lastModifiedByUser.LastName as LastModifiedByLastName,
    lastModifiedByUser.FirstName as LastModifiedByFirstName,
    lastModifiedByUser.UserName as LastModifiedByUserName,
    
    fl.FullHierarchy as FullHierarchy
	
FROM
    FormPermitAssessment f
    INNER JOIN PermitAssessment_Id_Cte ON PermitAssessmentId = f.Id
    INNER JOIN [FormPermitAssessmentFunctionalLocation] ffl on ffl.FormPermitAssessmentId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
   INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id
WHERE 
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange )
ORDER BY f.Id
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormOilsandsPermitAssessmentByFunctionalLocations TO PUBLIC
GO