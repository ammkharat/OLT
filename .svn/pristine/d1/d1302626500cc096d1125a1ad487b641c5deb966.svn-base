alter table ActionItem add WorkAssignmentId bigint null

GO

ALTER TABLE [dbo].[ActionItem]
ADD CONSTRAINT [FK_ActionItem_WorkAssignment]
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO

alter table ActionItemDefinition add WorkAssignmentId bigint null

GO

ALTER TABLE [dbo].[ActionItemDefinition]
ADD CONSTRAINT [FK_ActionItemDefinition_WorkAssignment]
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO


alter table ActionItemDefinitionHistory
add WorkAssignmentName varchar(40) null 

GO
