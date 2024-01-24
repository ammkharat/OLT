IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryQuestionnaireSectionsByQuestionnaireConfigurationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryQuestionnaireSectionsByQuestionnaireConfigurationId
	END
GO

CREATE Procedure dbo.QueryQuestionnaireSectionsByQuestionnaireConfigurationId
	(
	@QuestionnaireConfigurationId bigint
	)
AS

SELECT * 
FROM 
	QuestionnaireSection
WHERE 
	[QuestionnaireConfigurationId] = @QuestionnaireConfigurationId 
GO

GRANT EXEC ON QueryQuestionnaireSectionsByQuestionnaireConfigurationId TO PUBLIC
GO