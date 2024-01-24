

alter table dbo.WorkPermitEdmontonDetails add VehicleEntry bit null;
go

update dbo.WorkPermitEdmontonDetails set VehicleEntry = 1 where VehicleEntryTotal is not null or VehicleEntryType is not null;
update dbo.WorkPermitEdmontonDetails set VehicleEntry = 0 where VehicleEntry is null;
go

alter table dbo.WorkPermitEdmontonDetails alter column VehicleEntry bit not null;
go


--- history:

alter table dbo.WorkPermitEdmontonHistory add VehicleEntry bit null;
go

update dbo.WorkPermitEdmontonHistory set VehicleEntry = 1 where VehicleEntryTotal is not null or VehicleEntryType is not null;
update dbo.WorkPermitEdmontonHistory set VehicleEntry = 0 where VehicleEntry is null;
go

alter table dbo.WorkPermitEdmontonHistory alter column VehicleEntry bit not null;
go







GO

