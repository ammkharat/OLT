

alter table AreaLabel add AllowManualSelection bit;
alter table AreaLabel add SAPPlannerGroup varchar(6) null;
go

update AreaLabel set AllowManualSelection = 1;
go

alter table AreaLabel alter column AllowManualSelection bit not null;
go

update AreaLabel set SAPPlannerGroup = 'ED1' where Name = 'Heavy Oils' and SiteId = 8;
update AreaLabel set SAPPlannerGroup = 'ED2' where Name = 'Light Oils' and SiteId = 8;
insert into AreaLabel (Name, SiteId, DisplayOrder, Deleted, AllowManualSelection, SAPPlannerGroup) values ('Synthetic Oils', 8, 3, 0, 0, 'ED3');
update AreaLabel set DisplayOrder = 4 where Name = 'Syncrude' and SiteId = 8;
update AreaLabel set DisplayOrder = 5 where Name = 'Unionfining' and SiteId = 8;
update AreaLabel set SAPPlannerGroup = 'ED4', DisplayOrder = 6 where Name = 'Utilities' and SiteId = 8;
update AreaLabel set SAPPlannerGroup = 'ED5', DisplayOrder = 7 where Name = 'Pumping & Shipping' and SiteId = 8;
update AreaLabel set SAPPlannerGroup = 'ED6', DisplayOrder = 8 where Name = 'Shift Supervisor' and SiteId = 8;







GO

