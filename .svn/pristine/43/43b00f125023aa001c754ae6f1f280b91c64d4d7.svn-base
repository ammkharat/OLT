IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormProcedureDeviationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormProcedureDeviationId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormProcedureDeviationId
(
	@FormProcedureDeviationId bigint
)
AS
SELECT * FROM DocumentLink 
WHERE FormProcedureDeviationId = @FormProcedureDeviationId	and Deleted = 0	
and FormProcedureDeviationId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormProcedureDeviationId] TO PUBLIC
GO