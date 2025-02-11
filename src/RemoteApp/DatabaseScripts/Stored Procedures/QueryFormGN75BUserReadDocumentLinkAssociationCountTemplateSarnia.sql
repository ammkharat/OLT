
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75BUserReadDocumentLinkAssociationCountTemplateSarnia')
	BEGIN
		DROP Procedure [dbo].QueryFormGN75BUserReadDocumentLinkAssociationCountTemplateSarnia
	END
GO

Create Procedure [dbo].[QueryFormGN75BUserReadDocumentLinkAssociationCountTemplateSarnia]
	(
		@UserId bigint,
		@FormGN75BTemplateId bigint
	)
AS

SELECT COUNT(assoc.FormGN75BTemplateId) as COUNT
FROM [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia] assoc
WHERE assoc.UserId = @UserId and assoc.FormGN75BTemplateId = @FormGN75BTemplateId



GRANT EXEC ON QueryFormGN75BUserReadDocumentLinkAssociationCountTemplateSarnia TO PUBLIC
GO
