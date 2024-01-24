Declare @sitename varchar(40) = 'US Pipeline'
declare @ActiveDirectoryName varchar(40) = 'Uspipeline'
declare @TimeZone varchar(100) = 'Eastern Standard Time'
declare @LoginApprev char(3) = 'USP' -- new site (Montreal Sulphur Refinery)
declare @siteid bigint
--select @siteid = site.Id from Site order by site.Id
set @siteid = 18 --@siteid + 1
if not exists(select 1 from site where site.id = 18)
begin
INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (@siteid, @sitename, @TimeZone, @ActiveDirectoryName);
end


-- site configuration
if not exists(select 1 from [Shift] where SiteId = 18)
begin
	INSERT INTO dbo.[Shift] 
	VALUES 
	('Day','2016-03-08 10:21:14.363',18,'07:00:00','19:00:00')
end

	
delete ActionItemDefinitionAutoReApprovalConfiguration where siteid = 18
delete TargetDefinitionAutoReApprovalConfiguration where siteid = 18
insert into ActionItemDefinitionAutoReApprovalConfiguration values (18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
insert into TargetDefinitionAutoReApprovalConfiguration values (18, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
go


GO



delete FunctionalLocationAncestor from FunctionalLocation f inner join FunctionalLocationAncestor a on f.id = a.AncestorId and f.siteid	= 18
delete FunctionalLocationOperationalMode from  FunctionalLocationOperationalMode fm inner join FunctionalLocation f on fm.UnitId = f.Id and f.siteid	= 18
delete WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation wf inner join FunctionalLocation f on wf.FunctionalLocationId = f.id and f.SiteId = 18
delete UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation fh inner join FunctionalLocation f on fh.FunctionalLocationId = f.id and f.siteid = 18
delete ShiftHandoverQuestionnaireFunctionalLocation from ShiftHandoverQuestionnaireFunctionalLocation sf inner join FunctionalLocation f on sf.FunctionalLocationId = f.Id and f.SiteId = 18
delete SummaryLogFunctionalLocation from SummaryLogFunctionalLocation sf inner join FunctionalLocation f on sf.FunctionalLocationId = f.id and f.siteid = 18
delete BusinessCategoryFLOCAssociation from BusinessCategoryFLOCAssociation bf inner join FunctionalLocation f on bf.FunctionalLocationId = f.id and f.siteid = 18
delete FunctionalLocation where siteid = 18
go
declare @plantid bigint
if exists (select * from plant where siteid = 18)
begin
	delete plant where siteid = 18
end
--if exists (select * from plant where plant.id = 7030 and siteid != 18)
--begin
--declare @exitsite bigint
--declare @name nvarchar(50)
--select @name = name from plant where siteid != 18 and id = 7030
--select @exitsite = siteid from plant where siteid != 19 and id = 7030
--delete plant where id = 7030 and name = @name and siteid != 18
--set identity_insert [plant] on;
--	insert into plant (id,name,siteid) values (7031,@name,@exitsite)
--set identity_insert [plant] off;
--end
--if exists (select * from plant where plant.id = 7600 and siteid != 18)
--begin
--select @name = name from plant where siteid != 18 and id = 7600
--select @exitsite = siteid from plant where siteid != 18 and id = 7600

--delete plant where id = 7600 and name = @name and siteid != 18
--set identity_insert [plant] on;
--	insert into plant (id,name,siteid) values (7601,@name,@exitsite)
--set identity_insert [plant] off;
--end
set identity_insert [plant] on;
if not exists(select * from plant where id = 9991 and siteid = 18)
begin
insert into plant (id,name,SiteId) values (9991,'US Pipeline',18)
end

set identity_insert [plant] off;
go




GO



ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;


-- TR2
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'US Pipeline', N'USP', 0, 0, 1, 9991, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'US Pipeline', N'USP-General', 0, 0, 2, 9991, N'en', 2)


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SUNCOR INC PRIVATE CARRIER', N'TR2', 0, 0, 1, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DENVER JET FUEL LINE', N'TR2-RM10', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR2-RM10-DD00-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR2-RM10-DD00-SIC-PLC0801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR2-RM10-DD20-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STATION MAIN PLC', N'TR2-RM10-DD20-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR RTU A/B COMMUNICATIONS TO SCADA', N'TR2-RM10-DD20-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY STATION', N'TR2-RM10-DJ00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR2-RM10-DJ00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-RM10-DJ00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMMERCE CITY STATION', N'TR2-RM10-DJ00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMMERCE CITY STATION', N'TR2-RM10-DJ00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56th AVE. TO COP TERMINAL', N'TR2-RM10-DJ10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR2-RM10-DJ10-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CP0100 DJF NORTH BOND', N'TR2-RM10-DJ10-SEG-CP0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CP0101 DJF MIDDLE BOND', N'TR2-RM10-DJ10-SEG-CP0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CP0102 DJF SOUTH BOND', N'TR2-RM10-DJ10-SEG-CP0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-RM10-DJ10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FM0001 JET LINE METER COP', N'TR2-RM10-DJ10-SIL-FM0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA FLOW METER', N'TR2-RM10-DJ10-SIL-FM_30_0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA PRESSURE TRANSMITTER', N'TR2-RM10-DJ10-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA PRESSURE TRANSMITTER', N'TR2-RM10-DJ10-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COP TERMINAL PRESSURE TRANSMITTER', N'TR2-RM10-DJ10-SIL-P0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA TEMPERATURE TRANSMITTER', N'TR2-RM10-DJ10-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COP TERMINAL TEMPERATURE TRANSMITTER', N'TR2-RM10-DJ10-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COP TERMINAL RECEIPT PIG SIGNAL', N'TR2-RM10-DJ10-SIL-Z0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE, CONTROL & ACTUATOR"', N'TR2-RM10-DJ10-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA CONTROL VALVE', N'TR2-RM10-DJ10-SIV-PCV0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-RM10-DJ10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8J0 56TH AVE 8 DJF CHECK BV', N'TR2-RM10-DJ10-SLE-CV8J0', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA PROVER SUPPLY VALVE', N'TR2-RM10-DJ10-SLE-HV0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA PROVER ISOLATION VALVE', N'TR2-RM10-DJ10-SLE-HV0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA PROVER RETURN VALVE', N'TR2-RM10-DJ10-SLE-HV0105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COP TERMINAL 8 DJF RECEIVER OUTLET VALVE', N'TR2-RM10-DJ10-SLE-HV0112', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8J0 56TH AVE 8 DJF LAUNCHER BYPASS BV', N'TR2-RM10-DJ10-SLE-HV8J0', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8J0A 56TH AVE 8 DJF LAUNCHER BV', N'TR2-RM10-DJ10-SLE-HV8J0A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8J0B 56TH AVE 8 DJF LAUNCHER KICKER BV', N'TR2-RM10-DJ10-SLE-HV8J0B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8J0.2A COP 8 DJF RECEIVER BV', N'TR2-RM10-DJ10-SLE-HV8J0_2A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8J0.2B COP 8 DJF RECEIVER OUTLET BV', N'TR2-RM10-DJ10-SLE-HV8J0_2B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE PLANT 1 DELIVERY VALVE', N'TR2-RM10-DJ10-SLE-MOV0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE PLANT 2 DELIVERY VALVE', N'TR2-RM10-DJ10-SLE-MOV0109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COP TERMINAL DJF RECEIVER BYPASS BV', N'TR2-RM10-DJ10-SLE-MOV8J0_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA 8 DJF LAUNCHER TRAP', N'TR2-RM10-DJ10-SLE-X_30_0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-RM10-DJ10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMM CITY TO DENVER AIRPORT', N'TR2-RM10-DJ10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMM CITY TO DENVER AIRPORT', N'TR2-RM10-DJ10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-RM10-DJ10-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PMP0814 JET FUEL TO COP PUMP', N'TR2-RM10-DJ10-SMP-P0814', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM, COLUMN, TANK, VESSEL, WELLHEAD"', N'TR2-RM10-DJ10-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA STRAINER', N'TR2-RM10-DJ10-SPT-S_30_0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR2-RM10-DJ10-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'56TH AVE STA FIRE PROTECTION', N'TR2-RM10-DJ10-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-RM10-DJ10-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DENVER DIESEL LINE', N'TR2-RM11', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY STATION', N'TR2-RM11-DD00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-RM11-DD00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR2-RM11-DD00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA ML DELIVERY METER', N'TR2-RM11-DD00-SIR-FM801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR2-RM11-DD00-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA P811 FLOW SWITCH', N'TR2-RM11-DD00-SIS-FSLL801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA MOV102 PRESSURE SWITCH', N'TR2-RM11-DD00-SIS-PSHH101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSMITTER', N'TR2-RM11-DD00-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA PRESSURE TRANSMITTER', N'TR2-RM11-DD00-SIT-PTI801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA TEMPERATURE TRANSMITTER', N'TR2-RM11-DD00-SIT-TTI801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-RM11-DD00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA P811 DISCHARGE VALVE', N'TR2-RM11-DD00-SLE-HV802', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA PROVER ISOLATION VALVE', N'TR2-RM11-DD00-SLE-HV803', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA PROVER SUPPLY VALVE', N'TR2-RM11-DD00-SLE-HV804', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA PROVER RETURN VALVE', N'TR2-RM11-DD00-SLE-HV805', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA ML DELIVERY VALVE', N'TR2-RM11-DD00-SLE-MOV102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA P811 TO ML DELIVERY VALVE', N'TR2-RM11-DD00-SLE-MOV801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-RM11-DD00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMMERCE CITY STATION', N'TR2-RM11-DD00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMMERCE CITY STATION', N'TR2-RM11-DD00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-RM11-DD00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA DIESEL TO UPRR PUMP ASSY', N'TR2-RM11-DD00-SMP-P811', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR2-RM11-DD00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA FM801 MANIFOLD STRAINER', N'TR2-RM11-DD00-SPT-S801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR2-RM11-DD00-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-RM11-DD00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY MOV TO LAUNCHER THERMAL RELIEF', N'TR2-RM11-DD00-SSR-PRV801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA P811 TO MOV THERMAL RELIEF', N'TR2-RM11-DD00-SSR-PRV802', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY TO DENVER RAILYARD', N'TR2-RM11-DD10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-RM11-DD10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR2-RM11-DD10-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA RECEIVER PRESSURE TRANSMITTER', N'TR2-RM11-DD10-SIT-PTI201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE, CONTROL & ACTUATOR"', N'TR2-RM11-DD10-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-RM11-DD10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV4D0_75 SEC 12 T3S R68W ADAMS CO BV', N'TR2-RM11-DD10-SLE-CV4D0_75', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D0.1 DENVER REFINERY LAUNCHER BYPASS BV', N'TR2-RM11-DD10-SLE-HV4D0_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D0.1A DENVER REFINERY LAUNCHER BV', N'TR2-RM11-DD10-SLE-HV4D0_1A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D0.1B DEN REFINERY LAUNCHER KICKER BV', N'TR2-RM11-DD10-SLE-HV4D0_1B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D0_7 SEC 12 T3S R68W ADAMS CO BV', N'TR2-RM11-DD10-SLE-HV4D0_7', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D0_75 SEC 12 T3S R68W ADAMS CO BV', N'TR2-RM11-DD10-SLE-HV4D0_75', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D4.3 UPRR RECEIVER BYPASS BV', N'TR2-RM11-DD10-SLE-HV4D4_3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D4.3A UPRR RECEIVER BV', N'TR2-RM11-DD10-SLE-HV4D4_3A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'4D4.3B UPRR RECEIVER OUTLET BV', N'TR2-RM11-DD10-SLE-HV4D4_3B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA LAUNCHER TRAP', N'TR2-RM11-DD10-SLE-X101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA RECEIVER TRAP', N'TR2-RM11-DD10-SLE-X102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-RM11-DD10-SLP', 0, 0, 4, 9991, N'en', 1)


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMM CITY TO DENVER RR YARD', N'TR2-RM11-DD10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMM CITY TO DENVER RR YARD', N'TR2-RM11-DD10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR2-RM11-DD10-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY TO DEN RR YRD FIRE PROTECTION', N'TR2-RM11-DD10-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-RM11-DD10-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA ML RECEIVER THERMAL RELIEF', N'TR2-RM11-DD10-SSR-PSV203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UNION PACIFIC RAIL YARD', N'TR2-RM11-DD20', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-RM11-DD20-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR2-RM11-DD20-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA FUEL FACILITY DELIVERY METER', N'TR2-RM11-DD20-SIR-FM201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR2-RM11-DD20-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM CITY STA MOV203 PRESSURE SWITCH', N'TR2-RM11-DD20-SIS-PS202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR2-RM11-DD20-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA TEMPERATURE TRANSMITTER', N'TR2-RM11-DD20-SIT-TTI201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE, CONTROL & ACTUATOR"', N'TR2-RM11-DD20-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA FUEL FACILITY CONTROL VALVE', N'TR2-RM11-DD20-SIV-PCV212', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-RM11-DD20-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA PROVER SUPPLY VALVE', N'TR2-RM11-DD20-SLE-HV209', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA PROVER ISOLATION VALVE', N'TR2-RM11-DD20-SLE-HV210', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA PROVER RETURN VALVE', N'TR2-RM11-DD20-SLE-HV211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA DIESEL DELIVERY VALVE', N'TR2-RM11-DD20-SLE-MOV0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA FUEL FACILITY DELIVERY VALVE', N'TR2-RM11-DD20-SLE-MOV203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-RM11-DD20-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-UPPR STATION', N'TR2-RM11-DD20-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR MAINT-UPPR STATION', N'TR2-RM11-DD20-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-RM11-DD20-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA SUMP PUMP ASSY', N'TR2-RM11-DD20-SMP-P201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM, COLUMN, TANK, VESSEL, WELLHEAD"', N'TR2-RM11-DD20-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA METER FM101 METER STRAINER', N'TR2-RM11-DD20-SPT-S201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA SUMP TANK', N'TR2-RM11-DD20-SPT-TK201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR2-RM11-DD20-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UNION PACIFIC RAILYARD FIRE PROTECTION', N'TR2-RM11-DD20-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-RM11-DD20-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA MOV203 THERMAL RELIEF', N'TR2-RM11-DD20-SSR-PSV201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPRR STA METER MANIFOLD THERMAL RELIEF', N'TR2-RM11-DD20-SSR-PSV202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B TRUCK UNLOADING', N'TR2-SP10', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B STATION', N'TR2-SP10-SP00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR2-SP10-SP00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER SPINDLE B RSBTF1', N'TR2-SP10-SP00-SEG-RSBTF1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-SP10-SP00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR2-SP10-SP00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR ACT METER', N'TR2-SP10-SP00-SIR-FM001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-SP10-SP00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-SP10-SP00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT - SPINDLE B STATION', N'TR2-SP10-SP00-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR MAINT - SPINDLE B STATION', N'TR2-SP10-SP00-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-SP10-SP00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR UNLOADING PUMP ASSY', N'TR2-SP10-SP00-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR ACT PUMP ASSY', N'TR2-SP10-SP00-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B STA SUMP PUMP ASSY', N'TR2-SP10-SP00-SMP-P101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR2-SP10-SP00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR UNLOADING AIR ELIMINATO', N'TR2-SP10-SP00-SPT-AEL001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR A.C.T. AIR ELIMINATOR', N'TR2-SP10-SP00-SPT-AEL002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR SOUTH SUCTION STRAINER', N'TR2-SP10-SP00-SPT-S001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR NORTH SUCTION STRAINER', N'TR2-SP10-SP00-SPT-S002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR DISCHARGE STRAINER', N'TR2-SP10-SP00-SPT-S003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B STA SUMP TANK', N'TR2-SP10-SP00-SPT-TK101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B STA 500BBL STORAGE TANK 43885', N'TR2-SP10-SP00-SPT-TK43885', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR2-SP10-SP00-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B STA FIRE PROTECTION', N'TR2-SP10-SP00-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-SP10-SP00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SUNCOR INC TANKAGE', N'TR2-T411', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY TANKAGE', N'TR2-T411-GT10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-T411-GT10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK001 LEVEL', N'TR2-T411-GT10-SIL-L0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK001 TEMPERATURE', N'TR2-T411-GT10-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P54C TEMPERATURE', N'TR2-T411-GT10-SIL-T0054', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-T411-GT10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY TANKAGE', N'TR2-T411-GT10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY TANKAGE', N'TR2-T411-GT10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AGITATION & MIXING', N'TR2-T411-GT10-SMA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK001 MIXER 1', N'TR2-T411-GT10-SMA-MX001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK001 MIXER 2', N'TR2-T411-GT10-SMA-MX002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-T411-GT10-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1 BSTR PUMP', N'TR2-T411-GT10-SMP-P0054C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR2-T411-GT10-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TNK001 GUERNSEY STA 150 MBBL TANK', N'TR2-T411-GT10-SPT-TNK001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-T411-GT10-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1 TO CEN/ML METERS', N'TR2-T411-GT10-SSR-PRV0001_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CRUDE TRUCKING TERMINAL', N'TR2-T700', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CRUDE TRUCKING TERMINAL', N'TR2-T700-0700', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR2-T700-0700-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLDG, HOTSY STORAGE"', N'TR2-T700-0700-SAB-CRUDEHOTSYBLDG', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLDG, MCC"', N'TR2-T700-0700-SAB-CRUDEMCCBLDG', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLDG, SAMPLE"', N'TR2-T700-0700-SAB-CRUDESAMPLEBLDG', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR2-T700-0700-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMPUTER ON LOADING DOCK', N'TR2-T700-0700-SEC-DOCKCOMPUTER', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR2-T700-0700-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BAY 1 CORIOLAS METER', N'TR2-T700-0700-SIL-F101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FLOW THRU SETTLER 10V114', N'TR2-T700-0700-SIL-F105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SETTLER VESSEL DISCHRG FLW114', N'TR2-T700-0700-SIL-F112', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BAY 2 CORIOLAS METER', N'TR2-T700-0700-SIL-F201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BAY 3 CORIOLAS METER', N'TR2-T700-0700-SIL-F301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BAY 4 CORIOLAS METER', N'TR2-T700-0700-SIL-F401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UST LIQUID LEVEL CONTROL', N'TR2-T700-0700-SIL-L303', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UST HIGH LEVEL SWITCH', N'TR2-T700-0700-SIL-L304', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UST LEAK DETECTION', N'TR2-T700-0700-SIL-X808', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SETTLER HEAT TRACE', N'TR2-T700-0700-SIL-X809', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSMITTER', N'TR2-T700-0700-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UST LEAK DETECTION TRANSMITTER', N'TR2-T700-0700-SIT-XA808', 0, 0, 5, 9991, N'en', 1)


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SETTLER HEAT TRACE TRANSMITTER', N'TR2-T700-0700-SIT-XA809', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UST LEAK DETECTION TRANSMITTER', N'TR2-T700-0700-SIT-XS808', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR2-T700-0700-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CYCLONE, SEPERATOR"', N'TR2-T700-0700-SLE-X102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR2-T700-0700-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0019,US PIPELINE TO 210TK26"', N'TR2-T700-0700-SLP-PC0019', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0150,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0150', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0151,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0151', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0152,AIR ELIMENATOR # 1 & 2 TO 310P101"', N'TR2-T700-0700-SLP-PC0152', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0153,310P101 TO 310F1001"', N'TR2-T700-0700-SLP-PC0153', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0154,310F1001 TO 6-HC-310-0155"', N'TR2-T700-0700-SLP-PC0154', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0155,6-HC-310-0154 TO 310X103"', N'TR2-T700-0700-SLP-PC0155', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0156,310X103 TO 310V104"', N'TR2-T700-0700-SLP-PC0156', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0157,310P101 DRAIN TO 310TK101"', N'TR2-T700-0700-SLP-PC0157', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0158,310P101/F1001 TO 310TK101"', N'TR2-T700-0700-SLP-PC0158', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0159,SKID 101PROCESS VENT TO 310TK101"', N'TR2-T700-0700-SLP-PC0159', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0160,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0160', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0161,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0161', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0162,AIR ELIMENATOR # 3 & 4 TO 310P201"', N'TR2-T700-0700-SLP-PC0162', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0163,310P201 TO 310F2001"', N'TR2-T700-0700-SLP-PC0163', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0164,310F2001 TO 6-HC-310-0165"', N'TR2-T700-0700-SLP-PC0164', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0165,6-HC-310-0164 TO 310X203"', N'TR2-T700-0700-SLP-PC0165', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0166,310X203 TO 310V104"', N'TR2-T700-0700-SLP-PC0166', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0167,310P201 TO 310TK101"', N'TR2-T700-0700-SLP-PC0167', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0168,310P201/F2001 TO 310TK101"', N'TR2-T700-0700-SLP-PC0168', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0169,SKID 201 PROCESS VENT TO 310TK101"', N'TR2-T700-0700-SLP-PC0169', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0170,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0170', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0171,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0171', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0172,AIR ELIMENATOR # 5 & 6 TO 310P301"', N'TR2-T700-0700-SLP-PC0172', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0173,310P301 TO 310F3001"', N'TR2-T700-0700-SLP-PC0173', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0174,310F3001 TO 6-HC-310-0175"', N'TR2-T700-0700-SLP-PC0174', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0175,6-HC-310-0174 TO 310X301"', N'TR2-T700-0700-SLP-PC0175', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0176,310X303 TO 310V104"', N'TR2-T700-0700-SLP-PC0176', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0177,310P301 DRAIN TO 310TK101"', N'TR2-T700-0700-SLP-PC0177', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0178,310P301/F3001 TO 310TK101"', N'TR2-T700-0700-SLP-PC0178', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0179,SKID 301 PROCESS VENT TO 310TK101"', N'TR2-T700-0700-SLP-PC0179', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0180,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0180', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0181,FRT TRAILER CONN TO AIR ELIMENATO"', N'TR2-T700-0700-SLP-PC0181', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0182,AIR ELIMENATOR # 7 & 8 TO 310P401"', N'TR2-T700-0700-SLP-PC0182', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0183,310P401 TO 310F4001"', N'TR2-T700-0700-SLP-PC0183', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0184,310F4001 TO 6-HC-310-0185"', N'TR2-T700-0700-SLP-PC0184', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0185,6-HC-310-0184 TO 310X403"', N'TR2-T700-0700-SLP-PC0185', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0186,310X403 TO 310V104"', N'TR2-T700-0700-SLP-PC0186', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0187,310P401 DRAIN PAN TO 310TK101"', N'TR2-T700-0700-SLP-PC0187', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0188,310P401/F4001 TO 310TK101"', N'TR2-T700-0700-SLP-PC0188', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0189,SKID 401 PROCESS VENT TO 310TK101"', N'TR2-T700-0700-SLP-PC0189', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0190,310V102/V103/V104/V105/V106/V107"', N'TR2-T700-0700-SLP-PC0190', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0191,SKIDS & SAMPLE STATIONS TO 310TK1"', N'TR2-T700-0700-SLP-PC0191', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0192,SKID PROCESS VENTS TO 310TK101"', N'TR2-T700-0700-SLP-PC0192', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0193,STATIC MIXERS TO 310V101"', N'TR2-T700-0700-SLP-PC0193', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0194,310PSV104 TO 310TK101"', N'TR2-T700-0700-SLP-PC0194', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0195,310V101 TO 310TK101"', N'TR2-T700-0700-SLP-PC0195', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PC0196,SAMPLE BASIN TO 310TK101"', N'TR2-T700-0700-SLP-PC0196', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AGITATION & MIXING', N'TR2-T700-0700-SMA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'X103, NEW CRUDE DOCK #1 STATIC MIXER"', N'TR2-T700-0700-SMA-X103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'X203, NEW CRUDE DOCK #2 STATIC MIXER"', N'TR2-T700-0700-SMA-X203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'X303, NEW CRUDE DOCK #3 STATIC MIXER"', N'TR2-T700-0700-SMA-X303', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'X403, NEW CRUDE DOCK #4 STATIC MIXER"', N'TR2-T700-0700-SMA-X403', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR2-T700-0700-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P101, NEW CRUDE DOCK #1"', N'TR2-T700-0700-SMP-P101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P105, NEW CRUDE DOCKS SUMP PUMP"', N'TR2-T700-0700-SMP-P105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P201, NEW CRUDE DOCK #2"', N'TR2-T700-0700-SMP-P201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P301, NEW CRUDE DOCK #3"', N'TR2-T700-0700-SMP-P301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P401, NEW CRUDE DOCK #4"', N'TR2-T700-0700-SMP-P401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR2-T700-0700-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F1001, CRUDE DK1 MAIN BASKET STRAINER"', N'TR2-T700-0700-SPT-F1001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F1002, CRUDE DK 1 AIR ELIM BSKT STRNR"', N'TR2-T700-0700-SPT-F1002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F2001, CRUDE DK2 MAIN BASKET STRAINER"', N'TR2-T700-0700-SPT-F2001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F2002, CRUDE DK2 AIR ELIM BSKT STRNR"', N'TR2-T700-0700-SPT-F2002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F3001, CRUDE DK3 MAIN BASKET STRAINER"', N'TR2-T700-0700-SPT-F3001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F3002, CRUDE DK3 AIR ELIM BSKT STRNR"', N'TR2-T700-0700-SPT-F3002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F4001, CRUDE DK4 MAIN BASKET STRAINER"', N'TR2-T700-0700-SPT-F4001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F4002, CRUDE DK4 AIR ELIM BSKT STRNR"', N'TR2-T700-0700-SPT-F4002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TK101,TRANSPORT DK UNDERGROUND STG TK"', N'TR2-T700-0700-SPT-TK101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V101,CRUDE SEPARATOR @ TRANSPORTATION"', N'TR2-T700-0700-SPT-V101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V103, BAY 1 SAMPLE POT"', N'TR2-T700-0700-SPT-V103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V104, BAY 2 SAMPLE POT"', N'TR2-T700-0700-SPT-V104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V105, BAY 3 SAMPLE POT"', N'TR2-T700-0700-SPT-V105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V106, BAY 4 SAMPLE POT"', N'TR2-T700-0700-SPT-V106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'V107, PURGE SAMPLE POT"', N'TR2-T700-0700-SPT-V107', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRE PROTECTION', N'TR2-T700-0700-SSP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY SHOWER/EYEWASH', N'TR2-T700-0700-SSP-SS05', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR2-T700-0700-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV1023,PRESS SAFETY VALVE FOR 10V114"', N'TR2-T700-0700-SSR-PSV1023', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV103, NEW CRUDE DOCK #1"', N'TR2-T700-0700-SSR-PSV103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV104, NEW CRUDE DOCKS"', N'TR2-T700-0700-SSR-PSV104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV105, NEW CRUDE DOCKS SEPARATOR"', N'TR2-T700-0700-SSR-PSV105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV106, NEW CRUDE DOCKS SEPARATOR"', N'TR2-T700-0700-SSR-PSV106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV131, CRUDE PROVING LOOP"', N'TR2-T700-0700-SSR-PSV131', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV169, CRUDE OIL"', N'TR2-T700-0700-SSR-PSV169', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV170, CRUDE OIL"', N'TR2-T700-0700-SSR-PSV170', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV171, CRUDE OIL"', N'TR2-T700-0700-SSR-PSV171', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPSV172, CRUDE OIL"', N'TR2-T700-0700-SSR-PSV172', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV200, 10V108 RELIEF VALVE"', N'TR2-T700-0700-SSR-PSV200', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV203, NEW CRUDE DOCK #2"', N'TR2-T700-0700-SSR-PSV203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV303, NEW CRUDE DOCK #3"', N'TR2-T700-0700-SSR-PSV303', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PSV403, NEW CRUDE DOCK #4"', N'TR2-T700-0700-SSR-PSV403', 0, 0, 5, 9991, N'en', 1)


go



GO





--INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'', N'TR3', 0, 0, 1, 8890, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SUNCOR PIPELINE COMMON CARRIER', N'TR3', 0, 0, 1, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE GENERAL INFRASTRUCTURE', N'TR3-RM04', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE OFFICE BUILDING', N'TR3-RM04-CH01', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING,FIXTURE & HVAC"', N'TR3-RM04-CH01-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLDG1,CHEYENNE OFFICE"', N'TR3-RM04-CH01-SAB-BLDG1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM04-CH01-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DISTRICT OFFICE AED', N'TR3-RM04-CH01-SSA-OFFICE_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DISTRICT OFFICE PROJECT AED', N'TR3-RM04-CH01-SSA-PROJECT_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM04-CH01-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE OFFICE BUILDING FIRE PROTECTION', N'TR3-RM04-CH01-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY MAINLINE', N'TR3-RM05', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STATION', N'TR3-RM05-GU00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM05-GU00-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DRA INJECTION PUMP SKID', N'TR3-RM05-GU00-SAB-DRA_INJECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HOISTING & LIFTING EQUIPMENT', N'TR3-RM05-GU00-SCH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSPORTATION EQUIPMENT', N'TR3-RM05-GU00-SCT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM05-GU00-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SATELLITE DISH', N'TR3-RM05-GU00-SEC-VSAT1206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND GUERNSEY STA BGST0 (BRIDGER)', N'TR3-RM05-GU00-SEG-BGST0', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND GUERNSEY STA BGST1 (ML & CEN)', N'TR3-RM05-GU00-SEG-BGST1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND GUERNSEY STA BGST2 (PLATTE)', N'TR3-RM05-GU00-SEG-BGST2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND GUERNSEY STA BGST3 (PLAINS)', N'TR3-RM05-GU00-SEG-BGST3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM05-GU00-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM05-GU00-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0003 MOTOR CONTROL CENTER', N'TR3-RM05-GU00-SEG-MCC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0004 MOTOR CONTROL CENTER', N'TR3-RM05-GU00-SEG-MCC0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0005 MOTOR CONTROL CENTER', N'TR3-RM05-GU00-SEG-MCC0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF1 (M13B)', N'TR3-RM05-GU00-SEG-RGTF1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF2 (M13C)', N'TR3-RM05-GU00-SEG-RGTF2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF3 (M13)', N'TR3-RM05-GU00-SEG-RGTF3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF4 (M13D)', N'TR3-RM05-GU00-SEG-RGTF4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF5 (M13E)', N'TR3-RM05-GU00-SEG-RGTF5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF6 (M13F)', N'TR3-RM05-GU00-SEG-RGTF6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF7 (M13G)', N'TR3-RM05-GU00-SEG-RGTF7', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GUERNSEY STA RGTF8 (M13A)', N'TR3-RM05-GU00-SEG-RGTF8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SWG0001 SWITCHGEAR', N'TR3-RM05-GU00-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPS0001 UNINTERRUPTIBLE POWER SUPPLY', N'TR3-RM05-GU00-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA NEW OFFICE BUILDING UPS', N'TR3-RM05-GU00-SEG-UPS0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA NEW CONTROL BUILDING UPS', N'TR3-RM05-GU00-SEG-UPS0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM05-GU00-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM05-GU00-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM05-GU00-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA HUMAN MACHINE INTERFACE', N'TR3-RM05-GU00-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 4 MULTILIN', N'TR3-RM05-GU00-SIC-ML0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 5 MULTILIN', N'TR3-RM05-GU00-SIC-ML0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA OIT1 OP INTERFACE TERMINAL', N'TR3-RM05-GU00-SIC-OIT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC4 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC5 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC8 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC0008', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC9 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC0009', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLCA PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC000A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLCB PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC000B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLCC PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLCS PRGM LOGIC CONTROLLER', N'TR3-RM05-GU00-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GNSY RTU A/B COMMUNCATIONS TO SCADA', N'TR3-RM05-GU00-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA GRAVITY BELLE FOURCHE', N'TR3-RM05-GU00-SIL-D0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA GRAVITY PLATTE', N'TR3-RM05-GU00-SIL-D0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA GRAVITY BUTTE', N'TR3-RM05-GU00-SIL-D0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA GRAVITY RMPL/PLAINS', N'TR3-RM05-GU00-SIL-D0012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA E ML LAUNCHER GRAVITY', N'TR3-RM05-GU00-SIL-D0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FMP0001 GUERNSEY STA METER PROVER', N'TR3-RM05-GU00-SIL-FMP0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 LEVEL', N'TR3-RM05-GU00-SIL-L0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK85 LEVEL', N'TR3-RM05-GU00-SIL-L0085', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 LEVEL', N'TR3-RM05-GU00-SIL-L0089', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SUMP LEVEL', N'TR3-RM05-GU00-SIL-L0810', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SUMP LEVEL', N'TR3-RM05-GU00-SIL-L0811', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SUMP LEVEL', N'TR3-RM05-GU00-SIL-L0813', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK888 LEVEL', N'TR3-RM05-GU00-SIL-L0888', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1158 LEVEL', N'TR3-RM05-GU00-SIL-L1158', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1280 LEVEL', N'TR3-RM05-GU00-SIL-L1280', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BELLE FOURCHE PRESSURE', N'TR3-RM05-GU00-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE PRESSURRE', N'TR3-RM05-GU00-SIL-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 4 PRESSURE', N'TR3-RM05-GU00-SIL-P0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE MANIFOLD PRESSURE', N'TR3-RM05-GU00-SIL-P0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SINCLAIR SPLITTER PRESSURE', N'TR3-RM05-GU00-SIL-P0007', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML SPLITTER PRESSURE', N'TR3-RM05-GU00-SIL-P0010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLAINS/RMPL PRESSURE', N'TR3-RM05-GU00-SIL-P0012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P54A PRESSURE', N'TR3-RM05-GU00-SIL-P0509', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM13 PRESSURE', N'TR3-RM05-GU00-SIL-P0510', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PROVING TEMPERATURE', N'TR3-RM05-GU00-SIL-P0801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA UNIT 4 SUCTION PRESSURE', N'TR3-RM05-GU00-SIL-P0818', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CASE PRESSURE', N'TR3-RM05-GU00-SIL-P0819', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DISCHARGE PRESSURE', N'TR3-RM05-GU00-SIL-P0820', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DISCHARGE PRESSURE', N'TR3-RM05-GU00-SIL-P0821', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BELLE FOURCHE TEMPERATURE', N'TR3-RM05-GU00-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE TEMPERATURE', N'TR3-RM05-GU00-SIL-T0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 4 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TEMPERATURE', N'TR3-RM05-GU00-SIL-T0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SINCLAIR SPLITTER TEMP', N'TR3-RM05-GU00-SIL-T0007', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM010 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLAINS/RMPL TO OMNI', N'TR3-RM05-GU00-SIL-T0012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P53 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0053', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P58 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0058', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P59 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0059', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P54A TEMPERATURE', N'TR3-RM05-GU00-SIL-T0509', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM13 TEMPERATURE', N'TR3-RM05-GU00-SIL-T0510', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PROVING TEMPERATURE', N'TR3-RM05-GU00-SIL-T0801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DISCHARGE TEMPERATURE', N'TR3-RM05-GU00-SIL-T0820', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 4 VIBRATION', N'TR3-RM05-GU00-SIL-V0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNIT 5 VIBRATION', N'TR3-RM05-GU00-SIL-V0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM05-GU00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 2 BFPL', N'TR3-RM05-GU00-SIR-FM002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 3 PLATTE', N'TR3-RM05-GU00-SIR-FM003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 4 PLATTE', N'TR3-RM05-GU00-SIR-FM004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 5 BUTTE', N'TR3-RM05-GU00-SIR-FM005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 6 BUTTE', N'TR3-RM05-GU00-SIR-FM006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 7 SINCLAIR', N'TR3-RM05-GU00-SIR-FM007', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM010 MAILINE', N'TR3-RM05-GU00-SIR-FM010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 12 PLAINS/RMPL', N'TR3-RM05-GU00-SIR-FM012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML ML BLEND METER', N'TR3-RM05-GU00-SIR-FM013', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GNSY STA FQ201 FLOW COMPUTER', N'TR3-RM05-GU00-SIR-FQ201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GNSY STA FQ501 FLOW COMPUTER', N'TR3-RM05-GU00-SIR-FQ501', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GNSY STA FQI301 FLOW COMPUTER', N'TR3-RM05-GU00-SIR-FQI301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GNSY STA FQI401 FLOW COMPUTER', N'TR3-RM05-GU00-SIR-FQI401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER PROVER', N'TR3-RM05-GU00-SIR-PVR801', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM05-GU00-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0001 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0202 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0203 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0205 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0206 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0207 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0207', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0208 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0208', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0209 CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0209', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0510 TK1 ML BLEND FLOW CONTROL VALVE', N'TR3-RM05-GU00-SIV-FCV0510', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNITS DISCHARGE PCV', N'TR3-RM05-GU00-SIV-PCV0217', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PCV0509 TK1 ML BLEND PRESS CONTROL VALVE', N'TR3-RM05-GU00-SIV-PCV0509', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HV0014 GUERNSEY STA TO SINCLAIR', N'TR3-RM05-GU00-SLE-HV0014', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM10 PROVER ISOLATION VALVE', N'TR3-RM05-GU00-SLE-HV0211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM10 TO PROVER', N'TR3-RM05-GU00-SLE-HV0212', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 10 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0213', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM10 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0214', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 7 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0234', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 7 TO PROVER', N'TR3-RM05-GU00-SLE-HV0237', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 7 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0238', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 2 TO PROVER', N'TR3-RM05-GU00-SLE-HV0246', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 2 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0247', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 2 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0248', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 3 TO PROVER', N'TR3-RM05-GU00-SLE-HV0250', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 3 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0251', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 3 & 4 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0252', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 4 TO PROVER', N'TR3-RM05-GU00-SLE-HV0254', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 4 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0255', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 5 TO PROVER', N'TR3-RM05-GU00-SLE-HV0257', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 5 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0258', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 5 & 6 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0259', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 6 TO PROVER', N'TR3-RM05-GU00-SLE-HV0261', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 6 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0262', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 12 TO PROVER', N'TR3-RM05-GU00-SLE-HV0266', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 12 FROM PROVER', N'TR3-RM05-GU00-SLE-HV0267', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 12 BLOCK & BLEED', N'TR3-RM05-GU00-SLE-HV0268', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DRAINS FROM PROVER', N'TR3-RM05-GU00-SLE-HV0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA DRAINS TO PROVER', N'TR3-RM05-GU00-SLE-HV0302', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY ML UNIT 4 SUCTION VALVE', N'TR3-RM05-GU00-SLE-MOV0004A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY ML UNIT 4 DISCHARGE VALVE', N'TR3-RM05-GU00-SLE-MOV0004B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY ML UNIT 5 SUCTION VALVE', N'TR3-RM05-GU00-SLE-MOV0005A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY ML UNIT 5 DISCHARGE VALVE', N'TR3-RM05-GU00-SLE-MOV0005B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY SINCLAIR METER FROM SPLITTER', N'TR3-RM05-GU00-SLE-MOV0010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY SUMP TO TK888', N'TR3-RM05-GU00-SLE-MOV0024', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY SUMP TO TK89', N'TR3-RM05-GU00-SLE-MOV0025', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MOV0027', N'TR3-RM05-GU00-SLE-MOV0027', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0028 GUERNSEY STA SUMP TO TK1158', N'TR3-RM05-GU00-SLE-MOV0028', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE METER SUCTION', N'TR3-RM05-GU00-SLE-MOV0030', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOLD TO TK56', N'TR3-RM05-GU00-SLE-MOV0031', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOLD TO TK888', N'TR3-RM05-GU00-SLE-MOV0034', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOLD TO TK89', N'TR3-RM05-GU00-SLE-MOV0035', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOLD TO TK85', N'TR3-RM05-GU00-SLE-MOV0036', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOLD TO TK1', N'TR3-RM05-GU00-SLE-MOV0037', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOL TO TK1158', N'TR3-RM05-GU00-SLE-MOV0038', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY BELLE FOURCHE MANIFOL TO TK1280', N'TR3-RM05-GU00-SLE-MOV0039', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL METER SUCTION', N'TR3-RM05-GU00-SLE-MOV0040', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK56', N'TR3-RM05-GU00-SLE-MOV0041', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK888', N'TR3-RM05-GU00-SLE-MOV0044', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK89', N'TR3-RM05-GU00-SLE-MOV0045', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK85', N'TR3-RM05-GU00-SLE-MOV0046', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK1', N'TR3-RM05-GU00-SLE-MOV0047', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK1158', N'TR3-RM05-GU00-SLE-MOV0048', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLAINS/RMPL MANIFOLD TO TK1280', N'TR3-RM05-GU00-SLE-MOV0049', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLATTE 12 METER SUCTION', N'TR3-RM05-GU00-SLE-MOV0050', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLATTE 16 METER TO MANIFOLD', N'TR3-RM05-GU00-SLE-MOV0050A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0051 GUERNSEY STA PLATTE TO TK56', N'TR3-RM05-GU00-SLE-MOV0051', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY PLATTE 16 MANIFOLD TO TK56', N'TR3-RM05-GU00-SLE-MOV0051A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE TO TANK 89', N'TR3-RM05-GU00-SLE-MOV0055', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK89', N'TR3-RM05-GU00-SLE-MOV0055A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE TO TK85', N'TR3-RM05-GU00-SLE-MOV0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK85', N'TR3-RM05-GU00-SLE-MOV0056A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE METERS TO TK1', N'TR3-RM05-GU00-SLE-MOV0057', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK1', N'TR3-RM05-GU00-SLE-MOV0057A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE METERS TO TK1158', N'TR3-RM05-GU00-SLE-MOV0058', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE TO TK1280', N'TR3-RM05-GU00-SLE-MOV0059', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK1280', N'TR3-RM05-GU00-SLE-MOV0059A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TKAGE', N'TR3-RM05-GU00-SLE-MOV0060', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK56', N'TR3-RM05-GU00-SLE-MOV0061', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK888', N'TR3-RM05-GU00-SLE-MOV0064', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK89', N'TR3-RM05-GU00-SLE-MOV0065', 0, 0, 5, 9991, N'en', 1)

