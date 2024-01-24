
alter table [Role] add IsDefaultReadOnlyRoleForSite bit null;
go

update [Role] set IsDefaultReadOnlyRoleForSite = IsReadOnlyRole;
go

alter table [Role] alter column IsDefaultReadOnlyRoleForSite bit not null;
go

update [Role] set IsReadOnlyRole = 1 where ActiveDirectoryKey = 'EUReadUser';




GO

