IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormDocumentSuggestionThatAreNonDraftByFunctionalLocations')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormDocumentSuggestionThatAreNonDraftByFunctionalLocations
    END
GO

CREATE Procedure [dbo].QueryFormDocumentSuggestionThatAreNonDraftByFunctionalLocations
(
	@CreatedByUserId bigint,
	@CsvFlocIds VARCHAR(MAX),
	@Now DATETIME
)
AS

WITH DocumentSuggestion_Id_Cte (DocumentSuggestionId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormDocumentSuggestion f
  WHERE
    f.Deleted = 0 AND f.Id
	  IN
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormDocumentSuggestionId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormDocumentSuggestionFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormDocumentSuggestionId = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormDocumentSuggestionId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormDocumentSuggestionFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormDocumentSuggestionId = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormDocumentSuggestionId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormDocumentSuggestionFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormDocumentSuggestionId = f.Id
		UNION ALL
		-- All forms created by the user specified
		select ff.Id from FormDocumentSuggestion ff
		WHERE ff.CreatedByUserId = @CreatedByUserId	  
		)
)
SELECT
	f.Id as Id,	
	14 as FormTypeId,
	
	f.CreatedByUserId,
	f.CreatedDateTime,	

	f.LastModifiedByUserId,
	f.LastModifiedDateTime,
	
	f.ApprovedDateTime,

	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.ScheduledCompletionDateTime,
	f.FormStatusId,

	f.NumberOfExtensions,
	f.DocumentOwner,
	f.DocumentNumber,
	f.DocumentTitle,
	
	f.Description,

	f.InitialReviewApprovedDateTime,
	f.OwnerReviewApprovedDateTime,
	f.DocumentIssuedApprovedDateTime,
	f.DocumentArchivedApprovedDateTime,
	f.NotApprovedDateTime,
	f.NotApprovedReason,
	
	createdByUser.LastName as CreatedByLastName,
	createdByUser.FirstName as CreatedByFirstName,
	createdByUser.UserName as CreatedByUserName,	

	lastModifiedByUser.LastName as LastModifiedByLastName,
	lastModifiedByUser.FirstName as LastModifiedByFirstName,
	lastModifiedByUser.UserName as LastModifiedByUserName,

	fl.FullHierarchy as FullHierarchy,
  
	f.MaxEndDateTime
	
FROM
  FormDocumentSuggestion f
  INNER JOIN DocumentSuggestion_Id_Cte ON DocumentSuggestionId = f.Id
  INNER JOIN [FormDocumentSuggestionFunctionalLocation] ffl on ffl.FormDocumentSuggestionId = f.Id
  INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
  INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
  INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id
WHERE 
	(f.MaxEndDateTime >= @Now ) AND
	(f.FormStatusId = 6 OR f.FormStatusId = 7 OR f.FormStatusId = 8 OR 
	f.FormStatusId = 9 OR f.FormStatusId = 10 OR f.FormStatusId = 11)
ORDER BY f.Id
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormDocumentSuggestionThatAreNonDraftByFunctionalLocations TO PUBLIC
GO