go




GO


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK85', N'TR3-RM05-GU00-SLE-MOV0066', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK1', N'TR3-RM05-GU00-SLE-MOV0067', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TK1158', N'TR3-RM05-GU00-SLE-MOV0068', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO TK1280', N'TR3-RM05-GU00-SLE-MOV0069', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0072 GUERNSEY STA ML FROM TK56', N'TR3-RM05-GU00-SLE-MOV0072', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0073 GUERNSEY STA M/L FROM TK89', N'TR3-RM05-GU00-SLE-MOV0073', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0075 GUERNSEY STA ML FROM TK85', N'TR3-RM05-GU00-SLE-MOV0075', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0077 GUERNSEY STA ML FROM TK888', N'TR3-RM05-GU00-SLE-MOV0077', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0078 GUERNSEY STA ML FROM TK1158', N'TR3-RM05-GU00-SLE-MOV0078', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0079 GUERNSEY STA ML FROM TK1280', N'TR3-RM05-GU00-SLE-MOV0079', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0080 GUERNSEY STA TKG TO CENT', N'TR3-RM05-GU00-SLE-MOV0080', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 TO SINCLAIR MANIFOLD', N'TR3-RM05-GU00-SLE-MOV0092', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0093 GUERNSEY STA TK89 TO SINCLAIR', N'TR3-RM05-GU00-SLE-MOV0093', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0095 GUERNSEY STA TK86 TO SINCLAIR', N'TR3-RM05-GU00-SLE-MOV0095', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SINCLAIR SPLITTER FRM TK888', N'TR3-RM05-GU00-SLE-MOV0097', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0098 GUERNSEY STA TK1158 TO SINCLAIR', N'TR3-RM05-GU00-SLE-MOV0098', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1280 TO SINCLAIR METER', N'TR3-RM05-GU00-SLE-MOV0099', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOV0263 GUERNSEY STA 4WAY PROVER', N'TR3-RM05-GU00-SLE-MOV0263', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML TK1280 TO TK1', N'TR3-RM05-GU00-SLE-MOV0504', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML TK1 TO TK1 BLEND', N'TR3-RM05-GU00-SLE-MOV0507', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML TK1 BLEND ISOLATION', N'TR3-RM05-GU00-SLE-MOV0514', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML TK1 BLEND BYPASS', N'TR3-RM05-GU00-SLE-MOV0523', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML TK1 BLEND BYPASS', N'TR3-RM05-GU00-SLE-MOV0524', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY STATION', N'TR3-RM05-GU00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY STATION', N'TR3-RM05-GU00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AGITATION & MIXING', N'TR3-RM05-GU00-SMA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'A0887 GUERNSEY STA TK887 MIXER', N'TR3-RM05-GU00-SMA-A0887', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'A0888 GUERNSEY STA TK888 MIXER', N'TR3-RM05-GU00-SMA-A0888', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 MIXER', N'TR3-RM05-GU00-SMA-MX0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK85 MIXER', N'TR3-RM05-GU00-SMA-MX0085', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 MIXER', N'TR3-RM05-GU00-SMA-MX0089', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK888 MIXER', N'TR3-RM05-GU00-SMA-MX0888', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1158 MIXER', N'TR3-RM05-GU00-SMA-MX1158', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1280 MIXER', N'TR3-RM05-GU00-SMA-MX1280', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FAN, BLOWER & COMPRESSOR"', N'TR3-RM05-GU00-SMF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM05-GU00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SUMP PUMP P000', N'TR3-RM05-GU00-SMP-P000', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0004 GUERNSEY STA ML UNIT 4', N'TR3-RM05-GU00-SMP-P0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0005 GUERNSEY STA ML UNIT 5', N'TR3-RM05-GU00-SMP-P0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0051', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0053 GUERNSEY TK89 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0053', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0054A GUERNSEY STA ML BLEND PUMP', N'TR3-RM05-GU00-SMP-P0054A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0055 GUERNSEY STA TK887 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0055', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0056 GUERNSEY STA TK85 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0057 GUERNSEY STA TK888 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0057', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1158 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0058', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0059 GUERNSEY STA TK1280 BSTR PUMP', N'TR3-RM05-GU00-SMP-P0059', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA LAUNCHER DRAIN PUMP', N'TR3-RM05-GU00-SMP-P0060', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM05-GU00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 2 STRAINER BFPL', N'TR3-RM05-GU00-SPT-S002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 3 STRAINER PLATTE', N'TR3-RM05-GU00-SPT-S003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 4 STRAINER PLATTE', N'TR3-RM05-GU00-SPT-S004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 5 STRAINER BUTTE', N'TR3-RM05-GU00-SPT-S005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 6 STRAINER BUTTE', N'TR3-RM05-GU00-SPT-S006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 7 STRAINER SINCLAIR', N'TR3-RM05-GU00-SPT-S007', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA METER 10 STRAINER MAINLINE', N'TR3-RM05-GU00-SPT-S010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA ML UNITS SUCTION STRAINER', N'TR3-RM05-GU00-SPT-S011', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 12 STRAINER PLAINS', N'TR3-RM05-GU00-SPT-S012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SUMP TANK', N'TR3-RM05-GU00-SPT-TK000', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 96MBBL TANK', N'TR3-RM05-GU00-SPT-TK0056', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 96MBBL TANK', N'TR3-RM05-GU00-SPT-TK0085', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 96MBBL TANK', N'TR3-RM05-GU00-SPT-TK0089', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 35MBBL TANK', N'TR3-RM05-GU00-SPT-TK0888', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 39MBBL TANK', N'TR3-RM05-GU00-SPT-TK1158', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA 120MBBL TANK', N'TR3-RM05-GU00-SPT-TK1280', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TNK0887 GUERNSEY STA TANK (abandoned)', N'TR3-RM05-GU00-SPT-TNK0887', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM05-GU00-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STATION AED', N'TR3-RM05-GU00-SSA-STATION_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM05-GU00-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FIRE PROTECTION', N'TR3-RM05-GU00-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM05-GU00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1 TO BLEND PUMPS', N'TR3-RM05-GU00-SSR-PRV0001_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SINCLAIR TO METER 7', N'TR3-RM05-GU00-SSR-PRV0010', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BELLE FOURCHE MNFLD TO TK89', N'TR3-RM05-GU00-SSR-PRV0035', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BELLE FOURCHE MANIFOLD', N'TR3-RM05-GU00-SSR-PRV0036', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RMPL TO METER 12', N'TR3-RM05-GU00-SSR-PRV0040', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RMPL TO MANIFOLD', N'TR3-RM05-GU00-SSR-PRV0041', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE TO METERS 3 & 4', N'TR3-RM05-GU00-SSR-PRV0050', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK71', N'TR3-RM05-GU00-SSR-PRV0053', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 TO SPLITTER MANIFOLD', N'TR3-RM05-GU00-SSR-PRV0056_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK56 TO SPLITTER MANIFOLD', N'TR3-RM05-GU00-SSR-PRV0056_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK1158', N'TR3-RM05-GU00-SSR-PRV0058', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLATTE MANIFOLD TO TK1280', N'TR3-RM05-GU00-SSR-PRV0059', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE TO METERS 5 & 6', N'TR3-RM05-GU00-SSR-PRV0060', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE MANIFOLD TO TK71', N'TR3-RM05-GU00-SSR-PRV0063A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE MANIFOLD TO TK71', N'TR3-RM05-GU00-SSR-PRV0063B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE MANIFOLD TO TK1158', N'TR3-RM05-GU00-SSR-PRV0068', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE MANIFOLD TO TK1280', N'TR3-RM05-GU00-SSR-PRV0069', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MOV99 PIPING', N'TR3-RM05-GU00-SSR-PRV0079', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK85 TO SPLITTER MANIFOLDS', N'TR3-RM05-GU00-SSR-PRV0085_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK85 FILL TO SPLITTER', N'TR3-RM05-GU00-SSR-PRV0085_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK85 SUCTION TO DISCHARGE', N'TR3-RM05-GU00-SSR-PRV0085_3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 TO SPLITTER MANIFOLDS', N'TR3-RM05-GU00-SSR-PRV0089_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 TO SPLITTER MANIFOLDS', N'TR3-RM05-GU00-SSR-PRV0089_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 TO TK1158 SPLITTER', N'TR3-RM05-GU00-SSR-PRV0089_4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK89 FILL TO TK1280 SPLITT', N'TR3-RM05-GU00-SSR-PRV0089_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MOV99 PIPING', N'TR3-RM05-GU00-SSR-PRV0099', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA SINCLAIR TO METER 7', N'TR3-RM05-GU00-SSR-PRV0222', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BELLE FOURCHE FROM PROVER', N'TR3-RM05-GU00-SSR-PRV0248', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA BUTTE FM006 TO PROVER', N'TR3-RM05-GU00-SSR-PRV0261', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MAINLINE BLENDING RELIEF', N'TR3-RM05-GU00-SSR-PRV0514', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK888 TO SPLITTER MANIFOLDS', N'TR3-RM05-GU00-SSR-PRV0888_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1158 TO SPLITTER MANIFOLD', N'TR3-RM05-GU00-SSR-PRV1158_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1280 TO SPLITTER MANIFOLD', N'TR3-RM05-GU00-SSR-PRV1280_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1280 TO METERS 13 & 14', N'TR3-RM05-GU00-SSR-PRV1280_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RECEIPT MANIFOLDS TO TK56', N'TR3-RM05-GU00-SSR-PSV0056_3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RECEIPT MANIFOLDS TO TK89', N'TR3-RM05-GU00-SSR-PSV0089_3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK888 FROM LAUNCHER DRAIN', N'TR3-RM05-GU00-SSR-PSV0888', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK888 FROM RECEIPT MANIFOLD', N'TR3-RM05-GU00-SSR-PSV0888_6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK1158 FROM RECEIPT MANIFOL', N'TR3-RM05-GU00-SSR-PSV1158_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RUPTURE PIN BELLE FOURCHE', N'TR3-RM05-GU00-SSR-RP002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RUPTURE PIN PLATTE', N'TR3-RM05-GU00-SSR-RP003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RUPTURE PIN BUTTE', N'TR3-RM05-GU00-SSR-RP005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA RUPTURE PIN RMPL/PLAINS', N'TR3-RM05-GU00-SSR-RP012', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL TEST EQUIPMENT', N'TR3-RM05-GU00-STE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHART RECORDER - Barton 242A-21459', N'TR3-RM05-GU00-STE-CR0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STE-MM0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STE-MM0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STE-MM0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STE-MM0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STE-MM0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT TMI EQUIPMENT', N'TR3-RM05-GU00-STI', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STI-RBX0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STI-RBX0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STI-TG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STI-TG0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM05-GU00-STI-TG0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY TO GOSHEN EAST LINE', N'TR3-RM05-GU10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU10-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER CHERRY CREEK R8G11.2 (M14B)', N'TR3-RM05-GU10-SEG-R8G11_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GAMBLIN R8G15 (M15)', N'TR3-RM05-GU10-SEG-R8G15', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GOSHEN HOLE R8G18 (M15A)', N'TR3-RM05-GU10-SEG-R8G18', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GRAYROCKS R8G5 (M14)', N'TR3-RM05-GU10-SEG-R8G5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER DEER CREEK RD R8G8 (M14A)', N'TR3-RM05-GU10-SEG-R8G8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 EAST ML UPSTRM PRESSURE', N'TR3-RM05-GU10-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 EAST ML UPSTRM TEMPERATURE', N'TR3-RM05-GU10-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU10-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN HOLE S RIM 8 EAST ML PIG SIGNAL', N'TR3-RM05-GU10-SIS-ZSX101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN HOLE S RIM 8 EAST ML PIG SIGNAL', N'TR3-RM05-GU10-SIS-ZSX101B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G3E SEC32 T26N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-CV8G3E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G8E SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-CV8G8E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0E GUERNSEY 8 E ML LAUNCHER BYPASS BV', N'TR3-RM05-GU10-SLE-HV8G0E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0EA GUERNSEY 8 E ML LAUNCHER BV', N'TR3-RM05-GU10-SLE-HV8G0EA', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0EB GUERNSEY 8 E ML LAUNCHER KICKER BV', N'TR3-RM05-GU10-SLE-HV8G0EB', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G18E SEC18 T23N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-HV8G18E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22E SEC36 T23N R66W PLATTE CO BV', N'TR3-RM05-GU10-SLE-HV8G22E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G2E SEC29 T26N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-HV8G2E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G8EDS SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-HV8G8EDS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G8EUS SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU10-SLE-HV8G8EUS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA EAST ML LAUNCHER TRAP', N'TR3-RM05-GU10-SLE-X001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY TO GOSHEN EAST LINE', N'TR3-RM05-GU10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY TO GOSHEN EAST LINE', N'TR3-RM05-GU10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY TO GOSHEN WEST LINE', N'TR3-RM05-GU20', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU20-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 WEST ML UPSTRM PRESSURE', N'TR3-RM05-GU20-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU20-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN HOLE S RIM 8 WEST ML PIG SIGNAL', N'TR3-RM05-GU20-SIS-ZSX102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU20-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G3W SEC32 T26N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-CV8G3W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G8W SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-CV8G8W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0W GUERNSEY 8 W ML LAUNCHER BYPASS BV', N'TR3-RM05-GU20-SLE-HV8G0W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0WA GUERNSEY 8 W ML LAUNCHER BV', N'TR3-RM05-GU20-SLE-HV8G0WA', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G0WB GUERNSEY 8 W ML LAUNCHER KICKER BV', N'TR3-RM05-GU20-SLE-HV8G0WB', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G18W SEC18 T23N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G18W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22W SEC36 T23N R66W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G22W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G2W SEC29 T26N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G2W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G8WDS SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G8WDS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G8WUS SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G8WUS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G8X SEC29 T25N R65W PLATTE CO BV', N'TR3-RM05-GU20-SLE-HV8G8X', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA WEST ML LAUNCHER TRAP', N'TR3-RM05-GU20-SLE-X002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU20-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY TO GOSHEN WEST LINE', N'TR3-RM05-GU20-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY TO GOSHEN WEST LINE', N'TR3-RM05-GU20-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STATION', N'TR3-RM05-GU30', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM05-GU30-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STATION SATELLITE DISH', N'TR3-RM05-GU30-SEC-VSAT1210', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU30-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM05-GU30-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM05-GU30-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER GOSHEN STA R8G22.3 (M16)', N'TR3-RM05-GU30-SEG-R8G22_3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SWG0001 SWITCHGEAR', N'TR3-RM05-GU30-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SWG0002 SWITCHGEAR', N'TR3-RM05-GU30-SEG-SWG0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SWG0003 SWITCHGEAR', N'TR3-RM05-GU30-SEG-SWG0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPS0001 UNINTERRUPTIBLE POWER SUPPLY', N'TR3-RM05-GU30-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM05-GU30-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM05-GU30-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM05-GU30-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA HUMAN MACHINE INTERFACE', N'TR3-RM05-GU30-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 MULTILIN', N'TR3-RM05-GU30-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 MULTILIN', N'TR3-RM05-GU30-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA UNIT 1 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU30-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA UNIT 2 PRGM LOGIC CONTROLLER', N'TR3-RM05-GU30-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GSHN STATION DISCHARGE PRESSURE PLC', N'TR3-RM05-GU30-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GSHN RTU A/B COMMUNICATION TO SCADA', N'TR3-RM05-GU30-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU30-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TK101 LEVEL', N'TR3-RM05-GU30-SIL-L0001', 0, 0, 5, 9991, N'en', 1)

