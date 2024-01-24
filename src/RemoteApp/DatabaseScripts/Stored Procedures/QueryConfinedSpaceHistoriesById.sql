 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfinedSpaceHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryConfinedSpaceHistoriesById
	END
GO

CREATE Procedure [dbo].QueryConfinedSpaceHistoriesById
	(
	@Id bigint
	)
AS
SELECT * 
FROM ConfinedSpaceHistory 
WHERE Id=@Id 
ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryConfinedSpaceHistoriesById] TO PUBLIC
GO