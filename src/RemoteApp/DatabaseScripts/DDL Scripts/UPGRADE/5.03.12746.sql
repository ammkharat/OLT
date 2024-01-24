
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormGN75BTemplateId'
)
begin
alter table [dbo].[DocumentLink] Add FormGN75BTemplateId bigint NULL 
end
Go




GO

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia]') AND type in (N'U'))

Begin


CREATE TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia](
	[UserId] [bigint] NOT NULL,
	[FormGN75BTemplateId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGN75BUserReadDocumentLinkAssociationTemplateSarnia] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FormGN75BTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




--ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationTemplate_FormGN75BTemplateId] FOREIGN KEY([FormGN75BTemplateId])
--REFERENCES [dbo].[FormGN75BTemplate] ([Id])

--ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationTemplate_FormGN75BTemplateId]

--ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia]  WITH CHECK ADD  CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationTemplate_User] FOREIGN KEY([UserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[FormGN75BUserReadDocumentLinkAssociationTemplateSarnia] CHECK CONSTRAINT [FK_FormGN75BUserReadDocumentLinkAssociationTemplate_User]

End



GO

