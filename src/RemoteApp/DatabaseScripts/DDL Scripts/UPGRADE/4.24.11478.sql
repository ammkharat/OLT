if not exists (select 1 from dbo.dropdownvalue where [key]='gn75b_equipment_types' and siteid = 1)
begin
SET IDENTITY_INSERT dbo.DropdownValue off
insert into DropdownValue ([key],Value,Deleted,DisplayOrder,SiteId) values 
('gn75b_equipment_types','Pump',0,1,1),
('gn75b_equipment_types','Compressor',0,2,1),
('gn75b_equipment_types','Exchanger',0,3,1),
('gn75b_equipment_types','Piping Circuit',0,4,1),
('gn75b_equipment_types','Control Valve',0,5,1),
('gn75b_equipment_types','Vessel',0,6,1)
SET IDENTITY_INSERT dbo.DropdownValue On
end

if not exists (select 1 from dbo.dropdownvalue where [key]='gn75b_isolation_types' and siteid = 1)
begin
SET IDENTITY_INSERT dbo.DropdownValue off
insert into DropdownValue ([key],Value,Deleted,DisplayOrder,SiteId) values 
('gn75b_isolation_types','Single Valve',0,1,1),
('gn75b_isolation_types','DB&B',0,2,1),
('gn75b_isolation_types','Air Gap',0,3,1),
('gn75b_isolation_types','Breaker',0,4,1)
SET IDENTITY_INSERT dbo.DropdownValue On
end




GO

