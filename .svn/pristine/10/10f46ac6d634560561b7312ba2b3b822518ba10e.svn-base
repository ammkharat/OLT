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

UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P-31-COMS-SPT-C0-86' and SiteId = 3 and Level = 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P-31-COMS-SPT-C0-86-%' and SiteId = 3 and Level > 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-PJ0069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-PJ0069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-PJ0070' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-PJ0070-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-PJ0087' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-PJ0087-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-XJC0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-XJC0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-XJC0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-XJC0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-XJC0040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-XJC0040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIC-XJC0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIC-XJC0045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIL-A0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIL-A0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIL-A0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIL-A0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIL-F0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIL-F0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIL-F4469' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIL-F4469-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIL-P1112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIL-P1112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIR-F0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIR-F0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-FD0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-FD0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-FD0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-FD0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-FD0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-FD0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-XJ0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-XJ0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-XJ0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-XJ0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-XJ0007A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-XJ0007A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-XJ0007B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-XJ0007B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SLE-XJ0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SLE-XJ0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SMF-K0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SMF-K0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SMF-K0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SMF-K0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SML' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SML-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SPH-F0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SPH-F0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0051' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0051-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0072' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0072-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0075' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0075-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0323' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0323-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0326' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0326-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0327' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0327-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0385A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0385A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0385B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0385B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0386A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0386A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV0386B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV0386B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1022' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1022-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1205A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1205A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1205B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1205B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1205C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1205C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1207A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1207A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV1207B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV1207B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV4078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV4078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL01-SSR-PSV4406' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL01-SSR-PSV4406-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-C0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-C0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-PJ0070' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-PJ0070-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-XJC0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-XJC0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-XJC0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-XJC0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-XJC0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-XJC0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIC-XJC0046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIC-XJC0046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-F0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-F0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-F0048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-F0048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-F0054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-F0054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-H0304' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-H0304-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-H0305' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-H0305-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-P0158' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-P0158-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIL-S4388' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIL-S4388-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0074' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0074-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0076' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0076-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0080' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0080-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0119' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0119-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0239' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0239-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-H0241' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-H0241-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-PCV0442' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-PCV0442-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV0513' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV0513-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV0514' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV0514-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV0515' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV0515-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV0516' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV0516-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV1254' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV1254-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SIV-XV1255' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SIV-XV1255-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-FD0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-FD0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-FD0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-FD0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-FD0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-FD0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-X0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-X0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-XJ0002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-XJ0002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-XJ0002B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-XJ0002B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLE-XJ0002C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLE-XJ0002C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SLP-PA_COOLINGWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SLP-PA_COOLINGWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SMF-K0002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SMF-K0002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SML' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SML-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SPH-E0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SPH-E0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SPH-E0162' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SPH-E0162-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SPH-F0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SPH-F0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SSR-PSV0325' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SSR-PSV0325-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL02-SSR-PSV1205B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL02-SSR-PSV1205B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SEG-PC0048A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SEG-PC0048A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SEG-PC0048B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SEG-PC0048B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SEH-D0064' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SEH-D0064-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SEH-D0065' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SEH-D0065-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-C0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-C0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-PJ0084' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-PJ0084-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-XJC0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-XJC0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-XJC0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-XJC0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-XJC0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-XJC0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIC-XJC0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIC-XJC0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-A0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-A0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-A0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-A0045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-A4186' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-A4186-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-F0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-F0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-F0049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-F0049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-F0055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-F0055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-P1127' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-P1127-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-T0381' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-T0381-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-T0382' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-T0382-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-T0391' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-T0391-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIL-T0392' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIL-T0392-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIR-A0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIR-A0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIR-A4128' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIR-A4128-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIR-A4171' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIR-A4171-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIR-A4186' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIR-A4186-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SIV-H0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SIV-H0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-FD0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-FD0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-FD0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-FD0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-FD0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-FD0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-T0093' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-T0093-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-T3001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-T3001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-XJ0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-XJ0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-XJ0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-XJ0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLE-XJ0012A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLE-XJ0012A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLP-PA_COOLINGAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLP-PA_COOLINGAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SLP-UA_ASPIRATINGAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SLP-UA_ASPIRATINGAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMF-K0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMF-K0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMF-K0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMF-K0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMF-K0090A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMF-K0090A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SML' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SML-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMP-G0037A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMP-G0037A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMP-G0037B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMP-G0037B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMP-G0037C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMP-G0037C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMP-G0178C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMP-G0178C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SMP-G0178D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SMP-G0178D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SPH-E0036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SPH-E0036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SPH-E0163' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SPH-E0163-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SPT-C0041I' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SPT-C0041I-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SPZ-T0005A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SPZ-T0005A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SPZ-T0005B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SPZ-T0005B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0053' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0053-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0071' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0071-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0074' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0074-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0080' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0080-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0261' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0261-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0261E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0261E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0261F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0261F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0266' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0266-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0266E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0266E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0266F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0266F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0291' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0291-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0328' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0328-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0329' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0329-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0385E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0385E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0385F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0385F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0386E' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0386E-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0386F' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0386F-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0687' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0687-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV0688' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV0688-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1305A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1305A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1305B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1305B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1306A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1306A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1306B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1306B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1307A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1307A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1307B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1307B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1309A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1309A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1309B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1309B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV1314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV1314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV4203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV4203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV4235' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV4235-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV4267' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV4267-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-BL03-SSR-PSV4297' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-BL03-SSR-PSV4297-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-HTC0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-HTC0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0011A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0011A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0013P' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0013P-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0113' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0113-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0119' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0119-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0121' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0121-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0122' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0122-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0123' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0123-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0124' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0124-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0125' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0125-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0127' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0127-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0128' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0128-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0129' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0129-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0131' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0131-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0132' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0132-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0133' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0133-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0134' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0134-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0135' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0135-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0136' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0136-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PA0137' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PA0137-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PB0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PB0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0146' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0146-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0148' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0148-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0149' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0149-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0156A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0156A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0156B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0156B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0157' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0157-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0158' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0158-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PH0159' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PH0159-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PJ0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PJ0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PJ0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PJ0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-PJ0379' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-PJ0379-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEG-UPS0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEG-UPS0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0019' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0019-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0022' and SiteId = 3 and Level = 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0022-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0037' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0037-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0043' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0043-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0044' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0044-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0048' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0048-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0049' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0049-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0051' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0051-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0052' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0052-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0053' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0053-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0057' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0057-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0058' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0058-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0063' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0063-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0064' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0064-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0065' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0065-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0067' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0067-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0068' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0068-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0070' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0070-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0071' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0071-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0072' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0072-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0091' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0091-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0115A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0115A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0115B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0115B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0115C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0115C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0135' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0135-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0136' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0136-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0137' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0137-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0138' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0138-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0139' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0139-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0140' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0140-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0142' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0142-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0143' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0143-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0144' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0144-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0147' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0147-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0150' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0150-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0151' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0151-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0152' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0152-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0153' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0153-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0154' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0154-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0161' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0161-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0162' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0162-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0163' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0163-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0164' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0164-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0167' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0167-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0168' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0168-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0169' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0169-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0170' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0170-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0171' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0171-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0172' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0172-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0173' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0173-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0174' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0174-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0177' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0177-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0178' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0178-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH0179' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH0179-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH2100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH2100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH2101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH2101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEH-PH2277' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEH-PH2277-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0004A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0004A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0004B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0004B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0005A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0005A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0005B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0005B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0006A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0006A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SEM-VFD0006B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SEM-VFD0006B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIC-PLC0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIC-PLC0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIC-PLC0900' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIC-PLC0900-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A0262' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A0262-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A0785' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A0785-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A1694' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A1694-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4170' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4170-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4171' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4171-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4637' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4637-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4640' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4640-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4676' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4676-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4677' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4677-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4719' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4719-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A4720' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A4720-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A5026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A5026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-A5506' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-A5506-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-DV0018A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-DV0018A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0019' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0019-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0178' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0178-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0654' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0654-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0964' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0964-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F0965' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F0965-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F1697' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F1697-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F3573' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F3573-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F4018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F4018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F4084' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F4084-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-F5533' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-F5533-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-H4621' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-H4621-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0075' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0075-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0076' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0076-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0131' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0131-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0151' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0151-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0711' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0711-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0736' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0736-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0737' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0737-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0778' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0778-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L0873' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L0873-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L3749' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L3749-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4678' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4678-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4753' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4753-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4769' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4769-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4867' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4867-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4871' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4871-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4872' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4872-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4873' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4873-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4878' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4878-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4890' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4890-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-L4893' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-L4893-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0001C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0001C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0019A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0019A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0019B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0019B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0019C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0019C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0024B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0024B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0242' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0242-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P024B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P024B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0313' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0313-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0701' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0701-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0827' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0827-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0974' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0974-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0977' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0977-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0978' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0978-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0979' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0979-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P0980' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P0980-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P2001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P2001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P2020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P2020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P2586' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P2586-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P4037' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P4037-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P4261' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P4261-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P4464' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P4464-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P4621' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P4621-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P5024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P5024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-P6066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-P6066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-PV0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-PV0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-PV0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-PV0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-PV0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-PV0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-PV0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-PV0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R2542' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R2542-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-R2543' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-R2543-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-S0608' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-S0608-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0019' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0019-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0063' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0063-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0067' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0067-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0068' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0068-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0213' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0213-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T0500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T0500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-T3800' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-T3800-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIL-W4172' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIL-W4172-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F0212' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F0212-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F0256' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F0256-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F0964' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F0964-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F0965' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F0965-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F2028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F2028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F3571' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F3571-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4702' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4702-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4703' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4703-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4732' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4732-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F4743' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F4743-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-F5530' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-F5530-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIR-T4858' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIR-T4858-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-F5023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-F5023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-H0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-H0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-H0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-H0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-H0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-H0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-H1687' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-H1687-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-HV0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-HV0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-HV0020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-HV0020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-HV4142' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-HV4142-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-HV5504' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-HV5504-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-K0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-K0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-K0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-K0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-K1694' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-K1694-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-K1695' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-K1695-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-K4024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-K4024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-L0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-L0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-L0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-L0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-L0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-L0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-L0800' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-L0800-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV_T0514' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV_T0514-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV0302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV0302-%' and SiteId = 3 and Level > 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV0911' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV0911-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4633' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4633-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4634' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4634-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4691' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4691-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4710' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4710-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4711' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4711-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV4857' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV4857-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV5024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV5024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV5508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV5508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV5513' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV5513-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PCV862' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PCV862-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0012C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0012C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0012D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0012D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0016A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0016A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0017B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0017B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0018A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0018A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0018B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0018B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0018C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0018C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0019A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0019A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0019B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0019B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0019C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0019C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0024A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0024A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0024B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0024B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0265A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0265A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0265B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0265B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0367A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0367A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0367B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0367B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0367C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0367C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-PV0367D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-PV0367D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0002B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0002B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0004A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0004A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0004B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0004B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0005A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0005A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0005B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0005B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0006A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0006A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0006B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0006B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0426A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0426A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SIV-TV0426B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SIV-TV0426B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-RO0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-RO0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-RO0087' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-RO0087-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-RO2548' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-RO2548-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-SP0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-SP0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-SP0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-SP0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-XJ0251' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-XJ0251-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-XJ0252' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-XJ0252-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-XJ0253' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-XJ0253-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-Y0101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-Y0101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-Y0102A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-Y0102A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLE-Y0102B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLE-Y0102B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SLP-MS_150LB_STEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SLP-MS_150LB_STEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0317' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0317-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0318' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0318-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0319' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0319-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0320' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0320-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0321' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0321-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0322' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0322-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0323' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0323-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMA-T0324' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMA-T0324-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-G0242' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-G0242-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0045A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0045A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0045B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0045B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0090A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0090A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMF-K0092' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMF-K0092-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-G0027A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-G0027A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-G0027B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-G0027B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-G0215' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-G0215-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-GT0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-GT0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-GT0027A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-GT0027A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0057' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0057-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0058' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0058-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-V0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-V0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPH-31V0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPH-31V0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPH-E0176' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPH-E0176-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-C0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-C0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-C0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-C0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-C0003C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-C0003C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-D0018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-D0018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-D0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-D0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-D0075' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-D0075-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-D0081' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-D0081-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-E0215' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-E0215-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-H0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-H0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-H0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-H0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-H0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-H0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0081' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0081-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0249' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0249-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0292' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0292-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0293' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0293-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0294' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0294-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0295' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0295-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0296' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0296-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0467A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0467A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPT-T0467B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPT-T0467B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SPZ-T0178' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SPZ-T0178-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PRV_T833' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PRV_T833-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PRV2565' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PRV2565-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0215' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0215-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0227' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0227-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0248' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0248-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0254' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0254-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0269' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0269-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0319' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0319-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0388' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0388-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0393' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0393-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0394' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0394-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0395' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0395-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0396' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0396-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0484' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0484-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0485' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0485-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0486' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0486-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0491' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0491-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0492' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0492-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0540' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0540-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0546A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0546A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0546B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0546B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0546C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0546C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0546D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0546D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0830' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0830-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0844' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0844-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0851' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0851-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0852' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0852-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0853' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0853-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0854' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0854-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0969' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0969-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV0991' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV0991-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV2537' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV2537-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV2641' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV2641-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV5524' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV5524-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SSR-PSV5525' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SSR-PSV5525-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SEG-T0014A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SEG-T0014A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SEG-T0014B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SEG-T0014B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0043' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0043-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0047' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0047-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0169' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0169-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F0223' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F0223-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F3580' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F3580-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4198' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4198-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4217' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4217-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4220' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4220-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4223' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4223-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4226' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4226-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4230' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4230-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4249' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4249-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4252' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4252-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4255' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4255-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4258' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4258-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4262' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4262-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4281' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4281-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4283' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4283-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4285' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4285-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4291' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4291-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4382' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4382-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-F4400' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-F4400-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-L0874' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-L0874-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-L0875' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-L0875-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-L2002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-L2002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-LSH_T0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-LSH_T0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0083' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0083-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0087' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0087-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0119' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0119-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0346' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0346-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0488' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0488-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P0652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P0652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P2013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P2013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4179' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4179-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4181' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4181-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4184' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4184-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4185' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4185-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4192' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4192-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4194' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4194-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4195' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4195-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4199' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4199-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4234' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4234-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4263' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4263-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4266' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4266-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4292' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4292-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4296' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4296-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4331' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4331-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4383' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4383-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4385' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4385-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4386' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4386-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4389' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4389-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4401' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4401-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4403' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4403-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-P4407' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-P4407-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-R00027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-R00027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-R0044' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-R0044-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-R0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-R0045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-T4384' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-T4384-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIL-T4402' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIL-T4402-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A2733' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A2733-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A2734' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A2734-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A2737' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A2737-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A2738' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A2738-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A4197' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A4197-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A4229' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A4229-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A4261' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A4261-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIR-A4290' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIR-A4290-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-F0084' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-F0084-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-H0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-H0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-HV_T0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-HV_T0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV_T0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV_T0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV_T0145A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV_T0145A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV_T0924' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV_T0924-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV0063' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV0063-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV0584' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV0584-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SIV-PCV3580' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SIV-PCV3580-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SLE-T0246' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SLE-T0246-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SLE-T0247' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SLE-T0247-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SLP-FG_FUELGAS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SLP-FG_FUELGAS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SMP-G0139A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SMP-G0139A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SMP-G0139B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SMP-G0139B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-C0028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-C0028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-D0071' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-D0071-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-D0080' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-D0080-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-T0308' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-T0308-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-T0332' and SiteId = 3 and Level = 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-T0332-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-T0333' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-T0333-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPT-T0334' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPT-T0334-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SPZ-Y0014A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SPZ-Y0014A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SSR-PSV4078' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SSR-PSV4078-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-FUEL-SSR-PSV4406' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-FUEL-SSR-PSV4406-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIC-C0026A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIC-C0026A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIL-F0190' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIL-F0190-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-PCV0435' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-PCV0435-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-PCV0436' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-PCV0436-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-PCV0437' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-PCV0437-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-PCV0438' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-PCV0438-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-PCV0441' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-PCV0441-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SIV-S0027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SIV-S0027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0022A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0022A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0022B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0022B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0022C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0022C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0022D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0022D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0157A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0157A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SPT-T0157B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SPT-T0157B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SSR-PRV_T0990' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SSR-PRV_T0990-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SSR-PRV_T0991' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SSR-PRV_T0991-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SSR-PSV0904' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SSR-PSV0904-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IAIR-SSR-PSV0905' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IAIR-SSR-PSV0905-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IFST-SAB-RA1465' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IFST-SAB-RA1465-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IFST-SAB-RA1465-SAS' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IFST-SAB-RA1465-SAS-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-IFST-SAB-RA1465-SAS-RF0015' and SiteId = 3 and Level = 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-IFST-SAB-RA1465-SAS-RF0015-%' and SiteId = 3 and Level > 7
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SIV-H0791' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SIV-H0791-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SIV-H0792' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SIV-H0792-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0113' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0113-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG01-SSR-PSV0118' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG01-SSR-PSV0118-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG02-SIV-H0793' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG02-SIV-H0793-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-TG02-SIV-H0794' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-TG02-SIV-H0794-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEG-PH6045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEG-PH6045-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6054' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6054-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6057' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6057-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6058' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6058-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6063' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6063-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6064' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6064-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6065' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6065-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6067' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6067-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6068' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6068-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6070' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6070-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SEH-PH6083' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SEH-PH6083-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COMS-SLP-UW_UTILITYWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COMS-SLP-UW_UTILITYWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SEG-PJ0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SEG-PJ0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-A06006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-A06006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-A06007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-A06007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-A6006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-A6006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-A6007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-A6007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-A6253' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-A6253-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-T6005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-T6005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SIL-T6006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SIL-T6006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SLP-CW_COOLINGWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SLP-CW_COOLINGWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SMF-K6004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SMF-K6004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-COTW-SPT-E6004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-COTW-SPT-E6004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-RPH2-SIL-L4000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-RPH2-SIL-L4000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P032-RPH2-SSR-PSV6135' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P032-RPH2-SSR-PSV6135-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-API4' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-API4-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCH' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCH-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCH-T0108A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCH-T0108A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCH-T0108B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCH-T0108B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCH-T0108C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCH-T0108C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCH-T0108D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCH-T0108D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SCT-BGE100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SCT-BGE100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-FOP0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-FOP0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-FOP0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-FOP0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0022' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0022-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PA0026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PA0026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB0002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB0002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB0002B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB0002B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PB002B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PB002B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PC0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PC0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PD0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PD0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PD0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PD0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PJ0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PJ0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PL0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PL0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PP0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PP0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PP0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PP0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PS0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PS0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PT0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PT0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-PZ0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-PZ0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-UPS0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-UPS0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-UPS001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-UPS001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-WR0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-WR0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-WR0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-WR0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-WR0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-WR0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEG-WR0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEG-WR0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1500' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1500-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1501' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1501-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1502' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1502-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1503' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1503-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1504' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1504-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1505' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1505-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1506' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1506-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1507' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1507-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1509' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1509-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1511' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1511-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1513' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1513-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1514' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1514-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1515' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1515-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1516' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1516-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1517' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1517-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1518' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1518-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1519' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1519-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1520' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1520-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1521' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1521-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1522' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1522-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1523' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1523-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1524' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1524-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1525' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1525-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1527' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1527-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1528' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1528-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1529' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1529-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1530' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1530-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1531' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1531-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1532' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1532-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1533' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1533-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1534' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1534-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1535' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1535-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1536' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1536-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1537' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1537-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1538' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1538-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1539' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1539-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1540' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1540-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1541' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1541-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1542' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1542-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1543' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1543-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1544' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1544-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1545' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1545-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1546' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1546-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1547' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1547-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1548' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1548-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1549' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1549-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1550' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1550-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1551' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1551-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1552' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1552-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1553' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1553-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1554' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1554-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1555' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1555-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1556' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1556-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1557' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1557-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1558' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1558-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1559' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1559-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1560' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1560-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1561' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1561-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1562' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1562-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1563' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1563-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1564' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1564-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1565' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1565-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1566' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1566-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1567' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1567-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1568' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1568-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1569' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1569-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1570' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1570-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1571' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1571-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1572' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1572-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1573' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1573-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1574' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1574-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1575' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1575-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1576' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1576-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1577' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1577-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1578' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1578-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1579' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1579-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1580' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1580-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1581' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1581-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1582' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1582-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1583' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1583-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1584' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1584-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1585' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1585-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1586' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1586-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1587' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1587-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1588' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1588-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1589' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1589-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1590' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1590-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1591' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1591-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SEH-PH1592' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SEH-PH1592-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIC' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIC-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIC-HMI0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIC-HMI0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIC-PLC0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIC-PLC0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A1002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A1002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A1003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A1003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A1004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A1004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A3001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A3001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A3002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A3002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-A3006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-A3006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1000-%' and SiteId = 3 and Level > 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1211' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1211-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F1300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F1300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2090' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2090-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F2091' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F2091-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F3003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F3003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F3004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F3004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F3005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F3005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F3101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F3101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-F3102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-F3102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-H1102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-H1102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-H1202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-H1202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-H1302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-H1302-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-K2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-K2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-K2004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-K2004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-K3101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-K3101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-K3102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-K3102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L1301' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L1301-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2020' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2020-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L2021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L2021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L3100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L3100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-L3101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-L3101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P02116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P02116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1206' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1206-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1305' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1305-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P1306' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P1306-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2018' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2018-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P2116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P2116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P3109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P3109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P3110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P3110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P4198' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P4198-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-P4205' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-P4205-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T02112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T02112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T06005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T06005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T1000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T1000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T1100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T1100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T1200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T1200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T1300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T1300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T2112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T2112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T3001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T3001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T3100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T3100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T3102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T3102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T3103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T3103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SIL-T6005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SIL-T6005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-BD_CAUSTIC' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-BD_CAUSTIC-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-BD_COAGULANT' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-BD_COAGULANT-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-BD_FLOCCULANT' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-BD_FLOCCULANT-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-BD_VAPOUR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-BD_VAPOUR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-IA_INSTRUMENTAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-IA_INSTRUMENTAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-K_CAUSTIC' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-K_CAUSTIC-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-K_COAGULANT' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-K_COAGULANT-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-K_FLOCCULANT' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-K_FLOCCULANT-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-M_MISCELLANEOUS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-M_MISCELLANEOUS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-PA_PROCESSAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-PA_PROCESSAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-PEW_EFFLUENTWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-PEW_EFFLUENTWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-RCW_RECYCLEDWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-RCW_RECYCLEDWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-TW_TREATEDCOOLINGWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-TW_TREATEDCOOLINGWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-UW_UTILITYWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-UW_UTILITYWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SLP-WW_WASTE WATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SLP-WW_WASTE WATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMA' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMA-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMA-T00120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMA-T00120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMA-T0120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMA-T0120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMA-T0310' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMA-T0310-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMF' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMF-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMF-K0210A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMF-K0210A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMF-K0210B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMF-K0210B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMF-K210B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMF-K210B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0100A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0100A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0100B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0100B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0100C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0100C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0110A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0110A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0110B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0110B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0120A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0120A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0120B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0120B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0130A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0130A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0130B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0130B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0200A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0200A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0200B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0200B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0200C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0200C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0300A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0300A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0300B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0300B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0300C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0300C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0310A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0310A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G0310B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G0310B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G100B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G100B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G130A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G130A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G200A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G200A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G200B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G200B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G200C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G200C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G300A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G300A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SMP-G300B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SMP-G300B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-C0201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-C0201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-C0203A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-C0203A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-C0203B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-C0203B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-C203A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-C203A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0130' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0130-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0200A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0200A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0200B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0200B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D0310' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D0310-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-D200B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-D200B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-KD0210' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-KD0210-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-KD210' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-KD210-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0200A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0200A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0200B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0200B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0200C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0200C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0200D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0200D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0201A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0201A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SPT-T0201B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SPT-T0201B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSA' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSA-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSA-V0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSA-V0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSA-V0101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSA-V0101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSE3107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSE3107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSE3108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSE3108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1203' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1203-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1216' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1216-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1302-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1303' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1303-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV1316' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV1316-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2103' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2103-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV2110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV2110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV3104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV3104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV3105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV3105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PSV4197' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PSV4197-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV1205' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV1205-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV1217' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV1217-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV1317' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV1317-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV3134' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV3134-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV3178' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV3178-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WAST-SSR-PVRV3179' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WAST-SSR-PVRV3179-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0023' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0023-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0024' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0024-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SEG-PJ0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SEG-PJ0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SIL-H1102' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SIL-H1102-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SIL-H1202' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SIL-H1202-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P034-WEST-SIL-H1302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P034-WEST-SIL-H1302-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0164' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0164-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0167' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0167-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0169A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0169A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0169B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0169B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0169C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0169C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0170A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0170A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0170B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0170B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0170C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0170C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0174' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0174-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0176' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0176-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0178A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0178A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0178B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0178B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0178C' and SiteId = 3 and Level = 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0178C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0179A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0179A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0179B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0179B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL12-SIV-XV0179C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL12-SIV-XV0179C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0264' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0264-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0267' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0267-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0269A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0269A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0269B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0269B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0269C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0269C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0270A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0270A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0270B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0270B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0270C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0270C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0274' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0274-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0276' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0276-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0278A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0278A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0278B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0278B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0278C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0278C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0279A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0279A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0279B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0279B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL13-SIV-XV0279C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL13-SIV-XV0279C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0469A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0469A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0469B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0469B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0469C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0469C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0478A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0478A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0478B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0478B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL14-SIV-XV0478C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL14-SIV-XV0478C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0569A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0569A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0569B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0569B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0569C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0569C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0578A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0578A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0578B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0578B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-BL15-SIV-XV0578C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-BL15-SIV-XV0578C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-COMS-SLP-BCW_BEARINGCOOLINGWATR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-COMS-SLP-BCW_BEARINGCOOLINGWATR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P035-COMS-SLP-LS_STEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P035-COMS-SLP-LS_STEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP1-SEG-PC0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP1-SEG-PC0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP2-SEG-PC0021' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP2-SEG-PC0021-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SIL-L0204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SIL-L0204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SIL-L0205' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SIL-L0205-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0026' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0026-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0027' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0027-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P036-ESP3-SSR-PSV0036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P036-ESP3-SSR-PSV0036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SLP-GSW_GYPSUMSLURRYWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SLP-GSW_GYPSUMSLURRYWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SLP-PEW_PONDEFFLUENTWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SLP-PEW_PONDEFFLUENTWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SSR-PSV0247' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SSR-PSV0247-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SSR-PSV0347' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SSR-PSV0347-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SSR-PSV0431' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SSR-PSV0431-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-FGDP-SSR-PSV0434' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-FGDP-SSR-PSV0434-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-GYPD-SEM-PU0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-GYPD-SEM-PU0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-GYPD-SEM-PU0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-GYPD-SEM-PU0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-GYPD-SIL-D0401' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-GYPD-SIL-D0401-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SIL-D0403' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SIL-D0403-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SIL-D0404' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SIL-D0404-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0013A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0013A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0013B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0013B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0064A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0064A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0064B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0064B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0066A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0066A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-LIPR-SPZ-T0066B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-LIPR-SPZ-T0066B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-SO2S-SPT-C0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-SO2S-SPT-C0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P037-SO2S-SPT-C0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P037-SO2S-SPT-C0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-F0151' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-F0151-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L0111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L0111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L0117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L0117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L0128' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L0128-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L0825' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L0825-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L2194' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L2194-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-L2196' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-L2196-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-P2192' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-P2192-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIL-Z2196' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIL-Z2196-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIR-F2800' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIR-F2800-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIR-F2801' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIR-F2801-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIR-F2802' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIR-F2802-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIR-T4858' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIR-T4858-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SIV-PCV2905' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SIV-PCV2905-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0008' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0008-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLE-Y0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLE-Y0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLP-ROW_REVERSE OSMOSIS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLP-ROW_REVERSE OSMOSIS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLP-ROW_REVERSEOSMOSIS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLP-ROW_REVERSEOSMOSIS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SLP-WW_WASTEWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SLP-WW_WASTEWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SMP-G0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SMP-G0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SMP-G0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SMP-G0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SMP-G0259A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SMP-G0259A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SMP-G0259B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SMP-G0259B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SSR-PSV2206' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SSR-PSV2206-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CHTR-SSR-YS2206' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CHTR-SSR-YS2206-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SEG-PA0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SEG-PA0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-A0602' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-A0602-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-F0650' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-F0650-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-F2046' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-F2046-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-K0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-K0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-K0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-K0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-L0143' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-L0143-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-L0800' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-L0800-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-L0801' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-L0801-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-L0821' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-L0821-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-L0832' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-L0832-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-P0889' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-P0889-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-P2050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-P2050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-P2192' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-P2192-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-R0917' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-R0917-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-R0918' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-R0918-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-R0919' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-R0919-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-R0920' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-R0920-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-R2181' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-R2181-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-T0951' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-T0951-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-T0952' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-T0952-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-T3002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-T3002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIL-T3003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIL-T3003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIR-F0651' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIR-F0651-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIR-F0652' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIR-F0652-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-F0651' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-F0651-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-H0744' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-H0744-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-K0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-K0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-K0013' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-K0013-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-K0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-K0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-K0015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-K0015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-PCV0891' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-PCV0891-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SIV-PCV0892' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SIV-PCV0892-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-FW_FIREWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-FW_FIREWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-K_CHEMICALS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-K_CHEMICALS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-LC_CONDENSATE' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-LC_CONDENSATE-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-LS_STEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-LS_STEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-RW_RAWWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-RW_RAWWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-UW_UTILITYWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-UW_UTILITYWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SLP-WW_WASTEWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SLP-WW_WASTEWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SMP-G0028C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SMP-G0028C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SMP-G0028D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SMP-G0028D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SMP-G0058' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SMP-G0058-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SMP-G0062' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SMP-G0062-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SSR-PSV2015' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SSR-PSV2015-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-CLAR-SSR-PSV2016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-CLAR-SSR-PSV2016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0002A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0002A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PA0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PA0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PC0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PC0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PH0001C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PH0001C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PH0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PH0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PH0113' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PH0113-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PH0114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PH0114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PH0160A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PH0160A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0006' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0006-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0016' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0016-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0017' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0017-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0018' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0018-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0204' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0204-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0213' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0213-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0227' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0227-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0228' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0228-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0230' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0230-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0234' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0234-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0235' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0235-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ-0291' and SiteId = 3 and Level = 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ-0291-%' and SiteId = 3 and Level > 6
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0011' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0011-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0012' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0012-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PJ0211' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PJ0211-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PL0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PL0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PL0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PL0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PL0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PL0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PS0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PS0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PS0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PS0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PS0004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PS0004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PS0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PS0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEG-PZ0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEG-PZ0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PAH0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PAH0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0001A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0001A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0001B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0001B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0006A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0006A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0006B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0006B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0008A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0008A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0008B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0008B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0008C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0008C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0009' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0009-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0010A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0010A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0010B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0010B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0010C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0010C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0010D' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0010D-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0029' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0029-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0030' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0030-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0031' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0031-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0032' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0032-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0033' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0033-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0037' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0037-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0051' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0051-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH0117' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH0117-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PH3004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PH3004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0106A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0106A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0106B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0106B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0110' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0110-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0111A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0111A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0111B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0111B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SEH-PHRTD0112' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SEH-PHRTD0112-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-A0262' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-A0262-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-A0785' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-A0785-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-L2886' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-L2886-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-L2887' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-L2887-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-P4464' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-P4464-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SIL-W4172' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SIL-W4172-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-SPT-D0057' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-SPT-D0057-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-STL' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-STL-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-STL-ANALYZER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-STL-ANALYZER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-STL-AT0140' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-STL-AT0140-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-STL-AT0141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-STL-AT0141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-COMS-STL-AT0143' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-COMS-STL-AT0143-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-A0138' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-A0138-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0142' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0142-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0405' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0405-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0425' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0425-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0445' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0445-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0465' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0465-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0485' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0485-%' and SiteId = 3 and Level > 5
GO
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0505' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0505-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0525' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0525-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C0545' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C0545-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C2125' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C2125-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C2140' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C2140-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-C2167' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-C2167-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0076' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0076-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0250' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0250-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0406' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0406-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0408' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0408-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0426' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0426-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0428' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0428-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0446' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0446-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0448' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0448-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0466' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0466-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0468' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0468-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0486' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0486-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0506' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0506-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0528' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0528-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0546' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0546-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0548' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0548-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F0688' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F0688-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F2120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F2120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F2122' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F2122-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F2133' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F2133-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-F2165' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-F2165-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-L0804' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-L0804-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-L0805' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-L0805-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-L0809' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-L0809-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-L0810' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-L0810-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P0135' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P0135-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P0140' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P0140-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P0871' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P0871-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P2111' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P2111-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P2146' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P2146-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-P2170' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-P2170-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-R0902' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-R0902-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-T0141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-T0141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-T0951' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-T0951-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIL-T0952' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIL-T0952-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0145' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0145-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0200' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0200-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0225' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0225-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0250' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0250-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0406' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0406-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0408' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0408-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0426' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0426-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0428' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0428-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0446' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0446-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0448' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0448-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0466' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0466-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0468' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0468-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0486' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0486-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0489' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0489-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0506' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0506-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0508' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0508-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0526' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0526-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0528' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0528-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0546' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0546-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F0548' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F0548-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F2120' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F2120-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F2122' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F2122-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F2133' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F2133-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F2164' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F2164-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIR-F2165' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIR-F2165-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0152' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0152-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0409' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0409-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0410' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0410-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0411' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0411-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0412' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0412-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0429' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0429-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0430' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0430-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0431' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0431-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0432' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0432-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0449' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0449-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0450' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0450-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0451' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0451-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0452' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0452-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0469' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0469-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0470' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0470-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0471' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0471-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0472' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0472-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0489' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0489-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0490' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0490-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0491' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0491-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0492' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0492-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0509' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0509-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0510' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0510-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0511' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0511-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0512' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0512-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0529' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0529-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0530' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0530-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0531' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0531-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0532' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0532-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0549' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0549-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0550' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0550-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0551' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0551-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K0552' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K0552-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2034' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2034-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2037' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2037-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2038' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2038-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2114' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2114-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2115' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2115-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2116' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2116-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2131' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2131-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2142' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2142-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2143' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2143-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2149' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2149-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2157' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2157-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2161' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2161-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2162' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2162-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-K2163' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-K2163-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-PCV2124' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-PCV2124-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-PCV2139' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-PCV2139-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SIV-PCV2166' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SIV-PCV2166-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-K_CHEMICALS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-K_CHEMICALS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-LS_STEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-LS_STEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-M_MISCELLANEOUS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-M_MISCELLANEOUS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-ROW_REVERSEOSMOSIS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-ROW_REVERSEOSMOSIS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-RW_RAWWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-RW_RAWWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-UA_UTILITYAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-UA_UTILITYAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SLP-WW_WASTEWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SLP-WW_WASTEWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SMP-G0003A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SMP-G0003A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-FITR-SMP-G0003B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-FITR-SMP-G0003B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-POTR-SIL-A3536' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-POTR-SIL-A3536-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-POTR-SIL-A3537' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-POTR-SIL-A3537-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-POTR-SIL-L2004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-POTR-SIL-L2004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-POTR-SIL-L2014' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-POTR-SIL-L2014-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-POTR-SPT-D0050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-POTR-SPT-D0050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SEG-PJ0226' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SEG-PJ0226-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0310' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0310-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0320' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0320-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0330' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0330-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0655' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0655-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F0656' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F0656-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F2059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F2059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F2091' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F2091-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-F2101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-F2101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0153' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0153-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0154' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0154-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0156' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0156-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0157' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0157-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0301' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0301-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0302-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0303' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0303-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0304' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0304-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0305' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0305-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0306' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0306-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0311' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0311-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0312' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0312-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0313' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0313-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0315' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0315-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0316' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0316-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0321' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0321-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0322' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0322-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0323' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0323-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0324' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0324-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0325' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0325-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0326' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0326-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0331' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0331-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0332' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0332-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0333' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0333-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0334' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0334-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0335' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0335-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K0336' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K0336-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2094' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2094-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2095' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2095-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2096' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2096-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2097' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2097-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2098' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2098-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2099' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2099-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2104' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2104-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2105' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2105-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2108' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2108-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-K2109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-K2109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-L0343' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-L0343-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-L0817' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-L0817-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-L0818' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-L0818-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-L2188' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-L2188-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-P2050' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-P2050-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-R0900' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-R0900-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-R0901' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-R0901-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S0344' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S0344-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S0345' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S0345-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S0348' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S0348-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S0349' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S0349-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S2055' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S2055-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S2056' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S2056-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-S2066' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-S2066-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIL-T0141' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIL-T0141-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F0300' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F0300-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F0310' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F0310-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F0320' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F0320-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F0330' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F0330-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F0341' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F0341-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F2059' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F2059-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F2091' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F2091-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F2101' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F2101-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIR-F4831' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIR-F4831-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIV-H0705' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIV-H0705-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIV-HV4899' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIV-HV4899-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIV-K0155' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIV-K0155-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SIV-PCV2166' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SIV-PCV2166-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-HS_HIGHPRESSURESTEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-HS_HIGHPRESSURESTEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-K_CHEMICALS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-K_CHEMICALS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-LS_STEAM' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-LS_STEAM-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-M_MISCELLANEOUS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-M_MISCELLANEOUS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-ROW_REVERSEOSMOSIS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-ROW_REVERSEOSMOSIS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-RW_RAWWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-RW_RAWWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-TW_TREATEDWATER' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-TW_TREATEDWATER-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SLP-UA_UTILITYAIR' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SLP-UA_UTILITYAIR-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P038-WTRT-SSR-PSV2093' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P038-WTRT-SSR-PSV2093-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P056-API5' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P056-API5-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-CC0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-CC0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-CC0002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-CC0002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-CC0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-CC0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-CC0005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-CC0005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-CC0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-CC0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-P4464' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-P4464-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-PJ0239' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-PJ0239-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-PJ0240' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-PJ0240-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-UCN10_APM_09_10' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-UCN10_APM_09_10-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-UCN10_HPM_05_06' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-UCN10_HPM_05_06-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-UCN11_HPM_43_44' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-UCN11_HPM_43_44-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS1-SIC-UCN11_HPM_45_46' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS1-SIC-UCN11_HPM_45_46-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS2' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS2-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS2-SIC' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS2-SIC-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-DCS2-SIC-CC0006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-DCS2-SIC-CC0006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0016' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0016-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0017' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0017-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0028' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0028-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0039' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0039-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-31XJC0044' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-31XJC0044-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-36XJC0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-36XJC0010-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-37XJC0007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-37XJC0007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-38XJC0100' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-38XJC0100-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-38XJC0501' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-38XJC0501-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-XJC0003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-XJC0003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-XJC0040' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-XJC0040-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-XJC0042' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-XJC0042-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-PASS-PLC1-SIC-XJC0045' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-PASS-PLC1-SIC-XJC0045-%' and SiteId = 3 and Level > 5
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

EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #1 COMBUSTION',N'EU1-P031-BL01-SIL-B0011',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #2 COMBUSTION',N'EU1-P031-BL01-SIL-B0012',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #3 COMBUSTION',N'EU1-P031-BL01-SIL-B0013',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #4 COMBUSTION',N'EU1-P031-BL01-SIL-B0014',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #5 COMBUSTION',N'EU1-P031-BL01-SIL-B0015',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #6 COMBUSTION',N'EU1-P031-BL01-SIL-B0016',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #7 COMBUSTION',N'EU1-P031-BL01-SIL-B0017',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER #8 COMBUSTION',N'EU1-P031-BL01-SIL-B0018',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FUEL OIL FLOW',N'EU1-P031-BL01-SIL-F0032',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FLOW CONTROL / ANALYSIS',N'EU1-P031-BL01-SIL-F0121',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 WET ASH FLOW FROM CLINKER GRINDER',N'EU1-P031-BL01-SIL-F0236',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDR UNIT COOLNG SUBSECTN SOLENOID VALVE',N'EU1-P031-BL01-SIL-F1200',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HAND CONTROL',N'EU1-P031-BL01-SIL-H0066',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HAND CONTROL',N'EU1-P031-BL01-SIL-H0068',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B BURNER',N'EU1-P031-BL01-SIL-H0070',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A BURNER',N'EU1-P031-BL01-SIL-H0072',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRIM. AIR FAN INLET',N'EU1-P031-BL01-SIL-H0114',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HAND CONTROL',N'EU1-P031-BL01-SIL-H0115',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER BARRIER',N'EU1-P031-BL01-SIL-H0230',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER BARRIER',N'EU1-P031-BL01-SIL-H0232',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 DRUM LEVEL',N'EU1-P031-BL01-SIL-L0026',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 LEVEL-STEAM DRUM LEVEL',N'EU1-P031-BL01-SIL-L0035',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A PULVERIZER LEVEL',N'EU1-P031-BL01-SIL-L0049',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 LEVEL-31T-3B PULVERIZER LEVEL',N'EU1-P031-BL01-SIL-L0050',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 PRESSURE-STEAM',N'EU1-P031-BL01-SIL-P0002',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 PRESSURE-MAIN STEAM HEADER',N'EU1-P031-BL01-SIL-P0005',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 F.D. FAN DISCHARGE',N'EU1-P031-BL01-SIL-P0057',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 ATOMIZING STEAM TO  BURNERS',N'EU1-P031-BL01-SIL-P0068',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 PRESSURE-FUEL OIL',N'EU1-P031-BL01-SIL-P0077',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A AUX. AIR SUPPLY',N'EU1-P031-BL01-SIL-P0125',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B SEAL AIR DIFF. PRESSURE',N'EU1-P031-BL01-SIL-P0126',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 PRESSURE-BOILER FEEDWATER',N'EU1-P031-BL01-SIL-P0131',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FURNACE PRESSURE',N'EU1-P031-BL01-SIL-P0155',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 STEAM PRESSURE',N'EU1-P031-BL01-SIL-P0161',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SECONDARY AIR HEATER DIFF. PRESSURE',N'EU1-P031-BL01-SIL-P0164',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 AIR HEATER GAS PRESSURE',N'EU1-P031-BL01-SIL-P0167',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A/4A CLASSIFIER PRESSURE',N'EU1-P031-BL01-SIL-P0170',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A CLASSIFIER PRESSURE',N'EU1-P031-BL01-SIL-P0171',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A CLASSIFIER PRESSURE',N'EU1-P031-BL01-SIL-P0172',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CLARIFIED WATER PUMP SUCTION PRESSURE',N'EU1-P031-BL01-SIL-P0173',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CLARIFIED WATER PUMP SUCTION PRESSURE',N'EU1-P031-BL01-SIL-P0174',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CLARIFIED WATER PUMP SUCTION PRESSURE',N'EU1-P031-BL01-SIL-P0175',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CLASSIFIER PRESS DIFFERENTIAL-BURNER 5',N'EU1-P031-BL01-SIL-P0176',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CLASSIFIER DIFF PRESS INDICATOR BRNR 6',N'EU1-P031-BL01-SIL-P0177',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A PULVERIZER PRESSURE',N'EU1-P031-BL01-SIL-P0194',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B PULVERIZER PRESSURE',N'EU1-P031-BL01-SIL-P0195',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-1A F.D. FAN DISCHARGE PRESSURE',N'EU1-P031-BL01-SIL-P0200',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-4A/B DISCHARGE PRESSURE',N'EU1-P031-BL01-SIL-P0201',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRESSURE CONTROL / ANALYSIS',N'EU1-P031-BL01-SIL-P0324',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 HYDROEJECTOR RUPTURE DISC',N'EU1-P031-BL01-SIL-P0914',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FEED TO JBR DAMPER DIFF PRESSURE',N'EU1-P031-BL01-SIL-P1101',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31KT-51 SUCTION PRESSURE',N'EU1-P031-BL01-SIL-P1102',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FEED GUILLOTINE PRESSURE',N'EU1-P031-BL01-SIL-P1104',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BYPASS GUILLOTINE  31FD-4 PRESSURE',N'EU1-P031-BL01-SIL-P1109',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRESSURE CONTROL / ANALYSIS',N'EU1-P031-BL01-SIL-P3801',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COMBUSTION/SCANNER AIR FAN 31K-93A/B',N'EU1-P031-BL01-SIL-P4038',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3-4-5-6 HEADER PRESSURE',N'EU1-P031-BL01-SIL-P4346',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3/4/5/6 HEADER PRESSURE',N'EU1-P031-BL01-SIL-P4347',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3/4/5/6 HEADER PRESSURE',N'EU1-P031-BL01-SIL-P4349',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3-4-5-6 HEADER PRESSURE',N'EU1-P031-BL01-SIL-P4359',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 1/2/7/8 HEADER PRESSURE',N'EU1-P031-BL01-SIL-P4468',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGN1-2-7-8 HEADER FLOW',N'EU1-P031-BL01-SIL-P4469',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COMBUSTION/SCANNER AIR FANS',N'EU1-P031-BL01-SIL-P4483',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 SPEED-31T-6C COKE FEEDER "C" FREQ',N'EU1-P031-BL01-SIL-S0012',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 SPEED-31T-6D COKE FEEDER "D" FREQ',N'EU1-P031-BL01-SIL-S0013',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31C-5J FILTER CLEAN BACKWASH WAT',N'EU1-P031-BL01-SIL-S0168',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31C-5J FILTER CLEAN BACKWASH SUB',N'EU1-P031-BL01-SIL-S0169',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A PULVERIZER LUBE OIL SUPPL',N'EU1-P031-BL01-SIL-S0254',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B PULVERIZER LUBE OIL SUPPL',N'EU1-P031-BL01-SIL-S0255',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER 1 FUEL OIL SOLENOID VALVE',N'EU1-P031-BL01-SIL-S0286',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER 4 FUEL OIL SOLENOID VALVE',N'EU1-P031-BL01-SIL-S0287',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER 5 FUEL OIL SOLENOID VALVE',N'EU1-P031-BL01-SIL-S0288',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNER 8 FUEL OIL SOLENOID VALVE',N'EU1-P031-BL01-SIL-S0289',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 ATOMIZING STEAM VALVE FREQUENCY',N'EU1-P031-BL01-SIL-S0298',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNR 4 ATOMIZING STEAM VALVE FREQ',N'EU1-P031-BL01-SIL-S0299',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNR 5 ATOMIZING STEAM VALVE FREQ',N'EU1-P031-BL01-SIL-S0300',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BURNR 8 ATOMIZING STEAM VALVE FREQ',N'EU1-P031-BL01-SIL-S0301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FD FAN 31KT-1A TURBINE SPEED',N'EU1-P031-BL01-SIL-S4136',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FD FAN 31KT-1B TURBINE SPEED',N'EU1-P031-BL01-SIL-S4137',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR IGNITORS 1/2/7/8 HEADER',N'EU1-P031-BL01-SIL-S4415',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR FG TO IGNITOR 1',N'EU1-P031-BL01-SIL-S4416',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR FG TO IGNITOR 8',N'EU1-P031-BL01-SIL-S4419',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FG TO IGNITOR 3 BLOCK VALVE',N'EU1-P031-BL01-SIL-S4421',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR FG TO IGNITOR 4',N'EU1-P031-BL01-SIL-S4422',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR FG TO IGNITOR 5',N'EU1-P031-BL01-SIL-S4423',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FG TO IGNITOR 6 BLOCK VALVE',N'EU1-P031-BL01-SIL-S4424',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TEMPERATURE CONTROL / ANALYSIS',N'EU1-P031-BL01-SIL-T0025',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC UNIT COOLING SUBSECTION',N'EU1-P031-BL01-SIL-T1201',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 LUBE OIL RESERVOIR TEMPERATURE',N'EU1-P031-BL01-SIL-T1223',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 BEARING OIL RESERVOIR TEMPERATURE',N'EU1-P031-BL01-SIL-T1225',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TURNING GEAR HEATER 31E-155 CONTROLLER',N'EU1-P031-BL01-SIL-T1231',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 TEMP.FLUE GAS AFTER ECONOMIZER',N'EU1-P031-BL01-SIL-T3800',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3-4-5-6 HEADER FLOW',N'EU1-P031-BL01-SIL-T4346',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN OUTBOARD BEARING',N'EU1-P031-BL01-SIL-V1201',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN INBOARD BEARING',N'EU1-P031-BL01-SIL-V1202',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN GEARBOX BEARING',N'EU1-P031-BL01-SIL-V1203',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN GEARBOX BEARING',N'EU1-P031-BL01-SIL-V1204',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN GEARBOX BEARING',N'EU1-P031-BL01-SIL-V1205',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN GEARBOX BEARING',N'EU1-P031-BL01-SIL-V1206',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN GEARBOX ACCELERATION',N'EU1-P031-BL01-SIL-V1207',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN TURBINE INBRD BEARING',N'EU1-P031-BL01-SIL-V1208',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN TURBINE OUTBRD BEARIN',N'EU1-P031-BL01-SIL-V1209',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN TURBINE THUST BEARING',N'EU1-P031-BL01-SIL-V1210',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN KEY PHAZER',N'EU1-P031-BL01-SIL-V1211',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-51 ID FAN TURBINE KEY PHAZER',N'EU1-P031-BL01-SIL-V1212',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FEED GUILLOTINE 31FD-10',N'EU1-P031-BL01-SIL-Z1104',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 I.D. FAN 31K-51 CONTROL',N'EU1-P031-BL01-SIL-Z1105',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31FD-7 JBR FEED DAMPER POSITION',N'EU1-P031-BL01-SIL-Z1106',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 JBR BYPASS (31FD-1 POSITION)',N'EU1-P031-BL01-SIL-Z1107',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BYPASS GUILLOTINE 31FD-4/4B',N'EU1-P031-BL01-SIL-Z1109',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 THERMOPROBE-POSITION',N'EU1-P031-BL01-SIL-Z3807',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 STEAM FLOW RATE',N'EU1-P031-BL01-SIR-F0001',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 BLOW DOWN FLOW',N'EU1-P031-BL01-SIR-F0019',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31KT-51 STEAM FLOW VORTEX FLOW METER',N'EU1-P031-BL01-SIR-F1105',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLOW-FUEL OIL',N'EU1-P031-BL01-SIR-F2000',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLOW-SECONDARY AIR BURNERS 1/2/3/4',N'EU1-P031-BL01-SIR-F3814',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLOW-RECIRC.AIR FLOW',N'EU1-P031-BL01-SIR-F3816',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLOW-OVERFIRE AIR BURNERS 1/2/3/4',N'EU1-P031-BL01-SIR-F3819',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FD FAN AIR FLOW',N'EU1-P031-BL01-SIR-F3835',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3-4-5-6 HEADER FLOW',N'EU1-P031-BL01-SIR-F4346',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HAND CONTROL',N'EU1-P031-BL01-SIV-H0111',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 HAND-BOILER FEEDWATER',N'EU1-P031-BL01-SIV-H0124',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-6A COKE FEEDER CONTROL',N'EU1-P031-BL01-SIV-H0300',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-6B COKE FEEDER CONTROL',N'EU1-P031-BL01-SIV-H0301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 ASH HANDLING SYSTEM',N'EU1-P031-BL01-SIV-H0576',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ASH HANDLING SYSTEM DRUM',N'EU1-P031-BL01-SIV-H4176',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FUEL OIL MIN. PRESS. REGULATOR',N'EU1-P031-BL01-SIV-PCV0062',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ATOMIZING STM MIN PRESS',N'EU1-P031-BL01-SIV-PCV0065',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FURNACE TV PURGE AIR',N'EU1-P031-BL01-SIV-PCV0435',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FURNACE TV PURGE AIR',N'EU1-P031-BL01-SIV-PCV0436',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FURNACE TV PURGE AIR',N'EU1-P031-BL01-SIV-PCV0437',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FURNACE TV PURGE AIR',N'EU1-P031-BL01-SIV-PCV0438',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITORS 3-4-5-6 HEADER PRESSURE',N'EU1-P031-BL01-SIV-PCV4358',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGN 1-2-7-8 HEADER PRESSURE',N'EU1-P031-BL01-SIV-PCV4400',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FEEDWATER BLOCK VALVE',N'EU1-P031-BL01-SIV-X3907',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL BACK UP TO 31T-3A BALLMILL',N'EU1-P031-BL01-SIV-X4087',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL RECYCLE TO 31D-60 OIL RESERVOIR',N'EU1-P031-BL01-SIV-X4088',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL BACK UP TO 31T-3B BALLMILL',N'EU1-P031-BL01-SIV-X4089',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL RECYCLE TO 31D-61 OIL RESERVOIR',N'EU1-P031-BL01-SIV-X4090',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDROEJECTOR BOILER 01',N'EU1-P031-BL01-SLE-H0010',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0192A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0192B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0193A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0193B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0198A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0198B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0199A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0199B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0204A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0204B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0205A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL FILTERS',N'EU1-P031-BL01-SLE-T0205B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID SUPPLY OIL FILTER',N'EU1-P031-BL01-SLE-T0232A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID SUPPLY OIL FILTER',N'EU1-P031-BL01-SLE-T0232B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRE-AIR FILTER RO L.O. PUMP (31T-3A)',N'EU1-P031-BL01-SLE-T0250',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AIR FILTER TO L.O. PUMP (31T-3A)',N'EU1-P031-BL01-SLE-T0251',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER, BALL MILL',N'EU1-P031-BL01-SLE-T0252',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRE-AIR FILTER RO L.O. PUMP (31T-3B)',N'EU1-P031-BL01-SLE-T0255',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AIR FILTER TO L.O. PUMP (31T-3B)',N'EU1-P031-BL01-SLE-T0256',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER, BALL MILL',N'EU1-P031-BL01-SLE-T0257',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0258A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0258B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0258C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0259A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0259B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0259C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO BOILER 1 TV CAM',N'EU1-P031-BL01-SLE-T0259D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FEED WATER PIPING',N'EU1-P031-BL01-SLP-BFW_BOILERFEEDWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COOLING WATER PIPING',N'EU1-P031-BL01-SLP-CW_COOLINGWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FUEL GAS PIPING',N'EU1-P031-BL01-SLP-FG_FUELGAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FUEL OIL PIPING',N'EU1-P031-BL01-SLP-FO_FUELOIL',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HIGH PRESSURE CONDENSATE PIPING',N'EU1-P031-BL01-SLP-HC_CONDENSATE',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HIGH PRESSURE STEAM PIPING',N'EU1-P031-BL01-SLP-HS_HIGHPRESSURESTEAM',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INSTRUMENT AIR PIPING',N'EU1-P031-BL01-SLP-IA_INSTRUMENTAIR',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ACID WASH PIPING',N'EU1-P031-BL01-SLP-K_ACIDWASH',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOW PRESSURE CONDENSATE PIPING',N'EU1-P031-BL01-SLP-LC_CONDENSATE',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL PIPING',N'EU1-P031-BL01-SLP-LO_LUBEOIL',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER ASH PIPING',N'EU1-P031-BL01-SLP-M_BOILERASH',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FLUE GAS DUCTING',N'EU1-P031-BL01-SLP-PD_FLUE_GAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'RAW WATER PIPING',N'EU1-P031-BL01-SLP-RW_RAWWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 I.D. FAN 31K-51 PURGE AIR UNIT',N'EU1-P031-BL01-SMF-K0086',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COMBUSTION/SCANNER AIR FAN BOILER 31F-1',N'EU1-P031-BL01-SMF-K0093A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COMBUSTION/SCANNER AIR FAN BOILER 31F-1',N'EU1-P031-BL01-SMF-K0093B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A HARVARD MODEL C-BPM 5GPM @ 1150 R',N'EU1-P031-BL01-SMP-G0150',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B HARVARD MODEL C-BPM 5GPM @ 1150 R',N'EU1-P031-BL01-SMP-G0151',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TRUNNION LIFT PUMP',N'EU1-P031-BL01-SMP-G0176A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TRUNNION LIFT PUMP',N'EU1-P031-BL01-SMP-G0176B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. PUMP FOR 31T-3A',N'EU1-P031-BL01-SMP-G0180',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'GEARBOX / L.O. PUMP FOR 31T-3A',N'EU1-P031-BL01-SMP-G0181',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MAIN L.O. PUMP 31KT-1A',N'EU1-P031-BL01-SMP-G0182',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MAIN L.O. PUMP 31KT-1B',N'EU1-P031-BL01-SMP-G0183',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. PUMP FOR 31T-3B BALL MILL',N'EU1-P031-BL01-SMP-G0185',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'GEARBOX / L.O. PUMP FOR 31T-3B',N'EU1-P031-BL01-SMP-G0218',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL COOLER',N'EU1-P031-BL01-SPH-E0019AN',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL COOLER',N'EU1-P031-BL01-SPH-E0019AS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL COOLER',N'EU1-P031-BL01-SPH-E0019BN',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL COOLER',N'EU1-P031-BL01-SPH-E0019BS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID RESERVOIR HEATER 1',N'EU1-P031-BL01-SPH-E0152A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID RESERVOIR HEATER 2',N'EU1-P031-BL01-SPH-E0152B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID RESERVOIR HEATER 3',N'EU1-P031-BL01-SPH-E0152C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DMP HYD SKID RESERVOIR HEATER NO. 4',N'EU1-P031-BL01-SPH-E0152D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AIR/H20 CONVERTER PRESSURE VESSEL 31F-1',N'EU1-P031-BL01-SPT-C0026A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMPER HYDRAULIC SKID ACCUMULATOR NO. 10',N'EU1-P031-BL01-SPT-C0039K',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. DRUM FOR 31T-3A',N'EU1-P031-BL01-SPT-C0044',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. DRUM FOR 31T-3B BALL MILL',N'EU1-P031-BL01-SPT-C0045',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3A LUBE OIL RESERVOIR 16 x 45.5" x 2',N'EU1-P031-BL01-SPT-D0060',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-3B LUBE OIL RESERVOIR 16 x 45.5" x 2',N'EU1-P031-BL01-SPT-D0061',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'OVERFLOW SEAL BOX',N'EU1-P031-BL01-SPT-D0072',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0311A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0311B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0311C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0311D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0312A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0312B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0312C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC FLOW DIVIDERS',N'EU1-P031-BL01-SPZ-T0312D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER #3 UPS PANEL',N'EU1-P031-BL03-SEG-PA_UPS_03A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER #3 UPS PANEL',N'EU1-P031-BL03-SEG-PA_UPS_03B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER #3 THIRD FLOOR UTILITY POWER',N'EU1-P031-BL03-SEG-PA0126',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #1 COMBUSTION',N'EU1-P031-BL03-SIL-B0031',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #2 COMBUSTION',N'EU1-P031-BL03-SIL-B0032',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #3 COMBUSTION',N'EU1-P031-BL03-SIL-B0033',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #4 COMBUSTION',N'EU1-P031-BL03-SIL-B0034',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #5 COMBUSTION',N'EU1-P031-BL03-SIL-B0035',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #6 COMBUSTION',N'EU1-P031-BL03-SIL-B0036',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #7 COMBUSTION',N'EU1-P031-BL03-SIL-B0037',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER #8 COMBUSTION',N'EU1-P031-BL03-SIL-B0038',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 1 COMBUSTION',N'EU1-P031-BL03-SIL-B4216',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FG MAIN HDR GAS DENSITY',N'EU1-P031-BL03-SIL-D4190',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 MAIN STEAM FLOW',N'EU1-P031-BL03-SIL-F0003',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FEEDWATER FLOW RATE',N'EU1-P031-BL03-SIL-F0006',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 AUTO VENT VALVE FLOW',N'EU1-P031-BL03-SIL-F0123',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 WET ASH FLOW FROM CLINKER GRINDER',N'EU1-P031-BL03-SIL-F0240',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDR UNIT COOLING SUBSECTION SOLEND VALV',N'EU1-P031-BL03-SIL-F1300',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SECONDARY AIR BURNERS 1/2/3/4 FLOW RATE',N'EU1-P031-BL03-SIL-F1757',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AIR FLOW TO BURNERS',N'EU1-P031-BL03-SIL-F1765',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRIM.AIR FAN OUTLET',N'EU1-P031-BL03-SIL-H0122',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRIM.AIR FAN INLET',N'EU1-P031-BL03-SIL-H0123',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BURNER BARRIER',N'EU1-P031-BL03-SIL-H0246',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BURNER BARRIER',N'EU1-P031-BL03-SIL-H0248',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 STEAM DRUM LEVEL',N'EU1-P031-BL03-SIL-L0037',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BALL MILL 31T-5A PULVERIZER LEVE',N'EU1-P031-BL03-SIL-L0053',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BALL MILL 31T-5B LEVEL',N'EU1-P031-BL03-SIL-L0054',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 STEAM DRUM PRESSURE',N'EU1-P031-BL03-SIL-P0004',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 F.D. FAN DISCHARGE',N'EU1-P031-BL03-SIL-P0059',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B AUX. AIR SUPPLY',N'EU1-P031-BL03-SIL-P0124',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FURNACE PRESSURE',N'EU1-P031-BL03-SIL-P0129',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BALL MILL 31T-5B SEAL AIR PRESSURE',N'EU1-P031-BL03-SIL-P0130',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 PRESSURE-BOILER FEEDWATER',N'EU1-P031-BL03-SIL-P0133',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FURNACE PRESSURE',N'EU1-P031-BL03-SIL-P0157',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 SOOTBLOWER STEAM SUPPLY PRESSURE',N'EU1-P031-BL03-SIL-P0163',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 SECONDARY AIR HEATER PRESSURE',N'EU1-P031-BL03-SIL-P0166',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AIR HEATER GAS PRESSURE DIFFERENTIAL',N'EU1-P031-BL03-SIL-P0169',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0186',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0187',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0188',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0189',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0190',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0191',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'331F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0192',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-2/3  BURNER CLASSIFIER PRESSURE',N'EU1-P031-BL03-SIL-P0193',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 CLASSIFIER BALL MILL 31T-5A PRESS',N'EU1-P031-BL03-SIL-P0198',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 CLASSIFIER BALL MILL 31T-5B',N'EU1-P031-BL03-SIL-P0199',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-6A/B PRIMARY AIR FAN DISCHARGE',N'EU1-P031-BL03-SIL-P0205',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A TRUNNION BEARING LUBE OIL',N'EU1-P031-BL03-SIL-P0215',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 SOOT BLOWER STEAM PRESSURE',N'EU1-P031-BL03-SIL-P0291',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 HYDROEJECTOR RUPTURE DISC',N'EU1-P031-BL03-SIL-P0912',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 PLV COKE & DRAFT SYSTEM',N'EU1-P031-BL03-SIL-P0920',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FGD FEED GUILLOTINE 31FD-12 PRESS',N'EU1-P031-BL03-SIL-P1124',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BYPASS GUILLOTINE 37FD-6 PRESSURE',N'EU1-P031-BL03-SIL-P1129',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 LUBE OIL PRESSURE',N'EU1-P031-BL03-SIL-P1310',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'NG MAKE-UP TO 31F-3 FG LINE',N'EU1-P031-BL03-SIL-P4178',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FG MAIN HDR SUPPLY PRESSURE',N'EU1-P031-BL03-SIL-P4181',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FG MAIN HDR GAS DENSITY',N'EU1-P031-BL03-SIL-P4192',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR1458 PRESS',N'EU1-P031-BL03-SIL-P4199',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR1458 PRESS LO',N'EU1-P031-BL03-SIL-P4201',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR1458 PRESSURE',N'EU1-P031-BL03-SIL-P4202',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR2367 LETDOWN PRESSURE',N'EU1-P031-BL03-SIL-P4231',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR2367 PRESS LO',N'EU1-P031-BL03-SIL-P4233',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR2367 PRESSURE',N'EU1-P031-BL03-SIL-P4234',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR1458  PRESSURE',N'EU1-P031-BL03-SIL-P4263',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR1458 PRESS LO',N'EU1-P031-BL03-SIL-P4265',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR1458  PRESSURE',N'EU1-P031-BL03-SIL-P4266',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR1458  PRESSURE',N'EU1-P031-BL03-SIL-P4269',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR2367 PRESSURE',N'EU1-P031-BL03-SIL-P4292',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR2367 PRESSURE',N'EU1-P031-BL03-SIL-P4296',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8A COKE FEEDER SPEED',N'EU1-P031-BL03-SIL-S0018',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8B COKE FEEDER SPEED',N'EU1-P031-BL03-SIL-S0019',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8C COKE FEEDE SPEED',N'EU1-P031-BL03-SIL-S0020',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8D COKE FEEDER SPEED',N'EU1-P031-BL03-SIL-S0021',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'IGNITOR OIL MAIN HDR',N'EU1-P031-BL03-SIL-S0022',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A LUBE OIL ON/OFF VALVE',N'EU1-P031-BL03-SIL-S0172',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B LUBE OIL ON/OFF VALVE',N'EU1-P031-BL03-SIL-S0173',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A PULVERIZER LUBE OIL 3-WAY VALVE',N'EU1-P031-BL03-SIL-S0258',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B TRUNNION BEARNG,LUBE OIL',N'EU1-P031-BL03-SIL-S0259',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31KT-3A TURBINE GOVERNOR SPEED',N'EU1-P031-BL03-SIL-S4140',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR1458 FREQUENCY',N'EU1-P031-BL03-SIL-S4205',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 1',N'EU1-P031-BL03-SIL-S4209',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 4',N'EU1-P031-BL03-SIL-S4211',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 5',N'EU1-P031-BL03-SIL-S4213',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 8',N'EU1-P031-BL03-SIL-S4215',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 2',N'EU1-P031-BL03-SIL-S4241',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 3',N'EU1-P031-BL03-SIL-S4243',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 6',N'EU1-P031-BL03-SIL-S4245',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 IGN 7',N'EU1-P031-BL03-SIL-S4247',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 BNR FG HDR1458',N'EU1-P031-BL03-SIL-S4268',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOOP FOR 31F-3 BNR FG HDR2367',N'EU1-P031-BL03-SIL-S4298',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BL#3,SUPERHEATER OUTLET',N'EU1-P031-BL03-SIL-T0019',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'POTABLE WATER FILTERS',N'EU1-P031-BL03-SIL-T0028',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31E-16B STEAM COIL AIR HEATER TEMP',N'EU1-P031-BL03-SIL-T0029',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 SECONDARY AIR TEMPERATURE',N'EU1-P031-BL03-SIL-T0082',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TEMPERATURE 31F-3 AIR HEATER GAS',N'EU1-P031-BL03-SIL-T0085',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TEMP LUBE OIL 31K-3A/B',N'EU1-P031-BL03-SIL-T0470',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDRAULIC POWER UNIT TEMPERATURE',N'EU1-P031-BL03-SIL-T1301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31KM53 INB BEARING TEMP',N'EU1-P031-BL03-SIL-T1308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31KM53 OTB BEARING TEMPERATURE',N'EU1-P031-BL03-SIL-T1309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 LUBE OIL RESERVOIR TEMPERATURE',N'EU1-P031-BL03-SIL-T1323',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 BEARING RESERVOIR TEMPERATURE',N'EU1-P031-BL03-SIL-T1325',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 BEARING RESERVOIR',N'EU1-P031-BL03-SIL-T1326',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 TURNING GEAR HEATER 31T-186 CONTR',N'EU1-P031-BL03-SIL-T1331',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TEMPERATURE 31F-3 ATTEMPERATOR FLOW',N'EU1-P031-BL03-SIL-T4320',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FGD FEED GUILLOTINE 31FD-12',N'EU1-P031-BL03-SIL-U1124',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BYPASS GUILLOTINE 31FD-6',N'EU1-P031-BL03-SIL-U1129',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-52/53 ID FAN OUTBOARD BEARING',N'EU1-P031-BL03-SIL-V1301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-52/53 ID FAN OUTBOARD BEARING',N'EU1-P031-BL03-SIL-V1302',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31K-53 ID FAN KEY PHAZER',N'EU1-P031-BL03-SIL-V1311',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FG MAIN HDR VENT/VALVE PIPING',N'EU1-P031-BL03-SIL-X4180',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 FGD FEED GUILLOTINE 31FD-12',N'EU1-P031-BL03-SIL-Z1124',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31FD-13C POSITION',N'EU1-P031-BL03-SIL-Z1125',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 1 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4216',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 1 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4218',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 4 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4219',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 4 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4221',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 5 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4222',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 5 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4224',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 8 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4225',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 8 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4227',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 2 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4248',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 2 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4250',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 3 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4251',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 3 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4253',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 6 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4254',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 6 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4256',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 7 ELECTRODE POSITION',N'EU1-P031-BL03-SIL-Z4257',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGNITOR 7 GAS GUN POSITION',N'EU1-P031-BL03-SIL-Z4259',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 1 POSITION',N'EU1-P031-BL03-SIL-Z4282',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 4 POSITION',N'EU1-P031-BL03-SIL-Z4284',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 5 POSITION',N'EU1-P031-BL03-SIL-Z4286',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 8 POSITION',N'EU1-P031-BL03-SIL-Z4288',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 2 POSITION',N'EU1-P031-BL03-SIL-Z4312',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 3 POSITION',N'EU1-P031-BL03-SIL-Z4314',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 6 POSITION',N'EU1-P031-BL03-SIL-Z4316',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BURNER 7 POSITION',N'EU1-P031-BL03-SIL-Z4318',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR1458 FLOW',N'EU1-P031-BL03-SIR-F4198',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 1 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4217',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 4 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4220',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 5 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4223',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 8 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4226',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN FG HDR2367 FLOW',N'EU1-P031-BL03-SIR-F4230',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 2 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4249',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 3 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4252',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 6 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4255',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 IGN 7 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4258',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR1458 FLOW',N'EU1-P031-BL03-SIR-F4262',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 1 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4281',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 4 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4283',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 5 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4285',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 8 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4287',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR FG HDR2367 FLOW',N'EU1-P031-BL03-SIR-F4291',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 2 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4311',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 3 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4313',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 6 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4315',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BNR 7 COOLING AIR FLOW',N'EU1-P031-BL03-SIR-F4317',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'3RD STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111A3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'3RD STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111B3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'3RD STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111C3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'3RD STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111D3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'1ST STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111E3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'1ST STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111F3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'1ST STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111G3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'1ST STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111H3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'2ND STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111J3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'2ND STAGE DUST COLLECTION',N'EU1-P031-BL03-SIV-HV0111K3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SEGREGATING VALVE',N'EU1-P031-BL03-SIV-HV0111L3',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BFW STARTUP VALVE ON/OFF VALVE',N'EU1-P031-BL03-SIV-HV0126',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8A COKE FEEDER CONTROL',N'EU1-P031-BL03-SIV-HV0308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8B COKE FEEDER CONTROL',N'EU1-P031-BL03-SIV-HV0309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8C COKE FEEDER CONTROL',N'EU1-P031-BL03-SIV-HV0310',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-8D COKE FEEDER CONTROL',N'EU1-P031-BL03-SIV-HV0311',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 HYDROEJECTOR VENT',N'EU1-P031-BL03-SIV-HV0574',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 1ST STAGE DRUM CONTROL VALVE',N'EU1-P031-BL03-SIV-HV4356A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 2ND STAGE DRUM CONTROL VALVE',N'EU1-P031-BL03-SIV-HV4356B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BOTTOM DRUM CONTROL VALVE',N'EU1-P031-BL03-SIV-HV4356C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BYPASS FURNACE TV PURGE AIR BOILER #3',N'EU1-P031-BL03-SIV-PCV_T220',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BYPASS FURNACE TV PURGE AIR BOILER #3',N'EU1-P031-BL03-SIV-PCV_T221',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'TURBINE END GOVR BEARING PRES REGULATOR',N'EU1-P031-BL03-SIV-PCV0609F',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FURNACE TV PURGE AIR BLR#3',N'EU1-P031-BL03-SIV-PCV0709',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FURNACE TV PURGE AIR BLR#3',N'EU1-P031-BL03-SIV-PCV0710',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'37K-53 LUBE OIL FILTER 31T-191B',N'EU1-P031-BL03-SIV-PCV1120',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'37K-53 LUBE OIL TEMPERATURE',N'EU1-P031-BL03-SIV-T1319',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'***DO NOT USED****',N'EU1-P031-BL03-SIV-T1700',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 ATTEMP. FW BLK VALVE',N'EU1-P031-BL03-SIV-XV1711',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-3 BFW TO ECONOMIZER VALVE',N'EU1-P031-BL03-SIV-XV3407',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B LUBE OIL BACKUP TO BALLMILL',N'EU1-P031-BL03-SIV-XV4094',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31D-65 LUBE OIL RECYCLE TO RESERVOIR',N'EU1-P031-BL03-SIV-XV4095',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A LUBE OIL BACK UP TO BALLMILL',N'EU1-P031-BL03-SIV-XV4096',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31D-64 LUBE OIL RECYCLE TO RESERVOIR',N'EU1-P031-BL03-SIV-XV4097',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ATTEMPERATOR FLOW UPSTREAM BLK',N'EU1-P031-BL03-SIV-XV4321',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDROEJECTOR BOILER 03',N'EU1-P031-BL03-SLE-H0012',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL CUNO MODL 1H2 25 MICRON',N'EU1-P031-BL03-SLE-T0196A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL CUNO MODL 1H2 25 MICRON',N'EU1-P031-BL03-SLE-T0196B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL CUNO MODL 1H2 25 MICRON',N'EU1-P031-BL03-SLE-T0197A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL CUNO MODL 1H2 25 MICRON',N'EU1-P031-BL03-SLE-T0197B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL  HARARD 0.5 MICRON',N'EU1-P031-BL03-SLE-T0202A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL  HARARD 0.5 MICRON',N'EU1-P031-BL03-SLE-T0202B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL  HARARD 0.5 MICRON',N'EU1-P031-BL03-SLE-T0203A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL  HARARD 0.5 MICRON',N'EU1-P031-BL03-SLE-T0203B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL PFA-20  10 MICRON',N'EU1-P031-BL03-SLE-T0208A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL PFA-20  10 MICRON',N'EU1-P031-BL03-SLE-T0208B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL PFA-20  10 MICRON',N'EU1-P031-BL03-SLE-T0209A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER LUBE OIL PFA-20  10 MICRON',N'EU1-P031-BL03-SLE-T0209B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMP HYDRAULIC SKID SUPPLY OIL FILTER 1',N'EU1-P031-BL03-SLE-T0234A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DAMP HYDRAULIC SKID SUPPLY OIL FILTER 2',N'EU1-P031-BL03-SLE-T0234B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRE-FILTER AIR  TO L.O. PUMP',N'EU1-P031-BL03-SLE-T0276',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER AIR TO L.O. PUMP TO 31T-5A',N'EU1-P031-BL03-SLE-T0277',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PRE-FILTER AIR  TO L.O. PUMP',N'EU1-P031-BL03-SLE-T0281',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FILTER AIR TO L.O. PUMP TO 31T-5B',N'EU1-P031-BL03-SLE-T0282',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER FOR 31T-5B',N'EU1-P031-BL03-SLE-T0283A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER FOR 31T-5B',N'EU1-P031-BL03-SLE-T0283B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER FOR 31T-5B',N'EU1-P031-BL03-SLE-T0283C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'L.O. STRAINER FOR 31T-5B',N'EU1-P031-BL03-SLE-T0283D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO 31F-3 TV CAM',N'EU1-P031-BL03-SLE-T0284A',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO 31F-3 TV CAM',N'EU1-P031-BL03-SLE-T0284B',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO 31F-3 TV CAM',N'EU1-P031-BL03-SLE-T0284C',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INLINE AIR FILTER TO 31F-3 TV CAM',N'EU1-P031-BL03-SLE-T0284D',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FEED WATER PIPING',N'EU1-P031-BL03-SLP-BFW_BOILERFEEDWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'COOLING WATER PIPING',N'EU1-P031-BL03-SLP-CW_COOLINGWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FUEL GAS PIPING',N'EU1-P031-BL03-SLP-FG_FUELGAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'FUEL OIL PIPING',N'EU1-P031-BL03-SLP-FO_FUELOIL',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HIGH PRESSURE CONDENSATE PIPING',N'EU1-P031-BL03-SLP-HC_CONDENSATE',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HIGH PRESSURE STEAM PIPING',N'EU1-P031-BL03-SLP-HS_HIGHPRESSURESTEAM',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INSTRUMENT AIR PIPING',N'EU1-P031-BL03-SLP-IA_INSTRUMENTAIR',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ACID WASH PIPING',N'EU1-P031-BL03-SLP-K_ACIDWASH',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LOW PRESSURE CONDENSATE PIPING',N'EU1-P031-BL03-SLP-LC_CONDENSATE',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'LUBE OIL PIPING',N'EU1-P031-BL03-SLP-LO_LUBEOIL',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER ASH PIPING',N'EU1-P031-BL03-SLP-M_BOILERASH',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDR OIL FRM 31T-287 TO SLUICEGATE DAMPR',N'EU1-P031-BL03-SLP-M2041',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HYDR OIL FROM ASH SLUICE TO 31C-26C',N'EU1-P031-BL03-SLP-M2042',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FLUE GAS DUCTING',N'EU1-P031-BL03-SLP-PD_FLUE_GAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'RAW WATER PIPING',N'EU1-P031-BL03-SLP-RW_RAWWATER',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CONDENSATE POT',N'EU1-P031-BL03-SPT-B0003_1',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'ACCUMULATOR DAMPER HYDRAULIC SKID',N'EU1-P031-BL03-SPT-C0041K',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'STEAM DRUM, BOILER #3',N'EU1-P031-BL03-SPT-C3000',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MUD DRUM, BOILER #3',N'EU1-P031-BL03-SPT-C3001',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'OVERFLOW SEAL BOX',N'EU1-P031-BL03-SPT-D0074',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A MAIN LUBE OIL PUMP DISCHARGE',N'EU1-P031-BL03-SSR-PRV_T796',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B MAIN LUBE OIL PUMP DISCHARGE',N'EU1-P031-BL03-SSR-PRV_T797',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5A TRUNNION LUBE OIL PUMP DISCHARGE',N'EU1-P031-BL03-SSR-PRV_T921',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31T-5B TRUNNION LUBE OIL PUMP DISCHARGE',N'EU1-P031-BL03-SSR-PRV_T922',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PLANT AIR AFTERFILTER',N'EU1-P031-IAIR-SPT-T0093',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1A - FIE',N'EU1-P036-ESP1-SEG-PR0100',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1A - FIE',N'EU1-P036-ESP1-SEG-PR0101',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1A - FIE',N'EU1-P036-ESP1-SEG-PR0102',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1A - FIE',N'EU1-P036-ESP1-SEG-PR0103',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1A - FIE',N'EU1-P036-ESP1-SEG-PR0104',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1B - FIE',N'EU1-P036-ESP1-SEG-PR0105',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1B - FIE',N'EU1-P036-ESP1-SEG-PR0106',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1B - FIE',N'EU1-P036-ESP1-SEG-PR0107',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1B - FIE',N'EU1-P036-ESP1-SEG-PR0108',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR 36V-1B - FIE',N'EU1-P036-ESP1-SEG-PR0109',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1A - FIELD "B',N'EU1-P036-ESP1-SEG-PT0100',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1A - FIELD "C',N'EU1-P036-ESP1-SEG-PT0101',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1A - FIELD "D',N'EU1-P036-ESP1-SEG-PT0102',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1A - FIELD "E',N'EU1-P036-ESP1-SEG-PT0103',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1A - FIELD "F',N'EU1-P036-ESP1-SEG-PT0104',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1B - FIELD "B',N'EU1-P036-ESP1-SEG-PT0105',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1B - FIELD "C',N'EU1-P036-ESP1-SEG-PT0106',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1B - FIELD "D',N'EU1-P036-ESP1-SEG-PT0107',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1B - FIELD "E',N'EU1-P036-ESP1-SEG-PT0108',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-1B - FIELD "F',N'EU1-P036-ESP1-SEG-PT0109',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A1 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0307',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A4 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1B1 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1B4 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0310',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A2 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0311',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A5 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0312',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1B2 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0313',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A3 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0315',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1A6 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0316',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1B3 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0317',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'36V-1B6 FLY ASH HOPPER DISCHARGE FLOW',N'EU1-P036-ESP1-SIL-F0318',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLY ASH TO HYDROVACTOR FLOW',N'EU1-P036-ESP1-SIL-F0353',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLY ASH TO HYDROVACTOR FLOW',N'EU1-P036-ESP1-SIL-F0354',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'31F-1 FLY ASH TO HYDROVACTOR FLOW',N'EU1-P036-ESP1-SIL-F0355',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FLUE GAS DUCTING',N'EU1-P036-ESP1-SLP-PD_FLUE_GAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CONTROL DIST. PANEL, 120V LOCATED IN 36P',N'EU1-P036-ESP3-SEG-PA0032',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3A - FIELD "C"',N'EU1-P036-ESP3-SEG-PJ0301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3A - FIELD "D"',N'EU1-P036-ESP3-SEG-PJ0302',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3A - FIELD "E"',N'EU1-P036-ESP3-SEG-PJ0303',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3A - FIELD "F"',N'EU1-P036-ESP3-SEG-PJ0304',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3B - FIELD "B"',N'EU1-P036-ESP3-SEG-PJ0305',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3B - FIELD "C"',N'EU1-P036-ESP3-SEG-PJ0306',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3B - FIELD "D"',N'EU1-P036-ESP3-SEG-PJ0307',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3B - FIELD "E"',N'EU1-P036-ESP3-SEG-PJ0308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'AVC SWBD. PPTR 36V-3B - FIELD "F"',N'EU1-P036-ESP3-SEG-PJ0309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HOPPER HEATING CONTROL PANEL PPTR 36V-3B',N'EU1-P036-ESP3-SEG-PJ0310',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'STANDBY HOPPER HEATING CONTRL PANEL PPTR',N'EU1-P036-ESP3-SEG-PJ0313',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'POWER HOUSE TIE-IN ELECTRIC HEAT TRACE C',N'EU1-P036-ESP3-SEG-PJ0314',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PPTRS 36V-3A/B SHUTDOWN RELAY BOX',N'EU1-P036-ESP3-SEG-PJ0321',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INSULATOR COMPT. MAIN H&V CONTROL PANEL',N'EU1-P036-ESP3-SEG-PJ0324',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'INSULATOR COMPT. MAIN H&V CONTROL PANEL',N'EU1-P036-ESP3-SEG-PJ0325',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HEATING XFMR,480-120/208V,15KVA IN PPTR',N'EU1-P036-ESP3-SEG-PL0031',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CONTROL XFMR. 480-120V 5KVA',N'EU1-P036-ESP3-SEG-PL0032',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DISTRIBUTION SWITCHBOARD 480V 1600A',N'EU1-P036-ESP3-SEG-PP0031',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'DISTRIBUTION SWITCHBOARD 480V 1600A',N'EU1-P036-ESP3-SEG-PP0032',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3A FIELD B',N'EU1-P036-ESP3-SEG-PR0300',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3A FIELD C',N'EU1-P036-ESP3-SEG-PR0301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3A FIELD D',N'EU1-P036-ESP3-SEG-PR0302',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3A FIELD E',N'EU1-P036-ESP3-SEG-PR0303',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3A FIELD F',N'EU1-P036-ESP3-SEG-PR0304',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3B FIELD B',N'EU1-P036-ESP3-SEG-PR0305',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3B FIELD C',N'EU1-P036-ESP3-SEG-PR0306',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3B FIELD D',N'EU1-P036-ESP3-SEG-PR0307',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3B FIELD E',N'EU1-P036-ESP3-SEG-PR0308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'SATURABLE CORE REACTOR PPTR V-3B FIELD F',N'EU1-P036-ESP3-SEG-PR0309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3A - FIELD B',N'EU1-P036-ESP3-SEG-PT0300',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3A - FIELD C',N'EU1-P036-ESP3-SEG-PT0301',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3A - FIELD D',N'EU1-P036-ESP3-SEG-PT0302',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3A - FIELD E',N'EU1-P036-ESP3-SEG-PT0303',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3A - FIELD F',N'EU1-P036-ESP3-SEG-PT0304',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3B - FIELD B',N'EU1-P036-ESP3-SEG-PT0305',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3B - FIELD C',N'EU1-P036-ESP3-SEG-PT0306',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3B - FIELD D',N'EU1-P036-ESP3-SEG-PT0307',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3B - FIELD E',N'EU1-P036-ESP3-SEG-PT0308',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'HV XFMR RECTIFIER PPTR 36V-3B - FIELD F',N'EU1-P036-ESP3-SEG-PT0309',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PPTR 36V-3A INSULATOR COMPARTMENT HEATER',N'EU1-P036-ESP3-SEH-PH0307',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'PPTR 36V-3B INSULATOR COMPT. MAIN HEATR',N'EU1-P036-ESP3-SEH-PH0312',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'BOILER FLUE GAS DUCTING',N'EU1-P036-ESP3-SLP-PD_FLUE_GAS',1060,5, N'EN';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'CONTROL SYSTEM & STATION',N'EU1-PASS-PLC1-SIC',1060,4, N'EN';

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP PROCEDURE [dbo].FunctionalLocationAddOrUndelete
	END
GO

UPDATE dbo.FunctionalLocation SET Description = N'LOOP-FLOW-OVERFIRE AIR BURNERS 5,6,7,8', PlantId = 1060 where FullHierarchy = N'EU1-P031-BL03-SIL-F1764' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'AVC SWBD. PPTR 36V-3A - FIELD "B"', PlantId = 1060 where FullHierarchy = N'EU1-P036-ESP3-SEG-PJ0300' and SiteId = 3
GO


GO

