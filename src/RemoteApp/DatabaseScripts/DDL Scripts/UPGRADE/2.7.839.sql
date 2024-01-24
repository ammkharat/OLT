alter table SiteConfiguration
add DaysToEditDeviationAlerts int null

go

update SiteConfiguration
set DaysToEditDeviationAlerts = 7

go

alter table SiteConfiguration
alter column DaysToEditDeviationAlerts int not null

go



GO
