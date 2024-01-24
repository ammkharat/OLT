IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN75BUserReadDocumentLinkAssociation')
	BEGIN
		DROP  Procedure  InsertFormGN75BUserReadDocumentLinkAssociation
	END

GO

CREATE Procedure [dbo].[InsertFormGN75BUserReadDocumentLinkAssociation]
	(
	@FormGN75BId bigint,
	@UserId bigint	
	)
AS

INSERT INTO [FormGN75BUserReadDocumentLinkAssociation]
(
	FormGN75BId, 
	UserId
)
VALUES
(
	@FormGN75BId, 
	@UserId
)
GO

GRANT EXEC ON InsertFormGN75BUserReadDocumentLinkAssociation TO PUBLIC
GO


 