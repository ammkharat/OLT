IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormEdmontonGN75BDTO')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormEdmontonGN75BDTO
	END
GO

CREATE Procedure [dbo].[QueryFormEdmontonGN75BDTO]
	(
		@CsvFlocIds VARCHAR(MAX),
		@CsvFormStatusIds VARCHAR(100),
		@siteId bigint
	)
AS

SELECT
  form.Id,
  form.FormStatusId,
  form.CreatedDateTime,
  form.CreatedByUserId,
  created.Firstname as [CreatedByFirstName],
  created.Lastname as [CreatedByLastName],
  created.Username as [CreatedByUserName],
  form.LastModifiedByUserId,
  lastModified.Firstname as [LastModifiedByFirstName],
  lastModified.Lastname as [LastModifiedByLastName],
  lastModified.Username as [LastModifiedByUserName],
  form.LastModifiedDateTime,
  f.FullHierarchy as FunctionalLocationName,
  form.Location,
  form.EquipmentType,
  form.LockBoxNumber,
  form.ClosedDateTime,
  form.Deleted, -- this is always 0 here but is needed for another stored proc
  form.TemplateId
FROM
  FormGN75B form
  INNER JOIN [dbo].[User] created ON form.CreatedByUserId = created.Id
  INNER JOIN [dbo].[User] lastModified ON form.LastModifiedByUserId = lastModified.Id
  INNER JOIN dbo.FunctionalLocation f ON f.Id = form.FunctionalLocationId
WHERE 
  form.Deleted = 0 and form.siteid = @siteId 
  AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = form.FormStatusId)
  AND
  (
    EXISTS (
		-- Floc of Form matches one of the passed in flocs
		select * From IDSplitter(@CsvFLOCIds) flocIds
		WHERE flocIds.Id = f.Id
    )
    OR EXISTS (
		-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		select * from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.Id
		WHERE a.AncestorId = f.Id
    )
    OR EXISTS (
		-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select * from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.ancestorid
		WHERE a.Id = f.Id
    )
  )
OPTION (OPTIMIZE FOR UNKNOWN)  
