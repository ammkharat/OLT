IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardSummary')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardSummary
	END
GO

CREATE Procedure dbo.QueryCokerCardSummary
	(
		@ShiftStartDate datetime,
		@ShiftId bigint,
		@WorkAssignmentId bigint,
		@ConfigurationIds varchar(max)
	)

AS
select 
	CokerCardConfiguration.[Id] [CokerCardConfigurationId],
	CokerCardConfiguration.[Name] [CokerCardName],
	drumConfig.[Name] [DrumName],
	cyclestep.[Name] [LastCycleStep], 
	drumentry.HoursIntoLastCycle,
	drumentry.Comments
from
  CokerCard 
  INNER JOIN CokerCardConfiguration
    ON dbo.CokerCard.CokerCardConfigurationId = dbo.CokerCardConfiguration.Id
  INNER JOIN CokerCardConfigurationDrum drumConfig
    ON drumConfig.CokerCardConfigurationId = CokerCardConfiguration.Id
  LEFT OUTER JOIN CokerCardDrumEntry drumentry
    ON (drumentry.CokerCardConfigurationDrumId = drumConfig.Id and drumentry.CokerCardId = cokerCard.Id)
  LEFT OUTER JOIN CokerCardConfigurationCycleStep cyclestep 
    ON drumentry.CokerCardConfigurationLastCycleStepId = cyclestep.Id
where 
    CokerCard.ShiftId = @ShiftId
    and
    dbo.DatePartEquals(CokerCard.ShiftStartDate, @ShiftStartDate) = 1
    and
    (
		CokerCard.WorkAssignmentId = @WorkAssignmentId
		or
		EXISTS
		(
			SELECT Id
			FROM IdSplitter(@ConfigurationIds)
			WHERE Id = CokerCard.CokerCardConfigurationId
		)
    )
	and
	CokerCard.Deleted = 0
GO

GRANT EXEC ON dbo.QueryCokerCardSummary TO PUBLIC
GO