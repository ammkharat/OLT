DROP TABLE [dbo].[FormGN75BHistory];
GO

CREATE TABLE [dbo].[FormGN75BHistory] (
[Id] bigint NOT NULL,
[FormStatusId] int NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[ClosedDateTime] datetime NULL,
[BlindsRequired] bit NOT NULL,
[LockBoxNumber] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LockBoxLocation] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Isolations] varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SchematicImage] varbinary(MAX) NULL,
[DocumentLinks] varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FunctionalLocation] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
CONSTRAINT [FK_FormGN75BHistory_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO



GO

