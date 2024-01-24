alter table SiteConfiguration add IncludeWorkAssignmentInPriortyScreenQuery bit null

GO

update SiteConfiguration set IncludeWorkAssignmentInPriortyScreenQuery = 0

GO

update SiteConfiguration set IncludeWorkAssignmentInPriortyScreenQuery = 1 where SiteId = 3

GO

ALTER TABLE SiteConfiguration ALTER COLUMN IncludeWorkAssignmentInPriortyScreenQuery bit NOT NULL

GO

GO
