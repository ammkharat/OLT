IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradeByIdNotDeleted')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradeByIdNotDeleted
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradeByIdNotDeleted

	(
		@id int
	)

AS

SELECT	*
FROM
	[CraftOrTrade] 
WHERE 
	ID = @id AND DELETED = 0 
GO

GRANT EXEC ON QueryCraftOrTradeByIdNotDeleted TO PUBLIC
GO