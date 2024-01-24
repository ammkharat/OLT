IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOilsandsTrainingReportData')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormOilsandsTrainingReportData
    END
GO

CREATE Procedure [dbo].QueryFormOilsandsTrainingReportData
    (
        @CsvFLOCIds varchar(max),
        @StartDateTime DateTime,
        @EndDateTime DateTime,
             @CsvAssignmentIds varchar(max)
    )
AS

WITH FormOilsandsTraining_Id_Cte (FormOilsandsTrainingId)
AS
(
  SELECT 
    DISTINCT f.Id
  FROM
    FormOilsandsTraining f
  WHERE
    f.Deleted = 0 AND
       (
             f.WorkAssignmentId is null or
             exists
             (
                    select QueryAssignmentIds.Id
                    from IDSplitter(@CsvAssignmentIds) QueryAssignmentIds
                    where QueryAssignmentIds.Id = f.WorkAssignmentId
             )
       ) AND
         EXISTS
         (
             -- Floc of Form matches one of the passed in flocs
             select ffl.FormOilsandsTrainingId From IDSplitter(@CsvFLOCIds) ids
             INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId
             WHERE ffl.FormOilsandsTrainingId = f.Id
             UNION ALL
             -- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
             select ffl.FormOilsandsTrainingId from FunctionalLocationAncestor a
             INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id
             INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId
             WHERE ffl.FormOilsandsTrainingId = f.Id
             UNION ALL
             -- Floc of Formis child of one of the passed in flocs (look down the floc tree from my selected flocs)
             select ffl.FormOilsandsTrainingId from FunctionalLocationAncestor a
             INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
             INNER JOIN FormOilsandsTrainingFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId
             WHERE ffl.FormOilsandsTrainingId = f.Id
         )
)
SELECT
    f.Id as FormId,
       foti.Id as ItemId,
       
       f.FormStatusId,
       f.CreatedDateTime,
       f.CreatedByUserId,
       f.ApprovedDateTime,
       f.GeneralComments,
       
       f.TrainingDate,
       foti.Comments,
       foti.BlockCompleted,
       foti.Hours,
       tb.Name as TrainingBlockName,    
       tb.Code as TrainingBlockCode,
       
       s.Name as ShiftName,
       
       a.Approver as Approver,
       approvedByUser.LastName as ApprovedByUserLastName,
       approvedByUser.FirstName as ApprovedByUserFirstName,
       approvedByUser.UserName as ApprovedByUserUserName,
       
       wa.Name as CreatedByWorkAssignmentName,
       
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
       
       createdByUser.SAPId as Badge,
       
    fl.FullHierarchy as FullHierarchy
FROM
    FormOilsandsTraining f
    INNER JOIN FormOilsandsTraining_Id_Cte ON FormOilsandsTraining_Id_Cte.FormOilsandsTrainingId = f.Id
    INNER JOIN [FormOilsandsTrainingFunctionalLocation] ffl on ffl.FormOilsandsTrainingId = f.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
       INNER JOIN [FormOilsandsTrainingItem] foti on foti.FormOilsandsTrainingId = f.Id
       INNER JOIN [TrainingBlock] tb on tb.Id = foti.TrainingBlockId
       INNER JOIN Shift s on s.Id = f.ShiftId
       LEFT OUTER JOIN [FormOilsandsTrainingApproval] a on a.FormOilsandsTrainingId = f.Id
       LEFT OUTER JOIN [User] approvedByUser on approvedByUser.Id = a.ApprovedByUserId
       LEFT OUTER JOIN [WorkAssignment] wa on wa.Id = f.WorkAssignmentId
WHERE
    -- on the next line we are building a datetime representing the start of the shift that begins on TrainingDate.  So we are using the date from the TrainingDate and the time from the shift's StartTime.       
       (convert(datetime,f.TrainingDate) + convert(datetime,s.StartTime)) < @EndDateTime AND
       -- on the next line we are building a datetime corresponding to the end of the shift.  If it's a day shift we use the date from the TrainingDate and the time from the shift's EndTime.  If it's a night shift we
       -- use the date after the TrainingDate and the time from the shift's EndTime.
    ((case when s.StartTime < s.EndTime then f.TrainingDate else dateadd(day, 1, convert(datetime,f.TrainingDate)) end) + CAST(s.EndTime as datetime)) > @StartDateTime  AND
       foti.Deleted = 0 AND
       f.Deleted = 0
ORDER BY f.TrainingDate asc, s.StartTime asc
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC on QueryFormOilsandsTrainingReportData TO PUBLIC
GO