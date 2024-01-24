
if not exists (select * from Site where site.Id = 14)
begin
INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (14, 'Fort Hills Major Projects', 'Mountain Standard Time', 'MajorProjects');
end
GO

SET IDENTITY_INSERT dbo.Plant ON;

if not exists (select * from dbo.Plant where plant.Id = 999)
begin
INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (999, 'Fort Hills Major Projects', 14)
end
SET IDENTITY_INSERT dbo.Plant OFF;

GO


--- site configuration

INSERT INTO dbo.[Shift] ([Name], [StartTime], [EndTime], [CreatedDateTime], SiteId)
VALUES (
  '24H'  -- Name
  ,'2016-02-02 00:00:00'  -- StartTime
  ,'2016-02-02 23:59:59'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,14  -- SiteId
)

GO

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

GO

insert into TargetDefinitionAutoReApprovalConfiguration
values (14, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

GO
-- ------------------------------------------------------------------------------

--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;
GO

BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'MAJOR PROJECTS', N'MP1', 0, 0, 1, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'VU DELAYED COKER UNIT #3', N'MP1-P205', 0, 0, 2, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BITUMEN PREHEAT', N'MP1-P205-BIT1', 0, 0, 3, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEATER,EXCHANGER & COOLER', N'MP1-P205-BIT1-SPH', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER A', N'MP1-P205-BIT1-SPH-E0100A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER B', N'MP1-P205-BIT1-SPH-E0100B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER C', N'MP1-P205-BIT1-SPH-E0100C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER D', N'MP1-P205-BIT1-SPH-E0100D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER E', N'MP1-P205-BIT1-SPH-E0100E', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT / FEED EXCHANGER F', N'MP1-P205-BIT1-SPH-E0100F', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FIRST AID EQUIPMENT', N'MP1-P205-BIT1-SSA', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SAFETY SHOWER AND EYEWASH', N'MP1-P205-BIT1-SSA-V0506', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COMMON SYSTEMS', N'MP1-P205-COMS', 0, 0, 3, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LUBRICATION', N'MP1-P205-COMS-SML', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LUBE MIST GENERATOR SKID A', N'MP1-P205-COMS-SML-V0503A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LUBE MIST GENERATOR SKID B', N'MP1-P205-COMS-SML-V0503B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PUMP & MOTOR', N'MP1-P205-COMS-SMP', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED HYDROCARBON DRAIN PUMP A', N'MP1-P205-COMS-SMP-G0500A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED HYDROCARBON DRAIN PUMP B', N'MP1-P205-COMS-SMP-G0500B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CONDENSATE PUMP A', N'MP1-P205-COMS-SMP-G0502A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CONDENSATE PUMP B', N'MP1-P205-COMS-SMP-G0502B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BLOWDOWN PUMP A', N'MP1-P205-COMS-SMP-G0503A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BLOWDOWN PUMP B', N'MP1-P205-COMS-SMP-G0503B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEATER,EXCHANGER & COOLER', N'MP1-P205-COMS-SPH', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LP CONDENSATE COOLER', N'MP1-P205-COMS-SPH-E0500', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'INTERMITTENT BLOWDOWN COOLER', N'MP1-P205-COMS-SPH-E0501', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'MP1-P205-COMS-SPT', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LP FLASH DRUM', N'MP1-P205-COMS-SPT-C0500', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'ATMOSPHERIC FLASH DRUM', N'MP1-P205-COMS-SPT-C0501', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CONTINUOUS BLOWDOWN DRUM', N'MP1-P205-COMS-SPT-C0502', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'INTERMITTENT BLOWDOWN DRUM', N'MP1-P205-COMS-SPT-C0503', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'150 PSIG STEAM SEPARATOR', N'MP1-P205-COMS-SPT-C0505', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED HYDROCARBON DRAIN TANK', N'MP1-P205-COMS-SPT-D0500', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED HYDROCARBON DRAIN TANK', N'MP1-P205-COMS-SPT-D0501', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'ACTIVATED CARBON FILTER A', N'MP1-P205-COMS-SPT-T0500A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'ACTIVATED CARBON FILTER B', N'MP1-P205-COMS-SPT-T0500B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'AFTER FILTER A', N'MP1-P205-COMS-SPT-Y0500A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'AFTER FILTER B', N'MP1-P205-COMS-SPT-Y0500B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'AFTER FILTER C', N'MP1-P205-COMS-SPT-Y0500C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'AFTER FILTER D', N'MP1-P205-COMS-SPT-Y0500D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SEAL OIL FLUSH STRAINER', N'MP1-P205-COMS-SPT-Y0501', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DELAYED COKING #3', N'MP1-P205-DCU3', 0, 0, 3, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'STRUCTURE,CONCRETE & STEEL', N'MP1-P205-DCU3-SAS', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE PIT SURGE BASIN', N'MP1-P205-DCU3-SAS-V0310', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN A', N'MP1-P205-DCU3-SAS-V0312A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN B', N'MP1-P205-DCU3-SAS-V0312B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES BASIN RECOVERED OIL PIT', N'MP1-P205-DCU3-SAS-V0314', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PIPELINE EQUIPMENT', N'MP1-P205-DCU3-SLE', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL STRAINER A', N'MP1-P205-DCU3-SLE-Y0300A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL STRAINER B', N'MP1-P205-DCU3-SLE-Y0300B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LUBRICATION', N'MP1-P205-DCU3-SML', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SEAL OIL SKID FOR 205G-328A/B', N'MP1-P205-DCU3-SML-V0100', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEHEADING HYDRAULIC PUMPING SKID', N'MP1-P205-DCU3-SML-V0101', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PUMP & MOTOR', N'MP1-P205-DCU3-SMP', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE CHARGE PUMP A', N'MP1-P205-DCU3-SMP-G0300A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE CHARGE PUMP B', N'MP1-P205-DCU3-SMP-G0300B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE CHARGE PUMP C', N'MP1-P205-DCU3-SMP-G0300C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE CHARGE PUMP D', N'MP1-P205-DCU3-SMP-G0300D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP OIL FLASH DRUM BOTTOM PUMP A', N'MP1-P205-DCU3-SMP-G0303A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP OIL FLASH DRUM BOTTOM PUMP B', N'MP1-P205-DCU3-SMP-G0303B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL RECYCLE PUMP A', N'MP1-P205-DCU3-SMP-G0310A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL RECYCLE PUMP B', N'MP1-P205-DCU3-SMP-G0310B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CONDENSED BLOWDOWN WATER PUMP A', N'MP1-P205-DCU3-SMP-G0314A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CONDENSED BLOWDOWN WATER PUMP B', N'MP1-P205-DCU3-SMP-G0314B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP OIL PUMP A', N'MP1-P205-DCU3-SMP-G0312A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP OIL PUMP B', N'MP1-P205-DCU3-SMP-G0312B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH WATER PUMP A', N'MP1-P205-DCU3-SMP-G0313A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH WATER PUMP B', N'MP1-P205-DCU3-SMP-G0313B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH WATER PUMP C', N'MP1-P205-DCU3-SMP-G0313C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN SUMP PUMP C', N'MP1-P205-DCU3-SMP-G0314C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN SUMP PUMP D', N'MP1-P205-DCU3-SMP-G0314D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DECOKING WATER JET PUMP A', N'MP1-P205-DCU3-SMP-G0315A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DECOKING WATER JET PUMP B', N'MP1-P205-DCU3-SMP-G0315B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE PIT SURGE BASIN WATER SUMP PUMP A', N'MP1-P205-DCU3-SMP-G0316A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE PIT SURGE BASIN WATER SUMP PUMP B', N'MP1-P205-DCU3-SMP-G0316B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE PIT SURGE BASIN WATER SUMP PUMP C', N'MP1-P205-DCU3-SMP-G0316C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN OIL PUMP A', N'MP1-P205-DCU3-SMP-G0317A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN OIL PUMP B', N'MP1-P205-DCU3-SMP-G0317B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE FINES SETTLING BASIN BOOSTER PUMP', N'MP1-P205-DCU3-SMP-G0318', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CUTTING/QUENCH WATER TANK BD PUMP A', N'MP1-P205-DCU3-SMP-G0319A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CUTTING/QUENCH WATER TANK BD PUMP B', N'MP1-P205-DCU3-SMP-G0319B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'VAPOUR LINE QUENCH PUMP A', N'MP1-P205-DCU3-SMP-G0328A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'VAPOUR LINE QUENCH PUMP B', N'MP1-P205-DCU3-SMP-G0328B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP A', N'MP1-P205-DCU3-SMP-G0515A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP B', N'MP1-P205-DCU3-SMP-G0515B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP A', N'MP1-P205-DCU3-SMP-G0516A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP B', N'MP1-P205-DCU3-SMP-G0516B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP A', N'MP1-P205-DCU3-SMP-G0517A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BFW CIRCULATION PUMP B', N'MP1-P205-DCU3-SMP-G0517B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'ANTIFOAM INJECTION SKID', N'MP1-P205-DCU3-SMP-V0510', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEATER,EXCHANGER & COOLER', N'MP1-P205-DCU3-SPH', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SLOPS HEAT EXCHANGER', N'MP1-P205-DCU3-SPH-E0303', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL RECYCLE EXCHANGER A', N'MP1-P205-DCU3-SPH-E0304A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL RECYCLE EXCHANGER B', N'MP1-P205-DCU3-SPH-E0304B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL A', N'MP1-P205-DCU3-SPH-E0305A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL B', N'MP1-P205-DCU3-SPH-E0305B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL C', N'MP1-P205-DCU3-SPH-E0305C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL D', N'MP1-P205-DCU3-SPH-E0305D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL E', N'MP1-P205-DCU3-SPH-E0305E', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL F', N'MP1-P205-DCU3-SPH-E0305F', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL G', N'MP1-P205-DCU3-SPH-E0305G', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL H', N'MP1-P205-DCU3-SPH-E0305H', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL I', N'MP1-P205-DCU3-SPH-E0305I', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL J', N'MP1-P205-DCU3-SPH-E0305J', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL K', N'MP1-P205-DCU3-SPH-E0305K', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL L', N'MP1-P205-DCU3-SPH-E0305L', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL M', N'MP1-P205-DCU3-SPH-E0305M', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL N', N'MP1-P205-DCU3-SPH-E0305N', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL O', N'MP1-P205-DCU3-SPH-E0305O', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH TOWER OVHD FIN FAN CELL P', N'MP1-P205-DCU3-SPH-E0305P', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY SLOP OIL FIN FAN CELL', N'MP1-P205-DCU3-SPH-E0315', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP OIL HEATER', N'MP1-P205-DCU3-SPH-E0317', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE', N'MP1-P205-DCU3-SPH-F0300', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE', N'MP1-P205-DCU3-SPH-F0301', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FURNACE', N'MP1-P205-DCU3-SPH-F0302', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'MP1-P205-DCU3-SPT', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER FEED DRUM', N'MP1-P205-DCU3-SPT-C0300', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE DRUM', N'MP1-P205-DCU3-SPT-C0301', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE DRUM', N'MP1-P205-DCU3-SPT-C0302', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE DRUM', N'MP1-P205-DCU3-SPT-C0303', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE DRUM', N'MP1-P205-DCU3-SPT-C0304', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BLOWDOWN QUENCH TOWER', N'MP1-P205-DCU3-SPT-C0310', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'BLOWDOWN SETTLING DRUM', N'MP1-P205-DCU3-SPT-C0314', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FUEL GAS KO DRUM', N'MP1-P205-DCU3-SPT-C0312', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKE DRUM', N'MP1-P205-DCU3-SPT-C0313', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH OIL SURGE DRUM', N'MP1-P205-DCU3-SPT-C0315', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LIGHT SLOP FLASH DRUM', N'MP1-P205-DCU3-SPT-C0339', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'STEAM DRUM FOR 205F-300', N'MP1-P205-DCU3-SPT-C0515', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'STEAM DRUM FOR 205F-301', N'MP1-P205-DCU3-SPT-C0516', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'STEAM DRUM FOR 205F-302', N'MP1-P205-DCU3-SPT-C0517', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'QUENCH/CUTTING WATER TANK', N'MP1-P205-DCU3-SPT-D0300', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED BLOWDOWN DRUM EJECTOR A', N'MP1-P205-DCU3-SPT-EJ0300A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CLOSED BLOWDOWN DRUM EJECTOR B', N'MP1-P205-DCU3-SPT-EJ0300B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FIRST AID EQUIPMENT', N'MP1-P205-DCU3-SSA', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SAFETY SHOWER AND EYEWASH', N'MP1-P205-DCU3-SSA-V0504', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SAFETY SHOWER AND EYEWASH', N'MP1-P205-DCU3-SSA-V0509', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR #3', N'MP1-P205-FRC3', 0, 0, 3, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PIPELINE EQUIPMENT', N'MP1-P205-FRC3-SLE', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL WASH OIL STRAINER A', N'MP1-P205-FRC3-SLE-Y0301A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL WASH OIL STRAINER B', N'MP1-P205-FRC3-SLE-Y0301B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STRAINER A', N'MP1-P205-FRC3-SLE-Y0302A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STRAINER B', N'MP1-P205-FRC3-SLE-Y0302B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STRAINER C', N'MP1-P205-FRC3-SLE-Y0302C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STRAINER D', N'MP1-P205-FRC3-SLE-Y0302D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FZGO STRAINER A', N'MP1-P205-FRC3-SLE-Y0304A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FZGO STRAINER B', N'MP1-P205-FRC3-SLE-Y0304B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'LUBRICATION', N'MP1-P205-FRC3-SML', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'SEAL OIL SKID FOR 205G-387A/B', N'MP1-P205-FRC3-SML-V0357', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PUMP & MOTOR', N'MP1-P205-FRC3-SMP', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PA PUMP A', N'MP1-P205-FRC3-SMP-G0301A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PA PUMP B', N'MP1-P205-FRC3-SMP-G0301B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PA PUMP C', N'MP1-P205-FRC3-SMP-G0301C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA PUMP A', N'MP1-P205-FRC3-SMP-G0302A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA PUMP B', N'MP1-P205-FRC3-SMP-G0302B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA PUMP C', N'MP1-P205-FRC3-SMP-G0302C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CIRCULATING COKE REMOVAL PUMP', N'MP1-P205-FRC3-SMP-G0304', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'NATURAL RECYCLE/FZGO PA PUMP A', N'MP1-P205-FRC3-SMP-G0305A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'NATURAL RECYCLE/FZGO PA PUMP B', N'MP1-P205-FRC3-SMP-G0305B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'NATURAL RECYCLE/FZGO PA PUMP C', N'MP1-P205-FRC3-SMP-G0305C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT PUMP A', N'MP1-P205-FRC3-SMP-G0306A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT PUMP B', N'MP1-P205-FRC3-SMP-G0306B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PRODUCT PUMP C', N'MP1-P205-FRC3-SMP-G0306C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PRODUCT PUMP A', N'MP1-P205-FRC3-SMP-G0307A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PRODUCT PUMP B', N'MP1-P205-FRC3-SMP-G0307B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PRODUCT PUMP C', N'MP1-P205-FRC3-SMP-G0307C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR REFLUX/PRODUCT PUMP A', N'MP1-P205-FRC3-SMP-G0308A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR REFLUX/PRODUCT PUMP B', N'MP1-P205-FRC3-SMP-G0308B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR REFLUX/PRODUCT PUMP C', N'MP1-P205-FRC3-SMP-G0308C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD WATER PUMP A', N'MP1-P205-FRC3-SMP-G0309A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD WATER PUMP B', N'MP1-P205-FRC3-SMP-G0309B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD WATER PUMP C', N'MP1-P205-FRC3-SMP-G0309C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'MIDDLE REFLUX PUMP A', N'MP1-P205-FRC3-SMP-G0320A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'MIDDLE REFLUX PUMP B', N'MP1-P205-FRC3-SMP-G0320B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'CIRCULATING COKE REMOVAL PUMP', N'MP1-P205-FRC3-SMP-G0334', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY NAPHTHA PUMP A', N'MP1-P205-FRC3-SMP-G0387A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY NAPHTHA PUMP B', N'MP1-P205-FRC3-SMP-G0387B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEATER,EXCHANGER & COOLER', N'MP1-P205-FRC3-SPH', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STEAM GENERATOR', N'MP1-P205-FRC3-SPH-E0300A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL PA STEAM GENERATOR', N'MP1-P205-FRC3-SPH-E0300B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL A', N'MP1-P205-FRC3-SPH-E0302A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL B', N'MP1-P205-FRC3-SPH-E0302B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL C', N'MP1-P205-FRC3-SPH-E0302C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL D', N'MP1-P205-FRC3-SPH-E0302D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL E', N'MP1-P205-FRC3-SPH-E0302E', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL F', N'MP1-P205-FRC3-SPH-E0302F', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL G', N'MP1-P205-FRC3-SPH-E0302G', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL H', N'MP1-P205-FRC3-SPH-E0302H', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL I', N'MP1-P205-FRC3-SPH-E0302I', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL J', N'MP1-P205-FRC3-SPH-E0302J', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL K', N'MP1-P205-FRC3-SPH-E0302K', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL L', N'MP1-P205-FRC3-SPH-E0302L', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL M', N'MP1-P205-FRC3-SPH-E0302M', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL N', N'MP1-P205-FRC3-SPH-E0302N', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL O', N'MP1-P205-FRC3-SPH-E0302O', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD FIN FAN CELL P', N'MP1-P205-FRC3-SPH-E0302P', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FZGO PA STEAM GENERATOR', N'MP1-P205-FRC3-SPH-E0309', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD TRIM CONDENSER', N'MP1-P205-FRC3-SPH-E0310A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD TRIM CONDENSER', N'MP1-P205-FRC3-SPH-E0310B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD TRIM CONDENSER', N'MP1-P205-FRC3-SPH-E0310C', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVHD TRIM CONDENSER', N'MP1-P205-FRC3-SPH-E0310D', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'HEAVY NAPHTHA PRODUCT FIN FAN CELL', N'MP1-P205-FRC3-SPH-E0312', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO PA FIN FAN CELL', N'MP1-P205-FRC3-SPH-E0313', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'MP1-P205-FRC3-SPT', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'COKER MAIN FRACTIONATOR', N'MP1-P205-FRC3-SPT-C0305', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'KERO STRIPPER', N'MP1-P205-FRC3-SPT-C0306', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS OIL STRIPPER', N'MP1-P205-FRC3-SPT-C0307', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR STRAINER POT', N'MP1-P205-FRC3-SPT-C0308', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR OVERHEAD RECEIVER', N'MP1-P205-FRC3-SPT-C0309', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FRACTIONATOR STRAINER POT', N'MP1-P205-FRC3-SPT-C0338', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'GAS RECOVERY UNIT #3', N'MP1-P205-GRU3', 0, 0, 3, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'FAN,BLOWER & COMPRESSOR', N'MP1-P205-GRU3-SMF', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'WET GAS COMPRESSOR A', N'MP1-P205-GRU3-SMF-K0400A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'WET GAS COMPRESSOR B', N'MP1-P205-GRU3-SMF-K0400B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PUMP & MOTOR', N'MP1-P205-GRU3-SMP', 0, 0, 4, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEPROPANIZER FEED PUMP A', N'MP1-P205-GRU3-SMP-G0401A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEPROPANIZER FEED PUMP B', N'MP1-P205-GRU3-SMP-G0401B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PRESATURATOR LIQUID PUMP A', N'MP1-P205-GRU3-SMP-G0402A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'PRESATURATOR LIQUID PUMP B', N'MP1-P205-GRU3-SMP-G0402B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEHEXANIZER BOTTOMS PUMP A', N'MP1-P205-GRU3-SMP-G0403A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEHEXANIZER BOTTOMS PUMP B', N'MP1-P205-GRU3-SMP-G0403B', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEHEXANIZER REFLUX/PRODUCT PUMP A', N'MP1-P205-GRU3-SMP-G0404A', 0, 0, 5, 999, N'en', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (14, N'DEHEXANIZER REFLUX/PRODUCT PUMP B', N'MP1-P205-GRU3-SMP-G0404B', 0, 0, 5, 999, N'en', 2)

COMMIT TRANSACTION




--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
GO

---------------------------------------------------------------------------------------------
DECLARE @SiteId bigint
SET @SiteId = 14
-- ------------------------------------------------------------------------------------

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
		SiteId = @SiteId 
		AND Level = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
COMMIT TRANSACTION


--------------------------------------------------
--  Update Ancestor Table                           ---
--------------------------------------------------
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
   

-- Insert the Ancestor records for these Fort Hills Major Projects Flocs
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
	SELECT 
		c.id, a.id, a.[Level]
		FROM FunctionalLocation a
		INNER JOIN FunctionalLocation c 
			ON c.siteid = a.siteid and 
			c.[Level] > a.[Level] and
			CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
		where
			c.SiteId = @SiteId
)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO

insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Operator Handover Questions',0
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Supervisor Handover Questions',0

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
14,
7,7,7,7,1,1,1,1,1,1,1,'Chief Engineer Log', -- OperatingEngineerLogDisplayName
7,7,2,0,30,1,'Jan  1 1900 10:00AM', -- DorCutoffTime
15,30,3, 1,0,1,14, -- DaysToDisplayCokerCards
1,1,1,0,3,3, -- DaysToDisplayShiftHandoversOnPriorityPage
1,0,0,0,1,1,1,1,0, -- ShowAdditionalDetailsOnLogFormByDefault
'en',0,0,0,3,0,0,5,1, -- DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs
0, 0, -- PreShiftPaddingInMinuts, PostShiftPaddingInMinutes
3,null,1,3,0,1, -- DaysToDisplaySAPNotificationsBackwards
1,0,0,null,0,1, -- CollectAnalyticsData
3,null,0,0,0,1, -- MaximumDirectiveFLOCLevel
0,120,0, -- DaysToDisplayEventsBackwards
30,null,30 -- DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage

GO

insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog)
select 14, 1

GO


insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Key Performance Indicators','KPIs',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,14


insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 14 and f.FullHierarchy = 'MP1' and bc.SiteId = 14 and bc.Deleted = 0
go

