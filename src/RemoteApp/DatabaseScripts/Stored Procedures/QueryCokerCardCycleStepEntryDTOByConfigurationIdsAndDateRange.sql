IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardCycleStepEntryDTOByConfigurationIdsAndDateRange')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardCycleStepEntryDTOByConfigurationIdsAndDateRange
	END
GO

CREATE Procedure [dbo].QueryCokerCardCycleStepEntryDTOByConfigurationIdsAndDateRange
(
	@ConfigurationIds varchar(max),
	@StartOfRange datetime,
	@EndOfRange datetime
)
AS

SELECT 
  configDrum.[Name] as Drum, 
  configCycleStep.[Name] as [Cycle], 
  stepEntry.*,
  s.[Name] as ShiftName,
  cc.ShiftStartDate,
  de.Comments
from CokerCard cc
INNER JOIN dbo.CokerCardDrumEntry de
ON de.CokerCardId = cc.Id
INNER JOIN CokerCardCycleStepEntry stepEntry
ON stepEntry.CokerCardId = cc.Id
INNER JOIN CokerCardConfigurationDrum configDrum
ON stepEntry.CokerCardConfigurationDrumId = configDrum.Id
INNER JOIN CokerCardConfigurationCycleStep configCycleStep
ON stepEntry.CokerCardConfigurationCycleStepId = configCycleStep.Id
INNER JOIN Shift s
ON s.Id = cc.ShiftId
where cc.ShiftStartDate >= @StartOfRange
and cc.ShiftStartDate <= @EndOfRange
and cc.CokerCardConfigurationId IN (select id from IDSplitter(@ConfigurationIds))
and cc.Deleted = 0
and de.CokerCardConfigurationDrumId = stepEntry.CokerCardConfigurationDrumId
ORDER BY 
	cc.ShiftStartDate, 
	cc.ShiftId, 
	configDrum.DisplayOrder, 
	configCycleStep.DisplayOrder
GO

GRANT EXEC ON QueryCokerCardCycleStepEntryDTOByConfigurationIdsAndDateRange TO PUBLIC
GO