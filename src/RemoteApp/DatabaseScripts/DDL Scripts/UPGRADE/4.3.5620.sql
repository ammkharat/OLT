

ALTER TABLE [dbo].[PermitRequestOssa]
DROP COLUMN Supervisor
GO
   
ALTER TABLE [dbo].[PermitRequestOssa]
ADD
	[CrewSize] [int] NULL,
	[JobCoordinator] [varchar](100) NULL,
	[CoordinatorContactInfo] [varchar](100) NULL,
	[Location] [varchar](100) NULL
GO

ALTER TABLE [dbo].[PermitRequestOssa]
ALTER COLUMN Trade varchar(100) NULL
GO

ALTER TABLE [dbo].[PermitRequestOssa]
ALTER COLUMN WorkOrderNumber varchar(20) NULL
GO


CREATE TABLE [dbo].[PermitRequestOssaDetails] (
[Id] bigint NOT NULL,

FlameResistantWorkWear bit NOT NULL,
MonoGoggles bit NOT NULL,
FaceShield bit NOT NULL,

ChemicalSuit bit NOT NULL,
ConfinedSpaceMonitor bit NOT NULL,
FallProtection bit NOT NULL,

FireWatch bit NOT NULL,
FireExtinguisher bit NOT NULL,
ChargedFireHose bit NOT NULL,

FireBlanket bit NOT NULL,
SparkContainment bit NOT NULL,
CoveredSewers bit NOT NULL,

SuppliedBreathingAir bit NOT NULL,
BottleWatch bit NOT NULL,
AirPurifyingRespirator bit NOT NULL,

AirMover bit NOT NULL,
StandbyPerson bit NOT NULL,
SignalPerson bit NOT NULL,

PersonalFlotationDevice bit NOT NULL,
WorkingAlone bit NOT NULL,
CommunicationDevice bit NOT NULL,

HearingProtection bit NOT NULL,
SafetyGloves bit NOT NULL,
ReflectiveStripes bit NOT NULL,

OtherSpecialtySafetyEquipmentRequirements1 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements1Value varchar(100) NULL,
OtherSpecialtySafetyEquipmentRequirements2 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements2Value varchar(100) NULL,
OtherSpecialtySafetyEquipmentRequirements3 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements3Value varchar(100) NULL,

SafetyPrecautionsAndHazards varchar(500) null,

ConfinedSpaceEntry bit NOT NULL,
GroundDisturbance bit NOT NULL,
FireProtectionAuthorization bit NOT NULL,
CriticalOrSeriousLifts bit NOT NULL,
VehicleEntry bit NOT NULL,
IndustrialRadiography bit NOT NULL,
ElectricalEncroachment bit NOT NULL,
Msds bit NOT NULL,
OtherWorkAuthorizationsAndOrDocumentation bit NOT NULL,
OtherWorkAuthorizationsAndOrDocumentationValue varchar(100) NULL,

CONSTRAINT [PK_PermitRequestOssaDetails]
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[PermitRequestOssaDetails]
ADD  CONSTRAINT [FK_PermitRequestOssa_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[PermitRequestOssa] ( [Id] )
GO


---
--- History
---

ALTER TABLE [dbo].[PermitRequestOssaHistory]
DROP COLUMN Supervisor
GO

ALTER TABLE [dbo].[PermitRequestOssaHistory]
ADD
	[CrewSize] [int] NULL,
	[JobCoordinator] [varchar](100) NULL,
	[CoordinatorContactInfo] [varchar](100) NULL,
	[Location] [varchar](100) NULL
GO

ALTER TABLE [dbo].[PermitRequestOssaHistory]
ALTER COLUMN WorkOrderNumber varchar(20) NULL
GO

ALTER TABLE [dbo].[PermitRequestOssaHistory]
ALTER COLUMN Trade varchar(100) NULL
GO

ALTER TABLE [dbo].[PermitRequestOssaHistory]
ALTER COLUMN WorkOrderNumber varchar(20) NULL
GO


ALTER TABLE [dbo].[PermitRequestOssaHistory]
ADD
FlameResistantWorkWear bit NOT NULL,
MonoGoggles bit NOT NULL,
FaceShield bit NOT NULL,

ChemicalSuit bit NOT NULL,
ConfinedSpaceMonitor bit NOT NULL,
FallProtection bit NOT NULL,

FireWatch bit NOT NULL,
FireExtinguisher bit NOT NULL,
ChargedFireHose bit NOT NULL,

FireBlanket bit NOT NULL,
SparkContainment bit NOT NULL,
CoveredSewers bit NOT NULL,

SuppliedBreathingAir bit NOT NULL,
BottleWatch bit NOT NULL,
AirPurifyingRespirator bit NOT NULL,

AirMover bit NOT NULL,
StandbyPerson bit NOT NULL,
SignalPerson bit NOT NULL,

PersonalFlotationDevice bit NOT NULL,
WorkingAlone bit NOT NULL,
CommunicationDevice bit NOT NULL,

HearingProtection bit NOT NULL,
SafetyGloves bit NOT NULL,
ReflectiveStripes bit NOT NULL,

OtherSpecialtySafetyEquipmentRequirements1 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements1Value varchar(100) NULL,
OtherSpecialtySafetyEquipmentRequirements2 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements2Value varchar(100) NULL,
OtherSpecialtySafetyEquipmentRequirements3 bit NOT NULL,
OtherSpecialtySafetyEquipmentRequirements3Value varchar(100) NULL,

SafetyPrecautionsAndHazards varchar(500) null,

ConfinedSpaceEntry bit NOT NULL,
GroundDisturbance bit NOT NULL,
FireProtectionAuthorization bit NOT NULL,
CriticalOrSeriousLifts bit NOT NULL,
VehicleEntry bit NOT NULL,
IndustrialRadiography bit NOT NULL,
ElectricalEncroachment bit NOT NULL,
Msds bit NOT NULL,
OtherWorkAuthorizationsAndOrDocumentation bit NOT NULL,
OtherWorkAuthorizationsAndOrDocumentationValue varchar(100) NULL

GO








GO

