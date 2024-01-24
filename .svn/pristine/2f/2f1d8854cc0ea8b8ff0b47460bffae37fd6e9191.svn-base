alter table ShiftHandoverConfiguration drop constraint FK_ShiftHandoverConfiguration_FunctionalLocation
alter table ShiftHandoverConfiguration drop column FunctionalLocationId

GO

alter table ShiftHandoverConfiguration drop constraint FK_ShiftHandoverConfiguration_Role
alter table ShiftHandoverConfiguration drop column RoleId

CREATE TABLE [dbo].[ShiftHandoverConfigurationFunctionalLocation](
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL
)

GO

ALTER TABLE [dbo].[ShiftHandoverConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_ShiftHandoverConfigurationFunctionalLocation_ShiftHandoverConfiguration] 
FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])

ALTER TABLE [dbo].[ShiftHandoverConfigurationFunctionalLocation]
ADD CONSTRAINT [FK_ShiftHandoverConfigurationFunctionalLocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

CREATE TABLE [dbo].[ShiftHandoverConfigurationRole](
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL
)

GO

ALTER TABLE [dbo].[ShiftHandoverConfigurationRole]
ADD CONSTRAINT [FK_ShiftHandoverConfigurationRole_ShiftHandoverConfiguration] 
FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])

ALTER TABLE [dbo].[ShiftHandoverConfigurationRole]
ADD CONSTRAINT [FK_ShiftHandoverConfigurationRole_Role] 
FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])

GO


GO
