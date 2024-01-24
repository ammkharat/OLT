

CREATE TABLE [dbo].[FormGN7Approval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormGN7Id] [bigint] NOT NULL,
	
	[Approver] [varchar](100) NOT NULL,
	
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL
 CONSTRAINT [PK_FormGN7Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormGN7Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7Approval_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

ALTER TABLE [dbo].[FormGN7Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7Approval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])
GO


GO

