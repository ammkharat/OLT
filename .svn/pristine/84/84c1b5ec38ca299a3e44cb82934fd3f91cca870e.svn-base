IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradeByWorkCentreNameAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradeByWorkCentreNameAndSiteId
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradeByWorkCentreNameAndSiteId

	(
		@Name varchar(50),
		@SiteId bigint
	)

AS

SELECT     *
FROM         CraftOrTrade
WHERE     (Lower([Name]) = Lower(@Name))
AND SiteId = @SiteId
AND Deleted = 0 
GO

GRANT EXEC ON QueryCraftOrTradeByWorkCentreNameAndSiteId TO PUBLIC
GO