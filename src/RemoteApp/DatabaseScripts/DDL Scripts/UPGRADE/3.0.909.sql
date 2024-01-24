CREATE TABLE [dbo].[BusinessCategory](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,		
	[Name] [varchar](30) NOT NULL,
	[ShortName] [varchar](10) NOT NULL,	
	[IsHSchedDefault] bit NOT NULL,
	[IsSAPWorkOrderDefault] bit NOT NULL,
	[IsSAPNotificationDefault] bit NOT NULL,
	[IsSAPProductMovementDefault] bit NOT NULL,	
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Deleted] bit NOT NULL
	
	CONSTRAINT [PK_BusinessCategory] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[BusinessCategory]
ADD CONSTRAINT [FK_BusinessCategory_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO
