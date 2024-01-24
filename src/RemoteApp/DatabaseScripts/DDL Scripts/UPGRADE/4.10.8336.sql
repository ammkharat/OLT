

update SiteConfiguration 
set DaysToDisplayWorkPermitsBackwards = 1, 
    DaysToDisplayWorkPermitsForwards = 7,
	DaysToDisplayPermitRequestsBackwards = 0,
	DaysToDisplayPermitRequestsForwards = 7
where SiteId = 10;  -- Lubes!



GO

