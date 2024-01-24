IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByPermitRequestMontrealId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByPermitRequestMontrealId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByPermitRequestMontrealId
	(
		@PermitRequestMontrealId bigint
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	PermitRequestMontrealId = @PermitRequestMontrealId 
	and Deleted = 0
	and PermitRequestMontrealId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByPermitRequestMontrealId] TO PUBLIC
GO