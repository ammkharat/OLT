IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteCokerCardCycleStepEntryByCokerCardId')
	BEGIN
		DROP  Procedure  DeleteCokerCardCycleStepEntryByCokerCardId
	END
GO

CREATE Procedure [dbo].DeleteCokerCardCycleStepEntryByCokerCardId
(
	@CokerCardId bigint
)
AS


DELETE 
FROM CokerCardCycleStepEntry
WHERE CokerCardId = @CokerCardId

GO

GRANT EXEC ON DeleteCokerCardCycleStepEntryByCokerCardId TO PUBLIC
GO