IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormMudsTemporaryInstallation') 

Begin

SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


SET ANSI_PADDING ON


CREATE TABLE [dbo].[FormMudsTemporaryInstallation](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[HasBeenCommunicated] [bit] NULL,
	[HasAttachments] [bit] NULL,
	[CsdReason] [varchar](255) NOT NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[HasBeenApproved] [bit] NULL,
 CONSTRAINT [PK_FormMudsTemporaryInstallation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormMudsTemporaryInstallation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallation_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallation_CreatedByUser]


ALTER TABLE [dbo].[FormMudsTemporaryInstallation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallation_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallation_LastModifiedUser]


ALTER TABLE [dbo].[FormMudsTemporaryInstallation] ADD  DEFAULT ((0)) FOR [Deleted]



End