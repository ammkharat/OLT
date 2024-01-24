UPDATE dbo.PermitAttribute
  SET
    [Name] = 'Soudure électrique'
WHERE [Name] = 'Souduer électrique'
      AND SiteId = 9


GO

UPDATE dbo.SiteConfiguration
  SET 
  DaysToDisplayWorkPermitsForwards = 7,
  DaysToDisplayPermitRequestsForwards = 7
WHERE
  SITEID = 9


GO

