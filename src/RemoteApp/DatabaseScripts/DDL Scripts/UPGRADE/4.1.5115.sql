-- set sarnia's permits to print 2 copies by default.
UPDATE dbo.SiteConfiguration
  SET DefaultNumberOfCopiesForWorkPermits = 2
WHERE
  SiteId = 1


GO

