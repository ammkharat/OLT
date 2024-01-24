IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationNameBySite')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationNameBySite
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationNameBySite
	(
		@SiteId bigint
	)
AS

select 
	distinct(ccc.Name) 
from 
	CokerCardConfiguration ccc
	inner join FunctionalLocation fl on ccc.FunctionalLocationId = fl.Id
where
	fl.SiteId = @SiteId
GO

GRANT EXEC ON QueryCokerCardConfigurationNameBySite TO PUBLIC
GO