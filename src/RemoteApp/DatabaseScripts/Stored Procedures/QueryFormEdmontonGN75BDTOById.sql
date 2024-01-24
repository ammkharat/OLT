IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormEdmontonGN75BDTOById')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormEdmontonGN75BDTOById
	END
GO

CREATE Procedure [dbo].[QueryFormEdmontonGN75BDTOById]
	(
		@Id bigint
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
  form.TemplateID,
  form.Deleted
FROM
  FormGN75B form
  INNER JOIN [dbo].[User] created ON form.CreatedByUserId = created.Id
  INNER JOIN [dbo].[User] lastModified ON form.LastModifiedByUserId = lastModified.Id
  INNER JOIN dbo.FunctionalLocation f ON f.Id = form.FunctionalLocationId
WHERE 
  form.Id = @Id
  OPTION (OPTIMIZE FOR UNKNOWN)  
GO

GRANT EXEC ON [QueryFormEdmontonGN75BDTOById] TO PUBLIC
GO