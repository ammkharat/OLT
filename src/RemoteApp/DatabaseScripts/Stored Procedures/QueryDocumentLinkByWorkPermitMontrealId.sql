IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByWorkPermitMontrealId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByWorkPermitMontrealId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByWorkPermitMontrealId
	(
		@WorkPermitMontrealId bigint
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	WorkPermitMontrealId = @WorkPermitMontrealId
	and Deleted = 0
	and WorkPermitMontrealId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByWorkPermitMontrealId] TO PUBLIC
GO