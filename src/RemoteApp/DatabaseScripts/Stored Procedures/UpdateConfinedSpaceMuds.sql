 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateConfinedSpaceMuds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateConfinedSpaceMuds]
Go 
Create Procedure [dbo].[UpdateConfinedSpaceMuds]  
(  
 @Id bigint,  
 @ConfinedSpaceStatus int,  
 @StartDateTime datetime,  
 @EndDateTime datetime,  
 @FunctionalLocationId bigint,  
 @LastModifiedDateTime datetime,  
 @LastModifiedByUserId bigint,  
 @H2S bit,  
 @Hydrocarbure bit,  
 @Ammoniaque bit,  
 @Corrosif bit,   
 @CorrosifValue VARCHAR(50),  
 @Aromatique bit,   
 @AromatiqueValue VARCHAR(50),  
 @AutresSubstances bit,   
 @AutresSubstancesValue VARCHAR(50),  
 @ObtureOuDebranche bit,  
 @DepressuriseEtVidange bit,  
 @EnPresenceDeGazInerte bit,  
 @PurgeALaVapeur bit,  
 @DessinsRequis bit,   
 @DessinsRequisValue VARCHAR(50),  
 @PlanDeSauvetage bit,  
 @CablesChauffantsMisHorsTension bit,  
 @InterrupteursElectriquesVerrouilles bit,  
 @PurgeParUnGazInerte bit,  
 @RinceAlEau bit,  
 @VentilationMecanique bit,  
 @BouchesDegoutProtegees bit,  
 @PossibiliteDeSulfureDeFer bit,  
 @AereVentile bit,  
 @AutreConditions bit,   
 @AutreConditionsValue VARCHAR(50),  
 @VentilationNaturelle bit,  
 @InstructionsSpeciales VARCHAR(450),  
   
@SO2  bit,  
@NH3  bit,  
@AcideSulfurique  bit,  
@CO  bit,  
@Azote  bit,  
@Reflux  bit,  
@NaOH  bit,  
@SBS  bit,  
@Soufre  bit,  
@Amiante  bit,  
@Bacteries  bit,  
@Depressurise  bit,  
@Rince  bit,  
@Obture  bit,  
@Nettoyes  bit,  
@Purge  bit,  
@Vide  bit,  
@Dessins   bit,  
@DetectionDeGaz  bit,  
@PSS  bit,  
@VentilationEn  bit,  
@VentilationForce  bit,  
@Harnis bit ,
@GasTestFirstResultTime datetime=NULL,       
@GasTestSecondResultTime datetime=NULL,       
@GasTestThirdResultTime datetime=NULL,       
@GasTestFourthResultTime datetime=NULL  
  
)  
AS  
  
UPDATE ConfinedSpaceMuds  
  SET  
 ConfinedSpaceStatus = @ConfinedSpaceStatus,  
   StartDateTime = @StartDateTime,  
   EndDateTime = @EndDateTime,  
   FunctionalLocationId = @FunctionalLocationId,  
   H2S = @H2S,  
   Hydrocarbure = @Hydrocarbure,  
   Ammoniaque = @Ammoniaque,  
   Corrosif = @Corrosif,   
   CorrosifValue = @CorrosifValue,  
   Aromatique = @Aromatique,   
   AromatiqueValue = @AromatiqueValue,  
   AutresSubstances = @AutresSubstances,   
   AutresSubstancesValue = @AutresSubstancesValue,  
   ObtureOuDebranche = @ObtureOuDebranche,  
   DepressuriseEtVidange = @DepressuriseEtVidange,  
   EnPresenceDeGazInerte = @EnPresenceDeGazInerte,  
   PurgeALaVapeur = @PurgeALaVapeur,  
   DessinsRequis = @DessinsRequis,   
   DessinsRequisValue = @DessinsRequisValue,  
   PlanDeSauvetage = @PlanDeSauvetage,  
   CablesChauffantsMisHorsTension = @CablesChauffantsMisHorsTension,  
   InterrupteursElectriquesVerrouilles = @InterrupteursElectriquesVerrouilles,  
   PurgeParUnGazInerte = @PurgeParUnGazInerte,  
   RinceAlEau = @RinceAlEau,  
   VentilationMecanique = @VentilationMecanique,  
   BouchesDegoutProtegees = @BouchesDegoutProtegees,  
   PossibiliteDeSulfureDeFer = @PossibiliteDeSulfureDeFer,  
   AereVentile = @AereVentile,  
   AutreConditions = @AutreConditions,   
   AutreConditionsValue = @AutreConditionsValue,  
   VentilationNaturelle = @VentilationNaturelle,  
   InstructionsSpeciales = @InstructionsSpeciales,  
   LastModifiedDateTime = @LastModifiedDateTime,  
   LastModifiedByUserId = @LastModifiedByUserId,  
     
SO2  = @SO2 ,  
NH3  = @NH3 ,  
AcideSulfurique  = @AcideSulfurique ,  
CO  = @CO ,  
Azote  = @Azote ,  
Reflux  = @Reflux ,  
NaOH  = @NaOH ,  
SBS  = @SBS ,  
Soufre  = @Soufre ,  
Amiante  = @Amiante ,  
Bacteries  = @Bacteries ,  
Depressurise  = @Depressurise ,  
Rince  = @Rince ,  
Obture  = @Obture ,  
Nettoyes  = @Nettoyes ,  
Purge  = @Purge ,  
Vide  = @Vide ,  
Dessins   = @Dessins  ,  
DetectionDeGaz  = @DetectionDeGaz ,  
PSS  = @PSS ,  
VentilationEn  = @VentilationEn ,  
VentilationForce  = @VentilationForce ,  
Harnis = @Harnis  ,
GasTestFirstResultTime=@GasTestFirstResultTime,      
GasTestSecondResultTime=@GasTestSecondResultTime,       
GasTestThirdResultTime=@GasTestThirdResultTime,       
GasTestFourthResultTime =@GasTestFourthResultTime
  
  
   
     
WHERE Id = @Id  
  
  
  
GRANT EXEC ON UpdateConfinedSpaceMuds TO PUBLIC  