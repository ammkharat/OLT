CREATE TABLE [dbo].[ConfinedSpaceOssa] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[SiteId] bigint NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
[StartDateTime] datetime NOT NULL,
[EndDateTime] datetime NOT NULL,
[CreatedDateTime] datetime NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[Deleted] bit NOT NULL,
CONSTRAINT [ConfinedSpaceOssa_PK]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [ConfinedSpaceOssa_Site]
FOREIGN KEY ([SiteId])
REFERENCES [dbo].[Site] ( [Id] ),

CONSTRAINT [ConfinedSpaceOssa_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),

CONSTRAINT [ConfinedSpaceOssa_CreatedUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),

CONSTRAINT [ConfinedSpaceOssa_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
)
ON [PRIMARY];
GO




GO

