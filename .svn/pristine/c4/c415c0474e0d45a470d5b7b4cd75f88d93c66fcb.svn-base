IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryProcedureDeviationHistoryById')
	BEGIN
		DROP PROCEDURE [dbo].QueryProcedureDeviationHistoryById
	END
GO

CREATE Procedure [dbo].QueryProcedureDeviationHistoryById
(
	@Id bigint
)
AS

SELECT * 
FROM 
	FormProcedureDeviationHistory 
WHERE 
	Id=@Id 
ORDER BY 
	LastModifiedDateTime
GO

GO
GRANT EXEC ON QueryProcedureDeviationHistoryById TO PUBLIC