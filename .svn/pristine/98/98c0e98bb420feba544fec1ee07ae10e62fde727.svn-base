
declare @PermissionAlreadyExists bit;

select @PermissionAlreadyExists = count(*) from RoleElementTemplate where RoleElementId = 225 and RoleId in (select Id from Role where Name = 'Administrateur des Opérations')

if @PermissionAlreadyExists = 0
begin

insert into RoleElementTemplate (RoleElementId, RoleId)  
select 225, r.Id  
from Role r  
where r.Name in ('Administrateur des Opérations');

end





GO

