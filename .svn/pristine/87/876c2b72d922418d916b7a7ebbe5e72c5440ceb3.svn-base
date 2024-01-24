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


GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormMudsTemporaryInstallationApproval') 

Begin

SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


SET ANSI_PADDING ON


CREATE TABLE [dbo].[FormMudsTemporaryInstallationApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormMudsTemporaryInstallationId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormMudsTemporaryInstallationApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormMudsTemporaryInstallationApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationApproval] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationApproval_ApprovedByUser]


ALTER TABLE [dbo].[FormMudsTemporaryInstallationApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationApproval_FormMudsTemporaryInstallation] FOREIGN KEY([FormMudsTemporaryInstallationId])
REFERENCES [dbo].[FormMudsTemporaryInstallation] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationApproval] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationApproval_FormMudsTemporaryInstallation]


End




GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormMudsTemporaryInstallationFunctionalLocation') 

Begin

SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


CREATE TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation](
	[FormMudsTemporaryInstallationId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormMudsTemporaryInstallationFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormMudsTemporaryInstallationId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FormMudsTemporaryInstallation] FOREIGN KEY([FormMudsTemporaryInstallationId])
REFERENCES [dbo].[FormMudsTemporaryInstallation] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FormMudsTemporaryInstallation]


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[FormMudsTemporaryInstallationFunctionalLocation] CHECK CONSTRAINT [FK_FormMudsTemporaryInstallationFunctionalLocation_FunctionalLocation]



End


GO

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


GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MudsFormIdSequence') 

Begin


SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


SET ANSI_PADDING ON


CREATE TABLE [dbo].[MudsFormIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT NULL,
	[SeqVal] [varchar](1) NULL
) ON [PRIMARY]



SET ANSI_PADDING OFF

End




GO

