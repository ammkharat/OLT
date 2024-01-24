IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationDrums')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationDrums
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationDrums
	(
		@CokerCardConfigurationId bigint
	)
AS

SELECT * FROM dbo.CokerCardConfigurationDrum
  WHERE
    CokerCardConfigurationId = @CokerCardConfigurationId	
GO

GRANT EXEC ON QueryCokerCardConfigurationDrums TO PUBLIC
GO