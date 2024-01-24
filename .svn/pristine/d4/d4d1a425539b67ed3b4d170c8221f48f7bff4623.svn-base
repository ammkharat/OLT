IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN59Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN59Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN59Id(@FormGN59Id bigint)
AS
SELECT * FROM DocumentLink WHERE FormGN59Id = @FormGN59Id	and Deleted = 0	
and FormGN59Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN59Id] TO PUBLIC
GO