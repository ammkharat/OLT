CREATE TABLE [dbo].[DeviationAlert](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,	
	[DeviationAlertResponseId] [bigint] NULL,
	[RestrictionDefinitionName] [varchar](30) NOT NULL,
	[RestrictionDefinitionDescription] [varchar](max) NULL,
	[ProductionTargetValue] int NULL,
	[MeasurementValue] int NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[RestrictionDefinitionId] [bigint] NOT NULL,
	[MeasurementValueTagId] [bigint] NOT NULL,
	[ProductionTargetValueTagId] [bigint] NULL
	
	CONSTRAINT [PK_DeviationAlert] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[DeviationAlert]
ADD CONSTRAINT [FK_DeviationAlert_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlert]
ADD CONSTRAINT [FK_DeviationAlert_RestrictionDefinition] 
FOREIGN KEY([RestrictionDefinitionId])
REFERENCES [dbo].[RestrictionDefinition] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlert]
ADD CONSTRAINT [FK_DeviationAlert_Measurement_Tag] 
FOREIGN KEY([MeasurementValueTagId])
REFERENCES [dbo].[Tag] ([Id])

GO

ALTER TABLE [dbo].[DeviationAlert]
ADD CONSTRAINT [FK_DeviationAlert_ProductionTarget_Tag] 
FOREIGN KEY([ProductionTargetValueTagId])
REFERENCES [dbo].[Tag] ([Id])

GO
