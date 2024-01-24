UPDATE SiteConfiguration
	SET SummaryLogFunctionalLocationDisplayLevel = 2
WHERE
	SiteId = 6
GO

-- add new business categories to SWS that exist is Oilsands, and not SWS.
INSERT INTO BusinessCategory (
   [Name]
  ,ShortName
  ,IsSAPWorkOrderDefault
  ,IsSAPNotificationDefault
  ,LastModifiedUserId
  ,LastModifiedDateTime
  ,CreatedDateTime
  ,Deleted
  ,SiteId
) SELECT 
   bc_old.[Name]
  ,bc_old.ShortName
  ,bc_old.IsSAPWorkOrderDefault
  ,bc_old.IsSAPNotificationDefault
  ,bc_old.LastModifiedUserId
  ,bc_old.LastModifiedDateTime
  ,bc_old.CreatedDateTime
  ,bc_old.Deleted
  ,6
  FROM BusinessCategory bc_old
  left outer join businesscategory bc_new on bc_old.[Name] = bc_new.[Name] and bc_new.siteid = 6
  where bc_old.siteid = 3 and bc_new.Id is null 
GO

ALTER TABLE [dbo].[BusinessCategory] ADD [OldId] bigint NULL
GO

UPDATE bc_new
SET
bc_new.OldId = bc_old.Id
FROM
BusinessCategory bc_new
inner join businesscategory bc_old on bc_new.[name] = bc_old.[name] and bc_old.siteid = 3 and bc_new.siteid = 6
GO

-- update business category of EU1 Action Items
UPDATE ai
SET ai.BusinessCategoryId = bc.Id
FROM
dbo.ActionItem ai
INNER JOIN dbo.BusinessCategory bc ON bc.OldId = ai.BusinessCategoryId
INNER JOIN ActionItemFunctionalLocation aifl on aifl.ActionItemId = ai.Id
INNER JOIN FunctionalLocation f on f.Id = aifl.FunctionalLocationId
where
f.FullHierarchy like 'EU1%'
GO

-- update business category of Action Item Definitions
UPDATE aid
SET aid.BusinessCategoryId = bc.Id
FROM
dbo.ActionItemDefinition aid
INNER JOIN dbo.BusinessCategory bc ON bc.OldId = aid.BusinessCategoryId
INNER JOIN ActionItemDefinitionFunctionalLocation aidfl on aidfl.ActionItemDefinitionId = aid.Id
INNER JOIN FunctionalLocation f on f.Id = aidfl.FunctionalLocationId
where
f.FullHierarchy like 'EU1%'
GO

-- update schedule of Action Item Definition to be in new site.
UPDATE s
SET s.SiteId = 6
FROM 
dbo.ActionItemDefinition aid
INNER JOIN Schedule s on aid.ScheduleId = s.Id
INNER JOIN ActionItemDefinitionFunctionalLocation aidfl on aidfl.ActionItemDefinitionId = aid.Id
INNER JOIN FunctionalLocation f on f.Id = aidfl.FunctionalLocationId
where
f.FullHierarchy like 'EU1%'
GO

-- update ActionItemDefinitionHistory's business category to be from the new list
UPDATE h
SET h.BusinessCategoryId = bc.Id
FROM
dbo.ActionItemDefinitionHistory h
INNER JOIN dbo.BusinessCategory bc ON bc.OldId = h.BusinessCategoryId
INNER JOIN dbo.ActionItemDefinition aid on aid.Id = h.Id
INNER JOIN ActionItemDefinitionFunctionalLocation aidfl on aidfl.ActionItemDefinitionId = aid.Id
INNER JOIN FunctionalLocation f on f.Id = aidfl.FunctionalLocationId
where
f.FullHierarchy like 'EU1%'
GO

-- delete existing business category floc assications for EU1 flocs that are associated to business categories in oilsands
DELETE bcf
FROM
BusinessCategoryFLOCAssociation bcf
INNER JOIN FunctionalLocation f on bcf.FunctionalLocationId = f.Id
INNER JOIN BusinessCategory c on c.Id = bcf.BusinessCategoryId 
where f.fullhierarchy like 'EU1%' and c.SiteId = 3

