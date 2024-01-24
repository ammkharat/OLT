IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateFunctionalLocation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[FormGenericTemplateFunctionalLocation](
	[FormGenericTemplateId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormGenericTemplateFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormGenericTemplateId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FormGenericTemplate] FOREIGN KEY([FormGenericTemplateId])
REFERENCES [dbo].[FormGenericTemplate] ([Id])


ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation] CHECK CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FormGenericTemplate]


ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[FormGenericTemplateFunctionalLocation] CHECK CONSTRAINT [FK_FormGenericTemplateFunctionalLocation_FunctionalLocation]


End


