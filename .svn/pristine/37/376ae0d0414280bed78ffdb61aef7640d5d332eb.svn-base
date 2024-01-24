alter table LogDefinition add WorkAssignmentId bigint null

GO

ALTER TABLE [dbo].[LogDefinition]
ADD CONSTRAINT [FK_LogDefinition_WorkAssignment]
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO

GO
