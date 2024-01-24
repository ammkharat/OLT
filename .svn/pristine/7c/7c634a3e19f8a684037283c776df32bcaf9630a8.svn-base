EXEC sp_rename 'WorkPermitEdmontonDetails.GN6', 'GN6_Deprecated', 'COLUMN';
EXEC sp_rename 'WorkPermitEdmontonHistory.GN6', 'GN6_Deprecated', 'COLUMN';
go

alter table WorkPermitEdmontonDetails add GN6 bit null;
alter table WorkPermitEdmontonDetails add FormGN6Id bigint null;
alter table WorkPermitEdmontonHistory add GN6 bit null;
alter table WorkPermitEdmontonHistory add FormGN6Id bigint null;
go

update WorkPermitEdmontonDetails set GN6 = 0;
update WorkPermitEdmontonDetails set GN6 = 1 where GN6_Deprecated in (2, 3);   -- Approved, Required
go

update WorkPermitEdmontonHistory set GN6 = 0;
update WorkPermitEdmontonHistory set GN6 = 1 where GN6_Deprecated in ('Approved', 'Required');   -- Approved, Required
go

alter table WorkPermitEdmontonDetails alter column GN6 bit not null;
alter table WorkPermitEdmontonHistory alter column GN6 bit not null;
go

ALTER TABLE dbo.WorkPermitEdmontonDetails WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN6] FOREIGN KEY ([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

ALTER TABLE dbo.WorkPermitEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN6] FOREIGN KEY ([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

EXEC sp_rename 'PermitRequestEdmonton.GN6', 'GN6_Deprecated', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmontonHistory.GN6', 'GN6_Deprecated', 'COLUMN';
go

alter table PermitRequestEdmonton add GN6 bit null;
alter table PermitRequestEdmonton add FormGN6Id bigint null;
alter table PermitRequestEdmontonHistory add GN6 bit null;
alter table PermitRequestEdmontonHistory add FormGN6Id bigint null;
go

update PermitRequestEdmonton set GN6 = 0;
update PermitRequestEdmonton set GN6 = 1 where GN6_Deprecated in (2, 3);   -- Approved, Required
go

update PermitRequestEdmontonHistory set GN6 = 0;
update PermitRequestEdmontonHistory set GN6 = 1 where GN6_Deprecated in ('Approved', 'Required');   -- Approved, Required
go

alter table PermitRequestEdmonton alter column GN6 bit not null;
alter table PermitRequestEdmontonHistory alter column GN6 bit not null;
go

ALTER TABLE dbo.PermitRequestEdmonton WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN6] FOREIGN KEY ([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

ALTER TABLE dbo.PermitRequestEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN6] FOREIGN KEY ([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delete from PermitRequestEdmontonSAPImportData;
go

alter table PermitRequestEdmontonSAPImportData drop column GN6;
go

alter table PermitRequestEdmontonSAPImportData add GN6 bit not null;
go


GO

