
alter table WorkAssignment add AutoInsertLogTemplateId bigint null;
go

ALTER TABLE [dbo].[WorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_WorkAssignment_AutoInsertLogTemplate] FOREIGN KEY([AutoInsertLogTemplateId])
REFERENCES [dbo].[LogTemplate] ([Id])
GO

ALTER TABLE [dbo].[WorkAssignment] CHECK CONSTRAINT [FK_WorkAssignment_AutoInsertLogTemplate]
GO


GO

