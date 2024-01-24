IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationByName')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationByName
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationByName
	(
		@ConfigurationName varchar(40)
	)
AS

select Id from CokerCardConfiguration
where Name = @ConfigurationName
GO

GRANT EXEC ON QueryCokerCardConfigurationByName TO PUBLIC
GO