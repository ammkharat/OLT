IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsDetails]') AND type in (N'U'))

Begin
CREATE TABLE [dbo].[WorkPermitMudsDetails](
	[Id] [bigint] NOT NULL,
	[RemplirLeFormulaireDeCondition] [bit] NOT NULL,
	[RemplirLeFormulaireDeConditionValue] [varchar](100) NULL,
	[AnalyseCritiqueDeLaTache] [bit] NOT NULL,
	[Depressurises] [bit] NOT NULL,
	[Vides] [bit] NOT NULL,
	[ContournementDesGDA] [bit] NOT NULL,
	[Rinces] [bit] NOT NULL,
	[NettoyesLaVapeur] [bit] NOT NULL,
	[Purges] [bit] NOT NULL,
	[Ventiles] [bit] NOT NULL,
	[Aeres] [bit] NOT NULL,
	[Procedure] [bit] NOT NULL,
	[ProcedureValue] [varchar](100) NULL,
	[AutresCondition] [bit] NOT NULL,
	[AutresConditionValue] [varchar](100) NULL,
	[InterrupteursEtVannesCadenasses] [bit] NOT NULL,
	[InterrupteursEtVannesCadenassesValue] [varchar](100) NULL,
	[VerrouillagesParTravailleurs] [bit] NOT NULL,
	[SourcesDesenergisees] [bit] NOT NULL,
	[DepartsLocauxTestes] [bit] NOT NULL,
	[ConduitesDesaccouplees] [bit] NOT NULL,
	[ObturateursInstallees] [bit] NOT NULL,
	[Etiquette] [bit] NOT NULL,
	[EtiquetteValue] [varchar](100) NULL,
	[PVCISuncorEffectuee] [bit] NOT NULL,
	[PVCIEntExtEffectuee] [bit] NOT NULL,
	[Amiante] [bit] NOT NULL,
	[AcideSulfurique] [bit] NOT NULL,
	[Azote] [bit] NOT NULL,
	[Caustique] [bit] NOT NULL,
	[DioxydeDeSoufre] [bit] NOT NULL,
	[SBS] [bit] NOT NULL,
	[Soufre] [bit] NOT NULL,
	[EquipementsNonRinces] [bit] NOT NULL,
	[Hydrocarbures] [bit] NOT NULL,
	[HydrogeneSulfure] [bit] NOT NULL,
	[MonoxydeCarbone] [bit] NOT NULL,
	[Reflux] [bit] NOT NULL,
	[ProduitsVolatilsUtilises] [bit] NOT NULL,
	[Bacteries] [bit] NOT NULL,
	[Appareil] [bit] NOT NULL,
	[AppareilValue] [varchar](100) NULL,
	[InterferencesEntreTravaux] [bit] NOT NULL,
	[PiecesEnRotation] [bit] NOT NULL,
	[IncendieExplosion] [bit] NOT NULL,
	[ContrainteThermique] [bit] NOT NULL,
	[Radiations] [bit] NOT NULL,
	[Silice] [bit] NOT NULL,
	[Vanadium] [bit] NOT NULL,
	[AsphyxieIntoxication] [bit] NOT NULL,
	[AutresRisques] [bit] NOT NULL,
	[AutresRisquesValue] [varchar](100) NULL,
	[ElectriciteVolt] [bit] NOT NULL,
	[ElectriciteVoltValue] [varchar](100) NULL,
	[OutillageElectrique] [bit] NOT NULL,
	[TravailEnHauteur6EtPlus] [bit] NOT NULL,
	[Electrisation] [bit] NOT NULL,
	[LunettesMonocoques] [bit] NOT NULL,
	[Visiere] [bit] NOT NULL,
	[ProtectionAuditive] [bit] NOT NULL,
	[CagouleIgnifuge] [bit] NOT NULL,
	[Harnais2LiensDeRetenue] [bit] NOT NULL,
	[Gants] [bit] NOT NULL,
	[GantsValue] [varchar](100) NULL,
	[MasqueACartouches] [bit] NOT NULL,
	[MasqueACartouchesValue] [varchar](100) NULL,
	[EPIAntiArcCAT] [bit] NOT NULL,
	[EPIAntiArcCATValue] [varchar](100) NULL,
	[EPIAntiChoc] [bit] NOT NULL,
	[HabitProtecteur] [bit] NOT NULL,
	[HabitProtecteurValue] [varchar](100) NULL,
	[EcranDeflecteur] [bit] NOT NULL,
	[MALTDesEquipements] [bit] NOT NULL,
	[Rallonges] [bit] NOT NULL,
	[ApprobationPourEquipDeLevage] [bit] NOT NULL,
	[BarricadeRigide] [bit] NOT NULL,
	[AutresE] [bit] NOT NULL,
	[AutresEValue] [varchar](100) NULL,
	[AlarmeDCS] [bit] NOT NULL,
	[AlarmeDCSValue] [varchar](100) NULL,
	[EchelleSecurisee] [bit] NOT NULL,
	[EchafaudageApprouve] [bit] NOT NULL,
	[OutilDeLaiton] [bit] NOT NULL,
	[OutilDeLaitonManel] [bit] NOT NULL,
	[outilDeLaitonManelValue] [varchar](100) NULL,
	[PerimetreSecurite] [bit] NOT NULL,
	[PerimetreSecuriteValue] [varchar](100) NULL,
	[Radio] [bit] NOT NULL,
	[Signaleur] [bit] NOT NULL,
	[InstructionsSpeciales] [varchar](500) NULL,
	[SignatureOperateurSurLeTerrain] [bit] NOT NULL,
	[DetectionDesGazs] [bit] NOT NULL,
	[SignatureContremaitre] [bit] NOT NULL,
	[SignatureAutorise] [bit] NOT NULL,
	[NettoyageTransfertHorsSite] [bit] NOT NULL,
	[Soudage] [bit] NOT NULL,
	[Traitement] [bit] NOT NULL,
	[Cuissons] [bit] NOT NULL,
	[Perçage] [bit] NOT NULL,
	[Chaufferette] [bit] NOT NULL,
	[Meulage] [bit] NOT NULL,
	[Nettoyage] [bit] NOT NULL,
	[AutresTravaux] [bit] NOT NULL,
	[AutresTravauxValue] [varchar](100) NULL,
	[TravauxDansZone] [bit] NOT NULL,
	[Combustibles] [bit] NOT NULL,
	[Ecran] [bit] NOT NULL,
	[Boyau] [bit] NOT NULL,
	[BoyauDe] [bit] NOT NULL,
	[Couverture] [bit] NOT NULL,
	[Extincteur] [bit] NOT NULL,
	[Bouche] [bit] NOT NULL,
	[RadioS] [bit] NOT NULL,
	[Surveillant] [bit] NOT NULL,
	[UtilisationMoteur] [bit] NOT NULL,
	[NettoyageAU] [bit] NOT NULL,
	[UtilisationElectronics] [bit] NOT NULL,
	[Radiographie] [bit] NOT NULL,
	[UtilisationOutlis] [bit] NOT NULL,
	[UtilisationEquipments] [bit] NOT NULL,
	[Demolition] [bit] NOT NULL,
	[AutresInstruction] [bit] NOT NULL,
	[AutresInstructionValue] [varchar](100) NULL,
 CONSTRAINT [PK_WorkPermitMudsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]


--ALTER TABLE [dbo].[WorkPermitMudsDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMuds_Id] FOREIGN KEY([Id])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsDetails] CHECK CONSTRAINT [FK_WorkPermitMuds_Id]

--ALTER TABLE [dbo].[WorkPermitMudsDetails] ADD  CONSTRAINT [DF_WorkPermitMudsDetails_ProtectionAuditive]  DEFAULT ((1)) FOR [ProtectionAuditive]


End




IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsDetails]') 
         AND name = 'EffondrementEnsevelissement'
)
begin
Alter table [dbo].[WorkPermitMudsDetails] Add EffondrementEnsevelissement bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsDetails]') AND name = 'MasqueSoudeur'
)
begin
Alter table [dbo].[WorkPermitMudsDetails] Add MasqueSoudeur bit
end
Go



GO

