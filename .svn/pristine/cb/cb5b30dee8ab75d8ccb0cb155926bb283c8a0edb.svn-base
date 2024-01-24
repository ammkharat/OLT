IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardEntryHistoryByCokerCardHistoryId')
    BEGIN
        DROP PROCEDURE [dbo].QueryCokerCardEntryHistoryByCokerCardHistoryId
    END
GO

CREATE Procedure [dbo].QueryCokerCardEntryHistoryByCokerCardHistoryId
    (
        @CokerCardHistoryId bigint
    )
AS

SELECT 
  de.Id as DrumEntryHistoryId,
  DrumConfigurationId, 
  DrumName, 
  CokerCardConfigurationLastCycleStep,
  HoursIntoLastCycle,
  Comments, 
  cs.Id as CycleStepEntryHistoryId,
  CycleStepConfigurationId,
  CycleStepName,
  StartTime,
  EndTime
  FROM
    dbo.CokerCardDrumEntryHistory de
    INNER JOIN dbo.CokerCardCycleStepEntryHistory cs ON cs.CokerCardDrumEntryHistoryId = de.Id  
  WHERE
    de.CokerCardHistoryId = @CokerCardHistoryId
  order by DrumConfigurationId, CycleStepConfigurationId

GO

GRANT EXEC ON [QueryCokerCardEntryHistoryByCokerCardHistoryId] TO PUBLIC
GO