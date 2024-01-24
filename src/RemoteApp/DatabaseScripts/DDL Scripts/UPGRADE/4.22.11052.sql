UPDATE FunctionalLocation SET Source=1 WHERE SiteId=15 AND FullHierarchy='FH1' AND PlantId=764
GO

DELETE FROM FunctionalLocationAncestor WHERE Id IN (SELECT Id FROM FunctionalLocation WHERE SiteId=15 AND [Level]>1 AND PlantId=764) OR AncestorId IN (SELECT Id FROM FunctionalLocation WHERE SiteId=15 AND [Level]>1 AND PlantId=764)
GO

DELETE FROM FunctionalLocationOperationalMode WHERE UnitId IN (SELECT Id FROM FunctionalLocation WHERE SiteId=15 AND [Level]>1 AND PlantId=764)
GO

DELETE FROM FunctionalLocation WHERE Id IN (SELECT Id FROM FunctionalLocation WHERE SiteId=15 and [Level]>1 AND PlantId=764)
GO

---------------------------------------------------
---  FH1-P610   ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'PRIMARY EXTRACTION ORE PROCESSING', N'FH1-P610', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 CHEMICALS', N'FH1-P610-CHEM', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 COMMON SYSTEMS', N'FH1-P610-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 CRUSHING TRAIN 1', N'FH1-P610-CRT1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 CRUSHING TRAIN 2', N'FH1-P610-CRT2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 ELECTRICAL SYSTEMS', N'FH1-P610-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 EMERGENCY DUMP PONDS', N'FH1-P610-EMDP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 HYDROTRANSPORT LINE 1', N'FH1-P610-HTL1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 HYDROTRANSPORT LINE 2', N'FH1-P610-HTL2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 HYDROTRANSPORT LINE 3', N'FH1-P610-HTL3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 BUILDINGS', N'FH1-P610-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 SURGE BIN', N'FH1-P610-SBIN', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 SLURRY PREPARATION TRAIN 1', N'FH1-P610-SPT1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 SLURRY PREPARATION TRAIN 2', N'FH1-P610-SPT2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P610 SLURRY PREPARATION TRAIN 3', N'FH1-P610-SPT3', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P611  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'PRIMARY EXTRACTION SEPARATION AND TAILS', N'FH1-P611', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 CHEMICALS', N'FH1-P611-CHEM', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 COMMON SYSTEMS', N'FH1-P611-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 ELECTRICAL SYSTEMS', N'FH1-P611-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 EMERGENCY DUMP PONDS', N'FH1-P611-EMDP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 FROTH HANDLING', N'FH1-P611-FRTH', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 FINAL TAILINGS LINE 1', N'FH1-P611-FTL1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 FINAL TAILINGS LINE 2', N'FH1-P611-FTL2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 FINAL TAILINGS LINE 3', N'FH1-P611-FTL3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 HYDROTRANSPORT LINE 1', N'FH1-P611-HTL1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 HYDROTRANSPORT LINE 2', N'FH1-P611-HTL2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 HYDROTRANSPORT LINE 3', N'FH1-P611-HTL3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 BUILDINGS', N'FH1-P611-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 PRIMARY SEPARATION TRAIN 1', N'FH1-P611-PST1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 PRIMARY SEPARATION TRAIN 2', N'FH1-P611-PST2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 SECONDARY SEPARATION TRAIN 1', N'FH1-P611-SST1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 SECONDARY SEPARATION TRAIN 2', N'FH1-P611-SST2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 THICKENER TRAIN 1', N'FH1-P611-THT1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 THICKENER TRAIN 2', N'FH1-P611-THT2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 TERTIARY SEPARATION TRAIN 1', N'FH1-P611-TST1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P611 TERTIARY SEPARATION TRAIN 2', N'FH1-P611-TST2', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P612  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'SECONDARY EXTRACTION', N'FH1-P612', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 2ND STAGE TAILINGS SRU', N'FH1-P612-2TSR', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 SOLVENT AND CHEMICAL UNLOADING', N'FH1-P612-CHEM', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 COMMON SYSTEMS', N'FH1-P612-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 ELECTRICAL SYSTEMS', N'FH1-P612-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FLARE SYSTEM', N'FH1-P612-FLRS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FROTH TANK AREA', N'FH1-P612-FRTH', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FROTH SETTLING UNIT TRAIN 1', N'FH1-P612-FSU1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FROTH SETTLING UNIT TRAIN 2', N'FH1-P612-FSU2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FROTH SETTLING UNIT TRAIN 3', N'FH1-P612-FSU3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 BUILDINGS', N'FH1-P612-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 FROTH TREATMENT AND FLARE PONDS', N'FH1-P612-POND', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 SOLVENT STORAGE', N'FH1-P612-SOLV', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 SOLVENT RECOVERY UNIT TRAIN 1', N'FH1-P612-SRU1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 SOLVENT RECOVERY UNIT TRAIN 2', N'FH1-P612-SRU2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 TAILINGS SRU 1ST STAGE TRAIN 1', N'FH1-P612-TSR1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 TAILINGS SRU 1ST STAGE TRAIN 2', N'FH1-P612-TSR2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 TAILINGS SRU 1ST STAGE TRAIN 3', N'FH1-P612-TSR3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P612 VAPOUR RECOVERY UNIT', N'FH1-P612-VRU1', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P613  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'COURSE TAILINGS', N'FH1-P613', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'BIRD DETERRENT SYSTEM', N'FH1-P613-BIRD', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 COMMON SYSTEMS', N'FH1-P613-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 ELECTRICAL SYSTEMS', N'FH1-P613-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 FINAL TAILINGS LINE 1', N'FH1-P613-FTL1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 FINAL TAILINGS LINE 2', N'FH1-P613-FTL2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 FINAL TAILINGS LINE 3', N'FH1-P613-FTL3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 BUILDINGS', N'FH1-P613-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 TAILINGS THICKENER TRAIN 1', N'FH1-P613-THT1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 TAILINGS THICKENER TRAIN 2', N'FH1-P613-THT2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P613 TAILINGS SRU LINE TO OPTA', N'FH1-P613-TSRU', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P614  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'FINE TAILINGS', N'FH1-P614', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 RECLAIMED WATER BARGE 1', N'FH1-P614-BGE1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 RECLAIMED WATER BARGE 2', N'FH1-P614-BGE2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 BOATS', N'FH1-P614-BOAT', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 COMMON SYSTEMS', N'FH1-P614-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 ELECTRICAL SYSTEMS', N'FH1-P614-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 BUILDINGS', N'FH1-P614-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 PROCESS AFFECTED WATER EAST FACILITY', N'FH1-P614-PAWE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 PROCESS AFFECTED WATER WEST FACILITY', N'FH1-P614-PAWW', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 RECLAIMED WATER BOOSTER PUMPHOUSE', N'FH1-P614-RCWB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P614 RECLAIMED WATER LINE', N'FH1-P614-RCWL', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P630  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'WATER SUPPLY SYSTEM', N'FH1-P630', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P630 ELECTRICAL <13.8KV', N'FH1-P630-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P630 BUILDINGS', N'FH1-P630-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P630 RECYCLE WATER SYSTEM', N'FH1-P630-RCWS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P630 RIVER INTAKE PUMPS AND PIPELINE SYS', N'FH1-P630-RIPP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P630 RAW WATER DISTRIBUTION SYSTEM', N'FH1-P630-RWD1', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P631  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'UTILITIES', N'FH1-P631', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 100 KPA STEAM SYSTEM', N'FH1-P631-0100', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 380 KPA STEAM SYSTEM', N'FH1-P631-0380', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 2200 KPA STEAM SYSTEM', N'FH1-P631-2200', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 4400 KPA STEAM SYSTEM', N'FH1-P631-4400', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 COLD GLYCOL SYSTEM', N'FH1-P631-CGLY', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 CLOSED LOOP COOLING WATER SYSTEM', N'FH1-P631-CLCW', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 CONDENSATE SYSTEM', N'FH1-P631-COND', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 ODORIZED NATURAL GAS DISTRIBUTION', N'FH1-P631-DIST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 ELECTRICAL <13.8KV', N'FH1-P631-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 EXCESS THICKENER OVERFLOW SYSTEM', N'FH1-P631-ETOS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 NATURAL GAS SUPPLY TO FLARE', N'FH1-P631-FSNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 2413 KPA NATURAL GAS TO GTGS', N'FH1-P631-GTNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 HOT GLYCOL SYSTEM', N'FH1-P631-HGLY', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 HP NATURAL GAS SYSTEM', N'FH1-P631-HPNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 HOT PROCESS WATER SYSTEM', N'FH1-P631-HPWS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 INSTRUMENT & UTILITY AIR SYSTEMS', N'FH1-P631-IAUA', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 BUILDINGS', N'FH1-P631-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 LP NATURAL GAS SYSTEM', N'FH1-P631-LPNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 NATURAL GAS MAIN LINE', N'FH1-P631-MLNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 MP NATURAL GAS SYSTEM', N'FH1-P631-MPNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 NE ODORIZED NATURAL GAS', N'FH1-P631-NENG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 NATURAL GAS CHEMICAL INJECTION', N'FH1-P631-NGCI', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 NITROGEN SYSTEM', N'FH1-P631-NTRO', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 PROCESS WATER CHEMICAL INJECTION', N'FH1-P631-PWCI', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 PROCESS WATER HEATER CONDENSATE', N'FH1-P631-PWHC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 REJECTS & SUMPS', N'FH1-P631-SUMP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 SW ODORIZED NATURAL GAS', N'FH1-P631-SWNG', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 UTILITY AND GLAND WATER SYSTEMS', N'FH1-P631-UWGW', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 WTP-CHEMICAL INJECTION', N'FH1-P631-WTCI', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 WTP-RO SYSTEM', N'FH1-P631-WTRO', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 WTP-TREATED WATER & SOFTENER SYSTEM', N'FH1-P631-WTTW', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P631 WTP-RAW WATER & UF SYSTEM', N'FH1-P631-WTUF', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P632  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'POTABLE WATER', N'FH1-P632', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 CHEMICAL DOZING', N'FH1-P632-CHEM', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 COMMON SERVICES', N'FH1-P632-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 POTABLE WATER DISTRIBUTION', N'FH1-P632-DIST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 ELECTRICAL <13.8KV', N'FH1-P632-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 FEED WATER STREAM', N'FH1-P632-FWST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 BUILDINGS', N'FH1-P632-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 MULTIMEDIA FILTERS', N'FH1-P632-MMFS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 NANO FILTERATION (NF) MEMBRANES', N'FH1-P632-NFMB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 NEUTRALIZATION AND WASTES', N'FH1-P632-NTWT', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 POTABLE WATER OUTFLOW', N'FH1-P632-PWOT', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 ULTRA FILTERATION (UF) MEMBRANES', N'FH1-P632-UFMB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P632 UV DISINFECTION REACTORS', N'FH1-P632-UVRA', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P633  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'FIRE PROTECTION', N'FH1-P633', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P633 FIRE WATER DISTRIBUTION', N'FH1-P633-DIST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P633 BUILDINGS', N'FH1-P633-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P633 NE FIRE WATER PUMP SYSTEM', N'FH1-P633-NEFP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P633 OPP FIRE WATER PUMP SYSTEM', N'FH1-P633-OPFP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P633 SW FIRE WATER PUMP SYSTEM', N'FH1-P633-SWFP', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P634  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'WASTE WATER', N'FH1-P634', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 BIOREACTORS & SLUDGE (3000 SERIES)', N'FH1-P634-BIOR', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 CHEMICALS (6000 SERIES)', N'FH1-P634-CHEM', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 SANITARY SEWER COLLECTION', N'FH1-P634-COLL', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 COMMON SYSTEMS', N'FH1-P634-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 DEWATERING (5000 SERIES)', N'FH1-P634-DWTR', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 EFFLUENT TREATMENT (MEMBRANES & UV)', N'FH1-P634-EFTR', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 ELECTRICAL SYSTEMS', N'FH1-P634-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 BUILDINGS', N'FH1-P634-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 INLET & EQUALIZATION (2000 SERIES)', N'FH1-P634-INEQ', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 UTILITY WATER', N'FH1-P634-UWTR', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P634 WASTE (SUMPS & TANKS- 2800 SERIES)', N'FH1-P634-WAST', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P635  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'TRANSMISSION AND DISTRIBUTION 25KV & UP', N'FH1-P635', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 BARGE SUBSTATION', N'FH1-P635-BRGE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 CENTRAL DISTRIBUTION', N'FH1-P635-CNTL', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 COGEN SUBSTATION', N'FH1-P635-COGN', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 EXTRACTION & TAILINGS SUBSTATION', N'FH1-P635-EXTS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 HT BOOSTER PUMPHOUSE SUBSTATION', N'FH1-P635-HTBP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 BUILDINGS', N'FH1-P635-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 MAIN DISTRIBUTION', N'FH1-P635-MAIN', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 MINE SUBSTATIONS', N'FH1-P635-MINE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 ORE PREPARATION SUBSTATION', N'FH1-P635-OPPS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 OPTA SUBSTATION', N'FH1-P635-OPTA', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P635 TAILINGS BOOSTER PUMPHOUSE SUBSTATION', N'FH1-P635-TLBP', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P636  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'TRANSMISSION AND DISTRIBUTION 13.8KV', N'FH1-P636', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 BARGE SUBSTATION', N'FH1-P636-BRGE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 CENTRAL SUBSTATION', N'FH1-P636-CNTL', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 EXTRACTION & TAILINGS SUBSTATION', N'FH1-P636-EXTS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 HT BOOSTER PUMPHOUSE SUBSTATION', N'FH1-P636-HTBP', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 BUILDINGS', N'FH1-P636-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 MAIN DISTRIBUTION', N'FH1-P636-MAIN', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 MINE SUBSTATIONS', N'FH1-P636-MINE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 ORE PREPARATION SUBSTATION', N'FH1-P636-OPPS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 OPTA SUBSTATION', N'FH1-P636-OPTA', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 SOUTH WEST SUBSTATION', N'FH1-P636-SWST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P636 TAILINGS BOOSTER PUMPHOUSE SUBSTATION', N'FH1-P636-TLBP', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P637  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'COGEN & STEAM GENERATION', N'FH1-P637', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #1 AUXILIARY SYSTEMS', N'FH1-P637-AUX1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #2 AUXILIARY SYSTEMS', N'FH1-P637-AUX2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER FEED WATER CHEMICAL INJECTION', N'FH1-P637-BFCI', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER FEED WATER SYSTEM', N'FH1-P637-BFWS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER BLOWDOWN SYSTEM', N'FH1-P637-BLBD', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER #1', N'FH1-P637-BLR1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER #2', N'FH1-P637-BLR2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER #3', N'FH1-P637-BLR3', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BOILER #4', N'FH1-P637-BLR4', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 COGEN COMMON SYSTEMS', N'FH1-P637-CGEN', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 ELECTRICAL <13.8KV', N'FH1-P637-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #1 GENERATOR', N'FH1-P637-GEN1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #2 GENERATOR', N'FH1-P637-GEN2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #1', N'FH1-P637-GTG1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 GAS TURBINE #2', N'FH1-P637-GTG2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 HRSG #1 BLOWDOWN SYSTEM', N'FH1-P637-HBD1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 HRSG #2 BLOWDOWN SYSTEM', N'FH1-P637-HBD2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 HRSG #1', N'FH1-P637-HRS1', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 HRSG #2', N'FH1-P637-HRS2', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P637 BUILDINGS', N'FH1-P637-IFST', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P641  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'NON PROCESS BUILDINGS', N'FH1-P641', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P641 INFRASTRUCTURE BLOCK BUILDINGS', N'FH1-P641-INFB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P641 LODGES', N'FH1-P641-LDGS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P641 OPERATOR PERMIT CENTER BUILDINGS', N'FH1-P641-OPCB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P641 OFFPLOT BUILDINGS', N'FH1-P641-OPLT', 0, 0, 3, 764, N'en', 1)


