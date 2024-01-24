-- UPDATES to FLOCS for TRO being added to OLT

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([Level], [SiteId])
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
GO    

ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO

UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-BLDI-SAB-T0079' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-BLDI-SAB-T0079-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-BLDI-SAB-T0080' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-BLDI-SAB-T0080-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-COMS-SEG-81PJ1013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-COMS-SEG-81PJ1013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-EDP7-SEG-86PJ1041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-EDP7-SEG-86PJ1041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-PD01-SCT-T0372' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-PD01-SCT-T0372-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-PD01-SPT-C0066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-PD01-SPT-C0066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-PD4G-SSR-PSV0458' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-PD4G-SSR-PSV0458-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-PD4G-SSR-PSV2026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-PD4G-SSR-PSV2026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-SBPH-SEG-86PT4011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-SBPH-SEG-86PT4011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-STPD-SEG-81UPS1009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-STPD-SEG-81UPS1009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-OPLT-STPD-SEG-86UPS1009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-OPLT-STPD-SEG-86UPS1009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SAB-RK0240A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SAB-RK0240A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SAB-RK0240B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SAB-RK0240B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SCH-T0215A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SCH-T0215A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-D0090A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-D0090A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-D0090B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-D0090B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-D0090C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-D0090C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-D0090D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-D0090D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-E0005B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-E0005B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-F0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-F0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPH-F0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPH-F0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SPT-D0125' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SPT-D0125-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SSR-PSV1882' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SSR-PSV1882-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SSR-PSV1883' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SSR-PSV1883-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SSR-PSV463A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SSR-PSV463A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SSR-PSV463B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SSR-PSV463B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BLDI-SSR-PSV464A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BLDI-SSR-PSV464A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BRFT-SPT-D0114A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BRFT-SPT-D0114A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-BRFT-SPT-D0114B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-BRFT-SPT-D0114B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-CHEM-SPH-C0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-CHEM-SPH-C0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-CHEM-SSR-PSV0074' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-CHEM-SSR-PSV0074-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-COMS-SEG-UPS0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-COMS-SEG-UPS0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-COMS-SEG-UPS0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-COMS-SEG-UPS0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-COMS-SEG-UPS0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-COMS-SEG-UPS0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-COMS-SEG-UPS0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-COMS-SEG-UPS0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-COMS-SSR-PSV0275' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-COMS-SSR-PSV0275-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-FRTH-SSR-PSV0046_5' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-FRTH-SSR-PSV0046_5-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-FRTH-SSR-PSV0047_5' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-FRTH-SSR-PSV0047_5-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0539_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0539_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0539_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0539_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0539_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0539_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0540_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0540_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0540_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0540_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0540_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0540_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0541_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0541_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0541_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0541_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0541_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0541_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0542_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0542_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0542_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0542_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-LPSW-SIL-F0542_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-LPSW-SIL-F0542_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-PST2-SSR-PSV0045_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-PST2-SSR-PSV0045_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-PST4-SSR-PSV0045_4' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-PST4-SSR-PSV0045_4-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-PST5-SSR-PSV0045_5' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-PST5-SSR-PSV0045_5-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST1-SSR-PSV0049_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST1-SSR-PSV0049_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST2-SSR-PSV0049_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST2-SSR-PSV0049_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST3-SSR-PSV0049_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST3-SSR-PSV0049_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST4-SSR-PSV0049_4' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST4-SSR-PSV0049_4-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST5-SMA-T0173K' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST5-SMA-T0173K-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST5-SMA-T0174J' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST5-SMA-T0174J-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST5-SMA-T0175J' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST5-SMA-T0175J-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-SST5-SSR-PSV0049_5' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-SST5-SSR-PSV0049_5-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-TST1-SSR-PSV0048_1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-TST1-SSR-PSV0048_1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-TST2-SSR-PSV0048_3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-TST2-SSR-PSV0048_3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-TST3-SSR-PSV0048_5' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-TST3-SSR-PSV0048_5-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-UAIR-SPT-C0038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-UAIR-SPT-C0038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P003-UAIR-SSR-PSV0475' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P003-UAIR-SSR-PSV0475-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-BLDI-SAB-FD004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-BLDI-SAB-FD004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-BLDI-SAB-FD005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-BLDI-SAB-FD005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-BLDI-SCH-T0113' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-BLDI-SCH-T0113-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SEG-PJ0060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SEG-PJ0060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIC-PJ0060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIC-PJ0060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIR-AI0010E1' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIR-AI0010E1-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIR-AI0012A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIR-AI0012A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIR-AI0252D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIR-AI0252D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIR-AI0252E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIR-AI0252E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SIR-AI0583' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SIR-AI0583-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SMP-G0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SMP-G0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-DILU-SIL-F0055A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-DILU-SIL-F0055A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-DILU-SIL-F0055B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-DILU-SIL-F0055B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-DILU-SIR-AI0251B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-DILU-SIR-AI0251B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-FDTL-SIR-AI0785' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-FDTL-SIR-AI0785-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-FRTH-SMP-G0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-FRTH-SMP-G0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-FRTH-SMP-G0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-FRTH-SMP-G0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IAIR-SPT-C0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IAIR-SPT-C0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IAIR-SPT-C0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IAIR-SPT-C0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_01' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_01-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_02' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_02-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_03' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_03-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_05' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_05-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_06' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_06-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_07' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_07-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_08' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_08-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_09' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_09-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_10' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_10-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_11' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_11-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_12' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_12-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_13' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_13-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_14' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_14-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_15' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_15-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_16' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_16-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_17' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_17-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SEH-PJ0060_18' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SEH-PJ0060_18-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIL-HV656' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIL-HV656-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIL-HV657' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIL-HV657-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIL-HV658' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIL-HV658-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIL-HV659' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIL-HV659-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIR-AI0639' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIR-AI0639-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIR-AI0640' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIR-AI0640-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIR-AI0861' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIR-AI0861-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIR-AI0862' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIR-AI0862-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SIV-T0092B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SIV-T0092B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-LPSW-SIT-T0577A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-LPSW-SIT-T0577A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-LPSW-SIT-T0577B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-LPSW-SIT-T0577B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-LPSW-SIT-T0577C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-LPSW-SIT-T0577C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-OVHD-SIL-PSH213' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-OVHD-SIL-PSH213-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-OVHD-SIL-PSH258' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-OVHD-SIL-PSH258-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SEM-4PJ1600' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SEM-4PJ1600-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4F1620' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4F1620-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4F1621' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4F1621-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4PC1600' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4PC1600-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4S1652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4S1652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4S1653' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4S1653-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4S1654' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4S1654-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4ST1652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4ST1652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4ST1653' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4ST1653-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4T1654' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4T1654-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4TT1634' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4TT1634-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4TT1635' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4TT1635-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-4TT1649' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-4TT1649-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-H0204B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-H0204B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-H0205B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-H0205B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1610' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1610-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1611' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1611-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1612' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1612-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1613' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1613-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1614' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1614-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1615' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1615-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1616' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1616-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-HV1617' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-HV1617-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-PCV1626' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-PCV1626-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-PSV1622' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-PSV1622-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-ST1652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-ST1652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIL-ST1653' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIL-ST1653-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SIV-4XV1613' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SIV-4XV1613-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4IA1015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4IA1015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4IA1016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4IA1016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4M3008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4M3008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4N3046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4N3046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4NRD1001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4NRD1001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4P3007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4P3007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4P3008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4P3008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4PGB26' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4PGB26-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-PSCU-SLP-4SLW3' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-PSCU-SLP-4SLW3-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIA-A2701' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIA-A2701-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-1009' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-1009-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-2000' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-2000-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-2001' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-2001-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-2002' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-2002-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-2701' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-2701-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04A-2702' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04A-2702-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04F-2122' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04F-2122-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04P-2121' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04P-2121-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04PCV-2114' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04PCV-2114-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04PCV-2115' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04PCV-2115-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-04PCV-2116' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-04PCV-2116-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-4F_603' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-4F_603-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-4F_615' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-4F_615-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-A2012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-A2012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-A2700' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-A2700-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-D0581' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-D0581-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-F0053_90A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-F0053_90A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-F0053_90B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-F0053_90B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-F0611' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-F0611-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-F0612' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-F0612-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-F0614' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-F0614-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-HV2420' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-HV2420-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-HV2423' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-HV2423-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-HV2424' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-HV2424-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-HV2425' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-HV2425-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-HV2813' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-HV2813-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-P0617' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-P0617-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-PCV0026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-PCV0026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-PCV2501' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-PCV2501-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-PCV2509' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-PCV2509-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-PCV26' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-PCV26-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-S220' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-S220-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-S225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-S225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-V200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-V200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-V201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-V201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-V202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-V202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIL-V203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIL-V203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIR-A2700' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIR-A2700-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIR-AI0252D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIR-AI0252D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIR-AI0252E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIR-AI0252E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIR-AI0583' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIR-AI0583-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIS-P0876' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIS-P0876-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-4A_604' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-4A_604-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-HV0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-HV0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-HV0602' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-HV0602-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-P0433_2' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-P0433_2-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-P0602' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-P0602-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-PCV0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-PCV0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-PCV0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-PCV0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SIV-PCV0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SIV-PCV0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-SSCU-SSR-PSV0610' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-SSCU-SSR-PSV0610-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-COMS-SIL-P0365' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-COMS-SIL-P0365-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-H0827' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-H0827-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-L0379' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-L0379-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIV-XV0014A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIV-XV0014A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIV-XV0014B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIV-XV0014B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIV-XV0014C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIV-XV0014C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-IFST-SAB-RA1599-SSF-16A262' and SiteId = 3 and Level = 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-IFST-SAB-RA1599-SSF-16A262-%' and SiteId = 3 and Level > 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-IFST-SAB-RA1599-SSF-16A349' and SiteId = 3 and Level = 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-IFST-SAB-RA1599-SSF-16A349-%' and SiteId = 3 and Level > 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-LPSW-SIL-P0149' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-LPSW-SIL-P0149-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-F0130' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-F0130-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-F0350' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-F0350-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-F0351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-F0351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-L0273' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-L0273-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-L0389' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-L0389-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIL-P0136' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIL-P0136-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0131A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0131A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0132A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0132A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0132B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0132B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0134A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0134A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0134B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0134B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0290A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0290A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0290B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0290B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0291A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0291A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0291B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0291B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0293A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0293A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0293B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0293B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0347A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0347A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0347B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0347B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0348A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0348A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-AI0348B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-AI0348B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-PI328A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-PI328A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-PI328B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-PI328B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIR-PI328C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIR-PI328C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIT-F0326' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIT-F0326-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-OVHD-SIT-LSH380' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-OVHD-SIT-LSH380-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-CHEM-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-CHEM-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-CHEM-SIT-L0823' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-CHEM-SIT-L0823-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-CHEM-SIT-L0824' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-CHEM-SIT-L0824-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-COMS-SIL-TDC3000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-COMS-SIL-TDC3000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SEM-VFD0044A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SEM-VFD0044A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SEM-VFD0044B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SEM-VFD0044B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIL-S0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIL-S0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIL-S0115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIL-S0115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIL-T1012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIL-T1012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIL-T1017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIL-T1017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-S1003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-S1003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-T1023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-T1023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-T1025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-T1025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-T1027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-T1027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-T1031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-T1031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-W1000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-W1000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGA-SIT-W1003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGA-SIT-W1003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SEM-VFD0045A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SEM-VFD0045A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SEM-VFD0045B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SEM-VFD0045B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIL-S0214' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIL-S0214-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIL-S0215' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIL-S0215-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIL-T2012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIL-T2012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIL-T2017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIL-T2017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-S2003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-S2003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-S2004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-S2004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-T2023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-T2023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-T2031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-T2031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-W2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-W2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-DSGB-SIT-W2003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-DSGB-SIT-W2003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIL-P0821' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIL-P0821-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIL-P0826' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIL-P0826-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIS-T0851' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIS-T0851-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIS-T0852' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIS-T0852-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIS-T0853' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIS-T0853-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-F0870' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-F0870-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-F2014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-F2014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0821' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0821-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0826' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0826-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0872' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0872-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0878' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0878-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0888' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0888-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIT-P0898' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIT-P0898-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIV-PV0866A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIV-PV0866A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIV-PV0866B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIV-PV0866B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SIV-XV0890' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SIV-XV0890-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPEW-SLE-XV0890' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPEW-SLE-XV0890-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPSW-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPSW-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPSW-SIT-F0845' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPSW-SIT-F0845-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HPSW-SIT-P0844' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HPSW-SIT-P0844-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT-D0716' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-D0716-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT-F0720' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-F0720-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT-P0617' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-P0617-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT-P0705' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-P0705-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT02-SIT-P0706' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT02-SIT-P0706-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-D0746' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-D0746-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-F0750' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-F0750-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-P0627' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-P0627-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-P0734' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-P0734-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-P0735' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-P0735-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT03-SIT-P0736' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT03-SIT-P0736-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-D0776' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-D0776-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-F0780' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-F0780-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-P0637' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-P0637-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-P0764' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-P0764-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-P0765' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-P0765-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIT-P0766' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIT-P0766-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-HT04-SIV-HV0639' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-HT04-SIV-HV0639-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-IAIR-SIR-P0943' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-IAIR-SIR-P0943-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-IAIR-SIR-P0953' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-IAIR-SIR-P0953-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-F0835' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-F0835-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-F1006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-F1006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-F2006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-F2006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0371' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0371-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0381' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0381-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0391' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0391-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0471' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0471-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0481' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0481-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0491' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0491-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0574' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0574-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0575' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0575-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0576' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0576-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0584' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0584-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0585' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0585-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0586' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0586-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0594' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0594-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0595' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0595-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0596' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0596-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-LPSW-SIT-P0834' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-LPSW-SIT-P0834-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-MBS1-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-MBS1-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-MBS2-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-MBS2-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-NGAS-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-NGAS-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-NGAS-SIT-P0989' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-NGAS-SIT-P0989-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIL-T01956' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIL-T01956-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0160' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0160-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0180' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0180-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0310' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0310-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0320' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0320-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0344' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0344-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0354' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0354-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-I0364' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-I0364-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-L0103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-L0103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-L1132' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-L1132-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-L1219' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-L1219-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-P0149' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-P0149-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-T0108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-T0108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-T0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-T0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-T1222' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-T1222-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-W0165' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-W0165-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT1-SIT-W0185' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT1-SIT-W0185-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0205' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0205-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0206' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0206-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0260' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0260-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0280' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0280-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0410' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0410-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0420' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0420-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0444' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0444-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0454' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0454-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-I0464' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-I0464-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-L0203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-L0203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-L0203X' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-L0203X-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-L1133' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-L1133-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-L1220' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-L1220-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-P0249' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-P0249-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-P0445' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-P0445-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-P0455' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-P0455-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-P0465' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-P0465-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-T0208' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-T0208-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-T1223' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-T1223-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-W0265' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-W0265-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OPT2-SIT-W0285' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OPT2-SIT-W0285-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OVSZ-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OVSZ-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-OVSZ-SIT-W0502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-OVSZ-SIT-W0502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SIR-P0945' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SIR-P0945-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV0225C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV0225C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV0225D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV0225D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV0809' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV0809-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV1235' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV1235-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV1236' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV1236-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV1249' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV1249-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV1250' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV1250-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P082-UAIR-SSR-PSV1251' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P082-UAIR-SSR-PSV1251-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-D1500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-D1500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-D1503' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-D1503-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-F1510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-F1510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-F1511' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-F1511-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-F1512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-F1512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-F1521' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-F1521-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1540' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1540-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1541' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1541-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1542' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1542-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1543' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1543-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1544' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1544-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1545' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1545-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1546' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1546-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1547' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1547-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1550' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1550-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-L1551' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-L1551-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-P1502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-P1502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-P1511' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-P1511-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-P1512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-P1512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-PD1510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-PD1510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-T1500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-T1500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-T1501' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-T1501-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIL-T3950' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIL-T3950-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-FSH1521' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-FSH1521-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSH1543' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSH1543-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSH1551' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSH1551-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSHH1554' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSHH1554-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSHL1545' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSHL1545-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSL1553' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSL1553-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSLL1544' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSLL1544-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSLL1546' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSLL1546-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-LSLL1547' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-LSLL1547-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-PDSH1502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-PDSH1502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-PSL1513' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-PSL1513-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIS-TSH1505' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIS-TSH1505-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-D1500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-D1500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-D1503' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-D1503-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-L1540' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-L1540-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-L1541' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-L1541-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-L1542' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-L1542-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-P1511' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-P1511-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-P1512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-P1512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-PD1510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-PD1510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIT-T1500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIT-T1500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-KV1020A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-KV1020A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-KV1020B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-KV1020B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-PCV1508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-PCV1508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-PCV1509' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-PCV1509-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-PDV1502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-PDV1502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SIV-XV1315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SIV-XV1315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CHEM-SMP-G0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CHEM-SMP-G0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F1914' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F1914-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F1915' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F1915-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F1936' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F1936-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F2760' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F2760-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F2914' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F2914-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F2915' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F2915-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F2936' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F2936-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F3760' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F3760-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F3914' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F3914-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F3915' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F3915-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-F3936' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-F3936-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-P2912' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-P2912-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-P3912' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-P3912-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T1911' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T1911-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T1921' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T1921-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T2911' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T2911-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T2921' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T2921-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T3911' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T3911-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-CPEW-SIT-T3921' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-CPEW-SIT-T3921-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F1757' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F1757-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F1903' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F1903-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F1920' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F1920-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F2857' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F2857-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F2903' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F2903-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F2920' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F2920-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F3857' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F3857-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F3903' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F3903-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-F3920' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-F3920-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P1304' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P1304-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P1308' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P1308-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P1309' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P1309-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P2304' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P2304-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P2308' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P2308-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P2309' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P2309-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P2901' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P2901-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P3304' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P3304-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P3308' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P3308-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P3309' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P3309-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-P3901' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-P3901-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-PD1730' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-PD1730-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-PD2830' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-PD2830-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-PD3830' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-PD3830-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-T1902' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-T1902-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-T2902' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-T2902-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIT-T3902' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIT-T3902-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIV-T1919' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIV-T1919-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIV-T2919' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIV-T2919-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPEW-SIV-T3919' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPEW-SIV-T3919-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F1642' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F1642-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F1652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F1652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F2642' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F2642-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F2652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F2652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F3642' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F3642-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-F3652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-F3652-%' and SiteId = 3 and Level > 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-P1925' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-P1925-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-P2925' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-P2925-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-HPSW-SIT-P3925' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-HPSW-SIT-P3925-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SIT-P1670' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SIT-P1670-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SIT-P2670' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SIT-P2670-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SIT-P3670' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SIT-P3670-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SSR-PRV1192' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SSR-PRV1192-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SSR-PRV1949' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SSR-PRV1949-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SSR-PRV2949' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SSR-PRV2949-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-IAIR-SSR-PRV3949' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-IAIR-SSR-PRV3949-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-F1411' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-F1411-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-F2411' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-F2411-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-F3411' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-F3411-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-P1922' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-P1922-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-P2922' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-P2922-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-LPSW-SIT-P3922' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-LPSW-SIT-P3922-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1346A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1346A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1346B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1346B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706G' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706G-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706H' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706H-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706I' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706I-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SES-HS1706J' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SES-HS1706J-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-F1349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-F1349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-F1360' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-F1360-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-S1341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-S1341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-S1343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-S1343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-S1351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-S1351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-S1353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-S1353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1315A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1315A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1315B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1315B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1321A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1321A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1321B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1321B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1321C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1321C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1321D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1321D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1322A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1322A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1322B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1322B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1322C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1322C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1322D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1322D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1329A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1329A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1329B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1329B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1329C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1329C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIL-T1329D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIL-T1329D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-FSH1340' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-FSH1340-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-FSH1359' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-FSH1359-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-FSL1349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-FSL1349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-FSL1360' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-FSL1360-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-LSHH1666' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-LSHH1666-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-LSHH1907' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-LSHH1907-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-LSHL1667' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-LSHL1667-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-LSHL1906' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-LSHL1906-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-SSL1353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-SSL1353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-TSH1318' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-TSH1318-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIS-TSHH1319' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIS-TSHH1319-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-D1410' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-D1410-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-D1661' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-D1661-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-F1414' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-F1414-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-F1502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-F1502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1402' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1402-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1403' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1403-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1521' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1521-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-L1523' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-L1523-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-P1641' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-P1641-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-P1918' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-P1918-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-S1328' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-S1328-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1321' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1321-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1322' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1322-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1329' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1329-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1415' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1415-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1522' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1522-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1663' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1663-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1717' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1717-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-T1727' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-T1727-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-W1701' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-W1701-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT1-SIT-W1703' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT1-SIT-W1703-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2346A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2346A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2346B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2346B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706G' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706G-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706H' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706H-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706I' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706I-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706J' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706J-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706K' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706K-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706L' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706L-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706N' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706N-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706O' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706O-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706P' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706P-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706Q' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706Q-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706R' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706R-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706S' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706S-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2706T' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2706T-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806G' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806G-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806H' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806H-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806I' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806I-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806J' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806J-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806K' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806K-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806M' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806M-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806N' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806N-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806O' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806O-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SES-HS2806P' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SES-HS2806P-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-F2349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-F2349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-F2360' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-F2360-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-S2341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-S2341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-S2343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-S2343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-S2351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-S2351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-S2353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-S2353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T1322E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T1322E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T1322F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T1322F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2315A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2315A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2315B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2315B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2321A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2321A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2321B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2321B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2321C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2321C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2321D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2321D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2322A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2322A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2322B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2322B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2322C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2322C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2322D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2322D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2322F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2322F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2329A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2329A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2329B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2329B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2329C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2329C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T2329D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T2329D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T322E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T322E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T3322E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T3322E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIL-T3322F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIL-T3322F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-FSH2340' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-FSH2340-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-FSH2359' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-FSH2359-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHH2264' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHH2264-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHH2526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHH2526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHH2666' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHH2666-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHH2907' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHH2907-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHL2527' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHL2527-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHL2667' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHL2667-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-LSHL2906' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-LSHL2906-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-SSL2353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-SSL2353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-TSH2318' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-TSH2318-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIS-TSHH2319' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIS-TSHH2319-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-D2410' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-D2410-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-D2661' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-D2661-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-F2414' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-F2414-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-F2502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-F2502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2260' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2260-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2402' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2402-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2403' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2403-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2509' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2509-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-L2523' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-L2523-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-P2641' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-P2641-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-P2918' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-P2918-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-S2328' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-S2328-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2321' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2321-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2322' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2322-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2329' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2329-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2415' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2415-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2522' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2522-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2663' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2663-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2716' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2716-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2726' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2726-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2735' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2735-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2816' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2816-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-T2826' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-T2826-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-W2701' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-W2701-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-W2703' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-W2703-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-W2801' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-W2801-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SIT-W2803' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SIT-W2803-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT2-SPT-T0052B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT2-SPT-T0052B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SES-HS3346A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SES-HS3346A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SES-HS3346B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SES-HS3346B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-F3349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-F3349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-F3360' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-F3360-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-S3341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-S3341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-S3343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-S3343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-S3351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-S3351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-S3353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-S3353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3145A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3145A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3145B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3145B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3145C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3145C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3145D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3145D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3145E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3145E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3155A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3155A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3155B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3155B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3155C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3155C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3155D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3155D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3155E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3155E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3315A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3315A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3315B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3315B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3321A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3321A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3321B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3321B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3321C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3321C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3321D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3321D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3322A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3322A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3322B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3322B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3322C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3322C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3322D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3322D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3329A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3329A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3329B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3329B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3329C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3329C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIL-T3329D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIL-T3329D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-FSH3340' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-FSH3340-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-FSH3359' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-FSH3359-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-FSL3349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-FSL3349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-FSL3360' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-FSL3360-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHH3264' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHH3264-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHH3526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHH3526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHH3666' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHH3666-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHH3907' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHH3907-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHL3527' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHL3527-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHL3667' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHL3667-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-LSHL3906' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-LSHL3906-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3351' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3351-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-SSL3353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-SSL3353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-TSH3318' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-TSH3318-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIS-TSHH3319' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIS-TSHH3319-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-D3410' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-D3410-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-D3661' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-D3661-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-F3414' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-F3414-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-F3502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-F3502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3260' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3260-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3402' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3402-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3403' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3403-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-L3523' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-L3523-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-P3641' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-P3641-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-P3918' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-P3918-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-S3328' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-S3328-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T0059B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T0059B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T0059C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T0059C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3321' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3321-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3322' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3322-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3329' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3329-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3522' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3522-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3663' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3663-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3716' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3716-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3726' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3726-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3735' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3735-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3817' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3817-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-T3827' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-T3827-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-W3701' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-W3701-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-W3703' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-W3703-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-W3801' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-W3801-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SIT-W3803' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SIT-W3803-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-OPT3-SPT-T0052C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-OPT3-SPT-T0052C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-UAIR-SIT-F1759' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-UAIR-SIT-F1759-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-UAIR-SIT-F2859' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-UAIR-SIT-F2859-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-UAIR-SIT-F3859' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-UAIR-SIT-F3859-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P085-UAIR-SIV-85PV3027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P085-UAIR-SIV-85PV3027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0051' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0051-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0052' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0052-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0053' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0053-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0057' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0057-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0058' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0058-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0063' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0063-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-BLDI-SAB-T0114C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-BLDI-SAB-T0114C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-COMS-SIC-PJ0161' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-COMS-SIC-PJ0161-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-COMS-SIC-PJ0162' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-COMS-SIC-PJ0162-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-COMS-SLP-BD0099' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-COMS-SLP-BD0099-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-COMS-SLP-DW0099' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-COMS-SLP-DW0099-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-COMS-SLP-FO0099' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-COMS-SLP-FO0099-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0121' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0121-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0122' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0122-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0123' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0123-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0126' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0126-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0127' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0127-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0128' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0128-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0129' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0129-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0130' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0130-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0131' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0131-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0132' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0132-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-CPEW-SLP-PEW0133' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-CPEW-SLP-PEW0133-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-EPND-SLP-P0124' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-EPND-SLP-P0124-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-EPND-SLP-P0125' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-EPND-SLP-P0125-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-EPND-SLP-P0126' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-EPND-SLP-P0126-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-EPND-SLP-P0127' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-EPND-SLP-P0127-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-EPND-SLP-P0128' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-EPND-SLP-P0128-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SEM-PJ0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SEM-PJ0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SEM-PJC3507' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SEM-PJC3507-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SEM-VFD1300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SEM-VFD1300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SEM-VFD1400' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SEM-VFD1400-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SIL-P2047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SIL-P2047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SIT-D2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SIT-D2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P1048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P1048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P1049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P1049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P1050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P1050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P1061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P1061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-P2050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-P2050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-PD2048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-PD2048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-PD2049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-PD2049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIL-PD2050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIL-PD2050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIT-F2051' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIT-F2051-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIT-F2052' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIT-F2052-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SIT-F2053' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SIT-F2053-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0210' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0210-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0212' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0212-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0213' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0213-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0214' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0214-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0215' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0215-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0216' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0216-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0217' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0217-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0218' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0218-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0219' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0219-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0220' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0220-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0221' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0221-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0222' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0222-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0223' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0223-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0224' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0224-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0226' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0226-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-HPSW-SLP-SLW0227' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-HPSW-SLP-SLW0227-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-LPSW-SPT-D0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-LPSW-SPT-D0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-PWRT' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-PWRT-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SPT-KV0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SPT-KV0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SPT-KV0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SPT-KV0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SPT-KV0004A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SPT-KV0004A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SPT-KV0004B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SPT-KV0004B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SPT-KV0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SPT-KV0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SSR-PRV841A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SSR-PRV841A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SSR-PRV841B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SSR-PRV841B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SSR-PRV841C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SSR-PRV841C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SSR-PSV2071A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SSR-PSV2071A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UAIR-SSR-PSV2071B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UAIR-SSR-PSV2071B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0072' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0072-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0073' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0073-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0074' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0074-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0075' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0075-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0076' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0076-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0079' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0079-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0080' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0080-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0081' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0081-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0082' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0082-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0083' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0083-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0084' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0084-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0085' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0085-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0086' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0086-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-UWTR-SLP-UW0087' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-UWTR-SLP-UW0087-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SIV-HV0827' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SIV-HV0827-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0044' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0044-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0052' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0052-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0065' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0065-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-COMS-SLP-PGB0070' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-COMS-SLP-PGB0070-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0205' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0205-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0219' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0219-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0222' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0222-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0230' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0230-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0237' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0237-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0240' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0240-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0250' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0250-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0260' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0260-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0267' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0267-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0270' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0270-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0277' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0277-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0280' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0280-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0286' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0286-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0441' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0441-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0547' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0547-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0550' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0550-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0560' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0560-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0561' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0561-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0562' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0562-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0567' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0567-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DBIT-SLP-P0594' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DBIT-SLP-P0594-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-DILU-SIL-D0776' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-DILU-SIL-D0776-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-FDTL-SIL-T0638' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-FDTL-SIL-T0638-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SIV-H0832' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SIV-H0832-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0222' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0222-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0230' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0230-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0234' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0234-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0240' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0240-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0244' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0244-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0250' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0250-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0254' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0254-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0260' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0260-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0264' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0264-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0270' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0270-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0274' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0274-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0280' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0280-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0284' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0284-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0325' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0325-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0326' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0326-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0327' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0327-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0328' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0328-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0524' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0524-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0560' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0560-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0561' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0561-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0565' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0565-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-IPSU-SLP-P0570' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-IPSU-SLP-P0570-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SIL-L0627A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SIL-L0627A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SIL-L0627B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SIL-L0627B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SIL-L0645B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SIL-L0645B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SIL-L0745A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SIL-L0745A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SIL-L0745B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SIL-L0745B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0332' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0332-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0333' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0333-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0337' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0337-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0338' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0338-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0342' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0342-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0347' and SiteId = 3 and Level = 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0347-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0348' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0348-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0528' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0528-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0530' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0530-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0533' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0533-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-PCYC-SLP-P0536' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-PCYC-SLP-P0536-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIL-L0667A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIL-L0667A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIL-L0685A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIL-L0685A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIL-L0767A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIL-L0767A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIL-L0767B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIL-L0767B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIL-L0785A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIL-L0785A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIS-L0664' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIS-L0664-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SIS-L0764' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SIS-L0764-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0352' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0352-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0353' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0353-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0357' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0357-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0358' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0358-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0362' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0362-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0363' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0363-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0367' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0367-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0368' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0368-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0538' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0538-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0540' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0540-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0541' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0541-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P087-SCYC-SLP-P0543' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P087-SCYC-SLP-P0543-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0071' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0071-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0072' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0072-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0073' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0073-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0074' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0074-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0075' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0075-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0076' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0076-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SAB-T0078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SAB-T0078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0039A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0039A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0039B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0039B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0040A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0040A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0040B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0040B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0045A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0045A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0051A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0051A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0051B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0051B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0052A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0052A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0052B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0052B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0053' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0053-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-BLDI-SCH-T0056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-BLDI-SCH-T0056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PLA0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PLA0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PLA0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PLA0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PLA0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PLA0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PLA0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PLA0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PR0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PR0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SEG-PR0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SEG-PR0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SIL-P4025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SIL-P4025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SIL-T4008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SIL-T4008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-COMS-SIL-T4009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-COMS-SIL-T4009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-FTT1-SES-PS0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-FTT1-SES-PS0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-FTT2-SES-PS0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-FTT2-SES-PS0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-FTT3-SES-PS0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-FTT3-SES-PS0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-HPSW-SIL-T4000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-HPSW-SIL-T4000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-IAIR-SIL-P4021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-IAIR-SIL-P4021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-IAIR-SIS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-IAIR-SIS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-IAIR-SPH-V0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-IAIR-SPH-V0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-LPSW-SPT-300Y-3A' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-LPSW-SPT-300Y-3A-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-LPSW-SPT-300Y-3B' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-LPSW-SPT-300Y-3B-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300ED-1' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300ED-1-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KC-1' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KC-1-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KC-2A' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KC-2A-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KC-2B' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KC-2B-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KV-1B' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KV-1B-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KV-2A' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KV-2A-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KV-2B' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KV-2B-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P300-UAIR-SPT-300KV-3' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P300-UAIR-SPT-300KV-3-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-SY02-SY02' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-SY02-SY02-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-SY04-SY04' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-SY04-SY04-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-SY05-SY05' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-SY05-SY05-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-WTRS-WTRE' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-WTRS-WTRE-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-WTRS-WTRW' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-WTRS-WTRW-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0019' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0019-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0022' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0022-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0037' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0037-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-BLDI-SAB-65TD041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-BLDI-SAB-65TD041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-SD08-SIV-LN15_SD08_KGVALVES' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-SD08-SIV-LN15_SD08_KGVALVES-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-SD08-SIV-LN16_SD08_KGVALVES' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-SD08-SIV-LN16_SD08_KGVALVES-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-TLGS-SD08-SIV-LN17_SD08_KGVALVES' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-TLGS-SD08-SIV-LN17_SD08_KGVALVES-%' and SiteId = 3 and Level > 5
GO


DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO

ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD

-- Drop the old proc if it exists
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP PROCEDURE [dbo].FunctionalLocationAddOrUndelete
	END
GO

CREATE Procedure [dbo].FunctionalLocationAddOrUndelete
  (
    @SiteId bigint,
    @Description VARCHAR(50),
    @FullHierarchy VARCHAR(90), 
    @PlantId bigint,
    @Level tinyint,
	@Culture VARCHAR(5)
  )
AS

IF NOT EXISTS(SELECT * FROM FunctionalLocation
  where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId)
  BEGIN
    INSERT INTO FunctionalLocation (
       SiteId, Description,FullHierarchy,OutOfService,Deleted
      ,[Level],PlantId,Culture
    ) VALUES (
       @SiteId   -- SiteId - bigint
      ,@Description  -- Description - varchar(50)
      ,@FullHierarchy  -- FullHierarchy - varchar(90)
      ,0  -- OutOfService - bit
      ,0  -- Deleted - bit
      ,@Level   -- Level - tinyint
      ,@PlantId   -- PlantId - bigint
	  ,@Culture -- Culture VARCHAR(5)
    )

    -- attach children to the newly added floc	
    INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
  	SELECT 
  		c.id, a.id, a.[Level]
  		FROM FunctionalLocation a
  		INNER JOIN FunctionalLocation c 
  			ON c.siteid = a.siteid and 
  			c.[Level] > a.[Level] and
   			a.Fullhierarchy like c.fullhierarchy + '-%'
  	where
        a.Id = IDENT_CURRENT('FunctionalLocation')
  	  and
  	  NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
    )

    -- attach parents to the newly added floc
  	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
  	SELECT 
  		c.id, a.id, a.[Level]
  		FROM FunctionalLocation a
  		INNER JOIN FunctionalLocation c 
  			ON c.siteid = a.siteid and 
  			c.[Level] > a.[Level] and
   			c.Fullhierarchy like a.fullhierarchy + '-%'
  		where
  			c.Id = IDENT_CURRENT('FunctionalLocation')
  			and
  			NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
    )

  END
  
  IF EXISTS(SELECT * FROM FunctionalLocation 
    where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1)
  BEGIN
    UPDATE FunctionalLocation
      SET 
      DELETED = 0,
      OutOfService = 0,
	  Description = @Description
    WHERE
      FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1
  END
