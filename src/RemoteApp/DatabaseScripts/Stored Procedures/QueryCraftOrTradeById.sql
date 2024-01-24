IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCraftOrTradeById')
	BEGIN
		DROP PROCEDURE [dbo].QueryCraftOrTradeById
	END
GO

CREATE Procedure [dbo].QueryCraftOrTradeById

	(
		@id int
	)

AS

SELECT     *
FROM         [CraftOrTrade] WHERE ID=@id 
GO

GRANT EXEC ON QueryCraftOrTradeById TO PUBLIC
GO