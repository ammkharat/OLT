ALTER TABLE dbo.PermitRequestEdmonton ADD RadioChannel BIT;
ALTER TABLE dbo.PermitRequestEdmonton ADD WorkersMonitor bit; 
GO

UPDATE 
  dbo.PermitRequestEdmonton 
SET
  RadioChannel = CASE WHEN LEN(RadioChannelNumber) = 0 then 0 else 1 end,
  WorkersMonitor = CASE WHEN LEN(WorkersMonitorNumber) = 0 then 0 else 1 end 

ALTER TABLE dbo.PermitRequestEdmonton ALTER COLUMN RadioChannel bit NOT NULL;
ALTER TABLE dbo.PermitRequestEdmonton ALTER COLUMN WorkersMonitor bit NOT NULL;


ALTER TABLE dbo.PermitRequestEdmontonHistory ADD RadioChannel BIT;
ALTER TABLE dbo.PermitRequestEdmontonHistory ADD WorkersMonitor bit;
GO

UPDATE 
  dbo.PermitRequestEdmontonHistory 
SET
  RadioChannel = CASE WHEN LEN(RadioChannelNumber) = 0 then 0 else 1 end,
  WorkersMonitor = CASE WHEN LEN(WorkersMonitorNumber) = 0 then 0 else 1 end 

ALTER TABLE dbo.PermitRequestEdmontonHistory ALTER COLUMN RadioChannel bit NOT NULL;
ALTER TABLE dbo.PermitRequestEdmontonHistory ALTER COLUMN WorkersMonitor bit NOT NULL;


ALTER TABLE dbo.WorkPermitEdmontonDetails ADD RadioChannel BIT;
ALTER TABLE dbo.WorkPermitEdmontonDetails ADD WorkersMonitor bit; 
GO

UPDATE 
  dbo.WorkPermitEdmontonDetails
SET
  RadioChannel = CASE WHEN LEN(RadioChannelNumber) = 0 then 0 else 1 end,
  WorkersMonitor = CASE WHEN LEN(WorkersMonitorNumber) = 0 then 0 else 1 end 

ALTER TABLE dbo.WorkPermitEdmontonDetails ALTER COLUMN RadioChannel bit NOT NULL;
ALTER TABLE dbo.WorkPermitEdmontonDetails ALTER COLUMN WorkersMonitor bit NOT NULL;

ALTER TABLE dbo.WorkPermitEdmontonHistory ADD RadioChannel BIT;
ALTER TABLE dbo.WorkPermitEdmontonHistory ADD WorkersMonitor bit;
GO

UPDATE 
  dbo.WorkPermitEdmontonHistory 
SET
  RadioChannel = CASE WHEN LEN(RadioChannelNumber) = 0 then 0 else 1 end,
  WorkersMonitor = CASE WHEN LEN(WorkersMonitorNumber) = 0 then 0 else 1 end 

ALTER TABLE dbo.WorkPermitEdmontonHistory ALTER COLUMN RadioChannel bit NOT NULL;
ALTER TABLE dbo.WorkPermitEdmontonHistory ALTER COLUMN WorkersMonitor bit NOT NULL;
GO


GO

