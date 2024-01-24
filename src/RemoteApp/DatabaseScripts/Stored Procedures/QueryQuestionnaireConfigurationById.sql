IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryQuestionnaireConfigurationById')
	BEGIN
		DROP PROCEDURE [dbo].QueryQuestionnaireConfigurationById
	END
GO

CREATE Procedure dbo.QueryQuestionnaireConfigurationById
	(
	@Id bigint
	)
AS

SELECT * 
FROM 
	QuestionnaireConfiguration
WHERE 
	[Id] = @Id 
GO

GRANT EXEC ON QueryQuestionnaireConfigurationById TO PUBLIC
GO