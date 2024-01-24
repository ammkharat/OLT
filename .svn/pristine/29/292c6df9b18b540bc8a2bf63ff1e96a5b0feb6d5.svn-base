IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByWorkPermitEdmontonId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByWorkPermitEdmontonId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByWorkPermitEdmontonId
	(
		@WorkPermitEdmontonId bigint
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	WorkPermitEdmontonId = @WorkPermitEdmontonId 
	and Deleted = 0
	and WorkPermitEdmontonId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByWorkPermitEdmontonId] TO PUBLIC
GO