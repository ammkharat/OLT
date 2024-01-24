alter table SiteConfiguration
add DefaultNumberOfCopiesForWorkPermits int null

go

update SiteConfiguration
set DefaultNumberOfCopiesForWorkPermits = 1

go

alter table SiteConfiguration
alter column DefaultNumberOfCopiesForWorkPermits int not null

go

GO