GO

EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V ERR CABINETS',N'EX1-P004-COMS-SIC-04PJ-1111',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MCC CABINETS',N'EX1-P004-COMS-SIC-04PJ-1112',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V ERR CABINETS',N'EX1-P004-COMS-SIC-04PJ-1113',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MCC CABINETS',N'EX1-P004-COMS-SIC-04PJ-1116',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MCC CABINETS',N'EX1-P004-COMS-SIC-04PJ-1117',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MCC CABINETS',N'EX1-P004-COMS-SIC-04PJ-1118',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MCC CABINETS',N'EX1-P004-COMS-SIC-04PJ-1119',1200,6, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1007 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900A',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1007 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900B',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1008 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900C',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1008 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900D',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1009 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900E',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1009 HVAC AIR INTAKE H2S DETECTION',N'EX1-P004-IFST-SAB-RA0290-SIR-A1900F',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1007 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901A',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1007 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901B',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1008 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901C',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1008 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901D',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1009 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901E',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'4RH-1009 HVAC AIR INTAKE COMB GAS DETECT',N'EX1-P004-IFST-SAB-RA0290-SIR-A1901F',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT4 MCC BLDG S ENTRANCE OUTSIDE ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1902',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT 4 MCC BLDG W ENTRANCE INSIDE ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1903',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT4 MCC BLDG NW ENTRANC OUTSIDE ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1905',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT 4 MCC BLDG S INSIDE WALL ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1906',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT 4 MCC BLDG N INSIDE WALL ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1907',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT 4 MCC BLDG PLC ROOM INSIDE ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1908',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT4 MCC BLDG W ENTRANCE OUTSIDE ALARM',N'EX1-P004-IFST-SAB-RA0290-SIR-A1909',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-82-HT2',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-82-HT3',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-82-HT4',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-EHOUSE-COM1',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-EHOUSE-COM2',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-TR-A1',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-TR-A2',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-TR-B1',1200,7, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DELTA V MD PLUS CONTROLLER',N'EX1-PASS-DCS3-SIC-300-TR-B2',1200,7, N'EN';


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP PROCEDURE [dbo].FunctionalLocationAddOrUndelete
	END
