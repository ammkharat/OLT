


alter table dbo.PermitRequestEdmontonSAPImportData
add DoNotMerge bit null;
go

update dbo.PermitRequestEdmontonSAPImportData
set DoNotMerge = 0;
go

alter table dbo.PermitRequestEdmontonSAPImportData
alter column DoNotMerge bit not null;
go





GO

