IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAreaLabelBySiteAndPlannerGroup')
	BEGIN
		DROP PROCEDURE [dbo].QueryAreaLabelBySiteAndPlannerGroup
	END
GO

CREATE Procedure dbo.QueryAreaLabelBySiteAndPlannerGroup
(
	@SiteId bigint,
	@PlannerGroup varchar(max)
)
AS
SELECT * 
FROM AreaLabel
WHERE SiteId = @SiteId and
      SapPlannerGroup = @PlannerGroup
GO

GRANT EXEC ON QueryAreaLabelBySiteAndPlannerGroup TO PUBLIC
GO