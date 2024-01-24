alter table SiteConfiguration add Culture varchar(5) null;

GO

update SiteConfiguration set Culture = 'en' where SiteId <> 9;
update SiteConfiguration set Culture = 'fr' where SiteId = 9;

GO

alter table SiteConfiguration alter column Culture varchar(5) not null;

GO

alter table FunctionalLocation alter column Culture varchar(5) not null;


