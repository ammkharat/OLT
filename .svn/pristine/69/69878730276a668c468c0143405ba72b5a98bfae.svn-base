ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
NOCHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_Log]
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireLog] 
NOCHECK CONSTRAINT [FK_ShiftHandoverQuestionnaireLog_ShiftHandover]
GO

-- delete all the existing records in the table because the night shift ones are wrong since the original 4.12 script had a bug.
TRUNCATE TABLE ShiftHandoverQuestionnaireLog;
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
  q.CreatedByUserId,
  q.CreatedDateTime,
  CASE 
		WHEN 
      -- Shift Handover is in the night shift, and in the next day of the shift, so subtract a day from the date of the shift handover date to get the start date
      night = 1 and 
      dateadd(minute, s_cte.PostShiftPaddingInMinutes, s_cte.EndTime) >= cast(q.CreatedDateTime as time(0)) and
      cast(q.CreatedDateTime as time(0)) >= '00:00:00'
    THEN
			dateadd(minute, -1 * s_cte.PreShiftPaddingInMinutes, dateadd(day, -1, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime))) 
    ELSE 
      dateadd(minute, -1 * s_cte.PreShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime)) 
	END startdatetime, 
  CASE
    WHEN 
      -- in the night shift, and on the first day, need to add a day to the date of the shift handover date to get the end date
      night = 1 and
      cast(q.CreatedDateTime as time(0)) >= dateadd(minute, -1 * s_cte.PreShiftPaddingInMinutes, s_cte.StartTime) and
      cast(q.CreatedDateTime as time(0)) <= '23:59:59'
    THEN
      dateadd(minute, s_cte.PostShiftPaddingInMinutes, dateadd(day, 1, cast(cast(q.CreatedDateTime as date) as datetime) + cast(endtime as datetime))) 
    ELSE
      dateadd(minute, s_cte.PostShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(endtime as datetime)) 
  END enddatetime 
FROM 
	ShiftHandoverQuestionnaire q 
    INNER JOIN s_cte ON s_cte.Id = q.ShiftId
)
INSERT INTO ShiftHandoverQuestionnaireLog (ShiftHandoverQuestionnaireId, LogId) 
SELECT distinct sh_cte.id, l.Id 
FROM
  [Log] l 
  INNER JOIN sh_cte 
    ON l.CreationUserShiftPatternId = sh_cte.ShiftId and l.WorkAssignmentId = sh_cte.WorkAssignmentId
        and l.CreatedDateTime >= sh_cte.StartDateTime and l.CreatedDateTime <= sh_cte.EndDateTime
  WHERE
	  l.Deleted = 0 and
    l.LogType = 1 and
    (
  		EXISTS
  		(
  		-- Floc of Shift Handover is the same as one of the Log flocs
  		select * 
      FROM LogFunctionalLocation lfl
      INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shqfl 
        ON shqfl.FunctionalLocationId = lfl.FunctionalLocationId and shqfl.ShiftHandoverQuestionnaireId = sh_cte.Id
  		WHERE 
        lfl.LogId = l.Id
  		)
  		OR EXISTS
  		(
  		  -- Floc of Shift Handover is a parent of one of Log flocs
  		  select *
        FROM LogFunctionalLocation lfl
        INNER JOIN FunctionalLocationAncestor a 
          ON a.Id = lfl.FunctionalLocationId
        INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shqfl
          ON shqfl.FunctionalLocationId = a.AncestorId and shqfl.ShiftHandoverQuestionnaireId = sh_cte.Id
  		WHERE 
        lfl.LogId = l.Id
  		)
    )	
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



GO

