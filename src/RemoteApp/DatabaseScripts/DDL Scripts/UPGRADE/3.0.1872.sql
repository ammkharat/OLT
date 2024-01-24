alter table SiteConfiguration
add AllowStandardLogAtSecondLevelFunctionalLocation bit null

go

-- default, everyone logs at level 3
update SiteConfiguration
set  AllowStandardLogAtSecondLevelFunctionalLocation = 0

go

-- firebag can log at level 2
update SiteConfiguration
set  AllowStandardLogAtSecondLevelFunctionalLocation = 1
where SiteId = 5

go

alter table SiteConfiguration
alter column AllowStandardLogAtSecondLevelFunctionalLocation bit not null

go
GO

GO
