/****** Object:  Table [dbo].[DBVersion]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DBVersion')
	BEGIN
		DROP  table  [dbo].[DBVersion]
	END

GO

CREATE TABLE [dbo].[DBVersion](
	[VersionNumber] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[DeviationAlertResponseHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DeviationAlertResponseHistory')
	BEGIN
		DROP  table  [dbo].[DeviationAlertResponseHistory]
	END
GO

CREATE TABLE [dbo].[DeviationAlertResponseHistory](
	[Id] [bigint] NOT NULL,
	[ReasonCodes] [varchar](max) NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/

CREATE CLUSTERED INDEX [IDX_DeviationAlertResponseHistory] ON [dbo].[DeviationAlertResponseHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
/****************************************************************************************************************************************************************************************/

/****** Object:  Table [dbo].[EventSinks]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'EventSinks')
	BEGIN
		DROP  table  [dbo].[EventSinks]
	END
GO
CREATE TABLE [dbo].[EventSinks](
	[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CreationTime] [smalldatetime] NULL,
	[ClientUri] [varchar](500) NOT NULL,
	[SiteId] [bigint] NULL,
	[FullHierarchyList] [varchar](max) NULL,
	[WorkPermitEdmontonFullHierarchyList] [varchar](max) NULL,
	[ClientReadableVisibilityGroupIdList] [varchar](max) NULL,
 CONSTRAINT [PK_EventSinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_EventSinks_ClientUri] ON [dbo].[EventSinks] 
(
	[ClientUri] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[DocumentRootPathConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DocumentRootPathConfiguration')
	BEGIN
		DROP  table  [dbo].[DocumentRootPathConfiguration]
	END
GO
CREATE TABLE [dbo].[DocumentRootPathConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PathName] [varchar](50) NOT NULL,
	[UncPath] [varchar](200) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentRootPathConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[EdmontonPerson]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'EdmontonPerson')
	BEGIN
		DROP  table  [dbo].[EdmontonPerson]
	END
GO
CREATE TABLE [dbo].[EdmontonPerson](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[BadgeId] [varchar](50) NOT NULL,
	[LastScan] [datetime] NOT NULL,
	[ScanStatus] [tinyint] NOT NULL,
	[Deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[CustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomFieldGroup')
	BEGIN
		DROP  table  [dbo].[CustomFieldGroup]
	END
GO
CREATE TABLE [dbo].[CustomFieldGroup](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[AppliesToLogs] [bit] NOT NULL,
	[AppliesToSummaryLogs] [bit] NOT NULL,
	[AppliesToDailyDirectives] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[OriginCustomFieldGroupId] [bigint] NULL,
 CONSTRAINT [PK_SummaryLogCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[ConfinedSpaceNumberSequence]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ConfinedSpaceNumberSequence')
	BEGIN
		DROP  table  [dbo].[ConfinedSpaceNumberSequence]
	END
GO
CREATE TABLE [dbo].[ConfinedSpaceNumberSequence](
	[SeqID] [bigint] IDENTITY(25000,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[ConfinedSpaceHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ConfinedSpaceHistory')
	BEGIN
		DROP  table  [dbo].[ConfinedSpaceHistory]
	END
GO
CREATE TABLE [dbo].[ConfinedSpaceHistory](
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
	[LastModifiedByUserId] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_ConfinedSpaceHistory] ON [dbo].[ConfinedSpaceHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[Contractor_backup]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Contractor_backup')
	BEGIN
		DROP  table  [dbo].[Contractor_backup]
	END
GO
CREATE TABLE [dbo].[Contractor_backup](
	[Id] [bigint] NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[SiteId] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[ConfiguredDocumentLink]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ConfiguredDocumentLink')
	BEGIN
		DROP  table  [dbo].[ConfiguredDocumentLink]
	END
GO
CREATE TABLE [dbo].[ConfiguredDocumentLink](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Link] [varchar](1000) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ConfiguredDocumentLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[FormOilsandsIdSequence]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsIdSequence')
	BEGIN
		DROP  table  [dbo].[FormOilsandsIdSequence]
	END
GO
CREATE TABLE [dbo].[FormOilsandsIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****************************************************************************************************************************************************************************************/
/****** Object:  Table [dbo].[FormIdSequence]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormIdSequence')
	BEGIN
		DROP  table  [dbo].[FormIdSequence]
	END
GO
CREATE TABLE [dbo].[FormIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[LabAlertDefinitionHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LabAlertDefinitionHistory')
	BEGIN
		DROP  table  [dbo].[LabAlertDefinitionHistory]
	END
GO
CREATE TABLE [dbo].[LabAlertDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[TagID] [bigint] NOT NULL,
	[MinimumNumberOfSamples] [int] NOT NULL,
	[LabAlertTagQueryRange] [varchar](300) NOT NULL,
	[Schedule] [varchar](300) NOT NULL,
	[LabAlertDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[ObjectLock]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ObjectLock')
	BEGIN
		DROP  table  [dbo].[ObjectLock]
	END
GO
CREATE TABLE [dbo].[ObjectLock](
	[ObjectIdentifier] [varchar](255) NOT NULL,
	[LockedByUserId] [bigint] NOT NULL,
	[LockedByGuid] [varchar](255) NOT NULL,
	[LockedOnDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_[ObjectLock_Identifier] ON [dbo].[ObjectLock] 
(
	[ObjectIdentifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[PermitRequestEdmontonBatchIdSequence]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestEdmontonBatchIdSequence')
	BEGIN
		DROP  table  [dbo].[PermitRequestEdmontonBatchIdSequence]
	END
GO
CREATE TABLE [dbo].[PermitRequestEdmontonBatchIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[GasLimitUnit]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'GasLimitUnit')
	BEGIN
		DROP  table  [dbo].[GasLimitUnit]
	END
GO
CREATE TABLE [dbo].[GasLimitUnit](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Unit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GasLimitUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[User]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'User')
	BEGIN
		DROP  table  [dbo].[User]
	END
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Firstname] [varchar](25) NULL,
	[Lastname] [varchar](25) NULL,
	[SAPId] [char](8) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_User_Id_Include] ON [dbo].[User] 
(
	[Id] ASC
)
INCLUDE ( [Username],
[Firstname],
[Lastname]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_User_Unique_Username] ON [dbo].[User] 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[UserWorkPermitDefaultTimesPreference]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserWorkPermitDefaultTimesPreference')
	BEGIN
		DROP  table  [dbo].[UserWorkPermitDefaultTimesPreference]
	END
GO
CREATE TABLE [dbo].[UserWorkPermitDefaultTimesPreference](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PreShiftPadding] [datetime] NOT NULL,
	[PostShiftPadding] [datetime] NOT NULL,
 CONSTRAINT [PK_Userworkpermitdefaulttimespreference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TargetDefinitionHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionHistory')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionHistory]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[NeverToExceedMax] [decimal](9, 2) NULL,
	[NeverToExceedMin] [decimal](9, 2) NULL,
	[MaxValue] [decimal](9, 2) NULL,
	[MinValue] [decimal](9, 2) NULL,
	[NeverToExceedMaxFrequency] [int] NULL,
	[NeverToExceedMinFrequency] [int] NULL,
	[MaxValueFrequency] [int] NULL,
	[MinValueFrequency] [int] NULL,
	[TargetDefinitionValue] [varchar](50) NULL,
	[GapUnitValue] [decimal](9, 2) NULL,
	[TargetDefinitionStatusID] [bigint] NOT NULL,
	[TargetCategoryID] [bigint] NOT NULL,
	[TagID] [bigint] NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[GenerateActionItem] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
	[Schedule] [varchar](300) NOT NULL,
	[AlertRequired] [bit] NULL,
	[RequiresApproval] [bit] NOT NULL,
	[RequiresResponseWhenAlerted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[OperationalModeId] [int] NOT NULL,
	[AssociatedTargets] [varchar](200) NULL,
	[DocumentLinks] [varchar](1000) NULL,
	[PreApprovedNeverToExceedMin] [decimal](9, 2) NULL,
	[PreApprovedNeverToExceedMax] [decimal](9, 2) NULL,
	[PreApprovedMin] [decimal](9, 2) NULL,
	[PreApprovedMax] [decimal](9, 2) NULL,
	[PriorityId] [bigint] NOT NULL,
	[ReadWriteConfiguration] [varchar](300) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_TargetDefinitionHistory] ON [dbo].[TargetDefinitionHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TrainingBlock]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TrainingBlock')
	BEGIN
		DROP  table  [dbo].[TrainingBlock]
	END
GO
CREATE TABLE [dbo].[TrainingBlock](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Code] [varchar](100) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_TrainingBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkPermitLubesGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitLubesGroup')
	BEGIN
		DROP  table  [dbo].[WorkPermitLubesGroup]
	END
GO
CREATE TABLE [dbo].[WorkPermitLubesGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitLubesGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkPermitEdmontonPermitNumberSequence]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitEdmontonPermitNumberSequence')
	BEGIN
		DROP  table  [dbo].[WorkPermitEdmontonPermitNumberSequence]
	END
GO
CREATE TABLE [dbo].[WorkPermitEdmontonPermitNumberSequence](
	[SeqID] [bigint] IDENTITY(600000,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkOrderImportData]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkOrderImportData')
	BEGIN
		DROP  table  [dbo].[WorkOrderImportData]
	END
GO
CREATE TABLE [dbo].[WorkOrderImportData](
	[BatchId] [bigint] NOT NULL,
	[BatchItemCreatedDateTime] [datetime] NOT NULL,
	[SubmittedByUserId] [bigint] NOT NULL,
	[WONumber] [varchar](100) NULL,
	[ShortText] [varchar](500) NULL,
	[FunctionalLocation] [varchar](100) NULL,
	[EquipmentNumber] [varchar](50) NULL,
	[PlantId] [varchar](25) NULL,
	[LanguageCode] [varchar](10) NULL,
	[Priority] [varchar](10) NULL,
	[PlannerGroup] [varchar](50) NULL,
	[OperationKeyNo] [varchar](50) NULL,
	[OperationNumber] [varchar](10) NULL,
	[Suboperation] [varchar](50) NULL,
	[EarliestStartDate] [varchar](50) NULL,
	[EarliestStartTime] [varchar](50) NULL,
	[EarliestFinishDate] [varchar](50) NULL,
	[EarliestFinishTime] [varchar](50) NULL,
	[LongText] [varchar](max) NULL,
	[WorkPermitType] [varchar](50) NULL,
	[WorkPermitAttrib] [varchar](500) NULL,
	[WorkCenterID] [varchar](50) NULL,
	[WorkCenterName] [varchar](50) NULL,
	[WorkCenterText] [varchar](50) NULL,
	[ProcessStatus] [varchar](50) NULL,
	[ImportDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkOrderImportData_BatchId] ON [dbo].[WorkOrderImportData] 
(
	[BatchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[WorkPermitHistory_Extension]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitHistory_Extension')
	BEGIN
		DROP  table  [dbo].[WorkPermitHistory_Extension]
	END
GO
CREATE TABLE [dbo].[WorkPermitHistory_Extension](
	[Id] [bigint] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[SpecialFallOtherDescription] [varchar](50) NULL,
	[SpecialFallRestraint] [bit] NOT NULL,
	[SpecialFallSelfRetractingDevice] [bit] NOT NULL,
	[SpecialFallTieoffRequired] [bit] NULL,
	[GasTestForkliftNotUsed] [bit] NOT NULL,
	[AdditionalIsEnergizedElectricalForm] [bit] NOT NULL,
	[AdditionalIsNotApplicable] [bit] NOT NULL,
	[StartTimeNotApplicable] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkPermitHistory_Extension] ON [dbo].[WorkPermitHistory_Extension] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[WorkPermitHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitHistory')
	BEGIN
		DROP  table  [dbo].[WorkPermitHistory]
	END
GO
CREATE TABLE [dbo].[WorkPermitHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitStatusId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[SapOperationId] [bigint] NULL,
	[PermitNumber] [varchar](50) NULL,
	[WorkOrderNumber] [varchar](50) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[PermitValidDateTime] [datetime] NULL,
	[WorkPermitTypeId] [bigint] NOT NULL,
	[WorkPermitTypeClassificationId] [bigint] NOT NULL,
	[WorkOrderDescription] [varchar](max) NULL,
	[SpecialPrecautionsOrConsiderationsDescription] [varchar](max) NULL,
	[PermitConfinedSpaceEntry] [bit] NOT NULL,
	[PermitBreathingAirOrSCBA] [bit] NOT NULL,
	[PermitElectricalSwitching] [bit] NOT NULL,
	[PermitVehicleEntry] [bit] NOT NULL,
	[PermitHotTap] [bit] NOT NULL,
	[PermitBurnOrOpenFlame] [bit] NOT NULL,
	[PermitSystemEntry] [bit] NOT NULL,
	[PermitCriticalLift] [bit] NOT NULL,
	[PermitEnergizedElectrical] [bit] NOT NULL,
	[PermitExcavation] [bit] NOT NULL,
	[PermitAsbestos] [bit] NOT NULL,
	[PermitRadiationRadiography] [bit] NOT NULL,
	[PermitRadiationSealed] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorization] [bit] NOT NULL,
	[AdditionalFlareEntry] [bit] NOT NULL,
	[AdditionalCriticalLift] [bit] NOT NULL,
	[AdditionalExcavation] [bit] NOT NULL,
	[AdditionalHotTap] [bit] NOT NULL,
	[AdditionalSpecialWasteDisposal] [bit] NOT NULL,
	[AdditionalBlankOrBlindLists] [bit] NOT NULL,
	[AdditionalPJSROrSafetyPause] [bit] NOT NULL,
	[AdditionalAsbestosHandling] [bit] NOT NULL,
	[AdditionalRoadClosure] [bit] NOT NULL,
	[AdditionalElectrical] [bit] NOT NULL,
	[AdditionalBurnOrOpenFlameAssessment] [bit] NOT NULL,
	[AdditionalWaiverOrDeviation] [bit] NOT NULL,
	[AdditionalMSDS] [bit] NOT NULL,
	[AdditionalOtherFormsOrAssessmentsOrAuthorizations] [varchar](50) NULL,
	[ContactPersonnel] [varchar](50) NULL,
	[ContractorCompanyName] [varchar](50) NULL,
	[CraftOrTradeID] [bigint] NULL,
	[CraftOrTradeOther] [varchar](50) NULL,
	[JobStepDescription] [varchar](max) NULL,
	[CommunicationByRadio] [bit] NULL,
	[CommunicationRadioChannelOrBand] [varchar](20) NULL,
	[IsWorkPermitCommunicationNotApplicable] [bit] NOT NULL,
	[CommunicationRadioColor] [varchar](20) NULL,
	[CommunicationByOtherDescription] [varchar](50) NULL,
	[CoAuthorizationRequired] [bit] NULL,
	[CoAuthorizationDescription] [varchar](50) NULL,
	[ToolsAirTools] [bit] NOT NULL,
	[ToolsCraneOrCarrydeck] [bit] NOT NULL,
	[ToolsHandTools] [bit] NOT NULL,
	[ToolsJackhammer] [bit] NOT NULL,
	[ToolsVacuumTruck] [bit] NOT NULL,
	[ToolsCementSaw] [bit] NOT NULL,
	[ToolsElectricTools] [bit] NOT NULL,
	[ToolsHeavyEquipment] [bit] NOT NULL,
	[ToolsLanda] [bit] NOT NULL,
	[ToolsScaffolding] [bit] NOT NULL,
	[ToolsVehicle] [bit] NOT NULL,
	[ToolsCompressor] [bit] NOT NULL,
	[ToolsForklift] [bit] NOT NULL,
	[ToolsHEPAVacuum] [bit] NOT NULL,
	[ToolsManlift] [bit] NOT NULL,
	[ToolsTamper] [bit] NOT NULL,
	[ToolsHotTapMachine] [bit] NOT NULL,
	[ToolsPortLighting] [bit] NOT NULL,
	[ToolsTorch] [bit] NOT NULL,
	[ToolsWelder] [bit] NOT NULL,
	[ToolsOtherToolsDescription] [varchar](50) NULL,
	[ElectricIsolationMethodNotApplicable] [bit] NOT NULL,
	[ElectricIsolationMethodLOTO] [bit] NOT NULL,
	[ElectricIsolationMethodWiring] [bit] NOT NULL,
	[ElectricTestBumpNotApplicable] [bit] NOT NULL,
	[ElectricTestBump] [bit] NULL,
	[EquipmentNoElectricalTestBumpComments] [varchar](400) NULL,
	[EquipmentStillContainsResidualNotApplicable] [bit] NOT NULL,
	[EquipmentStillContainsResidual] [bit] NULL,
	[EquipmentStillContainsResidualComments] [varchar](400) NULL,
	[EquipmentLeakingValvesNotApplicable] [bit] NOT NULL,
	[EquipmentLeakingValves] [bit] NULL,
	[EquipmentLeakingValvesComments] [varchar](400) NULL,
	[EquipmentIsOutOfService] [bit] NULL,
	[EquipmentInServiceComments] [varchar](400) NULL,
	[EquipmentConditionNotApplicable] [bit] NOT NULL,
	[EquipmentConditionDepressured] [bit] NOT NULL,
	[EquipmentConditionDrained] [bit] NOT NULL,
	[EquipmentConditionCleaned] [bit] NOT NULL,
	[EquipmentConditionVentilated] [bit] NOT NULL,
	[EquipmentConditionH20Washed] [bit] NOT NULL,
	[EquipmentConditionNeutralized] [bit] NOT NULL,
	[EquipmentConditionPurged] [bit] NOT NULL,
	[EquipmentConditionPurgedDescription] [varchar](50) NULL,
	[EquipmentPreviousContentsNotApplicable] [bit] NOT NULL,
	[EquipmentPreviousContentsHydrocarbon] [bit] NOT NULL,
	[EquipmentPreviousContentsAcid] [bit] NOT NULL,
	[EquipmentPreviousContentsCaustic] [bit] NOT NULL,
	[EquipmentPreviousContentsH2S] [bit] NOT NULL,
	[EquipmentPreviousContentsOtherDescription] [varchar](50) NULL,
	[EquipmentIsolationMethodNotApplicable] [bit] NOT NULL,
	[EquipmentIsolationMethodBlindedorBlanked] [bit] NOT NULL,
	[EquipmentIsolationMethodBlockedIn] [bit] NOT NULL,
	[EquipmentIsolationMethodSeparation] [bit] NOT NULL,
	[EquipmentIsolationMethodMudderPlugs] [bit] NOT NULL,
	[EquipmentIsolationMethodLOTO] [bit] NOT NULL,
	[EquipmentIsolationMethodOtherDescription] [varchar](50) NULL,
	[JobSitePreparationFlowRequiredForJob] [bit] NULL,
	[JobSitePreparationFlowRequiredForJobNotApplicable] [bit] NOT NULL,
	[JobSitePreparationFlowRequiredComments] [varchar](400) NULL,
	[JobSitePreparationBondingOrGroundingRequiredNotApplicable] [bit] NOT NULL,
	[JobSitePreparationBondingOrGroundingRequired] [bit] NULL,
	[JobSitePreparationBondingGroundingNotRequiredComments] [varchar](400) NULL,
	[JobSitePreparationWeldingGroundWireInTestAreaNotApplicable] [bit] NOT NULL,
	[JobSitePreparationWeldingGroundWireInTestArea] [bit] NULL,
	[JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments] [varchar](400) NULL,
	[JobSitePreparationCriticalConditionRemainJobSiteNotApplicable] [bit] NOT NULL,
	[JobSitePreparationCriticalConditionRemainJobSite] [bit] NULL,
	[JobSitePreparationCriticalConditionsComments] [varchar](400) NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminated] [bit] NULL,
	[JobSitePreparationSurroundingConditionsAffectAreaComments] [varchar](400) NULL,
	[JobSitePreparationVestedBuddySystemInEffectNotApplicable] [bit] NOT NULL,
	[JobSitePreparationVestedBuddySystemInEffect] [bit] NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientation] [bit] NULL,
	[JobSitePreparationPermitReceiverRequiresOrientationComments] [varchar](400) NULL,
	[JobSitePreparationSewerIsolationMethodNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodSealedOrCovered] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodPlugged] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodBlindedOrBlanked] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodOtherDescription] [varchar](50) NULL,
	[JobSitePreparationVentilationMethodNotApplicable] [bit] NOT NULL,
	[JobSitePreparationVentilationMethodNaturalDraft] [bit] NOT NULL,
	[JobSitePreparationVentilationMethodLocalExhaust] [bit] NOT NULL,
	[JobSitePreparationVentilationMethodForced] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationBarricade] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNonEssentialEvac] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationPreopBoundaryRopeTape] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationOtherDescription] [varchar](50) NULL,
	[JobSitePreparationLightingElectricalRequirementNotApplicable] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementLowVoltage12V] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirement110VWithGFCI] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementGeneratorLights] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementOtherDescription] [varchar](50) NULL,
	[RadiationSealedSourceIsolationNotApplicable] [bit] NOT NULL,
	[RadiationSealedSourceIsolationLOTO] [bit] NOT NULL,
	[RadiationSealedSourceIsolationOpen] [bit] NOT NULL,
	[RadiationSealedSourceIsolationNumberOfSources] [int] NULL,
	[GasTestFrequencyOrDuration] [varchar](50) NULL,
	[GasTestConstantMonitoringRequired] [bit] NOT NULL,
	[FireConfinedSpace20ABCorDryChemicalExtinguisher] [bit] NOT NULL,
	[FireConfinedSpaceC02Extinguisher] [bit] NOT NULL,
	[FireConfinedSpaceFireResistantTarp] [bit] NOT NULL,
	[FireConfinedSpaceSparkContainment] [bit] NOT NULL,
	[FireConfinedSpaceWaterHose] [bit] NOT NULL,
	[FireConfinedSpaceSteamHose] [bit] NOT NULL,
	[FireConfinedSpaceWatchmen] [bit] NOT NULL,
	[FireConfinedSpaceOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsAirCartOrAirLine] [bit] NOT NULL,
	[RespitoryProtectionRequirementsSCBA] [bit] NOT NULL,
	[RespitoryProtectionRequirementsHalfFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsFullFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsDustMask] [bit] NOT NULL,
	[RespitoryProtectionRequirementsAirHood] [bit] NOT NULL,
	[RespitoryProtectionRequirementsOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription] [varchar](50) NULL,
	[SpecialEyeOrFaceProtectionGoggles] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionFaceshield] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionOtherDescription] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeRainCoat] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeRainPants] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothing] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothingTypeID] [bigint] NULL,
	[SpecialProtectiveClothingTypeCausticWear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeOtherDescripton] [varchar](50) NULL,
	[SpecialProtectiveFootwearChemicalImperviousBoots] [bit] NOT NULL,
	[SpecialProtectiveFootwearToeGuard] [bit] NOT NULL,
	[SpecialProtectiveFootwearOtherDescription] [varchar](50) NULL,
	[SpecialHandProtectionChemicalNeprene] [bit] NOT NULL,
	[SpecialHandProtectionNaturalRubber] [bit] NOT NULL,
	[SpecialHandProtectionNitrile] [bit] NOT NULL,
	[SpecialHandProtectionPVC] [bit] NOT NULL,
	[SpecialHandProtectionHighVoltage] [bit] NOT NULL,
	[SpecialHandProtectionWelding] [bit] NOT NULL,
	[SpecialHandProtectionLeather] [bit] NOT NULL,
	[SpecialHandProtectionOtherDescription] [varchar](50) NULL,
	[SpecialRescueOrFallBodyHarness] [bit] NOT NULL,
	[SpecialRescueOrFallLifeline] [bit] NOT NULL,
	[SpecialRescueOrFallYoYo] [bit] NOT NULL,
	[SpecialRescueOrFallRescueDevice] [bit] NOT NULL,
	[SpecialRescueOrFallOtherDescription] [varchar](50) NULL,
	[SourceId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[DocumentLinks] [varchar](500) NULL,
	[GasTestElements] [varchar](2000) NULL,
	[PermitInertConfinedSpaceEntry] [bit] NOT NULL,
	[PermitLeadAbatement] [bit] NOT NULL,
	[RespitoryProtectionRequirementsNotApplicable] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveFootwearNotApplicable] [bit] NOT NULL,
	[SpecialHandProtectionNotApplicable] [bit] NOT NULL,
	[SpecialRescueOrFallNotApplicable] [bit] NOT NULL,
	[FireConfinedSpaceNotApplicable] [bit] NOT NULL,
	[StartAndOrEndTimesFinalized] [bit] NOT NULL,
	[PermitElectricalWork] [bit] NOT NULL,
	[SpecialProtectiveFootwearMetatarsalGuard] [bit] NOT NULL,
	[SpecialProtectiveClothingTypePaperCoveralls] [bit] NOT NULL,
	[EquipmentConditionOtherDescription] [varchar](50) NULL,
	[EquipmentConditionPurgedN2] [bit] NOT NULL,
	[EquipmentConditionPurgedSteamed] [bit] NOT NULL,
	[EquipmentConditionPurgedAir] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorizationDescription] [varchar](50) NULL,
	[AdditionalBurnOrOpenFlameAssessmentDescription] [varchar](50) NULL,
	[AdditionalElectricalDescription] [varchar](50) NULL,
	[AdditionalAsbestosHandlingDescription] [varchar](50) NULL,
	[AdditionalCriticalLiftDescription] [varchar](50) NULL,
	[AdditionalWaiverOrDeviationDescription] [varchar](50) NULL,
	[AdditionalExcavationDescription] [varchar](50) NULL,
	[EquipmentAsbestosGasketsNotApplicable] [bit] NOT NULL,
	[EquipmentAsbestosGaskets] [bit] NULL,
	[EquipmentIsolationMethodCarBer] [bit] NOT NULL,
	[AdditionalRadiationApproval] [bit] NOT NULL,
	[AdditionalOnlineLeakRepairForm] [bit] NOT NULL,
	[FireConfinedSpaceHoleWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceFireWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceSpotterNumber] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeTyvekSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeKapplerSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeElectricalFlashGear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeCorrosiveClothing] [bit] NOT NULL,
	[SpecialHandProtectionChemicalGloves] [bit] NOT NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeId] [bigint] NULL,
	[ToolsChemicals] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationRadiationRope] [bit] NOT NULL,
	[EquipmentIsHazardousEnergyIsolationRequiredNotApplicable] [bit] NULL,
	[EquipmentIsHazardousEnergyIsolationRequired] [bit] NULL,
	[EquipmentLockOutMethodId] [bigint] NULL,
	[EquipmentLockOutMethodComments] [varchar](600) NULL,
	[EquipmentEnergyIsolationPlanNumber] [varchar](100) NULL,
	[EquipmentConditionsOfEIPSatisfied] [bit] NULL,
	[EquipmentConditionsOfEIPNotSatisfiedComments] [varchar](400) NULL,
	[AsbestosHazardsConsideredNotApplicable] [bit] NULL,
	[AsbestosHazardsConsidered] [bit] NULL,
	[WorkAssignmentId] [bigint] NULL,
	[GasTestTestTime] [datetime] NULL,
	[GasTestSystemEntryTestTime] [datetime] NULL,
	[GasTestConfinedSpaceTestTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkPermitHistory] ON [dbo].[WorkPermitHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[WorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitEdmontonGroup')
	BEGIN
		DROP  table  [dbo].[WorkPermitEdmontonGroup]
	END
GO
CREATE TABLE [dbo].[WorkPermitEdmontonGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DefaultToDayShiftOnSapImport] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitEdmontonGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[SummaryLogHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogHistory')
	BEGIN
		DROP  table  [dbo].[SummaryLogHistory]
	END
GO
CREATE TABLE [dbo].[SummaryLogHistory](
	[SummaryLogHistoryId] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Id] [bigint] NOT NULL,
	[FunctionalLocations] [varchar](max) NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](1000) NULL,
	[LogDateTime] [datetime] NOT NULL,
	[PlainTextComments] [varchar](max) NOT NULL,
	[DorComments] [varchar](max) NULL,
 CONSTRAINT [PK_SummaryLogHistory] PRIMARY KEY CLUSTERED 
(
	[SummaryLogHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_SummaryLogHistory_Id] ON [dbo].[SummaryLogHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Site]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Site')
	BEGIN
		DROP  table  [dbo].[Site]
	END
GO
CREATE TABLE [dbo].[Site](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TimeZone] [varchar](100) NULL,
	[ActiveDirectoryKey] [varchar](255) NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireHistory')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireHistory]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireHistory](
	[ShiftHandoverQuestionnaireHistoryId] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Id] [bigint] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireHistory] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireHistory_Id] ON [dbo].[ShiftHandoverQuestionnaireHistory] 
(
	[Id] ASC,
	[ShiftHandoverQuestionnaireHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[PermitRequestMontrealHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestMontrealHistory')
	BEGIN
		DROP  table  [dbo].[PermitRequestMontrealHistory]
	END
GO
CREATE TABLE [dbo].[PermitRequestMontrealHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[Attributes] [varchar](max) NULL,
	[SapDescription] [varchar](400) NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[RequestedByGroup] [varchar](100) NULL,
	[CompletionStatusId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_PermitRequestMontrealHistory_Id] ON [dbo].[PermitRequestMontrealHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[PermitRequestLubesImportBatchIdSequence]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestLubesImportBatchIdSequence')
	BEGIN
		DROP  table  [dbo].[PermitRequestLubesImportBatchIdSequence]
	END
GO
CREATE TABLE [dbo].[PermitRequestLubesImportBatchIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[RestrictionLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionLocation')
	BEGIN
		DROP  table  [dbo].[RestrictionLocation]
	END
GO
CREATE TABLE [dbo].[RestrictionLocation](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_RestrictionLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[RestrictionDefinitionHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionDefinitionHistory')
	BEGIN
		DROP  table  [dbo].[RestrictionDefinitionHistory]
	END
GO
CREATE TABLE [dbo].[RestrictionDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[MeasurementTagID] [bigint] NOT NULL,
	[ProductionTargetValue] [int] NULL,
	[ProductionTargetTagID] [bigint] NULL,
	[RestrictionDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsOnlyVisibleOnReports] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[RestrictionLocationItemSequence]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionLocationItemSequence')
	BEGIN
		DROP  table  [dbo].[RestrictionLocationItemSequence]
	END
GO
CREATE TABLE [dbo].[RestrictionLocationItemSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[SapWorkOrderOperation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SapWorkOrderOperation')
	BEGIN
		DROP  table  [dbo].[SapWorkOrderOperation]
	END
GO
CREATE TABLE [dbo].[SapWorkOrderOperation](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkOrderNumber] [char](12) NOT NULL,
	[OperationNumber] [char](4) NOT NULL,
	[SubOperation] [char](4) NULL,
	[OperationType] [char](2) NOT NULL,
 CONSTRAINT [PK_SapWorkOrderOperation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_SapWorkOrderOperatoin] ON [dbo].[SapWorkOrderOperation] 
(
	[WorkOrderNumber] ASC,
	[OperationNumber] ASC,
	[SubOperation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverConfiguration')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverConfiguration]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverConfiguration](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[RoleElement]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RoleElement')
	BEGIN
		DROP  table  [dbo].[RoleElement]
	END
GO
CREATE TABLE [dbo].[RoleElement](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](60) NOT NULL,
	[FunctionalArea] [varchar](100) NOT NULL,
 CONSTRAINT [PK_RoleElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkPermitMontrealTemplate]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealTemplate')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealTemplate]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealTemplate](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[H2S] [tinyint] NOT NULL,
	[Hydrocarbure] [tinyint] NOT NULL,
	[Ammoniaque] [tinyint] NOT NULL,
	[Corrosif] [tinyint] NOT NULL,
	[CorrosifValue] [varchar](100) NULL,
	[Aromatique] [tinyint] NOT NULL,
	[AromatiqueValue] [varchar](100) NULL,
	[AutresSubstances] [tinyint] NOT NULL,
	[AutresSubstancesValue] [varchar](100) NULL,
	[ObtureOuDeBranche] [tinyint] NOT NULL,
	[DepressuriseEtVidange] [tinyint] NOT NULL,
	[EnPresenceDeGazInerte] [tinyint] NOT NULL,
	[PurgeALaVapeur] [tinyint] NOT NULL,
	[RinceALEau] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[DessinsRequis] [tinyint] NOT NULL,
	[DessinsRequisValue] [varchar](100) NULL,
	[CablesChauffantsMisHorsTension] [tinyint] NOT NULL,
	[PompeOuVerinPneumatique] [tinyint] NOT NULL,
	[ChaineEtCadenasseOuScelle] [tinyint] NOT NULL,
	[InterrupteursElectriquesVerrouilles] [tinyint] NOT NULL,
	[PurgeParUnGazInerte] [tinyint] NOT NULL,
	[OutilsElectriquesOuABatteries] [tinyint] NOT NULL,
	[BoiteEnergieZero] [tinyint] NOT NULL,
	[BoiteEnergieZeroValue] [varchar](100) NULL,
	[OutilsPneumatiques] [tinyint] NOT NULL,
	[MoteurACombustionInterne] [tinyint] NOT NULL,
	[TravauxSuperposes] [tinyint] NOT NULL,
	[FormulaireDespaceClosAffiche] [tinyint] NOT NULL,
	[FormulaireDespaceClosAfficheValue] [varchar](100) NULL,
	[ExisteIlUneAnalyseDeTache] [tinyint] NOT NULL,
	[PossibiliteDeSulfureDeFer] [tinyint] NOT NULL,
	[AereVentile] [tinyint] NOT NULL,
	[SoudureALelectricite] [tinyint] NOT NULL,
	[BrulageAAcetylene] [tinyint] NOT NULL,
	[Nacelle] [tinyint] NOT NULL,
	[AutreConditions] [tinyint] NOT NULL,
	[AutreConditionsValue] [varchar](100) NULL,
	[LunettesMonocoques] [tinyint] NOT NULL,
	[HarnaisDeSecurite] [tinyint] NOT NULL,
	[EcranFacial] [tinyint] NOT NULL,
	[ProtectionAuditive] [tinyint] NOT NULL,
	[Trepied] [tinyint] NOT NULL,
	[DispositifAntiChute] [tinyint] NOT NULL,
	[ProtectionRespiratoire] [tinyint] NOT NULL,
	[ProtectionRespiratoireValue] [varchar](100) NULL,
	[Habits] [tinyint] NOT NULL,
	[HabitsValue] [varchar](100) NULL,
	[AutreProtection] [tinyint] NOT NULL,
	[AutreProtectionValue] [varchar](100) NULL,
	[Extincteur] [tinyint] NOT NULL,
	[BouchesDegoutProtegees] [tinyint] NOT NULL,
	[CouvertureAntiEtincelles] [tinyint] NOT NULL,
	[SurveillantPourEtincelles] [tinyint] NOT NULL,
	[PareEtincelles] [tinyint] NOT NULL,
	[MiseAlaTerrePresDuLieuDeTravail] [tinyint] NOT NULL,
	[BoyauAVapeur] [tinyint] NOT NULL,
	[AutresEquipementDincendie] [tinyint] NOT NULL,
	[AutresEquipementDincendieValue] [varchar](100) NULL,
	[Ventulateur] [tinyint] NOT NULL,
	[Barrieres] [tinyint] NOT NULL,
	[Surveillant] [tinyint] NOT NULL,
	[SurveillantValue] [varchar](100) NULL,
	[RadioEmetteur] [tinyint] NOT NULL,
	[PerimetreDeSecurite] [tinyint] NOT NULL,
	[DetectionContinueDesGaz] [tinyint] NOT NULL,
	[DetectionContinueDesGazValue] [varchar](100) NULL,
	[KlaxonSonore] [tinyint] NOT NULL,
	[Localiser] [tinyint] NOT NULL,
	[Amiante] [tinyint] NOT NULL,
	[AutreEquipementsSecurite] [tinyint] NOT NULL,
	[AutreEquipementsSecuriteValue] [varchar](100) NULL,
	[InstructionsSpeciales] [varchar](500) NULL,
	[SignatureOperateurSurLeTerrain] [tinyint] NOT NULL,
	[DetectionDesGazs] [tinyint] NOT NULL,
	[SignatureContremaitre] [tinyint] NOT NULL,
	[SignatureAutorise] [tinyint] NOT NULL,
	[TemplateNumber] [int] NOT NULL,
	[NettoyageTransfertHorsSite] [tinyint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkPermitMontrealHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealHistory')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealHistory]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[Template] [varchar](150) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](20) NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[Trade] [varchar](100) NULL,
	[Description] [varchar](400) NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[H2S] [bit] NOT NULL,
	[Hydrocarbure] [bit] NOT NULL,
	[Ammoniaque] [bit] NOT NULL,
	[Corrosif] [bit] NOT NULL,
	[CorrosifValue] [varchar](100) NULL,
	[Aromatique] [bit] NOT NULL,
	[AromatiqueValue] [varchar](100) NULL,
	[AutresSubstances] [bit] NOT NULL,
	[AutresSubstancesValue] [varchar](100) NULL,
	[ObtureOuDeBranche] [bit] NOT NULL,
	[DepressuriseEtVidange] [bit] NOT NULL,
	[EnPresenceDeGazInerte] [bit] NOT NULL,
	[PurgeALaVapeur] [bit] NOT NULL,
	[RinceALEau] [bit] NOT NULL,
	[Excavation] [bit] NOT NULL,
	[DessinsRequis] [bit] NOT NULL,
	[DessinsRequisValue] [varchar](100) NULL,
	[CablesChauffantsMisHorsTension] [bit] NOT NULL,
	[PompeOuVerinPneumatique] [bit] NOT NULL,
	[ChaineEtCadenasseOuScelle] [bit] NOT NULL,
	[InterrupteursElectriquesVerrouilles] [bit] NOT NULL,
	[PurgeParUnGazInerte] [bit] NOT NULL,
	[OutilsElectriquesOuABatteries] [bit] NOT NULL,
	[BoiteEnergieZero] [bit] NOT NULL,
	[BoiteEnergieZeroValue] [varchar](100) NULL,
	[OutilsPneumatiques] [bit] NOT NULL,
	[MoteurACombustionInterne] [bit] NOT NULL,
	[TravauxSuperposes] [bit] NOT NULL,
	[FormulaireDespaceClosAffiche] [bit] NOT NULL,
	[FormulaireDespaceClosAfficheValue] [varchar](100) NULL,
	[ExisteIlUneAnalyseDeTache] [bit] NOT NULL,
	[PossibiliteDeSulfureDeFer] [bit] NOT NULL,
	[AereVentile] [bit] NOT NULL,
	[SoudureALelectricite] [bit] NOT NULL,
	[BrulageAAcetylene] [bit] NOT NULL,
	[Nacelle] [bit] NOT NULL,
	[AutreConditions] [bit] NOT NULL,
	[AutreConditionsValue] [varchar](100) NULL,
	[LunettesMonocoques] [bit] NOT NULL,
	[HarnaisDeSecurite] [bit] NOT NULL,
	[EcranFacial] [bit] NOT NULL,
	[ProtectionAuditive] [bit] NOT NULL,
	[Trepied] [bit] NOT NULL,
	[DispositifAntiChute] [bit] NOT NULL,
	[ProtectionRespiratoire] [bit] NOT NULL,
	[ProtectionRespiratoireValue] [varchar](100) NULL,
	[Habits] [bit] NOT NULL,
	[HabitsValue] [varchar](100) NULL,
	[AutreProtection] [bit] NOT NULL,
	[AutreProtectionValue] [varchar](100) NULL,
	[Extincteur] [bit] NOT NULL,
	[BouchesDegoutProtegees] [bit] NOT NULL,
	[CouvertureAntiEtincelles] [bit] NOT NULL,
	[SurveillantPourEtincelles] [bit] NOT NULL,
	[PareEtincelles] [bit] NOT NULL,
	[MiseAlaTerrePresDuLieuDeTravail] [bit] NOT NULL,
	[BoyauAVapeur] [bit] NOT NULL,
	[AutresEquipementDincendie] [bit] NOT NULL,
	[AutresEquipementDincendieValue] [varchar](100) NULL,
	[Ventulateur] [bit] NOT NULL,
	[Barrieres] [bit] NOT NULL,
	[Surveillant] [bit] NOT NULL,
	[SurveillantValue] [varchar](100) NULL,
	[RadioEmetteur] [bit] NOT NULL,
	[PerimetreDeSecurite] [bit] NOT NULL,
	[DetectionContinueDesGaz] [bit] NOT NULL,
	[DetectionContinueDesGazValue] [varchar](100) NULL,
	[KlaxonSonore] [bit] NOT NULL,
	[Localiser] [bit] NOT NULL,
	[Amiante] [bit] NOT NULL,
	[AutreEquipementsSecurite] [bit] NOT NULL,
	[AutreEquipementsSecuriteValue] [varchar](100) NULL,
	[InstructionsSpeciales] [varchar](500) NULL,
	[SignatureOperateurSurLeTerrain] [bit] NOT NULL,
	[DetectionDesGazs] [bit] NOT NULL,
	[SignatureContremaitre] [bit] NOT NULL,
	[SignatureAutorise] [bit] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[RequestedByGroup] [varchar](100) NULL,
	[IssuedDateTime] [datetime] NULL,
	[NettoyageTransfertHorsSite] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkPermitMontrealHistory] ON [dbo].[WorkPermitMontrealHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[WorkPermitMontrealGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealGroup')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealGroup]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[WorkPermitMontrealPermitNumberSequence]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealPermitNumberSequence')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealPermitNumberSequence]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealPermitNumberSequence](
	[SeqID] [bigint] IDENTITY(600000,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[WorkPermitLubesPermitNumberSequence]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitLubesPermitNumberSequence')
	BEGIN
		DROP  table  [dbo].[WorkPermitLubesPermitNumberSequence]
	END
GO
CREATE TABLE [dbo].[WorkPermitLubesPermitNumberSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[WorkPermitLubesHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitLubesHistory')
	BEGIN
		DROP  table  [dbo].[WorkPermitLubesHistory]
	END
GO
CREATE TABLE [dbo].[WorkPermitLubesHistory](
	[Id] [bigint] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[DocumentLinks] [varchar](max) NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Trade] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[RequestedByGroup] [varchar](50) NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[WorkPermitStatus] [int] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](50) NULL,
	[RescuePlan] [bit] NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](50) NULL,
	[HazardousWorkApproverAdvised] [bit] NOT NULL,
	[AdditionalFollowupRequired] [bit] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[ExpireDateTime] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[HazardHydrocarbonGas] [bit] NOT NULL,
	[HazardHydrocarbonLiquid] [bit] NOT NULL,
	[HazardHydrogenSulphide] [bit] NOT NULL,
	[HazardInertGasAtmosphere] [bit] NOT NULL,
	[HazardOxygenDeficiency] [bit] NOT NULL,
	[HazardRadioactiveSources] [bit] NOT NULL,
	[HazardUndergroundOverheadHazards] [bit] NOT NULL,
	[HazardDesignatedSubstance] [bit] NOT NULL,
	[OtherHazardsAndOrRequirements] [varchar](max) NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[WorkPreparationsCompletedSectionNotApplicableToJob] [bit] NOT NULL,
	[ProductNormallyInPipingEquipment] [varchar](50) NULL,
	[DepressuredDrained] [varchar](10) NULL,
	[WaterWashed] [varchar](10) NULL,
	[Steamed] [varchar](10) NULL,
	[Purged] [varchar](10) NULL,
	[Disconnected] [varchar](10) NULL,
	[DepressuredAndVented] [varchar](10) NULL,
	[Ventilated] [varchar](10) NULL,
	[Blanked] [varchar](10) NULL,
	[DrainsCovered] [varchar](10) NULL,
	[AreaBarricated] [varchar](10) NULL,
	[EnergySourcesLockedOutTaggedOut] [varchar](10) NULL,
	[EnergyControlPlan] [varchar](15) NULL,
	[LockBoxNumber] [varchar](15) NULL,
	[OtherPreparations] [varchar](15) NULL,
	[SpecificRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[AttendedAtAllTimes] [bit] NOT NULL,
	[EyeProtection] [bit] NOT NULL,
	[FallProtectionEquipment] [bit] NOT NULL,
	[FullBodyHarnessRetrieval] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[ProtectiveClothing] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other1Value] [varchar](15) NULL,
	[EquipmentBondedGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireFightingEquipment] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[HydrantPermit] [bit] NOT NULL,
	[WaterHose] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other2Value] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[DrowningProtection] [bit] NOT NULL,
	[RespiratoryProtection] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other3Value] [varchar](15) NULL,
	[AdditionalLighting] [bit] NOT NULL,
	[DesignateHotOrColdCutChecked] [bit] NOT NULL,
	[DesignateHotOrColdCutValue] [varchar](6) NULL,
	[HoistingEquipment] [bit] NOT NULL,
	[Ladder] [bit] NOT NULL,
	[MotorizedEquipment] [bit] NOT NULL,
	[Scaffold] [bit] NOT NULL,
	[ReferToTipsProcedure] [bit] NOT NULL,
	[HighEnergy] [tinyint] NOT NULL,
	[CriticalLift] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[EnergyControlPlanFormRequirement] [tinyint] NOT NULL,
	[EquivalencyProc] [tinyint] NOT NULL,
	[TestPneumatic] [tinyint] NOT NULL,
	[LiveFlareWork] [tinyint] NOT NULL,
	[EntryAndControlPlan] [tinyint] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ChemicallyWashed] [varchar](10) NULL,
	[GasDetectorBumpTested] [bit] NOT NULL,
	[IsVehicleEntry] [bit] NOT NULL,
	[AtmosphericGasTestRequired] [bit] NOT NULL,
	[IssuedByUserId] [bigint] NULL,
	[IssuedDateTime] [datetime] NULL,
	[EnergizedElectrical] [tinyint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkPermitLubesHistory] ON [dbo].[WorkPermitLubesHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[Shift]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Shift')
	BEGIN
		DROP  table  [dbo].[Shift]
	END
GO
CREATE TABLE [dbo].[Shift](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[StartTime] [time](0) NOT NULL,
	[EndTime] [time](0) NOT NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[Schedule]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Schedule')
	BEGIN
		DROP  table  [dbo].[Schedule]
	END
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastInvokedDateTime] [datetime] NULL,
	[ScheduleTypeId] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[FromTime] [datetime] NULL,
	[ToTime] [datetime] NULL,
	[DailyFrequency] [int] NULL,
	[WeeklyFrequency] [int] NULL,
	[Monday] [bit] NULL,
	[Tuesday] [bit] NULL,
	[Wednesday] [bit] NULL,
	[Thursday] [bit] NULL,
	[Friday] [bit] NULL,
	[Saturday] [bit] NULL,
	[Sunday] [bit] NULL,
	[DayOfMonth] [int] NULL,
	[WeekOfMonth] [int] NULL,
	[January] [bit] NULL,
	[February] [bit] NULL,
	[March] [bit] NULL,
	[April] [bit] NULL,
	[May] [bit] NULL,
	[June] [bit] NULL,
	[July] [bit] NULL,
	[August] [bit] NULL,
	[September] [bit] NULL,
	[October] [bit] NULL,
	[November] [bit] NULL,
	[December] [bit] NULL,
	[Deleted] [bit] NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[DayOfWeek] [int] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Schedule_EndDateTime] ON [dbo].[Schedule] 
(
	[EndDateTime] ASC,
	[StartDateTime] ASC
)
INCLUDE ( [Id]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Schedule_TypeAndEnd] ON [dbo].[Schedule] 
(
	[ScheduleTypeId] ASC,
	[SiteId] ASC,
	[EndDateTime] ASC
)
INCLUDE ( [Id]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[SAPImportPriorityWorkPermitLubesGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SAPImportPriorityWorkPermitLubesGroup')
	BEGIN
		DROP  table  [dbo].[SAPImportPriorityWorkPermitLubesGroup]
	END
GO
CREATE TABLE [dbo].[SAPImportPriorityWorkPermitLubesGroup](
	[SAPImportPriority] [int] NULL,
	[SAPPlannerGroup] [varchar](25) NULL,
	[WorkPermitLubesGroupId] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[SAPImportPriorityWorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SAPImportPriorityWorkPermitEdmontonGroup')
	BEGIN
		DROP  table  [dbo].[SAPImportPriorityWorkPermitEdmontonGroup]
	END
GO
CREATE TABLE [dbo].[SAPImportPriorityWorkPermitEdmontonGroup](
	[SAPImportPriority] [int] NOT NULL,
	[WorkPermitEdmontonGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SAPImportPriorityWorkPermitEdmontonGroup] PRIMARY KEY CLUSTERED 
(
	[SAPImportPriority] ASC,
	[WorkPermitEdmontonGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[Role]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Role')
	BEGIN
		DROP  table  [dbo].[Role]
	END
GO
CREATE TABLE [dbo].[Role](
	[Name] [varchar](40) NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[deleted] [bit] NOT NULL,
	[ActiveDirectoryKey] [varchar](255) NOT NULL,
	[IsAdministratorRole] [bit] NOT NULL,
	[IsReadOnlyRole] [bit] NOT NULL,
	[IsWorkPermitNonOperationsRole] [bit] NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[WarnIfWorkAssignmentNotSelected] [bit] NOT NULL,
	[Alias] [varchar](10) NOT NULL,
	[IsDefaultReadOnlyRoleForSite] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[RestrictionReasonCode]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionReasonCode')
	BEGIN
		DROP  table  [dbo].[RestrictionReasonCode]
	END
GO
CREATE TABLE [dbo].[RestrictionReasonCode](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_RestrictionReasonCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[PermitRequestMontreal]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestMontreal')
	BEGIN
		DROP  table  [dbo].[PermitRequestMontreal]
	END
GO
CREATE TABLE [dbo].[PermitRequestMontreal](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
	[SourceId] [int] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[IsModified] [bit] NOT NULL,
	[SapDescription] [varchar](400) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[RequestedByGroupId] [bigint] NULL,
	[CompletionStatusId] [int] NOT NULL,
 CONSTRAINT [PK_PermitRequestMontreal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Permit_Request] ON [dbo].[PermitRequestMontreal] 
(
	[StartDate] ASC,
	[EndDate] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[PermitRequestLubesHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestLubesHistory')
	BEGIN
		DROP  table  [dbo].[PermitRequestLubesHistory]
	END
GO
CREATE TABLE [dbo].[PermitRequestLubesHistory](
	[Id] [bigint] NOT NULL,
	[CompletionStatusId] [int] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Trade] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[RequestedByGroup] [varchar](50) NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](50) NULL,
	[RescuePlan] [bit] NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](50) NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[SapDescription] [varchar](max) NULL,
	[HazardHydrocarbonGas] [bit] NOT NULL,
	[HazardHydrocarbonLiquid] [bit] NOT NULL,
	[HazardHydrogenSulphide] [bit] NOT NULL,
	[HazardInertGasAtmosphere] [bit] NOT NULL,
	[HazardOxygenDeficiency] [bit] NOT NULL,
	[HazardRadioactiveSources] [bit] NOT NULL,
	[HazardUndergroundOverheadHazards] [bit] NOT NULL,
	[HazardDesignatedSubstance] [bit] NOT NULL,
	[OtherHazardsAndOrRequirements] [varchar](max) NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[SpecificRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[AttendedAtAllTimes] [bit] NOT NULL,
	[EyeProtection] [bit] NOT NULL,
	[FallProtectionEquipment] [bit] NOT NULL,
	[FullBodyHarnessRetrieval] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[ProtectiveClothing] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other1Value] [varchar](15) NULL,
	[EquipmentBondedGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireFightingEquipment] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[HydrantPermit] [bit] NOT NULL,
	[WaterHose] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other2Value] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[DrowningProtection] [bit] NOT NULL,
	[RespiratoryProtection] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other3Value] [varchar](15) NULL,
	[AdditionalLighting] [bit] NOT NULL,
	[DesignateHotOrColdCutChecked] [bit] NOT NULL,
	[DesignateHotOrColdCutValue] [varchar](6) NULL,
	[HoistingEquipment] [bit] NOT NULL,
	[Ladder] [bit] NOT NULL,
	[MotorizedEquipment] [bit] NOT NULL,
	[Scaffold] [bit] NOT NULL,
	[ReferToTipsProcedure] [bit] NOT NULL,
	[HighEnergy] [tinyint] NOT NULL,
	[CriticalLift] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[EnergyControlPlan] [tinyint] NOT NULL,
	[EquivalencyProc] [tinyint] NOT NULL,
	[TestPneumatic] [tinyint] NOT NULL,
	[LiveFlareWork] [tinyint] NOT NULL,
	[EntryAndControlPlan] [tinyint] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[GasDetectorBumpTested] [bit] NOT NULL,
	[IsVehicleEntry] [bit] NOT NULL,
	[EnergizedElectrical] [tinyint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_PermitRequestLubesHistory_Id] ON [dbo].[PermitRequestLubesHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[PriorityPageSectionConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PriorityPageSectionConfiguration')
	BEGIN
		DROP  table  [dbo].[PriorityPageSectionConfiguration]
	END
GO
CREATE TABLE [dbo].[PriorityPageSectionConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SectionKey] [int] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SectionExpandedByDefault] [bit] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_PriorityPageSectionConfiguration_UQSectionKeyUserId] UNIQUE NONCLUSTERED 
(
	[SectionKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[Plant]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Plant')
	BEGIN
		DROP  table  [dbo].[Plant]
	END
GO
CREATE TABLE [dbo].[Plant](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NULL,
	[SiteId] [bigint] NOT NULL,
 CONSTRAINT [PlantId_Unique] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[ShiftHandoverQuestion]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestion')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestion]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestion](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Text] [varchar](150) NOT NULL,
	[HelpText] [varchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[IsCurrentQuestionVersion] [bit] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[SummaryLogCustomFieldEntryHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogCustomFieldEntryHistory')
	BEGIN
		DROP  table  [dbo].[SummaryLogCustomFieldEntryHistory]
	END
GO
CREATE TABLE [dbo].[SummaryLogCustomFieldEntryHistory](
	[SummaryLogHistoryId] [bigint] NOT NULL,
	[CustomFields] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SummaryLogCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[SummaryLogHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[TagGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TagGroup')
	BEGIN
		DROP  table  [dbo].[TagGroup]
	END
GO
CREATE TABLE [dbo].[TagGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[SiteId] [bigint] NOT NULL,
 CONSTRAINT [PK_TagGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UQ_TagGroup_Name_SiteId] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[Tag]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Tag')
	BEGIN
		DROP  table  [dbo].[Tag]
	END
GO
CREATE TABLE [dbo].[Tag](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](150) NULL,
	[Units] [varchar](32) NULL,
	[SiteId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Tag_Include] ON [dbo].[Tag] 
(
	[Id] ASC
)
INCLUDE ( [Name]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TagName_SiteAndName] ON [dbo].[Tag] 
(
	[Name] ASC,
	[SiteId] ASC,
	[Deleted] ASC
)
INCLUDE ( [Units],
[Id],
[Description]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[SiteConfigurationDefaults]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SiteConfigurationDefaults')
	BEGIN
		DROP  table  [dbo].[SiteConfigurationDefaults]
	END
GO
CREATE TABLE [dbo].[SiteConfigurationDefaults](
	[SiteId] [bigint] NOT NULL,
	[CopyTargetAlertResponseToLog] [bit] NOT NULL,
 CONSTRAINT [PK_SiteConfigurationDefaults] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_SiteConfigurationDefaults] UNIQUE NONCLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[SiteConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SiteConfiguration')
	BEGIN
		DROP  table  [dbo].[SiteConfiguration]
	END
GO
CREATE TABLE [dbo].[SiteConfiguration](
	[SiteId] [bigint] NOT NULL,
	[DaysToDisplayActionItems] [int] NOT NULL,
	[DaysToDisplayShiftLogs] [int] NOT NULL,
	[DaysBeforeArchivingClosedWorkPermits] [int] NOT NULL,
	[DaysBeforeDeletingPendingWorkPermits] [int] NOT NULL,
	[DaysBeforeClosingIssuedWorkPermits] [int] NOT NULL,
	[AutoApproveWorkOrderActionItemDefinition] [bit] NOT NULL,
	[AutoApproveSAPAMActionItemDefinition] [bit] NOT NULL,
	[AutoApproveSAPMCActionItemDefinition] [bit] NOT NULL,
	[CreateOperatingEngineerLogs] [bit] NOT NULL,
	[WorkPermitNotApplicableAutoSelected] [bit] NOT NULL,
	[WorkPermitOptionAutoSelected] [bit] NOT NULL,
	[OperatingEngineerLogDisplayName] [varchar](100) NOT NULL,
	[DaysToEditDeviationAlerts] [int] NOT NULL,
	[DaysToDisplayShiftHandovers] [int] NOT NULL,
	[SummaryLogFunctionalLocationDisplayLevel] [int] NOT NULL,
	[ShowActionItemsByWorkAssignmentOnPriorityPage] [bit] NOT NULL,
	[DaysToDisplayDeviationAlerts] [int] NOT NULL,
	[AllowStandardLogAtSecondLevelFunctionalLocation] [bit] NOT NULL,
	[DorCutoffTime] [datetime] NOT NULL,
	[DaysToDisplayWorkPermitsBackwards] [int] NOT NULL,
	[DaysToDisplayLabAlerts] [int] NOT NULL,
	[LabAlertRetryAttemptLimit] [int] NOT NULL,
	[RequireActionItemResponseLog] [bit] NOT NULL,
	[ActionItemRequiresApprovalDefaultValue] [bit] NOT NULL,
	[HideDORCommentEntry] [bit] NOT NULL,
	[DaysToDisplayCokerCards] [int] NOT NULL,
	[ActionItemRequiresResponseDefaultValue] [bit] NOT NULL,
	[ShowActionItemsOnShiftHandover] [bit] NOT NULL,
	[UseNewPriorityPage] [bit] NOT NULL,
	[ShowShiftHandoversByWorkAssignmentOnPriorityPage] [bit] NOT NULL,
	[DaysToDisplayDirectivesOnPriorityPage] [int] NOT NULL,
	[DaysToDisplayShiftHandoversOnPriorityPage] [int] NOT NULL,
	[DisplayActionItemWorkAssignmentOnPriorityPage] [bit] NOT NULL,
	[DaysToDisplayPermitRequestsBackwards] [int] NOT NULL,
	[DaysToDisplayPermitRequestsForwards] [int] NOT NULL,
	[DaysToDisplayWorkPermitsForwards] [int] NOT NULL,
	[DisplayActionItemCommentOnly] [bit] NOT NULL,
	[DefaultNumberOfCopiesForWorkPermits] [int] NOT NULL,
	[ShowFollowupOnLogForm] [bit] NOT NULL,
	[AllowCreateALogForEachSelectedFlocOnLogForm] [bit] NOT NULL,
	[ShowAdditionalDetailsOnLogFormByDefault] [bit] NOT NULL,
	[Culture] [varchar](5) NOT NULL,
	[ShowWorkPermitPrintingTabInPreferences] [bit] NOT NULL,
	[ShowDefaulPermitTimesTabInPreferences] [bit] NOT NULL,
	[DaysToDisplayTargetAlertsOnPriorityPage] [int] NOT NULL,
	[LoginFlocSelectionLevel] [int] NOT NULL,
	[UseCreatedByColumnForLogs] [bit] NOT NULL,
	[ShowIsModifiedColumnForLogs] [bit] NOT NULL,
	[ItemFlocSelectionLevel] [int] NOT NULL,
	[DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs] [bit] NOT NULL,
	[PreShiftPaddingInMinutes] [int] NOT NULL,
	[PostShiftPaddingInMinutes] [int] NOT NULL,
	[DaysToDisplayFormsBackwards] [int] NOT NULL,
	[DaysToDisplayFormsForwards] [int] NULL,
	[DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders] [bit] NOT NULL,
	[DaysToDisplayFormsBackwardsOnPriorityPage] [int] NOT NULL,
	[FormsFlocSetTypeId] [int] NOT NULL,
	[DaysToDisplaySAPNotificationsBackwards] [int] NOT NULL,
	[ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab] [bit] NOT NULL,
	[AllowCombinedShiftHandoverAndLog] [bit] NOT NULL,
	[ShowCreateShiftHandoverMessageFromNewLogClick] [bit] NOT NULL,
	[DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage] [int] NULL,
	[DefaultTargetDefinitionRequiresResponseWhenAlertedValue] [bit] NOT NULL,
	[CollectAnalyticsData] [bit] NOT NULL,
	[DaysToDisplayDirectivesBackwards] [int] NOT NULL,
	[DaysToDisplayDirectivesForwards] [int] NULL,
	[UseLogBasedDirectives] [bit] NOT NULL,
	[ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab] [bit] NOT NULL,
	[RememberActionItemWorkAssignment] [bit] NOT NULL,
 CONSTRAINT [PK_SiteConfiguration] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[SiteCommunication]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SiteCommunication')
	BEGIN
		DROP  table  [dbo].[SiteCommunication]
	END
GO
CREATE TABLE [dbo].[SiteCommunication](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Message] [varchar](300) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_SiteCommunication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[VisibilityGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'VisibilityGroup')
	BEGIN
		DROP  table  [dbo].[VisibilityGroup]
	END
GO
CREATE TABLE [dbo].[VisibilityGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[IsSiteDefault] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_GroupVisibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[WorkPermitCloseConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitCloseConfiguration')
	BEGIN
		DROP  table  [dbo].[WorkPermitCloseConfiguration]
	END
GO
CREATE TABLE [dbo].[WorkPermitCloseConfiguration](
	[SiteId] [bigint] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[RequiresLog] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitCloseConfiguration] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC,
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[UserGridLayout]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserGridLayout')
	BEGIN
		DROP  table  [dbo].[UserGridLayout]
	END
GO
CREATE TABLE [dbo].[UserGridLayout](
	[UserId] [bigint] NOT NULL,
	[GridId] [int] NOT NULL,
	[GridLayoutXml] [varchar](max) NULL,
 CONSTRAINT [PK_UserGridLayout] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GridId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[TradeChecklistHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TradeChecklistHistory')
	BEGIN
		DROP  table  [dbo].[TradeChecklistHistory]
	END
GO
CREATE TABLE [dbo].[TradeChecklistHistory](
	[Id] [bigint] NOT NULL,
	[Trade] [varchar](128) NULL,
	[Content] [nvarchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_TradeChecklistHistory] ON [dbo].[TradeChecklistHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TargetDefinitionAutoReApprovalConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionAutoReApprovalConfiguration')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionAutoReApprovalConfiguration]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionAutoReApprovalConfiguration](
	[SiteId] [bigint] NOT NULL,
	[NameChange] [bit] NOT NULL,
	[CategoryChange] [bit] NOT NULL,
	[OperationalModeChange] [bit] NOT NULL,
	[PriorityChange] [bit] NOT NULL,
	[DescriptionChange] [bit] NOT NULL,
	[DocumentLinksChange] [bit] NOT NULL,
	[FunctionalLocationChange] [bit] NOT NULL,
	[PHTagChange] [bit] NOT NULL,
	[TargetDependenciesChange] [bit] NOT NULL,
	[ScheduleChange] [bit] NOT NULL,
	[GenerateActionItemChange] [bit] NOT NULL,
	[RequiresResponseWhenAlertedChange] [bit] NOT NULL,
	[SuppressAlertChange] [bit] NOT NULL,
 CONSTRAINT [PK_TargetDefinitionAutoReApprovalConfiguration] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[UserPrintPreference]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserPrintPreference')
	BEGIN
		DROP  table  [dbo].[UserPrintPreference]
	END
GO
CREATE TABLE [dbo].[UserPrintPreference](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PrinterName] [varchar](125) NULL,
	[NumberOfCopies] [int] NOT NULL,
	[ShowPrintDialog] [bit] NOT NULL,
	[NumberOfTurnaroundCopies] [int] NOT NULL,
 CONSTRAINT [PK_UserPrintPreference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[UserPreferences]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserPreferences')
	BEGIN
		DROP  table  [dbo].[UserPreferences]
	END
GO
CREATE TABLE [dbo].[UserPreferences](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ActionItemDefinitionLastUsedWorkAssignmentId] [bigint] NULL,
 CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[HoneywellPhdConnectionInfo]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'HoneywellPhdConnectionInfo')
	BEGIN
		DROP  table  [dbo].[HoneywellPhdConnectionInfo]
	END
GO
CREATE TABLE [dbo].[HoneywellPhdConnectionInfo](
	[SiteId] [bigint] NOT NULL,
	[PhdUsername] [varchar](50) NOT NULL,
	[PhdPassword] [varchar](50) NOT NULL,
	[PhdServer] [varchar](200) NOT NULL,
	[ApiVersion] [varchar](50) NOT NULL,
	[UseWindowsAuthentication] [bit] NOT NULL,
	[DatabaseType] [varchar](20) NOT NULL,
	[DatabaseUsername] [varchar](200) NOT NULL,
	[DatabasePassword] [varchar](200) NOT NULL,
	[DatabaseServer] [varchar](200) NOT NULL,
	[DatabaseInstance] [varchar](200) NOT NULL,
	[StartTimeOffset] [int] NOT NULL,
	[EndTimeOffset] [int] NOT NULL,
	[SampleType] [varchar](50) NOT NULL,
	[SampleFrequency] [int] NULL,
	[DataReductionType] [varchar](50) NULL,
	[DataReductionFrequency] [int] NULL,
	[DataReductionOffset] [varchar](50) NULL,
	[MinimumConfidence] [int] NOT NULL,
	[MockTagWrites] [bit] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_HoneywellPhdConnectionInfo] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[GasTestElementInfoConfigurationHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'GasTestElementInfoConfigurationHistory')
	BEGIN
		DROP  table  [dbo].[GasTestElementInfoConfigurationHistory]
	END
GO
CREATE TABLE [dbo].[GasTestElementInfoConfigurationHistory](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[DisplayOrder] [int] NULL,
	[GasLimitUnitId] [bigint] NULL,
	[RangedLimit] [bit] NOT NULL,
	[ColdMaxValue] [float] NULL,
	[ColdMinValue] [float] NULL,
	[HotMaxValue] [float] NULL,
	[HotMinValue] [float] NULL,
	[CSEMaxValue] [float] NULL,
	[CSEMinValue] [float] NULL,
	[InertCSEMaxValue] [float] NULL,
	[InertCSEMinValue] [float] NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DecimalPlaceCount] [int] NOT NULL,
 CONSTRAINT [PK_GasTestElementInfoHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[GasTestElementInfo]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'GasTestElementInfo')
	BEGIN
		DROP  table  [dbo].[GasTestElementInfo]
	END
GO
CREATE TABLE [dbo].[GasTestElementInfo](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[OtherLimits] [varchar](50) NULL,
	[Standard] [bit] NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[DisplayOrder] [int] NULL,
	[GasLimitUnitId] [bigint] NULL,
	[RangedLimit] [bit] NOT NULL,
	[ColdMaxValue] [float] NULL,
	[ColdMinValue] [float] NULL,
	[HotMaxValue] [float] NULL,
	[HotMinValue] [float] NULL,
	[CSEMaxValue] [float] NULL,
	[CSEMinValue] [float] NULL,
	[InertCSEMaxValue] [float] NULL,
	[InertCSEMinValue] [float] NULL,
	[DecimalPlaceCount] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_GasTestElementInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[PermitAttribute]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitAttribute')
	BEGIN
		DROP  table  [dbo].[PermitAttribute]
	END
GO
CREATE TABLE [dbo].[PermitAttribute](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SapCode] [varchar](2) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PermitAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[LogTemplate]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogTemplate')
	BEGIN
		DROP  table  [dbo].[LogTemplate]
	END
GO
CREATE TABLE [dbo].[LogTemplate](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[AppliesToLogs] [bit] NOT NULL,
	[AppliesToSummaryLogs] [bit] NOT NULL,
	[AppliesToDirectives] [bit] NOT NULL,
 CONSTRAINT [PK_LogTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN75AHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75AHistory')
	BEGIN
		DROP  table  [dbo].[FormGN75AHistory]
	END
GO
CREATE TABLE [dbo].[FormGN75AHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[AssociatedFormGN75BId] [bigint] NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[FunctionalLocation] [varchar](max) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[FormGN59History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN59History')
	BEGIN
		DROP  table  [dbo].[FormGN59History]
	END
GO
CREATE TABLE [dbo].[FormGN59History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[ReleasedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormGN59History] ON [dbo].[FormGN59History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormGN75BHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75BHistory')
	BEGIN
		DROP  table  [dbo].[FormGN75BHistory]
	END
GO
CREATE TABLE [dbo].[FormGN75BHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[BlindsRequired] [bit] NOT NULL,
	[LockBoxNumber] [varchar](255) NULL,
	[LockBoxLocation] [varchar](255) NULL,
	[Isolations] [varchar](max) NULL,
	[SchematicImage] [varbinary](max) NULL,
	[DocumentLinks] [varchar](max) NULL,
	[FunctionalLocation] [varchar](255) NULL,
	[Location] [varchar](50) NULL,
	[EquipmentType] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN7History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN7History')
	BEGIN
		DROP  table  [dbo].[FormGN7History]
	END
GO
CREATE TABLE [dbo].[FormGN7History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormGN7History] ON [dbo].[FormGN7History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormOP14]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOP14')
	BEGIN
		DROP  table  [dbo].[FormOP14]
	END
GO
CREATE TABLE [dbo].[FormOP14](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[DepartmentId] [int] NOT NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	
 CONSTRAINT [PK_FormOP14] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormOP14_Covering_DTO] ON [dbo].[FormOP14] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_FormOP14_Covering_Job] ON [dbo].[FormOP14] 
(
	[FormStatusId] ASC,
	[ValidFromDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormTemplate]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormTemplate')
	BEGIN
		DROP  table  [dbo].[FormTemplate]
	END
GO
CREATE TABLE [dbo].[FormTemplate](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormTypeId] [int] NOT NULL,
	[Template] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[TemplateKey] [varchar](100) NULL,
	[Name] [varchar](200) NULL,
	
 CONSTRAINT [PK_FormTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[FormOvertimeFormHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOvertimeFormHistory')
	BEGIN
		DROP  table  [dbo].[FormOvertimeFormHistory]
	END
GO
CREATE TABLE [dbo].[FormOvertimeFormHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[FunctionalLocation] [varchar](max) NOT NULL,
	[TradeOccupation] [varchar](50) NOT NULL,
	[OnSitePersonnel] [varchar](max) NOT NULL,
	[Approvals] [varchar](max) NULL,
	[DocumentLinks] [varchar](max) NULL,
	[ApprovedDateTime] [datetime] NULL,
	[CancelledDateTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormOvertimeFormHistory] ON [dbo].[FormOvertimeFormHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[FormOP14History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOP14History')
	BEGIN
		DROP  table  [dbo].[FormOP14History]
	END
GO
CREATE TABLE [dbo].[FormOP14History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormOP14History] ON [dbo].[FormOP14History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormOilsandsTrainingHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsTrainingHistory')
	BEGIN
		DROP  table  [dbo].[FormOilsandsTrainingHistory]
	END
GO
CREATE TABLE [dbo].[FormOilsandsTrainingHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Approvals] [varchar](max) NULL,
	[TrainingItems] [varchar](max) NULL,
	[GeneralComments] [varchar](max) NULL,
	[TrainingDate] [date] NOT NULL,
	[ShiftName] [varchar](50) NOT NULL,
	[TotalHours] [decimal](8, 2) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormOilsandsTrainingHistory] ON [dbo].[FormOilsandsTrainingHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[BusinessCategory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'BusinessCategory')
	BEGIN
		DROP  table  [dbo].[BusinessCategory]
	END
GO
CREATE TABLE [dbo].[BusinessCategory](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[ShortName] [varchar](10) NOT NULL,
	[IsSAPWorkOrderDefault] [bit] NOT NULL,
	[IsSAPNotificationDefault] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[SiteId] [bigint] NOT NULL,
 CONSTRAINT [PK_BusinessCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[AreaLabel]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'AreaLabel')
	BEGIN
		DROP  table  [dbo].[AreaLabel]
	END
GO
CREATE TABLE [dbo].[AreaLabel](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[AllowManualSelection] [bit] NOT NULL,
	[SAPPlannerGroup] [varchar](6) NULL,
 CONSTRAINT [PK_AreaLabel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[ActionItemDefinitionAutoReApprovalConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinitionAutoReApprovalConfiguration')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinitionAutoReApprovalConfiguration]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinitionAutoReApprovalConfiguration](
	[SiteId] [bigint] NOT NULL,
	[NameChange] [bit] NOT NULL,
	[CategoryChange] [bit] NOT NULL,
	[OperationalModeChange] [bit] NOT NULL,
	[PriorityChange] [bit] NOT NULL,
	[DescriptionChange] [bit] NOT NULL,
	[DocumentLinksChange] [bit] NOT NULL,
	[FunctionalLocationsChange] [bit] NOT NULL,
	[TargetDependenciesChange] [bit] NOT NULL,
	[ScheduleChange] [bit] NOT NULL,
	[RequiresResponseWhenTriggeredChange] [bit] NOT NULL,
	[AssignmentChange] [bit] NOT NULL,
	[ActionItemGenerationModeChange] [bit] NOT NULL,
 CONSTRAINT [PK_ActionItemDefinitionAutoReApprovalConfiguration] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[Comment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Comment')
	BEGIN
		DROP  table  [dbo].[Comment]
	END
GO
CREATE TABLE [dbo].[Comment](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CreatedUserId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Text] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Comment_User] ON [dbo].[Comment] 
(
	[CreatedUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[Contractor]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Contractor')
	BEGIN
		DROP  table  [dbo].[Contractor]
	END
GO
CREATE TABLE [dbo].[Contractor](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[SiteId] [bigint] NOT NULL,
 CONSTRAINT [PK_Contractor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY],
 CONSTRAINT [UQ_Contractor_Name_Site] UNIQUE NONCLUSTERED 
(
	[CompanyName] ASC,
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN7')
	BEGIN
		DROP  table  [dbo].[FormGN7]
	END
GO
CREATE TABLE [dbo].[FormGN7](
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[Id] [bigint] NOT NULL,

 CONSTRAINT [PK_FormGN7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN7_Covering_DTO] ON [dbo].[FormGN7] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN6History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN6History')
	BEGIN
		DROP  table  [dbo].[FormGN6History]
	END
GO
CREATE TABLE [dbo].[FormGN6History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[JobDescription] [varchar](255) NULL,
	[ReasonForCriticalLift] [varchar](max) NULL,
	[Section1PlainTextContent] [nvarchar](max) NULL,
	[Section1NotApplicableToJob] [bit] NOT NULL,
	[Section2PlainTextContent] [nvarchar](max) NULL,
	[Section2NotApplicableToJob] [bit] NOT NULL,
	[Section3PlainTextContent] [nvarchar](max) NULL,
	[Section3NotApplicableToJob] [bit] NOT NULL,
	[Section4PlainTextContent] [nvarchar](max) NULL,
	[Section4NotApplicableToJob] [bit] NOT NULL,
	[Section5PlainTextContent] [nvarchar](max) NULL,
	[Section5NotApplicableToJob] [bit] NOT NULL,
	[Section6PlainTextContent] [nvarchar](max) NULL,
	[Section6NotApplicableToJob] [bit] NOT NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormGN6History] ON [dbo].[FormGN6History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN59')
	BEGIN
		DROP  table  [dbo].[FormGN59]
	END
GO
CREATE TABLE [dbo].[FormGN59](
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Id] [bigint] NOT NULL,

 CONSTRAINT [PK_FormGN59] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN59_Covering_DTO] ON [dbo].[FormGN59] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormGN24History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN24History')
	BEGIN
		DROP  table  [dbo].[FormGN24History]
	END
GO
CREATE TABLE [dbo].[FormGN24History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheSafeWorkPlanForPSVRemovalOrInstallation] [bit] NOT NULL,
	[IsTheSafeWorkPlanForWorkInTheAlkylationUnit] [bit] NOT NULL,
	[AlkylationClass] [int] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormGN24History] ON [dbo].[FormGN24History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[DropdownValue]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DropdownValue')
	BEGIN
		DROP  table  [dbo].[DropdownValue]
	END
GO
CREATE TABLE [dbo].[DropdownValue](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Key] [varchar](100) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[SiteId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealDropdownValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[Event]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Event')
	BEGIN
		DROP  table  [dbo].[Event]
	END
GO
CREATE TABLE [dbo].[Event](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SiteId] [bigint] NULL,
	[Name] [varchar](100) NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Event_DateTime] ON [dbo].[Event] 
(
	[DateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN24')
	BEGIN
		DROP  table  [dbo].[FormGN24]
	END
GO
CREATE TABLE [dbo].[FormGN24](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheSafeWorkPlanForPSVRemovalOrInstallation] [bit] NOT NULL,
	[IsTheSafeWorkPlanForWorkInTheAlkylationUnit] [bit] NOT NULL,
	[AlkylationClass] [int] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[PreJobMeetingSignatures] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL,

 CONSTRAINT [PK_FormGN24] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN24_DTO] ON [dbo].[FormGN24] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN1History]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN1History')
	BEGIN
		DROP  table  [dbo].[FormGN1History]
	END
GO
CREATE TABLE [dbo].[FormGN1History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocation] [varchar](max) NOT NULL,
	[Location] [varchar](128) NOT NULL,
	[CSELevel] [varchar](5) NOT NULL,
	[JobDescription] [varchar](256) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[PlanningWorksheetPlainTextContent] [nvarchar](max) NULL,
	[RescuePlanPlainTextContent] [nvarchar](max) NULL,
	[TradeChecklists] [varchar](max) NULL,
	[PlanningWorksheetApprovals] [varchar](max) NULL,
	[RescuePlanApprovals] [varchar](max) NULL,
	[TradeChecklistApprovals] [varchar](max) NULL,
	[DocumentLinks] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[ApprovedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_FormGN1History] ON [dbo].[FormGN1History] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[DeviationAlertResponse]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DeviationAlertResponse')
	BEGIN
		DROP  table  [dbo].[DeviationAlertResponse]
	END
GO
CREATE TABLE [dbo].[DeviationAlertResponse](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_DeviationAlertResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[CraftOrTrade]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CraftOrTrade')
	BEGIN
		DROP  table  [dbo].[CraftOrTrade]
	END
GO
CREATE TABLE [dbo].[CraftOrTrade](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[WorkCenter] [varchar](10) NULL,
	[SiteId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CraftOrTrade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[Directive]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Directive')
	BEGIN
		DROP  table  [dbo].[Directive]
	END
GO
CREATE TABLE [dbo].[Directive](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ActiveFromDateTime] [datetime] NOT NULL,
	[ActiveToDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[MigrationSource] [varchar](50) NULL,
	[ExtraInformationFromMigrationSource] [varchar](max) NULL,
 CONSTRAINT [PK_Directive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Directive_DTO] ON [dbo].[Directive] 
(
	[ActiveFromDateTime] ASC,
	[ActiveToDateTime] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[DirectiveHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DirectiveHistory')
	BEGIN
		DROP  table  [dbo].[DirectiveHistory]
	END
GO
CREATE TABLE [dbo].[DirectiveHistory](
	[Id] [bigint] NOT NULL,
	[WorkAssignments] [varchar](max) NULL,
	[FunctionalLocations] [varchar](max) NULL,
	[DocumentLinks] [varchar](max) NULL,
	[PlainTextContent] [varchar](max) NOT NULL,
	[ActiveFromDateTime] [datetime] NOT NULL,
	[ActiveToDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_DirectiveHistory_Id] ON [dbo].[DirectiveHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[DirectiveRead]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DirectiveRead')
	BEGIN
		DROP  table  [dbo].[DirectiveRead]
	END
GO
CREATE TABLE [dbo].[DirectiveRead](
	[DirectiveId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DirectiveRead] PRIMARY KEY CLUSTERED 
(
	[DirectiveId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormGN59Approval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN59Approval')
	BEGIN
		DROP  table  [dbo].[FormGN59Approval]
	END
GO
CREATE TABLE [dbo].[FormGN59Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN59Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN59Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN59Approval_GN59Id] ON [dbo].[FormGN59Approval] 
(
	[FormGN59Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN24Approval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN24Approval')
	BEGIN
		DROP  table  [dbo].[FormGN24Approval]
	END
GO
CREATE TABLE [dbo].[FormGN24Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN24Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN24Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN24Approval_FormGN24Id] ON [dbo].[FormGN24Approval] 
(
	[FormGN24Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN6')
	BEGIN
		DROP  table  [dbo].[FormGN6]
	END
GO
CREATE TABLE [dbo].[FormGN6](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[JobDescription] [varchar](255) NULL,
	[ReasonForCriticalLift] [varchar](max) NULL,
	[Section1Content] [varchar](max) NULL,
	[Section1PlainTextContent] [nvarchar](max) NULL,
	[Section1NotApplicableToJob] [bit] NOT NULL,
	[Section2Content] [varchar](max) NULL,
	[Section2PlainTextContent] [nvarchar](max) NULL,
	[Section2NotApplicableToJob] [bit] NOT NULL,
	[Section3Content] [varchar](max) NULL,
	[Section3PlainTextContent] [nvarchar](max) NULL,
	[Section3NotApplicableToJob] [bit] NOT NULL,
	[Section4Content] [varchar](max) NULL,
	[Section4PlainTextContent] [nvarchar](max) NULL,
	[Section4NotApplicableToJob] [bit] NOT NULL,
	[Section5Content] [varchar](max) NULL,
	[Section5PlainTextContent] [nvarchar](max) NULL,
	[Section5NotApplicableToJob] [bit] NOT NULL,
	[Section6Content] [varchar](max) NULL,
	[Section6PlainTextContent] [nvarchar](max) NULL,
	[Section6NotApplicableToJob] [bit] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[PreJobMeetingSignatures] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[WorkerResponsiblitiesTemplateId] [bigint] NOT NULL,

 CONSTRAINT [PK_FormGN6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN6_DTO] ON [dbo].[FormGN6] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[CustomField]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomField')
	BEGIN
		DROP  table  [dbo].[CustomField]
	END
GO
CREATE TABLE [dbo].[CustomField](
	[Name] [varchar](40) NOT NULL,
	[TagId] [bigint] NULL,
	[TypeId] [tinyint] NOT NULL,
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[OriginCustomFieldId] [bigint] NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_CustomField] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FunctionalLocation](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Description] [varchar](50) NULL,
	[FullHierarchy] [varchar](90) NOT NULL,
	[OutOfService] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Level] [tinyint] NOT NULL,
	[PlantId] [bigint] NOT NULL,
	[Culture] [varchar](5) NOT NULL,
	[Source] [tinyint] NOT NULL,
 CONSTRAINT [PK_FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] 
(
	[Level] ASC,
	[Deleted] ASC,
	[SiteId] ASC,
	[OutOfService] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] 
(
	[SiteId] ASC,
	[Level] ASC,
	[OutOfService] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] 
(
	[FullHierarchy] ASC,
	[SiteId] ASC,
	[Level] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormGN7Approval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN7Approval')
	BEGIN
		DROP  table  [dbo].[FormGN7Approval]
	END
GO
CREATE TABLE [dbo].[FormGN7Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN7Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN7Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN7Approval_GN7Id] ON [dbo].[FormGN7Approval] 
(
	[FormGN7Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormOP14Approval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOP14Approval')
	BEGIN
		DROP  table  [dbo].[FormOP14Approval]
	END
GO
CREATE TABLE [dbo].[FormOP14Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormOP14Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormOP14Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormOP14_FormId] ON [dbo].[FormOP14Approval] 
(
	[FormOP14Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkAssignment')
	BEGIN
		DROP  table  [dbo].[WorkAssignment]
	END
GO
CREATE TABLE [dbo].[WorkAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](75) NULL,
	[SiteId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[Category] [varchar](75) NULL,
	[UseWorkAssignmentForActionItemHandoverDisplay] [bit] NOT NULL,
	[CopyTargetAlertResponseToLog] [bit] NOT NULL,
	[AutoInsertLogTemplateId] [bigint] NULL,
 CONSTRAINT [PK_WorkAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkAssignment_Including] ON [dbo].[WorkAssignment] 
(
	[Id] ASC
)
INCLUDE ( [Name]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO







/****** Object:  Table [dbo].[WorkPermitMontreal]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontreal')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontreal]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontreal](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[TemplateId] [int] NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NULL,
	[Description] [varchar](400) NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[SourceId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[PermitRequestId] [bigint] NULL,
	[RequestedByGroupId] [bigint] NULL,
	[IssuedDateTime] [datetime] NULL,
 CONSTRAINT [PK_WorkPermitMontreal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitMontreal_DTO] ON [dbo].[WorkPermitMontreal] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverEmailConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverEmailConfiguration')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverEmailConfiguration]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverEmailConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ShiftId] [bigint] NOT NULL,
	[EmailAddresses] [varchar](max) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[ScheduleId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverEmailConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[TagGroupAssociation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TagGroupAssociation')
	BEGIN
		DROP  table  [dbo].[TagGroupAssociation]
	END
GO
CREATE TABLE [dbo].[TagGroupAssociation](
	[TagGroupId] [bigint] NOT NULL,
	[TagId] [bigint] NOT NULL,
 CONSTRAINT [UQ_TagGroupAssociation_TagGroup_Tag] PRIMARY KEY CLUSTERED 
(
	[TagGroupId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO







/****** Object:  Table [dbo].[PermitRequestMontrealPermitAttributeAssociation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestMontrealPermitAttributeAssociation')
	BEGIN
		DROP  table  [dbo].[PermitRequestMontrealPermitAttributeAssociation]
	END
GO
CREATE TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation](
	[PermitRequestId] [bigint] NOT NULL,
	[PermitAttributeId] [bigint] NOT NULL,
 CONSTRAINT [PK_PermitRequestMontrealPermitAttributeAssociation] PRIMARY KEY CLUSTERED 
(
	[PermitRequestId] ASC,
	[PermitAttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[Property]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Property')
	BEGIN
		DROP  table  [dbo].[Property]
	END
GO
CREATE TABLE [dbo].[Property](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EventId] [bigint] NOT NULL,
	[PropertyKey] [varchar](100) NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[TextValue] [varchar](max) NULL,
	[DateTimeValue] [datetime] NULL,
	[NumberValue] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Property_EventId] ON [dbo].[Property] 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[SapAutoImportConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SapAutoImportConfiguration')
	BEGIN
		DROP  table  [dbo].[SapAutoImportConfiguration]
	END
GO
CREATE TABLE [dbo].[SapAutoImportConfiguration](
	[SiteId] [bigint] NOT NULL,
	[ScheduleId] [bigint] NULL,
 CONSTRAINT [PK_SapAutoImportConfiguration] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[RolePermission]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RolePermission')
	BEGIN
		DROP  table  [dbo].[RolePermission]
	END
GO
CREATE TABLE [dbo].[RolePermission](
	[RoleId] [bigint] NOT NULL,
	[RoleElementId] [bigint] NOT NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[RoleElementId] ASC,
	[CreatedByRoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[RoleElementTemplate]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RoleElementTemplate')
	BEGIN
		DROP  table  [dbo].[RoleElementTemplate]
	END
GO
CREATE TABLE [dbo].[RoleElementTemplate](
	[RoleElementId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_RoleElementTemplate] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[RoleElementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[RoleDisplayConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RoleDisplayConfiguration')
	BEGIN
		DROP  table  [dbo].[RoleDisplayConfiguration]
	END
GO
CREATE TABLE [dbo].[RoleDisplayConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[SectionId] [int] NOT NULL,
	[PrimaryDefaultPageId] [int] NOT NULL,
	[SecondaryDefaultPageId] [int] NULL,
 CONSTRAINT [PK_RoleDisplayConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_RoleDisplayConfiguration] UNIQUE NONCLUSTERED 
(
	[RoleId] ASC,
	[SectionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverAnswerHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverAnswerHistory')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverAnswerHistory]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverAnswerHistory](
	[ShiftHandoverQuestionnaireHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[Answer] [bit] NOT NULL,
	[Comments] [varchar](1024) NOT NULL,
	[ShiftHandoverQuestionId] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_ShiftHandoverAnswerHistory_Id] ON [dbo].[ShiftHandoverAnswerHistory] 
(
	[ShiftHandoverQuestionnaireHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealUserReadDocumentLinkAssociation')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation](
	[UserId] [bigint] NOT NULL,
	[WorkPermitMontrealId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealUserReadDocumentLinkAssociation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[WorkPermitMontrealId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkPermitMontrealRequestDetails]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealRequestDetails')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealRequestDetails]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealRequestDetails](
	[Id] [bigint] NOT NULL,
	[RequestedDateTime] [datetime] NULL,
	[RequestedByUserId] [bigint] NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
 CONSTRAINT [PK_WorkPermitMontrealRequestDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[WorkPermitMontrealPermitAttributeAssociation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealPermitAttributeAssociation')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealPermitAttributeAssociation]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation](
	[WorkPermitMontrealId] [bigint] NOT NULL,
	[PermitAttributeId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealPermitAttribAssoc] PRIMARY KEY CLUSTERED 
(
	[WorkPermitMontrealId] ASC,
	[PermitAttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkPermitMontrealFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealFunctionalLocation](
	[WorkPermitMontrealId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[WorkPermitMontrealId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_WorkPermitMontrealFunctionalLocation_Floc] ON [dbo].[WorkPermitMontrealFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[WorkPermitMontrealId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO







/****** Object:  Table [dbo].[WorkPermitMontrealDetails]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitMontrealDetails')
	BEGIN
		DROP  table  [dbo].[WorkPermitMontrealDetails]
	END
GO
CREATE TABLE [dbo].[WorkPermitMontrealDetails](
	[Id] [bigint] NOT NULL,
	[H2S] [bit] NOT NULL,
	[Hydrocarbure] [bit] NOT NULL,
	[Ammoniaque] [bit] NOT NULL,
	[Corrosif] [bit] NOT NULL,
	[CorrosifValue] [varchar](100) NULL,
	[Aromatique] [bit] NOT NULL,
	[AromatiqueValue] [varchar](100) NULL,
	[AutresSubstances] [bit] NOT NULL,
	[AutresSubstancesValue] [varchar](100) NULL,
	[ObtureOuDeBranche] [bit] NOT NULL,
	[DepressuriseEtVidange] [bit] NOT NULL,
	[EnPresenceDeGazInerte] [bit] NOT NULL,
	[PurgeALaVapeur] [bit] NOT NULL,
	[RinceALEau] [bit] NOT NULL,
	[Excavation] [bit] NOT NULL,
	[DessinsRequis] [bit] NOT NULL,
	[DessinsRequisValue] [varchar](100) NULL,
	[CablesChauffantsMisHorsTension] [bit] NOT NULL,
	[PompeOuVerinPneumatique] [bit] NOT NULL,
	[ChaineEtCadenasseOuScelle] [bit] NOT NULL,
	[InterrupteursElectriquesVerrouilles] [bit] NOT NULL,
	[PurgeParUnGazInerte] [bit] NOT NULL,
	[OutilsElectriquesOuABatteries] [bit] NOT NULL,
	[BoiteEnergieZero] [bit] NOT NULL,
	[BoiteEnergieZeroValue] [varchar](100) NULL,
	[OutilsPneumatiques] [bit] NOT NULL,
	[MoteurACombustionInterne] [bit] NOT NULL,
	[TravauxSuperposes] [bit] NOT NULL,
	[FormulaireDespaceClosAffiche] [bit] NOT NULL,
	[FormulaireDespaceClosAfficheValue] [varchar](100) NULL,
	[ExisteIlUneAnalyseDeTache] [bit] NOT NULL,
	[PossibiliteDeSulfureDeFer] [bit] NOT NULL,
	[AereVentile] [bit] NOT NULL,
	[SoudureALelectricite] [bit] NOT NULL,
	[BrulageAAcetylene] [bit] NOT NULL,
	[Nacelle] [bit] NOT NULL,
	[AutreConditions] [bit] NOT NULL,
	[AutreConditionsValue] [varchar](100) NULL,
	[LunettesMonocoques] [bit] NOT NULL,
	[HarnaisDeSecurite] [bit] NOT NULL,
	[EcranFacial] [bit] NOT NULL,
	[ProtectionAuditive] [bit] NOT NULL,
	[Trepied] [bit] NOT NULL,
	[DispositifAntiChute] [bit] NOT NULL,
	[ProtectionRespiratoire] [bit] NOT NULL,
	[ProtectionRespiratoireValue] [varchar](100) NULL,
	[Habits] [bit] NOT NULL,
	[HabitsValue] [varchar](100) NULL,
	[AutreProtection] [bit] NOT NULL,
	[AutreProtectionValue] [varchar](100) NULL,
	[Extincteur] [bit] NOT NULL,
	[BouchesDegoutProtegees] [bit] NOT NULL,
	[CouvertureAntiEtincelles] [bit] NOT NULL,
	[SurveillantPourEtincelles] [bit] NOT NULL,
	[PareEtincelles] [bit] NOT NULL,
	[MiseAlaTerrePresDuLieuDeTravail] [bit] NOT NULL,
	[BoyauAVapeur] [bit] NOT NULL,
	[AutresEquipementDincendie] [bit] NOT NULL,
	[AutresEquipementDincendieValue] [varchar](100) NULL,
	[Ventulateur] [bit] NOT NULL,
	[Barrieres] [bit] NOT NULL,
	[Surveillant] [bit] NOT NULL,
	[SurveillantValue] [varchar](100) NULL,
	[RadioEmetteur] [bit] NOT NULL,
	[PerimetreDeSecurite] [bit] NOT NULL,
	[DetectionContinueDesGaz] [bit] NOT NULL,
	[DetectionContinueDesGazValue] [varchar](100) NULL,
	[KlaxonSonore] [bit] NOT NULL,
	[Localiser] [bit] NOT NULL,
	[Amiante] [bit] NOT NULL,
	[AutreEquipementsSecurite] [bit] NOT NULL,
	[AutreEquipementsSecuriteValue] [varchar](100) NULL,
	[InstructionsSpeciales] [varchar](500) NULL,
	[SignatureOperateurSurLeTerrain] [bit] NOT NULL,
	[DetectionDesGazs] [bit] NOT NULL,
	[SignatureContremaitre] [bit] NOT NULL,
	[SignatureAutorise] [bit] NOT NULL,
	[NettoyageTransfertHorsSite] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitMontrealDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[SAPNotification]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SAPNotification')
	BEGIN
		DROP  table  [dbo].[SAPNotification]
	END
GO
CREATE TABLE [dbo].[SAPNotification](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Comments] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[NotificationType] [char](2) NOT NULL,
	[NotificationNumber] [char](12) NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[ShortText] [varchar](40) NULL,
	[LongText] [varchar](max) NULL,
	[IncidentID] [varchar](20) NULL,
	[Processed] [bit] NOT NULL,
 CONSTRAINT [PK_SAPNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY],
 CONSTRAINT [UQ_SAPNotification_Number] UNIQUE NONCLUSTERED 
(
	[NotificationNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_SAPNOTIFICATION] ON [dbo].[SAPNotification] 
(
	[FunctionalLocationId] ASC,
	[CreationDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[RestrictionLocationWorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionLocationWorkAssignment')
	BEGIN
		DROP  table  [dbo].[RestrictionLocationWorkAssignment]
	END
GO
CREATE TABLE [dbo].[RestrictionLocationWorkAssignment](
	[RestrictionLocationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_RestrictionLocationWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[RestrictionLocationId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[RestrictionLocationItem]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionLocationItem')
	BEGIN
		DROP  table  [dbo].[RestrictionLocationItem]
	END
GO
CREATE TABLE [dbo].[RestrictionLocationItem](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FunctionalLocationId] [bigint] NULL,
	[ParentItemId] [bigint] NULL,
	[RestrictionLocationId] [bigint] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_RestrictionLocationItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_RestrictionLocationItem_RestrictionLocation] ON [dbo].[RestrictionLocationItem] 
(
	[RestrictionLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[PriorityPageSectionConfigurationWorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PriorityPageSectionConfigurationWorkAssignment')
	BEGIN
		DROP  table  [dbo].[PriorityPageSectionConfigurationWorkAssignment]
	END
GO
CREATE TABLE [dbo].[PriorityPageSectionConfigurationWorkAssignment](
	[PriorityPageSectionConfigurationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[RestrictionDefinition]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionDefinition')
	BEGIN
		DROP  table  [dbo].[RestrictionDefinition]
	END
GO
CREATE TABLE [dbo].[RestrictionDefinition](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[MeasurementTagID] [bigint] NOT NULL,
	[ProductionTargetValue] [int] NULL,
	[ProductionTargetTagID] [bigint] NULL,
	[RestrictionDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastInvokedDateTime] [datetime] NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IsOnlyVisibleOnReports] [bit] NOT NULL,
 CONSTRAINT [PK_RestrictionDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[PermitRequestLubes]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestLubes')
	BEGIN
		DROP  table  [dbo].[PermitRequestLubes]
	END
GO
CREATE TABLE [dbo].[PermitRequestLubes](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Description] [varchar](max) NULL,
	[SapDescription] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[DataSourceId] [int] NOT NULL,
	[CompletionStatusId] [int] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Trade] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[RequestedByGroupId] [bigint] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](50) NULL,
	[RescuePlan] [bit] NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](50) NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[HighEnergy] [tinyint] NOT NULL,
	[CriticalLift] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[EnergyControlPlan] [tinyint] NOT NULL,
	[EquivalencyProc] [tinyint] NOT NULL,
	[TestPneumatic] [tinyint] NOT NULL,
	[LiveFlareWork] [tinyint] NOT NULL,
	[EntryAndControlPlan] [tinyint] NOT NULL,
	[HazardHydrocarbonGas] [bit] NOT NULL,
	[HazardHydrocarbonLiquid] [bit] NOT NULL,
	[HazardHydrogenSulphide] [bit] NOT NULL,
	[HazardInertGasAtmosphere] [bit] NOT NULL,
	[HazardOxygenDeficiency] [bit] NOT NULL,
	[HazardRadioactiveSources] [bit] NOT NULL,
	[HazardUndergroundOverheadHazards] [bit] NOT NULL,
	[HazardDesignatedSubstance] [bit] NOT NULL,
	[OtherHazardsAndOrRequirements] [varchar](max) NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[SpecificRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[AttendedAtAllTimes] [bit] NOT NULL,
	[EyeProtection] [bit] NOT NULL,
	[FallProtectionEquipment] [bit] NOT NULL,
	[FullBodyHarnessRetrieval] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[ProtectiveClothing] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other1Value] [varchar](15) NULL,
	[EquipmentBondedGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireFightingEquipment] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[HydrantPermit] [bit] NOT NULL,
	[WaterHose] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other2Value] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[DrowningProtection] [bit] NOT NULL,
	[RespiratoryProtection] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other3Value] [varchar](15) NULL,
	[AdditionalLighting] [bit] NOT NULL,
	[DesignateHotOrColdCutChecked] [bit] NOT NULL,
	[DesignateHotOrColdCutValue] [varchar](6) NULL,
	[HoistingEquipment] [bit] NOT NULL,
	[Ladder] [bit] NOT NULL,
	[MotorizedEquipment] [bit] NOT NULL,
	[Scaffold] [bit] NOT NULL,
	[ReferToTipsProcedure] [bit] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedByRoleId] [bigint] NULL,
	[IsModified] [bit] NOT NULL,
	[GasDetectorBumpTested] [bit] NOT NULL,
	[IsVehicleEntry] [bit] NOT NULL,
	[EnergizedElectrical] [tinyint] NOT NULL,
	[SAPWorkCentre] [varchar](40) NULL,
 CONSTRAINT [PK_PermitRequestLubes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_PermitRequestLubes_DTO] ON [dbo].[PermitRequestLubes] 
(
	[RequestedStartDate] ASC,
	[EndDate] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[PermitRequestMontrealFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestMontrealFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[PermitRequestMontrealFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[PermitRequestMontrealFunctionalLocation](
	[PermitRequestMontrealId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_PermitRequestMontrealFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[PermitRequestMontrealId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_PermitRequestMontrealFunctionalLocation_Floc] ON [dbo].[PermitRequestMontrealFunctionalLocation] 
(
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[PermitRequestEdmontonSAPImportData]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestEdmontonSAPImportData')
	BEGIN
		DROP  table  [dbo].[PermitRequestEdmontonSAPImportData]
	END
GO
CREATE TABLE [dbo].[PermitRequestEdmontonSAPImportData](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[WorkOrderNumber] [varchar](25) NOT NULL,
	[OperationNumber] [varchar](4) NOT NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[EndDate] [datetime] NOT NULL,
	[TaskDescription] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[SpecialWorkType] [int] NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[GN11] [int] NOT NULL,
	[GN27] [int] NOT NULL,
	[WorkersMonitorNumber] [varchar](10) NULL,
	[RadioChannelNumber] [varchar](10) NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
	[SAPWorkCentre] [varchar](40) NOT NULL,
	[BatchId] [bigint] NOT NULL,
	[BatchItemCreatedAt] [datetime] NOT NULL,
	[DoNotMerge] [bit] NOT NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[AreaLabelId] [bigint] NULL,
	[GN24] [bit] NOT NULL,
	[GN6] [bit] NOT NULL,
	[GN75A] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
 CONSTRAINT [PK_PermitRequestEdmontonRawImportData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLog')
	BEGIN
		DROP  table  [dbo].[SummaryLog]
	END
GO
CREATE TABLE [dbo].[SummaryLog](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreationUserShiftPatternId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
	[RtfComments] [varchar](max) NULL,
	[PlainTextComments] [varchar](max) NOT NULL,
	[DorComments] [varchar](max) NULL,
	[RootLogId] [bigint] SPARSE  NULL,
	[ReplyToLogId] [bigint] SPARSE  NULL,
	[HasChildren] [bit] NOT NULL,
	[DataSourceId] [int] NOT NULL,
 CONSTRAINT [PK_SummaryLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_SummaryLog_DTO] ON [dbo].[SummaryLog] 
(
	[CreatedDateTime] ASC,
	[Id] ASC,
	[CreationUserShiftPatternId] ASC
)
INCLUDE ( [CreatedByUserId],
[WorkAssignmentId]) 
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_SummaryLog_ReplyToLogId] ON [dbo].[SummaryLog] 
(
	[ReplyToLogId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverEmailConfigurationWorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverEmailConfigurationWorkAssignment')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverEmailConfigurationWorkAssignment]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverEmailConfigurationWorkAssignment](
	[ShiftHandoverEmailConfigurationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverEmailConfigurationWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverEmailConfigurationId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[TargetDefinition]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinition')
	BEGIN
		DROP  table  [dbo].[TargetDefinition]
	END
GO
CREATE TABLE [dbo].[TargetDefinition](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[NeverToExceedMax] [decimal](9, 2) NULL,
	[NeverToExceedMin] [decimal](9, 2) NULL,
	[MaxValue] [decimal](9, 2) NULL,
	[MinValue] [decimal](9, 2) NULL,
	[NeverToExceedMaxFrequency] [int] NULL,
	[NeverToExceedMinFrequency] [int] NULL,
	[MaxValueFrequency] [int] NULL,
	[MinValueFrequency] [int] NULL,
	[TargetDefinitionValue] [decimal](9, 2) NULL,
	[GapUnitValue] [decimal](9, 2) NULL,
	[TargetDefinitionStatusID] [bigint] NOT NULL,
	[TargetCategoryID] [bigint] NOT NULL,
	[TagID] [bigint] NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[GenerateActionItem] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
	[ScheduleId] [bigint] NOT NULL,
	[AlertRequired] [bit] NULL,
	[RequiresApproval] [bit] NOT NULL,
	[RequiresResponseWhenAlerted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[OperationalModeId] [int] NOT NULL,
	[TargetValueTypeId] [bigint] NOT NULL,
	[PriorityId] [bigint] NOT NULL,
	[PreApprovedNeverToExceedMax] [decimal](9, 2) NULL,
	[PreApprovedNeverToExceedMin] [decimal](9, 2) NULL,
	[PreApprovedMax] [decimal](9, 2) NULL,
	[PreApprovedMin] [decimal](9, 2) NULL,
 CONSTRAINT [PK_TargetDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_TargetDefinition_FLOC] ON [dbo].[TargetDefinition] 
(
	[FunctionalLocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetDefinition_LastModifiedUserId] ON [dbo].[TargetDefinition] 
(
	[LastModifiedUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetDefinition_Name] ON [dbo].[TargetDefinition] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_TargetDefinition_ScheduleId] ON [dbo].[TargetDefinition] 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[LogTemplateWorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogTemplateWorkAssignment')
	BEGIN
		DROP  table  [dbo].[LogTemplateWorkAssignment]
	END
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogTemplateWorkAssignment')
	BEGIN
		DROP  table  [dbo].[LogTemplateWorkAssignment]
	END
GO
CREATE TABLE [dbo].[LogTemplateWorkAssignment](
	[LogTemplateId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogTemplateWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[LogTemplateId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverConfigurationWorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverConfigurationWorkAssignment')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverConfigurationWorkAssignment]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment](
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverConfigurationWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverConfigurationId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO







/****** Object:  Table [dbo].[TrainingBlockFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TrainingBlockFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[TrainingBlockFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[TrainingBlockFunctionalLocation](
	[TrainingBlockId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_TrainingBlockFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[TrainingBlockId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TrainingBlockFunctionalLocation_Floc_TrainingBlockId] ON [dbo].[TrainingBlockFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[TrainingBlockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitAutoAssignmentConfigurationFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation](
	[WorkAssignmentId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitAutoAssignmentConfigurationFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[WorkAssignmentId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO







/****** Object:  Table [dbo].[WorkPermit]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermit')
	BEGIN
		DROP  table  [dbo].[WorkPermit]
	END
GO
CREATE TABLE [dbo].[WorkPermit](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitStatusId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[SapOperationId] [bigint] NULL,
	[PermitNumber] [varchar](50) NULL,
	[WorkOrderNumber] [varchar](50) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[PermitValidDateTime] [datetime] NULL,
	[WorkPermitTypeId] [bigint] NOT NULL,
	[WorkPermitTypeClassificationId] [bigint] NULL,
	[WorkOrderDescription] [varchar](max) NULL,
	[SpecialPrecautionsOrConsiderationsDescription] [varchar](max) NULL,
	[PermitConfinedSpaceEntry] [bit] NOT NULL,
	[PermitBreathingAirOrSCBA] [bit] NOT NULL,
	[PermitElectricalSwitching] [bit] NOT NULL,
	[PermitVehicleEntry] [bit] NOT NULL,
	[PermitHotTap] [bit] NOT NULL,
	[PermitBurnOrOpenFlame] [bit] NOT NULL,
	[PermitSystemEntry] [bit] NOT NULL,
	[PermitCriticalLift] [bit] NOT NULL,
	[PermitEnergizedElectrical] [bit] NOT NULL,
	[PermitExcavation] [bit] NOT NULL,
	[PermitAsbestos] [bit] NOT NULL,
	[PermitRadiationRadiography] [bit] NOT NULL,
	[PermitRadiationSealed] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorization] [bit] NOT NULL,
	[AdditionalFlareEntry] [bit] NOT NULL,
	[AdditionalCriticalLift] [bit] NOT NULL,
	[AdditionalExcavation] [bit] NOT NULL,
	[AdditionalHotTap] [bit] NOT NULL,
	[AdditionalSpecialWasteDisposal] [bit] NOT NULL,
	[AdditionalBlankOrBlindLists] [bit] NOT NULL,
	[AdditionalPJSROrSafetyPause] [bit] NOT NULL,
	[AdditionalAsbestosHandling] [bit] NOT NULL,
	[AdditionalRoadClosure] [bit] NOT NULL,
	[AdditionalElectrical] [bit] NOT NULL,
	[AdditionalBurnOrOpenFlameAssessment] [bit] NOT NULL,
	[AdditionalWaiverOrDeviation] [bit] NOT NULL,
	[AdditionalMSDS] [bit] NOT NULL,
	[AdditionalOtherFormsOrAssessmentsOrAuthorizations] [varchar](50) NULL,
	[ContactPersonnel] [varchar](50) NULL,
	[ContractorCompanyName] [varchar](50) NULL,
	[CraftOrTradeID] [bigint] NULL,
	[CraftOrTradeOther] [varchar](50) NULL,
	[JobStepDescription] [varchar](max) NULL,
	[CommunicationByRadio] [bit] NULL,
	[CommunicationRadioChannelOrBand] [varchar](20) NULL,
	[IsWorkPermitCommunicationNotApplicable] [bit] NOT NULL,
	[CommunicationRadioColor] [varchar](20) NULL,
	[CommunicationByOtherDescription] [varchar](50) NULL,
	[CoAuthorizationRequired] [bit] NULL,
	[CoAuthorizationDescription] [varchar](50) NULL,
	[ToolsAirTools] [bit] NOT NULL,
	[ToolsCraneOrCarrydeck] [bit] NOT NULL,
	[ToolsHandTools] [bit] NOT NULL,
	[ToolsJackhammer] [bit] NOT NULL,
	[ToolsVacuumTruck] [bit] NOT NULL,
	[ToolsCementSaw] [bit] NOT NULL,
	[ToolsElectricTools] [bit] NOT NULL,
	[ToolsHeavyEquipment] [bit] NOT NULL,
	[ToolsLanda] [bit] NOT NULL,
	[ToolsScaffolding] [bit] NOT NULL,
	[ToolsVehicle] [bit] NOT NULL,
	[ToolsCompressor] [bit] NOT NULL,
	[ToolsForklift] [bit] NOT NULL,
	[ToolsHEPAVacuum] [bit] NOT NULL,
	[ToolsManlift] [bit] NOT NULL,
	[ToolsTamper] [bit] NOT NULL,
	[ToolsHotTapMachine] [bit] NOT NULL,
	[ToolsPortLighting] [bit] NOT NULL,
	[ToolsTorch] [bit] NOT NULL,
	[ToolsWelder] [bit] NOT NULL,
	[ToolsOtherToolsDescription] [varchar](50) NULL,
	[ElectricIsolationMethodNotApplicable] [bit] NOT NULL,
	[ElectricIsolationMethodLOTO] [bit] NOT NULL,
	[ElectricIsolationMethodWiring] [bit] NOT NULL,
	[ElectricTestBumpNotApplicable] [bit] NOT NULL,
	[ElectricTestBump] [bit] NULL,
	[EquipmentNoElectricalTestBumpComments] [varchar](400) NULL,
	[EquipmentStillContainsResidualNotApplicable] [bit] NOT NULL,
	[EquipmentStillContainsResidual] [bit] NULL,
	[EquipmentStillContainsResidualComments] [varchar](400) NULL,
	[EquipmentLeakingValvesNotApplicable] [bit] NOT NULL,
	[EquipmentLeakingValves] [bit] NULL,
	[EquipmentLeakingValvesComments] [varchar](400) NULL,
	[EquipmentIsOutOfService] [bit] NULL,
	[EquipmentInServiceComments] [varchar](400) NULL,
	[EquipmentConditionNotApplicable] [bit] NOT NULL,
	[EquipmentConditionDepressured] [bit] NOT NULL,
	[EquipmentConditionDrained] [bit] NOT NULL,
	[EquipmentConditionCleaned] [bit] NOT NULL,
	[EquipmentConditionVentilated] [bit] NOT NULL,
	[EquipmentConditionH20Washed] [bit] NOT NULL,
	[EquipmentConditionNeutralized] [bit] NOT NULL,
	[EquipmentConditionPurged] [bit] NOT NULL,
	[EquipmentConditionPurgedDescription] [varchar](50) NULL,
	[EquipmentPreviousContentsNotApplicable] [bit] NOT NULL,
	[EquipmentPreviousContentsHydrocarbon] [bit] NOT NULL,
	[EquipmentPreviousContentsAcid] [bit] NOT NULL,
	[EquipmentPreviousContentsCaustic] [bit] NOT NULL,
	[EquipmentPreviousContentsH2S] [bit] NOT NULL,
	[EquipmentPreviousContentsOtherDescription] [varchar](50) NULL,
	[EquipmentIsolationMethodNotApplicable] [bit] NOT NULL,
	[EquipmentIsolationMethodBlindedorBlanked] [bit] NOT NULL,
	[EquipmentIsolationMethodBlockedIn] [bit] NOT NULL,
	[EquipmentIsolationMethodSeparation] [bit] NOT NULL,
	[EquipmentIsolationMethodMudderPlugs] [bit] NOT NULL,
	[EquipmentIsolationMethodLOTO] [bit] NOT NULL,
	[EquipmentIsolationMethodOtherDescription] [varchar](50) NULL,
	[JobSitePreparationFlowRequiredForJob] [bit] NULL,
	[JobSitePreparationFlowRequiredForJobNotApplicable] [bit] NOT NULL,
	[JobSitePreparationFlowRequiredComments] [varchar](400) NULL,
	[JobSitePreparationBondingOrGroundingRequiredNotApplicable] [bit] NOT NULL,
	[JobSitePreparationBondingOrGroundingRequired] [bit] NULL,
	[JobSitePreparationBondingGroundingNotRequiredComments] [varchar](400) NULL,
	[JobSitePreparationWeldingGroundWireInTestAreaNotApplicable] [bit] NOT NULL,
	[JobSitePreparationWeldingGroundWireInTestArea] [bit] NULL,
	[JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments] [varchar](400) NULL,
	[JobSitePreparationCriticalConditionRemainJobSiteNotApplicable] [bit] NOT NULL,
	[JobSitePreparationCriticalConditionRemainJobSite] [bit] NULL,
	[JobSitePreparationCriticalConditionsComments] [varchar](400) NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminated] [bit] NULL,
	[JobSitePreparationSurroundingConditionsAffectAreaComments] [varchar](400) NULL,
	[JobSitePreparationVestedBuddySystemInEffectNotApplicable] [bit] NOT NULL,
	[JobSitePreparationVestedBuddySystemInEffect] [bit] NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientation] [bit] NULL,
	[JobSitePreparationPermitReceiverRequiresOrientationComments] [varchar](400) NULL,
	[JobSitePreparationSewerIsolationMethodNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodSealedOrCovered] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodPlugged] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodBlindedOrBlanked] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodOtherDescription] [varchar](50) NULL,
	[EquipmentVentilationMethodNotApplicable] [bit] NOT NULL,
	[EquipmentVentilationMethodNaturalDraft] [bit] NOT NULL,
	[EquipmentVentilationMethodLocalExhaust] [bit] NOT NULL,
	[EquipmentVentilationMethodForced] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationBarricade] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNonEssentialEvac] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationPreopBoundaryRopeTape] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationOtherDescription] [varchar](50) NULL,
	[JobSitePreparationLightingElectricalRequirementNotApplicable] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementLowVoltage12V] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirement110VWithGFCI] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementGeneratorLights] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementOtherDescription] [varchar](50) NULL,
	[RadiationSealedSourceIsolationNotApplicable] [bit] NOT NULL,
	[RadiationSealedSourceIsolationLOTO] [bit] NOT NULL,
	[RadiationSealedSourceIsolationOpen] [bit] NOT NULL,
	[RadiationSealedSourceIsolationNumberOfSources] [int] NULL,
	[GasTestFrequencyOrDuration] [varchar](50) NULL,
	[GasTestConstantMonitoringRequired] [bit] NOT NULL,
	[FireConfinedSpace20ABCorDryChemicalExtinguisher] [bit] NOT NULL,
	[FireConfinedSpaceC02Extinguisher] [bit] NOT NULL,
	[FireConfinedSpaceFireResistantTarp] [bit] NOT NULL,
	[FireConfinedSpaceSparkContainment] [bit] NOT NULL,
	[FireConfinedSpaceWaterHose] [bit] NOT NULL,
	[FireConfinedSpaceSteamHose] [bit] NOT NULL,
	[FireConfinedSpaceWatchmen] [bit] NOT NULL,
	[FireConfinedSpaceOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsAirCartOrAirLine] [bit] NOT NULL,
	[RespitoryProtectionRequirementsSCBA] [bit] NOT NULL,
	[RespitoryProtectionRequirementsHalfFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsFullFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsDustMask] [bit] NOT NULL,
	[RespitoryProtectionRequirementsAirHood] [bit] NOT NULL,
	[RespitoryProtectionRequirementsOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription] [varchar](50) NULL,
	[SpecialEyeOrFaceProtectionGoggles] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionFaceshield] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionOtherDescription] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeRainCoat] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeRainPants] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothing] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothingTypeID] [int] NULL,
	[SpecialProtectiveClothingTypeCausticWear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeOtherDescripton] [varchar](50) NULL,
	[SpecialProtectiveFootwearChemicalImperviousBoots] [bit] NOT NULL,
	[SpecialProtectiveFootwearToeGuard] [bit] NOT NULL,
	[SpecialProtectiveFootwearOtherDescription] [varchar](50) NULL,
	[SpecialHandProtectionChemicalNeprene] [bit] NOT NULL,
	[SpecialHandProtectionNaturalRubber] [bit] NOT NULL,
	[SpecialHandProtectionNitrile] [bit] NOT NULL,
	[SpecialHandProtectionPVC] [bit] NOT NULL,
	[SpecialHandProtectionHighVoltage] [bit] NOT NULL,
	[SpecialHandProtectionWelding] [bit] NOT NULL,
	[SpecialHandProtectionLeather] [bit] NOT NULL,
	[SpecialHandProtectionOtherDescription] [varchar](50) NULL,
	[SpecialRescueOrFallBodyHarness] [bit] NOT NULL,
	[SpecialRescueOrFallLifeline] [bit] NOT NULL,
	[SpecialRescueOrFallYoYo] [bit] NOT NULL,
	[SpecialRescueOrFallRescueDevice] [bit] NOT NULL,
	[SpecialRescueOrFallOtherDescription] [varchar](50) NULL,
	[SourceId] [int] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[Deleted] [bit] NOT NULL,
	[PermitInertConfinedSpaceEntry] [bit] NOT NULL,
	[PermitLeadAbatement] [bit] NOT NULL,
	[RespitoryProtectionRequirementsNotApplicable] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveFootwearNotApplicable] [bit] NOT NULL,
	[SpecialHandProtectionNotApplicable] [bit] NOT NULL,
	[SpecialRescueOrFallNotApplicable] [bit] NOT NULL,
	[FireConfinedSpaceNotApplicable] [bit] NOT NULL,
	[StartAndOrEndTimesFinalized] [bit] NOT NULL,
	[PermitElectricalWork] [bit] NOT NULL,
	[SpecialProtectiveFootwearMetatarsalGuard] [bit] NOT NULL,
	[SpecialProtectiveClothingTypePaperCoveralls] [bit] NOT NULL,
	[EquipmentConditionOtherDescription] [varchar](50) NULL,
	[EquipmentConditionPurgedN2] [bit] NOT NULL,
	[EquipmentConditionPurgedSteamed] [bit] NOT NULL,
	[EquipmentConditionPurgedAir] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorizationDescription] [varchar](50) NULL,
	[AdditionalBurnOrOpenFlameAssessmentDescription] [varchar](50) NULL,
	[AdditionalElectricalDescription] [varchar](50) NULL,
	[AdditionalAsbestosHandlingDescription] [varchar](50) NULL,
	[AdditionalCriticalLiftDescription] [varchar](50) NULL,
	[AdditionalWaiverOrDeviationDescription] [varchar](50) NULL,
	[AdditionalExcavationDescription] [varchar](50) NULL,
	[EquipmentAsbestosGasketsNotApplicable] [bit] NOT NULL,
	[EquipmentAsbestosGaskets] [bit] NULL,
	[EquipmentIsolationMethodCarBer] [bit] NOT NULL,
	[AdditionalRadiationApproval] [bit] NOT NULL,
	[AdditionalOnlineLeakRepairForm] [bit] NOT NULL,
	[FireConfinedSpaceHoleWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceFireWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceSpotterNumber] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeTyvekSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeKapplerSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeElectricalFlashGear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeCorrosiveClothing] [bit] NOT NULL,
	[SpecialHandProtectionChemicalGloves] [bit] NOT NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeId] [bigint] NULL,
	[ToolsChemicals] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationRadiationRope] [bit] NOT NULL,
	[Version] [varchar](10) NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[EquipmentIsHazardousEnergyIsolationRequiredNotApplicable] [bit] NOT NULL,
	[EquipmentIsHazardousEnergyIsolationRequired] [bit] NULL,
	[EquipmentLockOutMethodId] [bigint] NULL,
	[EquipmentLockOutMethodComments] [varchar](600) NULL,
	[EquipmentEnergyIsolationPlanNumber] [varchar](100) NULL,
	[EquipmentConditionsOfEIPSatisfied] [bit] NULL,
	[EquipmentConditionsOfEIPNotSatisfiedComments] [varchar](400) NULL,
	[AsbestosHazardsConsideredNotApplicable] [bit] NOT NULL,
	[AsbestosHazardsConsidered] [bit] NULL,
	[GasTestTestTime] [datetime] NULL,
	[GasTestSystemEntryTestTime] [datetime] NULL,
	[GasTestConfinedSpaceTestTime] [datetime] NULL,
	[IsOperations] [bit] NOT NULL,
	[SpecialFallOtherDescription] [varchar](50) NULL,
	[SpecialFallRestraint] [bit] NOT NULL,
	[SpecialFallSelfRetractingDevice] [bit] NOT NULL,
	[SpecialFallTieoffRequired] [bit] NULL,
	[GasTestForkliftNotUsed] [bit] NOT NULL,
	[AdditionalIsEnergizedElectricalForm] [bit] NOT NULL,
	[AdditionalIsNotApplicable] [bit] NOT NULL,
	[StartTimeNotApplicable] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermit_SAPOperId] ON [dbo].[WorkPermit] 
(
	[SapOperationId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermit_WorkPermitPage] ON [dbo].[WorkPermit] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[WorkPermitStatusId] ASC,
	[WorkAssignmentId] ASC
)
INCLUDE ( [CraftOrTradeID],
[FunctionalLocationId],
[WorkPermitTypeId],
[CreatedByUserId],
[ApprovedByUserId],
[LastModifiedUserId]) 
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[UserLoginHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserLoginHistory')
	BEGIN
		DROP  table  [dbo].[UserLoginHistory]
	END
GO
CREATE TABLE [dbo].[UserLoginHistory](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[LoginDateTime] [datetime] NOT NULL,
	[ShiftId] [bigint] NOT NULL,
	[ShiftStartDateTime] [datetime] NOT NULL,
	[ShiftEndDateTime] [datetime] NOT NULL,
	[AssignmentId] [bigint] NULL,
	[ClientUri] [varchar](500) NOT NULL,
	[MachineName] [varchar](20) NOT NULL,
	[WindowsVersion] [varchar](100) NULL,
	[DotNetVersion] [varchar](200) NULL,
	[ClientUpdatePath] [varchar](100) NULL,
	[IsClickOnce] [bit] NULL,
 CONSTRAINT [PK_UserLoginHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_UserLoginHistory_UserId_LoginDateTime] ON [dbo].[UserLoginHistory] 
(
	[UserId] ASC,
	[LoginDateTime] ASC
)
INCLUDE ( [Id]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkAssignmentVisibilityGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkAssignmentVisibilityGroup')
	BEGIN
		DROP  table  [dbo].[WorkAssignmentVisibilityGroup]
	END
GO
CREATE TABLE [dbo].[WorkAssignmentVisibilityGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[VisibilityGroupId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
	[VisibilityType] [tinyint] NOT NULL,
 CONSTRAINT [PK_WorkAssignmentGroupVisibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_WorkAssignmentVisibilityGroup_FilteringOtherQueries] ON [dbo].[WorkAssignmentVisibilityGroup] 
(
	[VisibilityGroupId] ASC,
	[VisibilityType] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO








/****** Object:  Table [dbo].[WorkAssignmentFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkAssignmentFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[WorkAssignmentFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[WorkAssignmentFunctionalLocation](
	[WorkAssignmentId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkAssignmentFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[WorkAssignmentId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[WorkPermitFunctionalLocationConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitFunctionalLocationConfiguration')
	BEGIN
		DROP  table  [dbo].[WorkPermitFunctionalLocationConfiguration]
	END
GO
CREATE TABLE [dbo].[WorkPermitFunctionalLocationConfiguration](
	[WorkAssignmentId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitFunctionalLocationConfiguration] PRIMARY KEY CLUSTERED 
(
	[WorkAssignmentId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[OvertimeForm]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'OvertimeForm')
	BEGIN
		DROP  table  [dbo].[OvertimeForm]
	END
GO
CREATE TABLE [dbo].[OvertimeForm](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [tinyint] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[CancelledDateTime] [datetime] NULL,
	[Trade] [varchar](50) NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,

 CONSTRAINT [PK_OvertimeForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_OvertimeForm_DTO] ON [dbo].[OvertimeForm] 
(
	[ValidFromDateTime] ASC,
	[ValidToDateTime] ASC,
	[FormStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[LogGuideline]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogGuideline')
	BEGIN
		DROP  table  [dbo].[LogGuideline]
	END
GO
CREATE TABLE [dbo].[LogGuideline](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Text] [varchar](max) NULL,
 CONSTRAINT [PK_LogGuideline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [LogGuideline_FunctionalLocation_Unique] UNIQUE NONCLUSTERED 
(
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[LabAlertDefinition]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LabAlertDefinition')
	BEGIN
		DROP  table  [dbo].[LabAlertDefinition]
	END
GO
CREATE TABLE [dbo].[LabAlertDefinition](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[TagID] [bigint] NOT NULL,
	[MinimumNumberOfSamples] [int] NOT NULL,
	[LabAlertTagQueryRangeType] [tinyint] NOT NULL,
	[LabAlertTagQueryRangeFromTime] [datetime] NOT NULL,
	[LabAlertTagQueryRangeToTime] [datetime] NOT NULL,
	[LabAlertTagQueryRangeFromDayOfWeek] [int] NULL,
	[LabAlertTagQueryRangeToDayOfWeek] [int] NULL,
	[LabAlertTagQueryRangeFromWeekOfMonth] [int] NULL,
	[LabAlertTagQueryRangeToWeekOfMonth] [int] NULL,
	[LabAlertTagQueryRangeFromDayOfMonth] [int] NULL,
	[LabAlertTagQueryRangeToDayOfMonth] [int] NULL,
	[ScheduleId] [bigint] NOT NULL,
	[LabAlertDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_LabAlertDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[FunctionalLocationOperationalModeHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FunctionalLocationOperationalModeHistory')
	BEGIN
		DROP  table  [dbo].[FunctionalLocationOperationalModeHistory]
	END
GO
CREATE TABLE [dbo].[FunctionalLocationOperationalModeHistory](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UnitId] [bigint] NOT NULL,
	[OperationalModeId] [bigint] NOT NULL,
	[AvailabilityReasonId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_FunctionalLocationOperationalModeHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FunctionalLocationOperationalMode]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FunctionalLocationOperationalMode')
	BEGIN
		DROP  table  [dbo].[FunctionalLocationOperationalMode]
	END
GO
CREATE TABLE [dbo].[FunctionalLocationOperationalMode](
	[UnitId] [bigint] NOT NULL,
	[OperationalModeId] [bigint] NOT NULL,
	[AvailabilityReasonId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_FunctionalLocationOperationalMode] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FunctionalLocationAncestor]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FunctionalLocationAncestor')
	BEGIN
		DROP  table  [dbo].[FunctionalLocationAncestor]
	END
GO
CREATE TABLE [dbo].[FunctionalLocationAncestor](
	[Id] [bigint] NOT NULL,
	[AncestorId] [bigint] NOT NULL,
	[AncestorLevel] [tinyint] NOT NULL,
 CONSTRAINT [PK_FunctionalLocationAncestor] PRIMARY KEY CLUSTERED 
(
	[AncestorId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_FunctionalLocationAncestorId] ON [dbo].[FunctionalLocationAncestor] 
(
	[Id] ASC,
	[AncestorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinition')
	BEGIN
		DROP  table  [dbo].[LogDefinition]
	END
GO
CREATE TABLE [dbo].[LogDefinition](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ScheduleId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[PlainTextComments] [varchar](max) NOT NULL,
	[LogType] [tinyint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[CreateALogForEachFunctionalLocation] [bit] NOT NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
	[IsOperatingEngineerLog] [bit] NOT NULL,
	[RtfComments] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_LogDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_LogDefinition_Id_And_Schedule] ON [dbo].[LogDefinition] 
(
	[Id] ASC,
	[ScheduleId] ASC
)
WHERE ([DELETED]=(0) AND [Active]=(1))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN7FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN7FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormGN7FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormGN7FunctionalLocation](
	[FormGN7Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN7FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN7Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormGN7FunctionalLocation] ON [dbo].[FormGN7FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN7Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN75B]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75B')
	BEGIN
		DROP  table  [dbo].[FormGN75B]
	END
GO
CREATE TABLE [dbo].[FormGN75B](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[BlindsRequired] [bit] NOT NULL,
	[LockBoxNumber] [varchar](30) NULL,
	[LockBoxLocation] [varchar](30) NULL,
	[PathToSchematic] [varchar](max) NULL,
	[SchematicImage] [varbinary](max) NULL,
	[Location] [varchar](50) NULL,
	[EquipmentType] [varchar](50) NULL,

 CONSTRAINT [PK_FormGN75B_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN75A]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75A')
	BEGIN
		DROP  table  [dbo].[FormGN75A]
	END
GO
CREATE TABLE [dbo].[FormGN75A](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[AssociatedFormGN75BId] [bigint] NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,

 CONSTRAINT [PK_FormGN75A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[FormGN59FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN59FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormGN59FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormGN59FunctionalLocation](
	[FormGN59Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN59FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN59Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormGN59FunctionalLocation] ON [dbo].[FormGN59FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN59Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormOilsandsTraining]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsTraining')
	BEGIN
		DROP  table  [dbo].[FormOilsandsTraining]
	END
GO
CREATE TABLE [dbo].[FormOilsandsTraining](
	[FormStatusId] [int] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Id] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
	[GeneralComments] [varchar](max) NULL,
	[TrainingDate] [date] NOT NULL,
	[ShiftId] [bigint] NOT NULL,
	[TotalHours] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_FormOilsandsTraining] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTraining_TrainingDate] ON [dbo].[FormOilsandsTraining] 
(
	[TrainingDate] ASC,
	[ApprovedDateTime] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormOP14FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOP14FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormOP14FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormOP14FunctionalLocation](
	[FormOP14Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormOP14FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormOP14Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormOP14FunctionalLocation] ON [dbo].[FormOP14FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormOP14Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CustomFieldDropDownValue]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomFieldDropDownValue')
	BEGIN
		DROP  table  [dbo].[CustomFieldDropDownValue]
	END
GO
CREATE TABLE [dbo].[CustomFieldDropDownValue](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CustomFieldDropDownValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_CustomFieldDropDownValue_CustomFieldId] ON [dbo].[CustomFieldDropDownValue] 
(
	[CustomFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CustomFieldCustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomFieldCustomFieldGroup')
	BEGIN
		DROP  table  [dbo].[CustomFieldCustomFieldGroup]
	END
GO
CREATE TABLE [dbo].[CustomFieldCustomFieldGroup](
	[CustomFieldId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CustomFieldCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[CustomFieldId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ConfinedSpace]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ConfinedSpace')
	BEGIN
		DROP  table  [dbo].[ConfinedSpace]
	END
GO
CREATE TABLE [dbo].[ConfinedSpace](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
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
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [ConfinedSpace_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ConfinedSpace_DTO] ON [dbo].[ConfinedSpace] 
(
	[FunctionalLocationId] ASC,
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[BusinessCategoryFLOCAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'BusinessCategoryFLOCAssociation')
	BEGIN
		DROP  table  [dbo].[BusinessCategoryFLOCAssociation]
	END
GO
CREATE TABLE [dbo].[BusinessCategoryFLOCAssociation](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[BusinessCategoryId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BusinessCategoryFLOCAssociation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [BusinessCategoryFLOCAssociation_UniqueAssociation] UNIQUE NONCLUSTERED 
(
	[FunctionalLocationId] ASC,
	[BusinessCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CokerCardConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardConfiguration')
	BEGIN
		DROP  table  [dbo].[CokerCardConfiguration]
	END
GO
CREATE TABLE [dbo].[CokerCardConfiguration](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CokerCardConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[FormGN6FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN6FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormGN6FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormGN6FunctionalLocation](
	[FormGN6Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN6FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN6Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN6FunctionalLocation] ON [dbo].[FormGN6FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN6Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormGN6Approval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN6Approval')
	BEGIN
		DROP  table  [dbo].[FormGN6Approval]
	END
GO
CREATE TABLE [dbo].[FormGN6Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN6Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN6Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN6Approval_FormGN6Id] ON [dbo].[FormGN6Approval] 
(
	[FormGN6Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[FormGN24FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN24FunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormGN24FunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormGN24FunctionalLocation](
	[FormGN24Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN24FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN24Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_FormGN24FunctionalLocation] ON [dbo].[FormGN24FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN24Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[DocumentRootPathFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DocumentRootPathFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[DocumentRootPathFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[DocumentRootPathFunctionalLocation](
	[DocumentRootPathId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_DocumentRootPathFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[DocumentRootPathId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[CustomFieldGroupWorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomFieldGroupWorkAssignment')
	BEGIN
		DROP  table  [dbo].[CustomFieldGroupWorkAssignment]
	END
GO
CREATE TABLE [dbo].[CustomFieldGroupWorkAssignment](
	[CustomFieldGroupId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_CustomFieldGroupWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[CustomFieldGroupId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CustomFieldGroupWorkAssignment] ON [dbo].[CustomFieldGroupWorkAssignment] 
(
	[WorkAssignmentId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[DirectiveWorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DirectiveWorkAssignment')
	BEGIN
		DROP  table  [dbo].[DirectiveWorkAssignment]
	END
GO
CREATE TABLE [dbo].[DirectiveWorkAssignment](
	[DirectiveId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_DirectiveWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[DirectiveId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[DirectiveFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DirectiveFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[DirectiveFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[DirectiveFunctionalLocation](
	[DirectiveId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_DirectiveFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[DirectiveId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN1]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN1')
	BEGIN
		DROP  table  [dbo].[FormGN1]
	END
GO
CREATE TABLE [dbo].[FormGN1](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[CSELevel] [varchar](5) NOT NULL,
	[JobDescription] [varchar](256) NULL,
	[PlanningWorksheetContent] [nvarchar](max) NULL,
	[RescuePlanContent] [nvarchar](max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[PlanningWorksheetPlainTextContent] [varchar](max) NULL,
	[RescuePlanPlainTextContent] [varchar](max) NULL,
	[Location] [varchar](128) NOT NULL,
	[TradeChecklistNames] [varchar](max) NULL,

 CONSTRAINT [PK_FormGN1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN1RescuePlanApproval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN1RescuePlanApproval')
	BEGIN
		DROP  table  [dbo].[FormGN1RescuePlanApproval]
	END
GO
CREATE TABLE [dbo].[FormGN1RescuePlanApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN1Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN1RescuePlanApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN1PlanningWorksheetApproval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN1PlanningWorksheetApproval')
	BEGIN
		DROP  table  [dbo].[FormGN1PlanningWorksheetApproval]
	END
GO
CREATE TABLE [dbo].[FormGN1PlanningWorksheetApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN1Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN1PlanningWorksheetApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[DeviationAlertResponseReasonCodeAssignment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DeviationAlertResponseReasonCodeAssignment')
	BEGIN
		DROP  table  [dbo].[DeviationAlertResponseReasonCodeAssignment]
	END
GO
CREATE TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[DeviationAlertResponseId] [bigint] NULL,
	[RestrictionReasonCodeId] [bigint] NOT NULL,
	[ReasonCodeFunctionalLocationId] [bigint] NOT NULL,
	[AssignedAmount] [int] NOT NULL,
	[Comments] [varchar](max) NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[RestrictionLocationItemId] [bigint] NULL,
	[PlantState] [varchar](50) NULL,
 CONSTRAINT [PK_DeviationAlertResponseReasonCodeAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_DeviationAlertResponseReasonCodeAssignment_DeviationAlertResponse] ON [dbo].[DeviationAlertResponseReasonCodeAssignment] 
(
	[DeviationAlertResponseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[DeviationAlert]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DeviationAlert')
	BEGIN
		DROP  table  [dbo].[DeviationAlert]
	END
GO
CREATE TABLE [dbo].[DeviationAlert](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[DeviationAlertResponseId] [bigint] NULL,
	[RestrictionDefinitionName] [varchar](30) NOT NULL,
	[RestrictionDefinitionDescription] [varchar](max) NULL,
	[ProductionTargetValue] [int] NULL,
	[MeasurementValue] [int] NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[RestrictionDefinitionId] [bigint] NOT NULL,
	[MeasurementValueTagId] [bigint] NOT NULL,
	[ProductionTargetValueTagId] [bigint] NULL,
	[Comments] [varchar](2048) NULL,
	[IsOnlyVisibleOnReports] [bit] NOT NULL,
 CONSTRAINT [PK_DeviationAlert] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_DeviationAlert_CreatedDateTime] ON [dbo].[DeviationAlert] 
(
	[CreatedDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DeviationAlert_StartDateTime] ON [dbo].[DeviationAlert] 
(
	[StartDateTime] ASC,
	[FunctionalLocationID] ASC,
	[EndDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CokerCardConfigurationWorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardConfigurationWorkAssignment')
	BEGIN
		DROP  table  [dbo].[CokerCardConfigurationWorkAssignment]
	END
GO
CREATE TABLE [dbo].[CokerCardConfigurationWorkAssignment](
	[CokerCardConfigurationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL,
 CONSTRAINT [PK_CokerCardConfigurationWorkAssignment] PRIMARY KEY CLUSTERED 
(
	[CokerCardConfigurationId] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[CokerCardConfigurationDrum]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardConfigurationDrum')
	BEGIN
		DROP  table  [dbo].[CokerCardConfigurationDrum]
	END
GO
CREATE TABLE [dbo].[CokerCardConfigurationDrum](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CokerCardConfigurationId] [bigint] NOT NULL,
 CONSTRAINT [PK_CokerCardConfigurationDrum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[CokerCardConfigurationCycleStep]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardConfigurationCycleStep')
	BEGIN
		DROP  table  [dbo].[CokerCardConfigurationCycleStep]
	END
GO
CREATE TABLE [dbo].[CokerCardConfigurationCycleStep](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CokerCardConfigurationId] [bigint] NOT NULL,
 CONSTRAINT [PK_CokerCardConfigurationCycleStep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[CokerCard]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCard')
	BEGIN
		DROP  table  [dbo].[CokerCard]
	END
GO
CREATE TABLE [dbo].[CokerCard](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardConfigurationId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[ShiftId] [bigint] NOT NULL,
	[ShiftStartDate] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CokerCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCard_ConfigurationId_ShiftId] ON [dbo].[CokerCard] 
(
	[CokerCardConfigurationId] ASC,
	[ShiftId] ASC,
	[ShiftStartDate] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCard_CreatedDateTime_FunctionalLocationId] ON [dbo].[CokerCard] 
(
	[CreatedDateTime] ASC,
	[FunctionalLocationId] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[ActionItemDefinition]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinition')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinition]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinition](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[BusinessCategoryId] [bigint] NULL,
	[ActionItemDefinitionStatusId] [bigint] NOT NULL,
	[ScheduleId] [bigint] NOT NULL,
	[RequiresApproval] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[ResponseRequired] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
	[SourceId] [int] NOT NULL,
	[SapOperationId] [bigint] NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[OperationalModeId] [int] NOT NULL,
	[PriorityId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] SPARSE  NULL,
	[CreateAnActionItemForEachFunctionalLocation] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[GN75BId] [bigint] SPARSE  NULL,
 CONSTRAINT [PK_ActionItemDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDef_LastModifiedUser] ON [dbo].[ActionItemDefinition] 
(
	[LastModifiedUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDef_Name] ON [dbo].[ActionItemDefinition] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDef_Schedule] ON [dbo].[ActionItemDefinition] 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_SapOperation] ON [dbo].[ActionItemDefinition] 
(
	[SapOperationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_WorkAssignmentId] ON [dbo].[ActionItemDefinition] 
(
	[WorkAssignmentId] ASC,
	[Active] ASC
)
INCLUDE ( [ScheduleId]) 
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_WorkAssignmentId_Filtered] ON [dbo].[ActionItemDefinition] 
(
	[WorkAssignmentId] ASC,
	[Active] ASC
)
INCLUDE ( [ScheduleId]) 
WHERE ([WorkAssignmentId] IS NOT NULL AND [DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormOilsandsTrainingItem]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsTrainingItem')
	BEGIN
		DROP  table  [dbo].[FormOilsandsTrainingItem]
	END
GO
CREATE TABLE [dbo].[FormOilsandsTrainingItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[TrainingBlockId] [bigint] NULL,
	[Comments] [varchar](1000) NULL,
	[BlockCompleted] [bit] NOT NULL,
	[Hours] [decimal](8, 2) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTrainingItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTrainingItem_FormOilsandsTrainingId] ON [dbo].[FormOilsandsTrainingItem] 
(
	[FormOilsandsTrainingId] ASC
)
INCLUDE ( [TrainingBlockId]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormOilsandsTrainingFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsTrainingFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[FormOilsandsTrainingFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[FormOilsandsTrainingFunctionalLocation](
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTrainingFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormOilsandsTrainingId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[FormOilsandsTrainingApproval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormOilsandsTrainingApproval')
	BEGIN
		DROP  table  [dbo].[FormOilsandsTrainingApproval]
	END
GO
CREATE TABLE [dbo].[FormOilsandsTrainingApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormOilsandsTrainingId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormOilsandsTrainingApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTrainingApproval_FormOilsandsTrainingId] ON [dbo].[FormOilsandsTrainingApproval] 
(
	[FormOilsandsTrainingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN75BUserReadDocumentLinkAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75BUserReadDocumentLinkAssociation')
	BEGIN
		DROP  table  [dbo].[FormGN75BUserReadDocumentLinkAssociation]
	END
GO
CREATE TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation](
	[UserId] [bigint] NOT NULL,
	[FormGN75BId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN75BUserReadDocumentLinkAssociation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FormGN75BId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FormGN75BIsolationItem]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75BIsolationItem')
	BEGIN
		DROP  table  [dbo].[FormGN75BIsolationItem]
	END
GO
CREATE TABLE [dbo].[FormGN75BIsolationItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75BId] [bigint] NOT NULL,
	[IsolationType] [varchar](100) NOT NULL,
	[LocationOfEnergyIsolation] [varchar](500) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN75IsolationItem_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[FormGN75AApproval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'FormGN75AApproval')
	BEGIN
		DROP  table  [dbo].[FormGN75AApproval]
	END
GO
CREATE TABLE [dbo].[FormGN75AApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75AId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN75AApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[Log]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Log')
	BEGIN
		DROP  table  [dbo].[Log]
	END
GO
CREATE TABLE [dbo].[Log](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[LogDefinitionId] [bigint] SPARSE  NULL,
	[RootLogId] [bigint] SPARSE  NULL,
	[ReplyToLogId] [bigint] SPARSE  NULL,
	[SourceId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CreationUserShiftPatternId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[LogType] [tinyint] NOT NULL,
	[RecommendForShiftSummary] [bit] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[PlainTextComments] [varchar](max) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
	[IsOperatingEngineerLog] [bit] NOT NULL,
	[RtfComments] [varchar](max) NOT NULL,
	[HasChildren] [bit] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_Log_DefinitionId] ON [dbo].[Log] 
(
	[LogDefinitionId] ASC
)
INCLUDE ( [LogDateTime]) 
WHERE ([Deleted]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Log_DirectiveByWorkAssignmentPage] ON [dbo].[Log] 
(
	[CreatedDateTime] ASC,
	[WorkAssignmentId] ASC
)
INCLUDE ( [UserId],
[LastModifiedUserId],
[CreationUserShiftPatternId],
[LogDefinitionId]) 
WHERE ([DELETED]=(0) AND [LogType]=(3))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Log_LogAndDirectivePage] ON [dbo].[Log] 
(
	[CreatedDateTime] ASC,
	[WorkAssignmentId] ASC,
	[LogType] ASC
)
INCLUDE ( [CreationUserShiftPatternId],
[UserId],
[LastModifiedUserId],
[LogDefinitionId]) 
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Log_LogByWorkAssignmentPage] ON [dbo].[Log] 
(
	[CreatedDateTime] ASC,
	[WorkAssignmentId] ASC
)
INCLUDE ( [UserId],
[LastModifiedUserId],
[CreationUserShiftPatternId],
[LogDefinitionId]) 
WHERE ([DELETED]=(0) AND [LogType]=(1))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Log_ReplyToLog] ON [dbo].[Log] 
(
	[ReplyToLogId] ASC
)
WHERE ([Deleted]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LabAlert]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LabAlert')
	BEGIN
		DROP  table  [dbo].[LabAlert]
	END
GO
CREATE TABLE [dbo].[LabAlert](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](max) NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[TagId] [bigint] NOT NULL,
	[MinimumNumberOfSamples] [int] NOT NULL,
	[ActualNumberOfSamples] [int] NOT NULL,
	[LabAlertTagQueryRangeFromDateTime] [datetime] NOT NULL,
	[LabAlertTagQueryRangeToDateTime] [datetime] NOT NULL,
	[ScheduleDescription] [varchar](512) NOT NULL,
	[LabAlertDefinitionId] [bigint] NOT NULL,
	[LabAlertStatusId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LabAlert] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_LabAlert_CreatedDateTime] ON [dbo].[LabAlert] 
(
	[CreatedDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[LogDefinitionCustomFieldEntry]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinitionCustomFieldEntry')
	BEGIN
		DROP  table  [dbo].[LogDefinitionCustomFieldEntry]
	END
GO
CREATE TABLE [dbo].[LogDefinitionCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[LogDefinitionId] [bigint] NOT NULL,
	[CustomFieldName] [varchar](40) NOT NULL,
	[FieldEntry] [varchar](100) NULL,
	[DisplayOrder] [int] NOT NULL,
	[TypeId] [tinyint] NOT NULL,
	[NumericFieldEntry] [decimal](18, 6) NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_LogDefinitionCustomFieldEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[LogDefinitionHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinitionHistory')
	BEGIN
		DROP  table  [dbo].[LogDefinitionHistory]
	END
GO
CREATE TABLE [dbo].[LogDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[EnvironmentalHealthSafetyFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Schedule] [varchar](300) NULL,
	[DocumentLinks] [varchar](1000) NULL,
	[LogDefinitionHistoryId] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[FunctionalLocations] [varchar](max) NULL,
	[PlainTextComments] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_LogDefinitionHistory] PRIMARY KEY CLUSTERED 
(
	[LogDefinitionHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_LogDefinitionHistory] ON [dbo].[LogDefinitionHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LogDefinitionFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinitionFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[LogDefinitionFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[LogDefinitionFunctionalLocation](
	[LogDefinitionId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogDefinitionFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[LogDefinitionId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_LogDefinitionFunctionalLocation_Floc] ON [dbo].[LogDefinitionFunctionalLocation] 
(
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LogDefinitionCustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinitionCustomFieldGroup')
	BEGIN
		DROP  table  [dbo].[LogDefinitionCustomFieldGroup]
	END
GO
CREATE TABLE [dbo].[LogDefinitionCustomFieldGroup](
	[LogDefinitionId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogDefinitionCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[LogDefinitionId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[OvertimeFormContractor]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'OvertimeFormContractor')
	BEGIN
		DROP  table  [dbo].[OvertimeFormContractor]
	END
GO
CREATE TABLE [dbo].[OvertimeFormContractor](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[OvertimeFormId] [bigint] NOT NULL,
	[PersonnelName] [varchar](50) NOT NULL,
	[PrimaryLocation] [varchar](20) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[IsDayShift] [bit] NOT NULL,
	[IsNightShift] [bit] NOT NULL,
	[PhoneNumber] [varchar](25) NULL,
	[Radio] [varchar](15) NULL,
	[Description] [varchar](100) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[WorkOrderNumber] [varchar](15) NULL,
	[ExpectedHours] [decimal](8, 2) NOT NULL,
	[Deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_OvertimeFormContractor_OvertimeForm] ON [dbo].[OvertimeFormContractor] 
(
	[OvertimeFormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[OvertimeFormApproval]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'OvertimeFormApproval')
	BEGIN
		DROP  table  [dbo].[OvertimeFormApproval]
	END
GO
CREATE TABLE [dbo].[OvertimeFormApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[OvertimeFormId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[WorkAssignmentDisplayName] [varchar](40) NULL,
 CONSTRAINT [PK_OvertimeFormApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_Overtime_FormId] ON [dbo].[OvertimeFormApproval] 
(
	[OvertimeFormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[UserLoginHistoryFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserLoginHistoryFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[UserLoginHistoryFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[UserLoginHistoryFunctionalLocation](
	[UserLoginHistoryId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserLoginHistoryFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[UserLoginHistoryId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[TargetDefinitionComment]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionComment')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionComment]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionComment](
	[TargetDefinitionId] [bigint] NOT NULL,
	[CommentId] [bigint] NOT NULL,
 CONSTRAINT [PK_TargetDefinitionComment] PRIMARY KEY CLUSTERED 
(
	[TargetDefinitionId] ASC,
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TargetDefinitionAssociation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionAssociation')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionAssociation]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionAssociation](
	[ParentTargetDefinitionId] [bigint] NOT NULL,
	[ChildTargetDefinitionId] [bigint] NOT NULL,
 CONSTRAINT [PK_TargetDefinitionAssociation] PRIMARY KEY CLUSTERED 
(
	[ParentTargetDefinitionId] ASC,
	[ChildTargetDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TradeChecklist]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TradeChecklist')
	BEGIN
		DROP  table  [dbo].[TradeChecklist]
	END
GO
CREATE TABLE [dbo].[TradeChecklist](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SequenceNumber] [int] NOT NULL,
	[FormGN1Id] [bigint] NOT NULL,
	[Trade] [varchar](128) NOT NULL,
	[ConstFieldMaintCoordApproval] [bit] NOT NULL,
	[OpsCoordApproval] [bit] NOT NULL,
	[AreaManagerApproval] [bit] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [varchar](max) NULL,
	[ConstFieldMaintCoordApprovalLastModifiedId] [bigint] NULL,
	[OpsCoordApprovalLastModifiedId] [bigint] NULL,
	[AreaManagerApprovalLastModifiedId] [bigint] NULL,
	[ConstFieldMaintCoordApprovalDateTime] [datetime] NULL,
	[OpsCoordApprovalDateTime] [datetime] NULL,
	[AreaManagerApprovalDateTime] [datetime] NULL,
 CONSTRAINT [PK_TradeChecklist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[TargetDefinitionState]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionState')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionState]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionState](
	[TargetDefinitionId] [bigint] NOT NULL,
	[ExceedingBoundaries] [bit] NOT NULL,
	[LastSuccessfulTagAccess] [datetime] NULL,
 CONSTRAINT [PK_TargetDefinitionState] PRIMARY KEY CLUSTERED 
(
	[TargetDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TargetDefinitionReadWriteTagConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetDefinitionReadWriteTagConfiguration')
	BEGIN
		DROP  table  [dbo].[TargetDefinitionReadWriteTagConfiguration]
	END
GO
CREATE TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[MaxDirectionId] [bigint] NOT NULL,
	[MaxTagId] [bigint] NULL,
	[MinDirectionId] [bigint] NOT NULL,
	[MinTagId] [bigint] NULL,
	[TargetDirectionId] [bigint] NOT NULL,
	[TargetTagId] [bigint] NULL,
	[GapUnitValueDirectionId] [bigint] NOT NULL,
	[GapUnitValueTagId] [bigint] NULL,
	[Deleted] [bit] NOT NULL,
	[TargetDefinitionId] [bigint] NOT NULL,
 CONSTRAINT [PK_TargetDefinitionReadWriteTagConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetDefinitionReadWriteTagConf] ON [dbo].[TargetDefinitionReadWriteTagConfiguration] 
(
	[Deleted] ASC,
	[TargetDefinitionId] ASC,
	[GapUnitValueTagId] ASC,
	[TargetTagId] ASC
)
INCLUDE ( [TargetDirectionId],
[GapUnitValueDirectionId]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[WorkPermitLubes]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitLubes')
	BEGIN
		DROP  table  [dbo].[WorkPermitLubes]
	END
GO
CREATE TABLE [dbo].[WorkPermitLubes](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PermitRequestId] [bigint] NULL,
	[DataSourceId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Trade] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[RequestedByGroupId] [bigint] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](50) NULL,
	[RescuePlan] [bit] NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](50) NULL,
	[HazardousWorkApproverAdvised] [bit] NOT NULL,
	[AdditionalFollowupRequired] [bit] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[ExpireDateTime] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[HazardHydrocarbonGas] [bit] NOT NULL,
	[HazardHydrocarbonLiquid] [bit] NOT NULL,
	[HazardHydrogenSulphide] [bit] NOT NULL,
	[HazardInertGasAtmosphere] [bit] NOT NULL,
	[HazardOxygenDeficiency] [bit] NOT NULL,
	[HazardRadioactiveSources] [bit] NOT NULL,
	[HazardUndergroundOverheadHazards] [bit] NOT NULL,
	[HazardDesignatedSubstance] [bit] NOT NULL,
	[OtherHazardsAndOrRequirements] [varchar](max) NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[WorkPreparationsCompletedSectionNotApplicableToJob] [bit] NOT NULL,
	[ProductNormallyInPipingEquipment] [varchar](50) NULL,
	[DepressuredDrained] [bit] NULL,
	[WaterWashed] [bit] NULL,
	[Steamed] [bit] NULL,
	[Purged] [bit] NULL,
	[Disconnected] [bit] NULL,
	[DepressuredAndVented] [bit] NULL,
	[Ventilated] [bit] NULL,
	[Blanked] [bit] NULL,
	[DrainsCovered] [bit] NULL,
	[AreaBarricated] [bit] NULL,
	[EnergySourcesLockedOutTaggedOut] [bit] NULL,
	[EnergyControlPlan] [varchar](15) NULL,
	[LockBoxNumber] [varchar](15) NULL,
	[OtherPreparations] [varchar](15) NULL,
	[SpecificRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[AttendedAtAllTimes] [bit] NOT NULL,
	[EyeProtection] [bit] NOT NULL,
	[FallProtectionEquipment] [bit] NOT NULL,
	[FullBodyHarnessRetrieval] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[ProtectiveClothing] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other1Value] [varchar](15) NULL,
	[EquipmentBondedGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireFightingEquipment] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[HydrantPermit] [bit] NOT NULL,
	[WaterHose] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other2Value] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[DrowningProtection] [bit] NOT NULL,
	[RespiratoryProtection] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other3Value] [varchar](15) NULL,
	[AdditionalLighting] [bit] NOT NULL,
	[DesignateHotOrColdCutChecked] [bit] NOT NULL,
	[DesignateHotOrColdCutValue] [varchar](6) NULL,
	[HoistingEquipment] [bit] NOT NULL,
	[Ladder] [bit] NOT NULL,
	[MotorizedEquipment] [bit] NOT NULL,
	[Scaffold] [bit] NOT NULL,
	[ReferToTipsProcedure] [bit] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[HighEnergy] [tinyint] NOT NULL,
	[CriticalLift] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[EnergyControlPlanFormRequirement] [tinyint] NOT NULL,
	[EquivalencyProc] [tinyint] NOT NULL,
	[TestPneumatic] [tinyint] NOT NULL,
	[LiveFlareWork] [tinyint] NOT NULL,
	[EntryAndControlPlan] [tinyint] NOT NULL,
	[WorkPermitStatus] [int] NOT NULL,
	[IssuedDateTime] [datetime] NULL,
	[PermitRequestSubmittedByUserId] [bigint] NULL,
	[ChemicallyWashed] [bit] NULL,
	[UsePreviousPermitAnswered] [bit] NOT NULL,
	[GasDetectorBumpTested] [bit] NOT NULL,
	[IsVehicleEntry] [bit] NOT NULL,
	[AtmosphericGasTestRequired] [bit] NOT NULL,
	[IssuedByUserId] [bigint] NULL,
	[EnergizedElectrical] [tinyint] NOT NULL,
 CONSTRAINT [PK_WorkPermitLubes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitLubes_DTO] ON [dbo].[WorkPermitLubes] 
(
	[StartDateTime] ASC,
	[ExpireDateTime] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[WorkPermitGasTestElementInfo]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitGasTestElementInfo')
	BEGIN
		DROP  table  [dbo].[WorkPermitGasTestElementInfo]
	END
GO
CREATE TABLE [dbo].[WorkPermitGasTestElementInfo](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitId] [bigint] NOT NULL,
	[GasTestElementInfoId] [bigint] NOT NULL,
	[RequiredTest] [bit] NOT NULL,
	[LegacyFirstTestResult] [varchar](50) NULL,
	[FirstTestResult] [float] NULL,
	[ConfinedSpaceTestResult] [float] NULL,
	[ConfinedSpaceTestRequired] [bit] NOT NULL,
	[SystemEntryTestResult] [float] NULL,
	[SystemEntryTestNotApplicable] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitGasTestElementInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[WorkPermitId] ASC,
	[GasTestElementInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitGasTestElementInfo_WorkPermit] ON [dbo].[WorkPermitGasTestElementInfo] 
(
	[WorkPermitId] ASC,
	[Id] ASC,
	[GasTestElementInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[WorkPermitEdmontonHistory]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitEdmontonHistory')
	BEGIN
		DROP  table  [dbo].[WorkPermitEdmontonHistory]
	END
GO
CREATE TABLE [dbo].[WorkPermitEdmontonHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](50) NULL,
	[RequestedStartDateTime] [datetime] NOT NULL,
	[IssuedDateTime] [datetime] NULL,
	[ExpiredDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[HazardsAndOrRequirements] [varchar](2000) NULL,
	[RequestedByUserId] [bigint] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[Group] [varchar](50) NULL,
	[SpecialWorkFormNumber] [varchar](10) NULL,
	[SpecialWorkType] [varchar](42) NULL,
	[VehicleEntryType] [varchar](30) NULL,
	[RescuePlanFormNumber] [varchar](10) NULL,
	[StatusOfPipingEquipmentSectionNotApplicableToJob] [bit] NOT NULL,
	[ProductNormallyInPipingEquipment] [varchar](50) NULL,
	[IsolationValvesLocked] [varchar](10) NOT NULL,
	[DepressuredDrained] [varchar](10) NOT NULL,
	[Ventilated] [varchar](10) NOT NULL,
	[Purged] [varchar](10) NOT NULL,
	[BlindedAndTagged] [varchar](10) NOT NULL,
	[DoubleBlockAndBleed] [varchar](10) NOT NULL,
	[ElectricalLockout] [varchar](10) NOT NULL,
	[MechanicalLockout] [varchar](10) NOT NULL,
	[BlindSchematicAvailable] [varchar](10) NOT NULL,
	[ZeroEnergyFormNumber] [varchar](10) NULL,
	[LockBoxNumber] [varchar](10) NULL,
	[JobsiteEquipmentInspected] [bit] NOT NULL,
	[ConfinedSpaceWorkSectionNotApplicableToJob] [bit] NOT NULL,
	[QuestionOneResponse] [varchar](10) NOT NULL,
	[QuestionTwoResponse] [varchar](10) NOT NULL,
	[QuestionTwoAResponse] [varchar](10) NOT NULL,
	[QuestionTwoBResponse] [varchar](10) NOT NULL,
	[QuestionThreeResponse] [varchar](10) NOT NULL,
	[QuestionFourResponse] [varchar](10) NOT NULL,
	[GasTestsSectionNotApplicableToJob] [bit] NOT NULL,
	[OperatorGasDetectorNumber] [varchar](30) NULL,
	[GasTestDataLine1CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine1Oxygen] [varchar](10) NULL,
	[GasTestDataLine1ToxicGas] [varchar](20) NULL,
	[GasTestDataLine1Time] [datetime] NULL,
	[GasTestDataLine2CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine2Oxygen] [varchar](10) NULL,
	[GasTestDataLine2ToxicGas] [varchar](20) NULL,
	[GasTestDataLine2Time] [datetime] NULL,
	[GasTestDataLine3CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine3Oxygen] [varchar](10) NULL,
	[GasTestDataLine3ToxicGas] [varchar](20) NULL,
	[GasTestDataLine3Time] [datetime] NULL,
	[GasTestDataLine4CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine4Oxygen] [varchar](10) NULL,
	[GasTestDataLine4ToxicGas] [varchar](20) NULL,
	[GasTestDataLine4Time] [datetime] NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [varchar](15) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [varchar](15) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [varchar](15) NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](10) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[VehicleEntryTotal] [int] NULL,
	[GN6_Deprecated] [varchar](50) NOT NULL,
	[GN11] [varchar](50) NOT NULL,
	[GN24_Deprecated] [varchar](50) NOT NULL,
	[GN27] [varchar](50) NOT NULL,
	[GN75_Deprecated] [varchar](50) NOT NULL,
	[WorkersMonitorNumber] [varchar](10) NULL,
	[RadioChannelNumber] [varchar](10) NULL,
	[DurationPermit] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
	[FormGN7Id] [bigint] NULL,
	[FormGN59Id] [bigint] NULL,
	[DocumentLinks] [varchar](max) NULL,
	[WorkerToProvideGasTestData] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other4Checked] [bit] NOT NULL,
	[UseCurrentPermitNumberForZeroEnergyFormNumber] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[PermitAcceptor] [varchar](30) NULL,
	[ShiftSupervisor] [varchar](30) NULL,
	[PriorityId] [int] NOT NULL,
	[AreaLabel] [varchar](40) NULL,
	[GN24] [bit] NOT NULL,
	[FormGN24Id] [bigint] NULL,
	[GN6] [bit] NOT NULL,
	[FormGN6Id] [bigint] NULL,
	[FormGN75AId] [bigint] NULL,
	[GN75A] [bit] NOT NULL,
	[FormGN1TradeChecklistDisplayNumber] [varchar](32) NULL,
	[GN1] [bit] NULL,
	[FormGN1Id] [bigint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_WorkPermitEdmontonHistory] ON [dbo].[WorkPermitEdmontonHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[SummaryLogRead]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogRead')
	BEGIN
		DROP  table  [dbo].[SummaryLogRead]
	END
GO
CREATE TABLE [dbo].[SummaryLogRead](
	[SummaryLogId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SummaryLogRead] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[SummaryLogFunctionalLocationList]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogFunctionalLocationList')
	BEGIN
		DROP  table  [dbo].[SummaryLogFunctionalLocationList]
	END
GO
CREATE TABLE [dbo].[SummaryLogFunctionalLocationList](
	[SummaryLogId] [bigint] NOT NULL,
	[FunctionalLocationList] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SummaryLogFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[SummaryLogFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[SummaryLogFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[SummaryLogFunctionalLocation](
	[SummaryLogId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_SummaryLogFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_SummaryLogFunctionalLocation] ON [dbo].[SummaryLogFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[SummaryLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[SummaryLogCustomFieldGroup]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogCustomFieldGroup')
	BEGIN
		DROP  table  [dbo].[SummaryLogCustomFieldGroup]
	END
GO
CREATE TABLE [dbo].[SummaryLogCustomFieldGroup](
	[SummaryLogId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SummaryLogCustomFieldGroup_RealOne] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TargetAlert]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetAlert')
	BEGIN
		DROP  table  [dbo].[TargetAlert]
	END
GO
CREATE TABLE [dbo].[TargetAlert](
	[ID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TargetDefinitionID] [bigint] NOT NULL,
	[TargetName] [varchar](30) NULL,
	[NeverToExceedMax] [decimal](9, 2) NULL,
	[NeverToExceedMin] [decimal](9, 2) NULL,
	[MaxValue] [decimal](9, 2) NULL,
	[MinValue] [decimal](9, 2) NULL,
	[NeverToExceedMaxFrequency] [int] NULL,
	[NeverToExceedMinFrequency] [int] NULL,
	[MaxValueFrequency] [int] NULL,
	[MinValueFrequency] [int] NULL,
	[TargetAlertValue] [decimal](9, 2) NULL,
	[GapUnitValue] [decimal](9, 2) NULL,
	[TargetAlertStatusID] [bigint] NOT NULL,
	[ExceedingBoundaries] [bit] NOT NULL,
	[TagID] [bigint] NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[TargetCategoryID] [bigint] NOT NULL,
	[CreatedByScheduleTypeId] [int] NOT NULL,
	[Description] [varchar](max) NULL,
	[RequiresResponse] [bit] NOT NULL,
	[ActualValue] [decimal](9, 2) NULL,
	[TargetValueTypeId] [bigint] NOT NULL,
	[AcknowledgedUserId] [bigint] NULL,
	[AcknowledgedDateTime] [datetime] NULL,
	[PriorityId] [bigint] NOT NULL,
	[OriginalExceedingValue] [decimal](9, 2) NULL,
	[TypeOfViolationStatusId] [int] NOT NULL,
	[LastViolatedDateTime] [datetime] NOT NULL,
	[MaxAtEvaluation] [decimal](9, 2) NULL,
	[MinAtEvaluation] [decimal](9, 2) NULL,
	[NTEMaxAtEvaluation] [decimal](9, 2) NULL,
	[NTEMinAtEvaluation] [decimal](9, 2) NULL,
	[ActualValueAtEvaluation] [decimal](9, 2) NULL,
 CONSTRAINT [PK_TargetAlert] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlert_DefId] ON [dbo].[TargetAlert] 
(
	[TargetDefinitionID] ASC,
	[TargetAlertStatusID] ASC,
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlert_DTO] ON [dbo].[TargetAlert] 
(
	[CreatedDateTime] ASC,
	[TargetAlertStatusID] ASC
)
INCLUDE ( [TagID],
[TargetDefinitionID],
[FunctionalLocationID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlert_FLOC] ON [dbo].[TargetAlert] 
(
	[FunctionalLocationID] ASC,
	[TargetAlertStatusID] ASC,
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[SummaryLogCustomFieldEntry]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SummaryLogCustomFieldEntry')
	BEGIN
		DROP  table  [dbo].[SummaryLogCustomFieldEntry]
	END
GO
CREATE TABLE [dbo].[SummaryLogCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[SummaryLogId] [bigint] NOT NULL,
	[SummaryLogCustomFieldName] [varchar](40) NOT NULL,
	[FieldEntry] [varchar](100) NULL,
	[DisplayOrder] [int] NOT NULL,
	[TypeId] [tinyint] NOT NULL,
	[NumericFieldEntry] [decimal](18, 6) NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_SummaryLogCustomFieldEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_SummaryLogCustomFieldEntry_CustomFieldId] ON [dbo].[SummaryLogCustomFieldEntry] 
(
	[SummaryLogId] ASC,
	[CustomFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_SummaryLogCustomFieldEntry_SummaryLogId] ON [dbo].[SummaryLogCustomFieldEntry] 
(
	[SummaryLogId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[PermitRequestEdmontonHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestEdmontonHistory')
	BEGIN
		DROP  table  [dbo].[PermitRequestEdmontonHistory]
	END
GO
CREATE TABLE [dbo].[PermitRequestEdmontonHistory](
	[Id] [bigint] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[SAPDescription] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](15) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[RescuePlanFormNumber] [varchar](15) NULL,
	[VehicleEntryType] [varchar](30) NULL,
	[SpecialWorkFormNumber] [varchar](15) NULL,
	[SpecialWorkType] [varchar](42) NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	[HazardsAndOrRequirements] [varchar](500) NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [varchar](30) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [varchar](30) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [varchar](30) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [varchar](30) NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[Group] [varchar](50) NULL,
	[VehicleEntryTotal] [int] NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[GN6_Deprecated] [varchar](50) NOT NULL,
	[GN11] [varchar](50) NOT NULL,
	[GN24_Deprecated] [varchar](50) NOT NULL,
	[GN27] [varchar](50) NOT NULL,
	[GN75_Deprecated] [varchar](50) NOT NULL,
	[WorkersMonitorNumber] [varchar](10) NULL,
	[RadioChannelNumber] [varchar](10) NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
	[FormGN7Id] [bigint] NULL,
	[FormGN59Id] [bigint] NULL,
	[DocumentLinks] [varchar](max) NULL,
	[CompletionStatusId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[AreaLabel] [varchar](40) NULL,
	[GN24] [bit] NOT NULL,
	[FormGN24Id] [bigint] NULL,
	[GN6] [bit] NOT NULL,
	[FormGN6Id] [bigint] NULL,
	[FormGN75AId] [bigint] NULL,
	[GN75A] [bit] NOT NULL,
	[FormGN1TradeChecklistDisplayNumber] [varchar](32) NULL,
	[GN1] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_PermitRequestEdmontonHistory_Id] ON [dbo].[PermitRequestEdmontonHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[PermitRequestLubesWorkOrderSource]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestLubesWorkOrderSource')
	BEGIN
		DROP  table  [dbo].[PermitRequestLubesWorkOrderSource]
	END
GO
CREATE TABLE [dbo].[PermitRequestLubesWorkOrderSource](
	[PermitRequestLubesId] [bigint] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_PermitRequestLubesSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestLubesWorkOrderSource] 
(
	[OperationNumber] ASC,
	[SubOperationNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[RestrictionLocationItemReasonCode]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'RestrictionLocationItemReasonCode')
	BEGIN
		DROP  table  [dbo].[RestrictionLocationItemReasonCode]
	END
GO
CREATE TABLE [dbo].[RestrictionLocationItemReasonCode](
	[RestrictionLocationItemId] [bigint] NOT NULL,
	[RestrictionReasonCodeId] [bigint] NOT NULL,
	[Limit] [int] NULL,
 CONSTRAINT [PK_RestrictionLocationItemReasonCode] PRIMARY KEY CLUSTERED 
(
	[RestrictionLocationItemId] ASC,
	[RestrictionReasonCodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaire')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaire]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaire](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ShiftHandoverConfigurationName] [varchar](50) NOT NULL,
	[ShiftId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[HasYesAnswer] [bit] NOT NULL,
	[LogId] [bigint] NULL,
	[SummaryLogId] [bigint] NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaire] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaire_DTO] ON [dbo].[ShiftHandoverQuestionnaire] 
(
	[CreatedDateTime] ASC,
	[WorkAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TargetAlertResponse]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TargetAlertResponse')
	BEGIN
		DROP  table  [dbo].[TargetAlertResponse]
	END
GO
CREATE TABLE [dbo].[TargetAlertResponse](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TargetAlertId] [bigint] NOT NULL,
	[CommentId] [bigint] NOT NULL,
	[TargetGapReasonId] [bigint] NULL,
	[ResponsibleFunctionalLocationId] [bigint] NULL,
	[CreatedShiftPatternId] [bigint] NULL,
 CONSTRAINT [PK_TargetAlertResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlertResponse_Comment] ON [dbo].[TargetAlertResponse] 
(
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlertResponse_FLOC] ON [dbo].[TargetAlertResponse] 
(
	[ResponsibleFunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_TargetAlertResponse_TargetAlert] ON [dbo].[TargetAlertResponse] 
(
	[TargetAlertId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[PermitRequestEdmonton]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestEdmonton')
	BEGIN
		DROP  table  [dbo].[PermitRequestEdmonton]
	END
GO
CREATE TABLE [dbo].[PermitRequestEdmonton](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TaskDescription] [varchar](max) NULL,
	[SAPDescription] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[DataSourceId] [int] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsModified] [bit] NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](15) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[RescuePlanFormNumber] [varchar](15) NULL,
	[VehicleEntryType] [varchar](30) NULL,
	[SpecialWorkFormNumber] [varchar](15) NULL,
	[SpecialWorkType] [int] NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	[HazardsAndOrRequirements] [varchar](500) NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [varchar](30) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [varchar](30) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [varchar](30) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [varchar](30) NULL,
	[Deleted] [bit] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[VehicleEntryTotal] [int] NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[GN6_Deprecated] [int] NOT NULL,
	[GN11] [int] NOT NULL,
	[GN24_Deprecated] [int] NOT NULL,
	[GN27] [int] NOT NULL,
	[GN75_Deprecated] [int] NOT NULL,
	[WorkersMonitorNumber] [varchar](10) NULL,
	[RadioChannelNumber] [varchar](10) NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
	[FormGN59Id] [bigint] NULL,
	[FormGN7Id] [bigint] NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[SAPWorkCentre] [varchar](40) NULL,
	[DoNotMerge] [bit] NOT NULL,
	[CompletionStatusId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[AreaLabelId] [bigint] NULL,
	[GN24] [bit] NOT NULL,
	[FormGN24Id] [bigint] NULL,
	[GN6] [bit] NOT NULL,
	[FormGN6Id] [bigint] NULL,
	[FormGN75AId] [bigint] NULL,
	[GN75A] [bit] NOT NULL,
	[FormGN1Id] [bigint] NULL,
	[GN1] [bit] NOT NULL,
	[FormGN1TradeChecklistId] [bigint] NULL,
	[FormGN1TradeChecklistDisplayNumber] [varchar](32) NULL,
 CONSTRAINT [PK_PermitRequestEdmonton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmonton_DTO_Covering] ON [dbo].[PermitRequestEdmonton] 
(
	[RequestedStartDate] ASC,
	[EndDate] ASC,
	[FunctionalLocationId] ASC
)
INCLUDE ( [CompletionStatusId],
[GroupId],
[DataSourceId]) 
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogFunctionalLocationList]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogFunctionalLocationList')
	BEGIN
		DROP  table  [dbo].[LogFunctionalLocationList]
	END
GO
CREATE TABLE [dbo].[LogFunctionalLocationList](
	[LogId] [bigint] NOT NULL,
	[FunctionalLocationList] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LogFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[LogFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[LogFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[LogFunctionalLocation](
	[LogId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogFunctionalLocation] ON [dbo].[LogFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogWorkPermitLubesAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogWorkPermitLubesAssociation')
	BEGIN
		DROP  table  [dbo].[LogWorkPermitLubesAssociation]
	END
GO
CREATE TABLE [dbo].[LogWorkPermitLubesAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitLubesId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitLubesAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LogTargetAlertAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogTargetAlertAssociation')
	BEGIN
		DROP  table  [dbo].[LogTargetAlertAssociation]
	END
GO
CREATE TABLE [dbo].[LogTargetAlertAssociation](
	[LogId] [bigint] NOT NULL,
	[TargetAlertId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogTargetAlertAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LogRead]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogRead')
	BEGIN
		DROP  table  [dbo].[LogRead]
	END
GO
CREATE TABLE [dbo].[LogRead](
	[LogId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogRead] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogRead_UserId] ON [dbo].[LogRead] 
(
	[UserId] ASC,
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogHistory')
	BEGIN
		DROP  table  [dbo].[LogHistory]
	END
GO
CREATE TABLE [dbo].[LogHistory](
	[Id] [bigint] NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](1000) NULL,
	[RecommendForShiftSummary] [bit] NOT NULL,
	[LogHistoryId] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ActualLoggedDateTime] [datetime] NULL,
	[FunctionalLocations] [varchar](max) NULL,
	[IsOperatingEngineerLog] [bit] NOT NULL,
	[PlainTextComments] [varchar](max) NULL,
 CONSTRAINT [PK_LogHistory] PRIMARY KEY CLUSTERED 
(
	[LogHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_LogHistory] ON [dbo].[LogHistory] 
(
	[Id] ASC,
	[LogHistoryId] ASC,
	[LastModifiedDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogDefinitionCustomFieldEntryHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogDefinitionCustomFieldEntryHistory')
	BEGIN
		DROP  table  [dbo].[LogDefinitionCustomFieldEntryHistory]
	END
GO
CREATE TABLE [dbo].[LogDefinitionCustomFieldEntryHistory](
	[LogDefinitionHistoryId] [bigint] NOT NULL,
	[CustomFields] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LogDefinitionCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[LogDefinitionHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[LogCustomFieldEntry]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogCustomFieldEntry')
	BEGIN
		DROP  table  [dbo].[LogCustomFieldEntry]
	END
GO
CREATE TABLE [dbo].[LogCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[LogId] [bigint] NOT NULL,
	[CustomFieldName] [varchar](40) NOT NULL,
	[FieldEntry] [varchar](100) NULL,
	[DisplayOrder] [int] NOT NULL,
	[TypeId] [tinyint] NOT NULL,
	[NumericFieldEntry] [decimal](18, 6) NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_LogCustomFieldEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_CustomFieldId] ON [dbo].[LogCustomFieldEntry] 
(
	[LogId] ASC,
	[CustomFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_Log] ON [dbo].[LogCustomFieldEntry] 
(
	[LogId] ASC,
	[Id] ASC
)
INCLUDE ( [CustomFieldName],
[NumericFieldEntry]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LogActionItemDefinitionAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogActionItemDefinitionAssociation')
	BEGIN
		DROP  table  [dbo].[LogActionItemDefinitionAssociation]
	END
GO
CREATE TABLE [dbo].[LogActionItemDefinitionAssociation](
	[LogId] [bigint] NOT NULL,
	[ActionItemDefinitionId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogActionItemDefinitionAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[LabAlertResponse]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LabAlertResponse')
	BEGIN
		DROP  table  [dbo].[LabAlertResponse]
	END
GO
CREATE TABLE [dbo].[LabAlertResponse](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[LabAlertId] [bigint] NOT NULL,
	[LabAlertStatusId] [bigint] NOT NULL,
	[Comments] [varchar](max) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_LabAlertResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[LogCustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogCustomFieldGroup')
	BEGIN
		DROP  table  [dbo].[LogCustomFieldGroup]
	END
GO
CREATE TABLE [dbo].[LogCustomFieldGroup](
	[LogId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC,
	[CustomFieldGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[ActionItemDefinitionTargetDefinition]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinitionTargetDefinition')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinitionTargetDefinition]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinitionTargetDefinition](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[TargetDefinitionId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemDefTargetDef] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[TargetDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefTargetDef_TargetDefId] ON [dbo].[ActionItemDefinitionTargetDefinition] 
(
	[TargetDefinitionId] ASC,
	[ActionItemDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[ActionItemDefinitionHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinitionHistory')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinitionHistory]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[BusinessCategoryId] [bigint] NULL,
	[ActionItemDefinitionStatusId] [bigint] NOT NULL,
	[RequiresApproval] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[ResponseRequired] [bit] NOT NULL,
	[Description] [text] NULL,
	[SourceId] [int] NOT NULL,
	[SapOperationId] [bigint] NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[OperationalModeId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NULL,
	[DocumentLinks] [varchar](2000) NULL,
	[TargetDefinitions] [varchar](200) NULL,
	[Schedule] [varchar](300) NULL,
	[PriorityId] [bigint] NOT NULL,
	[WorkAssignmentName] [varchar](40) NULL,
	[CreateAnActionItemForEachFunctionalLocation] [bit] NOT NULL,
	[GN75BId] [bigint] SPARSE  NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IDX_ActionItemDefinitionHistory_Id] ON [dbo].[ActionItemDefinitionHistory] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ActionItemDefinitionFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinitionFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinitionFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinitionFunctionalLocation](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemDefinitionFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefinitionFunctionalLocation] ON [dbo].[ActionItemDefinitionFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[ActionItemDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ActionItemDefinitionComment]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemDefinitionComment')
	BEGIN
		DROP  table  [dbo].[ActionItemDefinitionComment]
	END
GO
CREATE TABLE [dbo].[ActionItemDefinitionComment](
	[ActionItemDefinitionId] [bigint] NOT NULL,
	[CommentId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemDefinitionComment] PRIMARY KEY CLUSTERED 
(
	[ActionItemDefinitionId] ASC,
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefinitionComment_CommentId] ON [dbo].[ActionItemDefinitionComment] 
(
	[CommentId] ASC,
	[ActionItemDefinitionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CokerCardCycleStepEntry]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardCycleStepEntry')
	BEGIN
		DROP  table  [dbo].[CokerCardCycleStepEntry]
	END
GO
CREATE TABLE [dbo].[CokerCardCycleStepEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardId] [bigint] NOT NULL,
	[CokerCardConfigurationDrumId] [bigint] NOT NULL,
	[CokerCardConfigurationCycleStepId] [bigint] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[StartEntryShiftId] [bigint] NOT NULL,
	[StartEntryShiftStartDate] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[EndEntryShiftId] [bigint] NULL,
	[EndEntryShiftStartDate] [datetime] NULL,
 CONSTRAINT [PK_CokerCardCycleStepEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCardCycleStepEntry_CokerCardId] ON [dbo].[CokerCardCycleStepEntry] 
(
	[CokerCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[CokerCardDrumEntry]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardDrumEntry')
	BEGIN
		DROP  table  [dbo].[CokerCardDrumEntry]
	END
GO
CREATE TABLE [dbo].[CokerCardDrumEntry](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardId] [bigint] NOT NULL,
	[CokerCardConfigurationDrumId] [bigint] NOT NULL,
	[CokerCardConfigurationLastCycleStepId] [bigint] NULL,
	[HoursIntoLastCycle] [decimal](4, 2) NULL,
	[Comments] [varchar](200) NULL,
 CONSTRAINT [PK_CokerCardDrumEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_CokerCardDrumEntry] UNIQUE NONCLUSTERED 
(
	[CokerCardId] ASC,
	[CokerCardConfigurationDrumId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[CokerCardHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardHistory')
	BEGIN
		DROP  table  [dbo].[CokerCardHistory]
	END
GO
CREATE TABLE [dbo].[CokerCardHistory](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CokerCardHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCardHistory_CokerCardId] ON [dbo].[CokerCardHistory] 
(
	[CokerCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ActionItem]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItem')
	BEGIN
		DROP  table  [dbo].[ActionItem]
	END
GO
CREATE TABLE [dbo].[ActionItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ResponseRequired] [bit] NOT NULL,
	[ActionItemStatusId] [bigint] NOT NULL,
	[BusinessCategoryId] [bigint] NULL,
	[Description] [varchar](max) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[ShiftAdjustedEndDateTime] [datetime] NULL,
	[SourceId] [int] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[createdByScheduleTypeId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Name] [varchar](50) NULL,
	[PreviousActionItemStatusId] [bigint] NULL,
	[StatusModifiedUserId] [bigint] NULL,
	[StatusModifiedDateTime] [datetime] NULL,
	[CreatedByActionItemDefinitionId] [bigint] NULL,
	[PriorityId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[FormGN75BId] [bigint] SPARSE  NULL,
 CONSTRAINT [PK_ActionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItem_ActionItemByAssignmentPage] ON [dbo].[ActionItem] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[WorkAssignmentId] ASC
)
WHERE ([DELETED]=(0) AND [WorkAssignmentId] IS NOT NULL AND [ActionItemStatusId]<(4))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItem_ActionItemDefinition] ON [dbo].[ActionItem] 
(
	[CreatedByActionItemDefinitionId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItem_ActionItemPage] ON [dbo].[ActionItem] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[WorkAssignmentId] ASC
)
WHERE ([DELETED]=(0) AND [ActionItemStatusId]<(4))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ActionItem_Priority_Page] ON [dbo].[ActionItem] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[WorkAssignmentId] ASC
)
WHERE ([DELETED]=(0) AND [ActionItemStatusId]<(4))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[ActionItemFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ActionItemFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[ActionItemFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[ActionItemFunctionalLocation](
	[ActionItemId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ActionItemFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[ActionItemId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemFunctionalLocation_Floc] ON [dbo].[ActionItemFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[ActionItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[CokerCardDrumEntryHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardDrumEntryHistory')
	BEGIN
		DROP  table  [dbo].[CokerCardDrumEntryHistory]
	END
GO
CREATE TABLE [dbo].[CokerCardDrumEntryHistory](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardHistoryId] [bigint] NOT NULL,
	[DrumConfigurationId] [bigint] NOT NULL,
	[DrumName] [varchar](40) NOT NULL,
	[Comments] [varchar](200) NULL,
	[CokerCardConfigurationLastCycleStep] [varchar](20) NULL,
	[HoursIntoLastCycle] [decimal](4, 2) NULL,
 CONSTRAINT [PK_dbo_CokerCardDrumEntryHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCardDrumEntryHistory_CokerCardHistory] ON [dbo].[CokerCardDrumEntryHistory] 
(
	[CokerCardHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogCustomFieldEntryHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogCustomFieldEntryHistory')
	BEGIN
		DROP  table  [dbo].[LogCustomFieldEntryHistory]
	END
GO
CREATE TABLE [dbo].[LogCustomFieldEntryHistory](
	[LogHistoryId] [bigint] NOT NULL,
	[CustomFields] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LogCustomFieldEntryHistoryFlattened] PRIMARY KEY CLUSTERED 
(
	[LogHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO





/****** Object:  Table [dbo].[LogActionItemAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogActionItemAssociation')
	BEGIN
		DROP  table  [dbo].[LogActionItemAssociation]
	END
GO
CREATE TABLE [dbo].[LogActionItemAssociation](
	[LogId] [bigint] NOT NULL,
	[ActionItemId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogActionItemAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_LogActionItemAssociation_ActionItem] ON [dbo].[LogActionItemAssociation] 
(
	[ActionItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireFunctionalLocationList')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[FunctionalLocationList] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO






/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireFunctionalLocation')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation] ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[ShiftHandoverQuestionnaireId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireCokerCardConfiguration')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[CokerCardConfigurationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireCokerCardConfiguration] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[CokerCardConfigurationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireSummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireSummaryLog')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireSummaryLog]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[SummaryLogId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireSummaryLog] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[SummaryLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireRead]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireRead')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireRead]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireRead](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireRead] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireRead_UserId] ON [dbo].[ShiftHandoverQuestionnaireRead] 
(
	[UserId] ASC,
	[ShiftHandoverQuestionnaireId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverQuestionnaireLog]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverQuestionnaireLog')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverQuestionnaireLog]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverQuestionnaireLog](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[LogId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireLog] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 95) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[ShiftHandoverAnswer]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ShiftHandoverAnswer')
	BEGIN
		DROP  table  [dbo].[ShiftHandoverAnswer]
	END
GO
CREATE TABLE [dbo].[ShiftHandoverAnswer](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[Answer] [bit] NOT NULL,
	[Comments] [varchar](2048) NULL,
	[QuestionDisplayOrder] [int] NOT NULL,
	[ShiftHandoverQuestionId] [bigint] NOT NULL,
 CONSTRAINT [PK_ShiftHandoverAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverAnswer] ON [dbo].[ShiftHandoverAnswer] 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverAnswer_QuestionId] ON [dbo].[ShiftHandoverAnswer] 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[ShiftHandoverQuestionId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[PermitRequestEdmontonWorkOrderSource]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PermitRequestEdmontonWorkOrderSource')
	BEGIN
		DROP  table  [dbo].[PermitRequestEdmontonWorkOrderSource]
	END
GO
CREATE TABLE [dbo].[PermitRequestEdmontonWorkOrderSource](
	[PermitRequestEdmontonId] [bigint] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmontonSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestEdmontonWorkOrderSource] 
(
	[OperationNumber] ASC,
	[SubOperationNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[WorkPermitEdmonton]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitEdmonton')
	BEGIN
		DROP  table  [dbo].[WorkPermitEdmonton]
	END
GO
CREATE TABLE [dbo].[WorkPermitEdmonton](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PermitRequestId] [bigint] NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](50) NULL,
	[RequestedStartDateTime] [datetime] NOT NULL,
	[IssuedDateTime] [datetime] NULL,
	[ExpiredDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[HazardsAndOrRequirements] [varchar](2000) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[GroupId] [bigint] NULL,
	[DurationPermit] [bit] NOT NULL,
	[IssuedByUserId] [bigint] NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[PermitRequestCreatedByUserId] [bigint] NULL,
	[UsePreviousPermitAnswered] [bit] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[AreaLabelId] [bigint] NULL,
 CONSTRAINT [PK_WorkPermitEdmonton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmonton_DTO_Covering] ON [dbo].[WorkPermitEdmonton] 
(
	[RequestedStartDateTime] ASC,
	[ExpiredDateTime] ASC,
	[FunctionalLocationId] ASC
)
WHERE ([DELETED]=(0))
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmonton_PermitRequestId] ON [dbo].[WorkPermitEdmonton] 
(
	[PermitRequestId] ASC,
	[WorkPermitStatusId] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[WorkPermitEdmontonDetails]    Script Date: 08/24/2014 11:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WorkPermitEdmontonDetails')
	BEGIN
		DROP  table  [dbo].[WorkPermitEdmontonDetails]
	END
GO
CREATE TABLE [dbo].[WorkPermitEdmontonDetails](
	[WorkPermitEdmontonId] [bigint] NOT NULL,
	[SpecialWorkFormNumber] [varchar](10) NULL,
	[SpecialWorkType] [int] NULL,
	[VehicleEntryType] [varchar](30) NULL,
	[RescuePlanFormNumber] [varchar](10) NULL,
	[StatusOfPipingEquipmentSectionNotApplicableToJob] [bit] NOT NULL,
	[ProductNormallyInPipingEquipment] [varchar](50) NULL,
	[IsolationValvesLocked] [bit] NULL,
	[DepressuredDrained] [bit] NULL,
	[Ventilated] [bit] NULL,
	[Purged] [bit] NULL,
	[BlindedAndTagged] [bit] NULL,
	[DoubleBlockAndBleed] [bit] NULL,
	[ElectricalLockout] [bit] NULL,
	[MechanicalLockout] [bit] NULL,
	[BlindSchematicAvailable] [bit] NULL,
	[ZeroEnergyFormNumber] [varchar](10) NULL,
	[LockBoxNumber] [varchar](10) NULL,
	[JobsiteEquipmentInspected] [bit] NOT NULL,
	[ConfinedSpaceWorkSectionNotApplicableToJob] [bit] NOT NULL,
	[QuestionOneResponse] [bit] NULL,
	[QuestionTwoResponse] [bit] NULL,
	[QuestionTwoAResponse] [bit] NULL,
	[QuestionTwoBResponse] [bit] NULL,
	[QuestionThreeResponse] [bit] NULL,
	[QuestionFourResponse] [bit] NULL,
	[GasTestsSectionNotApplicableToJob] [bit] NOT NULL,
	[OperatorGasDetectorNumber] [varchar](30) NULL,
	[GasTestDataLine1CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine1Oxygen] [varchar](10) NULL,
	[GasTestDataLine1ToxicGas] [varchar](20) NULL,
	[GasTestDataLine1Time] [datetime] NULL,
	[GasTestDataLine2CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine2Oxygen] [varchar](10) NULL,
	[GasTestDataLine2ToxicGas] [varchar](20) NULL,
	[GasTestDataLine2Time] [datetime] NULL,
	[GasTestDataLine3CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine3Oxygen] [varchar](10) NULL,
	[GasTestDataLine3ToxicGas] [varchar](20) NULL,
	[GasTestDataLine3Time] [datetime] NULL,
	[GasTestDataLine4CombustibleGas] [varchar](10) NULL,
	[GasTestDataLine4Oxygen] [varchar](10) NULL,
	[GasTestDataLine4ToxicGas] [varchar](20) NULL,
	[GasTestDataLine4Time] [datetime] NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [varchar](15) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [varchar](15) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [varchar](15) NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](10) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[VehicleEntryTotal] [int] NULL,
	[GN6_Deprecated] [int] NOT NULL,
	[GN11] [int] NOT NULL,
	[GN24_Deprecated] [int] NOT NULL,
	[GN27] [int] NOT NULL,
	[GN75_Deprecated] [int] NOT NULL,
	[WorkersMonitorNumber] [varchar](10) NULL,
	[RadioChannelNumber] [varchar](10) NULL,
	[VehicleEntry] [bit] NOT NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
	[FormGN59Id] [bigint] NULL,
	[FormGN7Id] [bigint] NULL,
	[WorkerToProvideGasTestData] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other4Checked] [bit] NOT NULL,
	[UseCurrentPermitNumberForZeroEnergyFormNumber] [bit] NOT NULL,
	[PermitAcceptor] [varchar](30) NULL,
	[ShiftSupervisor] [varchar](30) NULL,
	[GN24] [bit] NOT NULL,
	[FormGN24Id] [bigint] NULL,
	[GN6] [bit] NOT NULL,
	[FormGN6Id] [bigint] NULL,
	[FormGN75AId] [bigint] NULL,
	[GN75A] [bit] NOT NULL,
	[FormGN1Id] [bigint] NULL,
	[GN1] [bit] NOT NULL,
	[FormGN1TradeChecklistId] [bigint] NULL,
	[FormGN1TradeChecklistDisplayNumber] [varchar](32) NULL,
 CONSTRAINT [PK_WorkPermitEdmontonDetails] PRIMARY KEY CLUSTERED 
(
	[WorkPermitEdmontonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmontonDetails_FormGN24] ON [dbo].[WorkPermitEdmontonDetails] 
(
	[FormGN24Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmontonDetails_FormGN59] ON [dbo].[WorkPermitEdmontonDetails] 
(
	[FormGN59Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmontonDetails_FormGN6] ON [dbo].[WorkPermitEdmontonDetails] 
(
	[FormGN6Id] ASC
)
WHERE ([FormGN6Id] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmontonDetails_FormGN7] ON [dbo].[WorkPermitEdmontonDetails] 
(
	[FormGN7Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[LogWorkPermitEdmontonAssociation]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'LogWorkPermitEdmontonAssociation')
	BEGIN
		DROP  table  [dbo].[LogWorkPermitEdmontonAssociation]
	END
GO
CREATE TABLE [dbo].[LogWorkPermitEdmontonAssociation](
	[LogId] [bigint] NOT NULL,
	[WorkPermitEdmontonId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogWorkPermitEdmontonAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[DocumentLink]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DocumentLink')
	BEGIN
		DROP  table  [dbo].[DocumentLink]
	END
GO
CREATE TABLE [dbo].[DocumentLink](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Title] [varchar](50) NULL,
	[Link] [varchar](max) NULL,
	[TargetDefinitionId] [bigint] SPARSE  NULL,
	[ActionItemId] [bigint] SPARSE  NULL,
	[ActionItemDefinitionId] [bigint] SPARSE  NULL,
	[WorkPermitId] [bigint] SPARSE  NULL,
	[LogId] [bigint] SPARSE  NULL,
	[LogDefinitionId] [bigint] SPARSE  NULL,
	[Deleted] [bit] NOT NULL,
	[TargetAlertId] [bigint] SPARSE  NULL,
	[SummaryLogId] [bigint] SPARSE  NULL,
	[WorkPermitEdmontonId] [bigint] SPARSE  NULL,
	[PermitRequestEdmontonId] [bigint] SPARSE  NULL,
	[WorkPermitMontrealId] [bigint] SPARSE  NULL,
	[PermitRequestMontrealId] [bigint] SPARSE  NULL,
	[WorkPermitLubesId] [bigint] SPARSE  NULL,
	[PermitRequestLubesId] [bigint] SPARSE  NULL,
	[FormGN24Id] [bigint] SPARSE  NULL,
	[FormGN6Id] [bigint] SPARSE  NULL,
	[FormGN75AId] [bigint] SPARSE  NULL,
	[FormGN75BId] [bigint] SPARSE  NULL,
	[DirectiveId] [bigint] NULL,
	[FormGN1Id] [bigint] NULL,
	[OvertimeFormId] [bigint] SPARSE  NULL,
	[FormGN7Id] [bigint] SPARSE  NULL,
	[FormOP14Id] [bigint] SPARSE  NULL,
	[FormGN59Id] [bigint] SPARSE  NULL,
 CONSTRAINT [PK_DocumentLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_ActionItem] ON [dbo].[DocumentLink] 
(
	[ActionItemId] ASC
)
WHERE ([Deleted]=(0) AND [ActionItemId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_ActionItemDefinition] ON [dbo].[DocumentLink] 
(
	[ActionItemDefinitionId] ASC
)
WHERE ([Deleted]=(0) AND [ActionItemDefinitionId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN24] ON [dbo].[DocumentLink] 
(
	[FormGN24Id] ASC
)
WHERE ([Deleted]=(0) AND [FormGN24Id] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN6] ON [dbo].[DocumentLink] 
(
	[FormGN6Id] ASC
)
WHERE ([Deleted]=(0) AND [FormGN6Id] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN75A] ON [dbo].[DocumentLink] 
(
	[FormGN75AId] ASC
)
WHERE ([Deleted]=(0) AND [FormGN75AId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_FormGN75B] ON [dbo].[DocumentLink] 
(
	[FormGN75BId] ASC
)
WHERE ([Deleted]=(0) AND [FormGN75BId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_Log] ON [dbo].[DocumentLink] 
(
	[LogId] ASC
)
WHERE ([Deleted]=(0) AND [LogId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_LogDefinition] ON [dbo].[DocumentLink] 
(
	[LogDefinitionId] ASC
)
WHERE ([Deleted]=(0) AND [LogDefinitionId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestEdmonton] ON [dbo].[DocumentLink] 
(
	[PermitRequestEdmontonId] ASC
)
WHERE ([Deleted]=(0) AND [PermitRequestEdmontonId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestLubes] ON [dbo].[DocumentLink] 
(
	[PermitRequestLubesId] ASC
)
WHERE ([Deleted]=(0) AND [PermitRequestLubesId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_PermitRequestMontreal] ON [dbo].[DocumentLink] 
(
	[PermitRequestMontrealId] ASC
)
WHERE ([Deleted]=(0) AND [PermitRequestMontrealId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_SummaryLog] ON [dbo].[DocumentLink] 
(
	[SummaryLogId] ASC
)
WHERE ([Deleted]=(0) AND [SummaryLogId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_DocumentLink_TargetDefinitionId] ON [dbo].[DocumentLink] 
(
	[TargetDefinitionId] ASC
)
WHERE ([Deleted]=(0) AND [TargetDefinitionId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermit] ON [dbo].[DocumentLink] 
(
	[WorkPermitId] ASC
)
WHERE ([Deleted]=(0) AND [WorkPermitId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitEdmonton] ON [dbo].[DocumentLink] 
(
	[WorkPermitEdmontonId] ASC
)
WHERE ([Deleted]=(0) AND [WorkPermitEdmontonId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitLubes] ON [dbo].[DocumentLink] 
(
	[WorkPermitLubesId] ASC
)
WHERE ([Deleted]=(0) AND [WorkPermitLubesId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_DocumentLink_WorkPermitMontreal] ON [dbo].[DocumentLink] 
(
	[WorkPermitMontrealId] ASC
)
WHERE ([Deleted]=(0) AND [WorkPermitMontrealId] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[CokerCardCycleStepEntryHistory]    Script Date: 08/24/2014 11:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CokerCardCycleStepEntryHistory')
	BEGIN
		DROP  table  [dbo].[CokerCardCycleStepEntryHistory]
	END
GO
CREATE TABLE [dbo].[CokerCardCycleStepEntryHistory](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[CokerCardDrumEntryHistoryId] [bigint] NOT NULL,
	[CycleStepConfigurationId] [bigint] NOT NULL,
	[CycleStepName] [varchar](40) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
 CONSTRAINT [PK_dbo_CokerCardCycleStepEntryHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX_CokerCardCycleStepEntryHistory_DrumHistory] ON [dbo].[CokerCardCycleStepEntryHistory] 
(
	[CokerCardDrumEntryHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
/****** Object:  Default [DF_ActionItem_ResponseReq_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem] ADD  DEFAULT (0) FOR [ResponseRequired]
GO
/****** Object:  Default [DF_ActionItem_Source_As_Zero]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_ActionItem_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_ActionItemDef_ReqApproval_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [RequiresApproval]
GO
/****** Object:  Default [DF_ActionItemDef_Active_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [Active]
GO
/****** Object:  Default [DF_ActionItemDef_ResponseReq_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [ResponseRequired]
GO
/****** Object:  Default [DF_ActionItemDef_Source_As_Zero]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_ActionItemDef_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_ActionItemDef_Deleted_As_Zero]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (0) FOR [OperationalModeId]
GO
/****** Object:  Default [DF_ActionItemDef_Priority_As_One]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition] ADD  DEFAULT (1) FOR [PriorityId]
GO
/****** Object:  Default [DF_ActionItemDefHistory_ReqApproval_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  DEFAULT (0) FOR [RequiresApproval]
GO
/****** Object:  Default [DF_ActionItemDefHistory_Active_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  DEFAULT (0) FOR [Active]
GO
/****** Object:  Default [DF_ActionItemDefHistory_ResponseReq_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  DEFAULT (0) FOR [ResponseRequired]
GO
/****** Object:  Default [DF_ActionItemDefHistory_Source_As_Zero]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_ActionItemDefHistory_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_ActionItemDefHistory_Priority_As_One]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD  CONSTRAINT [DF_ActionItemDefHistory_Priority_As_One]  DEFAULT (1) FOR [PriorityId]
GO
/****** Object:  Default [DF__AreaLabel__Delet__56A5F4F7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[AreaLabel] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_CraftOrTrade_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CraftOrTrade] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__Deviation__IsOnl__16CCFDB2]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlert] ADD  DEFAULT ((0)) FOR [IsOnlyVisibleOnReports]
GO
/****** Object:  Default [DF_LiveLinkDocumentLink_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__DocumentR__Delet__07DBC72A]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentRootPathConfiguration] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN1__Deleted__069695E9]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN24__Delete__347C90D3]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN59__Delete__1285097D]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN6__Deleted__478F6547]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN7__Deleted__7E7E10D0]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN75A__Delet__5C8A822D]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75A] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN75B__Delet__670810A0]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75B] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormGN75B__Delet__6DB50E2F]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75BIsolationItem] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormOilsa__Delet__7851CCDC]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__FormOP14__Delete__2E2D23F2]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_FunctionalLocation_OutOfService_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocation] ADD  DEFAULT (0) FOR [OutOfService]
GO
/****** Object:  Default [DF_FunctionalLocation_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocation] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__GasTestEl__Globa__7BC631F6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfo] ADD  DEFAULT (0) FOR [Standard]
GO
/****** Object:  Default [DF_GasTestElementInfo_Deleted]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfo] ADD  CONSTRAINT [DF_GasTestElementInfo_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__LabAlertD__IsAct__7F268598]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinitionHistory] ADD  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_Log_SourceId_As_Zero]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_Log_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_LogDefinition_Deleted_As_False]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__Restricti__IsAct__09F78318]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition] ADD  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF__Restricti__Delet__0AEBA751]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF__Restricti__IsOnl__14E4B540]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition] ADD  DEFAULT ((0)) FOR [IsOnlyVisibleOnReports]
GO
/****** Object:  Default [DF__Restricti__IsAct__1198A4E0]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinitionHistory] ADD  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF__Restricti__IsOnl__15D8D979]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinitionHistory] ADD  DEFAULT ((0)) FOR [IsOnlyVisibleOnReports]
GO
/****** Object:  Default [DF__Role__deleted__238D37E9]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Role] ADD  DEFAULT ((0)) FOR [deleted]
GO
/****** Object:  Default [DF_SAPNotification_Process_As_Zero]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SAPNotification] ADD  DEFAULT (0) FOR [Processed]
GO
/****** Object:  Default [DF_Schedule_Deleted_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Schedule] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_SiteConfigurationSchedule_WorkPermitOptionAutoSelect_As_True]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration] ADD  DEFAULT (1) FOR [WorkPermitOptionAutoSelected]
GO
/****** Object:  Default [DF__SiteConfi__DaysT__2EB59D29]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration] ADD  DEFAULT ((30)) FOR [DaysToDisplayWorkPermitsBackwards]
GO
/****** Object:  Default [DF__SiteConfi__ShowA__026DD1EE]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration] ADD  DEFAULT ((1)) FOR [ShowActionItemsOnShiftHandover]
GO
/****** Object:  Default [DF__SiteConfi__Displ__35194D4C]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration] ADD  DEFAULT ((1)) FOR [DisplayActionItemCommentOnly]
GO
/****** Object:  Default [DF__SiteConfi__Remem__2F9976D3]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration] ADD  DEFAULT ((0)) FOR [RememberActionItemWorkAssignment]
GO
/****** Object:  Default [DF__SummaryLo__Delet__48BEBC98]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_Tag_Deleted_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Tag] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_TargetAlert_ReqResponse_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert] ADD  DEFAULT (0) FOR [RequiresResponse]
GO
/****** Object:  Default [DF_TargetDef_Deleted_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_TargetDef_GenerateActionItem_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (0) FOR [GenerateActionItem]
GO
/****** Object:  Default [DF_TargetDef_ReqApproval_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (0) FOR [RequiresApproval]
GO
/****** Object:  Default [DF_TargetDef_ReqResponse_As_True]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (1) FOR [RequiresResponseWhenAlerted]
GO
/****** Object:  Default [DF_TargetDef_IsActive_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (0) FOR [IsActive]
GO
/****** Object:  Default [DF_TargetDef_OperationalMode_As_Zero]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (0) FOR [OperationalModeId]
GO
/****** Object:  Default [DF_TargetDef_PriorityId_As_One]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition] ADD  DEFAULT (1) FOR [PriorityId]
GO
/****** Object:  Default [DF_TargetDefHistory_PriorityId_As_One]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionHistory] ADD  CONSTRAINT [DF_TargetDefHistory_PriorityId_As_One]  DEFAULT (1) FOR [PriorityId]
GO
/****** Object:  Default [DF_TargetDefRWTagConfig_Deleted_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__TradeChec__Delet__1A9D8E96]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_User_Deleted_As_False]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[User] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF__WorkAssig__Delet__1DD45E93]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignment] ADD  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_WorkPermit_PermitConfinedSpaceEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitConfinedSpaceEntry]
GO
/****** Object:  Default [DF_WorkPermit_PermitBreathingAirOrSCBA]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitBreathingAirOrSCBA]
GO
/****** Object:  Default [DF_WorkPermit_PermitElectricalSwitching]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitElectricalSwitching]
GO
/****** Object:  Default [DF_WorkPermit_PermitVehicleEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitVehicleEntry]
GO
/****** Object:  Default [DF_WorkPermit_PermitHotTap]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitHotTap]
GO
/****** Object:  Default [DF_WorkPermit_PermitBurnOrOpenFlame]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitBurnOrOpenFlame]
GO
/****** Object:  Default [DF_WorkPermit_PermitSystemEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitSystemEntry]
GO
/****** Object:  Default [DF_WorkPermit_PermitCriticalLift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitCriticalLift]
GO
/****** Object:  Default [DF_WorkPermit_PermitEnergizedElectrical]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitEnergizedElectrical]
GO
/****** Object:  Default [DF_WorkPermit_PermitExcavation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitExcavation]
GO
/****** Object:  Default [DF_WorkPermit_PermitAsbestos]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitAsbestos]
GO
/****** Object:  Default [DF_WorkPermit_PermitRadiationRadiography]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitRadiationRadiography]
GO
/****** Object:  Default [DF_WorkPermit_PermitRadiationSealed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitRadiationSealed]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalCSEAssessmentOrAuthorization]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalCSEAssessmentOrAuthorization]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalFlareEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalFlareEntry]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalCriticalLift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalCriticalLift]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalExcavation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalExcavation]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalHotTap]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalHotTap]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalSpecialWasteDisposal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalSpecialWasteDisposal]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalBlankOrBlindLists]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalBlankOrBlindLists]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalPJSROrSafetyPause]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalPJSROrSafetyPause]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalAsbestosHandling]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalAsbestosHandling]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalRoadClosure]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalRoadClosure]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalElectrical]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalElectrical]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalBurnOrOpenFlameAssessment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalBurnOrOpenFlameAssessment]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalWaiverOrDeviation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalWaiverOrDeviation]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalMSDS]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [AdditionalMSDS]
GO
/****** Object:  Default [DF_WorkPermit_CommunicationByRadio]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (1) FOR [CommunicationByRadio]
GO
/****** Object:  Default [DF_WorkPermit_IsWorkPermitCommunicationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [IsWorkPermitCommunicationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_CoAuthorizationRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [CoAuthorizationRequired]
GO
/****** Object:  Default [DF_WorkPermit_ToolsAirTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsAirTools]
GO
/****** Object:  Default [DF_WorkPermit_ToolsCraneOrCarrydeck]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsCraneOrCarrydeck]
GO
/****** Object:  Default [DF_WorkPermit_ToolsHandTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsHandTools]
GO
/****** Object:  Default [DF_WorkPermit_ToolsJackhammer]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsJackhammer]
GO
/****** Object:  Default [DF_WorkPermit_ToolsVacuumTruck]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsVacuumTruck]
GO
/****** Object:  Default [DF_WorkPermit_ToolsCementSaw]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsCementSaw]
GO
/****** Object:  Default [DF_WorkPermit_ToolsElectricTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsElectricTools]
GO
/****** Object:  Default [DF_WorkPermit_ToolsHeavyEquipment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsHeavyEquipment]
GO
/****** Object:  Default [DF_WorkPermit_ToolsLanda]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsLanda]
GO
/****** Object:  Default [DF_WorkPermit_ToolsScaffolding]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsScaffolding]
GO
/****** Object:  Default [DF_WorkPermit_ToolsVehicle]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsVehicle]
GO
/****** Object:  Default [DF_WorkPermit_ToolsCompressor]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsCompressor]
GO
/****** Object:  Default [DF_WorkPermit_ToolsForklift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsForklift]
GO
/****** Object:  Default [DF_WorkPermit_ToolsHEPAVacuum]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsHEPAVacuum]
GO
/****** Object:  Default [DF_WorkPermit_ToolsManlift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsManlift]
GO
/****** Object:  Default [DF_WorkPermit_ToolsTamper]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsTamper]
GO
/****** Object:  Default [DF_WorkPermit_ToolsHotTapMachine]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsHotTapMachine]
GO
/****** Object:  Default [DF_WorkPermit_ToolsPortLighting]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsPortLighting]
GO
/****** Object:  Default [DF_WorkPermit_ToolsTorch]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsTorch]
GO
/****** Object:  Default [DF_WorkPermit_ToolsWelder]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ToolsWelder]
GO
/****** Object:  Default [DF_WorkPermit_ElectricIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ElectricIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_ElectricIsolationMethodLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ElectricIsolationMethodLOTO]
GO
/****** Object:  Default [DF_WorkPermit_ElectricIsolationMethodWiring]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ElectricIsolationMethodWiring]
GO
/****** Object:  Default [DF_WorkPermit_ElectricTestBumpNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ElectricTestBumpNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_ElectricTestBump]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [ElectricTestBump]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentStillContainsResidualNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentStillContainsResidualNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentStillContainsResidual]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentStillContainsResidual]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentLeakingValvesNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentLeakingValvesNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentLeakingValves]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentLeakingValves]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsOutOfService]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsOutOfService]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionDepressured]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionDepressured]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionDrained]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionDrained]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionCleaned]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionCleaned]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionVentilated]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionVentilated]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionH20Washed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionH20Washed]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionNeutralized]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionNeutralized]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionPurged]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentConditionPurged]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentPreviousContentsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentPreviousContentsHydrocarbon]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsHydrocarbon]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentPreviousContentsAcid]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsAcid]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentPreviousContentsCaustic]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsCaustic]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentPreviousContentsH2S]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsH2S]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodBlindedorBlanked]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodBlindedorBlanked]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodBlockedIn]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodBlockedIn]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodSeparation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodSeparation]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodMudderPlugs]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodMudderPlugs]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodLOTO]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationFlowRequiredForJob]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationFlowRequiredForJob]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationFlowRequiredForJobNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationFlowRequiredForJobNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationBondingOrGroundingRequiredNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationBondingOrGroundingRequiredNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationBondingOrGroundingRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationBondingOrGroundingRequired]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationWeldingGroundWireInTestAreaNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationWeldingGroundWireInTestArea]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationWeldingGroundWireInTestArea]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationCriticalConditionRemainJobSiteNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationCriticalConditionRemainJobSite]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationCriticalConditionRemainJobSite]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSurroundingConditionsAffectOrContaminated]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminated]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationVestedBuddySystemInEffectNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationVestedBuddySystemInEffectNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationVestedBuddySystemInEffect]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationVestedBuddySystemInEffect]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationPermitReceiverFieldOrEquipmentOrientation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSewerIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSewerIsolationMethodSealedOrCovered]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodSealedOrCovered]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSewerIsolationMethodPlugged]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodPlugged]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationSewerIsolationMethodBlindedOrBlanked]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodBlindedOrBlanked]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentVentilationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentVentilationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentVentilationMethodNaturalDraft]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentVentilationMethodNaturalDraft]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentVentilationMethodLocalExhaust]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentVentilationMethodLocalExhaust]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentVentilationMethodForced]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [EquipmentVentilationMethodForced]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationAreaPreparationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationAreaPreparationBarricade]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationBarricade]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationAreaPreparationNonEssentialEvac]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationNonEssentialEvac]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationAreaPreparationPreopBoundaryRopeTape]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationPreopBoundaryRopeTape]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationLightingElectricalRequirementNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationLightingElectricalRequirementLowVoltage12V]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementLowVoltage12V]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationLightingElectricalRequirement110VWithGFCI]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirement110VWithGFCI]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationLightingElectricalRequirementGeneratorLights]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementGeneratorLights]
GO
/****** Object:  Default [DF_WorkPermit_RadiationSealedSourceIsolationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_RadiationSealedSourceIsolationLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationLOTO]
GO
/****** Object:  Default [DF_WorkPermit_RadiationSealedSourceIsolationOpen]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationOpen]
GO
/****** Object:  Default [DF_WorkPermit_GasTestConstantMonitoringRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [GasTestConstantMonitoringRequired]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpace20ABCorDryChemicalExtinguisher]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpace20ABCorDryChemicalExtinguisher]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceC02Extinguisher]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceC02Extinguisher]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceFireResistantTarp]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceFireResistantTarp]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceSparkContainment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceSparkContainment]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceWaterHose]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceWaterHose]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceSteamHose]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceSteamHose]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceWatchmen]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [FireConfinedSpaceWatchmen]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsAirCartOrAirLine]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsAirCartOrAirLine]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsSCBA]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsSCBA]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsHalfFaceRespirator]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsHalfFaceRespirator]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsFullFaceRespirator]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsFullFaceRespirator]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsDustMask]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsDustMask]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsAirHood]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsAirHood]
GO
/****** Object:  Default [DF_WorkPermit_SpecialEyeOrFaceProtectionGoggles]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionGoggles]
GO
/****** Object:  Default [DF_WorkPermit_SpecialEyeOrFaceProtectionFaceshield]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionFaceshield]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeRainCoat]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeRainCoat]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeRainPants]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeRainPants]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeAcidClothing]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeAcidClothing]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeCausticWear]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeCausticWear]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveFootwearChemicalImperviousBoots]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveFootwearChemicalImperviousBoots]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveFootwearToeGuard]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialProtectiveFootwearToeGuard]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionChemicalNeprene]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionChemicalNeprene]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionNaturalRubber]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionNaturalRubber]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionNitrile]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionNitrile]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionPVC]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionPVC]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionHighVoltage]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionHighVoltage]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionWelding]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionWelding]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionLeather]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialHandProtectionLeather]
GO
/****** Object:  Default [DF_WorkPermit_SpecialRescueOrFallBodyHarness]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialRescueOrFallBodyHarness]
GO
/****** Object:  Default [DF_WorkPermit_SpecialRescueOrFallLifeline]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialRescueOrFallLifeline]
GO
/****** Object:  Default [DF_WorkPermit_SpecialRescueOrFallYoYo]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialRescueOrFallYoYo]
GO
/****** Object:  Default [DF_WorkPermit_SpecialRescueOrFallRescueDevice]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SpecialRescueOrFallRescueDevice]
GO
/****** Object:  Default [DF_WorkPermit_SourceId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_WorkPermit_Deleted]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [Deleted]
GO
/****** Object:  Default [DF_WorkPermit_PermitInertConfinedSpaceEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitInertConfinedSpaceEntry]
GO
/****** Object:  Default [DF_WorkPermit_PermitLeadAbatement]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT (0) FOR [PermitLeadAbatement]
GO
/****** Object:  Default [DF_WorkPermit_RespitoryProtectionRequirementsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_RespitoryProtectionRequirementsNotApplicable]  DEFAULT (0) FOR [RespitoryProtectionRequirementsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_SpecialEyeOrFaceProtectionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialEyeOrFaceProtectionNotApplicable]  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveClothingTypeNotApplicable]  DEFAULT (0) FOR [SpecialProtectiveClothingTypeNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveFootwearNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveFootwearNotApplicable]  DEFAULT (0) FOR [SpecialProtectiveFootwearNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialHandProtectionNotApplicable]  DEFAULT (0) FOR [SpecialHandProtectionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_SpecialRescueOrFallNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialRescueOrFallNotApplicable]  DEFAULT (0) FOR [SpecialRescueOrFallNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_FireConfinedSpaceNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_FireConfinedSpaceNotApplicable]  DEFAULT (0) FOR [FireConfinedSpaceNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_PermitElectricalWork]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [PermitElectricalWork]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveFootwearMetatarsalGuard]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [SpecialProtectiveFootwearMetatarsalGuard]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypePaperCoveralls]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypePaperCoveralls]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionPurgedN2]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedN2]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionPurgedSteamed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedSteamed]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentConditionPurgedAir]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedAir]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentAsbestosGasketsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [EquipmentAsbestosGasketsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermit_EquipmentIsolationMethodCarBer]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodCarBer]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalRadiationApproval]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_AdditionalRadiationApproval]  DEFAULT ((0)) FOR [AdditionalRadiationApproval]
GO
/****** Object:  Default [DF_WorkPermit_AdditionalOnlineLeakRepairForm]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_AdditionalOnlineLeakRepairForm]  DEFAULT ((0)) FOR [AdditionalOnlineLeakRepairForm]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeTyvekSuit]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveClothingTypeTyvekSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeTyvekSuit]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeKapplerSuit]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveClothingTypeKapplerSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeKapplerSuit]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeElectricalFlashGear]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveClothingTypeElectricalFlashGear]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeElectricalFlashGear]
GO
/****** Object:  Default [DF_WorkPermit_SpecialProtectiveClothingTypeCorrosiveClothing]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialProtectiveClothingTypeCorrosiveClothing]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeCorrosiveClothing]
GO
/****** Object:  Default [DF_WorkPermit_SpecialHandProtectionChemicalGloves]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_SpecialHandProtectionChemicalGloves]  DEFAULT ((0)) FOR [SpecialHandProtectionChemicalGloves]
GO
/****** Object:  Default [DF_WorkPermit_ToolsChemicals]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_ToolsChemicals]  DEFAULT ((0)) FOR [ToolsChemicals]
GO
/****** Object:  Default [DF_WorkPermit_JobSitePreparationAreaPreparationRadiationRope]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  CONSTRAINT [DF_WorkPermit_JobSitePreparationAreaPreparationRadiationRope]  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationRadiationRope]
GO
/****** Object:  Default [DF__WorkPermi__Start__5B8B70FC]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit] ADD  DEFAULT ((0)) FOR [StartTimeNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitGasTestElementInfo_RequiredTest]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo] ADD  DEFAULT (0) FOR [RequiredTest]
GO
/****** Object:  Default [DF_WorkPermitGasTestElementInfo_ConfinedSpaceTestRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo] ADD  DEFAULT (0) FOR [ConfinedSpaceTestRequired]
GO
/****** Object:  Default [DF_WorkPermitGasTestElementInfo_SystemEntryTestNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo] ADD  CONSTRAINT [DF_WorkPermitGasTestElementInfo_SystemEntryTestNotApplicable]  DEFAULT ((0)) FOR [SystemEntryTestNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitConfinedSpaceEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitConfinedSpaceEntry]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitBreathingAirOrSCBA]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitBreathingAirOrSCBA]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitElectricalSwitching]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitElectricalSwitching]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitVehicleEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitVehicleEntry]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitHotTap]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitHotTap]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitBurnOrOpenFlame]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitBurnOrOpenFlame]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitSystemEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitSystemEntry]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitCriticalLift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitCriticalLift]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitEnergizedElectrical]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitEnergizedElectrical]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitExcavation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitExcavation]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitAsbestos]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitAsbestos]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitRadiationRadiography]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitRadiationRadiography]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitRadiationSealed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitRadiationSealed]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalCSEAssessmentOrAuthorization]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalCSEAssessmentOrAuthorization]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalFlareEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalFlareEntry]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalCriticalLift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalCriticalLift]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalExcavation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalExcavation]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalHotTap]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalHotTap]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalSpecialWasteDisposal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalSpecialWasteDisposal]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalBlankOrBlindLists]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalBlankOrBlindLists]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalPJSROrSafetyPause]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalPJSROrSafetyPause]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalAsbestosHandling]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalAsbestosHandling]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalRoadClosure]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalRoadClosure]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalElectrical]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalElectrical]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalBurnOrOpenFlameAssessment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalBurnOrOpenFlameAssessment]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalWaiverOrDeviation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalWaiverOrDeviation]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalMSDS]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [AdditionalMSDS]
GO
/****** Object:  Default [DF_WorkPermitHistory_CommunicationByRadio]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (1) FOR [CommunicationByRadio]
GO
/****** Object:  Default [DF_WorkPermitHistory_IsWorkPermitCommunicationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [IsWorkPermitCommunicationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_CoAuthorizationRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [CoAuthorizationRequired]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsAirTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsAirTools]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsCraneOrCarrydeck]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsCraneOrCarrydeck]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsHandTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsHandTools]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsJackhammer]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsJackhammer]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsVacuumTruck]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsVacuumTruck]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsCementSaw]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsCementSaw]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsElectricTools]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsElectricTools]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsHeavyEquipment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsHeavyEquipment]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsLanda]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsLanda]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsScaffolding]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsScaffolding]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsVehicle]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsVehicle]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsCompressor]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsCompressor]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsForklift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsForklift]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsHEPAVacuum]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsHEPAVacuum]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsManlift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsManlift]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsTamper]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsTamper]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsHotTapMachine]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsHotTapMachine]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsPortLighting]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsPortLighting]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsTorch]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsTorch]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsWelder]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ToolsWelder]
GO
/****** Object:  Default [DF_WorkPermitHistory_ElectricIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ElectricIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_ElectricIsolationMethodLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ElectricIsolationMethodLOTO]
GO
/****** Object:  Default [DF_WorkPermitHistory_ElectricIsolationMethodWiring]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ElectricIsolationMethodWiring]
GO
/****** Object:  Default [DF_WorkPermitHistory_ElectricTestBumpNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ElectricTestBumpNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_ElectricTestBump]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [ElectricTestBump]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentStillContainsResidualNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentStillContainsResidualNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentStillContainsResidual]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentStillContainsResidual]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentLeakingValvesNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentLeakingValvesNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentLeakingValves]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentLeakingValves]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsOutOfService]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsOutOfService]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionDepressured]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionDepressured]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionDrained]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionDrained]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionCleaned]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionCleaned]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionVentilated]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionVentilated]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionH20Washed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionH20Washed]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionNeutralized]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionNeutralized]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionPurged]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentConditionPurged]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentPreviousContentsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentPreviousContentsHydrocarbon]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsHydrocarbon]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentPreviousContentsAcid]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsAcid]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentPreviousContentsCaustic]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsCaustic]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentPreviousContentsH2S]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentPreviousContentsH2S]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodBlindedorBlanked]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodBlindedorBlanked]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodBlockedIn]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodBlockedIn]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodSeparation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodSeparation]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodMudderPlugs]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodMudderPlugs]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [EquipmentIsolationMethodLOTO]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationFlowRequiredForJob]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationFlowRequiredForJob]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationFlowRequiredForJobNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationFlowRequiredForJobNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationBondingOrGroundingRequiredNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationBondingOrGroundingRequiredNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationBondingOrGroundingRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationBondingOrGroundingRequired]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationWeldingGroundWireInTestAreaNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationWeldingGroundWireInTestArea]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationWeldingGroundWireInTestArea]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationCriticalConditionRemainJobSiteNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationCriticalConditionRemainJobSite]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationCriticalConditionRemainJobSite]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSurroundingConditionsAffectOrContaminated]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminated]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVestedBuddySystemInEffectNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVestedBuddySystemInEffectNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVestedBuddySystemInEffect]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVestedBuddySystemInEffect]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationPermitReceiverFieldOrEquipmentOrientation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSewerIsolationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSewerIsolationMethodSealedOrCovered]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodSealedOrCovered]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSewerIsolationMethodPlugged]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodPlugged]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationSewerIsolationMethodBlindedOrBlanked]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationSewerIsolationMethodBlindedOrBlanked]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVentilationMethodNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVentilationMethodNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVentilationMethodNaturalDraft]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVentilationMethodNaturalDraft]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVentilationMethodLocalExhaust]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVentilationMethodLocalExhaust]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationVentilationMethodForced]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationVentilationMethodForced]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationAreaPreparationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationAreaPreparationBarricade]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationBarricade]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationAreaPreparationNonEssentialEvac]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationNonEssentialEvac]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationAreaPreparationPreopBoundaryRopeTape]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationAreaPreparationPreopBoundaryRopeTape]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationLightingElectricalRequirementNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationLightingElectricalRequirementLowVoltage12V]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementLowVoltage12V]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationLightingElectricalRequirement110VWithGFCI]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirement110VWithGFCI]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationLightingElectricalRequirementGeneratorLights]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [JobSitePreparationLightingElectricalRequirementGeneratorLights]
GO
/****** Object:  Default [DF_WorkPermitHistory_RadiationSealedSourceIsolationNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_RadiationSealedSourceIsolationLOTO]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationLOTO]
GO
/****** Object:  Default [DF_WorkPermitHistory_RadiationSealedSourceIsolationOpen]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RadiationSealedSourceIsolationOpen]
GO
/****** Object:  Default [DF_WorkPermitHistory_GasTestConstantMonitoringRequired]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [GasTestConstantMonitoringRequired]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpace20ABCorDryChemicalExtinguisher]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpace20ABCorDryChemicalExtinguisher]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceC02Extinguisher]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceC02Extinguisher]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceFireResistantTarp]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceFireResistantTarp]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceSparkContainment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceSparkContainment]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceWaterHose]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceWaterHose]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceSteamHose]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceSteamHose]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceWatchmen]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [FireConfinedSpaceWatchmen]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsAirCartOrAirLine]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsAirCartOrAirLine]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsSCBA]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsSCBA]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsHalfFaceRespirator]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsHalfFaceRespirator]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsFullFaceRespirator]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsFullFaceRespirator]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsDustMask]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsDustMask]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsAirHood]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [RespitoryProtectionRequirementsAirHood]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialEyeOrFaceProtectionGoggles]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionGoggles]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialEyeOrFaceProtectionFaceshield]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionFaceshield]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeRainCoat]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeRainCoat]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeRainPants]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeRainPants]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeAcidClothing]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeAcidClothing]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeCausticWear]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveClothingTypeCausticWear]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveFootwearChemicalImperviousBoots]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveFootwearChemicalImperviousBoots]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveFootwearToeGuard]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialProtectiveFootwearToeGuard]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionChemicalNeprene]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionChemicalNeprene]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionNaturalRubber]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionNaturalRubber]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionNitrile]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionNitrile]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionPVC]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionPVC]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionHighVoltage]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionHighVoltage]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionWelding]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionWelding]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionLeather]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialHandProtectionLeather]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialRescueOrFallBodyHarness]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialRescueOrFallBodyHarness]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialRescueOrFallLifeline]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialRescueOrFallLifeline]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialRescueOrFallYoYo]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialRescueOrFallYoYo]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialRescueOrFallRescueDevice]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SpecialRescueOrFallRescueDevice]
GO
/****** Object:  Default [DF_WorkPermitHistory_SourceId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [SourceId]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitInertConfinedSpaceEntry]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitInertConfinedSpaceEntry]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitLeadAbatement]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT (0) FOR [PermitLeadAbatement]
GO
/****** Object:  Default [DF_WorkPermitHistory_RespitoryProtectionRequirementsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_RespitoryProtectionRequirementsNotApplicable]  DEFAULT (0) FOR [RespitoryProtectionRequirementsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialEyeOrFaceProtectionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialEyeOrFaceProtectionNotApplicable]  DEFAULT (0) FOR [SpecialEyeOrFaceProtectionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveClothingTypeNotApplicable]  DEFAULT (0) FOR [SpecialProtectiveClothingTypeNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveFootwearNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveFootwearNotApplicable]  DEFAULT (0) FOR [SpecialProtectiveFootwearNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialHandProtectionNotApplicable]  DEFAULT (0) FOR [SpecialHandProtectionNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialRescueOrFallNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialRescueOrFallNotApplicable]  DEFAULT (0) FOR [SpecialRescueOrFallNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_FireConfinedSpaceNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_FireConfinedSpaceNotApplicable]  DEFAULT (0) FOR [FireConfinedSpaceNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_PermitElectricalWork]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [PermitElectricalWork]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveFootwearMetatarsalGuard]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [SpecialProtectiveFootwearMetatarsalGuard]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypePaperCoveralls]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypePaperCoveralls]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionPurgedN2]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedN2]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionPurgedSteamed]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedSteamed]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentConditionPurgedAir]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedAir]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentAsbestosGasketsNotApplicable]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [EquipmentAsbestosGasketsNotApplicable]
GO
/****** Object:  Default [DF_WorkPermitHistory_EquipmentIsolationMethodCarBer]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodCarBer]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalRadiationApproval]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_AdditionalRadiationApproval]  DEFAULT ((0)) FOR [AdditionalRadiationApproval]
GO
/****** Object:  Default [DF_WorkPermitHistory_AdditionalOnlineLeakRepairForm]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_AdditionalOnlineLeakRepairForm]  DEFAULT ((0)) FOR [AdditionalOnlineLeakRepairForm]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeTyvekSuit]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveClothingTypeTyvekSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeTyvekSuit]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeKapplerSuit]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveClothingTypeKapplerSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeKapplerSuit]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeElectricalFlashGear]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveClothingTypeElectricalFlashGear]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeElectricalFlashGear]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialProtectiveClothingTypeCorrosiveClothing]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialProtectiveClothingTypeCorrosiveClothing]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeCorrosiveClothing]
GO
/****** Object:  Default [DF_WorkPermitHistory_SpecialHandProtectionChemicalGloves]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_SpecialHandProtectionChemicalGloves]  DEFAULT ((0)) FOR [SpecialHandProtectionChemicalGloves]
GO
/****** Object:  Default [DF_WorkPermitHistory_ToolsChemicals]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_ToolsChemicals]  DEFAULT ((0)) FOR [ToolsChemicals]
GO
/****** Object:  Default [DF_WorkPermitHistory_JobSitePreparationAreaPreparationRadiationRope]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory] ADD  CONSTRAINT [DF_WorkPermitHistory_JobSitePreparationAreaPreparationRadiationRope]  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationRadiationRope]
GO
/****** Object:  Default [DF__WorkPermi__Start__5C7F9535]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitHistory_Extension] ADD  DEFAULT ((0)) FOR [StartTimeNotApplicable]
GO
/****** Object:  ForeignKey [FK_ActionItem_ActionItemDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ActionItemDefinition] FOREIGN KEY([CreatedByActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_ActionItemDefinition]
GO
/****** Object:  ForeignKey [FK_ActionItem_BusinessCategory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_BusinessCategory] FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_BusinessCategory]
GO
/****** Object:  ForeignKey [fk_ActionItem_StatusModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [fk_ActionItem_StatusModifiedUser] FOREIGN KEY([StatusModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [fk_ActionItem_StatusModifiedUser]
GO
/****** Object:  ForeignKey [FK_ActionItem_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_User]
GO
/****** Object:  ForeignKey [FK_ActionItem_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_BusinessCategory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_BusinessCategory] FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_BusinessCategory]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_FormGN75B]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_FormGN75B] FOREIGN KEY([GN75BId])
REFERENCES [dbo].[FormGN75B] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_FormGN75B]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_Schedule]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_Schedule]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_User]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinition_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinition] CHECK CONSTRAINT [FK_ActionItemDefinition_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionAutoReApprovalConfiguration_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionAutoReApprovalConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionAutoReApprovalConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionAutoReApprovalConfiguration] CHECK CONSTRAINT [FK_ActionItemDefinitionAutoReApprovalConfiguration_Site]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionComment_ActionItemDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionComment]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionComment_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionComment] CHECK CONSTRAINT [FK_ActionItemDefinitionComment_ActionItemDefinition]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionComment_Comment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionComment]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionComment_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionComment] CHECK CONSTRAINT [FK_ActionItemDefinitionComment_Comment]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionFunctionalLocation_ActionItemId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_ActionItemId] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation] CHECK CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_ActionItemId]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionFunctionalLocation_FunctionalLocationId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionFunctionalLocation] CHECK CONSTRAINT [FK_ActionItemDefinitionFunctionalLocation_FunctionalLocationId]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionHistory_ActionItem]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionHistory_ActionItem] FOREIGN KEY([Id])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionHistory] CHECK CONSTRAINT [FK_ActionItemDefinitionHistory_ActionItem]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionHistory_BusinessCategory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionHistory]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionHistory_BusinessCategory] FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionHistory] CHECK CONSTRAINT [FK_ActionItemDefinitionHistory_BusinessCategory]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionTargetDefinition_ActionItemDefinitionId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionTargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionTargetDefinition_ActionItemDefinitionId] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionTargetDefinition] CHECK CONSTRAINT [FK_ActionItemDefinitionTargetDefinition_ActionItemDefinitionId]
GO
/****** Object:  ForeignKey [FK_ActionItemDefinitionTargetDefinition_TargetDefinitionId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemDefinitionTargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinitionTargetDefinition_TargetDefinitionId] FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[ActionItemDefinitionTargetDefinition] CHECK CONSTRAINT [FK_ActionItemDefinitionTargetDefinition_TargetDefinitionId]
GO
/****** Object:  ForeignKey [FK_ActionItemFunctionalLocation_ActionItemId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemFunctionalLocation_ActionItemId] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])
GO
ALTER TABLE [dbo].[ActionItemFunctionalLocation] CHECK CONSTRAINT [FK_ActionItemFunctionalLocation_ActionItemId]
GO
/****** Object:  ForeignKey [FK_ActionItemFunctionalLocation_FunctionalLocationId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ActionItemFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemFunctionalLocation_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[ActionItemFunctionalLocation] CHECK CONSTRAINT [FK_ActionItemFunctionalLocation_FunctionalLocationId]
GO
/****** Object:  ForeignKey [FK_AreaLabel_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[AreaLabel]  WITH CHECK ADD  CONSTRAINT [FK_AreaLabel_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[AreaLabel] CHECK CONSTRAINT [FK_AreaLabel_Site]
GO
/****** Object:  ForeignKey [FK_BusinessCategory_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[BusinessCategory]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategory_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[BusinessCategory] CHECK CONSTRAINT [FK_BusinessCategory_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_BusinessCategory_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[BusinessCategory]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategory_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[BusinessCategory] CHECK CONSTRAINT [FK_BusinessCategory_Site]
GO
/****** Object:  ForeignKey [FK_BusinessCategoryFLOCAssociation_BusinessCategory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategoryFLOCAssociation_BusinessCategory] FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])
GO
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation] CHECK CONSTRAINT [FK_BusinessCategoryFLOCAssociation_BusinessCategory]
GO
/****** Object:  ForeignKey [FK_BusinessCategoryFLOCAssociation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategoryFLOCAssociation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation] CHECK CONSTRAINT [FK_BusinessCategoryFLOCAssociation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_BusinessCategoryFLOCAssociation_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategoryFLOCAssociation_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation] CHECK CONSTRAINT [FK_BusinessCategoryFLOCAssociation_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_CokerCard_CokerCardConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_CokerCardConfiguration] FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_CokerCardConfiguration]
GO
/****** Object:  ForeignKey [FK_CokerCard_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_CokerCard_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_CokerCard_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_CokerCard_Shift]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_Shift]
GO
/****** Object:  ForeignKey [FK_CokerCard_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCard]  WITH CHECK ADD  CONSTRAINT [FK_CokerCard_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[CokerCard] CHECK CONSTRAINT [FK_CokerCard_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_CokerCardConfiguration_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardConfiguration_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[CokerCardConfiguration] CHECK CONSTRAINT [FK_CokerCardConfiguration_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_CokerCardConfigurationCycleStep_CokerCardConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardConfigurationCycleStep]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardConfigurationCycleStep_CokerCardConfiguration] FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO
ALTER TABLE [dbo].[CokerCardConfigurationCycleStep] CHECK CONSTRAINT [FK_CokerCardConfigurationCycleStep_CokerCardConfiguration]
GO
/****** Object:  ForeignKey [FK_CokerCardConfigurationDrum_CokerCardConfiguration]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardConfigurationDrum]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardConfigurationDrum_CokerCardConfiguration] FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO
ALTER TABLE [dbo].[CokerCardConfigurationDrum] CHECK CONSTRAINT [FK_CokerCardConfigurationDrum_CokerCardConfiguration]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardConfigurationWorkAssignment_CokerCard]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_CokerCard] FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO
ALTER TABLE [dbo].[CokerCardConfigurationWorkAssignment] CHECK CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_CokerCard]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardConfigurationWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[CokerCardConfigurationWorkAssignment] CHECK CONSTRAINT [FK_dbo_CokerCardConfigurationWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_CokerCardCycleStepEntry_CokerCard]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCard] FOREIGN KEY([CokerCardId])
REFERENCES [dbo].[CokerCard] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntry] CHECK CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCard]
GO
/****** Object:  ForeignKey [FK_CokerCardCycleStepEntry_CokerCardConfigurationCycleStep]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationCycleStep] FOREIGN KEY([CokerCardConfigurationCycleStepId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntry] CHECK CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationCycleStep]
GO
/****** Object:  ForeignKey [FK_CokerCardCycleStepEntry_CokerCardConfigurationDrum]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationDrum] FOREIGN KEY([CokerCardConfigurationDrumId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntry] CHECK CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationDrum]
GO
/****** Object:  ForeignKey [FK_CokerCardCycleStepEntry_EndEntryShift]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardCycleStepEntry_EndEntryShift] FOREIGN KEY([EndEntryShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntry] CHECK CONSTRAINT [FK_CokerCardCycleStepEntry_EndEntryShift]
GO
/****** Object:  ForeignKey [FK_CokerCardCycleStepEntry_StartEntryShift]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardCycleStepEntry_StartEntryShift] FOREIGN KEY([StartEntryShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntry] CHECK CONSTRAINT [FK_CokerCardCycleStepEntry_StartEntryShift]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardCycleStepEntryHistory_CycleStepConfig]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_CycleStepConfig] FOREIGN KEY([CycleStepConfigurationId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntryHistory] CHECK CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_CycleStepConfig]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardCycleStepEntryHistory_DrumHistory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardCycleStepEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_DrumHistory] FOREIGN KEY([CokerCardDrumEntryHistoryId])
REFERENCES [dbo].[CokerCardDrumEntryHistory] ([Id])
GO
ALTER TABLE [dbo].[CokerCardCycleStepEntryHistory] CHECK CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_DrumHistory]
GO
/****** Object:  ForeignKey [FK_CokerCardDrumEntry_CokerCard]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardDrumEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardDrumEntry_CokerCard] FOREIGN KEY([CokerCardId])
REFERENCES [dbo].[CokerCard] ([Id])
GO
ALTER TABLE [dbo].[CokerCardDrumEntry] CHECK CONSTRAINT [FK_CokerCardDrumEntry_CokerCard]
GO
/****** Object:  ForeignKey [FK_CokerCardDrumEntry_CokerCardConfigurationDrum]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardDrumEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardDrumEntry_CokerCardConfigurationDrum] FOREIGN KEY([CokerCardConfigurationDrumId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ([Id])
GO
ALTER TABLE [dbo].[CokerCardDrumEntry] CHECK CONSTRAINT [FK_CokerCardDrumEntry_CokerCardConfigurationDrum]
GO
/****** Object:  ForeignKey [FK_CokerCardDrumEntry_LastCycleStep]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardDrumEntry]  WITH CHECK ADD  CONSTRAINT [FK_CokerCardDrumEntry_LastCycleStep] FOREIGN KEY([CokerCardConfigurationLastCycleStepId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ([Id])
GO
ALTER TABLE [dbo].[CokerCardDrumEntry] CHECK CONSTRAINT [FK_CokerCardDrumEntry_LastCycleStep]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardDrumEntryHistory_CokerCardDrum]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardDrumEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardDrum] FOREIGN KEY([DrumConfigurationId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ([Id])
GO
ALTER TABLE [dbo].[CokerCardDrumEntryHistory] CHECK CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardDrum]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardDrumEntryHistory_CokerCardHistory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardDrumEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardHistory] FOREIGN KEY([CokerCardHistoryId])
REFERENCES [dbo].[CokerCardHistory] ([Id])
GO
ALTER TABLE [dbo].[CokerCardDrumEntryHistory] CHECK CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardHistory]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardHistory_CokerCard]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardHistory_CokerCard] FOREIGN KEY([CokerCardId])
REFERENCES [dbo].[CokerCard] ([Id])
GO
ALTER TABLE [dbo].[CokerCardHistory] CHECK CONSTRAINT [FK_dbo_CokerCardHistory_CokerCard]
GO
/****** Object:  ForeignKey [FK_dbo_CokerCardHistory_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CokerCardHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CokerCardHistory_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CokerCardHistory] CHECK CONSTRAINT [FK_dbo_CokerCardHistory_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_Comment_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_CreatedByUser] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_CreatedByUser]
GO
/****** Object:  ForeignKey [ConfinedSpace_CreatedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ConfinedSpace]  WITH CHECK ADD  CONSTRAINT [ConfinedSpace_CreatedUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ConfinedSpace] CHECK CONSTRAINT [ConfinedSpace_CreatedUser]
GO
/****** Object:  ForeignKey [ConfinedSpace_Floc]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ConfinedSpace]  WITH CHECK ADD  CONSTRAINT [ConfinedSpace_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[ConfinedSpace] CHECK CONSTRAINT [ConfinedSpace_Floc]
GO
/****** Object:  ForeignKey [ConfinedSpace_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[ConfinedSpace]  WITH CHECK ADD  CONSTRAINT [ConfinedSpace_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ConfinedSpace] CHECK CONSTRAINT [ConfinedSpace_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_Contractor_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Contractor]  WITH CHECK ADD  CONSTRAINT [FK_Contractor_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Contractor] CHECK CONSTRAINT [FK_Contractor_Site]
GO
/****** Object:  ForeignKey [FK_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CraftOrTrade]  WITH CHECK ADD  CONSTRAINT [FK_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[CraftOrTrade] CHECK CONSTRAINT [FK_Site]
GO
/****** Object:  ForeignKey [FK_CustomField_OriginCustomField]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomField]  WITH CHECK ADD  CONSTRAINT [FK_CustomField_OriginCustomField] FOREIGN KEY([OriginCustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[CustomField] CHECK CONSTRAINT [FK_CustomField_OriginCustomField]
GO
/****** Object:  ForeignKey [FK_CustomField_Tag]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomField]  WITH CHECK ADD  CONSTRAINT [FK_CustomField_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[CustomField] CHECK CONSTRAINT [FK_CustomField_Tag]
GO
/****** Object:  ForeignKey [FK_CustomFieldCustomFieldGroup_CustomField]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldCustomFieldGroup] CHECK CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomField]
GO
/****** Object:  ForeignKey [FK_CustomFieldCustomFieldGroup_CustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldCustomFieldGroup] CHECK CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_CustomFieldDropDownValue_CustomField]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldDropDownValue]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldDropDownValue_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldDropDownValue] CHECK CONSTRAINT [FK_CustomFieldDropDownValue_CustomField]
GO
/****** Object:  ForeignKey [FK_CustomFieldGroup_OriginCustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldGroup_OriginCustomFieldGroup] FOREIGN KEY([OriginCustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldGroup] CHECK CONSTRAINT [FK_CustomFieldGroup_OriginCustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldGroupWorkAssignment_SummaryLogCustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldGroupWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_SummaryLogCustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldGroupWorkAssignment] CHECK CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_SummaryLogCustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldGroupWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[CustomFieldGroupWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[CustomFieldGroupWorkAssignment] CHECK CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlert]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_FunctionalLocation] FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlert] CHECK CONSTRAINT [FK_DeviationAlert_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_Measurement_Tag]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlert]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_Measurement_Tag] FOREIGN KEY([MeasurementValueTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlert] CHECK CONSTRAINT [FK_DeviationAlert_Measurement_Tag]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_ProductionTarget_Tag]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlert]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_ProductionTarget_Tag] FOREIGN KEY([ProductionTargetValueTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlert] CHECK CONSTRAINT [FK_DeviationAlert_ProductionTarget_Tag]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_RestrictionDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlert]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_RestrictionDefinition] FOREIGN KEY([RestrictionDefinitionId])
REFERENCES [dbo].[RestrictionDefinition] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlert] CHECK CONSTRAINT [FK_DeviationAlert_RestrictionDefinition]
GO
/****** Object:  ForeignKey [FK_DeviationAlertResponse_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlertResponse_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponse] CHECK CONSTRAINT [FK_DeviationAlertResponse_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_DeviationAlertResponse]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_DeviationAlertResponse] FOREIGN KEY([DeviationAlertResponseId])
REFERENCES [dbo].[DeviationAlertResponse] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] CHECK CONSTRAINT [FK_DeviationAlert_DeviationAlertResponse]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] CHECK CONSTRAINT [FK_DeviationAlert_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_ReasonCodeFunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_ReasonCodeFunctionalLocation] FOREIGN KEY([ReasonCodeFunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] CHECK CONSTRAINT [FK_DeviationAlert_ReasonCodeFunctionalLocation]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_RestrictionLocationItem]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_RestrictionLocationItem] FOREIGN KEY([RestrictionLocationItemId])
REFERENCES [dbo].[RestrictionLocationItem] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] CHECK CONSTRAINT [FK_DeviationAlert_RestrictionLocationItem]
GO
/****** Object:  ForeignKey [FK_DeviationAlert_RestrictionReasonCode]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DeviationAlert_RestrictionReasonCode] FOREIGN KEY([RestrictionReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ([Id])
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] CHECK CONSTRAINT [FK_DeviationAlert_RestrictionReasonCode]
GO
/****** Object:  ForeignKey [FK_Directive_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Directive]  WITH CHECK ADD  CONSTRAINT [FK_Directive_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Directive] CHECK CONSTRAINT [FK_Directive_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_Directive_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Directive]  WITH CHECK ADD  CONSTRAINT [FK_Directive_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Directive] CHECK CONSTRAINT [FK_Directive_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_DirectiveFunctionalLocation_Directive]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveFunctionalLocation_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])
GO
ALTER TABLE [dbo].[DirectiveFunctionalLocation] CHECK CONSTRAINT [FK_DirectiveFunctionalLocation_Directive]
GO
/****** Object:  ForeignKey [FK_DirectiveFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[DirectiveFunctionalLocation] CHECK CONSTRAINT [FK_DirectiveFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_DirectiveHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveHistory]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DirectiveHistory] CHECK CONSTRAINT [FK_DirectiveHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_DirectiveRead_Directive]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveRead]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveRead_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])
GO
ALTER TABLE [dbo].[DirectiveRead] CHECK CONSTRAINT [FK_DirectiveRead_Directive]
GO
/****** Object:  ForeignKey [FK_DirectiveRead_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveRead]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveRead_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DirectiveRead] CHECK CONSTRAINT [FK_DirectiveRead_User]
GO
/****** Object:  ForeignKey [FK_DirectiveWorkAssignment_Directive]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveWorkAssignment_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])
GO
ALTER TABLE [dbo].[DirectiveWorkAssignment] CHECK CONSTRAINT [FK_DirectiveWorkAssignment_Directive]
GO
/****** Object:  ForeignKey [FK_DirectiveWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DirectiveWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[DirectiveWorkAssignment] CHECK CONSTRAINT [FK_DirectiveWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_DocumentLink_ActionItem]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_ActionItem] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_ActionItem]
GO
/****** Object:  ForeignKey [FK_DocumentLink_ActionItemDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_ActionItemDefinition]
GO
/****** Object:  ForeignKey [FK_DocumentLink_Directive]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_Directive]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN1]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN1]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN24]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN59]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN6]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN7]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN75A]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN75A]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormGN75B]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN75B] FOREIGN KEY([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormGN75B]
GO
/****** Object:  ForeignKey [FK_DocumentLink_FormOP14]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormOP14] FOREIGN KEY([FormOP14Id])
REFERENCES [dbo].[FormOP14] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_FormOP14]
GO
/****** Object:  ForeignKey [FK_DocumentLink_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_Log]
GO
/****** Object:  ForeignKey [FK_DocumentLink_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_LogDefinition] FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_LogDefinition]
GO
/****** Object:  ForeignKey [FK_DocumentLink_OvertimeForm]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_OvertimeForm] FOREIGN KEY([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_OvertimeForm]
GO
/****** Object:  ForeignKey [FK_DocumentLink_PermitRequestEdmonton]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestEdmonton] FOREIGN KEY([PermitRequestEdmontonId])
REFERENCES [dbo].[PermitRequestEdmonton] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_PermitRequestEdmonton]
GO
/****** Object:  ForeignKey [FK_DocumentLink_PermitRequestLubes]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestLubes] FOREIGN KEY([PermitRequestLubesId])
REFERENCES [dbo].[PermitRequestLubes] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_PermitRequestLubes]
GO
/****** Object:  ForeignKey [FK_DocumentLink_PermitRequestMontreal]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestMontreal] FOREIGN KEY([PermitRequestMontrealId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_PermitRequestMontreal]
GO
/****** Object:  ForeignKey [FK_DocumentLink_SumamryLog]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_SumamryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_SumamryLog]
GO
/****** Object:  ForeignKey [FK_DocumentLink_TargetAlert]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_TargetAlert] FOREIGN KEY([TargetAlertId])
REFERENCES [dbo].[TargetAlert] ([ID])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_TargetAlert]
GO
/****** Object:  ForeignKey [FK_DocumentLink_TargetDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_TargetDefinition] FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_TargetDefinition]
GO
/****** Object:  ForeignKey [FK_DocumentLink_WorkPermit]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermit] FOREIGN KEY([WorkPermitId])
REFERENCES [dbo].[WorkPermit] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_WorkPermit]
GO
/****** Object:  ForeignKey [FK_DocumentLink_WorkPermitEdmonton]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitEdmonton] FOREIGN KEY([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_WorkPermitEdmonton]
GO
/****** Object:  ForeignKey [FK_DocumentLink_WorkPermitLubes]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitLubes] FOREIGN KEY([WorkPermitLubesId])
REFERENCES [dbo].[WorkPermitLubes] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_WorkPermitLubes]
GO
/****** Object:  ForeignKey [FK_DocumentLink_WorkPermitMontreal]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[DocumentLink] CHECK CONSTRAINT [FK_DocumentLink_WorkPermitMontreal]
GO
/****** Object:  ForeignKey [FK_DocumentRootPathFloc_DocumentRoot]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentRootPathFloc_DocumentRoot] FOREIGN KEY([DocumentRootPathId])
REFERENCES [dbo].[DocumentRootPathConfiguration] ([Id])
GO
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation] CHECK CONSTRAINT [FK_DocumentRootPathFloc_DocumentRoot]
GO
/****** Object:  ForeignKey [FK_DocumentRootPathFloc_Floc]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentRootPathFloc_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation] CHECK CONSTRAINT [FK_DocumentRootPathFloc_Floc]
GO
/****** Object:  ForeignKey [FK_DropdownValue_SiteId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[DropdownValue]  WITH CHECK ADD  CONSTRAINT [FK_DropdownValue_SiteId] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[DropdownValue] CHECK CONSTRAINT [FK_DropdownValue_SiteId]
GO
/****** Object:  ForeignKey [FK_Event_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Site]
GO
/****** Object:  ForeignKey [FK_Event_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO
/****** Object:  ForeignKey [FK_FormGN1_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN1] CHECK CONSTRAINT [FK_FormGN1_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN1_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN1] CHECK CONSTRAINT [FK_FormGN1_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN1_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN1] CHECK CONSTRAINT [FK_FormGN1_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN1History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN1History] CHECK CONSTRAINT [FK_FormGN1History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN1PlanningWorksheetApproval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval] CHECK CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN1PlanningWorksheetApproval_FormGN1]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval] CHECK CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_FormGN1]
GO
/****** Object:  ForeignKey [FK_FormGN1RescuePlanApproval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1RescuePlanApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1RescuePlanApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN1RescuePlanApproval] CHECK CONSTRAINT [FK_FormGN1RescuePlanApproval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN1RescuePlanApproval_FormGN1]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN1RescuePlanApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1RescuePlanApproval_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[FormGN1RescuePlanApproval] CHECK CONSTRAINT [FK_FormGN1RescuePlanApproval_FormGN1]
GO
/****** Object:  ForeignKey [FK_FormGN24_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN24] CHECK CONSTRAINT [FK_FormGN24_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN24_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN24] CHECK CONSTRAINT [FK_FormGN24_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN24Approval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN24Approval] CHECK CONSTRAINT [FK_FormGN24Approval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN24Approval_FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24Approval_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[FormGN24Approval] CHECK CONSTRAINT [FK_FormGN24Approval_FormGN24]
GO
/****** Object:  ForeignKey [FK_FormGN24FunctionalLocation_FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24FunctionalLocation_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[FormGN24FunctionalLocation] CHECK CONSTRAINT [FK_FormGN24FunctionalLocation_FormGN24]
GO
/****** Object:  ForeignKey [FK_FormGN24FunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN24FunctionalLocation] CHECK CONSTRAINT [FK_FormGN24FunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN24History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN24History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN24History] CHECK CONSTRAINT [FK_FormGN24History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN59_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN59] CHECK CONSTRAINT [FK_FormGN59_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN59_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN59] CHECK CONSTRAINT [FK_FormGN59_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN59Approval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN59Approval] CHECK CONSTRAINT [FK_FormGN59Approval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN59Approval_FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59Approval_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[FormGN59Approval] CHECK CONSTRAINT [FK_FormGN59Approval_FormGN59]
GO
/****** Object:  ForeignKey [FK_FormGN59FunctionalLocation_FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59FunctionalLocation_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation] CHECK CONSTRAINT [FK_FormGN59FunctionalLocation_FormGN59]
GO
/****** Object:  ForeignKey [FK_FormGN59FunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation] CHECK CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN59History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN59History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN59History] CHECK CONSTRAINT [FK_FormGN59History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN6_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN6] CHECK CONSTRAINT [FK_FormGN6_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN6_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN6] CHECK CONSTRAINT [FK_FormGN6_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN6_WorkerResponsibiltiesTemplate]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6_WorkerResponsibiltiesTemplate] FOREIGN KEY([WorkerResponsiblitiesTemplateId])
REFERENCES [dbo].[FormTemplate] ([Id])
GO
ALTER TABLE [dbo].[FormGN6] CHECK CONSTRAINT [FK_FormGN6_WorkerResponsibiltiesTemplate]
GO
/****** Object:  ForeignKey [FK_FormGN6Approval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN6Approval] CHECK CONSTRAINT [FK_FormGN6Approval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN6Approval_FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6Approval_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[FormGN6Approval] CHECK CONSTRAINT [FK_FormGN6Approval_FormGN6]
GO
/****** Object:  ForeignKey [FK_FormGN6FunctionalLocation_FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6FunctionalLocation_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[FormGN6FunctionalLocation] CHECK CONSTRAINT [FK_FormGN6FunctionalLocation_FormGN6]
GO
/****** Object:  ForeignKey [FK_FormGN6FunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN6FunctionalLocation] CHECK CONSTRAINT [FK_FormGN6FunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN6History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN6History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN6History] CHECK CONSTRAINT [FK_FormGN6History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN7_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN7] CHECK CONSTRAINT [FK_FormGN7_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN7_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN7] CHECK CONSTRAINT [FK_FormGN7_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN75A_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75A]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75A_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75A] CHECK CONSTRAINT [FK_FormGN75A_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN75A_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75A]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75A_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN75A] CHECK CONSTRAINT [FK_FormGN75A_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN75A_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75A]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75A_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75A] CHECK CONSTRAINT [FK_FormGN75A_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN75AApproval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75AApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75AApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75AApproval] CHECK CONSTRAINT [FK_FormGN75AApproval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN75AApproval_FormGN75A]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75AApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75AApproval_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[FormGN75AApproval] CHECK CONSTRAINT [FK_FormGN75AApproval_FormGN75A]
GO
/****** Object:  ForeignKey [FK_FormGN75AHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75AHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75AHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75AHistory] CHECK CONSTRAINT [FK_FormGN75AHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN75B_CreateUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75B]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75B_CreateUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75B] CHECK CONSTRAINT [FK_FormGN75B_CreateUser]
GO
/****** Object:  ForeignKey [FK_FormGN75B_Floc]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75B]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75B_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN75B] CHECK CONSTRAINT [FK_FormGN75B_Floc]
GO
/****** Object:  ForeignKey [FK_FormGN75B_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75B]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75B_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75B] CHECK CONSTRAINT [FK_FormGN75B_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN75BHistory_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75BHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BHistory_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75BHistory] CHECK CONSTRAINT [FK_FormGN75BHistory_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormGN75IsolationItem_FormGN75]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75BIsolationItem]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75IsolationItem_FormGN75] FOREIGN KEY([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ([Id])
GO
ALTER TABLE [dbo].[FormGN75BIsolationItem] CHECK CONSTRAINT [FK_FormGN75IsolationItem_FormGN75]
GO
/****** Object:  ForeignKey [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BId] FOREIGN KEY([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ([Id])
GO
ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BId]
GO
/****** Object:  ForeignKey [FK_FormGN75BUserReadDocumentLinkAssociation_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_User]
GO
/****** Object:  ForeignKey [FK_FormGN7Approval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN7Approval] CHECK CONSTRAINT [FK_FormGN7Approval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormGN7Approval_FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7Approval_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[FormGN7Approval] CHECK CONSTRAINT [FK_FormGN7Approval_FormGN7]
GO
/****** Object:  ForeignKey [FK_FormGN7FunctionalLocation_FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7FunctionalLocation_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation] CHECK CONSTRAINT [FK_FormGN7FunctionalLocation_FormGN7]
GO
/****** Object:  ForeignKey [FK_FormGN7FunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN7FunctionalLocation] CHECK CONSTRAINT [FK_FormGN7FunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormGN7History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormGN7History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormGN7History] CHECK CONSTRAINT [FK_FormGN7History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTraining_CreatedByRoleId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTraining_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTraining_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTraining_Shift]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_Shift]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTraining_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingApproval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingApproval] CHECK CONSTRAINT [FK_FormOilsandsTrainingApproval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingApproval_FormOilsandsTraining]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingApproval_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingApproval] CHECK CONSTRAINT [FK_FormOilsandsTrainingApproval_FormOilsandsTraining]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingFunctionalLocation_FormOilsandsTraining]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation] CHECK CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FormOilsandsTraining]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingFunctionalLocation] CHECK CONSTRAINT [FK_FormOilsandsTrainingFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingHistory_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingHistory_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingHistory] CHECK CONSTRAINT [FK_FormOilsandsTrainingHistory_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingItem_FormOilsandsTraining]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingItem]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingItem_FormOilsandsTraining] FOREIGN KEY([FormOilsandsTrainingId])
REFERENCES [dbo].[FormOilsandsTraining] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingItem] CHECK CONSTRAINT [FK_FormOilsandsTrainingItem_FormOilsandsTraining]
GO
/****** Object:  ForeignKey [FK_FormOilsandsTrainingItem_TrainingBlock]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOilsandsTrainingItem]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTrainingItem_TrainingBlock] FOREIGN KEY([TrainingBlockId])
REFERENCES [dbo].[TrainingBlock] ([Id])
GO
ALTER TABLE [dbo].[FormOilsandsTrainingItem] CHECK CONSTRAINT [FK_FormOilsandsTrainingItem_TrainingBlock]
GO
/****** Object:  ForeignKey [FK_FormOP14_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOP14] CHECK CONSTRAINT [FK_FormOP14_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FormOP14_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOP14] CHECK CONSTRAINT [FK_FormOP14_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_FormOP14Approval_ApprovedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOP14Approval] CHECK CONSTRAINT [FK_FormOP14Approval_ApprovedByUser]
GO
/****** Object:  ForeignKey [FK_FormOP14Approval_FormOP14]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Approval_FormOP14] FOREIGN KEY([FormOP14Id])
REFERENCES [dbo].[FormOP14] ([Id])
GO
ALTER TABLE [dbo].[FormOP14Approval] CHECK CONSTRAINT [FK_FormOP14Approval_FormOP14]
GO
/****** Object:  ForeignKey [FK_FormOP14FunctionalLocation_FormOP14]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14FunctionalLocation_FormOP14] FOREIGN KEY([FormOP14Id])
REFERENCES [dbo].[FormOP14] ([Id])
GO
ALTER TABLE [dbo].[FormOP14FunctionalLocation] CHECK CONSTRAINT [FK_FormOP14FunctionalLocation_FormOP14]
GO
/****** Object:  ForeignKey [FK_FormOP14FunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormOP14FunctionalLocation] CHECK CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FormOP14History_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOP14History]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOP14History] CHECK CONSTRAINT [FK_FormOP14History_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormOvertimeFormHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormOvertimeFormHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormOvertimeFormHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormOvertimeFormHistory] CHECK CONSTRAINT [FK_FormOvertimeFormHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_FormTemplate_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FormTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormTemplate_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FormTemplate] CHECK CONSTRAINT [FK_FormTemplate_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_FunctionalLocation_Plant]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocation_Plant] FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocation] CHECK CONSTRAINT [FK_FunctionalLocation_Plant]
GO
/****** Object:  ForeignKey [FK_FunctionalLocation_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocation_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocation] CHECK CONSTRAINT [FK_FunctionalLocation_Site]
GO
/****** Object:  ForeignKey [FK_FunctionalLocationAncestor_AncestorId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocationAncestor]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId] FOREIGN KEY([AncestorId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor] CHECK CONSTRAINT [FK_FunctionalLocationAncestor_AncestorId]
GO
/****** Object:  ForeignKey [FK_FunctionalLocationAncestor_Id]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocationAncestor]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationAncestor_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationAncestor] CHECK CONSTRAINT [FK_FunctionalLocationAncestor_Id]
GO
/****** Object:  ForeignKey [FK_FunctionalLocationOpMode_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocationOperationalMode]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationOpMode_FunctionalLocation] FOREIGN KEY([UnitId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalMode] CHECK CONSTRAINT [FK_FunctionalLocationOpMode_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FunctionalLocationOperationalModeHistory_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_FunctionalLocation] FOREIGN KEY([UnitId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory] CHECK CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_FunctionalLocationOperationalModeHistory_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FunctionalLocationOperationalModeHistory] CHECK CONSTRAINT [FK_FunctionalLocationOperationalModeHistory_User]
GO
/****** Object:  ForeignKey [FK_GasTestElementInfo_GasLimitUnit]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfo]  WITH CHECK ADD  CONSTRAINT [FK_GasTestElementInfo_GasLimitUnit] FOREIGN KEY([GasLimitUnitId])
REFERENCES [dbo].[GasLimitUnit] ([Id])
GO
ALTER TABLE [dbo].[GasTestElementInfo] CHECK CONSTRAINT [FK_GasTestElementInfo_GasLimitUnit]
GO
/****** Object:  ForeignKey [FK_GasTestElementInfo_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfo]  WITH CHECK ADD  CONSTRAINT [FK_GasTestElementInfo_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[GasTestElementInfo] CHECK CONSTRAINT [FK_GasTestElementInfo_Site]
GO
/****** Object:  ForeignKey [FK_GasTestElementInfoHistory_GasLimitUnit]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory]  WITH CHECK ADD  CONSTRAINT [FK_GasTestElementInfoHistory_GasLimitUnit] FOREIGN KEY([GasLimitUnitId])
REFERENCES [dbo].[GasLimitUnit] ([Id])
GO
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory] CHECK CONSTRAINT [FK_GasTestElementInfoHistory_GasLimitUnit]
GO
/****** Object:  ForeignKey [FK_GasTestElementInfoHistory_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory]  WITH CHECK ADD  CONSTRAINT [FK_GasTestElementInfoHistory_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory] CHECK CONSTRAINT [FK_GasTestElementInfoHistory_Site]
GO
/****** Object:  ForeignKey [FK_GasTestElementInfoHistory_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory]  WITH CHECK ADD  CONSTRAINT [FK_GasTestElementInfoHistory_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[GasTestElementInfoConfigurationHistory] CHECK CONSTRAINT [FK_GasTestElementInfoHistory_User]
GO
/****** Object:  ForeignKey [FK_HoneywellPhdConnection_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[HoneywellPhdConnectionInfo]  WITH CHECK ADD  CONSTRAINT [FK_HoneywellPhdConnection_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[HoneywellPhdConnectionInfo] CHECK CONSTRAINT [FK_HoneywellPhdConnection_Site]
GO
/****** Object:  ForeignKey [FK_LabAlert_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlert]  WITH CHECK ADD  CONSTRAINT [FK_LabAlert_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[LabAlert] CHECK CONSTRAINT [FK_LabAlert_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_LabAlert_LabAlertDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlert]  WITH CHECK ADD  CONSTRAINT [FK_LabAlert_LabAlertDefinition] FOREIGN KEY([LabAlertDefinitionId])
REFERENCES [dbo].[LabAlertDefinition] ([Id])
GO
ALTER TABLE [dbo].[LabAlert] CHECK CONSTRAINT [FK_LabAlert_LabAlertDefinition]
GO
/****** Object:  ForeignKey [FK_LabAlert_LasModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlert]  WITH CHECK ADD  CONSTRAINT [FK_LabAlert_LasModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LabAlert] CHECK CONSTRAINT [FK_LabAlert_LasModifiedByUser]
GO
/****** Object:  ForeignKey [FK_LabAlert_Tag]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlert]  WITH CHECK ADD  CONSTRAINT [FK_LabAlert_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[LabAlert] CHECK CONSTRAINT [FK_LabAlert_Tag]
GO
/****** Object:  ForeignKey [FK_LabAlertDefinition_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertDefinition_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LabAlertDefinition] CHECK CONSTRAINT [FK_LabAlertDefinition_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_LabAlertDefinition_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertDefinition_FunctionalLocation] FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[LabAlertDefinition] CHECK CONSTRAINT [FK_LabAlertDefinition_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_LabAlertDefinition_LasModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertDefinition_LasModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LabAlertDefinition] CHECK CONSTRAINT [FK_LabAlertDefinition_LasModifiedByUser]
GO
/****** Object:  ForeignKey [FK_LabAlertDefinition_Schedule]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertDefinition_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[LabAlertDefinition] CHECK CONSTRAINT [FK_LabAlertDefinition_Schedule]
GO
/****** Object:  ForeignKey [FK_LabAlertDefinition_Tag]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertDefinition_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[LabAlertDefinition] CHECK CONSTRAINT [FK_LabAlertDefinition_Tag]
GO
/****** Object:  ForeignKey [FK_LabAlertResponse_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertResponse_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LabAlertResponse] CHECK CONSTRAINT [FK_LabAlertResponse_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_LabAlertResponse_LabAlert]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LabAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_LabAlertResponse_LabAlert] FOREIGN KEY([LabAlertId])
REFERENCES [dbo].[LabAlert] ([Id])
GO
ALTER TABLE [dbo].[LabAlertResponse] CHECK CONSTRAINT [FK_LabAlertResponse_LabAlert]
GO
/****** Object:  ForeignKey [FK_Log_CreatedByRoleId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_Log_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_Log_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LogDefinition] FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_LogDefinition]
GO
/****** Object:  ForeignKey [FK_Log_ReplyToLog]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_ReplyToLog] FOREIGN KEY([ReplyToLogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_ReplyToLog]
GO
/****** Object:  ForeignKey [FK_Log_RootLog]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_RootLog] FOREIGN KEY([RootLogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_RootLog]
GO
/****** Object:  ForeignKey [FK_Log_Shift]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Shift] FOREIGN KEY([CreationUserShiftPatternId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Shift]
GO
/****** Object:  ForeignKey [FK_Log_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_User]
GO
/****** Object:  ForeignKey [FK_Log_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_LogAssociation_ActionItem]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogActionItemAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogAssociation_ActionItem] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemAssociation] CHECK CONSTRAINT [FK_LogAssociation_ActionItem]
GO
/****** Object:  ForeignKey [FK_LogAssociation_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogActionItemAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemAssociation] CHECK CONSTRAINT [FK_LogAssociation_Log]
GO
/****** Object:  ForeignKey [FK_LogActionItemDefinitionAssociation_ActionItemDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogActionItemDefinitionAssociation_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation] CHECK CONSTRAINT [FK_LogActionItemDefinitionAssociation_ActionItemDefinition]
GO
/****** Object:  ForeignKey [FK_LogActionItemDefinitionAssociation_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogActionItemDefinitionAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation] CHECK CONSTRAINT [FK_LogActionItemDefinitionAssociation_Log]
GO
/****** Object:  ForeignKey [FK_LogCustomFieldEntry_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldEntry_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogCustomFieldEntry] CHECK CONSTRAINT [FK_LogCustomFieldEntry_Log]
GO
/****** Object:  ForeignKey [FL_LogCustomFieldEntry_CustomField]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FL_LogCustomFieldEntry_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[LogCustomFieldEntry] CHECK CONSTRAINT [FL_LogCustomFieldEntry_CustomField]
GO
/****** Object:  ForeignKey [FK_LogCustomFieldEntryHistory_LogHistory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldEntryHistory_LogHistory] FOREIGN KEY([LogHistoryId])
REFERENCES [dbo].[LogHistory] ([LogHistoryId])
GO
ALTER TABLE [dbo].[LogCustomFieldEntryHistory] CHECK CONSTRAINT [FK_LogCustomFieldEntryHistory_LogHistory]
GO
/****** Object:  ForeignKey [FK_LogCustomFieldGroup_CustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[LogCustomFieldGroup] CHECK CONSTRAINT [FK_LogCustomFieldGroup_CustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_LogCustomFieldGroup_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldGroup_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogCustomFieldGroup] CHECK CONSTRAINT [FK_LogCustomFieldGroup_Log]
GO
/****** Object:  ForeignKey [FK_LogDefinition_CreatedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinition_CreatedUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LogDefinition] CHECK CONSTRAINT [FK_LogDefinition_CreatedUser]
GO
/****** Object:  ForeignKey [FK_LogDefinition_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinition_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LogDefinition] CHECK CONSTRAINT [FK_LogDefinition_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_LogDefinition_Schedule]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinition_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[LogDefinition] CHECK CONSTRAINT [FK_LogDefinition_Schedule]
GO
/****** Object:  ForeignKey [FK_LogDefinition_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinition_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[LogDefinition] CHECK CONSTRAINT [FK_LogDefinition_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_LogDefninition_CreatedByRoleId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinition]  WITH CHECK ADD  CONSTRAINT [FK_LogDefninition_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[LogDefinition] CHECK CONSTRAINT [FK_LogDefninition_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_LogDefinitionCustomFieldEntry_CustomField]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldEntry_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry] CHECK CONSTRAINT [FK_LogDefinitionCustomFieldEntry_CustomField]
GO
/****** Object:  ForeignKey [FK_LogDefinitionCustomFieldEntry_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldEntry_LogDefinition] FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry] CHECK CONSTRAINT [FK_LogDefinitionCustomFieldEntry_LogDefinition]
GO
/****** Object:  ForeignKey [FK_LogDefinitionCustomFieldEntryHistory_LogDefinitionHistory]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldEntryHistory_LogDefinitionHistory] FOREIGN KEY([LogDefinitionHistoryId])
REFERENCES [dbo].[LogDefinitionHistory] ([LogDefinitionHistoryId])
GO
ALTER TABLE [dbo].[LogDefinitionCustomFieldEntryHistory] CHECK CONSTRAINT [FK_LogDefinitionCustomFieldEntryHistory_LogDefinitionHistory]
GO
/****** Object:  ForeignKey [FK_LogDefinitionCustomFieldGroup_CustomFieldGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup] CHECK CONSTRAINT [FK_LogDefinitionCustomFieldGroup_CustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_LogDefinitionCustomFieldGroup_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldGroup_LogDefinition] FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup] CHECK CONSTRAINT [FK_LogDefinitionCustomFieldGroup_LogDefinition]
GO
/****** Object:  ForeignKey [FK_LogDefinitionFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation] CHECK CONSTRAINT [FK_LogDefinitionFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_LogDefinitionFunctionalLocation_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionFunctionalLocation_LogDefinition] FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionFunctionalLocation] CHECK CONSTRAINT [FK_LogDefinitionFunctionalLocation_LogDefinition]
GO
/****** Object:  ForeignKey [FK_LogDefinitionHistory_LogDefinition]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogDefinitionHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionHistory_LogDefinition] FOREIGN KEY([Id])
REFERENCES [dbo].[LogDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogDefinitionHistory] CHECK CONSTRAINT [FK_LogDefinitionHistory_LogDefinition]
GO
/****** Object:  ForeignKey [FK_LogFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_LogFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[LogFunctionalLocation] CHECK CONSTRAINT [FK_LogFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_LogFunctionalLocation_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_LogFunctionalLocation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogFunctionalLocation] CHECK CONSTRAINT [FK_LogFunctionalLocation_Log]
GO
/****** Object:  ForeignKey [FK_LogFunctionalLocationList_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogFunctionalLocationList]  WITH CHECK ADD  CONSTRAINT [FK_LogFunctionalLocationList_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogFunctionalLocationList] CHECK CONSTRAINT [FK_LogFunctionalLocationList_Log]
GO
/****** Object:  ForeignKey [FK_LogGuideline_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogGuideline]  WITH CHECK ADD  CONSTRAINT [FK_LogGuideline_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[LogGuideline] CHECK CONSTRAINT [FK_LogGuideline_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_LogHistory_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogHistory]  WITH CHECK ADD  CONSTRAINT [FK_LogHistory_Log] FOREIGN KEY([Id])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogHistory] CHECK CONSTRAINT [FK_LogHistory_Log]
GO
/****** Object:  ForeignKey [LogsRead_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogRead]  WITH CHECK ADD  CONSTRAINT [LogsRead_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogRead] CHECK CONSTRAINT [LogsRead_Log]
GO
/****** Object:  ForeignKey [LogsRead_User]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogRead]  WITH CHECK ADD  CONSTRAINT [LogsRead_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LogRead] CHECK CONSTRAINT [LogsRead_User]
GO
/****** Object:  ForeignKey [FK_LogTargetAlertAssociation_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTargetAlertAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogTargetAlertAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogTargetAlertAssociation] CHECK CONSTRAINT [FK_LogTargetAlertAssociation_Log]
GO
/****** Object:  ForeignKey [FK_LogTargetAlertAssociation_TargetAlert]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTargetAlertAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogTargetAlertAssociation_TargetAlert] FOREIGN KEY([TargetAlertId])
REFERENCES [dbo].[TargetAlert] ([ID])
GO
ALTER TABLE [dbo].[LogTargetAlertAssociation] CHECK CONSTRAINT [FK_LogTargetAlertAssociation_TargetAlert]
GO
/****** Object:  ForeignKey [FK_LogTemplate_CreatedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTemplate]  WITH CHECK ADD  CONSTRAINT [FK_LogTemplate_CreatedUser] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LogTemplate] CHECK CONSTRAINT [FK_LogTemplate_CreatedUser]
GO
/****** Object:  ForeignKey [FK_LogTemplate_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTemplate]  WITH CHECK ADD  CONSTRAINT [FK_LogTemplate_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LogTemplate] CHECK CONSTRAINT [FK_LogTemplate_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_LogTemplateWorkAssignment_LogTemplate]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTemplateWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_LogTemplateWorkAssignment_LogTemplate] FOREIGN KEY([LogTemplateId])
REFERENCES [dbo].[LogTemplate] ([Id])
GO
ALTER TABLE [dbo].[LogTemplateWorkAssignment] CHECK CONSTRAINT [FK_LogTemplateWorkAssignment_LogTemplate]
GO
/****** Object:  ForeignKey [FK_LogTemplateWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogTemplateWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_LogTemplateWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[LogTemplateWorkAssignment] CHECK CONSTRAINT [FK_LogTemplateWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_LogWorkPermitEdmontonAssoc_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogWorkPermitEdmontonAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogWorkPermitEdmontonAssociation] CHECK CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_Log]
GO
/****** Object:  ForeignKey [FK_LogWorkPermitEdmontonAssoc_WorkPermit]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogWorkPermitEdmontonAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_WorkPermit] FOREIGN KEY([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ([Id])
GO
ALTER TABLE [dbo].[LogWorkPermitEdmontonAssociation] CHECK CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_WorkPermit]
GO
/****** Object:  ForeignKey [FK_LogWorkPermitLubesAssoc_Log]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogWorkPermitLubesAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitLubesAssoc_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogWorkPermitLubesAssociation] CHECK CONSTRAINT [FK_LogWorkPermitLubesAssoc_Log]
GO
/****** Object:  ForeignKey [FK_LogWorkPermitLubesAssoc_WorkPermit]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[LogWorkPermitLubesAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogWorkPermitLubesAssoc_WorkPermit] FOREIGN KEY([WorkPermitLubesId])
REFERENCES [dbo].[WorkPermitLubes] ([Id])
GO
ALTER TABLE [dbo].[LogWorkPermitLubesAssociation] CHECK CONSTRAINT [FK_LogWorkPermitLubesAssoc_WorkPermit]
GO
/****** Object:  ForeignKey [FK_OvertimeForm_CreatedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeForm]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeForm_CreatedUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[OvertimeForm] CHECK CONSTRAINT [FK_OvertimeForm_CreatedUser]
GO
/****** Object:  ForeignKey [FK_OvertimeForm_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeForm]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeForm_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[OvertimeForm] CHECK CONSTRAINT [FK_OvertimeForm_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_OvertimeForm_LastModifiedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeForm]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeForm_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[OvertimeForm] CHECK CONSTRAINT [FK_OvertimeForm_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_OvertimeApproval_ApprovedUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeFormApproval]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeApproval_ApprovedUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[OvertimeFormApproval] CHECK CONSTRAINT [FK_OvertimeApproval_ApprovedUser]
GO
/****** Object:  ForeignKey [FK_OvertimeApproval_OvertimeForm]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeFormApproval]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeApproval_OvertimeForm] FOREIGN KEY([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ([Id])
GO
ALTER TABLE [dbo].[OvertimeFormApproval] CHECK CONSTRAINT [FK_OvertimeApproval_OvertimeForm]
GO
/****** Object:  ForeignKey [FK_OvertimeContractor_Overtime]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[OvertimeFormContractor]  WITH CHECK ADD  CONSTRAINT [FK_OvertimeContractor_Overtime] FOREIGN KEY([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ([Id])
GO
ALTER TABLE [dbo].[OvertimeFormContractor] CHECK CONSTRAINT [FK_OvertimeContractor_Overtime]
GO
/****** Object:  ForeignKey [FK_PermitAttribute_Site]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PermitAttribute_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[PermitAttribute] CHECK CONSTRAINT [FK_PermitAttribute_Site]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_AreaLabel]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_AreaLabel] FOREIGN KEY([AreaLabelId])
REFERENCES [dbo].[AreaLabel] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_AreaLabel]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_CreatedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN1]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN1]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN24]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN59]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN6]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN7]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FormGN75A]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FormGN75A]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_LastImportedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_LastImportedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_LastSubmittedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_LastSubmittedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_TradeChecklist]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_TradeChecklist] FOREIGN KEY([FormGN1TradeChecklistId])
REFERENCES [dbo].[TradeChecklist] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_TradeChecklist]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmonton_WorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmonton] CHECK CONSTRAINT [FK_PermitRequestEdmonton_WorkPermitEdmontonGroup]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_FormGN24]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN24]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_FormGN59]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN59]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_FormGN6]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN6]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_FormGN7]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN7]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_FormGN75A]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_FormGN75A]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_LastImportedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonHistory_LastSubmittedByUser]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonRawImportData_FunctionalLocation]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData] CHECK CONSTRAINT [FK_PermitRequestEdmontonRawImportData_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonRawImportData_WorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonSAPImportData] CHECK CONSTRAINT [FK_PermitRequestEdmontonRawImportData_WorkPermitEdmontonGroup]
GO
/****** Object:  ForeignKey [FK_PermitRequestEdmontonWorkOrderSource_PermitRequestEdmonton]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestEdmontonWorkOrderSource]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonWorkOrderSource_PermitRequestEdmonton] FOREIGN KEY([PermitRequestEdmontonId])
REFERENCES [dbo].[PermitRequestEdmonton] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonWorkOrderSource] CHECK CONSTRAINT [FK_PermitRequestEdmontonWorkOrderSource_PermitRequestEdmonton]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_CreatedByRoleId]    Script Date: 08/24/2014 11:51:21 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_CreatedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_CreatedByUserId]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_LastImportedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_LastImportedByUserId] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_LastImportedByUserId]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_LastModifiedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_LastModifiedByUserId] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_LastModifiedByUserId]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_LastSubmittedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_LastSubmittedByUserId] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_LastSubmittedByUserId]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubes_WorkPermitLubesGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubes_WorkPermitLubesGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_WorkPermitLubesGroup]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubesHistory_LastImportedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastImportedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubesHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubesHistory_LastSubmittedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastSubmittedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestLubesWorkOrderSource_PermitRequestLubes]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestLubesWorkOrderSource]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesWorkOrderSource_PermitRequestLubes] FOREIGN KEY([PermitRequestLubesId])
REFERENCES [dbo].[PermitRequestLubes] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubesWorkOrderSource] CHECK CONSTRAINT [FK_PermitRequestLubesWorkOrderSource_PermitRequestLubes]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontreal_CreatedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontreal_LastImportedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_LastImportedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontreal_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontreal_LastSubmittedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_LastSubmittedByUser]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontreal_WorkPermitMontrealGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontreal]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontreal_WorkPermitMontrealGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitMontrealGroup] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontreal] CHECK CONSTRAINT [FK_PermitRequestMontreal_WorkPermitMontrealGroup]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation] CHECK CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontrealFunctionalLocation_PermitRequestMontreal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_PermitRequestMontreal] FOREIGN KEY([PermitRequestMontrealId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation] CHECK CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_PermitRequestMontreal]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontrealPermitAttributeAssociation_PermitAttribute]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontrealPermitAttributeAssociation_PermitAttribute] FOREIGN KEY([PermitAttributeId])
REFERENCES [dbo].[PermitAttribute] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation] CHECK CONSTRAINT [FK_PermitRequestMontrealPermitAttributeAssociation_PermitAttribute]
GO
/****** Object:  ForeignKey [FK_PermitRequestMontrealPermitAttributeAssociation_PermitRequestMontreal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMontrealPermitAttributeAssociation_PermitRequestMontreal] FOREIGN KEY([PermitRequestId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestMontrealPermitAttributeAssociation] CHECK CONSTRAINT [FK_PermitRequestMontrealPermitAttributeAssociation_PermitRequestMontreal]
GO
/****** Object:  ForeignKey [FK_Plant_SiteId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_SiteId] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_SiteId]
GO
/****** Object:  ForeignKey [FK_PriorityPageSectionConfiguration_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PriorityPageSectionConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_PriorityPageSectionConfiguration_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PriorityPageSectionConfiguration] CHECK CONSTRAINT [FK_PriorityPageSectionConfiguration_User]
GO
/****** Object:  ForeignKey [FK_PriorityPageSectionConfigurationWorkAssignment_PriorityPageSectionConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PriorityPageSectionConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_PriorityPageSectionConfigurationWorkAssignment_PriorityPageSectionConfiguration] FOREIGN KEY([PriorityPageSectionConfigurationId])
REFERENCES [dbo].[PriorityPageSectionConfiguration] ([Id])
GO
ALTER TABLE [dbo].[PriorityPageSectionConfigurationWorkAssignment] CHECK CONSTRAINT [FK_PriorityPageSectionConfigurationWorkAssignment_PriorityPageSectionConfiguration]
GO
/****** Object:  ForeignKey [FK_PriorityPageSectionConfigurationWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[PriorityPageSectionConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_PriorityPageSectionConfigurationWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[PriorityPageSectionConfigurationWorkAssignment] CHECK CONSTRAINT [FK_PriorityPageSectionConfigurationWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_Property_Event]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Event]
GO
/****** Object:  ForeignKey [FK_RestrictionDefinition_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionDefinition_FunctionalLocation] FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[RestrictionDefinition] CHECK CONSTRAINT [FK_RestrictionDefinition_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_RestrictionDefinition_MeasurementTag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionDefinition_MeasurementTag] FOREIGN KEY([MeasurementTagID])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[RestrictionDefinition] CHECK CONSTRAINT [FK_RestrictionDefinition_MeasurementTag]
GO
/****** Object:  ForeignKey [FK_RestrictionDefinition_ProductionTargetTag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionDefinition_ProductionTargetTag] FOREIGN KEY([ProductionTargetTagID])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[RestrictionDefinition] CHECK CONSTRAINT [FK_RestrictionDefinition_ProductionTargetTag]
GO
/****** Object:  ForeignKey [FK_RestrictionDefinition_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionDefinition]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionDefinition_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RestrictionDefinition] CHECK CONSTRAINT [FK_RestrictionDefinition_User]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationItem_Floc]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationItem]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationItem_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationItem] CHECK CONSTRAINT [FK_RestrictionLocationItem_Floc]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationItem_Parent]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationItem]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationItem_Parent] FOREIGN KEY([ParentItemId])
REFERENCES [dbo].[RestrictionLocationItem] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationItem] CHECK CONSTRAINT [FK_RestrictionLocationItem_Parent]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationItem_RestrictionLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationItem]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationItem_RestrictionLocation] FOREIGN KEY([RestrictionLocationId])
REFERENCES [dbo].[RestrictionLocation] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationItem] CHECK CONSTRAINT [FK_RestrictionLocationItem_RestrictionLocation]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationItemReasonCode_Item]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationItemReasonCode_Item] FOREIGN KEY([RestrictionLocationItemId])
REFERENCES [dbo].[RestrictionLocationItem] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode] CHECK CONSTRAINT [FK_RestrictionLocationItemReasonCode_Item]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationItemReasonCode_ReasonCode]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationItemReasonCode_ReasonCode] FOREIGN KEY([RestrictionReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode] CHECK CONSTRAINT [FK_RestrictionLocationItemReasonCode_ReasonCode]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationWorkAssignment_Restriction]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationWorkAssignment_Restriction] FOREIGN KEY([RestrictionLocationId])
REFERENCES [dbo].[RestrictionLocation] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationWorkAssignment] CHECK CONSTRAINT [FK_RestrictionLocationWorkAssignment_Restriction]
GO
/****** Object:  ForeignKey [FK_RestrictionLocationWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionLocationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionLocationWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[RestrictionLocationWorkAssignment] CHECK CONSTRAINT [FK_RestrictionLocationWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_RestrictionReasonCode_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RestrictionReasonCode]  WITH CHECK ADD  CONSTRAINT [FK_RestrictionReasonCode_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RestrictionReasonCode] CHECK CONSTRAINT [FK_RestrictionReasonCode_User]
GO
/****** Object:  ForeignKey [FK_Role_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Site]
GO
/****** Object:  ForeignKey [FK_RoleDisplayConfiguration_Role]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RoleDisplayConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_RoleDisplayConfiguration_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleDisplayConfiguration] CHECK CONSTRAINT [FK_RoleDisplayConfiguration_Role]
GO
/****** Object:  ForeignKey [FK_RoleElementTemplate_Role]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RoleElementTemplate]  WITH CHECK ADD  CONSTRAINT [FK_RoleElementTemplate_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleElementTemplate] CHECK CONSTRAINT [FK_RoleElementTemplate_Role]
GO
/****** Object:  ForeignKey [FK_RoleElementTemplate_RoleElement]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RoleElementTemplate]  WITH CHECK ADD  CONSTRAINT [FK_RoleElementTemplate_RoleElement] FOREIGN KEY([RoleElementId])
REFERENCES [dbo].[RoleElement] ([Id])
GO
ALTER TABLE [dbo].[RoleElementTemplate] CHECK CONSTRAINT [FK_RoleElementTemplate_RoleElement]
GO
/****** Object:  ForeignKey [FK_RolePermission_CreatedByRoleId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_RolePermission_RoleElementId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_RoleElementId] FOREIGN KEY([RoleElementId])
REFERENCES [dbo].[RoleElement] ([Id])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_RoleElementId]
GO
/****** Object:  ForeignKey [FK_RolePermission_RoleId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_RoleId]
GO
/****** Object:  ForeignKey [FK_SapAutoImportConfiguration_Schedule]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SapAutoImportConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_SapAutoImportConfiguration_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[SapAutoImportConfiguration] CHECK CONSTRAINT [FK_SapAutoImportConfiguration_Schedule]
GO
/****** Object:  ForeignKey [FK_SapAutoImportConfiguration_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SapAutoImportConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_SapAutoImportConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[SapAutoImportConfiguration] CHECK CONSTRAINT [FK_SapAutoImportConfiguration_Site]
GO
/****** Object:  ForeignKey [FK_SAPImportPriorityWorkPermitEdmontonGroup_WorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SAPImportPriorityWorkPermitEdmontonGroup]  WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitEdmontonGroup_WorkPermitEdmontonGroup] FOREIGN KEY([WorkPermitEdmontonGroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])
GO
ALTER TABLE [dbo].[SAPImportPriorityWorkPermitEdmontonGroup] CHECK CONSTRAINT [FK_SAPImportPriorityWorkPermitEdmontonGroup_WorkPermitEdmontonGroup]
GO
/****** Object:  ForeignKey [FK_SAPImportPriorityWorkPermitLubesGroup_WorkPermitLubesGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SAPImportPriorityWorkPermitLubesGroup]  WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitLubesGroup_WorkPermitLubesGroup] FOREIGN KEY([WorkPermitLubesGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])
GO
ALTER TABLE [dbo].[SAPImportPriorityWorkPermitLubesGroup] CHECK CONSTRAINT [FK_SAPImportPriorityWorkPermitLubesGroup_WorkPermitLubesGroup]
GO
/****** Object:  ForeignKey [FK_SAPNotification_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SAPNotification]  WITH CHECK ADD  CONSTRAINT [FK_SAPNotification_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[SAPNotification] CHECK CONSTRAINT [FK_SAPNotification_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_Schedule_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Site]
GO
/****** Object:  ForeignKey [FK_Shift_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Shift]  WITH CHECK ADD  CONSTRAINT [FK_Shift_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Shift] CHECK CONSTRAINT [FK_Shift_Site]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverAnswer_ShiftHandoverQuestion]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestion] FOREIGN KEY([ShiftHandoverQuestionId])
REFERENCES [dbo].[ShiftHandoverQuestion] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverAnswer] CHECK CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestion]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverAnswer] CHECK CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverAnswerHistory]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionId] FOREIGN KEY([ShiftHandoverQuestionId])
REFERENCES [dbo].[ShiftHandoverQuestion] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverAnswerHistory] CHECK CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionId]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionnaireHistory]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverAnswerHistory]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionnaireHistory] FOREIGN KEY([ShiftHandoverQuestionnaireHistoryId])
REFERENCES [dbo].[ShiftHandoverQuestionnaireHistory] ([ShiftHandoverQuestionnaireHistoryId])
GO
ALTER TABLE [dbo].[ShiftHandoverAnswerHistory] CHECK CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionnaireHistory]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverConfigurationWorkAssignment_ShiftHandoverConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_ShiftHandoverConfiguration] FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment] CHECK CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_ShiftHandoverConfiguration]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverConfigurationWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverConfigurationWorkAssignment] CHECK CONSTRAINT [FK_ShiftHandoverConfigurationWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverEmailConfiguration_Shift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration] CHECK CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Shift]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverEmailConfiguration_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration] CHECK CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Site]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverEmailConfigurationWorkAssignment_ShiftHandoverEmailConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverEmailConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverEmailConfigurationWorkAssignment_ShiftHandoverEmailConfiguration] FOREIGN KEY([ShiftHandoverEmailConfigurationId])
REFERENCES [dbo].[ShiftHandoverEmailConfiguration] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverEmailConfigurationWorkAssignment] CHECK CONSTRAINT [FK_ShiftHandoverEmailConfigurationWorkAssignment_ShiftHandoverEmailConfiguration]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverEmailConfigurationWorkAssignment_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverEmailConfigurationWorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverEmailConfigurationWorkAssignment_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverEmailConfigurationWorkAssignment] CHECK CONSTRAINT [FK_ShiftHandoverEmailConfigurationWorkAssignment_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestion_ShiftHandoverConfiguration]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestion_ShiftHandoverConfiguration] FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestion] CHECK CONSTRAINT [FK_ShiftHandoverQuestion_ShiftHandoverConfiguration]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaire_Log]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaire_Log]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaire_Shift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaire_Shift]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaire_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaire_SummaryLog]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaire_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_User] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaire_User]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaire_WorkUnitAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_WorkUnitAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaire_WorkUnitAssignment]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_CokerCardConfigurationId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_CokerCardConfigurationId] FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_CokerCardConfigurationId]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireCokerCardConfiguration] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireCokerCardConfiguration_ShiftHandoverQuestionnaire]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireFunctionalLocation_ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_ShiftHandoverQuestionnaire]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireLog_Log]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog]  WITH NOCHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog]  WITH NOCHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireRead_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireRead] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireRead_User]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireSummaryLog_ShiftHandover]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_ShiftHandover] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_ShiftHandover]
GO
/****** Object:  ForeignKey [FK_ShiftHandoverQuestionnaireSummaryLog_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[ShiftHandoverQuestionnaireSummaryLog] CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireSummaryLog_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SiteCommunication_CreatedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_SiteCommunication_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_SiteCommunication_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteCommunication]  WITH CHECK ADD  CONSTRAINT [FK_SiteCommunication_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[SiteCommunication] CHECK CONSTRAINT [FK_SiteCommunication_Site]
GO
/****** Object:  ForeignKey [FK_SiteConfiguration_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_SiteConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[SiteConfiguration] CHECK CONSTRAINT [FK_SiteConfiguration_Site]
GO
/****** Object:  ForeignKey [FK_SiteConfigurationDefaults_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SiteConfigurationDefaults]  WITH CHECK ADD  CONSTRAINT [FK_SiteConfigurationDefaults_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[SiteConfigurationDefaults] CHECK CONSTRAINT [FK_SiteConfigurationDefaults_Site]
GO
/****** Object:  ForeignKey [FK_SummaryLog_CreatedByRoleId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_CreatedByRoleId]
GO
/****** Object:  ForeignKey [FK_SummaryLog_LastModifiedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_LastModifiedUser] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_SummaryLog_ReplyToLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_ReplyToLog] FOREIGN KEY([ReplyToLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_ReplyToLog]
GO
/****** Object:  ForeignKey [FK_SummaryLog_RootLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_RootLog] FOREIGN KEY([RootLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_RootLog]
GO
/****** Object:  ForeignKey [FK_SummaryLog_Shift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_Shift] FOREIGN KEY([CreationUserShiftPatternId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_Shift]
GO
/****** Object:  ForeignKey [FK_SummaryLog_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_User] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_User]
GO
/****** Object:  ForeignKey [FK_SummaryLog_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLog]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLog_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[SummaryLog] CHECK CONSTRAINT [FK_SummaryLog_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldEntry_CustomField]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldEntry_CustomField] FOREIGN KEY([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogCustomFieldEntry] CHECK CONSTRAINT [FK_SummaryLogCustomFieldEntry_CustomField]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldEntry_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogCustomFieldEntry]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldEntry_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogCustomFieldEntry] CHECK CONSTRAINT [FK_SummaryLogCustomFieldEntry_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldEntryHistory_SummaryLogHistory]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogCustomFieldEntryHistory]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldEntryHistory_SummaryLogHistory] FOREIGN KEY([SummaryLogHistoryId])
REFERENCES [dbo].[SummaryLogHistory] ([SummaryLogHistoryId])
GO
ALTER TABLE [dbo].[SummaryLogCustomFieldEntryHistory] CHECK CONSTRAINT [FK_SummaryLogCustomFieldEntryHistory_SummaryLogHistory]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldGroup_CustomFieldGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroup_CustomFieldGroup] FOREIGN KEY([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogCustomFieldGroup] CHECK CONSTRAINT [FK_SummaryLogCustomFieldGroup_CustomFieldGroup]
GO
/****** Object:  ForeignKey [FK_SummaryLogCustomFieldGroup_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroup_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogCustomFieldGroup] CHECK CONSTRAINT [FK_SummaryLogCustomFieldGroup_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SummaryLogFunctionalLocation_FuncationalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogFunctionalLocation_FuncationalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogFunctionalLocation] CHECK CONSTRAINT [FK_SummaryLogFunctionalLocation_FuncationalLocation]
GO
/****** Object:  ForeignKey [FK_SummaryLogFunctionalLocation_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogFunctionalLocation_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogFunctionalLocation] CHECK CONSTRAINT [FK_SummaryLogFunctionalLocation_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SummaryLogFunctionalLocationList_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogFunctionalLocationList]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogFunctionalLocationList_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogFunctionalLocationList] CHECK CONSTRAINT [FK_SummaryLogFunctionalLocationList_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SummaryLogRead_SummaryLog]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogRead]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogRead_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogRead] CHECK CONSTRAINT [FK_SummaryLogRead_SummaryLog]
GO
/****** Object:  ForeignKey [FK_SummaryLogRead_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[SummaryLogRead]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogRead_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SummaryLogRead] CHECK CONSTRAINT [FK_SummaryLogRead_User]
GO
/****** Object:  ForeignKey [FK_Tag_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Site]
GO
/****** Object:  ForeignKey [FK_TagGroup_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TagGroup]  WITH CHECK ADD  CONSTRAINT [FK_TagGroup_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[TagGroup] CHECK CONSTRAINT [FK_TagGroup_Site]
GO
/****** Object:  ForeignKey [FK_TagGroupAssociation_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TagGroupAssociation]  WITH CHECK ADD  CONSTRAINT [FK_TagGroupAssociation_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TagGroupAssociation] CHECK CONSTRAINT [FK_TagGroupAssociation_Tag]
GO
/****** Object:  ForeignKey [FK_TagGroupAssociation_TagGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TagGroupAssociation]  WITH CHECK ADD  CONSTRAINT [FK_TagGroupAssociation_TagGroup] FOREIGN KEY([TagGroupId])
REFERENCES [dbo].[TagGroup] ([Id])
GO
ALTER TABLE [dbo].[TagGroupAssociation] CHECK CONSTRAINT [FK_TagGroupAssociation_TagGroup]
GO
/****** Object:  ForeignKey [fk_TargetAlert_AcknowledgedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert]  WITH CHECK ADD  CONSTRAINT [fk_TargetAlert_AcknowledgedUser] FOREIGN KEY([AcknowledgedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TargetAlert] CHECK CONSTRAINT [fk_TargetAlert_AcknowledgedUser]
GO
/****** Object:  ForeignKey [FK_TargetAlert_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlert_FunctionalLocation] FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[TargetAlert] CHECK CONSTRAINT [FK_TargetAlert_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_TargetAlert_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlert_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetAlert] CHECK CONSTRAINT [FK_TargetAlert_Tag]
GO
/****** Object:  ForeignKey [FK_TargetAlert_TargetDefinition]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlert_TargetDefinition] FOREIGN KEY([TargetDefinitionID])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetAlert] CHECK CONSTRAINT [FK_TargetAlert_TargetDefinition]
GO
/****** Object:  ForeignKey [FK_TargetAlert_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlert]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlert_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TargetAlert] CHECK CONSTRAINT [FK_TargetAlert_User]
GO
/****** Object:  ForeignKey [FK_TargetAlertResponse_Comment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlertResponse_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[TargetAlertResponse] CHECK CONSTRAINT [FK_TargetAlertResponse_Comment]
GO
/****** Object:  ForeignKey [FK_TargetAlertResponse_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlertResponse_FunctionalLocation] FOREIGN KEY([ResponsibleFunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[TargetAlertResponse] CHECK CONSTRAINT [FK_TargetAlertResponse_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_TargetAlertResponse_TargetAlert]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetAlertResponse]  WITH CHECK ADD  CONSTRAINT [FK_TargetAlertResponse_TargetAlert] FOREIGN KEY([TargetAlertId])
REFERENCES [dbo].[TargetAlert] ([ID])
GO
ALTER TABLE [dbo].[TargetAlertResponse] CHECK CONSTRAINT [FK_TargetAlertResponse_TargetAlert]
GO
/****** Object:  ForeignKey [FK_TargetDefinition_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinition_FunctionalLocation] FOREIGN KEY([FunctionalLocationID])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinition] CHECK CONSTRAINT [FK_TargetDefinition_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_TargetDefinition_Schedule]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinition_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinition] CHECK CONSTRAINT [FK_TargetDefinition_Schedule]
GO
/****** Object:  ForeignKey [FK_TargetDefinition_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinition_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinition] CHECK CONSTRAINT [FK_TargetDefinition_Tag]
GO
/****** Object:  ForeignKey [FK_TargetDefinition_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinition]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinition_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinition] CHECK CONSTRAINT [FK_TargetDefinition_User]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionAssociation_ChildTargetAssociation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionAssociation]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionAssociation_ChildTargetAssociation] FOREIGN KEY([ChildTargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionAssociation] CHECK CONSTRAINT [FK_TargetDefinitionAssociation_ChildTargetAssociation]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionAssociation_ParentTargetAssociation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionAssociation]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionAssociation_ParentTargetAssociation] FOREIGN KEY([ParentTargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionAssociation] CHECK CONSTRAINT [FK_TargetDefinitionAssociation_ParentTargetAssociation]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionAutoReApprovalConfiguration_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionAutoReApprovalConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionAutoReApprovalConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionAutoReApprovalConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionAutoReApprovalConfiguration_Site]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionComment_Comment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionComment]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionComment_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionComment] CHECK CONSTRAINT [FK_TargetDefinitionComment_Comment]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionComment_TargetDefinition]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionComment]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionComment_TargetDefinition] FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionComment] CHECK CONSTRAINT [FK_TargetDefinitionComment_TargetDefinition]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionReadWriteTagConfiguration_GapUnitValue_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_GapUnitValue_Tag] FOREIGN KEY([GapUnitValueTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_GapUnitValue_Tag]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionReadWriteTagConfiguration_Max_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Max_Tag] FOREIGN KEY([MaxTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Max_Tag]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionReadWriteTagConfiguration_Min_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Min_Tag] FOREIGN KEY([MinTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Min_Tag]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionReadWriteTagConfiguration_Target_Tag]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Target_Tag] FOREIGN KEY([TargetTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_Target_Tag]
GO
/****** Object:  ForeignKey [FK_TargetDefinitionReadWriteTagConfiguration_TargetDefId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_TargetDefId] FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration] CHECK CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_TargetDefId]
GO
/****** Object:  ForeignKey [FK_TargetDefinition_Id]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TargetDefinitionState]  WITH CHECK ADD  CONSTRAINT [FK_TargetDefinition_Id] FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO
ALTER TABLE [dbo].[TargetDefinitionState] CHECK CONSTRAINT [FK_TargetDefinition_Id]
GO
/****** Object:  ForeignKey [FK_TradeChecklist_AreaManagerApprovalLastModifiedId_LastModifiedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklist_AreaManagerApprovalLastModifiedId_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklist] CHECK CONSTRAINT [FK_TradeChecklist_AreaManagerApprovalLastModifiedId_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_TradeChecklist_ConstFieldMaintCoordApprovalLastModifiedId_LastModifiedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklist_ConstFieldMaintCoordApprovalLastModifiedId_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklist] CHECK CONSTRAINT [FK_TradeChecklist_ConstFieldMaintCoordApprovalLastModifiedId_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_TradeChecklist_FormGN1Id]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklist_FormGN1Id] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklist] CHECK CONSTRAINT [FK_TradeChecklist_FormGN1Id]
GO
/****** Object:  ForeignKey [FK_TradeChecklist_LastModifiedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklist_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklist] CHECK CONSTRAINT [FK_TradeChecklist_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_TradeChecklist_OpsCoordApprovalLastModifiedId_LastModifiedUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklist_OpsCoordApprovalLastModifiedId_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklist] CHECK CONSTRAINT [FK_TradeChecklist_OpsCoordApprovalLastModifiedId_LastModifiedUser]
GO
/****** Object:  ForeignKey [FK_TradeChecklistHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TradeChecklistHistory]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklistHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TradeChecklistHistory] CHECK CONSTRAINT [FK_TradeChecklistHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_TrainingBlockFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation] CHECK CONSTRAINT [FK_TrainingBlockFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_TrainingBlockFunctionalLocation_TrainingBlock]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBlockFunctionalLocation_TrainingBlock] FOREIGN KEY([TrainingBlockId])
REFERENCES [dbo].[TrainingBlock] ([Id])
GO
ALTER TABLE [dbo].[TrainingBlockFunctionalLocation] CHECK CONSTRAINT [FK_TrainingBlockFunctionalLocation_TrainingBlock]
GO
/****** Object:  ForeignKey [FK_User_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
/****** Object:  ForeignKey [FK_UserGridLayout_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserGridLayout]  WITH CHECK ADD  CONSTRAINT [FK_UserGridLayout_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserGridLayout] CHECK CONSTRAINT [FK_UserGridLayout_User]
GO
/****** Object:  ForeignKey [FK_UserLoginHistory_Assignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserLoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistory_Assignment] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistory] CHECK CONSTRAINT [FK_UserLoginHistory_Assignment]
GO
/****** Object:  ForeignKey [FK_UserLoginHistory_Shift]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserLoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistory_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistory] CHECK CONSTRAINT [FK_UserLoginHistory_Shift]
GO
/****** Object:  ForeignKey [FK_UserLoginHistory_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserLoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistory] CHECK CONSTRAINT [FK_UserLoginHistory_User]
GO
/****** Object:  ForeignKey [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation] CHECK CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_UserLoginHistoryFunctionalLocation_UserLoginHistory]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_UserLoginHistory] FOREIGN KEY([UserLoginHistoryId])
REFERENCES [dbo].[UserLoginHistory] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistoryFunctionalLocation] CHECK CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_UserLoginHistory]
GO
/****** Object:  ForeignKey [FK_UserPreferences_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserPreferences_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPreferences] CHECK CONSTRAINT [FK_UserPreferences_User]
GO
/****** Object:  ForeignKey [FK_UserPrintPreference_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[UserPrintPreference]  WITH CHECK ADD  CONSTRAINT [FK_UserPrintPreference_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPrintPreference] CHECK CONSTRAINT [FK_UserPrintPreference_User]
GO
/****** Object:  ForeignKey [FK_GroupVisibility_SiteId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[VisibilityGroup]  WITH CHECK ADD  CONSTRAINT [FK_GroupVisibility_SiteId] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[VisibilityGroup] CHECK CONSTRAINT [FK_GroupVisibility_SiteId]
GO
/****** Object:  ForeignKey [FK_WorkAssignment_AutoInsertLogTemplate]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_WorkAssignment_AutoInsertLogTemplate] FOREIGN KEY([AutoInsertLogTemplateId])
REFERENCES [dbo].[LogTemplate] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignment] CHECK CONSTRAINT [FK_WorkAssignment_AutoInsertLogTemplate]
GO
/****** Object:  ForeignKey [FK_WorkAssignment_Role]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_WorkAssignment_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignment] CHECK CONSTRAINT [FK_WorkAssignment_Role]
GO
/****** Object:  ForeignKey [FK_WorkAssignment_Site]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignment]  WITH CHECK ADD  CONSTRAINT [FK_WorkAssignment_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignment] CHECK CONSTRAINT [FK_WorkAssignment_Site]
GO
/****** Object:  ForeignKey [FK_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation] CHECK CONSTRAINT [FK_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignmentFunctionalLocation] CHECK CONSTRAINT [FK_WorkAssignment]
GO
/****** Object:  ForeignKey [IDX_WorkAssignmentGroupVisibility_Group]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignmentVisibilityGroup]  WITH CHECK ADD  CONSTRAINT [IDX_WorkAssignmentGroupVisibility_Group] FOREIGN KEY([VisibilityGroupId])
REFERENCES [dbo].[VisibilityGroup] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignmentVisibilityGroup] CHECK CONSTRAINT [IDX_WorkAssignmentGroupVisibility_Group]
GO
/****** Object:  ForeignKey [IDX_WorkAssignmentGroupVisibility_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkAssignmentVisibilityGroup]  WITH CHECK ADD  CONSTRAINT [IDX_WorkAssignmentGroupVisibility_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[WorkAssignmentVisibilityGroup] CHECK CONSTRAINT [IDX_WorkAssignmentGroupVisibility_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_WorkPermit_ApprovedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermit_ApprovedByUserId] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermit] CHECK CONSTRAINT [FK_WorkPermit_ApprovedByUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermit_CraftOrTrade]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermit_CraftOrTrade] FOREIGN KEY([CraftOrTradeID])
REFERENCES [dbo].[CraftOrTrade] ([Id])
GO
ALTER TABLE [dbo].[WorkPermit] CHECK CONSTRAINT [FK_WorkPermit_CraftOrTrade]
GO
/****** Object:  ForeignKey [FK_WorkPermit_CreatedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermit_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermit] CHECK CONSTRAINT [FK_WorkPermit_CreatedByUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermit_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermit_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermit] CHECK CONSTRAINT [FK_WorkPermit_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkPermit_LastModifiedUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermit]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermit_LastModifiedUserId] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermit] CHECK CONSTRAINT [FK_WorkPermit_LastModifiedUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitAutoAssignmentConfigurationFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitAutoAssignmentConfigurationFunctionalLocation_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_WorkPermitCloseConfiguration_SiteId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitCloseConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitCloseConfiguration_SiteId] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitCloseConfiguration] CHECK CONSTRAINT [FK_WorkPermitCloseConfiguration_SiteId]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_AreaLabel]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_AreaLabel] FOREIGN KEY([AreaLabelId])
REFERENCES [dbo].[AreaLabel] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_AreaLabel]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_CreatedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_CreatedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_IssuedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_IssuedByUser] FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_IssuedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_PermitRequest]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_PermitRequest] FOREIGN KEY([PermitRequestId])
REFERENCES [dbo].[PermitRequestEdmonton] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_PermitRequest]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_PermitRequestCreatedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_PermitRequestCreatedByUser] FOREIGN KEY([PermitRequestCreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_PermitRequestCreatedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmonton_WorkPermitEdmontonGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_WorkPermitEdmontonGroup]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN1]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN1]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN24]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN24]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN59]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN59]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN6]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN6]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN7]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN7]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_FormGN75A]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN75A]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_Id]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_Id] FOREIGN KEY([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_Id]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonDetails_TradeChecklist]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_TradeChecklist] FOREIGN KEY([FormGN1TradeChecklistId])
REFERENCES [dbo].[TradeChecklist] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] CHECK CONSTRAINT [FK_WorkPermitEdmontonDetails_TradeChecklist]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_FormGN24]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN24]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_FormGN59]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN59]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_FormGN6]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN6]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_FormGN7]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN7]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_FormGN75A]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_FormGN75A]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitEdmontonHistory_RequestedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmontonHistory_RequestedByUser] FOREIGN KEY([RequestedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] CHECK CONSTRAINT [FK_WorkPermitEdmontonHistory_RequestedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration] CHECK CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkPermitFunctionalLocationConfiguration_WorkAssignment]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitFunctionalLocationConfiguration] CHECK CONSTRAINT [FK_WorkPermitFunctionalLocationConfiguration_WorkAssignment]
GO
/****** Object:  ForeignKey [FK_WorkPermitGasTestElementInfo_GasTestElementId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitGasTestElementInfo_GasTestElementId] FOREIGN KEY([GasTestElementInfoId])
REFERENCES [dbo].[GasTestElementInfo] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo] CHECK CONSTRAINT [FK_WorkPermitGasTestElementInfo_GasTestElementId]
GO
/****** Object:  ForeignKey [FK_WorkPermitGasTestElementInfo_WorkPermitId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitGasTestElementInfo_WorkPermitId] FOREIGN KEY([WorkPermitId])
REFERENCES [dbo].[WorkPermit] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitGasTestElementInfo] CHECK CONSTRAINT [FK_WorkPermitGasTestElementInfo_WorkPermitId]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_CreatedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_CreatedByUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_Floc]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_Floc]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_IssuedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_IssuedByUser] FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_IssuedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_LastModifiedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_LastModifiedByUserId] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_LastModifiedByUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubeS_PermitRequest]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubeS_PermitRequest] FOREIGN KEY([PermitRequestId])
REFERENCES [dbo].[PermitRequestLubes] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubeS_PermitRequest]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_PermitRequestSubmittedByUserId]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_PermitRequestSubmittedByUserId] FOREIGN KEY([PermitRequestSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_PermitRequestSubmittedByUserId]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubes_WorkPermitLubesGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_WorkPermitLubesGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_WorkPermitLubesGroup]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubesHistory_IssuedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubesHistory_IssuedByUser] FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubesHistory] CHECK CONSTRAINT [FK_WorkPermitLubesHistory_IssuedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitLubesHistory_LastModifiedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubesHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubesHistory] CHECK CONSTRAINT [FK_WorkPermitLubesHistory_LastModifiedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontreal_PermitRequest]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontreal]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontreal_PermitRequest] FOREIGN KEY([PermitRequestId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontreal] CHECK CONSTRAINT [FK_WorkPermitMontreal_PermitRequest]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontreal_WorkPermitMontrealGroup]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontreal]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontreal_WorkPermitMontrealGroup] FOREIGN KEY([RequestedByGroupId])
REFERENCES [dbo].[WorkPermitMontrealGroup] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontreal] CHECK CONSTRAINT [FK_WorkPermitMontreal_WorkPermitMontrealGroup]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontreal_Id]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontreal_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealDetails] CHECK CONSTRAINT [FK_WorkPermitMontreal_Id]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealFunctionalLocation_WorkPermitMontreal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation] CHECK CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_WorkPermitMontreal]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealPermitAttributeAssociation_PermitAttribute]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_PermitAttribute] FOREIGN KEY([PermitAttributeId])
REFERENCES [dbo].[PermitAttribute] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation] CHECK CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_PermitAttribute]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealPermitAttributeAssociation_WorkPermitMontreal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealPermitAttributeAssociation] CHECK CONSTRAINT [FK_WorkPermitMontrealPermitAttributeAssociation_WorkPermitMontreal]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealRequestDetails_Id]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealRequestDetails_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealRequestDetails] CHECK CONSTRAINT [FK_WorkPermitMontrealRequestDetails_Id]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealRequestDetails_RequestedByUser]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealRequestDetails_RequestedByUser] FOREIGN KEY([RequestedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealRequestDetails] CHECK CONSTRAINT [FK_WorkPermitMontrealRequestDetails_RequestedByUser]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_User]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_User]
GO
/****** Object:  ForeignKey [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_WorkPermitMontreal]    Script Date: 08/24/2014 11:51:22 ******/
ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_WorkPermitMontreal]
GO



