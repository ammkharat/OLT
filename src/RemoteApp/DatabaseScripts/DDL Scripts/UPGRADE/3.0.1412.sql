alter table SiteConfiguration
add CrossShiftDisplayName varchar(50) null;

go

update SiteConfiguration
set CrossShiftDisplayName = 'Work Assignment Logs'

go

alter table SiteConfiguration
alter column CrossShiftDisplayName varchar(50) not null;

go

GO
