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

-- Sarnia deletes
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-OFFS-TKFM-SIC-F03203' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-OFFS-TKFM-SIC-F03203-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SIC-L23051' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SIC-L23051-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SIC-L23052' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SIC-L23052-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SLE-23RV041' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SLE-23RV041-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SLE-23RV042' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SLE-23RV042-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SLE-23RV043' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SLE-23RV043-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SMP-23P016A' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SMP-23P016A-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SMP-23P016B' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SMP-23P016B-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SMP-23P017' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SMP-23P017-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SPT-23V006' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SPT-23V006-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SPT-23V007' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SPT-23V007-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT2-REF2-SPT-23V019' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT2-REF2-SPT-23V019-%' and SiteId = 1 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SR1-PLT3-GEN3-SLP-59960' and SiteId = 1 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SR1-PLT3-GEN3-SLP-59960-%' and SiteId = 1 and Level > 5


-- Denver Deletes
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0004-SIV-04PV211' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0004-SIV-04PV211-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0008-SPT-T33' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0008-SPT-T33-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0008-SSF-FA24' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0008-SSF-FA24-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0008-SSF-FA25' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0008-SSF-FA25-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0024-SPT-24H2410' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0024-SPT-24H2410-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0035-SIC-PLC67' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0035-SIC-PLC67-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0040-SIL-40F0729' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0040-SIL-40F0729-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD1' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD1-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD10' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD10-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD11' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD11-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD5' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD5-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD8' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD8-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0047-SSF-FSD9' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0047-SSF-FSD9-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0074-SLP-PC0420' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0074-SLP-PC0420-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0210-SLP-PC0995' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0210-SLP-PC0995-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0210-SSR-210PSV137' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0210-SSR-210PSV137-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH13' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH13-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH29' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH29-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH30' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH30-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH31' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH31-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH32' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH32-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH33' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH33-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH34' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH34-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH35' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH35-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH44' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH44-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'DN1-3003-0410-SSF-410FH45' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'DN1-3003-0410-SSF-410FH45-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TR3-RM05-GU00-SPT-FD0002' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TR3-RM05-GU00-SPT-FD0002-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TR3-RM05-GU00-SPT-FD0007' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TR3-RM05-GU00-SPT-FD0007-%' and SiteId = 2 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ZZZ-DN1-DN1-3003-0019' and SiteId = 2 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ZZZ-DN1-DN1-3003-0019-%' and SiteId = 2 and Level > 5

-- Energy services
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EU1-P031-COMS-SMP-G0130A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EU1-P031-COMS-SMP-G0130A-%' and SiteId = 3 and Level > 5


-- Extraction
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'BLR1-HVACSYS-ELEHTR-86RH1024' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'BLR1-HVACSYS-ELEHTR-86RH1024-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'BLR1-PIPESYS' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'BLR1-PIPESYS-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'BLR1-PIPESYS-RLFVLV' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'BLR1-PIPESYS-RLFVLV-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'BLR1-PIPESYS-RLFVLV-86PSV3331' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'BLR1-PIPESYS-RLFVLV-86PSV3331-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'BLR1-PIPESYS-RLFVLV-86PSV3332' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'BLR1-PIPESYS-RLFVLV-86PSV3332-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL-BLDC' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-BLDC-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL-BLDI' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-BLDI-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL-TOOL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-TOOL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL-TOOL-STE' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-TOOL-STE-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-FACL-TOOL-STE-ELEC_SAFETY_EQUIPMENT' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-FACL-TOOL-STE-ELEC_SAFETY_EQUIPMENT-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-COMS-SMP-G0084A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-COMS-SMP-G0084A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P004-IPSU-SLE-T0093A' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P004-IPSU-SLE-T0093A-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-F0372' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-F0372-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-H0381' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-H0381-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-H0830' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-H0830-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-H0831' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-H0831-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P016-FDTL-SIL-Z0381' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P016-FDTL-SIL-Z0381-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12NBPHDISCH' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12NBPHDISCH-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12NBPHFEED' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12NBPHFEED-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12NBPHMIDS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12NBPHMIDS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12SBPHDISCH' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12SBPHDISCH-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12SBPHFEED' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12SBPHFEED-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SLP-86PTP12SBPHMIDS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SLP-86PTP12SBPHMIDS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SMP-G0090' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SMP-G0090-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SMP-G0091' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SMP-G0091-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SMP-G0092' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SMP-G0092-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SMP-G0107' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SMP-G0107-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P086-FTT1-SMP-G0109' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P086-FTT1-SMP-G0109-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-REPR-REPR' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-REPR-REPR-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'EX1-P501-SLWS-SLWE' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'EX1-P501-SLWS-SLWE-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'PH03-INSLOOP-FLOWSY-86F3214' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'PH03-INSLOOP-FLOWSY-86F3214-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'PH03-INSLOOP-PRESSY-86P3058' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'PH03-INSLOOP-PRESSY-86P3058-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'REPR' and SiteId = 3 and Level = 1
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'REPR-%' and SiteId = 3 and Level > 1
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'REPR-PUMPSYS' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'REPR-PUMPSYS-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'REPR-PUMPSYS-PMSKID' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'REPR-PUMPSYS-PMSKID-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PIPING-SLW_SEALWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PIPING-SLW_SEALWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PMPSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PMPSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PMPSYS-501G46' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PMPSYS-501G46-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PMPSYS-501G47' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PMPSYS-501G47-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-PMPSYS-501G48' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-PMPSYS-501G48-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-TANKVS-501D4000' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-TANKVS-501D4000-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8AZONE-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8AZONE-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PIPING-SLW_SEALWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PIPING-SLW_SEALWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PMPSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PMPSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PMPSYS-501G50' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PMPSYS-501G50-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PMPSYS-501G51' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PMPSYS-501G51-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PMPSYS-81G95' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PMPSYS-81G95-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-PMPSYS-81G96' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-PMPSYS-81G96-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-TANKVS-501D85' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-TANKVS-501D85-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SLWE-P8BZONE-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SLWE-P8BZONE-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-DAMPER' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-DAMPER-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-DAMPER-86RH1007' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-DAMPER-86RH1007-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-DAMPER-86RH1021' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-DAMPER-86RH1021-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-ELEHTR' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-ELEHTR-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-ELEHTR-86RH1084' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-ELEHTR-86RH1084-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB1-HVACSYS-ELEHTR-86RH1085' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB1-HVACSYS-ELEHTR-86RH1085-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-AIRCON' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-AIRCON-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-AIRCON-86RH1019' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-AIRCON-86RH1019-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-DAMPER' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-DAMPER-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-DAMPER-86RH1022' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-DAMPER-86RH1022-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-ELEHTR' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-ELEHTR-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-ELEHTR-86RH1082' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-ELEHTR-86RH1082-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-HVACSYS-ELEHTR-86RH1083' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-HVACSYS-ELEHTR-86RH1083-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SUB2-INSLOOP' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SUB2-INSLOOP-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-INJECT' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-INJECT-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-INJECT-501SP2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-INJECT-501SP2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-INJECT-501SP2602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-INJECT-501SP2602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-INJECT-501SP2603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-INJECT-501SP2603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-INJECT-501SP2604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-INJECT-501SP2604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-MIXERS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-MIXERS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-MIXERS-501SP2605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-MIXERS-501SP2605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-MIXERS-501SP2606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-MIXERS-501SP2606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-MIXERS-501SP2607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-MIXERS-501SP2607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-MIXERS-501SP2608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-MIXERS-501SP2608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-DRYAREA-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-DRYAREA-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PMPSYS-501G10' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PMPSYS-501G10-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PMPSYS-501G11' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PMPSYS-501G11-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PMPSYS-501G9' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PMPSYS-501G9-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PRESRL-501PSE2001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PRESRL-501PSE2001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-PRESRL-501PSE2002' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-PRESRL-501PSE2002-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-TANKVS-01D87' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-TANKVS-01D87-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-TANKVS-501D5' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-TANKVS-501D5-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV226' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV226-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV236' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV236-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV287A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV287A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV287B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV287B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV288A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV288A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV288B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV288B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV289A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV289A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV289B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV289B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV290A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV290A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV290B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV290B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV291A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV291A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-MFTPROC-VALVES-501HV291B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-MFTPROC-VALVES-501HV291B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501C15' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501C15-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501C5' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501C5-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501C6' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501C6-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501K2602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501K2602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501K2603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501K2603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501K2604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501K2604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-AIRSYS-501KV2001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-AIRSYS-501KV2001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PMPSYS-501G2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PMPSYS-501G2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PMPSYS-501G2602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PMPSYS-501G2602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PMPSYS-501G2603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PMPSYS-501G2603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PMPSYS-501G2604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PMPSYS-501G2604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PMPSYS-501G2605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PMPSYS-501G2605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2613' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2613-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2615' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2615-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2616' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2616-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2617' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2617-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2618' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2618-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2619' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2619-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2620' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2620-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2621' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2621-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PRESRL-501PSV2622' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PRESRL-501PSV2622-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501K2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501K2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2604D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2604D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-PROCEQ-501T2605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-PROCEQ-501T2605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-01D15' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-01D15-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-01D16' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-01D16-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501D2604D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501D2604D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501Y2601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501Y2601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-TANKVS-501Y2601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-TANKVS-501Y2601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-VALVES-501HV2600' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-VALVES-501HV2600-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-VALVES-501HV2601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-VALVES-501HV2601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-VALVES-501HV2604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-VALVES-501HV2604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-POLYSUP-VALVES-501HV2605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-POLYSUP-VALVES-501HV2605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-PRESRL-501PSE2003' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-PRESRL-501PSE2003-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-TANKVS-501D12' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-TANKVS-501D12-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-TANKVS-501D13' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-TANKVS-501D13-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-TANKVS-501D34' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-TANKVS-501D34-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY02-WATRSYS-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY02-WATRSYS-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-INJECT-501SP4607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-INJECT-501SP4607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4610' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4610-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4611' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4611-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4612' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4612-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4613' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4613-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-MIXERS-501SP4614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-MIXERS-501SP4614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-DRYAREA-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-DRYAREA-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-PMPSYS-501G4001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-PMPSYS-501G4001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-PMPSYS-501G4002' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-PMPSYS-501G4002-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-TANKVS-501D28' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-TANKVS-501D28-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-TANKVS-501D29' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-TANKVS-501D29-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-TANKVS-501D30' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-TANKVS-501D30-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-TANKVS-501D31' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-TANKVS-501D31-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4026' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4026-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4036' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4036-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4087A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4087A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4087B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4087B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4088A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4088A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4088B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4088B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4089A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4089A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4089B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4089B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4090A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4090A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4090B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4090B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4091A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4091A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-MFTPROC-VALVES-501HV4091B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-MFTPROC-VALVES-501HV4091B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501C1' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501C1-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501C2' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501C2-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501C3' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501C3-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501K4602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501K4602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501K4603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501K4603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501K4604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501K4604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-AIRSYS-501KV4001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-AIRSYS-501KV4001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-LIFTNG' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-LIFTNG-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-LIFTNG-501T4606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-LIFTNG-501T4606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PIPING-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PIPING-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4601C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4601C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PMPSYS-501G4603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PMPSYS-501G4603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4627' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4627-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4628' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4628-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4629' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4629-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4633' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4633-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4634' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4634-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4635' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4635-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4636' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4636-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4637' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4637-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4638' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4638-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4639' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4639-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4640' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4640-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4641' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4641-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PRESRL-501PSV4642' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PRESRL-501PSV4642-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501K4601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501K4601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4603C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4603C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4604D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4604D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-PROCEQ-501T4605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-PROCEQ-501T4605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501D4604D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501D4604D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-TANKVS-501Y4603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-TANKVS-501Y4603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4600' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4600-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4612' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4612-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-POLYSUP-VALVES-501HV4615' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-POLYSUP-VALVES-501HV4615-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT-VALVES-501HV28' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-VALVES-501HV28-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-RETNWAT-VALVES-501HV29' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-RETNWAT-VALVES-501HV29-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-PRESRL-501PSE4003' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-PRESRL-501PSE4003-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-TANKVS-501D19' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-TANKVS-501D19-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-TANKVS-501D25' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-TANKVS-501D25-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-TANKVS-501D26' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-TANKVS-501D26-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-TANKVS-501D27' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-TANKVS-501D27-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4001A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4001A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4001B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4001B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4002A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4002A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4002B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4002B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4003A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4003A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4003B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4003B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4004A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4004A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY04-WATRSYS-VALVES-501HV4004B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY04-WATRSYS-VALVES-501HV4004B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5613' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5613-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-INJECT-501SP5614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-INJECT-501SP5614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5610' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5610-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5611' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5611-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5612' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5612-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5615' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5615-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-MIXERS-501SP5616' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-MIXERS-501SP5616-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PRESRL-501PSE5036' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PRESRL-501PSE5036-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PRESRL-501PSE5082' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PRESRL-501PSE5082-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-PRESRL-501PSE5083' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-PRESRL-501PSE5083-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-DRYAREA-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-DRYAREA-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-LIFTNG' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-LIFTNG-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-LIFTNG-501T-5001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-LIFTNG-501T-5001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-LIFTNG-501T-5002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-LIFTNG-501T-5002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5000' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5000-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5002' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5002-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5003' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5003-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5004' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5004-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PMPSYS-501G5005' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PMPSYS-501G5005-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PRESRL-501PSE5080' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PRESRL-501PSE5080-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-PRESRL-501PSE5081' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-PRESRL-501PSE5081-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-TANKVS-501D43' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-TANKVS-501D43-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5026' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5026-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5028' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5028-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5036' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5036-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5037' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5037-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5087A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5087A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5087B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5087B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5088A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5088A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5088B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5088B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5089A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5089A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5089B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5089B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5090A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5090A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5090B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5090B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5091A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5091A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5091B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5091B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5092A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5092A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5092B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5092B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5093A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5093A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5093B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5093B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5094A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5094A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5094B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5094B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5095A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5095A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5095B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5095B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5096A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5096A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5096B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5096B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5097A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5097A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5097B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5097B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5098A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5098A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5098B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5098B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5099A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5099A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-MFTPROC-VALVES-501HV5099B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-MFTPROC-VALVES-501HV5099B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501C10' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501C10-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501C13' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501C13-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501C9' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501C9-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501K5602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501K5602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501K5603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501K5603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-AIRSYS-501KV5001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-AIRSYS-501KV5001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-LIFTNG' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-LIFTNG-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-LIFTNG-501T5606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-LIFTNG-501T5606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-LIFTNG-501T5607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-LIFTNG-501T5607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PIPING-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PIPING-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5601C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5601C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PMPSYS-501G5603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PMPSYS-501G5603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5610' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5610-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PRESRL-501PSV5611' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PRESRL-501PSV5611-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501K5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501K5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5603C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5603C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5605A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5605A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5605B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5605B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5605C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5605C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-PROCEQ-501T5605D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-PROCEQ-501T5605D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5603C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5603C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501D5603D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501D5603D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-TANKVS-501Y5603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-TANKVS-501Y5603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5600' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5600-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5612' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5612-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-POLYSUP-VALVES-501HV5615' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-POLYSUP-VALVES-501HV5615-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-TANKVS-501D46' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-TANKVS-501D46-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-TANKVS-501D47' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-TANKVS-501D47-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-VALVES-501HV10A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-VALVES-501HV10A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-VALVES-501HV10B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-VALVES-501HV10B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-VALVES-501HV11A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-VALVES-501HV11A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-RETNWAT-VALVES-501HV11B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-RETNWAT-VALVES-501HV11B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-PRESRL-501PSE5048' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-PRESRL-501PSE5048-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-TANKVS-501D41' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-TANKVS-501D41-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-TANKVS-501D44' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-TANKVS-501D44-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-VALVES-501HV5001A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-VALVES-501HV5001A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-VALVES-501HV5001B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-VALVES-501HV5001B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-VALVES-501HV5001C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-VALVES-501HV5001C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY05-WATRSYS-VALVES-501HV5001D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY05-WATRSYS-VALVES-501HV5001D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT-501SP6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-501SP6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT-501SP6602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-501SP6602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT-501SP6603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-501SP6603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT-501SP6604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-501SP6604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-INJECT-501SP6605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-INJECT-501SP6605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS-501SP6606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-501SP6606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS-501SP6607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-501SP6607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS-501SP6608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-501SP6608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS-501SP6609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-501SP6609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-MIXERS-501SP6610' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-MIXERS-501SP6610-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PRESRL-501PSE6082' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PRESRL-501PSE6082-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-PRESRL-501PSE6083' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-PRESRL-501PSE6083-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-DRYAREA-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-DRYAREA-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-LIFTNG' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-LIFTNG-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-LIFTNG-501T6001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-LIFTNG-501T6001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-LIFTNG-501T6002' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-LIFTNG-501T6002-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PIPING-M_MFTSLURRY' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PIPING-M_MFTSLURRY-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6000' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6000-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6002' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6002-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6003' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6003-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6004' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6004-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PMPSYS-501G6005' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PMPSYS-501G6005-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PRESRL-501PSE6080' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PRESRL-501PSE6080-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-PRESRL-501PSE6081' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-PRESRL-501PSE6081-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-TANKVS-501D53' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-TANKVS-501D53-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6026' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6026-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6027' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6027-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6036' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6036-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6037' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6037-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6087A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6087A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6087B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6087B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6088A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6088A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6088B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6088B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6089A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6089A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6089B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6089B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6090A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6090A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6090B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6090B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6091A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6091A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6091B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6091B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6092A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6092A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6092B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6092B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6093A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6093A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6093B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6093B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6094A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6094A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6094B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6094B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6095A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6095A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6095B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6095B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6096A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6096A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6096B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6096B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6097A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6097A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6097B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6097B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6098A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6098A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6098B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6098B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6099A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6099A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-MFTPROC-VALVES-501HV6099B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-MFTPROC-VALVES-501HV6099B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501C11' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501C11-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501C12' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501C12-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501C14' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501C14-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501K6602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501K6602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501K6603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501K6603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-AIRSYS-501KV6001' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-AIRSYS-501KV6001-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-LIFTNG' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-LIFTNG-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-LIFTNG-501T6606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-LIFTNG-501T6606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-LIFTNG-501T6607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-LIFTNG-501T6607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PIPING-K_CHEMICALS' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PIPING-K_CHEMICALS-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6601C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6601C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PMPSYS-501G6603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PMPSYS-501G6603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6603' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6603-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6605' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6605-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6610' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6610-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PRESRL-501PSV6611' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PRESRL-501PSV6611-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501K6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501K6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6602' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6602-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6603C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6603C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6604A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6604A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6604B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6604B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6604C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6604C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6605A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6605A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6605B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6605B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6605C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6605C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-PROCEQ-501T6605D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-PROCEQ-501T6605D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6602C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6602C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6603C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6603C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501D6603D' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501D6603D-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6601A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6601A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6601B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6601B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6602A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6602A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6602B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6602B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6603A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6603A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-TANKVS-501Y6603B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-TANKVS-501Y6603B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6600' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6600-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6601' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6601-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6604' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6604-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6606' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6606-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6607' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6607-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6608' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6608-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6609' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6609-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6612' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6612-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6614' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6614-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-POLYSUP-VALVES-501HV6615' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-POLYSUP-VALVES-501HV6615-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-PIPING' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-PIPING-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-PIPING-PW_PROCESSWATER' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-PIPING-PW_PROCESSWATER-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-TANKVS-501D50' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-TANKVS-501D50-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-TANKVS-501D51' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-TANKVS-501D51-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-TANKVS-501D52' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-TANKVS-501D52-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6001A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6001A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6001B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6001B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6002A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6002A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6002B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6002B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6003A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6003A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6003B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6003B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6004A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6004A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY06-WATRSYS-VALVES-501HV6004B' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY06-WATRSYS-VALVES-501HV6004B-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-RETNWAT' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-RETNWAT-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-RETNWAT-PMPSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-RETNWAT-PMPSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-RETNWAT-PMPSYS-501G64' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-RETNWAT-PMPSYS-501G64-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-RETNWAT-PMPSYS-501G65' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-RETNWAT-PMPSYS-501G65-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-WATRSYS' and SiteId = 3 and Level = 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-WATRSYS-%' and SiteId = 3 and Level > 2
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-WATRSYS-PMPSYS' and SiteId = 3 and Level = 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-WATRSYS-PMPSYS-%' and SiteId = 3 and Level > 3
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'SY07-WATRSYS-PMPSYS-501G33' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'SY07-WATRSYS-PMPSYS-501G33-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-HVACSYS-SUPFAN-86RK1017A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-HVACSYS-SUPFAN-86RK1017A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-HVACSYS-SUPFAN-86RK1017C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-HVACSYS-SUPFAN-86RK1017C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3055' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3055-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3091' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3091-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3106' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3106-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3191' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3191-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3193' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3193-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3255' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3255-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3295' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3295-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-PRESSU-86P3296' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-PRESSU-86P3296-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-TEMPSY-86T3117' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-TEMPSY-86T3117-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-INSLOOP-TEMPSY-86T3118' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-INSLOOP-TEMPSY-86T3118-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-PIPING-TFT1_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-PIPING-TFT1_PIPING-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3202' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3202-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3203' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3203-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3204' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3204-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3205' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3205-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3206' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3206-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3207' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3207-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3247' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3247-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT1-PIPESYS-VALVES-86HV3248' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT1-PIPESYS-VALVES-86HV3248-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-DEICSYS-THRSTR-86T1024E' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-DEICSYS-THRSTR-86T1024E-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-DEICSYS-THRSTR-86T1024F' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-DEICSYS-THRSTR-86T1024F-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-HVACSYS-AIRCON-86RH1046A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-HVACSYS-AIRCON-86RH1046A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-HVACSYS-SUPFAN-86RK1018A' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-HVACSYS-SUPFAN-86RK1018A-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-HVACSYS-SUPFAN-86RK1018C' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-HVACSYS-SUPFAN-86RK1018C-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3148' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3148-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3200' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3200-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3202' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3202-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3241' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3241-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3257' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3257-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3297' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3297-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3298' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3298-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-PRESSU-86P3348' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-PRESSU-86P3348-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-TEMPSY-86T3119' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-TEMPSY-86T3119-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-TEMPSY-86T3120' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-TEMPSY-86T3120-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-INSLOOP-TEMPSY-86T3130' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-INSLOOP-TEMPSY-86T3130-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-PIPING-TFT2_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-PIPING-TFT2_PIPING-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3210' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3210-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3211' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3211-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3212' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3212-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3213' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3213-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3214' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3214-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3215' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3215-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3249' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3249-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT2-PIPESYS-VALVES-86HV3250' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT2-PIPESYS-VALVES-86HV3250-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3096' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3096-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3097' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3097-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3211' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3211-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3213' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3213-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3215' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3215-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3216' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3216-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3217' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3217-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3218' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3218-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3259' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3259-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3299' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3299-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3300' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3300-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-PRESSU-86P3313' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-PRESSU-86P3313-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-TEMPSY-86T3121' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-TEMPSY-86T3121-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-INSLOOP-TEMPSY-86T3122' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-INSLOOP-TEMPSY-86T3122-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-PIPING-TFT3_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-PIPING-TFT3_PIPING-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3218' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3218-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3219' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3219-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3220' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3220-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3221' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3221-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3222' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3222-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3223' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3223-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3251' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3251-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'TFT3-PIPESYS-VALVES-86HV3252' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'TFT3-PIPESYS-VALVES-86HV3252-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR1-INSLOOP-PRESSU-86P3223' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR1-INSLOOP-PRESSU-86P3223-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR1-PIPESYS-PIPING-WATER1_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR1-PIPESYS-PIPING-WATER1_PIPING-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR2-INSLOOP-PRESSU-86P3262' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR2-INSLOOP-PRESSU-86P3262-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR2-PIPESYS-PIPING-WATER2_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR2-PIPESYS-PIPING-WATER2_PIPING-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR3-INSLOOP-PRESSU-86P3266' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR3-INSLOOP-PRESSU-86P3266-%' and SiteId = 3 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'WTR3-PIPESYS-PIPING-WATER3_PIPING' and SiteId = 3 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'WTR3-PIPESYS-PIPING-WATER3_PIPING-%' and SiteId = 3 and Level > 4

-- Mining (none to delete)

--Upgrading
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-COMS-SSR-PSV0852' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-COMS-SSR-PSV0852-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SIV-H0301' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SIV-H0301-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SIV-H0302' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SIV-H0302-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SSR-PSV0088' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SSR-PSV0088-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SSR-PSV0089' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SSR-PSV0089-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SSR-PSV0096' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SSR-PSV0096-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-DRU1-SSR-PSV0164' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-DRU1-SSR-PSV0164-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SIV-H0106' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SIV-H0106-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SSR-PSV0025' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SSR-PSV0025-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SSR-PSV0059B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SSR-PSV0059B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SSR-PSV0059C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SSR-PSV0059C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SSR-PSV0077' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SSR-PSV0077-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-FRC1-SSR-PSV0465' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-FRC1-SSR-PSV0465-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-GRU1-SSR-PSV0041' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-GRU1-SSR-PSV0041-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-GRU1-SSR-PSV0065' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-GRU1-SSR-PSV0065-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P005-GRU1-SSR-PSV0068' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P005-GRU1-SSR-PSV0068-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P007-KHU1-SIV-H0088' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P007-KHU1-SIV-H0088-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P007-NHU1-SIV-H0087' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P007-NHU1-SIV-H0087-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P008-AMN1-SSR-PSV0517' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P008-AMN1-SSR-PSV0517-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0204' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0204-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0246' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0246-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0254' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0254-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0256' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0256-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0258' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0258-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0270' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0270-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0273' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0273-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0278' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0278-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0279' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0279-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SIV-H0301' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SIV-H0301-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-NTF1-SSR-PSV0937' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-NTF1-SSR-PSV0937-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-STF1-SIV-H0314' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-STF1-SIV-H0314-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P021-STF1-SSR-PSV0781' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P021-STF1-SSR-PSV0781-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P025-VAC1-SSR-PSV0933' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P025-VAC1-SSR-PSV0933-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P032-CWTR-SSR-PSV6049C' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P032-CWTR-SSR-PSV6049C-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP1-P032-CWTR-SSR-PSV6135' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP1-P032-CWTR-SSR-PSV6135-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-COMS-SSR-PSV1941' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-COMS-SSR-PSV1941-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SIV-H2201' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SIV-H2201-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SIV-H3504' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SIV-H3504-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV1000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV1000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV1001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV1001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3000' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3000-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3001' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3001-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3006' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3006-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3007' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3007-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3069' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3069-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3807' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3807-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3808' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3808-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV3918' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV3918-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DCU2-SSR-PSV5548B' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DCU2-SSR-PSV5548B-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1802' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1802-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1805' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1805-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1806' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1806-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1808' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1808-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1809' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1809-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1819' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1819-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1821' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1821-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1825' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1825-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1827' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1827-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1832' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1832-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1836' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1836-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1843' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1843-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1844' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1844-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1848' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1848-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1867' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1867-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1874' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1874-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1875' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1875-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-DRU3-SSR-PSV1889' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-DRU3-SSR-PSV1889-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SIV-X3581' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SIV-X3581-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SIV-X3582' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SIV-X3582-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SIV-X3583' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SIV-X3583-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SSR-PSV2035' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SSR-PSV2035-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SSR-PSV2036' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SSR-PSV2036-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-FRC2-SSR-PSV5524' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-FRC2-SSR-PSV5524-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-GRU2-SSR-PSV1871' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-GRU2-SSR-PSV1871-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P052-GRU2-SSR-PSV5556' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P052-GRU2-SSR-PSV5556-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P054-RFR2-SSR-PSV0060' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P054-RFR2-SSR-PSV0060-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P054-RFR2-SSR-PSV0061' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P054-RFR2-SSR-PSV0061-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P056-PPL2-SIV-H1207' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P056-PPL2-SIV-H1207-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P056-WAT1-SSR-PSV7002' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P056-WAT1-SSR-PSV7002-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P056-WAT1-SSR-PSV7003' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P056-WAT1-SSR-PSV7003-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P056-WAT1-SSR-PSV7004' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P056-WAT1-SSR-PSV7004-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P056-WAT1-SSR-PSV7005' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P056-WAT1-SSR-PSV7005-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P057-VAC2-SIV-X1073' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P057-VAC2-SIV-X1073-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P066-COMS-SIL-P1123' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P066-COMS-SIL-P1123-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-P066-RFR3-SIL-F1044' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-P066-RFR3-SIL-F1044-%' and SiteId = 3 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'UP2-PASS-SIS2-SIC-XU0010' and SiteId = 3 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'UP2-PASS-SIS2-SIC-XU0010-%' and SiteId = 3 and Level > 5


