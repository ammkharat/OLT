IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN59DTOsByFunctionalLocationsAndOtherThings')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormGN59DTOsByFunctionalLocationsAndOtherThings
    END
GO

CREATE Procedure [dbo].QueryFormGN59DTOsByFunctionalLocationsAndOtherThings
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormGN59_Id_Cte (FormGN59Id)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormGN59 f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormGN59Id From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormGN59FunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormGN59Id = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormGN59Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormGN59FunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormGN59Id = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormGN59Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormGN59FunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormGN59Id = f.Id
	  )
)
SELECT
    f.Id as Id,	
	2 as FormTypeId,
	
	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.FormStatusId,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
    fl.FullHierarchy as FullHierarchy,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder
FROM
    FormGN59 f
    INNER JOIN FormGN59_Id_Cte ON FormGN59Id = f.Id
    INNER JOIN [FormGN59FunctionalLocation] ffl on ffl.FormGN59Id = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	LEFT OUTER JOIN [FormGN59Approval] a on a.FormGN59Id = f.Id
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 0 AND f.FormStatusId = 15)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id, ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormGN59DTOsByFunctionalLocationsAndOtherThings TO PUBLIC
GO