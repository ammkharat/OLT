/****** Object:  Table [dbo].[FormMontrealCsd]    Script Date: 09/16/2014 13:50:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormMontrealCsd](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[HasBeenCommunicated] [bit] NOT NULL,
	[HasAttachments] [bit] NOT NULL,
	[CsdReason] [varchar](255)NOT NULL,	
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
 CONSTRAINT [PK_FormMontrealCsd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormMontrealCsd]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsd_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsd] CHECK CONSTRAINT [FK_FormMontrealCsd_CreatedByUser]
GO

ALTER TABLE [dbo].[FormMontrealCsd]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsd_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsd] CHECK CONSTRAINT [FK_FormMontrealCsd_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormMontrealCsd] ADD  DEFAULT ((0)) FOR [Deleted]
GO



/****** Object:  Table [dbo].[FormMontrealCsdApproval]    Script Date: 09/16/2014 13:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormMontrealCsdApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormMontrealCsdId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormMontrealCsdApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormMontrealCsdApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsdApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsdApproval] CHECK CONSTRAINT [FK_FormMontrealCsdApproval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormMontrealCsdApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsdApproval_FormMontrealCsd] FOREIGN KEY([FormMontrealCsdId])
REFERENCES [dbo].[FormMontrealCsd] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsdApproval] CHECK CONSTRAINT [FK_FormMontrealCsdApproval_FormMontrealCsd]
GO


/****** Object:  Table [dbo].[FormMontrealCsdFunctionalLocation]    Script Date: 09/16/2014 13:56:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormMontrealCsdFunctionalLocation](
	[FormMontrealCsdId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormMontrealCsdFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormMontrealCsdId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormMontrealCsdFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsdFunctionalLocation_FormMontrealCsd] FOREIGN KEY([FormMontrealCsdId])
REFERENCES [dbo].[FormMontrealCsd] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsdFunctionalLocation] CHECK CONSTRAINT [FK_FormMontrealCsdFunctionalLocation_FormMontrealCsd]
GO

ALTER TABLE [dbo].[FormMontrealCsdFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsdFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsdFunctionalLocation] CHECK CONSTRAINT [FK_FormMontrealCsdFunctionalLocation_FunctionalLocation]



/****** Object:  Table [dbo].[FormMontrealCsdHistory]    Script Date: 09/16/2014 13:57:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormMontrealCsdHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[HasBeenCommunicated] [bit] NOT NULL,
	[HasAttachments] [bit] NOT NULL,
	[CsdReason] [varchar](255)NOT NULL,	
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormMontrealCsdHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormMontrealCsdHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormMontrealCsdHistory] CHECK CONSTRAINT [FK_FormMontrealCsdHistory_LastModifiedByUser]
GO

Alter Table DocumentLink add FormMontrealCsdId bigint sparse null
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormMontrealCsd] FOREIGN KEY([FormMontrealCsdId])
REFERENCES [dbo].[FormMontrealCsd] ([Id])
GO



GO

