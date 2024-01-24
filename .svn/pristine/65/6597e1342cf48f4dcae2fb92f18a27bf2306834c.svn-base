INSERT INTO RoleElement(Id,Name) VALUES (88,'View Shift Summary Logs')
INSERT INTO RoleElement(Id,Name) VALUES (89,'Create Shift Summary Logs')
INSERT INTO RoleElement(Id,Name) VALUES (90,'Edit Shift Summary Logs In Operator Group')
INSERT INTO RoleElement(Id,Name) VALUES (91,'Edit Shift Summary Logs In Operating Engineer Group')
INSERT INTO RoleElement(Id,Name) VALUES (92,'Edit Shift Summary Logs In Supervisor Group')
INSERT INTO RoleElement(Id,Name) VALUES (93,'Delete Shift Summary Logs In Operator Group')
INSERT INTO RoleElement(Id,Name) VALUES (94,'Delete Shift Summary Logs In Operating Engineer Group')
INSERT INTO RoleElement(Id,Name) VALUES (95,'Delete Shift Summary Logs In Supervisor Group')

GO


-- only firebag users (view)
insert into userroleelements
select a.id, e.id
from [user] a,
usersite c,
site d,
role b,
roleelement e
where  
a.id = c.userid
and c.siteid = d.id
and d.id = 5
and a.roleid = b.id
and e.id in (88)
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
where  
a.id = c.userid
and c.siteid = d.id
and d.id = 5
and a.roleid = b.id
and b.name like 'Supervisor%'
and e.id in (89, 92, 95)

GO


GO


GO