go


GO


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 PRESSURE', N'TR3-RM05-GU30-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA UNIT 2 LOW PRESS/SEAL FAIL', N'TR3-RM05-GU30-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SUCTION PRESSURE', N'TR3-RM05-GU30-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA HIGH CASE PRESSURE S/D', N'TR3-RM05-GU30-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 CASE PRESS TRANS', N'TR3-RM05-GU30-SIL-P0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA DISCHARGE PRESSURE', N'TR3-RM05-GU30-SIL-P0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA HIGH DISCHARGE PRESSURE', N'TR3-RM05-GU30-SIL-P0105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 CASE PRESS TRANS', N'TR3-RM05-GU30-SIL-P0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 PRESSURE SEAL FAIL', N'TR3-RM05-GU30-SIL-P0901', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 PRESSURE SEAL FAIL', N'TR3-RM05-GU30-SIL-P0902', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 TEMPERATURE', N'TR3-RM05-GU30-SIL-T0901', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 TEMPERATURE', N'TR3-RM05-GU30-SIL-T0902', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 VIBRATION', N'TR3-RM05-GU30-SIL-V0901', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 VIBRATION', N'TR3-RM05-GU30-SIL-V0902', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM05-GU30-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM05-GU30-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA DISCHARGE CONTROL VALVE', N'TR3-RM05-GU30-SIV-PCV0107', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU30-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22.3E DS GOSHEN EAST ML DISCHARGE BV', N'TR3-RM05-GU30-SLE-HV0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22.3W DS GOSHEN WEST ML DISCHARGE BV', N'TR3-RM05-GU30-SLE-HV0109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SUMP DISCHARGE VALVE', N'TR3-RM05-GU30-SLE-HV0115', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 SUCTION VALVE', N'TR3-RM05-GU30-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 DISCHARGE VALVE', N'TR3-RM05-GU30-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 SUCTION VALVE', N'TR3-RM05-GU30-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 DISCHARGE VALVE', N'TR3-RM05-GU30-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22.3E US GOSHEN EAST ML SUCTION BV', N'TR3-RM05-GU30-SLE-MOV101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G22.3W US GOSHEN 8 WEST ML SUCTION BV', N'TR3-RM05-GU30-SLE-MOV102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU30-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GOSHEN STATION', N'TR3-RM05-GU30-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GOSHEN STATION', N'TR3-RM05-GU30-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM05-GU30-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 1 PUMP', N'TR3-RM05-GU30-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA ML UNIT 2 PUMP', N'TR3-RM05-GU30-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SUMP PUMP', N'TR3-RM05-GU30-SMP-P101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM05-GU30-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SUCTION STRAINER', N'TR3-RM05-GU30-SPT-S101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA SUMP TANK', N'TR3-RM05-GU30-SPT-TK101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM05-GU30-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA FIRE PROTECTION', N'TR3-RM05-GU30-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN TO HORSE CREEK EAST LINE', N'TR3-RM05-GU40', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU40-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER SLATER RD R8G25 (M16A)', N'TR3-RM05-GU40-SEG-R8G25', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER CHUGWATER R8G29 (M17)', N'TR3-RM05-GU40-SEG-R8G29', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER HIGHWAY 313 R8G34 (M17A)', N'TR3-RM05-GU40-SEG-R8G34', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER RANGE ROAD R8G38.6 (M17B)', N'TR3-RM05-GU40-SEG-R8G38_6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER LITTLE BEAR R8G47.2 (M18)', N'TR3-RM05-GU40-SEG-R8G47_2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER NIMMO R8G52 (M18B)', N'TR3-RM05-GU40-SEG-R8G52', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU40-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 E ML UPSTRM PRESS TRANS', N'TR3-RM05-GU40-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 EAST ML DWNSTRM PRESSURE', N'TR3-RM05-GU40-SIL-P0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 E ML DWNSTRM TEMP TRANS', N'TR3-RM05-GU40-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM05-GU40-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 EAST ML UPSTRM PIG SIGNAL', N'TR3-RM05-GU40-SIS-ZSX102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 EAST ML DWNSTRM PIG SIGNAL', N'TR3-RM05-GU40-SIS-ZSX108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU40-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G22_3E GOSHEN 8 EAST ML CHECK BV', N'TR3-RM05-GU40-SLE-CV8G22_3E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G34E SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU40-SLE-CV8G34E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G42_3E SEC11 T19N R66W LARAMIE CO BV', N'TR3-RM05-GU40-SLE-CV8G42_3E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G48E SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM05-GU40-SLE-CV8G48E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G54E HRS CRK 8 EAST ML CHECK BV', N'TR3-RM05-GU40-SLE-CV8G54E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G25E SEC13 T22N R66W PLATTE CO BV', N'TR3-RM05-GU40-SLE-HV8G25E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G34EDS SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU40-SLE-HV8G34EDS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G34EUS SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU40-SLE-HV8G34EUS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G42E SEC11 T19N R66W LARAMIE CO BV', N'TR3-RM05-GU40-SLE-HV8G42E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G47E SEC3 T18N R66W PLATTE CO BV', N'TR3-RM05-GU40-SLE-HV8G47E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G48E SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM05-GU40-SLE-HV8G48E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G53E SEC4 T17N R66W LARAMIE CO BV', N'TR3-RM05-GU40-SLE-HV8G53E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54E HRS CRK 8 E ML RECEIVER BYPASS BV', N'TR3-RM05-GU40-SLE-HV8G54E', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54EA HRS CRK 8 E ML RECEIVER BV', N'TR3-RM05-GU40-SLE-HV8G54EA', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54EB HRS CRK 8 E ML RECEIVER OUTLET BV', N'TR3-RM05-GU40-SLE-HV8G54EB', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CRK STA 8 EAST ML RECEIVER TRAP', N'TR3-RM05-GU40-SLE-X_10_0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU40-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GOSHEN TO HORSE CREEK EAST LINE', N'TR3-RM05-GU40-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GOSHEN TO HORSE CRK EST LINE', N'TR3-RM05-GU40-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN TO HORSE CREEK WEST LINE', N'TR3-RM05-GU50', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU50-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 W ML UPSTRM PRESS TRANS', N'TR3-RM05-GU50-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 WEST ML DWNSTRM PRESSURE', N'TR3-RM05-GU50-SIL-P0109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 W ML UPSTRM TEMP TRANS', N'TR3-RM05-GU50-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 W ML DWNSTRM TEMP TRANS', N'TR3-RM05-GU50-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM05-GU50-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 8 WEST ML UPSTRM PIG SIGNAL', N'TR3-RM05-GU50-SIS-ZSX101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GOSHEN STA 8 WEST ML DWNSTRM PIG SIGNAL', N'TR3-RM05-GU50-SIS-ZSX109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU50-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G22_3W GOSHEN 8 WEST ML CHECK BV', N'TR3-RM05-GU50-SLE-CV8G22_3W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G34W SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU50-SLE-CV8G34W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G42_3W SEC11 T19N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-CV8G42_3W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G48W SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-CV8G48W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV8G54W HRS CRK 8 WEST ML CHECK BV', N'TR3-RM05-GU50-SLE-CV8G54W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G25W SEC13 T22N R66W PLATTE CO BV', N'TR3-RM05-GU50-SLE-HV8G25W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G34WDS SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU50-SLE-HV8G34WDS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G34WU/S SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU50-SLE-HV8G34WUS', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G34X SEC2 T20N R66W PLATTE CO BV', N'TR3-RM05-GU50-SLE-HV8G34X', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G42W SEC11 T19N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-HV8G42W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G47W SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-HV8G47W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G48W SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-HV8G48W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G53W SEC4 T17N R66W LARAMIE CO BV', N'TR3-RM05-GU50-SLE-HV8G53W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54W HRS CRK 8 W ML RECEIVER BYPASS BV', N'TR3-RM05-GU50-SLE-HV8G54W', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54WA HRS CRK 8 W ML RECEIVER BV', N'TR3-RM05-GU50-SLE-HV8G54WA', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'8G54WB HRS CRK 8 W ML RECEIVER OUTLET BV', N'TR3-RM05-GU50-SLE-HV8G54WB', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CRK STA 8 WEST ML RECEIVER TRAP', N'TR3-RM05-GU50-SLE-X_10_0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU50-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GOSHEN TO HORSE CREEK WEST LINE', N'TR3-RM05-GU50-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GOSHEN TO HORSE CRK WST LINE', N'TR3-RM05-GU50-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CREEK STATION', N'TR3-RM05-GU60', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU60-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER HORSE CREEK STA R10H54 (M18A)', N'TR3-RM05-GU60-SEG-R10H54', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU60-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-HORSE CREEK STATION', N'TR3-RM05-GU60-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-HORSE CREEK STATION', N'TR3-RM05-GU60-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM05-GU60-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CREEK STA FIRE PROTECTION', N'TR3-RM05-GU60-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CREEK TO CHEYENNE', N'TR3-RM05-GU70', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM05-GU70-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER FABER R10H59 (M19)', N'TR3-RM05-GU70-SEG-R10H59', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER NORTH CHEYENNE R10H72 (M20)', N'TR3-RM05-GU70-SEG-R10H72', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM05-GU70-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML LINE PRESSURE', N'TR3-RM05-GU70-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML RECEIPT TEMPERATURE', N'TR3-RM05-GU70-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM05-GU70-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML RECEIPT PIG SIGNAL', N'TR3-RM05-GU70-SIS-ZSX101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM05-GU70-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D54.1 HRS CRK 10 ML LAUNCHER BYPASS BV', N'TR3-RM05-GU70-SLE-HV10D54_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D54.1A HRS CRK 10 ML LAUNCHER BV', N'TR3-RM05-GU70-SLE-HV10D54_1A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D54.1B HRS CR 10 ML LAUNCHER KICKER BV', N'TR3-RM05-GU70-SLE-HV10D54_1B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D60 SEC4 T16N R66W LARAMIE CO BV', N'TR3-RM05-GU70-SLE-HV10D60', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D72 SEC3 T16N R66W LARAMIE CO BV', N'TR3-RM05-GU70-SLE-HV10D72', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D77 SEC4 T13N R66W LARAMIE CO BV', N'TR3-RM05-GU70-SLE-HV10D77', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D77.8 CHY 10 ML RECEIVER BYPASS BV', N'TR3-RM05-GU70-SLE-MOV10D77_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D77.8A CHY 10 ML RECEIVER BV', N'TR3-RM05-GU70-SLE-MOV10D77_8A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D77.8B CHY 10 ML RECEIVER OUTLET BV', N'TR3-RM05-GU70-SLE-MOV10D77_8B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HORSE CRK STA 10 ML LAUNCHER TRAP', N'TR3-RM05-GU70-SLE-X003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML RECEIVER TRAP', N'TR3-RM05-GU70-SLE-X101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM05-GU70-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-HORSE CREEK TO CHEYENNE', N'TR3-RM05-GU70-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-HORSE CREEK TO CHEYENNE', N'TR3-RM05-GU70-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE 10"" LINE"', N'TR3-RM06', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE STATION', N'TR3-RM06-CH00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM06-CH00-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA DRA INJECTION PUMP SKID', N'TR3-RM06-CH00-SAB-DRA_INJECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HOISTING & LIFTING EQUIPMENT', N'TR3-RM06-CH00-SCH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSPORTATION EQUIPMENT', N'TR3-RM06-CH00-SCT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM06-CH00-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE STA SATELLITE DISH', N'TR3-RM06-CH00-SEC-VSAT1214', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA EMERGENCY BACKUP GENERATOR', N'TR3-RM06-CH00-SEG-GS0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM06-CH00-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM06-CH00-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0003 MOTOR CONTROL CENTER', N'TR3-RM06-CH00-SEG-MCC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER TANK 928 RCTF1 (M22A)', N'TR3-RM06-CH00-SEG-RCTF1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER TANK 1156 RCTF2 (M22B)', N'TR3-RM06-CH00-SEG-RCTF2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER CHEYENNE STA RCTF3 (M22)', N'TR3-RM06-CH00-SEG-RCTF3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SUB0001SUBSTATION', N'TR3-RM06-CH00-SEG-SUB0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SWG0001 SWITCHGEAR', N'TR3-RM06-CH00-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SWG0002 SWITCHGEAR', N'TR3-RM06-CH00-SEG-SWG0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CONTROL BUILDING UPS', N'TR3-RM06-CH00-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA NEW OFFICE BUILDING UPS', N'TR3-RM06-CH00-SEG-UPS0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM06-CH00-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0002 TRANSFORMER', N'TR3-RM06-CH00-SEG-XT0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM06-CH00-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOTOR, DRIVE, BRAKE & CLUTCH"', N'TR3-RM06-CH00-SEM', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML UNIT 3 PUMP VFD', N'TR3-RM06-CH00-SEM-VFD0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM06-CH00-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA HUMAN MACHINE INTERFACE', N'TR3-RM06-CH00-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P001 MULTILIN', N'TR3-RM06-CH00-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 MULTILIN', N'TR3-RM06-CH00-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P003 MULTILIN', N'TR3-RM06-CH00-SIC-ML0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P055 MULTILIN', N'TR3-RM06-CH00-SIC-ML0055', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P001 PROGRAMABLE LG CONTROLLER', N'TR3-RM06-CH00-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P002 PROGRAMABLE LG CONTROLLER', N'TR3-RM06-CH00-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P003 PROGRAMABLE LG CONTROLLER', N'TR3-RM06-CH00-SIC-PLC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STATION DISCHARGE PRESSURE PLC', N'TR3-RM06-CH00-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STATION METERING PLC', N'TR3-RM06-CH00-SIC-PLC000M', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STATION MAIN PLC', N'TR3-RM06-CH00-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STATION 2 MAIN PLC', N'TR3-RM06-CH00-SIC-PLC000S2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P055 PROGRAMABLE LG CONTROLLER', N'TR3-RM06-CH00-SIC-PLC0055', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY RTU A/B COMMUNICATIONS TO SCADA', N'TR3-RM06-CH00-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML RECEIPT GRAVITY', N'TR3-RM06-CH00-SIL-D0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML DISCHARGE GRAVITY', N'TR3-RM06-CH00-SIL-D0501', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 FLOW', N'TR3-RM06-CH00-SIL-F0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 LO TANK LEVEL', N'TR3-RM06-CH00-SIL-L0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK401 LEVEL', N'TR3-RM06-CH00-SIL-L0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK401 LEVEL', N'TR3-RM06-CH00-SIL-L0403', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK401 LEVEL', N'TR3-RM06-CH00-SIL-L0404', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK402 LEVEL', N'TR3-RM06-CH00-SIL-L0405', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK402 LEVEL', N'TR3-RM06-CH00-SIL-L0407', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK402 LEVEL', N'TR3-RM06-CH00-SIL-L0408', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK928 LEVEL', N'TR3-RM06-CH00-SIL-L0928', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1156 LEVEL', N'TR3-RM06-CH00-SIL-L1156', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1168 LEVEL', N'TR3-RM06-CH00-SIL-L1168', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P001 PRESSURE', N'TR3-RM06-CH00-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P002 PRESSURE', N'TR3-RM06-CH00-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P003 PRESSURE', N'TR3-RM06-CH00-SIL-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PROVING PRESSURE', N'TR3-RM06-CH00-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML RECEIPT PRESSURE', N'TR3-RM06-CH00-SIL-P0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML UNITS SUCTION PRESSURE', N'TR3-RM06-CH00-SIL-P0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM404 PRESSURE', N'TR3-RM06-CH00-SIL-P0404', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PROVING PRESSURE', N'TR3-RM06-CH00-SIL-P0405', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P055 PRESSURE', N'TR3-RM06-CH00-SIL-P0455', 0, 0, 5, 9991, N'en', 1)

