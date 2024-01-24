if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertQuestionnaireConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertQuestionnaireConfiguration]
GO

CREATE Procedure [dbo].[InsertQuestionnaireConfiguration]
    (
    @Id bigint Output,    
    @SiteId bigint,
	@Type varchar(50),
	@Name varchar(100),
	@Version int
    )
AS

INSERT INTO QuestionnaireConfiguration
(
	[SiteId],
	[Type],
	[Name],
	[Version],
	[Deleted]
)
VALUES
(
	@SiteId,
	@Type,
	@Name,
	@Version,
	0)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertQuestionnaireConfiguration TO PUBLIC
GO  