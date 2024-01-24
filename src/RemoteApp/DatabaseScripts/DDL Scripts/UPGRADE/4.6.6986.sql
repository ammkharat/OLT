

INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (11, 'Voyageur', 'Mountain Standard Time', 'Voyageur');

GO

SET IDENTITY_INSERT dbo.Plant ON;
INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (1310, 'Voyageur', 11)
SET IDENTITY_INSERT dbo.Plant OFF;

GO


--- site configuration

INSERT INTO dbo.[Shift] 
VALUES (
  'D'  -- Name
  ,'2011-01-01 07:00'  -- StartTime
  ,'2011-01-01 19:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,11  -- SiteId
)

INSERT INTO dbo.[Shift] 
VALUES (
  'N'  -- Name
  ,'2011-01-01 19:00'  -- StartTime
  ,'2011-01-01 07:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,11   -- SiteId
)

GO

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

GO

insert into TargetDefinitionAutoReApprovalConfiguration
values (11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

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
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UPGRADER 3, VOYAGEUR', N'UP3', 0, 0, 1, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU DELAYED COKER UNIT #3', N'UP3-P205', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BITUMEN PREHEAT', N'UP3-P205-BIT1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P205-BIT1-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER A', N'UP3-P205-BIT1-SPH-E0100A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER B', N'UP3-P205-BIT1-SPH-E0100B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER C', N'UP3-P205-BIT1-SPH-E0100C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER D', N'UP3-P205-BIT1-SPH-E0100D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER E', N'UP3-P205-BIT1-SPH-E0100E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT / FEED EXCHANGER F', N'UP3-P205-BIT1-SPH-E0100F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER A', N'UP3-P205-BIT1-SPH-E0101A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER B', N'UP3-P205-BIT1-SPH-E0101B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER C', N'UP3-P205-BIT1-SPH-E0101C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER D', N'UP3-P205-BIT1-SPH-E0101D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER E', N'UP3-P205-BIT1-SPH-E0101E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER F', N'UP3-P205-BIT1-SPH-E0101F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER G', N'UP3-P205-BIT1-SPH-E0101G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER H', N'UP3-P205-BIT1-SPH-E0101H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PUMPAROUND / FEED EXCHANGER I', N'UP3-P205-BIT1-SPH-E0101I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER A', N'UP3-P205-BIT1-SPH-E0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER B', N'UP3-P205-BIT1-SPH-E0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER C', N'UP3-P205-BIT1-SPH-E0102C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER D', N'UP3-P205-BIT1-SPH-E0102D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER E', N'UP3-P205-BIT1-SPH-E0102E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER F', N'UP3-P205-BIT1-SPH-E0102F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER G', N'UP3-P205-BIT1-SPH-E0102G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER H', N'UP3-P205-BIT1-SPH-E0102H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT / FEED EXCHANGER I', N'UP3-P205-BIT1-SPH-E0102I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER A', N'UP3-P205-BIT1-SPH-E0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER B', N'UP3-P205-BIT1-SPH-E0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER C', N'UP3-P205-BIT1-SPH-E0103C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER D', N'UP3-P205-BIT1-SPH-E0103D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER E', N'UP3-P205-BIT1-SPH-E0103E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER F', N'UP3-P205-BIT1-SPH-E0103F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER G', N'UP3-P205-BIT1-SPH-E0103G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER H', N'UP3-P205-BIT1-SPH-E0103H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER I', N'UP3-P205-BIT1-SPH-E0103I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER J', N'UP3-P205-BIT1-SPH-E0103J', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER K', N'UP3-P205-BIT1-SPH-E0103K', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER L', N'UP3-P205-BIT1-SPH-E0103L', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER M', N'UP3-P205-BIT1-SPH-E0103M', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER N', N'UP3-P205-BIT1-SPH-E0103N', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER O', N'UP3-P205-BIT1-SPH-E0103O', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER P', N'UP3-P205-BIT1-SPH-E0103P', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER Q', N'UP3-P205-BIT1-SPH-E0103Q', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER R', N'UP3-P205-BIT1-SPH-E0103R', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER S', N'UP3-P205-BIT1-SPH-E0103S', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER T', N'UP3-P205-BIT1-SPH-E0103T', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER U', N'UP3-P205-BIT1-SPH-E0103U', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER V', N'UP3-P205-BIT1-SPH-E0103V', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER W', N'UP3-P205-BIT1-SPH-E0103W', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PUMPAROUND / FEED EXCHANGER X', N'UP3-P205-BIT1-SPH-E0103X', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BITUMEN / STEAM EXCHANGER A', N'UP3-P205-BIT1-SPH-E0104A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BITUMEN / STEAM EXCHANGER B', N'UP3-P205-BIT1-SPH-E0104B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P205-BIT1-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER AND EYEWASH', N'UP3-P205-BIT1-SSA-V0506', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMMON SYSTEMS', N'UP3-P205-COMS', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P205-COMS-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE MIST GENERATOR SKID A', N'UP3-P205-COMS-SML-V0503A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE MIST GENERATOR SKID B', N'UP3-P205-COMS-SML-V0503B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P205-COMS-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN PUMP A', N'UP3-P205-COMS-SMP-G0500A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN PUMP B', N'UP3-P205-COMS-SMP-G0500B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE PUMP A', N'UP3-P205-COMS-SMP-G0502A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE PUMP B', N'UP3-P205-COMS-SMP-G0502B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP A', N'UP3-P205-COMS-SMP-G0503A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP B', N'UP3-P205-COMS-SMP-G0503B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P205-COMS-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE COOLER', N'UP3-P205-COMS-SPH-E0500', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BLOWDOWN COOLER', N'UP3-P205-COMS-SPH-E0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P205-COMS-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP FLASH DRUM', N'UP3-P205-COMS-SPT-C0500', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ATMOSPHERIC FLASH DRUM', N'UP3-P205-COMS-SPT-C0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONTINUOUS BLOWDOWN DRUM', N'UP3-P205-COMS-SPT-C0502', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BLOWDOWN DRUM', N'UP3-P205-COMS-SPT-C0503', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'150 PSIG STEAM SEPARATOR', N'UP3-P205-COMS-SPT-C0505', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN TANK', N'UP3-P205-COMS-SPT-D0500', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN TANK', N'UP3-P205-COMS-SPT-D0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACTIVATED CARBON FILTER A', N'UP3-P205-COMS-SPT-T0500A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACTIVATED CARBON FILTER B', N'UP3-P205-COMS-SPT-T0500B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AFTER FILTER A', N'UP3-P205-COMS-SPT-Y0500A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AFTER FILTER B', N'UP3-P205-COMS-SPT-Y0500B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AFTER FILTER C', N'UP3-P205-COMS-SPT-Y0500C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AFTER FILTER D', N'UP3-P205-COMS-SPT-Y0500D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEAL OIL FLUSH STRAINER', N'UP3-P205-COMS-SPT-Y0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DELAYED COKING #3', N'UP3-P205-DCU3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRUCTURE,CONCRETE & STEEL', N'UP3-P205-DCU3-SAS', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE PIT SURGE BASIN', N'UP3-P205-DCU3-SAS-V0310', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN A', N'UP3-P205-DCU3-SAS-V0312A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN B', N'UP3-P205-DCU3-SAS-V0312B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES BASIN RECOVERED OIL PIT', N'UP3-P205-DCU3-SAS-V0314', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPELINE EQUIPMENT', N'UP3-P205-DCU3-SLE', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL STRAINER A', N'UP3-P205-DCU3-SLE-Y0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL STRAINER B', N'UP3-P205-DCU3-SLE-Y0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P205-DCU3-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEAL OIL SKID FOR 205G-328A/B', N'UP3-P205-DCU3-SML-V0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEADING HYDRAULIC PUMPING SKID', N'UP3-P205-DCU3-SML-V0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P205-DCU3-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE CHARGE PUMP A', N'UP3-P205-DCU3-SMP-G0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE CHARGE PUMP B', N'UP3-P205-DCU3-SMP-G0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE CHARGE PUMP C', N'UP3-P205-DCU3-SMP-G0300C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE CHARGE PUMP D', N'UP3-P205-DCU3-SMP-G0300D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP OIL FLASH DRUM BOTTOM PUMP A', N'UP3-P205-DCU3-SMP-G0303A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP OIL FLASH DRUM BOTTOM PUMP B', N'UP3-P205-DCU3-SMP-G0303B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL RECYCLE PUMP A', N'UP3-P205-DCU3-SMP-G0310A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL RECYCLE PUMP B', N'UP3-P205-DCU3-SMP-G0310B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSED BLOWDOWN WATER PUMP A', N'UP3-P205-DCU3-SMP-G0311A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSED BLOWDOWN WATER PUMP B', N'UP3-P205-DCU3-SMP-G0311B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP OIL PUMP A', N'UP3-P205-DCU3-SMP-G0312A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP OIL PUMP B', N'UP3-P205-DCU3-SMP-G0312B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER PUMP A', N'UP3-P205-DCU3-SMP-G0313A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER PUMP B', N'UP3-P205-DCU3-SMP-G0313B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER PUMP C', N'UP3-P205-DCU3-SMP-G0313C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN SUMP PUMP A', N'UP3-P205-DCU3-SMP-G0314A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN SUMP PUMP B', N'UP3-P205-DCU3-SMP-G0314B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN SUMP PUMP C', N'UP3-P205-DCU3-SMP-G0314C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN SUMP PUMP D', N'UP3-P205-DCU3-SMP-G0314D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DECOKING WATER JET PUMP A', N'UP3-P205-DCU3-SMP-G0315A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DECOKING WATER JET PUMP B', N'UP3-P205-DCU3-SMP-G0315B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE PIT SURGE BASIN WATER SUMP PUMP A', N'UP3-P205-DCU3-SMP-G0316A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE PIT SURGE BASIN WATER SUMP PUMP B', N'UP3-P205-DCU3-SMP-G0316B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE PIT SURGE BASIN WATER SUMP PUMP C', N'UP3-P205-DCU3-SMP-G0316C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN OIL PUMP A', N'UP3-P205-DCU3-SMP-G0317A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN OIL PUMP B', N'UP3-P205-DCU3-SMP-G0317B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE FINES SETTLING BASIN BOOSTER PUMP', N'UP3-P205-DCU3-SMP-G0318', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CUTTING/QUENCH WATER TANK BD PUMP A', N'UP3-P205-DCU3-SMP-G0319A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CUTTING/QUENCH WATER TANK BD PUMP B', N'UP3-P205-DCU3-SMP-G0319B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VAPOUR LINE QUENCH PUMP A', N'UP3-P205-DCU3-SMP-G0328A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VAPOUR LINE QUENCH PUMP B', N'UP3-P205-DCU3-SMP-G0328B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP A', N'UP3-P205-DCU3-SMP-G0515A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP B', N'UP3-P205-DCU3-SMP-G0515B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP A', N'UP3-P205-DCU3-SMP-G0516A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP B', N'UP3-P205-DCU3-SMP-G0516B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP A', N'UP3-P205-DCU3-SMP-G0517A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW CIRCULATION PUMP B', N'UP3-P205-DCU3-SMP-G0517B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ANTIFOAM INJECTION SKID', N'UP3-P205-DCU3-SMP-V0510', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P205-DCU3-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOPS HEAT EXCHANGER', N'UP3-P205-DCU3-SPH-E0303', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL RECYCLE EXCHANGER A', N'UP3-P205-DCU3-SPH-E0304A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL RECYCLE EXCHANGER B', N'UP3-P205-DCU3-SPH-E0304B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL A', N'UP3-P205-DCU3-SPH-E0305A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL B', N'UP3-P205-DCU3-SPH-E0305B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL C', N'UP3-P205-DCU3-SPH-E0305C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL D', N'UP3-P205-DCU3-SPH-E0305D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL E', N'UP3-P205-DCU3-SPH-E0305E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL F', N'UP3-P205-DCU3-SPH-E0305F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL G', N'UP3-P205-DCU3-SPH-E0305G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL H', N'UP3-P205-DCU3-SPH-E0305H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL I', N'UP3-P205-DCU3-SPH-E0305I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL J', N'UP3-P205-DCU3-SPH-E0305J', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL K', N'UP3-P205-DCU3-SPH-E0305K', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL L', N'UP3-P205-DCU3-SPH-E0305L', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL M', N'UP3-P205-DCU3-SPH-E0305M', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL N', N'UP3-P205-DCU3-SPH-E0305N', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL O', N'UP3-P205-DCU3-SPH-E0305O', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER OVHD FIN FAN CELL P', N'UP3-P205-DCU3-SPH-E0305P', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY SLOP OIL FIN FAN CELL', N'UP3-P205-DCU3-SPH-E0315', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP OIL HEATER', N'UP3-P205-DCU3-SPH-E0317', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE', N'UP3-P205-DCU3-SPH-F0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE', N'UP3-P205-DCU3-SPH-F0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FURNACE', N'UP3-P205-DCU3-SPH-F0302', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P205-DCU3-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER FEED DRUM', N'UP3-P205-DCU3-SPT-C0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0302', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0303', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN QUENCH TOWER', N'UP3-P205-DCU3-SPT-C0310', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN SETTLING DRUM', N'UP3-P205-DCU3-SPT-C0311', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS KO DRUM', N'UP3-P205-DCU3-SPT-C0312', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0313', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE DRUM', N'UP3-P205-DCU3-SPT-C0314', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH OIL SURGE DRUM', N'UP3-P205-DCU3-SPT-C0315', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LIGHT SLOP FLASH DRUM', N'UP3-P205-DCU3-SPT-C0339', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM FOR 205F-300', N'UP3-P205-DCU3-SPT-C0515', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM FOR 205F-301', N'UP3-P205-DCU3-SPT-C0516', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM FOR 205F-302', N'UP3-P205-DCU3-SPT-C0517', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH/CUTTING WATER TANK', N'UP3-P205-DCU3-SPT-D0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED BLOWDOWN DRUM EJECTOR A', N'UP3-P205-DCU3-SPT-EJ0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED BLOWDOWN DRUM EJECTOR B', N'UP3-P205-DCU3-SPT-EJ0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P205-DCU3-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER AND EYEWASH', N'UP3-P205-DCU3-SSA-V0504', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER AND EYEWASH', N'UP3-P205-DCU3-SSA-V0509', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR #3', N'UP3-P205-FRC3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPELINE EQUIPMENT', N'UP3-P205-FRC3-SLE', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL WASH OIL STRAINER A', N'UP3-P205-FRC3-SLE-Y0301A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL WASH OIL STRAINER B', N'UP3-P205-FRC3-SLE-Y0301B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STRAINER A', N'UP3-P205-FRC3-SLE-Y0302A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STRAINER B', N'UP3-P205-FRC3-SLE-Y0302B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STRAINER C', N'UP3-P205-FRC3-SLE-Y0302C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STRAINER D', N'UP3-P205-FRC3-SLE-Y0302D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FZGO STRAINER A', N'UP3-P205-FRC3-SLE-Y0304A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FZGO STRAINER B', N'UP3-P205-FRC3-SLE-Y0304B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P205-FRC3-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEAL OIL SKID FOR 205G-387A/B', N'UP3-P205-FRC3-SML-V0357', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P205-FRC3-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PA PUMP A', N'UP3-P205-FRC3-SMP-G0301A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PA PUMP B', N'UP3-P205-FRC3-SMP-G0301B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PA PUMP C', N'UP3-P205-FRC3-SMP-G0301C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA PUMP A', N'UP3-P205-FRC3-SMP-G0302A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA PUMP B', N'UP3-P205-FRC3-SMP-G0302B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA PUMP C', N'UP3-P205-FRC3-SMP-G0302C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CIRCULATING COKE REMOVAL PUMP', N'UP3-P205-FRC3-SMP-G0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL RECYCLE/FZGO PA PUMP A', N'UP3-P205-FRC3-SMP-G0305A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL RECYCLE/FZGO PA PUMP B', N'UP3-P205-FRC3-SMP-G0305B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL RECYCLE/FZGO PA PUMP C', N'UP3-P205-FRC3-SMP-G0305C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT PUMP A', N'UP3-P205-FRC3-SMP-G0306A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT PUMP B', N'UP3-P205-FRC3-SMP-G0306B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PRODUCT PUMP C', N'UP3-P205-FRC3-SMP-G0306C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT PUMP A', N'UP3-P205-FRC3-SMP-G0307A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT PUMP B', N'UP3-P205-FRC3-SMP-G0307B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PRODUCT PUMP C', N'UP3-P205-FRC3-SMP-G0307C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR REFLUX/PRODUCT PUMP A', N'UP3-P205-FRC3-SMP-G0308A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR REFLUX/PRODUCT PUMP B', N'UP3-P205-FRC3-SMP-G0308B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR REFLUX/PRODUCT PUMP C', N'UP3-P205-FRC3-SMP-G0308C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD WATER PUMP A', N'UP3-P205-FRC3-SMP-G0309A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD WATER PUMP B', N'UP3-P205-FRC3-SMP-G0309B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD WATER PUMP C', N'UP3-P205-FRC3-SMP-G0309C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MIDDLE REFLUX PUMP A', N'UP3-P205-FRC3-SMP-G0320A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MIDDLE REFLUX PUMP B', N'UP3-P205-FRC3-SMP-G0320B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CIRCULATING COKE REMOVAL PUMP', N'UP3-P205-FRC3-SMP-G0334', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY NAPHTHA PUMP A', N'UP3-P205-FRC3-SMP-G0387A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY NAPHTHA PUMP B', N'UP3-P205-FRC3-SMP-G0387B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P205-FRC3-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STEAM GENERATOR', N'UP3-P205-FRC3-SPH-E0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL PA STEAM GENERATOR', N'UP3-P205-FRC3-SPH-E0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL A', N'UP3-P205-FRC3-SPH-E0302A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL B', N'UP3-P205-FRC3-SPH-E0302B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL C', N'UP3-P205-FRC3-SPH-E0302C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL D', N'UP3-P205-FRC3-SPH-E0302D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL E', N'UP3-P205-FRC3-SPH-E0302E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL F', N'UP3-P205-FRC3-SPH-E0302F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL G', N'UP3-P205-FRC3-SPH-E0302G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL H', N'UP3-P205-FRC3-SPH-E0302H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL I', N'UP3-P205-FRC3-SPH-E0302I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL J', N'UP3-P205-FRC3-SPH-E0302J', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL K', N'UP3-P205-FRC3-SPH-E0302K', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL L', N'UP3-P205-FRC3-SPH-E0302L', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL M', N'UP3-P205-FRC3-SPH-E0302M', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL N', N'UP3-P205-FRC3-SPH-E0302N', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL O', N'UP3-P205-FRC3-SPH-E0302O', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD FIN FAN CELL P', N'UP3-P205-FRC3-SPH-E0302P', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FZGO PA STEAM GENERATOR', N'UP3-P205-FRC3-SPH-E0309', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD TRIM CONDENSER', N'UP3-P205-FRC3-SPH-E0310A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD TRIM CONDENSER', N'UP3-P205-FRC3-SPH-E0310B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD TRIM CONDENSER', N'UP3-P205-FRC3-SPH-E0310C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVHD TRIM CONDENSER', N'UP3-P205-FRC3-SPH-E0310D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEAVY NAPHTHA PRODUCT FIN FAN CELL', N'UP3-P205-FRC3-SPH-E0312', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO PA FIN FAN CELL', N'UP3-P205-FRC3-SPH-E0313', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P205-FRC3-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER MAIN FRACTIONATOR', N'UP3-P205-FRC3-SPT-C0305', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'KERO STRIPPER', N'UP3-P205-FRC3-SPT-C0306', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL STRIPPER', N'UP3-P205-FRC3-SPT-C0307', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR STRAINER POT', N'UP3-P205-FRC3-SPT-C0308', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR OVERHEAD RECEIVER', N'UP3-P205-FRC3-SPT-C0309', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRACTIONATOR STRAINER POT', N'UP3-P205-FRC3-SPT-C0338', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS RECOVERY UNIT #3', N'UP3-P205-GRU3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P205-GRU3-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WET GAS COMPRESSOR A', N'UP3-P205-GRU3-SMF-K0400A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WET GAS COMPRESSOR B', N'UP3-P205-GRU3-SMF-K0400B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P205-GRU3-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER FEED PUMP A', N'UP3-P205-GRU3-SMP-G0401A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER FEED PUMP B', N'UP3-P205-GRU3-SMP-G0401B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRESATURATOR LIQUID PUMP A', N'UP3-P205-GRU3-SMP-G0402A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRESATURATOR LIQUID PUMP B', N'UP3-P205-GRU3-SMP-G0402B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER BOTTOMS PUMP A', N'UP3-P205-GRU3-SMP-G0403A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER BOTTOMS PUMP B', N'UP3-P205-GRU3-SMP-G0403B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER REFLUX/PRODUCT PUMP A', N'UP3-P205-GRU3-SMP-G0404A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER REFLUX/PRODUCT PUMP B', N'UP3-P205-GRU3-SMP-G0404B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P205-GRU3-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMPRESSOR DISCHARGE COOLER', N'UP3-P205-GRU3-SPH-E0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECONTACT COOLER A', N'UP3-P205-GRU3-SPH-E0401A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECONTACT COOLER B', N'UP3-P205-GRU3-SPH-E0401B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER REBOILER', N'UP3-P205-GRU3-SPH-E0402', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER ABSORBER OVHD COOLER A', N'UP3-P205-GRU3-SPH-E0403A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER ABSORBER OVHD COOLER B', N'UP3-P205-GRU3-SPH-E0403B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER REBOILER', N'UP3-P205-GRU3-SPH-E0405', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER OVHD FIN FAN CELL A', N'UP3-P205-GRU3-SPH-E0406A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER OVHD FIN FAN CELL B', N'UP3-P205-GRU3-SPH-E0406B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER OVHD FIN FAN CELL C', N'UP3-P205-GRU3-SPH-E0406C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER OVHD FIN FAN CELL D', N'UP3-P205-GRU3-SPH-E0406D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMEDIATE NAPHTHA FIN FAN CELL', N'UP3-P205-GRU3-SPH-E0407', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN OIL FIN FAN CELL', N'UP3-P205-GRU3-SPH-E0408', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA PRODUCT TRIM COOLER', N'UP3-P205-GRU3-SPH-E0409', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER SIDE REBOILER', N'UP3-P205-GRU3-SPH-E0416', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN/RICH SPONGE OIL EXCHANGER A', N'UP3-P205-GRU3-SPH-E0417A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN/RICH SPONGE OIL EXCHANGER B', N'UP3-P205-GRU3-SPH-E0417B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN SPONGE OIL COOLER', N'UP3-P205-GRU3-SPH-E0418', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MAKE UP DILUENT COOLER A', N'UP3-P205-GRU3-SPH-E0419A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MAKE UP DILUENT COOLER B', N'UP3-P205-GRU3-SPH-E0419B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER SIDE REBOILER', N'UP3-P205-GRU3-SPH-E0422', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P205-GRU3-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMPRESSOR SUCTION DRUM', N'UP3-P205-GRU3-SPT-C0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECONTACT DRUM', N'UP3-P205-GRU3-SPT-C0401', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER ABSORBER', N'UP3-P205-GRU3-SPT-C0402', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SPONGE OIL ABSORBER', N'UP3-P205-GRU3-SPT-C0404', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRESATURATOR WATER DRAWOFF POT', N'UP3-P205-GRU3-SPT-C0405', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER', N'UP3-P205-GRU3-SPT-C0406', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEHEXANIZER REFLUX DRUM', N'UP3-P205-GRU3-SPT-C0407', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER REBOILER CONDENSATE POT', N'UP3-P205-GRU3-SPT-C0518', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEPROPANIZER WATER KO POT', N'UP3-P205-GRU3-SPT-C0520', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU HYDROGEN GENERATION #4', N'UP3-P206', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGEN PRODUCT COMPRESSOR UNIT #4', N'UP3-P206-CMP4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P206-CMP4-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 PRODUCT COMPRESSOR A', N'UP3-P206-CMP4-SMF-K0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 PRODUCT COMPRESSOR B', N'UP3-P206-CMP4-SMF-K0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 PRODUCT COMPRESSOR C', N'UP3-P206-CMP4-SMF-K0103C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P206-CMP4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR JACKET GLYCOL WATER SKID', N'UP3-P206-CMP4-SMP-V0106', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P206-CMP4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 1ST STAGE COOLER CELL A', N'UP3-P206-CMP4-SPH-E0113A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 1ST STAGE COOLER CELL B', N'UP3-P206-CMP4-SPH-E0113B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 1ST STAGE COOLER CELL C', N'UP3-P206-CMP4-SPH-E0113C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 2ND STAGE COOLER CELL A', N'UP3-P206-CMP4-SPH-E0114A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 2ND STAGE COOLER CELL B', N'UP3-P206-CMP4-SPH-E0114B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR 2ND STAGE COOLER CELL C', N'UP3-P206-CMP4-SPH-E0114C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR SPILLBACK FIN FAN CELL', N'UP3-P206-CMP4-SPH-E0115', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P206-CMP4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR A INLET FILTER', N'UP3-P206-CMP4-SPT-C0113A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR B INLET FILTER', N'UP3-P206-CMP4-SPT-C0113B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 COMPRESSOR C INLET FILTER', N'UP3-P206-CMP4-SPT-C0113C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE H2 OIL REMOVAL FILTER A', N'UP3-P206-CMP4-SPT-V0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE H2 OIL REMOVAL FILTER B', N'UP3-P206-CMP4-SPT-V0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DISCHARGE H2 OIL REMOVAL FILTER A', N'UP3-P206-CMP4-SPT-V0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DISCHARGE H2 OIL REMOVAL FILTER B', N'UP3-P206-CMP4-SPT-V0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'IMPORT H2 OIL REMOVAL FILTER', N'UP3-P206-CMP4-SPT-V0110', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMMON SYSTEMS', N'UP3-P206-COMS', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA UNIT #3', N'UP3-P206-PSA3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPELINE EQUIPMENT', N'UP3-P206-PSA3-SLE', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA OFF GAS SILENCER A', N'UP3-P206-PSA3-SLE-VC0114A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA OFF GAS SILENCER B', N'UP3-P206-PSA3-SLE-VC0114B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P206-PSA3-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA OFFGAS DRUM', N'UP3-P206-PSA3-SPT-VC0109', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER A', N'UP3-P206-PSA3-SPT-VC0501A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER B', N'UP3-P206-PSA3-SPT-VC0501B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER C', N'UP3-P206-PSA3-SPT-VC0501C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER D', N'UP3-P206-PSA3-SPT-VC0501D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER E', N'UP3-P206-PSA3-SPT-VC0501E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER F', N'UP3-P206-PSA3-SPT-VC0501F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER G', N'UP3-P206-PSA3-SPT-VC0501G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER H', N'UP3-P206-PSA3-SPT-VC0501H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER I', N'UP3-P206-PSA3-SPT-VC0501I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER J', N'UP3-P206-PSA3-SPT-VC0501J', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER K', N'UP3-P206-PSA3-SPT-VC0501K', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER L', N'UP3-P206-PSA3-SPT-VC0501L', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER M', N'UP3-P206-PSA3-SPT-VC0501M', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PSA ADSORBER N', N'UP3-P206-PSA3-SPT-VC0501N', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED GAS & H2 REFORMER UNIT #4', N'UP3-P206-RFR4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRUCTURE,CONCRETE & STEEL', N'UP3-P206-RFR4-SAS', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 REFORMER FLUE GAS STACK', N'UP3-P206-RFR4-SAS-F0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'H2 PLANT FLARE', N'UP3-P206-RFR4-SAS-F0103', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REFORMER COMBUSTION AIR INLET STACK', N'UP3-P206-RFR4-SAS-Y0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPELINE EQUIPMENT', N'UP3-P206-RFR4-SLE', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM SILENCER', N'UP3-P206-RFR4-SLE-V0712', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P206-RFR4-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FORCED DRAFT (FD) FAN', N'UP3-P206-RFR4-SMF-K0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INDUCED DRAFT (ID) FAN', N'UP3-P206-RFR4-SMF-K0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P206-RFR4-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FD/ID FAN LO SKID', N'UP3-P206-RFR4-SML-V0104', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P206-RFR4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW PUMP A', N'UP3-P206-RFR4-SMP-G0101A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW PUMP B', N'UP3-P206-RFR4-SMP-G0101B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP A', N'UP3-P206-RFR4-SMP-G0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP B', N'UP3-P206-RFR4-SMP-G0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER WATER CIRCULATION PUMP A', N'UP3-P206-RFR4-SMP-G0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER WATER CIRCULATION PUMP B', N'UP3-P206-RFR4-SMP-G0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER WATER CIRCULATION PUMP C', N'UP3-P206-RFR4-SMP-G0103C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICAL INJECTION SKID', N'UP3-P206-RFR4-SMP-V0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P206-RFR4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS STEAM GENERATOR', N'UP3-P206-RFR4-SPH-E0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED PREHEATER', N'UP3-P206-RFR4-SPH-E0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW PREHEATER A', N'UP3-P206-RFR4-SPH-E0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW PREHEATER B', N'UP3-P206-RFR4-SPH-E0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEGASIFIER WATER PREHEATER', N'UP3-P206-RFR4-SPH-E0104', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL A', N'UP3-P206-RFR4-SPH-E0105A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL B', N'UP3-P206-RFR4-SPH-E0105B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL C', N'UP3-P206-RFR4-SPH-E0105C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL D', N'UP3-P206-RFR4-SPH-E0105D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL E', N'UP3-P206-RFR4-SPH-E0105E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL F', N'UP3-P206-RFR4-SPH-E0105F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL G', N'UP3-P206-RFR4-SPH-E0105G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS AIR COOLER CELL H', N'UP3-P206-RFR4-SPH-E0105H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MIXED FEED PREHEATER', N'UP3-P206-RFR4-SPH-E0107', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM SUPERHEATER', N'UP3-P206-RFR4-SPH-E0108', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBUSTION AIR PREHEATER', N'UP3-P206-RFR4-SPH-E0109', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM GENERATION COIL A', N'UP3-P206-RFR4-SPH-E0110A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM GENERATION COIL B', N'UP3-P206-RFR4-SPH-E0110B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN COOLER', N'UP3-P206-RFR4-SPH-E0111', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS TRIM COOLER', N'UP3-P206-RFR4-SPH-E0120', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE VAPORIZER', N'UP3-P206-RFR4-SPH-E0130', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM-HYDROCARBON REFORMER', N'UP3-P206-RFR4-SPH-F0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW START-UP HOT FILL COOLER', N'UP3-P206-RFR4-SPH-VE0104', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P206-RFR4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGENATOR', N'UP3-P206-RFR4-SPT-C0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DESULFURIZER A', N'UP3-P206-RFR4-SPT-C0101A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DESULFURIZER B', N'UP3-P206-RFR4-SPT-C0101B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH TEMPERATURE SHIFT CONVERTER', N'UP3-P206-RFR4-SPT-C0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS CONDENSATE SEPARATOR', N'UP3-P206-RFR4-SPT-C0104', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEGASIFIER', N'UP3-P206-RFR4-SPT-C0105', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM', N'UP3-P206-RFR4-SPT-C0106', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN DRUM', N'UP3-P206-RFR4-SPT-C0107', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM CONDENSATE DRUM', N'UP3-P206-RFR4-SPT-C0115', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE FILTER', N'UP3-P206-RFR4-SPT-Y0130', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU HYDROTREATING-NAPHTHA/DIESEL/GAS OlL', N'UP3-P207', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMMON SYSTEMS', N'UP3-P207-COMS', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P207-COMS-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ATMOSPHERIC CONDENSATE PUMP A', N'UP3-P207-COMS-SMP-G0402A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ATMOSPHERIC CONDENSATE PUMP B', N'UP3-P207-COMS-SMP-G0402B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONTINUOUS BLOWDOWN PUMP A', N'UP3-P207-COMS-SMP-G0403A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONTINUOUS BLOWDOWN PUMP B', N'UP3-P207-COMS-SMP-G0403B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN PUMP', N'UP3-P207-COMS-SMP-G0404', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED AMINE DRAIN PUMP', N'UP3-P207-COMS-SMP-G0405', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASH WATER PUMP A', N'UP3-P207-COMS-SMP-G0453A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASH WATER PUMP B', N'UP3-P207-COMS-SMP-G0453B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP A', N'UP3-P207-COMS-SMP-G0454A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP B', N'UP3-P207-COMS-SMP-G0454B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P207-COMS-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONTINUOUS BLOWDOWN COOLER', N'UP3-P207-COMS-SPH-E0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE COOLER', N'UP3-P207-COMS-SPH-E0401', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P207-COMS-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MP CONDENSATE FLASH DRUM', N'UP3-P207-COMS-SPT-C0402', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ATMOSPHERIC CONDENSATE FLASH DRUM', N'UP3-P207-COMS-SPT-C0403', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONTINUOUS BLOWDOWN DRUM', N'UP3-P207-COMS-SPT-C0404', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED HYDROCARBON DRAIN DRUM', N'UP3-P207-COMS-SPT-C0406', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CLOSED AMINE DRAIN DRUM', N'UP3-P207-COMS-SPT-C0407', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH AMINE FLASH DRUM', N'UP3-P207-COMS-SPT-C0410', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASH WATER BREAK TANK', N'UP3-P207-COMS-SPT-C0453', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DIESEL HYDROTREATERS #2', N'UP3-P207-DHU2', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P207-DHU2-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS COMPRESSOR', N'UP3-P207-DHU2-SMF-K0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P207-DHU2-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LO MIST GENERATOR CONSOLE', N'UP3-P207-DHU2-SML-V0202', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P207-DHU2-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DIESEL CHARGE PUMP', N'UP3-P207-DHU2-SMP-G0200A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DIESEL/GAS OIL CHARGE PUMP', N'UP3-P207-DHU2-SMP-G0200B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM & REBOILER PUMP A', N'UP3-P207-DHU2-SMP-G0201A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM & REBOILER PUMP B', N'UP3-P207-DHU2-SMP-G0201B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM & REBOILER PUMP C', N'UP3-P207-DHU2-SMP-G0201C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD PUMP A', N'UP3-P207-DHU2-SMP-G0203A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD PUMP B', N'UP3-P207-DHU2-SMP-G0203B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD SOUR WATER PUMP', N'UP3-P207-DHU2-SMP-G0208', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM CIRCULATION PUMP A', N'UP3-P207-DHU2-SMP-G0240A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM DRUM CIRCULATION PUMP B', N'UP3-P207-DHU2-SMP-G0240B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICAL INJECTION SKID', N'UP3-P207-DHU2-SMP-V0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P207-DHU2-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER A', N'UP3-P207-DHU2-SPH-E0200A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER B', N'UP3-P207-DHU2-SPH-E0200B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER C', N'UP3-P207-DHU2-SPH-E0200C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER D', N'UP3-P207-DHU2-SPH-E0200D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER E', N'UP3-P207-DHU2-SPH-E0200E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER F', N'UP3-P207-DHU2-SPH-E0200F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER G', N'UP3-P207-DHU2-SPH-E0200G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT COMBINED FEED EXCHANGER H', N'UP3-P207-DHU2-SPH-E0200H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD COMBINED FEED EXCHANGER A', N'UP3-P207-DHU2-SPH-E0201A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD COMBINED FEED EXCHANGER B', N'UP3-P207-DHU2-SPH-E0201B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD COMBINED FEED EXCHANGER C', N'UP3-P207-DHU2-SPH-E0201C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD COMBINED FEED EXCHANGER D', N'UP3-P207-DHU2-SPH-E0201D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EFFLUENT FLASH DRUM EXCHANGER A', N'UP3-P207-DHU2-SPH-E0202A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EFFLUENT FLASH DRUM EXCHANGER B', N'UP3-P207-DHU2-SPH-E0202B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EFFLUENT FLASH DRUM EXCHANGER C', N'UP3-P207-DHU2-SPH-E0202C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EFFLUENT FLASH DRUM EXCHANGER D', N'UP3-P207-DHU2-SPH-E0202D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER KERO/HT DIESEL RD FIN FAN CELL A', N'UP3-P207-DHU2-SPH-E0205A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER KERO/HT DIESEL RD FIN FAN CELL B', N'UP3-P207-DHU2-SPH-E0205B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER KERO/HT DIESEL RD FIN FAN CELL C', N'UP3-P207-DHU2-SPH-E0205C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER KERO/HT DIESEL RD FIN FAN CELL D', N'UP3-P207-DHU2-SPH-E0205D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER KERO/HT DIESEL RD FIN FAN CELL E', N'UP3-P207-DHU2-SPH-E0205E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM 600 PSIG STEAM GENERATOR', N'UP3-P207-DHU2-SPH-E0206', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM 150 PSIG STEAM GENERATOR', N'UP3-P207-DHU2-SPH-E0207', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL A', N'UP3-P207-DHU2-SPH-E0208A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL B', N'UP3-P207-DHU2-SPH-E0208B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL C', N'UP3-P207-DHU2-SPH-E0208C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL D', N'UP3-P207-DHU2-SPH-E0208D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL E', N'UP3-P207-DHU2-SPH-E0208E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL F', N'UP3-P207-DHU2-SPH-E0208F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL G', N'UP3-P207-DHU2-SPH-E0208G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL H', N'UP3-P207-DHU2-SPH-E0208H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD CONDENSER FIN FAN CELL A', N'UP3-P207-DHU2-SPH-E0209A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD CONDENSER FIN FAN CELL B', N'UP3-P207-DHU2-SPH-E0209B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BD COOLER', N'UP3-P207-DHU2-SPH-E0213', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW PREHEATER', N'UP3-P207-DHU2-SPH-E0216', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED HEATER A', N'UP3-P207-DHU2-SPH-F0200A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED HEATER B', N'UP3-P207-DHU2-SPH-F0200B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER REBOILER', N'UP3-P207-DHU2-SPH-F0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P207-DHU2-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR TRAIN A', N'UP3-P207-DHU2-SPT-C0201A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR TRAIN B', N'UP3-P207-DHU2-SPT-C0201B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED SURGE DRUM', N'UP3-P207-DHU2-SPT-C0202', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEPARATOR', N'UP3-P207-DHU2-SPT-C0205', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM', N'UP3-P207-DHU2-SPT-C0206', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS SCRUBBER', N'UP3-P207-DHU2-SPT-C0207', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS COMP KO DRUM', N'UP3-P207-DHU2-SPT-C0208', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER', N'UP3-P207-DHU2-SPT-C0212', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER RECEIVER', N'UP3-P207-DHU2-SPT-C0213', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'700 PSIG STEAM DRUM', N'UP3-P207-DHU2-SPT-C0240', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BD DRUM', N'UP3-P207-DHU2-SPT-C0241', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS COALESCER', N'UP3-P207-DHU2-SPT-C0242', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EJECTOR', N'UP3-P207-DHU2-SPT-EJ0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEEP BED SAND FEED FILTER A', N'UP3-P207-DHU2-SPT-Y0201A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEEP BED SAND FEED FILTER B', N'UP3-P207-DHU2-SPT-Y0201B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P207-DHU2-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER & EYEWASH STATION', N'UP3-P207-DHU2-SSA-V0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL HYDROTREATERS #3', N'UP3-P207-GHU3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P207-GHU3-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS COMPRESSOR', N'UP3-P207-GHU3-SMF-K0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P207-GHU3-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS OIL CHARGE PUMP A', N'UP3-P207-GHU3-SMP-G0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD PUMP A', N'UP3-P207-GHU3-SMP-G0303A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD PUMP B', N'UP3-P207-GHU3-SMP-G0303B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM PUMP A', N'UP3-P207-GHU3-SMP-G0304A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM PUMP B', N'UP3-P207-GHU3-SMP-G0304B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICAL INJECTION SKID', N'UP3-P207-GHU3-SMP-V0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P207-GHU3-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER A', N'UP3-P207-GHU3-SPH-E0301A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER B', N'UP3-P207-GHU3-SPH-E0301B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER C', N'UP3-P207-GHU3-SPH-E0301C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER D', N'UP3-P207-GHU3-SPH-E0301D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER E', N'UP3-P207-GHU3-SPH-E0301E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER F', N'UP3-P207-GHU3-SPH-E0301F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER G', N'UP3-P207-GHU3-SPH-E0301G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER H', N'UP3-P207-GHU3-SPH-E0301H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT STRIPPER FEED EXCHANGER', N'UP3-P207-GHU3-SPH-E0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD STRIPPER FEED EXCHANGER', N'UP3-P207-GHU3-SPH-E0305', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS EXCHANGER A', N'UP3-P207-GHU3-SPH-E0306A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS EXCHANGER B', N'UP3-P207-GHU3-SPH-E0306B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT FLASH 600 PSIG STEAM GENERATOR', N'UP3-P207-GHU3-SPH-E0307', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT FLASH 150 PSIG STEAM GENERATOR', N'UP3-P207-GHU3-SPH-E0308', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM 150 PSIG STEAM GENERATOR', N'UP3-P207-GHU3-SPH-E0309', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER BTM BFW EXCHANGER', N'UP3-P207-GHU3-SPH-E0310', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL A', N'UP3-P207-GHU3-SPH-E0311A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL B', N'UP3-P207-GHU3-SPH-E0311B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL C', N'UP3-P207-GHU3-SPH-E0311C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL D', N'UP3-P207-GHU3-SPH-E0311D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL E', N'UP3-P207-GHU3-SPH-E0311E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL F', N'UP3-P207-GHU3-SPH-E0311F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL G', N'UP3-P207-GHU3-SPH-E0311G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL H', N'UP3-P207-GHU3-SPH-E0311H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT FLASH VAPOUR CONDENSER FIN FAN CELL', N'UP3-P207-GHU3-SPH-E0312', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD CONDENSER FIN FAN CELL A', N'UP3-P207-GHU3-SPH-E0313A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER OVHD CONDENSER FIN FAN CELL B', N'UP3-P207-GHU3-SPH-E0313B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL A', N'UP3-P207-GHU3-SPH-E0314A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL B', N'UP3-P207-GHU3-SPH-E0314B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL C', N'UP3-P207-GHU3-SPH-E0314C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL D', N'UP3-P207-GHU3-SPH-E0314D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL E', N'UP3-P207-GHU3-SPH-E0314E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL F', N'UP3-P207-GHU3-SPH-E0314F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL G', N'UP3-P207-GHU3-SPH-E0314G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER/HT GAS OIL RD FIN FAN CELL H', N'UP3-P207-GHU3-SPH-E0314H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BD COOLER', N'UP3-P207-GHU3-SPH-E0320', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED HEATER A', N'UP3-P207-GHU3-SPH-F0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED HEATER B', N'UP3-P207-GHU3-SPH-F0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P207-GHU3-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR A', N'UP3-P207-GHU3-SPT-C0301A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR B', N'UP3-P207-GHU3-SPT-C0301B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED SURGE DRUM', N'UP3-P207-GHU3-SPT-C0302', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT SEPARATOR', N'UP3-P207-GHU3-SPT-C0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HOT FLASH DRUM', N'UP3-P207-GHU3-SPT-C0305', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD SEPARATOR', N'UP3-P207-GHU3-SPT-C0306', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COLD FLASH DRUM', N'UP3-P207-GHU3-SPT-C0307', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS SCRUBBER', N'UP3-P207-GHU3-SPT-C0308', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS COMPRESSOR KO DRUM', N'UP3-P207-GHU3-SPT-C0309', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER', N'UP3-P207-GHU3-SPT-C0311', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER RECEIVER', N'UP3-P207-GHU3-SPT-C0312', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERMITTENT BD DRUM', N'UP3-P207-GHU3-SPT-C0341', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS COALESCER', N'UP3-P207-GHU3-SPT-C0342', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EJECTOR', N'UP3-P207-GHU3-SPT-EJ0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEEP BED SAND FEED FILTER A', N'UP3-P207-GHU3-SPT-Y0301A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DEEP BED SAND FEED FILTER B', N'UP3-P207-GHU3-SPT-Y0301B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P207-GHU3-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER & EYEWASH STATION', N'UP3-P207-GHU3-SSA-V0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER & EYEWASH STATION', N'UP3-P207-GHU3-SSA-V0303', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA HYDROTREATERS #4', N'UP3-P207-NHU4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPELINE EQUIPMENT', N'UP3-P207-NHU4-SLE', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE WATER STATIC MIXER', N'UP3-P207-NHU4-SLE-Y0103', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P207-NHU4-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS COMPRESSOR', N'UP3-P207-NHU4-SMF-K0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBRICATION', N'UP3-P207-NHU4-SML', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE PUMP SEAL BARRIER FLUID SKID', N'UP3-P207-NHU4-SML-V0112', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P207-NHU4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHARGE PUMP A', N'UP3-P207-NHU4-SMP-G0100A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHARGE PUMP B', N'UP3-P207-NHU4-SMP-G0100B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE PUMP A', N'UP3-P207-NHU4-SMP-G0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE PUMP B', N'UP3-P207-NHU4-SMP-G0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER OVHD PUMP A', N'UP3-P207-NHU4-SMP-G0106A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER OVHD PUMP B', N'UP3-P207-NHU4-SMP-G0106B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER REFLUX PUMP A', N'UP3-P207-NHU4-SMP-G0120A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER REFLUX PUMP B', N'UP3-P207-NHU4-SMP-G0120B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE WATER WASH CIRCULATING PUMP A', N'UP3-P207-NHU4-SMP-G0121A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE WATER WASH CIRCULATING PUMP B', N'UP3-P207-NHU4-SMP-G0121B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP A', N'UP3-P207-NHU4-SMP-G0124A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP B', N'UP3-P207-NHU4-SMP-G0124B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICAL INJECTION SKID', N'UP3-P207-NHU4-SMP-V0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P207-NHU4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR NO. 1 CHARGE HEATER', N'UP3-P207-NHU4-SPH-E0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 1', N'UP3-P207-NHU4-SPH-E0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 2', N'UP3-P207-NHU4-SPH-E0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 3', N'UP3-P207-NHU4-SPH-E0103', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 4A', N'UP3-P207-NHU4-SPH-E0104A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 4B', N'UP3-P207-NHU4-SPH-E0104B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 5', N'UP3-P207-NHU4-SPH-E0105', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMBINED FEED EXCHANGER NO. 6', N'UP3-P207-NHU4-SPH-E0106', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STABILIZER FEED-BTM EXCHANGER A', N'UP3-P207-NHU4-SPH-E0108A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STABILIZER FEED-BTM EXCHANGER B', N'UP3-P207-NHU4-SPH-E0108B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STABILIZER FEED-BTM EXCHANGER C', N'UP3-P207-NHU4-SPH-E0108C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STABILIZER FEED-BTM EXCHANGER D', N'UP3-P207-NHU4-SPH-E0108D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL A', N'UP3-P207-NHU4-SPH-E0110A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL B', N'UP3-P207-NHU4-SPH-E0110B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL C', N'UP3-P207-NHU4-SPH-E0110C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL D', N'UP3-P207-NHU4-SPH-E0110D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL E', N'UP3-P207-NHU4-SPH-E0110E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL F', N'UP3-P207-NHU4-SPH-E0110F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL G', N'UP3-P207-NHU4-SPH-E0110G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PRODUCT CONDENSER FIN FAN CELL H', N'UP3-P207-NHU4-SPH-E0110H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER FIN FAN CELL A', N'UP3-P207-NHU4-SPH-E0111A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER FIN FAN CELL B', N'UP3-P207-NHU4-SPH-E0111B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER REBOILER', N'UP3-P207-NHU4-SPH-E0112', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA PRODUCT FIN FAN CELL COOLER', N'UP3-P207-NHU4-SPH-E0114', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER CONDENSER FIN FAN CELL', N'UP3-P207-NHU4-SPH-E0120', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER REBOILER', N'UP3-P207-NHU4-SPH-E0121', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER FEED-BOTTOMS', N'UP3-P207-NHU4-SPH-E0122', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE VAPORIZER', N'UP3-P207-NHU4-SPH-E0123', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER BTM FIN FAN CELL', N'UP3-P207-NHU4-SPH-E0124', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE PRODUCT COOLER', N'UP3-P207-NHU4-SPH-E0125', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR NO. 2 CHARGE HEATER', N'UP3-P207-NHU4-SPH-F0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P207-NHU4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED SURGE DRUM', N'UP3-P207-NHU4-SPT-C0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR NO. 1', N'UP3-P207-NHU4-SPT-C0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTOR NO. 2', N'UP3-P207-NHU4-SPT-C0103', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEPARATOR', N'UP3-P207-NHU4-SPT-C0105', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RECYCLE GAS SCRUBBER', N'UP3-P207-NHU4-SPT-C0106', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMPRESSOR KO DRUM', N'UP3-P207-NHU4-SPT-C0107', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM', N'UP3-P207-NHU4-SPT-C0108', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER', N'UP3-P207-NHU4-SPT-C0109', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NAPHTHA STABILIZER RECEIVER', N'UP3-P207-NHU4-SPT-C0110', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS COALESCER', N'UP3-P207-NHU4-SPT-C0113', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER', N'UP3-P207-NHU4-SPT-C0120', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE STABILIZER RECEIVER', N'UP3-P207-NHU4-SPT-C0121', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE AMINE CONTACTOR', N'UP3-P207-NHU4-SPT-C0122', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE WATER WASH DRUM', N'UP3-P207-NHU4-SPT-C0123', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EJECTOR', N'UP3-P207-NHU4-SPT-EJ0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED FILTER', N'UP3-P207-NHU4-SPT-Y0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P207-NHU4-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER & EYEWASH STATION', N'UP3-P207-NHU4-SSA-V0102', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU SULPHUR AND AMINE / SOUR WATER', N'UP3-P208', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE RECOVERY UNIT #4', N'UP3-P208-AMN4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-AMN4-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-AMN4-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-AMN4-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-AMN4-SLP-BD_ACID_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE PIPING', N'UP3-P208-AMN4-SLP-BD_AMINE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS PIPING', N'UP3-P208-AMN4-SLP-BD_FUEL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PIPING', N'UP3-P208-AMN4-SLP-BD_LEAN_AMINE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH FUEL GAS PIPING', N'UP3-P208-AMN4-SLP-BD_RICH_FUEL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS PIPING', N'UP3-P208-AMN4-SLP-BD_SOUR_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER MEDIUM PRESSURE PIPING', N'UP3-P208-AMN4-SLP-BFWM_BOILERFEEDWTRMP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-AMN4-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-AMN4-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-AMN4-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICALS PIPING', N'UP3-P208-AMN4-SLP-K_CHEMICALS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-AMN4-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE OIL PIPING', N'UP3-P208-AMN4-SLP-LO_LUBEOIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-AMN4-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-AMN4-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-AMN4-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-AMN4-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-AMN4-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMPED CONDENSATE PIPING', N'UP3-P208-AMN4-SLP-PC_PUMPEDCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS WATER PIPING', N'UP3-P208-AMN4-SLP-PW_PROCESSWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PIPING', N'UP3-P208-AMN4-SLP-P_LEAN_AMINE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'OILY WATER PIPING', N'UP3-P208-AMN4-SLP-P_OILY_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH FUEL GAS PIPING', N'UP3-P208-AMN4-SLP-P_RICH_FUEL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SKIM OIL PIPING', N'UP3-P208-AMN4-SLP-P_SKIM_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL PIPING', N'UP3-P208-AMN4-SLP-P_SLOP_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWEET FLASH GAS PIPING', N'UP3-P208-AMN4-SLP-P_SWEET_FLASH_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS PIPING', N'UP3-P208-AMN4-SLP-SG_SOURGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-AMN4-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-AMN4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASH WATER PUMP', N'UP3-P208-AMN4-SMP-G0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE PUMP', N'UP3-P208-AMN4-SMP-G0202', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH AMINE PUMP A', N'UP3-P208-AMN4-SMP-G0204A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH AMINE PUMP B', N'UP3-P208-AMN4-SMP-G0204B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL PUMP', N'UP3-P208-AMN4-SMP-G0206', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REFLUX PUMP A', N'UP3-P208-AMN4-SMP-G0207A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REFLUX PUMP B', N'UP3-P208-AMN4-SMP-G0207B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP A', N'UP3-P208-AMN4-SMP-G0208A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP B', N'UP3-P208-AMN4-SMP-G0208B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP A', N'UP3-P208-AMN4-SMP-G0209A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP B', N'UP3-P208-AMN4-SMP-G0209B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-AMN4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REBOILER CONDENSATE FIN FAN CELL A', N'UP3-P208-AMN4-SPH-E0200A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REBOILER CONDENSATE FIN FAN CELL B', N'UP3-P208-AMN4-SPH-E0200B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE COOLER', N'UP3-P208-AMN4-SPH-E0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN / RICH EXCHANGER A', N'UP3-P208-AMN4-SPH-E0202A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN / RICH EXCHANGER B', N'UP3-P208-AMN4-SPH-E0202B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN / RICH EXCHANGER C', N'UP3-P208-AMN4-SPH-E0202C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER A', N'UP3-P208-AMN4-SPH-E0203A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER B', N'UP3-P208-AMN4-SPH-E0203B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER C', N'UP3-P208-AMN4-SPH-E0203C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER D', N'UP3-P208-AMN4-SPH-E0203D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL A', N'UP3-P208-AMN4-SPH-E0204A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL B', N'UP3-P208-AMN4-SPH-E0204B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL C', N'UP3-P208-AMN4-SPH-E0204C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL D', N'UP3-P208-AMN4-SPH-E0204D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL E', N'UP3-P208-AMN4-SPH-E0204E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL F', N'UP3-P208-AMN4-SPH-E0204F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL G', N'UP3-P208-AMN4-SPH-E0204G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGEN OVHD FIN FAN CELL H', N'UP3-P208-AMN4-SPH-E0204H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL A', N'UP3-P208-AMN4-SPH-E0205A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL B', N'UP3-P208-AMN4-SPH-E0205B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL C', N'UP3-P208-AMN4-SPH-E0205C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL D', N'UP3-P208-AMN4-SPH-E0205D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL E', N'UP3-P208-AMN4-SPH-E0205E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL F', N'UP3-P208-AMN4-SPH-E0205F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL G', N'UP3-P208-AMN4-SPH-E0205G', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL H', N'UP3-P208-AMN4-SPH-E0205H', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL I', N'UP3-P208-AMN4-SPH-E0205I', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL J', N'UP3-P208-AMN4-SPH-E0205J', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE TRIM COOLER', N'UP3-P208-AMN4-SPH-E0206', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS COOLER', N'UP3-P208-AMN4-SPH-E0210', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DGA RECLAIMER REBOILER', N'UP3-P208-AMN4-SPH-E0216', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-AMN4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS KO DRUM', N'UP3-P208-AMN4-SPT-C0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WATER WASH TOWER', N'UP3-P208-AMN4-SPT-C0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ABSORBER', N'UP3-P208-AMN4-SPT-C0202', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FUEL GAS KO DRUM', N'UP3-P208-AMN4-SPT-C0203', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'THREE PHASE SEPARATOR', N'UP3-P208-AMN4-SPT-C0204', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGENERATOR', N'UP3-P208-AMN4-SPT-C0205', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGENERATOR ACCUMULATOR', N'UP3-P208-AMN4-SPT-C0206', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REBOILER CONDENSATE DRUM', N'UP3-P208-AMN4-SPT-C0207', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DGA SUMP', N'UP3-P208-AMN4-SPT-C0208', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE CARTRIDGE FILTER', N'UP3-P208-AMN4-SPT-T0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACTIVATED CARBON FILTER', N'UP3-P208-AMN4-SPT-T0201', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACTIVATED CARBON AFTER FILTER', N'UP3-P208-AMN4-SPT-T0202', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DGA SUMP FILTER', N'UP3-P208-AMN4-SPT-T0203', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P208-AMN4-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER/EYEWASH', N'UP3-P208-AMN4-SSA-V0200', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COMMON SYSTEMS', N'UP3-P208-COMS', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-COMS-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-COMS-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PURGE PIPING', N'UP3-P208-COMS-SLP-BD_NG_PURGE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PURGE GAS PIPING', N'UP3-P208-COMS-SLP-BD_PURGE_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF PIPING', N'UP3-P208-COMS-SLP-BD_RELIEF', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VENT PIPING', N'UP3-P208-COMS-SLP-BD_VENT', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER HIGH PRESSURE PIPING', N'UP3-P208-COMS-SLP-BFWH_BOILERFEEDWTRHP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER MEDIUM PRESSURE PIPING', N'UP3-P208-COMS-SLP-BFWM_BOILERFEEDWTRMP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-COMS-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRE WATER PIPING', N'UP3-P208-COMS-SLP-FW_FIREWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-COMS-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGEN PIPING', N'UP3-P208-COMS-SLP-H_HYDROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-COMS-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICALS PIPING', N'UP3-P208-COMS-SLP-K_CHEMICALS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-COMS-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-COMS-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-COMS-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-COMS-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-COMS-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-COMS-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMPED CONDENSATE PIPING', N'UP3-P208-COMS-SLP-PC_PUMPEDCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS WATER PIPING', N'UP3-P208-COMS-SLP-PW_PROCESSWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL PIPING', N'UP3-P208-COMS-SLP-P_SLOP_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-COMS-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UTILITY AIR PIPING', N'UP3-P208-COMS-SLP-UA_UTILITYAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UTILITY WATER PIPING', N'UP3-P208-COMS-SLP-UW_UTILITYWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-COMS-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE PUMP A', N'UP3-P208-COMS-SMP-G0501A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDENSATE PUMP B', N'UP3-P208-COMS-SMP-G0501B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP A', N'UP3-P208-COMS-SMP-G0503A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN PUMP B', N'UP3-P208-COMS-SMP-G0503B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CAUSTIC INJECTION SKID', N'UP3-P208-COMS-SMP-V0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PHOSPHATE INJECTION SKID', N'UP3-P208-COMS-SMP-V0502', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-COMS-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MP CONDENSATE COOLER FIN FAN CELL A', N'UP3-P208-COMS-SPH-E0502A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MP CONDENSATE COOLER FIN FAN CELL B', N'UP3-P208-COMS-SPH-E0502B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN COOLER FIN FAN CELL', N'UP3-P208-COMS-SPH-E0503', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-COMS-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER DRAIN DRUM', N'UP3-P208-COMS-SPT-C0103', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MP CONDENSATE FLASH DRUM', N'UP3-P208-COMS-SPT-C0500', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE FLASH DRUM', N'UP3-P208-COMS-SPT-C0501', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN DRUM', N'UP3-P208-COMS-SPT-C0503', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR LOADING AND TANKAGE', N'UP3-P208-SLT2', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SLT2-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SLT2-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SLT2-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIPING', N'UP3-P208-SLT2-SLP-SU_SULPHUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SLT2-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR LOADING PUMP A', N'UP3-P208-SLT2-SMP-G0900A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR LOADING PUMP B', N'UP3-P208-SLT2-SMP-G0900B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SLT2-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR STORAGE TANK', N'UP3-P208-SLT2-SPT-D0900', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UNCLASSIFIED EQUIPMENT', N'UP3-P208-SLT2-SUU', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR LOADING DOCK', N'UP3-P208-SLT2-SUU-V0900', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR RECOVERY UNIT #6', N'UP3-P208-SRU6', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SRU6-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU6-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-SRU6-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU6-SLP-BD_ACID_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU6-SLP-BD_COOLING_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER HIGH PRESSURE PIPING', N'UP3-P208-SRU6-SLP-BFWH_BOILERFEEDWTRHP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER MEDIUM PRESSURE PIPING', N'UP3-P208-SRU6-SLP-BFWM_BOILERFEEDWTRMP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU6-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-SRU6-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-SRU6-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU6-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE OIL PIPING', N'UP3-P208-SRU6-SLP-LO_LUBEOIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SRU6-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU6-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-SRU6-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-SRU6-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SRU6-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS/PLANT AIR PIPING', N'UP3-P208-SRU6-SLP-PA_PROCESSPLANTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP CONDENSATE PIPING', N'UP3-P208-SRU6-SLP-PC_PUMPCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWEEP AIR PIPING', N'UP3-P208-SRU6-SLP-P_SWEEP_AIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWEEP GAS PIPING', N'UP3-P208-SRU6-SLP-P_SWEEP_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TAIL GAS PIPING', N'UP3-P208-SRU6-SLP-P_TAIL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIPING', N'UP3-P208-SRU6-SLP-SU_SULPHUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SRU6-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P208-SRU6-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE AIR BLOWER', N'UP3-P208-SRU6-SMF-K0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SRU6-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWS ACID GAS KO DRUM PUMP', N'UP3-P208-SRU6-SMP-G0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM PUMP', N'UP3-P208-SRU6-SMP-G0302', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-SRU6-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS PREHEATER', N'UP3-P208-SRU6-SPH-E0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASTE HEAT BOILER', N'UP3-P208-SRU6-SPH-E0303', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #1', N'UP3-P208-SRU6-SPH-E0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #1', N'UP3-P208-SRU6-SPH-E0305', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #2', N'UP3-P208-SRU6-SPH-E0306', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #2', N'UP3-P208-SRU6-SPH-E0307', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #3', N'UP3-P208-SRU6-SPH-E0308', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SRU6-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE', N'UP3-P208-SRU6-SPT-C0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #1', N'UP3-P208-SRU6-SPT-C0301', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #2', N'UP3-P208-SRU6-SPT-C0302', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM', N'UP3-P208-SRU6-SPT-C0304', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWS ACID GAS KO DRUM', N'UP3-P208-SRU6-SPT-C0305', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WHB BLOWDOWN DRUM', N'UP3-P208-SRU6-SPT-C0306', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT', N'UP3-P208-SRU6-SPT-D0300', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT STEAM EDUCTOR A', N'UP3-P208-SRU6-SPT-EJ0300A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT STEAM EDUCTOR B', N'UP3-P208-SRU6-SPT-EJ0300B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR RECOVERY UNIT #7', N'UP3-P208-SRU7', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SRU7-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU7-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-SRU7-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU7-SLP-BD_ACID_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU7-SLP-BD_COOLING_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER HIGH PRESSURE PIPING', N'UP3-P208-SRU7-SLP-BFWH_BOILERFEEDWTRHP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER MEDIUM PRESSURE PIPING', N'UP3-P208-SRU7-SLP-BFWM_BOILERFEEDWTRMP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU7-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-SRU7-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-SRU7-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU7-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE OIL PIPING', N'UP3-P208-SRU7-SLP-LO_LUBEOIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SRU7-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU7-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-SRU7-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-SRU7-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SRU7-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS/PLANT AIR PIPING', N'UP3-P208-SRU7-SLP-PA_PROCESSPLANTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWEEP AIR PIPING', N'UP3-P208-SRU7-SLP-P_SWEEP_AIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWEEP GAS PIPING', N'UP3-P208-SRU7-SLP-P_SWEEP_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TAIL GAS PIPING', N'UP3-P208-SRU7-SLP-P_TAIL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIPING', N'UP3-P208-SRU7-SLP-SU_SULPHUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SRU7-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P208-SRU7-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE AIR BLOWER', N'UP3-P208-SRU7-SMF-K0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SRU7-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM PUMP', N'UP3-P208-SRU7-SMP-G0402', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-SRU7-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS PREHEATER', N'UP3-P208-SRU7-SPH-E0401', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASTE HEAT BOILER', N'UP3-P208-SRU7-SPH-E0403', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #1', N'UP3-P208-SRU7-SPH-E0404', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #1', N'UP3-P208-SRU7-SPH-E0405', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #2', N'UP3-P208-SRU7-SPH-E0406', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #2', N'UP3-P208-SRU7-SPH-E0407', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #3', N'UP3-P208-SRU7-SPH-E0408', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SRU7-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE', N'UP3-P208-SRU7-SPT-C0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #1', N'UP3-P208-SRU7-SPT-C0401', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #2', N'UP3-P208-SRU7-SPT-C0402', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM', N'UP3-P208-SRU7-SPT-C0404', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WHB BLOWDOWN DRUM', N'UP3-P208-SRU7-SPT-C0406', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT', N'UP3-P208-SRU7-SPT-D0400', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT STEAM EDUCTOR A', N'UP3-P208-SRU7-SPT-EJ0400A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIT STEAM EDUCTOR B', N'UP3-P208-SRU7-SPT-EJ0400B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR RECOVERY #8', N'UP3-P208-SRU8', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SRU8-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU8-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-SRU8-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-SRU8-SLP-BD_ACID_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU8-SLP-BD_COOLING_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER HIGH PRESSURE PIPING', N'UP3-P208-SRU8-SLP-BFWH_BOILERFEEDWTRHP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BOILER FEED WATER MEDIUM PRESSURE PIPING', N'UP3-P208-SRU8-SLP-BFWM_BOILERFEEDWTRMP', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SRU8-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-SRU8-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-SRU8-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU8-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LUBE OIL PIPING', N'UP3-P208-SRU8-SLP-LO_LUBEOIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SRU8-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-SRU8-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-SRU8-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-SRU8-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SRU8-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS/PLANT AIR PIPING', N'UP3-P208-SRU8-SLP-PA_PROCESSPLANTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TAIL GAS PIPING', N'UP3-P208-SRU8-SLP-P_TAIL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR PIPING', N'UP3-P208-SRU8-SLP-SU_SULPHUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SRU8-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FAN,BLOWER & COMPRESSOR', N'UP3-P208-SRU8-SMF', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE AIR BLOWER', N'UP3-P208-SRU8-SMF-K0800', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SRU8-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM PUMP', N'UP3-P208-SRU8-SMP-G0802', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-SRU8-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS PREHEATER', N'UP3-P208-SRU8-SPH-E0801', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASTE HEAT BOILER', N'UP3-P208-SRU8-SPH-E0803', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #1', N'UP3-P208-SRU8-SPH-E0804', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #1', N'UP3-P208-SRU8-SPH-E0805', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #2', N'UP3-P208-SRU8-SPH-E0806', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REHEAT EXCHANGER #2', N'UP3-P208-SRU8-SPH-E0807', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR CONDENSER #3', N'UP3-P208-SRU8-SPH-E0808', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SRU8-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REACTION FURNACE', N'UP3-P208-SRU8-SPT-C0800', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #1', N'UP3-P208-SRU8-SPT-C0801', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CATALYTIC REACTOR #2', N'UP3-P208-SRU8-SPT-C0802', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ACID GAS KO DRUM', N'UP3-P208-SRU8-SPT-C0804', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WHB BLOWDOWN DRUM', N'UP3-P208-SRU8-SPT-C0806', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER STRIPPER #4', N'UP3-P208-SWS4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SWS4-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER ACID GAS PIPING', N'UP3-P208-SWS4-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SWS4-SLP-BD_LP_STEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SWS4-SLP-BD_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS PIPING', N'UP3-P208-SWS4-SLP-BD_SOUR_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR VAPOUR PIPING', N'UP3-P208-SWS4-SLP-BD_SOUR_VAPOUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER VAPOUR PIPING', N'UP3-P208-SWS4-SLP-BD_SW_VAPOUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SWS4-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-SWS4-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SWS4-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SWS4-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-SWS4-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-SWS4-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-SWS4-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SWS4-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMPED CONDENSATE PIPING', N'UP3-P208-SWS4-SLP-PC_PUMPEDCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS WATER PIPING', N'UP3-P208-SWS4-SLP-PW_PROCESSWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER GAS OIL PIPING', N'UP3-P208-SWS4-SLP-P_COKER_GAS_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL PIPING', N'UP3-P208-SWS4-SLP-P_SLOP_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SWS4-SLP-P_SOUR_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS PIPING', N'UP3-P208-SWS4-SLP-SG_SOURGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SWS4-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SWS4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SOUR WATER PUMP A', N'UP3-P208-SWS4-SMP-G0100A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SOUR WATER PUMP B', N'UP3-P208-SWS4-SMP-G0100B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FEED PUMP A', N'UP3-P208-SWS4-SMP-G0101A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FEED PUMP B', N'UP3-P208-SWS4-SMP-G0101B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER PUMP A', N'UP3-P208-SWS4-SMP-G0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER PUMP B', N'UP3-P208-SWS4-SMP-G0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND PUMP A', N'UP3-P208-SWS4-SMP-G0104A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND PUMP B', N'UP3-P208-SWS4-SMP-G0104B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SLOP OIL PUMP', N'UP3-P208-SWS4-SMP-G0105', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED PREPARATION TANK SLOP OIL PUMP', N'UP3-P208-SWS4-SMP-G0106', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-SWS4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED BOTTOMS EXCHANGER', N'UP3-P208-SWS4-SPH-E0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER REBOILER', N'UP3-P208-SWS4-SPH-E0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL A', N'UP3-P208-SWS4-SPH-E0102A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL B', N'UP3-P208-SWS4-SPH-E0102B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL C', N'UP3-P208-SWS4-SPH-E0102C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL D', N'UP3-P208-SWS4-SPH-E0102D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL A', N'UP3-P208-SWS4-SPH-E0103A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL B', N'UP3-P208-SWS4-SPH-E0103B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL C', N'UP3-P208-SWS4-SPH-E0103C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL D', N'UP3-P208-SWS4-SPH-E0103D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SWS4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FLASH DRUM', N'UP3-P208-SWS4-SPT-C0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER', N'UP3-P208-SWS4-SPT-C0101', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED PREPARATION TANK', N'UP3-P208-SWS4-SPT-D0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH GAS EDUCTOR', N'UP3-P208-SWS4-SPT-EJ0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROCYCLONE', N'UP3-P208-SWS4-SPT-V0100', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER STRIPPER #5', N'UP3-P208-SWS5', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-SWS5-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER ACID GAS PIPING', N'UP3-P208-SWS5-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SWS5-SLP-BD_LP_STEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SWS5-SLP-BD_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR VAPOUR PIPING', N'UP3-P208-SWS5-SLP-BD_SOUR_VAPOUR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FLASH GAS PIPING', N'UP3-P208-SWS5-SLP-BD_SW_FLASH_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-SWS5-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-SWS5-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-SWS5-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-SWS5-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-SWS5-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-SWS5-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-SWS5-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-SWS5-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMPED CONDENSATE PIPING', N'UP3-P208-SWS5-SLP-PC_PUMPEDCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS WATER PIPING', N'UP3-P208-SWS5-SLP-PW_PROCESSWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKER GAS OIL PIPING', N'UP3-P208-SWS5-SLP-P_COKER_GAS_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL PIPING', N'UP3-P208-SWS5-SLP-P_SLOP_OIL', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SWS5-SLP-P_SOUR_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR GAS PIPING', N'UP3-P208-SWS5-SLP-SG_SOURGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-SWS5-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-SWS5-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SOUR WATER PUMP A', N'UP3-P208-SWS5-SMP-G0700A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SOUR WATER PUMP B', N'UP3-P208-SWS5-SMP-G0700B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FEED PUMP A', N'UP3-P208-SWS5-SMP-G0701A', 0, 0, 5, 1310, N'en')
COMMIT TRANSACTION
GO
BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FEED PUMP B', N'UP3-P208-SWS5-SMP-G0701B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER PUMP A', N'UP3-P208-SWS5-SMP-G0702A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER PUMP B', N'UP3-P208-SWS5-SMP-G0702B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND PUMP A', N'UP3-P208-SWS5-SMP-G0704A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND PUMP B', N'UP3-P208-SWS5-SMP-G0704B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH DRUM SLOP OIL PUMP', N'UP3-P208-SWS5-SMP-G0705', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED PREPARATION TANK SLOP OIL PUMP', N'UP3-P208-SWS5-SMP-G0706', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-SWS5-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED/BOTTOMS EXCHANGER', N'UP3-P208-SWS5-SPH-E0700', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER REBOILER', N'UP3-P208-SWS5-SPH-E0701', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL A', N'UP3-P208-SWS5-SPH-E0702A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL B', N'UP3-P208-SWS5-SPH-E0702B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL C', N'UP3-P208-SWS5-SPH-E0702C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER PUMPAROUND FIN FAN CELL D', N'UP3-P208-SWS5-SPH-E0702D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL A', N'UP3-P208-SWS5-SPH-E0703A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL B', N'UP3-P208-SWS5-SPH-E0703B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL C', N'UP3-P208-SWS5-SPH-E0703C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED WATER COOLER FIN FAN CELL D', N'UP3-P208-SWS5-SPH-E0703D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-SWS5-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER FLASH DRUM', N'UP3-P208-SWS5-SPT-C0700', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPER', N'UP3-P208-SWS5-SPT-C0701', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FEED PREPARATION TANK', N'UP3-P208-SWS5-SPT-D0700', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLASH GAS EDUCTOR', N'UP3-P208-SWS5-SPT-EJ0700', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROCYCLONE', N'UP3-P208-SWS5-SPT-V0700', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TAIL GAS UNIT #4', N'UP3-P208-TOU4', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRUCTURE,CONCRETE & STEEL', N'UP3-P208-TOU4-SAS', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWAG FLARE', N'UP3-P208-TOU4-SAS-F0612', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPING CIRCUIT', N'UP3-P208-TOU4-SLP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-TOU4-SLP-AG_ACIDGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RELIEF AND BLOWDOWN STEAM PIPING', N'UP3-P208-TOU4-SLP-BDS_BLOWDOWNSTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'ACID GAS PIPING', N'UP3-P208-TOU4-SLP-BD_ACID_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMNE PIPING', N'UP3-P208-TOU4-SLP-BD_AMINE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-TOU4-SLP-BD_COOLING_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS PIPING', N'UP3-P208-TOU4-SLP-BD_PROCESS_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER ACID GAS PIPING', N'UP3-P208-TOU4-SLP-BD_SWAG', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING WATER PIPING', N'UP3-P208-TOU4-SLP-CW_COOLINGWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HIGH PRESSURE STEAM PIPING', N'UP3-P208-TOU4-SLP-HS_HIGHPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGEN PIPING', N'UP3-P208-TOU4-SLP-H_HYDROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT AIR PIPING', N'UP3-P208-TOU4-SLP-IA_INSTRUMENTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICALS PIPING', N'UP3-P208-TOU4-SLP-K_CHEMICALS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE CONDENSATE PIPING', N'UP3-P208-TOU4-SLP-LC_LOWPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LOW PRESSURE STEAM PIPING', N'UP3-P208-TOU4-SLP-LS_LOWPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE CONDENSATE PIPING', N'UP3-P208-TOU4-SLP-MC_MEDIUMPRESSURECOND', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MEDIUM PRESSURE STEAM PIPING', N'UP3-P208-TOU4-SLP-MS_MEDIUMPRESSURESTEAM', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS PIPING', N'UP3-P208-TOU4-SLP-NG_NATURALGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN PIPING', N'UP3-P208-TOU4-SLP-N_NITROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS PLANT AIR PIPING', N'UP3-P208-TOU4-SLP-PA_PROCESSPLANTAIR', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMPED CONDENSATE PIPING', N'UP3-P208-TOU4-SLP-PC_PUMPEDCONDENSATE', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS WATER PIPING', N'UP3-P208-TOU4-SLP-PW_PROCESSWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGEN PIPING', N'UP3-P208-TOU4-SLP-P_HYDROGEN', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PROCESS GAS PIPING', N'UP3-P208-TOU4-SLP-P_PROCESS_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCHED TAIL GAS PIPING', N'UP3-P208-TOU4-SLP-P_QUENCHED_TAIL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-TOU4-SLP-P_SOUR_WATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'START UP GAS PIPING', N'UP3-P208-TOU4-SLP-P_START_UP_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'START UP VENTGAS PIPING', N'UP3-P208-TOU4-SLP-P_START_UP_VENTGAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TAIL GAS PIPING', N'UP3-P208-TOU4-SLP-P_TAIL_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VENT GAS PIPING', N'UP3-P208-TOU4-SLP-P_VENT_GAS', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOUR WATER PIPING', N'UP3-P208-TOU4-SLP-SW_SOURWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UTILITY WATER PIPING', N'UP3-P208-TOU4-SLP-UW_UTILITYWATER', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PUMP & MOTOR', N'UP3-P208-TOU4-SMP', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER PUMP A', N'UP3-P208-TOU4-SMP-G0600A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER PUMP B', N'UP3-P208-TOU4-SMP-G0600B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH AMINE PUMP A', N'UP3-P208-TOU4-SMP-G0601A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH AMINE PUMP B', N'UP3-P208-TOU4-SMP-G0601B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP A', N'UP3-P208-TOU4-SMP-G0602A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE PUMP B', N'UP3-P208-TOU4-SMP-G0602B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REFLUX PUMP A', N'UP3-P208-TOU4-SMP-G0603A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REFLUX PUMP B', N'UP3-P208-TOU4-SMP-G0603B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FRESH MDEA PUMP', N'UP3-P208-TOU4-SMP-G0604', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP A', N'UP3-P208-TOU4-SMP-G0606A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LP CONDENSATE PUMP B', N'UP3-P208-TOU4-SMP-G0606B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HEATER,EXCHANGER & COOLER', N'UP3-P208-TOU4-SPH', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SCOT PREHEATER', N'UP3-P208-TOU4-SPH-E0600', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER TRIM COOLER A', N'UP3-P208-TOU4-SPH-E0601A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER TRIM COOLER B', N'UP3-P208-TOU4-SPH-E0601B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE TRIM COOLER', N'UP3-P208-TOU4-SPH-E0602', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN RICH EXCHANGER A', N'UP3-P208-TOU4-SPH-E0603A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN RICH EXCHANGER B', N'UP3-P208-TOU4-SPH-E0603B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER A', N'UP3-P208-TOU4-SPH-E0604A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REBOILER B', N'UP3-P208-TOU4-SPH-E0604B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR OVHD FIN FAN CELL A', N'UP3-P208-TOU4-SPH-E0605A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR OVHD FIN FAN CELL B', N'UP3-P208-TOU4-SPH-E0605B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR OVHD FIN FAN CELL C', N'UP3-P208-TOU4-SPH-E0605C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR OVHD FIN FAN CELL D', N'UP3-P208-TOU4-SPH-E0605D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL A', N'UP3-P208-TOU4-SPH-E0606A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL B', N'UP3-P208-TOU4-SPH-E0606B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL C', N'UP3-P208-TOU4-SPH-E0606C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL D', N'UP3-P208-TOU4-SPH-E0606D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL E', N'UP3-P208-TOU4-SPH-E0606E', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER COOLER FIN FAN CELL F', N'UP3-P208-TOU4-SPH-E0606F', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL A', N'UP3-P208-TOU4-SPH-E0607A', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL B', N'UP3-P208-TOU4-SPH-E0607B', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL C', N'UP3-P208-TOU4-SPH-E0607C', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE COOLER FIN FAN CELL D', N'UP3-P208-TOU4-SPH-E0607D', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'THERMAL OXIDIZER BURNER', N'UP3-P208-TOU4-SPH-F0610', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD', N'UP3-P208-TOU4-SPT', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SCOT REACTOR', N'UP3-P208-TOU4-SPT-C0601', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH TOWER', N'UP3-P208-TOU4-SPT-C0602', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE ABSORBER', N'UP3-P208-TOU4-SPT-C0603', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'AMINE REGENERATOR', N'UP3-P208-TOU4-SPT-C0604', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REGENERATOR REFLUX ACCUMULATOR DRUM', N'UP3-P208-TOU4-SPT-C0605', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SCOT PREHEATER CONDENSATE DRUM', N'UP3-P208-TOU4-SPT-C0606', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'REBOILER CONDENSATE DRUM', N'UP3-P208-TOU4-SPT-C0607', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MDEA SUMP', N'UP3-P208-TOU4-SPT-C0611', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SWAG FLARE KO DRUM', N'UP3-P208-TOU4-SPT-C0612', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SCOT STARTUP EDUCTOR', N'UP3-P208-TOU4-SPT-EJ0600', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'QUENCH WATER FILTER', N'UP3-P208-TOU4-SPT-T0600', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'LEAN AMINE FILTER', N'UP3-P208-TOU4-SPT-T0601', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'MDEA SUMP FILTER', N'UP3-P208-TOU4-SPT-T0604', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FIRST AID EQUIPMENT', N'UP3-P208-TOU4-SSA', 0, 0, 4, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SAFETY SHOWER EYEWASH', N'UP3-P208-TOU4-SSA-V0600', 0, 0, 5, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU INTERCONNECTIONG PIPERACKS', N'UP3-P210', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INTERCONNECTIONG PIPERACKS', N'UP3-P210-ITP1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU OSBL UTILITIES - WATER SYSTEMS', N'UP3-P212', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'API UNIT', N'UP3-P212-API3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW TREATMENT', N'UP3-P212-BFW1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING TOWERS', N'UP3-P212-CTW3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SSW BIOTREATMENT', N'UP3-P212-SSW1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RAW WATER SUPPLY/TREATMENT', N'UP3-P212-WAT3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU COOLING TOWER', N'UP3-P213', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CHEMICAL TREATMENT', N'UP3-P213-CHEM', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COOLING TOWER', N'UP3-P213-CTW3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'UTILITIES', N'UP3-P213-UTIL', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU OSBL UTILITIES - STEAM', N'UP3-P214', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BFW TREATMENT', N'UP3-P214-BFWT', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'GAS FIRED BOILERS', N'UP3-P214-GFBS', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STEAM LETDOWN & DISTRIBUTION', N'UP3-P214-STEM', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TURBO GENERATOR #12', N'UP3-P214-TG12', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'TURBO GENERATOR #13', N'UP3-P214-TG13', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU OSBL UTILITES - GAS & OTHER SYSTEMS', N'UP3-P215', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'HYDROGEN DISTRIBUTION', N'UP3-P215-HYDD', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NATURAL GAS', N'UP3-P215-NATG', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'NITROGEN', N'UP3-P215-NIT3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'OXYGEN DISTRIBUTION', N'UP3-P215-OXYD', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'RICH FUEL GAS COMPRESSORS', N'UP3-P215-RICH', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU EVAPORATOR/CRYSTALLIZATION', N'UP3-P216', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CRYSTALLIZATION', N'UP3-P216-CRY1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EVAPORATOR', N'UP3-P216-EVP1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SOLIDS HANDLING', N'UP3-P216-SLD1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU OFFPLOTS - PIPELINES', N'UP3-P217', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'PIPERACKS & RD COOLERS', N'UP3-P217-OPL3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU COKE AND SULPHUR STORAGE & HANDLING', N'UP3-P218', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'COKE HANDLING, STORAGE', N'UP3-P218-COK3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SULPHUR HANDLING AND STORAGE', N'UP3-P218-SUL3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU FLARE AND SLOPS SYSTEM', N'UP3-P219', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'EFFLUENT WATER / API / DAF', N'UP3-P219-API3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'STRIPPED SOUR WATER BIO-TREATER', N'UP3-P219-BIOT', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'FLARE AND KNOCKOUT', N'UP3-P219-FLR3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEWAGE TREATMENT', N'UP3-P219-SEWT', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SLOP OIL', N'UP3-P219-SLP3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'WASTE WATER / STORM WATER', N'UP3-P219-WASW', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU TANKAGE', N'UP3-P220', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BUTANE', N'UP3-P220-BUT3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BITUMEN AND DILUENT PRODUCTS / BLENDING', N'UP3-P220-ETF1', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'SEAL OIL / FLUSHING OIL', N'UP3-P220-OIL3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VAPOUR RECOVERY', N'UP3-P220-VAP3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'VU POWER HOUSE UTILITIES', N'UP3-P230', 0, 0, 2, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'INSTRUMENT/UTILITY AIR', N'UP3-P230-AIR3', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'CONDESATE SYSTEMS', N'UP3-P230-COND', 0, 0, 3, 1310, N'en')
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (11, N'BLOWDOWN COMPENSATE AND STEAM SYSTEMS', N'UP3-P230-STEM', 0, 0, 3, 1310, N'en')
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
SET @SiteId = 11
-- ------------------------------------------------------------------------------------

-------------------------------------------------
---  Insert Operational Modes for each Unit   ---
-------------------------------------------------

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
-- Update Ancestor Table                       ---
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
   

-- Insert the Ancestor records for these Mississaugua Flocs
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

INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (11,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (11,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (11,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (11,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (11,7)
GO


insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Operator Handover Questions',0
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Supervisor Handover Questions',0
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Boiler House Handover Questions',1
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'White Oils Lead Tech',0
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Test Operator',1

insert into SiteConfiguration ( 
SiteId,DaysToDisplayActionItems,DaysToDisplayShiftLogs,DaysBeforeArchivingClosedWorkPermits,DaysBeforeDeletingPendingWorkPermits,
DaysBeforeClosingIssuedWorkPermits,AutoApproveWorkOrderActionItemDefinition,AutoApproveSAPAMActionItemDefinition,AutoApproveSAPMCActionItemDefinition,CreateOperatingEngineerLogs,
WorkPermitNotApplicableAutoSelected,WorkPermitOptionAutoSelected,OperatingEngineerLogDisplayName,DaysToEditDeviationAlerts,DaysToDisplayShiftHandovers,
SummaryLogFunctionalLocationDisplayLevel,ShowActionItemsByWorkAssignmentOnPriorityPage,DaysToDisplayDeviationAlerts,AllowStandardLogAtSecondLevelFunctionalLocation,DorCutoffTime,
DaysToDisplayWorkPermitsBackwards,DaysToDisplayLabAlerts,LabAlertRetryAttemptLimit,RequireActionItemResponseLog,ActionItemRequiresApprovalDefaultValue,
HideDORCommentEntry,DaysToDisplayCokerCards,ActionItemRequiresResponseDefaultValue,ShowActionItemsOnShiftHandover,UseNewPriorityPage,ShowDirectivesOnPriorityPage,ShowShiftHandoversOnPriorityPage,
ShowShiftHandoversByWorkAssignmentOnPriorityPage,DaysToDisplayDirectivesOnPriorityPage,DaysToDisplayShiftHandoversOnPriorityPage,DisplayActionItemWorkAssignmentOnPriorityPage,
DaysToDisplayPermitRequestsBackwards,DaysToDisplayPermitRequestsForwards,DaysToDisplayWorkPermitsForwards,DisplayActionItemCommentOnly,DefaultNumberOfCopiesForWorkPermits,
ShowFollowupOnLogForm,AllowCreateALogForEachSelectedFlocOnLogForm,ShowAdditionalDetailsOnLogFormByDefault,Culture,ShowWorkPermitPrintingTabInPreferences,ShowDefaulPermitTimesTabInPreferences,
DaysToDisplayTargetAlertsOnPriorityPage,LoginFlocSelectionLevel,UseCreatedByColumnForLogs,ShowIsModifiedColumnForLogs,CopyTargetAlertResponseToLog,ShowLogRecommendedForSummaryColumn,
ItemFlocSelectionLevel,DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs, DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
PreShiftPaddingInMinutes,PostShiftPaddingInMinutes,DaysToDisplayFormsBackwards,DaysToDisplayFormsForwards)  
select 
11,7,7,7,7,
1,1,1,1,1,
1,1,'Chief Engineer Log',7,7,
2,0,7,1,'Jan  1 1753 10:00AM',
15,30,3,1,1,
1,14,1,1,1,
1,1,0,7,2,1,0,0,0,1,1,1,1,1,'en',0,0,
0,7,0,0,1,0,
7,1,1,
60,60,3,3

go


/*
insert into DocumentRootPathConfiguration (PathName, UncPath, Deleted) values ('Lubes W: Drive', '\\MISFS01.pcacorp.net\workgrp', 0)
insert into DocumentRootPathConfiguration (PathName, UncPath, Deleted) values ('TIPS Online', 'http://lcinfo/tipsonline/search.asp', 0)

insert into DocumentRootPathFunctionalLocation (DocumentRootPathId, FunctionalLocationId)
select drpfl.DocumentRootPathId, drpfl.FunctionalLocationId
from DocumentRootPathFunctionalLocation drpfl
inner join functionallocation fl on drpfl.FunctionalLocationId = fl.Id
inner join DocumentRootPathConfiguration drpc on drpc.Id = drpfl.DocumentRootPathId
where fl.SiteId = 10
*/

insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'May 23 2012  8:53AM','May 23 2012  8:53AM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Sampling','Smpl',0,0,-1,'Jul  6 2012  1:50PM','Jul  6 2012  1:50PM',0,11
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Shutdown / Turnaround','TA',0,0,-1,'Jul 10 2012  1:31PM','Jul 10 2012  1:31PM',0,11


insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 11 and f.FullHierarchy = 'UP3' and bc.SiteId = 11 and bc.Deleted = 0
go

-- roles

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (136, 'Operator', 0, 'Operator', 11, 0, 0, 0, 1, 'oper');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (137, 'Shift Supervisor', 0, 'Supervisor', 11, 0, 0, 0, 1, 'super');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (138, 'Coordinator/Manager', 0, 'Coordinator', 11, 0, 0, 0, 1, 'eng');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (139, 'Engineer', 0, 'Engineer', 11, 0, 0, 0, 1, 'eng');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (140, 'Chief Engineer/Assistant Chief Engineer', 0, 'ChiefEngineer', 11, 0, 0, 0, 1, 'eng');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (141, 'Read User', 0, 'ReadUser', 11, 0, 1, 0, 0, 'read');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (142, 'Administrator', 0, 'Administrator', 11, 1, 0, 0, 0, 'admin');

SET IDENTITY_INSERT [Role] OFF;

GO

update Role set WarnIfWorkAssignmentNotSelected = 1 where SiteId = 11 
go  
  
update Role set WarnIfWorkAssignmentNotSelected = 0 where SiteId = 11 and Name in ('Read User', 'Administrator')  
go  

-------------------------------- Role Elements Start --------------------------------------

insert into RoleElementTemplate (RoleElementId, RoleId) values (10,136); -- Comment Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,136); -- View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,136); -- Respond to Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,136); -- Create Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,136); -- View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,136); -- Edit Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,136); -- Delete Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,136); -- Reply To Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,136); -- View Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,136); -- View Summary Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,136); -- View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,136); -- Create Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,136); -- Edit Shift Handover Questionnaire, Operator

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,142); -- View Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,142); -- View Action Item, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,142); -- Configure Auto Approve SAP Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,142); -- Configure Business Categories, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,142); -- Associate Business Categories To Functional Locations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (113,142); -- Configure Log Guidelines, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,142); -- Configure Summary Log Custom Fields, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,142); -- Edit Log Templates, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,142); -- Configure Plant Historian Tag List, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (120,142); -- Edit Shift Handover Configurations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (76,142); -- Configure Display Limits, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,142); -- Configure Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,142); -- Configure Default FLOCs for Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (136,142); -- Configure Default Tabs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (141,142); -- Configure Work Assignment Not Selected Warning, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,142); -- Configure Unc Paths for Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,142); -- Configure Priorities Page, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (81,142); -- Configure Craft Or Trade, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (195,142); -- Configure Configured Document Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,142); -- View Log, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,142); -- View Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,142); -- View Standing Orders, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,142); -- View Summary Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,142); -- View Shift Handover, Administrator

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,140); -- View Action Item Definition, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,140); -- Comment Action Item Definition, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,140); -- View Action Item, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,140); -- Respond to Action Item, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,140); -- Create Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,140); -- View Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,140); -- Edit Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,140); -- Delete Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,140); -- Reply To Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,140); -- View Log Definitions, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (63,140); -- Edit Log Flagged as Operating Engineer Log, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,140); -- View Directives, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (97,140); -- Create Directives, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (98,140); -- Edit Directives, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,140); -- View Standing Orders, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,140); -- View Summary Logs, Chief Engineer/Assistant Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,140); -- View Shift Handover, Chief Engineer/Assistant Chief Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,138); -- View Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,138); -- Approve Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,138); -- Reject Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,138); -- Create Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,138); -- Edit Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,138); -- Delete Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,138); -- Comment Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,138); -- Toggle Approval Required for Action Item Definition, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,138); -- View Action Item, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (73,138); -- Manage Operational Modes, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,138); -- Create Log, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,138); -- View Log, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,138); -- Edit Log, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,138); -- Delete Log, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,138); -- Reply To Log, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,138); -- View Directives, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (97,138); -- Create Directives, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (98,138); -- Edit Directives, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,138); -- Delete Directives, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (177,138); -- Cancel Standing Orders, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,138); -- View Standing Orders, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,138); -- View Summary Logs, Coordinator/Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,138); -- View Shift Handover, Coordinator/Manager

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,139); -- View Action Item Definition, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,139); -- Comment Action Item Definition, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,139); -- View Action Item, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,139); -- Respond to Action Item, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,139); -- Create Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,139); -- View Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,139); -- Edit Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,139); -- Delete Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,139); -- Reply To Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (63,139); -- Edit Log Flagged as Operating Engineer Log, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,139); -- View Summary Logs, Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,139); -- View Shift Handover, Engineer

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,141); -- View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,141); -- View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,141); -- View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,141); -- View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,141); -- View Standing Orders, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,141); -- View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,141); -- View Shift Handover, Read User

