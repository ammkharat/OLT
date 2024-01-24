IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormOP14Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormOP14Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormOP14Id(@FormOP14Id bigint)
AS
SELECT * FROM DocumentLink WHERE FormOP14Id = @FormOP14Id	and Deleted = 0	
and FormOP14Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormOP14Id] TO PUBLIC
GO