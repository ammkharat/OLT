CREATE TABLE [dbo].[ShiftHandoverQuestionnaireHistory](
	[ShiftHandoverQuestionnaireHistoryId] [bigint] IDENTITY(100,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[FunctionalLocations] varchar(max) not null,
	[LastModifiedByUserId] bigint NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL

	CONSTRAINT [PK_ShiftHandoverQuestionnaireHistory] PRIMARY KEY ([ShiftHandoverQuestionnaireHistoryId] ASC)		
)

CREATE INDEX [IDX_ShiftHandoverQuestionnaireHistory_Id] 
ON [dbo].[ShiftHandoverQuestionnaireHistory] 
(
	[Id] ASC
)

CREATE TABLE [dbo].[ShiftHandoverAnswerHistory](
	[ShiftHandoverQuestionnaireHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[QuestionText] varchar(512) NOT NULL,
	[Answer] bit NOT NULL,
	[Comments] varchar(512) NOT NULL
)

ALTER TABLE [ShiftHandoverAnswerHistory]
ADD CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionnaireHistory] 
FOREIGN KEY([ShiftHandoverQuestionnaireHistoryId])
REFERENCES [ShiftHandoverQuestionnaireHistory] ([ShiftHandoverQuestionnaireHistoryId])

GO
GO
