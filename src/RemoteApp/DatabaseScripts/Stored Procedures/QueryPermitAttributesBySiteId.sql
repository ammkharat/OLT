IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAttributesBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAttributesBySiteId
	END
GO

CREATE Procedure dbo.QueryPermitAttributesBySiteId
	(
		@SiteId BIGINT
	)
AS
SELECT *
FROM PermitAttribute
WHERE SiteId = @SiteId
and Deleted = 0
order by Name
GO

GRANT EXEC ON QueryPermitAttributesBySiteId TO PUBLIC
GO
