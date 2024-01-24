SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[PermitAssessmentAnswer] 
ADD  PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY]
GO
CREATE TABLE [dbo].[PermitAssessmentHistory] (
[PermitAssessmentHistoryId] bigint IDENTITY(100, 1) NOT FOR REPLICATION NOT NULL,
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[FunctionalLocations] varchar(MAX) NOT NULL,
[DocumentLinks] varchar(MAX) NULL,
[ValidFromDateTime] datetime NOT NULL,
[ValidToDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[IssuedToSuncor] bit NOT NULL,
[IssuedToContractor] bit NOT NULL,
[CrewSize] int NOT NULL,
[OilsandsWorkPermitType] int NOT NULL,
[TotalScoredPercentage] decimal(5, 2) NULL,
[TotalAnswerScore] int NULL,
[TotalAnswerWeightedScore] int NULL,
[TotalQuestionnaireWeight] int NULL,
[JobDescription] varchar(255) NULL,
[OverallFeedback] varchar(255) NULL,
[LocationEquipmentNumber] varchar(100) NULL,
[JobCoordinator] varchar(100) NULL,
[PermitNumber] varchar(10) NOT NULL,
[contractor] varchar(100) NULL,
[IsIlpRecommended] bit NULL,
[Trade] varchar(100) NOT NULL
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[PermitAssessmentHistory] SET (LOCK_ESCALATION = TABLE);
GO

CREATE TABLE [dbo].[PermitAssessmentAnswerHistory] (
[Id] bigint NOT NULL,
[PermitAssessmentHistoryId] bigint NOT NULL,
[PermitAssessmentAnswerId] bigint NOT NULL,
[SectionScoredPercentage] decimal(5, 2) NOT NULL,
[Score] int NOT NULL,
[Comments] varchar(255) NULL,
CONSTRAINT [FK_PermitAssessmentAnswerHistory_PermitAssessmentAnswerId]
FOREIGN KEY ([PermitAssessmentAnswerId])
REFERENCES [dbo].[PermitAssessmentAnswer] ( [Id] )
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO
ALTER TABLE [dbo].[PermitAssessmentAnswerHistory] SET (LOCK_ESCALATION = TABLE);
GO






GO

