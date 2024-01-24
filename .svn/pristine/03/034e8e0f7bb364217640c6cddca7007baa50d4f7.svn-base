IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUnrespondedToActionItemByActionItemDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryUnrespondedToActionItemByActionItemDefinitionId
	END
GO

CREATE Procedure [dbo].QueryUnrespondedToActionItemByActionItemDefinitionId(@ActionItemDefinitionId bigint)
AS

select * from ActionItem ai
where ai.Deleted = 0 
and ai.CreatedByActionItemDefinitionId = @ActionItemDefinitionId	
and ai.ActionItemStatusId = 0
and (not exists (select * from LogActionItemAssociation laia where ai.Id = laia.ActionItemId))
GO 

GRANT EXEC ON QueryUnrespondedToActionItemByActionItemDefinitionId TO PUBLIC
GO