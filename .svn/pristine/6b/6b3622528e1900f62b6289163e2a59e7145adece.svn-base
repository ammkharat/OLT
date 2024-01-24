CREATE TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation] (
	[UserId] [bigint] NOT NULL,
	[FormGN75BId] [bigint] NOT NULL
CONSTRAINT [PK_FormGN75BUserReadDocumentLinkAssociation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FormGN75BId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociation]
WITH CHECK ADD CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociation_FormGN75BId] 
FOREIGN KEY([FormGN75BId])
REFERENCES [dbo].[FormGN75B] ([Id]);
GO




GO

