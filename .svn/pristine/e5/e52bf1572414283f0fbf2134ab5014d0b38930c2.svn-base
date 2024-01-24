IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionByScheduleId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionByScheduleId
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionByScheduleId
(
	@scheduleId int
)
AS

SELECT * FROM LabAlertDefinition 
WHERE ScheduleId=@scheduleId
GO

GRANT EXEC ON QueryLabAlertDefinitionByScheduleId TO PUBLIC
GO