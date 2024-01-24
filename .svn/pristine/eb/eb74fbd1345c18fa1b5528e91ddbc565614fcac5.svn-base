IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsForScheduling')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionsForScheduling
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionsForScheduling
(
	@CsvSiteIds varchar(max)
)
AS 

SELECT 
	td.*
FROM 
	TargetDefinition td
	inner join Schedule s on td.ScheduleId = s.Id
WHERE 	
	td.Deleted = 0
	AND s.ScheduleTypeId IN (1,3,4,5,6,7,8,9)  
	AND s.SiteId IN (select id from IDSplitter(@CsvSiteIds))
	AND (s.EndDateTime IS NULL OR s.EndDateTime > dateadd(day, -1, getdate()))
GO

GRANT EXEC ON QueryTargetDefinitionsForScheduling TO PUBLIC
GO