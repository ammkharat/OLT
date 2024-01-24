IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormMontrealCsdDTOsByFunctionalLocationsAndOtherThings')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormMontrealCsdDTOsByFunctionalLocationsAndOtherThings
    END
GO

CREATE Procedure [dbo].QueryFormMontrealCsdDTOsByFunctionalLocationsAndOtherThings
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormMontrealCsd_Id_Cte (FormMontrealCsdId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormMontrealCsd f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormMontrealCsdId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormMontrealCsdFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormMontrealCsdId = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormMontrealCsdId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormMontrealCsdFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormMontrealCsdId = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormMontrealCsdId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormMontrealCsdFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormMontrealCsdId = f.Id
	  )
)
SELECT
    f.Id as Id,	
	11 as FormTypeId,
	f.CriticalSystemDefeated,
	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	f.HasBeenApproved,
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.FormStatusId,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
	lastModifiedByUser.LastName as LastModifiedByLastName,
    lastModifiedByUser.FirstName as LastModifiedByFirstName,
    lastModifiedByUser.UserName as LastModifiedByUserName,

    fl.FullHierarchy as FullHierarchy,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder
FROM
    FormMontrealCsd f
    INNER JOIN FormMontrealCsd_Id_Cte ON FormMontrealCsdId = f.Id
    INNER JOIN [FormMontrealCsdFunctionalLocation] ffl on ffl.FormMontrealCsdId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
    INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id
	LEFT OUTER JOIN [FormMontrealCsdApproval] a on a.FormMontrealCsdId = f.Id and a.Enabled = 1
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 1 AND f.FormStatusId = 1)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id, ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormMontrealCsdDTOsByFunctionalLocationsAndOtherThings TO PUBLIC
GO