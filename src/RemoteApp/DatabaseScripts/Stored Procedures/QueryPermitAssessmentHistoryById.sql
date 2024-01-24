IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAssessmentHistoryById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAssessmentHistoryById
	END
GO

CREATE Procedure [dbo].QueryPermitAssessmentHistoryById
(
	@Id bigint
)
AS

SELECT * 
FROM 
	PermitAssessmentHistory 
WHERE 
	Id=@Id 
ORDER BY 
	LastModifiedDateTime
GO

GRANT EXEC ON QueryPermitAssessmentHistoryById TO PUBLIC
GO