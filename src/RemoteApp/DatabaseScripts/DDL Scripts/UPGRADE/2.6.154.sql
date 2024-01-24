-----------------------
--- Add Asbestos Gaskets to Work Permit
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'EquipmentAsbestosGasketsNotApplicable')
BEGIN

ALTER TABLE [dbo].[WorkPermit]
	ADD 
		EquipmentAsbestosGasketsNotApplicable BIT NOT NULL DEFAULT (0),
		EquipmentAsbestosGaskets BIT NULL
		
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD
		EquipmentAsbestosGasketsNotApplicable BIT NOT NULL DEFAULT (0),
		EquipmentAsbestosGaskets BIT NULL
END

GO
