EXEC sp_rename 'HoneywellPhdConnectionInfo', 'ScadaConnectionInfo'
GO
alter table ScadaConnectionInfo add [ScadaConnectionTypeId] [tinyint] NOT NULL default(0)
GO
alter table ScadaConnectionInfo add [Description] varchar(150) not null default('PHD')
GO
ALTER TABLE ScadaConnectionInfo ALTER COLUMN PhdUsername varchar(50) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN PhdPassword varchar(50) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN PhdServer varchar(200) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN ApiVersion varchar(50) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN UseWindowsAuthentication bit NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN DatabaseType varchar(20) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN DatabaseUsername varchar(200) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN DatabasePassword varchar(200) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN DatabaseServer varchar(200) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN DatabaseInstance varchar(200) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN StartTimeOffset int NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN EndTimeOffset int NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN SampleType varchar(50) NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN MinimumConfidence int NULL
ALTER TABLE ScadaConnectionInfo ALTER COLUMN MockTagWrites bit NULL
GO
alter table ScadaConnectionInfo add [PiUsername] varchar(50) null
alter table ScadaConnectionInfo add [PiPassword] varchar(50) null
alter table ScadaConnectionInfo add [PiServer] varchar(250) null
GO
INSERT INTO [ScadaConnectionInfo]
           ([SiteId]
           ,[LastModifiedDateTime]
           ,[ScadaConnectionTypeId]
           ,[Description]
           ,[PiUsername]
           ,[PiPassword]
           ,[PiServer]
           ,[MockTagWrites])
     VALUES
           (2
           ,getDate()
           ,1
           ,'PI'
           ,'OLTClient'
           ,'DvPI4OLT'
           ,'DEAPPI1.network.lan'
           ,0)
GO

INSERT INTO [ScadaConnectionInfo]
           ([SiteId]
           ,[LastModifiedDateTime]
           ,[ScadaConnectionTypeId]
           ,[Description]
           ,[PiUsername]
           ,[PiPassword]
           ,[PiServer]
           ,[MockTagWrites])
     VALUES
           (13          
           ,getDate()
           ,1
           ,'PI'
           ,'PIOLTadmin'
           ,'$uncorOLT_admin'
           ,'192.168.65.35'
           ,0)
GO

ALTER TABLE ScadaConnectionInfo DROP CONSTRAINT PK_HoneywellPhdConnectionInfo
GO

alter table ScadaConnectionInfo add Id bigint null

GO
update ScadaConnectionInfo set id = 1 where siteid = 1
update ScadaConnectionInfo set id = 2 where siteid = 2
update ScadaConnectionInfo set id = 3 where siteid = 3
update ScadaConnectionInfo set id = 4 where siteid = 6
update ScadaConnectionInfo set id = 5 where siteid = 9
update ScadaConnectionInfo set id = 6 where siteid = 10
update ScadaConnectionInfo set id = 7 where siteid = 12
update ScadaConnectionInfo set id = 8 where siteid = 13
GO

alter table ScadaConnectionInfo alter column Id bigint not NULL

GO

ALTER TABLE ScadaConnectionInfo ADD CONSTRAINT [PK_ScadaConnectionInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO

alter table Tag add ScadaConnectionInfoId bigint null
GO
update Tag set ScadaConnectionInfoId = 1 where siteid = 1
GO
update Tag set ScadaConnectionInfoId = 2 where siteid = 2
GO
update Tag set ScadaConnectionInfoId = 3 where siteid = 3
GO
update Tag set ScadaConnectionInfoId = 4 where siteid = 6
GO
update Tag set ScadaConnectionInfoId = 5 where siteid = 9
GO
update Tag set ScadaConnectionInfoId = 6 where siteid = 10
GO
update Tag set ScadaConnectionInfoId = 7 where siteid = 12
GO
update Tag set ScadaConnectionInfoId = 8 where siteid = 13
GO

delete from tag where siteid =5
GO

ALTER TABLE Tag  WITH CHECK ADD  CONSTRAINT FK_ScadaConnectioninfoId_Tag FOREIGN KEY(ScadaConnectionInfoId)
REFERENCES ScadaConnectionInfo (Id)
GO

ALTER TABLE Tag CHECK CONSTRAINT FK_ScadaConnectioninfoId_Tag
GO









GO

