IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormEdmontonGN75ADTO')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormEdmontonGN75ADTO
    END
GO

CREATE Procedure [dbo].QueryFormEdmontonGN75ADTO
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormEdmontonGN75A_Id_Cte (FormGN75AId)
AS
(
  SELECT DISTINCT f.Id
  FROM
    FormGN75A f
	INNER JOIN FunctionalLocation fl ON fl.Id = f.FunctionalLocationId	
  WHERE
    f.Deleted = 0 AND
	(
	    EXISTS (
			-- Floc of Form matches one of the passed in flocs
			select * From IDSplitter(@CsvFLOCIds) flocIds
			WHERE flocIds.Id = fl.Id
	    )
	    OR EXISTS (
			-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
			select * from FunctionalLocationAncestor a
			INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.Id
			WHERE a.AncestorId = fl.Id
	    )
	    OR EXISTS (
			-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
			select * from FunctionalLocationAncestor a
			INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.ancestorid
			WHERE a.Id = fl.Id
	    )
    )
)

SELECT
    f.Id as Id,	
	6 as FormTypeId,
	
	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.LastModifiedDateTime,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	
	f.FromDateTime,
	f.ToDateTime,
	f.FormStatusId,
	f.AssociatedFormGN75BId,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
    fl.FullHierarchy as FullHierarchy,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder
FROM
    FormGN75A f  
	INNER JOIN FormEdmontonGN75A_Id_Cte ON FormGN75AId = f.Id	
    INNER JOIN [FunctionalLocation] fl on fl.Id = f.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	LEFT OUTER JOIN [FormGN75AApproval] a on a.FormGN75AId = f.Id
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 0 AND f.FormStatusId = 15)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.FromDateTime <= @EndOfDateRange AND f.ToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id, a.DisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)	
GO
GRANT EXEC on QueryFormEdmontonGN75ADTO TO PUBLIC
GO