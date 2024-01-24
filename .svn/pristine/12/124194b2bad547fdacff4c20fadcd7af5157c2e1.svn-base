alter table SiteConfiguration
add DisplayActionItemWorkAssignmentOnPriorityPage bit null;

go

update SiteConfiguration
set DisplayActionItemWorkAssignmentOnPriorityPage = 0;

go

update SiteConfiguration
set DisplayActionItemWorkAssignmentOnPriorityPage = 1
where siteid in (3, 8);

go

alter table SiteConfiguration
alter column DisplayActionItemWorkAssignmentOnPriorityPage bit not null;

go

GO
