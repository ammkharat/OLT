Declare @sitename varchar(40) = N'Montréal usine de soufre'
declare @ActiveDirectoryName varchar(40) = 'MUDS'
declare @TimeZone varchar(100) = 'Eastern Standard Time'
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @siteid bigint
select @siteid = site.Id from Site order by site.Id

if not exists(select * from site where ActiveDirectoryKey = 'MUDS')
begin
	set @siteid = @siteid + 1
	INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (@siteid, @sitename, @TimeZone, @ActiveDirectoryName);
end
else
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

SET IDENTITY_INSERT dbo.Plant ON;
if not exists(select * from plant where plant.Id = 304)
begin
	INSERT INTO dbo.[Plant] (Id,name,SiteId) VALUES (304,@sitename, @siteid)
end
SET IDENTITY_INSERT dbo.Plant OFF;
declare @plantid bigint = 304 --Ident_current('plant')

-- site configuration
if not exists(select 1 from shift where siteid = @siteid)
begin
	INSERT INTO dbo.[Shift] 
	VALUES 
	('Jour','2016-03-08 10:21:14.363',@siteid,'06:00:00','18:00:00'),
	('Nuit','2016-03-08 10:21:14.363',@siteid,'18:00:00','06:00:00');
end
else
begin
	update dbo.[shift] set CreatedDateTime = '2016-03-08 10:21:14.363',StartTime = '06:00:00', Endtime = '18:00:00' where name='Jour' and siteid = @siteid
	update dbo.[shift] set CreatedDateTime = '2016-03-08 10:21:14.363',StartTime = '18:00:00', Endtime = '06:00:00' where name='Nuit' and siteid = @siteid
end

