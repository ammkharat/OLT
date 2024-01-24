  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteDeviationAlertResponseReasonCodeAssignmentsByResponseId')
	BEGIN
		DROP  Procedure  DeleteDeviationAlertResponseReasonCodeAssignmentsByResponseId
	END

GO

CREATE Procedure dbo.DeleteDeviationAlertResponseReasonCodeAssignmentsByResponseId
	(	
	@ResponseId bigint		
	)
AS
DELETE FROM DeviationAlertResponseReasonCodeAssignment WHERE DeviationAlertResponseId = @ResponseId

RETURN

GO   