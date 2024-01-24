-- Delete existing OilSands users and have then created with the new tool.
DELETE 
	[UserLayoutPreference]
FROM
	[UserLayoutPreference]
INNER JOIN [UserSite] ON [UserLayoutPreference].[UserId] = [UserSite].[UserId]
WHERE 
	SiteId IN (3,4)

DELETE 
	[UserRoleElements] 
FROM 
[UserRoleElements] 
INNER JOIN RoleElement ON [UserRoleElements].RoleElementId = [RoleElement].[Id]
INNER JOIN [User] ON [User].[Id] = [UserRoleElements].[UserId] 
INNER JOIN [UserSite] ON [User].[Id] = [UserSite].[UserId]
WHERE 
siteid in (3, 4)

DELETE
	[UserFunctionalLocationPreference]
FROM
	[UserFunctionalLocationPreference]
INNER JOIN [UserSite] ON [UserFunctionalLocationPreference].[UserId] = [UserSite].[UserId]
WHERE 
siteid in (3, 4)

DELETE 
	[user]
FROM
	[user]
INNER JOIN [UserSite] ON [User].[Id] = [UserSite].[UserId]
WHERE 
	SiteId IN (3,4)

GO