gO



GO



INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SECONDARY DISCHARGE PRESS TRANS', N'TR3-RM06-CH00-SIL-P0501', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML UNITS CASE PRESSURE', N'TR3-RM06-CH00-SIL-P0503', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA HIGH CASE PRESSURE', N'TR3-RM06-CH00-SIL-P0504', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P001 TEMPERATURE', N'TR3-RM06-CH00-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P002 TEMPERATURE', N'TR3-RM06-CH00-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P003 TEMPERATURE', N'TR3-RM06-CH00-SIL-T0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA METER 1 TO OMNI 1 TEMP TRANS', N'TR3-RM06-CH00-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM404 TEMPERATURE', N'TR3-RM06-CH00-SIL-T0404', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PROVING TEMPERATURE', N'TR3-RM06-CH00-SIL-T0405', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P055 TEMPERATURE', N'TR3-RM06-CH00-SIL-T0455', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P001 VIBRATION', N'TR3-RM06-CH00-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P002 VIBRATION', N'TR3-RM06-CH00-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P003 VIBRATION', N'TR3-RM06-CH00-SIL-V0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P055 VIBRATION', N'TR3-RM06-CH00-SIL-V0455', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM06-CH00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML RECEIPT', N'TR3-RM06-CH00-SIR-FM101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML DNVR DELIVERY METER FM404', N'TR3-RM06-CH00-SIR-FM404', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STA FQI1 FLOW COMPUTER', N'TR3-RM06-CH00-SIR-FQI001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STA FQI2 FLOW COMPUTER', N'TR3-RM06-CH00-SIR-FQI002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEY STA FQI3 FLOW COMPUTER', N'TR3-RM06-CH00-SIR-FQI003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA METER PROVER', N'TR3-RM06-CH00-SIR-PVR401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM06-CH00-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSMITTER', N'TR3-RM06-CH00-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK928 LEVEL TRANSMITTER', N'TR3-RM06-CH00-SIT-LTI928', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM06-CH00-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML RECEIPT CONTROL VALVE', N'TR3-RM06-CH00-SIV-PCV0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML DISCHARGE CONTROL VALVE', N'TR3-RM06-CH00-SIV-PCV0501', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM001 PROVER SUPPLY VALVE', N'TR3-RM06-CH00-SLE-HV0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM001 PROVER ISOLATION VALVE', N'TR3-RM06-CH00-SLE-HV0109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM001 PROVER RETURN VALVE', N'TR3-RM06-CH00-SLE-HV0110', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM404 PROVER SUPPLY VALVE', N'TR3-RM06-CH00-SLE-HV0425', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM404 PROVER ISOLATION VALVE', N'TR3-RM06-CH00-SLE-HV0426', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM404 PROVER RETURN VALVE', N'TR3-RM06-CH00-SLE-HV0427', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P001 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P001 DISCHARGE VALVE', N'TR3-RM06-CH00-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 DISCHARGE VALVE', N'TR3-RM06-CH00-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P003 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0003A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P003 DISCHARGE VALVE', N'TR3-RM06-CH00-SLE-MOV0003B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML TO METER 3 DEL VALV', N'TR3-RM06-CH00-SLE-MOV0113', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML FM101 TO TK928 DEL VALVE', N'TR3-RM06-CH00-SLE-MOV0116', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML FM101 TO TK1156 DEL VALVE', N'TR3-RM06-CH00-SLE-MOV0117', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML FM101 TO TK1168 DEL VALVE', N'TR3-RM06-CH00-SLE-MOV0118', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1156 TO P53/P55 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0406', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1168 TO P53/P55 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0412', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P53 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0413', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK928 TO P53/P55 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0419', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P55 SUCTION VALVE', N'TR3-RM06-CH00-SLE-MOV0420', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PROVER X401 4-WAY DIVERTER VALVE', N'TR3-RM06-CH00-SLE-MOV0432', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-CHEYENNE STATION', N'TR3-RM06-CH00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-CHEYENNE STATION', N'TR3-RM06-CH00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AGITATION & MIXING', N'TR3-RM06-CH00-SMA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1156 MIXER', N'TR3-RM06-CH00-SMA-MX1156', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1168 MIXER', N'TR3-RM06-CH00-SMA-MX1168', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK928 MIXER', N'TR3-RM06-CH00-SMA-MX928A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK928 MIXER (REMOVED)', N'TR3-RM06-CH00-SMA-MX928B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM06-CH00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P001 PUMP ASSEMBLY', N'TR3-RM06-CH00-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P002 PUMP ASSEMBLY', N'TR3-RM06-CH00-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML P003 PUMP ASSEMBLY', N'TR3-RM06-CH00-SMP-P003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA HORIZONTAL BOOSTER PUMP ASSY', N'TR3-RM06-CH00-SMP-P053', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA VERTICAL BOOSTER PUMP ASSY', N'TR3-RM06-CH00-SMP-P055', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SUMP PUMP', N'TR3-RM06-CH00-SMP-P401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SUMP PUMP', N'TR3-RM06-CH00-SMP-P402', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM06-CH00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML RECEIPT STRAINER', N'TR3-RM06-CH00-SPT-S101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P55 SUCTION STRAINER', N'TR3-RM06-CH00-SPT-S401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML PUMP UNITS SUCTION STRAINER', N'TR3-RM06-CH00-SPT-S402', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML DNVR DELIVERY FM404 STRAINER', N'TR3-RM06-CH00-SPT-S404', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 35MBBL STORAGE TANK 1156', N'TR3-RM06-CH00-SPT-TK1156', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 38MBBL STORAGE TANK 1168', N'TR3-RM06-CH00-SPT-TK1168', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA SUMP TANK', N'TR3-RM06-CH00-SPT-TK401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA RECEIVING SUMP TANK', N'TR3-RM06-CH00-SPT-TK402', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 73MBBL STORAGE TANK 928', N'TR3-RM06-CH00-SPT-TK928', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM06-CH00-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE FIELD AED', N'TR3-RM06-CH00-SSA-FIELD_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE STATION AED', N'TR3-RM06-CH00-SSA-STATION_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH00-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FIRE PROTECTION', N'TR3-RM06-CH00-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM06-CH00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA ML METER RECEIPT', N'TR3-RM06-CH00-SSR-PRV0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA MAINLINE MANIFOLD', N'TR3-RM06-CH00-SSR-PRV0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PROVER TO SUMP', N'TR3-RM06-CH00-SSR-PRV0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1156 FILL LINE', N'TR3-RM06-CH00-SSR-PSV401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TK1156 TO P53/P55 SUCTION LINE', N'TR3-RM06-CH00-SSR-PSV403', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA P053 DISCHARGE PIPING', N'TR3-RM06-CH00-SSR-PSV414', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML HIGH PRESSURE RUPTURE PIN', N'TR3-RM06-CH00-SSR-RP102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM101 ML MANIFOLD RUPTURER PIN', N'TR3-RM06-CH00-SSR-RP112', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CENT HIGH PRESS RUPTURE PIN', N'TR3-RM06-CH00-SSR-RP204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM205 CEN MANIFOLD RUPTURER PIN', N'TR3-RM06-CH00-SSR-RP215', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CENT TO FRONTIER RUPTURE PIN', N'TR3-RM06-CH00-SSR-RP234', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL TEST EQUIPMENT', N'TR3-RM06-CH00-STE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHART RECORDER', N'TR3-RM06-CH00-STE-CR0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH00-STE-MM0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH00-STE-MM0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT TMI EQUIPMENT', N'TR3-RM06-CH00-STI', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH00-STI-LCB0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COUNTER, GEIGER"', N'TR3-RM06-CH00-STI-MTP0001', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH00-STI-TG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH00-STI-TG0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE TO WY/CO STATE LINE', N'TR3-RM06-CH10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH10-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND CHEYENNE STA B16D78 (LAUNCHER)', N'TR3-RM06-CH10-SEG-B16D78', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER TOWER HILL R10D84.5 (M23D)', N'TR3-RM06-CH10-SEG-R10D84_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML DWNSTRM PRESSURE', N'TR3-RM06-CH10-SIL-P0504', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 10 ML DWNSTRM TEMPERATURE', N'TR3-RM06-CH10-SIL-T0502', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D78 SEC4 T13N R66W LARAMIE CO BV', N'TR3-RM06-CH10-SLE-HV10D78', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D83 SEC33 T13N R66W LARAMIE CO BV', N'TR3-RM06-CH10-SLE-HV10D83', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-CHEYENNE TO CO/WY STATE LINE', N'TR3-RM06-CH10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-CHEYENNE TO CO/WY STATE LINE', N'TR3-RM06-CH10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'WY/CO STATE LINE TO AULT', N'TR3-RM06-CH20', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH20-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER DOVER R10D104 (M23A)', N'TR3-RM06-CH20-SEG-R10D104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER LONE TREE R10D97.5 (M23)', N'TR3-RM06-CH20-SEG-R10D97_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH20-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UPSTREAM TEMP TRANS', N'TR3-RM06-CH20-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH20-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D104 SEC7 T9N R66W WELD CO BV', N'TR3-RM06-CH20-SLE-HV10D104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D115 SEC8 T7N R66W WELD CO BV', N'TR3-RM06-CH20-SLE-HV10D115', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D116 SEC18 T7N R66W WELD CO BV', N'TR3-RM06-CH20-SLE-HV10D116', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D94 SEC29 T11N R66W WELD CO BV', N'TR3-RM06-CH20-SLE-HV10D94', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH20-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-CO/WY STATE LINE TO AULT', N'TR3-RM06-CH20-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-CO/WY STATE LINE TO AULT', N'TR3-RM06-CH20-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STATION', N'TR3-RM06-CH30', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM06-CH30-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA DRA INJECTION PUMP SKID', N'TR3-RM06-CH30-SAB-DRA_INJECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM06-CH30-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STATION SATELLITE DISH', N'TR3-RM06-CH30-SEC-VSAT1216', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH30-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM06-CH30-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM06-CH30-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0003 MOTOR CONTROL CENTER', N'TR3-RM06-CH30-SEG-MCC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER AULT STA R10D116 (M23B)', N'TR3-RM06-CH30-SEG-R10D116', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SWG0001 SWITCHGEAR', N'TR3-RM06-CH30-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA UPS', N'TR3-RM06-CH30-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM06-CH30-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM06-CH30-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM06-CH30-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA HUMAN MACHINE INTERFACE', N'TR3-RM06-CH30-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 1 MULTILIN', N'TR3-RM06-CH30-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 2 MULTILIN', N'TR3-RM06-CH30-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA UNIT 1 PRGM LOGIC CONTROLLER', N'TR3-RM06-CH30-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA UNIT 2 PRGM LOGIC CONTROLLER', N'TR3-RM06-CH30-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA PIPELINE INSTRUMENT CONTROLLER', N'TR3-RM06-CH30-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STATION MAIN PLC', N'TR3-RM06-CH30-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT RTU A/B COMMUNICATIONS TO SCADA', N'TR3-RM06-CH30-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH30-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP TK101 LEVEL', N'TR3-RM06-CH30-SIL-L0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP TK101 LEVEL', N'TR3-RM06-CH30-SIL-L0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP TK101 LEVEL', N'TR3-RM06-CH30-SIL-L0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P001 SUCTION/SEAL FAIL PRESSURE', N'TR3-RM06-CH30-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P002 SUCTION/SEAL FAIL PRESSURE', N'TR3-RM06-CH30-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUCTION PRESSURE TRANSMITTER', N'TR3-RM06-CH30-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P001 HIGH CASE PRESSURE', N'TR3-RM06-CH30-SIL-P0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P002 HIGH CASE PRESSURE', N'TR3-RM06-CH30-SIL-P0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNITS CASE PRESSURE', N'TR3-RM06-CH30-SIL-P0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA DISCHARGE PRESSURE', N'TR3-RM06-CH30-SIL-P0105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA DISCHARGE HIGH PRESSURE', N'TR3-RM06-CH30-SIL-P0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P001 TEMPERATURE', N'TR3-RM06-CH30-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P002 TEMPERATURE', N'TR3-RM06-CH30-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P001 VIBRATION', N'TR3-RM06-CH30-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P002 VIBRATION', N'TR3-RM06-CH30-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM06-CH30-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE, CONTROL & ACTUATOR"', N'TR3-RM06-CH30-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA DISCHARGE CONTROL VALVE', N'TR3-RM06-CH30-SIV-PCV0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH30-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA DISCHARGE VALVE', N'TR3-RM06-CH30-SLE-HV0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 1 SUCTION VALVE', N'TR3-RM06-CH30-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 1 DISCHARGE VALVE', N'TR3-RM06-CH30-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 2 SUCTION VALVE', N'TR3-RM06-CH30-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 2 DISCHARGE VALVE', N'TR3-RM06-CH30-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUCTION VALVE', N'TR3-RM06-CH30-SLE-MOV0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH30-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-AULT STATION', N'TR3-RM06-CH30-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-AULT STATION', N'TR3-RM06-CH30-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM06-CH30-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 1 PUMP ASSEMBLY', N'TR3-RM06-CH30-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 2 PUMP ASSEMBLY', N'TR3-RM06-CH30-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML UNIT 2 LO PUMP ASSEMBLY', N'TR3-RM06-CH30-SMP-P003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP PUMP', N'TR3-RM06-CH30-SMP-P101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM06-CH30-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUCTION STRAINER', N'TR3-RM06-CH30-SPT-S101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP TANK', N'TR3-RM06-CH30-SPT-TK101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH30-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA FIRE PROTECTION', N'TR3-RM06-CH30-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM06-CH30-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA SUMP PRESSURE RELIEF VALVE', N'TR3-RM06-CH30-SSR-PRV106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P001 DIFFERENTIAL RELIEF VALVE', N'TR3-RM06-CH30-SSR-PSV101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA P002 DIFFERENTIAL RELIEF VALVE', N'TR3-RM06-CH30-SSR-PSV102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT TO FT LUPTON', N'TR3-RM06-CH40', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH40-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BOND FORT LUPTON STA (B10D147)', N'TR3-RM06-CH40-SEG-CP0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER WOODS LAKE 10D121.5 (M24)', N'TR3-RM06-CH40-SEG-R10D121_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER THOMPSON RIVER 10D131.5 (M25)', N'TR3-RM06-CH40-SEG-R10D131_5', 0, 0, 5, 9991, N'en', 1)

