ALTER TABLE [dbo].[UserSite]
	ADD [RoleId] bigint NULL
	
ALTER TABLE [dbo].[UserSite]
	ADD [IsDefaultRole] bit NULL
GO

delete from usersite
where UserId not in (select id from [user])
go

ALTER TABLE [dbo].[UserSite]
	ADD FOREIGN KEY(UserId) REFERENCES [dbo].[User]([Id])

ALTER TABLE [dbo].[UserSite]
	ADD FOREIGN KEY(SiteId) REFERENCES [dbo].[Site]([Id])

UPDATE [UserSite]
	SET RoleId = (SELECT [RoleId] FROM [User] WHERE [User].[Id] = [UserSite].[UserId]),
		IsDefaultRole = 1

ALTER TABLE [UserSite]
	ALTER COLUMN [RoleId] bigint NOT NULL
	
ALTER TABLE [UserSite]
	ALTER COLUMN [IsDefaultRole] bit NOT NULL

ALTER TABLE [dbo].[UserSite]
	ADD FOREIGN KEY(RoleId) REFERENCES [dbo].[Role]([Id])
	 
ALTER TABLE [dbo].[UserSite]
 ADD CONSTRAINT UserSite_Unique
 UNIQUE(UserId, SiteId, RoleId)

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IDX_User_Role')
DROP INDEX [IDX_User_Role] ON [dbo].[User] WITH ( ONLINE = OFF )

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role]

ALTER TABLE [User]
	DROP COLUMN [RoleId]		

DELETE FROM [UserSite] WHERE UserId = 0 or UserId = -1
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,1,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,1,1,1)

INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,2,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,2,1,1)

INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,3,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,3,1,1)

INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,5,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,5,1,1)

INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,6,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,6,1,1)

INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (-1,7,1,1)
INSERT INTO dbo.UserSite(UserId,SiteId, RoleId, IsDefaultRole) VALUES (0,7,1,1)

Go

DELETE FROM [Role] Where Id=4
GO
GO
