IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPlantBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPlantBySiteId
	END
GO

CREATE Procedure [dbo].QueryPlantBySiteId
(
		@siteId bigint
)
AS
SELECT 
	Id, Name, SiteId
FROM
	Plant
WHERE
	Plant.SiteId = @siteId
GO

GRANT EXEC ON QueryPlantBySiteId TO PUBLIC
GO