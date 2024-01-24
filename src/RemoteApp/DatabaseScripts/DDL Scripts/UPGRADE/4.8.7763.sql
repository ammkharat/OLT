-- alter table [dbo].WorkPermitLubes add IssuedDateTime datetime null;

alter table [dbo].WorkPermitLubes drop constraint FK_WorkPermitLubes_RequestedByUserId;
alter table [dbo].WorkPermitLubes drop column RequestedByUserId;

GO

-- alter table [dbo].WorkPermitLubes add PermitRequestSubmittedByUserId bigint null;
-- GO
-- ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_PermitRequestSubmittedByUserId] FOREIGN KEY([PermitRequestSubmittedByUserId])
-- REFERENCES [dbo].[User] ([Id])







GO

