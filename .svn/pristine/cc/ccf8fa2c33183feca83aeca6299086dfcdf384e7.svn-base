

alter table FormOilsandsTraining drop column ClosedDateTime;
go



CREATE TABLE [dbo].[FormOilsandsTrainingHistory] (
    [Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,	
	[ApprovedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[EarliestTrainingDate] [datetime] NOT NULL,
	[LatestTrainingDate] [datetime] NOT NULL,
	[Approvals] [varchar](max) NULL,
	[TrainingItems] [varchar](max) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormOilsandsTrainingHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingHistory_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingHistory] CHECK CONSTRAINT [FK_FormOilsandsTrainingHistory_LastModifiedUser]
GO






GO

