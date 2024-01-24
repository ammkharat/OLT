IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN75AId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormGN75AId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormGN75AId
	(
		@FormGN75AId bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN75AId = @FormGN75AId	
	and Deleted = 0
	and FormGN75AId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormGN75AId] TO PUBLIC
GO