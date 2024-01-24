IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormProcedureDeviationId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormProcedureDeviationId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormProcedureDeviationId
(
    @ProcedureDeviationId bigint
)
AS

SELECT fl.* 
FROM 
	FormProcedureDeviationFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormProcedureDeviationId = @ProcedureDeviationId
GO

GRANT EXEC ON QueryFunctionalLocationsByFormProcedureDeviationId TO PUBLIC
GO