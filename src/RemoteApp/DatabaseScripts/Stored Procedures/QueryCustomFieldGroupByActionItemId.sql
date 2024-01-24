IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupByActionItemId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldGroupByActionItemId
	END
GO


CREATE Procedure [dbo].[QueryCustomFieldGroupByActionItemId]
	(
		@ActionItemId bigint
	)
AS

SELECT cfg.* 
FROM ActionItemCustomFieldGroup Acfg
INNER JOIN CustomFieldGroup cfg on cfg.Id = Acfg.CustomFieldGroupId	
where Acfg.ActionItemId = @ActionItemId
