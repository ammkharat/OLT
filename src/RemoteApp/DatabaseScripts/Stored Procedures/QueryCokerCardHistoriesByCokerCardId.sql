IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardHistoriesByCokerCardId')
    BEGIN
        DROP PROCEDURE [dbo].QueryCokerCardHistoriesByCokerCardId
    END
GO

CREATE Procedure [dbo].QueryCokerCardHistoriesByCokerCardId
    (
        @CokerCardId bigint
    )
AS

SELECT dbo.CokerCardHistory.*
  FROM
    dbo.CokerCardHistory
WHERE 
  dbo.CokerCardHistory.CokerCardId = @CokerCardId
GO

GRANT EXEC ON [QueryCokerCardHistoriesByCokerCardId] TO PUBLIC
GO