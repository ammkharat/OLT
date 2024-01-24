if not exists (select * from RoleElement where RoleElement.Id = 285)
begin
insert into RoleElement (id,Name,FunctionalArea) values (285,'Create Form - Training','Forms')
end 

if not exists (select * from RoleElement where RoleElement.Id = 286)
begin
insert into RoleElement (id,Name,FunctionalArea) values (286,'View Form - Training','Forms')
end 

if not exists (select * from RoleElement where RoleElement.Id = 287)
begin
insert into RoleElement (id,Name,FunctionalArea) values (287,'Edit Form - Training','Forms')
end 

if not exists (select * from RoleElement where RoleElement.Id = 288)
begin
insert into RoleElement (id,Name,FunctionalArea) values (288,'Close Form - Training','Forms')
end 



GO

