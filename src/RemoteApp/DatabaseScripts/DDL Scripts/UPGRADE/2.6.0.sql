------------------
--- ActionItem ---
------------------
-- Convert all TEXT types in ActionItem table to VARCHAR(MAX)
ALTER TABLE [dbo].[ActionItem]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

-- set the name to 5o chars because it is 50 chars on the Definition
ALTER TABLE [dbo].[ActionItem]
	ALTER COLUMN [Name] VARCHAR(50) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE [dbo].[ActionItem]
	SET Description = Description
GO

ALTER INDEX [PK_ActionItem] ON [dbo].[ActionItem] 
	REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItem]') AND name = N'IDX_ActionItem_FunctionalLocation')
DROP INDEX [IDX_ActionItem_FunctionalLocation] ON [dbo].[ActionItem] WITH ( ONLINE = OFF )


IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItem]') AND name = N'IDX_ActionItem_LastModifiedUser')
DROP INDEX [IDX_ActionItem_LastModifiedUser] ON [dbo].[ActionItem] WITH ( ONLINE = OFF )

IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItem]') AND name = N'IDX_ActionItem_For_DTO')
CREATE NONCLUSTERED INDEX [IDX_ActionItem_For_DTO] ON [dbo].[ActionItem] 
(
	[FunctionalLocationID] ASC,
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[ActionItemStatusId] ASC,
	[LastModifiedUserId] ASC,
	[Deleted] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO


----------------------------
--- ActionItemDefinition ---
----------------------------
-- Convert all TEXT types in ActionItemDefinition table to VARCHAR(MAX)
ALTER TABLE [dbo].[ActionItemDefinition]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE [dbo].[ActionItemDefinition]
	SET Description = Description
GO

ALTER INDEX [PK_ActionItemDefinition] ON [dbo].[ActionItemDefinition] 
	REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_ActionItemDef_LastModifiedUser] ON [dbo].[ActionItemDefinition] 
	REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_ActionItemDef_Name] ON [dbo].[ActionItemDefinition] 
	REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_ActionItemDef_Schedule] ON [dbo].[ActionItemDefinition] 
	REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


-----------------------------------
--- ActionItemDefinitionHistory ---
-----------------------------------
-- Downsize LiveLinkDocumentLinks
ALTER TABLE [dbo].[ActionItemDefinitionHistory]
	ALTER COLUMN [LiveLinkDocumentLinks] VARCHAR(2000) NULL
GO
-- Downsize TargetDefinitions
ALTER TABLE [dbo].[ActionItemDefinitionHistory]
	ALTER COLUMN [TargetDefinitions] VARCHAR(200) NULL
GO
-- Upsize the FunctionalLocations to VARCHAR(MAX) because SWS has 10000+ units
ALTER TABLE [dbo].[ActionItemDefinitionHistory]
	ALTER COLUMN [FunctionalLocations] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE ActionItemDefinitionHistory SET FunctionalLocations = FunctionalLocations
GO

-- recreate the index as a clustered index
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionHistory]') AND name = N'IDX_ActionItemDefinitionHistory_Id')
BEGIN
	DROP INDEX [IDX_ActionItemDefinitionHistory_Id] ON [dbo].[ActionItemDefinitionHistory] WITH ( ONLINE = OFF )
END

CREATE CLUSTERED INDEX [IDX_ActionItemDefinitionHistory_Id] ON [dbo].[ActionItemDefinitionHistory] 
(
	[Id] ASC
)WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

----------------
--- Comments ---
----------------
-- Convert Text from NVarChar(4000) to VARCHAR(MAX)
ALTER TABLE [dbo].[Comment]
	ALTER COLUMN [Text] VARCHAR(MAX) NOT NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE Comment SET [Text] = [Text]
GO

ALTER INDEX [PK_Comment] 
	ON [dbo].[Comment] 
		REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_Comment_User] 
	ON [dbo].[Comment] 
		REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

--------------------
--- CraftOrTrade ---
--------------------
-- Convert from NVARCHAR to VARCHAR. No need to store as unicode
ALTER TABLE [dbo].[CraftOrTrade]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO

