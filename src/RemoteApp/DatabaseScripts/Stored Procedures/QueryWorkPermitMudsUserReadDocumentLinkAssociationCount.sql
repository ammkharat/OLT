
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsUserReadDocumentLinkAssociationCount')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsUserReadDocumentLinkAssociationCount
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsUserReadDocumentLinkAssociationCount]
	(
		@UserId bigint,
		@WorkPermitMudsId bigint
	)
AS

SELECT
	COUNT(assoc.WorkPermitMudsId) as COUNT
FROM 
	[dbo].[WorkPermitMudsUserReadDocumentLinkAssociation] assoc
WHERE assoc.UserId = @UserId and
      assoc.WorkPermitMudsId = @WorkPermitMudsId
GO

GRANT EXEC ON QueryWorkPermitMudsUserReadDocumentLinkAssociationCount TO PUBLIC
GO
