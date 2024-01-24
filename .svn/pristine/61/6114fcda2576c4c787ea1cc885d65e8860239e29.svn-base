IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionsForScheduling')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionsForScheduling
	END
GO

CREATE Procedure [dbo].QueryActionItemDefinitionsForScheduling
AS 

SELECT *
FROM 
	ActionItemDefinition ai
	INNER JOIN Schedule s ON ai.ScheduleId = s.Id 
WHERE 
	ai.Deleted  = 0 
	AND ai.Active = 1
	AND s.ScheduleTypeId IN (1,2,3,4,5,6,7,8)  
	AND (s.EndDateTime IS NULL OR s.EndDateTime > dateadd(day, -1, getdate()))
GO 

GRANT EXEC ON QueryActionItemDefinitionsForScheduling TO PUBLIC
GO