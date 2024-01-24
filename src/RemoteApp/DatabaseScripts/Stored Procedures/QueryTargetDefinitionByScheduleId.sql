IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionByScheduleId')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionByScheduleId
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionByScheduleId
	(
		@ScheduleId bigint
	)
AS

SELECT *
FROM
	TargetDefinition 
WHERE
	ScheduleId=@ScheduleId
GO

GRANT EXEC ON QueryTargetDefinitionByScheduleId TO PUBLIC
GO