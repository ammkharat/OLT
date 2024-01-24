CREATE TABLE [dbo].[PermitRequestLubesSAPImportData](

	BatchId bigint NOT NULL,
	BatchItemCreatedDateTime datetime NOT NULL,
	SubmittedByUserId bigint NOT NULL,

	WorkPermitTypeId int,
	FunctionalLocationId bigint,

	WorkOrderNumber varchar(12),
	OperationNumber varchar(4),
	SubOperationNumber varchar(4),

	RequestedByGroupId bigint,
	Description varchar(500),
	RequestedStartDate datetime,
	RequestedStartTime datetime,
	RequestedEndDate datetime,

	Trade varchar(50),

	ConfinedSpace bit,
	HighEnergy bit, 
	CriticalLift bit, 
	Excavation bit, 
	EnergyControlPlan bit, 

	EquivalencyProc bit,  
	TestPneumatic bit,  
	LiveFlareWork bit,  
	EntryAndControlPlan bit,  

	HazardDesignatedSubstance bit,  
	HazardHydrocarbonGas bit,  
	HazardHydrocarbonLiquid bit,  
	HazardHydrogenSulphide bit,  
	HazardInertGasAtmosphere bit,  
	HazardOxygenDeficiency bit,  
	HazardRadioactiveSources bit,  
	HazardUndergroundOverheadHazards bit,  

	DesignateLocationOfHotOrColdCuts bit,
	FireWatch bit, 
	HydrantPermit bit 
) ON [PRIMARY]	
GO

ALTER TABLE [dbo].[PermitRequestLubesSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesSAPImportData_SubmittedByUserId] FOREIGN KEY([SubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesSAPImportData] CHECK CONSTRAINT [FK_PermitRequestLubesSAPImportData_SubmittedByUserId]
GO

ALTER TABLE [dbo].[PermitRequestLubesSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesSAPImportData_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesSAPImportData] CHECK CONSTRAINT [FK_PermitRequestLubesSAPImportData_FunctionalLocationId]
GO

ALTER TABLE [dbo].[PermitRequestLubesSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesSAPImportData_WorkPermitLubesGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesSAPImportData] CHECK CONSTRAINT [FK_PermitRequestLubesSAPImportData_WorkPermitLubesGroup]
GO





GO

