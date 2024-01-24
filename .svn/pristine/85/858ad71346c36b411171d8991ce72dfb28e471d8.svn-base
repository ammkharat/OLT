CREATE TABLE [dbo].[RestrictionLocation] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[Name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] DATETIME NOT NULL,
DELETED bit NOT NULL,
CONSTRAINT [PK_RestrictionLocation]
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[RestrictionLocationWorkAssignment] (
[RestrictionLocationId] bigint NOT NULL,
[WorkAssignmentId] bigint NOT NULL,
CONSTRAINT [FK_RestrictionLocationWorkAssignment_Restriction]
FOREIGN KEY ([RestrictionLocationId])
REFERENCES [dbo].[RestrictionLocation] ( [Id] ),
CONSTRAINT [PK_RestrictionLocationWorkAssignment]
PRIMARY KEY CLUSTERED ([RestrictionLocationId] ASC, [WorkAssignmentId] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_RestrictionLocationWorkAssignment_WorkAssignment]
FOREIGN KEY ([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ( [Id] )
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[RestrictionLocationItem] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[Name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
[ParentItemId] bigint NULL,
[RestrictionLocationId] bigint NOT NULL,
CONSTRAINT [PK_RestrictionLocationItem]
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_RestrictionLocationItem_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),
CONSTRAINT [FK_RestrictionLocationItem_RestrictionLocation]
FOREIGN KEY ([RestrictionLocationId])
REFERENCES [dbo].[RestrictionLocation] ( [Id] ),
CONSTRAINT [FK_RestrictionLocationItem_Parent]
FOREIGN KEY ([ParentItemId])
REFERENCES [dbo].[RestrictionLocationItem] ( [Id] )
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[RestrictionLocationItemReasonCode] (
[RestrictionLocationItemId] bigint NOT NULL,
[RestrictionReasonCodeId] bigint NOT NULL,
CONSTRAINT [PK_RestrictionLocationItemReasonCode]
PRIMARY KEY CLUSTERED ([RestrictionLocationItemId], [RestrictionReasonCodeId] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_RestrictionLocationItemReasonCode_Item]
FOREIGN KEY ([RestrictionLocationItemId])
REFERENCES [dbo].[RestrictionLocationItem] ( [Id] ),
CONSTRAINT [FK_RestrictionLocationItemReasonCode_ReasonCode]
FOREIGN KEY ([RestrictionReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ( [Id] )
)
ON [PRIMARY];
GO