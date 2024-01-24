CREATE TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment](
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL);

GO

ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment] 
ADD CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_ShiftHandoverConfiguration] 
FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])
GO

ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment] 
ADD CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
