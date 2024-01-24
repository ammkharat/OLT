if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertConfinedSpaceMuds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertConfinedSpaceMuds]
Go   
Create Procedure [dbo].[InsertConfinedSpaceMuds]    
(    
 @Id bigint Output,    
 @ConfinedSpaceNumber bigint Output,    
 @ShouldCreateConfinedSpaceNumber bit,    
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
 @InstructionsSpeciales VARCHAR(450) ,  
   
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
@Harnis bit,
@GasTestFirstResultTime datetime=NULL,       
@GasTestSecondResultTime datetime=NULL,       
@GasTestThirdResultTime datetime=NULL,       
@GasTestFourthResultTime datetime=NULL  
  
 
)    
AS    
    
--DECLARE @NewConfinedSpaceNumber bigint    
    
IF @ShouldCreateConfinedSpaceNumber = 1    
 BEGIN    
  EXEC @ConfinedSpaceNumber = GetNewSeqVal_ConfinedSpaceMudsNumberSequence    
 END    
ELSE    
 BEGIN    
  SET @ConfinedSpaceNumber = NULL    
 END    
    
    
INSERT INTO ConfinedSpaceMuds    
(    
 ConfinedSpaceNumber,    
 ConfinedSpaceStatus,    
 StartDateTime,    
 EndDateTime,    
 FunctionalLocationId,    
 H2S,    
 Hydrocarbure,    
 Ammoniaque,    
 Corrosif,     
 CorrosifValue,    
 Aromatique,     
 AromatiqueValue,    
 AutresSubstances,     
 AutresSubstancesValue,    
 ObtureOuDebranche,    
 DepressuriseEtVidange,    
 EnPresenceDeGazInerte,    
 PurgeALaVapeur,    
 DessinsRequis,     
 DessinsRequisValue,    
 PlanDeSauvetage,    
 CablesChauffantsMisHorsTension,    
 InterrupteursElectriquesVerrouilles,    
 PurgeParUnGazInerte,    
 RinceAlEau,    
 VentilationMecanique,    
 BouchesDegoutProtegees,    
 PossibiliteDeSulfureDeFer,    
 AereVentile,    
 AutreConditions,     
 AutreConditionsValue,    
 VentilationNaturelle,    
 InstructionsSpeciales,    
 LastModifiedDateTime,    
 LastModifiedByUserId,    
 CreatedDateTime,    
 CreatedByUserId,    
 Deleted  ,  
  
SO2   
,NH3   
,AcideSulfurique   
,CO   
,Azote   
,Reflux   
,NaOH   
,SBS   
,Soufre   
,Amiante   
,Bacteries   
,Depressurise   
,Rince   
,Obture   
,Nettoyes   
,Purge   
,Vide   
,Dessins    
,DetectionDeGaz   
,PSS   
,VentilationEn   
,VentilationForce   
,Harnis ,
GasTestFirstResultTime ,    
GasTestSecondResultTime,       
GasTestThirdResultTime,       
GasTestFourthResultTime 
  
)    
VALUES    
(    
 @ConfinedSpaceNumber,    
 @ConfinedSpaceStatus,    
 @StartDateTime,    
 @EndDateTime,    
 @FunctionalLocationId,    
 @H2S,    
 @Hydrocarbure,    
 @Ammoniaque,    
 @Corrosif,     
 @CorrosifValue,    
 @Aromatique,     
 @AromatiqueValue,    
 @AutresSubstances,     
 @AutresSubstancesValue,    
 @ObtureOuDebranche,    
 @DepressuriseEtVidange,    
 @EnPresenceDeGazInerte,    
 @PurgeALaVapeur,    
 @DessinsRequis,     
 @DessinsRequisValue,    
 @PlanDeSauvetage,    
 @CablesChauffantsMisHorsTension,    
 @InterrupteursElectriquesVerrouilles,    
 @PurgeParUnGazInerte,    
 @RinceAlEau,    
 @VentilationMecanique,    
 @BouchesDegoutProtegees,    
 @PossibiliteDeSulfureDeFer,    
 @AereVentile,    
 @AutreConditions,     
 @AutreConditionsValue,    
 @VentilationNaturelle,    
 @InstructionsSpeciales,    
 @LastModifiedDateTime,    
 @LastModifiedByUserId,    
 @LastModifiedDateTime,    
 @LastModifiedByUserId,    
 0  ,  
   
 @SO2 ,  
@NH3 ,  
@AcideSulfurique ,  
@CO ,  
@Azote ,  
@Reflux ,  
@NaOH ,  
@SBS ,  
@Soufre ,  
@Amiante ,  
@Bacteries ,  
@Depressurise ,  
@Rince ,  
@Obture ,  
@Nettoyes ,  
@Purge ,  
@Vide ,  
@Dessins  ,  
@DetectionDeGaz ,  
@PSS ,  
@VentilationEn ,  
@VentilationForce ,  
@Harnis ,
@GasTestFirstResultTime ,       
@GasTestSecondResultTime ,       
@GasTestThirdResultTime ,       
@GasTestFourthResultTime  
  
)    
    
SET @Id= SCOPE_IDENTITY()     
--SET @ConfinedSpaceNumber = @NewConfinedSpaceNumber    
  
  
GRANT EXEC ON InsertConfinedSpaceMuds TO PUBLIC  