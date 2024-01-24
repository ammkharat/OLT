IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'zz_AddTestConfinedSpace')
	BEGIN
		DROP  Procedure  [dbo].zz_AddTestConfinedSpace
	END

GO

CREATE Procedure [dbo].zz_AddTestConfinedSpace
	(
		@CONFINED_SPACE_NUMBER as bigint,
		@FLOC AS VARCHAR(MAX),
		@START AS DATETIME,
		@END AS DATETIME,
		@USER_NAME AS varchar(max),
		@INSTRUCTIONS_SPECIAL AS VARCHAR(MAX)
	)

AS

DECLARE @USER_ID AS BIGINT;
SET @USER_ID = (select Id from [User] where username = @USER_NAME);

DECLARE @FLOC_ID AS BIGINT;
SET @FLOC_ID = (select Id from FunctionalLocation where fullhierarchy = @FLOC);

DECLARE @DATE as datetime;
set @DATE = getdate();

INSERT INTO dbo.ConfinedSpace (
   ConfinedSpaceStatus
  ,StartDateTime
  ,EndDateTime
  ,ConfinedSpaceNumber
  ,FunctionalLocationId
  ,H2S
  ,Hydrocarbure
  ,Ammoniaque
  ,Corrosif
  ,CorrosifValue
  ,Aromatique
  ,AromatiqueValue
  ,AutresSubstances
  ,AutresSubstancesValue
  ,ObtureOuDebranche
  ,DepressuriseEtVidange
  ,EnPresenceDeGazInerte
  ,PurgeALaVapeur
  ,DessinsRequis
  ,DessinsRequisValue
  ,PlanDeSauvetage
  ,CablesChauffantsMisHorsTension
  ,InterrupteursElectriquesVerrouilles
  ,PurgeParUnGazInerte
  ,RinceAlEau
  ,VentilationMecanique
  ,BouchesDegoutProtegees
  ,PossibiliteDeSulfureDeFer
  ,AereVentile
  ,AutreConditions
  ,AutreConditionsValue
  ,VentilationNaturelle
  ,InstructionsSpeciales
  ,CreatedDateTime
  ,CreatedByUserId
  ,LastModifiedDateTime
  ,LastModifiedByUserId
  ,Deleted
) VALUES (
   1,
	@START + datediff(day, '2011-11-21', getdate()) ,
	@END + datediff(day, '2011-11-21', getdate()) ,
  @CONFINED_SPACE_NUMBER   -- ConfinedSpaceNumber - bigint
  ,	@FLOC_ID,   -- FunctionalLocationId - bigint
  0  -- H2S - bit
  ,0  -- Hydrocarbure - bit
  ,0  -- Ammoniaque - bit
  ,0  -- Corrosif - bit
  ,null  -- CorrosifValue - varchar(50)
  ,0  -- Aromatique - bit
  ,null  -- AromatiqueValue - varchar(50)
  ,0  -- AutresSubstances - bit
  ,null  -- AutresSubstancesValue - varchar(50)
  ,0  -- ObtureOuDebranche - bit
  ,0  -- DepressuriseEtVidange - bit
  ,0  -- EnPresenceDeGazInerte - bit
  ,0  -- PurgeALaVapeur - bit
  ,0  -- DessinRequis - bit
  ,null  -- DessinRequisValue - varchar(50)
  ,0  -- PlanDeSauvetage - bit
  ,0  -- CablesChauffantsMisHorsTension - bit
  ,0  -- InterrupteursElectriquesVerrouilles - bit
  ,0  -- PurgeParUnGazInerte - bit
  ,''  -- RinceAlEau - bit
  ,''  -- VentilationMecanique - bit
  ,''  -- BouchesDegoutProtegees - bit
  ,''  -- PossibiliteDeSulfureDeFer - bit
  ,''  -- AereVentile - bit
  ,''  -- AutreConditions - bit
  ,null  -- AutreConditionsValue - varchar(50)
  ,''  -- VentilationNaturelle - bit
  ,@INSTRUCTIONS_SPECIAL  -- InstructionsSpeciales - varchar(450)
  ,@DATE  -- CreatedDateTime - datetime
  ,@USER_ID   -- CreatedByUserId - bigint
  ,@DATE  -- LastModifiedDateTime - datetime
  ,@USER_ID  -- LastModifiedByUserId - bigint
  ,0  -- Deleted - bit
)
GO

-- aromatics
DECLARE @unit400 AS VARCHAR(MAX);
SET @unit400 = 'MT1-A002-U400';
DECLARE @unit410 AS VARCHAR(MAX);
SET @unit410 = 'MT1-A002-U410';
DECLARE @unit450 AS VARCHAR(MAX);
SET @unit450 = 'MT1-A002-U450';
DECLARE @unit470 AS VARCHAR(MAX);
SET @unit470 = 'MT1-A002-U470';

exec zz_AddTestConfinedSpace 19048, @unit400, '2011-12-21 01:22', '2011-12-21 06:00', 'ymaranda', 'Registre de présence obligatoire'
exec zz_AddTestConfinedSpace 19047, @unit400, '2011-12-21 01:22', '2011-11-21 06:00', 'jlacroix', 'Registre de présence obligatoire'
exec zz_AddTestConfinedSpace 19046, @unit400, '2011-11-21 06:00', '2011-11-21 18:00', 'jlacroix', 'Registre de présence obligatoire'
exec zz_AddTestConfinedSpace 19026, @unit400, '2011-11-27 06:00', '2011-12-31 18:00', 'ymaranda', 'Registre de présence obligatoire'
go

-- -----------------------------------------------------------------------------------------

DROP  Procedure  [dbo].zz_AddTestConfinedSpace;

