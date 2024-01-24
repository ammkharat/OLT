IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllRestrictionLocations')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllRestrictionLocations
	END
GO

CREATE Procedure [dbo].QueryAllRestrictionLocations
@SiteID bigint

AS

SELECT 
	* 
FROM 
	RestrictionLocation
WHERE
	DELETED = 0 and Siteid = @SiteID
go
GRANT EXEC ON QueryAllRestrictionLocations TO PUBLIC
GO
