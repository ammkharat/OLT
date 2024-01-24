DROP TABLE dbo.UncRoot
GO

CREATE TABLE [dbo].[DocumentRootPathConfiguration] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[PathName] varchar(50) NOT NULL,
[UncPath] varchar(200) NOT NULL,
[Deleted] bit NOT NULL DEFAULT ((0)),
CONSTRAINT [PK_DocumentRootPathConfiguration]
PRIMARY KEY CLUSTERED ([Id] )
)
ON [PRIMARY];
GO

CREATE TABLE dbo.DocumentRootPathFunctionalLocation (
	[DocumentRootPathId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
)
GO

ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]
ADD  CONSTRAINT [FK_DocumentRootPathFloc_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )
GO

ALTER TABLE [dbo].[DocumentRootPathFunctionalLocation]
ADD  CONSTRAINT [FK_DocumentRootPathFloc_DocumentRoot]
FOREIGN KEY ([DocumentRootPathId])
REFERENCES [dbo].[DocumentRootPathConfiguration] ( [Id] )
GO



GO
