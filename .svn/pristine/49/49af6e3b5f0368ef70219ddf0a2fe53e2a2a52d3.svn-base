IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMontrealUserReadDocumentLinkAssociation')
	BEGIN
		DROP  Procedure  InsertWorkPermitMontrealUserReadDocumentLinkAssociation
	END

GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealUserReadDocumentLinkAssociation]
	(
	@WorkPermitMontrealId bigint,
	@UserId bigint	
	)
AS

INSERT INTO [WorkPermitMontrealUserReadDocumentLinkAssociation]
(
	WorkPermitMontrealId, 
	UserId
)
VALUES
(
	@WorkPermitMontrealId, 
	@UserId
)
GO

GRANT EXEC ON InsertWorkPermitMontrealUserReadDocumentLinkAssociation TO PUBLIC
GO


 