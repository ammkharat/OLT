-- Update SiteConfiguration so all columns are Not Nullable.
UPDATE dbo.SiteConfiguration
  SET 
  DaysToDisplayWorkPermitsForwards = 0
WHERE
  SITEID <> (9)
AND DaysToDisplayWorkPermitsForwards IS NULL  
GO
  
ALTER TABLE SiteConfiguration ALTER COLUMN DaysToDisplayWorkPermitsForwards INT NOT NULL;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN ShowLogRecommendedForSummaryColumn BIT NOT NULL;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN ShowIsModifiedColumnForLogs BIT NOT NULL;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN UseCreatedByColumnForLogs BIT NOT NULL;

GO