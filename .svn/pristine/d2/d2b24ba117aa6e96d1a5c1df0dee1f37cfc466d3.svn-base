IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradesByNameAndWorkCentreAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradesByNameAndWorkCentreAndSiteId
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradesByNameAndWorkCentreAndSiteId
	(
		@Name varchar(50),
		@WorkCenter varchar(10) = NULL,
		@SiteId bigint		
	)

AS
select * from CraftOrTrade
where [Name] = @Name
and SiteId = @SiteId
and ((@WorkCenter is null and WorkCenter is null) or (@WorkCenter is not null and @WorkCenter = WorkCenter))
and Deleted = 0
GO

GRANT EXEC ON QueryCraftOrTradesByNameAndWorkCentreAndSiteId TO PUBLIC
GO