go



GO


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER MIDPOINT STA R10D137.5 (M25A)', N'TR3-RM06-CH40-SEG-R10D137_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER PLATTEVILLE R10D142 (M26)', N'TR3-RM06-CH40-SEG-R10D142', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH40-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML INSTATION GRAVITY', N'TR3-RM06-CH40-SIL-D1201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BRACEWELL STA PRESSURE', N'TR3-RM06-CH40-SIL-P0120', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML HIGH LINE PRESSURE', N'TR3-RM06-CH40-SIL-P1201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML DWNSTRM TEMP TRANS', N'TR3-RM06-CH40-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML INCOMING TEMPERATURE', N'TR3-RM06-CH40-SIL-T1201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM06-CH40-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AULT STA ML PIG SIGNAL', N'TR3-RM06-CH40-SIS-ZSX101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 10 ML RECEIPT PIG SIGNAL', N'TR3-RM06-CH40-SIS-ZSX101A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 10 ML RECEIPT PIG SIGNAL', N'TR3-RM06-CH40-SIS-ZSX101B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH40-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'C10D116 AULT 10 ML CHECK BV', N'TR3-RM06-CH40-SLE-CV10D116', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV10DCV126 SEC 31 T6N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-CV10D126', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV10D134 SEC18 T4N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-CV10D134', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV10D147 FT LUPTON 10 ML CHECK BV', N'TR3-RM06-CH40-SLE-CV10D147', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP10 RECEIVER X101 DRAIN VALVE TO SUMP', N'TR3-RM06-CH40-SLE-HV0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D116_1 SEC18 T7N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-HV10D116_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D131 SEC31 T5N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-HV10D131', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D134 SEC18 T4N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-HV10D134', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 10 ML RECEIVER BYPASS BV', N'TR3-RM06-CH40-SLE-MOV0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 10 ML RECEIVER OUTLET BV', N'TR3-RM06-CH40-SLE-MOV0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D116_5 SEC18 T7N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-MOV10D116_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D123 SEC20 T6N R66W WELD CO BV', N'TR3-RM06-CH40-SLE-MOV10D123', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D147 (MOV147) FT LUPTON ML BLOCK BV', N'TR3-RM06-CH40-SLE-MOV10D147', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 10 ML RECEIVER TRAP', N'TR3-RM06-CH40-SLE-X101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH40-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-AULT TO FT. LUPTON', N'TR3-RM06-CH40-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-AULT TO FT. LUPTON', N'TR3-RM06-CH40-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM06-CH40-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BRACEWELL STATION', N'TR3-RM06-CH50', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH50-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BW STA LIGHTING BREAKER PANEL', N'TR3-RM06-CH50-SEG-LP0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM06-CH50-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER BRACEWELL STA R10D123 (M24A)', N'TR3-RM06-CH50-SEG-R10D123', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BRACEWELL STA UPS', N'TR3-RM06-CH50-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VSAT1221 BRACEWELL STATION VSAT', N'TR3-RM06-CH50-SEG-VSAT1221', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM06-CH50-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BW STA PROGRAMABLE LG CONTROLLER RTU A', N'TR3-RM06-CH50-SIC-PLC_RTU_A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BW STA PROGRAMABLE LG CONTROLLER RTU B', N'TR3-RM06-CH50-SIC-PLC_RTU_B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BW STA PROGRAMABLE LG CONTROLLER S1', N'TR3-RM06-CH50-SIC-PLC_S1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH50-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-BRACEWELL STATION', N'TR3-RM06-CH50-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-BRACEWELL STATION', N'TR3-RM06-CH50-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH50-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BRACEWELL STA FIRE PROTECTION', N'TR3-RM06-CH50-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B TO FT LUPTON', N'TR3-RM06-CH70', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH70-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH70-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B RECEIVER BYPASS', N'TR3-RM06-CH70-SLE-MOV0405', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SPINDLE B SUNCOR LAUNCHER TRAP', N'TR3-RM06-CH70-SLE-X400', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B RECEIVER TRAP', N'TR3-RM06-CH70-SLE-X401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH70-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-SPINDLE B TO FT LUPTON', N'TR3-RM06-CH70-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR MAINT-SPINDLE B TO FT LUPTON', N'TR3-RM06-CH70-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM, COLUMN, TANK, VESSEL, WELLHEAD"', N'TR3-RM06-CH70-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH70-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STATION', N'TR3-RM06-CH80', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM06-CH80-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HOISTING & LIFTING EQUIPMENT', N'TR3-RM06-CH80-SCH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSPORTATION EQUIPMENT', N'TR3-RM06-CH80-SCT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM06-CH80-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STATION SATELLITE DISH', N'TR3-RM06-CH80-SEC-VSAT1218', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH80-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP MOTOR CONTROL CENTER', N'TR3-RM06-CH80-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP MOTOR CONTROL CENTER', N'TR3-RM06-CH80-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0003 MOTOR CONTROL CENTER', N'TR3-RM06-CH80-SEG-MCC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0004 MOTOR CONTROL CENTER', N'TR3-RM06-CH80-SEG-MCC0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER FT LUPTON STA RFLTF1 (M26A)', N'TR3-RM06-CH80-SEG-RFLTF1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SWG0001 SWITCHGEAR', N'TR3-RM06-CH80-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UPS', N'TR3-RM06-CH80-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM06-CH80-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM06-CH80-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM06-CH80-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA HUMAN MACHINE INTERFACE', N'TR3-RM06-CH80-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 1 MULTILIN', N'TR3-RM06-CH80-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 2 MULTILIN', N'TR3-RM06-CH80-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 3 MULTILIN', N'TR3-RM06-CH80-SIC-ML0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA BOOSTER PUMP 50 MULTILIN', N'TR3-RM06-CH80-SIC-ML0050', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA BOOSTER PUMP 51 MULTILIN', N'TR3-RM06-CH80-SIC-ML0051', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 1 PRGM LOGIC CONTROL', N'TR3-RM06-CH80-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 2 PRGM LOGIC CONTROL', N'TR3-RM06-CH80-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 3 PRGM LOGIC CONTROL', N'TR3-RM06-CH80-SIC-PLC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 50 PRGM LOGIC CONTROL', N'TR3-RM06-CH80-SIC-PLC0050', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 51 PRGM LOGIC CONTROL', N'TR3-RM06-CH80-SIC-PLC0051', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP DISCHARGE PRESSURE PLC', N'TR3-RM06-CH80-SIC-PLC_C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STATION PLC', N'TR3-RM06-CH80-SIC-PLC_H', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STATION METERING PLC', N'TR3-RM06-CH80-SIC-PLC_M', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STATION MAIN PLC', N'TR3-RM06-CH80-SIC-PLC_S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STATION RTU PLC', N'TR3-RM06-CH80-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM06-CH80-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA CRITICAL SUMP/LOW FLOW', N'TR3-RM06-CH80-SIL-F0350', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA CRITICAL SUMP/LOW FLOW', N'TR3-RM06-CH80-SIL-F0351', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK004 LEVEL', N'TR3-RM06-CH80-SIL-L0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1148 LEVEL', N'TR3-RM06-CH80-SIL-L1148', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1149 LEVEL', N'TR3-RM06-CH80-SIL-L1149', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK003 LEVEL', N'TR3-RM06-CH80-SIL-L1201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK003 LEVEL', N'TR3-RM06-CH80-SIL-L1202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK003 LEVEL', N'TR3-RM06-CH80-SIL-L1203', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK003 LEVEL', N'TR3-RM06-CH80-SIL-L1204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P001 PRESSURE', N'TR3-RM06-CH80-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P002 PRESSURE', N'TR3-RM06-CH80-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P003 PRESSURE', N'TR3-RM06-CH80-SIL-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P050 PRESSURE', N'TR3-RM06-CH80-SIL-P0350', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P051 PRESSURE', N'TR3-RM06-CH80-SIL-P0351', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FM003 PRESSURE', N'TR3-RM06-CH80-SIL-P0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SUCTION PRESSURE', N'TR3-RM06-CH80-SIL-P1203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P001 CASE PRESSURE', N'TR3-RM06-CH80-SIL-P1204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FM002 PRESSURE', N'TR3-RM06-CH80-SIL-P1206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA PVR001 PRESSURE', N'TR3-RM06-CH80-SIL-P1208', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT PRESSURE', N'TR3-RM06-CH80-SIL-P1211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P003 SUCTION PRESSURE', N'TR3-RM06-CH80-SIL-P1216', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA DISCHARGE PRESURE', N'TR3-RM06-CH80-SIL-P1218', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P001 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P002 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P003 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P050 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0350', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P051 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0351', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FM003 TEMPERATURE', N'TR3-RM06-CH80-SIL-T0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FM002 TEMPERATURE', N'TR3-RM06-CH80-SIL-T1206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FM001 TEMPERATURE', N'TR3-RM06-CH80-SIL-T1207', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA PRV001 TEMPERATURE', N'TR3-RM06-CH80-SIL-T1208', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P001 VIBRATION', N'TR3-RM06-CH80-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P002 VIBRATION', N'TR3-RM06-CH80-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P003 VIBRATION', N'TR3-RM06-CH80-SIL-V0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P050 VIBRATION', N'TR3-RM06-CH80-SIL-V0350', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P051 VIBRATION', N'TR3-RM06-CH80-SIL-V0351', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA GRAVITY / VISCOSITY', N'TR3-RM06-CH80-SIL-V1202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM06-CH80-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT METER', N'TR3-RM06-CH80-SIR-FM001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML DELIVERY METER', N'TR3-RM06-CH80-SIR-FM002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B DEL TO FT LUPTON', N'TR3-RM06-CH80-SIR-FM003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP FLOW COMPUTER OMNI', N'TR3-RM06-CH80-SIR-FQI1204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA METER PROVER', N'TR3-RM06-CH80-SIR-PVR001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM06-CH80-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSMITTER', N'TR3-RM06-CH80-SIT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM06-CH80-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA BACKPRESSURE CONTROL VALVE', N'TR3-RM06-CH80-SIV-PCV0318', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM06-CH80-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM001 PROVER ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0307', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM001 PROVER SUPPLY VALVE', N'TR3-RM06-CH80-SLE-HV0308', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM001 PROVER RETURN VALVE', N'TR3-RM06-CH80-SLE-HV0309', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP FM002 TO TK1148 NOZZLE VALVE', N'TR3-RM06-CH80-SLE-HV0314', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP RP001 TO TK1148 NOZZLE VALVE', N'TR3-RM06-CH80-SLE-HV0316', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP TK1148 TO BOOSTER PUMPS VALVE', N'TR3-RM06-CH80-SLE-HV0317', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP FM001 TO TK1149 NOZZLE VALVE', N'TR3-RM06-CH80-SLE-HV0332', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STRAINER S302 U/S ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0338', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM002 PROVER ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0339', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM002 PROVER SUPPLY VALVE', N'TR3-RM06-CH80-SLE-HV0340', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM002 PROVER RETURN VALVE', N'TR3-RM06-CH80-SLE-HV0341', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP RP001 D/S ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0343', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP RP001 U/S ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0345', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP RP001 TO TK1149 NOZZLE VALVE', N'TR3-RM06-CH80-SLE-HV0347', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP BOOSTER PUMP 50 SUCTION VALVE', N'TR3-RM06-CH80-SLE-HV0351', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM003 PROVER ISOLATION VALVE', N'TR3-RM06-CH80-SLE-HV0408', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM003 PROVER SUPPLY VALVE', N'TR3-RM06-CH80-SLE-HV0409', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON FM003 PROVER RETURN VALVE', N'TR3-RM06-CH80-SLE-HV0410', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 1 SUCTION VALVE', N'TR3-RM06-CH80-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 1 DISCHARGE VALVE', N'TR3-RM06-CH80-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 2 SUCTION VALVE', N'TR3-RM06-CH80-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 2 DISCHARGE VALVE', N'TR3-RM06-CH80-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 3 SUCTION VALVE', N'TR3-RM06-CH80-SLE-MOV0003A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 3 DISCHARGE VALVE', N'TR3-RM06-CH80-SLE-MOV0003B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SUCTION VALVE (10D147A) BV', N'TR3-RM06-CH80-SLE-MOV0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML TO ML PUMP SUCTION', N'TR3-RM06-CH80-SLE-MOV0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML TO TANKAGE', N'TR3-RM06-CH80-SLE-MOV0302', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT METER TO TK1148', N'TR3-RM06-CH80-SLE-MOV0313', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1148 TO P051 SUCTION', N'TR3-RM06-CH80-SLE-MOV0318', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FROM ML RECIEPT METER 1', N'TR3-RM06-CH80-SLE-MOV0332', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT METER TO TK1149', N'TR3-RM06-CH80-SLE-MOV0333', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1149 TO PUMP 51 SUCTION', N'TR3-RM06-CH80-SLE-MOV0348', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1149 TO PUMP 50 SUCTION', N'TR3-RM06-CH80-SLE-MOV0349', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1148 TO P050 SUCTION', N'TR3-RM06-CH80-SLE-MOV0350', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P050 DISCHARGE', N'TR3-RM06-CH80-SLE-MOV0352', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA PROVER 4WAY DIVERTER VALVE', N'TR3-RM06-CH80-SLE-MOV0353', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P051 DISCHARGE', N'TR3-RM06-CH80-SLE-MOV0357', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B TO TK 1148', N'TR3-RM06-CH80-SLE-MOV0402', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B TO TK1149', N'TR3-RM06-CH80-SLE-MOV0411', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STORAGE TO UNIT 3', N'TR3-RM06-CH80-SLE-MOV0626', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP STORAGE TO UNITS 1 OR 2', N'TR3-RM06-CH80-SLE-MOV0627', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP UNITS 1 OR 2 DISCHARGE TO 10 ML', N'TR3-RM06-CH80-SLE-MOV0628', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH80-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-FT. LUPTON STATION', N'TR3-RM06-CH80-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-FT. LUPTON STATION', N'TR3-RM06-CH80-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'AGITATION & MIXING', N'TR3-RM06-CH80-SMA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1148 MIXER', N'TR3-RM06-CH80-SMA-MX1148', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TK1149 MIXER', N'TR3-RM06-CH80-SMA-MX1149', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM06-CH80-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 1 PUMP ASSY', N'TR3-RM06-CH80-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 2 PUMP ASSY', N'TR3-RM06-CH80-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML UNIT 3 PUMP ASSY', N'TR3-RM06-CH80-SMP-P003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ORIGINATION BSTR PUMP ASSY', N'TR3-RM06-CH80-SMP-P050', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA INJECTION BSTR PUMP ASSY', N'TR3-RM06-CH80-SMP-P051', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SUMP PUMP', N'TR3-RM06-CH80-SMP-P130', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON RECEIVING SUMP PUMP', N'TR3-RM06-CH80-SMP-P131', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM06-CH80-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT STRAINER', N'TR3-RM06-CH80-SPT-S301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML DELIVERY STRAINER', N'TR3-RM06-CH80-SPT-S302', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B RECEIPT STRAINER', N'TR3-RM06-CH80-SPT-S401', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SUMP TANK', N'TR3-RM06-CH80-SPT-TK003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON RECEIVER/LAUNCHER SUMP TANK', N'TR3-RM06-CH80-SPT-TK004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 23MBBL STORAGE TANK 1148', N'TR3-RM06-CH80-SPT-TK1148', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA 23MBBL STORAGE TANK 1149', N'TR3-RM06-CH80-SPT-TK1149', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM06-CH80-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FORT LUPTON STATION AED', N'TR3-RM06-CH80-SSA-STATION_AED', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH80-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA FIRE PROTECTION', N'TR3-RM06-CH80-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM06-CH80-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA MAINLINE METER RECEIPT', N'TR3-RM06-CH80-SSR-PRV0300', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML RECEIPT TO ML UNITS', N'TR3-RM06-CH80-SSR-PRV0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA RUPTURE PIN RELIEF LINE', N'TR3-RM06-CH80-SSR-PRV0304', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA MAINLINE METERED RECEIPT', N'TR3-RM06-CH80-SSR-PRV0305', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TANK BOOSTER(S) SUCTION', N'TR3-RM06-CH80-SSR-PRV0306', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UPSTREAM FM002 STRAINER', N'TR3-RM06-CH80-SSR-PRV0311', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA DWNSTREAM FM002 STRAINER', N'TR3-RM06-CH80-SSR-PRV0312', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA METER PROVER PRV', N'TR3-RM06-CH80-SSR-PRV0313', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SUMP PUMP DISCHARGE', N'TR3-RM06-CH80-SSR-PRV0317', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B RECEIPT', N'TR3-RM06-CH80-SSR-PRV0401', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE B RECEIPT MANIFOLD', N'TR3-RM06-CH80-SSR-PRV0402', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P51 CHECK TO MOV357', N'TR3-RM06-CH80-SSR-PSV302', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA MAINLINE METERED RECEIPT', N'TR3-RM06-CH80-SSR-PSV307', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA RUPTURE PIN RELIEF LINE', N'TR3-RM06-CH80-SSR-PSV308', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TANK BSTR PUMP 50 SUCTION', N'TR3-RM06-CH80-SSR-PSV309', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA P50 CHECK TO MOV352', N'TR3-RM06-CH80-SSR-PSV310', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 1 THERMAL RELIEF', N'TR3-RM06-CH80-SSR-PSV314', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 2 THERMAL RELIEF', N'TR3-RM06-CH80-SSR-PSV315', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA UNIT 3 THERMAL RELIEF', N'TR3-RM06-CH80-SSR-PSV316', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA TANK BSTR PUMP 51 SUCTION', N'TR3-RM06-CH80-SSR-PSV319', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA SPINDLE ""B"" RECEIPT"', N'TR3-RM06-CH80-SSR-PSV403', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA ML HIGH PRESS RUPTURE PIN', N'TR3-RM06-CH80-SSR-RP001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STA RECEIPT MANF RUPTURE PIN', N'TR3-RM06-CH80-SSR-RP002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL TEST EQUIPMENT', N'TR3-RM06-CH80-STE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL TEST EQUIPMENT', N'TR3-RM06-CH80-STE-MM0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT TMI EQUIPMENT', N'TR3-RM06-CH80-STI', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH80-STI-LCB0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH80-STI-MTP0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TEST EQUIPMENT', N'TR3-RM06-CH80-STI-TSG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DENVER STATION', N'TR3-RM06-CH95', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'TRANSPORTATION EQUIPMENT', N'TR3-RM06-CH95-SCT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM06-CH95-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM06-CH95-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DENVER CRUDE STA UPS', N'TR3-RM06-CH95-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM06-CH95-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM06-CH95-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM06-CH95-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-DENVER STATION', N'TR3-RM06-CH95-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-DENVER STATION', N'TR3-RM06-CH95-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM06-CH95-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM06-CH95-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DENVER STA FIRE PROTECTION', N'TR3-RM06-CH95-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE 16"" LINE"', N'TR3-RM07', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY STATION', N'TR3-RM07-CC00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM07-CC00-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STATION CONTROL BUILDING', N'TR3-RM07-CC00-SAB-PDC001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HOISTING & LIFTING EQUIPMENT', N'TR3-RM07-CC00-SCH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM07-CC00-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM07-CC00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA EMERGENCY BACKUP GENERATOR', N'TR3-RM07-CC00-SEG-GS0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM UPS BYPASS TRANSFER SWITCH', N'TR3-RM07-CC00-SEG-MBS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM MOTOR CONTROL CENTER', N'TR3-RM07-CC00-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM UDS UNITIZED DISTIBUTION SUBSTATION', N'TR3-RM07-CC00-SEG-PA0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY STATION UPS', N'TR3-RM07-CC00-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM07-CC00-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA PROGRAMABLE LOGIC CONTROLLER', N'TR3-RM07-CC00-SIC-PLC_M', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA PROGRAMABLE LOGIC CONTROLLER', N'TR3-RM07-CC00-SIC-PLC_S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA RTU A/B COMMUNICATIOIN TO SCADA', N'TR3-RM07-CC00-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM07-CC00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STATION SUMP TANK LEVEL', N'TR3-RM07-CC00-SIL-L0300', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM METER PROVER PRESSURE', N'TR3-RM07-CC00-SIL-P0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM METER PROVER TEMPERATURE', N'TR3-RM07-CC00-SIL-T0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM07-CC00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA FQI 1 FLOW COMPUTER', N'TR3-RM07-CC00-SIR-FQI001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA FQI 2 FLOW COMPUTER', N'TR3-RM07-CC00-SIR-FQI002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA PRESSURE RECORDER', N'TR3-RM07-CC00-SIR-PR100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STA PRESSURE RECORDER', N'TR3-RM07-CC00-SIR-PR201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM METER PROVER', N'TR3-RM07-CC00-SIR-PVR301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM07-CC00-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM07-CC00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM101 PROVER RETURN VALVE', N'TR3-RM07-CC00-SLE-HV0115', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM102 PROVER RETURN VALVE', N'TR3-RM07-CC00-SLE-HV0118', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP102 U/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0119', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP102 D/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0120', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP102 BYPASS VALVE', N'TR3-RM07-CC00-SLE-HV0121', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP101 U/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0122', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP101 D/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0123', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM201 PROVER RETURN VALVE', N'TR3-RM07-CC00-SLE-HV0215', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM202 PROVER RETURN VALVE', N'TR3-RM07-CC00-SLE-HV0218', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RP202 U/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0219', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RP202 D/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0220', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RP202 BYPASS VALVE', N'TR3-RM07-CC00-SLE-HV0221', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RP201 U/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0222', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RP201 D/S ISOLATION VALVE', N'TR3-RM07-CC00-SLE-HV0223', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 TANK TK775 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 TANK TK776 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0107', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 TANK TK58 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0108', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 TANK TK775 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 TANK TK776 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0207', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 TANK TK58 DELIVERY VALVE', N'TR3-RM07-CC00-SLE-MOV0208', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM PROVER 4-WAY DIVERTER VALVE', N'TR3-RM07-CC00-SLE-MOV0301', 0, 0, 5, 9991, N'en', 1)

