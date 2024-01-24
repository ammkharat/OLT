-- Rename the Respiratory Cartridge Type Column
IF EXISTS(
	SELECT * FROM information_schema.columns 
	WHERE table_name = 'WorkPermit' 
	AND Column_name = 'RespitoryProtectionRequirementsRespiratoryCartridgeType')
BEGIN
EXEC sp_rename 'WorkPermit.RespitoryProtectionRequirementsRespiratoryCartridgeType', 'RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription', 'COLUMN'
EXEC sp_rename 'WorkPermitHistory.RespitoryProtectionRequirementsRespiratoryCartridgeType', 'RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription', 'COLUMN'
END
GO

IF EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'FireConfinedSpace300ABCorDryChemicalExtinguisher')
BEGIN

ALTER TABLE [dbo].[WorkPermit]
	DROP CONSTRAINT
		[DF_WorkPermit_FireConfinedSpace300ABCorDryChemicalExtinguisher],
		[DF_WorkPermit_FireConfinedSpace150ABCorDryChemicalExtinguisher],
		[DF_WorkPermit_FireConfinedSpace30ABCorDryChemicalExtinguisher],
		
		[DF_WorkPermit_SpecialProtectiveClothingTypePolyethyleneSuit],
		[DF_WorkPermit_SpecialProtectiveClothingTypeSlicker],
		[DF_WorkPermit_SpecialProtectiveClothingTypeNomex],
		[DF_WorkPermit_SpecialProtectiveClothingTypeChemicalResistantSuit],
		[DF_WorkPermit_SpecialHandProtectionCottonJersey],
		
		[DF_WorkPermit_ToolsGrinder],
		
		[DF_WorkPermit_RadiationSourceTypeSerialActivityNotApplicable],
		
		[DF_WorkPermit_RadiationMeasureNotApplicable],
		[DF_WorkPermit_RadiationMeasureSurveyInstrument],
		[DF_WorkPermit_RadiationMeasureDosimeter],
		
		[DF_WorkPermit_ExternalNotificationRequired]

ALTER TABLE [dbo].[WorkPermitHistory]
	DROP CONSTRAINT
		[DF_WorkPermitHistory_FireConfinedSpace300ABCorDryChemicalExtinguisher],
		[DF_WorkPermitHistory_FireConfinedSpace150ABCorDryChemicalExtinguisher],
		[DF_WorkPermitHistory_FireConfinedSpace30ABCorDryChemicalExtinguisher],
		
		[DF_WorkPermitHistory_SpecialProtectiveClothingTypePolyethyleneSuit],
		[DF_WorkPermitHistory_SpecialProtectiveClothingTypeSlicker],
		[DF_WorkPermitHistory_SpecialProtectiveClothingTypeNomex],
		[DF_WorkPermitHistory_SpecialProtectiveClothingTypeChemicalResistantSuit],
		[DF_WorkPermitHistory_SpecialHandProtectionCottonJersey],
		
		[DF_WorkPermitHistory_ToolsGrinder],
		
		[DF_WorkPermitHistory_RadiationSourceTypeSerialActivityNotApplicable],

		[DF_WorkPermitHistory_RadiationMeasureNotApplicable],
		[DF_WorkPermitHistory_RadiationMeasureSurveyInstrument],
		[DF_WorkPermitHistory_RadiationMeasureDosimeter],

		[DF_WorkPermitHistory_ExternalNotificationRequired]

ALTER TABLE [dbo].[WorkPermit] 
	DROP COLUMN
		[FireConfinedSpace300ABCorDryChemicalExtinguisher],
		[FireConfinedSpace150ABCorDryChemicalExtinguisher],
		[FireConfinedSpace30ABCorDryChemicalExtinguisher],
		[FireConfinedSpaceWatchmenType],
		[FireConfinedSpaceWatchmenNumber],
		
		[SpecialProtectiveClothingTypePolyethyleneSuit],
		[SpecialProtectiveClothingTypeSlicker],
		[SpecialProtectiveClothingTypeNomex],
		[SpecialProtectiveClothingTypeChemicalResistantSuit],
		[SpecialHandProtectionCottonJersey],
		
		[ToolsGrinder],
		[ToolsWelderDescription],		

		[RadiationSourceTypeSerialActivityNotApplicable],
		[RadiationSourceTypeSerialActivityDescription],
		
		[RadiationMeasureNotApplicable],
		[RadiationMeasureSurveyInstrument],
		[RadiationMeasureDosimeter],
	    [RadiationMeasureOtherDescription],
		
		[ExternalNotificationRequired],
		[ExternalNotificationDescription]	

