IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfiguredDocumentLinksByLocation')
	BEGIN
		DROP PROCEDURE [dbo].QueryConfiguredDocumentLinksByLocation
	END
GO

CREATE Procedure [dbo].QueryConfiguredDocumentLinksByLocation
(
	@Location VARCHAR(100)
)
AS
SELECT * 
FROM ConfiguredDocumentLink
WHERE Deleted = 0 AND Location = @Location
ORDER BY DisplayOrder ASC;
GO

GRANT EXEC ON QueryConfiguredDocumentLinksByLocation TO PUBLIC
GO