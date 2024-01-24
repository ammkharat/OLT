IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitFortHillsDetails]') AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[WorkPermitFortHillsDetails](
	[WorkPermitFortHillsId] [bigint] NOT NULL,
	[EquipmentNo] [int] NULL,
	[Craft] [varchar](25) NULL,
	[CrewSize] [int] NULL,
	[JobCoordinator] [varchar](25) NULL,
	[CoOrdContactNumber] [varchar](10) NULL,
	[EmergencyAssemblyArea] [varchar](25) NULL,
	[EmergencyMeetingPoint] [varchar](25) NULL,
	[EmergencyContactNumber] [varchar](10) NULL,
	[Locknumber] [varchar](10) NULL,
	[IsolationNumber] [varchar](10) NULL,
	[RevalidationDateTime] [datetime] NULL,
	[ExtensionDateTime] [datetime] NULL,
	[SAPDescription] [varchar](max) NULL,
	[FlameResistantWorkWear] [bit] NOT NULL,
	[ChemicalSuit] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[SuppliedBreathingAir] [bit] NOT NULL,
	[AirMover] [bit] NOT NULL,
	[PersonalFlotationDevice] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[Other1] [varchar](30) NULL,
	[MonoGoggles] [bit] NOT NULL,
	[ConfinedSpaceMoniter] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[SparkContainment] [bit] NOT NULL,
	[BottleWatch] [bit] NOT NULL,
	[StandbyPerson] [bit] NOT NULL,
	[WorkingAlone] [bit] NOT NULL,
	[SafetyGloves] [bit] NOT NULL,
	[Other2] [varchar](30) NULL,
	[FaceShield] [bit] NOT NULL,
	[FallProtection] [bit] NOT NULL,
	[ChargedFireHouse] [bit] NOT NULL,
	[CoveredSewer] [bit] NOT NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[SingalPerson] [bit] NOT NULL,
	[CommunicationDevice] [bit] NOT NULL,
	[ReflectiveStrips] [bit] NOT NULL,
	[Other3] [varchar](30) NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[GoundDisturbance] [bit] NOT NULL,
	[FireProtectionAuthorization] [bit] NOT NULL,
	[CriticalOrSeriousLifts] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[IndustrialRadiography] [bit] NOT NULL,
	[ElectricalEncroachment] [bit] NOT NULL,
	[MSDS] [bit] NOT NULL,
	[OthersPartE] [varchar](30) NULL,
	[MechanicallyIsolated] [bit] NOT NULL,
	[BlindedOrBlanked] [bit] NOT NULL,
	[DoubleBlockedandBled] [bit] NOT NULL,
	[DrainedAndDepressurised] [bit] NOT NULL,
	[PurgedorNeutralised] [bit] NOT NULL,
	[ElectricallyIsolated] [bit] NOT NULL,
	[TestBumped] [bit] NOT NULL,
	[NuclearSource] [bit] NOT NULL,
	[ReceiverStafingRequirements] [bit] NOT NULL,
	[PermitAcceptor] [varchar](30) NULL,
	[ShiftSupervisor] [varchar](30) NULL,
	[Frequency] [varchar](10) NULL,
	[TesterName] [varchar](50) NULL,
	[Oxygen] [bit] NULL,
	[LEL] [bit] NULL,
	[H2SPPM] [bit] NULL,
	[CoPPM] [bit] NULL,
	[So2PPM] [bit] NULL,
	[Other1PartGValue] [varchar](50) NULL,
	[Other2PartGValue] [varchar](50) NULL,
	[PermitIssuer] [varchar](50) NULL,
	[AreaAuthority] [varchar](50) NULL,
	[COAuthorizingIssuer] [varchar](50) NULL,
	[AddationalAuthority] [varchar](50) NULL,
	[PermitIssuerContact] [varchar](10) NULL,
	[AreaAuthorityContact] [varchar](10) NULL,
	[COAuthorizingIssuerContact] [varchar](10) NULL,
	[AddationalAuthorityContact] [varchar](10) NULL,
	[IsFieldTourRequired] [bit] NULL,
	[FieldTourConductedBy] [varchar](25) NULL,
	[Continuous] [bit] NULL,
 CONSTRAINT [PK_WorkPermitFortHillsDetails] PRIMARY KEY CLUSTERED 
(
	[WorkPermitFortHillsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'WorkPermitFortHillsDetails' AND column_name = 'ExtendedByUser')
BEGIN    
ALTER TABLE WorkPermitFortHillsDetails ADD ExtendedByUser bigint null  
END



IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'WorkPermitFortHillsDetails' AND column_name = 'ExtensionReasonPartJ')
BEGIN    
ALTER TABLE WorkPermitFortHillsDetails ADD ExtensionReasonPartJ VARCHAR(50) null  
END