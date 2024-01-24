alter table SiteConfiguration
add DorCutoffTime datetime null

go

update SiteConfiguration
set  DorCutoffTime = '1753-01-01 10:00:00'

go

alter table SiteConfiguration
alter column DorCutoffTime datetime not null

go
GO

GO

GO
