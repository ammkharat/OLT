
Declare @sitename varchar(40) = 'Turnaround'
declare @ActiveDirectoryName varchar(40) = 'Turnaround'
declare @siteid bigint = 17
declare @plantid bigint = 1388

if not exists(select 1 from site where site.id = @siteid)
begin
	INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (@siteid, @sitename, 'Mountain Standard Time', @ActiveDirectoryName);
end

SET IDENTITY_INSERT dbo.Plant ON;
if not exists(select 1 from plant where plant.id = @plantid)
begin
	INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (@plantid, @sitename, @siteid)
end
SET IDENTITY_INSERT dbo.Plant OFF;

-- site configuration
delete userloginhistoryfunctionallocation from userloginhistoryfunctionallocation ulfl inner join functionallocation fl on ulfl.functionallocationid = fl.id and fl.siteid = @siteid
delete userloginhistory from userloginhistory ul inner join [shift] s on ul.shiftid = s.id and s.siteid = @siteid
delete [Shift] where SiteId = @siteid
	INSERT INTO dbo.[Shift] ([Name], [StartTime], [EndTime], [CreatedDateTime], SiteId)
	VALUES (
	  'D'  -- Name
	  ,'08:00:00'  -- StartTime
	  ,'20:00:00'  -- EndTime
	  ,getdate()  -- CreatedDateTime
	  ,@siteid
	),
	(  'N'  -- Name
	  ,'20:00:00'  -- StartTime
	  ,'08:00:00'  -- EndTime
	  ,getdate()  -- CreatedDateTime
	  ,@siteid
	)

