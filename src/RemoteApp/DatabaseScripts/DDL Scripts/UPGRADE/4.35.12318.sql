
IF not EXISTS (
select * from RoleElement where  Name like N'Mark As Read CSD Forms' and FunctionalArea = N'Forms'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (340, 'Mark As Read CSD Forms', 'Forms')
End





GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'EnableCSDMarkAsRead'
)
BEGIN
ALTER TABLE SiteConfiguration ADD EnableCSDMarkAsRead BIT NOT NULL DEFAULT '0'
END


GO

IF OBJECT_ID('dbo.FormOP14Read', 'U') IS NOT NULL 
  DROP TABLE [dbo].[FormOP14Read]; 
GO  


CREATE TABLE [dbo].[FormOP14Read](
	[FormOP14Id] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[ShiftId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormOP14Read] PRIMARY KEY CLUSTERED 
(
	[FormOP14Id] ASC,
	[UserId] ASC,
	[DateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormOP14Read]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Read_FormOP14] FOREIGN KEY([FormOP14Id])
REFERENCES [dbo].[FormOP14] ([Id])
GO

ALTER TABLE [dbo].[FormOP14Read] CHECK CONSTRAINT [FK_FormOP14Read_FormOP14]
GO

ALTER TABLE [dbo].[FormOP14Read]  WITH CHECK ADD  CONSTRAINT [FK_FormOP14Read_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOP14Read] CHECK CONSTRAINT [FK_FormOP14Read_User]
GO

ALTER TABLE [dbo].[FormOP14Read] ADD  CONSTRAINT [DF_FormOP14Read_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO


GO

