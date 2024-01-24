-- Delete all the old SWS stuff before renaming/re-purposing the site and plant.
DELETE
  UserLoginHistoryFunctionalLocation
FROM
  UserLoginHistoryFunctionalLocation
  INNER JOIN UserLoginHistory ON UserLoginHistoryFunctionalLocation.UserLoginHistoryId = UserLoginHistory.Id
 INNER JOIN Shift ON UserLoginHistory.ShiftId = Shift.Id
 WHERE Shift.SiteId = 6
GO

DELETE UserLoginHistory
FROM
  UserLoginHistory
  INNER JOIN Shift ON UserLoginHistory.ShiftId = Shift.Id
WHERE Shift.SiteId = 6
GO

DELETE 
  [LogHistory]
FROM
  [LogHistory]
  INNER JOIN [Log] ON [LogHistory].Id = [Log].[Id]
  INNER JOIN dbo.Shift ON dbo.Shift.Id = dbo.[Log].CreationUserShiftPatternId
where dbo.Shift.SiteId = 6
GO

DELETE 
  [LogFunctionalLocation]
FROM
  [LogFunctionalLocation]
  INNER JOIN [Log] ON [LogFunctionalLocation].LogId = [Log].[Id]
  INNER JOIN dbo.Shift ON dbo.Shift.Id = dbo.[Log].CreationUserShiftPatternId
where dbo.Shift.SiteId = 6
GO

DELETE
  [LogFunctionalLocationList]
FROM
  [LogFunctionalLocationList]
  INNER JOIN [Log] ON [LogFunctionalLocationList].LogId = [Log].[Id]
  INNER JOIN dbo.Shift ON dbo.Shift.Id = dbo.[Log].CreationUserShiftPatternId
where dbo.Shift.SiteId = 6
GO
  
DELETE 
  [Log]
FROM
  [Log]
  INNER JOIN dbo.Shift ON dbo.Shift.Id = dbo.[Log].CreationUserShiftPatternId
where dbo.Shift.SiteId = 6
GO

DELETE 
  SAPNotification
FROM
  SAPNotification
  INNER JOIN FunctionalLocation on FunctionalLocation.Id = FunctionalLocationId
WHERE
  SiteId = 6
GO

DELETE
  ActionItemDefinitionHistory
FROM
  ActionItemDefinitionHistory
  INNER JOIN dbo.ActionItemDefinition ON ActionItemDefinitionHistory.Id = ActionItemDefinition.Id
  INNER JOIN dbo.BusinessCategory ON dbo.BusinessCategory.Id = dbo.ActionItemDefinition.BusinessCategoryId
where dbo.BusinessCategory.SiteId = 6

DELETE
  ActionItemDefinitionFunctionalLocation
FROM
  ActionItemDefinitionFunctionalLocation
  INNER JOIN ActionItemDefinition ON ActionItemDefinitionFunctionalLocation.ActionItemDefinitionId = ActioNItemDefinition.Id
  INNER JOIN dbo.BusinessCategory ON dbo.BusinessCategory.Id = dbo.ActionItemDefinition.BusinessCategoryId
where dbo.BusinessCategory.SiteId = 6

DELETE ActionItemFunctionalLocation
FROM
  ActionItemFunctionalLocation
  INNER JOIN ActionItem ON ActionItem.Id = ActionItemFunctionalLocation.ActionItemId
  INNER JOIN ActionItemDefinition ON ActionItem.CreatedByActionitemDefinitionId = ActionItemDefinition.Id
  INNER JOIN dbo.BusinessCategory ON dbo.BusinessCategory.Id = dbo.ActionItemDefinition.BusinessCategoryId
where dbo.BusinessCategory.SiteId = 6

DELETE ActionItem
FROM
  ActionItem
  INNER JOIN ActionItemDefinition ON ActionItem.CreatedByActionitemDefinitionId = ActionItemDefinition.Id
  INNER JOIN dbo.BusinessCategory ON dbo.BusinessCategory.Id = dbo.ActionItemDefinition.BusinessCategoryId
where dbo.BusinessCategory.SiteId = 6
GO

DELETE
  ActionItemDefinition
FROM
  ActionItemDefinition
  INNER JOIN dbo.BusinessCategory ON dbo.BusinessCategory.Id = dbo.ActionItemDefinition.BusinessCategoryId
where dbo.BusinessCategory.SiteId = 6

DELETE
  BusinessCategoryFLOCAssociation
FROM
  BusinessCategoryFLOCAssociation
  INNER JOIN FunctionalLocation ON BusinessCategoryFLOCAssociation.FunctionalLocationId = FunctionalLocation.Id
WHERE
  FunctionalLocation.SiteId = 6
GO

  
DELETE
  BusinessCategory
WHERE SiteId = 6
GO

DELETE 
  FunctionalLocationOperationalModeHistory
FROM
  FunctionalLocationOperationalModeHistory h
  INNER JOIN FunctionalLocationOperationalMode op on op.UnitId = h.UnitId
  INNER JOIN FunctionalLocation f on f.Id = op.UnitId
WHERE
  f.SiteId = 6
GO

DELETE 
  FunctionalLocationOperationalMode 
FROM
  FunctionalLocationOperationalMode op
  INNER JOIN FunctionalLocation f on f.Id = op.UnitId
WHERE
  f.SiteId = 6
GO 

DELETE 
	FunctionalLocationAncestor 
FROM
  FunctionalLocationAncestor
  INNER JOIN FunctionalLocation ON FunctionalLocationAncestor.Id = FunctionalLocation.Id
WHERE
  FunctionalLocation.SiteId = 6
GO

-- temporarily turn off the constraints to speed up delete.  We are safe to do this one because we don't EVER put records in Work Permit Table for SWS flocs. 
ALTER TABLE [dbo].[WorkPermit] 
NOCHECK CONSTRAINT [FK_WorkPermit_FunctionalLocation]
GO

DELETE
  FunctionalLocation
WHERE
  SiteId = 6
GO

-- turn the constraint check back on!
ALTER TABLE [dbo].[WorkPermit] 
CHECK CONSTRAINT [FK_WorkPermit_FunctionalLocation]
GO

DELETE FROM [dbo].[Shift] where siteid = 6
GO

DELETE FROM [dbo].[SiteFunctionalArea] where siteid = 6
GO

-- Update Site Configuration to be modern
UPDATE 
  dbo.SiteConfiguration
SET
  DaysToDisplayActionItems = 7,
  DaysToDisplayShiftLogs = 14,
  ActionItemRequiresResponseDefaultValue = 1,
  UseNewPriorityPage = 1,
  ShowDirectivesOnPriorityPage = 1,
  ShowShiftHandoversOnPriorityPage = 1,
  DisplayActionItemWorkAssignmentOnPriorityPage = 1,
  ShowAdditionalDetailsOnLogFormByDefault = 0,
  ItemFlocSelectionLevel = 5, -- we have 7 levels in OLT
  LoginFlocSelectionLevel = 5,
  DaysToDisplaySAPNotificationsBackwards = 7
WHERE
  SiteId = 6

INSERT INTO dbo.[Shift] 
([Name],StartTime,EndTime,CreatedDateTime,SiteId)
VALUES (
  'D'  -- Name
  ,'08:00:00'  -- StartTime
  ,'20:00:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,6   -- SiteId
)

INSERT INTO dbo.[Shift] 
([Name],StartTime,EndTime,CreatedDateTime,SiteId)
VALUES (
  'N'  -- Name
  ,'20:00:00'  -- StartTime
  ,'08:00:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,6   -- SiteId
)
GO

--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Id] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;
GO

BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SITE WIDE SERVICES', N'OS1', 0, 0, 1, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSMISSION AND DISTRIBUTION 25KV & UP', N'OS1-P029', 0, 0, 2, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION DISTRIBUTION', N'OS1-P029-EXTD', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV SUBSTATION SKID FOR OPP UNIT B', N'OS1-P029-EXTD-SEG-EDD009', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD009-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-EXTD-SEG-EDD009-SEG-PB0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20951,TRANSFORMER,10/13.3MVA,72KV', N'OS1-P029-EXTD-SEG-EDD009-SEG-PT0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION BOOSTER PUMPHOUSE SUBSTATION', N'OS1-P029-EXTD-SEG-EDD020', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD020-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-EXTD-SEG-EDD020-SEG-PB0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20265,TRANSFORMER,8/10MVA,72KV', N'OS1-P029-EXTD-SEG-EDD020-SEG-PT0070', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-EXTD-SEG-EDD031', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD031-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20915, TRANSFORMER, 8/10MVA,72KV', N'OS1-P029-EXTD-SEG-EDD031-SEG-29PT0094', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POND #6 BARDGE SUBSTATION', N'OS1-P029-EXTD-SEG-EDD032', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD032-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-EXTD-SEG-EDD032-SEG-PB0023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD032-SEG-PS0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20273,TRANSFORMER,8/10MVA,72KV', N'OS1-P029-EXTD-SEG-EDD032-SEG-PT0097', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NORTH TAILINGS 72KV SUBSTATION', N'OS1-P029-EXTD-SEG-EDD045', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD045-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-EXTD-SEG-EDD045-SEG-PB0006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0079', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0080', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0081', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PS0084', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20244,TRANSFORMER,17/22.6MVA,72KV', N'OS1-P029-EXTD-SEG-EDD045-SEG-PT0123', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20243,TRANSFORMER,17/22.6MVA,72KV', N'OS1-P029-EXTD-SEG-EDD045-SEG-PT0124', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PT0125', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-EXTD-SEG-EDD045-SEG-PT0126', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TFT 7.2 KV HIGH VOLTAGE SUBSTATION SKID', N'OS1-P029-EXTD-SEG-EDD149', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD149-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 125VDC DISTRIBUTION PANEL', N'OS1-P029-EXTD-SEG-EDD149-SEG-PA114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 125VDC BATTERY BANK', N'OS1-P029-EXTD-SEG-EDD149-SEG-PB7', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION XFRMR PROTECTION PANEL 1', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ340', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION XFRMR PROTECTION PANEL 2', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ341', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION BREAKER CONTROL PANEL', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ342', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION LOAD SHEDDING PANEL', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ343', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION RTU-EDMS CONTROL PANEL', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ344', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION DC COMMONING PANEL', N'OS1-P029-EXTD-SEG-EDD149-SEG-PJ359', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 7.2 KV LINE 1', N'OS1-P029-EXTD-SEG-EDD149-SEG-PL641', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 7.2 KV LINE 2', N'OS1-P029-EXTD-SEG-EDD149-SEG-PL642', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 7.2 kV LIGHTNING ARRESTER', N'OS1-P029-EXTD-SEG-EDD149-SEG-PLA127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 7.2 kV LIGHTNING ARRESTER', N'OS1-P029-EXTD-SEG-EDD149-SEG-PLA128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION LINE DISCONNECT SWITCH 1', N'OS1-P029-EXTD-SEG-EDD149-SEG-PS514', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION LINE DISCONNECT SWITCH 2', N'OS1-P029-EXTD-SEG-EDD149-SEG-PS515', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION LINE DISCONNECT SWITCH 3', N'OS1-P029-EXTD-SEG-EDD149-SEG-PS516', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION LINE DISCONNECT SWITCH 4', N'OS1-P029-EXTD-SEG-EDD149-SEG-PS517', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION TRANSFORMER 1', N'OS1-P029-EXTD-SEG-EDD149-SEG-PT525', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION TRANSFORMER 2', N'OS1-P029-EXTD-SEG-EDD149-SEG-PT526', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SD8 SUBSTATION 125VDC BATTERY CHARGER', N'OS1-P029-EXTD-SEG-EDD149-SEG-PU24', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP 7.2 KV HIGH VOLTAGE SUBSTATION', N'OS1-P029-EXTD-SEG-EDD150', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-EXTD-SEG-EDD150-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 125VDC DISTRIBUTION PANEL', N'OS1-P029-EXTD-SEG-EDD150-SEG-PA115', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 125VDC BATTERY BANK', N'OS1-P029-EXTD-SEG-EDD150-SEG-PB8', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION XFRMR PROTECTION PANEL 1', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ345', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION XFRMR PROTECTION PANEL 2', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ346', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION BREAKER CONTROL PANEL', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ347', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION LOAD SHEDDING PANEL', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ348', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION RTU-EDMS CONTROL PANEL', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ349', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION DC COMMONING PANEL', N'OS1-P029-EXTD-SEG-EDD150-SEG-PJ358', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 7.2 KV LINE 1', N'OS1-P029-EXTD-SEG-EDD150-SEG-PL643', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION7.2 KV LINE 2', N'OS1-P029-EXTD-SEG-EDD150-SEG-PL644', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 7.2 kV LIGHTNING ARRESTER', N'OS1-P029-EXTD-SEG-EDD150-SEG-PLA118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 7.2 kV LIGHTNING ARRESTER', N'OS1-P029-EXTD-SEG-EDD150-SEG-PLA9', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'7.2 KV LINE DISCONNECT SWITCH NUMBER 1', N'OS1-P029-EXTD-SEG-EDD150-SEG-PS524', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'7.2 KV LINE DISCONNECT SWITCH NUMBER 2', N'OS1-P029-EXTD-SEG-EDD150-SEG-PS525', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'7.2 KV LINE DISCONNECT SWITCH NUMBER 3', N'OS1-P029-EXTD-SEG-EDD150-SEG-PS526', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'7.2 KV LINE DISCONNECT SWITCH NUMBER 4', N'OS1-P029-EXTD-SEG-EDD150-SEG-PS527', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION TRANSFORMER 1', N'OS1-P029-EXTD-SEG-EDD150-SEG-PT527', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION TRANSFORMER 2', N'OS1-P029-EXTD-SEG-EDD150-SEG-PT528', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STP SUBSTATION 125VDC BATTERY CHARGER', N'OS1-P029-EXTD-SEG-EDD150-SEG-PU25', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG DISTRIBUTION', N'OS1-P029-FRBG', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD018', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD018-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20312,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1600T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20301,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1601', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20302,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1602', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20303,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1603', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20304,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1604', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20305,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1605', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20306,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1606', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20307,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1607', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20308,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1608', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20309,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1609', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20310,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1610', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20311,BREAKER,VACUUM INDOOR,25KV,630A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_1611', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20328,BREAKER,VACUUM INDOOR,25KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20329,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20330,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20331,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20332,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20333,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20334,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20335,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_2108T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20313,BREAKER,VACUUM INDOOR,25KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20314,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20315,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20316,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20317,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4205', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20318,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4206', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20319,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4207', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20320,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4208', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20321,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4209', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20322,BREAKER,VACUUM INDOOR,25KV,1250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-352_4210', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20642,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20643,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20644,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20645,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20646,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20647,BREAKER,SF6 DEAD TANK,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-752_106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20168,PANEL DIST,DC,125V,100A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20169,PANEL DIST,ABC,600V,225A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20170,PANEL DIST,ABC,208V,250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20340,PANEL DIST,DC,125V,225A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0019A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20341,PANEL DIST,DC,125V,225A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0019B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20339,PANEL DIST,DC,125V,125A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20337,PANEL DIST,ABC,208V,125A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20342,PANEL DIST,ABC,208V,250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0032', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20327,PANEL DIST,ABC,208V,250A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20326,PANEL DIST,DC,125V,125A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PA0052', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20659,BATTERY,CALCIUM,200 A/H', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20324,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0003A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20324,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0003B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20660,BATTERY,CALCIUM,200 A/H', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20663,BATTERY,ANTIMONY,100 A/H', N'OS1-P029-FRBG-SEG-EDD018-SEG-PB0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20338,PANEL DIST,ABC,600V,400A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PD0101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'25KV PL FOR WELL PAD #1&#2 DISPOSAL WELL', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3054', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3057', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3058', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3059', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3060', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3061', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3062', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3063', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3064', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3065', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3068', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3069', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3070', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3071', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3072', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3074', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3075', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3076', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL3077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV PWR LINE FROM 20EDD-200 TO FIREBAG', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL7001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PL7002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PP0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20336,BUSBAR,AIR_INSULATED,25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PP0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20323,BUSBAR,AIR_INSULATED,25KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PP0042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20624,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20634,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20637,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20638,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0057', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20639,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0058', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0059', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0060', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20627,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0140', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20626,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0141', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0143', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20630,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20629,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0273', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20632,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0274', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20633,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0275', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'25KV DISCONNECT SWITCH', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0506', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'25KV DISCONNECT SWITCH', N'OS1-P029-FRBG-SEG-EDD018-SEG-PS0509', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0068', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0071', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0079', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0096', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20621,TRANSFORMER,45/60MVA,144KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0100', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20619,TRANSFORMER,45/60MVA,144KV', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 80.5KV/115V/115V', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0120A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 80.5KV/115V/115V', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0120B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 80.5KV/115V/115V', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0120C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0162', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0182', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0183', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20618,TRANSFORMER,144KV,45/60MVA', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'2MVA TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0506', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'2MVA TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD018-SEG-PT0509', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20661,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PU0006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20662,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PU0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20324,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PU0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20325,CHARGER,DC SYSTEM,EDD18', N'OS1-P029-FRBG-SEG-EDD018-SEG-PU0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG FEEDER STAGE 2,3 AND 4,SUBS', N'OS1-P029-FRBG-SEG-EDD034', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD034-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PL9007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PL9008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21000,TRANSFORMER,75/100/125MVA,260KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0112', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20993,TRANSFORMER,CVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0113', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20994,TRANSFORMER,CVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20995,TRANSFORMER,CVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0115', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20999,TRANSFORMER,CVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0116', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20990,TRANSFORMER, MVT,84KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20991,TRANSFORMER, MVT,84KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20992,TRANSFORMER,MVT,84KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0119', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0122', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0129', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0131', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20996,TRANSFORMER,SSVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0133A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20997,TRANSFORMER,SSVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0133B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20998,TRANSFORMER,SSVT,172.5KV', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0133C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0197', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0198', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0199', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0200', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0205', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-FRBG-SEG-EDD034-SEG-PT0206', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION FIREBAG CAMP', N'OS1-P029-FRBG-SEG-EDD035', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD035-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20699,TRANSFORMER,2.5/3.3MVA,25KV', N'OS1-P029-FRBG-SEG-EDD035-SEG-PT0161', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG ADMIN & CONTROL BLDG', N'OS1-P029-FRBG-SEG-EDD036', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD036-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20668,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD036-SEG-PT0072', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 STEAM GEN', N'OS1-P029-FRBG-SEG-EDD037', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD037-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20665,TRANSFORMER,5MVA,25KV', N'OS1-P029-FRBG-SEG-EDD037-SEG-PT0073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20664,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD037-SEG-PT0074', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 WATER TREATMENT', N'OS1-P029-FRBG-SEG-EDD038', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD038-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20669,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD038-SEG-PT0075', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 PROCESS', N'OS1-P029-FRBG-SEG-EDD039', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD039-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20671,TRANSFORMER,0.75/1MVA,25KV', N'OS1-P029-FRBG-SEG-EDD039-SEG-PT0076', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 TANK FARM', N'OS1-P029-FRBG-SEG-EDD040', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD040-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20675,TRANSFORMER,500KVA,25KV', N'OS1-P029-FRBG-SEG-EDD040-SEG-PT0077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG TERMINUS', N'OS1-P029-FRBG-SEG-EDD041', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD041-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20171,TRANSFORMER,2MVA,25KV', N'OS1-P029-FRBG-SEG-EDD041-SEG-PT0078', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 DIESEL UNLOADING', N'OS1-P029-FRBG-SEG-EDD042', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD042-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD042-SEG-PL3078', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD042-SEG-PL3079', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20673,TRANSFORMER,500KVA,25KV', N'OS1-P029-FRBG-SEG-EDD042-SEG-PT0098', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 WELL PAD 2', N'OS1-P029-FRBG-SEG-EDD043', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD043-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-FRBG-SEG-EDD043-SEG-PL3081', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20147,TRANSFORMER,1MVA,25KV', N'OS1-P029-FRBG-SEG-EDD043-SEG-PT0080', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20145,TRANSFORMER,3MVA,25KV', N'OS1-P029-FRBG-SEG-EDD043-SEG-PT0203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG STAGE 1 WELL PAD 1', N'OS1-P029-FRBG-SEG-EDD044', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD044-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20141,TRANSFORMER,1MVA,25KV', N'OS1-P029-FRBG-SEG-EDD044-SEG-PT0081', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20139,TRANSFORMER,3MVA,25KV', N'OS1-P029-FRBG-SEG-EDD044-SEG-PT0202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG ETS PILOT PLT SUBSTATION', N'OS1-P029-FRBG-SEG-EDD047', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD047-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20143,TRANSFORMER,500KVA,25KV', N'OS1-P029-FRBG-SEG-EDD047-SEG-PT0099', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FRGB STAGE 3/4 DISTRIBUTION SUBSTATION', N'OS1-P029-FRBG-SEG-EDD048', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-FRBG-SEG-EDD048-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD048-SEG-PL9009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD048-SEG-PL9010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 260KV', N'OS1-P029-FRBG-SEG-EDD048-SEG-PL9011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD049', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD049-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20683,TRANSFORMER,25MVA,25KV', N'OS1-P029-FRBG-SEG-EDD049-SEG-PT0104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD050', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD050-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20677,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD050-SEG-PT0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20679,TRANSFORMER,15MVA,25KV', N'OS1-P029-FRBG-SEG-EDD050-SEG-PT0103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD051', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD051-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20690,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD051-SEG-PT0107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD052', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD052-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20149, TRANSFORMER, 1/1.5MVA,25KV', N'OS1-P029-FRBG-SEG-EDD052-SEG-PT0108', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20151,TRANSFORMER,25KV,2.5MVA', N'OS1-P029-FRBG-SEG-EDD052-SEG-PT0296', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD053', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD053-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20153, TRANSFORMER, 1.5/2MVA,25KV', N'OS1-P029-FRBG-SEG-EDD053-SEG-PT0109', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD054', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD054-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20681,TRANSFORMER,3/4MVA,25KV', N'OS1-P029-FRBG-SEG-EDD054-SEG-PT0105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-FRBG-SEG-EDD058', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD058-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20702, TRANSFORMER, 300KVA,13.8KV', N'OS1-P029-FRBG-SEG-EDD058-SEG-PT0127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FRGB BOOSTER PUMP STATION PAD 107 SUPPLY', N'OS1-P029-FRBG-SEG-EDD086', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD086-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21311,SF6 DEAD TANK,170KV,1200A', N'OS1-P029-FRBG-SEG-EDD086-SEG-752_PT_297', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21310,SWITCH,GANG MANUAL,144KV,1200A', N'OS1-P029-FRBG-SEG-EDD086-SEG-PS_323', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21312,TRANSFORMER,144KV,7.5MVA', N'OS1-P029-FRBG-SEG-EDD086-SEG-PT0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FRGB BOOSTER PUMP STATION PAD 108 SUPPLY', N'OS1-P029-FRBG-SEG-EDD087', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD087-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21307,SF6 DEAD TANK,170KV,1200A', N'OS1-P029-FRBG-SEG-EDD087-SEG-752_PT_298', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21306,SWITCH,GANG MANUAL,144KV,1200A', N'OS1-P029-FRBG-SEG-EDD087-SEG-PS_324', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21308,TRANSFORMER,144KV,7.5MVA', N'OS1-P029-FRBG-SEG-EDD087-SEG-PT0008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD088', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD088-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21363,TRANSFORMER,9/12MVA.25KV', N'OS1-P029-FRBG-SEG-EDD088-SEG-PT0302', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21362,TRANSFORMER,9/12MVA.25KV', N'OS1-P029-FRBG-SEG-EDD088-SEG-PT0303', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD089', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD089-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21375,TRANSFORMER,15/20MVA,25KV', N'OS1-P029-FRBG-SEG-EDD089-SEG-PT0304', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21374,TRANSFORMER,15/20MVA,25KV', N'OS1-P029-FRBG-SEG-EDD089-SEG-PT0305', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD090', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD090-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21364,TRANSFORMER,7.5/10MVA,25KV', N'OS1-P029-FRBG-SEG-EDD090-SEG-PT0306', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21365,TRANSFORMER,7.5/10MVA,25KV', N'OS1-P029-FRBG-SEG-EDD090-SEG-PT0307', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD091', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD091-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21361,TRANSFORMER,12/16MVA,25KV', N'OS1-P029-FRBG-SEG-EDD091-SEG-PT0308', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21360,TRANSFORMER,12/16MVA,25KV', N'OS1-P029-FRBG-SEG-EDD091-SEG-PT0309', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD092', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD092-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21376,TRANSFORMER,7.5/10MVA,25KV', N'OS1-P029-FRBG-SEG-EDD092-SEG-PT0310', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21377,TRANSFORMER,7.5/10MVA,25KV', N'OS1-P029-FRBG-SEG-EDD092-SEG-PT0311', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FRGB BOOSTER PUMP STATION PAD 104 SUPPLY', N'OS1-P029-FRBG-SEG-EDD107', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-FRBG-SEG-EDD107-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21315,SF6 DEAD TANK,170KV,1200A', N'OS1-P029-FRBG-SEG-EDD107-SEG-752_PT_332', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22193,SWITCH,GANG MANUAL,144KV,1200A', N'OS1-P029-FRBG-SEG-EDD107-SEG-PS_361', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21317,TRANSFORMER,144KV,7.5MVA', N'OS1-P029-FRBG-SEG-EDD107-SEG-PT0332', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-FRBG-SEG-EDD112', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-FRBG-SEG-EDD112-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21348,VACUUM INDOOR,15KV,3000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11700T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21349,VACUUM INDOOR,15KV,3000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11701', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21350,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11702', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21351,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11703', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21352,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11704', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21353,VACUUM INDOOR,15KV,3000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11801', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21354,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11802', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21355,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11803', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21356,VACUUM INDOOR,15KV,1200A', N'OS1-P029-FRBG-SEG-EDD112-SEG-252_11804', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21325,VACUUM INDOOR,36KV,2000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6500T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21326,VACUUM INDOOR,36KV,2000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6501', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21327,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6502', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21328,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6503', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21329,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6504', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21330,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6505', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21331,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6506', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21332,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6507', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21333,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6508', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21337,VACUUM INDOOR,36KV,2000A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6601', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21334,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6602', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21335,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6603', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21336,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6604', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21338,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6605', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21339,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6606', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21340,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6607', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21341,VACUUM INDOOR,36KV,1250A', N'OS1-P029-FRBG-SEG-EDD112-SEG-352_6608', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21357,BATTERY,CALCIUM,535  A/H', N'OS1-P029-FRBG-SEG-EDD112-SEG-PB0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'INVERTER,DC SYSTEMS,29EDD-112H', N'OS1-P029-FRBG-SEG-EDD112-SEG-PU0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'INVERTER,DC SYSTEMS,29EDD-112', N'OS1-P029-FRBG-SEG-EDD112-SEG-PU0049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUNCOR MAIN DISTRIBUTION', N'OS1-P029-MAIN', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION,POWERLINES', N'OS1-P029-MAIN-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION 260KV/72KV - MILLENNIUM', N'OS1-P029-MAIN-SEG-EDD001', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD001-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BREAKER,260KV,29PL9-5 TO 29PL9-16,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-952_102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BREAKER,260KV,29PL9-5 TO X260B1,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-952_103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BREAKER,260KV,29PL9-6 TO 29PL9-17,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-952_105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CVT,260KV,PH B,FOR BUS X260B1,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-CVT0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SCADA,125VDC,HMI,CONTROL FOR 29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-HMI0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SCADA,125VDC,HMI,CONTROL FOR 29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-HMI0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,260KV,3000A,NORTH BUS 1,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-N260B1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,260KV,3000A,NORTH BUS 2,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-N260B2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,72KV,3000A,NORTH BUS,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-N72B1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,125VDC,P&C SPARE,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PJ0053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,125VDC,P&C MIMIC,29PL9-5,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PJ0055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,125VDC,SCADA/RTU IN 41RA-1631', N'OS1-P029-MAIN-SEG-EDD001-SEG-PJ0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,125VDC,P&C MIMIC,29PL9-6,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PJ0091', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 29PL6-6,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0184A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 29PL6-6,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0184B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 29PL6-6,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0184C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 6L32,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0185A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 6L32,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0185B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 6L32,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0185C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 29PL6-22,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0186A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 29PL6-22,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0186B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 29PL6-22,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0186C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 29PL6-4,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0187A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 29PL6-4,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0187B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 29PL6-4,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0187C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 29PL6-5,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0188A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 29PL6-5,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0188B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 29PL6-5,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0188C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH A,FOR 29PL6-3,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0189A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH B,FOR 29PL6-3,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0189B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ARRESTER,72KV,PH C,FOR 29PL6-3,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PLA0189C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,LINE 29PL9-5 IN 29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0071', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-101 TO N260B1,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0072', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-102 TO 29PL9-5,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-103 TO 29PL9-5,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0074', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-103 TO X260B1,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0075', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-104 TO N260B1,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0076', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-106/X260B1,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-105 TO 29PL9-6,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0137', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,29-952-106 TO 29PL9-6,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0138', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,260KV,LINE 29PL9-6 IN 29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0139', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,72KV,FOR LINE 29PL6-22,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0146', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,208/120VAC,SSVT,FOR 29PZ-6,EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0161', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,72KV,FOR LINE 29PL6-6,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0195', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,72KV,FOR LINE 29PL6-5,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0196', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,72KV,FOR LINE 6L32,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PS0197', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CVT,260KV,PH A,FOR LINE 29PL9-5,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0121A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CVT,260KV,PH B,FOR LINE 29PL9-5,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0121B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CVT,260KV,PH C,FOR LINE 29PL9-5,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0121C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SSVT,260KV,PH A,FROM BUS X260B1,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0167', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SSVT,260KV,PH B,FROM BUS X260B1,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0168', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SSVT,260KV,PH C,FROM BUS X260B1,29EDD1X', N'OS1-P029-MAIN-SEG-EDD001-SEG-PT0169', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,208/120VAC,TRANSFER MAN,41RA-1631', N'OS1-P029-MAIN-SEG-EDD001-SEG-PZ0006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,208/120VAC,TRANSFER SSVT,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PZ0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,208/120VAC,TRANSFER 1,PVT1,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PZ0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL,208/120VAC,TRANSFER 2,PVT2,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-PZ0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,260KV,3000A,WEST BUS 1,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-W260B1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,260KV,3000A,SOUTH BUS 1,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-X260B1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,260KV,3000A,SOUTH BUS 2,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-X260B2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUS,72KV,3000A,SOUTH BUS,29EDD1', N'OS1-P029-MAIN-SEG-EDD001-SEG-X72B1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TAR ISLAND (UPG 2) SUBSTATION', N'OS1-P029-MAIN-SEG-EDD002', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD002-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2258', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2259', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_258_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_258_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_258_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_259_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_259_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-30PL2_259_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20429,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_00100T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20427,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20426,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20425,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20424,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20423,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20422,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20431,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20432,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20433,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20434,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20235,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0205', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20236,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD002-SEG-352_0206', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20455,SWITCH,FUSE,25KV,600A', N'OS1-P029-MAIN-SEG-EDD002-SEG-389_PT_43', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20446,SWITCH,FUSE,25KV,600A', N'OS1-P029-MAIN-SEG-EDD002-SEG-389_PT_44', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20443,SWITCH,FUSE,30A', N'OS1-P029-MAIN-SEG-EDD002-SEG-89_AUXCPT_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20444,SWITCH,FUSE,30A', N'OS1-P029-MAIN-SEG-EDD002-SEG-89_AUXCPT_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,SPLICE BOX', N'OS1-P029-MAIN-SEG-EDD002-SEG-JB0036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20419,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PA0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20439,PANEL DIST,ABC,0.120/208KV,225A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PA0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20440,PANEL DIST,ABC,0.120/208KV,225A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PA0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20420,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PA0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20445,PANEL DIST,ABC,0.347/600KV,250A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PA0005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20418,BATTERY,CALCIUM,440 A/H', N'OS1-P029-MAIN-SEG-EDD002-SEG-PB0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20441,SERVICE TRANSFORMER 3PHASE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3039', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3041', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3045', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3046', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3051', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3052', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0003_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0003_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0003_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0004_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0004_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0004_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0095_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0095_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_0095_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_A_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_A_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_B_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_B_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_C_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_130_C_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_43', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_45', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD002-SEG-PL3_49', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20437,,BUSBAR ,METAL CLAD AIR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PP0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20438,BUSBAR ,METAL CLAD AIR', N'OS1-P029-MAIN-SEG-EDD002-SEG-PP0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20428,TRANSFORMER,PT_3PHASE,25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PP_001_PT5', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20430,TRANSFORMER,PT_3PHASE,25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PP_002_PT4', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20451,SWITCH,GANG MOTORIZED,69KV,3000A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PS0005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20450,SWITCH,GANG MOTORIZED,69KV,3000A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PS0006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20453,TRANSFORMER,60/90/100MVA,72KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20449,TRANSFORMER,60/90/100MVA,72KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20275,TRANSFORMER,150KVA,25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20276,TRANSFORMER,150KVA,25KV', N'OS1-P029-MAIN-SEG-EDD002-SEG-PT0044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20417,CHARGER,DC,29EDD002', N'OS1-P029-MAIN-SEG-EDD002-SEG-PU0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20416,CHARGER,DC,29EDD002', N'OS1-P029-MAIN-SEG-EDD002-SEG-PU0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20442,SWITCH,AUTO TRANSFER,400A', N'OS1-P029-MAIN-SEG-EDD002-SEG-PZ0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20415,INVERTER,DC,29EDD-2', N'OS1-P029-MAIN-SEG-EDD002-SEG-UPS0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'THIRD PARTY UTILITY SHELTER SUBSTATION', N'OS1-P029-MAIN-SEG-EDD004', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD004-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20942,TRANSFORMER,15/20/25MVA,25KV', N'OS1-P029-MAIN-SEG-EDD004-SEG-PT0009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20922,TRANSFORMER,15/20/25MVA,25KV', N'OS1-P029-MAIN-SEG-EDD004-SEG-PT0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TURBINE GENERATOR 3 SUBSTATION', N'OS1-P029-MAIN-SEG-EDD005', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD005-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P029-MAIN-SEG-EDD005-SEG-PL2264', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV FEEDER FROM 29EDD-5 TO 30EDD-1', N'OS1-P029-MAIN-SEG-EDD005-SEG-PL6007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENIUM EXTRACTION SUBSTATION', N'OS1-P029-MAIN-SEG-EDD007', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD007-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV TO EXTRACTION MILLENNIUM & SHOVELS', N'OS1-P029-MAIN-SEG-EDD007-SEG-PL6016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20289,TRANSFORMER,35/46.7/58.3MVA,72KV', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20290,TRANSFORMER,35/46.7/58.3MVA,72KV', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0065A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0065B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0065BC', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0066A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0066B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD007-SEG-PT0066C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENIUM OPP-A SUBSTATION', N'OS1-P029-MAIN-SEG-EDD008', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD008-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20952,TRANSFORMER,10/13.3MVA,72KV', N'OS1-P029-MAIN-SEG-EDD008-SEG-PT0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'OPRE PREPARATION PLANT UNIT C', N'OS1-P029-MAIN-SEG-EDD010', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD010-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-MAIN-SEG-EDD010-SEG-PB0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20950,TRANSFORMER,10/13.3MVA,72KV', N'OS1-P029-MAIN-SEG-EDD010-SEG-PT0049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PLANT 56-4 SUBSTATION', N'OS1-P029-MAIN-SEG-EDD021', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD021-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20986,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-MAIN-SEG-EDD021-SEG-PT0088', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20985,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-MAIN-SEG-EDD021-SEG-PT0089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20284,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-MAIN-SEG-EDD021-SEG-PT0090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20987,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-MAIN-SEG-EDD021-SEG-PT0091', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TAR ISLAND SUBSTATION #2', N'OS1-P029-MAIN-SEG-EDD022', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD022-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20462,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_1700T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20466,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_1701', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20465,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_1702', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20464,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_1703', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20463,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_1704', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20474,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2500T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20470,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2501A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20471,BREAKER,VACUUM INDOOR,27KV,2000A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2501C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20472,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2502', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20473,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2503', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20475,BREAKER,VACUUM INDOOR,27KV,1200A', N'OS1-P029-MAIN-SEG-EDD022-SEG-352_2504', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20486,SWITCH,FUSE,25KV,600A', N'OS1-P029-MAIN-SEG-EDD022-SEG-389_29PT_85', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20481,SWITCH,FUSE,30A', N'OS1-P029-MAIN-SEG-EDD022-SEG-89_AUXCPT_3', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,SPLICE BOX', N'OS1-P029-MAIN-SEG-EDD022-SEG-JB_0035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20480,DISTRIBUTION PANEL', N'OS1-P029-MAIN-SEG-EDD022-SEG-PA0008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20478,DISTRIBUTION PANEL', N'OS1-P029-MAIN-SEG-EDD022-SEG-PA0009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20479,DISTRIBUTION PANEL', N'OS1-P029-MAIN-SEG-EDD022-SEG-PA0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20460,BATTERY,CALCIUM,270 A/H', N'OS1-P029-MAIN-SEG-EDD022-SEG-PBEDD0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20483,SERVICE TRANSFORMER 3PHASE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL0005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3095', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3096', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3100', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0096_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0096_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0096_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0100_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0100_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_0100_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_A_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_A_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_B_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_B_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_C_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_129_C_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_44', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_46', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PL3_48', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20468,BUSBAR ,METAL CLAD AIR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PP0017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20477,BUSBAR ,METAL CLAD AIR', N'OS1-P029-MAIN-SEG-EDD022-SEG-PP0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20467,TRANSFORMER,PT_3PHASE,25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PP_17 BUS_D', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20476,TRANSFORMER,PT_3PHASE,25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PP_25 BUS_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20488,SWITCH,GANG MOTORIZED,69KV,3000A', N'OS1-P029-MAIN-SEG-EDD022-SEG-PS0044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20489,TRANSFORMER,60/90/100MVA,72KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PT0084', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20487,TRANSFORMER,250KVA,25KV', N'OS1-P029-MAIN-SEG-EDD022-SEG-PT0085', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,XLPE', N'OS1-P029-MAIN-SEG-EDD022-SEG-PT_84_XO', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20458,CHARGER,DC,29EDD-22', N'OS1-P029-MAIN-SEG-EDD022-SEG-PU_0012A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20459,CHARGER,DC,29EDD-22', N'OS1-P029-MAIN-SEG-EDD022-SEG-PU_0012B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20482,SWITCH,AUTO TRANSFER,400A', N'OS1-P029-MAIN-SEG-EDD022-SEG-PZ0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20457,INVERTER,DC,29EDD-22', N'OS1-P029-MAIN-SEG-EDD022-SEG-UPS_0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENNIUM POWER EXTENSION SUBSTATION', N'OS1-P029-MAIN-SEG-EDD033', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD033-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P029-MAIN-SEG-EDD033-SEG-PL6021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD033-SEG-PT0132A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD033-SEG-PT0132B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD033-SEG-PT0132C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG TRANSMISSION SUPPLY', N'OS1-P029-MAIN-SEG-EDD034', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD034-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21233,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_112', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21234,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_113', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21235,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_122', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21236,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_123', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21237,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_131', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21238,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_132', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21239,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_141', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21240,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-29_952_142', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21380,SF6 DEAD TANK,79KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10200T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21378,SF6 DEAD TANK,79KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21379,SF6 DEAD TANK,79KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10202A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10202B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10202C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21381,SF6 DEAD TANK,79KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10301', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21382,SF6 DEAD TANK,79KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10302', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10302A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10302B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD034-SEG-652_10302C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21272,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_112A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21273,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_112B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21274,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_112C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21275,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_113A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21276,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_113B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21277,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_113C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21278,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_122A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21279,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_122B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21280,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_122C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21281,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_123A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21282,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_123B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21283,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_123C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21284,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_131A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21285,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_131B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21286,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_131C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21287,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_132A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21288,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_132B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21289,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_132C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21290,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_141A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21291,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_141B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21292,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_141C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21293,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_142A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21294,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_142B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21295,TRANSFORMER,CT_1PH.,260KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-952_142C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21220,BATTERY,ANTIMONY,260 A/H', N'OS1-P029-MAIN-SEG-EDD034-SEG-PB0045', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'260KV TRANSMISSION LINE EDD34 TO EDD65', N'OS1-P029-MAIN-SEG-EDD034-SEG-PL9012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'260KV TRANSMISSION LINE EDD34 TO EDD65', N'OS1-P029-MAIN-SEG-EDD034-SEG-PL9013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'260KV TRANSMISSION LINE EDD34 TO EDD56', N'OS1-P029-MAIN-SEG-EDD034-SEG-PL9014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'260KV TRANSMISSION LINE EDD34 TO EDD56', N'OS1-P029-MAIN-SEG-EDD034-SEG-PL9015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PP0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PP0045', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR INSULATED,72KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PP0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR INSULATED,72KV,3000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PP0103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21241,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0213', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21242,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0214', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21243,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0215', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21244,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0216', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21245,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0217', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21246,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0218', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21247,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0219', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21248,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0220', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21250,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0221', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21251,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0222', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21252,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0223', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21253,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0224', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21249,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0225', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21255,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0226', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21256,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0227', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21257,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0228', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21258,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0229', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21254,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0230', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0370', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0371', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0373', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0374', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21383,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0376', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21384,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0377', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21385,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0378', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21386,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0379', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21387,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0380', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21388,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0381', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21389,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0382', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21390,SWITCH,GANG MOTORIZED,72Kv,2000A', N'OS1-P029-MAIN-SEG-EDD034-SEG-PS0383', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21260,TRANSFORMER,CVT_1PH.,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0222A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21261,TRANSFORMER,CVT_1PH.,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0222B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21262,TRANSFORMER,CVT_1PH.,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0222C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21259,TRANSFORMER,CVT_1PH.,260KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0223B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21296,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0224A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21297,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0224B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21298,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0224C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21263,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0225A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21264,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0225B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21265,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0225C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21266,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0226A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21267,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0226B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21268,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0226C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21269,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0227A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21270,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0227B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21271,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0227C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21299,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0504A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21301,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0504AC', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21300,TRANSFORMER, SSVT, 172.5KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT0504B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22299,TRANSFORMER,260KV,90/120/150MVA', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_340', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21399,TRANSFORMER,260KV,90/120/150MVA', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_341', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21513,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_342A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21514,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_342B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21515,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_342C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21505,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_343A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21506,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_343B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21507,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_343C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21391,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_344B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21392,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_345B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21393,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_346A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21394,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_346B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21395,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_346C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21396,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_347A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21397,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_347B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21398,TRANSFORMER,350KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_347C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21510,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_133A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21511,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_133B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21512,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_133C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21502,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_143A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21503,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_143B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21504,TRANSFORMER,1050KV', N'OS1-P029-MAIN-SEG-EDD034-SEG-PT_952_143C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21218,CHARGER,DC SYSTEM,EDD34', N'OS1-P029-MAIN-SEG-EDD034-SEG-PU0040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21219,CHARGER,DC SYSTEM,EDD34', N'OS1-P029-MAIN-SEG-EDD034-SEG-PU0041', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'OILSANDS PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD055', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'OILSANDS PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD055-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PL2287', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22341,SWITCH,GANG MOTORIZED,15KV,4000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PS0163', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22371,SWITCH,GANG MOTORIZED,15KV,4000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PS0164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22340,SWITCH,GANG MANUAL,15KV,600A', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PS0176', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22373,SWITCH,GANG MANUAL,15KV,600A', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PS0177', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20957,TRANSFORMER,SERVICE 3PH,72V', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PT0232', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20958,TRANSFORMER,SERVICE 3PH,72V', N'OS1-P029-MAIN-SEG-EDD055-SEG-30PT0233', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22359,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-652_3701', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22366,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-652_3702', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22347,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-652_3703', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22354,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-652_3704', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21120,PANEL DIST,ABC,0.208KV,600A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PA0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21121,PANEL DIST,ABC,0.208KV,600A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PA0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21122,PANEL DIST,DC,0.125KV,400A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PA0049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21123,PANEL DIST,DC,0.125KV,400A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PA0050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21124,PANEL DIST,DC,0.125KV,200A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PA0051', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21117,BATTERY,ANTIMONY,620 A/H', N'OS1-P029-MAIN-SEG-EDD055-SEG-PB0036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'11930,BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PP0037A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'11931,BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PP0037B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'11932,BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PP0037C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'11966,BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PP0037D', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22358,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22360,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22365,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0112', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22367,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0113', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22346,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22348,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0115', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22353,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0116', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22355,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22357,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22364,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0119', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22349,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0120', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22342,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0121', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22356,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0124', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21499,SWITCH,GANG MOTORIZED,260KV,1200A', N'OS1-P029-MAIN-SEG-EDD055-SEG-PS0163', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22343,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0002A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22344,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0002B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22345,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0002C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20907,TRANSFORMER,45/60/75MVA,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0163', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20906,TRANSFORMER,45/60/75MVA,72KV', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0165', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0166', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0180', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0181', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22361,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0228A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22362,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0228B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22363,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0228C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22350,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0230A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22351,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0230B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22352,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0230C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22368,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0231A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22369,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0231B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22370,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0231C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0286', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,72', N'OS1-P029-MAIN-SEG-EDD055-SEG-PT0287', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21118,CHARGER,DC SYSTEM,EDD55', N'OS1-P029-MAIN-SEG-EDD055-SEG-PU0019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21119,CHARGER,DC SYSTEM,EDD55', N'OS1-P029-MAIN-SEG-EDD055-SEG-PU0020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENNIUM MINE SUPPLY', N'OS1-P029-MAIN-SEG-EDD056', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD056-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21454,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-14GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21458,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-14GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21483,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-16GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21487,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-16GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21471,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-23GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21475,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-23GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21446,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-24GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21447,TRANSFORMER,ZERO SEQ CT,72,200', N'OS1-P029-MAIN-SEG-EDD056-SEG-24GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21465,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21477,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4120', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21489,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21436,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4140', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21448,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4150', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21462,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4160', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21426,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-652_4170', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21420,BREAKER,SF6 LIVE TANK,300KV,1200A', N'OS1-P029-MAIN-SEG-EDD056-SEG-952_1401', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21498,BREAKER,SF6 LIVE TANK,300KV,1200A', N'OS1-P029-MAIN-SEG-EDD056-SEG-952_501', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21459,TRANSFORMER,ZERO SEQ CT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21460,TRANSFORMER,ZERO SEQ CT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21103,PANEL DIST,DC,0.125KV,400A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21104,PANEL DIST,DC,0.125KV,400A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21105,PANEL DIST,ABC,0.208KV,600A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21106,PANEL DIST,ABC,0.208KV,600A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21107,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0031', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21108,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0033', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21109,PANEL DIST,DC,0.125KV,250A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PA0039', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21500,BATTERY,ANTIMONY,1080 A/H', N'OS1-P029-MAIN-SEG-EDD056-SEG-PBEDD0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21496,TRANSFORMER,NEUTRAL_GROUNDING XFMR', N'OS1-P029-MAIN-SEG-EDD056-SEG-PN0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21491,TRANSFORMER,NEUTRAL_GROUNDING XFMR', N'OS1-P029-MAIN-SEG-EDD056-SEG-PN0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041D', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041E', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041F', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041G', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PP0041H', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20635,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0054', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21419,SWITCH,GANG MOTORIZED,260KV,1200A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21495,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0167', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21421,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0168', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21464,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0169', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21466,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0170', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21476,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0171', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21478,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0172', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21488,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0173', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21490,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0174', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21435,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0175', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21437,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0176', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21438,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0177', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21449,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0178', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21461,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0179', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21463,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0180', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21453,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0181', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21482,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0182', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21470,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0183', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21442,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0184', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21431,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0326', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21425,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0327', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21427,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0328', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21434,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0329', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21432,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0330', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21433,SWITCH,GANG MOTORIZED,72KV,2000A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0331', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21959,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD056-SEG-PS0551', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20935,TRANSFORMER,POWER_3PH_AUTO,260', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0190', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20933,TRANSFORMER,POWER_3PH_AUTO,260', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0191', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0192A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0192B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0192C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0193A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0193B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,260KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0193C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21469,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0194A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21468,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0194B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21467,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0194C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21479,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0195A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21480,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0195B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21481,TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0195C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21424,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0196A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21423,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0196B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21422,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0196C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21422,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0196_SSVT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21441,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0197A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21440,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0197B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21439,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0197C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21452,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0198A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21451,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0198B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21450,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0198C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21492,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0199A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21493,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0199B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21494,TRANSFORMER,SSVT,41.5KV', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0199C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0312A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0312B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,CVT,72', N'OS1-P029-MAIN-SEG-EDD056-SEG-PT0312C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21101,CHARGER,DC SYSTEM,EDD56', N'OS1-P029-MAIN-SEG-EDD056-SEG-PU0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21102,CHARGER,DC SYSTEM,EDD56', N'OS1-P029-MAIN-SEG-EDD056-SEG-PU0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-MAIN-SEG-EDD063', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MAIN-SEG-EDD063-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20666,TRANSFORMER,POWER_3PH_2WINDING,144', N'OS1-P029-MAIN-SEG-EDD063-SEG-PT0179', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20667,TRANSFORMER,15MVA,13.8KV', N'OS1-P029-MAIN-SEG-EDD063-SEG-PT0219', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NEW TECHNOLOGY SUPPLY', N'OS1-P029-MAIN-SEG-EDD064', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20597,TRANSFORMER,SERVICE 3PH OIL,72V', N'OS1-P029-MAIN-SEG-EDD064-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21950,BREAKER,SF6 DEAD TANK,72.5KV,1200A', N'OS1-P029-MAIN-SEG-EDD064-SEG-652_2503', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21964,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD064-SEG-89PA0700', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21958,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD064-SEG-89PA0701', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21965,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD064-SEG-89PA0702', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20597,TRANSFORMER,SERVICE 3PH OIL,72V', N'OS1-P029-MAIN-SEG-EDD064-SEG-89PT0700', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21955,RECTIFIER/INVERTER,600V,27A', N'OS1-P029-MAIN-SEG-EDD064-SEG-89UPS700', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21956,BATTERY,GLASS MATT,615 A/H', N'OS1-P029-MAIN-SEG-EDD064-SEG-PBEDD0064', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20636,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD064-SEG-PS0055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20916,TRANSFORMER,POWER_3PH_2WINDING,72', N'OS1-P029-MAIN-SEG-EDD064-SEG-PT0188', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21951,TRANSFORMER,CVT_1PH.,72', N'OS1-P029-MAIN-SEG-EDD064-SEG-PT0209', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21952,TRANSFORMER,CVT_1PH.,72', N'OS1-P029-MAIN-SEG-EDD064-SEG-PT0211', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21953,TRANSFORMER,CVT_1PH.,72', N'OS1-P029-MAIN-SEG-EDD064-SEG-PT0212', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20597,TRANSFORMER,SERVICE_3PH,72', N'OS1-P029-MAIN-SEG-EDD064-SEG-PT0700', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG TRANSMISSION SUPPLY', N'OS1-P029-MAIN-SEG-EDD065', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD065-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22118,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4811', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22119,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4812', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22120,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4813', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22121,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4821', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22122,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4822', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22123,BREAKER,SF6 LIVE TANK,300KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-29_952_4823', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22124,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4811A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22125,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4811B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22126,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4811C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22127,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4812A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22128,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4812B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22129,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4812C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22130,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4813A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22131,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4813B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22132,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4813C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22133,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4821A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22134,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4821B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22135,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4821C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22136,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4822A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22137,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4822B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22138,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4822C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22139,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4823A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22140,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4823B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22141,TRANSFORMER,CT_1PH.,260,3000', N'OS1-P029-MAIN-SEG-EDD065-SEG-952_4823C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22190,BATTERY,ANTIMONY,260 A/H', N'OS1-P029-MAIN-SEG-EDD065-SEG-PB0046', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD-65 TO EDD-71', N'OS1-P029-MAIN-SEG-EDD065-SEG-PL7003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD-65 TO EDD-71', N'OS1-P029-MAIN-SEG-EDD065-SEG-PL7004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,260KV', N'OS1-P029-MAIN-SEG-EDD065-SEG-PP0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,260KV', N'OS1-P029-MAIN-SEG-EDD065-SEG-PP0049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22100,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0264', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22101,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0265', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22102,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0266', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22103,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0267', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22104,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0268', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22105,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0269', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22106,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0270', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22107,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0271', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22108,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0272', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22109,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0279', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22110,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0280', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22111,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0281', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22112,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0282', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22113,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0283', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22114,SWITCH,GANG MOTORIZED,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0284', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22115,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0285', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22116,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0286', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22117,SWITCH,GANG MANUAL,260KV,2000A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PS0287', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,POWER_3PH_AUTO,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0236', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22160,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0249A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22161,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0249B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22162,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0249C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22163,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0250A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22164,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0250B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22165,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0250C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22166,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0251B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22167,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0252A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22168,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0252B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22169,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0252C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22187,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0253A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22188,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0253B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22189,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0253C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER,POWER_3PH_AUTO,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0257', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22170,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0258A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22171,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0258B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22172,TRANSFORMER,PT_1PH.,144,N/A', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0258C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22173,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0259A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22174,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0259B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22175,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0259C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22176,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0260A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22177,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0260B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22178,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0260C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22179,TRANSFORMER,CVT_1PH.,260', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0261B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22184,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0262A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22185,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0262B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22186,TRANSFORMER,SERVICE_1PH& METERING,', N'OS1-P029-MAIN-SEG-EDD065-SEG-PT0262C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22191,CHARGER,DC SYSTEM,EDD65', N'OS1-P029-MAIN-SEG-EDD065-SEG-PU0042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22192,CHARGER,DC SYSTEM,EDD65', N'OS1-P029-MAIN-SEG-EDD065-SEG-PU0043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD068', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD068-SEG', 0, 0, 6, 1000, N'en');
COMMIT TRANSACTION
GO
BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20687,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD068-SEG-PT0205', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20685,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD068-SEG-PT0206', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION SEP300', N'OS1-P029-MAIN-SEG-EDD070', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD070-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20041,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20040,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20039,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20038,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20037,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20042,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD070-SEG-652_7060', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20071,FLOODLIGHTS,ABC,0.208KV,50A', N'OS1-P029-MAIN-SEG-EDD070-SEG-FLOODLIGHTS', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20044,TRANSFORMER,CT_ZEROSEQ,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-GCT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20043,TRANSFORMER,CT_ZEROSEQ,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-GCT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20060,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PA0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20061,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PA0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20063,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PA0054', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20059,PANEL DIST,ABC,0.6KV,250A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PA0055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20062,PANEL DIST,ABC,0.6KV,250A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PA0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20068,BATTERY,AGM,208 A/H', N'OS1-P029-MAIN-SEG-EDD070-SEG-PB0037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20064,SERVICE TRANSFORMER 3PHASE', N'OS1-P029-MAIN-SEG-EDD070-SEG-PL0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20065,SERVICE TRANSFORMER 3PHASE', N'OS1-P029-MAIN-SEG-EDD070-SEG-PL0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV OVERHEAD POWER LINE', N'OS1-P029-MAIN-SEG-EDD070-SEG-PL6034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20073,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070A_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20074,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070A_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20075,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070A_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20047,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070B_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20048,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070B_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20049,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070B_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20100,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070C_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20101,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070C_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20102,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070C_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20052,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070D_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20051,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070D_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20050,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070D_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20084,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070E_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20085,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070E_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20086,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070E_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20092,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070F_A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20093,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070F_B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20094,CABLE,EPR', N'OS1-P029-MAIN-SEG-EDD070-SEG-PP_0070F_C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20005,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0334', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20004,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0335', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20011,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0336', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20012,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0337', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20016,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0338', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20017,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0339', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20015,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0340', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20014,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0341', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20010,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0342', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20009,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0343', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20006,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0344', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20007,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0345', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20008,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0346', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20013,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0347', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20003,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0366', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20018,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0367', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20002,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0368', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20001,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD070-SEG-PS0369', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20053,TRANSFORMER,30/40/50MVA,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0220', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20057,TRANSFORMER,30/40/50MVA,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0221', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20021,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0317A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20020,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0317B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20019,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0317C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20031,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0318A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20032,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0318B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20033,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0318C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20025,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0319A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20026,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0319B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20027,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0319C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20028,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0320A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20029,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0320B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20030,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0320C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20034,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0325A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20035,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0325B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20036,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0325C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20022,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0326A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20023,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0326B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20024,TRANSFORMER,CVT,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT0326C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20099,TRANSFORMER,CT_ZEROSEQ,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT220_GCT_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20103,TRANSFORMER,CT_ZEROSEQ,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT220_GCT_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20091,TRANSFORMER,CT_ZEROSEQ,72KV', N'OS1-P029-MAIN-SEG-EDD070-SEG-PT221_GCT_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20067,CHARGER,DC,29EDD-70', N'OS1-P029-MAIN-SEG-EDD070-SEG-PU0017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20066,CHARGER,DC,29EDD-70', N'OS1-P029-MAIN-SEG-EDD070-SEG-PU0018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD071', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD071-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22028,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4613', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22070,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4613A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22071,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4613B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22072,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4613C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22029,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4614', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22073,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4614A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22074,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4614B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22075,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4614C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22030,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4621', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22076,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4621A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22077,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4621B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22078,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4621C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22031,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4622', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22079,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4622A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22080,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4622B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22081,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4622C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22032,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4623', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22082,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4623A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22083,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4623B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22084,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4623C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22033,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4624', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22085,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4624A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22086,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4624B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22087,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4624C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22034,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4631', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22088,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4631A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22089,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4631B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22090,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4631C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22035,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4632', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22091,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4632A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22092,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4632B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22093,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4632C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22036,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4633', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22094,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4633A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22095,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4633B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22096,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4633C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22037,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4634', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22097,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4634A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22098,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4634B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22099,TRANSFORMER,CT_1PH.,144,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-752_4634C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22261,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0086A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22262,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0086B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22263,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0086C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22264,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0086D', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22265,PANEL DIST,DC,0.125KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0086E', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22258,PANEL DIST,ABC,0.208KV,600A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0088', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22259,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22260,PANEL DIST,ABC,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PA0090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21216,BATTERY,ANTIMONY,530 A/H', N'OS1-P029-MAIN-SEG-EDD071-SEG-PB0048A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21217,BATTERY,ANTIMONY,530 A/H', N'OS1-P029-MAIN-SEG-EDD071-SEG-PB0048B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22256,TRANSFORMER,SERVICE_3PH,0.6', N'OS1-P029-MAIN-SEG-EDD071-SEG-PL0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD-18 TO EDD-71', N'OS1-P029-MAIN-SEG-EDD071-SEG-PL7005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD071-SEG-PP0046', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD071-SEG-PP0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22001,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0231', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22002,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0232', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22003,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0233', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22004,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0234', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22005,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0235', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22006,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0236', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22007,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0237', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22008,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0238', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22009,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0239', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22010,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0240', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22011,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0241', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22012,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0242', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22013,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0243', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22014,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0244', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22015,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0245', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22016,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0246', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22017,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0247', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22018,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0248', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22019,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0249', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22020,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0250', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22021,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0251', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22022,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0252', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22023,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0253', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22024,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0254', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22025,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0255', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22026,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0256', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22027,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0257', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22254,SWITCH,3PDT_TRANSFER,,400A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0416', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22255,SWITCH,2PDT_TRANSFER,,400A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0458', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22257,SWITCH,3PST_SWITCHFUSE,,400A', N'OS1-P029-MAIN-SEG-EDD071-SEG-PS0459', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21201,TRANSFORMER,POWER_3PH_3WINDING,144', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0232', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21202,TRANSFORMER,POWER_3PH_3WINDING,144', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0233', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21203,TRANSFORMER,POWER_3PH_3WINDING,144', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0234', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21204,TRANSFORMER,POWER_3PH_3WINDING,144', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0237', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22038,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0238A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22039,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0238B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22040,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0238C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22041,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0239A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22042,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0239B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22043,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0239C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22044,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0240A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22045,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0240B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22046,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0240C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22047,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0241A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22048,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0241B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22049,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0241C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22050,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0242B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22051,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0243B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22052,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0244A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22053,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0244B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22054,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0244C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22055,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0245A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22056,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0245B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22057,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0245C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22058,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0246A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22059,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0246B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22060,TRANSFORMER,PT_1PH.,144,1000VA', N'OS1-P029-MAIN-SEG-EDD071-SEG-PT0246C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21213,INVERTER,DC SYSTEM,EDD71', N'OS1-P029-MAIN-SEG-EDD071-SEG-PU0044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21214,INVERTER,DC SYSTEM,EDD71', N'OS1-P029-MAIN-SEG-EDD071-SEG-PU0045', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21215,INVERTER,DC SYSTEM,EDD71', N'OS1-P029-MAIN-SEG-EDD071-SEG-PU0050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 72KV~4.16KV,HOT PROC. WATER', N'OS1-P029-MAIN-SEG-EDD079', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD079-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20132,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD079-SEG-652_PT_278', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20198,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD079-SEG-652_PT_279', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20194,BATTERY,AGM,152 A/H', N'OS1-P029-MAIN-SEG-EDD079-SEG-PB0039', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV POWER LINE', N'OS1-P029-MAIN-SEG-EDD079-SEG-PL6030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20196,CHARGER,DC,29EDD-79', N'OS1-P029-MAIN-SEG-EDD079-SEG-PU0034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20195,CHARGER,DC,29EDD-79', N'OS1-P029-MAIN-SEG-EDD079-SEG-PU0035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 72KV~4.16KV,POT EFFLU.WATER', N'OS1-P029-MAIN-SEG-EDD080', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD080-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20615,PANEL DIST,0.208KV,225A', N'OS1-P029-MAIN-SEG-EDD080-SEG-300PA_50', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20603,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD080-SEG-652_PT_280', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20607,BREAKER,SF6 DEAD TANK,72.5KV,2000A', N'OS1-P029-MAIN-SEG-EDD080-SEG-652_PT_281', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20614,PANEL DIST,DC,0.125KV,250A', N'OS1-P029-MAIN-SEG-EDD080-SEG-PA0065', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20613,BATTERY,AGM,152 A/H', N'OS1-P029-MAIN-SEG-EDD080-SEG-PB0040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20604,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD080-SEG-PS_0294', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20610,SWITCH,GANG MANUAL,69KV,1200A', N'OS1-P029-MAIN-SEG-EDD080-SEG-PS_0295', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20601,TRANSFORMER,11.2/14.33MVA,72KV', N'OS1-P029-MAIN-SEG-EDD080-SEG-PT0280', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20605,TRANSFORMER,11.2/14.33MVA,72KV', N'OS1-P029-MAIN-SEG-EDD080-SEG-PT0281', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20611,CHARGER,DC,29EDD-80', N'OS1-P029-MAIN-SEG-EDD080-SEG-PU0036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20612,CHARGER,DC,29EDD-80', N'OS1-P029-MAIN-SEG-EDD080-SEG-PU0037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG WELL PAD 144KV SUPPLY', N'OS1-P029-MAIN-SEG-EDD085', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD085-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22233,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752-10010A', 0, 0, 8, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22205,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22234,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10010B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22235,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10010C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22206,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22236,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10020A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22237,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10020B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22238,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10020C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22207,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22239,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10030A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22240,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10030B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22241,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10030C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22208,BREAKER,SF6 LIVE TANK,170KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22242,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10040A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22243,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10040B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22244,TRANSFORMER,CT_1PH.,144,2500', N'OS1-P029-MAIN-SEG-EDD085-SEG-752_10040C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22253,BATTERY,ANTIMONY,260 A/H', N'OS1-P029-MAIN-SEG-EDD085-SEG-PB0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD85 TO EDD87', N'OS1-P029-MAIN-SEG-EDD085-SEG-PL7007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD-85 TO EDD-107', N'OS1-P029-MAIN-SEG-EDD085-SEG-PL7008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'144KV TRANSMISION LINE EDD-18 TO EDD-85', N'OS1-P029-MAIN-SEG-EDD085-SEG-PL7010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD085-SEG-PP0100A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD085-SEG-PP0100B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD085-SEG-PP0100C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,AIR_INSULATED,144KV', N'OS1-P029-MAIN-SEG-EDD085-SEG-PP0100D', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22193,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0319', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22194,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0320', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22195,SWITCH,GANG MOTORIZED,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0322', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22196,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0420', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22197,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0421', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22198,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0422', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22199,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0423', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22200,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0424', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22201,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0425', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22202,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0426', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22203,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0427', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22204,SWITCH,GANG MANUAL,144KV,2000A', N'OS1-P029-MAIN-SEG-EDD085-SEG-PS0428', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22245,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0423A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22246,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0423B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22247,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0423C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22209,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0424A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22210,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0424B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22211,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0424C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22212,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0425A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22213,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0425B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22214,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0425C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22248,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0426A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22249,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0426B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22250,TRANSFORMER,SERVICE_3PH& METERING,', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0426C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22215,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0427A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22216,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0427B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22217,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0427C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22218,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0428A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22219,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0428B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22220,TRANSFORMER,PT_1PH.,144', N'OS1-P029-MAIN-SEG-EDD085-SEG-PT0428C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22251,CHARGER,DC SYSTEM,EDD85', N'OS1-P029-MAIN-SEG-EDD085-SEG-PU0046', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22252,CHARGER,DC SYSTEM,EDD85', N'OS1-P029-MAIN-SEG-EDD085-SEG-PU0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD104', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD104-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20343,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD104-SEG-PT0327', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20345,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD104-SEG-PT0328', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG PRIMARY DISTRIBUTION', N'OS1-P029-MAIN-SEG-EDD105', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MAIN-SEG-EDD105-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20695,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD105-SEG-PT0330', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20697,TRANSFORMER,POWER_3PH_2WINDING,25', N'OS1-P029-MAIN-SEG-EDD105-SEG-PT0331', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE DISTRIBUTION', N'OS1-P029-MINE', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV SUBSTATION FOR MILLENNIUM SHOVEL', N'OS1-P029-MINE-SEG-EDD015', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG-EDD015-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SEEPAGE COLLECTION SUPPLY SUBSTATION', N'OS1-P029-MINE-SEG-EDD019', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG-EDD019-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20944,TRANSFORMER,8/10MVA,72KV', N'OS1-P029-MINE-SEG-EDD019-SEG-PT0069', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-MINE-SEG-EDD046', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG-EDD046-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20583,TRANSFORMER,10/13MVA,72KV', N'OS1-P029-MINE-SEG-EDD046-SEG-PT0127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-MINE-SEG-EDD056-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P029-MINE-SEG-EDD056-SEG-PL6023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P029-MINE-SEG-EDD056-SEG-PL6024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-MINE-SEG-EDD067', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG-EDD067-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20592, TRANSFORMER, 8/10MVA,72KV', N'OS1-P029-MINE-SEG-EDD067-SEG-PT0062', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-MINE-SEG-EDD093', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-MINE-SEG-EDD093-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20593, TRANSFORMER, 8/10MVA,72KV', N'OS1-P029-MINE-SEG-EDD093-SEG-PT0050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'OFFPLOTS DISTRIBUTION', N'OS1-P029-OFFP', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-OFFP-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV SUBSTATION FOR SOUTH BOOSTER PUMP', N'OS1-P029-OFFP-SEG-EDD062', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-OFFP-SEG-EDD062-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P029-OFFP-SEG-EDD062-SEG-PB0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PS0209', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PS0210', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0184', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0185', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20945,TRANSFORMER,17/22.6/28.2MVA,72KV', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0186', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20946,TRANSFORMER,17/22.6/28.2MVA,72KV', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0187', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0214', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PT0215', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUPPLY POWER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PU0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUPPLY POWER', N'OS1-P029-OFFP-SEG-EDD062-SEG-PU0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK MINE DISTRIBUTION', N'OS1-P029-STMI', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-STMI-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV SUBSTATION STEEPBANK MINE SHOVEL', N'OS1-P029-STMI-SEG-EDD011', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-STMI-SEG-EDD011-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV FEEDER TAP BETWEEN STEEPBANK AND A', N'OS1-P029-STMI-SEG-EDD011-SEG-PL6014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P029-STMI-SEG-EDD011-SEG-PL6025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P029-STMI-SEG-EDD011-SEG-PL6026', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P029-STMI-SEG-EDD011-SEG-PS0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P029-STMI-SEG-EDD011-SEG-PS0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P029-STMI-SEG-EDD011-SEG-PS0191', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P029-STMI-SEG-EDD011-SEG-PS0198', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-STMI-SEG-EDD066', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-STMI-SEG-EDD066-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20401,BREAKER,SF6 LIVE TANK,72KV,2000A', N'OS1-P029-STMI-SEG-EDD066-SEG-652_2501', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20404,SWITCH,GANG MANUAL,72KV,1200A', N'OS1-P029-STMI-SEG-EDD066-SEG-PS0192', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20402,TRANSFORMER,6/8MVA,72KV', N'OS1-P029-STMI-SEG-EDD066-SEG-PT0200', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'UPGRADING DISTRIBUTION', N'OS1-P029-UPGD', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUB 56-1, 25KV SWITCHGEAR ROOM', N'OS1-P029-UPGD-SEG-EDD012', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD012-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21342,BUSBAR,METALCLAD_AIR,13.8KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-30PP0117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21343,BUSBAR,METALCLAD_AIR,13.8KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-30PP0118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22658,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_800T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22656,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_801', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22655,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_802', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22654,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_803', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22653,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_804', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22652,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_805', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22651,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_806', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22650,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_807', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22660,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_901', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22661,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_902', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22662,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_903', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22663,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_904', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22664,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_905', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22665,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_906', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22666,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD012-SEG-352_907', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22667,DIST PANEL, DC, 0.125kV, 100A', N'OS1-P029-UPGD-SEG-EDD012-SEG-56PA0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL317A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL317B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL318A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL318B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20104,CABLE,3PH FEEDER TO 29EDD-16', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_12', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20105,CABLE,3PH FEEDER TO 29PT-52', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_13', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20106,CABLE,3PH FEEDER TO 29PT-28', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_14', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20107,CABLE,3PH FEEDER TO 29PT-26', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_15', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20108,CABLE,3PH FEEDER TO 29PT-24', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_16', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20109,CABLE,3PH FEEDER TO 29PT-22', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_17', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20110,CABLE,3PH FEEDER TO 29PT-23', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_18', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20111,CABLE,3PH FEEDER TO 29PT-25', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_20', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20112,CABLE,3PH FEEDER TO 29PT-27', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_21', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20113,CABLE,3PH FEEDER TO 29PT-29', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_22', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20114,CABLE,3PH FEEDER TO 29EDD-26', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_23', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20115,CABLE,3PH FEEDER TO 29EDD-27', N'OS1-P029-UPGD-SEG-EDD012-SEG-PL3_24', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21319,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP0065', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21320,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP0066', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20498,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20499,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22657,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP08_BUS_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22659,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PP09_BUS_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20229,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20230,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20231,TRANSFORMER,10MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20232,TRANSFORMER,10MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20233,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0026', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20234,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20235,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20236,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD012-SEG-PT0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUB 56-2, 25KV SWITCHGEAR ROOM', N'OS1-P029-UPGD-SEG-EDD013', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD013-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3026', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3033', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL3038', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL329A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL329B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL330A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL330B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL331A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL331B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL332A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PL332B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20226,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20227,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20228,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20225,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20224,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20223,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 7.5/11MVA 25KV TO 13.8KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20291,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20292,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0031', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20293,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0032', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20294,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0033', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20222,TRANSFORMER,10/15MVA,25KV', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0172', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD013-SEG-PT0173', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUB 56-3, 25KV SWITCHGEAR ROOM', N'OS1-P029-UPGD-SEG-EDD014', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD014-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3080', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3085', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3086', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3087', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PL3088', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20221,TRANSFORMER,2.5/3.75MVA,25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20219,TRANSFORMER,2.5/3.75MVA,25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20220,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20218,TRANSFORMER,2/3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0174', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0176', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD014-SEG-PT0177', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'UPGRADING MILLENNIUM CONTROL BUILDING', N'OS1-P029-UPGD-SEG-EDD016', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD016-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20255,TRANSFORMER,500KVA,25KV', N'OS1-P029-UPGD-SEG-EDD016-SEG-PT0051', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'UPGRADING  MILLENNIUM MAINTENANCE BLDG', N'OS1-P029-UPGD-SEG-EDD017', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD017-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD017-SEG-PL3040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20582,TRANSFORMER,500KVA,25KV', N'OS1-P029-UPGD-SEG-EDD017-SEG-PT0060', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-UPGD-SEG-EDD021', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P029-UPGD-SEG-EDD021-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22687,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1800T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22672,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1801', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22670,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1802', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22669,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1803', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22668,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1804', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22689,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1901', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22691,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1902', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22692,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1903', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22693,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD021-SEG-352_1904', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3084', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3097', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3098', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3099', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21704,CABLE,3 PH FEEDER TO 29PT-90', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3_125', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21705,CABLE,3 PH FEEDER TO 29PT-88', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3_126', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21706,CABLE,3 PH FEEDER TO 29PT-89', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3_127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21707,CABLE,3 PH FEEDER TO 29PT-91', N'OS1-P029-UPGD-SEG-EDD021-SEG-PL3_128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20128,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20129,BUSBAR,METALCLAD_AIR,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22686,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP18_BUS_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22671,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP18_LINEPT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22690,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP19_BUS_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22688,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD021-SEG-PP19_LINEPT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EHT TRANSFORMER SUBSTATION', N'OS1-P029-UPGD-SEG-EDD023', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD023-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20212,TRANSFORMER,2.25/3.45MVA,25KV', N'OS1-P029-UPGD-SEG-EDD023-SEG-PT0055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SULPHUR PLANT EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD024', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD024-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20211,TRANSFORMER,1.5/2.5MVA,25KV', N'OS1-P029-UPGD-SEG-EDD024-SEG-PT0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'GOHT EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD025', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD025-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20256,TRANSFORMER,1.5/2.5MVA,25KV', N'OS1-P029-UPGD-SEG-EDD025-SEG-PT0052', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NHT EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD026', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD026-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20253,TRANSFORMER,1.5/2.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD026-SEG-PT0053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DHT EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD027', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD027-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20252,TRANSFORMER,1.5/2.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD027-SEG-PT0054', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NORTH SOUTH PIPERACK EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD028', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD028-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20249,TRANSFORMER,1.5/2.5MVA,25KV', N'OS1-P029-UPGD-SEG-EDD028-SEG-PT0057', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'WILD ROSE EHT BLDG SUBSTATION', N'OS1-P029-UPGD-SEG-EDD029', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD029-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20251,TRANSFORMER,1.5/2.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD029-SEG-PT0058', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'25KV SUBSTATION FOR 29PT-59', N'OS1-P029-UPGD-SEG-EDD030', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD030-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20247,TRANSFORMER,1.5/2.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD030-SEG-PT0059', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION 56-6', N'OS1-P029-UPGD-SEG-EDD057', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD057-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0135', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0136', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0137', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0138', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0139', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD057-SEG-PT0140', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION 56-7', N'OS1-P029-UPGD-SEG-EDD058', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD058-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20585,TRANSFORMER,7.5/11.2MVA,25KV', N'OS1-P029-UPGD-SEG-EDD058-SEG-PT0141', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20586,TRANSFORMER,7.5/11.2MVA,25KV', N'OS1-P029-UPGD-SEG-EDD058-SEG-PT0142', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD058-SEG-PT0143', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD058-SEG-PT0144', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD058-SEG-PT0145', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION 56-8', N'OS1-P029-UPGD-SEG-EDD059', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD059-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD059-SEG-PT0146', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD059-SEG-PT0147', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD059-SEG-PT0148', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD059-SEG-PT0149', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD059-SEG-PT0150', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION 56-10', N'OS1-P029-UPGD-SEG-EDD061', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD061-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD061-SEG-PT0156', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD061-SEG-PT0157', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD061-SEG-PT0158', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD061-SEG-PT0159', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P029-UPGD-SEG-EDD061-SEG-PT0160', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENNIUM NAPTHA UPGRADING DISTRIBUTION', N'OS1-P029-UPGD-SEG-EDD069', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P029-UPGD-SEG-EDD069-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22679,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4300T', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22677,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4301', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22675,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4302', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22674,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4303', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22673,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4304', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22681,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4401', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22683,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4402', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22684,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4403', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22685,VACUUM INDOOR,27KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-352_4404', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22700,DIST PANEL, DC, 0.125kV, 225A', N'OS1-P029-UPGD-SEG-EDD069-SEG-56PA0504', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22676,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL155_L1_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22680,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL158_L2_PT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20491,CABLE,3PH FEEDER TO 29PT-218', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_161', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20492,CABLE,3PH FEEDER TO 29PT-216', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_162', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20493,CABLE,3PH FEEDER TO 29PT-299', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_163', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20494,CABLE,3PH FEEDER TO 29PT-300', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20495,CABLE,3PH FEEDER TO 29PT-217', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_165', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20496,CABLE,3PH FEEDER TO 29PT-301', N'OS1-P029-UPGD-SEG-EDD069-SEG-PL3_168', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22699,BUSBAR,METALCLAD_AIR,25KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-PP0043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22678,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PP0043BUSPT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22696,BUSBAR,METALCLAD_AIR,25KV,1200A', N'OS1-P029-UPGD-SEG-EDD069-SEG-PP0044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22682,TRANSFORMER,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PP0044BUSPT', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22782,TRANSFORMER,7.5/11.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0216', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22781,TRANSFORMER,7.5/11.3MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0217', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22783,TRANSFORMER,1.5/2MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0218', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22780,TRANSFORMER,10MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0299', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22778,TRANSFORMER,10MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0300', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20500,TRANSFORMER1.5MVA,25KV', N'OS1-P029-UPGD-SEG-EDD069-SEG-PT0301', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-UPGD-SEG-EDD084', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD084-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20914, TRANSFORMER, 8/10MVA,72KV', N'OS1-P029-UPGD-SEG-EDD084-SEG-PT0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-UPGD-SEG-EDD095', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD095-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21401, TRANSFORMER, 2.5/3.45MVA,25KV', N'OS1-P029-UPGD-SEG-EDD095-SEG-PT0134', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUBSTATION', N'OS1-P029-UPGD-SEG-EDD133', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P029-UPGD-SEG-EDD133-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20286, TRANSFORMER, 10MVA,25KV', N'OS1-P029-UPGD-SEG-EDD133-SEG-PT0175', 0, 0, 7, 1000, N'en');
COMMIT TRANSACTION
GO
BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSMISSION AND DISTRIBUTION 13.8KV', N'OS1-P030', 0, 0, 2, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CENTRAL SERVICES DISTRIBUTION', N'OS1-P030-CENT', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TOP SHOP AREA SUBSTATION', N'OS1-P030-CENT-SEG-EDD017', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD017-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 6900/398OV', N'OS1-P030-CENT-SEG-EDD017-SEG-02PT0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 120/240V', N'OS1-P030-CENT-SEG-EDD017-SEG-02PT0093', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 30PF-21', N'OS1-P030-CENT-SEG-EDD017-SEG-PL2024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE - 6.9KV TOPSHOP AREA', N'OS1-P030-CENT-SEG-EDD017-SEG-PL2047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-29 OR 31', N'OS1-P030-CENT-SEG-EDD017-SEG-PL2130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-003', N'OS1-P030-CENT-SEG-EDD017-SEG-PL2131', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-CENT-SEG-EDD017-SEG-PS0028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-CENT-SEG-EDD017-SEG-PS0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-CENT-SEG-EDD017-SEG-PS0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-CENT-SEG-EDD017-SEG-PS0031', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EDD COMPLEX SUBSTATION', N'OS1-P030-CENT-SEG-EDD020', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD020-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20801,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-CENT-SEG-EDD020-SEG-PT0053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 120/208V', N'OS1-P030-CENT-SEG-EDD020-SEG-PT0075', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CMD SERVICES NORTH OF CMD SUBSTATION', N'OS1-P030-CENT-SEG-EDD028', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD028-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-2303', N'OS1-P030-CENT-SEG-EDD028-SEG-PL2022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2302', N'OS1-P030-CENT-SEG-EDD028-SEG-PL2114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2301', N'OS1-P030-CENT-SEG-EDD028-SEG-PL2115', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-2305', N'OS1-P030-CENT-SEG-EDD028-SEG-PL2204', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20838,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-CENT-SEG-EDD028-SEG-PT0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CAMP AND CAMP FACILITIES SUBSTATION', N'OS1-P030-CENT-SEG-EDD029', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD029-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3603', N'OS1-P030-CENT-SEG-EDD029-SEG-PL2116', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3604', N'OS1-P030-CENT-SEG-EDD029-SEG-PL2117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3605 13.8', N'OS1-P030-CENT-SEG-EDD029-SEG-PL2186', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 4160V', N'OS1-P030-CENT-SEG-EDD029-SEG-PT0031', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NORTH EAST ADMINISTRATION SUBSTATION', N'OS1-P030-CENT-SEG-EDD038', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD038-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20588,TRANSFORMER,1.5/2MVA,13.8KV', N'OS1-P030-CENT-SEG-EDD038-SEG-PT0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'HILTON SUBSTATION', N'OS1-P030-CENT-SEG-EDD043', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD043-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20204,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-CENT-SEG-EDD043-SEG-PT0051', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'U.O.B. UPGRADING OFFICE BUILDING', N'OS1-P030-CENT-SEG-EDD066', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-CENT-SEG-EDD066-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20254,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-CENT-SEG-EDD066-SEG-PT0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ENERGY SERVICES DISTRIBUTION', N'OS1-P030-ESDI', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'REACTOR HOUSE / PLT 36 MAIN SUBSTATION', N'OS1-P030-ESDI-SEG-EDD005', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-ESDI-SEG-EDD005-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1308', N'OS1-P030-ESDI-SEG-EDD005-SEG-PL2087', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1309', N'OS1-P030-ESDI-SEG-EDD005-SEG-PL2088', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1301', N'OS1-P030-ESDI-SEG-EDD005-SEG-PL2089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1302', N'OS1-P030-ESDI-SEG-EDD005-SEG-PL2090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ENERGY SERVICES 2.4 KV SUBSTATION', N'OS1-P030-ESDI-SEG-EDD011', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD011-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20283,TRANSFORMER,7.5/10MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD011-SEG-31PTX0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20901,TRANSFORMER,7.5/10MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD011-SEG-31PTX0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CAPACITOR BANK 13.8 KV 8.464 MVAR', N'OS1-P030-ESDI-SEG-EDD011-SEG-PK0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CAPACITOR BANK 13.8 KV 8.464 MVAR', N'OS1-P030-ESDI-SEG-EDD011-SEG-PK0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'AUXILLARY STEAM (PLT 35) SUBSTATION', N'OS1-P030-ESDI-SEG-EDD016', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD016-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-ESDI-SEG-EDD016-SEG-31PT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-ESDI-SEG-EDD016-SEG-31PT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-9401', N'OS1-P030-ESDI-SEG-EDD016-SEG-PL2044', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-41', N'OS1-P030-ESDI-SEG-EDD016-SEG-PL2078', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-42', N'OS1-P030-ESDI-SEG-EDD016-SEG-PL2079', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20217,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD016-SEG-PT0178', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'LOW LIFT PUMPHOUSE SUBSTATION', N'OS1-P030-ESDI-SEG-EDD032', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD032-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-ESDI-SEG-EDD032-SEG-33PT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-3301', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-3300', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FROM SWITCH 289-3301', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2034', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3304', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3301', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2119', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED TO 30PT-13', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2182', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3305', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2194', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-ESDI-SEG-EDD032-SEG-PL2306', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20282,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD032-SEG-PT0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20300,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD032-SEG-PT0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KVA TO 480V', N'OS1-P030-ESDI-SEG-EDD032-SEG-PT0033', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'RIVER WATER PUMPHOUSE SUBSTATION', N'OS1-P030-ESDI-SEG-EDD033', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD033-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20928,TRANSFORMER,2.5/3.325MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD033-SEG-PT0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20927,TRANSFORMER,2.5/3.325MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD033-SEG-PT0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NORTH PRECIP.4TH FLR OF ES SUBSTATION', N'OS1-P030-ESDI-SEG-EDD041', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD041-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20930,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD041-SEG-36PT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20929,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD041-SEG-36PT0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SOUTH PRECIP. 4TH FLOOR OF ES SUBSTATION', N'OS1-P030-ESDI-SEG-EDD042', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD042-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20920,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD042-SEG-36PT0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20919,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD042-SEG-36PT0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ES 480V AUXILIARY SERVICES SUBSTATION', N'OS1-P030-ESDI-SEG-EDD044', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD044-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20288,TRANSFORMER,1.5/2.24MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD044-SEG-31PTX0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20911,TRANSFORMER,1.5/2.24MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD044-SEG-31PTX0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20912,TRANSFORMER,1.5/2.24MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD044-SEG-31PTX0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20902,TRANSFORMER,1.5/2.24MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD044-SEG-31PTX0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PLANT 35 SUBSTATION', N'OS1-P030-ESDI-SEG-EDD096', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD096-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8302', N'OS1-P030-ESDI-SEG-EDD096-SEG-PL2217', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8301', N'OS1-P030-ESDI-SEG-EDD096-SEG-PL2218', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-ESDI-SEG-EDD096-SEG-PL2260', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21412,TRANSFORMER,3/4MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD096-SEG-PT0093', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FLUE GAS DESULPHURIZATION PLT SUBSTATION', N'OS1-P030-ESDI-SEG-EDD097', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD097-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7702', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2175', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7703', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2176', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7705', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2177', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7802', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2178', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7803', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2179', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7704', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2180', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7804', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2181', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PL2278', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20570,TRANSFORMER,2/2.7/3.3MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PT0096', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20569,TRANSFORMER,2/2.7/3.3MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PT0097', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20572,TRANSFORMER,5/6.6/8.3MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PT0098', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20571,TRANSFORMER,5/6.6/8.3MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PT0099', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20573,TRANSFORMER,4.5MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD097-SEG-PT0100', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NEW WATER TREATMENT PLANT SUBSTATION', N'OS1-P030-ESDI-SEG-EDD115', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD115-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCHGEAR DISTRIBUTION', N'OS1-P030-ESDI-SEG-EDD115-SEG-PP0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20926,TRANSFORMER,2/2.67MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD115-SEG-PT0101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20925,TRANSFORMER,2/2.67MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD115-SEG-PT0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'COOLING TOWER SUBSTATION', N'OS1-P030-ESDI-SEG-EDD117', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD117-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-9402', N'OS1-P030-ESDI-SEG-EDD117-SEG-PL2193', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20260,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD117-SEG-PT0139', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'13.8KV SUBSTATION FOR 30PT-194', N'OS1-P030-ESDI-SEG-EDD139', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD139-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20830,TRANSFORMER,3.75/5.6MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD139-SEG-PT0194', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENNIUM PUMPHOUSE #2', N'OS1-P030-ESDI-SEG-EDD148', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-ESDI-SEG-EDD148-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20924,TRANSFORMER,12/16/20MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD148-SEG-PT0160', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20923,TRANSFORMER,12/16/20MVA,13.8KV', N'OS1-P030-ESDI-SEG-EDD148-SEG-PT0161', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION DISTRIBUTION', N'OS1-P030-EXTD', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION MAIN SUBSTATION', N'OS1-P030-EXTD-SEG-EDD004', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD004-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 6900/3980V', N'OS1-P030-EXTD-SEG-EDD004-SEG-02PT0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 4 MVA 13.8 KV TO 6900V', N'OS1-P030-EXTD-SEG-EDD004-SEG-02PT0049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 3.5MVA 13.8KV TO 4.16V', N'OS1-P030-EXTD-SEG-EDD004-SEG-02PT0050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P030-EXTD-SEG-EDD004-SEG-PB0027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P030-EXTD-SEG-EDD004-SEG-PB0028A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P030-EXTD-SEG-EDD004-SEG-PB0028B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-014', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-024', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-6', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2067', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2070', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-013', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2074', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-023', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2076', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-011', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2195', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-021', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2197', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2280', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD004-SEG-PL2292', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FINAL TAILINGS PUMPHOUSE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD006', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD006-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-402', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-405', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2081', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-404', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-401', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-302', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2084', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-303', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2085', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-304', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2086', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8604', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2187', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8603', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2188', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8602', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2189', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8702', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2190', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8703', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2191', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-8704', N'OS1-P030-EXTD-SEG-EDD006-SEG-PL2192', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20266,TRANSFORMER,6/8MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20279,TRANSFORMER,6/8MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20280,TRANSFORMER,6/8MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20270,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20267,TRANSFORMER,4MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20268,TRANSFORMER,4MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20272,TRANSFORMER,6/8MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0022', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20271,TRANSFORMER,6/8MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20269,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20278,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0116', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20277,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20281,TRANSFORMER,5/5.67MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD006-SEG-PTX0169', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION PLANT 4 SUBSTATION', N'OS1-P030-EXTD-SEG-EDD007', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD007-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20840,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-16PT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P030-EXTD-SEG-EDD007-SEG-PB0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-034', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-024', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2108', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-025', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2109', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-026', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-030', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-031', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2112', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-032', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2113', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-035', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2166', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-023', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2219', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-033', N'OS1-P030-EXTD-SEG-EDD007-SEG-PL2220', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20207,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20208,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20209,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20214,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20215,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20839,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20216,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20205,TRANSFORMER,50/66/83MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20206,TRANSFORMER,5/7.5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD007-SEG-PT0111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PLANT 3 SWITCH HOUSE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD008', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD008-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20896,TRANSFORMER,3.75/5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20898,TRANSFORMER,3.75/5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20891,TRANSFORMER,3.75/5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20895,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20894,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20899,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20900,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20890,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20897,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20892,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20893,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD008-SEG-03PTX0019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-505', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2091', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-504', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2092', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-503', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2093', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-502', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2094', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-602', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2095', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-603', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2096', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-604', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2097', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-605', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2098', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-606', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2099', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-607', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2100', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-608', N'OS1-P030-EXTD-SEG-EDD008-SEG-PL2101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POND 2 BARGE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD023', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD023-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE SWITCH ISOLATING', N'OS1-P030-EXTD-SEG-EDD023-SEG-02PS0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE SWITCH FOR BARGE 2', N'OS1-P030-EXTD-SEG-EDD023-SEG-02PS0017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20836,TRANSFORMER,6MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD023-SEG-02PT0073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-7601', N'OS1-P030-EXTD-SEG-EDD023-SEG-PL2155', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 2PS-14', N'OS1-P030-EXTD-SEG-EDD023-SEG-PL2167', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD023-SEG-PL2307', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD023-SEG-PL2308', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21410,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD023-SEG-PT0154', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'GYPSUM BARGE AND POND 5 BARGE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD024', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD024-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20803,TRANSFORMER,5MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD024-SEG-02PT0083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-126', N'OS1-P030-EXTD-SEG-EDD024-SEG-PL2165', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-127', N'OS1-P030-EXTD-SEG-EDD024-SEG-PL2172', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD024-SEG-PS0126', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD024-SEG-PS0127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD024-SEG-PS0128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20802,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD024-SEG-PT0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'GYPSUM BARGE AND POND 5 BARGE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD025', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD025-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20298,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD025-SEG-02PT0103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-100', N'OS1-P030-EXTD-SEG-EDD025-SEG-PL2164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD025-SEG-PS0100', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EMERGENCY POND SUBSTATION', N'OS1-P030-EXTD-SEG-EDD031', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD031-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE SWITCH FOR DYKE DRAINAGE', N'OS1-P030-EXTD-SEG-EDD031-SEG-02PS0004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20835,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD031-SEG-03PT0035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-109', N'OS1-P030-EXTD-SEG-EDD031-SEG-PL2183', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD031-SEG-PS0109', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'2DL09/11 TAKE OFF STRUCTURE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD055', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD055-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 150 KVA 13.8 KV TO 480/277V', N'OS1-P030-EXTD-SEG-EDD055-SEG-02PT0102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-134', N'OS1-P030-EXTD-SEG-EDD055-SEG-PL2156', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SEEPAGE PUMPHOUSE TRANSFORMER SUBSTATION', N'OS1-P030-EXTD-SEG-EDD056', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD056-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 75 KVA 13.8 KV TO 480/120V', N'OS1-P030-EXTD-SEG-EDD056-SEG-02PT0112', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21087,TRANSFORMER,300KVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD056-SEG-PT0169', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BOOSTER PUMPHOUSE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD057', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD057-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1802', N'OS1-P030-EXTD-SEG-EDD057-SEG-PL2162', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-1801', N'OS1-P030-EXTD-SEG-EDD057-SEG-PL2163', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8KV - 2.4 KV', N'OS1-P030-EXTD-SEG-EDD057-SEG-PT0078A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE FAB SHOP TRANSFORMER SUBSTATION', N'OS1-P030-EXTD-SEG-EDD058', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD058-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-EXTD-SEG-EDD058-SEG-03PT0077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE 8 DEWATERING PUMPHOUSE SUBSTATION', N'OS1-P030-EXTD-SEG-EDD098', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD098-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 1.5 MVA 13.8 KV TO 2400V', N'OS1-P030-EXTD-SEG-EDD098-SEG-02PT0113', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2000 KVA 13.8 KV - 480/277V', N'OS1-P030-EXTD-SEG-EDD098-SEG-03PT0082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 30PS-113', N'OS1-P030-EXTD-SEG-EDD098-SEG-PL2033', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD098-SEG-PS0114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SOUTH LINE UNIT SUBSTATION', N'OS1-P030-EXTD-SEG-EDD102', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD102-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH POWER', N'OS1-P030-EXTD-SEG-EDD102-SEG-PS0116', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER  13.8 KV / 480V/277V', N'OS1-P030-EXTD-SEG-EDD102-SEG-PT0155', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DOUGLAS COATINGS COMPLEX', N'OS1-P030-EXTD-SEG-EDD130', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD130-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8KV TO 120/240V', N'OS1-P030-EXTD-SEG-EDD130-SEG-PT0171', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FROTH TREATMENT PLANT', N'OS1-P030-EXTD-SEG-EDD133', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-EXTD-SEG-EDD133-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BATTERY', N'OS1-P030-EXTD-SEG-EDD133-SEG-PB0025', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PL2273', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PL2274', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PL2275', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PL2276', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20578,TRANSFORMER,5/6.67MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PT0175', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20579,TRANSFORMER,5/6.67MVA,13.8KV', N'OS1-P030-EXTD-SEG-EDD133-SEG-PT0176', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG DISTRIBUTION', N'OS1-P030-FRBG', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-FRBG-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG CO-GENERATION BUILDING SUPPLY', N'OS1-P030-FRBG-SEG-EDD240', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P030-FRBG-SEG-EDD240-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21370,VACUUM INDOOR,15KV,5000A', N'OS1-P030-FRBG-SEG-EDD240-SEG-252_12101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,METAL CLAD AIR,13.8KV,5000A', N'OS1-P030-FRBG-SEG-EDD240-SEG-PP0121', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21371,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD240-SEG-PP0121_VT_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21372,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD240-SEG-PP0121_VT_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21373,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD240-SEG-PP0121_VT_4', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG CO-GENERATION BUILDING SUPPLY', N'OS1-P030-FRBG-SEG-EDD241', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P030-FRBG-SEG-EDD241-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21366,VACUUM INDOOR,15KV,5000A', N'OS1-P030-FRBG-SEG-EDD241-SEG-252_12201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUSBAR,METAL CLAD AIR,13.8KV,5000A', N'OS1-P030-FRBG-SEG-EDD241-SEG-PP0122', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21367,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD241-SEG-PP0122_VT_1', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21368,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD241-SEG-PP0122_VT_2', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21369,TRANSFORMER,95KV', N'OS1-P030-FRBG-SEG-EDD241-SEG-PP0122_VT_4', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREBAG CO-GENERATION BUILDING SUPPLY', N'OS1-P030-FRBG-SEG-EDD244', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY', N'OS1-P030-FRBG-SEG-EDD244-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,13.8KV,600A', N'OS1-P030-FRBG-SEG-EDD244-SEG-PS0180', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH,GANG MANUAL,13.8KV,600A', N'OS1-P030-FRBG-SEG-EDD244-SEG-PS0181', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22297,TRANSFORMER,13.8KV,6MVA', N'OS1-P030-FRBG-SEG-EDD244-SEG-PT0252', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'22298,TRANSFORMER,13.8KV,6MVA', N'OS1-P030-FRBG-SEG-EDD244-SEG-PT0253', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'INFRASTRUCTURE', N'OS1-P030-IFST', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BUILDING,FIXTURE & HVAC', N'OS1-P030-IFST-SAB', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'HORSESHOE SUBSTATION 30EDD3 BUILDING', N'OS1-P030-IFST-SAB-RA0010', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIRE PROTECTION & DETECTION', N'OS1-P030-IFST-SAB-RA0010-SSF', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PANEL FALRM HORSESHOE SUBSTATION 30EDD3', N'OS1-P030-IFST-SAB-RA0010-SSF-33PJ0554', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SUNCOR MAIN DISTRIBUTION', N'OS1-P030-MAIN', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MAIN-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK SUBSTATION (APL SUB)', N'OS1-P030-MAIN-SEG-EDD001', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MAIN-SEG-EDD001-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV FEEDER FROM 30EDD-1 TO 30EDD-200', N'OS1-P030-MAIN-SEG-EDD001-SEG-29PL6001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV FEEDER FROM 30EDD-1 TO 30EDD-200', N'OS1-P030-MAIN-SEG-EDD001-SEG-29PL6002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 621T', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 622T', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-702', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-705', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-802', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-805', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-707', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2045', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-807', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2046', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 623T', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 624T', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2049', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-703', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2052', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-704', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2053', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-706', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2054', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-803', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2055', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-804', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-806', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2057', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-708', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-808', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2075', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-MAIN-SEG-EDD001-SEG-PL2269', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 6D SUBSTATION', N'OS1-P030-MAIN-SEG-EDD002', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MAIN-SEG-EDD002-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-221', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-121', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-134', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-234', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-227', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2032', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-222', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-125', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-228', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2058', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-235', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2059', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-232', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2060', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-233', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2061', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-129', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2062', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-133', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2063', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-132', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2064', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-128', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2065', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-135', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2066', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-126', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-226', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2080', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-231', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2133', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-131', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2134', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-127', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2173', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-136', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2185', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-122', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2221', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-225', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2222', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-137', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2229', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-237', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2230', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'13.8KV POWER LINE', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2253', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'13.8KV POWER LINE', N'OS1-P030-MAIN-SEG-EDD002-SEG-PL2254', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE DISTRIBUTION', N'OS1-P030-MINE', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'HORSESHOE SUBSTATION', N'OS1-P030-MINE-SEG-EDD003', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD003-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P030-MINE-SEG-EDD003-SEG-29PL6008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P030-MINE-SEG-EDD003-SEG-29PL6009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-401 D1', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2003', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-402 D1', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2004', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-403', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2005', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-503', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2006', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-404', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-504', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 30PS-78', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-401', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2050', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-501', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2051', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-MINE-SEG-EDD003-SEG-PL2298', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE DRAINAGE NORTH SUBSTATION', N'OS1-P030-MINE-SEG-EDD034', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD034-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD034-SEG-02PT0013A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD034-SEG-02PT0013B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD034-SEG-02PT0013C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE DRAINAGE SOUTH SUBSTATION', N'OS1-P030-MINE-SEG-EDD035', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD035-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD035-SEG-02PT0014A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD035-SEG-02PT0014B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD035-SEG-02PT0014C', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'COKE PILE DRAINAGE SUBSTATION', N'OS1-P030-MINE-SEG-EDD036', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD036-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 45 KVA 13.8 KV TO 480V', N'OS1-P030-MINE-SEG-EDD036-SEG-PT0056', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 6A WEST ADMIN SUBSTATION', N'OS1-P030-MINE-SEG-EDD045', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD045-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 3.7 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD045-SEG-02PT0086', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 3 MVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD045-SEG-02PT0087', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4602', N'OS1-P030-MINE-SEG-EDD045-SEG-PL2068', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4603', N'OS1-P030-MINE-SEG-EDD045-SEG-PL2069', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 7A SUBSTATION', N'OS1-P030-MINE-SEG-EDD046', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD046-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 4160/3750V', N'OS1-P030-MINE-SEG-EDD046-SEG-02PT0015', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD046-SEG-02PT0016', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4702', N'OS1-P030-MINE-SEG-EDD046-SEG-PL2071', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4703', N'OS1-P030-MINE-SEG-EDD046-SEG-PL2072', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE NE25 SUBSTATION', N'OS1-P030-MINE-SEG-EDD047', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD047-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-33 OR 35', N'OS1-P030-MINE-SEG-EDD047-SEG-PL2129', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE NE21 SUBSTATION', N'OS1-P030-MINE-SEG-EDD049', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD049-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-41 OR 43', N'OS1-P030-MINE-SEG-EDD049-SEG-PL2127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE 7 DEWATERING SUBSTATION', N'OS1-P030-MINE-SEG-EDD050', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD050-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-45 OR 47', N'OS1-P030-MINE-SEG-EDD050-SEG-PL2161', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'BULK EXPLOSIVE YARD SUBSTATION', N'OS1-P030-MINE-SEG-EDD052', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD052-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20264,TRANSFORMER,300KVA,13.8KV', N'OS1-P030-MINE-SEG-EDD052-SEG-02PT0095', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILLENIUM BATCH PLANT SUBSTATION', N'OS1-P030-MINE-SEG-EDD053', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD053-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-27', N'OS1-P030-MINE-SEG-EDD053-SEG-PL2132', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE NE23 SUBSTATION', N'OS1-P030-MINE-SEG-EDD054', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD054-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 25 KVA 13.8 KV TO 120/240V', N'OS1-P030-MINE-SEG-EDD054-SEG-02PT0096', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-37 OR 39', N'OS1-P030-MINE-SEG-EDD054-SEG-PL2128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'260KVA SUBSTATION', N'OS1-P030-MINE-SEG-EDD056', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD056-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20935,TRANSFORMER,135/180/225MVA,260KV', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0190', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20933,TRANSFORMER,135/180/225MVA,260KV', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0191', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0192', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0193', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0194', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0195', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0196', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0197', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0198', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD056-SEG-29PT0199', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE DEWATERING PUMP SUBSTATION', N'OS1-P030-MINE-SEG-EDD071', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD071-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-61', N'OS1-P030-MINE-SEG-EDD071-SEG-PL2126', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE CONVEYOR 6C/6D 7C/7D SUBSTATION', N'OS1-P030-MINE-SEG-EDD073', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-MINE-SEG-EDD073-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PF-29', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2120', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PF-30', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2121', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3403', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2122', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3402', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2123', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3502', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2124', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3503', N'OS1-P030-MINE-SEG-EDD073-SEG-PL2125', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'1023-PWR-EDD-MINE-U30EDD-76', N'OS1-P030-MINE-SEG-EDD076', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD076-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2.8 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD076-SEG-02PT0104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD076-SEG-02PT0105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4002', N'OS1-P030-MINE-SEG-EDD076-SEG-PL2136', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4003', N'OS1-P030-MINE-SEG-EDD076-SEG-PL2137', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 6D SUBSTATION', N'OS1-P030-MINE-SEG-EDD077', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD077-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD077-SEG-02PT0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER, 6D SUBSTATION', N'OS1-P030-MINE-SEG-EDD077-SEG-02PT0107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4102', N'OS1-P030-MINE-SEG-EDD077-SEG-PL2138', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4103', N'OS1-P030-MINE-SEG-EDD077-SEG-PL2139', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4104', N'OS1-P030-MINE-SEG-EDD077-SEG-PL2143', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 7D SUBSTATION', N'OS1-P030-MINE-SEG-EDD078', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD078-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD078-SEG-02PT0110', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD078-SEG-02PT0111', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4204', N'OS1-P030-MINE-SEG-EDD078-SEG-PL2140', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4202', N'OS1-P030-MINE-SEG-EDD078-SEG-PL2141', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4203', N'OS1-P030-MINE-SEG-EDD078-SEG-PL2142', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'CONVEYOR 7C SUBSTATION', N'OS1-P030-MINE-SEG-EDD079', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD079-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 1.8 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD079-SEG-02PT0108', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD079-SEG-02PT0109', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4302', N'OS1-P030-MINE-SEG-EDD079-SEG-PL2144', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4303', N'OS1-P030-MINE-SEG-EDD079-SEG-PL2145', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SIZER A (SOUTH) SUBSTATION', N'OS1-P030-MINE-SEG-EDD080', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD080-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2.2 MVA 13.8 KV TO 500V', N'OS1-P030-MINE-SEG-EDD080-SEG-02PT0119A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD080-SEG-02PT0120A', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4402', N'OS1-P030-MINE-SEG-EDD080-SEG-PL2146', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4403', N'OS1-P030-MINE-SEG-EDD080-SEG-PL2147', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SIZER B (NORTH) SUBSTATION', N'OS1-P030-MINE-SEG-EDD081', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD081-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2.2 MVA 13.8 KV TO 500V', N'OS1-P030-MINE-SEG-EDD081-SEG-02PT0119B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 2 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD081-SEG-02PT0120B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4502', N'OS1-P030-MINE-SEG-EDD081-SEG-PL2148', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4503', N'OS1-P030-MINE-SEG-EDD081-SEG-PL2149', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE NE 03 SUBSTATION (2DL27 TAKEOFF)', N'OS1-P030-MINE-SEG-EDD083', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD083-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20913,TRANSFORMER,8/10MVA,72KV', N'OS1-P030-MINE-SEG-EDD083-SEG-29PT0067', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE STRUCT NEW14A SUB-OLD LUB ISLAND', N'OS1-P030-MINE-SEG-EDD084', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD084-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 225 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD084-SEG-02PT0125', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'1023-PWR-EDD-MINE-U30EDD-87', N'OS1-P030-MINE-SEG-EDD087', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD087-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8 KV TO 4.16KV', N'OS1-P030-MINE-SEG-EDD087-SEG-02PT0088', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD087-SEG-02PT0089', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4802', N'OS1-P030-MINE-SEG-EDD087-SEG-PL2159', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4803', N'OS1-P030-MINE-SEG-EDD087-SEG-PL2160', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'7B HEAD STATION SUBSTATION', N'OS1-P030-MINE-SEG-EDD088', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD088-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 5 MVA 13.8 KV TO 4160V', N'OS1-P030-MINE-SEG-EDD088-SEG-02PT0090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD088-SEG-02PT0091', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4902', N'OS1-P030-MINE-SEG-EDD088-SEG-PL2157', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-4903', N'OS1-P030-MINE-SEG-EDD088-SEG-PL2158', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'LUBE ISLAND SUBSTATION', N'OS1-P030-MINE-SEG-EDD091', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD091-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 500 KVA 13.8 KV TO 480/277V', N'OS1-P030-MINE-SEG-EDD091-SEG-02PT0118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-101', N'OS1-P030-MINE-SEG-EDD091-SEG-PL2184', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIREWATER PUMPHOUSE SUBSTATION', N'OS1-P030-MINE-SEG-EDD092', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD092-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-107', N'OS1-P030-MINE-SEG-EDD092-SEG-PL2168', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20262,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-MINE-SEG-EDD092-SEG-PT0090', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DEWATERING PUMP 2GM-303 SUBSTATION', N'OS1-P030-MINE-SEG-EDD105', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD105-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 1.5 MVA 13.8 KV - 4160/2400V', N'OS1-P030-MINE-SEG-EDD105-SEG-02PT0114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DYKE DRAINAGE SUBSTATION', N'OS1-P030-MINE-SEG-EDD106', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD106-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21081,TRANSFORMER,15KVA,13.8KV', N'OS1-P030-MINE-SEG-EDD106-SEG-PT0107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SHOVELS 40G & 41G SUBSTATION', N'OS1-P030-MINE-SEG-EDD109', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD109-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-MINE-SEG-EDD109-SEG-02PT0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE OPS DRAINAGE SHOP SUBSTATION', N'OS1-P030-MINE-SEG-EDD110', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD110-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21083,TRANSFORMER,150KVA,6.9KV', N'OS1-P030-MINE-SEG-EDD110-SEG-02PT0101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MICROWAVE TOWER SUBSTATION', N'OS1-P030-MINE-SEG-EDD111', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD111-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 10 KVA 6900V TO 120/240V', N'OS1-P030-MINE-SEG-EDD111-SEG-02PT0098', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'FIRE WTR. RES.-OVERBURDEN SUBSTATION', N'OS1-P030-MINE-SEG-EDD112', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD112-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21061,TRANSFORMER,150KVA,6.9KV', N'OS1-P030-MINE-SEG-EDD112-SEG-02PT0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20210,TRANSFORMER,300KVA,6.9KV', N'OS1-P030-MINE-SEG-EDD112-SEG-02PT0128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MINE MAINTENANCE COMPLEX SUBSTATION', N'OS1-P030-MINE-SEG-EDD114', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD114-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20274,TRANSFORMER,500KVA,6.9KV', N'OS1-P030-MINE-SEG-EDD114-SEG-02PT0129', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK  RADIO REC''R TWR SUBSTATION', N'OS1-P030-MINE-SEG-EDD118', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD118-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 25 KVA 13.8 KV TO 2240V', N'OS1-P030-MINE-SEG-EDD118-SEG-PT0165', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MILL. BATCH PLT LINE ISOL. SWITCH SUBSTN', N'OS1-P030-MINE-SEG-EDD132', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD132-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 750 KVA 13.8 KV TO 480V', N'OS1-P030-MINE-SEG-EDD132-SEG-PT0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 500 KVA 6.9KV / 480V / 277V', N'OS1-P030-MINE-SEG-EDD146', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-MINE-SEG-EDD146-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 500 KVA 6.9KV / 480V / 277V', N'OS1-P030-MINE-SEG-EDD146-SEG-02PT0156', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'OFFPLOTS DISTRIBUTION', N'OS1-P030-OFFP', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SOUTH TANK FARM REF SUBSTATION 8', N'OS1-P030-OFFP-SEG-EDD009', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD009-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD009-SEG-PL2267', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD009-SEG-PL2268', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20245,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD009-SEG-PT0028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20246,TRANSFORMER,1.5/2MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD009-SEG-PT0184', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'MAIN LINE PUMP NORTH TANK SUBSTATION', N'OS1-P030-OFFP-SEG-EDD012', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD012-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20983,TRANSFORMER,3.75MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD012-SEG-PT0061', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20984,TRANSFORMER,0.75/1MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD012-SEG-PT0062', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20981,TRANSFORMER,0.75/1MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD012-SEG-PT0063', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20982,TRANSFORMER,5.25MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD012-SEG-PT0114', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SOUTH TANK FARM REF SUBSTATION 6', N'OS1-P030-OFFP-SEG-EDD026', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD026-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-7102', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2028', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-7002', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-7005', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2031', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7003', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2169', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7004', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2170', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7103', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2171', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7104', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2174', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2265', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PL2266', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20964,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PT0036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20967,TRANSFORMER,1.5MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PT0037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20295,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PT0077', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20287,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD026-SEG-PT0078', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NORTH TANK FARM SUBSTATION', N'OS1-P030-OFFP-SEG-EDD027', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD027-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-2804', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2020', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-2604', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2021', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2802', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2803', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2602', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2603', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2605', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-2606', N'OS1-P030-OFFP-SEG-EDD027-SEG-PL2135', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20587,TRANSFORMER,750KVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD027-SEG-PT0048', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'API SEPERATORS SUBSTATION', N'OS1-P030-OFFP-SEG-EDD030', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD030-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3901', N'OS1-P030-OFFP-SEG-EDD030-SEG-PL2150', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3902', N'OS1-P030-OFFP-SEG-EDD030-SEG-PL2151', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3903', N'OS1-P030-OFFP-SEG-EDD030-SEG-PL2152', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20299,TRANSFORMER,225KVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD030-SEG-PT0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20297,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD030-SEG-PT0042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20296,TRANSFORMER,1.25MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD030-SEG-PT0043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'COOLING WATER PUMPHOUSE SUBSTATION', N'OS1-P030-OFFP-SEG-EDD037', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD037-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-3703', N'OS1-P030-OFFP-SEG-EDD037-SEG-PL2029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3703', N'OS1-P030-OFFP-SEG-EDD037-SEG-PL2153', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-3701', N'OS1-P030-OFFP-SEG-EDD037-SEG-PL2154', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20261,TRANSFORMER,2.5/3.3MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD037-SEG-PT0041', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20263,TRANSFORMER,2.5/3.3MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD037-SEG-PT0073', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'API SEPARATORS MAIN SUBSTATION', N'OS1-P030-OFFP-SEG-EDD101', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-OFFP-SEG-EDD101-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 289-8402', N'OS1-P030-OFFP-SEG-EDD101-SEG-PL2035', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'NEW SOUTH TANK FARM', N'OS1-P030-OFFP-SEG-EDD134', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-OFFP-SEG-EDD134-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20932,TRANSFORMER,5/7.5MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD134-SEG-PT0182', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20931,TRANSFORMER,5/7.5MVA,13.8KV', N'OS1-P030-OFFP-SEG-EDD134-SEG-PT0183', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'13.8KV SUBSTATION,SOUTH TANK FARM', N'OS1-P030-OFFP-SEG-EDD140', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY & GENERATION', N'OS1-P030-OFFP-SEG-EDD140-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2283', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2284', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2285', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2286', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2288', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2289', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2290', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-OFFP-SEG-EDD140-SEG-PL2291', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'1.0MVA, 13.8KV/480V TRANSFORMER', N'OS1-P030-OFFP-SEG-EDD140-SEG-PT0262', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'1.0MVA, 13.8KV/480V TRANSFORMER', N'OS1-P030-OFFP-SEG-EDD140-SEG-PT0263', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK MINE DISTRIBUTION', N'OS1-P030-STMI', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ATHABASCA CROSSING SUBSTATION', N'OS1-P030-STMI-SEG-EDD200', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD200-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV FEEDER TO STEEPBANK SUBSTATION  (', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV FEEDER TO STEEPBANK SUBSTATION  (', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6017', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6018', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6019', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-29PL6027', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0009', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0010', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0011', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0012', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0013', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0014', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0023', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0024', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0026', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0029', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0030', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0037', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0038', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0039', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0041', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0061', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0069', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0070', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0085', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-29PS0108', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-STMI-SEG-EDD200-SEG-29PT0063', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-STMI-SEG-EDD200-SEG-29PT0064', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-STMI-SEG-EDD200-SEG-29PT0083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-STMI-SEG-EDD200-SEG-29PT0095', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8802', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2038', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8902', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2039', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8803', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2040', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8903', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2041', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8805', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2042', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION LINE FED FROM 252-8906', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2043', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PT-121', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2223', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PT-120', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2224', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8904', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2225', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8804', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2226', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8905', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2227', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8806', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2228', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PT-120', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2249', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PT-121', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2250', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2251', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2252', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2296', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PL2297', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV FEEDER TO STEEPBANK SUBSTATION  (', N'OS1-P030-STMI-SEG-EDD200-SEG-PL6001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV FEEDER TO STEEPBANK SUBSTATION  (', N'OS1-P030-STMI-SEG-EDD200-SEG-PL6002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72KV OVERHEAD POWER LINE', N'OS1-P030-STMI-SEG-EDD200-SEG-PL6036', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-PS9001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-PS9002', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-PS9101', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD200-SEG-PS9102', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20184,TRANSFORMER,30/40/50MVA,72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PT0120', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20918,TRANSFORMER,30/40/50MVA,72KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PT0121', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20954,TRANSFORMER,150KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PT0135', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20179,TRANSFORMER,150KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD200-SEG-PT0136', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ORE PREPARATION PLANT SUBSTATION', N'OS1-P030-STMI-SEG-EDD201', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD201-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9205', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2234', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9204', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2235', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9203', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2236', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9202', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2237', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9302', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2238', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9303', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2239', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9304', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2240', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9305', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2241', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-9306', N'OS1-P030-STMI-SEG-EDD201-SEG-PL2242', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD201-SEG-PS0146', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20965,TRANSFORMER,2MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0123', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20903,TRANSFORMER,3.75MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0125', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20905,TRANSFORMER,7.5MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0126', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20908,TRANSFORMER,8.265MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0127', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20909,TRANSFORMER,8.265MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0128', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20910,TRANSFORMER,8.265MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0129', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20904,TRANSFORMER,7.5MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20979,TRANSFORMER,3.75MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0131', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20966,TRANSFORMER,2MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD201-SEG-PT0132', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK HOT PROCESS WATER SUBSTATION', N'OS1-P030-STMI-SEG-EDD210', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD210-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20955,TRANSFORMER,7.5MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD210-SEG-PT0143', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20956,TRANSFORMER,7.5MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD210-SEG-PT0144', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'UNDERCARRIAGE WASH BUILDING SUBSTATION', N'OS1-P030-STMI-SEG-EDD211', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD211-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-129', N'OS1-P030-STMI-SEG-EDD211-SEG-PL2247', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-STMI-SEG-EDD211-SEG-PS0129', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21402,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD211-SEG-PT0149', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-130', N'OS1-P030-STMI-SEG-EDD212', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD212-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-130', N'OS1-P030-STMI-SEG-EDD212-SEG-PL2248', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-STMI-SEG-EDD212-SEG-PS0130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21403,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD212-SEG-PT0150', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK MINE COMPLEX SUBSTATION', N'OS1-P030-STMI-SEG-EDD213', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD213-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-132', N'OS1-P030-STMI-SEG-EDD213-SEG-PL2231', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-STMI-SEG-EDD213-SEG-PS0132', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21404,TRANSFORMER,2.5MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD213-SEG-PT0152', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK COLD STORAGE SHED SUBSTATION', N'OS1-P030-STMI-SEG-EDD214', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD214-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-131', N'OS1-P030-STMI-SEG-EDD214-SEG-PL2232', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-STMI-SEG-EDD214-SEG-PS0131', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21405,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD214-SEG-PT0151', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK WARMUP SHED SUBSTATION', N'OS1-P030-STMI-SEG-EDD215', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD215-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PS-133', N'OS1-P030-STMI-SEG-EDD215-SEG-PL2233', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POLE MOUNTED SWITCH', N'OS1-P030-STMI-SEG-EDD215-SEG-PS0133', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21406,TRANSFORMER,1MVA,13.8KV EDD249', N'OS1-P030-STMI-SEG-EDD215-SEG-PT0153', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK MINERAL SIZER SUBSTATION', N'OS1-P030-STMI-SEG-EDD216', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD216-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20770,TRANSFORMER,7.5/11.2MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD216-SEG-PT0122', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20769,TRANSFORMER,7.5/11.2MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD216-SEG-PT0124', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'EXTRACTION LINE 6 SUBSTATION', N'OS1-P030-STMI-SEG-EDD217', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD217-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-9502', N'OS1-P030-STMI-SEG-EDD217-SEG-PL2243', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-9503', N'OS1-P030-STMI-SEG-EDD217-SEG-PL2244', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-9504', N'OS1-P030-STMI-SEG-EDD217-SEG-PL2245', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 289-9602', N'OS1-P030-STMI-SEG-EDD217-SEG-PL2246', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD217-SEG-PL2295', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20977,TRANSFORMER,8/10MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD217-SEG-PT0145', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20976,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD217-SEG-PT0146', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20974,TRANSFORMER,1/1.33MVA,13.8KV', N'OS1-P030-STMI-SEG-EDD217-SEG-PT0147', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 3.75 MVA 13.8 KV TO 2400V', N'OS1-P030-STMI-SEG-EDD217-SEG-PT0148', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK 72KV SHOVEL SUBSTATION #1', N'OS1-P030-STMI-SEG-EDD218', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD218-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P030-STMI-SEG-EDD218-SEG-29PL3106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P030-STMI-SEG-EDD218-SEG-29PL3107', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 25KV', N'OS1-P030-STMI-SEG-EDD218-SEG-29PL3108', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'72 KV DISCONNECT SWITCH', N'OS1-P030-STMI-SEG-EDD218-SEG-29PS0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20768,TRANSFORMER,8/10MVA,72KV', N'OS1-P030-STMI-SEG-EDD218-SEG-29PT0001', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK 72KV SHOVEL SUBSTATION #2', N'OS1-P030-STMI-SEG-EDD219', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD219-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD219-SEG-29PS0008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK MINE POND F SERVICE SUBSTATION', N'OS1-P030-STMI-SEG-EDD220', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD220-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21067,TRANSFORMER,150KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD220-SEG-PT0164', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK LUB ISLAND FACILITY SUBSTATION', N'OS1-P030-STMI-SEG-EDD221', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD221-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 4 MVA 13.8 KV TO 6900V', N'OS1-P030-STMI-SEG-EDD221-SEG-02PT0130', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD221-SEG-PS0117', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD221-SEG-PS0118', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD221-SEG-PS0119', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21072,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD221-SEG-PT0134', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK BRIDGE LIGHTING SUBSTATION', N'OS1-P030-STMI-SEG-EDD224', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD224-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21073,TRANSFORMER,75KVA,13.8KV', N'OS1-P030-STMI-SEG-EDD224-SEG-PT0172', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'STEEPBANK SHOVEL ERECT SITE SUBSTATION', N'OS1-P030-STMI-SEG-EDD225', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-STMI-SEG-EDD225-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-STMI-SEG-EDD225-SEG-02PT0074', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER 300 KVA 13.8 KV TO 480/277V', N'OS1-P030-STMI-SEG-EDD225-SEG-02PT0094', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD225-SEG-PL2255', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD225-SEG-PL2256', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-STMI-SEG-EDD225-SEG-PL2281', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SWITCH', N'OS1-P030-STMI-SEG-EDD225-SEG-PS0140', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'TRANSFORMER', N'OS1-P030-STMI-SEG-EDD225-SEG-PT0195', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'21407,TRANSFORMER,2.5MVA,13.8KV-480V/277', N'OS1-P030-STMI-SEG-EDD225-SEG-PT0196', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'UPGRADING DISTRIBUTION', N'OS1-P030-UPGD', 0, 0, 3, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG', 0, 0, 4, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SATELITE BUILDING SUBSTATION', N'OS1-P030-UPGD-SEG-EDD040', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD040-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20837,TRANSFORMER,500KVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD040-SEG-PT0047', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'COMPRESSOR HOUSE SUBSTATION', N'OS1-P030-UPGD-SEG-EDD067', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD067-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20937,TRANSFORMER,5MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD067-SEG-PT0007', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20938,TRANSFORMER,5MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD067-SEG-PT0008', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'SEWAGE LAGOON SUBSTATION', N'OS1-P030-UPGD-SEG-EDD100', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD100-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 30PF-36', N'OS1-P030-UPGD-SEG-EDD100-SEG-PL2196', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20703,TRANSFORMER,300KVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD100-SEG-PT0103', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PLANT 25 SUBSTATION', N'OS1-P030-UPGD-SEG-EDD103', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD103-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8103', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2198', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8102', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2199', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8101', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2200', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8201', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2201', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8202', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2202', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-8203', N'OS1-P030-UPGD-SEG-EDD103-SEG-PL2203', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20706, TRANSFORMER CORRECTION: 30PT-108', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0010B', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20707,TRANSFORMER,2.5/3.3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0104', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20705,TRANSFORMER,2/2.6MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0105', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20706,TRANSFORMER,2.5/3.3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0106', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20704,TRANSFORMER,2/2.6MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0109', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20248,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0119', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20709,TRANSFORMER, DISTR, UPG PLANT 25', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0216', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20708,TRANSFORMER, DISTR, UPG PLANT 25', N'OS1-P030-UPGD-SEG-EDD103-SEG-PT0217', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'PLANT 10 SUBSTATION', N'OS1-P030-UPGD-SEG-EDD104', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD104-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7203', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2205', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7202', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2206', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7302', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2207', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7303', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2208', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7304', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2209', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7405', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2210', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7404', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2211', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7403', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2212', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7402', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2213', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7502', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2214', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7503', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2215', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'DISTRIBUTION FEED FROM 252-7504', N'OS1-P030-UPGD-SEG-EDD104-SEG-PL2216', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20989,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0079', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20980,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0080', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20988,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0081', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20978,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0082', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20971,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0083', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20968,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0084', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20972,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0085', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20969,TRANSFORMER,2/2.7/3MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0086', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20973,TRANSFORMER,3/4/4.47MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0091', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20970,TRANSFORMER,3/4/4.47MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD104-SEG-PT0092', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'13.8KV SUBSTATION FOR PLANT 9', N'OS1-P030-UPGD-SEG-EDD136', 0, 0, 5, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'ELECTRICAL SUPPLY AND GENERATION', N'OS1-P030-UPGD-SEG-EDD136-SEG', 0, 0, 6, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-UPGD-SEG-EDD136-SEG-PL2270', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-UPGD-SEG-EDD136-SEG-PL2271', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'POWER LINE FOR 13.8KV', N'OS1-P030-UPGD-SEG-EDD136-SEG-PL2272', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20773,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD136-SEG-PT0187', 0, 0, 7, 1000, N'en');
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture) VALUES (6, N'20772,TRANSFORMER,1MVA,13.8KV', N'OS1-P030-UPGD-SEG-EDD136-SEG-PT0188', 0, 0, 7, 1000, N'en');
COMMIT TRANSACTION
GO

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Id] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
GO

---------------------------------------------------------------------------------------------
DECLARE @SiteId bigint
SET @SiteId = 6
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
		AND [Level] = 3
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
WHERE SiteId = 6
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
   

-- Insert the Ancestor records for these Mississaugua Flocs
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

		
-- -- TDS functional areas
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,7)
GO

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (163, 'Dispatcher', 0, 'Dispatcher', 6, 0, 0, 0, 1, 'disp');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (164, 'Manager / Superintendent', 0, 'Manager', 6, 0, 0, 0, 1, 'manager');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (165, 'Engineer', 0, 'Engineer', 6, 0, 0, 0, 1, 'eng');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (166, 'Ops Coordinator', 0, 'OpsCoordinator', 6, 0, 0, 0, 1, 'coord');

