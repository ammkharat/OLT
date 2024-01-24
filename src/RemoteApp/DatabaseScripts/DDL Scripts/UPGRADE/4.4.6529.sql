CREATE TABLE [dbo].[FormOP14](
    [Id] [bigint] NOT NULL,
    [FormStatusId] [int] NOT NULL,
    [Content] [varchar](max) NULL,  
    [PlainTextContent] [varchar](max) NULL,
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
      
    [Deleted] [bit] NOT NULL DEFAULT ((0))
 CONSTRAINT [PK_FormOP14] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[FormOP14]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14_CreatedByUser] FOREIGN KEY([CreatedByUserId])  
REFERENCES [dbo].[User] ([Id])  
GO  
  
ALTER TABLE [dbo].[FormOP14]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])  
REFERENCES [dbo].[User] ([Id])  
GO  
  
  
  
  
  
CREATE TABLE [dbo].[FormOP14FunctionalLocation](  
    [FormOP14Id] [bigint] NOT NULL,  
    [FunctionalLocationId] [bigint] NOT NULL,  
 CONSTRAINT [PK_FormOP14FunctionalLocation] PRIMARY KEY CLUSTERED   
(  
    [FormOP14Id] ASC,  
    [FunctionalLocationId] ASC  
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
ALTER TABLE [dbo].[FormOP14FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])  
REFERENCES [dbo].[FunctionalLocation] ([Id])  
GO  
ALTER TABLE [dbo].[FormOP14FunctionalLocation] CHECK CONSTRAINT [FK_FormOP14FunctionalLocation_FunctionalLocation]  
GO  
ALTER TABLE [dbo].[FormOP14FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14FunctionalLocation_FormOP14] FOREIGN KEY([FormOP14Id])  
REFERENCES [dbo].[FormOP14] ([Id])  
GO  
ALTER TABLE [dbo].[FormOP14FunctionalLocation] CHECK CONSTRAINT [FK_FormOP14FunctionalLocation_FormOP14]  
GO  
  
  
CREATE NONCLUSTERED INDEX [IDX_FormOP14FunctionalLocation] ON [dbo].[FormOP14FunctionalLocation]   
(  
    [FunctionalLocationId] ASC,  
    [FormOP14Id] ASC  
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = ON) ON [PRIMARY]  
GO  
  
  
  
  
CREATE TABLE [dbo].[FormOP14Approval](  
    [Id] [bigint] IDENTITY(1,1) NOT NULL,  
    [FormOP14Id] [bigint] NOT NULL,  
      
    [Approver] [varchar](100) NOT NULL,  
      
    [ApprovedByUserId] [bigint] NULL,  
    [ApprovalDateTime] [datetime] NULL,  
    [DisplayOrder] [int] NOT NULL  
 CONSTRAINT [PK_FormOP14Approval] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[FormOP14Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Approval_FormOP14] FOREIGN KEY([FormOP14Id])  
REFERENCES [dbo].[FormOP14] ([Id])  
GO  
  
ALTER TABLE [dbo].[FormOP14Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])  
REFERENCES [dbo].[User] ([Id])  
GO




GO

