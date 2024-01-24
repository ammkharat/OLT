IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOilsandsPermitAssessmentByFunctionalLocationsForExcelDump')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormOilsandsPermitAssessmentByFunctionalLocationsForExcelDump
    END
GO

CREATE Procedure [dbo].QueryFormOilsandsPermitAssessmentByFunctionalLocationsForExcelDump
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
    paa.Id as Id,	
    s.name as [Site],
	pa.Id as FormNumber,
	pa.QuestionnaireVersion as VersionNumber,
	pa.FormStatusId as StatusId,	
	pa.LocationEquipmentNumber,
	pa.ValidFromDateTime as PermitStartDateTime,
	pa.ValidToDateTime as PermitExpireDateTime,
	createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,	
    pa.CreatedDateTime,    
    lastModifiedByUser.LastName as LastModifiedByLastName,
    lastModifiedByUser.FirstName as LastModifiedByFirstName,
    lastModifiedByUser.UserName as LastModifiedByUserName,
	pa.LastModifiedDateTime,    
	pa.IsIlpRecommended as IlpRecommended,
	pa.PermitNumber,
	pa.OilsandsWorkPermitType as PermitType,
	pa.IssuedToSuncor,
	pa.IssuedToContractor,
	pa.Contractor, 
	pa.Trade,
	pa.JobCoordinator,
	pa.JobDescription,
	pa.CrewSize,
	paa.SectionName as Section,
	paa.DisplayOrder as QuestionNumber,
	paa.QuestionText as Question,
	paa.Score,
	paa.ConfiguredWeight as [Weight],
	paa.Score * paa.ConfiguredWeight as OverallScore,
	paa.SectionConfiguredPercentageWeighting as SectionWeightPercentage,
	paa.SectionScoredPercentage as SectionScorePercentage,
	paa.Comments as QuestionFeedback,
	pa.TotalScoredPercentage as TotalScorePercentage,
	pa.OverallFeedback as Feedback,
	fl.FullHierarchy as FullHierarchy
	FROM PermitAssessmentAnswer paa
	INNER JOIN FormPermitAssessment pa on pa.id = paa.PermitAssessmentId
    INNER JOIN PermitAssessment_Id_Cte ON PermitAssessment_Id_Cte.PermitAssessmentId = pa.Id
       INNER JOIN [FormPermitAssessmentFunctionalLocation] ffl on ffl.FormPermitAssessmentId = pa.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId

    INNER JOIN [User] createdByUser on pa.CreatedByUserId = createdByUser.Id
    INNER JOIN [Site] s on pa.siteid = s.id
   	INNER JOIN [User] lastModifiedByUser on pa.LastModifiedByUserId = lastModifiedByUser.Id
WHERE 
	(pa.ValidFromDateTime <= @EndOfDateRange AND pa.ValidToDateTime >= @StartOfDateRange )
ORDER BY pa.Id


OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormOilsandsPermitAssessmentByFunctionalLocationsForExcelDump TO PUBLIC
GO