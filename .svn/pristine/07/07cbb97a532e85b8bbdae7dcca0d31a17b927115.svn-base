CREATE TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[CokerCardConfigurationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireCokerCardConfiguration] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[CokerCardConfigurationId] ASC
)
)

GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]
ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_CokerCardConfigurationId] 
FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])

GO


ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]
ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_ShiftHandoverQuestionnaire] 
FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])

GO
GO