-- add new associations for SWS business cateogories and EU1 flocs
INSERT INTO BusinessCategoryFLOCAssociation (
   BusinessCategoryId
  ,FunctionalLocationId
  ,LastModifiedUserId
  ,LastModifiedDateTime
) SELECT bc.id, f.id, -1, getdate() from businesscategory bc, FunctionalLocation f where bc.siteid = 6 and f.fullhierarchy = 'EU1'
GO

ALTER TABLE DocumentRootPathConfiguration
ADD SiteId bigint NULL
GO

UPDATE DocumentRootPathConfiguration 
SET
  DocumentRootPathConfiguration.SiteId = (select top 1 f.SiteId from FunctionalLocation f
  INNER JOIN DocumentRootPathFunctionalLocation on dbo.DocumentRootPathFunctionalLocation.FunctionalLocationId = f.Id
  where DocumentRootPathFunctionalLocation.DocumentRootPathId = DocumentRootPathConfiguration.Id)


INSERT INTO DocumentRootPathConfiguration (
   [PathName]
  ,UncPath
  ,Deleted
  ,SiteId
) SELECT 
    drpc.[PathName],
    drpc.UncPath,
    drpc.Deleted,
    6
    FROM
    DocumentRootPathConfiguration drpc where siteid = 3

UPDATE drpfl
SET drpfl.DocumentRootPathId = new_config.Id 
FROM
DocumentRootPathFunctionalLocation drpfl
INNER JOIN documentRootpathConfiguration old_config on old_config.id = drpfl.DocumentRootPathId
INNER JOIN DocumentRootPathConfiguration new_config ON new_config.[PathName] = old_config.[PathName] and new_config.[UncPath] = old_config.[UncPath] 
where old_config.SiteId = 3
and new_config.SiteId = 6
GO

ALTER TABLE DocumentRootPathConfiguration DROP COLUMN SiteId
GO

-- update schedule's site to SWS for log definitions in EU1
UPDATE s
SET s.SiteId = 6
FROM 
dbo.LogDefinition ld
INNER JOIN Schedule s on ld.ScheduleId = s.Id
INNER JOIN LogDefinitionFunctionalLocation ldfl on ldfl.LogDefinitionId = ld.Id
INNER JOIN FunctionalLocation f on f.Id = ldfl.FunctionalLocationId
where
f.FullHierarchy like 'EU1%'
GO

ALTER TABLE Shift
ADD OldId bigint NULL
GO

UPDATE 
  Shift
SET OldId = (Select Id FROM Shift where siteid = 3 and [Name]='D')
where
  Siteid = 6 and [Name] = 'D'

UPDATE 
  Shift
SET OldId = (Select Id FROM Shift where siteid = 3 and [Name]='N')
where
  Siteid = 6 and [Name] = 'N'
GO

ALTER TABLE dbo.[Role]
  ADD OldId bigint NULL
GO

  -- update the lone EUS role to be in SWS site
UPDATE [Role]
	SET SiteId = 6
WHERE SiteId = 3 and ActiveDirectoryKey like 'EU%'

-- create new roles for things like Supervisor or Operator that exist is Oilsands, but don't exist in SWS yet where we have an existing EUS work assignment in Oilsands.  Then, we are able to move those work assignments to the right role now.
INSERT INTO dbo.[Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
  ,OldId
) SELECT DISTINCT
   r.[Name]
  ,r.deleted
  ,r.ActiveDirectoryKey
  ,r.IsAdministratorRole
  ,r.IsReadOnlyRole
  ,r.IsWorkPermitNonOperationsRole
  ,6
  ,r.WarnIfWorkAssignmentNotSelected
  ,r.Alias
  ,r.Id
  FROM [Role] r 
  INNER JOIN dbo.WorkAssignment wa ON wa.RoleId = r.Id
  where wa.Category = 'EUS' and wa.SiteId = 3
  and NOT EXISTS (Select * from [Role] existing where existing.SiteId = 6 and existing.[Name] = r.[Name])


-- need to update existing SWS roles with old id with Role id in Oilsands
UPDATE
  sws_r
