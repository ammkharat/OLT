

alter table SiteConfiguration add UseLogBasedDirectives bit null;
go

update SiteConfiguration set UseLogBasedDirectives = 1;
go

alter table SiteConfiguration alter column UseLogBasedDirectives bit not null;
go



GO

