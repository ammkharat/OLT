CREATE TABLE [dbo].[ShiftHandoverQuestionnaireRead](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
CONSTRAINT [PK_ShiftHandoverQuestionnaireRead] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[UserId] ASC
))
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead] ADD CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire] 
FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead] ADD CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_User] 
FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

GO
