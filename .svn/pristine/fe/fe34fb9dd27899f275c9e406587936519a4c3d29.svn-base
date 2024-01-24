IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionByScheduleId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionByScheduleId
	END
GO

CREATE Procedure [dbo].QueryLogDefinitionByScheduleId
	(
		@ScheduleId bigint
	)
AS

SELECT * FROM LogDefinition WHERE ScheduleId = @ScheduleId
GO

GRANT EXEC ON QueryLogDefinitionByScheduleId TO PUBLIC
GO