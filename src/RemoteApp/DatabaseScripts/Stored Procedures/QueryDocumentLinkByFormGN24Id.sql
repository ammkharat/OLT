IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN24Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN24Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN24Id
	(
		@FormGN24Id bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN24Id = @FormGN24Id
	and Deleted = 0 
	and FormGN24Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN24Id] TO PUBLIC
GO