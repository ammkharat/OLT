IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryQuestionnaireConfigurationDtosBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryQuestionnaireConfigurationDtosBySiteId
	END
GO

CREATE Procedure dbo.QueryQuestionnaireConfigurationDtosBySiteId
	(
	@SiteId bigint
	)
AS

select id,name,[type],version from QuestionnaireConfiguration c
where c.SiteId = @SiteId
and c.Deleted = 0
GO

GRANT EXEC ON [QueryQuestionnaireConfigurationDtosBySiteId] TO PUBLIC
GO