



CREATE TABLE [dbo].[UserGridLayout](
	[UserId] [bigint] NOT NULL,
	[GridId] [int] NOT NULL,
	[GridLayoutXml] varchar(max)
CONSTRAINT [PK_UserGridLayout] PRIMARY KEY CLUSTERED ([UserId] ASC, [GridId] ASC)
WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserGridLayout]  WITH CHECK ADD  CONSTRAINT [FK_UserGridLayout_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])



GO

