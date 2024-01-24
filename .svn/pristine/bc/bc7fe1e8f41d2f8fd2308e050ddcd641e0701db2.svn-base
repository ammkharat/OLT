IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationByFloc')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardConfigurationByFloc
	END
GO

CREATE Procedure [dbo].QueryCokerCardConfigurationByFloc
	(
		@flocIds varchar(MAX)
	)

AS
SELECT * FROM dbo.CokerCardConfiguration
  WHERE 
    DELETED = 0 AND
    EXISTS
    (
      SELECT Id
        FROM IdSplitter(@flocIds)
        WHERE Id = CokerCardConfiguration.FunctionalLocationId
    )
GO

GRANT EXEC ON QueryCokerCardConfigurationByFloc TO PUBLIC
GO