-- roles - modeled after Firebag

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (242, 'Administrator', 0, 'Administrator', 14, 1, 0, 0, 1, 'admin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (243, 'Area Manager', 0, 'AreaManager', 14, 0, 0, 0, 1, 'areamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (244, 'Operating / Chief Engineer', 0, 'OperatingEngineer', 14, 0, 0, 0, 1, 'openg',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (245, 'Operator', 0, 'Operator', 14, 0, 0, 0, 1, 'oper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (246, 'Production Engineer', 0, 'ProductionEngineer', 14, 0, 0, 0, 1, 'prodeng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (247, 'Read User', 0, 'ReadUser', 14, 0, 1, 0, 0, 'read', 1);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (248, 'Supervisor', 0, 'Supervisor', 14, 0, 0, 0, 1, 'super',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (249, 'Technical Administrator', 0, 'TechnicalAdmin', 14, 0, 0, 0, 0, 'techadmin',0);

SET IDENTITY_INSERT [Role] OFF;

GO

update Role set WarnIfWorkAssignmentNotSelected = 1 where SiteId = 14 
go  
  
update Role set WarnIfWorkAssignmentNotSelected = 0 where SiteId = 14 and Name in ('Read User', 'Technical Administrator')  
go  

-------------------------------- Role Elements Start --------------------------------------

-- Administrator Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,242); 				-- Action Items - View Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,242); 			-- Action Items - View Action Item, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,242); 		-- Action Items - View Navigation - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,242); 		-- Action Items - View Priorities - Action Items, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,242); 		-- Action Items & Targets - Set Operational Modes, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,242); 		-- Directives - View Navigation - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,242); 		-- Directives - View Directives - Future, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,242); 		-- Directives - View Priorities - Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,242); 		-- Directives - View Directives, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,242); 		-- Events - View Navigation - Events, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,242); 		-- Events - View Priorities - Events, Administrator

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,242); 		-- Forms - View Form, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,242); 		-- Forms - View Navigation - Forms, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,242); 		-- Forms - View Priorities - Document Suggestion, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,242); 		-- Forms - Create Form - Document Suggestion, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,242); 		-- Forms - Edit Form - Document Suggestion, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,242); 		-- Forms - Approve Form - Document Suggestion, Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,242); 		-- Forms - Delete Form - Document Suggestion, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,242); 			-- Logs - View Log, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,242); 		-- Logs - View Navigation - Logs, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,242); 			-- Logs - Notifications - View SAP Notifications, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,242); 			-- Logs - Summary Logs - View Summary Logs, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,242); 		-- Shift Handovers - View Shift Handover, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,242); 		-- Shift Handovers - View Navigation - Shift Handovers, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,242); 		-- Shift Handovers - View Priorities - Shift Handovers, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (77,242); 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,242); 		-- Admin - Action Items - Configure Business Categories, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,242); 		-- Admin - Action Items - Associate Business Categories To Functional Locations, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (113,242); 		-- Admin - Logs - Configure Log Guidelines, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,242); 		-- Admin - Logs - Configure Summary Log Custom Fields, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,242); 		-- Admin - Logs - Edit Log Templates, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (80,242); 			-- Admin - Reports - Configure Plant Historian Tag List, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (120,242); 		-- Admin - Shift Handovers - Edit Shift Handover Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (206,242); 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (76,242); 			-- Admin - Site Configuration - Configure Display Limits, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,242); 			-- Admin - Site Configuration - Configure Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,242); 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (136,242); 		-- Admin - Site Configuration - Configure Default Tabs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (141,242); 		-- Admin - Site Configuration - Configure Work Assignment Not Selected Warning, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,242); 		-- Admin - Site Configuration - Configure Unc Paths for Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,242); 		-- Admin - Site Configuration - Configure Priorities Page, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,242); 		-- Admin - Site Configuration - Configure Site Communications, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (237,242); 		-- Admin - Site Configuration - Configure Functional Locations, Administrator

