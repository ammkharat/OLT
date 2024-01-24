SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[FormPermitAssessment] ADD [QuestionnaireId] bigint NOT NULL
GO
ALTER TABLE [dbo].[FormPermitAssessment] ADD
	CONSTRAINT [FK_FormPermitAssessment_QuestionnaireConfiguration]
	FOREIGN KEY ([QuestionnaireId])
	REFERENCES [dbo].[QuestionnaireConfiguration] ( [Id] )
GO


GO

