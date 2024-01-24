IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN75BId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN75BId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN75BId
	(
		@FormGN75BId bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN75BId = @FormGN75BId
	and Deleted = 0 
	and FormGN75BId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN75BId] TO PUBLIC
GO