

INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (12, 'Wood Buffalo', 'Mountain Standard Time', 'WoodBuffalo');

GO

-- LABTODO: What is our plant going to be?
SET IDENTITY_INSERT dbo.Plant ON;
INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (8888, 'Oilsands Labs Temp', 12)
SET IDENTITY_INSERT dbo.Plant OFF;

GO


--- site configuration

INSERT INTO dbo.[Shift] (Name, CreatedDateTime, SiteId, StartTime, EndTime)
VALUES (
  'D',  -- Name
  getdate(),  -- CreatedDateTime
  12, -- siteid
  '2011-01-01 08:00',  -- StartTime
  '2011-01-01 20:00'  -- EndTime  
)

INSERT INTO dbo.[Shift] (Name, CreatedDateTime, SiteId, StartTime, EndTime)
VALUES (
  'N',  -- Name
  getdate(),  -- CreatedDateTime
  12, -- siteid
  '2011-01-01 20:00',  -- StartTime
  '2011-01-01 08:00'  -- EndTime  
)

GO

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

GO

insert into TargetDefinitionAutoReApprovalConfiguration
values (12, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

GO
-- ------------------------------------------------------------------------------

--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;
GO


-- start of flocs

INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Wood Buffalo Laboratories', 'WBL', 0, 0, 1, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Oil Sands Laboratory', 'WBL-OSL', 0, 0, 2, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Analyzer', 'WBL-OSL-Analyzer', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANTON PARR CKT100 THERMOMETER', 'WBL-OSL-Analyzer-20004758', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER TESTER ANILINE POINT AAP-5', 'WBL-OSL-Analyzer-20004760', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATOR ISOTEMP D28671', 'WBL-OSL-Analyzer-20004761', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTOMETER MOD401 E-41L2025', 'WBL-OSL-Analyzer-20004762', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ISOTEMP FRIDGE P22364', 'WBL-OSL-Analyzer-20004763', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTOMETER HACH DR2800 D28178', 'WBL-OSL-Analyzer-20004764', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FRIDGE ISOTEMP 02042', 'WBL-OSL-Analyzer-20004765', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FRIDGE D28177', 'WBL-OSL-Analyzer-20004766', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETER GENESIS II E-41L59612', 'WBL-OSL-Analyzer-20004767', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ISOTEMP 725F E-41L53476', 'WBL-OSL-Analyzer-20004768', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ANTEK 9000 E-41L01420', 'WBL-OSL-Analyzer-20004770', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'WATERBATH IS0TEMP 210 D28666', 'WBL-OSL-Analyzer-20004771', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER CLOUD POINT PCA-70 E-41L53467', 'WBL-OSL-Analyzer-20004774', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER GAS E-41L014198', 'WBL-OSL-Analyzer-20004775', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER CLOUD POINT E-41L22315', 'WBL-OSL-Analyzer-20004776', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DETERMINATOR SULPHUR E-41L5040 L', 'WBL-OSL-Analyzer-20004777', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP AIR SAMPLING  D28664 DRAGER', 'WBL-OSL-Analyzer-20004780', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER  ANTON SID28185', 'WBL-OSL-Analyzer-20004781', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATOR DL 18 GP E-41L53416', 'WBL-OSL-Analyzer-20004782', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, null, 'WBL-OSL-Analyzer-20004783', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER CTC ANALYTICS E-41L56253', 'WBL-OSL-Analyzer-20004784', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANTEK 9000 MULTI MATRIX BOX L014206', 'WBL-OSL-Analyzer-20006681', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANTEK 9000 SAMPLE BOAT DRIVE L014205', 'WBL-OSL-Analyzer-20006682', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANTEK 9000 738 AUTOSAMPLER  L014204', 'WBL-OSL-Analyzer-20006683', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER SULFUR IN OIL HORIBA 41P22383', 'WBL-OSL-Analyzer-20006684', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER SULFUR IN OIL HORIBA 41L22305', 'WBL-OSL-Analyzer-20006685', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SULFUR HORIBA SINDIE ULSD ANALYZER', 'WBL-OSL-Analyzer-20006686', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETER ICP ATOMIC EMISSION', 'WBL-OSL-Analyzer-20006687', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER ICP-AES PERKIN-ELMER ASX-520', 'WBL-OSL-Analyzer-20006688', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER ICP  RECIRCLATOR E-41LP29898', 'WBL-OSL-Analyzer-20006689', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FLASHPOINT MANUAL CLEVLAND L2006', 'WBL-OSL-Analyzer-20006690', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER POUR POINT & CLOUD POINT', 'WBL-OSL-Analyzer-20006691', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ION ORION L2029', 'WBL-OSL-Analyzer-20006692', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ION ORION L53422', 'WBL-OSL-Analyzer-20006693', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL AND GREASE MACHINE HORIZON 41D28192', 'WBL-OSL-Analyzer-20006738', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL AND GREASE MACHINE HORIZON 41D28189', 'WBL-OSL-Analyzer-20006741', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER LAB', 'WBL-OSL-Analyzer-20094252', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER SULFUR/NITROGEN 41L00058', 'WBL-OSL-Analyzer-20107675', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER', 'WBL-OSL-Analyzer-20107676', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOMATED FLASH POINT ANALYZER #2', 'WBL-OSL-Analyzer-20120061', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TESTER MICRO CARBON RESIDUE E-41L00047', 'WBL-OSL-Analyzer-20120062', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TESTER REID VAPOR PRESSURE 41L00062', 'WBL-OSL-Analyzer-20120063', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL AND GREASE MACHINE HORIZON 41L00051', 'WBL-OSL-Analyzer-20120064', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER TESTER ANILINE POINT AAP-5', 'WBL-OSL-Analyzer-20120065', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER CLOUD POINT', 'WBL-OSL-Analyzer-20123022', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER CLOUD POINT', 'WBL-OSL-Analyzer-20123023', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL AND GREASE MACHINE HORIZON 41L00087', 'WBL-OSL-Analyzer-20123026', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS VACUUM PUMP FOR ANTEK', 'WBL-OSL-Analyzer-20140271', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATORS & CHILLERS XIII', 'WBL-OSL-Analyzer-20140987', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS & TESTERS VI', 'WBL-OSL-Analyzer-20140988', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS & TESTERS VI', 'WBL-OSL-Analyzer-20140989', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATORS & CHILLERS XIII', 'WBL-OSL-Analyzer-20140990', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOMATED FLASH POINT ANALYZER #3', 'WBL-OSL-Analyzer-20147566', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS SPEED VAP 3 EVAPORATOR', 'WBL-OSL-Analyzer-20147570', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS SPE-DEX 3000 CONTROLLER', 'WBL-OSL-Analyzer-20147571', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS SPE-DEX 3000 CONTROLLER', 'WBL-OSL-Analyzer-20147572', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS RVP TESTER', 'WBL-OSL-Analyzer-20147579', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZERS RVP TESTER', 'WBL-OSL-Analyzer-20147580', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VACUUM PUMP FOR ANTEK 9000', 'WBL-OSL-Analyzer-20156408', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VACUUM PUMP FOR ANTEK 9000', 'WBL-OSL-Analyzer-20156409', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SAMPLE DELIVERY AND CLEANING UNIT#3', 'WBL-OSL-Analyzer-20156410', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"ANALYSER, HORIBA XRF SULFER #3"', 'WBL-OSL-Analyzer-20204506', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'RONDOLINO AUTO SAMPLER', 'WBL-OSL-Analyzer-20204509', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Balance Analytical', 'WBL-OSL-Balance_Analytical', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER XS 104 LP22372', 'WBL-OSL-Balance_Analytical-20006694', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER AE100 L2112', 'WBL-OSL-Balance_Analytical-20006695', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER AE200 L2077', 'WBL-OSL-Balance_Analytical-20006696', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER XS104 D28151 ( AA-ICP)', 'WBL-OSL-Balance_Analytical-20006697', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER AE240 L55653', 'WBL-OSL-Balance_Analytical-20006698', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER AG104 LP22347', 'WBL-OSL-Balance_Analytical-20006699', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER P22390', 'WBL-OSL-Balance_Analytical-20006700', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER P22393', 'WBL-OSL-Balance_Analytical-20006701', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER AB 304S UPG', 'WBL-OSL-Balance_Analytical-20006702', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PC4400 L2075', 'WBL-OSL-Balance_Analytical-20006703', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PE160 L2073', 'WBL-OSL-Balance_Analytical-20006704', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PG 503S L53412', 'WBL-OSL-Balance_Analytical-20006705', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PG 603S P22371', 'WBL-OSL-Balance_Analytical-20006706', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PG 8001S P22337', 'WBL-OSL-Balance_Analytical-20006707', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PG403S P22373', 'WBL-OSL-Balance_Analytical-20006708', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PG603S P22374', 'WBL-OSL-Balance_Analytical-20006709', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PJ L59395', 'WBL-OSL-Balance_Analytical-20006710', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER 2070', 'WBL-OSL-Balance_Analytical-20006711', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER XS 204(QA)', 'WBL-OSL-Balance_Analytical-20006712', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER PJ4000 L2081', 'WBL-OSL-Balance_Analytical-20006713', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP VACUUM D28667', 'WBL-OSL-Balance_Analytical-20006714', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER  D28668', 'WBL-OSL-Balance_Analytical-20006716', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER B3000-1S L014182', 'WBL-OSL-Balance_Analytical-20006717', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER', 'WBL-OSL-Balance_Analytical-20030019', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER', 'WBL-OSL-Balance_Analytical-20030020', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE WEIGHING', 'WBL-OSL-Balance_Analytical-20033833', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE WEIGHING', 'WBL-OSL-Balance_Analytical-20033834', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER 41L00045', 'WBL-OSL-Balance_Analytical-20103428', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE ANALYTICAL', 'WBL-OSL-Balance_Analytical-20123025', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCES ANALYTICAL', 'WBL-OSL-Balance_Analytical-20140282', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCES ANALYTICAL', 'WBL-OSL-Balance_Analytical-20140283', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCES ANALYTICAL', 'WBL-OSL-Balance_Analytical-20140285', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCES ANALYTICAL', 'WBL-OSL-Balance_Analytical-20147575', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCES ANALYTICAL', 'WBL-OSL-Balance_Analytical-20147576', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Centrifuge', 'WBL-OSL-Centrifuge', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE DAEMON IEC L2018', 'WBL-OSL-Centrifuge-20006718', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE EPPENDORF 5804 L59305', 'WBL-OSL-Centrifuge-20006720', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE EPPENDORF 5804 L59791', 'WBL-OSL-Centrifuge-20006721', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE IEC HN-SII 41L14167', 'WBL-OSL-Centrifuge-20006722', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE IEC HN-SII L56251', 'WBL-OSL-Centrifuge-20006724', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE THERMO ELECTRON C3i 41P27786', 'WBL-OSL-Centrifuge-20006725', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE  L-K INDUSTRIES L014187', 'WBL-OSL-Centrifuge-20006726', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE  L-K INDUSTRIES 41P22352', 'WBL-OSL-Centrifuge-20006727', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE THERMO ELECTRON C3i 41D28183', 'WBL-OSL-Centrifuge-20006764', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE THERMO ELECTRON C3i 41D28183', 'WBL-OSL-Centrifuge-20010487', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE THERMO ELECTRON C3i 41D28181', 'WBL-OSL-Centrifuge-20010497', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"CENTRIFUGE, SORVAL LEGEND BENCHTOP"', 'WBL-OSL-Centrifuge-20204507', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Conductivity Meter', 'WBL-OSL-Conductivity_Meter', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METER DIESEL CONDUCTIVITY E-41L5055', 'WBL-OSL-Conductivity_Meter-20004794', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METER DIESEL CONDUCTIVITY E-41L53476', 'WBL-OSL-Conductivity_Meter-20004795', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CONDUCTIVITY H2O HORIBA L53431', 'WBL-OSL-Conductivity_Meter-20006728', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CONDUCTIVITY METER - EMCEE LP22349', 'WBL-OSL-Conductivity_Meter-20006730', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MONITOR GAS', 'WBL-OSL-Conductivity_Meter-20006731', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DETECTOR LEAK  - VARIAN LP22355', 'WBL-OSL-Conductivity_Meter-20006733', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METERS CONDUCTIVITY - DIESEL', 'WBL-OSL-Conductivity_Meter-20140286', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METERS CONDUCTIVITY - DIESEL', 'WBL-OSL-Conductivity_Meter-20140288', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Densitometer', 'WBL-OSL-Densitometer', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SOLVENT TRAP D28191 HORIZON', 'WBL-OSL-Densitometer-20006734', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY ANTON PARR DMA 4500 L022306', 'WBL-OSL-Densitometer-20006735', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY DMA 48 METER L2212', 'WBL-OSL-Densitometer-20006737', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, null, 'WBL-OSL-Densitometer-20006739', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY METER DE-40 41D28185', 'WBL-OSL-Densitometer-20010479', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY METER DE-40 41D28171', 'WBL-OSL-Densitometer-20010496', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY METER DE-40 41L00066', 'WBL-OSL-Densitometer-20120060', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Distillation Unit', 'WBL-OSL-Distillation_Unit', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTO DISTILLATION UNIT # 4 E-41L56667', 'WBL-OSL-Distillation_Unit-20004796', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTO DISTILLATION UNIT # 3 E-41L59536', 'WBL-OSL-Distillation_Unit-20004797', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTO DISTILLATION UNIT  # 2 E-41L59635', 'WBL-OSL-Distillation_Unit-20004798', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTO DISTILLATION UNIT # 1 E-41L53408', 'WBL-OSL-Distillation_Unit-20004799', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'D86 HERZOG DISTILLATION UNIT 4 LP22392', 'WBL-OSL-Distillation_Unit-20006740', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ATMOSPHERIC DISTILLATION D86', 'WBL-OSL-Distillation_Unit-20094503', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER ATMOSPHERIC DISTILLATION D86', 'WBL-OSL-Distillation_Unit-20120059', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DISTILLATION D86 OPTI', 'WBL-OSL-Distillation_Unit-20140273', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DISTILLATION D86 OPTI', 'WBL-OSL-Distillation_Unit-20140274', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Gas Chromatograph', 'WBL-OSL-Gas_Chromatograph', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP AIR SAMPLING D28665 DRAGER', 'WBL-OSL-Gas_Chromatograph-20004786', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS VARIAN E-41L59387', 'WBL-OSL-Gas_Chromatograph-20004787', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS VARIAN SID28196', 'WBL-OSL-Gas_Chromatograph-20004789', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METROHM ION CHROMATOGRAPH  #2', 'WBL-OSL-Gas_Chromatograph-20006715', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS VARIAN E-41L55749', 'WBL-OSL-Gas_Chromatograph-20006742', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL GREASE MACHINE SPE-DEX 3000 D28193', 'WBL-OSL-Gas_Chromatograph-20006743', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER 8200CX GC 3800 L53444', 'WBL-OSL-Gas_Chromatograph-20006745', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS AGILENT LP22350', 'WBL-OSL-Gas_Chromatograph-20006746', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS AGILENT L014194', 'WBL-OSL-Gas_Chromatograph-20006748', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS VARIAN E-41L14198', 'WBL-OSL-Gas_Chromatograph-20006750', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHROMATOGRAPH GAS AGILENT D28135', 'WBL-OSL-Gas_Chromatograph-20006751', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LAB ION CHOMATOGRAPH', 'WBL-OSL-Gas_Chromatograph-20006752', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER IC - METROHM P29907', 'WBL-OSL-Gas_Chromatograph-20006753', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'J & W SCIENTIFIC ADM 1000 L22324', 'WBL-OSL-Gas_Chromatograph-20006756', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SAMPLER INJECTOR AUTO LIQUID AGILENT', 'WBL-OSL-Gas_Chromatograph-20062856', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER GAS CHROMATOGRAPHS REFINERY #3', 'WBL-OSL-Gas_Chromatograph-20147565', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METROHM ION CHROMATOGRAPH', 'WBL-OSL-Gas_Chromatograph-20158454', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'RGW DI-2- 20 DEIONIZER L014234', 'WBL-OSL-Gas_Chromatograph-20006854', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'RGW ELGA L53406', 'WBL-OSL-Gas_Chromatograph-20006855', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HOOD DUCTLESS  D28180', 'WBL-OSL-Gas_Chromatograph-20006856', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41P22391', 'WBL-OSL-Gas_Chromatograph-20006857', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DIGIPREP CUBE REACTOR P22362', 'WBL-OSL-Gas_Chromatograph-20006858', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER BATH DRY/RECIRCULATING 41P22370', 'WBL-OSL-Gas_Chromatograph-20006859', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BATH NESLAB EX-111 L14163', 'WBL-OSL-Gas_Chromatograph-20006860', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FRIDGE ISOTEMP 53455', 'WBL-OSL-Gas_Chromatograph-20006861', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER FST SYSTEM MAXICOOL L53445', 'WBL-OSL-Gas_Chromatograph-20006862', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FRIDGE ISOTEMP D28158', 'WBL-OSL-Gas_Chromatograph-20006863', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41L22317', 'WBL-OSL-Gas_Chromatograph-20006864', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41L22318', 'WBL-OSL-Gas_Chromatograph-20006865', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41L22319', 'WBL-OSL-Gas_Chromatograph-20006866', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PH METER FISCHER SCIENTIFIC E-41L53471', 'WBL-OSL-Gas_Chromatograph-20010467', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO COD READER HACH E-41L53473', 'WBL-OSL-Gas_Chromatograph-20010468', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO COD READER HACH  E41L50116', 'WBL-OSL-Gas_Chromatograph-20010469', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER METTLER TOLEDO FISHER THERMIX', 'WBL-OSL-Gas_Chromatograph-20010470', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE METTLER TOLEDO E-41L28165', 'WBL-OSL-Gas_Chromatograph-20010471', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PH CONDUCTIVITY METER E-41L22356', 'WBL-OSL-Gas_Chromatograph-20010472', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER E-41L28148', 'WBL-OSL-Gas_Chromatograph-20010473', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, null, 'WBL-OSL-Gas_Chromatograph-20010474', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LAB SINDIE-7039 SID28176', 'WBL-OSL-Gas_Chromatograph-20010475', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVEN 175 FISCHER SCIENTIFIC  E-41L2036', 'WBL-OSL-Gas_Chromatograph-20010481', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DISTILLATION HERZOG HDA627 E-41L22392', 'WBL-OSL-Gas_Chromatograph-20010482', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BALANCE HS204 METTLER TOLEDO E-41L28152', 'WBL-OSL-Gas_Chromatograph-20010483', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'E-41L2067 METTLER TOLEDO PJ360', 'WBL-OSL-Gas_Chromatograph-20010484', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ISOTEMP FISCHER 200 SERIES E-41L2032', 'WBL-OSL-Gas_Chromatograph-20010485', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ISOTEMP FISCHER  200 SERIES E-41L2037', 'WBL-OSL-Gas_Chromatograph-20010486', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LIQUID SULPHUR CELL D28657', 'WBL-OSL-Gas_Chromatograph-20010488', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SLFA UN21 HORIBA SULFER ANALYSER', 'WBL-OSL-Gas_Chromatograph-20010489', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATOR E-41L59957  DL77 METTLER ST20A', 'WBL-OSL-Gas_Chromatograph-20010490', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATOR UNIT E-41L59958 METTLER DL77', 'WBL-OSL-Gas_Chromatograph-20010491', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PHASE TECHNOLOGY CLOUDPOINT E-41L28145', 'WBL-OSL-Gas_Chromatograph-20010494', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTRUM 100 PERKIN ELMER E-41L28159', 'WBL-OSL-Gas_Chromatograph-20010495', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ULTRA IONIC PURE LAB ELGA WATER D28655', 'WBL-OSL-Gas_Chromatograph-20010498', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'THERMOLYNE 48000 E-41L22313', 'WBL-OSL-Gas_Chromatograph-20010499', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ISOTEMP 630F FISHER SCIENTIFIC E-41L2038', 'WBL-OSL-Gas_Chromatograph-20010500', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41D28195', 'WBL-OSL-Gas_Chromatograph-20010501', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PRINTER EPSON E-41L27780', 'WBL-OSL-Gas_Chromatograph-20010504', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PRINTER EPSON E-41L15419', 'WBL-OSL-Gas_Chromatograph-20010505', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER 80300 GC E-41L28141', 'WBL-OSL-Gas_Chromatograph-20010506', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'COOLER LAWLER  E-41L29897', 'WBL-OSL-Gas_Chromatograph-20010507', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'COOLER LAWLER E-41L53474', 'WBL-OSL-Gas_Chromatograph-20010508', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BATH THELCO E-41L14178', 'WBL-OSL-Gas_Chromatograph-20010510', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'JULABO SCIENTIFIC PARKER', 'WBL-OSL-Gas_Chromatograph-20010511', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FRIDGE E-4114217', 'WBL-OSL-Gas_Chromatograph-20010512', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MULTIMIXER E-41L2049 MISTRAL', 'WBL-OSL-Gas_Chromatograph-20010513', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"TITRATOR UNIT 1, KARL FISHER"', 'WBL-OSL-Gas_Chromatograph-20010514', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TEMP BATH SID22359 BOEKEL GRANT', 'WBL-OSL-Gas_Chromatograph-20010515', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FILTERING CABINET', 'WBL-OSL-Gas_Chromatograph-20030021', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP VACUUM', 'WBL-OSL-Gas_Chromatograph-20032989', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER', 'WBL-OSL-Gas_Chromatograph-20061812', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'ANALYZER FLASH POINT', 'WBL-OSL-Gas_Chromatograph-20061813', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER ID 28140', 'WBL-OSL-Gas_Chromatograph-20062858', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER ID 14170', 'WBL-OSL-Gas_Chromatograph-20062859', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER MICATHERIC', 'WBL-OSL-Gas_Chromatograph-20065095', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER MICATHERIC', 'WBL-OSL-Gas_Chromatograph-20065096', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'COOLER WATER CIRCULATION', 'WBL-OSL-Gas_Chromatograph-20065097', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DIGITAL STIRRER/HOTPLATE', 'WBL-OSL-Gas_Chromatograph-20081382', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DIGITAL STIRRER/HOTPLATE', 'WBL-OSL-Gas_Chromatograph-20081383', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DIGITAL STIRRER/HOTPLATE', 'WBL-OSL-Gas_Chromatograph-20081384', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER/HOT PLATE', 'WBL-OSL-Gas_Chromatograph-20106980', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER/HOT PLATE', 'WBL-OSL-Gas_Chromatograph-20106981', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER/HOT PLATE', 'WBL-OSL-Gas_Chromatograph-20106982', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRER/HOT PLATE', 'WBL-OSL-Gas_Chromatograph-20106983', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER', 'WBL-OSL-Gas_Chromatograph-20106984', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITY METER', 'WBL-OSL-Gas_Chromatograph-20106985', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SAMPLE DELIVERY/CLEANING UNIT', 'WBL-OSL-Gas_Chromatograph-20106987', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"TITRATOR UNIT 2, KARL FISHER"', 'WBL-OSL-Gas_Chromatograph-20106988', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DURA LABEL PRE 300', 'WBL-OSL-Gas_Chromatograph-20106989', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AUTOSAMPLER', 'WBL-OSL-Gas_Chromatograph-20106991', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP VACUUM', 'WBL-OSL-Gas_Chromatograph-20107672', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP VACUUM', 'WBL-OSL-Gas_Chromatograph-20107673', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'METER AIR VELOCITY', 'WBL-OSL-Gas_Chromatograph-20107674', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CHILLER DRY/RECIRCULATING 41L00022', 'WBL-OSL-Gas_Chromatograph-20120066', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SHAKER PAINT', 'WBL-OSL-Gas_Chromatograph-20123017', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SHAKER PAINT', 'WBL-OSL-Gas_Chromatograph-20123018', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SHAKER PAINT', 'WBL-OSL-Gas_Chromatograph-20123019', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SHAKER PAINT', 'WBL-OSL-Gas_Chromatograph-20123020', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SHAKER PAINT', 'WBL-OSL-Gas_Chromatograph-20123021', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATORS AND CHILLERS XIII', 'WBL-OSL-Gas_Chromatograph-20137873', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATORS & BURETTE DRIVES X', 'WBL-OSL-Gas_Chromatograph-20137901', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATORS & BURETTE DRIVES X', 'WBL-OSL-Gas_Chromatograph-20137902', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATORS & BURETTE DRIVES X', 'WBL-OSL-Gas_Chromatograph-20137903', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS  FURNACES & HEATERS/CIRCULATORS XV', 'WBL-OSL-Gas_Chromatograph-20137904', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DENSITOMETERS SAMPLE DELIVERY-CLEANING', 'WBL-OSL-Gas_Chromatograph-20140275', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRERS FISHER', 'WBL-OSL-Gas_Chromatograph-20140290', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRERS FINEMECH', 'WBL-OSL-Gas_Chromatograph-20140291', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FURNACES ASHING', 'WBL-OSL-Gas_Chromatograph-20140294', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS DISPATCH SAFETY', 'WBL-OSL-Gas_Chromatograph-20140295', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS CONST TEMP VISC BATH', 'WBL-OSL-Gas_Chromatograph-20140297', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS WATER BATH', 'WBL-OSL-Gas_Chromatograph-20140298', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'WASHERS BOTTLE', 'WBL-OSL-Gas_Chromatograph-20140300', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LAB ENVIRONMENTAL BAROMETER', 'WBL-OSL-Gas_Chromatograph-20140301', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CONTROL SYSTEM GAS DETECTOR', 'WBL-OSL-Gas_Chromatograph-20140302', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'BOTTLE WASHER MACHINE LAB  NAMCO', 'WBL-OSL-Gas_Chromatograph-20140473', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS  FURNACES & HEATERS XVI', 'WBL-OSL-Gas_Chromatograph-20140985', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REACTORS XI', 'WBL-OSL-Gas_Chromatograph-20140986', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MIXERS  STIRRERS  SHAKERS XIV', 'WBL-OSL-Gas_Chromatograph-20140991', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TITRATORS KARL FISHER UNIT', 'WBL-OSL-Gas_Chromatograph-20147573', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REACTORS DIGITAL REACTOR BLOCK', 'WBL-OSL-Gas_Chromatograph-20147574', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRERS FINEMECH', 'WBL-OSL-Gas_Chromatograph-20147577', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VENTED STORAGE CABINET', 'WBL-OSL-Gas_Chromatograph-20147578', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATORS MINI FRIDGE', 'WBL-OSL-Gas_Chromatograph-20147581', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REACTORS COD REACTOR', 'WBL-OSL-Gas_Chromatograph-20147582', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OVENS ISOTEMP WATER BATH', 'WBL-OSL-Gas_Chromatograph-20147583', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MILLI-Q INTEGRAL 15 PURE WATER PURIFICAT', 'WBL-OSL-Gas_Chromatograph-20156406', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DIGITAL VACUUM REGULATOR', 'WBL-OSL-Gas_Chromatograph-20156407', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DETECTOR DIGITAL 305D NO. 1', 'WBL-OSL-Gas_Chromatograph-20167595', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DETECTOR DIGITAL 305D NO. 2', 'WBL-OSL-Gas_Chromatograph-20167596', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP MICRO 302D NO. 1', 'WBL-OSL-Gas_Chromatograph-20167597', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP MICRO 302D NO. 2', 'WBL-OSL-Gas_Chromatograph-20167598', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DILUTORS 312 NO. 1', 'WBL-OSL-Gas_Chromatograph-20167599', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DILUTORS 312 NO. 2', 'WBL-OSL-Gas_Chromatograph-20167600', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DISTILLATION BATH NO. 2', 'WBL-OSL-Gas_Chromatograph-20167601', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'DISTILLATION BATH NO. 1', 'WBL-OSL-Gas_Chromatograph-20167602', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'RECEIVER GAS SCOTT 7800 SENTINEL 16 CH', 'WBL-OSL-Gas_Chromatograph-20167603', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"SAMPLER 311, XYZ DILUTOR NO. 1"', 'WBL-OSL-Gas_Chromatograph-20167604', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"SAMPLER 311, XYZ DILUTOR NO. 2"', 'WBL-OSL-Gas_Chromatograph-20167606', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'PUMP AUXILIARY NO. 1', 'WBL-OSL-Gas_Chromatograph-20167607', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER CENTRIFUGE TUBES', 'WBL-OSL-Gas_Chromatograph-20167608', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER CENTRIFUGE TUBES', 'WBL-OSL-Gas_Chromatograph-20167609', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'REFRIGERATED CIRCULATOR JULABO', 'WBL-OSL-Gas_Chromatograph-20167610', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CARTRIDGE MODULE 303A-2 NO. 1', 'WBL-OSL-Gas_Chromatograph-20167611', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CARTRIDGE MODULE 303A-2 NO. 2', 'WBL-OSL-Gas_Chromatograph-20167612', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER SYSTEM CRITERION WATER BATH', 'WBL-OSL-Gas_Chromatograph-20167613', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'TESTER MICRO CARBON RESIDUE (MCRT-160)', 'WBL-OSL-Gas_Chromatograph-20167615', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CENTRIFUGE HEATED L-K INDUSTRIES', 'WBL-OSL-Gas_Chromatograph-20167616', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER #1 L-K OIL SAMPLE HTR LAB MAIN OF', 'WBL-OSL-Gas_Chromatograph-20174622', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HEATER #2 L-K OIL SAMPLE HTR LAB MAIN OF', 'WBL-OSL-Gas_Chromatograph-20174623', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'NSX-2100V VF-210 VERTICAL FURNACE #1', 'WBL-OSL-Gas_Chromatograph-20177820', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"PUMP, VACUUM FOR NSX-2100V N2 ANALYSER"', 'WBL-OSL-Gas_Chromatograph-20177821', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"DETECTOR, SULPHER"', 'WBL-OSL-Gas_Chromatograph-20177822', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"DETECTOR, NITROGEN"', 'WBL-OSL-Gas_Chromatograph-20177823', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"SAMPLER, LIQUID AUTOMATIC"', 'WBL-OSL-Gas_Chromatograph-20177824', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"SCRUBBER, UNIT 1"', 'WBL-OSL-Gas_Chromatograph-20182825', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"SCRUBBER, UNIT 2"', 'WBL-OSL-Gas_Chromatograph-20182826', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"ANALYZER, OIL IN WATER"', 'WBL-OSL-Gas_Chromatograph-20182827', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"DIGESTER, UNIT 1"', 'WBL-OSL-Gas_Chromatograph-20182828', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LIFT UNIT 1', 'WBL-OSL-Gas_Chromatograph-20182829', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"DIGESTER, UNIT 2"', 'WBL-OSL-Gas_Chromatograph-20182830', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LIFT UNIT 2', 'WBL-OSL-Gas_Chromatograph-20182831', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AGILENT GC 7890 SIMDIST ANALYZER', 'WBL-OSL-Gas_Chromatograph-20186643', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'AGILENT GC 7890A REF GAS ANALYZER', 'WBL-OSL-Gas_Chromatograph-20186644', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, '"METER PH,METTER TOLEDO SEVEN EXCELLENCE"', 'WBL-OSL-Gas_Chromatograph-20204508', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Monitor', 'WBL-OSL-Monitor', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRING HOT PLATES FISHER  D28663', 'WBL-OSL-Monitor-20004790', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LEVEL METRICS LM2000 CONTROLLER L014180', 'WBL-OSL-Monitor-20006757', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LEVEL METRICS LMS-040 SENSOR L014181', 'WBL-OSL-Monitor-20006758', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MINIDENS DENSITOMETER L14201', 'WBL-OSL-Monitor-20006759', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MINIDENS UNIT #2 L059858', 'WBL-OSL-Monitor-20006760', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MINIRAE 2000 RAE SYSTEMS P29908', 'WBL-OSL-Monitor-20006761', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Oven Scale', 'WBL-OSL-Oven_Scale', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STIRRING HOT PLATES FISHER  D28659', 'WBL-OSL-Oven_Scale-20004791', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SCALE BALANCE E-41L14164', 'WBL-OSL-Oven_Scale-20004792', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MACHINE X-RAY METOREX E-41L59535', 'WBL-OSL-Oven_Scale-20004793', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Lab Spectrophotometer', 'WBL-OSL-Spectrophotometer', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'COLORIMETER ASTM D1500 L59641', 'WBL-OSL-Spectrophotometer-20006762', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPEC 21 UPDATE INSTRUMENT L053487', 'WBL-OSL-Spectrophotometer-20006763', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPEC BAUCH & LOMB 21 UPGRADE L2002', 'WBL-OSL-Spectrophotometer-20006765', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPEC BAUCH & LOMB 21 UPGRADE L5033', 'WBL-OSL-Spectrophotometer-20006766', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPEC BIOCHROM LIBRA S21 L022320', 'WBL-OSL-Spectrophotometer-20006767', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPEC BIOCHROM LIBRA S21 L022321', 'WBL-OSL-Spectrophotometer-20006768', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'HOT PLATE CIMAREC 28670 FISHER', 'WBL-OSL-Spectrophotometer-20006769', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'OIL GREASE MACHINE SPE-DEX 3000 D28194', 'WBL-OSL-Spectrophotometer-20006770', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO METER DR2800 D28179', 'WBL-OSL-Spectrophotometer-20006771', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO L2024', 'WBL-OSL-Spectrophotometer-20006772', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO L53403', 'WBL-OSL-Spectrophotometer-20006773', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTO L2025', 'WBL-OSL-Spectrophotometer-20006774', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STAR800 MIB W/SERIAL-2ADC CHANNEL', 'WBL-OSL-Spectrophotometer-20006775', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'STAR800MIBW/SERIAL-4ADC CHANNEL', 'WBL-OSL-Spectrophotometer-20006776', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'FTIR 1600 PE L2113', 'WBL-OSL-Spectrophotometer-20006777', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'EVAPORATOR D28190', 'WBL-OSL-Spectrophotometer-20006779', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SULPHUR CELL AND CONTROL L22328', 'WBL-OSL-Spectrophotometer-20006780', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'LIQUID SULFUR CELL FOR FTIR LP22363', 'WBL-OSL-Spectrophotometer-20006781', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CONDUCTITIVITY H2O HORIBA L59398', 'WBL-OSL-Spectrophotometer-20006782', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'CONDUCTIVITY DIESEL 1152 L53479', 'WBL-OSL-Spectrophotometer-20006783', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROPHOTOMETER LAB', 'WBL-OSL-Spectrophotometer-20094504', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETERS SPECTRUM 100 FT-IR', 'WBL-OSL-Spectrophotometer-20140272', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETERS ICP-ATOMIC EMISSION', 'WBL-OSL-Spectrophotometer-20147567', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETERS ICP-AES AUTOSAMPLER', 'WBL-OSL-Spectrophotometer-20147568', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'SPECTROMETERS ICP-AES CHILLER', 'WBL-OSL-Spectrophotometer-20147569', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Viscometers', 'WBL-OSL-Viscometers', 0, 0, 3, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VISCOMETERS ROTATIONAL BROOKFIELD', 'WBL-OSL-Viscometers-20140277', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VISCOMETERS THERMOSEL ACCESS BROOKFIELD', 'WBL-OSL-Viscometers-20140279', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'VISCOMETERS TEMP CONTROLLER BROOKFIELD', 'WBL-OSL-Viscometers-20140280', 0, 0, 4, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'Firebag Laboratory', 'WBL-FBL', 0, 0, 2, 8888, 'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (12, 'MacKay River Laboratory', 'WBL-MRL', 0, 0, 2, 8888, 'en');

-- end of flocs

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
GO

---------------------------------------------------------------------------------------------
DECLARE @SiteId bigint
SET @SiteId = 12
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
   

-- Insert the Ancestor records for these Flocs
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

-- insert ShiftHandoverConfiguration (Name,Deleted) values ('Operator Handover Questions', 0);
-- insert ShiftHandoverConfiguration (Name,Deleted) values ('Supervisor Handover Questions', 0);

GO

insert into [SiteConfiguration]
([SiteId],
[DaysToDisplayActionItems],[DaysToDisplayShiftLogs],[DaysBeforeArchivingClosedWorkPermits],[DaysBeforeDeletingPendingWorkPermits],[DaysBeforeClosingIssuedWorkPermits],
[AutoApproveWorkOrderActionItemDefinition],[AutoApproveSAPAMActionItemDefinition],[AutoApproveSAPMCActionItemDefinition],
[CreateOperatingEngineerLogs],[WorkPermitNotApplicableAutoSelected],[WorkPermitOptionAutoSelected],
[OperatingEngineerLogDisplayName],
[DaysToEditDeviationAlerts],[DaysToDisplayShiftHandovers],
[SummaryLogFunctionalLocationDisplayLevel],
[ShowActionItemsByWorkAssignmentOnPriorityPage],[DaysToDisplayDeviationAlerts],[AllowStandardLogAtSecondLevelFunctionalLocation],[DorCutoffTime],
[DaysToDisplayWorkPermitsBackwards],[DaysToDisplayLabAlerts],
[LabAlertRetryAttemptLimit],[RequireActionItemResponseLog],[ActionItemRequiresApprovalDefaultValue],
[HideDORCommentEntry],[DaysToDisplayCokerCards],[ActionItemRequiresResponseDefaultValue],[ShowActionItemsOnShiftHandover],
[UseNewPriorityPage],[ShowShiftHandoversByWorkAssignmentOnPriorityPage],[DaysToDisplayDirectivesOnPriorityPage],
[DaysToDisplayShiftHandoversOnPriorityPage],[DisplayActionItemWorkAssignmentOnPriorityPage],[DaysToDisplayPermitRequestsBackwards],
[DaysToDisplayPermitRequestsForwards],[DaysToDisplayWorkPermitsForwards],[DisplayActionItemCommentOnly],
[DefaultNumberOfCopiesForWorkPermits],[ShowFollowupOnLogForm],[AllowCreateALogForEachSelectedFlocOnLogForm],
[ShowAdditionalDetailsOnLogFormByDefault],[Culture],[ShowWorkPermitPrintingTabInPreferences],[ShowDefaulPermitTimesTabInPreferences],
[DaysToDisplayTargetAlertsOnPriorityPage],[LoginFlocSelectionLevel],[UseCreatedByColumnForLogs],
[ShowIsModifiedColumnForLogs],[ItemFlocSelectionLevel],[DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs],
[PreShiftPaddingInMinutes],[PostShiftPaddingInMinutes],
[DaysToDisplayFormsBackwards],[DaysToDisplayFormsForwards],
[DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders],[DaysToDisplayFormsBackwardsOnPriorityPage],
[FormsFlocSetTypeId],[DaysToDisplaySAPNotificationsBackwards],[ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab],
[AllowCombinedShiftHandoverAndLog],[ShowCreateShiftHandoverMessageFromNewLogClick],[DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage],
[DefaultTargetDefinitionRequiresResponseWhenAlertedValue],[CollectAnalyticsData],[DaysToDisplayDirectivesBackwards],
[DaysToDisplayDirectivesForwards],[UseLogBasedDirectives]) 
values (
12,
7,7,7,7,1,
'True','True','True',
'True','True','True',
'Chief Engineer Log',
7,7,
2,
'False',30,'True','1900-01-01 10:00:00',
1,30,
3,'True','False',
'True',14,'True','True',
'True','False',2,
3,'True',1,
7,1,'True',
1,'True','True',
'True','en','True','False',
0,7,'True',
'False',7,'True',
60,60,
3,null,
'True',3,
1,1,'False',
'False','False',null,
'False','True',3,
null,'False');

GO

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

insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1, GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Sampling','Smpl',0,0,-1,GETDATE(),GETDATE(),0,12
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Shutdown / Turnaround','TA',0,0,-1,GETDATE(),GETDATE(),0,12

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 12 and f.FullHierarchy = 'WBL' and bc.SiteId = 12 and bc.Deleted = 0
go

-- roles

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (185, 'Lab Technician', 0, 'LabTechnician', 12, 0, 0, 0, 1, 0, 'labtech');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (186, 'Lab Supervisor', 0, 'Supervisor', 12, 0, 0, 0, 1, 0, 'super');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (187, 'Lab System Analyst/Instrumentation Tech', 0, 'LabSystemAnalystInstTech', 12, 0, 0, 0, 1, 0, 'sysanalyst');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (188, 'Lab Manager', 0, 'LabManager', 12, 0, 0, 0, 1, 0, 'labmgr');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (189, 'Lab Unit Leader', 0, 'LabUnitLeader', 12, 0, 0, 0, 1, 0, 'ulead');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (190, 'Quality Team', 0, 'QualityTeam', 12, 0, 0, 0, 1, 0, 'qualteam');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (191, 'Read-only', 0, 'ReadUser', 12, 0, 1, 0, 1, 1, 'read');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (192, 'Administrator', 0, 'Administrator', 12, 1, 0, 0, 1, 0, 'admin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (193, 'Technical Administrator', 0, 'TechnicalAdmin', 12, 0, 0, 0, 1, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (194, 'LabSpecialist', 0, 'LabSpecialist', 12, 0, 0, 0, 1, 0, 'labspecial');

SET IDENTITY_INSERT [Role] OFF;

GO

update Role set WarnIfWorkAssignmentNotSelected = 1 where SiteId = 12 
go  
  
update Role set WarnIfWorkAssignmentNotSelected = 0 where SiteId = 12 and Name in ('Read-only', 'Administrator')  
go  

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Oilsands Lab Administrator', 'Oilsands Lab Administrator' , 12, 0, 192, 'Misc', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Extraction 1 Day Shift Lab Tech', 'Extraction 1 Day Shift Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Extraction 2 Day Shift Lab Tech', 'Extraction 2 Day Shift Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Upgrading 1 Lab Tech', 'Upgrading 1 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Upgrading 2 Lab Tech', 'Upgrading 2 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Upgrading 3 Lab Tech', 'Upgrading 3 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Upgrading 4 Lab Tech', 'Upgrading 4 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Waters 1 Lab Tech', 'Waters 1 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Waters 2 Lab Tech', 'Waters 2 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Projects Lab Tech', 'Projects Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('GC Lab Tech', 'GC Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('ICP Lab Tech', 'ICP Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('QA Lab Tech', 'QA Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Night Shift Extraction', 'Night Shift Extraction' , 12, 0, 185, 'Night Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Night Shift Upgrading 1/3', 'Night Shift Upgrading 1/3' , 12, 0, 185, 'Night Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Night Shift Upgrading 2/4', 'Night Shift Upgrading 2/4' , 12, 0, 185, 'Night Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Night Shift Projects', 'Night Shift Projects' , 12, 0, 185, 'Night Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Unit Leader', 'Unit Leader' , 12, 0, 189, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Lab Specialist', 'Lab Specialist' , 12, 0, 187, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Lab Supervisor', 'Lab Supervisor' , 12, 0, 186, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Lab Manager', 'Lab Manager' , 12, 0, 188, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Lab System Analyst', 'Lab System Analyst' , 12, 0, 187, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('QA Staff', 'QA Staff' , 12, 0, 190, 'Day Shift', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Read Only', 'Read Only' , 12, 0, 191, 'Misc', 1, 0);
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('Instrumentation Technician', 'Instrumentation Technician' , 12, 0, 185, 'Day Shift', 1, 0);
GO

-- 
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Oilsands Lab Administrator' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Extraction 1 Day Shift Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Extraction 2 Day Shift Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Upgrading 1 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Upgrading 2 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Upgrading 3 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Upgrading 4 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Waters 1 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Waters 2 Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Projects Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'GC Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'ICP Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'QA Lab Tech' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Night Shift Extraction' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Night Shift Upgrading 1/3' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Night Shift Upgrading 2/4' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Night Shift Projects' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Unit Leader' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Lab Specialist' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Lab Supervisor' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Lab Manager' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Lab System Analyst' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'QA Staff' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Read Only' and a.SiteId = 12;
insert into WorkAssignmentFunctionalLocation(WorkAssignmentId,FunctionalLocationId) select a.id, f.id from functionallocation f, workassignment a where f.siteid = 12 and f.fullhierarchy = 'WBL' and a.name = 'Instrumentation Technician' and a.SiteId = 12;

GO

insert into VisibilityGroup (Name, SiteId, IsSiteDefault, Deleted) values ('Operations', 12, 1, 0);

INSERT INTO WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
SELECT vg.Id, wa.Id, 1 
from VisibilityGroup vg, WorkAssignment wa 
	where vg.SiteId = 12 and wa.SiteId = 12;
	
INSERT INTO WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
SELECT vg.Id, wa.Id, 2
from VisibilityGroup vg, WorkAssignment wa 
	where vg.SiteId = 12 and wa.SiteId = 12;

GO


-- Role Element Templates start --

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Manage Operational Modes';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Configure Automatic Re-Approval by Field';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Create Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Edit Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Delete Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Supervisor' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab System Analyst/Instrumentation Tech' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Manager' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Quality Team' and re.[Name] = 'View Summary Logs';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Technician' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Lab Unit Leader' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'LabSpecialist' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Read-only' and re.[Name] = 'View Directives - Future';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Display Limits';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Plant Historian Tag List';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Work Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Default FLOCs for Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Log Guidelines';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Shift Handover Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Summary Log Custom Fields';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure DOR Cutoff Time';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Log Templates';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Lab Alert';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Default Tabs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Work Assignment Not Selected Warning';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Unc Paths for Links';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Coker Cards';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Priorities Page';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Shift Handover E-mail Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Site Communications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Navigation - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Directives - Future';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Administrator' and re.[Name] = 'View Summary Logs';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'Perform Tech Admin Tasks';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Lab Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Restrictions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'View Navigation - Forms';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 12 and r.[Name] = 'Technical Administrator' and re.[Name] = 'Configure Site Communications';

-- Role Element Templates End --

insert into ShiftHandoverConfiguration (Name, Deleted) values ('Wood Buffalo Lab Tech', 0);

select 
wa.Id, 
wa.Name,
(select Id from ShiftHandoverConfiguration where Name = 'Wood Buffalo Lab Tech')
From WorkAssignment wa
inner join Role r on r.Id = wa.RoleId
where 
wa.SiteId = 12 and r.Name = 'Lab Technician';




GO

