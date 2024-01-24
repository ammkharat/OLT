IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemByActionItemDefinitionAndStatusAfterCurrentTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemByActionItemDefinitionAndStatusAfterCurrentTime
	END
GO

CREATE Procedure [dbo].QueryActionItemByActionItemDefinitionAndStatusAfterCurrentTime
	(	
		@ActionItemDefinitionId bigint,
		@Status int,
		@CurrentTimeAtSite datetime,
		@StartDateTimeMustBeAfterCurrentTime bit			
	)
AS

select 
	*
from 
	ActionItem 
where 
	Deleted = 0 	
	and	CreatedByActionItemDefinitionId = @ActionItemDefinitionId 
	and	ActionItemStatusId = @Status
	and (ShiftAdjustedEndDateTime is null or ShiftAdjustedEndDateTime > @CurrentTimeAtSite) 
	and (@StartDateTimeMustBeAfterCurrentTime = 0 or StartDateTime > @CurrentTimeAtSite)
GO 

GRANT EXEC ON QueryActionItemByActionItemDefinitionAndStatusAfterCurrentTime TO PUBLIC
GO