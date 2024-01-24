-- Mark as deleted all Functional Location records (except Site Wide Services) that have 6th (or higher) level FLOCS
UPDATE FunctionalLocation
SET Deleted = 1
WHERE (len(FullHierarchy)-len(replace(FullHierarchy,'-',''))) > 4 
AND SiteId <> 6 -- Site Wide Services


GO

