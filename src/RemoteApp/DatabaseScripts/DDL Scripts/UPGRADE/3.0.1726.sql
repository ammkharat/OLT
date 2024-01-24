alter table SiteConfiguration
add SummaryLogFunctionalLocationDisplayLevel int null

go

update SiteConfiguration
set SummaryLogFunctionalLocationDisplayLevel = 1

go

update SiteConfiguration
set SummaryLogFunctionalLocationDisplayLevel = 2
where SiteId = 3

go

alter table SiteConfiguration
alter column SummaryLogFunctionalLocationDisplayLevel int not null

go

GO
