

alter table SiteConfiguration add ShowActiveCriticalSystemDefeatsOnPriorityPage bit;
alter table SiteConfiguration add ShowWorkPermitsOnPriorityPage bit;
go

update SiteConfiguration set ShowActiveCriticalSystemDefeatsOnPriorityPage = 0;
update SiteConfiguration set ShowActiveCriticalSystemDefeatsOnPriorityPage = 1 where SiteId = 8;  -- Edmonton

update SiteConfiguration set ShowWorkPermitsOnPriorityPage = 0;
update SiteConfiguration set ShowWorkPermitsOnPriorityPage = 1 where SiteId in (8, 9, 10);   -- Edmo, Montreal, Lubes
go

alter table SiteConfiguration alter column ShowActiveCriticalSystemDefeatsOnPriorityPage bit not null;
alter table SiteConfiguration alter column ShowWorkPermitsOnPriorityPage bit not null;
go




GO

