

alter table dbo.WorkPermitEdmontonDetails add UseCurrentPermitNumberForZeroEnergyFormNumber bit null
go

update dbo.WorkPermitEdmontonDetails set UseCurrentPermitNumberForZeroEnergyFormNumber = 0
go

alter table dbo.WorkPermitEdmontonDetails alter column UseCurrentPermitNumberForZeroEnergyFormNumber bit not null
go


-----------

alter table dbo.WorkPermitEdmontonHistory add UseCurrentPermitNumberForZeroEnergyFormNumber bit null
go

update dbo.WorkPermitEdmontonHistory set UseCurrentPermitNumberForZeroEnergyFormNumber = 0
go

alter table dbo.WorkPermitEdmontonHistory alter column UseCurrentPermitNumberForZeroEnergyFormNumber bit not null
go


GO

