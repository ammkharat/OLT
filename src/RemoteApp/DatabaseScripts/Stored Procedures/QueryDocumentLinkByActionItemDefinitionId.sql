IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByActionItemDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByActionItemDefinitionId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByActionItemDefinitionId
	(
		@ActionItemDefinitionid [bigint]
	)
AS

SELECT 
	*
FROM         
	[DocumentLink] 
WHERE 
	ActionItemDefinitionID = @ActionItemDefinitionid 
	and deleted = 0 
	and ActionItemDefinitionID IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON QueryDocumentLinkByActionItemDefinitionId TO PUBLIC
GO