IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormDTOsThatAreMontrealCsdApprovedDraftExpiredByFunctionalLocations')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormDTOsThatAreMontrealCsdApprovedDraftExpiredByFunctionalLocations
    END
GO

CREATE Procedure [dbo].QueryFormDTOsThatAreMontrealCsdApprovedDraftExpiredByFunctionalLocations
    (
        @CsvFlocIds VARCHAR(MAX),
        @Now DATETIME
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
	
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.FormStatusId,
	f.HasBeenApproved,
	
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
    FormStatusId = 2 OR FormStatusId = 5 OR FormStatusId = 1 OR FormStatusId = 3
ORDER BY f.Id, ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC on QueryFormDTOsThatAreMontrealCsdApprovedDraftExpiredByFunctionalLocations TO PUBLIC
GO