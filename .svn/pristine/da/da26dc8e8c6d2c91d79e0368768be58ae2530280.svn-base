if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertQuestionnaireSection]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertQuestionnaireSection]
GO

CREATE Procedure [dbo].[InsertQuestionnaireSection]
    (
	@Id bigint Output,    
  	@QuestionnaireConfigurationId bigint,
	@DisplayOrder int,
	@PercentageWeighting decimal(5,2),
	@Name varchar(100)
	
    )
AS

INSERT INTO QuestionnaireSection
(
	[QuestionnaireConfigurationId],
	[DisplayOrder],
	[PercentageWeighting],
	[Name]
)
VALUES
(
	@QuestionnaireConfigurationId,
	@DisplayOrder,
	@PercentageWeighting,
	@Name)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertQuestionnaireSection TO PUBLIC
GO  