
CREATE TABLE [dbo].[FormGN59](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormNumber] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[Content] [varchar](max) NULL,
	[PlainTextContent] [varchar](max) NULL,
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ReleasedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	
	[Deleted] [bit] NOT NULL DEFAULT ((0))
 CONSTRAINT [PK_FormGN59] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormGN59]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN59]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO





CREATE TABLE [dbo].[FormGN59FunctionalLocation](
	[FormGN59Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN59FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN59Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation] CHECK CONSTRAINT [FK_FormGN59FunctionalLocation_FunctionalLocation]
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59FunctionalLocation_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO
ALTER TABLE [dbo].[FormGN59FunctionalLocation] CHECK CONSTRAINT [FK_FormGN59FunctionalLocation_FormGN59]
GO


CREATE NONCLUSTERED INDEX [IDX_FormGN59FunctionalLocation] ON [dbo].[FormGN59FunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[FormGN59Id] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = ON) ON [PRIMARY]
GO




CREATE TABLE [dbo].[FormGN59Approval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormGN59Id] [bigint] NOT NULL,
	
	[Approver] [varchar](100) NOT NULL,
	
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL
 CONSTRAINT [PK_FormGN59Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormGN59Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59Approval_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO

ALTER TABLE [dbo].[FormGN59Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO






GO

