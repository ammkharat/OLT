IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByTargetDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByTargetDefinitionId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByTargetDefinitionId
	(
		@TargetDefinitionId BIGINT
	)

AS
SELECT  
	*
FROM
	DocumentLink
WHERE	
	TargetDefinitionId = @TargetDefinitionId 
	and Deleted = 0 and TargetDefinitionId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByTargetDefinitionId] TO PUBLIC
GO