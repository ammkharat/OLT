alter table SiteConfiguration
add DaysToDisplayDeviationAlerts int null

go

update SiteConfiguration
set  DaysToDisplayDeviationAlerts = 30

go

alter table SiteConfiguration
alter column DaysToDisplayDeviationAlerts int not null

go
GO