SET
  sws_r.OldId = oilsands_r.Id
FROM
  dbo.[Role] sws_r
  INNER JOIN dbo.[Role] oilsands_r ON sws_r.[Name] = oilsands_r.[Name]
 where
  sws_r.SiteId = 6 and oilsands_r.SiteId = 3 and sws_r.OldId IS NULL
GO

UPDATE l
SET 
  l.CreationUserShiftPatternId = s.Id
FROM
dbo.[Log] l
INNER JOIN Shift s ON s.OldId = l.CreationUserShiftPatternId
INNER JOIN LogFunctionalLocation lfl on lfl.LogId = l.Id
INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'
GO

UPDATE l
SET 
  l.CreatedByRoleId = r.Id
FROM
dbo.[Log] l
INNER JOIN Role r on r.OldId = l.CreatedByRoleId
INNER JOIN LogFunctionalLocation lfl on lfl.LogId = l.Id
INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'
GO

UPDATE ld
SET 
  ld.CreatedByRoleId = r.Id
FROM
dbo.[LogDefinition] ld
INNER JOIN Role r on r.OldId = ld.CreatedByRoleId
INNER JOIN LogDefinitionFunctionalLocation ldfl on ldfl.LogDefinitionId = ld.Id
INNER JOIN FunctionalLocation f on f.Id = ldfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'
GO
  
ALTER TABLE LogTemplate
  ADD OldId BIGINT NULL
GO

INSERT INTO LogTemplate (
   [Name]
  ,[Text]
  ,LastModifiedUserId
  ,LastModifiedDateTime
  ,CreatedUserId
  ,CreatedDateTime
  ,AppliesToLogs
  ,AppliesToSummaryLogs
  ,AppliesToDirectives
  ,OldId
) SELECT DISTINCT 
   lt.[Name]
  ,lt.[Text]
  ,lt.LastModifiedUserId
  ,lt.LastModifiedDateTime
  ,lt.CreatedUserId
  ,lt.CreatedDateTime
  ,lt.AppliesToLogs
  ,lt.AppliesToSummaryLogs
  ,lt.AppliesToDirectives
  ,lt.Id
  FROM
    LogTemplate lt
    INNER JOIN LogTemplateWorkAssignment ON dbo.LogTemplateWorkAssignment.LogTemplateId = lt.Id
    INNER JOIN dbo.WorkAssignment ON dbo.WorkAssignment.Id = dbo.LogTemplateWorkAssignment.WorkAssignmentId
    WHERE dbo.WorkAssignment.Category = 'EUS'
GO
	
UPDATE
  ltwa
SET
  ltwa.LogTemplateId = lt.Id
FROM
  LogTemplateWorkAssignment ltwa
  INNER JOIN LogTemplate lt ON ltwa.LogTemplateId = lt.OldId
  INNER JOIN WorkAssignment wa on ltwa.WorkAssignmentId = wa.Id
WHERE wa.Category = 'EUS'
GO

UPDATE Plant
  Set SiteId = 6
  where Id = 1060
GO

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT 
  r.Id,
  rdc.SectionId,
  rdc.PrimaryDefaultPageId,
  rdc.SecondaryDefaultPageId
FROM
  RoleDisplayConfiguration rdc
  INNER JOIN dbo.[Role] r ON r.OldId = rdc.RoleId and r.SiteId = 6
WHERE NOT EXISTS (Select * from RoleDisplayConfiguration exist where exist.RoleId = r.Id and exist.SectionId = rdc.SectionId) 	
GO

INSERT INTO 
  RoleElementTemplate (
     RoleElementId
    ,RoleId
  ) SELECT 
    ret.RoleElementId,
    r.Id
    FROM
      RoleElementTemplate ret
      INNER JOIN Role r ON r.OldId = ret.RoleId
    WHERE 
      r.SiteId = 6 and 
    NOT EXISTS (
      Select * from dbo.RoleElementTemplate exist 
      where 
        exist.RoleElementId = ret.RoleElementId
          and exist.RoleId = r.Id)
GO
		
