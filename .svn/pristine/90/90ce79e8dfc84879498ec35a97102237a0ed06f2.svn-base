INSERT INTO RoleElement(Id,Name) VALUES (96,'View (Area Manager) Directives')
INSERT INTO RoleElement(Id,Name) VALUES (97,'Create (Area Manager) Directives')
INSERT INTO RoleElement(Id,Name) VALUES (98,'Edit (Area Manager) Directives')
INSERT INTO RoleElement(Id,Name) VALUES (99,'Delete (Area Manager) Directives')
GO


-- only firebag users (view)
insert into userroleelements
select a.id, e.id
from [user] a,
usersite c,
site d,
role b,
roleelement e
where  1=1
and a.id = c.userid
and c.siteid = d.id
and d.id = 5
and a.roleid = b.id
and e.id in (96)
order by a.id

GO

-- supervisors at firebag (create, edit, delete)
insert into userroleelements
select a.id, e.id
from [user] a,
usersite c,
site d,
role b,
roleelement e
where  1=1
and a.id = c.userid
and c.siteid = d.id
and d.id = 5
and a.roleid = b.id
and b.name like 'Supervisor%'
and e.id in (97, 98, 99)

GO

GO
