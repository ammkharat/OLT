IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardDrumEntryByCokerCardId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardDrumEntryByCokerCardId
	END
GO

CREATE Procedure [dbo].QueryCokerCardDrumEntryByCokerCardId
(
	@CokerCardId bigint
)
AS

SELECT * 
FROM CokerCardDrumEntry
WHERE CokerCardID=@CokerCardId
GO

GRANT EXEC ON QueryCokerCardDrumEntryByCokerCardId TO PUBLIC
GO