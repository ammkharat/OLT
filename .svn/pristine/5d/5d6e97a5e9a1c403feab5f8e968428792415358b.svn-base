
/****** Object:  Table [dbo].[QuestionnaireConfiguration]    Script Date: 11/21/2014 08:25:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuestionnaireConfiguration](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Version] [int] NOT NULL,	
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_QuestionnaireConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[QuestionnaireConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO

ALTER TABLE [dbo].[QuestionnaireConfiguration] CHECK CONSTRAINT [FK_QuestionnaireConfiguration_Site]
SET ANSI_PADDING OFF
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuestionnaireSection](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[QuestionnaireConfigurationId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,	
	[PercentageWeighting] [decimal](5, 2) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_QuestionnaireSection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[QuestionnaireSection]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireSection_QuestionnaireConfiguration] FOREIGN KEY([QuestionnaireConfigurationId])
REFERENCES [dbo].[QuestionnaireConfiguration] ([Id])
GO

ALTER TABLE [dbo].[QuestionnaireSection] CHECK CONSTRAINT [FK_QuestionnaireSection_QuestionnaireConfiguration]
SET ANSI_PADDING OFF
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuestionnaireSectionQuestion](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[QuestionnaireSectionId] [bigint] NOT NULL,
	[QuestionnaireConfigurationId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,	
	[Weight] [int] NOT NULL,
	[QuestionText] [varchar](150) NOT NULL,
CONSTRAINT [PK_QuestionnaireSectionQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[QuestionnaireSectionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireSectionQuestion_QuestionnaireSection] FOREIGN KEY([QuestionnaireSectionId])
REFERENCES [dbo].[QuestionnaireSection]([Id])
GO

ALTER TABLE [dbo].[QuestionnaireSectionQuestion] CHECK CONSTRAINT [FK_QuestionnaireSectionQuestion_QuestionnaireSection]
SET ANSI_PADDING OFF

GO
ALTER TABLE [dbo].[QuestionnaireSectionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireSectionQuestion_QuestionnaireConfiguration] FOREIGN KEY([QuestionnaireConfigurationId])
REFERENCES [dbo].[QuestionnaireConfiguration] ([Id])
GO

ALTER TABLE [dbo].[QuestionnaireSectionQuestion] CHECK CONSTRAINT [FK_QuestionnaireSectionQuestion_QuestionnaireConfiguration]
SET ANSI_PADDING OFF
GO
GO



GO

