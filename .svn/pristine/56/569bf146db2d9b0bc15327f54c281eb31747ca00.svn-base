ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation]
DROP CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_FunctionalLocationId]
GO
ALTER TABLE [dbo].[ActionItemFunctionalLocation]
DROP CONSTRAINT [FK_ActionItemFunctionalLocation_FunctionalLocationId]
GO
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]
DROP CONSTRAINT [FK_BusinessCategoryFLOCAssociation_FunctionalLocation]
GO
ALTER TABLE [dbo].[CokerCard]
DROP CONSTRAINT [FK_CokerCard_FunctionalLocation]
GO
ALTER TABLE [dbo].[CokerCardConfiguration]
DROP CONSTRAINT [FK_CokerCardConfiguration_FunctionalLocation]
GO
ALTER TABLE [dbo].[ConfinedSpace]
DROP CONSTRAINT [ConfinedSpace_Floc]
GO
ALTER TABLE [dbo].[DeviationAlert]
DROP CONSTRAINT [FK_DeviationAlert_FunctionalLocation]
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
DROP CONSTRAINT [FK_DeviationAlert_ReasonCodeFunctionalLocation]
GO
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]
DROP CONSTRAINT [FK_DocumentRootPathFloc_Floc]
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation]
DROP CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation]
DROP CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]
DROP CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FormOP14FunctionalLocation]
DROP CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor]
DROP CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId]
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor]
DROP CONSTRAINT [FK_FunctionalLocationAncestor_Id]
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalMode]
DROP CONSTRAINT [FK_FunctionalLocationOpMode_FunctionalLocation]
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory]
DROP CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_FunctionalLocation]
GO
ALTER TABLE [dbo].[LabAlert]
DROP CONSTRAINT [FK_LabAlert_FunctionalLocation]
GO
ALTER TABLE [dbo].[LabAlertDefinition]
DROP CONSTRAINT [FK_LabAlertDefinition_FunctionalLocation]
GO
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]
DROP CONSTRAINT [FK_LogDefinitionFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[LogFunctionalLocation]
DROP CONSTRAINT [FK_LogFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[LogGuideline]
DROP CONSTRAINT [FK_LogGuideline_FunctionalLocation]
GO
ALTER TABLE [dbo].[PermitRequestEdmonton]
DROP CONSTRAINT [FK_PermitRequestEdmonton_FunctionalLocation]
GO
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData]
DROP CONSTRAINT [FK_PermitRequestEdmontonRawImportData_FunctionalLocation]
GO
ALTER TABLE [dbo].[PermitRequestLubes]
DROP CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation]
GO
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]
DROP CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[PermitRequestOssa]
DROP CONSTRAINT [FK_PermitRequestOssa_FunctionalLocation]
GO
ALTER TABLE [dbo].[RestrictionDefinition]
DROP CONSTRAINT [FK_RestrictionDefinition_FunctionalLocation]
GO
ALTER TABLE [dbo].[RestrictionReasonCodeFLOCAssociation]
DROP CONSTRAINT [FK_RestrictionReasonCodeFLOCAssociation_FunctionalLocation]
GO
ALTER TABLE [dbo].[SAPNotification]
DROP CONSTRAINT [FK_SAPNotification_FunctionalLocation]
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
DROP CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId]
GO
ALTER TABLE [dbo].[SummaryLogFunctionalLocation]
DROP CONSTRAINT [FK_SummaryLogFunctionalLocation_FuncationalLocation]
GO
ALTER TABLE [dbo].[TargetAlert]
DROP CONSTRAINT [FK_TargetAlert_FunctionalLocation]
GO
ALTER TABLE [dbo].[TargetAlertResponse]
DROP CONSTRAINT [FK_TargetAlertResponse_FunctionalLocation]
GO
ALTER TABLE [dbo].[TargetDefinition]
DROP CONSTRAINT [FK_TargetDefinition_FunctionalLocation]
GO
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]
DROP CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation]
DROP CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation]
DROP CONSTRAINT [FK_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermit]
DROP CONSTRAINT [FK_WorkPermit_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]
DROP CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermitEdmonton]
DROP CONSTRAINT [FK_WorkPermitEdmonton_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]
DROP CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]
DROP CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[WorkPermitOssa]
DROP CONSTRAINT [FK_WorkPermitOssa_Floc]
GO
ALTER TABLE [dbo].[FunctionalLocation]
DROP CONSTRAINT [FK_FunctionalLocation_Plant]
GO
ALTER TABLE [dbo].[FunctionalLocation]
DROP CONSTRAINT [FK_FunctionalLocation_Site]
GO


-- Make the FullHierarchy column non-nullable.
DROP INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] 
ON [dbo].[FunctionalLocation];
GO

