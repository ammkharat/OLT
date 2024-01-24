alter table [Log] add [WorkAssignmentId] bigint null;

GO

ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [FK_Log_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO


GO
