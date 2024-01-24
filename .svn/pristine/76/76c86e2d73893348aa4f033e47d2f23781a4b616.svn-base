alter table [dbo].WorkPermitLubes add IssuedDateTime datetime null;

-- alter table [dbo].WorkPermitLubes drop column RequestedByUser;
GO

alter table [dbo].WorkPermitLubes add PermitRequestCreatedByUserId bigint null;
GO
ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_PermitRequestCreatedByUserId] FOREIGN KEY([PermitRequestCreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

alter table [dbo].WorkPermitLubes add PermitRequestSubmittedByUserId bigint null;
GO
ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_PermitRequestSubmittedByUserId] FOREIGN KEY([PermitRequestSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])







GO

