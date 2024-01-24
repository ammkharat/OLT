ALTER TABLE [dbo].[PermitRequest] ADD IsModified bit;
GO
update PermitRequest set IsModified = 0;
GO
ALTER TABLE [dbo].[PermitRequest] alter column IsModified bit not null;
GO

ALTER TABLE [dbo].[PermitRequest] ADD SapDescription varchar(400);
GO
update PermitRequest set SapDescription = Description;
GO
ALTER TABLE [dbo].[PermitRequest] alter column SapDescription varchar(400) not null;
GO

ALTER TABLE [dbo].[PermitRequestHistory] ADD SapDescription varchar(400);
GO
update PermitRequestHistory set SapDescription = Description;
GO
ALTER TABLE [dbo].[PermitRequestHistory] alter column SapDescription varchar(400) not null;



GO
