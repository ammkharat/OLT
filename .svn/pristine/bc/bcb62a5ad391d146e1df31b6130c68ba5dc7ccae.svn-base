-- ************* Permit Request

EXEC sp_RENAME 'PermitRequestEdmonton.GN75' , 'GN75_Deprecated', 'COLUMN';
GO

alter table PermitRequestEdmonton add FormGN75AId bigint null;
GO

alter table PermitRequestEdmonton add GN75A bit null;
GO

update PermitRequestEdmonton set GN75A = 0 where GN75_Deprecated = 1;
update PermitRequestEdmonton set GN75A = 1 where GN75_Deprecated = 2 or GN75_Deprecated = 3;

alter table PermitRequestEdmonton alter column GN75A bit not null;

ALTER TABLE [dbo].[PermitRequestEdmonton] WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id]);
GO

-- ************* Permit

EXEC sp_RENAME 'WorkPermitEdmontonDetails.GN75' , 'GN75_Deprecated', 'COLUMN';

alter table WorkPermitEdmontonDetails add FormGN75AId bigint null;
GO

alter table WorkPermitEdmontonDetails add GN75A bit null;
GO


update WorkPermitEdmontonDetails set GN75A = 0 where GN75_Deprecated = 1;
update WorkPermitEdmontonDetails set GN75A = 1 where GN75_Deprecated = 2 or GN75_Deprecated = 3;
GO

alter table WorkPermitEdmontonDetails alter column GN75A bit not null;

ALTER TABLE [dbo].[WorkPermitEdmontonDetails] WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id]);

-- ************* PermitRequestHistory

EXEC sp_RENAME 'PermitRequestEdmontonHistory.GN75' , 'GN75_Deprecated', 'COLUMN';
GO

alter table PermitRequestEdmontonHistory add FormGN75AId bigint null;
GO

alter table PermitRequestEdmontonHistory add GN75A bit null;
GO

-- TODO: Do stuff to fill in the GN75A data
update PermitRequestEdmontonHistory set GN75A = 0;

alter table PermitRequestEdmontonHistory alter column GN75A bit not null;

ALTER TABLE [dbo].[PermitRequestEdmontonHistory] WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id]);
GO

-- ************* Import Data


alter table PermitRequestEdmontonSAPImportData drop column GN75;
GO

alter table PermitRequestEdmontonSAPImportData add GN75A bit null;
GO

update PermitRequestEdmontonSAPImportData set GN75A = 0;
GO

alter table PermitRequestEdmontonSAPImportData alter column GN75A bit not null;
GO

-- ************* WorkPermitHistory

EXEC sp_RENAME 'WorkPermitEdmontonHistory.GN75' , 'GN75_Deprecated', 'COLUMN';
GO

alter table WorkPermitEdmontonHistory add FormGN75AId bigint null;
GO

alter table WorkPermitEdmontonHistory add GN75A bit null;
GO

-- TODO: Do stuff to fill in the GN75A data
update WorkPermitEdmontonHistory set GN75A = 0;

alter table WorkPermitEdmontonHistory alter column GN75A bit not null;

ALTER TABLE [dbo].[WorkPermitEdmontonHistory] WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id]);
GO




GO

