
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ConfinedSpaceMudsHistory]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[ConfinedSpaceMudsHistory](
	[Id] [bigint] NOT NULL,
	[ConfinedSpaceStatus] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[ConfinedSpaceNumber] [bigint] NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[H2S] [bit] NOT NULL,
	[Hydrocarbure] [bit] NOT NULL,
	[Ammoniaque] [bit] NOT NULL,
	[Corrosif] [bit] NOT NULL,
	[CorrosifValue] [varchar](50) NULL,
	[Aromatique] [bit] NOT NULL,
	[AromatiqueValue] [varchar](50) NULL,
	[AutresSubstances] [bit] NOT NULL,
	[AutresSubstancesValue] [varchar](50) NULL,
	[ObtureOuDebranche] [bit] NOT NULL,
	[DepressuriseEtVidange] [bit] NOT NULL,
	[EnPresenceDeGazInerte] [bit] NOT NULL,
	[PurgeALaVapeur] [bit] NOT NULL,
	[DessinsRequis] [bit] NOT NULL,
	[DessinsRequisValue] [varchar](50) NULL,
	[PlanDeSauvetage] [bit] NOT NULL,
	[CablesChauffantsMisHorsTension] [bit] NOT NULL,
	[InterrupteursElectriquesVerrouilles] [bit] NOT NULL,
	[PurgeParUnGazInerte] [bit] NOT NULL,
	[RinceAlEau] [bit] NOT NULL,
	[VentilationMecanique] [bit] NOT NULL,
	[BouchesDegoutProtegees] [bit] NOT NULL,
	[PossibiliteDeSulfureDeFer] [bit] NOT NULL,
	[AereVentile] [bit] NOT NULL,
	[AutreConditions] [bit] NOT NULL,
	[AutreConditionsValue] [varchar](50) NULL,
	[VentilationNaturelle] [bit] NOT NULL,
	[InstructionsSpeciales] [varchar](450) NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[SO2] [bit] NULL,
	[NH3] [bit] NULL,
	[AcideSulfurique] [bit] NULL,
	[CO] [bit] NULL,
	[Azote] [bit] NULL,
	[Reflux] [bit] NULL,
	[NaOH] [bit] NULL,
	[SBS] [bit] NULL,
	[Soufre] [bit] NULL,
	[Amiante] [bit] NULL,
	[Bacteries] [bit] NULL,
	[Depressurise] [bit] NULL,
	[Rince] [bit] NULL,
	[Obture] [bit] NULL,
	[Nettoyes] [bit] NULL,
	[Purge] [bit] NULL,
	[Vide] [bit] NULL,
	[Dessins] [bit] NULL,
	[DetectionDeGaz] [bit] NULL,
	[PSS] [bit] NULL,
	[VentilationEn] [bit] NULL,
	[VentilationForce] [bit] NULL,
	[Harnis] [bit] NULL
) ON [PRIMARY]

End


