ALTER TABLE [dbo].[DocumentLink] 
DROP CONSTRAINT [FK_DocumentLink_FormLubesCsd];
GO

ALTER TABLE [dbo].[FormLubesCsdApproval] 
DROP CONSTRAINT [FK_FormLubesCsdApproval_FormLubesCsd];
GO

DROP TABLE [dbo].[FormLubesCsdFunctionalLocation];
GO

DROP TABLE [dbo].[FormLubesCsdHistory];
GO

DROP TABLE [dbo].[FormLubesCsd]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesCsd](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[Location] varchar(128) NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
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

ALTER TABLE [dbo].[FormLubesCsd]  WITH CHECK ADD CONSTRAINT [FK_FormLubesCsd_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsd]  WITH CHECK ADD CONSTRAINT [FK_FormLubesCsd_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsd] CHECK CONSTRAINT [FK_FormLubesCsd_CreatedByUser]
GO

ALTER TABLE [dbo].[FormLubesCsd]  WITH CHECK ADD CONSTRAINT [FK_FormLubesCsd_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsd] CHECK CONSTRAINT [FK_FormLubesCsd_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormLubesCsd] ADD  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormLubesCsd] FOREIGN KEY([FormLubesCsdId])
REFERENCES [dbo].[FormLubesCsd] ([Id])
GO

ALTER TABLE [dbo].[FormLubesCsdApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesCsdApproval_FormLubesCsd] FOREIGN KEY([FormLubesCsdId])
REFERENCES [dbo].[FormLubesCsd] ([Id])
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesCsdHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocation] [varchar](max) NOT NULL,
	[Location] varchar(128) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
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

