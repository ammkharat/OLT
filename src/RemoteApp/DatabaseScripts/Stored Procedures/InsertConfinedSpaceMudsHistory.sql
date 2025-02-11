
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertConfinedSpaceMudsHistory')
	BEGIN
		DROP Procedure [dbo].InsertConfinedSpaceMudsHistory
	END
GO

  
Create Procedure [dbo].[InsertConfinedSpaceMudsHistory]  
(  
 @Id bigint,  
 @ConfinedSpaceNumber bigint,  
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
@Harnis bit

  
)  
AS  
  
  
  
INSERT INTO ConfinedSpaceMudsHistory  
(  
 Id,  
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
 LastModifiedByUserId ,
 
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
,Harnis 
)  
VALUES  
(  
 @Id,  
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
@Harnis
)  



GRANT EXEC ON InsertConfinedSpaceMudsHistory TO PUBLIC
GO
