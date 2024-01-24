-- Remove existing Firebag UserRoleElements
DELETE [UserRoleElements]
FROM [UserRoleElements]
INNER JOIN [User] ON [User].[Id] = [UserRoleElements].[UserId] 
INNER JOIN [UserSite] ON [User].[Id] = [UserSite].[UserId]
WHERE 
siteid = 5


-- Insert UserRoleElements for Firebag Supervisors (36)
insert into userroleelements
select u.id, re.id
from [user] u,
usersite us,
site s,
role r,
roleelement re
where  
u.id = us.userid
and us.siteid = s.id
and s.id = 5
and r.id = 1
and u.roleid = r.id
and re.id in (1, 2, 3, 4, 6, 8, 10, 11, 32, 33, 34, 35, 39, 40, 43, 44, 47, 48, 51, 54, 69, 70, 71, 73, 77, 79, 84, 85, 88, 89, 92, 95, 96, 97, 98, 99)
order by u.id

-- Insert UserRoleElements for Firebag Operators (20)
insert into userroleelements
select u.id, re.id
from [user] u,
usersite us,
site s,
role r,
roleelement re
where  
u.id = us.userid
and us.siteid = s.id
and s.id = 5
and r.id = 2
and u.roleid = r.id
and re.id in (1, 10, 32, 33, 34, 35, 39, 40, 43, 47, 48, 51, 54, 55, 56, 66, 67, 68, 88, 96)
order by u.id

-- Insert UserRoleElements for Firebag Engineering (23)
insert into userroleelements
select u.id, re.id
from [user] u,
usersite us,
site s,
role r,
roleelement re
where  
u.id = us.userid
and us.siteid = s.id
and s.id = 5
and r.id = 5
and u.roleid = r.id
and re.id in (1, 10, 32, 33, 34, 35, 39, 40, 43, 47, 48, 51, 54, 55, 56, 63, 64, 65, 66, 67, 68, 88, 96)
order by u.id

-- Insert UserRoleElements for Firebag Read only users (6)
insert into userroleelements
select u.id, re.id
from [user] u,
usersite us,
site s,
role r,
roleelement re
where  
u.id = us.userid
and us.siteid = s.id
and s.id = 5
and r.id = 7
and u.roleid = r.id
and re.id in (1, 33, 39, 47, 88, 96)
order by u.id

-- Insert UserRoleElements for Firebag Admin users (13)
insert into userroleelements
select u.id, re.id
from [user] u,
usersite us,
site s,
role r,
roleelement re
where  
u.id = us.userid
and us.siteid = s.id
and s.id = 5
and r.id = 37
and u.roleid = r.id
and re.id in (1, 33, 39, 47, 72, 74, 76, 77, 81, 82, 85, 88, 96)
order by u.id

GO
