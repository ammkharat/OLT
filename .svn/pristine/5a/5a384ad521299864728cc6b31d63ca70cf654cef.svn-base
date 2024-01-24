IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfigurationPriorityPageConfiguration')
	BEGIN
		DROP  Procedure  UpdateSiteConfigurationPriorityPageConfiguration
	END

GO

CREATE Procedure [dbo].[UpdateSiteConfigurationPriorityPageConfiguration]
	(
		@SiteId bigint,
		@UseNewPriorityPage bit,
		@ShowActionItemsByWorkAssignmentOnPriorityPage bit,
		@ShowShiftHandoversByWorkAssignmentOnPriorityPage bit,
		@DaysToDisplayDirectivesOnPriorityPage int,
		@DaysToDisplayShiftHandoversOnPriorityPage int,
		@DisplayActionItemWorkAssignmentOnPriorityPage bit,
		@DaysToDisplayFormsBackwardsOnPriorityPage int,
		@DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage int = NULL,
		@MaximumAllowableExcursionEventDurationMins int,
		@MaximumAllowableExcursionEventTimeframeMins int,
		@DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage int
	)
AS
 
 UPDATE    
   SiteConfiguration
 SET
   UseNewPriorityPage = @UseNewPriorityPage,
   ShowActionItemsByWorkAssignmentOnPriorityPage = @ShowActionItemsByWorkAssignmentOnPriorityPage,
   ShowShiftHandoversByWorkAssignmentOnPriorityPage = @ShowShiftHandoversByWorkAssignmentOnPriorityPage,
   DaysToDisplayDirectivesOnPriorityPage = @DaysToDisplayDirectivesOnPriorityPage,
   DaysToDisplayShiftHandoversOnPriorityPage = @DaysToDisplayShiftHandoversOnPriorityPage,
   DisplayActionItemWorkAssignmentOnPriorityPage = @DisplayActionItemWorkAssignmentOnPriorityPage,
   DaysToDisplayFormsBackwardsOnPriorityPage = @DaysToDisplayFormsBackwardsOnPriorityPage,
   DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage = @DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
	 MaximumAllowableExcursionEventDurationMins = @MaximumAllowableExcursionEventDurationMins,
	 MaximumAllowableExcursionEventTimeframeMins = @MaximumAllowableExcursionEventTimeframeMins,
	 DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage = @DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage
WHERE  
	SiteId = @SiteId
GO