IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllDropdownValues')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllDropdownValues
	END
GO

CREATE Procedure [dbo].QueryAllDropdownValues
(
	@SiteId bigint	
)
AS
SELECT * FROM DropdownValue
WHERE Deleted = 0 AND SiteId = @SiteId
ORDER BY Id ASC;
GO

GRANT EXEC ON QueryAllDropdownValues TO PUBLIC
GO