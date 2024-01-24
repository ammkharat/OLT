alter table SiteConfiguration add DaysToDisplayShiftHandovers int null
GO

UPDATE SiteConfiguration Set DaysToDisplayShiftHandovers = 7

alter table SiteConfiguration alter column DaysToDisplayShiftHandovers int not null



GO
