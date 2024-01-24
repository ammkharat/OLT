IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountRolesUsingRoleElementInSite')
	BEGIN
		DROP Procedure [dbo].CountRolesUsingRoleElementInSite
	END
GO

CREATE Procedure [dbo].CountRolesUsingRoleElementInSite
	(
		@SiteId [bigint],
		@RoleElementId [bigint]
	)
AS

SELECT
	Count(ret.RoleId) as COUNT
FROM
	RoleElementTemplate ret
	inner join Role r on r.Id = ret.RoleId
WHERE
	ret.RoleElementId = @RoleElementId and
	r.SiteId = @SiteId
	
GO

GRANT EXEC ON CountRolesUsingRoleElementInSite TO PUBLIC
GO