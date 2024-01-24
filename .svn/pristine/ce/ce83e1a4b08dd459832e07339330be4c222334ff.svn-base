CREATE TABLE [dbo].[WorkPermitOssaDetails] (
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

MechanicallyIsolated bit NOT NULL,
BlindedOrBlanked bit NOT NULL,
DoubleBlockedAndBled bit NOT NULL,
DrainedAndDepressurized bit NOT NULL,
PurgedOrNeutralized bit NOT NULL,
ElectricallyIsolated bit NOT NULL,
TestBumped bit NOT NULL,
NuclearSource bit NOT NULL,
ReceiverSafingRequirements bit NOT NULL,

CONSTRAINT [PK_WorkPermitOssaDetails]
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

ALTER TABLE [dbo].[WorkPermitOssaDetails]
ADD  CONSTRAINT [FK_WorkPermitOssa_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[WorkPermitOssa] ( [Id] )
GO


GO

