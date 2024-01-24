IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertProcedureDeviationFunctionalLocation')
	BEGIN
		DROP Procedure InsertProcedureDeviationFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertProcedureDeviationFunctionalLocation]
(
	@ProcedureDeviationId bigint,
	@FunctionalLocationId bigint	
)
AS

INSERT INTO [FormProcedureDeviationFunctionalLocation]
(	
	[FormProcedureDeviationId],
	[FunctionalLocationId]
)
VALUES
(	
	@ProcedureDeviationId,
	@FunctionalLocationId	
)
	
GRANT EXEC ON [InsertProcedureDeviationFunctionalLocation] TO PUBLIC
GO