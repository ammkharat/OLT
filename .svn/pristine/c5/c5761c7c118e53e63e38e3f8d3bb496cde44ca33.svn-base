CREATE TABLE [dbo].[CokerCardConfigurationWorkAssignment] (
[CokerCardConfigurationId] bigint NOT NULL,
[WorkAssignmentId] bigint NOT NULL,
CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_CokerCard]
FOREIGN KEY ([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ( [Id] ),
CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_WorkAssignment]
FOREIGN KEY ([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ( [Id] )
)
ON [PRIMARY];
GO

GO
