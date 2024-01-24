alter table PermitRequest
add IsSubmitted bit null;

go

update PermitRequest
set IsSubmitted = 0;

go

alter table PermitRequest
alter column IsSubmitted bit not null;

go

alter table PermitRequestHistory
add IsSubmitted bit null;

go

update PermitRequestHistory
set IsSubmitted = 0;

go

alter table PermitRequestHistory
alter column IsSubmitted bit not null;

go

GO
