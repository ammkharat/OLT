

declare @roleId bigint;

select @roleId = Id from Role where SiteId = 8 and Name = 'TA Team Leader'

delete from RoleElementTemplate where RoleId = @roleId and RoleElementId in (23, 26, 27, 29, 31, 46, 52, 86)



GO

