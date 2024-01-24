IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByDirectiveId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByDirectiveId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByDirectiveId(@DirectiveId bigint)
AS

SELECT * FROM DocumentLink WHERE DirectiveId = @DirectiveId and deleted = 0 and DirectiveId IS NOT NULL 
GO

GRANT EXEC ON [QueryDocumentLinkByDirectiveId] TO PUBLIC
GO