SET IDENTITY_INSERT [Role] OFF;

UPDATE Role 
	SET WarnIfWorkAssignmentNotSelected = 1
WHERE 
	SiteId = 6
GO
	
-- clear out all existing role element templates and re-create them.
DELETE 
  dbo.RoleElementTemplate 
  FROM
  dbo.RoleElementTemplate ret
  INNER JOIN [Role] r on ret.RoleId = r.Id
  where r.SiteId = 6
GO
  
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Auto Approve SAP Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Business Categories';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Associate Business Categories To Functional Locations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Log Guidelines';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Summary Log Custom Fields';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Log Templates';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Shift Handover Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Edit Shift Handover E-mail Configurations';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Display Limits';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Work Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Default FLOCs for Assignments';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Default Tabs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Work Assignment Not Selected Warning';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Unc Paths for Links';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Priorities Page';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Area Labels';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Dispatcher' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Engineer' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Operator' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Ops Coordinator' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Read User' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Process SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Manage Operational Modes';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Configure Automatic Re-Approval by Field';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Technical Administrator' and re.[Name] = 'Configure Role Matrix';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Technical Administrator' and re.[Name] = 'Configure Role Permissions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 6 and r.[Name] = 'Technical Administrator' and re.[Name] = 'Configure Site';
GO

-- Role Permissions for Logs, Directives, Standing Orders, etc.  This does not include Action Items!  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Manager / Superintendent' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'Manager / Superintendent')

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'Supervisor')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Directives' and createRole.[Name]= 'Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Directives' and createRole.[Name]= 'Manager / Superintendent')
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 6 and createRole.[SiteId] = 6 and r.[Name] = 'Supervisor' and re.[Name] = 'Cancel Standing Orders' and createRole.[Name]= 'Manager / Superintendent')
GO

