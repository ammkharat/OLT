IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionLocationById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionLocationById
	END
GO

CREATE Procedure [dbo].QueryRestrictionLocationById
(
	@Id bigint
)
AS

SELECT 
	* 
FROM 
	RestrictionLocation
WHERE 
	Id=@Id
GO

GRANT EXEC ON QueryRestrictionLocationById TO PUBLIC
GO