

alter table [dbo].[Role]
add ActiveDirectoryKey varchar(255) NULL;

GO

update [dbo].[Role] set ActiveDirectoryKey = 'Supervisor' where id = 1;
update [dbo].[Role] set ActiveDirectoryKey = 'Operator' where id = 2;
update [dbo].[Role] set ActiveDirectoryKey = 'EngineeringSupport' where id = 3;
update [dbo].[Role] set ActiveDirectoryKey = 'OperatingEngineer' where id = 5;
update [dbo].[Role] set ActiveDirectoryKey = 'PermitScreener' where id = 6;
update [dbo].[Role] set ActiveDirectoryKey = 'ReadUser' where id = 7;
update [dbo].[Role] set ActiveDirectoryKey = 'Non_OperationPermitIssuer' where id = 8;
update [dbo].[Role] set ActiveDirectoryKey = 'SupervisorPlus' where id = 12;
update [dbo].[Role] set ActiveDirectoryKey = 'EngineeringSupportPlus' where id = 18;
update [dbo].[Role] set ActiveDirectoryKey = 'PermitScreenerCommentor' where id = 19;
update [dbo].[Role] set ActiveDirectoryKey = 'Administrator' where id = 37;
update [dbo].[Role] set ActiveDirectoryKey = 'RestrictionReportingAdmin' where id = 38;
update [dbo].[Role] set ActiveDirectoryKey = 'AreaManager' where id = 39;

GO

alter table [dbo].[Site]
add ActiveDirectoryKey varchar(255) NULL;

GO

update [dbo].[Site] set ActiveDirectoryKey = 'Sarnia' where id = 1;
update [dbo].[Site] set ActiveDirectoryKey = 'Denver' where id = 2;
update [dbo].[Site] set ActiveDirectoryKey = 'OilSands' where id = 3;
update [dbo].[Site] set ActiveDirectoryKey = 'Firebag' where id = 5;
update [dbo].[Site] set ActiveDirectoryKey = 'SiteWideServices' where id = 6;
update [dbo].[Site] set ActiveDirectoryKey = 'MacKayRiver' where id = 7;

GO
GO