go


GO


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM07-CC00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMMERCE CITY STATION', N'TR3-RM07-CC00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMMERCE CITY STATION', N'TR3-RM07-CC00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM07-CC00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STATION SUMP PUMP', N'TR3-RM07-CC00-SMP-P300', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM07-CC00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM STATION SUMP TANK', N'TR3-RM07-CC00-SPT-TK300', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FIRST AID EQUIPMENT', N'TR3-RM07-CC00-SSA', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM07-CC00-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY STA FIRE PROTECTION', N'TR3-RM07-CC00-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM07-CC00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RP102 BYPASS PRESSURE RELIEF', N'TR3-RM07-CC00-SSR-PRV0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 TO TANKAGE DELIVERY MANIFOLD', N'TR3-RM07-CC00-SSR-PRV0105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM PROVER PRESSURE RELIEF', N'TR3-RM07-CC00-SSR-PRV0301', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM E PLANT DELIVERY LINE PRESS RELIEF', N'TR3-RM07-CC00-SSR-PSV106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER MANIFOLD PRESSURE RELIEF', N'TR3-RM07-CC00-SSR-PSV107', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER MANIFOLD PRESSURE RELIEF', N'TR3-RM07-CC00-SSR-PSV207', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 HIGH LINE PRESSURE RUPTURE PIN', N'TR3-RM07-CC00-SSR-RP101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIPT MANIFOLD RUPTURE PIN', N'TR3-RM07-CC00-SSR-RP102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 HIGH LINE PRESSURE RUPTURE PIN', N'TR3-RM07-CC00-SSR-RP201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIPT MANIFOLD RUPTURE PIN', N'TR3-RM07-CC00-SSR-RP202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE STATION', N'TR3-RM07-CY00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM07-CY00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM07-CY00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA DISCHARGE PRESSURE', N'TR3-RM07-CY00-SIL-P0601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA DISCHARGE PRESSURE SWITCH', N'TR3-RM07-CY00-SIL-P0603', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA DISCHARGE TEMPERATURE', N'TR3-RM07-CY00-SIL-T0602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM07-CY00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM07-CY00-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA LAUNCHER PIG SIGNAL', N'TR3-RM07-CY00-SIS-ZSX601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM07-CY00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 16 ML LAUNCHER KICKER BV', N'TR3-RM07-CY00-SLE-MOV0602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 16 ML LAUNCHER BV', N'TR3-RM07-CY00-SLE-MOV0604', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 16 ML LAUNCHER BYPASS BV', N'TR3-RM07-CY00-SLE-MOV0605', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 16 ML LAUNCHER TRAP', N'TR3-RM07-CY00-SLE-X601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM07-CY00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-CHEYENNE STATION', N'TR3-RM07-CY00-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR_MAINT-CHEYENNE STATION', N'TR3-RM07-CY00-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE TO WY/CO STATE LINE', N'TR3-RM07-CY10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM07-CY10-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM07-CY10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM07-CY10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHECK VALVE 16"" ML COLLEGE DRIVE BV"', N'TR3-RM07-CY10-SLE-CV16D79', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLOCK VALVE 16"" ML I-80 BV"', N'TR3-RM07-CY10-SLE-HV16D78', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLOCK VALVE 16"" ML HIGHWAY-85 BV"', N'TR3-RM07-CY10-SLE-HV16D83', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM07-CY10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-CHEYENNE TO WY/CO STATE LINE', N'TR3-RM07-CY10-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR_MAINT-CHEYENNE TO WY/CO STATE LINE', N'TR3-RM07-CY10-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'WY/CO STATE LINE TO CIG STATION', N'TR3-RM07-CY20', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM07-CY20-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM07-CY20-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML MOV90 PRESSURE', N'TR3-RM07-CY20-SIL-P0602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM07-CY20-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BLOCK VALVE 16"" ML CIG STATION BV"', N'TR3-RM07-CY20-SLE-MOV16D90', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM07-CY20-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-CO/WY STATE LINE TO CIG STA', N'TR3-RM07-CY20-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR_MAINT-CO/WY STATE LINE TO CIG STA', N'TR3-RM07-CY20-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STATION', N'TR3-RM07-CY30', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'BUILDING, FIXTURE & HVAC"', N'TR3-RM07-CY30-SAB', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STATION DRA INJECTION PUMP SKID', N'TR3-RM07-CY30-SAB-DRA_INJECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM07-CY30-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM07-CY30-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STATION MAIN PLC', N'TR3-RM07-CY30-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STATION 3 MAIN PLC', N'TR3-RM07-CY30-SIC-PLC000S3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG RTU A/B COMMUNICATION TO SCADA', N'TR3-RM07-CY30-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM07-CY30-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML DWNSTRM PRESSURE', N'TR3-RM07-CY30-SIL-P0506', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIPT TEMP TRANSMITTER', N'TR3-RM07-CY30-SIL-T0603', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM07-CY30-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM07-CY30-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML LAUNCHER PIG SIGNAL', N'TR3-RM07-CY30-SIS-ZSX502', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIPT PIG SIGNAL', N'TR3-RM07-CY30-SIS-ZSX602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM07-CY30-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML LAUNCHER KICKER BV', N'TR3-RM07-CY30-SLE-MOV0506', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML LAUNCHER BV', N'TR3-RM07-CY30-SLE-MOV0507', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML LAUNCHER BYPASS BV', N'TR3-RM07-CY30-SLE-MOV0508', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIVER OUTLET BV', N'TR3-RM07-CY30-SLE-MOV0606', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIVER BV', N'TR3-RM07-CY30-SLE-MOV0607', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIVER BYPASS BV', N'TR3-RM07-CY30-SLE-MOV0608', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 10 ML LAUNCHER TRAP', N'TR3-RM07-CY30-SLE-X502', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STA 16 ML RECEIVER TRAP', N'TR3-RM07-CY30-SLE-X602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM07-CY30-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COR CONT-CIG STATION', N'TR3-RM07-CY30-SLP-CORROSION_CONTROL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAJOR_MAINT-CIG STATION', N'TR3-RM07-CY30-SLP-MAJOR_MAINT', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM07-CY30-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CIG STATION FIRE PROTECTION', N'TR3-RM07-CY30-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CENTENNIAL', N'TR3-RM09', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STATION', N'TR3-RM09-CE00', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM09-CE00-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM09-CE00-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOTOR, DRIVE, BRAKE & CLUTCH"', N'TR3-RM09-CE00-SEM', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM09-CE00-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 1 MULTILIN', N'TR3-RM09-CE00-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 MULTILIN', N'TR3-RM09-CE00-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 MULTILIN', N'TR3-RM09-CE00-SIC-ML0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 MULTILIN', N'TR3-RM09-CE00-SIC-ML0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA OIT2 OP INTERFACE TERMINAL', N'TR3-RM09-CE00-SIC-OIT0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC1 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE00-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC2 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE00-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC3 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE00-SIC-PLC0003', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLC6 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE00-SIC-PLC0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA PLCC PRGM LOGIC CONTROLLER', N'TR3-RM09-CE00-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE00-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN LAUNCHER GRAVITY', N'TR3-RM09-CE00-SIL-D0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT UNIT 1 PRESSURE', N'TR3-RM09-CE00-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 PRESSURE', N'TR3-RM09-CE00-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 PRESSURE', N'TR3-RM09-CE00-SIL-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 PRESSURE', N'TR3-RM09-CE00-SIL-P0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN SPLITTER PRESSURE', N'TR3-RM09-CE00-SIL-P0008', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM14 PRESSURE', N'TR3-RM09-CE00-SIL-P0517', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA UNIT 2 SUCTION PRESSURE', N'TR3-RM09-CE00-SIL-P0809', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT DISCHARGE PRESSURE', N'TR3-RM09-CE00-SIL-P0810', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN CASE PRESSURE', N'TR3-RM09-CE00-SIL-P0811', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 1 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM008 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0008', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA P54B TEMPERATURE', N'TR3-RM09-CE00-SIL-T0516', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM14 TEMPERATURE', N'TR3-RM09-CE00-SIL-T0517', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN DISCHARGE TEMPERATURE', N'TR3-RM09-CE00-SIL-T0810', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 1 VIBRATION', N'TR3-RM09-CE00-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 VIBRATION', N'TR3-RM09-CE00-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 VIBRATION', N'TR3-RM09-CE00-SIL-V0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 VIBRATION', N'TR3-RM09-CE00-SIL-V0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM09-CE00-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA FM008 CENT', N'TR3-RM09-CE00-SIR-FM008', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT BLEND METER', N'TR3-RM09-CE00-SIR-FM014', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM09-CE00-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0002 CONTROL VALVE', N'TR3-RM09-CE00-SIV-FCV0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FCV0517 TK1 CENT BLEND FLOW CNTRL VALVE', N'TR3-RM09-CE00-SIV-FCV0517', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PCV0516 TK1 CENT BLEND PRESS CNTRL VALVE', N'TR3-RM09-CE00-SIV-PCV0516', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN LAUNCHER CONTROL VALVE', N'TR3-RM09-CE00-SIV-PCV0810', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE00-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT UNIT 1 SUCTION VALVE', N'TR3-RM09-CE00-SLE-HV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT UNIT 1 DISCHARGE VALVE', N'TR3-RM09-CE00-SLE-HV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 8 TO PROVER', N'TR3-RM09-CE00-SLE-HV0193', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 8 BLOCK & BLEED', N'TR3-RM09-CE00-SLE-HV0194', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA MTR 8 FROM PROVER', N'TR3-RM09-CE00-SLE-HV0195', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 SUCTION VALVE', N'TR3-RM09-CE00-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 2 DISCHARGE VALVE', N'TR3-RM09-CE00-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 SUCTION VALVE', N'TR3-RM09-CE00-SLE-MOV0003A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 3 DISCHARGE VALVE', N'TR3-RM09-CE00-SLE-MOV0003B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 SUCTION VALVE', N'TR3-RM09-CE00-SLE-MOV0006A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNIT 6 DISCHARGE VALVE', N'TR3-RM09-CE00-SLE-MOV0006B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA TANKAGE TO CENT', N'TR3-RM09-CE00-SLE-MOV0080', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK56', N'TR3-RM09-CE00-SLE-MOV0082', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK89', N'TR3-RM09-CE00-SLE-MOV0083', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK86', N'TR3-RM09-CE00-SLE-MOV0085', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK888', N'TR3-RM09-CE00-SLE-MOV0087', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK1158', N'TR3-RM09-CE00-SLE-MOV0088', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT FROM TK1280', N'TR3-RM09-CE00-SLE-MOV0089', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT TK1280 TO TK1 BLEND', N'TR3-RM09-CE00-SLE-MOV0505', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT TK1 TO TK1 BLEND', N'TR3-RM09-CE00-SLE-MOV0508', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT BLEND MANIFOLD DISCH', N'TR3-RM09-CE00-SLE-MOV0521', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN TO ML BLENDING MANIFOLD', N'TR3-RM09-CE00-SLE-MOV0523', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENT TK1 BLEND BYPASS', N'TR3-RM09-CE00-SLE-MOV0525', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE00-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY STATION', N'TR3-RM09-CE00-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY STATION', N'TR3-RM09-CE00-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FAN,BLOWER & COMPRESSOR"', N'TR3-RM09-CE00-SMF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM09-CE00-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0001 GUERNSEY STA CENT UNIT 1', N'TR3-RM09-CE00-SMP-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0002 GUERNSEY STA CENT UNIT 2', N'TR3-RM09-CE00-SMP-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0003 GUERNSEY STA CENT UNIT 3', N'TR3-RM09-CE00-SMP-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0006 GUERNSEY STA CENT UNIT 6', N'TR3-RM09-CE00-SMP-P0006', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P0054B GUERNSEY STA CENT BLEND PUMP', N'TR3-RM09-CE00-SMP-P0054B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'P2000 GUERNSEY STA ML SUMP PUMP', N'TR3-RM09-CE00-SMP-P2000', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM09-CE00-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA S008 STRAINER', N'TR3-RM09-CE00-SPT-S008', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN UNITS SUCTION STRAINER', N'TR3-RM09-CE00-SPT-S009', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM09-CE00-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENTENNIAL METER RUN', N'TR3-RM09-CE00-SSR-PRV0194', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CENTENNIAL BLENDING RELIEF', N'TR3-RM09-CE00-SSR-PRV0521', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY TO SLATER', N'TR3-RM09-CE10', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM09-CE10-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER CHUGWATER CREEK R12C23 (A1)', N'TR3-RM09-CE10-SEG-R12C23', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE10-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA CEN INSTATION TEMPERATURE', N'TR3-RM09-CE10-SIL-T0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE10-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C23 SEC36 T23N R67W PLATTE CO BV', N'TR3-RM09-CE10-SLE-CV12C23', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C3 SEC32 T26N R65W PLATTE CO BV', N'TR3-RM09-CE10-SLE-CV12C3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C1 SEC20 T26N R65W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C13 SEC12 T24N R66W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C13', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C21 SEC17 T23N R66W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C21', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C23 SEC36 T23N R67W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C23', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C288 SEC21 T22N R67W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C28_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C3 SEC32 T26N R65W PLATTE CO BV', N'TR3-RM09-CE10-SLE-HV12C3', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C0 GUERNSEY CEN LAUNCHER BYPASS BV', N'TR3-RM09-CE10-SLE-MOV12C0', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'120A GUERNSEY CEN LAUNCHER BV', N'TR3-RM09-CE10-SLE-MOV12C0A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C0B GUERNSEY CEN LAUNCHER KICKER BV', N'TR3-RM09-CE10-SLE-MOV12C0B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'GUERNSEY STA CEN LAUNCHER TRAP', N'TR3-RM09-CE10-SLE-X200', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE10-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-GUERNSEY TO SLATER', N'TR3-RM09-CE10-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-GUERNSEY TO SLATER', N'TR3-RM09-CE10-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STATION', N'TR3-RM09-CE20', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM09-CE20-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STATION SATELLITE DISH', N'TR3-RM09-CE20-SEC-VSAT1211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM09-CE20-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM09-CE20-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM09-CE20-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0003 MOTOR CONTROL CENTER', N'TR3-RM09-CE20-SEG-MCC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER SLATER STA R12C29 (A2)', N'TR3-RM09-CE20-SEG-R12C29', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SWG0001 SWITCHGEAR', N'TR3-RM09-CE20-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA UPS', N'TR3-RM09-CE20-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM09-CE20-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM09-CE20-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MOTOR, DRIVE, BRAKE & CLUTCH"', N'TR3-RM09-CE20-SEM', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 2 VFD', N'TR3-RM09-CE20-SEM-VFD0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM09-CE20-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA CEN UNIT 1 MULTILIN', N'TR3-RM09-CE20-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA CEN UNIT 2 MULTILIN', N'TR3-RM09-CE20-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA UNIT 1 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE20-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA UNIT 2 PRGM LOGIC CONTROLLER', N'TR3-RM09-CE20-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA PLCC PRGM LOGIC CONTROLLER', N'TR3-RM09-CE20-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLAT STATION MAIN PLC', N'TR3-RM09-CE20-SIC-PLCS000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLAT RTU A/B COMMUNCATIONS TO SCADA', N'TR3-RM09-CE20-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE20-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUMP 201 LEVEL', N'TR3-RM09-CE20-SIL-L0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUMP LEAK DETECTION', N'TR3-RM09-CE20-SIL-L0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P001 PRESSURE', N'TR3-RM09-CE20-SIL-P0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P002 PRESSURE', N'TR3-RM09-CE20-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUCTION PRESSURE', N'TR3-RM09-CE20-SIL-P0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA HIGH DISCHARGE PRESSURE', N'TR3-RM09-CE20-SIL-P0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA HIGH DISCHARGE PRESS SWITCH', N'TR3-RM09-CE20-SIL-P0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P001 TEMPERATURE', N'TR3-RM09-CE20-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P002 TEMPERATURE', N'TR3-RM09-CE20-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P001 VIBRATION', N'TR3-RM09-CE20-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA P002 VIBRATION', N'TR3-RM09-CE20-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM09-CE20-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE20-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNITS DISCHARGE VALVE', N'TR3-RM09-CE20-SLE-HV0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 1 SUCTION VALVE', N'TR3-RM09-CE20-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 1 DISCHARGE VALVE', N'TR3-RM09-CE20-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 2 SUCTION VALVE', N'TR3-RM09-CE20-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 2 DISCHARGE VALVE', N'TR3-RM09-CE20-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNITS SUCTION VALVE', N'TR3-RM09-CE20-SLE-MOV0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE20-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-SLATER STATION', N'TR3-RM09-CE20-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-SLATER STATION', N'TR3-RM09-CE20-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FAN,BLOWER & COMPRESSOR"', N'TR3-RM09-CE20-SMF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F0001 SLATER STA UNT 2 VSD LUBE OIL FAN', N'TR3-RM09-CE20-SMF-F0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F0002 SLATER STA UNT 2 VSD LUBE OIL FAN', N'TR3-RM09-CE20-SMF-F0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F0003 SLATER STA UNT 2 VSD LUBE OIL FAN', N'TR3-RM09-CE20-SMF-F0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F0004 SLATER STA UNT 2 VSD LUBE OIL FAN', N'TR3-RM09-CE20-SMF-F0004', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'F0005 SLATER STA UNT 2 VSD LUBE OIL FAN', N'TR3-RM09-CE20-SMF-F0005', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM09-CE20-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 1 PUMP ASSY', N'TR3-RM09-CE20-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML UNIT 2 PUMP ASSY', N'TR3-RM09-CE20-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUMP PUMP', N'TR3-RM09-CE20-SMP-P201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA UNIT 2', N'TR3-RM09-CE20-SMP-P_23_0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM09-CE20-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUCTION STRAINER', N'TR3-RM09-CE20-SPT-S201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA SUMP TANK', N'TR3-RM09-CE20-SPT-TK201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM09-CE20-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA FIRE PROTECTION', N'TR3-RM09-CE20-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM09-CE20-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RV0001 SLATER STA PROTECTS VSD LO', N'TR3-RM09-CE20-SSR-RV0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER TO LITTLE BEAR', N'TR3-RM09-CE30', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE30-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUCTION TEMPERATURE', N'TR3-RM09-CE30-SIL-T0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA ML DWNSTRM TEMP TRANS', N'TR3-RM09-CE30-SIL-T0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE30-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SLATER STA CENT DWNSTRM PIG SIGNAL', N'TR3-RM09-CE30-SIS-ZSX201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE30-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C28_8 SLATER 12 CEN ML CHECK BV', N'TR3-RM09-CE30-SLE-CV12C28_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C39 SEC1 T20N R67W PLATTE CO BV', N'TR3-RM09-CE30-SLE-CV12C39', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C44 SEC16 T19N R66W LARAMIE CO BV', N'TR3-RM09-CE30-SLE-CV12C44', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C29 SEC28 T22N R67W PLATTE CO BV', N'TR3-RM09-CE30-SLE-HV12C29', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C38 SEC35 T21N R67W PLATTE CO BV', N'TR3-RM09-CE30-SLE-HV12C38', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C43 SEC5 T19N R66W LARAMIE CO BV', N'TR3-RM09-CE30-SLE-HV12C43', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C47 SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM09-CE30-SLE-HV12C47', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE30-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-SLATER TO LITTLE BEAR', N'TR3-RM09-CE30-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-SLATER TO LITTLE BEAR', N'TR3-RM09-CE30-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LITTLE BEAR STATION', N'TR3-RM09-CE40', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMUNICATION EQUIPMENT', N'TR3-RM09-CE40-SEC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LITTLE BEAR STATION SATELLITE DISH', N'TR3-RM09-CE40-SEC-VSAT1212', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM09-CE40-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0001 MOTOR CONTROL CENTER', N'TR3-RM09-CE40-SEG-MCC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MCC0002 MOTOR CONTROL CENTER', N'TR3-RM09-CE40-SEG-MCC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SWG0001 SWITCHGEAR', N'TR3-RM09-CE40-SEG-SWG0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'UPS0001 UNINTERRUPTIBLE POWER SUPPLY', N'TR3-RM09-CE40-SEG-UPS0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'XT0001 TRANSFORMER', N'TR3-RM09-CE40-SEG-XT0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HEATING & DRYING EQUIPMENT', N'TR3-RM09-CE40-SEH', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL SYSTEM & STATION', N'TR3-RM09-CE40-SIC', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA HUMAN MACHINE INTERFACE', N'TR3-RM09-CE40-SIC-HMI', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 1 MULTILIN', N'TR3-RM09-CE40-SIC-ML0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 2 MULTILIN', N'TR3-RM09-CE40-SIC-ML0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 3 MULTILIN', N'TR3-RM09-CE40-SIC-ML0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA UNIT 1 PRGM LOGIC CONTROLL', N'TR3-RM09-CE40-SIC-PLC0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA UNIT 2 PRGM LOGIC CONTROLL', N'TR3-RM09-CE40-SIC-PLC0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA UNIT 3 PRGM LOGIC CONTROLL', N'TR3-RM09-CE40-SIC-PLC0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTBR STATION DISCHARGE PRESSURE PLC', N'TR3-RM09-CE40-SIC-PLC000C', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTBR STATION MAIN PLC', N'TR3-RM09-CE40-SIC-PLC000S', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTBR STATION 2 MAIN PLC', N'TR3-RM09-CE40-SIC-PLC000S2', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTBR RTU A/B COMMUNICATIONS TO SCADA', N'TR3-RM09-CE40-SIC-RTU_PLC', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE40-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUMP 201 LEVEL', N'TR3-RM09-CE40-SIL-L0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P001 PRESSURE', N'TR3-RM09-CE40-SIL-P0001', 0, 0, 5, 9991, N'en', 1)


