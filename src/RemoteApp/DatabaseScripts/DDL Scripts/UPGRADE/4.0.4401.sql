alter table SiteConfiguration
add UseNewPriorityPage bit null;

go

update SiteConfiguration
set UseNewPriorityPage = 0;

go

alter table SiteConfiguration
alter column UseNewPriorityPage bit not null;

go


GO
