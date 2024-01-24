-----------------------
--- Add Equipment Isolation  Car-Ber to WorkPermit
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'EquipmentIsolationMethodCarBer')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD 
		EquipmentIsolationMethodCarBer [bit] NOT NULL DEFAULT (0)
		
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD
		EquipmentIsolationMethodCarBer [bit] NOT NULL DEFAULT (0)
END
GO
