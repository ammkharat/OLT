  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateDisplayLimits')
	BEGIN
		DROP  Procedure  UpdateDisplayLimits
	END

GO

CREATE Procedure [dbo].[UpdateDisplayLimits]
	(
		@SiteId bigint,
		@DaysToDisplayActionItems int,
		@DaysToDisplayShiftLogs int,
		@DaysToDisplayShiftHandovers int,
		@DaysToDisplayDeviationAlerts int,
		@DaysToDisplayWorkPermitsBackwards int,
		@DaysToDisplayWorkPermitsForwards int = NULL,
		@DaysToDisplayLabAlerts int,
		@DaysToDisplayCokerCards int,
		@DaysToDisplayPermitRequestsBackwards int,
		@DaysToDisplayPermitRequestsForwards int,
		@DaysToDisplayElectronicFormsBackwards int,
		@DaysToDisplayElectronicFormsForwards int = NULL,
		@DaysToDisplayDirectivesBackwards int,
		@DaysToDisplayDirectivesForwards int = NULL,
		@DaysToDisplaySAPNotificationsBackwards int,
		@DaysToDisplayEventsBackwards int = Null,
		@DaysToDisplayDocumentSuggestionFormsBackwards int,
		@DaysToDisplayDocumentSuggestionFormsForwards int
		)	
AS
 
 UPDATE    
	SiteConfiguration
 SET
		DaysToDisplayActionItems = @DaysToDisplayActionItems,
		DaysToDisplayShiftLogs = @DaysToDisplayShiftLogs,
		DaysToDisplayShiftHandovers = @DaysToDisplayShiftHandovers,
		DaysToDisplayDeviationAlerts = @DaysToDisplayDeviationAlerts,                
		DaysToDisplayWorkPermitsBackwards = @DaysToDisplayWorkPermitsBackwards,
		DaysToDisplayWorkPermitsForwards = @DaysToDisplayWorkPermitsForwards,
		DaysToDisplayLabAlerts = @DaysToDisplayLabAlerts,
		DaysToDisplayCokerCards = @DaysToDisplayCokerCards,
		DaysToDisplayPermitRequestsBackwards = @DaysToDisplayPermitRequestsBackwards,
		DaysToDisplayPermitRequestsForwards = @DaysToDisplayPermitRequestsForwards,
		DaysToDisplayFormsBackwards = @DaysToDisplayElectronicFormsBackwards,
		DaysToDisplayFormsForwards = @DaysToDisplayElectronicFormsForwards,
		DaysToDisplaySAPNotificationsBackwards = @DaysToDisplaySAPNotificationsBackwards,
		DaysToDisplayDirectivesBackwards = @DaysToDisplayDirectivesBackwards,
		DaysToDisplayDirectivesForwards = @DaysToDisplayDirectivesForwards,
		DaysToDisplayEventsBackwards = @DaysToDisplayEventsBackwards,
		DaysToDisplayDocumentSuggestionFormsBackwards = @DaysToDisplayDocumentSuggestionFormsBackwards,
		DaysToDisplayDocumentSuggestionFormsForwards = @DaysToDisplayDocumentSuggestionFormsForwards
WHERE  
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateDisplayLimits TO PUBLIC

GO