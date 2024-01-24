alter table SiteConfiguration add RequireActionItemResponseLog bit null

GO

update SiteConfiguration set RequireActionItemResponseLog = 0

GO

alter table SiteConfiguration alter column RequireActionItemResponseLog bit not null

GO

update SiteConfiguration set RequireActionItemResponseLog = 1 where SiteId = 8

GO

GO
