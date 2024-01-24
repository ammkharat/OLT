IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryProcedureDeviationCauseDeterminationByProcedureDeviationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryProcedureDeviationCauseDeterminationByProcedureDeviationId
	END

GO

CREATE Procedure [dbo].QueryProcedureDeviationCauseDeterminationByProcedureDeviationId
(
	@ProcedureDeviationId bigint
)
AS

SELECT
    cause.*
FROM
    FormProcedureDeviationCauseDetermination cause
WHERE
    cause.FormProcedureDeviationId = @ProcedureDeviationId
GO

GRANT EXEC ON QueryProcedureDeviationCauseDeterminationByProcedureDeviationId TO PUBLIC
GO


  