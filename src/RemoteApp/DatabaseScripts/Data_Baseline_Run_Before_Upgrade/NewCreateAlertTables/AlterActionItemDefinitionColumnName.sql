IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ActionItemDefinition'
)
begin
ALTER TABLE  ActionItemDefinition ALTER COLUMN  Name   VARCHAR (60)  NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ActionItemDefinitionHistory'
)
begin
ALTER TABLE  ActionItemDefinitionHistory ALTER COLUMN Name VARCHAR (60)  NULL
end
Go




IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ControlRoomContactedNotApplicable'
)
begin
ALTER TABLE WorkPermit ADD ControlRoomContactedNotApplicable Bit NOT NULL   DEFAULT (0) WITH VALUES
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'ControlRoomContactedNotApplicable'
)
begin
ALTER TABLE WorkPermitHistory ADD ControlRoomContactedNotApplicable Bit NOT NULL    DEFAULT (0) WITH VALUES
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'PermitFreshAir'
)
begin
ALTER TABLE WorkPermit ADD PermitFreshAir Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'PermitFreshAir'
)
begin
ALTER TABLE WorkPermitHistory ADD PermitFreshAir Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'EquipmentConditionPurgedChecked'
)
begin
ALTER TABLE WorkPermit ADD  EquipmentConditionPurgedChecked bit NOT NULL   DEFAULT (0) WITH VALUES
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'EquipmentConditionPurgedChecked'
)
begin
ALTER TABLE WorkPermitHistory ADD EquipmentConditionPurgedChecked Bit NOT NULL   DEFAULT (0) WITH VALUES
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'EquipmentInAsbestosHazardPresentComments'
)
begin
ALTER TABLE WorkPermit ADD EquipmentInAsbestosHazardPresentComments  varchar(400)  NULL
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'EquipmentInAsbestosHazardPresentComments'
)
begin
ALTER TABLE WorkPermitHistory ADD EquipmentInAsbestosHazardPresentComments varchar(400)  NULL
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'EquipmentInHazardousEnergyIsolationComments'
)
begin
ALTER TABLE WorkPermit ADD EquipmentInHazardousEnergyIsolationComments  varchar(400)  NULL
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'EquipmentInHazardousEnergyIsolationComments'
)
begin
ALTER TABLE WorkPermitHistory ADD EquipmentInHazardousEnergyIsolationComments varchar(400)  NULL
end
Go




IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ControlRoomContacted'
)
begin
ALTER TABLE WorkPermit ADD ControlRoomContacted Bit 
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'ControlRoomContacted'
)
begin
ALTER TABLE WorkPermitHistory ADD ControlRoomContacted Bit 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinition]') AND name = 'CopyResponseToLog'
)
begin
ALTER TABLE ActionItemDefinition ADD CopyResponseToLog bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionHistory]') AND name = 'CopyResponseToLog'
)
begin
ALTER TABLE ActionItemDefinitionHistory ADD CopyResponseToLog bit
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinition]') AND name = 'WorkPermitId'
)
begin
ALTER TABLE ActionItemDefinition ADD WorkPermitId bigint DEFAULT NULL
end




