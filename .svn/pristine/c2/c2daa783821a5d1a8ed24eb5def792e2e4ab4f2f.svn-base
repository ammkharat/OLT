ALTER TABLE dbo.SiteConfiguration ADD RememberActionItemWorkAssignment BIT NOT NULL DEFAULT 0
GO

-- set edmonton refinery to true for remembering action item work assignments
UPDATE dbo.SiteConfiguration SET RememberActionItemWorkAssignment = 1 WHERE SiteId = 8
GO

/****** Object:  Table [dbo].[UserPreferences]    Script Date: 07/21/2014 18:42:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserPreferences](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ActionItemDefinitionLastUsedWorkAssignmentId] [bigint] NULL
 CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UserPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserPreferences_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserPreferences] CHECK CONSTRAINT [FK_UserPreferences_User]
GO




GO

