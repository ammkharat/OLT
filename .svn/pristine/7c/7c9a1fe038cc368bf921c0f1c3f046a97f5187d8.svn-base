

alter table dbo.WorkPermitEdmonton add DurationPermit bit null;
alter table dbo.WorkPermitEdmontonHistory add DurationPermit bit null;
go

update dbo.WorkPermitEdmonton set DurationPermit = 0;
update dbo.WorkPermitEdmontonHistory set DurationPermit = 0;
go

alter table dbo.WorkPermitEdmonton alter column DurationPermit bit not null;
alter table dbo.WorkPermitEdmontonHistory alter column DurationPermit bit not null;
go





GO

