IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade')
	BEGIN
		DROP  Procedure  UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade
	END

GO

CREATE Procedure [dbo].UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade
	(
		@CraftOrTradeId BIGINT
	)
AS
UPDATE WorkPermit
SET CraftOrTradeId=NULL,
CraftOrTradeOther=(SELECT Name FROM CraftOrTrade WHERE Id=@CraftOrTradeId)
WHERE CraftOrTradeId=@CraftOrTradeId 

GO