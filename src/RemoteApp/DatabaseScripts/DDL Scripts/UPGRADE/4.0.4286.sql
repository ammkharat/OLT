alter table Log
add IsOperatingEngineerLog bit null;

go

update Log
set IsOperatingEngineerLog = 1
where CurrentRoleGroupId = 4 and LogType = 1;

update Log
set IsOperatingEngineerLog = 0
where IsOperatingEngineerLog is null;

go

alter table Log
alter column IsOperatingEngineerLog bit not null;

go

-- ------------------------------------------------

alter table LogHistory
add IsOperatingEngineerLog bit null;

go

UPDATE h
SET  h.IsOperatingEngineerLog = 1
FROM Log l 
join LogHistory h on l.id = h.Id
WHERE h.CurrentRoleGroupId = 4 and l.LogType = 1;

update LogHistory
set IsOperatingEngineerLog = 0
where IsOperatingEngineerLog is null;

go

alter table LogHistory
alter column IsOperatingEngineerLog bit not null;

go


-- ------------------------------------------------

alter table LogDefinition
add IsOperatingEngineerLog bit null;

go

update LogDefinition
set IsOperatingEngineerLog = 1
where CurrentRoleGroupId = 4 and LogType = 1;

update LogDefinition
set IsOperatingEngineerLog = 0
where IsOperatingEngineerLog is null;

go

alter table LogDefinition
alter column IsOperatingEngineerLog bit not null;

go


-- ------------------------------------------------

alter table Log
drop FK_Log_CreatedByRoleGroup;

alter table Log
drop column CreatedByRoleGroupId;

alter table Log
drop FK_Log_CurrentRoleGroup;

alter table Log
drop column CurrentRoleGroupId;

alter table LogHistory
drop column CreatedByRoleGroupId;

alter table LogHistory
drop column CurrentRoleGroupId;

go

-- ------------------------------------------------

alter table LogDefinition
drop FK_LogDefinition_CreatedByRoleGroup;

alter table LogDefinition
drop column CreatedByRoleGroupId;

alter table LogDefinition
drop FK_LogDefinition_CurrentRoleGroup;

alter table LogDefinition
drop column CurrentRoleGroupId;

alter table LogDefinitionHistory
drop column CreatedByRoleGroupId;

alter table LogDefinitionHistory
drop column CurrentRoleGroupId;

go

-- ------------------------------------------------

alter table Role
drop FK_Role_RoleGroup;

alter table Role
drop column RoleGroupId;

drop table RoleGroup;

go

-- ------------------------------------------------

ALTER TABLE RolePermission 
ADD CONSTRAINT UK_RolePermission UNIQUE NONCLUSTERED 
(
	RoleId ASC,
	RoleElementId ASC,
	CreatedByRoleId ASC
)
;

go

 -- sarnia
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 65
and CreatedByRoleId = 56;

-- edmonton
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 69
and CreatedByRoleId = 62;

-- firebag
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 67
and CreatedByRoleId = 59;

-- mackay
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 68
and CreatedByRoleId = 61;

-- oilsands
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 66
and CreatedByRoleId = 58;

go

-- ------------------------------------------------

 -- remove edit/delete/cancel log flagged as openg log from TA Engineer 
delete from RoleElementTemplate
where RoleElementId in (63, 64, 65)
and  RoleId = 104;

go




GO
