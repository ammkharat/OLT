INSERT INTO RoleElement(Id,Name) VALUES (111,'Configure Business Categories');
INSERT INTO RoleElement(Id,Name) VALUES (112,'Associate Business Categories To Functional Locations');

GO

-- add role elements for admin users
insert into UserRoleElements
select u.id, 111
from [user] u
where u.RoleId = 4;

GO

insert into UserRoleElements
select u.id, 112
from [user] u
where u.RoleId = 4;

GO

GO