go




GO


INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P002 PRESSURE', N'TR3-RM09-CE40-SIL-P0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P003 PRESSURE', N'TR3-RM09-CE40-SIL-P0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUCTION PRESSURE', N'TR3-RM09-CE40-SIL-P0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA HIGH CASE PRESS TO RTU', N'TR3-RM09-CE40-SIL-P0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA HIGH CASE PRESSURE S/D', N'TR3-RM09-CE40-SIL-P0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA HIGH CASE PRESSURE', N'TR3-RM09-CE40-SIL-P0204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA DISCHARGE PRESSURE', N'TR3-RM09-CE40-SIL-P0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA DISCHARGE PRESSURE SWITCH', N'TR3-RM09-CE40-SIL-P0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P001 TEMPERATURE', N'TR3-RM09-CE40-SIL-T0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P002 TEMPERATURE', N'TR3-RM09-CE40-SIL-T0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P003 TEMPERATURE', N'TR3-RM09-CE40-SIL-T0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P001 VIBRATION', N'TR3-RM09-CE40-SIL-V0001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P002 VIBRATION', N'TR3-RM09-CE40-SIL-V0002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA P003 VIBRATION', N'TR3-RM09-CE40-SIL-V0003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM09-CE40-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM09-CE40-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA DISCHARGE CONTROL VALVE', N'TR3-RM09-CE40-SIV-PCV0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE40-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 1 SUCTION VALVE', N'TR3-RM09-CE40-SLE-MOV0001A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 1 DISCHARGE VALVE', N'TR3-RM09-CE40-SLE-MOV0001B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 2 SUCTION VALVE', N'TR3-RM09-CE40-SLE-MOV0002A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 2 DISCHARGE VALVE', N'TR3-RM09-CE40-SLE-MOV0002B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 3 SUCTION VALVE', N'TR3-RM09-CE40-SLE-MOV0003A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN UNIT 3 DISCHARGE VALVE', N'TR3-RM09-CE40-SLE-MOV0003B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN SUCTION VALVE', N'TR3-RM09-CE40-SLE-MOV0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA CEN DISCHARGE VALVE', N'TR3-RM09-CE40-SLE-MOV0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE40-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-LITTLE BEAR STATION', N'TR3-RM09-CE40-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-LITTLE BEAR STATION', N'TR3-RM09-CE40-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PUMP & MOTOR', N'TR3-RM09-CE40-SMP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA ML P001 PUMP ASSEMBLY', N'TR3-RM09-CE40-SMP-P001', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA ML P002 PUMP ASSEMBLY', N'TR3-RM09-CE40-SMP-P002', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA ML P003 PUMP ASSEMBLY', N'TR3-RM09-CE40-SMP-P003', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUMP PUMP', N'TR3-RM09-CE40-SMP-P201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM09-CE40-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUCTION STRAINER', N'TR3-RM09-CE40-SPT-S201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA SUMP TANK', N'TR3-RM09-CE40-SPT-TK201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'SAFETY, PPE & FIRE PROTECTION"', N'TR3-RM09-CE40-SSF', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA FIRE PROTECTION', N'TR3-RM09-CE40-SSF-FIRE_PROTECTION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LITTLE BEAR TO CHEYENNE', N'TR3-RM09-CE50', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM09-CE50-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER HIGHWAY 85 R12C67.1 (A3)', N'TR3-RM09-CE50-SEG-R12C67_1', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE50-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CEN LINE PRESSURE', N'TR3-RM09-CE50-SIL-P0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CEN RECEIPT TEMPERATURE', N'TR3-RM09-CE50-SIL-T0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA DISCHARGE TEMPERATURE', N'TR3-RM09-CE50-SIL-T0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM09-CE50-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'LTL BEAR STA 12 CENT DWNSTRM PIG SIGNAL', N'TR3-RM09-CE50-SIS-ZSX201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE50-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C47 LITLE BEAR12 CEN ML CHECK BV', N'TR3-RM09-CE50-SLE-CV12C47', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV12C53_6 SEC4 T17N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-CV12C53_6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C48 SEC3 T18N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-HV12C48', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C53 SEC4 T17N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-HV12C53', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C67 SEC15 T15N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-HV12C67', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C77 SEC13 T14N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-HV12C77', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C86 SEC4 T13N R66W LARAMIE CO BV', N'TR3-RM09-CE50-SLE-HV12C86', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C87 CHY 12 CEN RECEIVER BYPASS BV', N'TR3-RM09-CE50-SLE-MOV12C87', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C87A CHY 12 CEN RECEIVER BV', N'TR3-RM09-CE50-SLE-MOV12C87A', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'12C87B CHY 12 CEN RECEIVER OUTLET BV', N'TR3-RM09-CE50-SLE-MOV12C87B', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CEN RECEIVER TRAP', N'TR3-RM09-CE50-SLE-X201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE50-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-LITTLE BEAR TO CHEYENNE', N'TR3-RM09-CE50-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-LITTLE BEAR TO CHEYENNE', N'TR3-RM09-CE50-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE STATION', N'TR3-RM09-CE60', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM09-CE60-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CEN RECEIPT GRAVITY', N'TR3-RM09-CE60-SIL-D0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 PRESSURE', N'TR3-RM09-CE60-SIL-P0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM203 PRESSURE', N'TR3-RM09-CE60-SIL-P0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TO OMNI 1 PRESSURE', N'TR3-RM09-CE60-SIL-P0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN BACK PRESSURE', N'TR3-RM09-CE60-SIL-P0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 TEMPERATURE', N'TR3-RM09-CE60-SIL-T0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM203 TEMPERATURE', N'TR3-RM09-CE60-SIL-T0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TEMPERATURE', N'TR3-RM09-CE60-SIL-T0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM09-CE60-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 DELIVERY TO FRONTIER', N'TR3-RM09-CE60-SIR-FM202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TO FRONTIER DELIVERY METER 3', N'TR3-RM09-CE60-SIR-FM203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 DELIVERY TO TANKAGE', N'TR3-RM09-CE60-SIR-FM205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM09-CE60-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN BACKPRESSURE CONTROL VALVE', N'TR3-RM09-CE60-SIV-PCV0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM09-CE60-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 PROVER SUPPLY VALVE', N'TR3-RM09-CE60-SLE-HV0208', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 PROVER ISOLATION VALVE', N'TR3-RM09-CE60-SLE-HV0209', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 PROVER RETURN VALVE', N'TR3-RM09-CE60-SLE-HV0210', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 PROVER SUPPLY VALVE', N'TR3-RM09-CE60-SLE-HV0211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 PROVER ISOLATION VALVE', N'TR3-RM09-CE60-SLE-HV0212', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 PROVER RETURN VALVE', N'TR3-RM09-CE60-SLE-HV0213', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM203 PROVER SUPPLY VALVE', N'TR3-RM09-CE60-SLE-HV0230', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM203 PROVER ISOLATION VALVE', N'TR3-RM09-CE60-SLE-HV0231', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM203 PROVER RETURN VALVE', N'TR3-RM09-CE60-SLE-HV0232', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA 12 CEN TO METER 5 DEL VALVE', N'TR3-RM09-CE60-SLE-MOV0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN TO FM202 DELIVERY VALVE', N'TR3-RM09-CE60-SLE-MOV0207', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TO TK928 DEL VALVE', N'TR3-RM09-CE60-SLE-MOV0220', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TO TK1156 DEL VALVE', N'TR3-RM09-CE60-SLE-MOV0221', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TO TK1168 DEL VALVE', N'TR3-RM09-CE60-SLE-MOV0222', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM09-CE60-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-CHEYENNE STATION', N'TR3-RM09-CE60-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-CHEYENNE STATION', N'TR3-RM09-CE60-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM09-CE60-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN DELIVERY/FRONTIER STRAINER', N'TR3-RM09-CE60-SPT-S202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA TO FRONTIER DEL METER 3 STRAINER', N'TR3-RM09-CE60-SPT-S203', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN DELIVERY TO TANKAGE STRAINER', N'TR3-RM09-CE60-SPT-S205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM09-CE60-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM205 TO MANIFOLD', N'TR3-RM09-CE60-SSR-PRV0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CEN FM202 TO FRONTIER', N'TR3-RM09-CE60-SSR-PRV0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA FM203 TO FRONTIER MANIFOLD', N'TR3-RM09-CE60-SSR-PRV0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA CENTENNIAL MANIFOLD', N'TR3-RM09-CE60-SSR-PRV0204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHY STA PIPING DISCHARGE TO FRONTIER', N'TR3-RM09-CE60-SSR-PRV0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE 16"" LINE FT TO COMM"', N'TR3-RM6A', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON STATION', N'TR3-RM6A-CY70', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM6A-CY70-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6A-CY70-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6A-CY70-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP UNITS 1 & 2 TO 16 MAINLINE', N'TR3-RM6A-CY70-SLE-MOV0625', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6A-CY70-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON TO ADAMS COUNTY LINE', N'TR3-RM6A-CY75', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6A-CY75-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML DISCHARGE PRESSURE', N'TR3-RM6A-CY75-SIL-P0601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML DISCHARGE TEMPERATURE', N'TR3-RM6A-CY75-SIL-T0604', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM6A-CY75-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON ML 16 LAUNCHER PIG SIGNAL', N'TR3-RM6A-CY75-SIS-ZSX601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP ML 16 LAUNCHER PIG SIGNAL', N'TR3-RM6A-CY75-SIS-ZSX602', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6A-CY75-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV16D150.8 SEC19 T2N R67W WELD CO BV', N'TR3-RM6A-CY75-SLE-CV16D150_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV16D159.4 SEC9 T1N R67W WELD CO BV', N'TR3-RM6A-CY75-SLE-CV16D159_4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'16D150.8 SEC19 T2N R67W WELD CO BV', N'TR3-RM6A-CY75-SLE-HV16D150_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'16D159.4 SEC9 T1N R67W WELD CO BV', N'TR3-RM6A-CY75-SLE-HV16D159_4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML LAUNCHER KICKER BV', N'TR3-RM6A-CY75-SLE-MOV0620', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML LAUNCHER BV', N'TR3-RM6A-CY75-SLE-MOV0621', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML LAUNCHER BYPASS BV', N'TR3-RM6A-CY75-SLE-MOV0622', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 16 ML LAUNCHER TRAP', N'TR3-RM6A-CY75-SLE-X601', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6A-CY75-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-FT. LUPTON TO ADAMS COUNTY', N'TR3-RM6A-CY75-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-FT. LUPTON TO ADAMS COUNTY', N'TR3-RM6A-CY75-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ADAMS COUNTY LINE TO COMMERCE CITY', N'TR3-RM6A-CY80', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM6A-CY80-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6A-CY80-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIPT BACK PRESSURE', N'TR3-RM6A-CY80-SIL-P0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIPT BACK PRESSURE', N'TR3-RM6A-CY80-SIL-T0200', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM6A-CY80-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIVER PIG SIGNAL', N'TR3-RM6A-CY80-SIS-ZSX204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6A-CY80-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV16D167.6 SEC 12 T1S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-CV16D167_6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV16D173.4 SEC 2 T2S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-CV16D173_4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CV16D178.8 SEC 36 T2S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-CV16D178_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HV16D167.6 SEC 12 T1S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-HV16D167_6', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'HV16D173.4 SEC 2 T2S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-HV16D173_4', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'16D178.8 SEC 36 T2S R68W ADAMS CO BV', N'TR3-RM6A-CY80-SLE-HV16D178_8', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIVER BYPASS VALVE', N'TR3-RM6A-CY80-SLE-MOV0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIVER VALVE', N'TR3-RM6A-CY80-SLE-MOV0204', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIVER OUTLET VALVE BV', N'TR3-RM6A-CY80-SLE-MOV0205', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 ML RECEIVER TRAP', N'TR3-RM6A-CY80-SLE-X201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6A-CY80-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-ADAMS COUNTY TO COMMERCE CITY', N'TR3-RM6A-CY80-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-ADAMS COUNTY TO COMM CITY', N'TR3-RM6A-CY80-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM6A-CY80-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIVER BARREL PRESSURE RELIEF', N'TR3-RM6A-CY80-SSR-PSV203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY 16"" RECEIPT/METER MANIFOLD"', N'TR3-RM6A-CY92', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM6A-CY92-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6A-CY92-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 RECEIPT MANIFOLD PRESSURE', N'TR3-RM6A-CY92-SIL-P0203', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER MANIFOLD PRESSURE', N'TR3-RM6A-CY92-SIL-P0206', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER FM201 TEMPERATURE', N'TR3-RM6A-CY92-SIL-T0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER FM202 TEMPERATURE', N'TR3-RM6A-CY92-SIL-T0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM6A-CY92-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM201 RECEIPT METER', N'TR3-RM6A-CY92-SIR-FM201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM202 RECEIPT METER', N'TR3-RM6A-CY92-SIR-FM202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM6A-CY92-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 ML RECEIPT PRESSURE CONTROL VALVE', N'TR3-RM6A-CY92-SIV-PCV0200', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6A-CY92-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 STRAINER S201 U/S ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-HV0209', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 STRAINER S201 D/S ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-HV0210', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 STRAINER S201 BYPASS VALVE', N'TR3-RM6A-CY92-SLE-HV0211', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM201 PROVER ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-HV0213', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM201 PROVER SUPPLY VALVE', N'TR3-RM6A-CY92-SLE-HV0214', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM202 PROVER ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-HV0216', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 FM202 PROVER SUPPLY VALVE', N'TR3-RM6A-CY92-SLE-HV0217', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER FM201 U/S/ ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-MOV0201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 METER FM202 U/S/ ISOLATION VALVE', N'TR3-RM6A-CY92-SLE-MOV0202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6A-CY92-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMM16 RECEIPT/METER MANIFOLD', N'TR3-RM6A-CY92-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMM16 RECEIPT/MTR MANIFOLD', N'TR3-RM6A-CY92-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM6A-CY92-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM16 ML MANIFOLD STRAINER', N'TR3-RM6A-CY92-SPT-S201', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CHEYENNE 10"" LINE FT TO COMM"', N'TR3-RM6B', 0, 0, 2, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON TO COMMERCE CITY', N'TR3-RM6B-CH90', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM6B-CH90-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER FT LUPTON CITY R10D152.5 (M27)', N'TR3-RM6B-CH90-SEG-R10D152_5', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER HENDERSON R10D164 (M28)', N'TR3-RM6B-CH90-SEG-R10D164', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECTIFIER CREAM PUFF R10D170 (M28A)', N'TR3-RM6B-CH90-SEG-R10D170', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6B-CH90-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIPT BACK PRESSURE', N'TR3-RM6B-CH90-SIL-P0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIPT TEMPERATURE', N'TR3-RM6B-CH90-SIL-T0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 10 ML OUTSTATION TEMPERATURE', N'TR3-RM6B-CH90-SIL-T1202', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENTATION SWITCH', N'TR3-RM6B-CH90-SIS', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 10 ML LAUNCHER PIG SIGNAL', N'TR3-RM6B-CH90-SIS-ZSX102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIVER PIG SIGNAL', N'TR3-RM6B-CH90-SIS-ZSX104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6B-CH90-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D151 SEC5 T1N R66W WELD CO BV', N'TR3-RM6B-CH90-SLE-HV10D151', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D159 SEC24 T1S R67W ADAMS CO BV', N'TR3-RM6B-CH90-SLE-HV10D159', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'10D170 SEC6 T3S R67W ADAMS CO BV', N'TR3-RM6B-CH90-SLE-HV10D170', 0, 0, 5, 9991, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIVER BYPASS VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIVER VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0104', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP10 LAUNCHER KICKER VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0104FL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIVER OUTLET VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0105', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP10 LAUNCHER BYPASS VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0105FL', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FTLP10 LAUNCHER VALVE BV', N'TR3-RM6B-CH90-SLE-MOV0106', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 ML RECEIVER TRAP', N'TR3-RM6B-CH90-SLE-X101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'FT LUPTON 10 ML LAUNCHER TRAP', N'TR3-RM6B-CH90-SLE-X102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6B-CH90-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-FT. LUPTON TO COMMERCE CITY', N'TR3-RM6B-CH90-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-FT. LUPTON TO COMMERCE CITY', N'TR3-RM6B-CH90-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RELIEF DEVICE & PRESSURE PROTECTION', N'TR3-RM6B-CH90-SSR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIVER BARREL PRESSURE RELIEF', N'TR3-RM6B-CH90-SSR-PSV103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMMERCE CITY 10"" RECEIPT/METER MANIFOLD"', N'TR3-RM6B-CH92', 0, 0, 3, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'ELECTRICAL SUPPLY & GENERATION', N'TR3-RM6B-CH92-SEG', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'INSTRUMENT LOOP', N'TR3-RM6B-CH92-SIL', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER MANIFOLD PRESSURE', N'TR3-RM6B-CH92-SIL-P0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIPT MANIFOLD PRESSURE', N'TR3-RM6B-CH92-SIL-P0103', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER FM101 TEMPERATURE', N'TR3-RM6B-CH92-SIL-T0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER FM102 TEMPERATURE', N'TR3-RM6B-CH92-SIL-T0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'RECORDER, INDICATOR & ALARM"', N'TR3-RM6B-CH92-SIR', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM101 RECEIPT METER', N'TR3-RM6B-CH92-SIR-FM101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM102 RECEIPT METER', N'TR3-RM6B-CH92-SIR-FM102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'VALVE,CONTROL & ACTUATOR"', N'TR3-RM6B-CH92-SIV', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 RECEIPT PRESSURE CONTROL VALVE', N'TR3-RM6B-CH92-SIV-PCV0100', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPELINE EQUIPMENT', N'TR3-RM6B-CH92-SLE', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 STRAINER S101 U/S ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-HV0109', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 STRAINER S101 D/S ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-HV0110', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 STRAINER S101 BYPASS VALVE', N'TR3-RM6B-CH92-SLE-HV0111', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM101 PROVER ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-HV0113', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM101 PROVER SUPPLY VALVE', N'TR3-RM6B-CH92-SLE-HV0114', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM102 PROVER ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-HV0116', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 FM102 PROVER SUPPLY VALVE', N'TR3-RM6B-CH92-SLE-HV0117', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER FM101 U/S ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-MOV0101', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 METER FM102 U/S ISOLATION VALVE', N'TR3-RM6B-CH92-SLE-MOV0102', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'PIPING CIRCUIT', N'TR3-RM6B-CH92-SLP', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'CONTROL COR CONT-COMM10 RECEIPT/METER MANIFOLD', N'TR3-RM6B-CH92-SLP-CORROSION', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'MAINT MAJOR MAINT-COMM10 RECEIPT/MTR MANIFOLD', N'TR3-RM6B-CH92-SLP-MAJOR', 0, 0, 5, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD"', N'TR3-RM6B-CH92-SPT', 0, 0, 4, 9991, N'en', 1)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (18, N'COMM10 MANIFOLD STRAINER', N'TR3-RM6B-CH92-SPT-S101', 0, 0, 5, 9991, N'en', 1)


