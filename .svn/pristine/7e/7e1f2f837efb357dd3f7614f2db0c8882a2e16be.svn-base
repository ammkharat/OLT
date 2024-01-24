
CREATE TABLE [dbo].[OpmExcursion](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ExcursionId] [bigint] NOT NULL,
	[ToeVersion] [bigint] NOT NULL,
	[HistorianTag] nvarchar(255) NOT NULL,
	[FunctionalLocation] nvarchar(255) NOT NULL,
	[ToeName] nvarchar(255) NOT NULL,
	[ToeType] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,	
	[EndDateTime] [datetime] NULL,	
	[UnitOfMeasure] nvarchar(15) NOT NULL,
	[Peak] decimal(18,6) NOT NULL,
	[Average] decimal(18,6)NOT NULL,
	[Duration] int NOT NULL,
	[OpmTrendUrl] nvarchar(400) NOT NULL,
	[IlpNumber] [bigint] NULL,
	[EngineerComments] nvarchar(4000) NULL,
	[ReasonCode] nvarchar(255) NOT NULL,
	[LastUpdatedDateTime] datetime NOT NULL,	
 CONSTRAINT [PK_OpmExcursion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[OpmToeDefinition](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ToeVersion] [bigint] NOT NULL,
	[HistorianTag] nvarchar(255) NOT NULL,
	[ToeVersionPublishDate] [datetime] NOT NULL,	
	[ToeName] nvarchar(50) NOT NULL,
	[FunctionalLocation] nvarchar(255) NOT NULL,
	[ToeType] [int] NOT NULL,
	[LimitValue] nvarchar(2000) NOT NULL,
	[CausesDescription] nvarchar(2000) NULL,
	[ConsequencesDescription] nvarchar(2000) NULL,
	[CorrectiveActionDescription] nvarchar(2000) NULL,
	[ReferenceDocuments] nvarchar(400) NULL,
CONSTRAINT [PK_OpmToeDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[OpmExcursionResponse](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ExcursionId] [bigint] NOT NULL,
	[ToeVersion] [bigint] NOT NULL,
	[HistorianTag] nvarchar(255) NOT NULL,
	[UserName] nvarchar(30) NOT NULL,	
	[FirstName] nvarchar(30) NOT NULL,
	[LastName] nvarchar(30) NOT NULL,
	[Response] nvarchar(4000) NULL,
	[LastModifiedDateTime] datetime NOT NULL,	
CONSTRAINT [PK_OpmExcursionResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[OpmToeDefinitionComment](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ToeVersion] [bigint] NOT NULL,
	[HistorianTag] nvarchar(255) NOT NULL,
	[UserName] nvarchar(30) NOT NULL,	
	[FirstName] nvarchar(30) NOT NULL,
	[LastName] nvarchar(30) NOT NULL,
	[Comment] nvarchar(255) Not NULL,
	[LastModifiedDateTime] datetime NOT NULL,	
CONSTRAINT [PK_OpmToeDefinitionComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]




GO

