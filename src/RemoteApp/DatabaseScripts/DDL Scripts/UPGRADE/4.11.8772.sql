CREATE TABLE [dbo].[FormGN75A](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[AssociatedFormGN75BId] bigint NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN75A] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN75A] WITH CHECK ADD CONSTRAINT [FK_FormGN75A_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN75A] WITH CHECK ADD CONSTRAINT [FK_FormGN75A_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN75A]  WITH CHECK ADD CONSTRAINT [FK_FormGN75A_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN75A] ADD  DEFAULT ((0)) FOR [Deleted]
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN75AHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[AssociatedFormGN75BId] [bigint] NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,	
	[Approvals] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN75AHistory] WITH CHECK ADD CONSTRAINT [FK_FormGN75AHistory_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN75AHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75AHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN75AHistory] CHECK CONSTRAINT [FK_FormGN75AHistory_LastModifiedByUser]
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN75AApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75AId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN75AApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN75AApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN75AApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN75AApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN75AApproval_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])
GO


