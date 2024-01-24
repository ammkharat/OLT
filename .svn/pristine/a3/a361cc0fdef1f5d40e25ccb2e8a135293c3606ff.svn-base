
-- create Turnaround visibility group for Edmonton
INSERT INTO dbo.[VisibilityGroup] (Name, SiteId, IsSiteDefault, Deleted)
values ('Turnaround', 8, 0, 0)

-- create READ of Turnaround group for all the Edmonton work assignments with roles that begin with 'TA'
INSERT INTO dbo.WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
select VisibilityGroup.Id, WorkAssignment.Id, 1
from WorkAssignment
inner join Role ON WorkAssignment.RoleId = Role.Id
inner join VisibilityGroup ON VisibilityGroup.Name = 'Turnaround' and VisibilityGroup.SiteId = 8
where Role.SiteId = 8 and Role.Name like 'TA %'

-- create WRITE of Turnaround group for all the Edmonton work assignments with roles that begin with 'TA"
INSERT INTO dbo.WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
select VisibilityGroup.Id, WorkAssignment.Id, 2
from WorkAssignment
inner join Role ON WorkAssignment.RoleId = Role.Id
inner join VisibilityGroup ON VisibilityGroup.Name = 'Turnaround' and VisibilityGroup.SiteId = 8
where Role.SiteId = 8 and Role.Name like 'TA %'



GO

