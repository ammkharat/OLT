IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByActionItemId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByActionItemId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByActionItemId
	(
		@ActionItemId [bigint]
	)
AS

	SELECT
		*
	FROM
		[DocumentLink] 
	WHERE
		ActionItemId = @ActionItemId 
		and deleted = 0
		and ActionItemId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON QueryDocumentLinkByActionItemId TO PUBLIC
GO