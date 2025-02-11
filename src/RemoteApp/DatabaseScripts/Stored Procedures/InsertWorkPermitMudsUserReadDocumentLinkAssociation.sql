
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMudsUserReadDocumentLinkAssociation')
	BEGIN
		DROP Procedure [dbo].InsertWorkPermitMudsUserReadDocumentLinkAssociation
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMudsUserReadDocumentLinkAssociation]
	(
	@WorkPermitMudsId bigint,
	@UserId bigint	
	)
AS

INSERT INTO [WorkPermitMudsUserReadDocumentLinkAssociation]
(
	WorkPermitMudsId, 
	UserId
)
VALUES
(
	@WorkPermitMudsId, 
	@UserId
)
GO


GRANT EXEC ON InsertWorkPermitMudsUserReadDocumentLinkAssociation TO PUBLIC
GO