-- Area Manager Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,243); 				-- Action Items - View Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,243); 			-- Action Items - View Action Item, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,243); 		-- Action Items - View Navigation - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,243); 		-- Action Items - View Priorities - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,243); 				-- Action Items - Approve Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,243); 				-- Action Items - Reject Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,243); 				-- Action Items - Create Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,243); 				-- Action Items - Edit Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,243); 				-- Action Items - Delete Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,243); 			-- Action Items - Comment Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,243); 			-- Action Items - Toggle Approval Required for Action Item Definition, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,243); 		-- Action Items & Targets - Set Operational Modes, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,243); 		-- Directives - View Navigation - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,243); 		-- Directives - View Directives - Future, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,243); 		-- Directives - View Priorities - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,243); 		-- Directives - View Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,243); 		-- Directives - Create Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,243); 		-- Directives - Edit Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,243); 		-- Directives - Delete Directives, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,243); 		-- Events - View Navigation - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,243); 		-- Events - View Priorities - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,243); 		-- Events - Respond to Excursion, Area Manager

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,243); 		-- Forms - View Form, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,243); 		-- Forms - View Navigation - Forms, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,243); 		-- Forms - View Priorities - Document Suggestion, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,243); 		-- Forms - Create Form - Document Suggestion, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,243); 		-- Forms - Edit Form - Document Suggestion, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,243); 		-- Forms - Approve Form - Document Suggestion, Area Manager
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,243); 		-- Forms - Delete Form - Document Suggestion, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,243); 			-- Logs - View Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,243); 			-- Logs - View Log Definitions, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,243); 		-- Logs - View Navigation - Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,243); 			-- Logs - Create Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,243); 			-- Logs - Edit Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,243); 			-- Logs - Delete Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,243); 			-- Logs - Reply To Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,243); 		-- Logs - Cancel Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,243); 		-- Logs - Create Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,243); 		-- Logs - Edit Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,243); 		-- Logs - Copy Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,243); 		-- Logs - Add Shift Information, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,243); 			-- Logs - Notifications - View SAP Notifications, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,243); 			-- Logs - Summary Logs - View Summary Logs, Area Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,243); 		-- Shift Handovers - View Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,243); 		-- Shift Handovers - View Navigation - Shift Handovers, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,243); 		-- Shift Handovers - View Priorities - Shift Handovers, Area Manager

