 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteRoleDisplayConfigurationBySite')
	BEGIN
		DROP  Procedure  DeleteRoleDisplayConfigurationBySite
	END

GO

CREATE Procedure [dbo].DeleteRoleDisplayConfigurationBySite
	(
		@SiteId bigint
	)

AS

delete from RoleDisplayConfiguration
where exists
(
	select r.Id
	from Role r
	where r.Id = RoleId
	and SiteId = @SiteId
)

GO

GRANT EXEC ON DeleteRoleDisplayConfigurationBySite TO PUBLIC

GO


