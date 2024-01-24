IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAssessmentAnswersByPermitAssessmentId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAssessmentAnswersByPermitAssessmentId
	END
GO

CREATE Procedure dbo.QueryPermitAssessmentAnswersByPermitAssessmentId
	(
	@PermitAssessmentId bigint
	)
AS
SELECT 
	* 
FROM 
	PermitAssessmentAnswer 
WHERE PermitAssessmentId = @PermitAssessmentId 
ORDER BY SectionDisplayOrder, DisplayOrder
GO

GRANT EXEC ON [QueryPermitAssessmentAnswersByPermitAssessmentId] TO PUBLIC
GO