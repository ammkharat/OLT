IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteProcedureDeviationCauseDeterminationCausesByProcedureDeviationId')
BEGIN
	DROP Procedure DeleteProcedureDeviationCauseDeterminationCausesByProcedureDeviationId
END
GO

CREATE Procedure dbo.DeleteProcedureDeviationCauseDeterminationCausesByProcedureDeviationId
(
	@ProcedureDeviationId bigint
)
AS
DELETE FROM FormProcedureDeviationCauseDetermination 
WHERE FormProcedureDeviationId = @ProcedureDeviationId

RETURN

GO   