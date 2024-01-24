IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationById')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationById
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationById
	(
		@Id bigint
	)

AS
SELECT * FROM dbo.CokerCardConfiguration
  WHERE 
    Id = @Id
GO

GRANT EXEC ON QueryCokerCardConfigurationById TO PUBLIC
GO