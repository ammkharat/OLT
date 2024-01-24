

alter table WorkPermitLubesHistory add AtmosphericGasTestRequired bit;
GO

update WorkPermitLubesHistory set AtmosphericGasTestRequired = 0;
GO

alter table WorkPermitLubesHistory alter column AtmosphericGasTestRequired bit not null;


GO

