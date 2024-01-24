  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteRoleElementTemplate')
	BEGIN
		DROP  Procedure  DeleteRoleElementTemplate
	END

GO

CREATE Procedure dbo.DeleteRoleElementTemplate
	(	
	@SiteId bigint,
	@RoleName varchar(max),
	@RoleElementName varchar(max)
	)
AS

DELETE FROM RoleElementTemplate 
WHERE RoleId = (select r.Id from [Role] r where r.SiteId = @SiteId and r.[Name] = @RoleName) and 
      RoleElementId = (select re.Id from RoleElement re where re.[Name] = @RoleElementName)

RETURN

GO    