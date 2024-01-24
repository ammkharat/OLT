IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed')
	BEGIN
		DROP  Procedure  UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed
	END

GO

CREATE Procedure [dbo].UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed
(@SiteId bigint,
 @CurrentDateTimeAtSite datetime,
 @NewStatusId bigint,
 @StatusModifiedUserId bigint)
AS

UPDATE [ActionItem]
SET [PreviousActionItemStatusId] = [ActionItemStatusId],
	[ActionItemStatusId] = @NewStatusId,
	[StatusModifiedUserId] = @StatusModifiedUserId,
	[StatusModifiedDateTime] = @CurrentDateTimeAtSite
WHERE Deleted = 0
	  AND ResponseRequired = 0 
      AND ShiftAdjustedEndDateTime is not null 
      AND ShiftAdjustedEndDateTime <= @CurrentDateTimeAtSite
      AND EXISTS (
				SELECT FunctionalLocation.Id 
				FROM ActionItemFunctionalLocation,
				FunctionalLocation 
				where ActionItemFunctionalLocation.ActionItemId = ActionItem.Id
				and FunctionalLocation.Id = ActionItemFunctionalLocation.FunctionalLocationID 
				and functionallocation.siteid = @SiteId
				 )
	  AND [ActionItemStatusId] <> @NewStatusId 

GO


GRANT EXEC ON UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed TO PUBLIC

GO