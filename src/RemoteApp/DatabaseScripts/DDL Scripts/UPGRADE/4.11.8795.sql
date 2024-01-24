CREATE TABLE [dbo].[FormGN75B] (
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[CreatedDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[ClosedDateTime] datetime NULL,
[Deleted] bit NOT NULL DEFAULT ((0)),
[BlindsRequired] bit NOT NULL,
[LockBoxNumber] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LockBoxLocation] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PathToSchematic] varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SchematicImage] varbinary(MAX) NULL,
CONSTRAINT [PK_FormGN75B_Id]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_FormGN75B_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),
CONSTRAINT [FK_FormGN75B_CreateUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_FormGN75B_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
)
ON [PRIMARY];
GO

ALTER TABLE dbo.DocumentLink
	ADD [FormGN75BId] bigint SPARSE NULL;
ALTER TABLE [dbo].[DocumentLink]
 ADD CONSTRAINT [FK_DocumentLink_FormGN75B] FOREIGN KEY ([FormGN75BId])
		REFERENCES [dbo].[FormGN75B] ([Id]);
GO
		
	
CREATE TABLE [dbo].[FormGN75BIsolationItem] (
[Id] bigint IDENTITY(1, 1) NOT FOR REPLICATION NOT NULL,
[FormGN75BId] bigint NOT NULL,
[SortOrder] int NOT NULL,
[IsolationType] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LocationOfEnergyIsolation] varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Deleted] bit NOT NULL DEFAULT ((0)),
CONSTRAINT [PK_FormGN75IsolationItem_Id]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_FormGN75IsolationItem_FormGN75]
FOREIGN KEY ([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ( [Id] )
)
GO

CREATE TABLE [dbo].[FormGN75BHistory] (
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[ClosedDateTime] datetime NULL,
[BlindsRequired] bit NOT NULL,
[LockBoxNumber] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LockBoxLocation] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[FormGN75BHistory] 
ADD  FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
GO
ALTER TABLE [dbo].[FormGN75BHistory] 
ADD  FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )
GO

CREATE CLUSTERED INDEX [IDX_FormGN75BHistory_Id]
ON [dbo].[FormGN75BHistory]
([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO



GO

