IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardCycleStepEntryByCokerCardId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardCycleStepEntryByCokerCardId
	END
GO

CREATE Procedure [dbo].QueryCokerCardCycleStepEntryByCokerCardId
(
	@CokerCardId bigint
)
AS

SELECT e.* 
FROM CokerCardCycleStepEntry e
WHERE e.CokerCardId = @CokerCardId
GO

GRANT EXEC ON QueryCokerCardCycleStepEntryByCokerCardId TO PUBLIC
GO