

alter table WorkPermitLubes add GasDetectorBumpTested bit null;
alter table PermitRequestLubes add GasDetectorBumpTested bit null;
alter table WorkPermitLubesHistory add GasDetectorBumpTested bit null;
alter table PermitRequestLubesHistory add GasDetectorBumpTested bit null;
go

update WorkPermitLubes set GasDetectorBumpTested = 0;
update PermitRequestLubes set GasDetectorBumpTested = 0;
update WorkPermitLubesHistory set GasDetectorBumpTested = 0;
update PermitRequestLubesHistory set GasDetectorBumpTested = 0;
go

alter table WorkPermitLubes alter column GasDetectorBumpTested bit not null;
alter table PermitRequestLubes alter column GasDetectorBumpTested bit not null;
alter table WorkPermitLubesHistory alter column GasDetectorBumpTested bit not null;
alter table PermitRequestLubesHistory alter column GasDetectorBumpTested bit not null;
go



GO

