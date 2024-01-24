  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteQuestionsByQuestionnaireConfigurationId')
	BEGIN
		DROP  Procedure  DeleteQuestionsByQuestionnaireConfigurationId
	END

GO

CREATE Procedure dbo.DeleteQuestionsByQuestionnaireConfigurationId(@QuestionnaireConfigurationId bigint)
AS

delete from QuestionnaireSectionQuestion where QuestionnaireConfigurationId = @QuestionnaireConfigurationId;

  
RETURN

GO    
GRANT EXEC ON DeleteQuestionsByQuestionnaireConfigurationId TO PUBLIC
GO