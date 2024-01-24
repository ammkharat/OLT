IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN1Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN1Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN1Id(@FormGN1Id bigint)
AS
SELECT * FROM DocumentLink WHERE FormGN1Id = @FormGN1Id	and Deleted = 0	
and FormGN1Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN1Id] TO PUBLIC
GO