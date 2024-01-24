
insert into RoleElementTemplate (RoleElementId, RoleId)
select 35, r.Id  -- 35 == delete log
from Role r
where r.SiteId = 10 and r.Name = 'Operator'




GO

