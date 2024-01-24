

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia](
	[UserId] [bigint] NOT NULL,
	[FormGN75BSarniaId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN75BUserReadDocumentLinkAssociationSarnia] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FormGN75BSarniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BSarniaId] FOREIGN KEY([FormGN75BSarniaId])
REFERENCES [dbo].[FormGN75BSarnia] ([Id])


ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BSarniaId]


ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationSarnia_FormGN75BSarniaId] FOREIGN KEY([FormGN75BSarniaId])
REFERENCES [dbo].[FormGN75BSarnia] ([Id])


ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationSarnia_FormGN75BSarniaId]


ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationSarnia_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationSarnia] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationSarnia_User]


End


