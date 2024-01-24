 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRoleElementTemplate')
	BEGIN
		DROP  Procedure  InsertRoleElementTemplate
	END

GO

CREATE Procedure [dbo].[InsertRoleElementTemplate]
	(
	@SiteId bigint,
	@RoleName varchar(max),
	@RoleElementName varchar(max)
	)
AS

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) 
select re.Id, r.Id 
from RoleElement re, Role r 
where r.SiteId = @SiteId and r.[Name] = @RoleName and re.[Name] = @RoleElementName

GO

GRANT EXEC ON [InsertRoleElementTemplate] TO PUBLIC
GO


