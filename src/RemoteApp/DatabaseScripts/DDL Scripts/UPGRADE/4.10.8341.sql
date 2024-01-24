

alter table WorkPermitLubes alter column TaskDescription varchar(max) null;
alter table WorkPermitLubesHistory alter column TaskDescription varchar(max) null;
alter table WorkPermitLubes alter column OtherHazardsAndOrRequirements varchar(max) null;
alter table WorkPermitLubesHistory alter column OtherHazardsAndOrRequirements varchar(max) null;


alter table PermitRequestLubes alter column Description varchar(max) null;
alter table PermitRequestLubesHistory alter column Description varchar(max) null;
alter table PermitRequestLubes alter column OtherHazardsAndOrRequirements varchar(max) null;
alter table PermitRequestLubesHistory alter column OtherHazardsAndOrRequirements varchar(max) null;
alter table PermitRequestLubes alter column SapDescription varchar(max) null;
alter table PermitRequestLubesHistory alter column SapDescription varchar(max) null;






GO