ALTER TABLE [dbo].[WorkPermitHistory] 
	DROP COLUMN
		[FireConfinedSpace300ABCorDryChemicalExtinguisher],
		[FireConfinedSpace150ABCorDryChemicalExtinguisher],
		[FireConfinedSpace30ABCorDryChemicalExtinguisher],
		[FireConfinedSpaceWatchmenType],
		[FireConfinedSpaceWatchmenNumber],
		
		[SpecialProtectiveClothingTypePolyethyleneSuit],
		[SpecialProtectiveClothingTypeSlicker],
		[SpecialProtectiveClothingTypeNomex],
		[SpecialProtectiveClothingTypeChemicalResistantSuit],
		[SpecialHandProtectionCottonJersey],
		
		[ToolsGrinder],
		[ToolsWelderDescription],		
		
		[RadiationSourceTypeSerialActivityNotApplicable],
		[RadiationSourceTypeSerialActivityDescription], 
		
		[RadiationMeasureNotApplicable],
		[RadiationMeasureSurveyInstrument],
		[RadiationMeasureDosimeter],
		[RadiationMeasureOtherDescription],
		
		[ExternalNotificationRequired],
		[ExternalNotificationDescription]
END
GO


IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'FireConfinedSpaceHoleWatchNumber')
BEGIN

ALTER TABLE [dbo].[WorkPermit]
	ADD
		[FireConfinedSpaceHoleWatchNumber] [varchar](50) NULL,
		[FireConfinedSpaceFireWatchNumber] [varchar](50) NULL,
		[FireConfinedSpaceSpotterNumber] [varchar](50) NULL,

		[SpecialProtectiveClothingTypeTyvekSuit] [bit] NOT NULL CONSTRAINT DF_WorkPermit_SpecialProtectiveClothingTypeTyvekSuit DEFAULT (0),
		[SpecialProtectiveClothingTypeKapplerSuit] [bit] NOT NULL CONSTRAINT DF_WorkPermit_SpecialProtectiveClothingTypeKapplerSuit DEFAULT (0),
		[SpecialProtectiveClothingTypeElectricalFlashGear] [bit] NOT NULL CONSTRAINT DF_WorkPermit_SpecialProtectiveClothingTypeElectricalFlashGear DEFAULT (0),
		[SpecialProtectiveClothingTypeCorrosiveClothing] [bit] NOT NULL CONSTRAINT DF_WorkPermit_SpecialProtectiveClothingTypeCorrosiveClothing DEFAULT (0),		
		[SpecialHandProtectionChemicalGloves] [bit] NOT NULL CONSTRAINT DF_WorkPermit_SpecialHandProtectionChemicalGloves DEFAULT (0),
		
		[RespitoryProtectionRequirementsRespiratoryCartridgeTypeId] [bigint] NULL,
		
		[ToolsChemicals] [bit] NOT NULL CONSTRAINT DF_WorkPermit_ToolsChemicals DEFAULT (0),
		
		[JobSitePreparationAreaPreparationRadiationRope] [bit] NOT NULL CONSTRAINT DF_WorkPermit_JobSitePreparationAreaPreparationRadiationRope DEFAULT(0)

ALTER TABLE [dbo].[WorkPermitHistory]
	ADD
		[FireConfinedSpaceHoleWatchNumber] [varchar](50) NULL,
		[FireConfinedSpaceFireWatchNumber] [varchar](50) NULL,
		[FireConfinedSpaceSpotterNumber] [varchar](50) NULL,

		[SpecialProtectiveClothingTypeTyvekSuit] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_SpecialProtectiveClothingTypeTyvekSuit DEFAULT (0),
		[SpecialProtectiveClothingTypeKapplerSuit] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_SpecialProtectiveClothingTypeKapplerSuit DEFAULT (0),
		[SpecialProtectiveClothingTypeElectricalFlashGear] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_SpecialProtectiveClothingTypeElectricalFlashGear DEFAULT (0),
		[SpecialProtectiveClothingTypeCorrosiveClothing] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_SpecialProtectiveClothingTypeCorrosiveClothing DEFAULT (0),		
		[SpecialHandProtectionChemicalGloves] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_SpecialHandProtectionChemicalGloves DEFAULT (0),
		
		[RespitoryProtectionRequirementsRespiratoryCartridgeTypeId] [bigint] NULL,
		
		[ToolsChemicals] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_ToolsChemicals DEFAULT (0),	
		
		[JobSitePreparationAreaPreparationRadiationRope] [bit] NOT NULL CONSTRAINT DF_WorkPermitHistory_JobSitePreparationAreaPreparationRadiationRope DEFAULT(0)
END		
GO
