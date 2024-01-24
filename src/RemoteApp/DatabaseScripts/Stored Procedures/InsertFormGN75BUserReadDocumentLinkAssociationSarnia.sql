if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75BUserReadDocumentLinkAssociationSarnia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75BUserReadDocumentLinkAssociationSarnia]
GO

create Procedure [dbo].[InsertFormGN75BUserReadDocumentLinkAssociationSarnia]
	(
	@FormGN75BSarniaId bigint,
	@UserId bigint	
	)
AS

INSERT INTO [FormGN75BUserReadDocumentLinkAssociationSarnia]
(
	FormGN75BSarniaId, 
	UserId
)
VALUES
(
	@FormGN75BSarniaId, 
	@UserId
)
