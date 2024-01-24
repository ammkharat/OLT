IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormMontrealCsdId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormMontrealCsdId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormMontrealCsdId(@FormMontrealCsdId bigint)
AS
SELECT * FROM DocumentLink WHERE FormMontrealCsdId = @FormMontrealCsdId	and Deleted = 0	
and FormMontrealCsdId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormMontrealCsdId] TO PUBLIC
GO