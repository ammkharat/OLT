IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsUserReadDocumentLinkAssociation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsUserReadDocumentLinkAssociation](
	[UserId] [bigint] NOT NULL,
	[WorkPermitMudsId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkPermitMudsUserReadDocumentLinkAssociation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[WorkPermitMudsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--ALTER TABLE [dbo].[WorkPermitMudsUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsUserReadDocumentLinkAssociation_User] FOREIGN KEY([UserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_WorkPermitMudsUserReadDocumentLinkAssociation_User]

--ALTER TABLE [dbo].[WorkPermitMudsUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsUserReadDocumentLinkAssociation_WorkPermitMuds] FOREIGN KEY([WorkPermitMudsId])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsUserReadDocumentLinkAssociation] CHECK CONSTRAINT [FK_WorkPermitMudsUserReadDocumentLinkAssociation_WorkPermitMuds]

End
