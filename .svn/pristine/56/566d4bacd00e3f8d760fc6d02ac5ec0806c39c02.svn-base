IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByOvertimeFormId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByOvertimeFormId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByOvertimeFormId
	(
		@OvertimeFormId bigint
	)

AS
SELECT * FROM DocumentLink WHERE OvertimeFormId = @OvertimeFormId
	and Deleted = 0 
	and OvertimeFormId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByOvertimeFormId] TO PUBLIC
GO