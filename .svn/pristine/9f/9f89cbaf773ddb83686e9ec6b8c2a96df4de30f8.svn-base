  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteOilsandPermitAssessmentFunctionalLocationsByOilsandPermitAssessmentId')
	BEGIN
		DROP Procedure DeleteOilsandPermitAssessmentFunctionalLocationsByOilsandPermitAssessmentId
	END

GO

CREATE Procedure dbo.DeleteOilsandPermitAssessmentFunctionalLocationsByOilsandPermitAssessmentId(@PermitAssessmentId bigint)
AS
DELETE FROM FormPermitAssessmentFunctionalLocation WHERE FormPermitAssessmentId = @PermitAssessmentId

RETURN

GO   