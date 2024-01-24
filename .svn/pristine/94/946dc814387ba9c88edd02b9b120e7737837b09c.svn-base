
/****** Object:  Table [dbo].[FormGN75BApproval]    Script Date: 8/7/2018 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGN75BApproval') 
BEGIN

CREATE TABLE [dbo].[FormGN75BApproval](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormGN75BId] [bigint] NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_FormGN75BApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[FormGN75BApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BApproval_ApprovedByUser] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])

ALTER TABLE [dbo].[FormGN75BApproval] CHECK CONSTRAINT [FK_FormGN75BApproval_ApprovedByUser]


ALTER TABLE [dbo].[FormGN75BApproval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BApproval_FormGN75B] FOREIGN KEY([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ([Id])
	END
GO
