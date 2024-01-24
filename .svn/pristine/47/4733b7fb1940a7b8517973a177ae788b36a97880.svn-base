-- Remove Targets and Permits Role Elements from Firebag and MacKay River Users
DELETE 
	[UserRoleElements] 
FROM 
[UserRoleElements] 
INNER JOIN RoleElement ON [UserRoleElements].RoleElementId = [RoleElement].[Id]
INNER JOIN [User] ON [User].[Id] = [UserRoleElements].[UserId] 
INNER JOIN [UserSite] ON [User].[Id] = [UserSite].[UserId]
WHERE 
	(
	lower(RoleElement.[Name]) like '%permit%' or 
	lower(RoleElement.[Name]) like '%target%' or
	lower(RoleElement.[Name]) like '%plant historian%'
	)
and 
siteid in (5, 7)

GO
alter table [user]
alter column OrgUnitId bigint null;
GO
