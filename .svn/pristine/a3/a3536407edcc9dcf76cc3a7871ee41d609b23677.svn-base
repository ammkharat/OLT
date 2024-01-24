
-- add Group to Permit Request table
alter table dbo.PermitRequestEdmonton add [Group] varchar(50) null;
go

update dbo.PermitRequestEdmonton set [Group] = 'temporary';   --- this feature isn't released so it's ok to put some junk in any existing ones
go

alter table dbo.PermitRequestEdmonton alter column [Group] varchar(50) not null;
go

-- change the license number to a total
alter table dbo.PermitRequestEdmonton drop column VehicleEntryLicenseNumber;
alter table dbo.WorkPermitEdmontonDetails drop column VehicleEntryLicenseNumber;
GO

alter table dbo.PermitRequestEdmonton add VehicleEntryTotal int null;
alter table dbo.WorkPermitEdmontonDetails add VehicleEntryTotal int null;
GO

-- Remove old columns from both tables

alter table dbo.PermitRequestEdmonton drop column GN1FormNumber;
alter table dbo.PermitRequestEdmonton drop column BT1FormNumber;
alter table dbo.PermitRequestEdmonton drop column GN75FormNumber;
alter table dbo.PermitRequestEdmonton drop column OtherTypeOfWork;
alter table dbo.PermitRequestEdmonton drop column OtherTypeOfWorkFormNumber;

alter table dbo.WorkPermitEdmontonDetails drop column GN1FormNumber;
alter table dbo.WorkPermitEdmontonDetails drop column BT1FormNumber;
alter table dbo.WorkPermitEdmontonDetails drop column GN75FormNumber;
alter table dbo.WorkPermitEdmontonDetails drop column OtherTypeOfWork;
alter table dbo.WorkPermitEdmontonDetails drop column OtherTypeOfWorkFormNumber;
GO

-- Add new columns in on the request
alter table dbo.PermitRequestEdmonton add AlkylationEntry bit null;
alter table dbo.PermitRequestEdmonton add FlarePitEntry bit null;
alter table dbo.PermitRequestEdmonton add ConfinedSpace bit null;
alter table dbo.PermitRequestEdmonton add RescuePlan bit null;
alter table dbo.PermitRequestEdmonton add VehicleEntry bit null;
alter table dbo.PermitRequestEdmonton add SpecialWork bit null;
GO

update PermitRequestEdmonton set AlkylationEntry = 0;
update PermitRequestEdmonton set FlarePitEntry = 0;
update PermitRequestEdmonton set ConfinedSpace = 0;
update PermitRequestEdmonton set RescuePlan = 0;
update PermitRequestEdmonton set VehicleEntry = 0;
update PermitRequestEdmonton set SpecialWork = 0;
GO

alter table PermitRequestEdmonton alter column AlkylationEntry bit not null;
alter table PermitRequestEdmonton alter column FlarePitEntry bit not null;
alter table PermitRequestEdmonton alter column ConfinedSpace bit not null;
alter table PermitRequestEdmonton alter column RescuePlan bit not null;
alter table PermitRequestEdmonton alter column VehicleEntry bit not null;
alter table PermitRequestEdmonton alter column SpecialWork bit not null;
GO

alter table dbo.PermitRequestEdmonton add GN59 bit not null;
alter table dbo.PermitRequestEdmonton add GN7 bit not null;

alter table dbo.PermitRequestEdmonton add GN6 bit not null;
alter table dbo.PermitRequestEdmonton add GN11 bit not null;
alter table dbo.PermitRequestEdmonton add GN24 bit not null;

alter table dbo.PermitRequestEdmonton add GN27 bit not null;
alter table dbo.PermitRequestEdmonton add GN75 bit not null;
alter table dbo.PermitRequestEdmonton add BT1 bit not null;
		



GO