-- Default tabs cleanup, followed by new values.
DELETE 
  RoleDisplayConfiguration
FROM
  RoleDisplayConfiguration
inner join dbo.[Role] ON dbo.[Role].Id = dbo.RoleDisplayConfiguration.RoleId
where dbo.[Role].SiteId = 6
GO

-- Operator default Action Item tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 2, 3, null from Role where [Name]='Operator' and SiteId = 6)
-- Operator default Log tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 4, 8, 7 from Role where [Name]='Operator' and SiteId = 6)
-- Operator default Shift Handover tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 6, 18, 17 from Role where [Name]='Operator' and SiteId = 6)

-- Supervisor default Action Item tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 2, 2, null from Role where [Name]='Supervisor' and SiteId = 6)
-- Supervisor default Log tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 4, 10, null from Role where [Name]='Supervisor' and SiteId = 6)
-- Supervisor default Shift Handover tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 6, 18, 17 from Role where [Name]='Supervisor' and SiteId = 6)
  
-- Everyone but Operator and Supervisor default Action Item tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 2, 3, null from Role where [Name]!='Supervisor' and [Name] != 'Operator' and SiteId = 6)
-- Everyone but Operator and Supervisor default Log tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 4, 10, null from Role where [Name]!='Supervisor' and [Name] != 'Operator' and SiteId = 6)
-- Everyone but Operator and Supervisor default Shift Handover tab
INSERT INTO RoleDisplayConfiguration (RoleId,SectionId,PrimaryDefaultPageId,SecondaryDefaultPageId) 
  (SELECT Id, 6, 17, null from Role where [Name]!='Supervisor' and [Name] != 'Operator' and SiteId = 6)
