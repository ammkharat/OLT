alter table SiteConfiguration add ActionItemRequiresResponseDefaultValue bit null;

GO

update SiteConfiguration set ActionItemRequiresResponseDefaultValue = 0;

GO

-- Edmonton
update SiteConfiguration set ActionItemRequiresResponseDefaultValue = 1 where SiteId = 8;

GO

alter table SiteConfiguration alter column ActionItemRequiresResponseDefaultValue bit not null





GO
