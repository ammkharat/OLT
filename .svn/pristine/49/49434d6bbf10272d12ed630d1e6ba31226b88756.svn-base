/****** Object:  Table [dbo].[FormPermitAssessment]    Script Date: 12/05/2014 11:29:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormPermitAssessment](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToContractor] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Trade] [varchar](50) NULL,
	[CrewSize] [int] NOT NULL,
	[OilsandsWorkPermitType] [int] NOT NULL,
	[TotalScoredPercentage] decimal(5,2) NULL,
	[TotalAnswerScore] [INT] NULL,
	[TotalAnswerWeightedScore] [INT] NULL,
	[TotalQuestionnaireWeight] [INT] NULL,
	[JobDescription] Varchar(255) NULL,
	[OverallFeedback] Varchar(255) NULL,
	[LocationEquipmentNumber] Varchar(100) NULL,
	[JobCoordinator] Varchar(100) NULL,
	[QuestionnaireName] Varchar(100) NULL,
	[QuestionnaireVersion] [int] NOT NULL,
 CONSTRAINT [PK_FormPermitAssessment] PRIMARY KEY CLUSTERED 
(
[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormPermitAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessment_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessment] CHECK CONSTRAINT [FK_FormPermitAssessment_CreatedByUser]
GO

ALTER TABLE [dbo].[FormPermitAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessment_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessment] CHECK CONSTRAINT [FK_FormPermitAssessment_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormPermitAssessment] ADD  DEFAULT ((0)) FOR [Deleted]
GO





GO

