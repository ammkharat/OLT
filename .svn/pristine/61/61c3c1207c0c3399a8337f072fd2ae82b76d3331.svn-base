ALTER TABLE OpmToeDefinitionComment DROP COLUMN FirstName
ALTER TABLE OpmToeDefinitionComment DROP COLUMN LastName
ALTER TABLE OpmToeDefinitionComment DROP COLUMN UserName

ALTER TABLE OpmToeDefinitionComment ADD [LastModifiedByUserId] [bigint] NOT NULL

ALTER TABLE OpmToeDefinitionComment ADD [ToeName] [nvarchar](255) NOT NULL

ALTER TABLE [dbo].OpmToeDefinitionComment  WITH CHECK ADD  CONSTRAINT [FK_OpmToeDefinitionComment_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OpmToeDefinitionCommentHistory](
	[Id] [bigint] NOT NULL,
	[ToeName] [nvarchar](255) not null,
	[Comment] [varchar](max) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OpmToeDefinitionCommentHistory]  WITH CHECK ADD  CONSTRAINT [FK_OpmToeDefinitionCommentHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[OpmToeDefinitionCommentHistory] CHECK CONSTRAINT [FK_OpmToeDefinitionCommentHistory_LastModifiedByUser]
GO





GO

