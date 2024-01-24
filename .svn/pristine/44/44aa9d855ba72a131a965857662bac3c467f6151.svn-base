ALTER TABLE WorkPermitEdmonton ADD IssuedByUserId bigint null;

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD CONSTRAINT [FK_WorkPermitEdmonton_IssuedByUser]
FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])


GO

