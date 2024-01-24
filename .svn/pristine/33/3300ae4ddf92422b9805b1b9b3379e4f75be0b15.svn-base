

alter table SiteConfiguration add AllowCombinedShiftHandoverAndLog bit null;
go

update SiteConfiguration set AllowCombinedShiftHandoverAndLog = 0;
update SiteConfiguration set AllowCombinedShiftHandoverAndLog = 1 where SiteId = 2;  -- Denver
go

alter table SiteConfiguration alter column AllowCombinedShiftHandoverAndLog bit not null;
go



GO

