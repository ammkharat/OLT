IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertSummaryLogFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertSummaryLogFunctionalLocation]
	(
	@SummaryLogId bigint,
	@FunctionalLocationId bigint	
	)
AS
							
INSERT INTO 
	[SummaryLogFunctionalLocation]
	(
	[SummaryLogId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@SummaryLogId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertSummaryLogFunctionalLocation] TO PUBLIC
GO