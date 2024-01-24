  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateQuestionnaireConfiguration')
	BEGIN
		DROP  Procedure  UpdateQuestionnaireConfiguration
	END

GO

CREATE Procedure [dbo].[UpdateQuestionnaireConfiguration]
	(
	@Id bigint,
	@Name varchar(100),	
	@Version int	
	)
AS

UPDATE [QuestionnaireConfiguration]
SET              
	Name = @Name,
	Version = @Version
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateQuestionnaireConfiguration TO PUBLIC

GO
