
alter table SiteConfiguration
add ShowShiftHandoversByWorkAssignmentOnPriorityPage bit null;

go

update SiteConfiguration
set ShowShiftHandoversByWorkAssignmentOnPriorityPage = 0;

go

update SiteConfiguration
set ShowShiftHandoversByWorkAssignmentOnPriorityPage = 1
where siteid in (3, 5);

go


alter table SiteConfiguration
alter column ShowShiftHandoversByWorkAssignmentOnPriorityPage bit not null;

go


GO
