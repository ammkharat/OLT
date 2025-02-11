
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfinedSpaceMudsHistoriesById')
	BEGIN
		DROP Procedure [dbo].QueryConfinedSpaceMudsHistoriesById
	END
GO

create Procedure [dbo].[QueryConfinedSpaceMudsHistoriesById]
	(
	@Id bigint
	)
AS
SELECT * 
FROM ConfinedSpaceMudsHistory 
WHERE Id=@Id 
ORDER BY LastModifiedDateTime
GO


GRANT EXEC ON QueryConfinedSpaceMudsHistoriesById TO PUBLIC
GO

