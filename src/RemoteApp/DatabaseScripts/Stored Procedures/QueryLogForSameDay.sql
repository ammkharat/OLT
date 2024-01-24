IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogForSameDay')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogForSameDay
	END
GO

CREATE Procedure [dbo].[QueryLogForSameDay]
(
    @LogDefinitionId bigint,
    @DateToCheck datetime,
    @CsvFlocIds varchar(max)
)
AS

SELECT  l.Id
FROM 
	[Log] l
    INNER JOIN [LogDefinition] d ON l.LogDefinitionId = d.Id 
    INNER JOIN [Schedule] s ON d.ScheduleId = s.Id 
	INNER JOIN [LogFunctionalLocation] lfl ON l.Id = lfl.LogId
WHERE
	l.Deleted = 0 and
    (l.LogDefinitionId = @LogDefinitionId) and
    (s.ScheduleTypeId NOT IN (6, 7, 8, 9)) and
	dbo.DatePartEquals(l.CreatedDateTime, @DateToCheck) = 1 AND
	exists
	(
		select QueryIds.Id
		from IDSplitter(@CsvFlocIds) QueryIds
		where QueryIds.Id = lfl.FunctionalLocationId
	)
GO

GRANT EXEC ON [dbo].[QueryLogForSameDay] TO PUBLIC
GO