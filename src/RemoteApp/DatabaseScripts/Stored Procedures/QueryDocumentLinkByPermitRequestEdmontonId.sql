IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByPermitRequestEdmontonId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByPermitRequestEdmontonId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByPermitRequestEdmontonId
	(
		@PermitRequestEdmontonId bigint
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	PermitRequestEdmontonId = @PermitRequestEdmontonId 
	and Deleted = 0
	and PermitRequestEdmontonId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByPermitRequestEdmontonId] TO PUBLIC
GO