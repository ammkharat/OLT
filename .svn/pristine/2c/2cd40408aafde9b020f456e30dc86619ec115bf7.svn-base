
EXEC sp_rename 'WorkPermitEdmontonDetails.GN24', 'GN24_Deprecated', 'COLUMN';
EXEC sp_rename 'WorkPermitEdmontonHistory.GN24', 'GN24_Deprecated', 'COLUMN';
go

alter table WorkPermitEdmontonDetails add GN24 bit null;
alter table WorkPermitEdmontonDetails add FormGN24Id bigint null;
alter table WorkPermitEdmontonHistory add GN24 bit null;
alter table WorkPermitEdmontonHistory add FormGN24Id bigint null;
go

update WorkPermitEdmontonDetails set GN24 = 0;
update WorkPermitEdmontonDetails set GN24 = 1 where GN24_Deprecated in (2, 3);   -- Approved, Required
go

update WorkPermitEdmontonHistory set GN24 = 0;
update WorkPermitEdmontonHistory set GN24 = 1 where GN24_Deprecated in ('Approved', 'Required');   -- Approved, Required
go

alter table WorkPermitEdmontonDetails alter column GN24 bit not null;
alter table WorkPermitEdmontonHistory alter column GN24 bit not null;
go

ALTER TABLE dbo.WorkPermitEdmontonDetails WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN24] FOREIGN KEY ([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

ALTER TABLE dbo.WorkPermitEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN24] FOREIGN KEY ([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

EXEC sp_rename 'PermitRequestEdmonton.GN24', 'GN24_Deprecated', 'COLUMN';
EXEC sp_rename 'PermitRequestEdmontonHistory.GN24', 'GN24_Deprecated', 'COLUMN';
go

alter table PermitRequestEdmonton add GN24 bit null;
alter table PermitRequestEdmonton add FormGN24Id bigint null;
alter table PermitRequestEdmontonHistory add GN24 bit null;
alter table PermitRequestEdmontonHistory add FormGN24Id bigint null;
go

update PermitRequestEdmonton set GN24 = 0;
update PermitRequestEdmonton set GN24 = 1 where GN24_Deprecated in (2, 3);   -- Approved, Required
go

update PermitRequestEdmontonHistory set GN24 = 0;
update PermitRequestEdmontonHistory set GN24 = 1 where GN24_Deprecated in ('Approved', 'Required');   -- Approved, Required
go

alter table PermitRequestEdmonton alter column GN24 bit not null;
alter table PermitRequestEdmontonHistory alter column GN24 bit not null;
go

ALTER TABLE dbo.PermitRequestEdmonton WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN24] FOREIGN KEY ([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

ALTER TABLE dbo.PermitRequestEdmontonHistory WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN24] FOREIGN KEY ([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delete from PermitRequestEdmontonSAPImportData;
go

alter table PermitRequestEdmontonSAPImportData drop column GN24;
go

alter table PermitRequestEdmontonSAPImportData add GN24 bit not null;
go



GO

