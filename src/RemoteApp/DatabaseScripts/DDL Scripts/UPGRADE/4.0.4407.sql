alter table SiteConfiguration
add ShowDirectivesOnPriorityPage bit null;

go

update SiteConfiguration
set ShowDirectivesOnPriorityPage = 1;

go

update SiteConfiguration
set ShowDirectivesOnPriorityPage = 0
where siteid in (1, 2, 6, 7);

go


alter table SiteConfiguration
alter column ShowDirectivesOnPriorityPage bit not null;

go

--- 

alter table SiteConfiguration
add ShowShiftHandoversOnPriorityPage bit null;

go

update SiteConfiguration
set ShowShiftHandoversOnPriorityPage = 1;

go

update SiteConfiguration
set ShowShiftHandoversOnPriorityPage = 0
where siteid in (1, 2, 6, 7);

go


alter table SiteConfiguration
alter column ShowShiftHandoversOnPriorityPage bit not null;

go


GO
