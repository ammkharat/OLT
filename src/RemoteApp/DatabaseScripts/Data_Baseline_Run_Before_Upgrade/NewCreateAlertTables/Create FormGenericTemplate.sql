IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplate]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[FormGenericTemplate](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[DepartmentId] [int] NOT NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[siteid] [bigint] NULL,
	[FormTypeID] [bigint] NULL,
 CONSTRAINT [PK_FormGenericTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormGenericTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplate_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGenericTemplate] CHECK CONSTRAINT [FK_FormGenericTemplate_CreatedByUser]


ALTER TABLE [dbo].[FormGenericTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplate_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGenericTemplate] CHECK CONSTRAINT [FK_FormGenericTemplate_LastModifiedUser]


ALTER TABLE [dbo].[FormGenericTemplate] ADD  DEFAULT ((0)) FOR [Deleted]


End
