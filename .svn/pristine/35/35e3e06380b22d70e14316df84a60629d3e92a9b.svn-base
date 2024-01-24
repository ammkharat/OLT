alter table PermitRequestLubes add IsVehicleEntry bit;
GO

update PermitRequestLubes set IsVehicleEntry = 1, WorkPermitTypeId = 2 where WorkPermitTypeId = 3;
GO
update PermitRequestLubes set IsVehicleEntry = 0 where IsVehicleEntry <> 1;
GO

alter table PermitRequestLubes alter column IsVehicleEntry bit not null;
GO

-- -----

alter table PermitRequestLubesHistory add IsVehicleEntry bit;
GO

update PermitRequestLubesHistory set IsVehicleEntry = 1, WorkPermitTypeId = 2 where WorkPermitTypeId = 3;
GO

update PermitRequestLubesHistory set IsVehicleEntry = 0 where IsVehicleEntry <> 1;
GO

alter table PermitRequestLubesHistory alter column IsVehicleEntry bit not null;
GO







GO

