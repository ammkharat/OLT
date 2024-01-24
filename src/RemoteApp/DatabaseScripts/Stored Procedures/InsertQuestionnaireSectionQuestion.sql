if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertQuestionnaireSectionQuestion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertQuestionnaireSectionQuestion]
GO

CREATE Procedure [dbo].[InsertQuestionnaireSectionQuestion]
    (
    @Id bigint Output,    
    @QuestionnaireConfigurationId bigint, 
    @QuestionnaireSectionId bigint,    
	@DisplayOrder int,
	@Weight int,
	@QuestionText varchar(150)
    )
AS

INSERT INTO QuestionnaireSectionQuestion
(
    [QuestionnaireConfigurationId],
    [QuestionnaireSectionId],
	[DisplayOrder],
	[Weight],
	[QuestionText]
	)
VALUES
(
    @QuestionnaireConfigurationId,
    @QuestionnaireSectionId,
	@DisplayOrder,
	@Weight,
	@QuestionText
)

SET @Id= SCOPE_IDENTITY() 

GO 
GRANT EXEC ON InsertQuestionnaireSectionQuestion TO PUBLIC
GO 