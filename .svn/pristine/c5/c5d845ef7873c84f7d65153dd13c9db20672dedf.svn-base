IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormEdmontonGN6DTO')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormEdmontonGN6DTO
    END
GO

CREATE Procedure [dbo].QueryFormEdmontonGN6DTO
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormEdmontonGN6_Id_Cte (FormGN6Id)
AS
(
  SELECT DISTINCT f.Id
  FROM
    FormGN6 f
  WHERE
    f.Deleted = 0 AND
	  EXISTS
	  (
		-- Floc of Form matches one of the passed in flocs
		select ffl.FormGN6Id From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN FormGN6FunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
		WHERE ffl.FormGN6Id = f.Id
		UNION ALL
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select ffl.FormGN6Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
		INNER JOIN FormGN6FunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
		WHERE ffl.FormGN6Id = f.Id
		UNION ALL   
		-- Floc of Formis child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ffl.FormGN6Id from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN FormGN6FunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
		WHERE ffl.FormGN6Id = f.Id
	  )
)
SELECT
    f.Id as Id,	
	5 as FormTypeId,
	
	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.FormStatusId,
	
	f.JobDescription,
	f.LastModifiedDateTime,
	f.Section1NotApplicableToJob,
	f.Section2NotApplicableToJob,
	f.Section3NotApplicableToJob,
	f.Section4NotApplicableToJob,
	f.Section5NotApplicableToJob,
	f.Section6NotApplicableToJob,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
    fl.FullHierarchy as FullHierarchy,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder
FROM
    FormGN6 f
    INNER JOIN FormEdmontonGN6_Id_Cte ON FormGN6Id = f.Id
    INNER JOIN [FormGN6FunctionalLocation] ffl on ffl.FormGN6Id = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	LEFT OUTER JOIN [FormGN6Approval] a on a.FormGN6Id = f.Id
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 0 AND f.FormStatusId = 15)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id, a.DisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)	
GO
GRANT EXEC on QueryFormEdmontonGN6DTO TO PUBLIC
GO