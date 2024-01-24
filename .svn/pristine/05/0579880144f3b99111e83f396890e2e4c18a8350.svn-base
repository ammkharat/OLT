CREATE TABLE [dbo].[WorkPermitMontrealDetails] (
[Id] bigint NOT NULL,

[H2S] bit NOT NULL,
[Hydrocarbure] bit NOT NULL,
[Ammoniaque] bit NOT NULL,
[Corrosif] bit NOT NULL,
[CorrosifValue] VARCHAR(100),
[Aromatique] bit NOT NULL,
[AromatiqueValue] VARCHAR(100) NULL,
[AutresSubstances] bit NOT NULL,
[AutresSubstancesValue] VARCHAR(100) NULL,

[ObtureOuDeBranche] bit NOT NULL,
[DepressuriseEtVidange] bit NOT NULL,
[EnPresenceDeGazInerte] bit NOT NULL,
[PurgeALaVapeur] bit NOT NULL,
[RinceALEau] bit NOT NULL,
[Excavation] bit NOT NULL,
[DessinsRequis] bit NOT NULL,
[DessinsRequisValue] VARCHAR(100) NULL,
[CablesChauffantsMisHorsTension] bit NOT NULL,
[PompeOuVerinPneumatique] bit NOT NULL,

[ChaineEtCadenasseOuScelle] bit NOT NULL,
[InterrupteursElectriquesVerrouilles] bit NOT NULL,
[PurgeParUnGazInerte] bit NOT NULL,
[OutilsElectriquesOuABatteries] bit NOT NULL,
[BoiteDeVerrouillage] bit NOT NULL,
[BoiteDeVerrouillageValue] VARCHAR(100) NULL,
[OutilsPneumatiques] bit NOT NULL,
[MoteurACombustionInterne] bit NOT NULL,
[TravauxSuperposes] bit NOT NULL,

[FormulaireDespaceClosAffiche] bit NOT NULL,
[FormulaireDespaceClosAfficheValue] VARCHAR(100) NULL,
[ExisteIlUneAnalyseDeTache] bit NOT NULL,
[PossibiliteDeSulfureDeFer] bit NOT NULL,
[AereVentile] bit NOT NULL,
[SoudureALelectricite] bit NOT NULL,
[BrulageAAcetylene] bit NOT NULL,
[Nacelle] bit NOT NULL,
[AutreConditions] bit NOT NULL,
[AutreConditionsValue] VARCHAR(100) NULL,

[LunettesMonocoques] bit NOT NULL,
[HarnaisDeSecurite] bit NOT NULL,
[EcranFacial] bit NOT NULL,
[ProtectionAuditive] bit NOT NULL,
[Trepied] bit NOT NULL,
[DispositifAntiChute] bit NOT NULL,
[ProtectionRespiratoire] bit NOT NULL,
[ProtectionRespiratoireValue] VARCHAR(100) NULL,
[Habits] bit NOT NULL,
[HabitsValue] VARCHAR(100) NULL,
[AutreProtection] bit NOT NULL,
[AutreProtectionValue] VARCHAR(100) NULL,

[Extincteur] bit NOT NULL,
[BouchesDegoutProtegees] bit NOT NULL,
[CouvertureAntiEtincelles] bit NOT NULL,
[SurveillantPourEtincelles] bit NOT NULL,
[PareEtincelles] bit NOT NULL,
[MiseAlaTerrePresDuLieuDeTravail] bit NOT NULL,
[BoyauAVapeur] bit NOT NULL,
[AutresEquipementDincendie] bit NOT NULL,
[AutresEquipementDincendieValue] VARCHAR(100) NULL,

[Ventulateur] bit NOT NULL,
[Barrieres] bit NOT NULL,
[Surveillant] bit NOT NULL,
[SurveillantValue] VARCHAR(100) NULL,
[RadioEmetteur] bit NOT NULL,
[ZoneBarricadee] bit NOT NULL,
[DetectionContinueDesGaz] bit NOT NULL,
[DetectionContinueDesGazValue] VARCHAR(100) NULL,
[KlaxonSonore] bit NOT NULL,
[Localiser] bit NOT NULL,
[Amiante] bit NOT NULL,
[AutreEquipementsSecurite] bit NOT NULL,
[AutreEquipementsSecuriteValue] VARCHAR(100) NULL,

[InstructionsSpeciales] VARCHAR(500) NULL,
[SignatureOperateurSurLeTerrain] bit NOT NULL,
[DetectionDesGazs] bit NOT NULL,
[SignatureContremaitre] bit NOT NULL,
[SignatureAutorise] bit NOT NULL,
CONSTRAINT [PK_WorkPermitMontrealDetails]
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

ALTER TABLE [dbo].[WorkPermitMontrealDetails]
ADD  CONSTRAINT [FK_WorkPermitMontreal_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[WorkPermitMontreal] ( [Id] )
GO