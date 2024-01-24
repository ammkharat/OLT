alter table SiteConfiguration
add ShowFollowupOnLogForm bit null

alter table SiteConfiguration
add AllowCreateALogForEachSelectedFlocOnLogForm bit null

alter table SiteConfiguration
add ShowMoreDetailsOnLogFormByDefault bit null

go

update SiteConfiguration
set ShowFollowupOnLogForm = 1

update SiteConfiguration
set AllowCreateALogForEachSelectedFlocOnLogForm = 1

update SiteConfiguration
set ShowMoreDetailsOnLogFormByDefault = 1


go

alter table SiteConfiguration
alter column ShowFollowupOnLogForm bit not null

alter table SiteConfiguration
alter column AllowCreateALogForEachSelectedFlocOnLogForm bit not null

alter table SiteConfiguration
alter column ShowMoreDetailsOnLogFormByDefault bit not null

go


GO