GO

UPDATE dbo.FunctionalLocation SET Description = N'EAST MFT BARGE POND 7�UNIT HEATER #2', PlantId = 1200 where FullHierarchy = N'EX1-OPLT-BLDI-SAB-RH0059' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EXT. MTC SHOP WELDING BAY 1 TON HOIST', PlantId = 1200 where FullHierarchy = N'EX1-P003-BLDI-SCH-T0265' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'WESTFALIA FLOOR 4 TON HOIST CENTER BAY', PlantId = 1200 where FullHierarchy = N'EX1-P004-BLDI-SCH-T0100A' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'4G-71C DISCHARGE AUTO SAMPLER 04AS3014', PlantId = 1200 where FullHierarchy = N'EX1-P004-IPSU-SIV-AS3014' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'4G-71D DISCHARGE AUTO SAMPLER 04AS3015', PlantId = 1200 where FullHierarchy = N'EX1-P004-IPSU-SIV-AS3015' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'DOOR,�O/H #6 EAST EXTERIOR PLT 86', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RD0051' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'DOOR,�O/H #2 SOUTH EXTERIOR PLT 86', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RD0053' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'DOOR,�O/H #1 SOUTH EXTERIOR PLT 86', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RD0054' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED �EXHAUST FAN', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0118' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED �EXHAUST FAN', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0119' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED �EXHAUST FAN', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0120' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED �EXHAUST FAN', PlantId = 1200 where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0121' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'UPS RECTIFIER SOUTH BOOSTER PUMPHOUSE', PlantId = 1200 where FullHierarchy = N'EX1-P086-COMS-SEG-PU0509' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'UNIT HEATER�BASEBOARD ELEC WOMEN W/R 305', PlantId = 1200 where FullHierarchy = N'EX1-P300-BLDI-SAB-RH0092' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'UNIT HEATER BASEBOARD�ELEC OFFICE 304', PlantId = 1200 where FullHierarchy = N'EX1-P300-BLDI-SAB-RH0093' and SiteId = 3
GO

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (195, 'TRO Operator', 0, 'TROOperator', 3, 0, 0, 0, 1, 0, 'trooper');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (196, 'TRO Shift Supervisor', 0, 'TROShiftSupervisor', 3, 0, 0, 0, 1, 0, 'trosuper');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (197, 'TRO Manager / Superintendent', 0, 'TROManager', 3, 0, 0, 0, 1, 0, 'tromanager');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (198, 'TRO Administrator', 0, 'TROAdministrator', 3, 1, 0, 0, 0, 0, 'troadmin');

