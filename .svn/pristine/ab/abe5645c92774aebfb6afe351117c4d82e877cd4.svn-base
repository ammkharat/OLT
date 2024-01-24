alter table SiteConfiguration add HideDORCommentEntry bit null;

GO

update SiteConfiguration set HideDORCommentEntry = 0;

GO

alter table SiteConfiguration alter column HideDORCommentEntry bit not null

GO

update SiteConfiguration set HideDORCommentEntry = 1 where SiteId = 8

GO


GO
