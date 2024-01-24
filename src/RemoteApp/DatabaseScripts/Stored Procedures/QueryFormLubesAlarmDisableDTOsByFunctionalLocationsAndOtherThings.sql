IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormLubesAlarmDisableDTOsByFunctionalLocationsAndOtherThings')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormLubesAlarmDisableDTOsByFunctionalLocationsAndOtherThings
    END
GO

CREATE Procedure [dbo].QueryFormLubesAlarmDisableDTOsByFunctionalLocationsAndOtherThings
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormLubesAlarmDisable_Id_Cte (FormLubesAlarmDisableId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormLubesAlarmDisable f
	INNER JOIN FunctionalLocation fl ON fl.Id = f.FunctionalLocationId
  WHERE
    f.Deleted = 0 AND
	(EXISTS (
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
	))
)
SELECT
    f.Id as Id,	
	12 as FormTypeId,
	f.Alarm,
	f.Criticality,
	f.SapNotification,
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
	f.Location,
	
	a.Approver,
	a.ApprovedByUserId,
	a.DisplayOrder as ApprovalDisplayOrder
FROM
    FormLubesAlarmDisable f
    INNER JOIN FormLubesAlarmDisable_Id_Cte ON FormLubesAlarmDisableId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = f.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id
	LEFT OUTER JOIN [FormLubesAlarmDisableApproval] a on a.FormLubesAlarmDisableId = f.Id and a.Enabled = 1
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 1 AND f.FormStatusId = 1)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id, ApprovalDisplayOrder
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QueryFormLubesAlarmDisableDTOsByFunctionalLocationsAndOtherThings TO PUBLIC
GO