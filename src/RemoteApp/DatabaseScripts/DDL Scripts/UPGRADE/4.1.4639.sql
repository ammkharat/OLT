alter table SiteConfiguration
add DaysToDisplayPermitRequestsBackwards int null;

go

update SiteConfiguration
set DaysToDisplayPermitRequestsBackwards = 0;

go

alter table SiteConfiguration
alter column DaysToDisplayPermitRequestsBackwards int not null;

go


alter table SiteConfiguration
add DaysToDisplayPermitRequestsForwards int null;

go

update SiteConfiguration
set DaysToDisplayPermitRequestsForwards = 0;

go

alter table SiteConfiguration
alter column DaysToDisplayPermitRequestsForwards int not null;

go



GO
