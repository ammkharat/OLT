CREATE TABLE [dbo].[ConfinedSpace] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[ConfinedSpaceStatus] int NOT NULL,
[StartDateTime] datetime NOT NULL,
[EndDateTime] datetime NOT NULL,
[ConfinedSpaceNumber] bigint NULL,
[FunctionalLocationId] bigint NOT NULL,
[H2S] bit NOT NULL,
[Hydrocarbure] bit NOT NULL,
[Ammoniaque] bit NOT NULL,
[Corrosif] bit NOT NULL,
[CorrosifValue] VARCHAR(50) NULL,
[Aromatique] bit NOT NULL,
[AromatiqueValue] VARCHAR(50) NULL,
[AutresSubstances] bit NOT NULL,
[AutresSubstancesValue] VARCHAR(50) NULL,
[ObtureOuDebranche] bit NOT NULL,
[DepressuriseEtVidange] bit NOT NULL,
[EnPresenceDeGazInerte] bit NOT NULL,
[PurgeALaVapeur] bit NOT NULL,
[DessinsRequis] bit NOT NULL,
[DessinsRequisValue] VARCHAR(50) NULL,
[PlanDeSauvetage] bit NOT NULL,
[CablesChauffantsMisHorsTension] bit NOT NULL,
[InterrupteursElectriquesVerrouilles] bit NOT NULL,
[PurgeParUnGazInerte] bit NOT NULL,
[RinceAlEau] bit NOT NULL,
[VentilationMecanique] bit NOT NULL,
[BouchesDegoutProtegees] bit NOT NULL,
[PossibiliteDeSulfureDeFer] bit NOT NULL,
[AereVentile] bit NOT NULL,
[AutreConditions] bit NOT NULL,
[AutreConditionsValue] VARCHAR(50) NULL,
[VentilationNaturelle] bit NOT NULL,
[InstructionsSpeciales] VARCHAR(450) NULL,
[CreatedDateTime] datetime NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[Deleted] bit NOT NULL,
CONSTRAINT [ConfinedSpace_PK]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [ConfinedSpace_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),
CONSTRAINT [ConfinedSpace_CreatedUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [ConfinedSpace_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
)
ON [PRIMARY];
GO
GO
