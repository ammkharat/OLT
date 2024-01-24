CREATE TABLE [dbo].[FormGN1](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[CSFLevel] varchar(5) NOT NULL,
	[JobDescription] varchar(256) NULL,
	[PlanningWorksheetContent] nvarchar(max) NULL,
	[RescuePlanContent] nvarchar(max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN1] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[FormGN1] ADD  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[FormGN1] WITH CHECK ADD CONSTRAINT [FK_FormGN1_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN1] WITH CHECK ADD CONSTRAINT [FK_FormGN1_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN1]  WITH CHECK ADD CONSTRAINT [FK_FormGN1_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN1History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[CSFLevel] varchar(5) NOT NULL,
	[JobDescription] varchar(256) NULL,
	[PlanningWorksheetContent] nvarchar(max) NULL,
	[RescuePlanContent] nvarchar(max) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN1History] WITH CHECK ADD CONSTRAINT [FK_FormGN1History_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN1History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN1History] CHECK CONSTRAINT [FK_FormGN1History_LastModifiedByUser]
GO

---------------------------------------------

CREATE TABLE [dbo].[FormGN1PlanningWorksheetApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN1Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN1PlanningWorksheetApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN1PlanningWorksheetApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN1PlanningWorksheetApproval_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])

---------------------------------------------

CREATE TABLE [dbo].[FormGN1RescuePlanApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN1Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN1RescuePlanApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN1RescuePlanApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN1RescuePlanApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN1RescuePlanApproval] WITH CHECK ADD CONSTRAINT [FK_FormGN1RescuePlanApproval_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])




GO

