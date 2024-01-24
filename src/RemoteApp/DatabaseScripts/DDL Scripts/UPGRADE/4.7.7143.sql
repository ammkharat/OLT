

alter table WorkPermitEdmonton add PriorityId int null;
alter table WorkPermitEdmontonHistory add PriorityId int null;
alter table PermitRequestEdmonton add PriorityId int null;
alter table PermitRequestEdmontonHistory add PriorityId int null;
go

update WorkPermitEdmonton set PriorityId = 1
update WorkPermitEdmontonHistory set PriorityId = 1
update PermitRequestEdmonton set PriorityId = 1
update PermitRequestEdmontonHistory set PriorityId = 1
go

alter table WorkPermitEdmonton alter column PriorityId int not null;
alter table WorkPermitEdmontonHistory alter column PriorityId int not null;
alter table PermitRequestEdmonton alter column PriorityId int not null;
alter table PermitRequestEdmontonHistory alter column PriorityId int not null;
go






GO

