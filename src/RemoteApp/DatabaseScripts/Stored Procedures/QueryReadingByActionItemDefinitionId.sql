IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryReadingByActionItemDefinitionId')  
 BEGIN  
  DROP PROCEDURE [dbo].QueryReadingByActionItemDefinitionId  
 END  
GO  
  
CREATE Procedure [dbo].[QueryReadingByActionItemDefinitionId]
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT aidcg.Reading from ActionItemDefinitionCustomFieldGroup Aidcg where Aidcg.ActionItemDefinitionId = @ActionItemDefinitionId

