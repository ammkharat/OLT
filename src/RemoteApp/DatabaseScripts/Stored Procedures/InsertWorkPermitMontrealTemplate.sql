IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMontrealTemplate')
	BEGIN
		DROP  Procedure  InsertWorkPermitMontrealTemplate
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealTemplate]
(
    @Id bigint Output,
    @Name varchar(100),
	@TemplateNumber int Output,
	@TypeId int,
	@Active bit,
	@Deleted bit,
	@H2S tinyint,
	@Hydrocarbure tinyint,
	@Ammoniaque tinyint,
	@Corrosif tinyint,
	@CorrosifValue varchar(100),
	@Aromatique tinyint,
	@AromatiqueValue varchar(100),
	@AutresSubstances tinyint,
	@AutresSubstancesValue varchar(100),
	@ObtureOuDeBranche tinyint,
	@DepressuriseEtVidange tinyint,
	@EnPresenceDeGazInerte tinyint,
	@PurgeALaVapeur tinyint,
	@RinceALEau tinyint,
	@Excavation tinyint,
	@DessinsRequis tinyint,
	@DessinsRequisValue varchar(100),
	@CablesChauffantsMisHorsTension tinyint,
	@PompeOuVerinPneumatique tinyint,
	@ChaineEtCadenasseOuScelle tinyint,
	@InterrupteursElectriquesVerrouilles tinyint,
	@PurgeParUnGazInerte tinyint,
	@OutilsElectriquesOuABatteries tinyint,
	@BoiteEnergieZero tinyint,
	@BoiteEnergieZeroValue varchar(100),
	@OutilsPneumatiques tinyint,
	@MoteurACombustionInterne tinyint,
	@TravauxSuperposes tinyint,
	@FormulaireDespaceClosAffiche tinyint,
	@FormulaireDespaceClosAfficheValue varchar(100),
	@ExisteIlUneAnalyseDeTache tinyint,
	@PossibiliteDeSulfureDeFer tinyint,
	@AereVentile tinyint,
	@SoudureALelectricite tinyint,
	@BrulageAAcetylene tinyint,
	@Nacelle tinyint,
	@AutreConditions tinyint,
	@AutreConditionsValue varchar(100),
	@LunettesMonocoques tinyint,
	@HarnaisDeSecurite tinyint,
	@EcranFacial tinyint,
	@ProtectionAuditive tinyint,
	@Trepied tinyint,
	@DispositifAntiChute tinyint,
	@ProtectionRespiratoire tinyint,
	@ProtectionRespiratoireValue varchar(100),
	@Habits tinyint,
	@HabitsValue varchar(100),
	@AutreProtection tinyint,
	@AutreProtectionValue varchar(100),
	@Extincteur tinyint,
	@BouchesDegoutProtegees tinyint,
	@CouvertureAntiEtincelles tinyint,
	@SurveillantPourEtincelles tinyint,
	@PareEtincelles tinyint,
	@MiseAlaTerrePresDuLieuDeTravail tinyint,
	@BoyauAVapeur tinyint,
	@AutresEquipementDincendie tinyint,
	@AutresEquipementDincendieValue varchar(100),
	@Ventulateur tinyint,
	@Barrieres tinyint,
	@Surveillant tinyint,
	@SurveillantValue varchar(100),
	@RadioEmetteur tinyint,
	@PerimetreDeSecurite tinyint,
	@DetectionContinueDesGaz tinyint,
	@DetectionContinueDesGazValue varchar(100),
	@KlaxonSonore tinyint,
	@Localiser tinyint,
	@Amiante tinyint,
	@AutreEquipementsSecurite tinyint,
	@AutreEquipementsSecuriteValue varchar(100),
	@InstructionsSpeciales varchar(500),
	@SignatureOperateurSurLeTerrain tinyint,
	@DetectionDesGazs tinyint,
	@SignatureContremaitre tinyint,
	@SignatureAutorise tinyint,
	@NettoyageTransfertHorsSite tinyint
)
AS

IF(@TemplateNumber = 0)
	BEGIN
		SELECT @TemplateNumber = MAX(TemplateNumber)+1 FROM WorkPermitMontrealTemplate;
	END
	
