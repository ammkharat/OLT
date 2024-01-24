update SiteConfiguration
set OperatingEngineerLogDisplayName = 'Operating Engineer Log'
where OperatingEngineerLogDisplayName is null

go

alter table SiteConfiguration
alter column OperatingEngineerLogDisplayName VARCHAR(100) not null

go

GO
