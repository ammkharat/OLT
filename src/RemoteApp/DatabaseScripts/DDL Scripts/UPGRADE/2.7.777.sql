CREATE TABLE [dbo].[RestrictionDefinitionStatus](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](15) NOT NULL,
 CONSTRAINT [PK_RestrictionDefinitionStatus] PRIMARY KEY ( [Id] ASC )
)
GO

insert into [RestrictionDefinitionStatus] values (1, 'Valid', 1)
go

insert into [RestrictionDefinitionStatus] values (2, 'Invalid Tag', 2)
go



GO
CREATE TABLE [dbo].[RestrictionDefinition](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[MeasurementTagID] [bigint] NOT NULL,
	[ProductionTargetValue] int NULL,
	[ProductionTargetTagID] [bigint] NULL,
	[RestrictionDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((0)),
	[LastInvokedDateTime] [datetime] NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL DEFAULT ((0)),

    CONSTRAINT [PK_RestrictionDefinition] PRIMARY KEY ([Id] ASC)
)
GO

ALTER TABLE [dbo].[RestrictionDefinition]
ADD CONSTRAINT [FK_RestrictionDefinition_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[RestrictionDefinition]
ADD CONSTRAINT [FK_RestrictionDefinition_RestrictionDefinitionStatus] 
FOREIGN KEY([RestrictionDefinitionStatusID])
REFERENCES [dbo].[RestrictionDefinitionStatus] ([Id])
GO

ALTER TABLE [dbo].[RestrictionDefinition]
ADD CONSTRAINT [FK_RestrictionDefinition_MeasurementTag] 
FOREIGN KEY([MeasurementTagID])
REFERENCES [dbo].[Tag] ([Id])
GO

ALTER TABLE [dbo].[RestrictionDefinition]
ADD CONSTRAINT [FK_RestrictionDefinition_ProductionTargetTag] 
FOREIGN KEY([ProductionTargetTagID])
REFERENCES [dbo].[Tag] ([Id])
GO

ALTER TABLE [dbo].[RestrictionDefinition] 
ADD CONSTRAINT [FK_RestrictionDefinition_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO

GO
