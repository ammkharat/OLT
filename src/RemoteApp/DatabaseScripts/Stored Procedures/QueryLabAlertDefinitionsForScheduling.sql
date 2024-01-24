IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionsForScheduling')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionsForScheduling
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionsForScheduling
AS

SELECT 
	lab.* 
FROM 
	LabAlertDefinition lab
	inner join Schedule s on lab.ScheduleId = s.Id
WHERE 
	lab.Deleted = 0
	AND lab.LabAlertDefinitionStatusId != 2
	AND (s.EndDateTime IS NULL OR s.EndDateTime > dateadd(day, -1, getdate()))
GO

GRANT EXEC ON QueryLabAlertDefinitionsForScheduling TO PUBLIC
GO 