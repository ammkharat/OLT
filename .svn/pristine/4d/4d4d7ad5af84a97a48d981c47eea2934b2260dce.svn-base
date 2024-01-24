ALTER TABLE dbo.WorkPermitEdmontonHistory ALTER COLUMN HazardsAndOrRequirements VARCHAR(2000);



GO

UPDATE 
  dbo.SiteConfiguration
SET
  DaysToDisplayPermitRequestsForwards = 7,
  DaysToDisplayPermitRequestsBackwards = 0
WHERE
  SiteId = 8


GO

