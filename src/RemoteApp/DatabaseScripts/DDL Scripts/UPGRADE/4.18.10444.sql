﻿ALTER TABLE OpmExcursionResponse DROP COLUMN FirstName
ALTER TABLE OpmExcursionResponse DROP COLUMN LastName
ALTER TABLE OpmExcursionResponse DROP COLUMN UserName

ALTER TABLE OpmExcursionResponse ADD [LastModifiedByUserId] [bigint] NOT NULL



ALTER TABLE [dbo].[OpmExcursionResponse]  WITH CHECK ADD  CONSTRAINT [FK_OpmExcursionResponse_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

/****** Object:  Table [dbo].[DirectiveHistory]    Script Date: 03/02/2015 15:14:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ExcursionResponseHistory](
	[Id] [bigint] NOT NULL,
	[Response] [varchar](max) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ExcursionResponseHistory]  WITH CHECK ADD  CONSTRAINT [FK_ExcursionResponseHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ExcursionResponseHistory] CHECK CONSTRAINT [FK_ExcursionResponseHistory_LastModifiedByUser]
GO





GO



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[OpmExcursionResponse]') AND name = 'Asset'
)
begin
ALTER TABLE [dbo].[OpmExcursionResponse] ADD Asset nvarchar(100)
end

Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[OpmExcursionResponse]') AND name = 'Code'
)
begin
ALTER TABLE [dbo].[OpmExcursionResponse] ADD Code nvarchar(100)
end

Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[ExcursionResponseHistory]') AND name = 'Asset'
)
begin
ALTER TABLE [dbo].[ExcursionResponseHistory] ADD Asset nvarchar(100)
end

Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[ExcursionResponseHistory]') AND name = 'Code'
)
begin
ALTER TABLE [dbo].[ExcursionResponseHistory] ADD Code nvarchar(100)
end

Go


