SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestrictionReasonCode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] varchar(150) NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] bit NOT NULL,
 CONSTRAINT [PK_RestrictionReasonCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RestrictionReasonCode]  WITH NOCHECK ADD  CONSTRAINT [FK_RestrictionReasonCode_User] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO
