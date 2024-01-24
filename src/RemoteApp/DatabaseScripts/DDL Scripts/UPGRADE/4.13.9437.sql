-- delete all the existing records in the table because the night shift ones are wrong since the original 4.12 script had a bug.
TRUNCATE TABLE ShiftHandoverQuestionnaireSummaryLog;
GO

;WITH s_cte
AS
(
SELECT 
  s.Id, s.StartTime, s.EndTime, sc.PreShiftPaddingInMinutes, sc.PostShiftPaddingInMinutes, 
  CASE 
    WHEN datediff(minute, s.StartTime, s.EndTime) > 0 THEN 0
    ELSE 1
    END 'night'
from 
  Shift s WITH (FORCESEEK) 
  INNER JOIN SiteConfiguration sc on sc.SiteId = s.SiteId
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
INSERT INTO ShiftHandoverQuestionnaireSummaryLog (ShiftHandoverQuestionnaireId, SummaryLogId) 
SELECT distinct sh_cte.id, sl.Id
FROM
  [SummaryLog] sl 
  INNER JOIN sh_cte 
    ON sl.CreationUserShiftPatternId = sh_cte.ShiftId and sl.WorkAssignmentId = sh_cte.WorkAssignmentId
        and sl.CreatedDateTime >= sh_cte.StartDateTime and sl.CreatedDateTime <= sh_cte.EndDateTime
  WHERE
	  sl.Deleted = 0 and
    (
  		EXISTS
  		(
  		-- Floc of Shift Handover is the same as one of the Summary Log flocs
  		select * 
      FROM SummaryLogFunctionalLocation slfl
      INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shqfl 
        ON shqfl.FunctionalLocationId = slfl.FunctionalLocationId and shqfl.ShiftHandoverQuestionnaireId = sh_cte.Id
  		WHERE 
        slfl.SummaryLogId = sl.Id
  		)
  		OR EXISTS
  		(
  		  -- Floc of Shift Handover is a parent of one of Summary Log flocs
  		  select *
        FROM SummaryLogFunctionalLocation slfl
        INNER JOIN FunctionalLocationAncestor a 
          ON a.Id = slfl.FunctionalLocationId
        INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shqfl
          ON shqfl.FunctionalLocationId = a.AncestorId and shqfl.ShiftHandoverQuestionnaireId = sh_cte.Id
  		WHERE 
        slfl.SummaryLogId = sl.Id
  		)
    )	
OPTION (LOOP JOIN)
GO


GO

