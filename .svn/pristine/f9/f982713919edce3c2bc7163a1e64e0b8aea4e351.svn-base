
/* Drop dependant View  
	dbo.VDenverTargetBounds,
    dbo.VReportingTargetDefinitions
    dbo.VReportingTargetAlerts  
   on tables  TargetDefinition and TargetAlert to alter column
    */ 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VDenverTargetBounds')
BEGIN
	DROP VIEW dbo.VDenverTargetBounds
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingTargetDefinitions')
BEGIN
	DROP VIEW dbo.VReportingTargetDefinitions
END  

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingTargetAlerts')
BEGIN
	DROP VIEW dbo.VReportingTargetAlerts
END    
 

/*
ALTER TABLE dbo.TargetDefinition
*/
ALTER TABLE dbo.TargetDefinition ALTER COLUMN NeverToExceedMax decimal(10,3)
ALTER TABLE dbo.TargetDefinition ALTER COLUMN NeverToExceedMin decimal(10,3)
ALTER TABLE dbo.TargetDefinition ALTER COLUMN MaxValue decimal(10,3)
ALTER TABLE dbo.TargetDefinition ALTER COLUMN MinValue decimal(10,3)
ALTER TABLE dbo.TargetDefinition ALTER COLUMN GapUnitValue decimal(10,3)
ALTER TABLE dbo.TargetDefinition ALTER COLUMN TargetDefinitionValue decimal(10,3)

/*
ALTER TABLE dbo.TargetAlert
*/
ALTER TABLE dbo.TargetAlert ALTER COLUMN NeverToExceedMax decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN NeverToExceedMin decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN MaxValue decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN MinValue decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN GapUnitValue decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN TargetAlertValue decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN MaxAtEvaluation decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN MinAtEvaluation decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN NTEMaxAtEvaluation decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN NTEMinAtEvaluation decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN ActualValueAtEvaluation decimal(10,3)
ALTER TABLE dbo.TargetAlert ALTER COLUMN ActualValue decimal(10,3)

/*
ALTER TABLE dbo.TargetDefinitionHistory
*/
ALTER TABLE dbo.TargetDefinitionHistory ALTER COLUMN NeverToExceedMax decimal(10,3)
ALTER TABLE dbo.TargetDefinitionHistory ALTER COLUMN NeverToExceedMin decimal(10,3)
ALTER TABLE dbo.TargetDefinitionHistory ALTER COLUMN MaxValue decimal(10,3)
ALTER TABLE dbo.TargetDefinitionHistory ALTER COLUMN MinValue decimal(10,3)
ALTER TABLE dbo.TargetDefinitionHistory ALTER COLUMN GapUnitValue decimal(10,3)