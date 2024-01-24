IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationBySite')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationBySite
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationBySite
	(
		@SiteId bigint
	)
AS

select * 
from 
	CokerCardConfiguration ccc
	inner join FunctionalLocation fl on ccc.FunctionalLocationId = fl.Id
where 
	ccc.Deleted = 0
	and fl.SiteId = @SiteId
GO

GRANT EXEC ON QueryCokerCardConfigurationBySite TO PUBLIC
GO