-- Operating / Chief Engineer Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,244); 				-- Action Items - View Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,244); 			-- Action Items - View Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,244); 		-- Action Items - View Navigation - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,244); 		-- Action Items - View Priorities - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,244); 				-- Action Items - Approve Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,244); 				-- Action Items - Reject Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,244); 				-- Action Items - Create Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,244); 				-- Action Items - Edit Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,244); 				-- Action Items - Delete Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,244); 			-- Action Items - Comment Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,244); 			-- Action Items - Toggle Approval Required for Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,244); 			-- Action Items - Respond to Action Item, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,244); 		-- Action Items & Targets - Set Operational Modes, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,244); 		-- Directives - View Navigation - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,244); 		-- Directives - View Directives - Future, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,244); 		-- Directives - View Priorities - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,244); 		-- Directives - View Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,244); 		-- Directives - Create Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,244); 		-- Directives - Edit Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,244); 		-- Directives - Delete Directives, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,244); 		-- Events - View Navigation - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,244); 		-- Events - View Priorities - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,244); 		-- Events - Respond to Excursion, Operating / Chief Engineer

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,244); 		-- Forms - View Form, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,244); 		-- Forms - View Navigation - Forms, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,244); 		-- Forms - View Priorities - Document Suggestion, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,244); 		-- Forms - Create Form - Document Suggestion, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,244); 		-- Forms - Edit Form - Document Suggestion, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,244); 		-- Forms - Approve Form - Document Suggestion, Operating / Chief Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,244); 		-- Forms - Delete Form - Document Suggestion, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,244); 			-- Logs - View Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,244); 			-- Logs - View Log Definitions, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,244); 		-- Logs - View Navigation - Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,244); 			-- Logs - Create Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,244); 			-- Logs - Edit Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,244); 			-- Logs - Delete Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,244); 			-- Logs - Reply To Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (63,244); 			-- Logs - Edit Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (64,244); 			-- Logs - Delete Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (65,244); 			-- Logs - Cancel Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,244); 		-- Logs - Cancel Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,244); 		-- Logs - Create Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,244); 		-- Logs - Edit Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,244); 		-- Logs - Copy Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,244); 		-- Logs - Add Shift Information, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,244); 			-- Logs - Notifications - View SAP Notifications, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,244); 			-- Logs - Notifications - Process SAP Notifications, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,244); 			-- Logs - Summary Logs - View Summary Logs, Operating / Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,244); 		-- Shift Handovers - View Shift Handover, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,244); 		-- Shift Handovers - View Navigation - Shift Handovers, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,244); 		-- Shift Handovers - View Priorities - Shift Handovers, Operating / Chief Engineer

