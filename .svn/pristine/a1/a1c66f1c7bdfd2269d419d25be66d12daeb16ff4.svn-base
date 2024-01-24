IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormLubesCsdId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormLubesCsdId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormLubesCsdId(@FormLubesCsdId bigint)
AS
SELECT * FROM DocumentLink WHERE FormLubesCsdId = @FormLubesCsdId	and Deleted = 0	
and FormLubesCsdId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormLubesCsdId] TO PUBLIC
GO
