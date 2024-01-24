alter table SiteConfiguration add DaysToDisplayWorkPermits int not null default 30;

GO

update SiteConfiguration set DaysToDisplayWorkPermits = 15 where SiteId = 1;

GO

GO
