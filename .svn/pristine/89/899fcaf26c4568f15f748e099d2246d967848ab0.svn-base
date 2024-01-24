


CREATE TABLE [dbo].[FormOilsandsTraining](
	[FormStatusId] [int] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Id] [bigint] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTraining] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_CreatedByUser]
GO

ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormOilsandsTraining] ADD  DEFAULT ((0)) FOR [Deleted]
GO





---------------------- approvals

CREATE TABLE [dbo].[FormOilsandsTrainingApproval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTrainingApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormOilsandsTrainingApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingApproval] CHECK CONSTRAINT [FK_FormOilsandsTrainingApproval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormOilsandsTrainingApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingApproval_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingApproval] CHECK CONSTRAINT [FK_FormOilsandsTrainingApproval_FormOilsandsTraining]
GO



-------------------------- functional locations

CREATE TABLE [dbo].[FormOilsandsTrainingFunctionalLocation](
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTrainingFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormOilsandsTrainingId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation] CHECK CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FormOilsandsTraining]
GO

ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation] CHECK CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation]
GO



GO

