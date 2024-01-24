IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormGenericTemplateId'
)
begin
	ALTER TABLE DocumentLink 
	ADD FormGenericTemplateId bigint; 
End



GO


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplate]') AND type in (N'U'))

begin
CREATE TABLE [dbo].[FormGenericTemplate](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
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
	[siteid] [bigint] NULL,
	[FormTypeID] [bigint] NULL,
 CONSTRAINT [PK_FormGenericTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

end

GO

SET ANSI_PADDING OFF
GO

IF(OBJECT_ID('FK_FormGenericTemplate_CreatedByUser', 'F') IS NULL)
BEGIN

ALTER TABLE [dbo].[FormGenericTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplate_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGenericTemplate] CHECK CONSTRAINT [FK_FormGenericTemplate_CreatedByUser]
end
GO

IF(OBJECT_ID('FK_FormGenericTemplate_LastModifiedUser', 'F') IS NULL)

BEGIN

ALTER TABLE [dbo].[FormGenericTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplate_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])

ALTER TABLE [dbo].[FormGenericTemplate] CHECK CONSTRAINT [FK_FormGenericTemplate_LastModifiedUser]

ALTER TABLE [dbo].[FormGenericTemplate] ADD  DEFAULT ((0)) FOR [Deleted]
end
GO


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateApproval]') AND type in (N'U'))

begin
CREATE TABLE [dbo].[FormGenericTemplateApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGenericTemplateId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_FormGenericTemplateApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
end
GO

SET ANSI_PADDING OFF
GO

IF(OBJECT_ID('FK_FormGenericTemplateApproval_ApprovedByUser', 'F') IS NULL)
BEGIN
ALTER TABLE [dbo].[FormGenericTemplateApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])

ALTER TABLE [dbo].[FormGenericTemplateApproval] CHECK CONSTRAINT [FK_FormGenericTemplateApproval_ApprovedByUser]
end
GO

IF(OBJECT_ID('FK_FormGenericTemplateApproval_FormGenericTemplate', 'F') IS NULL)
BEGIN
ALTER TABLE [dbo].[FormGenericTemplateApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateApproval_FormGenericTemplate] FOREIGN KEY([FormGenericTemplateId])
REFERENCES [dbo].[FormGenericTemplate] ([Id])

ALTER TABLE [dbo].[FormGenericTemplateApproval] CHECK CONSTRAINT [FK_FormGenericTemplateApproval_FormGenericTemplate]
end
GO

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateFunctionalLocation]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[FormGenericTemplateFunctionalLocation](
	[FormGenericTemplateId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGenericTemplateFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGenericTemplateId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
end
GO

IF(OBJECT_ID('FK_FormGenericTemplateFunctionalLocation_FormGenericTemplate', 'F') IS NULL)
BEGIN
ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FormGenericTemplate] FOREIGN KEY([FormGenericTemplateId])
REFERENCES [dbo].[FormGenericTemplate] ([Id])

ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation] CHECK CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FormGenericTemplate]
end
GO

IF(OBJECT_ID('FK_FormGenericTemplateFunctionalLocation_FunctionalLocation', 'F') IS NULL)
BEGIN
ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation] CHECK CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FunctionalLocation]
end
GO


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateHistory]') AND type in (N'U'))
begin

CREATE TABLE [dbo].[FormGenericTemplateHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
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

end
GO

SET ANSI_PADDING OFF
GO

IF(OBJECT_ID('FK_FormGenericTemplateHistory_LastModifiedByUser', 'F') IS NULL)
BEGIN
ALTER TABLE [dbo].[FormGenericTemplateHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])

ALTER TABLE [dbo].[FormGenericTemplateHistory] CHECK CONSTRAINT [FK_FormGenericTemplateHistory_LastModifiedByUser]
end

GO

