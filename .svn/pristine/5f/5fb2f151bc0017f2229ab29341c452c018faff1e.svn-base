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

