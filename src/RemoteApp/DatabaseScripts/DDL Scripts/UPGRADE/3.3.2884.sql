CREATE TABLE [dbo].[LabAlert](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](max) NULL,
	[FunctionalLocationId] [bigint] NOT NULL,	
	[TagId] [bigint] NOT NULL,
	[MinimumNumberOfSamples] int NOT NULL,
	[ActualNumberOfSamples] int NOT NULL,
	[LabAlertTagQueryRangeFromDateTime] datetime NOT NULL,
	[LabAlertTagQueryRangeToDateTime] datetime NOT NULL,
	[ScheduleDescription] [varchar](512) NOT NULL,
	[LabAlertDefinitionId] [bigint] NOT NULL,
	[LabAlertStatusId] bigint NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,	
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,		
 CONSTRAINT [PK_LabAlert] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

ALTER TABLE [dbo].[LabAlert] 
ADD CONSTRAINT [FK_LabAlert_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[LabAlert] 
ADD CONSTRAINT [FK_LabAlert_Tag] 
FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO

ALTER TABLE [dbo].[LabAlert] 
ADD CONSTRAINT [FK_LabAlert_LabAlertDefinition] 
FOREIGN KEY([LabAlertDefinitionId])
REFERENCES [dbo].[LabAlertDefinition] ([Id])
GO

ALTER TABLE [dbo].[LabAlert]
ADD CONSTRAINT [FK_LabAlert_LasModifiedByUser] 
FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

CREATE NONCLUSTERED INDEX [IDX_LabAlert_CreatedDateTime]
ON [dbo].[LabAlert] 
(
	[CreatedDateTime] ASC
)

GO
