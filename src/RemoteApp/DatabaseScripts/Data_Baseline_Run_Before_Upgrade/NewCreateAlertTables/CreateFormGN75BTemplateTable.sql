
/****** Object:  Table [dbo].[FormGN75B]    Script Date: 6/13/2018 12:30:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BTemplate')
BEGIN

CREATE TABLE [dbo].[FormGN75BTemplate](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[PathToSchematic] [varchar](max) NULL,
	[SchematicImage] [varbinary](max) NULL,
	[Location] [varchar](100) NULL,
	[EquipmentType] [varchar](50) NULL,
	[siteid] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN75BTemplate_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]




ALTER TABLE [dbo].[FormGN75BTemplate] ADD  DEFAULT ((0)) FOR [Deleted]


ALTER TABLE [dbo].[FormGN75BTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BTemplate_CreateUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGN75BTemplate] CHECK CONSTRAINT [FK_FormGN75BTemplate_CreateUser]


ALTER TABLE [dbo].[FormGN75BTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BTemplate_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[FormGN75BTemplate] CHECK CONSTRAINT [FK_FormGN75BTemplate_Floc]


ALTER TABLE [dbo].[FormGN75BTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BTemplate_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGN75BTemplate] CHECK CONSTRAINT [FK_FormGN75BTemplate_LastModifiedUser]

end
