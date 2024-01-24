  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteSummaryLogFunctionalLocationsBySummaryLogId')
	BEGIN
		DROP  Procedure  DeleteSummaryLogFunctionalLocationsBySummaryLogId
	END

GO

CREATE Procedure dbo.DeleteSummaryLogFunctionalLocationsBySummaryLogId
	(	
	@SummaryLogId bigint		
	)
AS
DELETE FROM SummaryLogFunctionalLocation WHERE SummaryLogId = @SummaryLogId

RETURN

GO   