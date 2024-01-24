


CREATE TABLE [dbo].[LogDefinitionFunctionalLocation](
	[LogDefinitionId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_LogDefinitionFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[LogDefinitionId] ASC,
		[FunctionalLocationId] ASC
	)
)
GO

ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]
ADD CONSTRAINT [FK_LogDefinitionFunctionalLocation_LogDefinition]
FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO

ALTER TABLE [dbo].[LogDefinitionFunctionalLocation]
ADD CONSTRAINT [FK_LogDefinitionFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

INSERT INTO [dbo].LogDefinitionFunctionalLocation
SELECT Id, FunctionalLocationId FROM [dbo].[LogDefinition]
GO

ALTER TABLE [dbo].[LogDefinition]
DROP CONSTRAINT FK_LogDefinition_FunctionalLocation
GO

DROP INDEX IDX_LOGDEFINITION_FLOC ON [dbo].[LogDefinition]
GO

alter table [dbo].[LogDefinition] drop column FunctionalLocationId
GO


GO

GO
