IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserLayoutPreference_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserLayoutPreference]'))
ALTER TABLE [dbo].[UserLayoutPreference] DROP CONSTRAINT [FK_UserLayoutPreference_User]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLayoutPreference]') AND type in (N'U'))
DROP TABLE [dbo].[UserLayoutPreference]
GO



GO

