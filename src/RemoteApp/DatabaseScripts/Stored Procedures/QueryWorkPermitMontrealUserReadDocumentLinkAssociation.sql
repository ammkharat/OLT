IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount')
	BEGIN
		DROP  Procedure  QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount
	END

GO

CREATE Procedure [dbo].QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount
	(
		@UserId bigint,
		@WorkPermitMontrealId bigint
	)
AS

SELECT
	COUNT(assoc.WorkPermitMontrealId) as COUNT
FROM 
	[dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation] assoc
WHERE assoc.UserId = @UserId and
      assoc.WorkPermitMontrealId = @WorkPermitMontrealId
GO

GRANT EXEC ON QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount TO PUBLIC
GO