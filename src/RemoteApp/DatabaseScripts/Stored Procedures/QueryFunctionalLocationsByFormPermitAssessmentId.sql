IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormPermitAssessmentId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormPermitAssessmentId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormPermitAssessmentId
(
    @PermitAssessmentId bigint
)
AS

SELECT fl.* 
FROM 
	FormPermitAssessmentFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormPermitAssessmentId = @PermitAssessmentId
GO

GRANT EXEC ON QueryFunctionalLocationsByFormPermitAssessmentId TO PUBLIC
GO