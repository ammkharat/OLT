alter table SiteConfiguration add DailyDirectiveFunctionalLocationDisplayLevel int null;

GO

update SiteConfiguration set DailyDirectiveFunctionalLocationDisplayLevel = 1;

GO

alter table SiteConfiguration alter column DailyDirectiveFunctionalLocationDisplayLevel int not null

GO

update SiteConfiguration set DailyDirectiveFunctionalLocationDisplayLevel = 2 where SiteId = 8

GO

update SiteConfiguration set SummaryLogFunctionalLocationDisplayLevel = 2 where SiteId = 8

GO


GO
