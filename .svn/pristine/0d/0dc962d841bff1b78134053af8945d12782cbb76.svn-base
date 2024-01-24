ALTER TABLE [dbo].[FormGN75B] ADD [Location] varchar(50);
GO
ALTER TABLE [dbo].[FormGN75B] ADD [EquipmentType] varchar(50);
GO

ALTER TABLE [dbo].[FormGN75BHistory] ADD [Location] varchar(50);
GO
ALTER TABLE [dbo].[FormGN75BHistory] ADD [EquipmentType] varchar(50);
GO


UPDATE 
  DropdownValue
SET
  [Value] = 'Single Valve'
WHERE
  [Key] = 'gn75b_isolation_types'
  and
  [Value] = 'Single Value'
  
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Pump',0,1,8);
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Compressor',0,2,8);
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Exchanger',0,3,8);
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Piping Circuit',0,4,8);  
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Control Valve',0,5,8);
INSERT INTO DropdownValue ([Key],[Value],Deleted,DisplayOrder,SiteId) 
  VALUES ('gn75b_equipment_types','Vessel',0,6,8);  
  


GO

