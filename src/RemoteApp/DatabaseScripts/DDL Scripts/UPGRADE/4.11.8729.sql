

CREATE TABLE [dbo].[FormGN6](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	
	[JobDescription] [varchar](255) NULL,
	[ReasonForCriticalLift] [varchar](max) NULL,
	
	[Section1Content] [varchar](max) NULL,
	[Section1PlainTextContent] [nvarchar](max) NULL,
	[Section1NotApplicableToJob] [bit] NOT NULL,
	
	[Section2Content] [varchar](max) NULL,
	[Section2PlainTextContent] [nvarchar](max) NULL,
	[Section2NotApplicableToJob] [bit] NOT NULL,
	
	[Section3Content] [varchar](max) NULL,
	[Section3PlainTextContent] [nvarchar](max) NULL,
	[Section3NotApplicableToJob] [bit] NOT NULL,
	
	[Section4Content] [varchar](max) NULL,
	[Section4PlainTextContent] [nvarchar](max) NULL,
	[Section4NotApplicableToJob] [bit] NOT NULL,
	
	[Section5Content] [varchar](max) NULL,
	[Section5PlainTextContent] [nvarchar](max) NULL,
	[Section5NotApplicableToJob] [bit] NOT NULL,
	
	[Section6Content] [varchar](max) NULL,
	[Section6PlainTextContent] [nvarchar](max) NULL,
	[Section6NotApplicableToJob] [bit] NOT NULL,	
	
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[PreJobMeetingSignatures] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL
 CONSTRAINT [PK_FormGN6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN6]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN6] CHECK CONSTRAINT [FK_FormGN6_CreatedByUser]
GO

ALTER TABLE [dbo].[FormGN6]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN6] CHECK CONSTRAINT [FK_FormGN6_LastModifiedUser]
GO

ALTER TABLE [dbo].[FormGN6] ADD  DEFAULT ((0)) FOR [Deleted]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[FormGN6Approval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN6Id] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormGN6Approval] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN6Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN6Approval] CHECK CONSTRAINT [FK_FormGN6Approval_ApprovedByUser]
GO

ALTER TABLE [dbo].[FormGN6Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6Approval_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

ALTER TABLE [dbo].[FormGN6Approval] CHECK CONSTRAINT [FK_FormGN6Approval_FormGN6]
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[FormGN6FunctionalLocation](
	[FormGN6Id] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN6FunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGN6Id] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN6FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6FunctionalLocation_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
GO

ALTER TABLE [dbo].[FormGN6FunctionalLocation] CHECK CONSTRAINT [FK_FormGN6FunctionalLocation_FormGN6]
GO

ALTER TABLE [dbo].[FormGN6FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormGN6FunctionalLocation] CHECK CONSTRAINT [FK_FormGN6FunctionalLocation_FunctionalLocation]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[FormGN6History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	
	[JobDescription] [varchar](255) NULL,
	[ReasonForCriticalLift] [varchar](max) NULL,
	
	[Section1PlainTextContent] [nvarchar](max) NULL,
	[Section1NotApplicableToJob] [bit] NOT NULL,
	
	[Section2PlainTextContent] [nvarchar](max) NULL,
	[Section2NotApplicableToJob] [bit] NOT NULL,
	
	[Section3PlainTextContent] [nvarchar](max) NULL,
	[Section3NotApplicableToJob] [bit] NOT NULL,
	
	[Section4PlainTextContent] [nvarchar](max) NULL,
	[Section4NotApplicableToJob] [bit] NOT NULL,
	
	[Section5PlainTextContent] [nvarchar](max) NULL,
	[Section5NotApplicableToJob] [bit] NOT NULL,
	
	[Section6PlainTextContent] [nvarchar](max) NULL,
	[Section6NotApplicableToJob] [bit] NOT NULL,
	
	[ValidFromDateTime] [datetime] NOT NULL,
	[ValidToDateTime] [datetime] NOT NULL,
	[ApprovedDateTime] [datetime] NULL,
	[ClosedDateTime] [datetime] NULL,
	[Approvals] [varchar](max) NULL,
	[PlainTextPreJobMeetingSignatures] [varchar](max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,	

) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN6History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN6History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN6History] CHECK CONSTRAINT [FK_FormGN6History_LastModifiedByUser]
GO

------------------------------------------------------------------------------------------------------------------------------------------------

alter table [dbo].DocumentLink add FormGN6Id bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN6] FOREIGN KEY([FormGN6Id])
REFERENCES [dbo].[FormGN6] ([Id])
go




GO

