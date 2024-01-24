IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertProcedureDeviationCauseDetermination')
	BEGIN
		DROP Procedure InsertProcedureDeviationCauseDetermination
	END

GO

CREATE Procedure [dbo].[InsertProcedureDeviationCauseDetermination]
(
	@ProcedureDeviationId bigint,
	@CauseDeterminationTypeId bigint	
)
AS

INSERT INTO [FormProcedureDeviationCauseDetermination]
(	
	[FormProcedureDeviationId],
	[CauseDeterminationTypeId]
)
VALUES
(	
	@ProcedureDeviationId,
	@CauseDeterminationTypeId	
)
	
GRANT EXEC ON [InsertProcedureDeviationCauseDetermination] TO PUBLIC
GO