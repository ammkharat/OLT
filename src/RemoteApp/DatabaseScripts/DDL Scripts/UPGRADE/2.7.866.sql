ALTER TABLE FUNCTIONALLOCATION ALTER COLUMN Description VARCHAR(50)
GO

UPDATE [dbo].[Site] SET [Name] = 'Firebag' WHERE Id = 5 and [Name] = 'Oilsands Firebag'
UPDATE [dbo].[Site] SET [Name] = 'Oilsands' WHERE Id = 3 and [Name] = 'Oilsands Extraction'
-- Move Upgrading plants to the Oilsands site
UPDATE [dbo].[Plant] SET SiteId = 3 WHERE SiteId = 4
DELETE FROM [dbo].[ActionItemDefinitionAutoReApprovalConfiguration] where SiteId = 4
DELETE FROM [dbo].[TargetDefinitionAutoReApprovalConfiguration] where SiteId = 4
DELETE FROM [dbo].[GasTestElementInfo] where SiteId = 4
DELETE FROM [dbo].[GasTestElementInfoConfigurationHistory] where SiteId = 4
UPDATE [dbo].[Tag] Set SiteId = 3 where SiteId = 4
Delete From [dbo].[SiteConfiguration] where SiteId = 4
DELETE FROM [dbo].[Site] WHERE Id = 4 and [Name] = 'Oilsands Upgrading'

-- Extraction Shifts	
INSERT INTO Shift
	(SapShiftId,Name,StartTime,EndTime,CreatedDateTime,SiteId) 
	VALUES 
	('0 ','D','2010-05-25 07:00:00','2010-05-25 19:00:00','2010-05-25 14:19:00',3)

INSERT INTO Shift
	(SapShiftId,Name,StartTime,EndTime,CreatedDateTime,SiteId) 
	VALUES 
	('0 ','N','2010-05-25 19:00:00','2010-05-26 07:00:00','2010-05-25 14:19:00',3)

-- Mining Plants
set identity_insert Plant on
INSERT INTO Plant ([Id], [Name], SiteId) VALUES (1100, 'Oilsands Mining', 3)
set identity_insert Plant off
GO
GO