--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
go


GO



delete FunctionalLocationOperationalMode from FunctionalLocationOperationalMode fm inner join FunctionalLocation f on fm.UnitId = f.id and f.SiteId = 18
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
			SiteId = 18
			AND Level = 3
			AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
	)



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
				c.SiteId = 18
	)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];

--insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Relève de Quart Quotidien',0
delete SiteConfiguration where siteid = 18
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
18,
7,7,7,7,1,1,1,1,1,1,1,'Operating Engineer Log', -- OperatingEngineerLogDisplayName    
7,7,2,0,30,1,'Jan  1 1900 10:00AM', -- DorCutoffTime
15,30,3, 1,0,1,14, -- DaysToDisplayCokerCards
1,1,1,0,3,3, -- DaysToDisplayShiftHandoversOnPriorityPage
1,0,0,0,1,1,1,1,0, -- ShowAdditionalDetailsOnLogFormByDefault
'en',0,0,0,7,0,0,5,1, -- DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs
0, 0, -- PreShiftPaddingInMinuts, PostShiftPaddingInMinutes
3,null,1,3,0,1, -- DaysToDisplaySAPNotificationsBackwards
1,0,0,null,0,1, -- CollectAnalyticsData
3,null,0,0,0,1, -- MaximumDirectiveFLOCLevel
0,120,0, -- DaysToDisplayEventsBackwards
30,null,30 -- DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage




delete from  BusinessCategoryFLOCAssociation from BusinessCategoryFLOCAssociation bc inner join BusinessCategory b on bc.BusinessCategoryId = b.Id and b.SiteId = 18
delete BusinessCategory where SiteId = 18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Key Performance Indicators','KPIs',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,18

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 18 and f.FullHierarchy = 'TR2' and bc.SiteId = 18 and bc.Deleted = 0

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 18 and f.FullHierarchy = 'TR3' and bc.SiteId = 18 and bc.Deleted = 0

delete WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation wf inner join WorkAssignment w on wf.WorkAssignmentId = w.id and w.SiteId = 18
delete WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup wv inner join WorkAssignment w on wv.WorkAssignmentId = w.id and w.siteid = 18
delete UserLoginHistory from UserLoginHistory u inner join WorkAssignment w on u.AssignmentId = w.id and w.siteid = 18
delete ShiftHandoverConfigurationWorkAssignment from ShiftHandoverConfigurationWorkAssignment s inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid	 = 18
delete ShiftHandoverQuestionnaireFunctionalLocation from ShiftHandoverQuestionnaireFunctionalLocation q inner join FunctionalLocation f on q.FunctionalLocationId = f.id and f.siteid = 18
delete ShiftHandoverQuestionnaireFunctionalLocation from ShiftHandoverQuestionnaireFunctionalLocation q inner join ShiftHandoverQuestionnaire s on q.ShiftHandoverQuestionnaireId = s.id inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid = 18
delete ShiftHandoverAnswer from ShiftHandoverAnswer a inner join ShiftHandoverQuestionnaire q on a.ShiftHandoverQuestionnaireId = q.Id inner join WorkAssignment w on q.WorkAssignmentId = w.id and w.siteid = 18
delete ShiftHandoverQuestionnaireFunctionalLocationList from ShiftHandoverQuestionnaire s inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid = 18 inner join ShiftHandoverQuestionnaireFunctionalLocationList sf on sf.ShiftHandoverQuestionnaireId = s.id
delete ShiftHandoverQuestionnaireSummaryLog from shiftHandoverQuestionnaire s inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid = 18 inner join ShiftHandoverQuestionnaireSummaryLog sf on sf.ShiftHandoverQuestionnaireId = s.id
delete ShiftHandoverQuestionnaire from ShiftHandoverQuestionnaire q inner join WorkAssignment w on q.WorkAssignmentId = w.id and w.SiteId = 18
delete SummaryLogFunctionalLocationList from SummaryLogFunctionalLocationList sl inner join SummaryLog s on sl.SummaryLogId = s.Id inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid = 18
delete SummaryLog from SummaryLog s inner join WorkAssignment w on s.WorkAssignmentId = w.id and w.siteid = 18
delete WorkAssignment from WorkAssignment w inner join role r on w.RoleId = r.Id and r.siteid	= 18
delete RoleElementTemplate from RoleElementTemplate rt inner join Role r on rt.RoleId = r.Id and r.siteid	= 18
delete role where siteid = 18


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Manager', 0, 'manager', 18, 0, 0, 0, 1, 'mgr',0);
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (220,IDENT_CURRENT('ROLE')); 		-- Logs - View Priorities - Log Based Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- summary Logs - View Summary Logs
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,IDENT_CURRENT('ROLE')); 			-- summary Logs - Create Summary Logs
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,IDENT_CURRENT('ROLE')); 			-- summary Logs - Edit Summary Logs
insert into RoleElementTemplate (RoleElementId, RoleId) values (95,IDENT_CURRENT('ROLE')); 			-- summary Logs - Delete Summary Logs
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Create Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Edit Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (117,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Delete Shift Handover, Area Manager


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Administrator', 0, 'administrator', 18, 1, 0, 0, 1, 'admin',0);
-- Operating / Chief Engineer Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View priority - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,IDENT_CURRENT('ROLE')); 			-- Configure Auto Approve SAP Action Item Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,IDENT_CURRENT('ROLE')); 		-- Configure Auto Approve SAP Action Item Definition Configure Business Categories
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,IDENT_CURRENT('ROLE'));			--Associate Business Categories To Functional Locations
insert into RoleElementTemplate (RoleElementId, RoleId) values (113,IDENT_CURRENT('ROLE'));			--Configure Log Guidelines
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,IDENT_CURRENT('ROLE'));			--Configure Summary Log Custom Fields
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE'));			--Edit Log Templates
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,IDENT_CURRENT('ROLE'));  --Configure Plant Historian Tag List
insert into RoleElementTemplate (RoleElementId, RoleId) values (120,IDENT_CURRENT('ROLE'));    --Edit Shift Handover Configurations
insert into RoleElementTemplate (RoleElementId, RoleId) values (206,IDENT_CURRENT('ROLE')); --Edit Shift Handover E-mail Configurations
insert into RoleElementTemplate (RoleElementId, RoleId) values (76,IDENT_CURRENT('ROLE'));   --Configure Display Limits
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,IDENT_CURRENT('ROLE'));     --Configure Work Assignments
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,IDENT_CURRENT('ROLE'));    --Configure Default FLOCs for Assignments
insert into RoleElementTemplate (RoleElementId, RoleId) values (136,IDENT_CURRENT('ROLE'));  --Configure Default Tabs
insert into RoleElementTemplate (RoleElementId, RoleId) values (141,IDENT_CURRENT('ROLE'));   --Configure Work Assignment Not Selected Warning
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,IDENT_CURRENT('ROLE'));  --Configure Unc Paths for Links
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,IDENT_CURRENT('ROLE'));     --Configure Priorities Page
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,IDENT_CURRENT('ROLE'));    --Configure Site Communications




insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Read Only', 0, 'readonly', 18, 0, 1, 0, 1, 'readonly',1);
-- Operator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operator



insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Supervisor', 0, 'supervisor', 18, 0, 0, 0, 1, 'sprvsr',0);
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- View Future Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (220,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,IDENT_CURRENT('ROLE')); 
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,IDENT_CURRENT('ROLE')); 
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,IDENT_CURRENT('ROLE')); 
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,IDENT_CURRENT('ROLE')); 



insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Operator', 0, 'operator', 18, 0, 0, 0, 1, 'oprtr',0);
-- Supervisor Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (220,IDENT_CURRENT('ROLE')); 
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Create Shift Handover Questionnaire, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Edit Shift Handover Questionnaire, Supervisor


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Technical Administrator', 0, 'technicaladmin', 18, 0, 0, 0, 0, 'techadmin',0);
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



-------------------------------- Work Assignments Start --------------------------------------

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Operations/Maintenance Manager',' Operations/Maintenance Manager',18, 0, (select ID from Role where SiteId = 18 and Name='Manager'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Operations Supervisor',' Operations Supervisor',18, 0, (select ID from Role where SiteId = 18 and Name='Supervisor'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Maintenance/ Ops manager',' Maintenance/ Ops manager',18, 0, (select ID from Role where SiteId = 18 and Name='Manager'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Integrity Manager',' Integrity Manager',18, 0, (select ID from Role where SiteId = 18 and Name='Manager'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Engg Manager',' Engg Manager',18, 0, (select ID from Role where SiteId = 18 and Name='Manager'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Operator', ' Operator',18, 0, (select id from Role where SiteId = 18 and Name = 'Operator'), 'Operations', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values ('Technician', ' Technician',18, 0, (select id from Role where SiteId = 18 and Name = 'Operator'), 'Operations', 1, 1, 0, 1);


-------------------------------- Work Assignment Functional Locations Start --------------------------------------

--TR2

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Operations/Maintenance Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Operations Supervisor' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Maintenance/ Ops manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Integrity Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Engg Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Operator' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR2' and a.name = 'Technician' and a.SiteId = 18;



----TR3
insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Operations/Maintenance Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Operations Supervisor' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Maintenance/ Ops manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Integrity Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Engg Manager' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Operator' and a.SiteId = 18;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId])
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 18 and f.fullhierarchy = 'TR3' and a.name = 'Technician' and a.SiteId = 18;

--GO


--SET IDENTITY_INSERT [VisibilityGroup] ON;
delete WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup wv inner join WorkAssignment w on wv.WorkAssignmentId = w.id and w.siteid = 18
delete  VisibilityGroup where siteid = 18

insert into VisibilityGroup ([Name], SiteId, IsSiteDefault, [Deleted])
select 'Operations', 18, 1, 0;



--SET IDENTITY_INSERT [VisibilityGroup] OFF;



-------------------------------- Work Assignment Visibiliy Group Start --------------------------------------

--------------------------------------------------------------------------------
---  Insert Work Assignment Visibility Group for each Work Assignment   ---
--------------------------------------------------------------------------------


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
			wa.SiteId=18 
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
			wa.SiteId=18
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=IDENT_CURRENT('VisibilityGroup') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)



GO






GO

