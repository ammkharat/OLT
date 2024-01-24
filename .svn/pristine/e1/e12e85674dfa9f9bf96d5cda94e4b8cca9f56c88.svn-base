alter table dbo.PermitRequestEdmonton add DurationPermit bit null;
alter table dbo.PermitRequestEdmontonHistory add DurationPermit bit null;
go

update dbo.PermitRequestEdmonton set DurationPermit = 0;
update dbo.PermitRequestEdmontonHistory set DurationPermit = 0;
go

alter table dbo.PermitRequestEdmonton alter column DurationPermit bit not null;
alter table dbo.PermitRequestEdmontonHistory alter column DurationPermit bit not null;
go



GO

