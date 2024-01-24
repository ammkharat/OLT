-----------------------
--- Add purge options to Work Permit
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'EquipmentConditionPurgedN2')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD 
		EquipmentConditionPurgedN2 BIT NOT NULL DEFAULT (0),
		EquipmentConditionPurgedSteamed BIT NOT NULL DEFAULT(0),
		EquipmentConditionPurgedAir BIT NOT NULL DEFAULT(0);
	
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD
		EquipmentConditionPurgedN2 BIT NOT NULL DEFAULT (0),
		EquipmentConditionPurgedSteamed BIT NOT NULL DEFAULT(0),
		EquipmentConditionPurgedAir BIT NOT NULL DEFAULT(0);
END
GO
