alter table WorkPermit
add IsOperations bit null;

go

update WorkPermit
set IsOperations = 1
where CreatedByRoleId != 8; -- 8 is non-ops permit issuer

update WorkPermit
set IsOperations = 0
where CreatedByRoleId = 8; -- 8 is non-ops permit issuer

go

alter table WorkPermit
alter column IsOperations bit not null;

go

alter table WorkPermit
drop FK_WorkPermit_Role;

go

alter table WorkPermit
drop column CreatedByRoleId;

go



GO
