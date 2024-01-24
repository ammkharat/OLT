IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionItemByRestrictionLocationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionItemByRestrictionLocationId
	END
GO

CREATE Procedure [dbo].QueryRestrictionItemByRestrictionLocationId
(
	@RestrictionLocationId bigint
)
AS

SELECT 
	* 
FROM 
	RestrictionLocationItem
WHERE 
	RestrictionLocationId=@RestrictionLocationId
	and DELETED = 0
GO

GRANT EXEC ON QueryRestrictionItemByRestrictionLocationId TO PUBLIC
GO