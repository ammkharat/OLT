if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitMudsHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertWorkPermitMudsHistory]
Go
CREATE Procedure [dbo].[InsertWorkPermitMudsHistory]        
(        
-- Columns from WorkPermitMuds table        
@Id bigint,        
@WorkPermitStatusId int = NULL,        
@WorkPermitTypeId int = NULL,        
@Template varchar(150) = NULL,        
@StartDateTime dateTime,        
@EndDateTime dateTime,        
@PermitNumber bigint = NULL,        
@WorkOrderNumber VARCHAR(12) = NULL,        
@FunctionalLocations VARCHAR(MAX) = NULL,        
@Trade varchar(100)= NULL,        
@Description VARCHAR(400) = NULL,        
@RequestedByGroup varchar(100) = NULL,
 @WorkPermitCloseComments varchar(500)=NULL,  
 @WorkpermitClosedById bigint =null,
 @ActionItemCloseById bigint=null,
 @PermitCloseDateTime datetime=null,
 @ActionItemCloseDateTime datetime=null,
 @ActionItemCheckboxchecked bit=null,        
@LastModifiedDateTime dateTime,        
@LastModifiedByUserId bigint = NULL,        
@IssuedDateTime datetime = NULL,        
        
-- Columns from WorkPermitMudsDetails        
@RemplirLeFormulaireDeCondition bit ,        
@RemplirLeFormulaireDeConditionValue varchar(100) ,        
@AnalyseCritiqueDeLaTache bit ,        
@Depressurises bit ,        
@Vides bit ,        
@ContournementDesGDA bit ,        
@Rinces bit ,        
@NettoyesLaVapeur bit ,        
@Purges bit ,        
@Ventiles bit ,        
@Aeres bit ,      
@Energies bit ,        
@Procedure bit ,        
@ProcedureValue varchar(100) ,        
@AutresCondition bit ,        
@AutresConditionValue varchar(100) ,        
@InterrupteursEtVannesCadenasses bit ,        
@InterrupteursEtVannesCadenassesValue varchar(100) ,        
@VerrouillagesParTravailleurs bit ,        
@SourcesDesenergisees bit ,        
@DepartsLocauxTestes bit ,        
@ConduitesDesaccouplees bit ,        
@ObturateursInstallees bit ,        
@Etiquette bit ,        
@EtiquetteValue varchar(100) ,        
@PVCISuncorEffectuee bit ,        
@PVCIEntExtEffectuee bit ,        
@Amiante bit ,        
@AcideSulfurique bit ,        
@Azote bit ,        
@Caustique bit ,        
@DioxydeDeSoufre bit ,        
@SBS bit ,        
@Soufre bit ,        
@EquipementsNonRinces bit ,        
@Hydrocarbures bit ,        
@HydrogeneSulfure bit ,        
@MonoxydeCarbone bit ,        
@Reflux bit ,        
@ProduitsVolatilsUtilises bit ,        
@Bacteries bit ,        
@Appareil bit ,        
@AppareilValue varchar(100) ,        
@InterferencesEntreTravaux bit ,        
@PiecesEnRotation bit ,        
@IncendieExplosion bit ,        
@ContrainteThermique bit ,        
@Radiations bit ,        
@Silice bit ,        
@Vanadium bit ,        
@AsphyxieIntoxication bit ,        
@AutresRisques bit ,        
@AutresRisquesValue varchar(100) ,        
@ElectriciteVolt bit ,        
@ElectriciteVoltValue varchar(100) ,        
@OutillageElectrique bit ,        
@TravailEnHauteur6EtPlus bit ,      
@VapeurCondensat bit,      
@Electrisation bit ,        
@LunettesMonocoques bit ,        
@Visiere bit ,        
@ProtectionAuditive bit ,        
@CagouleIgnifuge bit ,        
@Harnais2LiensDeRetenue bit ,        
@Gants bit ,        
@GantsValue varchar(100) ,        
@MasqueACartouches bit ,        
@MasqueACartouchesValue varchar(100) ,        
@EPIAntiArcCAT bit ,        
@EPIAntiArcCATValue varchar(100) ,        
@EPIAntiChoc bit ,        
@HabitProtecteur bit ,        
@HabitProtecteurValue varchar(100) ,        
@EcranDeflecteur bit ,        
@MALTDesEquipements bit ,        
@Rallonges bit ,        
@ApprobationPourEquipDeLevage bit ,        
@BarricadeRigide bit ,        
@AutresE bit ,        
@AutresEValue varchar(100) ,        
@AlarmeDCS bit ,        
@AlarmeDCSValue varchar(100) ,        
@EchelleSecurisee bit ,        
@EchafaudageApprouve bit ,        
@OutilDeLaiton bit ,        
@OutilDeLaitonManel bit ,        
@outilDeLaitonManelValue varchar(100) ,        
@PerimetreSecurite bit ,     
@PerimetreSecuriteValue  varchar(100) ,          
@Radio bit ,        
@Signaleur bit ,        
@InstructionsSpeciales varchar(500) ,        
@SignatureOperateurSurLeTerrain bit ,        
@DetectionDesGazs bit ,        
@SignatureContremaitre bit ,        
@SignatureAutorise bit ,        
@NettoyageTransfertHorsSite bit ,        
@Soudage bit ,        
@Traitement bit ,        
@Cuissons bit ,        
@Percage bit ,        
@Chaufferette bit ,        
@Meulage bit ,        
@Nettoyage bit ,        
@AutresTravaux bit ,        
@AutresTravauxValue varchar(100),        
@TravauxDansZone bit ,        
@Combustibles bit ,        
@Ecran bit ,        
@Boyau bit ,        
@BoyauDe bit ,        
@Couverture bit ,        
@Extincteur bit ,        
@Bouche bit ,        
@RadioS bit ,        
@Surveillant bit ,        
@UtilisationMoteur bit ,        
@NettoyageAU bit ,        
@UtilisationElectronics bit ,        
@Radiographie bit ,        
@UtilisationOutlis bit ,        
@UtilisationEquipments bit ,        
@Demolition bit ,        
@AutresInstruction bit ,        
@AutresInstructionValue varchar(100),       
       
-- Other        
@DocumentLinks varchar(max) = null  ,  
@GasTestFirstResultTime datetime=NULL,   
@GasTestSecondResultTime datetime=NULL,   
@GasTestThirdResultTime datetime=NULL,   
@GasTestFourthResultTime datetime=NULL ,  
@GasTestElements Varchar(2000)=NULL  ,
@FeSValue bit    ,
 @MudsAnswerTextBox varchar(max), 
 @MudsQuestionlabel varchar(max) 
)        
AS        
        