-- delete role element templates having to do with Forms, Restriction Reporting and Lab Alerts from SWS that were migrated from Oilsands
DELETE ret
FROM
  dbo.RoleElementTemplate ret
  INNER JOIN [role] r ON ret.RoleId = r.Id
  inner join dbo.RoleElement re ON re.Id =ret.RoleElementId
where 
  r.SiteId = 6 and 
  re.FunctionalArea IN ('Forms', 'Restriction Reporting', 'Lab Alerts', 'Coker Cards', 'Admin - Coker Cards', 'Admin - Forms', 'Admin - Lab Alerts', 'Admin - Restriction Reporting')
GO
  
INSERT INTO RolePermission (
   RoleId
  ,RoleElementId
  ,CreatedByRoleId
) 
SELECT 
  r.Id,
  rp.RoleElementId,
  cr.Id
  FROM
    RolePermission rp
    INNER JOIN Role r ON rp.RoleId = r.OldId
	INNER JOIN Role cr ON rp.CreatedByRoleId = cr.OldId
    WHERE r.SiteId = 6 and cr.SiteId = 6
    and NOT EXISTS(
    Select * from RolePermission exist 
    where exist.Roleid = r.Id and 
          exist.RoleElementId = rp.RoleElementId and
          exist.CreatedByRoleId = rp.CreatedByRoleId)
GO
		  
-- delete all role permissions having to do with forms, Restriction Reporting or Lab Alerts in SWS
DELETE rp
FROM
RolePermission rp
inner join dbo.RoleElement ON dbo.RoleElement.Id = rp.RoleElementId
inner join dbo.[Role] ON dbo.[Role].Id = rp.roleid
where 
	role.SiteId = 6 and 
	roleelement.FunctionalArea IN ('Forms', 'Restriction Reporting', 'Lab Alerts', 'Coker Cards', 'Admin - Coker Cards', 'Admin - Forms', 'Admin - Lab Alerts', 'Admin - Restriction Reporting')
GO

-- need to deal with Shift Handover and deleting temp columns now.
ALTER TABLE ShiftHandoverConfiguration
  ADD SiteId BIGINT NULL,
  OldId BIGINT NULL
GO

UPDATE c 
SET c.SiteId = wa.SiteId
FROM
  ShiftHandoverConfiguration c
  INNER JOIN ShiftHandoverConfigurationWorkAssignment many ON many.ShiftHandoverConfigurationId = c.Id
  INNER JOIN WorkAssignment wa ON wa.id = many.WorkAssignmentId

INSERT INTO ShiftHandoverConfiguration (
   [Name]
  ,Deleted
  ,SiteId
  ,OldId
) SELECT DISTINCT
  old_config.[Name],
  old_config.Deleted,
  6,
  old_config.Id
FROM
  ShiftHandoverConfiguration old_config
  INNER JOIN ShiftHandoverConfigurationWorkAssignment many on many.ShiftHandoverConfigurationId = old_config.Id
  INNER JOIN WorkAssignment wa ON wa.Id = many.WorkAssignmentId
where wa.Category = 'EUS'  

UPDATE many
SET
  many.ShiftHandoverConfigurationId = config.Id
FROM
  ShiftHandoverConfigurationWorkAssignment many
  INNER JOIN ShiftHandoverConfiguration config ON config.OldId = many.ShiftHandoverConfigurationId
  INNER JOIN WorkAssignment wa on wa.Id = many.WorkAssignmentId
where wa.Category = 'EUS'

INSERT INTO ShiftHandoverQuestion (
   ShiftHandoverConfigurationId
  ,DisplayOrder
  ,[Text]
  ,HelpText
  ,Deleted
  ,IsCurrentQuestionVersion
) SELECT 
   config.Id
  ,q.DisplayOrder
  ,q.[Text]
  ,q.HelpText
  ,q.Deleted
  ,q.IsCurrentQuestionVersion
FROM
  ShiftHandoverQuestion q
  INNER JOIN ShiftHandoverConfiguration config ON config.OldId = q.ShiftHandoverConfigurationId

UPDATE 
  q
SET
  q.ShiftId = s.Id
