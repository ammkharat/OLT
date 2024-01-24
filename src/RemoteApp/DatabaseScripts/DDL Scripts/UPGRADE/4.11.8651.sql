

CREATE TABLE [dbo].[FormGN24](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheSafeWorkPlanForPSVRemovalOrInstallation] [bit] NOT NULL,
	[IsTheSafeWorkPlanForWorkInTheAlkylationUnit] [bit] NOT NULL,
	[AlkylationClass] [int] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN24] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN24]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN24] CHECK CONSTRAINT [FK_FormGN24_CreatedByUser]
GO

ALTER TABLE [dbo].[FormGN24]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN24] CHECK CONSTRAINT [FK_FormGN24_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormGN24] ADD  DEFAULT ((0)) FOR [Deleted]
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN24History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[IsTheSafeWorkPlanForPSVRemovalOrInstallation] [bit] NOT NULL,
	[IsTheSafeWorkPlanForWorkInTheAlkylationUnit] [bit] NOT NULL,
	[AlkylationClass] [int] NULL,
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN24History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN24History] CHECK CONSTRAINT [FK_FormGN24History_LastModifiedByUser]
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN24Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN24Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL
 CONSTRAINT [PK_FormGN24Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN24Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN24Approval] CHECK CONSTRAINT [FK_FormGN24Approval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormGN24Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24Approval_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

ALTER TABLE [dbo].[FormGN24Approval] CHECK CONSTRAINT [FK_FormGN24Approval_FormGN24]
GO

---------------------------------------------------

CREATE TABLE [dbo].[FormGN24FunctionalLocation](
	[FormGN24Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN24FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN24Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN24FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24FunctionalLocation_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
GO

ALTER TABLE [dbo].[FormGN24FunctionalLocation] CHECK CONSTRAINT [FK_FormGN24FunctionalLocation_FormGN24]
GO

ALTER TABLE [dbo].[FormGN24FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN24FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN24FunctionalLocation] CHECK CONSTRAINT [FK_FormGN24FunctionalLocation_FunctionalLocation]
GO




GO

