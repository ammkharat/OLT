CREATE TABLE [dbo].[CokerCardHistory] (
[Id] bigint IDENTITY(100, 1) NOT NULL,
[CokerCardId] bigint NOT NULL,
[LastModifiedUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
CONSTRAINT [PK_CokerCardHistory]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_dbo_CokerCardHistory_LastModifiedUser]
FOREIGN KEY ([LastModifiedUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_dbo_CokerCardHistory_CokerCard]
FOREIGN KEY ([CokerCardId])
REFERENCES [dbo].[CokerCard] ( [Id] )
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_CokerCardHistory_CokerCardId]
ON [dbo].[CokerCardHistory]
([CokerCardId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[CokerCardDrumEntryHistory] (
[Id] bigint IDENTITY(100, 1) NOT NULL,
[CokerCardHistoryId] bigint NOT NULL,
[DrumConfigurationId] bigint NOT NULL,
[DrumName] varchar(40) NOT NULL,
[Comments] varchar(200) NULL,
CONSTRAINT [PK_dbo_CokerCardDrumEntryHistory]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardHistory]
FOREIGN KEY ([CokerCardHistoryId])
REFERENCES [dbo].[CokerCardHistory] ( [Id] ),
CONSTRAINT [FK_dbo_CokerCardDrumEntryHistory_CokerCardDrum]
FOREIGN KEY ([DrumConfigurationId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ( [Id] )
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_CokerCardDrumEntryHistory_CokerCardHistory]
ON [dbo].[CokerCardDrumEntryHistory]
([CokerCardHistoryId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO


CREATE TABLE [dbo].[CokerCardCycleStepEntryHistory] (
[Id] bigint IDENTITY(100, 1) NOT NULL,
[CokerCardDrumEntryHistoryId] bigint NOT NULL,
[CycleStepConfigurationId] bigint NOT NULL,
[CycleStepName] varchar(40) NOT NULL,
[StartTime] datetime NULL,
[EndTime] datetime NULL,
CONSTRAINT [PK_dbo_CokerCardCycleStepEntryHistory]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_DrumHistory]
FOREIGN KEY ([CokerCardDrumEntryHistoryId])
REFERENCES [dbo].[CokerCardDrumEntryHistory] ( [Id] ),
CONSTRAINT [FK_dbo_CokerCardCycleStepEntryHistory_CycleStepConfig]
FOREIGN KEY ([CycleStepConfigurationId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ( [Id] )
)
ON [PRIMARY];
GO


CREATE NONCLUSTERED INDEX [IDX_CokerCardCycleStepEntryHistory_DrumHistory]
ON [dbo].[CokerCardCycleStepEntryHistory]
([CokerCardDrumEntryHistoryId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO
GO
