ALTER TABLE [dbo].[WorkPermitEdmonton] ADD [PermitRequestId] bigint NULL
GO
ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_PermitRequest]
FOREIGN KEY ([PermitRequestId])
REFERENCES [dbo].[PermitRequestEdmonton] ( [Id] )
GO


GO

