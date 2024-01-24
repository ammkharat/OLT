IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradesBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradesBySiteId
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradesBySiteId
	(
		@SiteId BIGINT
	)
AS
SELECT *
FROM CraftOrTrade
WHERE SiteId = @SiteId
AND Deleted = 0
ORDER BY [Name] ASC
GO

GRANT EXEC ON QueryCraftOrTradesBySiteId TO PUBLIC
GO