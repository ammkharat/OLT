INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   179   -- Id - bigint
  ,'Configure Priorities Page'  -- Name - varchar(60)
  ,'Admin - Priorities'  -- FunctionalArea - varchar(100)
)

insert into RoleElementTemplate
select 179, Id
from [Role]
where [Name] like 'Administrateur des Opérations' or [Name] = 'Administrator'
and not exists (select * from roleelementtemplate where roleelementid = 179 and roleid = id)
GO