delete ActionItemDefinitionAutoReApprovalConfiguration where siteid = @siteid
delete TargetDefinitionAutoReApprovalConfiguration where siteid = @siteid
insert into ActionItemDefinitionAutoReApprovalConfiguration values (@siteid, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
insert into TargetDefinitionAutoReApprovalConfiguration values (@siteid, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

--- temporarily disable all floc indexes to speed up bulk insert

ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
GO

ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO

ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;
GO


Declare @sitename varchar(40) = 'Turnaround'
declare @ActiveDirectoryName varchar(40) = 'Turnaround'
declare @siteid bigint = 17
declare @plantid bigint = 1388

delete businesscategoryflocassociation from businesscategoryflocassociation bc inner join functionallocation fl on bc.functionallocationid = fl.id and fl.siteid = @siteid
delete from FunctionalLocationAncestor from FunctionalLocationAncestor inner join FunctionalLocation on FunctionalLocationAncestor.AncestorId = FunctionalLocation.Id and FunctionalLocation.SiteId = @siteid
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join FunctionalLocation on WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.SiteId = @siteid
delete from FunctionalLocationOperationalMode from FunctionalLocationOperationalMode inner join FunctionalLocation on FunctionalLocationOperationalMode.UnitId = FunctionalLocation.Id and FunctionalLocation.SiteId = @siteid
delete from FunctionalLocation where SiteId = @siteid
go

Declare @sitename varchar(40) = 'Turnaround'
declare @ActiveDirectoryName varchar(40) = 'Turnaround'
declare @siteid bigint = 17
declare @plantid bigint = 1388

if not exists (select 1 from functionallocation where siteid = @siteid and level = 1)
begin
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Turnaround', N'TA1', 0, 0, 1, @plantid, N'en', 2)
end
if not exists (select 1 from functionallocation where siteid = @siteid and level = 2)
begin
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'General', N'TA1-001', 0, 0, 2, @plantid, N'en', 2)
end

--up1
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'UPGRADER 1, BASE PLANT',N'UP1',0,0,1,@plantid,N'en',1)
,(@siteid,N'UP1 UPGRADER 1 FACILITIES',N'UP1-FACL',0,0,2,@plantid,N'en',1)
,(@siteid,N'P1 UPG PIPELINES AND PUMPING',N'UP1-P001',0,0,2,@plantid,N'en',1)
,(@siteid,N'P5 U1 COKER AND DILUENT RECOVERY',N'UP1-P005',0,0,2,@plantid,N'en',1)
,(@siteid,N'P6 U1 HYDROGEN UNIT',N'UP1-P006',0,0,2,@plantid,N'en',1)
,(@siteid,N'P8 U1 SULPHUR UNIT',N'UP1-P008',0,0,2,@plantid,N'en',1)
,(@siteid,N'P7 U1 HYDROTREATERS',N'UP1-P007',0,0,2,@plantid,N'en',1)
,(@siteid,N'P9 U1 DTH GAS COMPRESSION UNIT (SHARED)',N'UP1-P009',0,0,2,@plantid,N'en',1)
,(@siteid,N'P10 U1 COMMON FACILITIES & SOUR WATER',N'UP1-P010',0,0,2,@plantid,N'en',1)
,(@siteid,N'P19 U1 RELIEF & BLOWDOWN',N'UP1-P019',0,0,2,@plantid,N'en',1)
,(@siteid,N'P20 U1 NORTH & SOUTH TANK FARM',N'UP1-P020',0,0,2,@plantid,N'en',1)
,(@siteid,N'P21 U1 OFFPLOTS & VRU',N'UP1-P021',0,0,2,@plantid,N'en',1)
,(@siteid,N'P25 U1 VACUUM UNIT',N'UP1-P025',0,0,2,@plantid,N'en',1)
,(@siteid,N'P31 NATURAL GAS OPERATING (SHARED)',N'UP1-P031',0,0,2,@plantid,N'en',1)
,(@siteid,N'P32 U1 COOLING AND SERVICE WATER (SHARED)',N'UP1-P032',0,0,2,@plantid,N'en',1)
,(@siteid,N'P61 UPG NATURAL GAS',N'UP1-P061',0,0,2,@plantid,N'en',1)
,(@siteid,N'UP1 PROCESS AUTOMATION SYSTEMS',N'UP1-PASS',0,0,2,@plantid,N'en',1)
,(@siteid,N'P33 UPG FIRE PROTECTION (SHARED)',N'UP1-P033',0,0,2,@plantid,N'en',1)
,(@siteid,N'U1,P033,COMMON SYSTEMS',N'UP1-P033-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 33 OPERATIONS',N'UP1-P033-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'UP1 ASSET MANAGEMENT SYSTEMS',N'UP1-PASS-AMS1',0,0,3,@plantid,N'en',1)
,(@siteid,N'UP1 DISTRIBUTED CONTROL SYSTEMS',N'UP1-PASS-DCS1',0,0,3,@plantid,N'en',1)
,(@siteid,N'UP1 MONITORING SYSTEMS',N'UP1-PASS-HMI1',0,0,3,@plantid,N'en',1)
,(@siteid,N'UP1 PROGRAMABLE LOGIC CONTROLLERS',N'UP1-PASS-PLC1',0,0,3,@plantid,N'en',1)
,(@siteid,N'UP1 SAFETY INSTRUMENTED SYSTEMS',N'UP1-PASS-SIS1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P061,COMMON SYSTEMS',N'UP1-P061-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'NATURAL GAS',N'UP1-P061-NGAS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 61 OPERATIONS',N'UP1-P061-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P032,COMMON SYSTEMS',N'UP1-P032-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'COOLING WATER',N'UP1-P032-CWTR',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 32 OPERATIONS',N'UP1-P032-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P031,COMMON SYSTEMS',N'UP1-P031-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'NATURAL GAS',N'UP1-P031-NGAS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 31 OPERATIONS',N'UP1-P031-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1.P025,COMMON SYSTEMS',N'UP1-P025-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'DILUENT RECOVERY UNIT #2',N'UP1-P025-DRU2',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 25 OPERATIONS',N'UP1-P025-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'VACUUM UNIT #1',N'UP1-P025-VAC1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P021,COMMON SYSTEMS',N'UP1-P021-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P021,NORTH TANK FARM',N'UP1-P021-NTF1',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 21 OPERATIONS',N'UP1-P021-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'PIPERACKS & PIPELINES',N'UP1-P021-PPL1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P021,SOUTH TANK FARM',N'UP1-P021-STF1',0,0,3,@plantid,N'en',1)
,(@siteid,N'VAPOR RECOVERY UNIT #1',N'UP1-P021-VRU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P020,COMMON SYSTEMS',N'UP1-P020-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P020,NORTH TANK FARM',N'UP1-P020-NTF1',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 20 OPERATIONS',N'UP1-P020-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P020,SOUTH TANK FARM',N'UP1-P020-STF1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P019,COMMON SYSTEMS',N'UP1-P019-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'UPGRADING #1 FLARE SYSTEM',N'UP1-P019-FLAR',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT19 OPERATIONS',N'UP1-P019-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P010,COMMON SYSTEMS',N'UP1-P010-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'EXCESS RFG COMPRESSOR',N'UP1-P010-FGAS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 10 OPERATIONS',N'UP1-P010-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 10 OPERATIONS PRIMARY',N'UP1-P010-OPPR',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 10 OPERATIONS RFG COMPRESSION',N'UP1-P010-OPRF',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P010,PRIMARY UPGRADING SYSTEMS',N'UP1-P010-PRIM',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P010,SECONDARY UPGRADING SYSTEMS',N'UP1-P010-SCND',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P009,COMMON SYSTEMS',N'UP1-P009-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'FEEDGAS (COMPRESSION & DEHYDRATION)',N'UP1-P009-FGAS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 9 OPERATIONS',N'UP1-P009-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P007,COMMON SYSTEMS',N'UP1-P007-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'GAS OIL HYDROTREATER UNIT #1',N'UP1-P007-GHU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'KEROSENE HYDROTREATER UNIT #1',N'UP1-P007-KHU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'NAPHTHA HYDROTREATER UNIT #1',N'UP1-P007-NHU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 7 OPERATIONS',N'UP1-P007-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'AMINE UNIT #1',N'UP1-P008-AMN1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P008,COMMON SYSTEMS',N'UP1-P008-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 8 OPERATIONS',N'UP1-P008-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'SULPHUR RECOVERY UNIT #1',N'UP1-P008-SRU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'SULPHUR RECOVERY UNIT #2',N'UP1-P008-SRU2',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1 SULPHUR RECOVERY COMMON / TOU1',N'UP1-P008-SRUF',0,0,3,@plantid,N'en',1)
,(@siteid,N'SUPERCLAUS & INCINERATOR',N'UP1-P008-SUPC',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLT 8 TEMP COOLING TWR',N'UP1-P008-TCT2',0,0,3,@plantid,N'en',1)
,(@siteid,N'CATACARB',N'UP1-P006-CATA',0,0,3,@plantid,N'en',1)
,(@siteid,N'HYDROGEN PRODUCT COMPRESSOR UNIT #1',N'UP1-P006-CMP1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P006,COMMON SYSTEMS',N'UP1-P006-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 6 OPERATIONS',N'UP1-P006-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'HYDROGEN REFORMER UNIT #1',N'UP1-P006-RFR1',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P005,COMMON SYSTEMS',N'UP1-P005-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'DELAYED COKING UNIT #1',N'UP1-P005-DCU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'DILUENT RECOVERY UNIT #1',N'UP1-P005-DRU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'FRACTIONATOR #1',N'UP1-P005-FRC1',0,0,3,@plantid,N'en',1)
,(@siteid,N'GAS OIL RECOVERY UNIT #1',N'UP1-P005-GRU1',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 5 OPERATIONS',N'UP1-P005-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P001,COMMON SYSTEMS',N'UP1-P001-COMS',0,0,3,@plantid,N'en',1)
,(@siteid,N'U1,P001,NORTH TANK FARM UNIT #1',N'UP1-P001-NTF1',0,0,3,@plantid,N'en',1)
,(@siteid,N'PLANT 1 OPERATIONS',N'UP1-P001-OPER',0,0,3,@plantid,N'en',1)
,(@siteid,N'UPGRADER 1 SPECIALTY TOOLS/EQUIPMENT',N'UP1-FACL-TOOL',0,0,3,@plantid,N'en',1)


--Declare @sitename varchar(40) = 'Turnaround'
--declare @ActiveDirectoryName varchar(40) = 'Turnaround'
--declare @siteid bigint = 17
--declare @plantid bigint = 1388

--up2

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) 
VALUES (@siteid, N'UPGRADER 2, MILLENNIUM',N'UP2',0,0,1,@plantid,N'en',1)
,(@siteid, N'UP2 UPGRADER 2 FACILITIES',N'UP2-FACL',0,0,2,@plantid,N'en',1)
,(@siteid, N'P52 U2 COKER AND DILUENT RECOVERY',N'UP2-P052',0,0,2,@plantid,N'en',1)
,(@siteid, N'P53 U2 SULPHUR UNIT',N'UP2-P053',0,0,2,@plantid,N'en',1)
,(@siteid, N'P55 U2 HYDROTREATERS',N'UP2-P055',0,0,2,@plantid,N'en',1)
,(@siteid, N'P59 U2 RELIEF & BLOWDOWN',N'UP2-P059',0,0,2,@plantid,N'en',1)
,(@siteid, N'P64 U2 NAPHTHA HYDROTREATER UNIT',N'UP2-P064',0,0,2,@plantid,N'en',1)
,(@siteid, N'P66 U2 HYDROGEN UNIT',N'UP2-P066',0,0,2,@plantid,N'en',1)
,(@siteid, N'P68 U2 SULPHUR UNIT',N'UP2-P068',0,0,2,@plantid,N'en',1)
,(@siteid, N'P56 U2 UTILITIES & OFFSITES',N'UP2-P056',0,0,2,@plantid,N'en',1)
,(@siteid, N'P57 U2 VACUUM UNIT',N'UP2-P057',0,0,2,@plantid,N'en',1)
,(@siteid, N'P34 UPG INDUSTRIAL SEWER & SEWAGE TREATM',N'UP2-P034',0,0,2,@plantid,N'en',1)
,(@siteid, N'UP2 PROCESS AUTOMATION SYSTEMS',N'UP2-PASS',0,0,2,@plantid,N'en',1)
,(@siteid, N'P54 U2 HYDROGEN UNIT',N'UP2-P054',0,0,2,@plantid,N'en',1)
,(@siteid, N'HYDROGEN PRODUCT COMPRESSOR UNIT #2',N'UP2-P054-CMP2',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P054,COMMON SYSTEMS',N'UP2-P054-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PSA UNIT #1',N'UP2-P054-PSA1',0,0,3,@plantid,N'en',1)
,(@siteid, N'HYDROGEN REFORMER UNIT #2',N'UP2-P054-RFR2',0,0,3,@plantid,N'en',1)
,(@siteid, N'NAPHTHA HYDROTREATER UNIT #2',N'UP2-P055-NHU2',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P056,COMMON SYSTEMS',N'UP2-P056-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'BUILDING & GROUNDS',N'UP2-P034-BLDG',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P034,COMMON SYSTEMS',N'UP2-P034-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 34 SEWAGE & PONDS',N'UP2-P034-SEWG',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 34 SLOP WATER SYSTEM',N'UP2-P034-SLOP',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 34 WASTE WATER SYSTEM',N'UP2-P034-WAST',0,0,3,@plantid,N'en',1)
,(@siteid, N'UP2 ASSET MANAGEMENT SYSTEMS',N'UP2-PASS-AMS2',0,0,3,@plantid,N'en',1)
,(@siteid, N'UP2 DISTRIBUTED CONTROL SYSTEMS',N'UP2-PASS-DCS2',0,0,3,@plantid,N'en',1)
,(@siteid, N'UP2 MONITORING SYSTEMS',N'UP2-PASS-HMI2',0,0,3,@plantid,N'en',1)
,(@siteid, N'UP2 PROGRAMABLE LOGIC CONTROLLERS',N'UP2-PASS-PLC2',0,0,3,@plantid,N'en',1)
,(@siteid, N'UP2 SAFETY INSTRUMENTED SYSTEMS',N'UP2-PASS-SIS2',0,0,3,@plantid,N'en',1)
,(@siteid, N'DELAYED COKING UNIT #2',N'UP2-P052-DCU2',0,0,3,@plantid,N'en',1)
,(@siteid, N'FRACTIONATOR #2',N'UP2-P052-FRC2',0,0,3,@plantid,N'en',1)
,(@siteid, N'API UNIT #1',N'UP2-P034-API1',0,0,3,@plantid,N'en',1)
,(@siteid, N'DILUENT RECOVERY UNIT #3',N'UP2-P052-DRU3',0,0,3,@plantid,N'en',1)
,(@siteid, N'SULPHUR RECOVERY UNIT #4',N'UP2-P053-SRU4',0,0,3,@plantid,N'en',1)
,(@siteid, N'SULPHUR RECOVERY COMMON FACILITIES',N'UP2-P053-SRUF',0,0,3,@plantid,N'en',1)
,(@siteid, N'GAS OIL HYDROTREATER UNIT #2',N'UP2-P055-GHU2',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 56 STM, BFW, COND',N'UP2-P056-STEM',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 56 COOLING WATER',N'UP2-P056-WAT1',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P053,COMMON SYSTEMS',N'UP2-P053-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'SULPHUR RECOVERY UNIT #3',N'UP2-P053-SRU3',0,0,3,@plantid,N'en',1)
,(@siteid, N'PEW SYSTEM',N'UP2-P056-PEW2',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 56 PIPERACKS & RD COOLERS',N'UP2-P056-PPL2',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P068,COMMON UTILITIES',N'UP2-P068-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'SULPHUR RECOVERY COMMON FACILITIES',N'UP2-P068-SRUF',0,0,3,@plantid,N'en',1)
,(@siteid, N'SOUR WATER SYSTEM 3',N'UP2-P068-SWS3',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 53 TGTU',N'UP2-P053-TGTU',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 57 VACUUM UNIT',N'UP2-P057-VAC2',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 34 OPERATIONS',N'UP2-P034-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 52 OPERATIONS',N'UP2-P052-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 53 OPERATIONS',N'UP2-P053-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 54 OPERATIONS',N'UP2-P054-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 55 OPERATIONS',N'UP2-P055-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 56 OPERATIONS',N'UP2-P056-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 57 OPERATIONS',N'UP2-P057-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 59 OPERATIONS',N'UP2-P059-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 64 OPERATIONS',N'UP2-P064-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 66 OPERATIONS',N'UP2-P066-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 68 OPERATIONS',N'UP2-P068-OPER',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P057,COMMON SYSTEMS',N'UP2-P057-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'SULPHUR RECOVERY UNIT #5',N'UP2-P068-SRU5',0,0,3,@plantid,N'en',1)
,(@siteid, N'BUILDING & GROUNDS',N'UP2-P056-BLDG',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 56 API & COKE PIT',N'UP2-P056-CKPT',0,0,3,@plantid,N'en',1)
,(@siteid, N'AMINE UNIT #3',N'UP2-P068-AMN3',0,0,3,@plantid,N'en',1)
,(@siteid, N'HYDROGEN PRODUCT COMPRESSOR UNIT #3',N'UP2-P066-CMP3',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P066,COMMON SYSTEMS',N'UP2-P066-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PSA UNIT #2',N'UP2-P066-PSA2',0,0,3,@plantid,N'en',1)
,(@siteid, N'HYDROGEN REFORMER UNIT #3',N'UP2-P066-RFR3',0,0,3,@plantid,N'en',1)
,(@siteid, N'NAPHTHA HYDROTREATERS #3',N'UP2-P064-NHU3',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P059,COMMON SYSTEMS',N'UP2-P059-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'HYDROCARBON FLARE',N'UP2-P059-HCFL',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P055,COMMON SYSTEMS',N'UP2-P055-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'DILUENT RECOVERY UNIT #4',N'UP2-P057-DRU4',0,0,3,@plantid,N'en',1)
,(@siteid, N'AMINE UNIT #2',N'UP2-P053-AMN2',0,0,3,@plantid,N'en',1)
,(@siteid, N'THERMAL OXIDIZER UNIT #2',N'UP2-P053-TOU2',0,0,3,@plantid,N'en',1)
,(@siteid, N'U2,P052,COMMON SYSTEMS',N'UP2-P052-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'GAS RECOVERY UNIT 2',N'UP2-P052-GRU2',0,0,3,@plantid,N'en',1)
,(@siteid, N'SOUR WATER SYSTEM UNIT #2',N'UP2-P053-SWS2',0,0,3,@plantid,N'en',1)
,(@siteid, N'UPGRADER 2 SPECIALTY TOOLS/EQUIPMENT',N'UP2-FACL-TOOL',0,0,3,@plantid,N'en',1)


--Declare @sitename varchar(40) = 'Turnaround'
--declare @ActiveDirectoryName varchar(40) = 'Turnaround'
--declare @siteid bigint = 17
--declare @plantid bigint = 1388

--eu1

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) 
VALUES (@siteid, N'OS ENERGIES & UTILITIES',N'EU1',0,0,1,@plantid,N'en',1)
,(@siteid, N'DISTRIBUTION SYSTEMS',N'EU1-DIST',0,0,2,@plantid,N'en',1)
,(@siteid, N'PLT 36  ELECTROSTATIC PRECIPITATOR',N'EU1-P036',0,0,2,@plantid,N'en',1)
,(@siteid, N'FLUE GAS DESULPHURIZATION',N'EU1-P037',0,0,2,@plantid,N'en',1)
,(@siteid, N'PLT 38 WATER TREATMENT PLANT',N'EU1-P038',0,0,2,@plantid,N'en',1)
,(@siteid, N'POPLAR CREEK COGEN',N'EU1-P039',0,0,2,@plantid,N'en',1)
,(@siteid, N'STEAM POWER GENERATION&WATER TREATMENT',N'EU1-P031',0,0,2,@plantid,N'en',1)
,(@siteid, N'COOLING AND SERVICE WATER FACILITIES',N'EU1-P032',0,0,2,@plantid,N'en',1)
,(@siteid, N'AUXILIARY BOILER HOUSE',N'EU1-P035',0,0,2,@plantid,N'en',1)
,(@siteid, N'INDUSTRIAL WASTE WATER COLLECTION SYS',N'EU1-P313',0,0,2,@plantid,N'en',1)
,(@siteid, N'SB POTABLE WATER & SEWAGE TREATMENT PLT',N'EU1-P314',0,0,2,@plantid,N'en',1)
,(@siteid, N'EU1 PROCESS AUTOMATION SYSTEMS',N'EU1-PASS',0,0,2,@plantid,N'en',1)
,(@siteid, N'INDUSTRIAL SEWER AND SEWAGE TREATMENT',N'EU1-P034',0,0,2,@plantid,N'en',1)
,(@siteid, N'UTILITIES WW OFFPLOTS',N'EU1-P056',0,0,2,@plantid,N'en',1)
,(@siteid, N'WASTE MANAGEMENT AND LANDFILLS',N'EU1-P312',0,0,2,@plantid,N'en',1)
,(@siteid, N'INFRASTRUCTURE',N'EU1-P312-IFST',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 56 API5 & RETENTION PONDS',N'EU1-P056-API5',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLANT 34 API4 & RETENTION PONDS',N'EU1-P034-API4',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 CCTV NETWORK',N'EU1-PASS-CCTV',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 LCN1 HONEYWELL DCS',N'EU1-PASS-DCS1',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 LCN2 HONEYWELL DCS',N'EU1-PASS-DCS2',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 DEMILITARIZED ZONE NETWORK',N'EU1-PASS-DMZ1',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 PROCESS CONTROL NETWORK',N'EU1-PASS-PCN1',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 PLC ALLEN BRADLEY',N'EU1-PASS-PLC1',0,0,3,@plantid,N'en',1)
,(@siteid, N'EU1 PLC MOORE',N'EU1-PASS-PLC2',0,0,3,@plantid,N'en',1)
,(@siteid, N'SIS1 MOORE SAFETY PLC',N'EU1-PASS-SIS1',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 BASE BOILER 12',N'EU1-P035-BL12',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 BASE BOILER 13',N'EU1-P035-BL13',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 BASE BOILER 14',N'EU1-P035-BL14',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 BASE BOILER 15',N'EU1-P035-BL15',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 COMMON SYSTEMS',N'EU1-P035-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 FEED WATER SYSTEM',N'EU1-P035-FWDS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 35 INTERMITTENT BLOWDOWN',N'EU1-P035-INBD',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 RAW WATER UTILITY WATER',N'EU1-P032-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 COOLING TOWER',N'EU1-P032-COTW',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 RAW WATER DISTRIBUTION',N'EU1-P032-DIRW',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 RAW WATER LOW LIFT PUMPHOUSE',N'EU1-P032-LLPH',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 PONDS',N'EU1-P032-POND',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 32 RAW WATER RIVER PUMPHOUSE 1',N'EU1-P032-RPH1',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 BASE BOILER 1',N'EU1-P031-BL01',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 BASE BOILER 3',N'EU1-P031-BL03',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 BASE BOILER 4',N'EU1-P031-BL04',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 CHEMICAL FEED',N'EU1-P031-CHTR',0,0,3,@plantid,N'en',1)
,(@siteid, N'FLOCCULANT TANK MIXER PLT 31',N'EU1-P031-CLAR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 BASE COKE SYSTEM',N'EU1-P031-COKE',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 COMMON SYSTEMS',N'EU1-P031-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 FUEL STORAGE AND DISTRIBUTION',N'EU1-P031-FUEL',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 BASE INSTRUMENT AIR',N'EU1-P031-IAIR',0,0,3,@plantid,N'en',1)
,(@siteid, N'MILLENNIUM NAPHTHA UNIT WATER TREATMENT',N'EU1-P031-MNUW',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 POTABLE WATER',N'EU1-P031-POTR',0,0,3,@plantid,N'en',1)
,(@siteid, N'TURBINE GENERATOR 1',N'EU1-P031-TG01',0,0,3,@plantid,N'en',1)
,(@siteid, N'TURBINE GENERATOR 2',N'EU1-P031-TG02',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 31 WATER TREATMENT',N'EU1-P031-WTRT',0,0,3,@plantid,N'en',1)
,(@siteid, N'COMMON SYSTEMS',N'EU1-P039-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'FUEL DISTRIBUTION',N'EU1-P039-FUEL',0,0,3,@plantid,N'en',1)
,(@siteid, N'FEED WATER DISTRIBUTION SYSTEM',N'EU1-P039-FWDS',0,0,3,@plantid,N'en',1)
,(@siteid, N'GAS TURBINE COMMON SYSTEMS',N'EU1-P039-GTCM',0,0,3,@plantid,N'en',1)
,(@siteid, N'GAS TURBINE GENERATOR',N'EU1-P039-GTG5',0,0,3,@plantid,N'en',1)
,(@siteid, N'GAS TURBINE GENERATOR NO.6',N'EU1-P039-GTG6',0,0,3,@plantid,N'en',1)
,(@siteid, N'HEAT RECOVERY STEAM GENERATOR NO.5',N'EU1-P039-HSG5',0,0,3,@plantid,N'en',1)
,(@siteid, N'HEAT RECOVERY STEAM GENERATOR NO.6',N'EU1-P039-HSG6',0,0,3,@plantid,N'en',1)
,(@siteid, N'INSTRUMENT AIR SYSTEM',N'EU1-P039-IAIR',0,0,3,@plantid,N'en',1)
,(@siteid, N'INFRASTRUCTURE',N'EU1-P039-IFST',0,0,3,@plantid,N'en',1)
,(@siteid, N'STEAM TURBINE GENERATOR NO.3',N'EU1-P039-STG3',0,0,3,@plantid,N'en',1)
,(@siteid, N'STEAM TURBINE GENERATOR NO.4',N'EU1-P039-STG4',0,0,3,@plantid,N'en',1)
,(@siteid, N'STEAM TURBINE GENERATOR NO.3',N'EU1-P039-TG03',0,0,3,@plantid,N'en',1)
,(@siteid, N'STEAM TURBINE GENERATOR NO.4',N'EU1-P039-TG04',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 CHEMICAL FEED',N'EU1-P038-CHTR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 CLARIFIER WATER',N'EU1-P038-CLAR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 COMMON SYSTEMS',N'EU1-P038-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 TREATED WATER FILTERS',N'EU1-P038-FITR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 LIME REACTOR WATER',N'EU1-P038-LIME',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 POTABLE WATER',N'EU1-P038-POTR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 38 BASE WATER TREATMENT',N'EU1-P038-WTRT',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 COMMON SYSTEMS',N'EU1-P037-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 ENVIRONMENT DISTRIBUTION',N'EU1-P037-DIEN',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 BASE FGD PLANT',N'EU1-P037-FGDP',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 FLUE GAS SYSTEMS',N'EU1-P037-FLGS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 GYPSUM PONDING',N'EU1-P037-GYPD',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 LIMESTONE PREPARATION',N'EU1-P037-LIPR',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 37 SO2 SCRUBBING',N'EU1-P037-SO2S',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 COMMON SYSTEMS',N'EU1-P036-COMS',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 BASE ESP 1',N'EU1-P036-ESP1',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 BASE ESP 2',N'EU1-P036-ESP2',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 BASE ESP 3',N'EU1-P036-ESP3',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 BASE FLY ASH SYSTEM',N'EU1-P036-FASH',0,0,3,@plantid,N'en',1)
,(@siteid, N'PLT 36 BASE STACK 31',N'EU1-P036-STAK',0,0,3,@plantid,N'en',1)
,(@siteid, N'DIESEL SYSTEM',N'EU1-DIST-DISL',0,0,3,@plantid,N'en',1)
,(@siteid, N'LOW PRESSURE NATURAL GAS SYSTEM',N'EU1-DIST-NATG',0,0,3,@plantid,N'en',1)
,(@siteid, N'POND F AND POND EFFLUENT WATER TIE IN',N'EU1-DIST-PNDF',0,0,3,@plantid,N'en',1)
,(@siteid, N'POTABLE WATER SYSTEM',N'EU1-DIST-PTWR',0,0,3,@plantid,N'en',1)
,(@siteid, N'SANITARY SEWER SYSTEM',N'EU1-DIST-SSWR',0,0,3,@plantid,N'en',1)

--Declare @sitename varchar(40) = 'Turnaround'
--declare @ActiveDirectoryName varchar(40) = 'Turnaround'
--declare @siteid bigint = 17
--declare @plantid bigint = 1388
--COMMIT TRANSACTION
go

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
GO

Declare @sitename varchar(40) = 'Turnaround'
declare @siteid bigint = 17
declare @plantid bigint = 1388

---------------------------------------------------
---  Insert Operational Modes for each Unit   ---
---------------------------------------------------

	BEGIN TRANSACTION
	INSERT INTO FunctionalLocationOperationalMode
	( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
	(
		Select
			FunctionalLocation.Id,
			0,
			0,
			GETDATE()
		FROM
			FunctionalLocation
		WHERE
			SiteId = @siteid
			AND Level = 3
			AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
	)
	COMMIT TRANSACTION

Go

Declare @sitename varchar(40) = 'Turnaround'
declare @siteid bigint = 17
declare @plantid bigint = 1388

--testing temp off
----------------------------------------------------
----  Update Ancestor Table                           ---
----------------------------------------------------
-- create a temp index for fast querying
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([SiteId] , [Level])
INCLUDE ([FullHierarchy],[Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = OFF
)
ON [PRIMARY];
  

-- Insert the Ancestor records for the new site Flocs


	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
		SELECT 
			c.id, a.id, a.[Level]
			FROM FunctionalLocation a
			INNER JOIN FunctionalLocation c 
				ON c.siteid = a.siteid and 
				c.[Level] > a.[Level] and
				CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
			where
				c.SiteId = 17--@SiteId
	)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];

--???? needs calrification
--insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Operator Handover Questions',0
--insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Supervisor Handover Questions',0

delete SiteConfiguration where siteid = @siteid
insert into SiteConfiguration ( 
SiteId,
DaysToDisplayActionItems,
DaysToDisplayShiftLogs,
DaysBeforeArchivingClosedWorkPermits,
DaysBeforeDeletingPendingWorkPermits,
DaysBeforeClosingIssuedWorkPermits,
AutoApproveWorkOrderActionItemDefinition,
AutoApproveSAPAMActionItemDefinition,
AutoApproveSAPMCActionItemDefinition,
CreateOperatingEngineerLogs,
WorkPermitNotApplicableAutoSelected,
WorkPermitOptionAutoSelected,
OperatingEngineerLogDisplayName,
DaysToEditDeviationAlerts,
DaysToDisplayShiftHandovers,
SummaryLogFunctionalLocationDisplayLevel,
ShowActionItemsByWorkAssignmentOnPriorityPage,
DaysToDisplayDeviationAlerts,
AllowStandardLogAtSecondLevelFunctionalLocation,
DorCutoffTime,
DaysToDisplayWorkPermitsBackwards,
DaysToDisplayLabAlerts,
LabAlertRetryAttemptLimit,
RequireActionItemResponseLog,
ActionItemRequiresApprovalDefaultValue,
HideDORCommentEntry,
DaysToDisplayCokerCards,
ActionItemRequiresResponseDefaultValue,
ShowActionItemsOnShiftHandover,
UseNewPriorityPage,
ShowShiftHandoversByWorkAssignmentOnPriorityPage,
DaysToDisplayDirectivesOnPriorityPage,
DaysToDisplayShiftHandoversOnPriorityPage,
DisplayActionItemWorkAssignmentOnPriorityPage,
DaysToDisplayPermitRequestsBackwards,
DaysToDisplayPermitRequestsForwards,
DaysToDisplayWorkPermitsForwards,
DisplayActionItemCommentOnly,
DefaultNumberOfCopiesForWorkPermits,
ShowFollowupOnLogForm,
AllowCreateALogForEachSelectedFlocOnLogForm,
ShowAdditionalDetailsOnLogFormByDefault,
Culture,
ShowWorkPermitPrintingTabInPreferences,
ShowDefaulPermitTimesTabInPreferences,
DaysToDisplayTargetAlertsOnPriorityPage,
LoginFlocSelectionLevel,
UseCreatedByColumnForLogs,
ShowIsModifiedColumnForLogs,
ItemFlocSelectionLevel,
DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
PreShiftPaddingInMinutes,
PostShiftPaddingInMinutes,
DaysToDisplayFormsBackwards,
DaysToDisplayFormsForwards,
DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
DaysToDisplayFormsBackwardsOnPriorityPage,
FormsFlocSetTypeId,
DaysToDisplaySAPNotificationsBackwards,
ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab,
AllowCombinedShiftHandoverAndLog,
ShowCreateShiftHandoverMessageFromNewLogClick,
DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
DefaultTargetDefinitionRequiresResponseWhenAlertedValue,
CollectAnalyticsData,
DaysToDisplayDirectivesBackwards,
DaysToDisplayDirectivesForwards,
UseLogBasedDirectives,
ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab,
RememberActionItemWorkAssignment,
MaximumDirectiveFLOClevel,
MaximumAllowableExcursionEventDurationMins,
MaximumAllowableExcursionEventTimeframeMins,
DaysToDisplayEventsBackwards,
DaysToDisplayDocumentSuggestionFormsBackwards,
DaysToDisplayDocumentSuggestionFormsForwards,
DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage)  
select 
@siteid,
7,7,7,7,1,1,1,1,1,1,1,'Chief Engineer Log', -- OperatingEngineerLogDisplayName
7,7,2,0,30,1,'Jan  1 1900 10:00AM', -- DorCutoffTime
15,30,3, 1,0,1,14, -- DaysToDisplayCokerCards
1,1,1,0,3,3, -- DaysToDisplayShiftHandoversOnPriorityPage
1,0,0,0,1,1,1,1,0, -- ShowAdditionalDetailsOnLogFormByDefault
'en',0,0,0,3,0,0,5,1, -- DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs
2, 2, -- PreShiftPaddingInMinuts, PostShiftPaddingInMinutes
3,null,1,3,0,1, -- DaysToDisplaySAPNotificationsBackwards
1,0,0,null,0,1, -- CollectAnalyticsData
3,null,0,0,0,1, -- MaximumDirectiveFLOCLevel
0,120,0, -- DaysToDisplayEventsBackwards
30,null,30 -- DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage

delete from  BusinessCategoryFLOCAssociation from BusinessCategoryFLOCAssociation bc inner join BusinessCategory b on bc.BusinessCategoryId = b.Id and b.SiteId = @siteid
delete BusinessCategory where SiteId = @siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Key Performance Indicators','KPIs',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = @siteid and f.FullHierarchy = 'TA1' and bc.SiteId = @siteid and bc.Deleted = 0


-- roles


--SET IDENTITY_INSERT [Role] ON;
--249 is the last id in role table
delete from RoleElementTemplate from RoleElementTemplate re inner join role r on re.RoleId = r.Id and r.SiteId = @siteid
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation wf inner join FunctionalLocation f on wf.FunctionalLocationId = f.id and f.SiteId = @siteid
delete from WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup wg inner join WorkAssignment w on wg.WorkAssignmentId = w.Id and w.SiteId = @siteid
delete WorkAssignment where SiteId = @siteid
delete role where role.SiteId = @siteid

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Manager', 0, 'Manager', @siteid, 0, 0, 0, 1, 'manager',0);
--Insert role elements here too to get the identity_current of role table
-- Administrator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Configure Business Categories, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Associate Business Categories To Functional Locations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (113,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Log Guidelines, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Summary Log Custom Fields, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Edit Log Templates, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,IDENT_CURRENT('ROLE')); 			-- Admin - Reports - Configure Plant Historian Tag List, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (120,IDENT_CURRENT('ROLE')); 		-- Admin - Shift Handovers - Edit Shift Handover Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (206,IDENT_CURRENT('ROLE')); 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (76,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Display Limits, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (136,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Default Tabs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (141,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Work Assignment Not Selected Warning, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Unc Paths for Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Priorities Page, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Site Communications, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (237,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Functional Locations, Administrator


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Director', 0, 'Director', @siteid, 0, 0, 0, 1, 'director',0);
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Area Manager


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Team Lead', 0, 'TeamLead', @siteid, 0, 0, 0, 1, 'teamlead',0);
-- Operating / Chief Engineer Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (63,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (64,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (65,IDENT_CURRENT('ROLE')); 			-- Logs - Cancel Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - Process SAP Notifications, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operating / Chief Engineer




insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Analyst', 0, 'Analyst', @siteid, 0, 0, 0, 1, 'analyst',0);
-- Operator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - Process SAP Notifications, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Create Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Edit Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (117,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Delete Shift Handover Questionnaire, Operator



insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Technical Administrator', 0, 'TechnicalAdmin', @siteid, 0, 0, 0, 0, 'techadmin',0);
---- Technical Administrator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Site Communications, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (202,IDENT_CURRENT('ROLE')); 		-- Technical Admin - Perform Tech Admin Tasks, Technical Administrator


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Administrator', 0, 'Administrator', @siteid, 1, 0, 0, 1, 'admin',0);
--Insert role elements here too to get the identity_current of role table
-- Administrator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Configure Business Categories, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Associate Business Categories To Functional Locations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (113,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Log Guidelines, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Summary Log Custom Fields, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Edit Log Templates, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,IDENT_CURRENT('ROLE')); 			-- Admin - Reports - Configure Plant Historian Tag List, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (120,IDENT_CURRENT('ROLE')); 		-- Admin - Shift Handovers - Edit Shift Handover Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (206,IDENT_CURRENT('ROLE')); 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (76,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Display Limits, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (136,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Default Tabs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (141,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Work Assignment Not Selected Warning, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Unc Paths for Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Priorities Page, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Site Communications, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (237,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Functional Locations, Administrator

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Read User', 0, 'ReadUser', @siteid, 0, 1, 0, 0, 'read', 1);
--insert role elements for read user
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User



--update Role set WarnIfWorkAssignmentNotSelected = 0 where SiteId = 15 and Name in ('Read User', 'Technical Administrator')  
--go  

-------------------------------- Work Assignments Start --------------------------------------

insert into WorkAssignment 
(Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Project Controls Manager','Project Controls Manager',@siteid, 0, (select ID from Role where SiteId=@SiteId and Name='Manager'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Turnaround Support','Turnaround Support',@siteid, 0, (select id from Role where SiteId=@siteid and Name='Director'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('SPS Lead','',@siteid, 0, (select id from Role where SiteId = @siteid and Name='Team Lead'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E13 Day Shift Analyst','',@siteid, 0, (select id from Role where SiteId=@siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E13 Night Shift Analyst','',@siteid, 0, (select id from Role where SiteId=@siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E14 Day Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E14 Night Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);


insert into WorkAssignment 
([Name], Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E15 Day Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E15 Night Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E16 Day Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('E16 Night Shift Analyst','',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Analyst'), 'General', 1, 1, 0, 1);

-------------------------------- Work Assignment Functional Locations Start --------------------------------------

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'Project Controls Manager' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'Turnaround Support' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'SPS Lead' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E13 Day Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E13 Night Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E14 Day Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E14 Night Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E15 Day Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E15 Night Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E16 Day Shift Analyst' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TA1' and a.name = 'E16 Night Shift Analyst' and a.SiteId = @siteid;
-------------------------------- Visibility Group Start --------------------------------------

--SET IDENTITY_INSERT [VisibilityGroup] ON;
delete  VisibilityGroup where siteid = @siteid

insert into VisibilityGroup ([Name], SiteId, IsSiteDefault, [Deleted])
select 'Operations', @siteid, 1, 0;

--SET IDENTITY_INSERT [VisibilityGroup] OFF;



-------------------------------- Work Assignment Visibiliy Group Start --------------------------------------

--------------------------------------------------------------------------------
---  Insert Work Assignment Visibility Group for each Work Assignment   ---
--------------------------------------------------------------------------------

BEGIN TRANSACTION
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			IDENT_CURRENT('VisibilityGroup'), -- Operations visibility group for the new site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=IDENT_CURRENT('VisibilityGroup') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			IDENT_CURRENT('VisibilityGroup'), -- Operations visibility group for Fort Hills Major Projects
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=IDENT_CURRENT('VisibilityGroup') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)
COMMIT TRANSACTION

GO


If Exists (Select Name from Shift Where SiteId = 6 and Name = 'D')
Begin
	Update Shift
	Set StartTime= '06:00:00', EndTime = '18:00:00'
	Where SiteId = 6 And Name = 'D'
End

If Exists (Select Name from Shift Where SiteId = 6 and Name = 'N')
Begin
	Update Shift
	Set StartTime= '18:00:00', EndTime = '06:00:00'
	Where SiteId = 6 And Name = 'N'
End




GO

