IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormPermitAssessmentId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormPermitAssessmentId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormPermitAssessmentId(@PermitAssessmentId bigint)
AS
SELECT * FROM DocumentLink WHERE FormOilsandsPermitAssessmentId = @PermitAssessmentId	and Deleted = 0	
and FormOilsandsPermitAssessmentId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormPermitAssessmentId] TO PUBLIC
GO