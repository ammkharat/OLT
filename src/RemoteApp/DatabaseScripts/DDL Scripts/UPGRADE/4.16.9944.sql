

/****** Object:  Table [dbo].[FormLubesCsd]    Script Date: 08/19/2014 13:12:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesCsd](
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
 CONSTRAINT [PK_FormLubesCsd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormLubesCsd]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsd_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsd] CHECK CONSTRAINT [FK_FormLubesCsd_CreatedByUser]
GO

ALTER TABLE [dbo].[FormLubesCsd]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsd_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsd] CHECK CONSTRAINT [FK_FormLubesCsd_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormLubesCsd] ADD  DEFAULT ((0)) FOR [Deleted]
GO


Alter Table DocumentLink add FormLubesCsdId bigint sparse null
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormLubesCsd] FOREIGN KEY([FormLubesCsdId])
REFERENCES [dbo].[FormLubesCsd] ([Id])
GO


/****** Object:  Table [dbo].[FormLubesCsdApproval]    Script Date: 08/19/2014 13:12:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesCsdApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormLubesCsdId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormLubesCsdApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormLubesCsdApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdApproval] CHECK CONSTRAINT [FK_FormLubesCsdApproval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormLubesCsdApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdApproval_FormLubesCsd] FOREIGN KEY([FormLubesCsdId])
REFERENCES [dbo].[FormLubesCsd] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdApproval] CHECK CONSTRAINT [FK_FormLubesCsdApproval_FormLubesCsd]
GO



/****** Object:  Table [dbo].[FormLubesCsdFunctionalLocation]    Script Date: 08/19/2014 13:12:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormLubesCsdFunctionalLocation](
	[FormLubesCsdId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormLubesCsdFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormLubesCsdId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormLubesCsdFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdFunctionalLocation_FormLubesCsd] FOREIGN KEY([FormLubesCsdId])
REFERENCES [dbo].[FormLubesCsd] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdFunctionalLocation] CHECK CONSTRAINT [FK_FormLubesCsdFunctionalLocation_FormLubesCsd]
GO

ALTER TABLE [dbo].[FormLubesCsdFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdFunctionalLocation] CHECK CONSTRAINT [FK_FormLubesCsdFunctionalLocation_FunctionalLocation]
GO




/****** Object:  Table [dbo].[FormLubesCsdHistory]    Script Date: 08/19/2014 13:12:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesCsdHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormLubesCsdHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdHistory] CHECK CONSTRAINT [FK_FormLubesCsdHistory_LastModifiedByUser]
GO


  




GO

