IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDropdownValuesByKey')
	BEGIN
		DROP PROCEDURE [dbo].QueryDropdownValuesByKey
	END
GO

CREATE Procedure [dbo].QueryDropdownValuesByKey
(
	@SiteId bigint,
	@Key VARCHAR(100)	
)
AS
SELECT * FROM DropdownValue
WHERE Deleted = 0 
	AND [Key] = @Key
	AND SiteId = @SiteId
ORDER BY DisplayOrder ASC;
GO

GRANT EXEC ON QueryDropdownValuesByKey TO PUBLIC
GO