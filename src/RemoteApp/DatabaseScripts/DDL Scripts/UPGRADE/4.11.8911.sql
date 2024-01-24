


CREATE TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation] (
	[UserId] [bigint] NOT NULL,
	[WorkPermitMontrealId] [bigint] NOT NULL
CONSTRAINT [PK_WorkPermitMontrealUserReadDocumentLinkAssociation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[WorkPermitMontrealId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitMontrealUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMontrealUserReadDocumentLinkAssociation_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO





GO