GO

-- work Assignments
DELETE
  WorkAssignmentFunctionalLocation
FROM
  WorkAssignmentFunctionalLocation
  INNER JOIN WorkAssignment ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id
where
  workassignment.Siteid = 6
GO
  
DELETE
  WorkAssignment
WHERE
  SiteId = 6
GO
  
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Administrator', 'Administrator',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Administrator');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Firebag OM Technician', 'Firebag OM Technician',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Operator');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Oilsands OM Technician', 'Oilsands OM Technician',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Operator');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Firebag Protection Specialist', 'Firebag Protection Specialist',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Operator');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Oilsands Protection Specialist', 'Oilsands Protection Specialist',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Operator');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'SCC Operator', 'SCC Operator',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Dispatcher');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Firebag Shift Supervisor', 'Firebag Shift Supervisor',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Supervisor');
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Oilsands Shift Supervisor', 'Oilsands Shift Supervisor',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Supervisor');  
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Ops Coordinator', 'Ops Coordinator',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Ops Coordinator');    
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Ops Manager', 'Ops Manager',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Manager / Superintendent');      
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Process Engineer', 'Process Engineer',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Engineer');        
INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'Read-only', 'Read-only',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='Read User');          
GO

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Administrator' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and a.[name] = 'Firebag OM Technician' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy NOT IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and f.[Level] = 3 and a.[name] = 'Oilsands OM Technician' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and a.[name] = 'Firebag Protection Specialist' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy NOT IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and f.[Level] = 3 and a.[name] = 'Oilsands Protection Specialist' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'SCC Operator' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and a.[name] = 'Firebag Shift Supervisor' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy NOT IN ('OS1-P029-FRBG', 'OS1-P030-FRBG') and f.[Level] = 3 and a.[name] = 'Oilsands Shift Supervisor' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Ops Coordinator' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Ops Manager' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Process Engineer' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Reliability Engineer' and a.siteId = 6;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'Read-only' and a.siteId = 6;

