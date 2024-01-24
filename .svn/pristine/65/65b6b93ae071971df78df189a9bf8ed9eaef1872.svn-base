if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BUserReadDocumentLinkAssociationCountSarnia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BUserReadDocumentLinkAssociationCountSarnia]
GO
Create Procedure [dbo].[QueryFormGN75BUserReadDocumentLinkAssociationCountSarnia]
	(
		@UserId bigint,
		@FormGN75BSarniaId bigint
	)
AS

SELECT COUNT(assoc.FormGN75BSarniaId) as COUNT
FROM [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia] assoc
WHERE assoc.UserId = @UserId and assoc.FormGN75BSarniaId = @FormGN75BSarniaId
