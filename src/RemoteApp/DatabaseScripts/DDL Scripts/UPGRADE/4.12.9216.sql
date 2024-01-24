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
  Shift s
  INNER JOIN SiteConfiguration sc on sc.SiteId = s.SiteId
),
sh_cte
AS
(
select q.Id, q.WorkAssignmentId, q.ShiftId,
CASE
  WHEN night = 1 and cast(q.CreatedDateTime as time) > cast('00:00:00' as time) THEN
    dateadd(minute, -1*s_cte.PreShiftPaddingInMinutes, dateadd(day, -1, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime)))
  ELSE
    dateadd(minute, -1*s_cte.PreShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(starttime as datetime))
END startdatetime,
  dateadd(minute, s_cte.PostShiftPaddingInMinutes, cast(cast(q.CreatedDateTime as date) as datetime) + cast(endtime as datetime)) enddatetime
FROM ShiftHandoverQuestionnaire q
INNER JOIN s_cte ON s_cte.Id = q.ShiftId
)
INSERT INTO ShiftHandoverQuestionnaireSummaryLog (ShiftHandoverQuestionnaireId, SummaryLogId) 
SELECT distinct sh_cte.id, sl.Id
FROM
  [SummaryLog] sl
  INNER JOIN sh_cte ON sh_cte.ShiftId = sl.CreationUserShiftPatternId and sh_cte.WorkAssignmentId = sl.WorkAssignmentId
  INNER JOIN ShiftHandoverQuestionnaireFunctionalLocation shfl on shfl.ShiftHandoverQuestionnaireId = sh_cte.Id
  INNER JOIN dbo.SummaryLogFunctionalLocation slfl ON slfl.SummaryLogId = sl.Id
  INNER JOIN dbo.FunctionalLocationAncestor a on a.Id = slfl.FunctionalLocationId
WHERE
  sl.CreatedDateTime >= sh_cte.startdatetime and sl.CreatedDateTime <= sh_cte.enddatetime
  and
  (shfl.FunctionalLocationId = a.AncestorId
  OR
  shfl.FunctionalLocationId = a.Id)


GO

