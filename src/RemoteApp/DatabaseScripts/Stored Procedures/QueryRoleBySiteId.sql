IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleBySiteId
	END
GO

CREATE Procedure dbo.QueryRoleBySiteId
	(
	@SiteId int
	)
AS
SELECT *
from [Role]
where 
  Siteid = @SiteId
  and Deleted = 0
GO

GRANT EXEC ON QueryRoleBySiteId TO PUBLIC
GO