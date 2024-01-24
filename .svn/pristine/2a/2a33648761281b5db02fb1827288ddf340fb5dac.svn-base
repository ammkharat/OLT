IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByWorkPermitId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByWorkPermitId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByWorkPermitId

	(
		@WorkPermitid [bigint]
	)
AS

SELECT
	*
FROM
	[DocumentLink] 
WHERE 
	WorkPermitID = @WorkPermitid 
	and deleted = 0
	and WorkPermitID IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON QueryDocumentLinkByWorkPermitId TO PUBLIC
GO