DROP INDEX [IDX_FunctionalLocation_Id] 
ON [dbo].[FunctionalLocation];
GO

ALTER TABLE [FunctionalLocation] ALTER COLUMN [FullHierarchy] VARCHAR(90) NOT NULL

CREATE UNIQUE NONCLUSTERED INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([FullHierarchy] , [SiteId] , [Level])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation]
 ADD CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_FunctionalLocationId] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[ActionItemFunctionalLocation]
 ADD CONSTRAINT [FK_ActionItemFunctionalLocation_FunctionalLocationId] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]
 ADD CONSTRAINT [FK_BusinessCategoryFLOCAssociation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[CokerCard]
 ADD CONSTRAINT [FK_CokerCard_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[CokerCardConfiguration]
 ADD CONSTRAINT [FK_CokerCardConfiguration_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[ConfinedSpace]
 ADD CONSTRAINT [ConfinedSpace_Floc] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[DeviationAlert]
 ADD CONSTRAINT [FK_DeviationAlert_FunctionalLocation] FOREIGN KEY ([FunctionalLocationID])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
 ADD CONSTRAINT [FK_DeviationAlert_ReasonCodeFunctionalLocation] FOREIGN KEY ([ReasonCodeFunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]
 ADD CONSTRAINT [FK_DocumentRootPathFloc_Floc] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation]
 ADD CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation]
 ADD CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]
 ADD CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FormOP14FunctionalLocation]
 ADD CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor]
 ADD CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId] FOREIGN KEY ([AncestorId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor]
 ADD CONSTRAINT [FK_FunctionalLocationAncestor_Id] FOREIGN KEY ([Id])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalMode]
 ADD CONSTRAINT [FK_FunctionalLocationOpMode_FunctionalLocation] FOREIGN KEY ([UnitId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory]
 ADD CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_FunctionalLocation] FOREIGN KEY ([UnitId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[LabAlert]
 ADD CONSTRAINT [FK_LabAlert_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[LabAlertDefinition]
 ADD CONSTRAINT [FK_LabAlertDefinition_FunctionalLocation] FOREIGN KEY ([FunctionalLocationID])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]
 ADD CONSTRAINT [FK_LogDefinitionFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[LogFunctionalLocation]
 ADD CONSTRAINT [FK_LogFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[LogGuideline]
 ADD CONSTRAINT [FK_LogGuideline_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[PermitRequestEdmonton]
 ADD CONSTRAINT [FK_PermitRequestEdmonton_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData]
 ADD CONSTRAINT [FK_PermitRequestEdmontonRawImportData_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[PermitRequestLubes]
 ADD CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]
 ADD CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[PermitRequestOssa]
 ADD CONSTRAINT [FK_PermitRequestOssa_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionDefinition]
 ADD CONSTRAINT [FK_RestrictionDefinition_FunctionalLocation] FOREIGN KEY ([FunctionalLocationID])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionReasonCodeFLOCAssociation]
 ADD CONSTRAINT [FK_RestrictionReasonCodeFLOCAssociation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[SAPNotification]
 ADD CONSTRAINT [FK_SAPNotification_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
 ADD CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[SummaryLogFunctionalLocation]
 ADD CONSTRAINT [FK_SummaryLogFunctionalLocation_FuncationalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[TargetAlert]
 ADD CONSTRAINT [FK_TargetAlert_FunctionalLocation] FOREIGN KEY ([FunctionalLocationID])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[TargetAlertResponse]
 ADD CONSTRAINT [FK_TargetAlertResponse_FunctionalLocation] FOREIGN KEY ([ResponsibleFunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[TargetDefinition]
 ADD CONSTRAINT [FK_TargetDefinition_FunctionalLocation] FOREIGN KEY ([FunctionalLocationID])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]
 ADD CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation]
 ADD CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation]
 ADD CONSTRAINT [FK_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermit]
 ADD CONSTRAINT [FK_WorkPermit_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]
 ADD CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermitEdmonton]
 ADD CONSTRAINT [FK_WorkPermitEdmonton_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]
 ADD CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]
 ADD CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[WorkPermitOssa]
 ADD CONSTRAINT [FK_WorkPermitOssa_Floc] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocation]
 ADD CONSTRAINT [FK_FunctionalLocation_Plant] FOREIGN KEY ([PlantId])
		REFERENCES [dbo].[Plant] ([Id])
	
GO
ALTER TABLE [dbo].[FunctionalLocation]
 ADD CONSTRAINT [FK_FunctionalLocation_Site] FOREIGN KEY ([SiteId])
		REFERENCES [dbo].[Site] ([Id])
	
GO