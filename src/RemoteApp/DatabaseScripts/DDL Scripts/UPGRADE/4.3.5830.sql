DROP TABLE [dbo].[PermitRequestMontrealWorkPermitMontrealAssociation]
GO

ALTER TABLE [dbo].[WorkPermitMontreal] ADD [PermitRequestId] bigint NULL
GO
ALTER TABLE [dbo].[WorkPermitMontreal]
ADD  CONSTRAINT [FK_WorkPermitMontreal_PermitRequest]
FOREIGN KEY ([PermitRequestId])
REFERENCES [dbo].[PermitRequestMontreal] ( [Id] )
GO	