
/****** Object:  Table [dbo].[FormGN75BSarniaApproval]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BSarniaApproval') 

BEGIN


CREATE TABLE [dbo].[FormGN75BSarnia](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[BlindsRequired] [bit] NOT NULL,
	[LockBoxNumber] [varchar](30) NULL,
	[LockBoxLocation] [varchar](30) NULL,
	[PathToSchematic] [varchar](max) NULL,
	[SchematicImage] [varbinary](max) NULL,
	[Location] [varchar](50) NULL,
	[EquipmentType] [varchar](50) NULL,
	[TemplateID] [bigint] NULL,
	[DeadLeg] [bit] NOT NULL,
	[DeadLegRisk] [bit] NOT NULL,
	[SpecialPrecautions] [varchar](250) NOT NULL,
	[siteid] [bigint] NULL,
 CONSTRAINT [PK_FormGN75BSarnia_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormGN75BSarnia] ADD  DEFAULT ((0)) FOR [Deleted]


ALTER TABLE [dbo].[FormGN75BSarnia] ADD  DEFAULT ('0') FOR [DeadLeg]


ALTER TABLE [dbo].[FormGN75BSarnia] ADD  DEFAULT ('0') FOR [DeadLegRisk]


ALTER TABLE [dbo].[FormGN75BSarnia] ADD  DEFAULT (NULL) FOR [SpecialPrecautions]


ALTER TABLE [dbo].[FormGN75BSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BSarnia_CreateUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGN75BSarnia] CHECK CONSTRAINT [FK_FormGN75BSarnia_CreateUser]


ALTER TABLE [dbo].[FormGN75BSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BSarnia_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[FormGN75BSarnia] CHECK CONSTRAINT [FK_FormGN75BSarnia_Floc]


ALTER TABLE [dbo].[FormGN75BSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BSarnia_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGN75BSarnia] CHECK CONSTRAINT [FK_FormGN75BSarnia_LastModifiedUser]


END

