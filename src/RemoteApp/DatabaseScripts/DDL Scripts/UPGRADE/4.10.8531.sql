
alter table WorkPermitLubes add EnergizedElectrical tinyint null;
alter table WorkPermitLubesHistory add EnergizedElectrical tinyint null;
alter table PermitRequestLubes add EnergizedElectrical tinyint null;
alter table PermitRequestLubesHistory add EnergizedElectrical tinyint null;
go

update WorkPermitLubes set EnergizedElectrical = 1;
update WorkPermitLubesHistory set EnergizedElectrical = 1;
update PermitRequestLubes set EnergizedElectrical = 1;
update PermitRequestLubesHistory set EnergizedElectrical = 1;
go

alter table WorkPermitLubes alter column EnergizedElectrical tinyint not null;
alter table WorkPermitLubesHistory alter column EnergizedElectrical tinyint not null;
alter table PermitRequestLubes alter column EnergizedElectrical tinyint not null;
alter table PermitRequestLubesHistory alter column EnergizedElectrical tinyint not null;
go


GO

