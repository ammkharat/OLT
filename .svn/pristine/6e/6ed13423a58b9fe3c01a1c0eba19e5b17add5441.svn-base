CREATE TABLE [dbo].[RestrictionWorkAssignmentConfigurationFunctionalLocation](
	[WorkAssignmentId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_RestrictionWorkAssignmentConfigurationFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[WorkAssignmentId] ASC,
		[FunctionalLocationId] ASC
	)
)
GO

ALTER TABLE [dbo].[RestrictionWorkAssignmentConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_RestrictionWorkAssignmentConfigurationFunctionalLocation_WorkAssignment]
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

ALTER TABLE [dbo].[RestrictionWorkAssignmentConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_RestrictionWorkAssignmentConfigurationFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO



GO

