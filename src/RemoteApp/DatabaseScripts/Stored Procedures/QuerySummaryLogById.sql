IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogById')
	BEGIN
		DROP Procedure [dbo].QuerySummaryLogById
	END
GO

CREATE Procedure [dbo].QuerySummaryLogById
	(
		@id int
	)
AS

select 
	sl.*
from 
	SummaryLog sl
where 
	sl.id = @id
GO

GRANT EXEC ON QuerySummaryLogById TO PUBLIC
GO