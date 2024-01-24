IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAreaLabelBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryAreaLabelBySiteId
	END
GO

CREATE Procedure dbo.QueryAreaLabelBySiteId
	(
	@SiteId bigint
	)
AS
SELECT * 
FROM AreaLabel
WHERE SiteId = @SiteId AND
Deleted = 0
ORDER BY DisplayOrder ASC
GO

GRANT EXEC ON QueryAreaLabelBySiteId TO PUBLIC
GO