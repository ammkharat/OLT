IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationCycleSteps')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationCycleSteps
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationCycleSteps
	(
		@CokerCardConfigurationId bigint
	)
AS

SELECT * FROM dbo.CokerCardConfigurationCycleStep
  WHERE
    CokerCardConfigurationId = @CokerCardConfigurationId
GO

GRANT EXEC ON QueryCokerCardConfigurationCycleSteps TO PUBLIC
GO