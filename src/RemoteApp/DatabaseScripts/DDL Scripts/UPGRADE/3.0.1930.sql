-- Delete old RoleElements from the RoleElementTemplate table that no longer exist
-- Also, add FKs so this situation doesn't happen again.

delete from RoleElementTemplate WHERE RoleElementId IN(43, 44, 55, 56)
ALTER TABLE [dbo].[RoleElementTemplate]
ADD CONSTRAINT [FK_RoleElementTemplate_RoleElement]
FOREIGN KEY([RoleElementId])
REFERENCES [dbo].[RoleElement] ([Id])

ALTER TABLE [dbo].[RoleElementTemplate]
ADD CONSTRAINT [FK_RoleElementTemplate_Role]
FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])

GO
