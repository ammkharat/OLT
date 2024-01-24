
CREATE TABLE [dbo].[DirectiveRead](
	[DirectiveId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DirectiveRead] PRIMARY KEY CLUSTERED 
(
	[DirectiveId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DirectiveRead]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveRead_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])
GO

ALTER TABLE [dbo].[DirectiveRead] CHECK CONSTRAINT [FK_DirectiveRead_Directive]
GO

ALTER TABLE [dbo].[DirectiveRead]  WITH CHECK ADD  CONSTRAINT [FK_DirectiveRead_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[DirectiveRead] CHECK CONSTRAINT [FK_DirectiveRead_User]
GO



GO

