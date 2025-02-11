
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia')
	BEGIN
		DROP Procedure [dbo].InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia
	END
GO

Create Procedure [dbo].[InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia]
	(
	@FormGN75BTemplateId bigint,
	@UserId bigint	
	)
AS

INSERT INTO [FormGN75BUserReadDocumentLinkAssociationTemplateSarnia]
(
	FormGN75BTemplateId, 
	UserId
)
VALUES
(
	@FormGN75BTemplateId, 
	@UserId
)



GRANT EXEC ON InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia TO PUBLIC
GO