FROM
  ShiftHandoverQuestionnaire q
  INNER JOIN [Shift] s ON s.OldId = q.ShiftId
  INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shqfl ON shqfl.ShiftHandoverQuestionnaireId = q.Id
  INNER JOIN FunctionalLocation f on f.Id = shqfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'

  
UPDATE l
SET 
  l.CreationUserShiftPatternId = s.Id
FROM
dbo.[SummaryLog] l
INNER JOIN Shift s ON s.OldId = l.CreationUserShiftPatternId
INNER JOIN SummaryLogFunctionalLocation lfl on lfl.SummaryLogId = l.Id
INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'
GO

UPDATE l
SET 
  l.CreatedByRoleId = r.Id
FROM
dbo.[SummaryLog] l
INNER JOIN Role r on r.OldId = l.CreatedByRoleId
INNER JOIN SummaryLogFunctionalLocation lfl on lfl.SummaryLogId = l.Id
INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId
where
  f.FullHierarchy like 'EU1%'
GO

ALTER TABLE TagGroup
  ADD OldId bigint null
GO

INSERT INTO TagGroup (
   [Name]
  ,SiteId
  ,OldId
) SELECT
  [Name],
  6,
  Id
  FROM
    TagGroup where SiteId = 3
GO

ALTER TABLE Tag
  Add OldId bigint null
GO
  
INSERT INTO Tag (
   [Name]
  ,[Description]
  ,Units
  ,SiteId
  ,Deleted
  ,OldId
) SELECT 
   t.[Name]
  ,t.[Description]
  ,t.Units
  ,6
  ,t.Deleted
  ,t.Id
FROM
  Tag t
  where t.SiteId = 3
GO

-- Update the Tag a Custom Field is associated to as the Tag in SWS, not the Tag in OilSands
UPDATE
  cf
SET 
  cf.TagId = (SELECT new_tag.Id FROM [Tag] new_tag where new_tag.SiteId = 6 and new_tag.[Name] = t.[Name])
FROM
  CustomField cf
  INNER JOIN dbo.Tag ON dbo.Tag.Id = cf.TagId
  INNER JOIN CustomFieldCustomFieldGroup many on cf.Id = many.CustomFieldId
  INNER JOIN CustomFieldGroup cfg on cfg.Id = many.CustomFieldGroupId
  INNER JOIN CustomFieldGroupWorkAssignment many_wa on many_wa.CustomFieldGroupId = cfg.Id
  INNER JOIN WorkAssignment wa on wa.Id = many_wa.WorkAssignmentId
  INNER JOIN Tag t on t.Id = cf.TagId
where wa.Category = 'EUS' and t.SiteId = 3
GO

UPDATE 
  many
SET many.TagGroupId = tg.Id
FROM
  TagGroupAssociation many
  INNER JOIN TagGroup tg ON many.TagGroupId = tg.OldId
  
UPDATE 
  many
SET many.TagId = t.Id
FROM
  TagGroupAssociation many
  INNER JOIN Tag t ON many.TagId = t.OldId
GO

UPDATE ta
SET ta.TagId = t.Id
FROM
TargetAlert ta
INNER JOIN Tag t on t.OldId = ta.TagId
INNER JOIN FunctionalLocation f ON f.Id = ta.FunctionalLocationId
where f.FullHierarchy like 'EU1%'
GO

ALTER TABLE TargetAlertResponse 
  DROP COLUMN CreatedShiftPatternIds
GO

UPDATE tar
SET tar.CreatedShiftPatternId = s.Id
FROM
  TargetAlertResponse tar
  INNER JOIN TargetAlert ta on ta.Id = tar.TargetAlertId
  INNER JOIN FunctionalLocation f on f.Id = ta.FunctionalLocationId
  INNER JOIN Shift s on s.OldId = tar.CreatedShiftPatternId
where
  f.FullHierarchy like 'EU1%'
GO

UPDATE 
  td
SET td.TagId = t.Id
FROM
TargetDefinition td
INNER JOIN Tag t on t.OldId = td.TagId
INNER JOIN FunctionalLocation f ON f.Id = td.FunctionalLocationId
where f.FullHierarchy like 'EU1%'
GO

UPDATE 
  s