INSERT INTO WorkAssignmentVisibilityGroup (
   VisibilityGroupId
  ,WorkAssignmentId
  ,VisibilityType
) SELECT vg.Id, wa.Id, 1 from VisibilityGroup vg, WorkAssignment wa where vg.SiteId = 6 and wa.SiteId = 6

INSERT INTO WorkAssignmentVisibilityGroup (
   VisibilityGroupId
  ,WorkAssignmentId
  ,VisibilityType
) SELECT vg.Id, wa.Id, 2 from VisibilityGroup vg, WorkAssignment wa where vg.SiteId = 6 and wa.SiteId = 6


INSERT INTO TargetDefinitionAutoReApprovalConfiguration (
   SiteId
  ,NameChange
  ,CategoryChange
  ,OperationalModeChange
  ,PriorityChange
  ,DescriptionChange
  ,DocumentLinksChange
  ,FunctionalLocationChange
  ,PHTagChange
  ,TargetDependenciesChange
  ,ScheduleChange
  ,GenerateActionItemChange
  ,RequiresResponseWhenAlertedChange
  ,SuppressAlertChange
) VALUES (
   6   -- SiteId - bigint
  ,1   -- NameChange - bit
  ,1   -- CategoryChange - bit
  ,1   -- OperationalModeChange - bit
  ,1   -- PriorityChange - bit
  ,1   -- DescriptionChange - bit
  ,1   -- DocumentLinksChange - bit
  ,1   -- FunctionalLocationChange - bit
  ,1   -- PHTagChange - bit
  ,1   -- TargetDependenciesChange - bit
  ,1   -- ScheduleChange - bit
  ,1   -- GenerateActionItemChange - bit
  ,1   -- RequiresResponseWhenAlertedChange - bit
  ,1   -- SuppressAlertChange - bit
)

INSERT INTO ActionItemDefinitionAutoReApprovalConfiguration (
   SiteId
  ,NameChange
  ,CategoryChange
  ,OperationalModeChange
  ,PriorityChange
  ,DescriptionChange
  ,DocumentLinksChange
  ,FunctionalLocationsChange
  ,TargetDependenciesChange
  ,ScheduleChange
  ,RequiresResponseWhenTriggeredChange
  ,AssignmentChange
  ,ActionItemGenerationModeChange
) VALUES (
   6   -- SiteId - bigint
  ,1   -- NameChange - bit
  ,1   -- CategoryChange - bit
  ,1   -- OperationalModeChange - bit
  ,1   -- PriorityChange - bit
  ,1   -- DescriptionChange - bit
  ,1   -- DocumentLinksChange - bit
  ,1   -- FunctionalLocationsChange - bit
  ,1   -- TargetDependenciesChange - bit
  ,1   -- ScheduleChange - bit
  ,1   -- RequiresResponseWhenTriggeredChange - bit
  ,1   -- AssignmentChange - bit
  ,1   -- ActionItemGenerationModeChange - bit
)

GO