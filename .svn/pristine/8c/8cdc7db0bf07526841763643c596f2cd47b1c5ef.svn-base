CREATE TABLE [dbo].[SummaryLogCustomFieldGroup](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] varchar(100) NOT NULL
				
	CONSTRAINT [PK_SummaryLogCustomFieldGroup] PRIMARY KEY ([Id] ASC)		
)

GO

-- ---------------------------------------------------------------------------

CREATE TABLE [dbo].[SummaryLogCustomFieldGroupFunctionalLocation](
	[SummaryLogCustomFieldGroupId] [bigint] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
)

GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroupFunctionalLocation]
ADD CONSTRAINT [FK_SummaryLogCustomFieldGroupFunctionalLocation_SummaryLogCustomFieldGroup] 
FOREIGN KEY([SummaryLogCustomFieldGroupId])
REFERENCES [dbo].[SummaryLogCustomFieldGroup] ([Id])

GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroupFunctionalLocation]
ADD CONSTRAINT [FK_SummaryLogCustomFieldGroupFunctionalLocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

-- ---------------------------------------------------------------------------

CREATE TABLE [dbo].[SummaryLogCustomField](
	[SummaryLogCustomFieldGroupId] [bigint] NOT NULL,
	[Name] varchar(20) NOT NULL,
	[DisplayOrder] int NOT NULL
)

GO

ALTER TABLE [dbo].[SummaryLogCustomField]
ADD CONSTRAINT [FK_SummaryLogCustomField_SummaryLogCustomFieldGroup] 
FOREIGN KEY([SummaryLogCustomFieldGroupId])
REFERENCES [dbo].[SummaryLogCustomFieldGroup] ([Id])

GO

GO
