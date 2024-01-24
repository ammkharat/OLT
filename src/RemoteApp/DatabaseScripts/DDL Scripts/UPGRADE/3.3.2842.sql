
CREATE TABLE [dbo].[LabAlertDefinition](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[TagID] [bigint] NOT NULL,
	[MinimumNumberOfSamples] int NOT NULL,
	[LabAlertTagQueryRangeType] tinyint NOT NULL,
	[LabAlertTagQueryRangeFromTime] datetime NOT NULL,
	[LabAlertTagQueryRangeToTime] datetime NOT NULL,
	[LabAlertTagQueryRangeFromDayOfWeek] int NULL,
	[LabAlertTagQueryRangeToDayOfWeek] int NULL,
	[LabAlertTagQueryRangeFromWeekOfMonth] int NULL,
	[LabAlertTagQueryRangeToWeekOfMonth] int NULL,
	[LabAlertTagQueryRangeFromDayOfMonth] int NULL,
	[LabAlertTagQueryRangeToDayOfMonth] int NULL,
	[ScheduleId] [bigint] NOT NULL,
	[LabAlertDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastInvokedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_LabAlertDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)

GO

ALTER TABLE [dbo].[LabAlertDefinition] 
ADD CONSTRAINT [FK_LabAlertDefinition_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[LabAlertDefinition] 
ADD CONSTRAINT [FK_LabAlertDefinition_Tag] 
FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([Id])
GO

ALTER TABLE [dbo].[LabAlertDefinition] 
ADD CONSTRAINT [FK_LabAlertDefinition_Schedule] 
FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO

ALTER TABLE [dbo].[LabAlertDefinition]
ADD CONSTRAINT [FK_LabAlertDefinition_LasModifiedByUser] 
FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[LabAlertDefinition]
ADD CONSTRAINT [FK_LabAlertDefinition_CreatedByUser] 
FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO


GO
