

alter table dbo.PermitRequestEdmonton drop column GN59FormNumber;
go

alter table dbo.PermitRequestEdmonton add FormGN59Id bigint null;
go

ALTER TABLE dbo.PermitRequestEdmonton WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN59] FOREIGN KEY ([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO


---------

alter table dbo.PermitRequestEdmonton drop column GN7FormNumber;
go

alter table dbo.PermitRequestEdmonton add FormGN7Id bigint null;
go

ALTER TABLE dbo.PermitRequestEdmonton WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN7] FOREIGN KEY ([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO


----------



alter table dbo.WorkPermitEdmontonDetails drop column GN59FormNumber;
go

alter table dbo.WorkPermitEdmontonDetails add FormGN59Id bigint null;
go

ALTER TABLE dbo.WorkPermitEdmontonDetails WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN59] FOREIGN KEY ([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO


---------

alter table dbo.WorkPermitEdmontonDetails drop column GN7FormNumber;
go

alter table dbo.WorkPermitEdmontonDetails add FormGN7Id bigint null;
go

ALTER TABLE dbo.WorkPermitEdmontonDetails WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN7] FOREIGN KEY ([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

----------

alter table dbo.WorkPermitEdmontonHistory drop column GN7FormNumber;
go

alter table dbo.WorkPermitEdmontonHistory add FormGN7Id bigint null;
go

ALTER TABLE dbo.WorkPermitEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN7] FOREIGN KEY ([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

alter table dbo.WorkPermitEdmontonHistory drop column GN59FormNumber;
go

alter table dbo.WorkPermitEdmontonHistory add FormGN59Id bigint null;
go

ALTER TABLE dbo.WorkPermitEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN59] FOREIGN KEY ([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO


----------

alter table dbo.PermitRequestEdmontonHistory drop column GN7FormNumber;
go

alter table dbo.PermitRequestEdmontonHistory add FormGN7Id bigint null;
go

ALTER TABLE dbo.PermitRequestEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN7] FOREIGN KEY ([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO


alter table dbo.PermitRequestEdmontonHistory drop column GN59FormNumber;
go

alter table dbo.PermitRequestEdmontonHistory add FormGN59Id bigint null;
go

ALTER TABLE dbo.PermitRequestEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN59] FOREIGN KEY ([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO



GO

