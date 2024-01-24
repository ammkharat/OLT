
CREATE TABLE [dbo].[WorkPermitEdmontonHistory] (
	[Id] bigint NOT NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](55) NOT NULL,
	[RequestedStartDateTime] [datetime] NOT NULL,
	[IssuedDateTime] [datetime] NOT NULL,
	[ExpiredDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[TaskDescription] [varchar](500) NULL,
	[HazardsAndOrRequirements] [varchar](500) NULL,
	[RequestedByUserId] [bigint] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[Group] [varchar](50) NOT NULL,
	[SpecialWorkFormNumber] [varchar](25) NULL,
	[SpecialWorkType] [varchar](25) NULL,
	[VehicleEntryType] [varchar](25) NULL,
	[RescuePlanFormNumber] [varchar](25) NULL,
	[GN59FormNumber] [varchar](25) NULL,
	[GN7FormNumber] [varchar](25) NULL,
	[StatusOfPipingEquipmentSectionNotApplicableToJob] [bit] NOT NULL,
	[ProductNormallyInPipingEquipment] [varchar](50) NULL,
	[IsolationValvesLocked] [varchar](10) NOT NULL,
	[DepressuredDrained] [varchar](10) NOT NULL,
	[Ventilated] [varchar](10) NOT NULL,
	[Purged] [varchar](10) NOT NULL,
	[BlindedAndTagged] [varchar](10) NOT NULL,
	[DoubleBlockAndBleed] [varchar](10) NOT NULL,
	[ElectricalLockout] [varchar](10) NOT NULL,
	[MechanicalLockout] [varchar](10) NOT NULL,
	[BlindSchematicAvailable] [varchar](10) NOT NULL,
	[ZeroEnergyFormNumber] [varchar](100) NULL,
	[LockBoxNumber] [varchar](100) NULL,
	[JobsiteEquipmentInspected] [bit] NOT NULL,
	[ConfinedSpaceWorkSectionNotApplicableToJob] [bit] NOT NULL,
	[QuestionOneResponse] [varchar](10) NOT NULL,
	[QuestionTwoResponse] [varchar](10) NOT NULL,
	[QuestionTwoAResponse] [varchar](10) NOT NULL,
	[QuestionTwoBResponse] [varchar](10) NOT NULL,
	[QuestionThreeResponse] [varchar](10) NOT NULL,
	[QuestionFourResponse] [varchar](10) NOT NULL,
	[GasTestsSectionNotApplicableToJob] [bit] NOT NULL,
	[OperatorGasDetectorNumber] [varchar](50) NULL,
	[GasTestDataLine1CombustibleGas] [varchar](25) NULL,
	[GasTestDataLine1Oxygen] [varchar](25) NULL,
	[GasTestDataLine1ToxicGas] [varchar](25) NULL,
	[GasTestDataLine1Time] [datetime] NULL,
	[GasTestDataLine2CombustibleGas] [varchar](25) NULL,
	[GasTestDataLine2Oxygen] [varchar](25) NULL,
	[GasTestDataLine2ToxicGas] [varchar](25) NULL,
	[GasTestDataLine2Time] [datetime] NULL,
	[GasTestDataLine3CombustibleGas] [varchar](25) NULL,
	[GasTestDataLine3Oxygen] [varchar](25) NULL,
	[GasTestDataLine3ToxicGas] [varchar](25) NULL,
	[GasTestDataLine3Time] [datetime] NULL,
	[GasTestDataLine4CombustibleGas] [varchar](25) NULL,
	[GasTestDataLine4Oxygen] [varchar](25) NULL,
	[GasTestDataLine4ToxicGas] [varchar](25) NULL,
	[GasTestDataLine4Time] [datetime] NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SystemHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [bit] NOT NULL,
	[Other1Value] [varchar](25) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [bit] NOT NULL,
	[Other2Value] [varchar](25) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[WorkersMonitorNumber] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [bit] NULL,
	[Other3Value] [varchar](25) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[Radio] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [bit] NOT NULL,
	[Other4Value] [varchar](25) NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](25) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](50) NULL,
	[VehicleEntryTotal] [int] NULL,
	[GN6] [bit] NOT NULL,
	[GN11] [bit] NOT NULL,
	[GN24] [bit] NOT NULL,
	[GN27] [bit] NOT NULL,
	[GN75] [bit] NOT NULL,
	[BT1] [bit] NOT NULL,
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmontonHistory]
ON [dbo].[WorkPermitEdmontonHistory]
([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

GO


ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_LastModifiedByUser]


ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_RequestedByUser] FOREIGN KEY([RequestedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_RequestedByUser]






GO

