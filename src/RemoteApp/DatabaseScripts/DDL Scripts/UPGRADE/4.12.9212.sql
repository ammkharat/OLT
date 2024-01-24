CREATE TABLE [dbo].[ShiftHandoverQuestionnaireLog] (
[ShiftHandoverQuestionnaireId] bigint NOT NULL,
[LogId] bigint NOT NULL,
CONSTRAINT [PK_ShiftHandoverQuestionnaireLog]
PRIMARY KEY CLUSTERED ([ShiftHandoverQuestionnaireId] ASC, [LogId] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 95,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log]
FOREIGN KEY ([LogId])
REFERENCES [dbo].[Log] ( [Id] ),
CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]
FOREIGN KEY ([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ( [Id] )
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog] (
[ShiftHandoverQuestionnaireId] bigint NOT NULL,
[SummaryLogId] bigint NOT NULL,
CONSTRAINT [PK_ShiftHandoverQuestionnaireSummaryLog]
PRIMARY KEY CLUSTERED ([ShiftHandoverQuestionnaireId] ASC, [SummaryLogId] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 95,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_SummaryLog]
FOREIGN KEY ([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ( [Id] ),
CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_ShiftHandover]
FOREIGN KEY ([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ( [Id] )
)
ON [PRIMARY];
GO


GO

