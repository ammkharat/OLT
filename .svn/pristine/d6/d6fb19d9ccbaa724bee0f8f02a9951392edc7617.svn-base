IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN7Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN7Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN7Id(@FormGN7Id bigint)
AS
SELECT * FROM DocumentLink WHERE FormGN7Id = @FormGN7Id	and Deleted = 0	
and FormGN7Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN7Id] TO PUBLIC
GO