-- Operator Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,245); 				-- Action Items - View Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,245); 			-- Action Items - View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,245); 		-- Action Items - View Navigation - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,245); 		-- Action Items - View Priorities - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,245); 			-- Action Items - Comment Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,245); 			-- Action Items - Respond to Action Item, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,245); 		-- Action Items & Targets - Set Operational Modes, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,245); 		-- Directives - View Navigation - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,245); 		-- Directives - View Directives - Future, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,245); 		-- Directives - View Priorities - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,245); 		-- Directives - View Directives, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,245); 		-- Events - View Navigation - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,245); 		-- Events - View Priorities - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,245); 		-- Events - Respond to Excursion, Operator

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,245); 		-- Forms - View Form, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,245); 		-- Forms - View Navigation - Forms, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,245); 		-- Forms - View Priorities - Document Suggestion, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,245); 		-- Forms - Create Form - Document Suggestion, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,245); 		-- Forms - Edit Form - Document Suggestion, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,245); 		-- Forms - Approve Form - Document Suggestion, Operator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,245); 		-- Forms - Delete Form - Document Suggestion, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,245); 			-- Logs - View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,245); 			-- Logs - View Log Definitions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,245); 		-- Logs - View Navigation - Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,245); 			-- Logs - Create Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,245); 			-- Logs - Edit Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,245); 			-- Logs - Delete Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,245); 			-- Logs - Reply To Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,245); 		-- Logs - Cancel Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,245); 		-- Logs - Create Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,245); 		-- Logs - Edit Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,245); 		-- Logs - Copy Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,245); 		-- Logs - Add Shift Information, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,245); 			-- Logs - Notifications - View SAP Notifications, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,245); 			-- Logs - Notifications - Process SAP Notifications, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,245); 			-- Logs - Summary Logs - View Summary Logs, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,245); 		-- Shift Handovers - View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,245); 		-- Shift Handovers - View Navigation - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,245); 		-- Shift Handovers - View Priorities - Shift Handovers, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (115,245); 		-- Shift Handovers - Create Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,245); 		-- Shift Handovers - Edit Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (117,245); 		-- Shift Handovers - Delete Shift Handover Questionnaire, Operator

