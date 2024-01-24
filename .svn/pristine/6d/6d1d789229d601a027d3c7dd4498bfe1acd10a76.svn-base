alter table WorkPermitLubes add IsVehicleEntry bit;
GO

update WorkPermitLubes set IsVehicleEntry = 1, WorkPermitTypeId = 2 where WorkPermitTypeId = 3;
GO
update WorkPermitLubes set IsVehicleEntry = 0 where IsVehicleEntry <> 1;
GO

alter table WorkPermitLubes alter column IsVehicleEntry bit not null;
GO

-- -----

alter table WorkPermitLubesHistory add IsVehicleEntry bit;
GO

update WorkPermitLubesHistory set IsVehicleEntry = 1, WorkPermitTypeId = 2 where WorkPermitTypeId = 3;
GO

update WorkPermitLubesHistory set IsVehicleEntry = 0 where IsVehicleEntry <> 1;
GO

alter table WorkPermitLubesHistory alter column IsVehicleEntry bit not null;
GO

-- -----

alter table WorkPermitLubes add AtmosphericGasTestRequired bit;
GO

update WorkPermitLubes set AtmosphericGasTestRequired = 0;
GO

alter table WorkPermitLubes alter column AtmosphericGasTestRequired bit not null;





GO

