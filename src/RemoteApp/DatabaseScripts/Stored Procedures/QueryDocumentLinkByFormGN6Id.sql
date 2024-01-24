IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN6Id')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN6Id
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN6Id
	(
		@FormGN6Id bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN6Id = @FormGN6Id
	and Deleted = 0 
	and FormGN6Id IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN6Id] TO PUBLIC
GO