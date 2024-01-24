  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateActionItemSettings')
	BEGIN
		DROP  Procedure UpdateActionItemSettings
	END

GO

CREATE Procedure [dbo].[UpdateActionItemSettings]
	(
		@SiteId BIGINT,
		@AutoApproveWorkOrderActionItemDefinition BIT,
		@AutoApproveSAPAMActionItemDefinition BIT,
		@AutoApproveSAPMCActionItemDefinition BIT,
		@RequireActionItemResponseLog BIT,
		@ActionItemRequiresApprovalDefaultValue BIT,
		@ActionItemRequiresResponseDefaultValue BIT
	)
AS

UPDATE
	SiteConfiguration
SET 
	AutoApproveWorkOrderActionItemDefinition = @AutoApproveWorkOrderActionItemDefinition,
	AutoApproveSAPAMActionItemDefinition = @AutoApproveSAPAMActionItemDefinition,
	AutoApproveSAPMCActionItemDefinition = @AutoApproveSAPMCActionItemDefinition,
	RequireActionItemResponseLog = @RequireActionItemResponseLog,
	ActionItemRequiresApprovalDefaultValue = @ActionItemRequiresApprovalDefaultValue,
	ActionItemRequiresResponseDefaultValue = @ActionItemRequiresResponseDefaultValue
WHERE
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateActionItemSettings TO PUBLIC

GO


 