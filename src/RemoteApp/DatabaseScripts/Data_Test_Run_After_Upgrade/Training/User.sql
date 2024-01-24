SET IDENTITY_INSERT [User] ON

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId], 
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(1, 'oltuser1', 'OLT', 'User1', '00092600', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] ) 
	VALUES(2, 'oltuser2', 'OLT', 'User2', '02000000', 1, GETDATE());
	
INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] ) 
	VALUES(3, 'oltuser3', 'OLT', 'User3', '03000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(4, 'oltuser4', 'OLT', 'User4', '04000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(5, 'oltuser5', 'OLT', 'User5', '05000000', 1, GETDATE());
	
INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(6, 'oltuser6', 'OLT', 'User6', '06000000', 1, GETDATE());
	
INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(7, 'oltuser7', 'OLT', 'User7', '07000000', 1, GETDATE());
	
INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(8, 'oltuser8', 'OLT', 'User8', '08000000',1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname], [SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(9, 'oltuser9', 'OLT', 'User9', '09000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(10, 'oltuser10', 'OLT', 'User10', '10000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(11, 'oltuser11', 'OLT', 'User11', '11000000', 1, GETDATE());
	
INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(12, 'oltuser12', 'OLT', 'User12', '12000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(13, 'oltuser13', 'OLT', 'User13', '13000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] ) 
	VALUES(14, 'oltuser14', 'OLT', 'User14', '14000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(15, 'oltuser15', 'OLT', 'User15', '15000000', 1, GETDATE());

INSERT INTO [USER] ([Id], [Username], [Firstname], [Lastname],[SAPId],
	[LastModifiedUserId], [LastModifiedDateTime] )
	VALUES(16, 'oltuser16', 'OLT', 'User16', '16000000', 1, GETDATE());
GO

SET IDENTITY_INSERT [User] OFF
DBCC CHECKIDENT ([User], RESEED)

GO