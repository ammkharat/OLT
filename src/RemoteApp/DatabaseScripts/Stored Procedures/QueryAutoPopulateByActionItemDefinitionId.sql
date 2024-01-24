IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAutoPopulateByActionItemDefinitionId')
	BEGIN
		DROP  Procedure  QueryAutoPopulateByActionItemDefinitionId
	END

GO
CREATE Procedure [dbo].[QueryAutoPopulateByActionItemDefinitionId]
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT aidcg.AutoPopulate from ActionItemDefinitionCustomFieldGroup Aidcg where Aidcg.ActionItemDefinitionId = @ActionItemDefinitionId