-- Production Engineer Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,246); 				-- Action Items - View Action Item Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,246); 			-- Action Items - View Action Item, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,246); 		-- Action Items - View Navigation - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,246); 		-- Action Items - View Priorities - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,246); 			-- Action Items - Comment Action Item Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,246); 			-- Action Items - Respond to Action Item, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,246); 		-- Action Items & Targets - Set Operational Modes, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,246); 		-- Directives - View Navigation - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,246); 		-- Directives - View Directives - Future, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,246); 		-- Directives - View Priorities - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,246); 		-- Directives - View Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,246); 		-- Directives - Create Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,246); 		-- Directives - Edit Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,246); 		-- Directives - Delete Directives, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,246); 		-- Events - View Navigation - Events, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,246); 		-- Events - View Priorities - Events, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,246); 		-- Events - Respond to Excursion, Production Engineer

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,246); 		-- Forms - View Form, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,246); 		-- Forms - View Navigation - Forms, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,246); 		-- Forms - View Priorities - Document Suggestion, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,246); 		-- Forms - Create Form - Document Suggestion, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,246); 		-- Forms - Edit Form - Document Suggestion, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,246); 		-- Forms - Approve Form - Document Suggestion, Production Engineer
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,246); 		-- Forms - Delete Form - Document Suggestion, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,246); 			-- Logs - View Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,246); 			-- Logs - View Log Definitions, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,246); 		-- Logs - View Navigation - Logs, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,246); 			-- Logs - Create Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,246); 			-- Logs - Edit Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,246); 			-- Logs - Delete Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,246); 			-- Logs - Reply To Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,246); 		-- Logs - Cancel Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,246); 		-- Logs - Create Log Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,246); 		-- Logs - Edit Log Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,246); 		-- Logs - Copy Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,246); 		-- Logs - Add Shift Information, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,246); 			-- Logs - Notifications - View SAP Notifications, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,246); 			-- Logs - Notifications - Process SAP Notifications, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,246); 			-- Logs - Summary Logs - View Summary Logs, Production Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,246); 		-- Shift Handovers - View Shift Handover, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,246); 		-- Shift Handovers - View Navigation - Shift Handovers, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,246); 		-- Shift Handovers - View Priorities - Shift Handovers, Production Engineer

-- Read User Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,247); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,247); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,247); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,247); 		-- Action Items - View Priorities - Action Items, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,247); 		-- Action Items & Targets - Set Operational Modes, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,247); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,247); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,247); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,247); 		-- Directives - View Directives, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,247); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,247); 		-- Events - View Priorities - Events, Read User

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,247); 		-- Forms - View Form, Read User
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,247); 		-- Forms - View Navigation - Forms, Read User
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,247); 		-- Forms - View Priorities - Document Suggestion, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,247); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,247); 		-- Logs - View Navigation - Logs, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,247); 			-- Logs - Notifications - View SAP Notifications, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,247); 			-- Logs - Summary Logs - View Summary Logs, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,247); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,247); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,247); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User