-- Firebag
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-EV90001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-EV90001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-EV99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-EV99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-EV99002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-EV99002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV91003' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV91003-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92101' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92101-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92102' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92102-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92103' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92103-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92104' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92104-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92105' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92105-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92201' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92201-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92202' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92202-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-HV92203' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-HV92203-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-KV9006' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-KV9006-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV9001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV9001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV9002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV9002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV9003' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV9003-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV9004' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV9004-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV9005' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV9005-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIL-XV99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIL-XV99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91E90001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91E90001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91E99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91E99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91E99002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91E99002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91F92501' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91F92501-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91F92601' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91F92601-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91H92203' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91H92203-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91L91001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91L91001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91P93404' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91P93404-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91P99008' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91P99008-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91T91001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91T91001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-91X99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-91X99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-EV90001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-EV90001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-EV99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-EV99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-EV99002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-EV99002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV91002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV91002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV91003' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV91003-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92101' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92101-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92102' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92102-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92103' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92103-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92104' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92104-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92105' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92105-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92201' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92201-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92202' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92202-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-HV92203' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-HV92203-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-KV9006' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-KV9006-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-P9053' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-P9053-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-P9058' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-P9058-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-P9060' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-P9060-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-P9062' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-P9062-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-X9000' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-X9000-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV9001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV9001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV9002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV9002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV9003' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV9003-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV9004' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV9004-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV9005' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV9005-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SIV-XV99001' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SIV-XV99001-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SSF-91Z91002' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SSF-91Z91002-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-0900-SSF-91Z91003' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-0900-SSF-91Z91003-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-9000-SIL-91F9000' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-9000-SIL-91F9000-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-9000-SIL-91F9019' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-9000-SIL-91F9019-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-9000-SIV-91F9000' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-9000-SIV-91F9000-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FBOP-9000-SIV-91F9019' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FBOP-9000-SIV-91F9019-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-10281' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-10281-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-10435' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-10435-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11386' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11386-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11438' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11438-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11439' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11439-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11440' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11440-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11441' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11441-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11465' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11465-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11597' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11597-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11612' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11612-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11624' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11624-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11628' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11628-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11666' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11666-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11671' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11671-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11701' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11701-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11702' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11702-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11703' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11703-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11704' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11704-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11705' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11705-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11706' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11706-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11707' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11707-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11708' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11708-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-11709' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-11709-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-14169' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-14169-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-14171' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-14171-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-15264' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-15264-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-LVFM-15365' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-LVFM-15365-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-MOBL-16184' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-MOBL-16184-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-MOBL-19067' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-MOBL-19067-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-FLET-MOBL-19068' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-FLET-MOBL-19068-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SEG-88MH1HST' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SEG-88MH1HST-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SHE' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SHE-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-20FP1A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-20FP1A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-20FP1AE' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-20FP1AE-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-20FP2A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-20FP2A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-20FP2AE' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-20FP2AE-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-20FP90A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-20FP90A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-33FP1A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-33FP1A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SIL-33FP2A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SIL-33FP2A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P091-5721-SPT-BDEE' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P091-5721-SPT-BDEE-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P092-7000-SSR-PSV7022' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P092-7000-SSR-PSV7022-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-2000-SLE-T2181' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-2000-SLE-T2181-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-2000-SLE-T2186' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-2000-SLE-T2186-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-3000-SIV-PCV34101' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-3000-SIV-PCV34101-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-3000-SIV-PCV34102' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-3000-SIV-PCV34102-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-3000-SPT-C3021' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-3000-SPT-C3021-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-3000-SPT-C3022' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-3000-SPT-C3022-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-3000-SPT-C3023' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-3000-SPT-C3023-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-5000-SHE' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-5000-SHE-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-5000-SIV-PCV50165' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-5000-SIV-PCV50165-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-5000-SIV-PCV50265' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-5000-SIV-PCV50265-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-F84410B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-F84410B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-K82251' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-K82251-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L80151A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L80151A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L80151B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L80151B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L80151C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L80151C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L80151D' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L80151D-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L81252' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L81252-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L82651A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L82651A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L82651B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L82651B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L82651C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L82651C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-L82651D' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-L82651D-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80369' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80369-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80402A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80402A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80402B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80402B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80407A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80407A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80407B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80407B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441D' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441D-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441E' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441E-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80441F' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80441F-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80443A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80443A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80443B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80443B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80443C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80443C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80850A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80850A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P80850B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P80850B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P81600A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P81600A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-P81600B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-P81600B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80425A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80425A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80425B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80425B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80425C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80425C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80426A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80426A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80426B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80426B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80426C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80426C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80427A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80427A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80427B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80427B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80429A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80429A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80429B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80429B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80429C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80429C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80432A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80432A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80432B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80432B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T80432C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T80432C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950E' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950E-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950F' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950F-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950G' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950G-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T81950H' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T81950H-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T84423A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T84423A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T84423B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T84423B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-T84423C' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-T84423C-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIL-V81950' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIL-V81950-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SIV-PCV81206' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SIV-PCV81206-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SLE-T8295' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SLE-T8295-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P093-8000-SLE-T8395' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P093-8000-SLE-T8395-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-3000-SMP- G3007' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-3000-SMP- G3007-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-3000-SMP- G3017' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-3000-SMP- G3017-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-4000-SLE-T4081' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-4000-SLE-T4081-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-4000-SPT-D40950' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-4000-SPT-D40950-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-4900-SIL-F49201' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-4900-SIL-F49201-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-5000-SIL-P55202' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-5000-SIL-P55202-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-5000-SIL-P55208' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-5000-SIL-P55208-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-5000-SIL-P55216' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-5000-SIL-P55216-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIL-N80500' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIL-N80500-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIL-P80750' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIL-P80750-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIL-V80550' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIL-V80550-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80520' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80520-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80570' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80570-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80580' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80580-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80620' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80620-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80630' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80630-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SIV-PCV80760' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SIV-PCV80760-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SSR-PSV80571' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SSR-PSV80571-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-8000-SSR-PSV80760' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-8000-SSR-PSV80760-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P099-9000-SEG-PJ9675' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P099-9000-SEG-PJ9675-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SAB' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SAB-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSH8008' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSH8008-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSHH8010' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSHH8010-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSHH8012' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSHH8012-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSHH8014' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSHH8014-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSHL8016' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSHL8016-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSLL8011' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSLL8011-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSLL8013' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSLL8013-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-LSLL8015' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-LSLL8015-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-TSHH8074' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-TSHH8074-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-TSHH8075' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-TSHH8075-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-TSHH8076' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-TSHH8076-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8004' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8004-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8006' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8006-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8008' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8008-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8010' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8010-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8012' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8012-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8014' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8014-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8016' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8016-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8018' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8018-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8020' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8020-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SIS-XSH8022' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SIS-XSH8022-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SMP-G8051A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SMP-G8051A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SMP-G8051B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SMP-G8051B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SMP-G8161' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SMP-G8161-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH' and SiteId = 5 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-%' and SiteId = 5 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8193' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8193-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8194A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8194A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8194B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8194B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8195' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8195-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8196' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8196-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8197A' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8197A-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8197B' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8197B-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SPH-Y8198' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SPH-Y8198-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-ASH9175' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-ASH9175-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-ASH9189' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-ASH9189-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-ASL9155' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-ASL9155-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9150' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9150-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9151' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9151-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9152' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9152-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9153' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9153-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9157' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9157-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9159' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9159-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9161' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9161-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9163' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9163-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9165' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9165-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P103-FPAD-SSF-AT9167' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P103-FPAD-SSF-AT9167-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90013' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90013-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90014' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90014-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90032' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90032-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90033' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90033-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90034' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90034-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90035' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90035-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT90036' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT90036-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P106-ABSF-SIR-AT93532' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P106-ABSF-SIR-AT93532-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-L88551' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-L88551-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80161' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80161-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80461' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80461-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80561' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80561-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80661' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80661-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80861' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80861-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N80961' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N80961-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N81061' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N81061-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N81161' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N81161-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N81261' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N81261-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N81361' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N81361-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N81461' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N81461-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84061' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84061-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84072' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84072-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84081' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84081-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84082' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84082-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84150' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84150-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84250' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84250-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84422' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84422-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-N84432' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-N84432-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-U84503' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-U84503-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-U84603' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-U84603-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-V86000' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-V86000-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-V86100' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-V86100-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-X85772' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-X85772-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIL-X85775' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIL-X85775-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIR-A84094' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIR-A84094-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIR-A84097' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIR-A84097-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIR-A84494' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIR-A84494-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIR-A84497' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIR-A84497-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SIV-PCV83532' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SIV-PCV83532-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P107-ABSF-SSR-PSV87521' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P107-ABSF-SSR-PSV87521-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N80261' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N80261-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N80861' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N80861-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N80961' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N80961-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N81061' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N81061-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84061' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84061-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84062' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84062-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84071' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84071-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84072' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84072-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84081' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84081-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84150' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84150-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84250' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84250-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84411' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84411-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84421' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84421-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84422' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84422-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84431' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84431-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N84500' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N84500-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-N86100' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-N86100-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-U85611' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-U85611-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-U85632' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-U85632-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-U85871' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-U85871-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-U85882' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-U85882-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-U85889' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-U85889-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-V86000' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-V86000-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-V86050' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-V86050-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIL-X83032' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIL-X83032-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIR-A84094' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIR-A84094-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIR-A84494' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIR-A84494-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SIV-TCV85804' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SIV-TCV85804-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SSR-PSV84450' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SSR-PSV84450-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P108-ABSF-SSR-PSV87521' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P108-ABSF-SSR-PSV87521-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90011' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90011-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90012' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90012-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90013' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90013-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90014' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90014-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90031' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90031-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90032' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90032-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90034' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90034-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT90035' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT90035-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P116-ABSF-SIR-AT91031' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P116-ABSF-SIR-AT91031-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5000-SIL-A50018' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5000-SIL-A50018-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5000-SIL-F50096' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5000-SIL-F50096-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5000-SSR-PSV50036' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5000-SSR-PSV50036-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5000-SSR-PSV59163' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5000-SSR-PSV59163-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5025-SIL-VGC_1' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5025-SIL-VGC_1-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5025-SIL-VGC_2' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5025-SIL-VGC_2-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P191-5025-SIL-VGC_3' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P191-5025-SIL-VGC_3-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SIL-A50018' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SIL-A50018-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SIL-F96FM1' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SIL-F96FM1-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SIL-P50062' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SIL-P50062-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SIL-T50012' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SIL-T50012-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SIV-PCV50096' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SIV-PCV50096-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SSR-PSV50036' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SSR-PSV50036-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5000-SSR-PSV59523' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5000-SSR-PSV59523-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5025-SIL-VGC_1' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5025-SIL-VGC_1-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5025-SIL-VGC_2' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5025-SIL-VGC_2-%' and SiteId = 5 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'FB1-P192-5025-SIL-VGC_3' and SiteId = 5 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'FB1-P192-5025-SIL-VGC_3-%' and SiteId = 5 and Level > 5


-- MacKay River
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-FORK-18639' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-FORK-18639-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-FORK-18640' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-FORK-18640-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-FORK-18641' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-FORK-18641-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-FORK-18642' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-FORK-18642-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-FORK-18643' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-FORK-18643-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-LVFM-10371' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-LVFM-10371-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-LVFM-10372' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-LVFM-10372-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-SUPM-19062' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-SUPM-19062-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-MOBL-SUPM-19063' and SiteId = 7 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-MOBL-SUPM-19063-%' and SiteId = 7 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P003-0300-SCC-CF0313A' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P003-0300-SCC-CF0313A-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P003-0300-SCC-CF0313B' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P003-0300-SCC-CF0313B-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P007-0700-SSR-PRV0195' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P007-0700-SSR-PRV0195-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P008-0800-SAS-Z0840' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P008-0800-SAS-Z0840-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P022-0022-SIL-L0007' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P022-0022-SIL-L0007-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P040-0040-SEG-GEM0061' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P040-0040-SEG-GEM0061-%' and SiteId = 7 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MR1-P040-0040-SPH-EH0061' and SiteId = 7 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MR1-P040-0040-SPH-EH0061-%' and SiteId = 7 and Level > 5


-- Edmonton
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A001-U069-SIC-PLC0001' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A001-U069-SIC-PLC0001-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A001-U069-SIC-PLC0002' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A001-U069-SIC-PLC0002-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A001-U069-SIC-PLC0005' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A001-U069-SIC-PLC0005-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A003-U063-SMP-E0006B' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A003-U063-SMP-E0006B-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A003-U063-SPH-E0006' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A003-U063-SPH-E0006-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U020-SMA-Y0002' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U020-SMA-Y0002-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U020-SMA-Y0003' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U020-SMA-Y0003-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U020-SMA-Y0006' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U020-SMA-Y0006-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-A0007' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-A0007-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-A0010' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-A0010-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-A0013' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-A0013-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-D0001' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-D0001-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-F0002A' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-F0002A-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-F0002C' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-F0002C-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-F0006' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-F0006-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-F0008A' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-F0008A-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-F0024' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-F0024-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-H0007' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-H0007-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SIL-P0049' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SIL-P0049-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SSR-PSV0205' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SSR-PSV0205-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A005-U022-SSR-PSV0206' and SiteId = 8 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A005-U022-SSR-PSV0206-%' and SiteId = 8 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A006-HVFL-120004' and SiteId = 8 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A006-HVFL-120004-%' and SiteId = 8 and Level > 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'ED1-A006-MISC-110010' and SiteId = 8 and Level = 4
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'ED1-A006-MISC-110010-%' and SiteId = 8 and Level > 4


-- Montreal
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A001-U020-SPT-L291' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U020-SPT-L291-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A001-U020-SPT-L291_A' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U020-SPT-L291_A-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A001-U020-SPT-L291_B' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U020-SPT-L291_B-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A001-U020-SPT-L291_C' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U020-SPT-L291_C-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A001-U030-SPT-E305' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U030-SPT-E305-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A003-U150-SLE-L1503' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U150-SLE-L1503-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A003-U170-SEG-GCM1801A' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SEG-GCM1801A-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A003-U170-SEG-NTM1114_2' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SEG-NTM1114_2-%' and SiteId = 9 and Level > 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy = N'MT1-A003-U170-SEG-NTM1120A' and SiteId = 9 and Level = 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SEG-NTM1120A-%' and SiteId = 9 and Level > 5
GO

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO

ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD



-- Add Stored proc for Inserting
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP Procedure [dbo].FunctionalLocationAddOrUndelete
	END
GO

