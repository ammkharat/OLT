IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkById')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkById
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkById
	(
		@id [bigint]
	)
AS

SELECT
	*
FROM
	[DocumentLink] 
WHERE 
	ID = @id
GO

GRANT EXEC ON QueryDocumentLinkById TO PUBLIC
GO