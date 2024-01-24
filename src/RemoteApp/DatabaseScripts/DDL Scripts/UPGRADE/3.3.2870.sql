alter table SiteConfiguration
add DaysToDisplayLabAlerts int null;
 
go

update SiteConfiguration
set DaysToDisplayLabAlerts = 30;

go

alter table SiteConfiguration
alter column DaysToDisplayLabAlerts int not null;

go





GO