CREATE Procedure [dbo].FunctionalLocationAddOrUndelete
  (
    @SiteId bigint,
    @Division VARCHAR(15),
    @Section VARCHAR(15),
    @Unit VARCHAR(30),
    @Equipment1 VARCHAR(15),
    @Equipment2 VARCHAR(25),
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
       SiteId,Division,[Section],Unit,Equipment1,Equipment2
      ,Description,FullHierarchy,OutOfService,Deleted
      ,[Level],PlantId,Culture
    ) VALUES (
       @SiteId   -- SiteId - bigint
      ,@Division  -- Division - varchar(15)
      ,@Section  -- Section - varchar(15)
      ,@Unit  -- Unit - varchar(30)
      ,@Equipment1  -- Equipment1 - varchar(15)
      ,@Equipment2  -- Equipment2 - varchar(25)
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
   			a.Fullhierarchy like c.fullhierarchy + '-%'
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

-- Sarnia Inserts
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'BDTF', N'SIL', null, null,N'SR1-OFFS-BDTF-SIL',4000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'GENO', N'STL', N'00LEALL', N'GENERAL LAB EQUIP',N'SR1-OFFS-GENO-STL-00LEALL',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'GENO', N'STP', N'03WS002', N'GUARD HOUSE WEIGH SCALE',N'SR1-OFFS-GENO-STP-03WS002',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'LABM', N'STL', N'00LE001', N'KNOCK ENGINE',N'SR1-OFFS-LABM-STL-00LE001',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'LABM', N'STL', N'00LE002', N'LAB CENTRIFUGE',N'SR1-OFFS-LABM-STL-00LE002',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'LABM', N'STL', N'00LE005', N'HCC CATALYST FINES TEST SHAKER',N'SR1-OFFS-LABM-STL-00LE005',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'LOSP', N'SCT', N'08TRASBES', N'ASBESTOS DECONTAM TRAILER',N'SR1-OFFS-LOSP-SCT-08TRASBES',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'LOSP', N'SCT', N'08TREMERG', N'T/A UTILITY TRAILER',N'SR1-OFFS-LOSP-SCT-08TREMERG',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SIC', N'C03001', N'CONDUCTIVITY ANALYZER LOOP (NIS)',N'SR1-OFFS-TKFM-SIC-C03001',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SIC', N'F031457', N'MMT TO GASOLINE BLENDING *NIS*',N'SR1-OFFS-TKFM-SIC-F031457',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SIC', N'H03030', N'PANEL MOUNTED LOADING REGULATO (nis)',N'SR1-OFFS-TKFM-SIC-H03030',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SIC', N'H03124', N'PUMP 03P124 HAND LOOP (NIS)950081896',N'SR1-OFFS-TKFM-SIC-H03124',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SIC', N'T03005', N'CONDUCTIVITY ANALYZER C-03001 (NIS)',N'SR1-OFFS-TKFM-SIC-T03005',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SMP', N'03P1055', N'CW SEPARATOR IONJECTION PUMP',N'SR1-OFFS-TKFM-SMP-03P1055',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SMP', N'03P1056', N'WELL INJECTION PUMP',N'SR1-OFFS-TKFM-SMP-03P1056',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SMP', N'03P1057', N'WELL INJECTION PUMP',N'SR1-OFFS-TKFM-SMP-03P1057',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'SMP', N'03P1058', N'METHANOL INJECTION PUMP',N'SR1-OFFS-TKFM-SMP-03P1058',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'STL', N'00LE006', N'KNOCK ENGINE',N'SR1-OFFS-TKFM-STL-00LE006',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'TKFM', N'STP', N'03WS002', N'GUARD HOUSE WEIGH SCALE',N'SR1-OFFS-TKFM-STP-03WS002',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'UTOF', N'SIC', N'P041043', N'3100KPA STEAM FROM DOW',N'SR1-OFFS-UTOF-SIC-P041043',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SIC', N'F05032', N'VTC EFF TO EQUALIZATION BASIN (NIS)',N'SR1-OFFS-WWTU-SIC-F05032',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SIC', N'H05160', N'VALVE 05MV006 HAND LOOP (NIS)',N'SR1-OFFS-WWTU-SIC-H05160',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SIC', N'L05038', N'WEMCO 2 (NIS)',N'SR1-OFFS-WWTU-SIC-L05038',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SIC', N'P05031', N'WATER TO 05-P-003 SEALS "NIS"',N'SR1-OFFS-WWTU-SIC-P05031',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SIC', N'P05064', N'05-P-062A DISCHARGE PRES (NIS)',N'SR1-OFFS-WWTU-SIC-P05064',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'OFFS', N'WWTU', N'SMP', N'05P004A', N'POLYMER INJECTION PUMP',N'SR1-OFFS-WWTU-SMP-05P004A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'F19202', N'ISO-BUTANE TO 19-V-023 (NIS)',N'SR1-PLT1-ALKU-SIC-F19202',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'F19203', N'KERO OR ALKYLATE TO 19-V-023 (NIS)',N'SR1-PLT1-ALKU-SIC-F19203',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'F19204', N'ASO FROM 19-V-023 (NIS)',N'SR1-PLT1-ALKU-SIC-F19204',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'L19200', N'19-V-023 INTERFACE LEVEL NUCLE (NIS)',N'SR1-PLT1-ALKU-SIC-L19200',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'L19201', N'19-V-023 OVERALL LEVEL (NIS)',N'SR1-PLT1-ALKU-SIC-L19201',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'P19009A', N'19-V-005A ACID SETTLER PRESSUR',N'SR1-PLT1-ALKU-SIC-P19009A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'P19009B', N'19-V-005A ACID SETTLER PRESSUR',N'SR1-PLT1-ALKU-SIC-P19009B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'P19200', N'19-V-023 PRESSURE (NIS)',N'SR1-PLT1-ALKU-SIC-P19200',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'T19200', N'19-V-023 STEAM JACKET (NIS)',N'SR1-PLT1-ALKU-SIC-T19200',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'ALKU', N'SIC', N'T19201', N'19-V-023 TEMP. (NIS)',N'SR1-PLT1-ALKU-SIC-T19201',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPH', N'16E101', N'KERO TRTR FD/EFFL EXCH O/S',N'SR1-PLT1-BEND-SPH-16E101',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPH', N'16E163', N'KERO TRT FG HTR EXCH O/S',N'SR1-PLT1-BEND-SPH-16E163',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPH', N'16E165', N'KERO HTR EXCH O/S',N'SR1-PLT1-BEND-SPH-16E165',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPT', N'16R001', N'KERO TREATER REACTOR',N'SR1-PLT1-BEND-SPT-16R001',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPT', N'16V145A', N'KERO TRTR SULPH ABSORB VESSEL',N'SR1-PLT1-BEND-SPT-16V145A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPT', N'16V145B', N'KERO TRTR SULPH ABSORB VESSEL',N'SR1-PLT1-BEND-SPT-16V145B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'BEND', N'SPT', N'16V146', N'KERO TRTR  DRYER VESSEL',N'SR1-PLT1-BEND-SPT-16V146',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'CRD1', N'SIC', N'S11001', N'* 12-AB-101 TURBINE SPEED * (NIS)',N'SR1-PLT1-CRD1-SIC-S11001',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'GASP', N'SIC', N'F181501', N'ALKYLATE TO ALKYLATE CAUSTIC T',N'SR1-PLT1-GASP-SIC-F181501',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'GASP', N'SIC', N'L181209', N'FV-18-038 TRIP AND ALARM *** I',N'SR1-PLT1-GASP-SIC-L181209',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'GDSU', N'SIC', N'F12470', N'SULPHUR ANAYLZER A12-020 LOW S (NIS)',N'SR1-PLT1-GDSU-SIC-F12470',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'GDSU', N'SIC', N'F12471', N'SULPHUR ANALYZER A12-021 TO 12 (NIS)',N'SR1-PLT1-GDSU-SIC-F12471',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'GDSU', N'SIC', N'P12473', N'SULPHUR H2S ANALYZER A-12023 L (NIS)',N'SR1-PLT1-GDSU-SIC-P12473',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'F171228', N'NAPHTHA TO PRETREATER **OUT OF',N'SR1-PLT1-PRE1-SIC-F171228',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'F171230', N'HYDROGEN TO 17-R-104 ***NOT IN',N'SR1-PLT1-PRE1-SIC-F171230',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'F17327', N'HYDROGEN TO R-105 (OUT OF SERV',N'SR1-PLT1-PRE1-SIC-F17327',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'L171219', N'17-V-114 PRETRTR 1 FEED TK. **',N'SR1-PLT1-PRE1-SIC-L171219',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'L171220', N'PRETREATER REACTOR 17-R-104 **',N'SR1-PLT1-PRE1-SIC-L171220',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'L171221', N'17-R-104 LEVEL ***NOT IN SERVI',N'SR1-PLT1-PRE1-SIC-L171221',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'L171263', N'PRETREATER FEED TANK 17-V-114',N'SR1-PLT1-PRE1-SIC-L171263',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'L171291', N'NAPHTHA TO STRIPPER (OUT OF SE',N'SR1-PLT1-PRE1-SIC-L171291',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'P171226', N'17-H-109 PRETREAT HEATER INLET',N'SR1-PLT1-PRE1-SIC-P171226',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'P171227', N'FUEL GAS TO 17-H-109 ***OUT OF',N'SR1-PLT1-PRE1-SIC-P171227',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'P171228', N'PILOT GAS TO 17-H-109 ***OUT O',N'SR1-PLT1-PRE1-SIC-P171228',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'T171204', N'PENTANE FROM V-108 (NOW 12-V-2',N'SR1-PLT1-PRE1-SIC-T171204',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'T171225', N'17-E-150B EFFLUENT TO CONDENSE',N'SR1-PLT1-PRE1-SIC-T171225',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'T171226', N'FEED TO 17-E-150B INLET (NIS)',N'SR1-PLT1-PRE1-SIC-T171226',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'T171227', N'17-E-150B EFFLUENT OUT (NIS)',N'SR1-PLT1-PRE1-SIC-T171227',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT1', N'PRE1', N'SIC', N'T171235', N'17-E-150C FEED OUT (NIS)',N'SR1-PLT1-PRE1-SIC-T171235',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'BTXE', N'SIC', N'F24084', N'STEAM TO BTX (NIS)',N'SR1-PLT2-BTXE-SIC-F24084',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'CRU2', N'SPH', N'21E023A', N'STRIPPED WATER COOLER',N'SR1-PLT2-CRU2-SPH-21E023A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'CRU2', N'SPH', N'21E023B', N'STRIPPED WATER COOLER',N'SR1-PLT2-CRU2-SPH-21E023B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'GEN2', N'STP', N'04WS001', N'PLT2 CHLORINE WEIGH SCALE',N'SR1-PLT2-GEN2-STP-04WS001',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'PRE2', N'SIL', N'A22017', N'22T-002 NAPHTHA SPLITTER BTMS.',N'SR1-PLT2-PRE2-SIL-A22017',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'UTP2', N'SIL', N'A04018', N'04-CT-001 HC ANALYZER (NIS)',N'SR1-PLT2-UTP2-SIL-A04018',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25035', N'REDUCED CRUDE TO 25-V-003',N'SR1-PLT2-VACU-SIL-F25035',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25084', N'RECOVERED OIL',N'SR1-PLT2-VACU-SIL-F25084',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25085', N'FUEL GAS TO 25-H-001 BURNERS',N'SR1-PLT2-VACU-SIL-F25085',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25086', N'FV-25010 CONTROL VALVE BYPASS FO',N'SR1-PLT2-VACU-SIL-F25086',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25087', N'25-P-003A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25087',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25088', N'25-P-003B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25088',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25089', N'25-P-007A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25089',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25090', N'25-P-007B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25090',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25091', N'25-P-008A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25091',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25092', N'25-P-008B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25092',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25093', N'25-P-003A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25093',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25094', N'25-P-003B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25094',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25096', N'25-P-007B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25096',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25097', N'25-P-008A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25097',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25098', N'25-P-008B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25098',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25099', N'25-P-003A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25099',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25100', N'25-P-003B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25100',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25101', N'25-P-007A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25101',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25102', N'25-P-007B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25102',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25103', N'25-P-008A SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25103',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25104', N'25-P-008B SEAL FLUSH',N'SR1-PLT2-VACU-SIL-F25104',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25120', N'VGOH PUMP AROUND',N'SR1-PLT2-VACU-SIL-F25120',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25121', N'25-P-001A PUMP SEAL',N'SR1-PLT2-VACU-SIL-F25121',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25122', N'COMBINED VACUUM FRESH FEED',N'SR1-PLT2-VACU-SIL-F25122',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25123', N'RECYCLE QUENCH',N'SR1-PLT2-VACU-SIL-F25123',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25124', N'25-P-001B PUMP SEAL',N'SR1-PLT2-VACU-SIL-F25124',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25125', N'VGOL TO MIXED GAS OIL',N'SR1-PLT2-VACU-SIL-F25125',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25126', N'HVGO',N'SR1-PLT2-VACU-SIL-F25126',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25127', N'CRUDE TO 25-E-020A',N'SR1-PLT2-VACU-SIL-F25127',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25128', N'CRUDE TO 25-E-015A',N'SR1-PLT2-VACU-SIL-F25128',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25129', N'LVC TO MIXED GAS OIL',N'SR1-PLT2-VACU-SIL-F25129',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SIL', N'F25133', N'25-T-001 STRIPPING STEAM',N'SR1-PLT2-VACU-SIL-F25133',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SLE', N'25RV013', N'2-5E-09A T/S RV',N'SR1-PLT2-VACU-SLE-25RV013',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SLE', N'25RV014', N'2-5E-09B T/S RV',N'SR1-PLT2-VACU-SLE-25RV014',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SLE', N'25RV017', N'25 P 13 DISC RV',N'SR1-PLT2-VACU-SLE-25RV017',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SMP', N'25P013', N'KERO CUTTER STOCK PUMP',N'SR1-PLT2-VACU-SMP-25P013',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SPH', N'25E015A', N'CRUDE/VAC QUENCH EXCHANGER',N'SR1-PLT2-VACU-SPH-25E015A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT2', N'VACU', N'SPH', N'25E015B', N'CRUDE/VAC QUENCH EXCHANGER',N'SR1-PLT2-VACU-SPH-25E015B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SIL', N'P31002', N'XV31001 DEPRESS VALVE AIR ASSIST (NIS)',N'SR1-PLT3-REAU-SIL-P31002',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SIL', N'P31003', N'XV31002 DEPRESs VALVE AIR ASSIST (NIS)',N'SR1-PLT3-REAU-SIL-P31003',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SIL', N'P31162', N'INSTRUMENT AIR TO 31-P-031 *removed*',N'SR1-PLT3-REAU-SIL-P31162',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SLE', N'31RV137A', N'31P-035A OIL PUMP DISCHARGE RV',N'SR1-PLT3-REAU-SLE-31RV137A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SLE', N'31RV137B', N'31P-036A OIL PUMP DISCHARGE RV',N'SR1-PLT3-REAU-SLE-31RV137B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SLE', N'31RV138A', N'31P-035B OIL PUMP DISCHARGE RV',N'SR1-PLT3-REAU-SLE-31RV138A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SLE', N'31RV138B', N'31P-036B OIL PUMP DISCHARGE RV',N'SR1-PLT3-REAU-SLE-31RV138B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E001A', N'1ST REACTOR EFF/FRESH FEED EXCHANGER',N'SR1-PLT3-REAU-SPH-31E001A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E001B', N'1ST REACTOR EFF/FRESH FEED EXCHANGER',N'SR1-PLT3-REAU-SPH-31E001B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E030A', N'LUBE OIL COOLER',N'SR1-PLT3-REAU-SPH-31E030A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E030B', N'LUBE OIL COOLER',N'SR1-PLT3-REAU-SPH-31E030B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E032A', N'GLYCOL COOLANT COOLER',N'SR1-PLT3-REAU-SPH-31E032A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E032B', N'GLYCOL COOLANT COOLER',N'SR1-PLT3-REAU-SPH-31E032B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E035A', N'LUBE OIL COOLER',N'SR1-PLT3-REAU-SPH-31E035A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPH', N'31E035B', N'LUBE OIL COOLER',N'SR1-PLT3-REAU-SPH-31E035B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS010A', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS010A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS010B', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS010B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS012A', N'GLYCOL FILTER',N'SR1-PLT3-REAU-SPT-31FS012A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS012B', N'GLYCOL FILTER',N'SR1-PLT3-REAU-SPT-31FS012B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS015A', N'LUBE OIL FILTER A FOR 31P01B',N'SR1-PLT3-REAU-SPT-31FS015A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS015B', N'LUBE OIL FILTER B FOR 31P01B',N'SR1-PLT3-REAU-SPT-31FS015B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS016A', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS016A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS016B', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS016B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS017A', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS017A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'REAU', N'SPT', N'31FS017B', N'LUBE OIL FILTER',N'SR1-PLT3-REAU-SPT-31FS017B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'SAP3', N'SPH', N'34E013A', N'STRIPPER CONDENSER',N'SR1-PLT3-SAP3-SPH-34E013A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT3', N'SAP3', N'SPH', N'34E013B', N'STRIPPER CONDENSER',N'SR1-PLT3-SAP3-SPH-34E013B',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT4', N'DHTU', N'SIL', N'H41116', null,N'SR1-PLT4-DHTU-SIL-H41116',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT4', N'SAP4', N'SIL', N'H44111', null,N'SR1-PLT4-SAP4-SIL-H44111',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT4', N'SAP4', N'SPH', N'44E001A', N'LP CONDENSATE TREATED WATER EXCHANGER',N'SR1-PLT4-SAP4-SPH-44E001A',4000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 1, N'SR1', N'PLT4', N'SAP4', N'SPH', N'44E001B', N'LP CONDENSATE TREATED WATER EXCHANGER',N'SR1-PLT4-SAP4-SPH-44E001B',4000,5,'en';


-- Denver Inserts
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0000', N'SAB', N'00HV0007', N'00HV0007, NEW CONTROL ROOM HEAT PUMP#1',N'DN1-3003-0000-SAB-00HV0007',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0000', N'SAB', N'00HV0008', N'00HV0008, NEW CONTROL RM HEAT PUMP #2',N'DN1-3003-0000-SAB-00HV0008',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0000', N'SAB', N'00HV0009', N'00HV0009, NEW CONTROL RM HEAT PUMP #3',N'DN1-3003-0000-SAB-00HV0009',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SIL', N'01T472', N'01T472, VACUUM TOWER SLOP OIL DRAW',N'DN1-3003-0001-SIL-01T472',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0209', N'PC0209, 01E116(OOS) TO SLOP OIL SYSTEM',N'DN1-3003-0001-SLP-PC0209',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0220', N'PC0220, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0220',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0221', N'PC0221, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0221',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0223', N'PC0223, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0223',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0233', N'PC0233, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0233',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0234', N'PC0234, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0234',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0235', N'PC0235, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0235',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0236', N'PC0236, OUT OF SERVICE',N'DN1-3003-0001-SLP-PC0236',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0240', N'PC0240, FLUSH OIL SYSTEM TO 8-HC-01-0001',N'DN1-3003-0001-SLP-PC0240',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0311', N'PC0311, PLANT AIR TO 01V101 (OOS)',N'DN1-3003-0001-SLP-PC0311',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0312', N'PC0312, PLANT AIR TO 01T103 (OOS)',N'DN1-3003-0001-SLP-PC0312',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0313', N'PC0313, PLANT AIR TO 01T102 (OOS)',N'DN1-3003-0001-SLP-PC0313',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0314', N'PC0314, PLANT AIR TO 01V105 (OOS)',N'DN1-3003-0001-SLP-PC0314',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0315', N'PC0315, PLANT AIR TO 01T104 (OOS)',N'DN1-3003-0001-SLP-PC0315',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0316', N'PC0316, PLANT AIR TO 01V106 (OOS)',N'DN1-3003-0001-SLP-PC0316',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0317', N'PC0317, PLANT AIR TO 01T105 (OOS)',N'DN1-3003-0001-SLP-PC0317',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SLP', N'PC0318', N'PC0318, PLANT AIR TO 01T106 (OOS)',N'DN1-3003-0001-SLP-PC0318',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPH', N'01E108A', N'01E108A, CRUDE/COLD ASPHALT BOTTOM',N'DN1-3003-0001-SPH-01E108A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPH', N'01E108B', N'01E108B, CRUDE/COLD ASPHALT TOP',N'DN1-3003-0001-SPH-01E108B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPH', N'01E116', N'01E116, DIESEL STRIPPER REBOILER',N'DN1-3003-0001-SPH-01E116',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPH', N'01E125', N'01E125, ASPHALT BOX COOLER NO INFO',N'DN1-3003-0001-SPH-01E125',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01F101', N'01F101, SLOP OIL',N'DN1-3003-0001-SPT-01F101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01F105', N'01F105, DIESEL GLAND OIL',N'DN1-3003-0001-SPT-01F105',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01F114A', N'01F114A, DIESEL PREFILTERS',N'DN1-3003-0001-SPT-01F114A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01F114B', N'01F114B, DIESEL COALESCER/SEPARATOR',N'DN1-3003-0001-SPT-01F114B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01V103', N'01V103, SECOND STAGE DESALTER',N'DN1-3003-0001-SPT-01V103',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0001', N'SPT', N'01V112', N'01V112, CONDENSATE DRUM',N'DN1-3003-0001-SPT-01V112',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SMP', N'02P213', N'02P213, HYDRAULIC OIL SOUTH',N'DN1-3003-0002-SMP-02P213',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SMP', N'02P214', N'02P214, HYDRAULIC OIL NORTH',N'DN1-3003-0002-SMP-02P214',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SMP', N'02P217', N'02P217, RAM OIL',N'DN1-3003-0002-SMP-02P217',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E208A', N'02E208A, SLURRY/GAS OIL',N'DN1-3003-0002-SPH-02E208A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E208B', N'02E208B, SLURRY/GAS OIL',N'DN1-3003-0002-SPH-02E208B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E208C', N'02E208C, SLURRY/GAS OIL',N'DN1-3003-0002-SPH-02E208C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E209', N'02E209, HCO STEAM GENERATOR',N'DN1-3003-0002-SPH-02E209',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E210A', N'02E210A, HEAVY DISTILLATE FIN FAN EAST',N'DN1-3003-0002-SPH-02E210A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPH', N'02E210B', N'02E210B, HEAVY DISTILLATE FIN FAN WEST',N'DN1-3003-0002-SPH-02E210B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPT', N'02W202A', N'02W202A, SEPARATOR, 4TH STAGE, FSS UPPER',N'DN1-3003-0002-SPT-02W202A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0002', N'SPT', N'02W202B', N'02W202A, SEPARATOR, 4TH STAGE, FSS LOWER',N'DN1-3003-0002-SPT-02W202B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0003', N'SMP', N'03IS320', N'03IS320, WATER INJECTION TO #1 RX SOUTH',N'DN1-3003-0003-SMP-03IS320',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0003', N'SMP', N'03IS321', N'03IS321, WATER INJECTION TO #2 RX NORTH',N'DN1-3003-0003-SMP-03IS321',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0003', N'SMP', N'03IS322', N'03IS322, WATER INJETION TO GUARD CASE',N'DN1-3003-0003-SMP-03IS322',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SLE', N'04J401', N'04J401, STEAM JET EJECTOR',N'DN1-3003-0004-SLE-04J401',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P415A', N'04P415A, LOW PRESSURE AMMONIA PUMP',N'DN1-3003-0004-SMP-04P415A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P415B', N'04P415B, LOW PRESSURE AMMONIA PUMP',N'DN1-3003-0004-SMP-04P415B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P416A', N'04P416A, INTERMEDIATE PRESS AMMONIA PUMP',N'DN1-3003-0004-SMP-04P416A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P416B', N'04P416B, INTERMEDIATE PRESS AMMONIA PUMP',N'DN1-3003-0004-SMP-04P416B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P417A', N'04P417A, AQUA PUMP',N'DN1-3003-0004-SMP-04P417A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P417B', N'04P417B, AQUA PUMP',N'DN1-3003-0004-SMP-04P417B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SMP', N'04P428', N'04P428, AMMONIA CONDENSER WATER RECIR',N'DN1-3003-0004-SMP-04P428',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E425', N'04E425, NEW GAS/TREAT GAS PRECOOLER',N'DN1-3003-0004-SPH-04E425',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E426', N'04E426, NET GAS/TREAT CHILLER',N'DN1-3003-0004-SPH-04E426',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E427', N'04E427, LOW PRESS LIQ AMMONIA COOLER',N'DN1-3003-0004-SPH-04E427',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E428', N'04E428, AMMONIA CONDENSER',N'DN1-3003-0004-SPH-04E428',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E429', N'04E429, RECTIFIER BOTTOMS COOLER',N'DN1-3003-0004-SPH-04E429',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E430', N'04E430, AMMONIA RECTIFIER REBOILER',N'DN1-3003-0004-SPH-04E430',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E431', N'04E431, LPG PREHEATER',N'DN1-3003-0004-SPH-04E431',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E432', N'04E432, AQUA COOLER',N'DN1-3003-0004-SPH-04E432',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04E433', N'04E433, AQUA SYSTEM COOLER',N'DN1-3003-0004-SPH-04E433',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04H428A', N'04H428A, AMMONIA COND H20 SUMP ELECT HTR',N'DN1-3003-0004-SPH-04H428A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04H428B', N'04H428B, AMMONIA COND H20 SUMP ELECT HTR',N'DN1-3003-0004-SPH-04H428B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPH', N'04H433', N'04H433, AQUA SYS CLR H20 SMP ELEC HR FRZ',N'DN1-3003-0004-SPH-04H433',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04T403', N'04T403, AMMONIA RECTIFIER TOWER',N'DN1-3003-0004-SPT-04T403',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04TK401', N'04TK401, AMMONIA PURGE DRM (BUBBLE TANK)',N'DN1-3003-0004-SPT-04TK401',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V407', N'04V407, STEAM DRUM',N'DN1-3003-0004-SPT-04V407',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V409', N'04V409, BOILER BLOWDOWN DRUM',N'DN1-3003-0004-SPT-04V409',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V411', N'04V411, LOW PRESSURE AMMONIA ABSORBER',N'DN1-3003-0004-SPT-04V411',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V412', N'04V412, LOW PRESSURE AMMONIA RECEIVER',N'DN1-3003-0004-SPT-04V412',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V413', N'04V413, INTERMDAT PRESS AMMONIA ABSORBER',N'DN1-3003-0004-SPT-04V413',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V414', N'04V414, INTERMEDIATE PRESS AMMONIA REC',N'DN1-3003-0004-SPT-04V414',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V415', N'04V415, NET GAS/TREAT GAS KNOCK-OUT DRUM',N'DN1-3003-0004-SPT-04V415',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V416', N'04V416, LOW PRESSURE AMMONIA SEPARATOR',N'DN1-3003-0004-SPT-04V416',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V417', N'04V417, AMMONIA CONDENSER RECEIVER',N'DN1-3003-0004-SPT-04V417',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V418', N'04V418, RECTIFIER BOTTOMS FLASH DRUM',N'DN1-3003-0004-SPT-04V418',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0004', N'SPT', N'04V419', N'04V419, AQUA SURGE DRUM',N'DN1-3003-0004-SPT-04V419',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05F183', N'05F183, CONDENSATE FROM X362',N'DN1-3003-0005-SIL-05F183',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05F184', N'05F184,175# STEAM FROM X362',N'DN1-3003-0005-SIL-05F184',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05F410', N'05F410, STRAIGHT RUN TO JP4',N'DN1-3003-0005-SIL-05F410',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05L131', N'05L0131, D52 LEVEL',N'DN1-3003-0005-SIL-05L131',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05L132', N'05L0132, D51 LEVEL',N'DN1-3003-0005-SIL-05L132',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05L183', N'05L183, X362 CONDENSATE LEVEL',N'DN1-3003-0005-SIL-05L183',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05L184', N'05L184, X362 SPLITTER REBOILER LEVEL',N'DN1-3003-0005-SIL-05L184',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05L186', N'05L0186, D53 CONDENSATE DRUM LEVEL',N'DN1-3003-0005-SIL-05L186',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SIL', N'05P165', N'05P165, OOS- W71 DIFFERENTIAL PRESSURE',N'DN1-3003-0005-SIL-05P165',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SLP', N'PC0117', N'PC0117, 4-HN-05-0105 TO OPEN END (O.O.S)',N'DN1-3003-0005-SLP-PC0117',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SLP', N'PC0118', N'PC0118, 4-HN-05-0105 TO OPEN END(O.O.S.)',N'DN1-3003-0005-SLP-PC0118',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0005-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0005', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0005-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0007', N'SLP', N'PC0043', N'PC0043, 1.5-BD-07-0212 TO BLOWDOWN',N'DN1-3003-0007-SLP-PC0043',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0007', N'SLP', N'PC0182', N'PC0182, 180# STEAM TO 1-WW-07-0902',N'DN1-3003-0007-SLP-PC0182',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0007', N'SPH', N'07E705', N'07E705, AMINE RECLAIMER',N'DN1-3003-0007-SPH-07E705',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0007', N'SPT', N'07F701', N'07F701, AMINE STRING FILTER',N'DN1-3003-0007-SPT-07F701',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0007', N'SPT', N'07TK701', N'07TK701, AMINE STORAGE TANK',N'DN1-3003-0007-SPT-07TK701',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08F2001', N'08F2001, P583 DISCHARGE',N'DN1-3003-0008-SIL-08F2001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08F442', N'08F442, RED DYE FLOW',N'DN1-3003-0008-SIL-08F442',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08F443', N'08F443, BRONZE DYE FLOW',N'DN1-3003-0008-SIL-08F443',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08F526', N'08F526, DIESEL SALT DRIER D815 FEED',N'DN1-3003-0008-SIL-08F526',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08L401', N'08L401, D290 RED DYE DRUM LEVEL',N'DN1-3003-0008-SIL-08L401',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08L402', N'08L402, D290 RED DYE DRUM  HIGH LEVEL',N'DN1-3003-0008-SIL-08L402',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08L403', N'08L403, D289 BRONZE DYE DRUM LEVEL',N'DN1-3003-0008-SIL-08L403',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08L404', N'08L404, D289 BRONZE DYE DRUM  HIGH LEVEL',N'DN1-3003-0008-SIL-08L404',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08X689', N'08X689, BRONZE DYE PUMP',N'DN1-3003-0008-SIL-08X689',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08X690', N'08X690, RED DYE PUMP',N'DN1-3003-0008-SIL-08X690',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08Y289', N'08Y289, TANK HIGH LEVEL',N'DN1-3003-0008-SIL-08Y289',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SIL', N'08Y290', N'08Y290, TANK HIGH LEVEL',N'DN1-3003-0008-SIL-08Y290',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLE', N'S15', N'S15, FILTER, JET-50 TO AIRPORT',N'DN1-3003-0008-SLE-S15',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLE', N'S51', N'S51, FILTER,OSS, SALT',N'DN1-3003-0008-SLE-S51',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0415', N'PC0415, D290 TO P690',N'DN1-3003-0008-SLP-PC0415',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0416', N'PC0416, P690 TO D290',N'DN1-3003-0008-SLP-PC0416',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0417', N'PC0417, 1.5-XX-08-0416 TO 1-XX-08-0421',N'DN1-3003-0008-SLP-PC0417',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0418', N'PC0418, D289 TO P689',N'DN1-3003-0008-SLP-PC0418',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0419', N'PC0419, P689 TO D289',N'DN1-3003-0008-SLP-PC0419',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0420', N'PC0420, 4-HN-08-0834 TO D-89/D290',N'DN1-3003-0008-SLP-PC0420',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0421', N'PC0421, 1.5-XX-08-0419 TO 10-HN-08-0442',N'DN1-3003-0008-SLP-PC0421',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0422', N'PC0422, 2-XX-08-0418 TO HOSE CONNECTION',N'DN1-3003-0008-SLP-PC0422',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0423', N'PC0423, LOG ON D-290 TO 3-HN-08-0425',N'DN1-3003-0008-SLP-PC0423',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0424', N'PC0424, 1.5-HN-08-0420 TO 1-XX-08-0421',N'DN1-3003-0008-SLP-PC0424',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0425', N'PC0425, 3-HN-08-0420 TO 4-HN-03-0802',N'DN1-3003-0008-SLP-PC0425',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0426', N'PC0426, 2-XX-08-0415 TO 2-XX-08-0418',N'DN1-3003-0008-SLP-PC0426',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC0427', N'PC0427, 1-XX-08-0423 TO SEAL ON D290',N'DN1-3003-0008-SLP-PC0427',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC1020', N'PC1020, D290 TO HC',N'DN1-3003-0008-SLP-PC1020',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SLP', N'PC1021', N'PC1021, D289 TO OE',N'DN1-3003-0008-SLP-PC1021',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P175', N'P175, PUMP,T70 TRANSFER',N'DN1-3003-0008-SMP-P175',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P290', N'P290, PUMP,T34 TRANSFER',N'DN1-3003-0008-SMP-P290',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P35', N'P35,  PUMP,OOS WATER WELL #1',N'DN1-3003-0008-SMP-P35',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P378', N'P378, PUMP,T80 TRANSFER',N'DN1-3003-0008-SMP-P378',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P433', N'P433, PUMP,#10 WATER WELL',N'DN1-3003-0008-SMP-P433',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SMP', N'P47', N'P47,  PUMP,DIESEL SALES',N'DN1-3003-0008-SMP-P47',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPH', N'X801', N'X801, VACUUM RESID HEATER',N'DN1-3003-0008-SPH-X801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPH', N'X806', N'X806,T39 CIRCULATION HEATER',N'DN1-3003-0008-SPH-X806',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D141', N'D141, DRUM, MIX FOR BUTANE LOADING',N'DN1-3003-0008-SPT-D141',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D209', N'D209, DRUM, JET 50 FILTER, MIDDLE',N'DN1-3003-0008-SPT-D209',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D220', N'D220, DRUM, JET 50 FILTER, NORTH',N'DN1-3003-0008-SPT-D220',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D291', N'D291, DRUM, HOLD AND TRANSFER',N'DN1-3003-0008-SPT-D291',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D293', N'D293, DRUM, REG LEADED PROTO',N'DN1-3003-0008-SPT-D293',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D294', N'D294, DRUM, PREM UNLEADED PROTO',N'DN1-3003-0008-SPT-D294',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D295', N'D295, DRUM, REG UNLEADED PROTO',N'DN1-3003-0008-SPT-D295',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D369', N'D369, DRUM, CAUSTIC FILTER',N'DN1-3003-0008-SPT-D369',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D393', N'D393, DRUM, C7 INLET KO',N'DN1-3003-0008-SPT-D393',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'D95', N'D95, DRUM, JP4 INTIICING INHIBITOR',N'DN1-3003-0008-SPT-D95',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'T13', N'T13, TANK, SLOP',N'DN1-3003-0008-SPT-T13',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'T3801', N'T3801, ULSD STORAGE TANK',N'DN1-3003-0008-SPT-T3801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'T781', N'T781, TANK, STANDBY EQUIPMENT',N'DN1-3003-0008-SPT-T781',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'T801', N'T801, BETZ STORAGE TANK #900387',N'DN1-3003-0008-SPT-T801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SPT', N'T88', N'T88, TANK, FUEL OIL STORAGE',N'DN1-3003-0008-SPT-T88',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSF', N'FA801', N'FA801, FLAME ARRESTER,T811',N'DN1-3003-0008-SSF-FA801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSF', N'FA802', N'FA802, FLAME ARRESTER @ D94',N'DN1-3003-0008-SSF-FA802',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV10', N'RDV10, VENT/PRESS/VAC,PROTECTS D289',N'DN1-3003-0008-SSR-RDV10',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV1038', N'RDV1038, VACUUM RELIEF DEVICE FOR T3801',N'DN1-3003-0008-SSR-RDV1038',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV1039', N'RDV1039, VACUUM RELIEF DEVICE FOR T3801',N'DN1-3003-0008-SSR-RDV1039',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV11', N'RDV11, VENT/PRESS/VAC,PROTECTS D289',N'DN1-3003-0008-SSR-RDV11',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV8', N'RDV8, VENT/PRESS/VAC PROTECTS D290',N'DN1-3003-0008-SSR-RDV8',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV803', N'RDV803, VENT/PRESS/VAC PROTECTS T2',N'DN1-3003-0008-SSR-RDV803',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV804', N'RDV804, VENT/PRESS/VAC PROTECTS T2',N'DN1-3003-0008-SSR-RDV804',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV805', N'RDV805, VENT/PRESS/VAC, PROTECTS D94',N'DN1-3003-0008-SSR-RDV805',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV806', N'RDV806, VENT/PRESS/VAC, PROTECTS T809',N'DN1-3003-0008-SSR-RDV806',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV807', N'RDV807, VENT/PRESS/VAC, PROTECTS T810',N'DN1-3003-0008-SSR-RDV807',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV8774', N'RDV8774, VACUUM BREAKER PROTECTS T774',N'DN1-3003-0008-SSR-RDV8774',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV8775', N'RDV8775, VACUUM BREAKER PROTECTS T774',N'DN1-3003-0008-SSR-RDV8775',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RDV9', N'RDV9, VENT/PRESS/VAC PROTECTS D290',N'DN1-3003-0008-SSR-RDV9',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SSR', N'RV818', N'RV818, RELIEF VALVE PROTECTS D369',N'DN1-3003-0008-SSR-RV818',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0008-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0008', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0008-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10F339', N'10F339, FUEL OIL TO H10',N'DN1-3003-0010-SIL-10F339',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10F350', N'10F350, P1020 DISCHARGE',N'DN1-3003-0010-SIL-10F350',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10H347', N'10H347, W56 NAPHTHA STRIPPER LEVEL HIGH',N'DN1-3003-0010-SIL-10H347',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10T356', N'10T356, W55 14TH TRAY TEMPERATURE',N'DN1-3003-0010-SIL-10T356',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10T364', N'10T364, W56 BOTTOMS TEMPERATURE',N'DN1-3003-0010-SIL-10T364',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10T365', N'10T365, NAPHTHA TO STORAGE TEMPERATURE',N'DN1-3003-0010-SIL-10T365',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SIL', N'10T385', N'10T385, W56 OVERHEAD TEMPERATURE',N'DN1-3003-0010-SIL-10T385',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLE', N'S8', N'S8  FILTER, LEAN AMINE CARTRIDGE',N'DN1-3003-0010-SLE-S8',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0105', N'PC0105, W56 (IDLE PORT) TO 3-HN-10-0193',N'DN1-3003-0010-SLP-PC0105',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0106', N'PC0106, W56 TO 3" FLATCAP',N'DN1-3003-0010-SLP-PC0106',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0107', N'PC0107, 3-HN-10-0231 TO P786',N'DN1-3003-0010-SLP-PC0107',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0122', N'PC0122, W56 TO X492',N'DN1-3003-0010-SLP-PC0122',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0123', N'PC0123, X492 TO W56',N'DN1-3003-0010-SLP-PC0123',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0161', N'PC0161, W56 TO 14-HN-10-0143',N'DN1-3003-0010-SLP-PC0161',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0162', N'PC0162, W55 TO W56',N'DN1-3003-0010-SLP-PC0162',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0164', N'PC0164, W56 (IDLE) TO W55',N'DN1-3003-0010-SLP-PC0164',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0175', N'PC0175, FUEL OIL (O.O.S.) TO H10',N'DN1-3003-0010-SLP-PC0175',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SLP', N'PC0176', N'PC0176, H10 TO FUEL OIL (O.O.S.)',N'DN1-3003-0010-SLP-PC0176',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SMP', N'P1099', N'P1099, PUMP,EXCESS KERO SAMPLE RECOVERY',N'DN1-3003-0010-SMP-P1099',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SPH', N'X1099', N'X1099, KERO SAMPLE COOLER',N'DN1-3003-0010-SPH-X1099',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SPT', N'D1099', N'D1099, EXCESS KERO SAMPLE RECOVERY DRUM',N'DN1-3003-0010-SPT-D1099',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SSF', N'FA1099', N'FA1099, FLAME/SPARK ARRESTOR',N'DN1-3003-0010-SSF-FA1099',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0010-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0010', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0010-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0012', N'SLE', N'ARM37', N'ARM37, MP,SBS, TRACK 2 - SPOT7',N'DN1-3003-0012-SLE-ARM37',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0012', N'SMP', N'P147', N'P147, PUMP, JET-A TRANSFER',N'DN1-3003-0012-SMP-P147',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0012', N'SPT', N'D210', N'D210, DRUM, JP4 FILTER',N'DN1-3003-0012-SPT-D210',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0012', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0012-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0012', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0012-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F17', N'13F17, HEAVY NAPHTHA TO P1018',N'DN1-3003-0013-SIL-13F17',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F23', N'13F23, 175# STEAM TO D78',N'DN1-3003-0013-SIL-13F23',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F65', N'13F65, TSB TO FUEL',N'DN1-3003-0013-SIL-13F65',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F75', N'13F75, COLD TAR STRIPPER BOTTOMS TO H6',N'DN1-3003-0013-SIL-13F75',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F9', N'13F9, T58 CRUDE',N'DN1-3003-0013-SIL-13F9',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F90', N'13F90, 1ST TRAY VGO REFLUX TO W36',N'DN1-3003-0013-SIL-13F90',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F91', N'13F91, 1ST TRAY VGO TO D37',N'DN1-3003-0013-SIL-13F91',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F92', N'13F92, W36 TOTAL GRID SPRAY CURTAIN',N'DN1-3003-0013-SIL-13F92',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F93', N'13F93, 2ND TRAY WASH OIL DRAW',N'DN1-3003-0013-SIL-13F93',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F94', N'13F94, VACUUM BOTTOMS TO STORAGE',N'DN1-3003-0013-SIL-13F94',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F95', N'13F95, TOTAL VAC BOTTOMS W/QUENCH',N'DN1-3003-0013-SIL-13F95',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F96', N'13F96, 175# STEAM TO EJECTOR/U48',N'DN1-3003-0013-SIL-13F96',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F97', N'13F97, TAR STRIPPER BOTTOMS TO SLOP',N'DN1-3003-0013-SIL-13F97',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F98', N'13F98, CLARIFIED OIL TO #6 FUEL OIL',N'DN1-3003-0013-SIL-13F98',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13F99', N'13F99, FIRST TRAY VGO TO #4 HDS',N'DN1-3003-0013-SIL-13F99',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13L18', N'13L18, W2 LEVEL',N'DN1-3003-0013-SIL-13L18',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13L38', N'13L38, W6 LEVEL',N'DN1-3003-0013-SIL-13L38',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13P11', N'13P11, ATOMIZING STEAM TO H27',N'DN1-3003-0013-SIL-13P11',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13P44', N'13P44, W6 PRESSURE',N'DN1-3003-0013-SIL-13P44',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SIL', N'13T94', N'13T94, SWEET NAPHTHA TO STORAGE TEMP',N'DN1-3003-0013-SIL-13T94',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0124', N'PC0124, 2-HM-13-0604 TO 2-HM-08-0211',N'DN1-3003-0013-SLP-PC0124',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0125', N'PC0125, 3-HR-13-0086 TO 3-HR-13-0245',N'DN1-3003-0013-SLP-PC0125',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0208', N'PC0208, 4-HR-13-0521 TO 4-HR-13-0344',N'DN1-3003-0013-SLP-PC0208',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0414', N'PC0414,3-HD-35-00451 BLINDED @  3" VALVE',N'DN1-3003-0013-SLP-PC0414',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0415', N'PC0415, 3-HN-08-0710 TO GASOLINE BLENDER',N'DN1-3003-0013-SLP-PC0415',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0418', N'PC0418, 175# STEAM TO STEAM SEPARATOR',N'DN1-3003-0013-SLP-PC0418',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0437', N'PC0437, CWS TO X252 TUBESIDE',N'DN1-3003-0013-SLP-PC0437',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SLP', N'PC0438', N'PC0438, X252 TUBESIDE TO CWR',N'DN1-3003-0013-SLP-PC0438',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SMP', N'P2033', N'P2033, PUMP, DESALTER WASH WATER',N'DN1-3003-0013-SMP-P2033',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SMP', N'P72', N'P72, PUMP, W6 BOTTOMS',N'DN1-3003-0013-SMP-P72',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SPH', N'X34', N'X34, EXCHANGER, VACUUM BOTTOMS VS CRUDE',N'DN1-3003-0013-SPH-X34',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SPH', N'X342', N'X342, EXCHANGER, DESALTER FEED',N'DN1-3003-0013-SPH-X342',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SPT', N'W2', N'W2, TOWER, NAPTHA STRIPPER',N'DN1-3003-0013-SPT-W2',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SPT', N'W6', N'W6, TOWER, SWEET NAPHTHA FLASH',N'DN1-3003-0013-SPT-W6',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SSR', N'RV509', N'RV509, RELIEF VALVE, PROTECTS W6',N'DN1-3003-0013-SSR-RV509',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0013-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0013', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0013-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15F805', N'15F805, W39 STRIPPER BYPASS',N'DN1-3003-0015-SIL-15F805',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15F818', N'15F818, OUT OF SERVICE',N'DN1-3003-0015-SIL-15F818',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15P239', N'15P239, #1 REFORMER CHARGE',N'DN1-3003-0015-SIL-15P239',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15P314', N'15P314, T52 PUMP START',N'DN1-3003-0015-SIL-15P314',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15R239', N'15R239, P239 STOP RELAY',N'DN1-3003-0015-SIL-15R239',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15X239', N'15X239, P239 STOP',N'DN1-3003-0015-SIL-15X239',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SIL', N'15X314', N'15X314, T52 PUMP START/STOP',N'DN1-3003-0015-SIL-15X314',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SLP', N'PC0130', N'PC0130, 3-FG-15-0097 to #3 HDS (OOS)',N'DN1-3003-0015-SLP-PC0130',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMF', N'C1', N'C1, COMPRESSOR, #1HDS H2 BOOSTER',N'DN1-3003-0015-SMF-C1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMF', N'C18', N'C18, COMPRESSOR, H2 BOOSTER RECYCLE',N'DN1-3003-0015-SMF-C18',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMP', N'J100', N'J100, PUMP,MORPHALINE ADDITION',N'DN1-3003-0015-SMP-J100',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMP', N'J295', N'J295, PUMP,C1 CYLINDER REFORMATE',N'DN1-3003-0015-SMP-J295',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMP', N'P239', N'P239, PUMP, W39 BOTTOMS',N'DN1-3003-0015-SMP-P239',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMP', N'P244', N'P244, PUMP, C-1 AUX OIL',N'DN1-3003-0015-SMP-P244',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SMP', N'P291', N'P291, C18 LUBE PUMP',N'DN1-3003-0015-SMP-P291',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'H12', N'H12, HEATER, STANDBY',N'DN1-3003-0015-SPH-H12',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'H7', N'H7, HEATER, STANDBY',N'DN1-3003-0015-SPH-H7',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'H8', N'H8, HEATER, STANDBY',N'DN1-3003-0015-SPH-H8',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X147', N'X147, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X147',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X148', N'X148 ,EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X148',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X149', N'X149, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X149',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X150', N'X150, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X150',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X151', N'X151, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X151',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X152', N'X152, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X152',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X2012', N'X2012, EXCHANGER, C1 LUBE OIL VS WATER',N'DN1-3003-0015-SPH-X2012',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X217', N'X217, EXCHANGER, FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X217',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'X226', N'X226, EXCHANGER, OOS - FEED VS EFFLUENT',N'DN1-3003-0015-SPH-X226',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPH', N'XF216', N'XF216, FIN FAN, W51 BTMS COOLER',N'DN1-3003-0015-SPH-XF216',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D275', N'D275, DRUM, CHLORIDE BLOWPOT',N'DN1-3003-0015-SPT-D275',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D404', N'D404, DRUM,W73 CAT SAMPLE RECEIVER',N'DN1-3003-0015-SPT-D404',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D79', N'D79, DRUM,C1 INLET SURGE CYLINDER',N'DN1-3003-0015-SPT-D79',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D80', N'D80, DRUM,C1 DSCHG SURGE CYLINDER',N'DN1-3003-0015-SPT-D80',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D81', N'D81, DRUM,C1 INLET SURGE CYLINDER',N'DN1-3003-0015-SPT-D81',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'D82', N'D82, DRUM,C1 DSCHG SURGE CYLINDER',N'DN1-3003-0015-SPT-D82',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'W33', N'W33, TOWER, #1 REFORMER RX #1',N'DN1-3003-0015-SPT-W33',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'W34', N'W34, TOWER, #1 REFORMER RX #2',N'DN1-3003-0015-SPT-W34',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SPT', N'W35', N'W35, TOWER, #1 REFORMER RX #3',N'DN1-3003-0015-SPT-W35',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0015-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0015', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0015-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SLE', N'EJ7', N'EJ7, EJECTOR, S36',N'DN1-3003-0016-SLE-EJ7',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SLE', N'S30', N'S30, FILTER, COALESCING, HP1',N'DN1-3003-0016-SLE-S30',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SLE', N'S31', N'S31, FILTER, COALESCING, HP2',N'DN1-3003-0016-SLE-S31',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SMF', N'F176', N'F176, FAN, XF224, GOHDS DIESEL',N'DN1-3003-0016-SMF-F176',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SMP', N'J651', N'J651, PUMP, C53 LUBE OIL',N'DN1-3003-0016-SMP-J651',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'X409', N'X409, EXCHANGER, HPHS VAPOR VS RECY GAS',N'DN1-3003-0016-SPH-X409',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'X445', N'X445, EXCHANGER, FEED PREHEAT FOR HP2',N'DN1-3003-0016-SPH-X445',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'X446', N'X446, EXCHANGER, FEED PREHEAT FOR HP1',N'DN1-3003-0016-SPH-X446',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'X452', N'X452, EXCHANGER, H2 PRODUCT VS WATER',N'DN1-3003-0016-SPH-X452',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'X453', N'X453, EXCHANGER, COMB RESIDUE COOLER',N'DN1-3003-0016-SPH-X453',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPH', N'XF224', N'XF224, FIN FAN, GOHDS DIESEL COOLER',N'DN1-3003-0016-SPH-XF224',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPT', N'D363', N'D363, DRUM,MEMBRANE SEPARATOR - HP1',N'DN1-3003-0016-SPT-D363',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SPT', N'D365', N'D365, DRUM,MEMBRANE SEPARATOR - HP2',N'DN1-3003-0016-SPT-D365',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0016-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0016', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0016-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17H91', null,N'DN1-3003-0017-SIL-17H91',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17H911', N'17H911,C1714 LOAD CTRL SS  LOCAL-DCS',N'DN1-3003-0017-SIL-17H911',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17H912', N'17H912,C1714 RUN MODE SS NORM/START-UP',N'DN1-3003-0017-SIL-17H912',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17H913', N'17H913,C1714  2,3,4TH STG 0%  IND LT',N'DN1-3003-0017-SIL-17H913',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17H914', N'17H914,C1714  START-UP RUN  IND LT',N'DN1-3003-0017-SIL-17H914',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SIL', N'17ISS500', N'17ISS500, HIGH RATE DEPRESSURING SYSTEM',N'DN1-3003-0017-SIL-17ISS500',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMF', N'F1793', N'F1793,FAN',N'DN1-3003-0017-SMF-F1793',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMP', N'J17181', N'J17181,PUMP,START UP/WARM UP AT P1718',N'DN1-3003-0017-SMP-J17181',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMP', N'P17109', N'P17109,PUMP,ANTI-FOAM INJECTION SYSTEM',N'DN1-3003-0017-SMP-P17109',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMP', N'P1756', N'P1756, PUMP,SOUR WATER',N'DN1-3003-0017-SMP-P1756',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMP', N'P1757', N'P1757 ,PUMP,SOUR WATER',N'DN1-3003-0017-SMP-P1757',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SMP', N'P1782', N'P1782,PUMP,C1714 LUBRICATOR',N'DN1-3003-0017-SMP-P1782',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'H1715', N'H1715,HEATER, C1715',N'DN1-3003-0017-SPH-H1715',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'H17151', N'H17151,HEATER, C1715 SEAL GAS',N'DN1-3003-0017-SPH-H17151',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'H1781', N'H1781, LUBRICATOR HEATER',N'DN1-3003-0017-SPH-H1781',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'X17137', N'X17137,EXCHANGER,LEAN AMINE SAMPLE',N'DN1-3003-0017-SPH-X17137',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'X17138', N'X17138,EXCHANGER,RICH AMINE SAMPLE',N'DN1-3003-0017-SPH-X17138',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'X1718', N'X1718,EXCHANGER,P1718 SEAL OIL',N'DN1-3003-0017-SPH-X1718',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SPH', N'X17182', N'X17182,EXCHANGER, P1718 SEAL OIL COOLER',N'DN1-3003-0017-SPH-X17182',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0017', N'SSF', N'FA17180', N'FA17180, FLAME ARRESTOR ON C1715',N'DN1-3003-0017-SSF-FA17180',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19F217', N'19F217, OUT OF SERVICE',N'DN1-3003-0019-SIL-19F217',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19H211', N'19H211, OUT OF SERVICE',N'DN1-3003-0019-SIL-19H211',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19H618', N'19H618, OUT OF SERVICE',N'DN1-3003-0019-SIL-19H618',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P323', N'19P323, H37 FUEL GAS PRESSURE.',N'DN1-3003-0019-SIL-19P323',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P324', N'19P324, H37 LOW FUEL GAS PRESSURE.',N'DN1-3003-0019-SIL-19P324',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P325', N'19P325, FUEL GAS TO H37',N'DN1-3003-0019-SIL-19P325',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P327', N'19P327, W76 LVGO REFLUX',N'DN1-3003-0019-SIL-19P327',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P331', N'19P331, W82 MID-PRESS SOUR CRUDE FRACT',N'DN1-3003-0019-SIL-19P331',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P332', N'19P332, W82 OVERHEAD',N'DN1-3003-0019-SIL-19P332',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P333', N'19P333, W82 UPPER SECTION',N'DN1-3003-0019-SIL-19P333',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P334', N'19P334, W82 LOWER SECTION',N'DN1-3003-0019-SIL-19P334',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P335', N'19P335, H37 PILOT GAS REGULATOR',N'DN1-3003-0019-SIL-19P335',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P344', N'19P344, H33 FUEL GAS PRESSURE.',N'DN1-3003-0019-SIL-19P344',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P345', N'19P345, H33 LOW FUEL GAS PRESSURE.',N'DN1-3003-0019-SIL-19P345',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P346', N'19P346, FUEL GAS TO H33',N'DN1-3003-0019-SIL-19P346',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P348', N'19P348, H33 PILOT GAS REGULATOR',N'DN1-3003-0019-SIL-19P348',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P349', N'19P349, H13 PILOT GAS REGULATOR',N'DN1-3003-0019-SIL-19P349',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P352', N'19P352, D1902 PRESSURE',N'DN1-3003-0019-SIL-19P352',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P353', N'19P353, D1902 MIX VLV DIFFERENTIAL PRES',N'DN1-3003-0019-SIL-19P353',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P364', N'19P364, D1903 MIX VLV DIFFERENTIAL PRES',N'DN1-3003-0019-SIL-19P364',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P381', N'19P381, BUFFER TANK P796',N'DN1-3003-0019-SIL-19P381',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P385', N'19P385, BUFFER TANK P795',N'DN1-3003-0019-SIL-19P385',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P389', N'19P389, BUFFER TANK P798 OUTBOARD',N'DN1-3003-0019-SIL-19P389',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P391', N'19P391, BUFFER TANK P798 INBOARD',N'DN1-3003-0019-SIL-19P391',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19P393', N'19P393, BUFFER TANK P799',N'DN1-3003-0019-SIL-19P393',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SIL', N'19Z310', N'19Z310, OUT OF SERVICE',N'DN1-3003-0019-SIL-19Z310',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SLE', N'SL1901', N'SL1901,SILENCER STEAM GENERATOR X1914',N'DN1-3003-0019-SLE-SL1901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMF', N'F1950', N'F1950,FAN, XF1912',N'DN1-3003-0019-SMF-F1950',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMF', N'F1951', N'F1951,FAN, XF1912',N'DN1-3003-0019-SMF-F1951',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J1903', N'J1903,PUMP,COOLING TWR CHEM INJECT GE-B',N'DN1-3003-0019-SMP-J1903',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J1907', N'J1907,INJEC. PUMP INTO HVGO PA. INLET',N'DN1-3003-0019-SMP-J1907',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J1979', N'J1979,PUMP, MILTON ROY,(J237&J278 SPARE)',N'DN1-3003-0019-SMP-J1979',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J225', N'J225, PUMP, 3F19 INJECTION',N'DN1-3003-0019-SMP-J225',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J226', N'J226, PUMP, FEED EMULSION D201/282',N'DN1-3003-0019-SMP-J226',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J239', N'J239, PUMP,D201/D282 EMULSION BRKR',N'DN1-3003-0019-SMP-J239',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J241', N'J241, PUMP, CHEMICAL INJECTION',N'DN1-3003-0019-SMP-J241',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'J657', N'J657, PUMP, 8% CAUSTIC AT T333',N'DN1-3003-0019-SMP-J657',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P251', N'P251, PUMP, SOUR KEROSENE TO CTU',N'DN1-3003-0019-SMP-P251',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P348', N'P348, PUMP, AU SPARE COOLING WATER',N'DN1-3003-0019-SMP-P348',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P358', N'P358, PUMP, AU CPI SUMP',N'DN1-3003-0019-SMP-P358',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P617', N'P617, PUMP, W60 PREFLASH BOTTOMS',N'DN1-3003-0019-SMP-P617',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P618', N'P618, PUMP, W60 PREFLASH BOTTOMS',N'DN1-3003-0019-SMP-P618',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P806', N'P806, PUMP, AU SLOP TRANSFER',N'DN1-3003-0019-SMP-P806',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P906', N'P906, PUMP, T324 SLOP OIL TRANSFER',N'DN1-3003-0019-SMP-P906',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SMP', N'P907', N'P907, PUMP, T324 SLOP OIL TRANSFER',N'DN1-3003-0019-SMP-P907',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'X209', N'X209,W76 BOTTOMS VS H2O',N'DN1-3003-0019-SPH-X209',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'X351', N'X351, EXCHANGER, DESALTER FEED VS EFFLUE',N'DN1-3003-0019-SPH-X351',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'X400', N'X400, EXCHANGER, CRUDE VS KEROSENE',N'DN1-3003-0019-SPH-X400',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'X401', N'X401, EXCHANGER, CRUDE VS KEROSENE',N'DN1-3003-0019-SPH-X401',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'X435', N'X435, EXCHANGER, SOUR CRUDE VS AGO',N'DN1-3003-0019-SPH-X435',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPH', N'XF502', N'XF502, FIN FAN,P2039 SEAL FLUSH COOLER',N'DN1-3003-0019-SPH-XF502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPT', N'T1901', N'T1901, BETZ STORAGE TANK #880386',N'DN1-3003-0019-SPT-T1901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPT', N'T1902', N'T1902, BETZ STORAGE TANK #920167',N'DN1-3003-0019-SPT-T1902',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPT', N'T1908', N'T1908, BETZ STORAGE TANK #900387',N'DN1-3003-0019-SPT-T1908',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SPT', N'T333', N'T333, TANK, AU 8% CAUSTIC STORAGE',N'DN1-3003-0019-SPT-T333',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0019-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0019', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0019-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SLE', N'ARM112', N'ARM112 LOAD ARM, AU TRK RACK, SPOT 112',N'DN1-3003-0032-SLE-ARM112',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SLE', N'ARM160', N'ARM160,LOADING ARM, AU TRK RACK',N'DN1-3003-0032-SLE-ARM160',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SLE', N'ARM39', N'ARM39,LOAD ARM,12150 LOADING (NORTH), AU',N'DN1-3003-0032-SLE-ARM39',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SLE', N'ARM40', N'ARM40,LOAD ARM,12150 LOADING (SOUTH), AU',N'DN1-3003-0032-SLE-ARM40',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A29', N'A29,AGITATOR, T120, SOUTH, UPPER',N'DN1-3003-0032-SMA-A29',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A31', N'A31,AGITATOR, T120, SOUTH, BTM',N'DN1-3003-0032-SMA-A31',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A35', N'A35,AGITATOR, T168',N'DN1-3003-0032-SMA-A35',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A36', N'A36, AGITATOR, T163',N'DN1-3003-0032-SMA-A36',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A37', N'A37,AGITATOR, T-163',N'DN1-3003-0032-SMA-A37',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A38', N'A38,AGITATOR, T164',N'DN1-3003-0032-SMA-A38',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMA', N'A39', N'A39,AGITATOR, T166',N'DN1-3003-0032-SMA-A39',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J133', N'J133, PUMP, D1000 INJECTION',N'DN1-3003-0032-SMP-J133',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J203', N'J203, PUMP, OIL LOADING & TRANSFER',N'DN1-3003-0032-SMP-J203',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J215', N'J215, PUMP, ASPHALT TRANSFER',N'DN1-3003-0032-SMP-J215',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J220', N'J220, PUMP, SLOP CHARGE',N'DN1-3003-0032-SMP-J220',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J64A', N'J64A, PUMP, T169',N'DN1-3003-0032-SMP-J64A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'J79', N'J79, PUMP, ACRA RAIL UNLOADING',N'DN1-3003-0032-SMP-J79',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P135', N'P135, PUMP, CONDENSATE TO T106',N'DN1-3003-0032-SMP-P135',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P201', N'P201, PUMP, MC CUTTER',N'DN1-3003-0032-SMP-P201',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P205', N'P205, PUMP, EMULSION LOADING',N'DN1-3003-0032-SMP-P205',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P309', N'P309, PUMP, T161 ASPHALT LOADING',N'DN1-3003-0032-SMP-P309',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P341', N'P341, PUMP, T102 TRANSFER',N'DN1-3003-0032-SMP-P341',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P357', N'P357, PUMP, AU H2O WELL, SOUTH',N'DN1-3003-0032-SMP-P357',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P432', N'P432, PUMP, AU WATER WELL, NORTH',N'DN1-3003-0032-SMP-P432',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'P548', N'P548, PUMP, T141 TRANSFER',N'DN1-3003-0032-SMP-P548',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SMP', N'R29', N'R29, PUMP, T133 RAM OIL',N'DN1-3003-0032-SMP-R29',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T107', N'T107, TANK, ACRA STORAGE',N'DN1-3003-0032-SPT-T107',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T120', N'T120,TANK,PMA STORAGE (STAND BY)',N'DN1-3003-0032-SPT-T120',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T121', N'T121, TANK, LATEX STORAGE, EAST',N'DN1-3003-0032-SPT-T121',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T122', N'T122, TANK, LATEX STORAGE, WEST',N'DN1-3003-0032-SPT-T122',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T123', N'T123, TANK, D1000 STORAGE',N'DN1-3003-0032-SPT-T123',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T131', N'T131, TANK, MC CUTTER STOCK, EAST',N'DN1-3003-0032-SPT-T131',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T132', N'T132, TANK, MC CUTTER STOCK, WEST',N'DN1-3003-0032-SPT-T132',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T133', N'T133, TANK, GAS OIL STORAGE',N'DN1-3003-0032-SPT-T133',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T135', N'T135, TANK, FUEL OIL STORAGE',N'DN1-3003-0032-SPT-T135',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T137', N'T137, TANK, OOS STORAGE',N'DN1-3003-0032-SPT-T137',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T141', N'T141, TANK, GAS OIL STORAGE',N'DN1-3003-0032-SPT-T141',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T161', N'T161, TANK, EMULSION STORAGE',N'DN1-3003-0032-SPT-T161',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T162', N'T162, TANK, EMULSION STORAGE',N'DN1-3003-0032-SPT-T162',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T163', N'T163, TANK, PMA SALES',N'DN1-3003-0032-SPT-T163',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T164', N'T164, TANK, AU SLOP/AC-10 STORAGE',N'DN1-3003-0032-SPT-T164',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T165', N'T165, TANK, EMULSION STORAGE',N'DN1-3003-0032-SPT-T165',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T166', N'T166, TANK, EMULSION STORAGE',N'DN1-3003-0032-SPT-T166',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T167', N'T167, TANK, AC-10 STORAGE',N'DN1-3003-0032-SPT-T167',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T168', N'T168, TANK, AC-5 STORAGE',N'DN1-3003-0032-SPT-T168',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T169', N'T169, TANK, MC CUTTER STORAGE',N'DN1-3003-0032-SPT-T169',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T170', N'T170, TANK, MC CUTTER STORAGE',N'DN1-3003-0032-SPT-T170',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T171', N'T171, TANK, MC CUTTER STORAGE',N'DN1-3003-0032-SPT-T171',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T172', N'T172, TANK, OSS STORAGE',N'DN1-3003-0032-SPT-T172',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T173', N'T173, TANK, MC CUTTER STORAGE',N'DN1-3003-0032-SPT-T173',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T174', N'T174, TANK, ASPHALT STORAGE',N'DN1-3003-0032-SPT-T174',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T175', N'T175, TANK, EMULSION STORAGE',N'DN1-3003-0032-SPT-T175',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SPT', N'T176', N'T176, TANK, ASPHALT STORAGE',N'DN1-3003-0032-SPT-T176',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SSF', N'FA13', N'FA13, FLAME ARRESTOR',N'DN1-3003-0032-SSF-FA13',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0032-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0032', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0032-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35F162', N'35F162, H22 FUEL OIL SUPPLY',N'DN1-3003-0035-SIL-35F162',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35L118', N'35L118, D334 HOTWELL LEVEL',N'DN1-3003-0035-SIL-35L118',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35L119', N'35L119, D334 HOTWELL PUMP CONTROLLER',N'DN1-3003-0035-SIL-35L119',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35L157', N'35L157, D65 HYDROLIC OIL DRUM LEVEL',N'DN1-3003-0035-SIL-35L157',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35P149', N'35P149, H22 ATONIZING STEAM PRESS',N'DN1-3003-0035-SIL-35P149',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35T102', N'35T102, H22 GAS OIL TEMPERATURE CONTROL',N'DN1-3003-0035-SIL-35T102',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SIL', N'35X114', N'35X114, H22 FUEL OIL SUPPLY S',N'DN1-3003-0035-SIL-35X114',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SLE', N'S2005', N'S2005, FILTER, AMERTAP',N'DN1-3003-0035-SLE-S2005',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SLP', N'PC0718', N'PC0718, 3-HD-35-0225 TO 3-HD-35-0456',N'DN1-3003-0035-SLP-PC0718',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SMP', N'J294A', N'J294A,PUMP, DEBUTE END PT ANALYZER',N'DN1-3003-0035-SMP-J294A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SMP', N'P527', N'P527, PUMP, AMERTAP COOLING H2O',N'DN1-3003-0035-SMP-P527',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SMP', N'P561', N'P561, PUMP, FCC HYDRAULIC SYSTEM',N'DN1-3003-0035-SMP-P561',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SMP', N'P575', N'P575, PUMP, HYDRAULIC OIL, SOUTH',N'DN1-3003-0035-SMP-P575',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SPT', N'D313', N'D312, DRUM, CONTINUOUS CAT FEEDER',N'DN1-3003-0035-SPT-D313',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SPT', N'D65', N'D65, DRUM, HYDRAULIC OIL STORAGE',N'DN1-3003-0035-SPT-D65',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SPT', N'T2015', N'T2015, TANK, LUBE STORAGE TOTE',N'DN1-3003-0035-SPT-T2015',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SPT', N'W20', N'W20, TOWER, SLURRY OIL STRIPPER',N'DN1-3003-0035-SPT-W20',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0035-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0035', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0035-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0036', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0036-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0036', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0036-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLE', N'EJ3703', N'EJ3703,EDUCTOR @ P3703/U3703',N'DN1-3003-0037-SLE-EJ3703',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLE', N'S3707', N'S3707,FILTER,CARBON',N'DN1-3003-0037-SLE-S3707',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLE', N'S3708', N'S3708,FILTER,CARBON',N'DN1-3003-0037-SLE-S3708',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLE', N'S3709', N'S3709,FILTER,CARBON',N'DN1-3003-0037-SLE-S3709',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0009', N'PC0009, P249 TO D103/104',N'DN1-3003-0037-SLP-PC0009',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0014', N'PC0014, 4-CH-37-0004 TO P77/P176',N'DN1-3003-0037-SLP-PC0014',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0062', N'PC0062, D-03 TO D231/D232',N'DN1-3003-0037-SLP-PC0062',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0063', N'PC0063, 6-WT-37-0063 TO TP-37-131',N'DN1-3003-0037-SLP-PC0063',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0066', N'PC0066, D103 TO SEWER',N'DN1-3003-0037-SLP-PC0066',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0067', N'PC0067, D103 BTM TO P349 SUCTION',N'DN1-3003-0037-SLP-PC0067',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0068', N'PC0068, P349 DSCHG TO D103',N'DN1-3003-0037-SLP-PC0068',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0069', N'PC0069, P41 DSCH TO D104',N'DN1-3003-0037-SLP-PC0069',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0070', N'PC0070, D104 BTM TO P41 SUCTION',N'DN1-3003-0037-SLP-PC0070',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0071', N'PC0071, 6-WR-40-9000 TO D101',N'DN1-3003-0037-SLP-PC0071',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0072', N'PC0072, D102 TO P77 SUCTION',N'DN1-3003-0037-SLP-PC0072',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0073', N'PC0073, D101 TO P176',N'DN1-3003-0037-SLP-PC0073',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0074', N'PC0074, P77 DSCH TO D104',N'DN1-3003-0037-SLP-PC0074',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0075', N'PC0075, P176 DSCH TO D03',N'DN1-3003-0037-SLP-PC0075',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0076', N'PC0076, 1.5-WT-37-0072 TO 1.5-WT-37-0073',N'DN1-3003-0037-SLP-PC0076',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0077', N'PC0077, 1.5-WT-37-0073 TO 1.5-WT-37-0072',N'DN1-3003-0037-SLP-PC0077',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0078', N'PC0078, P77 DSCH TO P176 DSCH',N'DN1-3003-0037-SLP-PC0078',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0080', N'PC0080, D104 TO RV221',N'DN1-3003-0037-SLP-PC0080',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0081', N'PC0081, RV221 TO ATMOS',N'DN1-3003-0037-SLP-PC0081',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0083', N'PC0083, RV652 TO ATMOS',N'DN1-3003-0037-SLP-PC0083',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0085', N'PC0085, D231/232 TO P246/247 SUCTION',N'DN1-3003-0037-SLP-PC0085',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0093', N'PC0093, 4-WX-37-0093 TO TP-37-161',N'DN1-3003-0037-SLP-PC0093',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0096', N'PC0096, 6-WT-37-0555 TO 4-WT-37-0096',N'DN1-3003-0037-SLP-PC0096',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0166', N'PC0166, X496 TO WATER RETURN',N'DN1-3003-0037-SLP-PC0166',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0169', N'PC0169, D103 BTM TO D-04 BTM',N'DN1-3003-0037-SLP-PC0169',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0170', N'PC0170, D102 TO ATMOS',N'DN1-3003-0037-SLP-PC0170',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0171', N'PC0171, LINE LOADING TO D102',N'DN1-3003-0037-SLP-PC0171',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0172', N'PC0172, LIME LOADING TO D101',N'DN1-3003-0037-SLP-PC0172',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0173', N'PC0173, D101 TO ATMOS',N'DN1-3003-0037-SLP-PC0173',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0174', N'PC0174, D104 TO ATMOS',N'DN1-3003-0037-SLP-PC0174',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0175', N'PC0175, D103 TO ATMOS',N'DN1-3003-0037-SLP-PC0175',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0176', N'PC0176, D102 TO SEWER',N'DN1-3003-0037-SLP-PC0176',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SLP', N'PC0177', N'PC0177, D101 TO SEWER',N'DN1-3003-0037-SLP-PC0177',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'GW100', N'GW100, ARAPHAOE WELL',N'DN1-3003-0037-SMP-GW100',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3704', N'J3704,PUMP,ANTISCALANT FEED',N'DN1-3003-0037-SMP-J3704',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3705', N'J3705,PUMP,ANTISCALANT FEED',N'DN1-3003-0037-SMP-J3705',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3706', N'J3706,PUMP,CHEMICAL INJECTION',N'DN1-3003-0037-SMP-J3706',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3716', N'J3716,PUMP,MILTON ROY',N'DN1-3003-0037-SMP-J3716',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3719', N'J3719,PUMP,MILTON ROY',N'DN1-3003-0037-SMP-J3719',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3742', N'J3742, PUMP, METERING, INJECTION, PROPOR',N'DN1-3003-0037-SMP-J3742',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'J3743', N'J3743, PUMP, METERING, INJECTION, PROPOR',N'DN1-3003-0037-SMP-J3743',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'P249', N'P249, PUMP, DIRTY BACKWASH',N'DN1-3003-0037-SMP-P249',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'P434', N'P434, PUMP, DEEP SOFT WATER #11',N'DN1-3003-0037-SMP-P434',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SMP', N'P65', N'P65, PUMP, ZEOLITE BACKWASH',N'DN1-3003-0037-SMP-P65',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SPH', N'X3745', N'X3745,EXCHANGER,BFW LUBE OIL COOLER',N'DN1-3003-0037-SPH-X3745',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SPH', N'X501', N'X501,EXCHANGER, BOILER BLWDWN SMPL COOL',N'DN1-3003-0037-SPH-X501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SPT', N'T3704', N'T3704, CIP RO SKID',N'DN1-3003-0037-SPT-T3704',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SPT', N'T3717', N'T3717, TANK, ANTI-SCALANT',N'DN1-3003-0037-SPT-T3717',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0037-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0037', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0037-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SLE', N'S3801', N'S3801,FILTER,AIR DRYER, AFTER',N'DN1-3003-0038-SLE-S3801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SLE', N'S3802', N'S3802,FILTER,AIR DRYER, AFTER',N'DN1-3003-0038-SLE-S3802',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SLE', N'S3803', N'S3803,FILTER,AIR DRYER, AFTER',N'DN1-3003-0038-SLE-S3803',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SMF', N'F159', N'F159, FAN, C19 MOTOR BLOWER (M-539)',N'DN1-3003-0038-SMF-F159',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPH', N'H3801', N'H3801,HEATER,AIR DRYER',N'DN1-3003-0038-SPH-H3801',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPH', N'X255', N'X255, EXCHANGER, FUEL OIL HEATER',N'DN1-3003-0038-SPH-X255',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D182', N'D182,DRUM, PLANT AIR DRYER',N'DN1-3003-0038-SPT-D182',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D183', N'D183,DRUM, PLANT AIR DRYER',N'DN1-3003-0038-SPT-D183',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D184', N'D184,DRUM, PLANT AIR DRYER',N'DN1-3003-0038-SPT-D184',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D185', N'D185,DRUM, PLANT AIR DRYER',N'DN1-3003-0038-SPT-D185',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D3802', N'D3802,DRUM,PLANT AIR DRYER',N'DN1-3003-0038-SPT-D3802',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SPT', N'D3803', N'D3803,DRUM,PLANT AIR DRYER',N'DN1-3003-0038-SPT-D3803',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0038-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0038', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0038-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SLE', N'S3902', N'S3902, STRAINER,SEAL WATER',N'DN1-3003-0039-SLE-S3902',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SLE', N'S4', N'S4, FILTER,SEAL LIQUID FILTER',N'DN1-3003-0039-SLE-S4',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMF', N'C3901', N'C3901, COMPRESSOR,MAIN PLANT FLARE GAS',N'DN1-3003-0039-SMF-C3901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMF', N'C3902', N'C3902, COMPRESSOR,MAIN PLANT FLARE GAS',N'DN1-3003-0039-SMF-C3902',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMF', N'C3903', N'C3903, COMPRESSOR,MAIN PLANT FLARE GAS',N'DN1-3003-0039-SMF-C3903',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMF', N'C3904', N'C3904, COMPRESSOR,MAIN PLANT FLARE GAS',N'DN1-3003-0039-SMF-C3904',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMP', N'P3905', N'P3905, COMPRESSOR SEAL LIQUID PUMP',N'DN1-3003-0039-SMP-P3905',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMP', N'P3918', N'P3918,PUMP.SOUR WATER',N'DN1-3003-0039-SMP-P3918',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SMP', N'P3919', N'P3919,PUMP.SOUR WATER',N'DN1-3003-0039-SMP-P3919',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SPH', N'X3901', N'X3901,EXCHANGER, SEAL LLIQUID COOLER',N'DN1-3003-0039-SPH-X3901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SPH', N'XF3926', N'XF3926,FIN FAN,2ND STG DISCH AIR COOLER',N'DN1-3003-0039-SPH-XF3926',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SPT', N'D3908', N'D3908, DRUM, FLARE LIQUID COALESCER',N'DN1-3003-0039-SPT-D3908',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SPT', N'D3956', N'D3956,TANK,LUBE OIL RUNDOWN',N'DN1-3003-0039-SPT-D3956',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0039-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0039', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0039-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'GW101', N'GW101, OLD SOUTH WATER WELL',N'DN1-3003-0040-SMP-GW101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'GW102', N'GW102, NORTH WATER WELL',N'DN1-3003-0040-SMP-GW102',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'J140', N'J140, PUMP, SULFURIC ACID INJECTION',N'DN1-3003-0040-SMP-J140',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'J272', N'J272, PUMP, CAUSTIC INJECTION',N'DN1-3003-0040-SMP-J272',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'J48', N'J48, PUMP, SULFURIC ACID INJECTION',N'DN1-3003-0040-SMP-J48',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'J60', N'J60, PUMP, SULFURIC ACID INJECTION',N'DN1-3003-0040-SMP-J60',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'P346', N'P346, PUMP, Y4 COOLING H2O',N'DN1-3003-0040-SMP-P346',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SMP', N'P404', N'P404, PUMP, COOLING H2O BOOSTER',N'DN1-3003-0040-SMP-P404',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SPT', N'T4001', N'T4001, BETZ STORAGE TANK #971438',N'DN1-3003-0040-SPT-T4001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SPT', N'T4002', N'T4002, BETZ STORAGE TANK #971438',N'DN1-3003-0040-SPT-T4002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0040-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0040', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0040-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H400', N'41H400, SPARE P398/P399',N'DN1-3003-0041-SIL-41H400',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H402', N'41H402, W69 REFLUX PUMP',N'DN1-3003-0041-SIL-41H402',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H403', N'41H403, W30 FEED PUMP',N'DN1-3003-0041-SIL-41H403',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H411', N'41H411, P4101 REFLUX PUMP',N'DN1-3003-0041-SIL-41H411',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H412', N'41H412, P4102 RELUX PUMP (SPARE)',N'DN1-3003-0041-SIL-41H412',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H424', N'41H424, W68 REFLUX PUMP',N'DN1-3003-0041-SIL-41H424',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H425', N'41H425, W68 REFLUX PUMP',N'DN1-3003-0041-SIL-41H425',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H429', N'41H429, W68 REFLUX',N'DN1-3003-0041-SIL-41H429',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H443', N'41H443, W37 INTRCOOLER PUMP',N'DN1-3003-0041-SIL-41H443',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SIL', N'41H444', N'41H444, W37 INTRCOOLER PUMP',N'DN1-3003-0041-SIL-41H444',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SMF', N'F4111', N'F4111, FAN',N'DN1-3003-0041-SMF-F4111',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SPH', N'X329', N'X329, EXCHANGER, PB TO T400 COOLER',N'DN1-3003-0041-SPH-X329',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SPT', N'D126', N'D126, DRUM, OUT OF SERVICE',N'DN1-3003-0041-SPT-D126',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SPT', N'T4102', N'T4102, BETZ STORAGE TANK #920484',N'DN1-3003-0041-SPT-T4102',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0041-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0041', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0041-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SAA', N'SW6', N'SW6, MORGAN BOX',N'DN1-3003-0045-SAA-SW6',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SAA', N'SW7', N'SW7, TANK,PIT HOLDING',N'DN1-3003-0045-SAA-SW7',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SAA', N'WT7', N'WT7, BASIN,WATER TREATMENT',N'DN1-3003-0045-SAA-WT7',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SAA', N'WW5', N'WW5, TANK,MP API/CPI HEADWORKS',N'DN1-3003-0045-SAA-WW5',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SLE', N'S26', N'S26, FILTER, CPI SLUDGE TANK',N'DN1-3003-0045-SLE-S26',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SLE', N'S28', N'S28, FILTER, AU CPI BAR SCREEN',N'DN1-3003-0045-SLE-S28',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SLE', N'S4505', N'S4505, STRAINER,OILINER FOR P363',N'DN1-3003-0045-SLE-S4505',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SLE', N'S4506', N'S4506, SUCTION STRAINER FOR P370',N'DN1-3003-0045-SLE-S4506',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SLE', N'S53', N'S53, FILTER, CPI BAR SCREEN',N'DN1-3003-0045-SLE-S53',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A24', N'A24,AERATOR, 4TH LAGOON',N'DN1-3003-0045-SMA-A24',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A25', N'A25,AERATOR, 4TH LAGOON',N'DN1-3003-0045-SMA-A25',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A45', N'A45,AERATOR, #1 LAGOON',N'DN1-3003-0045-SMA-A45',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4507', N'A4507, AERATOR, #2 LAGOON',N'DN1-3003-0045-SMA-A4507',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4508', N'A4508, AERATOR, #3 LAGOON',N'DN1-3003-0045-SMA-A4508',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4517', N'A4517, MIXER,SLUDGE TANK',N'DN1-3003-0045-SMA-A4517',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4518', N'A4518, MIXER,SLUDGE TANK',N'DN1-3003-0045-SMA-A4518',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4531', N'A4531,DGF RAPID MIX TANK AGITATOR',N'DN1-3003-0045-SMA-A4531',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4532', N'A4532,DGF FLOCCULATION TANK AGITATOR',N'DN1-3003-0045-SMA-A4532',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4535', N'A4535, DRUM SCREEN,API SEPARATOR',N'DN1-3003-0045-SMA-A4535',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4536', N'A4536, GRINDER,API SEPARATOR',N'DN1-3003-0045-SMA-A4536',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4537', N'A4537, DRUM SCREEN,API SEPARATOR',N'DN1-3003-0045-SMA-A4537',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4542', N'A4542, RAKE,API SEPARATOR',N'DN1-3003-0045-SMA-A4542',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A4543', N'A4543, RAKE,API SEPARATOR',N'DN1-3003-0045-SMA-A4543',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A46', N'A46 AERATOR, #1 LAGOON',N'DN1-3003-0045-SMA-A46',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMA', N'A78', N'A78,AGITATOR, T329 GRIT SETTLER+D75',N'DN1-3003-0045-SMA-A78',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J137', N'J137, PUMP, S28 BAR',N'DN1-3003-0045-SMP-J137',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J138', N'J138, PUMP, SLUDGE T324',N'DN1-3003-0045-SMP-J138',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J139', N'J139, PUMP, SLUDGE T324, SPARE',N'DN1-3003-0045-SMP-J139',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J180', N'J180, PUMP, CAUSTIC METERING',N'DN1-3003-0045-SMP-J180',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J646', N'J646, PUMP, HYDROGEN PEROXIDE',N'DN1-3003-0045-SMP-J646',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'J649', N'J649, PUMP, LUBRICATING OIL',N'DN1-3003-0045-SMP-J649',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P2037', N'P2037, PUMP, API OIL SUMP',N'DN1-3003-0045-SMP-P2037',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P208', N'P208, PUMP, T13/T16 TRANSFER',N'DN1-3003-0045-SMP-P208',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P363', N'P363, PUMP, T13/T16 TRANSFER',N'DN1-3003-0045-SMP-P363',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P4505', N'P4505,PUMP,BARRIER FLUID CIRC PUMP@P363',N'DN1-3003-0045-SMP-P4505',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P4506', N'P4506,PUMP,BARRIER FLUID CIRC PUMP@P370',N'DN1-3003-0045-SMP-P4506',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P459', N'P459, PUMP, SAND CREEK WATER',N'DN1-3003-0045-SMP-P459',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P460', N'P460, PUMP, AU CPI SUMP',N'DN1-3003-0045-SMP-P460',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P658', N'P658, PUMP, STORM H2O DIVERSION',N'DN1-3003-0045-SMP-P658',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P659', N'P659, PUMP, GROUND H2O DIVERSION',N'DN1-3003-0045-SMP-P659',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P660', N'P660, PUMP, GROUND H2O DIVERSION',N'DN1-3003-0045-SMP-P660',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P661', N'P661, PUMP, PROCESS H2O DIVERSION',N'DN1-3003-0045-SMP-P661',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P674', N'P674, PUMP, API SEPARATOR',N'DN1-3003-0045-SMP-P674',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P716', N'P716, PUMP, A-BAY TRAP',N'DN1-3003-0045-SMP-P716',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P717', N'P717, PUMP, C-BAY TRAP',N'DN1-3003-0045-SMP-P717',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P721', N'P721, PUMP, D-BAY TRAP',N'DN1-3003-0045-SMP-P721',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SMP', N'P818', N'P818, PUMP, #4 LAGOON SPRAY COOLER',N'DN1-3003-0045-SMP-P818',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'D142', N'D142, DRUM, CAUSTIC STORAGE',N'DN1-3003-0045-SPT-D142',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'D409', N'D409, DRUM, AU CPI BAR SCREEN',N'DN1-3003-0045-SPT-D409',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T20', N'T20, TANK, WASTEWATER SLOP RECOVERY',N'DN1-3003-0045-SPT-T20',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T202', N'T202, TANK, ROUND HOLDING',N'DN1-3003-0045-SPT-T202',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T203', N'T203, LAGOON #4',N'DN1-3003-0045-SPT-T203',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T21', N'T21, TANK, WASTEWATER SLOP STORAGE',N'DN1-3003-0045-SPT-T21',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T325', N'T325, TANK, SLUDGE HOLDING',N'DN1-3003-0045-SPT-T325',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SPT', N'T782', N'T782, TANK, HYDROGEN PEROXIDE STG',N'DN1-3003-0045-SPT-T782',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4501', N'RDV4501, VACUUM BREAKER FOR SW4501',N'DN1-3003-0045-SSR-RDV4501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4502', N'RDV4502, VACUUM BREAKER FOR SW4501',N'DN1-3003-0045-SSR-RDV4502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4514A', N'RDV4514A, API OIL WATER SEPARATOR',N'DN1-3003-0045-SSR-RDV4514A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4514B', N'RDV4514B, API OIL WATER SEPARATOR',N'DN1-3003-0045-SSR-RDV4514B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4515A', N'RDV4515A ,API OIL WATER SEPARATOR',N'DN1-3003-0045-SSR-RDV4515A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4515B', N'RDV4515B, API OIL WATER SEPARATOR',N'DN1-3003-0045-SSR-RDV4515B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4516', N'RDV4516, API OIL TANK',N'DN1-3003-0045-SSR-RDV4516',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4517', N'RDV4517, API SLUDGE TANK',N'DN1-3003-0045-SSR-RDV4517',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SSR', N'RDV4518', N'RDV4518, API SLUDGE TANK',N'DN1-3003-0045-SSR-RDV4518',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0045-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0045', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0045-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0046', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0046-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0046', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0046-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'SMP', N'P45', N'P45, PUMP, HOT POND FIRE',N'DN1-3003-0047-SMP-P45',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'SMT', N'U15', N'U15, FIRE WATER TURBINE',N'DN1-3003-0047-SMT-U15',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D001', N'D001,METER,AIR VELOCITY',N'DN1-3003-0047-STI-D001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D003', N'D003,PROBE,RADIATION',N'DN1-3003-0047-STI-D003',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D007', N'D007,DOSIMETER,NOISE',N'DN1-3003-0047-STI-D007',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D008', N'D008,DOSIMETER,NOISE',N'DN1-3003-0047-STI-D008',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D009', N'D009,ANNUAL RECALIBRATION',N'DN1-3003-0047-STI-D009',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D011', N'D011,CALIBRATOR, DOSIMETER,NOISE',N'DN1-3003-0047-STI-D011',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D012', N'D012,METER,SOUND LEVEL/OCTAVE BAND',N'DN1-3003-0047-STI-D012',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D013', N'D013,ACOUSTIC CALIBRATOR',N'DN1-3003-0047-STI-D013',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D014', N'DD014,METER,SOUND LEVEL',N'DN1-3003-0047-STI-D014',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D015', N'D015,IND. SOUND LVL MTR, ACOUS. CAL',N'DN1-3003-0047-STI-D015',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D016', N'D016,METER,RADIATION SURVEY',N'DN1-3003-0047-STI-D016',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D018', N'D018, DOSIMETER, CALIBRATOR',N'DN1-3003-0047-STI-D018',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D020', N'D020,DOSIMETER,RADIATION',N'DN1-3003-0047-STI-D020',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D030', N'D030,MONITOR,HEAT STRESS (PERSONAL)',N'DN1-3003-0047-STI-D030',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'STI', N'D031', N'D031,MONITOR,HEAT STRESS  ( AREA )',N'DN1-3003-0047-STI-D031',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0047-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0047', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0047-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'SAB', N'49HU1', N'49HU1, HUMIDIFIER, LAB INSTRUMENT AIR',N'DN1-3003-0049-SAB-49HU1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'SAB', N'49VAC1', N'49VAC1, VACUUM SYSTEM, LABORATORY',N'DN1-3003-0049-SAB-49VAC1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49DW03', N'49HU1, HUMIDIFIER, LAB INSTRUMENT AIR',N'DN1-3003-0049-STL-49DW03',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49FR01', N'49FR01, FREEZER, LAB',N'DN1-3003-0049-STL-49FR01',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49FR02', N'49FR02, FREEZER, LAB',N'DN1-3003-0049-STL-49FR02',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49FR03', N'49FR03, FREEZER, LAB',N'DN1-3003-0049-STL-49FR03',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49FR04', N'49FR04, FREEZER, LAB',N'DN1-3003-0049-STL-49FR04',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49IM01', N'49IM01, ICE MAKER, LAB',N'DN1-3003-0049-STL-49IM01',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'49IM02', N'49IM02, ICE MAKER, LAB',N'DN1-3003-0049-STL-49IM02',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA1', N'LA1, HOUSTON ATLAS',N'DN1-3003-0049-STL-LA1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA11', N'LA11, MICROSCOPE, C MATHESON CAT#000',N'DN1-3003-0049-STL-LA11',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA12', N'LA12, FLASH POINT TESTER, PM/ISL',N'DN1-3003-0049-STL-LA12',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA13', N'LA13, GAS CHROMATOGRAPH SERIES 400 GAS#2',N'DN1-3003-0049-STL-LA13',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA14', N'LA14, RECORDING TITRATOR, ''STREAMS''',N'DN1-3003-0049-STL-LA14',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA15', N'LA15, FLASH POINT TESTER, COC',N'DN1-3003-0049-STL-LA15',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA17', N'LA17, SPECTROPHOTOMETER, BAUSH & LOMB',N'DN1-3003-0049-STL-LA17',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA20', N'LA20, PRESSURE RECORDER FOR INDUCTION',N'DN1-3003-0049-STL-LA20',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA21', N'LA21, FLASH POINT TESTER, TCC/HERZOG',N'DN1-3003-0049-STL-LA21',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA22', N'LA22, FLASH POINT TESTER, GRABNER',N'DN1-3003-0049-STL-LA22',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA23', N'LA23, FLASH POINT TESTER, TCC/ISL',N'DN1-3003-0049-STL-LA23',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA24', N'LA24, GAS CHROMATOGRAPH SERIES 400 LIQ 1',N'DN1-3003-0049-STL-LA24',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA25', N'LA25, GAS CHROMATOGRAPH SERIES 400 LIQ 2',N'DN1-3003-0049-STL-LA25',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA26', N'LA26, GAS CHROMATOGRAPH SERIES 400 GAS 1',N'DN1-3003-0049-STL-LA26',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA27', N'LA27, RECORDING TITRATOR ''PRODUCTS''',N'DN1-3003-0049-STL-LA27',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA28', N'LA28, RECORDING TITRATOR, ''BROMINE''',N'DN1-3003-0049-STL-LA28',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA29', N'LA29, SPECTROPHOTOMETER, HACH',N'DN1-3003-0049-STL-LA29',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA31', N'LA31, RVP ANALYZER, GRABNER #2',N'DN1-3003-0049-STL-LA31',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA32', N'LA32, RVP ANALYZER, GRABNER #1',N'DN1-3003-0049-STL-LA32',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA33', N'LA33, WT% SULFUR ANALYZER, HORIBA #1',N'DN1-3003-0049-STL-LA33',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA34', N'LA34, RVP, SETAVAP',N'DN1-3003-0049-STL-LA34',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA35', N'LA35, COPPER STRIP',N'DN1-3003-0049-STL-LA35',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA36', N'LA36, B/2 ANTI-ICING ADDITIVE TEST KIT',N'DN1-3003-0049-STL-LA36',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA37', N'LA37, INDUCTION BATH',N'DN1-3003-0049-STL-LA37',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA38', N'LA38, CONSTANT TEMPERATURE BATH 122F',N'DN1-3003-0049-STL-LA38',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA4', N'LA4, GUM BATH TEMP RANGE 300 - 600F',N'DN1-3003-0049-STL-LA4',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA40', N'LA40, CONSTANT TEMPERATURE BATH, 104F',N'DN1-3003-0049-STL-LA40',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA41', N'LA41, CONSTANT TEMPERATURE BATH, 210F',N'DN1-3003-0049-STL-LA41',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA42', N'LA42, CONSTANT TEMPERATURE BATH, -20F',N'DN1-3003-0049-STL-LA42',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA44', N'LA44, COULOMETERIC MOISTURE METER',N'DN1-3003-0049-STL-LA44',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA45', N'LA45, PH METER #1',N'DN1-3003-0049-STL-LA45',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA46', N'LA46, PH METER #2',N'DN1-3003-0049-STL-LA46',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA47', N'LA47, API GRAVITY MACHINE',N'DN1-3003-0049-STL-LA47',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA48', N'LA48, 90 MINUTE HEAT (THERMAL STABILITY)',N'DN1-3003-0049-STL-LA48',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA49', N'LA49,  FIA',N'DN1-3003-0049-STL-LA49',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA4901', N'LA4901,BOTTLE WASHER,LAB',N'DN1-3003-0049-STL-LA4901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA5', N'LA5, JET FUEL THERMAL OXIDATION TESTER 2',N'DN1-3003-0049-STL-LA5',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA50', N'LA50,  ASH FURNACE',N'DN1-3003-0049-STL-LA50',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA51', N'LA51,  CHEMICALS',N'DN1-3003-0049-STL-LA51',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA52', N'LA52, ANALYTICAL BALANCE FR-300 MKII',N'DN1-3003-0049-STL-LA52',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA53', N'LA53, ANALYTICAL BALANCE FR-300 MKI #2',N'DN1-3003-0049-STL-LA53',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA54', N'LA54, ANALYTICAL BALANCE FR-300 MKI #3',N'DN1-3003-0049-STL-LA54',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA55', N'LA55, ANALYTICAL BALANCE FR-300 MKI #4',N'DN1-3003-0049-STL-LA55',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA56', N'LA56, REFRACTIVE INDEX',N'DN1-3003-0049-STL-LA56',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA57', N'LA57, GLASSWARE',N'DN1-3003-0049-STL-LA57',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA58', N'LA58, ATOMSCAN-16 SEQUENTIAL PLASMA SPEC',N'DN1-3003-0049-STL-LA58',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA59', N'LA59, PLASTIC TUBING',N'DN1-3003-0049-STL-LA59',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA6', N'LA6, JET FUEL THERMAL OXIDATION TESTER 1',N'DN1-3003-0049-STL-LA6',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA60', N'LA60, VISCOMETERS',N'DN1-3003-0049-STL-LA60',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA61', N'LA61, ANALYZER, POUR & CLOUD POINT',N'DN1-3003-0049-STL-LA61',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA62', N'LA62, MISCELLANEOUS EQUIPMENT',N'DN1-3003-0049-STL-LA62',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA63', N'LA63, SODIUM BISULFIDE TEST',N'DN1-3003-0049-STL-LA63',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA64', N'LA64, AUTOMATIC DISTILLATION UNIT',N'DN1-3003-0049-STL-LA64',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA65', N'LA65, AUTOMATIC DISTILLATION UNIT',N'DN1-3003-0049-STL-LA65',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA66', N'LA66, AUTOMATIC DISTALLATION UNIT',N'DN1-3003-0049-STL-LA66',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA67', N'LA67, AUTOMATIC DISTILLATION UNIT',N'DN1-3003-0049-STL-LA67',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA68', N'LA68, WT% SULFUR ANALYZER HORIBA #2',N'DN1-3003-0049-STL-LA68',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA69', N'LA69, GLASSWARE WASHER FOR SAMPLE BOTTLE',N'DN1-3003-0049-STL-LA69',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA70', N'LA70, CHROMATOGRAPH, BENZENE ANALYSIS',N'DN1-3003-0049-STL-LA70',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA71', N'LA71, MILLIPORE',N'DN1-3003-0049-STL-LA71',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA72', N'LA72, TSS',N'DN1-3003-0049-STL-LA72',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA73', N'LA73, KNOCK ENGINE',N'DN1-3003-0049-STL-LA73',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA74', N'LA74, BOD METER',N'DN1-3003-0049-STL-LA74',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA75', N'LA75, DOCTOR TEST',N'DN1-3003-0049-STL-LA75',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA76', N'LA76, CHEMECTRICS',N'DN1-3003-0049-STL-LA76',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA77', N'LA77, WATER SEPERATION INST. ''WISM''',N'DN1-3003-0049-STL-LA77',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA78', N'LA78,  CONTAINERS',N'DN1-3003-0049-STL-LA78',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA79', N'LA79, OIL & GREASE MACHINE (HORIZON)',N'DN1-3003-0049-STL-LA79',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA82', N'LA82, PETROSPEC RED DYE ANALYZER',N'DN1-3003-0049-STL-LA82',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA83', N'LA83, MIDAC FTIR FOX FUEL ANALYZER',N'DN1-3003-0049-STL-LA83',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA84', N'LA84, RAMSBOTTOM CARBON RESIDUE TESTER',N'DN1-3003-0049-STL-LA84',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA86', N'LA86, SIMULATED DISTILLATION UNIT #2887A',N'DN1-3003-0049-STL-LA86',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA87', N'LA87, SIMULATED DISTILLATION UNIT #2887B',N'DN1-3003-0049-STL-LA87',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA88', N'LA88, SIMULATED DISTILLATION UNIT #3710A',N'DN1-3003-0049-STL-LA88',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA89', N'LA89, SIMULATED DISTILLATION UNIT #3710B',N'DN1-3003-0049-STL-LA89',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'STL', N'LA90', N'LA90, LAB GASES',N'DN1-3003-0049-STL-LA90',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0049-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0049', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0049-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIL', N'51F101', N'51F101, BOILER #2 FEEDWATER',N'DN1-3003-0051-SIL-51F101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIL', N'51F108', N'51F108, BOILER #1 FEEDWATER',N'DN1-3003-0051-SIL-51F108',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIL', N'51L308', N'51L308, CONDENSATE DRUM',N'DN1-3003-0051-SIL-51L308',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIV', N'51PCV208', N'51PCV208, #2 BOILER FUEL GAS REGULATOR',N'DN1-3003-0051-SIV-51PCV208',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIV', N'51PCV209', N'51PCV209, #3 BOILER FUEL GAS REGULATOR E',N'DN1-3003-0051-SIV-51PCV209',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIV', N'51PCV210', N'51PCV210, #3 BOILER FUEL GAS REGULATOR W',N'DN1-3003-0051-SIV-51PCV210',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIV', N'51PCV211', N'51PCV211, #1 BOILER FUEL GAS REGULATOR W',N'DN1-3003-0051-SIV-51PCV211',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SIV', N'51PCV212', N'51PCV212, #1 BOILER FUEL GAS REGULATOR E',N'DN1-3003-0051-SIV-51PCV212',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0002', N'PC0002, 51B502 WATER DRM TO 2-BD-51-0125',N'DN1-3003-0051-SLP-PC0002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0003', N'PC0003, 51B502 WATER DRM TO 2-BD-51-0125',N'DN1-3003-0051-SLP-PC0003',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0004', N'PC0004, 51TK501 TO 51P519 A/B',N'DN1-3003-0051-SLP-PC0004',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0005', N'PC0005, WELL #4 TO 4-WR-51-0016',N'DN1-3003-0051-SLP-PC0005',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0006', N'PC0006, 4-WR-51-0005 TO 4-WR-51-0016',N'DN1-3003-0051-SLP-PC0006',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0007', N'PC0007, 4-WR-51-0005 TO 3-WR-51-0023',N'DN1-3003-0051-SLP-PC0007',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0008', N'PC0008, 4-WR-51-0005 TO 1.5-WR-51-0010',N'DN1-3003-0051-SLP-PC0008',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0009', N'PC0009, 1-WR-51-0008 TO 51V503',N'DN1-3003-0051-SLP-PC0009',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0010', N'PC0010, 1-WR-51-0008 TO 51ME501A/B',N'DN1-3003-0051-SLP-PC0010',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0012', N'PC0012, 1.5-WR-51-0010 TO GRADE',N'DN1-3003-0051-SLP-PC0012',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0013', N'PC0013, 1.5-WR-51-0010 TO 1.5-WR-51-0012',N'DN1-3003-0051-SLP-PC0013',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0014', N'PC0014, 4-WR-51-0016 TO 1.5-WR-51-0012',N'DN1-3003-0051-SLP-PC0014',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0015', N'PC0015, 4-WR-51-0017 TO 1.5-WR51-0013',N'DN1-3003-0051-SLP-PC0015',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0016', N'PC0016, 51ME501B TO 4-WR-51-0007',N'DN1-3003-0051-SLP-PC0016',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0017', N'PC0017, 51ME501A TO 1.5-WR-51-0016',N'DN1-3003-0051-SLP-PC0017',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0018', N'PC0018, 2-WR51-0076 TO 3-WR-01-0179',N'DN1-3003-0051-SLP-PC0018',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0019', N'PC0019, 3-WR-51-0007 TO 4-WR-51-0022',N'DN1-3003-0051-SLP-PC0019',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0020', N'PC0020, 51V507 TO 51V508',N'DN1-3003-0051-SLP-PC0020',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0021', N'PC0021, 51V508 TO 51P507 A/B',N'DN1-3003-0051-SLP-PC0021',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0022', N'PC0022, 4-WR-51-0064 TO 51V506',N'DN1-3003-0051-SLP-PC0022',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0023', N'PC0023, 3-WR-51-0007 TO 3-XS-252-1011',N'DN1-3003-0051-SLP-PC0023',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0024', N'PC0024, 51V506 51TK503',N'DN1-3003-0051-SLP-PC0024',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0025', N'PC0025, 4-WR-51-0022 TO 51TK503',N'DN1-3003-0051-SLP-PC0025',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0026', N'PC0026, CHEM INJ TO 6-WB-51-0024',N'DN1-3003-0051-SLP-PC0026',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0027', N'PC0027, 51TK503 TO 51P504 A/B',N'DN1-3003-0051-SLP-PC0027',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0028', N'PC0028, 51TK503 TO 51P504 C/D',N'DN1-3003-0051-SLP-PC0028',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0029', N'PC0029, 51P504 A/B TO 4-WB-51-0211',N'DN1-3003-0051-SLP-PC0029',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0030', N'PC0030, CHEM INJ TO 8-SM-51-0098',N'DN1-3003-0051-SLP-PC0030',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0031', N'PC0031, 4-WB-51-0029 TO 3-WB-51-0032',N'DN1-3003-0051-SLP-PC0031',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0032', N'PC0032, 51P504 C/D TO 3-WB-51-0038',N'DN1-3003-0051-SLP-PC0032',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0033', N'PC0033, CHEM INJ TO 8-SM-51-0043',N'DN1-3003-0051-SLP-PC0033',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0034', N'PC0034, 51P506 A/B TO 3-WB-51-0032',N'DN1-3003-0051-SLP-PC0034',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0035', N'PC0035, CHEM INJ TO 3-WB-51-0032',N'DN1-3003-0051-SLP-PC0035',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0036', N'PC0036, 3-WB-51-0038 TO .75-WB-02-0478',N'DN1-3003-0051-SLP-PC0036',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0037', N'PC0037, 1.5-WB-51-0036 TO 2.5-WB-51-0120',N'DN1-3003-0051-SLP-PC0037',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0038', N'PC0038, 3-WB-51-0032 TO 2.5-WB-51-0121',N'DN1-3003-0051-SLP-PC0038',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0039', N'PC0039, 6-SE-51-0042 TO 51V504',N'DN1-3003-0051-SLP-PC0039',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0040', N'PC0040, 8-SE-51-0039 TO 51V502',N'DN1-3003-0051-SLP-PC0040',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0041', N'PC0041, 51P519B TURBINE TO 4-SE-51-0040',N'DN1-3003-0051-SLP-PC0041',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0042', N'PC0042, 51P504D TURBINE TO 8-SE-51-0039',N'DN1-3003-0051-SLP-PC0042',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0043', N'PC0043, 51B503 STM DRM TO 12-SM-51-0230',N'DN1-3003-0051-SLP-PC0043',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0044', N'PC0044, 51B501 STM DRM TO 8-SM-51-0043',N'DN1-3003-0051-SLP-PC0044',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0048', N'PC0048, 4-SM-51-0045 TO 51P504B TURBINE',N'DN1-3003-0051-SLP-PC0048',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0051', N'PC0051, 8-SM-51-0105 TO 51P504D TURBINE',N'DN1-3003-0051-SLP-PC0051',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0053', N'PC0053, 51B503 WATER DRM TO 2-BD-51-0125',N'DN1-3003-0051-SLP-PC0053',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0062', N'PC0062, 3-XS-252-1011 TO 51V507',N'DN1-3003-0051-SLP-PC0062',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0063', N'PC0063, 51P507 A/B TO 51E503',N'DN1-3003-0051-SLP-PC0063',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0064', N'PC0064, 51E503 TO 4-WR-51-0022',N'DN1-3003-0051-SLP-PC0064',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0065', N'PC0065, 51V502 TO 51E503',N'DN1-3003-0051-SLP-PC0065',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0066', N'PC0066, 3-WB-51-0034 TO 6-WB-51-0027',N'DN1-3003-0051-SLP-PC0066',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0067', N'PC0067, 3-WB-51-0034 TO 4-WR-51-0025',N'DN1-3003-0051-SLP-PC0067',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0068', N'PC0068, 3-WB-51-0034 TO .5-WB-51-0071',N'DN1-3003-0051-SLP-PC0068',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0069', N'PC0069, 3-WB-51-0108 TO .5-WB-51-0071',N'DN1-3003-0051-SLP-PC0069',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0070', N'PC0070, 6-WB-51-0024 TO .5-WB-51-0071',N'DN1-3003-0051-SLP-PC0070',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0071', N'PC0071, 3-WB-51-0029 TO 51E504',N'DN1-3003-0051-SLP-PC0071',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0072', N'PC0072, 3-WB-51-0034 TO 4-WR-51-0025',N'DN1-3003-0051-SLP-PC0072',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0073', N'PC0073, 3-WB-51-0034 TO 51V506',N'DN1-3003-0051-SLP-PC0073',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0075', N'PC0075, CM33/CM34/CM32 TO 8-SE-51-0039',N'DN1-3003-0051-SLP-PC0075',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0077', N'PC0077, 3-WR-15-0018 TO 53E511',N'DN1-3003-0051-SLP-PC0077',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0088', N'PC0088, 53E502/53E512 TO 51TK501',N'DN1-3003-0051-SLP-PC0088',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0090', N'PC0090, 51E503 TO GRADE',N'DN1-3003-0051-SLP-PC0090',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0091', N'PC0091, 51V508 (OVERFLOW) TO GRADE',N'DN1-3003-0051-SLP-PC0091',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0092', N'PC0092, 51V508 (BOTTOM) TO GRADE',N'DN1-3003-0051-SLP-PC0092',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0094', N'PC0094, 3-FG-54-0008 TO 51B501 BURNERS',N'DN1-3003-0051-SLP-PC0094',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0095', N'PC0095, 51B501 STM DRUM TO 2-BD-51-0126',N'DN1-3003-0051-SLP-PC0095',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0096', N'PC0096, 51F503 TO 51B502 BURNERS',N'DN1-3003-0051-SLP-PC0096',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0097', N'PC0097, 3-FG-51-0096 TO 51B502 BURNERS',N'DN1-3003-0051-SLP-PC0097',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0098', N'PC0098, 51B502 STM DRUM TO 8-SM-51-0105',N'DN1-3003-0051-SLP-PC0098',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0099', N'PC0099, 3-FG-54-0009 TO 51B503 BURNERS',N'DN1-3003-0051-SLP-PC0099',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0100', N'PC0100, 54V501 TO 3-DO-51-0103',N'DN1-3003-0051-SLP-PC0100',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0103', N'PC0103, 51V502 TO GRADE DRAIN',N'DN1-3003-0051-SLP-PC0103',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0104', N'PC0104, 3-SM-51-114 TO 2-BD-51-0125',N'DN1-3003-0051-SLP-PC0104',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0108', N'PC0108, 3-WB-51-0032 TO 51B502 ECONOMIZE',N'DN1-3003-0051-SLP-PC0108',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0109', N'PC0109, 51P508 TO 4-WR-51-0022',N'DN1-3003-0051-SLP-PC0109',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0110', N'PC0110, 2-WR-51-0083 TO 51TK501',N'DN1-3003-0051-SLP-PC0110',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0111', N'PC0111, WELL 1 TO 51TK501 (OOS)',N'DN1-3003-0051-SLP-PC0111',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0112', N'PC0112, 51V504 TO 51P506 A/B',N'DN1-3003-0051-SLP-PC0112',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0113', N'PC0113, 6-WB-51-0112 TO 4-WB-51-0034',N'DN1-3003-0051-SLP-PC0113',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0115', N'PC0115, 51B502 ECONO TO 51B502 STM DRM',N'DN1-3003-0051-SLP-PC0115',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0120', N'PC0120, 3-WB-51-0037 TO 51B503 STM DRM',N'DN1-3003-0051-SLP-PC0120',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0121', N'PC0121,3-WB-51-0038 TO 51B501 WATER DRM',N'DN1-3003-0051-SLP-PC0121',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0122', N'PC0122, 51B503 STM DRUM TO 2-BD-51-0053',N'DN1-3003-0051-SLP-PC0122',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0123', N'PC0123, 6-SE-51-0124 TO 51V506',N'DN1-3003-0051-SLP-PC0123',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0124', N'PC0124, 51P504B TURBINE TO 6-SE-51-0042',N'DN1-3003-0051-SLP-PC0124',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0125', N'PC0125, 51B502 STM DRM TO 51V502',N'DN1-3003-0051-SLP-PC0125',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0126', N'PC0126, 51B501 WATER DRM TO 3-BD-51-0125',N'DN1-3003-0051-SLP-PC0126',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0149', N'PC0149, 51P509 TO 51TK503',N'DN1-3003-0051-SLP-PC0149',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0152', N'PC0152, 51V504 TO 51P509',N'DN1-3003-0051-SLP-PC0152',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0200', N'PC0200, 3-WR-51-0005 TO 51SC11',N'DN1-3003-0051-SLP-PC0200',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0211', N'PC0211, 4-WB-51-0029 TO 2-WB-04-0411',N'DN1-3003-0051-SLP-PC0211',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0477', N'PC0477, .75-SM-51-0467 TO 2-CL-51-0059',N'DN1-3003-0051-SLP-PC0477',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SLP', N'PC0501', N'PC0501, 51B501 STM DRM TO GRADE',N'DN1-3003-0051-SLP-PC0501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMA', N'51ME533', N'51ME533, SALT TRANSFER AUGER',N'DN1-3003-0051-SMA-51ME533',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMF', N'51C501', N'51C501, DECARBONATOR BLOWER',N'DN1-3003-0051-SMF-51C501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS501A', N'51IS501A, BETZDEARBORN 60404 NORTH',N'DN1-3003-0051-SMP-51IS501A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS501B', N'51IS501B, BETZDEARBORN 60404 CENTER',N'DN1-3003-0051-SMP-51IS501B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS501C', N'51IS501C, BETZDEARBORN 60404 SOUTH',N'DN1-3003-0051-SMP-51IS501C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS502A', N'51IS502A, BETZDRBRN IS1050 INJ SYS SOUTH',N'DN1-3003-0051-SMP-51IS502A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS502B', N'51IS502B, BETZDRBRN IS1050 INJ SYS NORTH',N'DN1-3003-0051-SMP-51IS502B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS503A', N'51IS503A, BETZDEARBRN PAS781 INJECTION N',N'DN1-3003-0051-SMP-51IS503A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS503B', N'51IS503B, BETZDEARBRN PAS781 INJECTION S',N'DN1-3003-0051-SMP-51IS503B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51IS509', N'51IS509, DECARB ACID INJECTION PUMP',N'DN1-3003-0051-SMP-51IS509',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P504A', N'51P504A, REFORMER/CRUDE BFW EAST',N'DN1-3003-0051-SMP-51P504A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P504B', N'51P504B, REFORMER/CRUDE BFW WEST',N'DN1-3003-0051-SMP-51P504B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P504C', N'51P504C, BOILER HOUSE BFW NORTH',N'DN1-3003-0051-SMP-51P504C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P504D', N'51P504D, BOILER HOUSE BFW SOUTH',N'DN1-3003-0051-SMP-51P504D',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P506A', N'51P506A, CONDENSATE EAST',N'DN1-3003-0051-SMP-51P506A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P506B', N'51P506B, CONDENSATE WEST',N'DN1-3003-0051-SMP-51P506B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P507A', N'51P507A, DECARBONATOR PUMP (NORTH)',N'DN1-3003-0051-SMP-51P507A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P507B', N'51P507B, DECARBONATOR PUMP (SOUTH)',N'DN1-3003-0051-SMP-51P507B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P509', N'51P509, CONDENSATE TO BFW TANK PUMP',N'DN1-3003-0051-SMP-51P509',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P519A', N'51P519A, RAW WATER EAST (ELECTRIC)',N'DN1-3003-0051-SMP-51P519A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SMP', N'51P519B', N'51P519B, RAW WATER WEST (TURBINE)',N'DN1-3003-0051-SMP-51P519B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPH', N'51B501', N'51B501, BOILER #1',N'DN1-3003-0051-SPH-51B501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPH', N'51B502', N'51B502, BOILER #2',N'DN1-3003-0051-SPH-51B502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPH', N'51B503', N'51B503, BOILER #3',N'DN1-3003-0051-SPH-51B503',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPH', N'51E503', N'51E503,BOILER FEED WATER SAMPLE COOLER',N'DN1-3003-0051-SPH-51E503',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPH', N'51E504', N'51E504, BFW PH CONTROL SYS SAMPLE COOLER',N'DN1-3003-0051-SPH-51E504',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51F503', N'51F503, #2 BOILER FUEL GAS FILTER',N'DN1-3003-0051-SPT-51F503',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51ME501A', N'51ME501A, SOFTENER EAST',N'DN1-3003-0051-SPT-51ME501A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51ME501B', N'51ME501B, SOFTENER WEST',N'DN1-3003-0051-SPT-51ME501B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51TK501', N'51TK501, RAW WATER TANK',N'DN1-3003-0051-SPT-51TK501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51TK502', N'51TK502, SALT TANK',N'DN1-3003-0051-SPT-51TK502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51TK503', N'51TK503, BFW TANK',N'DN1-3003-0051-SPT-51TK503',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V501', N'51V501, FUEL GAS KNOCK-OUT POT',N'DN1-3003-0051-SPT-51V501',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V502', N'51V502, BLOWDOWN DRUM 12 PSI STEAM',N'DN1-3003-0051-SPT-51V502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V503', N'51V503, WATER SOFTNER BRINE DRUM',N'DN1-3003-0051-SPT-51V503',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V504', N'51V504, CONDENSATE DRUM',N'DN1-3003-0051-SPT-51V504',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V506', N'51V506, DEAEREATOR',N'DN1-3003-0051-SPT-51V506',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V507', N'51V507, PICKLE BARREL',N'DN1-3003-0051-SPT-51V507',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SPT', N'51V508', N'51V508, SURGE DRUM',N'DN1-3003-0051-SPT-51V508',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV501A', N'51PSV501A, NUMBER 1 BOILER 51B501',N'DN1-3003-0051-SSR-51PSV501A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV501B', N'51PSV501B, NUMBER 1 BOILER 51B501',N'DN1-3003-0051-SSR-51PSV501B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV501C', N'51PSV501C, NUMBER 1 BOILER 51B501',N'DN1-3003-0051-SSR-51PSV501C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV501D', N'51PSV501D, NUMBER 1 BOILER 51B501',N'DN1-3003-0051-SSR-51PSV501D',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV502A', N'51PSV502A, NUMBER 2 BOILER 51B502',N'DN1-3003-0051-SSR-51PSV502A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV502B', N'51PSV502B, NUMBER 2 BOILER 51B502',N'DN1-3003-0051-SSR-51PSV502B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV503A', N'51PSV503A, NUMBER 3 BOILER 51B503',N'DN1-3003-0051-SSR-51PSV503A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV503B', N'51PSV503B, NUMBER 3 BOILER 51B503',N'DN1-3003-0051-SSR-51PSV503B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV503C', N'51PSV503C, NUMBER 3 BOILER 51B503',N'DN1-3003-0051-SSR-51PSV503C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV504B', N'51PSV504B, STEAM TURBINE PSV',N'DN1-3003-0051-SSR-51PSV504B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV504D', N'51PSV504D, STEAM TURBINE PSV',N'DN1-3003-0051-SSR-51PSV504D',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV505', N'51PSV505, COND DRUM 51V504 (20 PSIG)',N'DN1-3003-0051-SSR-51PSV505',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0051', N'SSR', N'51PSV519B', N'51PSV519B, STEAM TURBINE PSV',N'DN1-3003-0051-SSR-51PSV519B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0052-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0052-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS1', N'MS1,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS10', N'MS10,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS10',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS11', N'MS11,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS11',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS12', N'MS12,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS12',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS13', N'MS13,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS13',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS14', N'MS14,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS14',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS15', N'MS15,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS15',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS16', N'MS16,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS16',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS17', N'MS17,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS17',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS18', N'MS18,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS18',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS19', N'MS19,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS19',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS2', N'MS2,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS2',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS20', N'MS20,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS20',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS21', N'MS21,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS21',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS22', N'MS22,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS22',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS23', N'MS23,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS23',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS24', N'MS24,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS24',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS25', N'MS25,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS25',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS26', N'MS26,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS26',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS27', N'MS27,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS27',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS28', N'MS28,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS28',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS29', N'MS29,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS29',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS3', N'MS3,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS3',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS30', N'MS30,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS30',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS31', N'MS31,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS31',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS32', N'MS32,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS32',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS33', N'MS33,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS33',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS4', N'MS4,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS4',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS5', N'MS5,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS5',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS6', N'MS6,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS6',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS7', N'MS7,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS7',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS8', N'MS8,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS8',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0052', N'SWM', N'MS9', N'MS9,SHOP EQUIPMENT',N'DN1-3003-0052-SWM-MS9',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SMP', N'53P1', N'53P1, AIR COMP CONDENSATE PUMP',N'DN1-3003-0053-SMP-53P1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPH', N'53E501A', N'53E501A,ELECTRIC UTILITY AIR HEATER',N'DN1-3003-0053-SPH-53E501A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPH', N'53E501B', N'53E501B,ELECTRIC UTILITY AIR HEATER',N'DN1-3003-0053-SPH-53E501B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPT', N'53F502', N'53F502, UTILITY AIR CHARCOAL FILTER',N'DN1-3003-0053-SPT-53F502',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPT', N'53ME502E', N'53ME502E, PLANT AIR DRYER EAST',N'DN1-3003-0053-SPT-53ME502E',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPT', N'53ME502W', N'53ME502W, PLANT AIR DRYER WEST',N'DN1-3003-0053-SPT-53ME502W',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0053', N'SPT', N'53TK507', N'53TK507, TK ACID STORAGE TANK',N'DN1-3003-0053-SPT-53TK507',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0054', N'SLP', N'PC0002', N'PC0002, 3-FG-54-0003 TO  51B502',N'DN1-3003-0054-SLP-PC0002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0054', N'SLP', N'PC0008', N'PC0008, 54V501 TO 51B501',N'DN1-3003-0054-SLP-PC0008',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0054', N'SLP', N'PC0009', N'PC0009, 54V501 TO 51B503',N'DN1-3003-0054-SLP-PC0009',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'D032', N'D032, MISC TESTING (PORTABLE)',N'DN1-3003-0055-STI-D032',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'DMS1', N'DMS1, INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-DMS1',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'DMS2A', N'DMS2A, HFXV, INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-DMS2A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'DMS2B', N'DMS2B, HFXW,  INSECTION EQUIPMENT',N'DN1-3003-0055-STI-DMS2B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'NA01', N'NA01, NITON ANALYSER',N'DN1-3003-0055-STI-NA01',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'USK7A', N'USK7A, 2527,INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-USK7A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'USK7B', N'USK7B,  5521, INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-USK7B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'USK7C', N'USK7C, 3736,  INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-USK7C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'STI', N'USK7D', N'USK7D,#2496,  INSPECTION EQUIPMENT',N'DN1-3003-0055-STI-USK7D',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0055-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0055', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0055-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0057', N'SPT', N'57D002', N'57D002, SOUTH FLARE KO POT @ BUNDLE PAD',N'DN1-3003-0057-SPT-57D002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0057', N'SPT', N'57F001', N'57F001,INSTRUMENT AIR FILTER',N'DN1-3003-0057-SPT-57F001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0059', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0059-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0059', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0059-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70A901', N'70A901, WASTEWATER PH',N'DN1-3003-0070-SIL-70A901',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F1001', N'70F1001, EFFLUENT WTR TO SAND CRK METER',N'DN1-3003-0070-SIL-70F1001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F103', N'70F103, TREATED WTR DISCHARGE',N'DN1-3003-0070-SIL-70F103',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F104', N'70F104, AIR FLOW TO TK19 DIFFUSERS',N'DN1-3003-0070-SIL-70F104',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F105', N'70F105, AIR FLOW TO TK29 DIFFUSERS',N'DN1-3003-0070-SIL-70F105',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F110', N'70F110, AIR FLOW TO TK19 (LOW RANGE)',N'DN1-3003-0070-SIL-70F110',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70F111', N'70F111, AIR FLOW TO TK29 (LOW RANGE)',N'DN1-3003-0070-SIL-70F111',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70L302', N'70L302, TK19 HIGH HIGH LEVEL',N'DN1-3003-0070-SIL-70L302',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70P204', N'70P204, AIR TO TK19 DIFFUSERS',N'DN1-3003-0070-SIL-70P204',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70P205', N'70P205, AIR TO TK29 TANK DIFFUSERS',N'DN1-3003-0070-SIL-70P205',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70P206', N'70P206, AIR PRESS TO TK19 (LOW RANGE)',N'DN1-3003-0070-SIL-70P206',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70P207', N'70P207, AIR PRESS TO TK29 (LOW RANGE)',N'DN1-3003-0070-SIL-70P207',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70T401B', N'70T401B, TK19 BIO-TREATMENT TEMPERATURE',N'DN1-3003-0070-SIL-70T401B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70T401C', N'70T401C, TK19 BIO-TREATMENT TEMPERATURE',N'DN1-3003-0070-SIL-70T401C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70Y802', N'70Y802, COMPRESSOR 702 RUNNING',N'DN1-3003-0070-SIL-70Y802',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIL', N'70Y803', N'70Y803, COMPRESSOR 703 RUNNING',N'DN1-3003-0070-SIL-70Y803',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SIV', N'70LV304', N'70LV304, 19-29 LEVEL TO CLARIFER',N'DN1-3003-0070-SIV-70LV304',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMA', N'70CLARIFIER2', N'70CLARIFIER2, MIXER',N'DN1-3003-0070-SMA-70CLARIFIER2',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMA', N'70CLARIFIER3', N'70CLARIFIER3, MIXER',N'DN1-3003-0070-SMA-70CLARIFIER3',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMF', N'70C702', N'70C702, SOUTH AIR BLOWER (WWTS)',N'DN1-3003-0070-SMF-70C702',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMF', N'70C703', N'70C703, NORTH AIR BLOWER (WWTS)',N'DN1-3003-0070-SMF-70C703',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMF', N'70C705', N'70C705, D.O. TANK COMPRESSOR',N'DN1-3003-0070-SMF-70C705',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P925', N'70P925, SAND FILTER (VENT JOHNSTON)',N'DN1-3003-0070-SMP-70P925',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P926', N'70P926, SAND CREEK (SETTLING POND WEST)',N'DN1-3003-0070-SMP-70P926',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P927', N'70P927, SAND CREEK (SETTLING POND EAST)',N'DN1-3003-0070-SMP-70P927',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P928', N'70P928, SOUTH CLARIFIER PUMP',N'DN1-3003-0070-SMP-70P928',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P929', N'70P929, CENTER CLARIFIER PUMP',N'DN1-3003-0070-SMP-70P929',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P930', N'70P930, NORTH CLARIFIER SLUDGE PUMP',N'DN1-3003-0070-SMP-70P930',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SMP', N'70P957', N'70P957, HOLDING POND CIRCULATION',N'DN1-3003-0070-SMP-70P957',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0070', N'SPT', N'70TK701', N'70TK701, DISOLVED OXYGEN',N'DN1-3003-0070-SPT-70TK701',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0072', N'SMP', N'72P006', N'72P006, #6 WATER WELL (OUT OF SERVICE)',N'DN1-3003-0072-SMP-72P006',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0219', N'PC0219, D57 TO RV490 (OOS)',N'DN1-3003-0074-SLP-PC0219',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0220', N'PC0220, D57 2-HL-74-219 TO FLARE (OOS)',N'DN1-3003-0074-SLP-PC0220',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0222', N'PC0222, RV490/D57 TO W21 (OOS)',N'DN1-3003-0074-SLP-PC0222',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0223', N'PC0223, D57 TO SEWER (OOS)',N'DN1-3003-0074-SLP-PC0223',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0224', N'PC0224, D57 TO 1.5-HM-74-225 (OOS)',N'DN1-3003-0074-SLP-PC0224',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0225', N'PC0225, D57 TO 2-HM-74-223 (OOS)',N'DN1-3003-0074-SLP-PC0225',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SLP', N'PC0226', N'PC0226,1.5-WW-74-225 TO.75-WW-74-259(OOS',N'DN1-3003-0074-SLP-PC0226',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SMF', N'F7411', N'F7411,FAN,SWS CONDENSER',N'DN1-3003-0074-SMF-F7411',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SMF', N'F7412', N'F7412,FAN,SWS CONDENSER',N'DN1-3003-0074-SMF-F7412',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SPT', N'D57', N'D57, DRUM, OIL SEPERATOR',N'DN1-3003-0074-SPT-D57',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SPT', N'W22', N'W22, TOWER, SOUR WATER STRIPPER',N'DN1-3003-0074-SPT-W22',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0074-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0074', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0074-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0081', N'PC0081, N2 HEADER TO H2001',N'DN1-3003-0075-SLP-PC0081',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0087', N'PC0087, CITY GAS HEADER TO H2003',N'DN1-3003-0075-SLP-PC0087',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0088', N'PC0088, N2 HEADER TO H2003',N'DN1-3003-0075-SLP-PC0088',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0093', N'PC0093, X2005 TO BOILER BLOWDOWN',N'DN1-3003-0075-SLP-PC0093',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0094', N'PC0094, X2005 TO SAMPLE COOLER',N'DN1-3003-0075-SLP-PC0094',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SLP', N'PC0105', N'PC0105, X2005 TO BOILER BLOWDOWN',N'DN1-3003-0075-SLP-PC0105',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SMP', N'P2006', N'P2006, PUMP, #2 SRU SULFUR',N'DN1-3003-0075-SMP-P2006',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SPH', N'H2002', N'H2002, HEATER, #2 SRU ACID GAS',N'DN1-3003-0075-SPH-H2002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SPH', N'H2003', N'H2003, INCINERATOR, #2 SRU',N'DN1-3003-0075-SPH-H2003',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0075-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0075', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0075-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', null, null, N'TAIL GAS (OUT OF SERVICE),  PLANT #1',N'DN1-3003-0076',7000,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SAB', null, N'BUILDING,FIXTURE & HVAC',N'DN1-3003-0076-SAB',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SIC', null, N'CONTROL SYSTEM & STATION',N'DN1-3003-0076-SIC',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SIC', N'76PCLC28', N'76PLC28, TGU SAMPLE LINE TUBE BUNDLE',N'DN1-3003-0076-SIC-76PCLC28',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SIL', null, N'INSTRUMENT LOOP',N'DN1-3003-0076-SIL',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SLE', null, N'PIPELINE EQUIPMENT',N'DN1-3003-0076-SLE',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SLP', null, N'PIPING CIRCUIT',N'DN1-3003-0076-SLP',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SMP', null, N'PUMP & MOTOR',N'DN1-3003-0076-SMP',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SPH', null, N'HEATER,EXCHANGER & COOLER',N'DN1-3003-0076-SPH',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SPT', null, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD',N'DN1-3003-0076-SPT',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SSR', null, N'RELIEF DEVICE & PRESSURE PROTECTION',N'DN1-3003-0076-SSR',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0076', N'SUU', null, N'UNCLASSIFIED EQUIPMENT',N'DN1-3003-0076-SUU',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0077', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0077-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0077', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0077-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0083', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0083-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0083', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0083-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0092', N'SLE', N'S5', N'S5, FILTER, CARBON BED FILTER',N'DN1-3003-0092-SLE-S5',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0092', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0092-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0092', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0092-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', null, null, N'STAND-BY EQUIPMENT,  PLANT #1',N'DN1-3003-0097',7000,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SEM', null, N'MOTOR,DRIVE,BRAKE & CLUTCH',N'DN1-3003-0097-SEM',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SLE', null, N'PIPELINE EQUIPMENT',N'DN1-3003-0097-SLE',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SLP', null, N'PIPING CIRCUIT',N'DN1-3003-0097-SLP',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SLP', N'PC0381', N'PC0381, PSV478 TO FLARE',N'DN1-3003-0097-SLP-PC0381',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SLP', N'PC0382', N'PC0382, D261 TO PSV478',N'DN1-3003-0097-SLP-PC0382',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SMA', null, N'AGITATION & MIXING',N'DN1-3003-0097-SMA',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SMF', null, N'FAN,BLOWER & COMPRESSOR',N'DN1-3003-0097-SMF',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SMG', null, N'GEARBOX',N'DN1-3003-0097-SMG',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SMP', null, N'PUMP & MOTOR',N'DN1-3003-0097-SMP',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SPH', null, N'HEATER,EXCHANGER & COOLER',N'DN1-3003-0097-SPH',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SPT', null, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD',N'DN1-3003-0097-SPT',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SSF', null, N'FIRE PROTECTION',N'DN1-3003-0097-SSF',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0097', N'SSR', null, N'RELIEF DEVICE & PRESSURE PROTECTION',N'DN1-3003-0097-SSR',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', null, null, N'SURPLUS, DENVER REFINERY',N'DN1-3003-0098',7000,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SCH', null, N'HOISTING & LIFTING EQUIPMENT',N'DN1-3003-0098-SCH',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SEM', null, N'MOTOR,DRIVE,BRAKE & CLUTCH',N'DN1-3003-0098-SEM',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SIL', null, N'INSTRUMENT LOOP',N'DN1-3003-0098-SIL',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SLE', null, N'PIPELINE EQUIPMENT',N'DN1-3003-0098-SLE',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SMA', null, N'AGITATION & MIXING',N'DN1-3003-0098-SMA',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SMF', null, N'FAN,BLOWER & COMPRESSOR',N'DN1-3003-0098-SMF',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SMG', null, N'GEARBOX',N'DN1-3003-0098-SMG',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SMP', null, N'PUMP & MOTOR',N'DN1-3003-0098-SMP',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SMT', null, N'TURBINE',N'DN1-3003-0098-SMT',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SPH', null, N'HEATER,EXCHANGER & COOLER',N'DN1-3003-0098-SPH',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SPT', null, N'DRUM,COLUMN,TANK,VESSEL,WELLHEAD',N'DN1-3003-0098-SPT',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SSF', null, N'FIRE PROTECTION',N'DN1-3003-0098-SSF',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0098', N'SSR', null, N'RELIEF DEVICE & PRESSURE PROTECTION',N'DN1-3003-0098-SSR',7000,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0099', null, null, N'MOBILE EQUIPMENT, PLANT #2',N'DN1-3003-0099',7000,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SLE', N'S2010', N'S2010, FILTER 100 MICRON',N'DN1-3003-0145-SLE-S2010',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SLE', N'S2011', N'S2011, FILTER 10 MICRON',N'DN1-3003-0145-SLE-S2011',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMA', N'A51', N'A51,AERATOR, #2 LAGOON',N'DN1-3003-0145-SMA-A51',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMA', N'A52', N'A52,AERATOR, SURGE BASIN',N'DN1-3003-0145-SMA-A52',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMA', N'A53', N'A53,AERATOR, SURGE BASIN',N'DN1-3003-0145-SMA-A53',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMA', N'A54', N'A54,AERATOR, SURGE BASIN',N'DN1-3003-0145-SMA-A54',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMF', N'C54', N'C54, COMPRESSOR, GROUND WATER AIR',N'DN1-3003-0145-SMF-C54',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMP', N'J178', N'J178, PUMP, POLYMER INJECTION',N'DN1-3003-0145-SMP-J178',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMP', N'J179', N'J179, PUMP, CAUSTIC INJECTION',N'DN1-3003-0145-SMP-J179',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMP', N'J181', N'J181, PUMP,DYE INJECTION',N'DN1-3003-0145-SMP-J181',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMP', N'J182', N'J182, PUMP,DYE INJECTION',N'DN1-3003-0145-SMP-J182',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SMP', N'P510', N'P510, PUMP, CREEK WATER',N'DN1-3003-0145-SMP-P510',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T786', N'T786, TANK, SUMP 3 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T786',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T787', N'T787, TANK, SUMP 4 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T787',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T788', N'T788, TANK, SUMP 5 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T788',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T789', N'T789, TANK, SUMP 6 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T789',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T790', N'T790, TANK',N'DN1-3003-0145-SPT-T790',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T791', N'T791, STORAGE TANK',N'DN1-3003-0145-SPT-T791',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T792', N'T792, SUMP7 RECOVERY PRODUCT STORAGE',N'DN1-3003-0145-SPT-T792',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T796', N'T796, TANK, SUMP 2 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T796',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SPT', N'T797', N'T797, TANK, SUMP 7 PRODUCT STORAGE',N'DN1-3003-0145-SPT-T797',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0145-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0145', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0145-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0151', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0151-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0151', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0151-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0154', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0154-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0154', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0154-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0178', N'SUU', N'HAND_TOOLS', N'HAND TOOLS',N'DN1-3003-0178-SUU-HAND_TOOLS',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0178', N'SUU', N'MISC_LAB', N'LABORATORY, MISCELLANEOUS',N'DN1-3003-0178-SUU-MISC_LAB',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0208', N'SPH', N'08E298', N'08E298, ISO-BUTANE COOLER',N'DN1-3003-0208-SPH-08E298',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0208', N'SPH', N'08E316', N'08E316, WATER WASH HEATER',N'DN1-3003-0208-SPH-08E316',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMA', N'210MX46', N'210MX46, TK46 MIXER',N'DN1-3003-0210-SMA-210MX46',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P1013', N'210P1013, PROPANE PUMP',N'DN1-3003-0210-SMP-210P1013',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P1103', N'210P1103, TK24 INJEC TO WYCO S TK FARM',N'DN1-3003-0210-SMP-210P1103',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P1104', N'210P1104, TK24 INJECT. CV HYDRAULIC',N'DN1-3003-0210-SMP-210P1104',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P515', N'210P515,  TK42/43 DIESEL FUEL ADDITIVE',N'DN1-3003-0210-SMP-210P515',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P802', N'210P802,  WATER FOXHILL',N'DN1-3003-0210-SMP-210P802',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P803', N'210P803,  WATER FOXHILL',N'DN1-3003-0210-SMP-210P803',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P804', N'210P804,  WATER ARAPHOE',N'DN1-3003-0210-SMP-210P804',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P805', N'210P805,  FIRE LINE',N'DN1-3003-0210-SMP-210P805',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P806', N'210P806,  WATER SURFACE',N'DN1-3003-0210-SMP-210P806',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P911', N'210P911,  SOUTH TRANSFER',N'DN1-3003-0210-SMP-210P911',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P914', N'210P914,  BUTNE UNLOAD SLAB NEAR SHOP',N'DN1-3003-0210-SMP-210P914',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P918', N'210P918,  VAP RECOVERY OUTSIDE LWR HOUSE',N'DN1-3003-0210-SMP-210P918',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P919', N'210P919,  NUMBER 5 FUEL OIL',N'DN1-3003-0210-SMP-210P919',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P925', N'210P925,  SAND FILTER (SETTLING POND)',N'DN1-3003-0210-SMP-210P925',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P940A', N'210P940A, CRUDE BOOSTER SPARE HORIZONTAL',N'DN1-3003-0210-SMP-210P940A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P940B', N'210P940B, MAIN CRUDE BOOSTER (VERTICAL)',N'DN1-3003-0210-SMP-210P940B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P942A', N'210P942A, TK43 OLD WYCO XFER PMP S TK FM',N'DN1-3003-0210-SMP-210P942A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P942B', N'210P942B, TK43 NEW WYCO XFER PMP S TK FM',N'DN1-3003-0210-SMP-210P942B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P943', N'210P943,  CIRCULATION/TRANS & TANK FARM',N'DN1-3003-0210-SMP-210P943',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P944', N'210P944,  NO LEAD (DOCK)',N'DN1-3003-0210-SMP-210P944',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P945', N'210P945,  SMALL NL CIRC/XFER S TK FRM',N'DN1-3003-0210-SMP-210P945',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P948', N'210P948,  TK43, OLD KERO, S TK FARM',N'DN1-3003-0210-SMP-210P948',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P949', N'210P949,  TK43, INTERSTAGE, SO TK FARM',N'DN1-3003-0210-SMP-210P949',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P953', N'210P953,  TK05 SLOP (NEAR TK5)',N'DN1-3003-0210-SMP-210P953',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P954A', N'210P954A, DIESEL ADDITIVE',N'DN1-3003-0210-SMP-210P954A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P954B', N'210P954B, DIESEL ADDITIVE',N'DN1-3003-0210-SMP-210P954B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P955', N'210P955, DIESEL ADDITIVE',N'DN1-3003-0210-SMP-210P955',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P963', N'210P963,  TK32 FUEL OIL TO UNITS N PUMP',N'DN1-3003-0210-SMP-210P963',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P964', N'210P964,  TK32FUEL OIL-UNITS CENTER PUMP',N'DN1-3003-0210-SMP-210P964',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P965', N'210P965,  TK32 FUEL OIL TO UNITS  PUMP',N'DN1-3003-0210-SMP-210P965',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P968', N'210P968,  MMT INJECTION BY LAPI',N'DN1-3003-0210-SMP-210P968',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P978', N'210P978,  DIESEL FUEL ADDITIVE, SOUTH',N'DN1-3003-0210-SMP-210P978',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P981', N'210P981,  GAS OIL UNLOADING PUMP',N'DN1-3003-0210-SMP-210P981',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P983', N'210P983,  AVGAS LOADING PUMP',N'DN1-3003-0210-SMP-210P983',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SMP', N'210P984', N'210P984,  TK59 IN EAST TANK FARM',N'DN1-3003-0210-SMP-210P984',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPH', N'210E105', N'210E105, BIG BERTHA',N'DN1-3003-0210-SPH-210E105',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPH', N'210E106', N'210E106, TK32',N'DN1-3003-0210-SPH-210E106',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPH', N'210H102', N'210TK39,FUEL OIL HEATER',N'DN1-3003-0210-SPH-210H102',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F100', N'210F100, JET FILTER (LARGE) NORTH',N'DN1-3003-0210-SPT-210F100',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F104C', N'210F104C,KERO JET FUEL RUNDWN FLTR-WEST',N'DN1-3003-0210-SPT-210F104C',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F106', N'210F106,PHLIPS FLTR @ SE CORNER E TK FRM',N'DN1-3003-0210-SPT-210F106',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F107', N'210F107, TK24 TO WYCO INJECTION',N'DN1-3003-0210-SPT-210F107',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F108', N'210F108, CALCIUM CHLORIDE SCRBR N VESSEL',N'DN1-3003-0210-SPT-210F108',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F109', N'210F109, CAUSTIC SCRUBBER (SOUTH VESSEL)',N'DN1-3003-0210-SPT-210F109',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210F110', N'210F110, AVGAS FILTER',N'DN1-3003-0210-SPT-210F110',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210ME1000', N'210ME1000, PROPANE ODORANT SYSTEM',N'DN1-3003-0210-SPT-210ME1000',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK1S', N'210TK1S, SLOP TANK #1 (OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK1S',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK23', N'210TK23, TRANSMIX (CONDEMED)',N'DN1-3003-0210-SPT-210TK23',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK2S', N'210TK2S, SLOP TANK #2 (OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK2S',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK32', N'210TK32, SLURRY (OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK32',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK3S', N'210TK3S, SLOP TANK #3, (OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK3S',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK4', N'210TK4, OFF-SPEC PRODUCT(OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK4',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK40', N'210TK40, GASOLINE',N'DN1-3003-0210-SPT-210TK40',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK41', N'210TK41, GASOLINE',N'DN1-3003-0210-SPT-210TK41',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK42', N'210TK42, DIESEL LOW(OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK42',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK43', N'210TK43, #2 ULSD',N'DN1-3003-0210-SPT-210TK43',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK44', N'210TK44, POLY GAS',N'DN1-3003-0210-SPT-210TK44',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK45', N'210TK45, UNFINISHED LCO',N'DN1-3003-0210-SPT-210TK45',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK46', N'210TK46, SLURRY RUN DOWN',N'DN1-3003-0210-SPT-210TK46',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK47', N'210TK47, REFORMATE',N'DN1-3003-0210-SPT-210TK47',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK48', N'210TK48, #1 DISTILLATE',N'DN1-3003-0210-SPT-210TK48',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK49', N'210TK49, #1 DISTILLATE',N'DN1-3003-0210-SPT-210TK49',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK5', N'210TK5, TRANSMIX (OUT OF SERVICE)',N'DN1-3003-0210-SPT-210TK5',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK50', N'210TK50, N-BUTANE',N'DN1-3003-0210-SPT-210TK50',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK51', N'210TK51, N-BUTANE',N'DN1-3003-0210-SPT-210TK51',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK52', N'210TK52, FCC GAS',N'DN1-3003-0210-SPT-210TK52',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK53', N'210TK53, POLY GAS',N'DN1-3003-0210-SPT-210TK53',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK54', N'210TK54, FCC GAS',N'DN1-3003-0210-SPT-210TK54',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK57', N'210TK57, UNFINISHED DIESEL',N'DN1-3003-0210-SPT-210TK57',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK58', N'210TK58, HEAVY NAPHTHA',N'DN1-3003-0210-SPT-210TK58',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210TK59', N'210TK59, A024 ADDITIVE TANK',N'DN1-3003-0210-SPT-210TK59',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0210', N'SPT', N'210V110', N'210V110, AIR RECEIVER PRESSURE VESSEL',N'DN1-3003-0210-SPT-210V110',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0252', N'SMP', N'252IS505A', N'252IS505A, COOLING H20 ACID INJEC WEST',N'DN1-3003-0252-SMP-252IS505A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0252', N'SMP', N'252IS505B', N'252IS505B, COOLING H20 ACID INJEC W CNTR',N'DN1-3003-0252-SMP-252IS505B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0252', N'SMP', N'252IS508', N'252IS508, CHLORINE INJECTION SYSTEM',N'DN1-3003-0252-SMP-252IS508',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SEC', N'310DOCKCOMPUTER', N'310DOCKCOMPUTER, COMPUTER ON LOADING DK',N'DN1-3003-0310-SEC-310DOCKCOMPUTER',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SIL', N'310L304A', N'310L304A, BAY 1/2 VAPOR LINE',N'DN1-3003-0310-SIL-310L304A',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SIL', N'310L304B', N'310L304B, BAY 3/4 VAPOR LINE',N'DN1-3003-0310-SIL-310L304B',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SLP', N'PC0218', N'PC0218, 4-HL-210-1100 TO 310ME1003 (OOS)',N'DN1-3003-0310-SLP-PC0218',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SLP', N'PC0319', N'PC0319, OUT OF SERVICE',N'DN1-3003-0310-SLP-PC0319',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SLP', N'PC0775', N'PC0775, 310P980(OOS) TO 6-HL-310-0754',N'DN1-3003-0310-SLP-PC0775',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SMP', N'310P101', N'310P101, NEW CRUDE DOCK #1',N'DN1-3003-0310-SMP-310P101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SPT', N'310F101', N'310F101,DK1,VOLUME POT (AIR ELIMINATOR)',N'DN1-3003-0310-SPT-310F101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SPT', N'310V101', N'310V101,CRUDE SEPARATOR @ TRANSPORTATION',N'DN1-3003-0310-SPT-310V101',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0310', N'SSR', N'310PSV106', N'310PSV106, NEW CRUDE DOCKS SEPARATOR',N'DN1-3003-0310-SSR-310PSV106',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS001', N'410IS001, P DIESEL FUEL BAY 1',N'DN1-3003-0410-SMP-410IS001',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS002', N'410IS002, P DIESEL FUEL BAY 2',N'DN1-3003-0410-SMP-410IS002',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS003', N'410IS003, P DIESEL FUEL BAY 3',N'DN1-3003-0410-SMP-410IS003',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS011', N'410IS011, PNL BAY 1',N'DN1-3003-0410-SMP-410IS011',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS021', N'410IS021, NL BAY 1',N'DN1-3003-0410-SMP-410IS021',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS031', N'410IS031, MID GRADE BAY 1',N'DN1-3003-0410-SMP-410IS031',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS061', N'410IS061, PNL BAY 2',N'DN1-3003-0410-SMP-410IS061',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS071', N'410IS071, NL BAY 2',N'DN1-3003-0410-SMP-410IS071',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS081', N'410IS081, MID GRADE BAY 2',N'DN1-3003-0410-SMP-410IS081',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS111', N'410IS111, PNL BAY 3',N'DN1-3003-0410-SMP-410IS111',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS121', N'410IS121, NL BAY 3',N'DN1-3003-0410-SMP-410IS121',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS131', N'410IS131, MID GRADE BAY 3',N'DN1-3003-0410-SMP-410IS131',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS161', N'410IS161, PNL BAY 4',N'DN1-3003-0410-SMP-410IS161',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS171', N'410IS171, NL BAY 4',N'DN1-3003-0410-SMP-410IS171',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS181', N'410IS181, MID GRADE BAY 4',N'DN1-3003-0410-SMP-410IS181',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS241', N'410IS241, JET BAY 1',N'DN1-3003-0410-SMP-410IS241',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS251', N'410IS251, DIESEL FUEL BAY 1',N'DN1-3003-0410-SMP-410IS251',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS311', N'410IS311, ADDITIVE METER BAY 1 PNL',N'DN1-3003-0410-SMP-410IS311',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS321', N'410IS321, ADDITIVE METER BAY 1 NL',N'DN1-3003-0410-SMP-410IS321',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS331', N'410IS331, ADDITIVE METER BAY 1 MID-G',N'DN1-3003-0410-SMP-410IS331',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS361', N'410IS361, ADDITIVE METER BAY 4 PNL',N'DN1-3003-0410-SMP-410IS361',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS371', N'410IS371, ADDITIVE METER BAY 4 NL',N'DN1-3003-0410-SMP-410IS371',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410IS381', N'410IS381, ADDITIVE MTR BAY 4 MID-G',N'DN1-3003-0410-SMP-410IS381',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SMP', N'410P982', N'410P982, AVGAS RAILCAR UNLOADING PUMP',N'DN1-3003-0410-SMP-410P982',7000,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 2, N'DN1', N'3003', N'0410', N'SPT', N'410TK202', N'410TK202,LUBRICITY ADDITIVE 350 GAL TOTE',N'DN1-3003-0410-SPT-410TK202',7000,5,'en';

-- Energy Services
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'P035', N'BL13', N'SIV', N'XV0270A', N'MAIN GAS BURNER ''B'' ISO VALVE CONTROL VA',N'EU1-P035-BL13-SIV-XV0270A',1060,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', null, null, null, N'EU1 PROCESS AUTOMATION SYSTEMS',N'EU1-PASS',1060,2,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'DCS1', null, null, N'EU1 LCN1 HONEYWELL DCS',N'EU1-PASS-DCS1',1060,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'DCS1', N'SIC', null, N'CONTROL SYSTEM AND STATION',N'EU1-PASS-DCS1-SIC',1060,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'DCS1', N'SIC', N'UCN12_HPM_31_32', N'HPM P31 PLANT 31 RACK ROOM',N'EU1-PASS-DCS1-SIC-UCN12_HPM_31_32',1060,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'SIS1', null, null, N'SIS1 MOORE SAFETY PLC',N'EU1-PASS-SIS1',1060,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'SIS1', N'SIC', null, N'CONTROL SYSTEM AND STATION',N'EU1-PASS-SIS1-SIC',1060,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EU1', N'PASS', N'SIS1', N'SIC', N'NODE30_31_BL03', N'NODE30_31 BOILER_31F_3 PLT31 3RD FLOOR',N'EU1-PASS-SIS1-SIC-NODE30_31_BL03',1060,5,'en';

-- Extraction
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EX1', N'OPLT', N'PD06', N'SEG', N'PC0192', N'3T0383 BARGE 6 - 4160V MCC',N'EX1-OPLT-PD06-SEG-PC0192',1200,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EX1', N'P004', N'SSCU', N'SPC', N'T0070', N'SEPARATER DISC. WASHER',N'EX1-P004-SSCU-SPC-T0070',1200,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EX1', N'P300', N'TOOL', N'SWM', N'LIFTING_DEVICES', N'ENGINEERED LIFTING DEVICES',N'EX1-P300-TOOL-SWM-LIFTING_DEVICES',1200,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'EX1', N'TLGS', N'TOOL', N'SWM', N'SPECIALTY_TOOLS', N'SPECIALTY TOOLS',N'EX1-TLGS-TOOL-SWM-SPECIALTY_TOOLS',1200,5,'en';

-- Mining
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'MIOP', null, null, N'MINE PRODUCTION',N'MN1-FACL-MIOP',1100,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'MIOP', N'SWM', null, N'PRODUCTION TOOLS AND RESOURCES',N'MN1-FACL-MIOP-SWM',1100,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'MIOP', N'SWM', N'CABLE_STANDS', N'MINE OPS POWER CABLE STANDS',N'MN1-FACL-MIOP-SWM-CABLE_STANDS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', null, null, N'SHOVELS',N'MN1-FACL-SHOV',1100,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', N'SWM', null, N'PRODUCTION TOOLS & RESOURCES',N'MN1-FACL-SHOV-SWM',1100,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', N'SWM', N'LIFTING DEVICES', N'LIFTING DEVICES',N'MN1-FACL-SHOV-SWM-LIFTING DEVICES',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', N'SWM', N'MISC TOOLS', N'TOOLS, JIGS AND FIXTURES',N'MN1-FACL-SHOV-SWM-MISC TOOLS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', N'SWM', N'MOTIVATOR', N'****DELETED. PLEASE DO NOT USE*****',N'MN1-FACL-SHOV-SWM-MOTIVATOR',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'SHOV', N'SWM', N'STANDS', N'ENGINEERED STANDS',N'MN1-FACL-SHOV-SWM-STANDS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRAX', null, null, N'TRACKS AND AUXILLARY',N'MN1-FACL-TRAX',1100,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRAX', N'SWM', null, N'PRODUCTION TOOLS & RESOURCES',N'MN1-FACL-TRAX-SWM',1100,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRAX', N'SWM', N'LIFTING DEVICES', N'LIFTING DEVICES',N'MN1-FACL-TRAX-SWM-LIFTING DEVICES',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRAX', N'SWM', N'MISC TOOLS', N'TOOLS, JIGS AND FIXTURES',N'MN1-FACL-TRAX-SWM-MISC TOOLS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRAX', N'SWM', N'STANDS', N'ENGINEERED STANDS',N'MN1-FACL-TRAX-SWM-STANDS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', null, null, N'TRUCKS',N'MN1-FACL-TRKS',1100,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', N'SWM', null, N'PRODUCTION TOOLS & RESOURCES',N'MN1-FACL-TRKS-SWM',1100,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', N'SWM', N'LIFTING DEVICES', N'LIFTING DEVICES',N'MN1-FACL-TRKS-SWM-LIFTING DEVICES',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', N'SWM', N'MISC TOOLS', N'TOOLS, JIGS AND FIXTURES',N'MN1-FACL-TRKS-SWM-MISC TOOLS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', N'SWM', N'STAIRS_PLATFORMS', N'MOBILE FUEL TANK PLATFORM',N'MN1-FACL-TRKS-SWM-STAIRS_PLATFORMS',1100,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'MN1', N'FACL', N'TRKS', N'SWM', N'STANDS', N'ENGINEERED STANDS',N'MN1-FACL-TRKS-SWM-STANDS',1100,5,'en';

-- Upgrading
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'STE', N'CALIBRATED_INSTRUMENTS', N'CALIBRATED INST & ELEC EQUIPMENTS',N'UP1-FACL-TOOL-STE-CALIBRATED_INSTRUMENTS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'STM', N'CALIBRATED_TOOLS', N'CALIBRATED & INSPECTED MECHANICAL TOOLS',N'UP1-FACL-TOOL-STM-CALIBRATED_TOOLS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'SWM', N'LIFTING_DEVICES', N'ENGINEERED LIFTING DEVICES',N'UP1-FACL-TOOL-SWM-LIFTING_DEVICES',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'SWM', N'MATERIAL_HANDLING', N'MATERIAL HANDLING EQUIPMENT',N'UP1-FACL-TOOL-SWM-MATERIAL_HANDLING',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'SWM', N'SHOP_EQUIPMENT', N'SHOP EQUIPMENT',N'UP1-FACL-TOOL-SWM-SHOP_EQUIPMENT',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'FACL', N'TOOL', N'SWM', N'STANDS', N'ENGINEERED TOOLS, STANDS AND FIXTURES',N'UP1-FACL-TOOL-SWM-STANDS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SMP', N'G0009A', N'INTERNAL GAS OIL REFLUX PUMP',N'UP1-P005-FRC1-SMP-G0009A',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003A', N'COKER FRAC O/H CONDENSER',N'UP1-P005-FRC1-SPH-E0003A',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AA', N'FRAC OVHD COND CELL A (1ST FROM EAST)',N'UP1-P005-FRC1-SPH-E0003AA',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB', N'FRAC OVHD COND CELL B (2ND FROM EAST)',N'UP1-P005-FRC1-SPH-E0003AB',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB11', N'FRAC OVHD CONDENSER BUNDLE 11',N'UP1-P005-FRC1-SPH-E0003AB11',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB12', N'FRAC OVHD CONDENSER BUNDLE 12',N'UP1-P005-FRC1-SPH-E0003AB12',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB5', N'FRAC OVHD CONDENSER BUNDLE 5',N'UP1-P005-FRC1-SPH-E0003AB5',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB6', N'FRAC OVHD CONDENSER BUNDLE 6',N'UP1-P005-FRC1-SPH-E0003AB6',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB7', N'FRAC OVHD CONDENSER BUNDLE 7',N'UP1-P005-FRC1-SPH-E0003AB7',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB8', N'FRAC OVHD CONDENSER BUNDLE 8',N'UP1-P005-FRC1-SPH-E0003AB8',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AB9', N'FRAC OVHD CONDENSER BUNDLE 9',N'UP1-P005-FRC1-SPH-E0003AB9',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AC', N'FRAC OVHD COND CELL C (3RD FROM EAST)',N'UP1-P005-FRC1-SPH-E0003AC',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003AD', N'FRAC OVHD COND CELL D (4TH FROM EAST)',N'UP1-P005-FRC1-SPH-E0003AD',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003B', N'COKER FRACTIONATER O/H CONDENSER',N'UP1-P005-FRC1-SPH-E0003B',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003C', N'COKER FRACTIONATER O/H CONDENSER',N'UP1-P005-FRC1-SPH-E0003C',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003D', N'COKER FRACTIONATER O/H CONDENSER',N'UP1-P005-FRC1-SPH-E0003D',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P005', N'FRC1', N'SPH', N'E0003E', N'COKER FRACTIONATER O/H CONDENSER',N'UP1-P005-FRC1-SPH-E0003E',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P006', N'CATA', N'SPT', N'D0007', N'CARBONATE SETTLING TANK',N'UP1-P006-CATA-SPT-D0007',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P006', N'CATA', N'SPT', N'T0008', N'CATACARB BAG FILTER',N'UP1-P006-CATA-SPT-T0008',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P006', N'RFR1', N'SMP', N'G0011', N'CAUSTIC CHARGE PUMP',N'UP1-P006-RFR1-SMP-G0011',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P006', N'RFR1', N'SMP', N'G0014', N'WASH WATER PUMP',N'UP1-P006-RFR1-SMP-G0014',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P006', N'RFR1', N'SPH', N'E0001', N'COMPRESSOR RECIRCULATION COOLER',N'UP1-P006-RFR1-SPH-E0001',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P007', N'GHU1', N'SIL', N'F0528', null,N'UP1-P007-GHU1-SIL-F0528',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P021', N'STF1', N'SIL', N'F0282', N'*****DELETED PLEASE DO NOT USE*****',N'UP1-P021-STF1-SIL-F0282',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P025', N'VAC1', N'SIL', N'P0713A', null,N'UP1-P025-VAC1-SIL-P0713A',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP1', N'P025', N'VAC1', N'SIL', N'P0713B', null,N'UP1-P025-VAC1-SIL-P0713B',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'STE', N'CALIBRATED_INSTRUMENTS', N'CALIBRATED INST & ELEC EQUIPMENTS',N'UP2-FACL-TOOL-STE-CALIBRATED_INSTRUMENTS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'STM', N'CALIBRATED_TOOLS', N'CALIBRATED & INSPECTED MECHANICAL TOOLS',N'UP2-FACL-TOOL-STM-CALIBRATED_TOOLS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'SWM', N'LIFTING_DEVICES', N'ENGINEERED LIFTING DEVICES',N'UP2-FACL-TOOL-SWM-LIFTING_DEVICES',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'SWM', N'MATERIAL_HANDLING', N'MATERIAL HANDLING EQUIPMENT',N'UP2-FACL-TOOL-SWM-MATERIAL_HANDLING',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'SWM', N'SHOP_EQUIPMENT', N'SHOP EQUIPMENT',N'UP2-FACL-TOOL-SWM-SHOP_EQUIPMENT',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'FACL', N'TOOL', N'SWM', N'STANDS', N'ENGINEERED TOOLS, STANDS AND FIXTURES',N'UP2-FACL-TOOL-SWM-STANDS',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P034', N'API1', N'SIL', N'L0121', null,N'UP2-P034-API1-SIL-L0121',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'DCU2', N'SIL', N'V3842', null,N'UP2-P052-DCU2-SIL-V3842',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'DCU2', N'SIL', N'V3857', null,N'UP2-P052-DCU2-SIL-V3857',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'DCU2', N'SIL', N'V3870', null,N'UP2-P052-DCU2-SIL-V3870',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'DCU2', N'SIL', N'V3871', null,N'UP2-P052-DCU2-SIL-V3871',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'DCU2', N'SSR', N'PSV3933', N'VALVE; PSV, 52G-327A/B NITROGEN BSTR PMP',N'UP2-P052-DCU2-SSR-PSV3933',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'FRC2', N'SMP', N'G0305C', N'NATURAL RECYCLE PUMP',N'UP2-P052-FRC2-SMP-G0305C',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P052', N'FRC2', N'SMP', N'G0305D', N'NATURAL RECYCLE PUMP',N'UP2-P052-FRC2-SMP-G0305D',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P053', N'SRU4', N'SPT', N'K0400', N'***DELETE DO NOT USE***',N'UP2-P053-SRU4-SPT-K0400',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P053', N'SRUF', N'SSR', N'PSV5084', N'VALVE, PRESSURE SAFETY PHOSP INJ PACK',N'UP2-P053-SRUF-SSR-PSV5084',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P053', N'SWS2', N'SMP', N'VG0502', N'CAUSTIC INJECTION PUMP',N'UP2-P053-SWS2-SMP-VG0502',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P053', N'TGTU', N'SSR', N'PSV6143', N'FRESH AMN PMP 53G-604',N'UP2-P053-TGTU-SSR-PSV6143',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SIL', N'F1031', null,N'UP2-P056-COMS-SIL-F1031',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SSR', N'PSV1897A', N'VALVE, PRESSURE SAFETY UW',N'UP2-P056-COMS-SSR-PSV1897A',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SSR', N'PSV1897B', N'VALVE, PRESSURE SAFETY UW FROM ES',N'UP2-P056-COMS-SSR-PSV1897B',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SSR', N'PSV1897C', N'VALVE, PRESSURE SAFETY UW FROM ES',N'UP2-P056-COMS-SSR-PSV1897C',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SSR', N'PSV1897D', N'VALVE, PRESSURE SAFETY UW FROM ES',N'UP2-P056-COMS-SSR-PSV1897D',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'COMS', N'SSR', N'PSV1897E', N'VALVE, PRESSURE SAFETY UW FROM ES',N'UP2-P056-COMS-SSR-PSV1897E',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'PPL2', N'SIV', N'H1231', null,N'UP2-P056-PPL2-SIV-H1231',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'WAT1', N'SSR', N'PSV1811A', N'*******DO NOT USE****************',N'UP2-P056-WAT1-SSR-PSV1811A',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P056', N'WAT1', N'SSR', N'PSV1811B', N'*******DO NOT USE****************',N'UP2-P056-WAT1-SSR-PSV1811B',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P057', N'DRU4', N'SIV', N'X1027', N'**********DELETED DO NOT USE**********',N'UP2-P057-DRU4-SIV-X1027',1300,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 3, N'UP2', N'P057', N'DRU4', N'SIV', N'X1028', N'**********DELETED DO NOT USE**********',N'UP2-P057-DRU4-SIV-X1028',1300,5,'en';

-- Firebag
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'FBOP', N'0900', N'SPH', N'Y933A', N'PLANT 91 INSTRUMENT AIR PRE-FILTER',N'FB1-FBOP-0900-SPH-Y933A',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'FBOP', N'0900', N'SPH', N'Y933B', N'PLANT 92 INSTRUMENT AIR PRE-FILTER',N'FB1-FBOP-0900-SPH-Y933B',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'FBOP', N'0900', N'SPH', N'Y935A', N'PLANT 92 INSTRUMENT AIR PRE-FILTER',N'FB1-FBOP-0900-SPH-Y935A',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'FBOP', N'0900', N'SPH', N'Y935B', N'PLANT 92 INSTRUMENT AIR PRE-FILTER',N'FB1-FBOP-0900-SPH-Y935B',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'STE', N'CALIBRATED_INSTRUMENTS', N'CALIBRATED ELEC & INST INSTRUMENTS',N'FB1-P091-TOOL-STE-CALIBRATED_INSTRUMENTS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'STM', N'CALIBRATED_TOOLS', N'CALIBRATED & INSPECTED MECHANICAL TOOLS',N'FB1-P091-TOOL-STM-CALIBRATED_TOOLS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'ELEC_TOOLS_AND_EQUIP', N'ELECTRICAL TOOLS & EQUIPMENT',N'FB1-P091-TOOL-SWM-ELEC_TOOLS_AND_EQUIP',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'INST_TOOLS_AND_EQUIP', N'INSTRUMENTATION TOOLS & EQUIPMENT',N'FB1-P091-TOOL-SWM-INST_TOOLS_AND_EQUIP',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'LIFTING_DEVICES', N'ENGINEERED LIFTING DEVICES',N'FB1-P091-TOOL-SWM-LIFTING_DEVICES',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'MATERIAL_HANDLING', N'MATERIAL HANDLING EQUIPMENT',N'FB1-P091-TOOL-SWM-MATERIAL_HANDLING',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'SHOP_EQUIPMENT', N'SHOP EQUIPMENT',N'FB1-P091-TOOL-SWM-SHOP_EQUIPMENT',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P091', N'TOOL', N'SWM', N'STANDS', N'ENGINEERED STANDS & FIXTURES',N'FB1-P091-TOOL-SWM-STANDS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5502X', N'92G-5310A BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5502X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5502Y', N'92G-5310A BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5502Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5503X', N'92G-5310A BFW CHARGE PUMP VIIBRATION DE',N'FB1-P092-5000-SIL-V5503X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5503Y', N'92G-5310A BFW CHARGE PUMP VIBRATION DE',N'FB1-P092-5000-SIL-V5503Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5504X', N'92G-5310A BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5504X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5504Y', N'92G-5310A BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5504Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5505X', N'92G-5310A BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5505X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5505Y', N'92G-5310A BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5505Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5602X', N'92G-5310B BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5602X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5602Y', N'92G-5310B BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5602Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5603X', N'92G-5310B BFW CHARGE PUMP VIIBRATION DE',N'FB1-P092-5000-SIL-V5603X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5603Y', N'92G-5310B BFW CHARGE PUMP VIIBRATION DE',N'FB1-P092-5000-SIL-V5603Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5604X', N'92G-5310B BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5604X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5604Y', N'92G-5310B BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5604Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5605X', N'92G-5310B BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5605X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5605Y', N'92G-5310B BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5605Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5702X', N'92G-5310C BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5702X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5702Y', N'92G-5310C BFW CHARGE PUMP VIIBRATION NDE',N'FB1-P092-5000-SIL-V5702Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5703X', N'92G-5310C BFW CHARGE PUMP VIIBRATION DE',N'FB1-P092-5000-SIL-V5703X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5703Y', N'92G-5310C BFW CHARGE PUMP VIIBRATION DE',N'FB1-P092-5000-SIL-V5703Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5704X', N'92G-5310C BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5704X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5704Y', N'92G-5310C BFW CHARGE PUMP MTR VIB NDE',N'FB1-P092-5000-SIL-V5704Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5705X', N'92G-5310C BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5705X',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'5000', N'SIL', N'V5705Y', N'92G-5310C BFW CHARGE PUMP MTR VIB DE',N'FB1-P092-5000-SIL-V5705Y',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P092', N'7000', N'SEG', N'PJ7032', null,N'FB1-P092-7000-SEG-PJ7032',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'1000', N'SLP', N'P_INTERFACERECYCLE', N'INTERFACE RECYCLE PIPING',N'FB1-P093-1000-SLP-P_INTERFACERECYCLE',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'STE', N'CALIBRATED_INSTRUMENTS', N'CALIBRATED ELEC & INST INSTRUMENTS',N'FB1-P093-TOOL-STE-CALIBRATED_INSTRUMENTS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'STM', N'CALIBRATED_TOOLS', N'CALIBRATED & INSPECTED MECHANICAL TOOLS',N'FB1-P093-TOOL-STM-CALIBRATED_TOOLS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'SWM', N'LIFTING_DEVICES', N'ENGINEERED LIFTING DEVICES',N'FB1-P093-TOOL-SWM-LIFTING_DEVICES',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'SWM', N'MATERIAL_HANDLING', N'MATERIAL HANDLING EQUIPMENT',N'FB1-P093-TOOL-SWM-MATERIAL_HANDLING',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'SWM', N'SHOP_EQUIPMENT', N'SHOP EQUIPMENT',N'FB1-P093-TOOL-SWM-SHOP_EQUIPMENT',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P093', N'TOOL', N'SWM', N'STANDS', N'ENGINEERED STANDS & FIXTURES',N'FB1-P093-TOOL-SWM-STANDS',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'1000', N'SPH', N'E1007A', N'TEG COOLER',N'FB1-P099-1000-SPH-E1007A',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'1000', N'SPH', N'E1007B', N'TEG COOLER',N'FB1-P099-1000-SPH-E1007B',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'1000', N'SPH', N'E1014A', N'AUXILIARY TEG COOLER',N'FB1-P099-1000-SPH-E1014A',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'1000', N'SPH', N'E1014B', N'AUXILIARY TEG COOLER',N'FB1-P099-1000-SPH-E1014B',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'4000', N'SPH', N'E4065A', N'CONDENSATE DRUM COOLER',N'FB1-P099-4000-SPH-E4065A',1400,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 5, N'FB1', N'P099', N'4000', N'SPH', N'E4065B', N'CONDENSATE DRUM COOLER',N'FB1-P099-4000-SPH-E4065B',1400,5,'en';

-- MacKay River
EXEC dbo.FunctionalLocationAddOrUndelete 7, N'MR1', N'P001', N'0100', N'SSR', N'PSV0452A', N'VALVE, BIT TRANS PUMPS SEAL N2 (SPARE)',N'MR1-P001-0100-SSR-PSV0452A',754,5,'en';

-- Edmonton
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U007', N'SSR', N'PSV0033A', N'AIR PREHEATER',N'ED1-A001-U007-SSR-PSV0033A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U007', N'SSR', N'PSV0033B', N'AIR PREHEATER',N'ED1-A001-U007-SSR-PSV0033B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0004A', N'8KT-1 TURBINE OUTLET',N'ED1-A001-U008-SSR-PSV0004A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0004B', N'8KT-1 TURBINE OUTLET',N'ED1-A001-U008-SSR-PSV0004B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0020A', N'PRODUCT ACCUMULATOR DRUM 8C-16',N'ED1-A001-U008-SSR-PSV0020A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0020B', N'PRODUCT ACCUMULATOR DRUM 8C-16',N'ED1-A001-U008-SSR-PSV0020B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0020C', N'PRODUCT ACCUMULATOR DRUM 8C-16',N'ED1-A001-U008-SSR-PSV0020C',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0025A', N'SLURRY STEAM GENERATOR 8E-1A',N'ED1-A001-U008-SSR-PSV0025A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0025B', N'SLURRY STEAM GENERATOR 8E-1A',N'ED1-A001-U008-SSR-PSV0025B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0027A', N'SLURRY STEAM GENERATOR 8E-1B',N'ED1-A001-U008-SSR-PSV0027A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0027B', N'SLURRY STEAM GENERATOR 8E-1B',N'ED1-A001-U008-SSR-PSV0027B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0033A', N'OVERHEAD FRACTIONATOR',N'ED1-A001-U008-SSR-PSV0033A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0033B', N'OVERHEAD FRACTIONATOR',N'ED1-A001-U008-SSR-PSV0033B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0033C', N'OVERHEAD FRACTIONATOR',N'ED1-A001-U008-SSR-PSV0033C',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0033D', N'OVERHEAD FRACTIONATOR',N'ED1-A001-U008-SSR-PSV0033D',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0108A', N'8K-2T TURBINE',N'ED1-A001-U008-SSR-PSV0108A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U008', N'SSR', N'PSV0108B', N'8K-2T TURBINE',N'ED1-A001-U008-SSR-PSV0108B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U009', N'SSR', N'PSV0005A', N'DEPENTANIZER',N'ED1-A001-U009-SSR-PSV0005A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U009', N'SSR', N'PSV0005B', N'DEPENTANIZER',N'ED1-A001-U009-SSR-PSV0005B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSE0013A', N'ISOSTRIPPER 12C-2',N'ED1-A001-U012-SSR-PSE0013A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSE0013B', N'ISOSTRIPPER 12C-2',N'ED1-A001-U012-SSR-PSE0013B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSE0050A', N'HC FROM 12C-5 TO FEED PRE-HEATER',N'ED1-A001-U012-SSR-PSE0050A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSE0050B', N'HC FROM 12C-5 TO FEED PRE-HEATER',N'ED1-A001-U012-SSR-PSE0050B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0001A', N'OLEFIN FEED SURGE DRUM',N'ED1-A001-U012-SSR-PSV0001A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0001B', N'OLEFIN FEED SURGE DRUM',N'ED1-A001-U012-SSR-PSV0001B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0013A', N'ISOSTRIPPER 12C-2',N'ED1-A001-U012-SSR-PSV0013A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0013B', N'ISOSTRIPPER 12C-2',N'ED1-A001-U012-SSR-PSV0013B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0031A', N'OLEFIN FEED SETTLER 12C-30',N'ED1-A001-U012-SSR-PSV0031A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0031B', N'OLEFIN FEED SETTLER 12C-30',N'ED1-A001-U012-SSR-PSV0031B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0032A', N'WATER WASH COLUMN',N'ED1-A001-U012-SSR-PSV0032A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0032B', N'WATER WASH COLUMN',N'ED1-A001-U012-SSR-PSV0032B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0038A', N'CAUSTIC WASH COLUMN 12C-19',N'ED1-A001-U012-SSR-PSV0038A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0038B', N'CAUSTIC WASH COLUMN 12C-19',N'ED1-A001-U012-SSR-PSV0038B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0050A', N'HC FROM 12C-5 TO FEED PRE-HEATER',N'ED1-A001-U012-SSR-PSV0050A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0050B', N'HC FROM 12C-5 TO FEED PRE-HEATER',N'ED1-A001-U012-SSR-PSV0050B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0052A', N'INLET 12E-15A',N'ED1-A001-U012-SSR-PSV0052A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0052B', N'INLET 12E-15A',N'ED1-A001-U012-SSR-PSV0052B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0064A', N'12E-13A DEPROPANIZER RECYCLE COOLER',N'ED1-A001-U012-SSR-PSV0064A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0064B', N'12E-13A DEPROPANIZER RECYCLE COOLER',N'ED1-A001-U012-SSR-PSV0064B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0065A', N'12E-13B DEPROPANIZER RECYCLE COOLER',N'ED1-A001-U012-SSR-PSV0065A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0065B', N'12E-13B DEPROPANIZER RECYCLE COOLER',N'ED1-A001-U012-SSR-PSV0065B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0066A', N'INLET TO 12E-15B',N'ED1-A001-U012-SSR-PSV0066A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U012', N'SSR', N'PSV0066B', N'INLET TO 12E-15B',N'ED1-A001-U012-SSR-PSV0066B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'MISC0090', N'MISCELLANEOUS',N'ED1-A001-U013-SWM-MISC0090',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'MISC0091', N'MISCELLANEOUS',N'ED1-A001-U013-SWM-MISC0091',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'T0013A', N'COKER BOTTOM MANWAY AIR WRENCH',N'ED1-A001-U013-SWM-T0013A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'T0013B', N'COKER BOTTOM MANWAY AIR WRENCH',N'ED1-A001-U013-SWM-T0013B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'T0027', N'COKER MANWAY AIR IMPACT GUN',N'ED1-A001-U013-SWM-T0027',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A001', N'U013', N'SWM', N'T0113', N'COKER PNEUMATIC WRENCH',N'ED1-A001-U013-SWM-T0113',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A002', N'U006', N'SWM', N'TOOLS_1', N'TOOLS GROUP 1',N'ED1-A002-U006-SWM-TOOLS_1',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSA', N'Y0024', null,N'ED1-A004-U031-SSA-Y0024',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0002A', N'BOILER 1',N'ED1-A004-U031-SSR-PSV0002A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0003A', N'BOILER 1',N'ED1-A004-U031-SSR-PSV0003A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0019A', N'FUEL GAS MIX DRUM 31C-15',N'ED1-A004-U031-SSR-PSV0019A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0019B', N'FUEL GAS MIX DRUM 31C-15',N'ED1-A004-U031-SSR-PSV0019B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0055A', N'31K-8 COLD WATER SUPPLY',N'ED1-A004-U031-SSR-PSV0055A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0055B', N'31K-8 COLD WATER SUPPLY',N'ED1-A004-U031-SSR-PSV0055B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U031', N'SSR', N'PSV0055C', N'31K-8 COLD WATER SUPPLY',N'ED1-A004-U031-SSR-PSV0055C',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U032', N'SSR', N'PSV0016A', N'WETWELL A',N'ED1-A004-U032-SSR-PSV0016A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U032', N'SSR', N'PSV0016B', N'WETWELL A',N'ED1-A004-U032-SSR-PSV0016B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U065', N'SSR', N'PSV0301A', N'65C-1 SW DEGASS.DRUM #1-FLASH GAS PSV',N'ED1-A004-U065-SSR-PSV0301A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U065', N'SSR', N'PSV0301B', N'65C-1 SW DEGASS.DRUM #1-FLASH GAS PSV',N'ED1-A004-U065-SSR-PSV0301B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U065', N'SSR', N'PSV0303A', N'65C-11 SW DEG. DRUM #2-FLASH GAS PSV',N'ED1-A004-U065-SSR-PSV0303A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A004', N'U065', N'SSR', N'PSV0303B', N'65C-11 SW DEG. DRUM #2-FLASH GAS PSV',N'ED1-A004-U065-SSR-PSV0303B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U020', N'SIC', N'LP0004', N'EQUIPMENT CABINET',N'ED1-A005-U020-SIC-LP0004',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U020', N'SSR', N'PSV0092A', N'NEW PROPANE BULLET RELIEF VALVE',N'ED1-A005-U020-SSR-PSV0092A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U020', N'SSR', N'PSV0092B', N'NEW PROPANE BULLET RELIEF VALVE',N'ED1-A005-U020-SSR-PSV0092B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U021', N'SSR', N'PSV0092A', N'NITROGEN OVERPRESSURE PROTECTION',N'ED1-A005-U021-SSR-PSV0092A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U021', N'SSR', N'PSV0092B', N'NITROGEN OVERPRESSURE PROTECTION',N'ED1-A005-U021-SSR-PSV0092B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SLE', N'MISC0076', N'MISCELLANEOUS',N'ED1-A005-U022-SLE-MISC0076',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SLE', N'MISC0077', N'MISCELLANEOUS',N'ED1-A005-U022-SLE-MISC0077',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SPZ', N'MISC0013', N'MISCELLANEOUS',N'ED1-A005-U022-SPZ-MISC0013',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SPZ', N'MISC0023', N'MISCELLANEOUS',N'ED1-A005-U022-SPZ-MISC0023',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0021A', N'VENTING ON DIESEL TANK 301',N'ED1-A005-U022-SSR-PSV0021A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0021B', N'VENTING ON DIESEL TANK 301',N'ED1-A005-U022-SSR-PSV0021B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0022A', N'VENTING ON DIESEL TANK 302',N'ED1-A005-U022-SSR-PSV0022A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0022B', N'VENTING ON DIESEL TANK 302',N'ED1-A005-U022-SSR-PSV0022B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0087A', N'ALKYLATE TANK 313',N'ED1-A005-U022-SSR-PSV0087A',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SSR', N'PSV0087B', N'ALKYLATE TANK 313',N'ED1-A005-U022-SSR-PSV0087B',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SWM', N'MISC0002', N'MISCELLANEOUS EQUIPMENT CABINETS',N'ED1-A005-U022-SWM-MISC0002',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SWM', N'MISC0003', N'MISCELLANEOUS EQUIPMENT CABINETS',N'ED1-A005-U022-SWM-MISC0003',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A005', N'U022', N'SWM', N'MISC0004', N'MISCELLANEOUS EQUIPMENT CABINETS',N'ED1-A005-U022-SWM-MISC0004',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A006', N'U073', N'SPZ', N'MISC0242', N'MISCELLANEOUS',N'ED1-A006-U073-SPZ-MISC0242',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A006', N'U073', N'SPZ', N'MISC0243', N'MISCELLANEOUS',N'ED1-A006-U073-SPZ-MISC0243',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A006', N'U073', N'SWM', N'TOOLS_1', N'TOOLS GROUP 1',N'ED1-A006-U073-SWM-TOOLS_1',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A006', N'U073', N'SWM', N'TOOLS_2', N'TOOLS GROUP 2',N'ED1-A006-U073-SWM-TOOLS_2',702,5,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 8, N'ED1', N'A006', N'U079', N'SWM', N'TOOLS_1', N'TOOLS GROUP 1',N'ED1-A006-U079-SWM-TOOLS_1',702,5,'en';

-- Montreal
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SEH', N'HPC020007', N'PANN. CONTROLE CABLE CHAUFF. SKID',N'MT1-A001-U020-SEH-HPC020007',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020329', N'RÉSERVOIR DE LV-2100',N'MT1-A001-U020-SIL-L020329',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020330', N'RÉSERVOIR DE LV-2105',N'MT1-A001-U020-SIL-L020330',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020331', N'RÉSERVOIR DE LV-2105',N'MT1-A001-U020-SIL-L020331',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020332', N'RÉSERVOIR DE TV-2117',N'MT1-A001-U020-SIL-L020332',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020333', N'RÉSERVOIR DE TV-2117',N'MT1-A001-U020-SIL-L020333',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020334', N'RÉSERVOIR DE PDV-2100A/B',N'MT1-A001-U020-SIL-L020334',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020335', N'RÉSERVOIR DE PDV-2100A/B',N'MT1-A001-U020-SIL-L020335',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020336', N'RÉSERVOIR DE PV-2102A/B',N'MT1-A001-U020-SIL-L020336',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'L020337', N'RÉSERVOIR DE PV-2102',N'MT1-A001-U020-SIL-L020337',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020548', N'HAUTE PRESS DIFF HUILE DE LUB-J-290',N'MT1-A001-U020-SIL-P020548',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020550', N'PRESSION COLL HUILE DE LUB-J-290',N'MT1-A001-U020-SIL-P020550',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020554', N'PRESSION ADP EN MARCHE-J-290',N'MT1-A001-U020-SIL-P020554',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020555', N'PRESSION SYSTEME HUILE BAS-J-290',N'MT1-A001-U020-SIL-P020555',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020559', N'POMPE PRINCIPALE (J-020100-2) LV-2100',N'MT1-A001-U020-SIL-P020559',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020560', N'SYSTÈME D''HUILE DE LV-2100',N'MT1-A001-U020-SIL-P020560',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020561', N'POMPE CIRCULATION (J-020100-3) LV-2100',N'MT1-A001-U020-SIL-P020561',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020562', N'ESD DU SYSTÈME D''HUILE DE LV-2100',N'MT1-A001-U020-SIL-P020562',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020563', N'BLOCAGE HYDRAULIC DE LV-2100',N'MT1-A001-U020-SIL-P020563',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020564', N'ACCUMULATEUR PRINC DE LV-2100',N'MT1-A001-U020-SIL-P020564',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020565', N'ACCUMULATEUR ESD DE LV-2100',N'MT1-A001-U020-SIL-P020565',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020566', N'CYL FERMÉ CTRL POUSSÉE DE LV-2100',N'MT1-A001-U020-SIL-P020566',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020568', N'POMPE PRINCIPALE (J-020100-1) LV-2100',N'MT1-A001-U020-SIL-P020568',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020569', N'POMPE PRINCIPALE (J-020100-2) LV-2100',N'MT1-A001-U020-SIL-P020569',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020570', N'POMPE CIRCULATION (J-020100-3) LV-2100',N'MT1-A001-U020-SIL-P020570',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020571', N'SYSTÈME D''HUILE DE LV-2100',N'MT1-A001-U020-SIL-P020571',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020572', N'ESSAI ESD DU SYSTÈME D''HUILE DE LV-2100',N'MT1-A001-U020-SIL-P020572',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020573', N'BLOCAGE HYDRAULIC DE LV-2100',N'MT1-A001-U020-SIL-P020573',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020574', N'ACCUMULATEUR PRINC DE LV-2100',N'MT1-A001-U020-SIL-P020574',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020575', N'ACCUMULATEUR ESD DE LV-2100',N'MT1-A001-U020-SIL-P020575',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020576', N'CYLINDRE FERMÉ DE LV-2100',N'MT1-A001-U020-SIL-P020576',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020577', N'CYLINDRE OUVERT DE LV-2100',N'MT1-A001-U020-SIL-P020577',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020582', N'ESD DU SYSTÈME D''HUILE DE LV-2105',N'MT1-A001-U020-SIL-P020582',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020583', N'BLOCAGE HYDRAULIC DE LV-2105',N'MT1-A001-U020-SIL-P020583',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020588', N'POMPE PRINCIPALE (J-020105-1) LV-2105',N'MT1-A001-U020-SIL-P020588',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020589', N'POMPE PRINCIPALE (J-020105-2) LV-2105',N'MT1-A001-U020-SIL-P020589',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020590', N'POMPE CIRCULATION (J-020105-3) LV-2105',N'MT1-A001-U020-SIL-P020590',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020591', N'SYSTÈME D''HUILE DE LV-2105',N'MT1-A001-U020-SIL-P020591',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020592', N'ESSAI ESD DU SYSTÈME D''HUILE DE LV-2105',N'MT1-A001-U020-SIL-P020592',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020593', N'BLOCAGE HYDRAULIC DE LV-2105',N'MT1-A001-U020-SIL-P020593',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020594', N'ACCUMULATEUR PRINC DE LV-2105',N'MT1-A001-U020-SIL-P020594',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020595', N'ACCUMULATEUR ESD DE LV-2105',N'MT1-A001-U020-SIL-P020595',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020596', N'CYLINDRE FERMÉ DE LV-2105',N'MT1-A001-U020-SIL-P020596',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020597', N'CYLINDRE OUVERT DE LV-2105',N'MT1-A001-U020-SIL-P020597',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020598', N'POMPE PRINCIPALE (J-020117-1) TV-2117',N'MT1-A001-U020-SIL-P020598',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020599', N'POMPE PRINCIPALE (J-020117-2) TV-2117',N'MT1-A001-U020-SIL-P020599',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020600', N'SYSTÈME D''HUILE DE TV-2117',N'MT1-A001-U020-SIL-P020600',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020601', N'POMPE CIRCULATION (J-020117-3) TV-2117',N'MT1-A001-U020-SIL-P020601',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020602', N'ESD DU SYSTÈME D''HUILE DE TV-2117',N'MT1-A001-U020-SIL-P020602',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020603', N'BLOCAGE HYDRAULIC DE TV-2117',N'MT1-A001-U020-SIL-P020603',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020604', N'ACCUMULATEUR PRINC DE TV-2117',N'MT1-A001-U020-SIL-P020604',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020605', N'ACCUMULATEUR ESD DE TV-2117',N'MT1-A001-U020-SIL-P020605',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020606', N'POMPE PRINCIPALE (J-020117-1) TV-2117',N'MT1-A001-U020-SIL-P020606',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020607', N'POMPE PRINCIPALE (J-020117-2) TV-2117',N'MT1-A001-U020-SIL-P020607',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020608', N'POMPE CIRCULATION (J-020117-3) TV-2117',N'MT1-A001-U020-SIL-P020608',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020609', N'SYSTÈME D''HUILE DE TV-2117',N'MT1-A001-U020-SIL-P020609',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020610', N'ESSAI ESD DU SYSTÈME D''HUILE DE TV-2117',N'MT1-A001-U020-SIL-P020610',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020611', N'BLOCAGE HYDRAULIC DE TV-2117',N'MT1-A001-U020-SIL-P020611',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020612', N'ACCUMULATEUR PRINC DE LV-2105',N'MT1-A001-U020-SIL-P020612',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020613', N'ACCUMULATEUR ESD DE TV-2117',N'MT1-A001-U020-SIL-P020613',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020614', N'CYLINDRE FERMÉ DE TV-2117',N'MT1-A001-U020-SIL-P020614',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020615', N'CYLINDRE OUVERT DE TV-2117',N'MT1-A001-U020-SIL-P020615',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020616', N'POMPE PRINC (J-020100AB-1) PDV-2100A/B',N'MT1-A001-U020-SIL-P020616',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020617', N'POMPE PRINC (J-020100AB-2) PDV-2100A/B',N'MT1-A001-U020-SIL-P020617',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020618', N'SYSTÈME D''HUILE DE PDV-2100A/B',N'MT1-A001-U020-SIL-P020618',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020619', N'POMPE CIRC (J-020100AB-3) PDV-2100A/B',N'MT1-A001-U020-SIL-P020619',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020620', N'BLOCAGE HYDRAULIC DE PDV-2100A',N'MT1-A001-U020-SIL-P020620',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020621', N'ACCUMULATEUR PRINC DE PDV-2100A',N'MT1-A001-U020-SIL-P020621',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020622', N'ACCUMULATEUR RESERVE DE PDV-2100A',N'MT1-A001-U020-SIL-P020622',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020623', N'BLOCAGE HYDRAULIC DE PDV-2100B',N'MT1-A001-U020-SIL-P020623',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020624', N'ACCUMULATEUR PRINC DE PDV-2100B',N'MT1-A001-U020-SIL-P020624',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020625', N'ACCUMULATEUR RESERVE DE PDV-2100B',N'MT1-A001-U020-SIL-P020625',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020626', N'POMPE PRINC (J-020100AB-1) PDV-2100A/B',N'MT1-A001-U020-SIL-P020626',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020627', N'POMPE PRINC (J-020100AB-2) PDV-2100A/B',N'MT1-A001-U020-SIL-P020627',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020628', N'POMPE CIRC (J-020100AB-3) PDV-2100A/B',N'MT1-A001-U020-SIL-P020628',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020629', N'SYSTÈME D''HUILE DE PDV-2100A/B',N'MT1-A001-U020-SIL-P020629',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020630', N'BLOCAGE HYDRAULIC DE PDV-2100A',N'MT1-A001-U020-SIL-P020630',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020631', N'ACCUMULATEUR PRINC DE PDV-2100A',N'MT1-A001-U020-SIL-P020631',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020632', N'ACCUMULATEUR RESERVE DE PDV-2100A',N'MT1-A001-U020-SIL-P020632',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020635', N'POMPE PRINC (J-020102AB-1) PV-2102A/B',N'MT1-A001-U020-SIL-P020635',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020636', N'POMPE PRINC (J-020102AB-2) PV-2102A/B',N'MT1-A001-U020-SIL-P020636',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020637', N'SYSTÈME D''HUILE DE PV-2102A/B',N'MT1-A001-U020-SIL-P020637',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020638', N'POMPE CIRC (J-020100AB-3) PV-2102A/B',N'MT1-A001-U020-SIL-P020638',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020639', N'BLOCAGE HYDRAULIC DE PV-2102A',N'MT1-A001-U020-SIL-P020639',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020640', N'ACCUMULATEUR PRINC DE PV-2102A',N'MT1-A001-U020-SIL-P020640',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020641', N'ACCUMULATEUR RESERVE DE PV-2102A',N'MT1-A001-U020-SIL-P020641',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020642', N'BLOCAGE HYDRAULIC DE PV-2102B',N'MT1-A001-U020-SIL-P020642',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020643', N'ACCUMULATEUR PRINC DE PV-2102B',N'MT1-A001-U020-SIL-P020643',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020644', N'ACCUMULATEUR RESERVE DE PV-2102B',N'MT1-A001-U020-SIL-P020644',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020645', N'PURGE PANNEAU CTRL DE LV-2100',N'MT1-A001-U020-SIL-P020645',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020646', N'PURGE PANNEAU CTRL DE LV-2105',N'MT1-A001-U020-SIL-P020646',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020647', N'PURGE PANNEAU CTRL DE TV-2117',N'MT1-A001-U020-SIL-P020647',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020649', N'BLOCAGE HYDRAULIC DE PV-2102B',N'MT1-A001-U020-SIL-P020649',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020650', N'PURGE PANNEAU CTRL DE PDV-2100A/B',N'MT1-A001-U020-SIL-P020650',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020651', N'ACCUMULATEUR RESERVE DE PDV-2100B',N'MT1-A001-U020-SIL-P020651',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020652', N'CYLINDRE FERMÉ DE PV-2102B',N'MT1-A001-U020-SIL-P020652',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020653', N'CYLINDRE OUVERT DE PDV-2100B',N'MT1-A001-U020-SIL-P020653',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020654', N'PURGE PANNEAU CTRL DE PV-2102A/B',N'MT1-A001-U020-SIL-P020654',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020656', N'ACCUMULATEUR RESERVE DE PV-2102B',N'MT1-A001-U020-SIL-P020656',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020658', N'CYLINDRE OUVERT DE PV-2102B',N'MT1-A001-U020-SIL-P020658',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020661', N'BLOCAGE HYDRAULIC DE PV-2102A',N'MT1-A001-U020-SIL-P020661',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020662', N'ACCUMULATEUR PRINC DE PV-2102A',N'MT1-A001-U020-SIL-P020662',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020663', N'ACCUMULATEUR RESERVE DE PV-2102A',N'MT1-A001-U020-SIL-P020663',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020664', N'CYLINDRE FERMÉ DE PV-2102A',N'MT1-A001-U020-SIL-P020664',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020665', N'CYLINDRE OUVERT DE PV-2102A',N'MT1-A001-U020-SIL-P020665',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020666', N'CYLINDRE FERMÉ DE PDV-2100A',N'MT1-A001-U020-SIL-P020666',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020667', N'CYLINDRE OUVERT DE PDV-2100A',N'MT1-A001-U020-SIL-P020667',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020668', N'BLOCAGE HYDRAULIC DE PDV-2100B',N'MT1-A001-U020-SIL-P020668',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020669', N'CYLINDRE FERMÉ DE PDV-2100B',N'MT1-A001-U020-SIL-P020669',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020674', N'POMPE PRINC (J-020102AB-1) PV-2102A/B',N'MT1-A001-U020-SIL-P020674',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020675', N'POMPE PRINC (J-020102AB-2) PDV-2102A/B',N'MT1-A001-U020-SIL-P020675',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020676', N'POMPE CIRC (J-020102AB-3) PV-2102A/B',N'MT1-A001-U020-SIL-P020676',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020677', N'SYSTÈME D''HUILE DE PV-2102A/B',N'MT1-A001-U020-SIL-P020677',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020679', N'ACCUMULATEUR PRINC DE PV-2102B',N'MT1-A001-U020-SIL-P020679',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'P020681', N'ACCUMULATEUR PRINC DE PDV-2100B',N'MT1-A001-U020-SIL-P020681',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'R020357', N'HAUTE PRESS PURGE AÉRATION-PDT-020547',N'MT1-A001-U020-SIL-R020357',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'R020358', N'BASSE PRESS PURGE AÉRATION-PDT-020547',N'MT1-A001-U020-SIL-R020358',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020408', N'BLOCAGE HYDRAULIC DE LV-2100',N'MT1-A001-U020-SIL-S020408',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020409', N'ESSAI ESD DU SYSTÈME D''HUILE DE LV-2100',N'MT1-A001-U020-SIL-S020409',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020410', N'COMMANDE JOG FERMER VANNE LV-2100',N'MT1-A001-U020-SIL-S020410',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020411', N'COMMANDE JOG OUVRIR VANNE LV-2100',N'MT1-A001-U020-SIL-S020411',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020412', N'SERVO VALVE DE LV-2100',N'MT1-A001-U020-SIL-S020412',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020413', N'BLOCAGE HYDRAULIC DE LV-2105',N'MT1-A001-U020-SIL-S020413',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020414', N'ESSAI ESD DU SYSTÈME D''HUILE DE LV-2105',N'MT1-A001-U020-SIL-S020414',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020415', N'COMMANDE JOG FERMER VANNE LV-2105',N'MT1-A001-U020-SIL-S020415',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020416', N'COMMANDE JOG OUVRIR VANNE LV-2105',N'MT1-A001-U020-SIL-S020416',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020417', N'SERVO VALVE DE LV-2105',N'MT1-A001-U020-SIL-S020417',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020418', N'BLOCAGE HYDRAULIC DE TV-2117',N'MT1-A001-U020-SIL-S020418',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020419', N'ESSAI ESD DU SYSTÈME D''HUILE DE TV-2117',N'MT1-A001-U020-SIL-S020419',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020420', N'COMMANDE JOG FERMER VANNE TV-2117',N'MT1-A001-U020-SIL-S020420',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020421', N'COMMANDE JOG OUVRIR VANNE TV-2117',N'MT1-A001-U020-SIL-S020421',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020422', N'SERVO VALVE DE TV-2117',N'MT1-A001-U020-SIL-S020422',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020423', N'BLOCAGE HYDRAULIC DE PDV-2100A',N'MT1-A001-U020-SIL-S020423',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020424', N'COMMANDE JOG FERMER VANNE PDV-2100A',N'MT1-A001-U020-SIL-S020424',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020425', N'COMMANDE JOG OUVRIR VANNE PDV-2100A',N'MT1-A001-U020-SIL-S020425',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020426', N'SERVO VALVE DE PDV-2100A',N'MT1-A001-U020-SIL-S020426',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020427', N'BLOCAGE HYDRAULIC DE PDV-2100B',N'MT1-A001-U020-SIL-S020427',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020428', N'COMMANDE JOG FERMER VANNE PDV-2100B',N'MT1-A001-U020-SIL-S020428',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020429', N'COMMANDE JOG OUVRIR VANNE PDV-2100B',N'MT1-A001-U020-SIL-S020429',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020430', N'SERVO VALVE DE PDV-2100B',N'MT1-A001-U020-SIL-S020430',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020431', N'BLOCAGE HYDRAULIC DE PV-2102A',N'MT1-A001-U020-SIL-S020431',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020432', N'COMMANDE JOG FERMER VANNE PV-2102A',N'MT1-A001-U020-SIL-S020432',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020434', N'COMMANDE JOG OUVRIR VANNE PV-2102A',N'MT1-A001-U020-SIL-S020434',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020435', N'SERVO VALVE DE PV-2102A',N'MT1-A001-U020-SIL-S020435',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020436', N'BLOCAGE HYDRAULIC DE PV-2102B',N'MT1-A001-U020-SIL-S020436',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020437', N'COMMANDE JOG FERMER VANNE PV-2102B',N'MT1-A001-U020-SIL-S020437',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020438', N'COMMANDE JOG OUVRIR VANNE PV-2102B',N'MT1-A001-U020-SIL-S020438',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'S020439', N'SERVO VALVE DE PV-2102B',N'MT1-A001-U020-SIL-S020439',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020506', N'TEMPÉRATURE DECHARGE COMPRESSEUR-J-290',N'MT1-A001-U020-SIL-T020506',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020507', N'TEMPÉRATURE RECHAUF RESV HUILE LUB-J-290',N'MT1-A001-U020-SIL-T020507',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020509', N'HAUTE TEMP PERM HUILE DE LUB-J-290',N'MT1-A001-U020-SIL-T020509',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020510', N'RÉSERVOIR DE LV-2105',N'MT1-A001-U020-SIL-T020510',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020511', N'PANNEAU DE CONTRÔLE DE LV-2100',N'MT1-A001-U020-SIL-T020511',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020512', N'RÉSERVOIR DE LV-2100',N'MT1-A001-U020-SIL-T020512',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020513', N'RÉSERVOIR DE LV-2100',N'MT1-A001-U020-SIL-T020513',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020514', N'PANNEAU DE CONTRÔLE DE LV-2105',N'MT1-A001-U020-SIL-T020514',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020515', N'RÉSERVOIR DE LV-2105',N'MT1-A001-U020-SIL-T020515',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020517', N'RÉSERVOIR DE TV-2117',N'MT1-A001-U020-SIL-T020517',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020518', N'PANNEAU DE CONTRÔLE DE TV-2117',N'MT1-A001-U020-SIL-T020518',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020519', N'RÉSERVOIR DE TV-2117',N'MT1-A001-U020-SIL-T020519',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020521', N'RÉSERVOIR DE PDV-2100A/B',N'MT1-A001-U020-SIL-T020521',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020522', N'PANNEAU DE CONTRÔLE DE PDV-2100A',N'MT1-A001-U020-SIL-T020522',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020523', N'RÉSERVOIR DE PDV-2100A/B',N'MT1-A001-U020-SIL-T020523',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020524', N'RÉSERVOIR DE PV-2102A/B',N'MT1-A001-U020-SIL-T020524',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020525', N'RÉSERVOIR DE PV-2102A/B',N'MT1-A001-U020-SIL-T020525',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020526', N'PANNEAU DE CONTRÔLE DE PV-2102A',N'MT1-A001-U020-SIL-T020526',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020528', N'PANNEAU DE CONTRÔLE DE PDV-2100B',N'MT1-A001-U020-SIL-T020528',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T020529', N'PANNEAU DE CONTRÔLE DE PV-2102B',N'MT1-A001-U020-SIL-T020529',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'T02392', N'TEMPÉRATURE DU RÉACTEUR-D-283',N'MT1-A001-U020-SIL-T02392',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020408', N'SLIDE-VALVE LV-2100',N'MT1-A001-U020-SIL-Z020408',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020409', N'SLIDE-VALVE LV-2100',N'MT1-A001-U020-SIL-Z020409',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020410', N'SLIDE-VALVE LV-2100',N'MT1-A001-U020-SIL-Z020410',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020411', N'SLIDE-VALVE LV-2105',N'MT1-A001-U020-SIL-Z020411',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020412', N'SLIDE-VALVE LV-2105',N'MT1-A001-U020-SIL-Z020412',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020413', N'SLIDE-VALVE LV-2105',N'MT1-A001-U020-SIL-Z020413',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020414', N'SLIDE-VALVE TV-2117',N'MT1-A001-U020-SIL-Z020414',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020415', N'SLIDE-VALVE TV-2117',N'MT1-A001-U020-SIL-Z020415',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020419', N'SLIDE-VALVE PDV-2100A',N'MT1-A001-U020-SIL-Z020419',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020423', N'SLIDE-VALVE PDV-2100B',N'MT1-A001-U020-SIL-Z020423',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020424', N'CAPTEUR DE POSITION',N'MT1-A001-U020-SIL-Z020424',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020427', N'SLIDE-VALVE PV-2102A',N'MT1-A001-U020-SIL-Z020427',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020428', N'CAPTEUR DE POSITION',N'MT1-A001-U020-SIL-Z020428',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020431', N'SLIDE-VALVE PV-2102B',N'MT1-A001-U020-SIL-Z020431',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020432', N'CAPTEUR DE POSITION',N'MT1-A001-U020-SIL-Z020432',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SIL', N'Z020433', N'SLIDE-VALVE TV-2117',N'MT1-A001-U020-SIL-Z020433',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100AB_1', N'POMPE HYDRAULIQUE (MAIN) DU PDV02100AB',N'MT1-A001-U020-SMP-J020100AB_1',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100AB_2', N'POMPE HYDRAULIQUE (SPARE)  DU PDV02100AB',N'MT1-A001-U020-SMP-J020100AB_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100AB_3', N'POMPE HYDRAULIQUE (CIRC)  DU PDV02100AB',N'MT1-A001-U020-SMP-J020100AB_3',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100_1', N'POMPE HYDRAULIQUE (MAIN) DU LV02100',N'MT1-A001-U020-SMP-J020100_1',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100_2', N'POMPE HYDRAULIQUE (SPARE)  DU LV02100',N'MT1-A001-U020-SMP-J020100_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020100_3', N'POMPE HYDRAULIQUE (CIRC)  DU LV02100',N'MT1-A001-U020-SMP-J020100_3',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020102AB_1', N'POMPE HYDRAULIQUE (MAIN) DU PV02102AB',N'MT1-A001-U020-SMP-J020102AB_1',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020102AB_2', N'POMPE HYDRAULIQUE (SPARE)  DU PV02102AB',N'MT1-A001-U020-SMP-J020102AB_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020102AB_3', N'POMPE HYDRAULIQUE (CIRC)  DU PV02102AB',N'MT1-A001-U020-SMP-J020102AB_3',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020105_1', N'POMPE HYDRAULIQUE (MAIN) DU LV02105',N'MT1-A001-U020-SMP-J020105_1',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020105_2', N'POMPE HYDRAULIQUE (SPARE)  DU LV02105',N'MT1-A001-U020-SMP-J020105_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020105_3', N'POMPE HYDRAULIQUE (CIRC)  DU LV02105',N'MT1-A001-U020-SMP-J020105_3',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020117_1', N'POMPE HYDRAULIQUE (MAIN) DU TV02117',N'MT1-A001-U020-SMP-J020117_1',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020117_2', N'POMPE HYDRAULIQUE (SPARE)  DU TV02117',N'MT1-A001-U020-SMP-J020117_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SMP', N'J020117_3', N'POMPE HYDRAULIQUE (CIRC)  DU TV02117',N'MT1-A001-U020-SMP-J020117_3',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020307', N'ACCUMULATEUR- PRINCIPAL LV2100',N'MT1-A001-U020-SPT-L020307',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020308', N'ACCUMULATEUR- ESD LV2100',N'MT1-A001-U020-SPT-L020308',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020309', N'ACCUMULATEUR- PRINCIPAL LV2105',N'MT1-A001-U020-SPT-L020309',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020310', N'ACCUMULATEUR- ESD LV2105',N'MT1-A001-U020-SPT-L020310',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020311', N'ACCUMULATEUR- PRINCIPAL TV2117',N'MT1-A001-U020-SPT-L020311',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020312', N'ACCUMULATEUR- ESD TV2117',N'MT1-A001-U020-SPT-L020312',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020313', N'ACCUMULATEUR- PRINCIPAL PDV2100A',N'MT1-A001-U020-SPT-L020313',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020314', N'ACCUMULATEUR- RESERVE PDV2100A',N'MT1-A001-U020-SPT-L020314',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020315', N'ACCUMULATEUR- PRINCIPAL PDV2100B',N'MT1-A001-U020-SPT-L020315',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020316', N'ACCUMULATEUR- RESERVE PDV2100B',N'MT1-A001-U020-SPT-L020316',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020317', N'ACCUMULATEUR- PRINCIPAL PV2102A',N'MT1-A001-U020-SPT-L020317',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020318', N'ACCUMULATEUR- RESERVE PV2102A',N'MT1-A001-U020-SPT-L020318',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020319', N'ACCUMULATEUR- PRINCIPAL PV2102B',N'MT1-A001-U020-SPT-L020319',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L020320', N'ACCUMULATEUR- RESERVE PV2102B',N'MT1-A001-U020-SPT-L020320',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L0291', N'CYCLONE-REACTEUR D-280',N'MT1-A001-U020-SPT-L0291',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L0291A', N'CYCLONE-REACTEUR D-280',N'MT1-A001-U020-SPT-L0291A',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L0291B', N'CYCLONE-REACTEUR D-280',N'MT1-A001-U020-SPT-L0291B',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SPT', N'L0291C', N'CYCLONE-REACTEUR D-280',N'MT1-A001-U020-SPT-L0291C',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U020', N'SSR', N'RVL020316_2', N'RUPTURE DISC-ACCUMULATEUR RELEVE PDV-210',N'MT1-A001-U020-SSR-RVL020316_2',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'L030028', N'INDICATEUR-NIVEAU BAS COTÉ REBOUILL-E305',N'MT1-A001-U030-SIL-L030028',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'L030029', N'NIVEAU BAS DÉBUTANISEUR-E305',N'MT1-A001-U030-SIL-L030029',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'L307', N'INDICATEUR-NIVEAU BAS DÉBUTANISEUR-E305',N'MT1-A001-U030-SIL-L307',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'P020547', N'PRESSION DIFF GARNITURE DU RÉACTEUR-D-28',N'MT1-A001-U030-SIL-P020547',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'P030300', N'PRESSION PMP AUX EN FONCTION-J-382',N'MT1-A001-U030-SIL-P030300',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'P030301', N'PRESSION DIFF FILTRE HUILE LUB-J-382',N'MT1-A001-U030-SIL-P030301',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'P030302', N'PRESSION DIFF HUILE SCELLEMENT-J-382',N'MT1-A001-U030-SIL-P030302',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T02194', N'COMMANDE JOG OUVRIR VANNE PV-2102B',N'MT1-A001-U030-SIL-T02194',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030055', N'TEMPÉRATURE BAS DÉBUTANISEUR-E-305',N'MT1-A001-U030-SIL-T030055',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030056', N'TEMPÉRATURE D''ENTRÉE REBOUILLEUR-C-384',N'MT1-A001-U030-SIL-T030056',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030057', N'TEMP DECHARGE 1ER STAGE-J-382',N'MT1-A001-U030-SIL-T030057',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030058', N'TEMP DECHARGE 2IEME STAGE-J-382',N'MT1-A001-U030-SIL-T030058',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030059', N'TEMPÉRATURE SORTIE REFROID D''HUILE-J-382',N'MT1-A001-U030-SIL-T030059',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030060', N'TEMPERATURE CHAUF RESERV HUILE LUB-J-382',N'MT1-A001-U030-SIL-T030060',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T030061', N'TEMPÉRATURE RECHAUFFEUR DEGASEUR-F-309',N'MT1-A001-U030-SIL-T030061',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T0307', N'BLOCAGE HYDRAULIC DE PV-2102B',N'MT1-A001-U030-SIL-T0307',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A001', N'U030', N'SIL', N'T0308', N'COMMANDE JOG FERMER VANNE PV-2102B',N'MT1-A001-U030-SIL-T0308',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4323', N'RESERVOIR/F4303',N'MT1-A002-U430-SIL-L4323',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4327', N'RESERVOIR/F4305',N'MT1-A002-U430-SIL-L4327',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4328', N'RESERVOIR/F4304',N'MT1-A002-U430-SIL-L4328',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4330', N'TOUR/E4301',N'MT1-A002-U430-SIL-L4330',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4331', N'RESERVOIR/F4307B',N'MT1-A002-U430-SIL-L4331',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4334', N'TOUR/E4302',N'MT1-A002-U430-SIL-L4334',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4337', N'TOUR/E4304',N'MT1-A002-U430-SIL-L4337',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4338', N'TOUR/E4305',N'MT1-A002-U430-SIL-L4338',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4339', N'RESERVOIR/F4308HAUT',N'MT1-A002-U430-SIL-L4339',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4340', N'RESERVOIR/F4308BAS',N'MT1-A002-U430-SIL-L4340',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4341', N'RÉSERVOIR / F4309',N'MT1-A002-U430-SIL-L4341',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4343', N'RÉSERVOIR / F4311',N'MT1-A002-U430-SIL-L4343',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4344', N'RESERVOIR/F4318',N'MT1-A002-U430-SIL-L4344',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4347', N'RESERVOIR/F4321NORD',N'MT1-A002-U430-SIL-L4347',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4351', N'RESERVOIR/F4322A2',N'MT1-A002-U430-SIL-L4351',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4352', N'RESERVOIR/F4322A3',N'MT1-A002-U430-SIL-L4352',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4353', N'RESERVOIR/F4323B1',N'MT1-A002-U430-SIL-L4353',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4354', N'RESERVOIR/F4331B2',N'MT1-A002-U430-SIL-L4354',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4362', N'RESERVOIR/F4324C1',N'MT1-A002-U430-SIL-L4362',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4363', N'RESERVOIR/F4324C2',N'MT1-A002-U430-SIL-L4363',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4364', N'RESERVOIR/F4324C3',N'MT1-A002-U430-SIL-L4364',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4368', N'RESERVOIR/F4330',N'MT1-A002-U430-SIL-L4368',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4369', N'POMPE/J4323',N'MT1-A002-U430-SIL-L4369',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4370', N'POMPE/J4323',N'MT1-A002-U430-SIL-L4370',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4371', N'POMPE/J4323',N'MT1-A002-U430-SIL-L4371',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'L4380', N'RESERVOIR/F4302',N'MT1-A002-U430-SIL-L4380',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U430', N'SIL', N'T319', N'D-4302B - REACTEUR',N'MT1-A002-U430-SIL-T319',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4411', N'TOUR/E4401',N'MT1-A002-U440-SIL-L4411',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L44116', N'RESERVOIR/F4457',N'MT1-A002-U440-SIL-L44116',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L44126', N'RESERVOIR/F4459',N'MT1-A002-U440-SIL-L44126',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4413', N'RESERVOIR/F4413',N'MT1-A002-U440-SIL-L4413',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4419', N'TOUR/E4402',N'MT1-A002-U440-SIL-L4419',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4422', N'TOUR/E4403',N'MT1-A002-U440-SIL-L4422',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4423', N'RESERVOIR/F4413',N'MT1-A002-U440-SIL-L4423',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4430', N'RESERVOIR/F4414',N'MT1-A002-U440-SIL-L4430',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4436', N'RESERVOIR/F4409A',N'MT1-A002-U440-SIL-L4436',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A002', N'U440', N'SIL', N'L4468', N'RESERVOIR/F4415',N'MT1-A002-U440-SIL-L4468',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U140', N'SSR', N'RVF1404B', N'SOUPAPE DE DECHARGE RV-F-1404B',N'MT1-A003-U140-SSR-RVF1404B',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U140', N'SSR', N'RVO291', N'SOUPAPE SURETE - O-291',N'MT1-A003-U140-SSR-RVO291',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U150', N'SLE', N'L1503_A', N'VANNE GLISSIÈRE AU CANAL D''ENTRÉ TOUR D''',N'MT1-A003-U150-SLE-L1503_A',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U150', N'SLE', N'L1503_B', N'VANNE GLISSIÈRE AU CANAL D''ENTRÉ TOUR D''',N'MT1-A003-U150-SLE-L1503_B',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U169', N'SLE', N'R169001', N'RESTRICTION ORIFICE - DEBIT MIN POMPE J-',N'MT1-A003-U169-SLE-R169001',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'A170014', N'LEL / J-170035',N'MT1-A003-U170-SIL-A170014',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'F170033', N'ESSENCE / J-170035',N'MT1-A003-U170-SIL-F170033',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'L170097', N'ESSENCE / F-170031',N'MT1-A003-U170-SIL-L170097',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'L170098', N'ESSENCE / F-170031',N'MT1-A003-U170-SIL-L170098',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'L170099', N'ESSENCE / F-170031',N'MT1-A003-U170-SIL-L170099',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'P170097', N'ESSENCE / J-170035',N'MT1-A003-U170-SIL-P170097',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'P170098', N'ESSENCE / J-170035',N'MT1-A003-U170-SIL-P170098',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'S170049', N'ESSENCE / J-170035',N'MT1-A003-U170-SIL-S170049',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'T170077', N'ESSENCE / F-170031',N'MT1-A003-U170-SIL-T170077',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'T170078', N'TEMPERATURR RÉSERVOIR-TK-306',N'MT1-A003-U170-SIL-T170078',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SIL', N'Z170049', N'ESSENCE / SOV-170049',N'MT1-A003-U170-SIL-Z170049',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U170', N'SWM', N'OUTIL', N'REMORQUE GENERATRICE LGP9924',N'MT1-A003-U170-SWM-OUTIL',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U172', N'SIL', N'T171551', N'TX TEMPERATURE-RESERVOIR-TK-1551',N'MT1-A003-U172-SIL-T171551',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U172', N'SIL', N'T172071', N'TX TEMPERATURE-RESERVOIR-TK-1551',N'MT1-A003-U172-SIL-T172071',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U173', N'SEH', N'HPC19185_6', N'PANNEAU DE CONTRÔLE CABLE CHAUFFANT',N'MT1-A003-U173-SEH-HPC19185_6',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U190', N'SEG', N'BCD190001', N'CABINET DE BATTERIES 36VCC',N'MT1-A003-U190-SEG-BCD190001',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U190', N'SEG', N'UPN190025', N'PANNEAU ELECTRIQUE',N'MT1-A003-U190-SEG-UPN190025',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U190', N'SEH', N'HPC190019', N'PANNEAU CONTROLE CABLES CHAUFFANTS',N'MT1-A003-U190-SEH-HPC190019',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U190', N'SIL', N'L190040', N'NIVEAU RÉSERVOIR RÉCUPÉRATION HYDROCARBU',N'MT1-A003-U190-SIL-L190040',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U280', N'SIL', N'F280173', N'DEBIT / EAU RECIRC / J-2813/A',N'MT1-A003-U280-SIL-F280173',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U280', N'SMP', N'J28100', N'POMPE RECIRCULATION UFAD',N'MT1-A003-U280-SMP-J28100',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U280', N'SMP', N'J28101', N'POMPE ECHANTILLONNAGE',N'MT1-A003-U280-SMP-J28101',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U280', N'SMP', N'J2810A', N'REBUT-POMPE RECH. INJECT.ACIDE SULF. H/S',N'MT1-A003-U280-SMP-J2810A',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A003', N'U480', N'SPT', N'F480019', N'F-480019 RESERVOIR ANTITARTE NALCO',N'MT1-A003-U480-SPT-F480019',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'IFST', N'SAB', N'K16101', N'GARAGE LEVI, 6E AVE. PRES SHERBROOKE',N'MT1-A004-IFST-SAB-K16101',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U540', N'SWM', N'OUTIL', N'MARTEAU PNEUMATIQUE DE DEMOLITION',N'MT1-A004-U540-SWM-OUTIL',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SMP', N'L840005', N'MÉLANGEUR MOBILE',N'MT1-A004-U840-SMP-L840005',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAT036', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAT036',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAT037', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAT037',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAT038', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAT038',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAV105', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAV105',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAV106', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAV106',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'CAZ051', N'ÉQUIPEMENT DE CALIBRATION DE L''INSTRUMEN',N'MT1-A004-U840-SWM-CAZ051',302,5,'fr';
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1', N'A004', N'U840', N'SWM', N'OUTIL', N'OUTILS MESURAGE ELECTRIQUE',N'MT1-A004-U840-SWM-OUTIL',302,5,'fr';

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
		[Level] = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
COMMIT TRANSACTION




-- Sarnia updates (none)

-- Denver updates
UPDATE dbo.FunctionalLocation SET Description = N'PC0402, 175# STEAM 2IN VALVE/FLATCAPPED' where FullHierarchy = N'DN1-3003-0013-SLP-PC0402' and SiteId = 2
UPDATE dbo.FunctionalLocation SET Description = N'39X025, XF3925 FAN MOTOR STOP' where FullHierarchy = N'DN1-3003-0039-SIL-39X025' and SiteId = 2

-- Energy Services
UPDATE dbo.FunctionalLocation SET Description = N'FLOW LOOP-RECIRC. AIR SOUTH WINDBOX' where FullHierarchy = N'EU1-P031-BL03-SIL-F1716' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'BOILER 3 OIL COOLER BALL MILL SOUTH' where FullHierarchy = N'EU1-P031-BL03-SPH-E0021B' and SiteId = 3

-- Extraction
UPDATE dbo.FunctionalLocation SET Description = N'EAST MFT BARGE POND 7 UNIT HEATER #2' where FullHierarchy = N'EX1-OPLT-BLDI-SAB-RH0059' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW5-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2081' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW5-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2082' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW5-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2083' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW5-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2084' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW10-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2085' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'EHT 82SW10-2”' where FullHierarchy = N'EX1-P082-LPSW-SEH-PH2086' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'OPPC UNIT HEATER - BREAKER BUILDING' where FullHierarchy = N'EX1-P085-OPT3-SAB-RH0007L' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED  EXHAUST FAN' where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0118' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED  EXHAUST FAN' where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0119' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED  EXHAUST FAN' where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0120' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'NBPH WALL MOUNTED  EXHAUST FAN' where FullHierarchy = N'EX1-P086-BLDI-SAB-RK0121' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'RADIANT TUBE HEATER SEP GYPSUM-WET BLDG' where FullHierarchy = N'EX1-P300-BLDI-SAB-RH0022B' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'UNIT HEATER BASEBOARD ELEC WOMEN W/R 305' where FullHierarchy = N'EX1-P300-BLDI-SAB-RH0092' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'UNIT HEATER BASEBOARD ELEC OFFICE 304' where FullHierarchy = N'EX1-P300-BLDI-SAB-RH0093' and SiteId = 3

-- Mining
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-SB LI WASHROOM-244H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2440' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-MILLENNIUM LI WASHROOM-250H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2500' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-WASTE LUBE LARGE LUNCHROOM-254H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2540' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-MILLENIUM LUNCHROOM-257H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2570' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-262H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2620' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-263H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2630' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-264H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2640' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-265H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2650' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-266H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2660' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOMS-267H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2670' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-SB WARM UP SHED-368H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2680' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-COKEPIT WASHROOM-272H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2720' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-WASH CAR MINE#2 12X20-298H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA2980' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-360H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3600' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-361H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3610' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-362H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3620' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-363H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3630' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-364H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3640' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM-365H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3650' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE OFFICE-385H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3850' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE OFFICE-393H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3930' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE OFFICE-394H' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3940' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE LUNCHROOM' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3950' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PORTABLE OFFICE' where FullHierarchy = N'MN1-P083-IFST-SAB-RA3970' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'TRAILER-PERMIT CENTER.-W # NAL 10588' where FullHierarchy = N'MN1-P083-IFST-SAB-RA8320' and SiteId = 3

-- Upgrading
UPDATE dbo.FunctionalLocation SET Description = N'LIGHTING PANEL  4TH COKER DECK OPERATOR' where FullHierarchy = N'UP1-P005-DCU1-SEL-PA0101' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'VALVE, PRESSURE SAFETY RELIEF' where FullHierarchy = N'UP1-P008-AMN1-SSR-PSV0101' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'LIGHTING PANEL, COMPRESSOR HOUSE' where FullHierarchy = N'UP1-P010-COMS-SEL-PA010J' and SiteId = 3
UPDATE dbo.FunctionalLocation SET Description = N'54K-101/102 LUBE OIL SUPPLY' where FullHierarchy = N'UP2-P054-RFR2-SIV-PRV8001' and SiteId = 3

-- Firebag
UPDATE dbo.FunctionalLocation SET Description = N'91D-3060 ,FLEXIBLE HOSE, 4 "' where FullHierarchy = N'FB1-P091-3000-SLE-SP3056' and SiteId = 5
UPDATE dbo.FunctionalLocation SET Description = N'PANEL,CONTROL ELECTROSTATIC TREATER' where FullHierarchy = N'FB1-P093-1000-SEG-PJ1010' and SiteId = 5
UPDATE dbo.FunctionalLocation SET Description = N'RECTIFIER, CATHODIC PROTECTION, 99D-4080' where FullHierarchy = N'FB1-P099-4000-SEG-PW4780' and SiteId = 5
UPDATE dbo.FunctionalLocation SET Description = N'RECTIFIER, CATHODIC PROTECTION, 99D-4095' where FullHierarchy = N'FB1-P099-4000-SEG-PW4795' and SiteId = 5

-- MacKay River
UPDATE dbo.FunctionalLocation SET Description = N'BUILDING, PROCESS' where FullHierarchy = N'MR1-P001-IFST-SAB-BU1000' and SiteId = 7
UPDATE dbo.FunctionalLocation SET Description = N'PRESSURE, LOW PRESS STM COND FROM E405' where FullHierarchy = N'MR1-P008-0800-SIL-P0720' and SiteId = 7
UPDATE dbo.FunctionalLocation SET Description = N'HAND OPERATED, WELLHEAD HP STM IN' where FullHierarchy = N'MR1-P022-0022-SIL-G5IH0015' and SiteId = 7
UPDATE dbo.FunctionalLocation SET Description = N'HAND OPERATED, WELLHEAD HP STM IN' where FullHierarchy = N'MR1-P022-0022-SIL-G5IH0020' and SiteId = 7
UPDATE dbo.FunctionalLocation SET Description = N'HAND OPERATED, 23F4I WELLHEAD HP STM IN' where FullHierarchy = N'MR1-P023-0023-SIL-F4IH0015' and SiteId = 7

-- Edmonton
UPDATE dbo.FunctionalLocation SET Description = N'NC4 FROM 11G1A/B TO 11E17 VIA 11P1156”/1' where FullHierarchy = N'ED1-A001-U011-SLP-INSP00410' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'C4 +H2 FROM 11P1093” TO 11E7 VIA 11P208”' where FullHierarchy = N'ED1-A001-U011-SLP-INSP00500' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ 600# STEAM SUPPLY' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02000' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ H.P. COND.' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02050' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ 175# STEAM SUPPLY' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02200' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ 50# STEAM SUPPLY,NONCRITICAL_' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02300' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ 50# STEAM SUPPLY STEAM TRACING' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02400' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ L.P. PMP COND.,NONCRITICAL' where FullHierarchy = N'ED1-A001-U011-SLP-INSP02450' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ COLLING WATER SUPPLY,CRITICAL' where FullHierarchy = N'ED1-A001-U011-SLP-INSP05500' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'BLK. ‘D’ COLLING WATER RETURN,CRITICAL' where FullHierarchy = N'ED1-A001-U011-SLP-INSP05600' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'SPILLBACK FROM LINE 11H24” TO 11E14' where FullHierarchy = N'ED1-A001-U011-SLP-INSP06010' and SiteId = 8
UPDATE dbo.FunctionalLocation SET Description = N'O/H LINE FROM 12C46 TO PSV’S AND TO 12PV' where FullHierarchy = N'ED1-A001-U012-SLP-INSP01632' and SiteId = 8

-- Montreal
UPDATE dbo.FunctionalLocation SET Description = N'DEMARREUR TRANSFO NTH-4302' where FullHierarchy = N'MT1-A002-U430-SEG-NTH4302' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'PANNEAU CONTRÔLE' where FullHierarchy = N'MT1-A003-U280-SEH-HPC280_01' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'PANNEAU DE CONTRÔLE' where FullHierarchy = N'MT1-A003-U280-SEH-HPC280_02' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE SURETÉ 208-S-00168-2''''' where FullHierarchy = N'MT1-A003-U280-SSR-RVS00168' and SiteId = 9


INSERT INTO DbVersion (
   VersionNumber
) VALUES (
   '4.2.5884'  -- VersionNumber - varchar(20)
)
GO