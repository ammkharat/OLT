  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteQuestionnaireConfigurationById')
	BEGIN
		DROP  Procedure  DeleteQuestionnaireConfigurationById
	END

GO

CREATE Procedure dbo.DeleteQuestionnaireConfigurationById(@QuestionnaireConfigurationId bigint)

AS

update QuestionnaireConfiguration
	set deleted = 1
	where Id = @QuestionnaireConfigurationId;

RETURN

GO    
GRANT EXEC ON DeleteQuestionnaireConfigurationById TO PUBLIC
GO