--clean and insert
delete from ActionItemDefinitionAutoReApprovalConfiguration where siteid = @siteid
delete from TargetDefinitionAutoReApprovalConfiguration where siteid = @siteid
insert into ActionItemDefinitionAutoReApprovalConfiguration values (@siteid, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
insert into TargetDefinitionAutoReApprovalConfiguration values (@siteid, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;

delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join FunctionalLocation on WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'UDS%'
delete from FunctionalLocationOperationalMode from FunctionalLocationOperationalMode inner join FunctionalLocation on FunctionalLocationOperationalMode.UnitId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'UDS%'
--delete Ancestors


	delete from functionallocationancestor from functionallocationancestor fa where fa.id+fa.ancestorid+fa.ancestorlevel in (		SELECT 
			c.id+ a.id+ a.[Level]
			FROM FunctionalLocation a
			INNER JOIN FunctionalLocation c 
				ON c.siteid = a.siteid and 
				c.[Level] > a.[Level] and
				CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
			where
				c.SiteId = @siteid
				)


delete from UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation inner join FunctionalLocation on UserLoginHistoryFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.SiteId in (3,11,13) and FunctionalLocation.FullHierarchy like 'UDS'
delete from BusinessCategoryFLOCAssociation from BusinessCategoryFLOCAssociation inner join BusinessCategory on BusinessCategoryFLOCAssociation.BusinessCategoryId = BusinessCategory.Id and BusinessCategory.SiteId = @siteid

delete from actionitemdefinitionhistory from actionitemdefinitionhistory inner join businesscategory on actionitemdefinitionhistory.businesscategoryid = businesscategory.id and businesscategory.siteid = @siteid
delete from actionitemfunctionallocation from actionitemfunctionallocation inner join actionitem on actionitemfunctionallocation.actionitemid = actionitem.id inner join businesscategory on actionitem.businesscategoryid = businesscategory.id and businesscategory.siteid = @siteid
delete from LogActionItemAssociation from LogActionItemAssociation inner join actionitem on LogActionItemAssociation.actionitemid = actionitem.id inner join businesscategory on actionitem.businesscategoryid = businesscategory.id and businesscategory.siteid = @siteid
delete from actionitem from actionitem  inner join businesscategory on actionitem.businesscategoryid = businesscategory.id and businesscategory.siteid = @siteid
delete from ActionItemDefinitionFunctionalLocation from ActionItemDefinitionFunctionalLocation inner join functionallocation on ActionItemDefinitionFunctionalLocation.functionallocationid = functionallocation.id and functionallocation.siteid = @siteid
delete from ActionItemDefinition from ActionItemDefinition  inner join businesscategory on ActionItemDefinition.BusinessCategoryId = BusinessCategory.Id and BusinessCategory.SiteId = @siteid


delete from BusinessCategory where SiteId = @siteid
alter table UserLoginHistoryFunctionalLocation nocheck constraint FK_UserLoginHistoryFunctionalLocation_FunctionalLocation
delete from DirectiveFunctionalLocation from DirectiveFunctionalLocation inner join functionallocation on DirectiveFunctionalLocation.functionallocationid = functionallocation.id and functionallocation.siteid = @siteid
delete from LogFunctionalLocation from LogFunctionalLocation inner join functionallocation on LogFunctionalLocation.functionallocationid = functionallocation.id and functionallocation.siteid = @siteid
delete from SummaryLogFunctionalLocation from SummaryLogFunctionalLocation inner join functionallocation on SummaryLogFunctionalLocation.functionallocationid = functionallocation.id and functionallocation.siteid = @siteid
delete FunctionalLocation where FullHierarchy like 'UDS%'
alter table UserLoginHistoryFunctionalLocation check constraint FK_UserLoginHistoryFunctionalLocation_FunctionalLocation


BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, @sitename, @LoginApprev, 0, 0, 1, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité d''amine 1', @LoginApprev + N'-0100', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-C120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-DK121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E112', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E113', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E114', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E131A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E131B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-E142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-F130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FI130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FO132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FT140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FV110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FV121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-FV122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG110~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG110~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG130~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG130~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG130~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LG150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LS170A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSH125A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSH125B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSHH110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSHH130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSHH170', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LSHH810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LT150S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-LV150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M151', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-M170', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P112', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P125A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P125B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P151', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-P170', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG150~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG150~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PG160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PI110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PI130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PI130A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PI130B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSL110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSL121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV112', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PSV132A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PT142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PTXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PV110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PV111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PV113', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-PV121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-T130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-T170', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TB112', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TB122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TB132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE111', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE112', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE113', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE114', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE133', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE180', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE181', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE182', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE183', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE184', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE185', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TE186', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TG130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-TT140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-V110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-V150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0100-VVB130', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

Begin Transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité d''amine 2', @LoginApprev + N'-0200', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-C210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-C220', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E213', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E215', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E225', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E230A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E230B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-E253', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-F211A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-F211B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-F212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-M270', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-P270', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV212A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV215', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV220', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV222A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV230A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV230B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV232A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV233A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSV253', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-T230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-T270', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TB212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TB222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TB232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TB233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TB252', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-V210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-VVB230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PRE210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT210B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT210C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT211A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT212A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT212B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT220', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT226', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT229', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT240', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT253', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PT866', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PV210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PV211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PV213', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PV230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-RO221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-SV212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE213', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE215', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE216', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE225', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE227', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE230I', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE230J', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE230K', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE230L', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE234', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE236', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE237', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE240A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE251E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE251F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE251G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE253E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE253F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE253G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE282', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE286', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TE287', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG230H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG251A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG251B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG251C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG251D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG253A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG253B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG253C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TG253D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TT217', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TT220A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TT220B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TT240', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TV217', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-TV240', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XS270', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XV212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-XV214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FE251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FI230A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FI230C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FI251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FIXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO212A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO222A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO232A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO233A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO251', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO252', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FO252A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT215', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT229', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT252', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT253', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FT256', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV232', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FV250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-FVXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-HS214', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-HS221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG210~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG210~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG220', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG223', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LG250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LSH211', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LSHH230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LSHH270', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LSHL270A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT210A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT210B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT212', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT230', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LT250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LV221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-LV250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PDT217', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG210G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG211B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG211C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG211D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG211E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG211G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG212C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG212F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG212G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG213', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG215A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG221', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG222', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG223A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG223B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG224', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG230H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG231', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG232A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG233', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG251H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG252E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG252F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG252G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG253A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG253B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG253C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG253D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PG255', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0200-PSL210', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité de récupération de soufre (SRU)', @LoginApprev + N'-0300', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AB301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AB302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AB303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AB304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AB305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AT308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-AT309', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-B301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-B302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-B303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-BE301M', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-BE301P', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-BE303M', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-BE303P', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-D330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-DPT301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-DPT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-DPT330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-DPV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E321', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-E331', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FEXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~10', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~11', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~12', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~13', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~14', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~15', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~16', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~17', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~18', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~19', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~6', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~7', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~8', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI301~9', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~10', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~11', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~12', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~13', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~14', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~15', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~16', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~17', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~18', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~19', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~20', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~21', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~6', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~7', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~8', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI303~9', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FI305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FO301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FO304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FO310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FO311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FOXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT301A/H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT301A/L', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT301G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT301S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT303A/H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT303A/L', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT303G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT303S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT305N', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT312', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT313', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT314', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT322', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FT332', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV301G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV301S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV303G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV303S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-FV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS300~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS301A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS301A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS301A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HS330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HSS301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HSS303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV301E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-HV303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-I330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-IT302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-IT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-IT304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-KO310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-KO311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-KO320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-KO330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LG330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSD303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSH300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSH310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSH311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSH320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSH330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSHH300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSL300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSLL301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSLL302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LSLL303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT301S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT302S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT303S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LT330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-LV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-M301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-M302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-M303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-M304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-P301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PDI301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG302A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG303E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG304A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG305A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG318', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PG330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PI301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PI303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PI303V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PI320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PO311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PRV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PRV302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PRV303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PRV303E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSH301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSH303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSL301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSL303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV301E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV302A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV302B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV310A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PSV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT300N', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT301G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT303G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT305A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT305N', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT306', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT312', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT350', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PT351', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV301V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV303V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-PV330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-R310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-R311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-R320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-R330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG302~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG303D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG310A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG310B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG311A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG311B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SG330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SL330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SS301V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SS303V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ST310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV300~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV301A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV301A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV301A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV301V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV303A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV303A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV303A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV303V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-SV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TB301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TB305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE301G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE303G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE312', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE313', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE314', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE315', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE321', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE322', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE331', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE332', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE350', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE351', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE352', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE353', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE354', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE355', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE356', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE357', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE358', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE360', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE361', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE362', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE363', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE364', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE365', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE366', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE367', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE368', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE370', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE371', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE372', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE373', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE374', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE375', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE376', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE377', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE379', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE380', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE381', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE382', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE383', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE384', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE385', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE386', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE387', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TE389', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TG330~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TGXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301~6', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT301M', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303~6', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT303M', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TT330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TV310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TV311', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TV320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-TV330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-U340', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-V301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-VT303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XS304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV300~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV301A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV301A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-XV301A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL301A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL301E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL303D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YL303E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-YS308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH300~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH301G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH303G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSH327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL300~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL300~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL300~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL300~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL301E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303A1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303A2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303A3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL303C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZSL327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZT301V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0300-ZT303V', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité des gaz résiduaires', @LoginApprev + N'-0400', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AB401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AT431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AT432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AT433', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AT450', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-AV432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-B430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-BE431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-BE432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-BE451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-BE452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-D430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-DF451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-DF452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-DPSL451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-DPSL452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FI451A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FI451B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FI452A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FI452B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FT454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV424', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV425', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-FV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV433', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV434', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV453A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV453B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV454A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GSV454B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GVV432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GVV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-GVV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HS423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HS425', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV437', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV438', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV455', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-HV456', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-I430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-I451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-I452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-IE401A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-IE401B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-IE401C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-IT401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-IT430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-LG436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-LSLL436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-LT436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-LT437', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-LV436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-M401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-M451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-M452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG401A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG401B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG420', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG422', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG435A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG435B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG438A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG438B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG451D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG451E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG452D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG452E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG453A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG453B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG454A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG454B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG455A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG455B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG456A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PG456B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV437', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV455', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PRV456', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSH431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSH453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSH454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSL430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSL431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSL453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSL454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSV430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSV430A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSV438', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSV455', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PSV456', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT422', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT432A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT433', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PT452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PV431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-PV436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-S450', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV424', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV425', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV434', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV453A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV453B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV453V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV454A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV454B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-SV454V', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE424', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE434A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE434B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE434C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE434D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE434E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TE436', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT422', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT431', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT433', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT435', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT470', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT471', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT472', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT473', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-TT474', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-XV439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-XV453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-XV454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-XV458', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-XV459', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-YA450', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-YS450', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH424', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH425', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH438', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH453', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH454', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH458', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSH459', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL424', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL425', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL430', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL432', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL433', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL434', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL437', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL439', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL451', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL452', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL453A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL453B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL453F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL453H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL454A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL454B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL454F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL454H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL458', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0400-ZSL459', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité de bisulfite de sodium', @LoginApprev + N'-0500', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT513', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT514', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-AT515', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-C503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-C504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-C505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-C506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-DK551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-DPT508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-DT508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-E504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-E504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-E507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-E551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-F502', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-F503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-F504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-F505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FI506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FI507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FI508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FI509', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FI530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO501', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO503A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO503B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO506~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO506~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO506~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO506~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FO506~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FSH500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FSH550', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT502', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT508I', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT513', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT514', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FT515', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV502', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV513', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV514', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-FV517', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-GDT820', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-GDT826', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-GDT827', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LG504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LG505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LSHH506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LSL530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT504N', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT504S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT506S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LT551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LV504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LV504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LV505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-LYT551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M505A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M505B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M509', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M531', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M551A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-M551B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P505A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P505B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P509', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P531', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P551A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-P551B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PB530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504I', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504J', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504K', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504L', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504M', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504N', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504O', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504P', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504Q', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504R', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG504S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG505C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG507A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG507B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG519', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PG550', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PI505A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PI505B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PR530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PRV550', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSL503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSV504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSV504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSV504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSV504D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PSV550', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT504D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-PT510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-S506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-SS~6160~2 (Unité SBS)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-SS~6160~3 (Charg. Wagon SBS)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-SS~6160~4 (Charg. Camion Caustique)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-SV530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-SV551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-T551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TC500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TC5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TC550A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE504D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE504G', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE504I', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE504J', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE505', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE515', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE516', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE517', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE519', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE552', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TE553', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG504H', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TG511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TT503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TT504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TT506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TT507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TT551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TV500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TV504', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TV507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TV550', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-TV551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-U530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-VB551', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS504A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS504B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS504C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS505A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS505B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS506', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS507A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS507B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XS509', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XV503', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XV507', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XV508', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XV517', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-XV530', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-YA516', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0500-YS515', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Entreposage et chargement', @LoginApprev + N'-0600', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-D631', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-DK630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-DK651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-DT650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E635F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-E654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FI630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FI635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FI635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FICV641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FICV642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FO651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FO652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FO653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FSH660', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FSL653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FSL654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT645', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FT650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FV643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-FV645', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-HS653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-HS654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-KA635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-KA650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LE632', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS631', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS632', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS633', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS661', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS662', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LS663', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LSHH635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LSHH643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LSHH661', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LSHH662', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LSHH663', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT631', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT640S', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LT654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-LV640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PA637A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PA637B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PA638A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PA638B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PDI630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG637A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG637B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG638A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG638B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG643A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG645B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PG660', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PRV630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PRV643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PRV660', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSL637', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSL638', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSLL637', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSLL638', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT637', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT638', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PT643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PV630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PV635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PV640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PV641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO635F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-RO643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SS635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SS635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV651A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV652A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV653A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-SV654A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE645', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE651A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE652A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE653A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE653B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE654A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TE654B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TI632', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TLSD563', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TLSD653A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TLSD653B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TLSD663', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT631', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT635B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT635C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT635D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TT654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV631', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TV660', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TWE632', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-TWXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XS653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-XV654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSH635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSH635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSH650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSH653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSH654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSL635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSL635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSL650', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSL653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-ZSL654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-M653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-P653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSV640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-PSV660', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-R640', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T635', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-T654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-U641', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-U642', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-U643', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-V630', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VB651', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VB652', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VB653', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VB654', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VVB635A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0600-VVB635B', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Périphérique', @LoginApprev + N'-0800', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LSHH663', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-DK831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-EA890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-F870', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI863', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI864', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI870', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI874', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI890~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FI890~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FK810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FK820', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FT801', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FT802', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FT833', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FT860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FT870', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-FV832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT801', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT802', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT803', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT804', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT805', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT806', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT807', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT808', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT809', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT812', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT813', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT815', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT816', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT817', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT818', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT821', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT822', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT823', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT824', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT825', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT828', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT829', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT833', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT834', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-GDT835', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-HV810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-HV811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LC830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG810~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG810~2', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG810~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG810~4', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG821', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LG861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LI890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LSHH812', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LSHH832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LSHH890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LT810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LT831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LT832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LT860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LT890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LV860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-LV890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M821', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M860A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M860B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-M890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P860A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P860B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-P890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG811A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG820B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG860A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG862', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG863', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PG890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI810A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI873', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PI874', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PL801', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PL802', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PRV873', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PSV820', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT801', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT862', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT863', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT864', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT865', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT867', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PT890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PV860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PV872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PV890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-PVXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-RO802', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-RO810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-RO811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-RO820', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-RO860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-S860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-S870', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV811', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV820', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV835', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV860A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV860B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV891', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-SV892', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T821', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T822', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-T832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TE861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TE862', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TE863', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TE864', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TG865', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT873', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TT890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-TV860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-U831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-U832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-U833', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-V860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-V890', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-VVB831', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-VVB832', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XS810', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XS830', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XS860A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XS860B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV835', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV861', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV891', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-XV892', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSH835', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSH860', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSH891', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSH892', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSL835', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0800-ZSL860', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Unité d''eau acide', @LoginApprev + N'-0900', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-C901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-E920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-E930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-E940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-F901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-F911', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-F912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FE941', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT910', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT931~1', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT931~3', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FT940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FV910', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-FV920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-HS931A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-HS933A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-HV931B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-HV933B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LG900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LG912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LG920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LG931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LG940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSH931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSHH900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSHH931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSHH940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSL931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LSL940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LT912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LT920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-LV920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-M901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-M940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-P901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-P940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG913', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG920A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG931A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PG942', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PGXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PI901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PI901A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PIXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSH940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSL940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSV912', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSV930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSV931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PSV940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT864', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT911', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT912A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT912B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PT931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-PV930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE903', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE910', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE920', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE941', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE942', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE943', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TE944', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TT930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TV930', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-TWXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-V931', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-V940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-XS901', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-XS940', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-XV931A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-XV933A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSH931A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSH933A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSL931A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSL931B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSL933A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-0900-ZSL933B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Vapeur et condensat', @LoginApprev + N'-1100', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AE1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AE1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AE1109', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AT1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AT1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AT1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-AT1162', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-B1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-B1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-B1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-BE1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-BE1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-BE1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-D1150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DF1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DF1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DK1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DK1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DPSL1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DPSL1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DPSL1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DPT1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-DPT1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-F1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-F1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FD1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FD1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FD1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FE1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FE1126', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1105', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1142A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FI1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FK1105', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FO1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FO1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FO1142A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FO1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FS1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1126', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1136', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1144', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1146', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FT1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FTXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-FV1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1125', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1133', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1163', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GSV1164', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GVV1123', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GVV1133', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-GVV1163', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-HS1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-HS1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-HV1126', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-IT1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-IT1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-IT1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1120A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1120B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1130A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1130B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LG1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LI1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LI1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LSLL1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LT1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LV1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LV1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LV1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LV1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-LV1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-M1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-OSV1127', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-OSV1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1102', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1103', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-P1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PCV1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1100C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1101B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1103', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1125', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1137A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1137B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1138A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1138B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1141A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1160A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1160B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1160C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PG1B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PGXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1102', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1103', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PRV1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSH1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSH1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSH1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSH1162', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSHH1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1123', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1133', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSL1162', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1102', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1102A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1103', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1103A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1120A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1120B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1120C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1120D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1130A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1130B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1130D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1140A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1140B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1140C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1140D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1142A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1160A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1160B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PSV1162', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1123', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1140A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1151', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PT1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1151', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PV1152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-PVV1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-RO1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-RO1102', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-RO1150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-RO1B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-S1110', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-S1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SD1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SS1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1123', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1125', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1162', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1163A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-SV1164', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-T1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-T1107', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-T1108', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-T1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-T1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TB1102', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TB1103', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TB1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TB1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TB1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TE1126', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TE1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TE288', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TG1152A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TG1153', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TI1139', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TSL1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TSL1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TT1136', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TT1152', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-TT1166', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-U1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-U1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-U1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1100B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1140', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1144', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1145', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1146F', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1147', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1148A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1148B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1149A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1149B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-V1149C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1101', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1141', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1143', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XS1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XV1100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XV1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XV1142', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XV1150A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-XV1150B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-YL1160A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-YL1160B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-YL1160C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-YL1160D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-YL1160E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZS1100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZS1100B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1120', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1130', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1131', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSH1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1121', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1122', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1124', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1125', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1126', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1127', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1132', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1133', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1134', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1135', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1160', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1161', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1163', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1100-ZSL1164', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Azote', @LoginApprev + N'-1200', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-FE1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-FT1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-FT1203', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PG1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PG1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PRV1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PRV1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PRV1204', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PSV1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PSV1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PT1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PT1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-PV1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-RO1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-RO1202', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-ROXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-TT1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-XV1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-ZSH1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1200-ZSL1201', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Eau de service', @LoginApprev + N'-1300', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AE1307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1306', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AT1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AV1307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-AV1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-CT1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-CT1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-CT1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-DF1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-DF1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-DF1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1327A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1327B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1328A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-F1328B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FAXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FI1304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FI1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FI1332', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FICV1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FICV1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FICV1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FIXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FO1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FQ1340', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1328', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1329', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FT1331', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-FV1331', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HS1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HS1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HS1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HX1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HX1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HX1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HZ1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HZ1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-HZ1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LG1305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LG1307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LSL1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LSL1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LSL1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LT1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LT1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LT1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LV1320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-LV1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-M1330B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1304', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1306', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1309', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-P1330B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PCV1301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PCV1303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PCV1306', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PCV1308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PCVXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1303A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1306', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1308', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1330B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1330D', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PG1330E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PGXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PI1330E', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PIXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PSV1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PSV1326A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PT1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PT1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PT1330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-PT1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-SB1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-SB1330B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-SV1303', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-T1301', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-T1302', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-T1305', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-T1307', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-TB1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-TGXXX', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-TT1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-TT1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-U1340', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSD1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSD1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSD1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSH1325A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSH1325B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-VSH1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1325', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1325C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1326', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1327', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1330A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1300-XS1330B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Air comprimé', @LoginApprev + N'-1400', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-AT1410', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-CP1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-CP1402', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-CP1404', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-DE1402', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-E1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-F1410A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-F1410B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-F1411A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-F1411B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-FE1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-FT1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-M1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-M1404', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PG1402', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PG1402A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PG1403', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1400', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1401A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1402', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1403', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1410', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PSV1411', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PT1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PT1410', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-PT1411', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-RO1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-SV1423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-TT1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1402', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1403', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1404', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1410A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1410B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1411A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-V1411B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-XV1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-XV1423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-ZSH1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-ZSH1423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-ZSL1401', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1400-ZSL1423', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Combustible / Stockage et distribution', @LoginApprev + N'-1500', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-DK1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-DK1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-E1510A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-E1510B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-E1511A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-E1511B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-E1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-ES1521', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-F1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-FE1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-FIQ1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LA1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LA1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LG1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LG1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LG1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LG1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LIR1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LT1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-LT1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-M1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-M1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-M1521', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-P1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-P1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-P1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-P1521', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PG1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PG1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PG1513', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PG1521A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PG1521B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PI1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1510A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1510B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1511A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1511B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PSV1511C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PT1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-PV1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-SV1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-SW1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-T1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-T1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-T1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-T1520', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TB1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TT1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TT1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TT1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TV1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TV1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-TV1512', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-VB1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-VB1511', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-XS1510', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-XV1521', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1500-ZSL1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Électricité', @LoginApprev + N'-1800', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-DE1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-DE1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-EE1812 (CCM~A)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-EE1813 (CCM~B)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-EE1814 (CCM~C)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-EE1826 (CCM~D)', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-F1841', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-GN1841', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-GN1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-GN1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-HV1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-HV1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LG1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LG1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LS1871B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LS1872B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LSH1871A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LSH1872A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LT1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-LT1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-PSV1841', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-PSV1841A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-T1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-T1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-TB1841', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-ZSL1871', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-1800-ZSL1872', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Système égout et traitement', @LoginApprev + N'-3300', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-AT3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-AT3350', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-LT3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-TT3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-TT3350', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-M3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-P3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3310', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3330', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3340', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3350', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-SW3360', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-U3320', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-3300-U3350', 0, 0, 3, @plantid, N'fr', 2)
commit transaction
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
begin transaction
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Bâtiment', @LoginApprev + N'-4000', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-AC4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-AC4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-AC5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4400', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4600', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4700', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4710', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4720', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4850', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-BG4950', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FK4100A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FK4100B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FQ4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FQ5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FSH4600', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FSH4900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FT4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-FT4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-GD4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-GD4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-GD5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-HS4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-HS4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PA4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PA4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSH4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSH4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSL4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSL4200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4400A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4400B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4600', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4900A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-PSV4900B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4400A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4400B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4600A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4600B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4900A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TC4900B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TV4600', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-TV4900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-VB4150', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-VB4900A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-4000-VB4900B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Bâtiment', @LoginApprev + N'-5000', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PSV5000', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PSV5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-VB5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-XA5900A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-XA5900B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-HS5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-HS5900A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-HS5900B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PA5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PSH5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PSL5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-PT5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5000', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5100', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5200', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5250', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5300', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5400', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5500', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5600', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5700', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5800', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5801', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5802', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-5000-BG5900', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Divers', @LoginApprev + N'-6000', 0, 0, 2, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-BG6000', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-PSV6160A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-PSV6160B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-PSV6160C', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-SS6160~5', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-XA6000A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-XB6000B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-HS6000A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-HS6000B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-TC6160A', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-TC6160B', 0, 0, 3, @plantid, N'fr', 2)
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'', @LoginApprev + N'-6000-TC6160C', 0, 0, 3, @plantid, N'fr', 2)


COMMIT TRANSACTION

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;

---------------------------------------------------
---  Insert Operational Modes for each Unit   ---
---------------------------------------------------

	BEGIN TRANSACTION

	INSERT INTO FunctionalLocationOperationalMode
	( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
	(
		Select
			FunctionalLocation.Id,
			0,
			0,
			GETDATE()
		FROM
			FunctionalLocation
		WHERE
			SiteId = @siteid
			AND Level = 3
			AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
	)
	COMMIT TRANSACTION



----------------------------------------------------
----  Update Ancestor Table                           ---
----------------------------------------------------
-- create a temp index for fast querying
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([SiteId] , [Level])
INCLUDE ([FullHierarchy],[Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = OFF
)
ON [PRIMARY];
  

-- Insert the Ancestor records for the new site Flocs


	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
		SELECT 
			c.id, a.id, a.[Level]
			FROM FunctionalLocation a
			INNER JOIN FunctionalLocation c 
				ON c.siteid = a.siteid and 
				c.[Level] > a.[Level] and
				CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
			where
				c.SiteId = @SiteId
	)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];


if not exists(select 1 from ShiftHandoverConfiguration where Name= N'Relève de Quart Quotidien' and deleted = 0)
begin
	insert ShiftHandoverConfiguration ( Name,Deleted )  select N'Relève de Quart Quotidien',0
end


if not exists(select 1 from SiteConfiguration where siteid = @siteid)
begin
	insert into SiteConfiguration ( 
	SiteId,
	DaysToDisplayActionItems,
	DaysToDisplayShiftLogs,
	DaysBeforeArchivingClosedWorkPermits,
	DaysBeforeDeletingPendingWorkPermits,
	DaysBeforeClosingIssuedWorkPermits,
	AutoApproveWorkOrderActionItemDefinition,
	AutoApproveSAPAMActionItemDefinition,
	AutoApproveSAPMCActionItemDefinition,
	CreateOperatingEngineerLogs,
	WorkPermitNotApplicableAutoSelected,
	WorkPermitOptionAutoSelected,
	OperatingEngineerLogDisplayName,
	DaysToEditDeviationAlerts,
	DaysToDisplayShiftHandovers,
	SummaryLogFunctionalLocationDisplayLevel,
	ShowActionItemsByWorkAssignmentOnPriorityPage,
	DaysToDisplayDeviationAlerts,
	AllowStandardLogAtSecondLevelFunctionalLocation,
	DorCutoffTime,
	DaysToDisplayWorkPermitsBackwards,
	DaysToDisplayLabAlerts,
	LabAlertRetryAttemptLimit,
	RequireActionItemResponseLog,
	ActionItemRequiresApprovalDefaultValue,
	HideDORCommentEntry,
	DaysToDisplayCokerCards,
	ActionItemRequiresResponseDefaultValue,
	ShowActionItemsOnShiftHandover,
	UseNewPriorityPage,
	ShowShiftHandoversByWorkAssignmentOnPriorityPage,
	DaysToDisplayDirectivesOnPriorityPage,
	DaysToDisplayShiftHandoversOnPriorityPage,
	DisplayActionItemWorkAssignmentOnPriorityPage,
	DaysToDisplayPermitRequestsBackwards,
	DaysToDisplayPermitRequestsForwards,
	DaysToDisplayWorkPermitsForwards,
	DisplayActionItemCommentOnly,
	DefaultNumberOfCopiesForWorkPermits,
	ShowFollowupOnLogForm,
	AllowCreateALogForEachSelectedFlocOnLogForm,
	ShowAdditionalDetailsOnLogFormByDefault,
	Culture,
	ShowWorkPermitPrintingTabInPreferences,
	ShowDefaulPermitTimesTabInPreferences,
	DaysToDisplayTargetAlertsOnPriorityPage,
	LoginFlocSelectionLevel,
	UseCreatedByColumnForLogs,
	ShowIsModifiedColumnForLogs,
	ItemFlocSelectionLevel,
	DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
	PreShiftPaddingInMinutes,
	PostShiftPaddingInMinutes,
	DaysToDisplayFormsBackwards,
	DaysToDisplayFormsForwards,
	DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
	DaysToDisplayFormsBackwardsOnPriorityPage,
	FormsFlocSetTypeId,
	DaysToDisplaySAPNotificationsBackwards,
	ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab,
	AllowCombinedShiftHandoverAndLog,
	ShowCreateShiftHandoverMessageFromNewLogClick,
	DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
	DefaultTargetDefinitionRequiresResponseWhenAlertedValue,
	CollectAnalyticsData,
	DaysToDisplayDirectivesBackwards,
	DaysToDisplayDirectivesForwards,
	UseLogBasedDirectives,
	ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab,
	RememberActionItemWorkAssignment,
	MaximumDirectiveFLOClevel,
	MaximumAllowableExcursionEventDurationMins,
	MaximumAllowableExcursionEventTimeframeMins,
	DaysToDisplayEventsBackwards,
	DaysToDisplayDocumentSuggestionFormsBackwards,
	DaysToDisplayDocumentSuggestionFormsForwards,
	DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage)  
	select 
	@siteid,
	7,7,7,7,1,1,1,1,1,1,1,N'Ingénieur de procédés l''entrée', -- OperatingEngineerLogDisplayName
	7,7,2,0,30,1,'Jan  1 1900 10:00AM', -- DorCutoffTime
	15,30,3, 1,0,1,14, -- DaysToDisplayCokerCards
	1,1,1,0,3,3, -- DaysToDisplayShiftHandoversOnPriorityPage
	1,0,0,0,1,1,1,1,0, -- ShowAdditionalDetailsOnLogFormByDefault
	'fr',0,0,0,7,0,0,5,1, -- DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs
	0, 0, -- PreShiftPaddingInMinuts, PostShiftPaddingInMinutes
	3,null,1,3,0,1, -- DaysToDisplaySAPNotificationsBackwards
	1,0,0,null,0,1, -- CollectAnalyticsData
	3,null,0,0,0,1, -- MaximumDirectiveFLOCLevel
	0,120,0, -- DaysToDisplayEventsBackwards
	30,null,30 -- DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage
end

if not exists(select 1 from SiteConfigurationDefaults where siteid = @siteid)
begin
	insert into SiteConfigurationDefaults values (@siteid,1)
end

insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Procédé','Proc',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Environnement','Env',0,1,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Production','Prod',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Équipement','Equip',1,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Activité de Routine','Rtn',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select N'Réglementaires','Reg',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid
--insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Key Performance Indicators','KPIs',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,@siteid

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = @siteid and f.FullHierarchy = @LoginApprev and bc.SiteId = @siteid and bc.Deleted = 0


delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join WorkAssignment on WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.SiteId = @siteid 

alter table UserLoginHistoryFunctionalLocation nocheck constraint FK_UserLoginHistoryFunctionalLocation_UserLoginHistory
delete from UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation inner join FunctionalLocation on UserLoginHistoryFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.SiteId = @siteid and FunctionalLocation.FullHierarchy = 'UDS'
delete userloginhistory from userloginhistory inner join workassignment on userloginhistory.assignmentid = workassignment.id and WorkAssignment.SiteId = @siteid
alter table UserLoginHistoryFunctionalLocation check constraint FK_UserLoginHistoryFunctionalLocation_UserLoginHistory


delete from WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup inner join WorkAssignment on WorkAssignmentVisibilityGroup.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.SiteId = @siteid
delete from PriorityPageSectionConfigurationWorkAssignment from PriorityPageSectionConfigurationWorkAssignment inner join workassignment on PriorityPageSectionConfigurationWorkAssignment.workassignmentid = workassignment.id and workassignment.siteid = @siteid

delete from loghistory from loghistory inner join log on loghistory.id = log.id inner join workassignment on log.workassignmentid = workassignment.id and workassignment.siteid = @siteid
delete from LogFunctionalLocationList from LogFunctionalLocationList inner join log on LogFunctionalLocationList.logid = log.id inner join workassignment on log.workassignmentid = workassignment.id and workassignment.siteid = @siteid
delete from log from log inner join workassignment on log.workassignmentid = workassignment.id and workassignment.siteid = @siteid
delete from SummaryLogFunctionalLocationList from SummaryLogFunctionalLocationList inner join SummaryLog on SummaryLogFunctionalLocationList.SummaryLogId = SummaryLog.Id inner join WorkAssignment on summarylog.WorkAssignmentId = workassignment.Id and workassignment.SiteId = @siteid
delete from SummaryLog from SummaryLog inner join workassignment on SummaryLog.WorkAssignmentId = workassignment.Id and workassignment.SiteId = @siteid
delete from DirectiveWorkAssignment from DirectiveWorkAssignment inner join WorkAssignment on DirectiveWorkAssignment.WorkAssignmentId = workassignment.id and workassignment.SiteId = @siteid
delete from WorkAssignment where siteid = @siteid
delete from RoleElementTemplate from RoleElementTemplate inner join Role on RoleElementTemplate.RoleId = role.Id and role.SiteId = @siteid
delete from DirectiveRead from DirectiveRead inner join Directive on directiveread.DirectiveId = directive.Id inner join role on directive.CreatedByRoleId = role.id and role.siteid = @siteid
delete from Directive from Directive inner join role on directive.CreatedByRoleId = role.id and role.siteid = @siteid
delete role where siteid = @siteid

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Administrateur', 0, 'Administrator', @siteid, 1, 0, 0, 1, 'admino',0);
go
--Insert role elements here too to get the identity_current of role table
-- Administrator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log Based Directives, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (95,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Summary Logs, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restriction Definition - Restrictions, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restriction Definition - Restrictions, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (59,IDENT_CURRENT('ROLE')); 			-- Work Permits - Delete Non-Operations Permit, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (183,IDENT_CURRENT('ROLE')); 		-- Work Permits - Edit Permit Request, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (184,IDENT_CURRENT('ROLE')); 		-- Work Permits - Delete Permit Request, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (185,IDENT_CURRENT('ROLE')); 		-- Work Permits - Submit Permit Request, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (191,IDENT_CURRENT('ROLE')); 		-- Work Permits - Print Confined Space Documents, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (197,IDENT_CURRENT('ROLE')); 		-- Work Permits - Clone Permit Request, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (77,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (111,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Configure Business Categories, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (112,IDENT_CURRENT('ROLE')); 		-- Admin - Action Items - Associate Business Categories To Functional Locations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (73,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items & Targets - Manage Operational Modes, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (84,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items & Targets - Configure Automatic Re-Approval by Field, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (263,IDENT_CURRENT('ROLE')); 		-- Admin - Form - SWP Audit, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (135,IDENT_CURRENT('ROLE')); 		-- Admin - Lab Alerts - Configure Lab Alert, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (113,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Log Guidelines, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Summary Log Custom Fields, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Edit Log Templates, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (80,IDENT_CURRENT('ROLE')); 			-- Admin - Reports - Configure Plant Historian Tag List, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (107,IDENT_CURRENT('ROLE')); 		-- Admin - Restriction Reporting - Configure Restiction Reason Code, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (108,IDENT_CURRENT('ROLE')); 		-- Admin - Restriction Reporting - Associate Restriction Reason Codes to Functional Locations, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (109,IDENT_CURRENT('ROLE')); 		-- Admin - Restriction Reporting - Configure Time Limit for Deviation Response, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (127,IDENT_CURRENT('ROLE')); 		-- Admin - Restriction Reporting - Configure DOR Cutoff Time, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (274,IDENT_CURRENT('ROLE')); 		-- Admin - Restriction Reporting - Configure Restriction FLOCs for Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (82,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Work Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (85,IDENT_CURRENT('ROLE')); 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (142,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Unc Paths for Links, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (179,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Priorities Page, Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (204,IDENT_CURRENT('ROLE')); 		-- Admin - Site Configuration - Configure Area Labels, Administrator

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Opérateur', 0, 'Operator', @siteid, 0, 0, 0, 1, 'oper',0);
go
-- Operator Role Elements
--insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities-Form OP-14s - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (238,IDENT_CURRENT('ROLE')); 		-- Forms - View Form Overtime Request - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (283,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form  - Procedure Deviation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (215,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Navigation - Lab Alerts, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (131,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Create Lab Alert Definitions , Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (132,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Edit Lab Alert Definitions , Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,IDENT_CURRENT('ROLE')); 			-- Logs Directive - Delete Log Based Directives , Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs , Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (50,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with no restiction, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (52,IDENT_CURRENT('ROLE')); 			-- Work Permits - Close permit , Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (57,IDENT_CURRENT('ROLE')); 			-- Work Permits - Approve Non-Operations Permit, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (58,IDENT_CURRENT('ROLE')); 			-- Work Permits - Reject Non-Operations Permit, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (59,IDENT_CURRENT('ROLE')); 			-- Work Permits - Delete Non-Operations Permit, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (182,IDENT_CURRENT('ROLE')); 			-- Work Permits - Create Permit Request, Operator

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Adjoint Opérations', 0, 'AdjointOperations', @siteid, 0, 0, 0, 1, 'AdjointOperations',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 			-- Action Items - Approve Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 			-- Action Items - Reject Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 			-- Action Items - Create Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 			-- Action Items - Edit Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 			-- Action Items - Delete Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (238,IDENT_CURRENT('ROLE')); 		-- Forms - View Form - Overtime Request 
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (196,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (208,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Oilsands Training Form
insert into RoleElementTemplate (RoleElementId, RoleId) values (226,IDENT_CURRENT('ROLE')); 		-- Forms - No reapproval required for GN-59 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (229,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-24 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (230,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-6 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (233,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-75A End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (234,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-1 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (283,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (215,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Navigation - Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (131,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Create Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (132,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Edit Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,IDENT_CURRENT('ROLE')); 			-- Logs Directive - Delete Log Based Directives 
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Create Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Edit Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (103,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (104,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Respond to Deviation in Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (105,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Deviation Response For Alert In Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (50,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with no restiction
insert into RoleElementTemplate (RoleElementId, RoleId) values (52,IDENT_CURRENT('ROLE')); 			-- Work Permits - Close permit 
insert into RoleElementTemplate (RoleElementId, RoleId) values (57,IDENT_CURRENT('ROLE')); 			-- Work Permits - Approve Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (58,IDENT_CURRENT('ROLE')); 			-- Work Permits - Reject Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (59,IDENT_CURRENT('ROLE')); 			-- Work Permits - Delete Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (182,IDENT_CURRENT('ROLE')); 		-- Work Permits - Create Permit Request
insert into RoleElementTemplate (RoleElementId, RoleId) values (186,IDENT_CURRENT('ROLE')); 		-- Work Permits - Import Permit Request

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Tableauteur', 0, 'Tableauteur', @siteid, 0, 0, 0, 1, 'Tableauteur',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities 
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities-Form OP-14s 
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (196,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (283,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (215,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Navigation - Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (131,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Create Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (132,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Edit Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (134,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Respond to Lab Alert 
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Entretien', 0, 'Entretien', @siteid, 0, 0, 0, 1, 'Entretien',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 			-- Action Items - Create Action Item Definition 
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (196,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (283,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (21,IDENT_CURRENT('ROLE')); 			-- Targets - Comment on Target Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (42,IDENT_CURRENT('ROLE')); 			-- Targets - Respond to Target Alert
insert into RoleElementTemplate (RoleElementId, RoleId) values (83,IDENT_CURRENT('ROLE')); 			-- Targets - Configure Pre-Approved Target Ranges
insert into RoleElementTemplate (RoleElementId, RoleId) values (181,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Permit Requests
insert into RoleElementTemplate (RoleElementId, RoleId) values (192,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Confined Space Documents
insert into RoleElementTemplate (RoleElementId, RoleId) values (224,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Priorities - Work Permits
insert into RoleElementTemplate (RoleElementId, RoleId) values (26,IDENT_CURRENT('ROLE')); 		-- Work Permits - Reject Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (49,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with some restrictions

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Ingénieur', 0, 'Engineer', @siteid, 0, 0, 0, 1, 'ing',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 			-- Action Items - Create Action Item Definition 
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Directeur', 0, 'Directeur', @siteid, 0, 0, 0, 1, 'Directeur',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (215,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Navigation - Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (131,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Create Lab Alert Definitions
insert into RoleElementTemplate (RoleElementId, RoleId) values (132,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Edit Lab Alert Definitions
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Create Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Edit Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (103,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (104,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Respond to Deviation in Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (105,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Deviation Response For Alert In Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (122,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Configure Summary Log Custom Fields
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE')); 		-- Admin - Logs - Edit Log Templates

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (N'Superviseur Opérations', 0, 'SupervisorOperation', @siteid, 0, 0, 0, 1, 'SupervisorOperation',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (238,IDENT_CURRENT('ROLE')); 		-- Forms - View Form - Overtime Request 
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (196,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (234,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-1 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (215,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Navigation - Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (131,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Create Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (132,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - Edit Lab Alert Definitions 
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,IDENT_CURRENT('ROLE')); 			-- Logs Directive - Delete Log Based Directives 
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (89,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Create Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (92,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - Edit Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (103,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (104,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Respond to Deviation in Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (105,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Edit Deviation Response For Alert In Shift
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (50,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with no restiction
insert into RoleElementTemplate (RoleElementId, RoleId) values (52,IDENT_CURRENT('ROLE')); 			-- Work Permits - Close permit 
insert into RoleElementTemplate (RoleElementId, RoleId) values (57,IDENT_CURRENT('ROLE')); 			-- Work Permits - Approve Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (58,IDENT_CURRENT('ROLE')); 			-- Work Permits - Reject Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (59,IDENT_CURRENT('ROLE')); 			-- Work Permits - Delete Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (182,IDENT_CURRENT('ROLE')); 		-- Work Permits - Create Permit Request

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('ESP', 0, 'ESP', @siteid, 0, 0, 0, 1, 'ESP',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (273,IDENT_CURRENT('ROLE')); 		-- Action Items - View Future Action Items, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 			-- Action Items - Create Action Item Definition, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Defintion 
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Forms, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Form OP-14s, 
insert into RoleElementTemplate (RoleElementId, RoleId) values (238,IDENT_CURRENT('ROLE')); 		-- Forms - View Form - Overtime Request 
insert into RoleElementTemplate (RoleElementId, RoleId) values (280,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Procedure Deviation 
insert into RoleElementTemplate (RoleElementId, RoleId) values (196,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (198,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form 
insert into RoleElementTemplate (RoleElementId, RoleId) values (234,IDENT_CURRENT('ROLE')); 		-- Forms - No approval required for GN-1 End Date Change
insert into RoleElementTemplate (RoleElementId, RoleId) values (282,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (283,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (284,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form  - Procedure Deviation - Forms
insert into RoleElementTemplate (RoleElementId, RoleId) values (130,IDENT_CURRENT('ROLE')); 		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,IDENT_CURRENT('ROLE')); 			-- Logs Directives - View Log Based Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,IDENT_CURRENT('ROLE')); 		-- Logs Directives - View Standing Orders
insert into RoleElementTemplate (RoleElementId, RoleId) values (97,IDENT_CURRENT('ROLE')); 		    -- Logs Directives - Create Log Based Directives
insert into RoleElementTemplate (RoleElementId, RoleId) values (99,IDENT_CURRENT('ROLE')); 			-- Logs Directive - Delete Log Based Directives 
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs 
insert into RoleElementTemplate (RoleElementId, RoleId) values (216,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - View Navigation - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (101,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Create Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (102,IDENT_CURRENT('ROLE')); 		-- Restriction Reporting - Delete Restiction Definition - Restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers
insert into RoleElementTemplate (RoleElementId, RoleId) values (13,IDENT_CURRENT('ROLE')); 			-- Targets - Approve Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (14,IDENT_CURRENT('ROLE')); 			-- Targets - Reject Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (17,IDENT_CURRENT('ROLE')); 			-- Targets - Edit Target Defintion
insert into RoleElementTemplate (RoleElementId, RoleId) values (21,IDENT_CURRENT('ROLE')); 			-- Targets - Comment on Target Definition
insert into RoleElementTemplate (RoleElementId, RoleId) values (42,IDENT_CURRENT('ROLE')); 			-- Targets - Respond to Target Alert
insert into RoleElementTemplate (RoleElementId, RoleId) values (83,IDENT_CURRENT('ROLE')); 			-- Targets - Configure Pre-Approved Target Ranges
insert into RoleElementTemplate (RoleElementId, RoleId) values (181,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Permit Requests
insert into RoleElementTemplate (RoleElementId, RoleId) values (192,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Confined Space Documents
insert into RoleElementTemplate (RoleElementId, RoleId) values (224,IDENT_CURRENT('ROLE')); 		-- Work Permits - View Priorities - Work Permits
insert into RoleElementTemplate (RoleElementId, RoleId) values (26,IDENT_CURRENT('ROLE')); 		-- Work Permits - Reject Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (49,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with some restrictions
insert into RoleElementTemplate (RoleElementId, RoleId) values (50,IDENT_CURRENT('ROLE')); 			-- Work Permits - Copy work permit with no restiction
insert into RoleElementTemplate (RoleElementId, RoleId) values (52,IDENT_CURRENT('ROLE')); 			-- Work Permits - Close permit 
insert into RoleElementTemplate (RoleElementId, RoleId) values (57,IDENT_CURRENT('ROLE')); 			-- Work Permits - Approve Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (58,IDENT_CURRENT('ROLE')); 			-- Work Permits - Reject Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (59,IDENT_CURRENT('ROLE')); 			-- Work Permits - Delete Non-Operations Permit
insert into RoleElementTemplate (RoleElementId, RoleId) values (182,IDENT_CURRENT('ROLE')); 		-- Work Permits - Create Permit Request
insert into RoleElementTemplate (RoleElementId, RoleId) values (183,IDENT_CURRENT('ROLE')); 		-- Work Permits - Edit Permit Request
insert into RoleElementTemplate (RoleElementId, RoleId) values (186,IDENT_CURRENT('ROLE')); 		-- Work Permits - Import Permit request
insert into RoleElementTemplate (RoleElementId, RoleId) values (189,IDENT_CURRENT('ROLE')); 		-- Work Permits - Create Confined Space Documents
insert into RoleElementTemplate (RoleElementId, RoleId) values (84,IDENT_CURRENT('ROLE')); 			-- Admin - Action Items & Targets - Configure Automatic Re-Approval by Field
insert into RoleElementTemplate (RoleElementId, RoleId) values (129,IDENT_CURRENT('ROLE')); 		-- Admin Logs - Edit Log Templates

Declare @sitename varchar(40) = 'Montréal usine de soufre'
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Lecture seulement', 0, 'ReadUser', @siteid, 0, 1, 0, 0, 'read',1);

--Add tech admin role---------------
go
declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
insert into role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('Technical Administrator', 0, 'TechnicalAdmin', @siteid, 0,0,0,0,'techadmin',0);
go
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (24,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (96,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (178,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (181,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (202,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (213,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (220,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (221,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (222,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (225,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (240,IDENT_CURRENT('ROLE'));
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE'));

declare @siteid bigint 
declare @LoginApprev char(3) = 'UDS' -- new site (Montreal Sulphur Refinery)
declare @plantid bigint = 304 --Ident_current('plant')
begin
	select @siteid = id from site where ActiveDirectoryKey = 'MUDS'
end
Declare @sitename varchar(40) = N'Montréal usine de soufre'
-------------------------------- Work Assignments Start --------------------------------------

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Administrateur',@sitename + N' Administrateur',@siteid, 0, (select ID from Role where SiteId = @siteid and Name = N'Administrateur'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Opérateur',@sitename + N' Opérateur',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Opérateur'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Adjoint Opérations',@sitename + N' Adjoint Opérations',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Adjoint Opérations'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Tableauteur',@sitename + N' Tableauteur',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Tableauteur'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Entretien',@sitename + N' Entretien',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Entretien'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Ingénieur',@sitename + N' Ingénieur',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Ingénieur'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Directeur',@sitename + N' Directeur',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Directeur'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Lecture seulement',@sitename + N' Lecture seulement',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Lecture seulement'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + N' Superviseur Opérations',@sitename + N' Superviseur Opérations',@siteid, 0, (select id from Role where SiteId = @siteid and Name = N'Superviseur Opérations'), 'General', 1, 1, 0, 1);

insert into WorkAssignment 
([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values (@LoginApprev + ' ESP',@sitename + ' ESP',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'ESP'), 'General', 1, 1, 0, 1);


-------------------------------- Work Assignment Functional Locations Start --------------------------------------

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Administrateur' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Opérateur' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Adjoint Opérations' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Tableauteur' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Entretien' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Ingénieur' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Directeur' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Lecture seulement' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Technical Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' Superviseur Opérations' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = @LoginApprev and a.name = @LoginApprev + N' ESP' and a.SiteId = @siteid;

-------------------------------- Visibility Group Start --------------------------------------

--SET IDENTITY_INSERT [VisibilityGroup] ON;


	delete from WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup inner join WorkAssignment on WorkAssignmentVisibilityGroup.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.SiteId = @siteid
	delete from VisibilityGroup where SiteId = @siteid
	
	insert into VisibilityGroup ([Name], SiteId, IsSiteDefault, [Deleted])
	select N'Operations', @siteid, 1, 0;


--SET IDENTITY_INSERT [VisibilityGroup] OFF;
-------------------------------- Work Assignment Visibiliy Group Start --------------------------------------
--------------------------------------------------------------------------------
---  Insert Work Assignment Visibility Group for each Work Assignment   ---
--------------------------------------------------------------------------------

BEGIN TRANSACTION
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			IDENT_CURRENT('VisibilityGroup'), -- Operations visibility group for the new site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=IDENT_CURRENT('VisibilityGroup') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			IDENT_CURRENT('VisibilityGroup'), -- Operations visibility group for Fort Hills Major Projects
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=IDENT_CURRENT('VisibilityGroup') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)
COMMIT TRANSACTION

GO

