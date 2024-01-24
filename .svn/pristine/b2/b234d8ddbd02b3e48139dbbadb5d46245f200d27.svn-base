IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllLogDefinitions')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllLogDefinitions
	END
GO

CREATE Procedure [dbo].QueryAllLogDefinitions
AS

SELECT 
	ld.* 
FROM 
	[LogDefinition] ld
	INNER JOIN Schedule s ON ScheduleId = s.Id 
where 
	ld.Deleted = 0 and ld.active = 1
	AND (s.EndDateTime IS NULL OR s.EndDateTime > dateadd(day, -1, getdate()))
GO

GRANT EXEC ON QueryAllLogDefinitions TO PUBLIC
GO