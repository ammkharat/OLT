IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormPermitAssessmentFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormPermitAssessmentFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormPermitAssessmentFunctionalLocation]
	(
	@PermitAssessmentId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormPermitAssessmentFunctionalLocation]
	(
	[FormPermitAssessmentId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@PermitAssessmentId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormPermitAssessmentFunctionalLocation] TO PUBLIC
GO