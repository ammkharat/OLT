IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByWorkPermitLubesId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByWorkPermitLubesId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByWorkPermitLubesId
	(
		@WorkPermitLubesId bigint
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	WorkPermitLubesId = @WorkPermitLubesId
	and Deleted = 0
	and WorkPermitLubesId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByWorkPermitLubesId] TO PUBLIC
GO