

ALTER TABLE [dbo].[PermitRequestLubes] ADD [CreatedByRoleId] [bigint] NOT NULL

ALTER TABLE [dbo].[PermitRequestLubes] ADD CONSTRAINT [FK_PermitRequestLubes_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId]) REFERENCES [dbo].[Role] ([Id])



GO

