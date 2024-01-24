IF  EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'EquipmentInHazardousEnergyIsolationComments'
)
begin
ALTER TABLE WorkPermit Drop column EquipmentInHazardousEnergyIsolationComments  
end
Go

IF  EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'EquipmentInHazardousEnergyIsolationComments'
)
begin
ALTER TABLE WorkPermitHistory Drop column  EquipmentInHazardousEnergyIsolationComments
end
Go