INSERT INTO [WorkPermitMontrealTemplate]
(	
    [Name], 
	[TypeId],
	[TemplateNumber],
	[Active],
	[Deleted],
	[H2S],
	[Hydrocarbure],
	[Ammoniaque],
	[Corrosif],
	[CorrosifValue],
	[Aromatique],
	[AromatiqueValue],
	[AutresSubstances],
	[AutresSubstancesValue],
	[ObtureOuDeBranche],
	[DepressuriseEtVidange],
	[EnPresenceDeGazInerte],
	[PurgeALaVapeur],
	[RinceALEau],
	[Excavation],
	[DessinsRequis],
	[DessinsRequisValue],
	[CablesChauffantsMisHorsTension],
	[PompeOuVerinPneumatique],
	[ChaineEtCadenasseOuScelle],
	[InterrupteursElectriquesVerrouilles],
	[PurgeParUnGazInerte],
	[OutilsElectriquesOuABatteries],
	[BoiteEnergieZero],
	[BoiteEnergieZeroValue],
	[OutilsPneumatiques],
	[MoteurACombustionInterne],
	[TravauxSuperposes],
	[FormulaireDespaceClosAffiche],
	[FormulaireDespaceClosAfficheValue],
	[ExisteIlUneAnalyseDeTache],
	[PossibiliteDeSulfureDeFer],
	[AereVentile],
	[SoudureALelectricite],
	[BrulageAAcetylene],
	[Nacelle],
	[AutreConditions],
	[AutreConditionsValue],
	[LunettesMonocoques],
	[HarnaisDeSecurite],
	[EcranFacial],
	[ProtectionAuditive],
	[Trepied],
	[DispositifAntiChute],
	[ProtectionRespiratoire],
	[ProtectionRespiratoireValue],
	[Habits],
	[HabitsValue],
	[AutreProtection],
	[AutreProtectionValue],
	[Extincteur],
	[BouchesDegoutProtegees],
	[CouvertureAntiEtincelles],
	[SurveillantPourEtincelles],
	[PareEtincelles],
	[MiseAlaTerrePresDuLieuDeTravail],
	[BoyauAVapeur],
	[AutresEquipementDincendie],
	[AutresEquipementDincendieValue],
	[Ventulateur],
	[Barrieres],
	[Surveillant],
	[SurveillantValue],
	[RadioEmetteur],
	[PerimetreDeSecurite],
	[DetectionContinueDesGaz],
	[DetectionContinueDesGazValue],
	[KlaxonSonore],
	[Localiser],
	[Amiante],
	[AutreEquipementsSecurite],
	[AutreEquipementsSecuriteValue],
	[InstructionsSpeciales],
	[SignatureOperateurSurLeTerrain],
	[DetectionDesGazs],
	[SignatureContremaitre],
	[SignatureAutorise],
	[NettoyageTransfertHorsSite]
)
VALUES
(
    @Name,
	@TypeId,
	@TemplateNumber,
	@Active,
	@Deleted,
	@H2S,
	@Hydrocarbure,
	@Ammoniaque,
	@Corrosif,
	@CorrosifValue,
	@Aromatique,
	@AromatiqueValue,
	@AutresSubstances,
	@AutresSubstancesValue,
	@ObtureOuDeBranche,
	@DepressuriseEtVidange,
	@EnPresenceDeGazInerte,
	@PurgeALaVapeur,
	@RinceALEau,
	@Excavation,
	@DessinsRequis,
	@DessinsRequisValue,
	@CablesChauffantsMisHorsTension,
	@PompeOuVerinPneumatique,
	@ChaineEtCadenasseOuScelle,
	@InterrupteursElectriquesVerrouilles,
	@PurgeParUnGazInerte,
	@OutilsElectriquesOuABatteries,
	@BoiteEnergieZero,
	@BoiteEnergieZeroValue,
	@OutilsPneumatiques,
	@MoteurACombustionInterne,
	@TravauxSuperposes,
	@FormulaireDespaceClosAffiche,
	@FormulaireDespaceClosAfficheValue,
	@ExisteIlUneAnalyseDeTache,
	@PossibiliteDeSulfureDeFer,
	@AereVentile,
	@SoudureALelectricite,
	@BrulageAAcetylene,
	@Nacelle,
	@AutreConditions,
	@AutreConditionsValue,
	@LunettesMonocoques,
	@HarnaisDeSecurite,
	@EcranFacial,
	@ProtectionAuditive,
	@Trepied,
	@DispositifAntiChute,
	@ProtectionRespiratoire,
	@ProtectionRespiratoireValue,
	@Habits,
	@HabitsValue,
	@AutreProtection,
	@AutreProtectionValue,
	@Extincteur,
	@BouchesDegoutProtegees,
	@CouvertureAntiEtincelles,
	@SurveillantPourEtincelles,
	@PareEtincelles,
	@MiseAlaTerrePresDuLieuDeTravail,
	@BoyauAVapeur,
	@AutresEquipementDincendie,
	@AutresEquipementDincendieValue,
	@Ventulateur,
	@Barrieres,
	@Surveillant,
	@SurveillantValue,
	@RadioEmetteur,
	@PerimetreDeSecurite,
	@DetectionContinueDesGaz,
	@DetectionContinueDesGazValue,
	@KlaxonSonore,
	@Localiser,
	@Amiante,
	@AutreEquipementsSecurite,
	@AutreEquipementsSecuriteValue,
	@InstructionsSpeciales,
	@SignatureOperateurSurLeTerrain,
	@DetectionDesGazs,
	@SignatureContremaitre,
	@SignatureAutorise,
	@NettoyageTransfertHorsSite
)

SET @Id = SCOPE_IDENTITY() 

GO
 