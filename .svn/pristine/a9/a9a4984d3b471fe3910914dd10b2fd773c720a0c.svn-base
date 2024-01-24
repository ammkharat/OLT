IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormDTOsThatAreOP14ApprovedDraftExpiredByFunctionalLocations')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormDTOsThatAreOP14ApprovedDraftExpiredByFunctionalLocations
    END
GO

CREATE Procedure [dbo].QueryFormDTOsThatAreOP14ApprovedDraftExpiredByFunctionalLocations
    (
        @CsvFlocIds VARCHAR(MAX),
        @Now DATETIME
    )
AS

WITH FormOP14_Id_Cte (FormOP14Id)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormOP14 f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormOP14Id From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormOP14FunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormOP14Id = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormOP14Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormOP14FunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormOP14Id = f.Id
		UNION ALL   
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormOP14Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormOP14FunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormOP14Id = f.Id
	  )
)
SELECT
    f.Id as Id,	
	3 as FormTypeId,
	f.CriticalSystemDefeated,
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
	a.DisplayOrder as ApprovalDisplayOrder,
	f.siteid   --ayman sarnia
FROM
    FormOP14 f
    INNER JOIN FormOP14_Id_Cte ON FormOP14Id = f.Id
    INNER JOIN [FormOP14FunctionalLocation] ffl on ffl.FormOP14Id = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	LEFT OUTER JOIN [FormOP14Approval] a on a.FormOP14Id = f.Id and a.Enabled = 1 
WHERE 
    FormStatusId = 2 OR FormStatusId = 5 OR FormStatusId = 15 -- waiting for approval status added ... ayman
ORDER BY f.Id, ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC on QueryFormDTOsThatAreOP14ApprovedDraftExpiredByFunctionalLocations TO PUBLIC
GO