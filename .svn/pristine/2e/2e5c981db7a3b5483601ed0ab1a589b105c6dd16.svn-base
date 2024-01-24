IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsByScheduleIds')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionsByScheduleIds
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionsByScheduleIds
	(
		@CsvScheduleIds VARCHAR(MAX)
	)
AS

SELECT TargetDefinition.*
FROM
	TargetDefinition 
  INNER JOIN IdSplitter(@CsvScheduleIds) ids ON ids.Id = TargetDefinition.ScheduleId
GO

GRANT EXEC ON QueryTargetDefinitionsByScheduleIds TO PUBLIC
GO