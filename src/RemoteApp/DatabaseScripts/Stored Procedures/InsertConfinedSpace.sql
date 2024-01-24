if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertConfinedSpace]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertConfinedSpace]
GO

CREATE Procedure [dbo].[InsertConfinedSpace]
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
	@InstructionsSpeciales VARCHAR(450)
)
AS

--DECLARE @NewConfinedSpaceNumber bigint

IF @ShouldCreateConfinedSpaceNumber = 1
	BEGIN
		EXEC @ConfinedSpaceNumber = GetNewSeqVal_ConfinedSpaceNumberSequence
	END
ELSE
	BEGIN
		SET @ConfinedSpaceNumber = NULL
	END


INSERT INTO ConfinedSpace
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
	Deleted
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
	0
)

SET @Id= SCOPE_IDENTITY() 
--SET @ConfinedSpaceNumber = @NewConfinedSpaceNumber
GO