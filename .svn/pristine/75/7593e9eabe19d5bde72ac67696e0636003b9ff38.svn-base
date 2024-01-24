SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesAlarmDisable](
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
	[DepartmentId] [int] NOT NULL,
	[IsTheCSDForAPressureSafetyValve] [bit] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CriticalSystemDefeated] [varchar](255) NULL,
	[HasBeenApproved] [bit] NOT NULL,
 CONSTRAINT [PK_FormLubesAlarmDisable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable]  WITH CHECK ADD CONSTRAINT [FK_FormLubesAlarmDisable_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesAlarmDisable_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable] CHECK CONSTRAINT [FK_FormLubesAlarmDisable_CreatedByUser]
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesAlarmDisable_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable] CHECK CONSTRAINT [FK_FormLubesAlarmDisable_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormLubesAlarmDisable] ADD  DEFAULT ((0)) FOR [Deleted]
GO


Alter Table DocumentLink add FormLubesAlarmDisableId bigint sparse null
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormLubesAlarmDisable] FOREIGN KEY([FormLubesAlarmDisableId])
REFERENCES [dbo].[FormLubesAlarmDisable] ([Id])
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesAlarmDisableApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormLubesAlarmDisableId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormLubesAlarmDisableApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormLubesAlarmDisableApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesAlarmDisableApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisableApproval] CHECK CONSTRAINT [FK_FormLubesAlarmDisableApproval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormLubesAlarmDisableApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesAlarmDisableApproval_FormLubesAlarmDisable] FOREIGN KEY([FormLubesAlarmDisableId])
REFERENCES [dbo].[FormLubesAlarmDisable] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisableApproval] CHECK CONSTRAINT [FK_FormLubesAlarmDisableApproval_FormLubesAlarmDisable]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormLubesAlarmDisableHistory](
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

ALTER TABLE [dbo].[FormLubesAlarmDisableHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormLubesAlarmDisableHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormLubesAlarmDisableHistory] CHECK CONSTRAINT [FK_FormLubesAlarmDisableHistory_LastModifiedByUser]
GO


  




GO

