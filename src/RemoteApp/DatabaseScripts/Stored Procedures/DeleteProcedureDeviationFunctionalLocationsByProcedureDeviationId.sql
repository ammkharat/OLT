IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteProcedureDeviationFunctionalLocationsByProcedureDeviationId')
BEGIN
	DROP Procedure DeleteProcedureDeviationFunctionalLocationsByProcedureDeviationId
END
GO

CREATE Procedure dbo.DeleteProcedureDeviationFunctionalLocationsByProcedureDeviationId
(
	@ProcedureDeviationId bigint
)
AS
DELETE FROM FormProcedureDeviationFunctionalLocation 
WHERE FormProcedureDeviationId = @ProcedureDeviationId

RETURN

GO   