ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
NOCHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log]
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
NOCHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]
GO

CREATE NONCLUSTERED INDEX [idx_Nonclustered_Log_temp]
ON [dbo].[Log]
([CreatedDateTime] , [CreationUserShiftPatternId] , [WorkAssignmentId])
INCLUDE ([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

;WITH s_cte 
AS 
(
SELECT s.Id, 
       s.StartTime, 
       s.EndTime, 
       sc.PreShiftPaddingInMinutes, 
       sc.PostShiftPaddingInMinutes, 
       CASE 
		WHEN datediff(minute, s.StartTime, s.EndTime) > 0 THEN 0 
		ELSE 1 
	   END 'night' 
FROM 
	Shift s WITH (FORCESEEK) 
    INNER JOIN SiteConfiguration sc ON sc.SiteId = s.SiteId
), 
sh_cte 
AS 
(
select 
	q.Id, 
    q.WorkAssignmentId, 
    q.ShiftId, 
    CASE 
		WHEN night = 1 and cast(q.CreatedDateTime as time) > cast('00:00:00' as time) THEN 
			dateadd(minute, -1 * s_cte.PreShiftPaddingInMinutes, dateadd(day, -1, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime))) 
        ELSE dateadd(minute, -1 * s_cte.PreShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime)) 
	END startdatetime, 
    dateadd(minute, s_cte.PostShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(endtime as datetime)) enddatetime 
FROM 
	ShiftHandoverQuestionnaire q 
    INNER JOIN s_cte ON s_cte.Id = q.ShiftId
) 
INSERT INTO ShiftHandoverQuestionnaireLog (ShiftHandoverQuestionnaireId, LogId) 
SELECT distinct sh_cte.id, l.Id 
FROM 
	[Log] l 
    INNER JOIN sh_cte 
		ON l.CreatedDateTime >= sh_cte.startdatetime 
             AND l.CreatedDateTime <= sh_cte.enddatetime 
             AND sh_cte.ShiftId = l.CreationUserShiftPatternId 
             AND sh_cte.WorkAssignmentId = l.WorkAssignmentId 
    INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shfl 
        ON shfl.ShiftHandoverQuestionnaireId = sh_cte.Id 
    INNER JOIN dbo.LogFunctionalLocation lfl 
		ON lfl.LogId = l.Id 
    INNER JOIN dbo.FunctionalLocationAncestor a 
		ON (shfl.FunctionalLocationId = a.AncestorId 
              OR shfl.FunctionalLocationId = a.Id) 
             AND a.Id = lfl.FunctionalLocationId 
OPTION (LOOP JOIN)
GO

DROP INDEX [idx_Nonclustered_Log_temp] 
ON [dbo].[Log];
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log]
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
CHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]
GO
