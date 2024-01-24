Declare @sitename varchar(40) = 'US Pipeline'
declare @ActiveDirectoryName varchar(40) = 'Uspipeline'
declare @TimeZone varchar(100) = 'Eastern Standard Time'
declare @LoginApprev char(3) = 'USP' -- new site (Montreal Sulphur Refinery)
declare @siteid bigint
--select @siteid = site.Id from Site order by site.Id
set @siteid = 18 --@siteid + 1
if not exists(select 1 from site where site.id = 18)
begin
INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (@siteid, @sitename, @TimeZone, @ActiveDirectoryName);
end


-- site configuration
if not exists(select 1 from [Shift] where SiteId = 18)
begin
	INSERT INTO dbo.[Shift] 
	VALUES 
	('Day','2016-03-08 10:21:14.363',18,'07:00:00','19:00:00')
end

	
delete ActionItemDefinitionAutoReApprovalConfiguration where siteid = 18
delete TargetDefinitionAutoReApprovalConfiguration where siteid = 18
insert into ActionItemDefinitionAutoReApprovalConfiguration values (18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
insert into TargetDefinitionAutoReApprovalConfiguration values (18, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);



GO

