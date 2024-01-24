IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteCokerCardDrumEntryByCokerCardId')
	BEGIN
		DROP  Procedure  DeleteCokerCardDrumEntryByCokerCardId
	END
GO

CREATE Procedure [dbo].DeleteCokerCardDrumEntryByCokerCardId
(
	@CokerCardId bigint
)
AS

DELETE
FROM CokerCardDrumEntry
WHERE CokerCardID=@CokerCardId
GO

GRANT EXEC ON DeleteCokerCardDrumEntryByCokerCardId TO PUBLIC
GO