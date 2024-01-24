IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteByPlantId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteByPlantId
	END
GO

CREATE Procedure [dbo].QuerySiteByPlantId
	(
		@PlantId int
	)
AS

if @PlantId in (7030,7600)
begin
	set @PlantId = 9991
end

SELECT	
	Site.*, Plant.Id as PlantId 
FROM Site
	INNER JOIN Plant ON Plant.SiteId = Site.Id
WHERE
	Plant.Id = @PlantId;
GO

GRANT EXEC ON QuerySiteByPlantId TO PUBLIC
GO