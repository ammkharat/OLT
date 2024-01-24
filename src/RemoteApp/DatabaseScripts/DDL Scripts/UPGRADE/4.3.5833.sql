DROP TABLE [dbo].[PermitRequestOssaWorkPermitOssaAssociation]
GO

ALTER TABLE [dbo].[WorkPermitOssa] ADD [PermitRequestId] bigint NULL
GO
ALTER TABLE [dbo].[WorkPermitOssa]
ADD  CONSTRAINT [FK_WorkPermitOssa_PermitRequest]
FOREIGN KEY ([PermitRequestId])
REFERENCES [dbo].[PermitRequestOssa] ( [Id] )
GO



GO

