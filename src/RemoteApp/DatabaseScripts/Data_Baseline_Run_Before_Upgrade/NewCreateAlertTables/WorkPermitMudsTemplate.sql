IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsTemplate]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsTemplate](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[TemplateNumber] [int] NOT NULL,
	[RemplirLeFormulaireDeCondition] [tinyint] NOT NULL,
	[RemplirLeFormulaireDeConditionValue] [varchar](100) NULL,
	[AnalyseCritiqueDeLaTache] [tinyint] NOT NULL,
	[Depressurises] [tinyint] NOT NULL,
	[Vides] [tinyint] NOT NULL,
	[ContournementDesGDA] [tinyint] NOT NULL,
	[Rinces] [tinyint] NOT NULL,
	[NettoyesLaVapeur] [tinyint] NOT NULL,
	[Purges] [tinyint] NOT NULL,
	[Ventiles] [tinyint] NOT NULL,
	[Aeres] [tinyint] NOT NULL,
	[Procedure] [tinyint] NOT NULL,
	[ProcedureValue] [varchar](100) NULL,
	[AutresCondition] [tinyint] NOT NULL,
	[AutresConditionValue] [varchar](100) NULL,
	[InterrupteursEtVannesCadenasses] [tinyint] NOT NULL,
	[InterrupteursEtVannesCadenassesValue] [varchar](100) NULL,
	[VerrouillagesParTravailleurs] [tinyint] NOT NULL,
	[SourcesDesenergisees] [tinyint] NOT NULL,
	[DepartsLocauxTestes] [tinyint] NOT NULL,
	[ConduitesDesaccouplees] [tinyint] NOT NULL,
	[ObturateursInstallees] [tinyint] NOT NULL,
	[Etiquette] [tinyint] NOT NULL,
	[EtiquetteValue] [varchar](100) NULL,
	[PVCISuncorEffectuee] [tinyint] NOT NULL,
	[PVCIEntExtEffectuee] [tinyint] NOT NULL,
	[Amiante] [tinyint] NOT NULL,
	[AcideSulfurique] [tinyint] NOT NULL,
	[Azote] [tinyint] NOT NULL,
	[Caustique] [tinyint] NOT NULL,
	[DioxydeDeSoufre] [tinyint] NOT NULL,
	[SBS] [tinyint] NOT NULL,
	[Soufre] [tinyint] NOT NULL,
	[EquipementsNonRinces] [tinyint] NOT NULL,
	[Hydrocarbures] [tinyint] NOT NULL,
	[HydrogeneSulfure] [tinyint] NOT NULL,
	[MonoxydeCarbone] [tinyint] NOT NULL,
	[Reflux] [tinyint] NOT NULL,
	[ProduitsVolatilsUtilises] [tinyint] NOT NULL,
	[Bacteries] [tinyint] NOT NULL,
	[Appareil] [tinyint] NOT NULL,
	[AppareilValue] [varchar](100) NULL,
	[InterferencesEntreTravaux] [tinyint] NOT NULL,
	[PiecesEnRotation] [tinyint] NOT NULL,
	[IncendieExplosion] [tinyint] NOT NULL,
	[ContrainteThermique] [tinyint] NOT NULL,
	[Radiations] [tinyint] NOT NULL,
	[Silice] [tinyint] NOT NULL,
	[Vanadium] [tinyint] NOT NULL,
	[AsphyxieIntoxication] [tinyint] NOT NULL,
	[EffondrementEnsevelissement] [tinyint] NOT NULL,
	[AutresRisques] [tinyint] NOT NULL,
	[AutresRisquesValue] [varchar](100) NULL,
	[ElectriciteVolt] [tinyint] NOT NULL,
	[ElectriciteVoltValue] [varchar](100) NULL,
	[OutillageElectrique] [tinyint] NOT NULL,
	[TravailEnHauteur6EtPlus] [tinyint] NOT NULL,
	[Electrisation] [tinyint] NOT NULL,
	[LunettesMonocoques] [tinyint] NOT NULL,
	[Visiere] [tinyint] NOT NULL,
	[ProtectionAuditive] [tinyint] NOT NULL,
	[CagouleIgnifuge] [tinyint] NOT NULL,
	[Harnais2LiensDeRetenue] [tinyint] NOT NULL,
	[AppareilEquipementDePrevention] [tinyint] NOT NULL,
	[AppareilEquipementDePreventionValue] [varchar](100) NULL,
	[Gants] [tinyint] NOT NULL,
	[GantsValue] [varchar](100) NULL,
	[MasqueACartouches] [tinyint] NOT NULL,
	[MasqueACartouchesValue] [varchar](100) NULL,
	[MasqueSoudeur] [tinyint] NOT NULL,
	[EPIAntiArcCAT] [tinyint] NOT NULL,
	[EPIAntiArcCATValue] [varchar](100) NULL,
	[EPIAntiChoc] [tinyint] NOT NULL,
	[HabitProtecteur] [tinyint] NOT NULL,
	[HabitProtecteurValue] [varchar](100) NULL,
	[EcranDeflecteur] [tinyint] NOT NULL,
	[MALTDesEquipements] [tinyint] NOT NULL,
	[Rallonges] [tinyint] NOT NULL,
	[ApprobationPourEquipDeLevage] [tinyint] NOT NULL,
	[BarricadeRigide] [tinyint] NOT NULL,
	[AutresE] [tinyint] NOT NULL,
	[AutresEValue] [varchar](100) NULL,
	[AlarmeDCS] [tinyint] NOT NULL,
	[AlarmeDCSValue] [varchar](100) NULL,
	[EchelleSecurisee] [tinyint] NOT NULL,
	[EchafaudageApprouve] [tinyint] NOT NULL,
	[OutilDeLaiton] [tinyint] NULL,
	[OutilDeLaitonManel] [tinyint] NOT NULL,
	[OutilDeLaitonManelValue] [varchar](100) NULL,
	[PerimetreSecurite] [tinyint] NOT NULL,
	[PerimetreSecuriteValue] [varchar](100) NULL,
	[Radio] [tinyint] NOT NULL,
	[AutresEquipementDePrevention] [tinyint] NOT NULL,
	[AutresEquipementDePreventionValue] [varchar](100) NULL,
	[Signaleur] [tinyint] NOT NULL,
	[InstructionsSpeciales] [varchar](500) NULL,
	[SignatureOperateurSurLeTerrain] [tinyint] NOT NULL,
	[DetectionDesGazs] [tinyint] NOT NULL,
	[SignatureContremaitre] [tinyint] NOT NULL,
	[SignatureAutorise] [tinyint] NOT NULL,
	[NettoyageTransfertHorsSite] [tinyint] NOT NULL,
	[Soudage] [tinyint] NOT NULL,
	[Traitement] [tinyint] NOT NULL,
	[Cuissons] [tinyint] NOT NULL,
	[Perçage] [tinyint] NOT NULL,
	[Chaufferette] [tinyint] NOT NULL,
	[Meulage] [tinyint] NOT NULL,
	[Nettoyage] [tinyint] NOT NULL,
	[AutresTravaux] [tinyint] NOT NULL,
	[AutresTravauxValue] [varchar](100) NULL,
	[TravauxDansZone] [tinyint] NOT NULL,
	[Combustibles] [tinyint] NOT NULL,
	[Ecran] [tinyint] NOT NULL,
	[Boyau] [tinyint] NOT NULL,
	[BoyauDe] [tinyint] NOT NULL,
	[Couverture] [tinyint] NOT NULL,
	[Extincteur] [tinyint] NOT NULL,
	[Bouche] [tinyint] NOT NULL,
	[RadioS] [tinyint] NOT NULL,
	[Surveillant] [tinyint] NOT NULL,
	[UtilisationMoteur] [tinyint] NOT NULL,
	[NettoyageAU] [tinyint] NOT NULL,
	[UtilisationElectronics] [tinyint] NOT NULL,
	[Radiographie] [tinyint] NOT NULL,
	[UtilisationOutlis] [tinyint] NOT NULL,
	[UtilisationEquipments] [tinyint] NOT NULL,
	[Demolition] [tinyint] NOT NULL,
	[AutresInstruction] [tinyint] NOT NULL,
	[AutresInstructionValue] [varchar](100) NULL,
 CONSTRAINT [PK_WorkPermitMudsTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


End
IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsTemplate]') AND name = 'VapeurCondensat'
)
begin
ALTER TABLE WorkPermitMudsTemplate ADD VapeurCondensat tinyint 
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsTemplate]') AND name = 'Energies'
)
begin
ALTER TABLE WorkPermitMudsTemplate ADD Energies tinyint 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsTemplate]') AND name = 'FeSValue'
)
begin
ALTER TABLE WorkPermitMudsTemplate ADD FeSValue tinyint 
end
Go

