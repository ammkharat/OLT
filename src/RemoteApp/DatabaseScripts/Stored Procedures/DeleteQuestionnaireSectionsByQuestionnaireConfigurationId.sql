  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteQuestionnaireSectionsByQuestionnaireConfigurationId')
	BEGIN
		DROP  Procedure  DeleteQuestionnaireSectionsByQuestionnaireConfigurationId
	END

GO

CREATE Procedure dbo.DeleteQuestionnaireSectionsByQuestionnaireConfigurationId(@QuestionnaireConfigurationId bigint)
AS

delete from QuestionnaireSection where QuestionnaireConfigurationId = @QuestionnaireConfigurationId;

  
RETURN
GO    
GRANT EXEC ON DeleteQuestionnaireSectionsByQuestionnaireConfigurationId TO PUBLIC
GO