ALTER TABLE [dbo].[CraftOrTrade]
	ALTER COLUMN [WorkCenter] VARCHAR(10) NULL
GO

ALTER INDEX [PK_CraftOrTrade] 
	ON [dbo].[CraftOrTrade] 
		REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


----------------------------
--- EventSinks ---
----------------------------
ALTER TABLE [dbo].[EventSinks]
	ALTER COLUMN [FlocIdList] VARCHAR(MAX) NULL
GO
-- Move column from LOB to table if less than 8000 characters
UPDATE EventSinks SET FlocIdList = FlocIdList
GO

----------------------------
--- FunctionalLocation -----
----------------------------
/****** Object:  Index [IDX_FunctionalLocation_UnitId]    Script Date: 12/16/2008 08:56:23 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocation]') AND name = N'IDX_FunctionalLocation_UnitId')
DROP INDEX [IDX_FunctionalLocation_UnitId] ON [dbo].[FunctionalLocation] WITH ( ONLINE = OFF )

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_UnitId] ON [dbo].[FunctionalLocation] 
(
	[UnitId] ASC
)
INCLUDE ( [Id],
[FullHierarchy]) WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


----------------------------
--- LiveLinkDocumentLink ---
----------------------------
ALTER TABLE [dbo].[LiveLinkDocumentLink]
	ALTER COLUMN [Link] VARCHAR(300) NULL
GO

-----------
--- Log ---
-----------
ALTER TABLE [dbo].[Log]
	ALTER COLUMN [Comments] VARCHAR(MAX) NOT NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE Log SET Comments = Comments
GO

ALTER INDEX [PK_Log] ON [dbo].[Log] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_Log_FLOC] ON [dbo].[Log] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_Log_ReplyToLog] ON [dbo].[Log] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


---------------------
--- LogDefinition ---
---------------------
ALTER TABLE [dbo].[LogDefinition]
	ALTER COLUMN [Comments] VARCHAR(MAX) NOT NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE LogDefinition SET Comments = Comments
GO

ALTER INDEX [PK_LogDefinition] ON [dbo].[LogDefinition] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_LogDefinition_FLOC] ON [dbo].[LogDefinition] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


----------------------------
--- LogDefinitionHistory ---
----------------------------
ALTER TABLE [dbo].[LogDefinitionHistory]
	ALTER COLUMN [Comments] VARCHAR(MAX) NOT NULL
GO

ALTER TABLE [dbo].[LogDefinitionHistory]
	ALTER COLUMN [LiveLinkDocumentLinks] VARCHAR(1000) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE LogDefinitionHistory SET Comments = Comments
GO

ALTER INDEX [IDX_LogDefinitionHistory] ON [dbo].[LogDefinitionHistory] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

----------------------------
--- LogHistory ---
----------------------------
ALTER TABLE [dbo].[LogHistory]
	ALTER COLUMN [Comments] VARCHAR(MAX) NOT NULL
GO

-- downsize the livelinkdocumentlinks
ALTER TABLE [dbo].[LogHistory]
	ALTER COLUMN [LiveLinkDocumentLinks] VARCHAR(1000) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE LogHistory SET Comments = Comments
GO

ALTER INDEX [IDX_LogHistory] ON [dbo].[LogHistory] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


----------------------------------------------
--- ProtectiveClothingTypeAcidClothingType ---
----------------------------------------------
ALTER TABLE [dbo].[ProtectiveClothingTypeAcidClothingType]
	ALTER COLUMN [Name] VARCHAR(10) NOT NULL
GO	
	
----------------------------
--- UserLayoutPreference ---
----------------------------
ALTER TABLE [dbo].[UserLayoutPreference]
	ALTER COLUMN [LayoutPreference] VARCHAR(MAX) NOT NULL
GO
UPDATE UserLayoutPreference SET LayoutPreference = LayoutPreference
GO


----------------------------
--- UserPrintPreferences ---
----------------------------
ALTER TABLE [dbo].[UserPrintPreference]
	ALTER COLUMN [PrinterName] VARCHAR(125) NOT NULL
GO


-----------------------
--- SAPNotification ---
-----------------------
-- Convert all TEXT Column types to VARCHAR(MAX)
ALTER TABLE [dbo].[SAPNotification]
	ALTER COLUMN [Comments] VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[SAPNotification]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[SAPNotification]
	ALTER COLUMN [LongText] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE SAPNotification
	SET 
		Comments = Comments,
		[Description] = [Description],
		LongText = LongText
		
		
ALTER INDEX [PK_SAPNotification] ON [dbo].[SAPNotification] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_SAPNotification_FunctionalLocation] ON [dbo].[SAPNotification] REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [UQ_SAPNotification_Number] ON [dbo].[SAPNotification] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


-------------------
--- TargetAlert ---
-------------------
ALTER TABLE [dbo].[TargetAlert]
	ALTER COLUMN [TargetName] VARCHAR(30) NULL
GO
ALTER TABLE [dbo].[TargetAlert]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
Update [dbo].[TargetAlert]
	SET Description = Description
GO

ALTER INDEX [PK_TargetAlert] ON [dbo].[TargetAlert] 
	REBUILD 
	WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


ALTER INDEX [IDX_TargetAlert_FLOC] ON [dbo].[TargetAlert] 
	REBUILD WITH ( FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


---------------------------
--- TargetAlertResponse ---
---------------------------
ALTER TABLE [dbo].[TargetAlertResponse]
	ALTER COLUMN [CreatedShiftPatternIds] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters	
UPDATE TargetAlertResponse SET CreatedShiftPatternIds = CreatedShiftPatternIds 
GO

ALTER INDEX [PK_TargetAlertResponse] ON [dbo].[TargetAlertResponse] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_TargetAlertResponse_Comment] 
	ON [dbo].[TargetAlertResponse] 
	REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO
ALTER INDEX [IDX_TargetAlertResponse_FLOC] 
	ON [dbo].[TargetAlertResponse] 
		REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO
ALTER INDEX [IDX_TargetAlertResponse_TargetAlert] 
	ON [dbo].[TargetAlertResponse] 
		REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

------------------------
--- TargetDefinition ---
------------------------
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TargetDefinition]') AND name = N'IDX_TargetDefinition_Name')
DROP INDEX [IDX_TargetDefinition_Name] ON [dbo].[TargetDefinition] WITH ( ONLINE = OFF )
GO

ALTER TABLE [dbo].[TargetDefinition]
	ALTER COLUMN [Name] VARCHAR(30) NOT NULL
GO

ALTER TABLE [dbo].[TargetDefinition]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE TargetDefinition SET [Description] = [Description]
GO

ALTER INDEX [PK_TargetDefinition] ON [dbo].[TargetDefinition] 
	REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

CREATE NONCLUSTERED INDEX [IDX_TargetDefinition_Name] ON [dbo].[TargetDefinition] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER INDEX [IDX_TargetDefinition_FLOC] ON [dbo].[TargetDefinition] 
	REBUILD WITH (FILLFACTOR = 90, PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

-------------------------------
--- TargetDefinitionHistory ---
-------------------------------
ALTER TABLE [dbo].[TargetDefinitionHistory]
	ALTER COLUMN [Description] VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[TargetDefinitionHistory]
	ALTER COLUMN [Schedule] VARCHAR(300) NOT NULL
GO
ALTER TABLE [dbo].[TargetDefinitionHistory]
	ALTER COLUMN [AssociatedTargets] VARCHAR(200) NULL
GO
ALTER TABLE [dbo].[TargetDefinitionHistory]
	ALTER COLUMN [LiveLinkDocumentLinks] VARCHAR(1000) NULL
GO

ALTER TABLE [dbo].[TargetDefinitionHistory]
	ALTER COLUMN [Name] VARCHAR(30) NOT NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE TargetDefinitionHistory SET [Description] = [Description]
GO

ALTER INDEX [IDX_TargetDefinitionHistory] ON [dbo].[TargetDefinitionHistory] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


-------------------------------
--- TargetDefinitionStatus ---
-------------------------------
ALTER TABLE [dbo].[TargetDefinitionStatus]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO
ALTER TABLE [dbo].[TargetDefinitionStatus]
	ALTER COLUMN [Code] VARCHAR(15) NOT NULL
GO


------------------
--- TargetMode ---
------------------
ALTER TABLE [dbo].[TargetMode]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO

------------------
--- User ---
------------------
/****** Object:  Index [PK_User]    Script Date: 12/16/2008 15:18:34 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IDX_User_Id_Include')
BEGIN
	DROP INDEX [IDX_User_Id_Include] ON [dbo].[User] WITH ( ONLINE = OFF )
END


CREATE NONCLUSTERED INDEX [IDX_User_Id_Include] ON [dbo].[User] 
(
	[Id] ASC
)
INCLUDE ( [Username],[Firstname], [Lastname]) 
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

GO

------------------------
--- UserRoleElements ---
------------------------
IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleElements]') AND name = N'IDX_UserRoleElements')
CREATE CLUSTERED INDEX [IDX_UserRoleElements] ON [dbo].[UserRoleElements] 
(
	[UserId] ASC,
	[RoleElementId] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

GO

------------------
--- WorkPermit ---
------------------
-- Convert all TEXT types in WorkPermit table to VARCHAR(MAX)
ALTER TABLE [dbo].[WorkPermit]
	ALTER COLUMN JobStepDescription VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[WorkPermit]
	ALTER COLUMN WorkOrderDescription VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[WorkPermit]
	ALTER COLUMN SpecialPrecautionsOrConsiderationsDescription VARCHAR(MAX) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE WorkPermit
	SET
		JobStepDescription = JobStepDescription,
		WorkOrderDescription = WorkOrderDescription,
		SpecialPrecautionsOrConsiderationsDescription = SpecialPrecautionsOrConsiderationsDescription
GO		
		
CREATE NONCLUSTERED INDEX IDX_WorkPermit_FLOC
ON [WorkPermit] ([FunctionalLocationId])
WITH DROP_EXISTING, FILLFACTOR = 90
GO

ALTER INDEX [PK_WorkPermit] ON [dbo].[WorkPermit] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO

ALTER INDEX [IDX_WorkPermit_FLOC] ON [dbo].[WorkPermit] REBUILD WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )
GO


-------------------------
--- WorkPermitHistory ---
-------------------------
-- Convert all TEXT types in WorkPermitHistory table to VARCHAR(MAX)
ALTER TABLE [dbo].[WorkPermitHistory]
	ALTER COLUMN JobStepDescription VARCHAR(MAX) NULL
GO

ALTER TABLE [dbo].[WorkPermitHistory]
	ALTER COLUMN WorkOrderDescription VARCHAR(MAX) NULL
GO
ALTER TABLE [dbo].[WorkPermitHistory]
	ALTER COLUMN SpecialPrecautionsOrConsiderationsDescription VARCHAR(MAX) NULL
GO
ALTER TABLE [dbo].[WorkPermitHistory]
	ALTER COLUMN GasTestElements VARCHAR(500) NULL
GO

-- Move column from LOB to table if less than 8000 characters
UPDATE WorkPermit
	SET
		JobStepDescription = JobStepDescription,
		WorkOrderDescription = WorkOrderDescription,
		SpecialPrecautionsOrConsiderationsDescription = SpecialPrecautionsOrConsiderationsDescription
GO		

CREATE NONCLUSTERED INDEX IDX_WorkPermitHistory
ON [WorkPermitHistory] ([Id])
WITH DROP_EXISTING, FILLFACTOR = 85
GO

------------------------
--- WorkPermitStatus ---
------------------------
ALTER TABLE [dbo].[WorkPermitStatus]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO


----------------------
--- WorkPermitType ---
----------------------
ALTER TABLE [dbo].[WorkPermitType]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO

------------------------------------
--- WorkPermitTypeClassification ---
------------------------------------
ALTER TABLE [dbo].[WorkPermitTypeClassification]
	ALTER COLUMN [Name] VARCHAR(50) NOT NULL
GO

INSERT INTO DBVERSION VALUES ('2.6.0')
GO