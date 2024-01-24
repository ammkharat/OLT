IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_OrgUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_OrgUnit]

ALTER TABLE [dbo].[User] DROP COLUMN OrgUnitId 

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IDX_User_ParentOrgUnit')
DROP INDEX [IDX_User_ParentOrgUnit] ON [dbo].[User] WITH ( ONLINE = OFF )

ALTER TABLE [dbo].[User] DROP COLUMN ParentOrgUnitId

DROP TABLE [dbo].[UserShiftAssignment]
DROP TABLE [dbo].[DailyWorkAssignment]

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_OrgUnitId]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrganizationalUnitAssignment]'))
ALTER TABLE [dbo].[OrganizationalUnitAssignment] DROP CONSTRAINT [fk_OrgUnitId]
ALTER TABLE [dbo].[OrganizationalUnitAssignment] DROP COLUMN OrgUnitId
ALTER TABLE [dbo].[OrganizationalUnitAssignment] DROP COLUMN SapJobId

DROP TABLE [dbo].[OrganizationalUnit]
DROP TABLE [dbo].[WorkAssignmentReportConfiguration]

GO