INSERT INTO WorkPermitMudsHistory        
(        
    Id,        
 WorkPermitTypeId,        
 Template,        
 WorkPermitStatusId,        
 StartDateTime,        
 EndDateTime,        
 PermitNumber,        
 WorkOrderNumber,        
 FunctionalLocations,        
 Trade,        
 Description,        
 RequestedByGroup,
 WorkPermitCloseComments, 
 WorkpermitClosedById,
 ActionItemCloseById,
 PermitCloseDateTime,
 ActionItemCloseDateTime,
 ActionItemCheckboxchecked,                  
 LastModifiedDateTime,        
 LastModifiedByUserId,        
 IssuedDateTime,        
       
 -- Details        
[RemplirLeFormulaireDeCondition] ,        
[RemplirLeFormulaireDeConditionValue] ,        
[AnalyseCritiqueDeLaTache] ,        
[Depressurises] ,        
[Vides] ,        
[ContournementDesGDA] ,        
[Rinces] ,        
[NettoyesLaVapeur] ,        
[Purges] ,        
[Ventiles] ,        
[Aeres] ,     
[Energies] ,       
    
[Procedure] ,        
[ProcedureValue] ,        
[AutresCondition] ,        
[AutresConditionValue] ,        
[InterrupteursEtVannesCadenasses] ,        
[InterrupteursEtVannesCadenassesValue] ,        
[VerrouillagesParTravailleurs] ,        
[SourcesDesenergisees] ,        
[DepartsLocauxTestes] ,        
[ConduitesDesaccouplees] ,        
[ObturateursInstallees] ,        
[Etiquette] ,        
[EtiquetteValue] ,        
[PVCISuncorEffectuee] ,        
[PVCIEntExtEffectuee] ,        
[Amiante] ,        
[AcideSulfurique] ,        
[Azote] ,        
[Caustique] ,        
[DioxydeDeSoufre] ,        
[SBS] ,        
[Soufre] ,        
[EquipementsNonRinces] ,        
[Hydrocarbures] ,        
[HydrogeneSulfure] ,        
[MonoxydeCarbone] ,        
[Reflux] ,        
[ProduitsVolatilsUtilises] ,        
[Bacteries] ,        
[Appareil] ,        
[AppareilValue] ,        
[InterferencesEntreTravaux] ,        
[PiecesEnRotation] ,        
[IncendieExplosion] ,        
[ContrainteThermique] ,        
[Radiations] ,        
[Silice] ,        
[Vanadium] ,        
[AsphyxieIntoxication] ,        
[AutresRisques] ,        
[AutresRisquesValue] ,        
[ElectriciteVolt] ,        
[ElectriciteVoltValue] ,        
[OutillageElectrique] ,        
[TravailEnHauteur6EtPlus] ,     
[VapeurCondensat],    
[Electrisation] ,        
[LunettesMonocoques] ,        
[Visiere] ,        
[ProtectionAuditive] ,        
[CagouleIgnifuge] ,        
[Harnais2LiensDeRetenue] ,        
[Gants] ,        
[GantsValue] ,        
[MasqueACartouches] ,        
[MasqueACartouchesValue] ,        
[EPIAntiArcCAT] ,        
[EPIAntiArcCATValue] ,        
[EPIAntiChoc] ,        
[HabitProtecteur] ,        
[HabitProtecteurValue] ,        
[EcranDeflecteur] ,        
[MALTDesEquipements] ,        
[Rallonges] ,        
[ApprobationPourEquipDeLevage] ,        
[BarricadeRigide] ,        
[AutresE] ,        
[AutresEValue] ,        
[AlarmeDCS] ,        
[AlarmeDCSValue] ,        
[EchelleSecurisee] ,        
[EchafaudageApprouve] ,        
[OutilDeLaiton] ,        
[OutilDeLaitonManel] ,        
[outilDeLaitonManelValue] ,        
[PerimetreSecurite] ,       
[PerimetreSecuriteValue] ,        
[Radio] ,        
[Signaleur] ,        
[InstructionsSpeciales] ,        
[SignatureOperateurSurLeTerrain] ,        
[DetectionDesGazs] ,        
[SignatureContremaitre] ,        
[SignatureAutorise] ,        
[NettoyageTransfertHorsSite] ,        
[Soudage] ,        
[Traitement] ,        
[Cuissons] ,        
[Percage] ,        
[Chaufferette] ,        
[Meulage] ,        
[Nettoyage] ,        
[AutresTravaux] ,        
[AutresTravauxValue] ,        
[TravauxDansZone] ,        
[Combustibles] ,        
[Ecran] ,        
[Boyau] ,        
[BoyauDe] ,        
[Couverture] ,        
[Extincteur] ,        
[Bouche] ,        
[RadioS] ,        
[Surveillant] ,        
[UtilisationMoteur] ,        
[NettoyageAU] ,        
[UtilisationElectronics] ,        
[Radiographie] ,        
[UtilisationOutlis] ,        
[UtilisationEquipments] ,        
[Demolition] ,        
[AutresInstruction] ,        
[AutresInstructionValue],        
         
DocumentLinks   ,  
GasTestFirstResultTime,   
GasTestSecondResultTime ,  
GasTestThirdResultTime,  
GasTestFourthResultTime,  
GasTestElements   ,
FeSValue  ,
 MudsAnswerTextBox,
 MudsQuestionlabel
)        
VALUES        
(        
    @Id,        
 @WorkPermitTypeId,        
 @Template,        
@WorkPermitStatusId,        
 @StartDateTime,        
 @EndDateTime,        
 @PermitNumber,        
 @WorkOrderNumber,        
 @FunctionalLocations,        
 @Trade,        
 @Description,        
 @RequestedByGroup, 
 @WorkPermitCloseComments, 
 @WorkpermitClosedById,
 @ActionItemCloseById,
 @PermitCloseDateTime,
 @ActionItemCloseDateTime,
 @ActionItemCheckboxchecked,       
 @LastModifiedDateTime,        
 @LastModifiedByUserId,        
 @IssuedDateTime,        
       
 -- Details        
 @RemplirLeFormulaireDeCondition ,        
@RemplirLeFormulaireDeConditionValue ,        
@AnalyseCritiqueDeLaTache ,        
@Depressurises ,        
@Vides ,        
@ContournementDesGDA ,        
@Rinces ,        
@NettoyesLaVapeur ,        
@Purges ,        
@Ventiles ,        
@Aeres ,       
@Energies ,     
@Procedure ,        
@ProcedureValue ,        
@AutresCondition ,        
@AutresConditionValue ,        
@InterrupteursEtVannesCadenasses ,        
@InterrupteursEtVannesCadenassesValue ,        
@VerrouillagesParTravailleurs ,        
@SourcesDesenergisees ,       
@DepartsLocauxTestes ,        
@ConduitesDesaccouplees ,        
@ObturateursInstallees ,        
@Etiquette ,        
@EtiquetteValue ,        
@PVCISuncorEffectuee ,        
@PVCIEntExtEffectuee ,        
@Amiante ,        
@AcideSulfurique ,        
@Azote ,        
@Caustique ,        
@DioxydeDeSoufre ,        
@SBS ,        
@Soufre ,        
@EquipementsNonRinces ,        
@Hydrocarbures ,        
@HydrogeneSulfure ,        
@MonoxydeCarbone ,        
@Reflux ,        
@ProduitsVolatilsUtilises ,        
@Bacteries ,        
@Appareil ,        
@AppareilValue ,        
@InterferencesEntreTravaux ,        
@PiecesEnRotation ,        
@IncendieExplosion ,        
@ContrainteThermique ,        
@Radiations ,        
@Silice ,        
@Vanadium ,        
@AsphyxieIntoxication ,        
@AutresRisques ,        
@AutresRisquesValue ,        
@ElectriciteVolt ,        
@ElectriciteVoltValue ,        
@OutillageElectrique ,        
@TravailEnHauteur6EtPlus ,     
@VapeurCondensat,      
@Electrisation ,        
@LunettesMonocoques ,        
@Visiere ,        
@ProtectionAuditive ,        
@CagouleIgnifuge ,        
@Harnais2LiensDeRetenue ,        
@Gants ,        
@GantsValue ,        
@MasqueACartouches ,        
@MasqueACartouchesValue ,        
@EPIAntiArcCAT ,        
@EPIAntiArcCATValue ,        
@EPIAntiChoc ,        
@HabitProtecteur ,        
@HabitProtecteurValue ,        
@EcranDeflecteur ,        
@MALTDesEquipements ,        
@Rallonges ,        
@ApprobationPourEquipDeLevage ,        
@BarricadeRigide ,        
@AutresE ,        
@AutresEValue ,        
@AlarmeDCS ,        
@AlarmeDCSValue ,        
@EchelleSecurisee ,        
@EchafaudageApprouve ,        
@OutilDeLaiton ,        
@OutilDeLaitonManel ,        
@outilDeLaitonManelValue ,        
@PerimetreSecurite ,     
@PerimetreSecuriteValue ,       
@Radio ,        
@Signaleur ,        
@InstructionsSpeciales ,        
@SignatureOperateurSurLeTerrain ,        
@DetectionDesGazs ,        
@SignatureContremaitre ,        
@SignatureAutorise ,        
@NettoyageTransfertHorsSite ,        
@Soudage ,        
@Traitement ,        
@Cuissons ,        
@Percage ,        
@Chaufferette ,        
@Meulage ,        
@Nettoyage ,        
@AutresTravaux ,        
@AutresTravauxValue ,        
@TravauxDansZone ,        
@Combustibles ,        
@Ecran ,        
@Boyau ,        
@BoyauDe ,        
@Couverture ,        
@Extincteur ,        
@Bouche ,        
@RadioS ,        
@Surveillant ,        
@UtilisationMoteur ,        
@NettoyageAU ,        
@UtilisationElectronics ,        
@Radiographie ,        
@UtilisationOutlis ,        
@UtilisationEquipments ,        
@Demolition ,        
@AutresInstruction ,        
@AutresInstructionValue ,      
      
 @DocumentLinks ,  
 @GasTestFirstResultTime,   
@GasTestSecondResultTime ,  
@GasTestThirdResultTime,  
@GasTestFourthResultTime,  
@GasTestElements   ,
@FeSValue  ,
 @MudsAnswerTextBox,
 @MudsQuestionlabel     
);    
  
  
GRANT EXEC ON InsertWorkPermitMudsHistory TO PUBLIC  