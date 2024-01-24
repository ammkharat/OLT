-----------------------
--- Add Other Description to WorkPermit's Equipment Preparation & Condition
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'EquipmentConditionOtherDescription')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD EquipmentConditionOtherDescription VARCHAR(50) NULL;
END
GO
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermitHistory' AND Column_name = 'EquipmentConditionOtherDescription')
BEGIN
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD EquipmentConditionOtherDescription VARCHAR(50) NULL;
END
GO
