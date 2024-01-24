IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradeByWorkCenterAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradeByWorkCenterAndSiteId
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradeByWorkCenterAndSiteId

	(
		@WorkCenter varchar(10),
		@SiteId bigint
	)

AS

SELECT * FROM CraftOrTrade
WHERE (Lower(WorkCenter) = Lower(@WorkCenter))
AND SiteId = @SiteId
AND Deleted = 0 
GO

GRANT EXEC ON QueryCraftOrTradeByWorkCenterAndSiteId TO PUBLIC
GO