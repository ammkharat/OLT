  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteRestrictionLocationItemReasonCodesByItemId')
	BEGIN
		DROP  Procedure  DeleteRestrictionLocationItemReasonCodesByItemId
	END

GO

CREATE Procedure dbo.DeleteRestrictionLocationItemReasonCodesByItemId
	(	
	@RestrictionLocationItemId bigint
	)
AS
DELETE FROM RestrictionLocationItemReasonCode WHERE RestrictionLocationItemId = @RestrictionLocationItemId

RETURN

GO   