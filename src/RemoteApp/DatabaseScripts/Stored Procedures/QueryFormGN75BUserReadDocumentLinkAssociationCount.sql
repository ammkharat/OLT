IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75BUserReadDocumentLinkAssociationCount')
	BEGIN
		DROP  Procedure  QueryFormGN75BUserReadDocumentLinkAssociationCount
	END

GO

CREATE Procedure [dbo].QueryFormGN75BUserReadDocumentLinkAssociationCount
	(
		@UserId bigint,
		@FormGN75BId bigint
	)
AS

SELECT COUNT(assoc.FormGN75BId) as COUNT
FROM [dbo].[FormGN75BUserReadDocumentLinkAssociation] assoc
WHERE assoc.UserId = @UserId and assoc.FormGN75BId = @FormGN75BId
GO

GRANT EXEC ON QueryFormGN75BUserReadDocumentLinkAssociationCount TO PUBLIC
GO