
ALTER TABLE [dbo].[CustomField] ADD TagId bigint null;
GO

ALTER TABLE [dbo].[CustomField]
ADD CONSTRAINT [FK_CustomField_Tag]
FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO



GO

