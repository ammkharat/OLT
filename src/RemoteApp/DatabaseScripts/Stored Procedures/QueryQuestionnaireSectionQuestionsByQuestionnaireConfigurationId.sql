IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryQuestionnaireSectionQuestionsByQuestionnaireConfigurationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryQuestionnaireSectionQuestionsByQuestionnaireConfigurationId
	END
GO

CREATE Procedure dbo.QueryQuestionnaireSectionQuestionsByQuestionnaireConfigurationId
	(
	@QuestionnaireConfigurationId bigint
	)
AS

SELECT * 
FROM 
	QuestionnaireSectionQuestion
WHERE 
	[QuestionnaireConfigurationId] = @QuestionnaireConfigurationId 
GO

GRANT EXEC ON QueryQuestionnaireSectionQuestionsByQuestionnaireConfigurationId TO PUBLIC
GO