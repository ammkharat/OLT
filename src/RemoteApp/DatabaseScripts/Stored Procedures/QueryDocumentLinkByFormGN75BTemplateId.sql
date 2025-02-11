
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormGN75BTemplateId')
	BEGIN
		DROP Procedure [dbo].QueryDocumentLinkByFormGN75BTemplateId
	END
GO

Create Procedure [dbo].[QueryDocumentLinkByFormGN75BTemplateId]
	(
		@FormGN75BTemplateId bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN75BTemplateId = @FormGN75BTemplateId
	and Deleted = 0 
	and FormGN75BTemplateId IS NOT NULL -- this is here to force the use of a Filtered index on the table


GRANT EXEC ON QueryDocumentLinkByFormGN75BTemplateId TO PUBLIC
GO
