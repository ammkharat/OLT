CREATE TABLE [dbo].[ShiftHandoverConfiguration](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Deleted] bit NOT NULL
			
	CONSTRAINT [PK_ShiftHandoverConfiguration] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[ShiftHandoverConfiguration]
ADD CONSTRAINT [FK_ShiftHandoverConfiguration_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

ALTER TABLE [dbo].[ShiftHandoverConfiguration]
ADD CONSTRAINT [FK_ShiftHandoverConfiguration_Role] 
FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])

GO

CREATE TABLE [dbo].[ShiftHandoverQuestion](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[ShiftHandoverConfigurationId] [bigint] NOT NULL,
	[DisplayOrder] int NOT NULL,
	[Text] [varchar](150) NOT NULL,
	[HelpText] varchar(max) NULL,
	[Deleted] bit NOT NULL

	CONSTRAINT [PK_ShiftHandoverQuestion] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[ShiftHandoverQuestion]
ADD CONSTRAINT [FK_ShiftHandoverQuestion_ShiftHandoverConfiguration] 
FOREIGN KEY([ShiftHandoverConfigurationId])
REFERENCES [dbo].[ShiftHandoverConfiguration] ([Id])

GO

CREATE TABLE [dbo].[ShiftHandoverQuestionnaire](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[ShiftHandoverConfigurationName] varchar(50) NOT NULL,
	[ShiftId] bigint NOT NULL,
	[WorkAssignmentId] bigint NULL,
	[CreatedByUserId] bigint NOT NULL,
	[CreatedDateTime] datetime NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL
				
	CONSTRAINT [PK_ShiftHandoverQuestionnaire] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]
ADD CONSTRAINT [FK_ShiftHandoverQuestionnaire_Shift] 
FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])

GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaire]
ADD CONSTRAINT [FK_ShiftHandoverQuestionnaire_WorkUnitAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO

CREATE TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation](
	[ShiftHandoverQuestionnaireId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_ShiftHandoverQuestionnaireFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[ShiftHandoverQuestionnaireId] ASC,
		[FunctionalLocationId] ASC
	)		
)

GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
ADD CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_ShiftHandoverQuestionnaire] 
FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])

CREATE TABLE [dbo].[ShiftHandoverAnswer](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[ShiftHandoverQuestionnaireId] bigint NOT NULL,
	[Answer] bit NOT NULL,
	[Comments] varchar(2048) NULL,
	[QuestionText] varchar(150) NOT NULL,
	[QuestionDisplayOrder] int NOT NULL,
	[ShiftHandoverQuestionId] bigint NOT NULL
				
	CONSTRAINT [PK_ShiftHandoverAnswer] PRIMARY KEY ([Id] ASC)		
)

GO

ALTER TABLE [dbo].[ShiftHandoverAnswer]
ADD CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire] 
FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])

GO

ALTER TABLE [dbo].[ShiftHandoverAnswer]
ADD CONSTRAINT [FK_ShiftHandoverAnswer_ShiftHandoverQuestion] 
FOREIGN KEY([ShiftHandoverQuestionId])
REFERENCES [dbo].[ShiftHandoverQuestion] ([Id])

GO

GO


