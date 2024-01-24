IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByTargetAlertId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByTargetAlertId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByTargetAlertId
	(
		@TargetAlertId BIGINT
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	TargetAlertId = @TargetAlertId 
	and Deleted = 0
	and TargetAlertId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByTargetAlertId] TO PUBLIC
GO