SET IDENTITY_INSERT [Role] OFF;

GO

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Manage Operational Modes';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Configure Automatic Re-Approval by Field';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Create Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Display Limits';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Auto Approve SAP Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Plant Historian Tag List';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Work Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Default FLOCs for Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Business Categories';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Associate Business Categories To Functional Locations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Log Guidelines';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Edit Shift Handover Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Summary Log Custom Fields';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Edit Log Templates';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Default Tabs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Work Assignment Not Selected Warning';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Unc Paths for Links';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Priorities Page';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Configure Site Communications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Administrator' and re.[Name] = 'Edit Shift Handover E-mail Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TRO Operator' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Directives - Future';
GO

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'TRO Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'TRO Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'TRO Manager / Superintendent')  

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'TRO Shift Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'TRO Shift Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Shift Supervisor' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'TRO Shift Supervisor')    
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'TRO Shift Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'TRO Shift Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'TRO Shift Supervisor')  
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'TRO Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'TRO Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)  
  (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 3 and createRole.[SiteId] = 3 and r.[Name] = 'TRO Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'TRO Manager / Superintendent')  
  
GO

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 2, 4, 3 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Operator'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 4, 8, 7 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Operator'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 6, 18, 17 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Operator'
GO

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 2, 2, 4 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 4, 10, 8 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 6, 18, 17 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Shift Supervisor'
GO

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 2, 4, 3 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 4, 8, 7 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 6, 18, 17 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Manager / Superintendent'
GO

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 2, 2, 3 FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Administrator'

INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT r.Id, 4, 7, null FROM dbo.[Role] r where r.SiteId = 3 and r.[Name] = 'TRO Administrator'
GO


GO




GO