SET s.SiteId = 6
FROM
  Schedule s
  INNER JOIN TargetDefinition td on td.ScheduleId = s.Id
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.Fullhierarchy like 'EU1%'
  and s.SiteId = 3
GO
  
UPDATE
  tdh
SET
  tdh.TagId = t.Id
FROM
  TargetDefinitionHistory tdh
  INNER JOIN Tag t on t.OldId = tdh.TagId
  INNER JOIN TargetDefinition td on td.Id = tdh.Id
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.SiteId = 3 and f.FullHierarchy like 'EU1%'
GO
  
UPDATE config 
SET config.MaxTagId = t.Id
FROM
TargetDefinitionReadWriteTagConfiguration config
INNER JOIN Tag t on t.OldId = config.MaxTagId
INNER JOIN TargetDefinition td on td.Id = config.TargetDefinitionId
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.SiteId = 3 and f.FullHierarchy like 'EU1%'
GO

UPDATE config 
SET config.MinTagId = t.Id
FROM
TargetDefinitionReadWriteTagConfiguration config
INNER JOIN Tag t on t.OldId = config.MinTagId
INNER JOIN TargetDefinition td on td.Id = config.TargetDefinitionId
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.SiteId = 3 and f.FullHierarchy like 'EU1%'
GO

UPDATE config 
SET config.TargetTagId = t.Id
FROM
TargetDefinitionReadWriteTagConfiguration config
INNER JOIN Tag t on t.OldId = config.TargetTagId
INNER JOIN TargetDefinition td on td.Id = config.TargetDefinitionId
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.SiteId = 3 and f.FullHierarchy like 'EU1%'
GO

UPDATE config 
SET config.GapUnitValueTagId = t.Id
FROM
TargetDefinitionReadWriteTagConfiguration config
INNER JOIN Tag t on t.OldId = config.GapUnitValueTagId
INNER JOIN TargetDefinition td on td.Id = config.TargetDefinitionId
  INNER JOIN FunctionalLocation f on f.Id = td.FunctionalLocationId
where
  f.SiteId = 3 and f.FullHierarchy like 'EU1%'
GO

UPDATE
  many
SET
  many.VisibilityGroupId = new_g.Id
FROM
  WorkAssignmentVisibilityGroup many
  INNER JOIN VisibilityGroup old_g ON many.VisibilityGroupId = old_g.Id
  INNER JOIN VisibilityGroup new_g on new_g.[Name] = old_g.[Name] and old_g.SiteId = 3 and new_g.SiteId = 6
  INNER JOIN WorkAssignment wa on wa.Id = many.WorkAssignmentId
where
  wa.SiteId = 3 and wa.Category = 'EUS'
GO
  
UPDATE 
  wa
SET 
  wa.RoleId = r.Id
 FROM
WorkAssignment wa
INNER JOIN Role r on r.OldId = wa.RoleId
where wa.SiteId = 3 and wa.Category = 'EUS'
GO

UPDATE 
  wa
SET 
  wa.SiteId = 6
 FROM
WorkAssignment wa
where wa.SiteId = 3 and wa.Category = 'EUS'
GO

UPDATE 
  wa
SET
  wa.AutoInsertLogTemplateId = lt.Id
FROM
  WorkAssignment wa
  INNER JOIN LogTemplate lt on lt.OldId = wa.AutoInsertLogTemplateId
where
  wa.Category = 'EUS'
GO

UPDATE FunctionalLocation
  SET SiteId = 6
  where siteid = 3 and FullHierarchy like 'EU1%'
GO
  
ALTER TABLE BusinessCategory DROP COLUMN OldId
GO

ALTER TABLE Shift DROP COLUMN OldId
GO

ALTER TABLE Role DROP COLUMN OldId
GO

ALTER TABLE LogTemplate DROP COLUMN OldId
GO

ALTER TABLE ShiftHandoverConfiguration DROP COLUMN SiteId
GO

ALTER TABLE ShiftHandoverConfiguration DROP COLUMN OldId
GO

ALTER TABLE TagGroup DROP COLUMN OldId
GO

ALTER TABLE Tag DROP COLUMN OldId
GO