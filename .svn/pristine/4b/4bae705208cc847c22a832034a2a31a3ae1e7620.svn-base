CREATE TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation](
	[WorkAssignmentId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_WorkPermitAutoAssignmentConfigurationFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[WorkAssignmentId] ASC,
		[FunctionalLocationId] ASC
	)
)
GO

ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_WorkAssignment]
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

insert into RoleElement values (153, 'Associate FLOCs to Work Assignments for Work Permits');

GO

insert into RoleElementTemplate (RoleElementId, RoleId, SiteId) 
values (153, 12, 1); -- supervisor plus for sarnia

GO

insert into RoleElementTemplate (RoleElementId, RoleId, SiteId) 
values (153, 37, 1); -- administrator for sarnia

GO



GO