GO

---------------------------------------------------
---  FH1-P642  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'INFRASTRUCTURE FUEL DEPOTS', N'FH1-P642', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 COMMON SYSTEMS', N'FH1-P642-COMS', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 DIESEL DYE', N'FH1-P642-DDYE', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 DIESEL EXHAUST FLUID', N'FH1-P642-DEXF', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 ELECTRICAL SYSTEMS', N'FH1-P642-ELEC', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 HVFD FUEL', N'FH1-P642-HVFL', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 HVFD LUBE', N'FH1-P642-HVLB', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P642 BUILDINGS', N'FH1-P642-IFST', 0, 0, 3, 764, N'en', 1)

GO

---------------------------------------------------
---  FH1-P651  ---
---------------------------------------------------

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'TELECOM ASSETS', N'FH1-P651', 0, 0, 2, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P651 TELECOM BUILDINGS', N'FH1-P651-IFST', 0, 0, 3, 764, N'en', 1)

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'P651 TELECOM EQUIPMENT', N'FH1-P651-TLCM', 0, 0, 3, 764, N'en', 1)

GO

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
		SiteId = 15
		AND Level = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
COMMIT TRANSACTION
GO

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
   

-- Insert the Ancestor records for these Fort Hills Operations Flocs
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
	SELECT 
		c.id, a.id, a.[Level]
		FROM FunctionalLocation a
		INNER JOIN FunctionalLocation c 
			ON c.siteid = a.siteid and 
			c.[Level] > a.[Level] and
			CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
		where
			c.SiteId = 15
)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO



GO