-- Supervisor Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,248); 				-- Action Items - View Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,248); 			-- Action Items - View Action Item, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,248); 		-- Action Items - View Navigation - Action Items, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,248); 		-- Action Items - View Priorities - Action Items, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,248); 				-- Action Items - Approve Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,248); 				-- Action Items - Reject Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,248); 				-- Action Items - Create Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,248); 				-- Action Items - Edit Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,248); 				-- Action Items - Delete Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,248); 			-- Action Items - Comment Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,248); 			-- Action Items - Toggle Approval Required for Action Item Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,248); 			-- Action Items - Respond to Action Item, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,248); 		-- Action Items & Targets - Set Operational Modes, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (231,248); 		-- Directives - View Navigation - Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,248); 		-- Directives - View Directives - Future, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,248); 		-- Directives - View Priorities - Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,248); 		-- Directives - View Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,248); 		-- Directives - Create Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,248); 		-- Directives - Edit Directives, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,248); 		-- Directives - Delete Directives, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,248); 		-- Events - View Navigation - Events, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,248); 		-- Events - View Priorities - Events, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,248); 		-- Events - Respond to Excursion, Supervisor

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,248); 		-- Forms - View Form, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,248); 		-- Forms - View Navigation - Forms, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,248); 		-- Forms - View Priorities - Document Suggestion, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,248); 		-- Forms - Create Form - Document Suggestion, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,248); 		-- Forms - Edit Form - Document Suggestion, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,248); 		-- Forms - Approve Form - Document Suggestion, Supervisor
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,248); 		-- Forms - Delete Form - Document Suggestion, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (33,248); 			-- Logs - View Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,248); 			-- Logs - View Log Definitions, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,248); 		-- Logs - View Navigation - Logs, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,248); 			-- Logs - Create Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,248); 			-- Logs - Edit Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,248); 			-- Logs - Delete Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,248); 			-- Logs - Reply To Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,248); 		-- Logs - Cancel Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,248); 		-- Logs - Create Log Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,248); 		-- Logs - Edit Log Definition, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,248); 		-- Logs - Copy Log, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,248); 		-- Logs - Add Shift Information, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (47,248); 			-- Logs - Notifications - View SAP Notifications, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,248); 			-- Logs - Notifications - Process SAP Notifications, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (88,248); 			-- Logs - Summary Logs - View Summary Logs, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,248); 			-- Logs - Summary Logs - Create Summary Logs, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,248); 			-- Logs - Summary Logs - Edit Summary Logs, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (95,248); 			-- Logs - Summary Logs - Delete Summary Logs, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (114,248); 		-- Shift Handovers - View Shift Handover, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,248); 		-- Shift Handovers - View Navigation - Shift Handovers, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,248); 		-- Shift Handovers - View Priorities - Shift Handovers, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,248); 		-- Shift Handovers - Create Shift Handover Questionnaire, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,248); 		-- Shift Handovers - Edit Shift Handover Questionnaire, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (117,248); 		-- Shift Handovers - Delete Shift Handover Questionnaire, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (77,248); 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (73,248); 			-- Admin - Action Items & Targets - Manage Operational Modes, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (84,248); 			-- Admin - Action Items & Targets - Configure Automatic Re-Approval by Field, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (80,248); 			-- Admin - Reports - Configure Plant Historian Tag List, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (120,248); 		-- Admin - Shift Handovers - Edit Shift Handover Configurations, Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (206,248); 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations, Supervisor

insert into RoleElementTemplate (RoleElementId, RoleId) values (85,248); 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments, Supervisor

-- Technical Administrator Role Elements

insert into RoleElementTemplate (RoleElementId, RoleId) values (210,249); 		-- Action Items - View Navigation - Action Items, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (272,249); 		-- Action Items & Targets - Set Operational Modes, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (264,249); 		-- Events - View Navigation - Events, Technical Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,249); 		-- Events - View Priorities - Events, Technical Administrator

--insert into RoleElementTemplate (RoleElementId, RoleId) values (207,249); 		-- Forms - View Form, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (217,249); 		-- Forms - View Navigation - Forms, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (275,249); 		-- Forms - View Priorities - Document Suggestion, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (276,249); 		-- Forms - Create Form - Document Suggestion, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (277,249); 		-- Forms - Edit Form - Document Suggestion, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (278,249); 		-- Forms - Approve Form - Document Suggestion, Technical Administrator
--insert into RoleElementTemplate (RoleElementId, RoleId) values (279,249); 		-- Forms - Delete Form - Document Suggestion, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (212,249); 		-- Logs - View Navigation - Logs, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (214,249); 		-- Shift Handovers - View Navigation - Shift Handovers, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (225,249); 		-- Admin - Site Configuration - Configure Site Communications, Technical Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (202,249); 		-- Technical Admin - Perform Tech Admin Tasks, Technical Administrator

GO

-------------------------------- Work Assignments Start --------------------------------------

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Administrator','Major Projects Administrator',14, 0, 242, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Read Only','Major Projects Read Only',14, 0, 247, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Area Manager','Major Projects Area Manager',14, 0, 243, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Chief Engineer','Major Projects Chief Engineer',14, 0, 244, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Operator','Major Projects Operator',14, 0, 245, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Production Engineer','Major Projects Production Engineer',14, 0, 246, 'General', 1, 1, 0, 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Major Projects Supervisor','Major Projects Supervisor',14, 0, 248, 'General', 1, 1, 0, 1);

GO

-------------------------------- Work Assignment Functional Locations Start --------------------------------------

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Administrator' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Read Only' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Area Manager' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Chief Engineer' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Operator' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Production Engineer' and a.SiteId = 14;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 14 and f.fullhierarchy = 'MP1' and a.name = 'Major Projects Supervisor' and a.SiteId = 14;

GO

-------------------------------- Visibility Group Start --------------------------------------

SET IDENTITY_INSERT [VisibilityGroup] ON;

IF NOT EXISTS(SELECT * FROM VisibilityGroup where Id=21)
BEGIN
	insert into VisibilityGroup ([Id], [Name], SiteId, IsSiteDefault, [Deleted])
  select 21, 'Operations', 14, 1, 0;
END
GO

SET IDENTITY_INSERT [VisibilityGroup] OFF;

GO

-------------------------------- Work Assignment Visibiliy Group Start --------------------------------------

--------------------------------------------------------------------------------
---  Insert Work Assignment Visibility Group for each Work Assignment   ---
--------------------------------------------------------------------------------

BEGIN TRANSACTION
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			21, -- Operations visibility group for Fort Hills Major Projects
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=14
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=21 AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			21, -- Operations visibility group for Fort Hills Major Projects
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=14
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=21 AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)
COMMIT TRANSACTION

GO




GO

