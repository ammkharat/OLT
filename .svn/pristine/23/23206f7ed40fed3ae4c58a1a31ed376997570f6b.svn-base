ALTER TABLE WorkPermitEdmontonGroup ADD DefaultToDayShiftOnSapImport bit;
GO

UPDATE WorkPermitEdmontonGroup set DefaultToDayShiftOnSapImport = 0;
UPDATE WorkPermitEdmontonGroup set DefaultToDayShiftOnSapImport = 1
  where [Name] IN ('Maintenance', 'Construction');
  
ALTER TABLE WorkPermitEdmontonGroup ALTER COLUMN DefaultToDayShiftOnSapImport bit NOT NULL;
GO


GO

