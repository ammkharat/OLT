
alter table [dbo].DocumentLink add PermitRequestLubesId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestLubes] FOREIGN KEY([PermitRequestLubesId])
REFERENCES [dbo].[PermitRequestLubes] ([Id])
go



GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
DROP CONSTRAINT [FK_WorkPermitEdmonton_RequestedByUser]
GO
ALTER TABLE [dbo].[WorkPermitEdmonton]
DROP COLUMN [RequestedByUserId]
GO


GO