insert into RoleElementTemplate (RoleElementId, RoleId) values (1,137); -- View Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,137); -- Approve Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,137); -- Reject Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,137); -- Create Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,137); -- Edit Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,137); -- Delete Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,137); -- Comment Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,137); -- Toggle Approval Required for Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,137); -- View Action Item, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,137); -- Respond to Action Item, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,137); -- Configure Auto Approve SAP Action Item Definition, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (73,137); -- Manage Operational Modes, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (84,137); -- Configure Automatic Re-Approval by Field, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,137); -- Configure Plant Historian Tag List, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,137); -- Configure Default FLOCs for Assignments, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,137); -- Create Log, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,137); -- View Log, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,137); -- Edit Log, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,137); -- Delete Log, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,137); -- Reply To Log, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,137); -- View Directives, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (97,137); -- Create Directives, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (98,137); -- Edit Directives, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,137); -- Delete Directives, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (177,137); -- Cancel Standing Orders, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,137); -- View Standing Orders, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,137); -- View Summary Logs, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,137); -- Create Summary Logs, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,137); -- Edit Summary Logs, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (95,137); -- Delete Summary Logs, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,137); -- View Shift Handover, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,137); -- Create Shift Handover Questionnaire, Shift Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,137); -- Edit Shift Handover Questionnaire, Shift Supervisor

GO

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Administrator','Administrator',11, 0, 142, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Read Only','Read Only',11, 0, 141, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Unit Operator','Unit Operator',11, 0, 136, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Team Lead','Team Lead',11, 0, 136, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Unit Leader','Unit Leader',11, 0, 136, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Shift Supervisor','Shift Supervisor',11, 0, 137, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Manager','Manager',11, 0, 138, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Engineer','Engineer',11, 0, 139, 'General', 1);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay) values ('Chief Engineer','Chief Engineer',11, 0, 140, 'General', 1);
GO
-- 
insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Administrator' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Read Only' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Unit Operator' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Team Lead' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Unit Leader' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Shift Supervisor' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Manager' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Engineer' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'UP3' and a.name = 'Chief Engineer' and a.SiteId = 11;

GO






GO

