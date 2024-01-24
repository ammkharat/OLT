IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateApproval]') AND type in (N'U'))

Begin

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



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[FormGenericTemplateApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGenericTemplateApproval] CHECK CONSTRAINT [FK_FormGenericTemplateApproval_ApprovedByUser]


ALTER TABLE [dbo].[FormGenericTemplateApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateApproval_FormGenericTemplate] FOREIGN KEY([FormGenericTemplateId])
REFERENCES [dbo].[FormGenericTemplate] ([Id])


ALTER TABLE [dbo].[FormGenericTemplateApproval] CHECK CONSTRAINT [FK_FormGenericTemplateApproval_FormGenericTemplate]


End
