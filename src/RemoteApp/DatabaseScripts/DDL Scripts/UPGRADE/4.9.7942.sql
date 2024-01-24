
CREATE TABLE [dbo].[TrainingBlock] (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Code] [varchar](100) NULL,
	[Deleted] [bit] NOT NULL
 CONSTRAINT [PK_TrainingBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrainingBlockFunctionalLocation](
	[TrainingBlockId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_TrainingBlockFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[TrainingBlockId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBlockFunctionalLocation_TrainingBlock] FOREIGN KEY([TrainingBlockId])
REFERENCES [dbo].[TrainingBlock] ([Id])
GO

ALTER TABLE [dbo].[TrainingBlockFunctionalLocation] CHECK CONSTRAINT [FK_TrainingBlockFunctionalLocation_TrainingBlock]
GO

ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[TrainingBlockFunctionalLocation] CHECK CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation]
GO



---------------------


CREATE TABLE [dbo].[FormOilsandsTrainingItem] (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[TrainingDate] datetime NOT NULL,
	[ShiftPatternId] [bigint] NOT NULL,
	[TrainingBlockId] [bigint] NULL,
	[Comments] [varchar](1000) NULL,
	[BlockCompleted] [bit] NOT NULL,
	[Hours] [decimal](8,2) NOT NULL,
	[Deleted] [bit] NOT NULL
 CONSTRAINT [PK_FormOilsandsTrainingItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormOilsandsTrainingItem]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingItem_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingItem] CHECK CONSTRAINT [FK_FormOilsandsTrainingItem_FormOilsandsTraining]
GO

ALTER TABLE [dbo].[FormOilsandsTrainingItem]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingItem_TrainingBlock] FOREIGN KEY([TrainingBlockId])
REFERENCES [dbo].[TrainingBlock] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingItem] CHECK CONSTRAINT [FK_FormOilsandsTrainingItem_TrainingBlock]
GO





GO

