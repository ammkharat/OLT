--------------------------
-- Add Gas Test Element columns for Denver
---------------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'GasTestElementInfo' AND Column_name = 'Deleted')
BEGIN
ALTER TABLE [GasTestElementInfo]
	ADD [Deleted] [bit] NOT NULL CONSTRAINT DF_GasTestElementInfo_Deleted DEFAULT (0)
END
GO

UPDATE [GasTestElementInfo]
	SET [Deleted] = 1
	WHERE [SiteId] = 2 AND [Name] IN ('Benzene', 'Toluene', 'Xylene', 'Ammonia')
GO
	
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermitGasTestElementInfo' AND Column_name = 'SystemEntryTestResult')
BEGIN
ALTER TABLE [WorkPermitGasTestElementInfo]
	ADD 
		[SystemEntryTestResult] [float] NULL,
		[SystemEntryTestNotApplicable] [bit] NOT NULL CONSTRAINT DF_WorkPermitGasTestElementInfo_SystemEntryTestNotApplicable DEFAULT (0)
END		
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'GasTestSystemEntryTestTime')
BEGIN
ALTER TABLE [WorkPermit]
	ADD [GasTestSystemEntryTestTime] [varchar](5) NULL
ALTER TABLE [WorkPermitHistory]
	ADD [GasTestSystemEntryTestTime] [varchar](5) NULL
END
GO
