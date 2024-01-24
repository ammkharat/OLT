IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormMudsTemporaryInstallationHistory') 

Begin

SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


SET ANSI_PADDING ON


CREATE TABLE [dbo].[FormMudsTemporaryInstallationHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NULL,
	[HasBeenCommunicated] [bit] NULL,
	[HasAttachments] [bit] NULL,
	[CsdReason] [varchar](255) NOT NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[DocumentLinks] [varchar](max) NULL
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormMudsTemporaryInstallationHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationHistory] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationHistory_LastModifiedByUser]



End