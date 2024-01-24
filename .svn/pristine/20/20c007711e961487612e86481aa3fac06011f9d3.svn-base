SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[PermitAssessmentAnswer] (
	[Id] bigint IDENTITY(100, 1) NOT FOR REPLICATION NOT NULL,
	[PermitAssessmentId] bigint NOT NULL,
	[SectionId] bigint NOT NULL,
	[SectionName] varchar(100) NOT NULL,
	[SectionConfiguredPercentageWeighting] decimal(5, 2) NOT NULL,
	[SectionScoredPercentage] decimal(5, 2) NOT NULL,
	[QuestionId] bigint NOT NULL,
	[ConfiguredWeight] int NOT NULL,
	[QuestionText] varchar(150) NOT NULL,
	[SectionDisplayOrder] int NOT NULL,
	[DisplayOrder] int NOT NULL,
	[Score] int NOT NULL,
	[Comments] varchar(255) NULL,
	CONSTRAINT [FK_PermitAssessmentAnswer_Question]
	FOREIGN KEY ([QuestionId])
	REFERENCES [dbo].[QuestionnaireSectionQuestion] ( [Id] ),
	CONSTRAINT [FK_PermitAssessmentAnswer_PermitAssessment]
	FOREIGN KEY ([PermitAssessmentId])
	REFERENCES [dbo].[FormPermitAssessment] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[PermitAssessmentAnswer] SET (LOCK_ESCALATION = TABLE);
GO



GO

