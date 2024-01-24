IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment
    END
GO

  
CREATE Procedure [dbo].QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment    
    (    
        @CsvFLOCIds varchar(max),    
        @WorkAssignmentId bigint = NULL,    
        @IncludeAssignmentInCondition bit,    
        @StartOfDateRange DateTime,    
  @EndOfDateRange DateTime,    
  @ReadByUserId bigint = NULL,    
  @CsvVisibilityGroupIds varchar(max)  ,
  @RoleId bigint=Null   
    )    
AS    
   
  -- Logic to Get Allowview WOrkassigmnet based on rolepermission

DECLARE @listStrWorkAssigmnet VARCHAR(MAX)
if(@WorkAssignmentId IS NULL)
Begin
(select @listStrWorkAssigmnet = COALESCE(@listStrWorkAssigmnet+',' ,'') + CAST(Id AS VARCHAR) from WorkAssignment where (RoleId IN(select CreatedByRoleId from RolePermission where RoleElementId=114 and RoleId =@RoleId)))-- OR Roleid=@RoleId);
--SELECT @listStrWorkAssigmnet
ENd;
------END------   
    
WITH q_cte (QuestionnaireId)    
AS    
(    
select distinct q.id    
  from dbo.ShiftHandoverQuestionnaire q    
  inner join ShiftHandoverQuestionnaireFunctionalLocation qfl on qfl.ShiftHandoverQuestionnaireId = q.Id    
  WHERE     
  (( q.CreatedDateTime >= @StartOfDateRange and    
 q.CreatedDateTime <= @EndOfDateRange  and IsFlexible=0)  
/*RITM RITM0185797 Flexi shift handover */  
/*Amit Shukla start*/  
 OR
 ((( q.FlexiShiftStartDate BETWEEN  @StartOfDateRange  AND @EndOfDateRange) OR ( q.FlexiShiftEndDate BETWEEN  @StartOfDateRange  AND @EndOfDateRange)) and IsFlexible=1))  
 --((( @StartOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate) OR ( @EndOfDateRange BETWEEN  q.FlexiShiftStartDate AND q.FlexiShiftEndDate)) and IsFlexible=1)
 /*Amit Shukla end*/  
 and    
    (@IncludeAssignmentInCondition = 0 or (q.WorkAssignmentId = @WorkAssignmentId or (q.WorkAssignmentId is null and @WorkAssignmentId is null)))    
 AND (    
    q.WorkAssignmentId is null or    
 @CsvVisibilityGroupIds is null or    
 EXISTS (    
  select wavg.Id    
  from WorkAssignmentVisibilityGroup wavg    
  inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId    
  where wavg.WorkAssignmentId = q.WorkAssignmentId and    
        wavg.VisibilityType = 2    
  )    
 )    
 AND (    
  EXISTS (    
    -- Floc of Shift Handover matches one of the passed in flocs    
    select * From IDSplitter(@CsvFLOCIds) ids    
    WHERE qfl.FunctionalLocationId = ids.Id    
  )    
  OR EXISTS    
  (    
    -- Floc of Shift Handover is parent of one of the passed in flocs (look up the floc tree from my selected flocs)    
    select * from FunctionalLocationAncestor a    
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id    
    WHERE a.AncestorId = qfl.FunctionalLocationId    
  )    
  OR EXISTS    
  (    
    -- Floc of Shift Handover is child of one of the passed in flocs (look down the floc tree from my selected flocs)    
    select * from FunctionalLocationAncestor a    
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
    WHERE a.Id = qfl.FunctionalLocationId    
  )    
 )    
)    
SELECT    
    q.Id,    
 q.ShiftHandoverConfigurationName,    
 q.CreatedByUserId,    
 q.CreatedDateTime,    
 q.HasYesAnswer,    
 q.IsFlexible,
q.FlexiShiftStartDate,
q.FlexiShiftEndDate,   
 s.Id as ShiftId,    
 s.Name as ShiftName,    
 s.StartTime as ShiftStartTime,    
 s.EndTime as ShiftEndTime,    
    
 sc.PreShiftPaddingInMinutes,    
 sc.PostShiftPaddingInMinutes,    
    
 a.Id as AssignmentId,    
 a.Name as AssignmentName,    
    
    CreateUser.LastName as CreatedByLastName,    
    CreateUser.FirstName as CreatedByFirstName,    
    CreateUser.UserName as CreatedByUserName,    
    
 shqfll.FunctionalLocationList as FullHierarchy,    
    
 shqread.UserId as ReadByUserId,    
 vg.Name as VisibilityGroupName    
FROM    
 ShiftHandoverQuestionnaire q    
    INNER JOIN q_cte ON q_cte.QuestionnaireId = q.Id    
    INNER JOIN Shift s ON q.ShiftId = s.Id    
 INNER JOIN SiteConfiguration sc ON s.SiteId = sc.SiteId    
    INNER JOIN [User] CreateUser ON q.CreatedByUserId = CreateUser.Id     
 INNER JOIN ShiftHandoverQuestionnaireFunctionalLocationList shqfll on shqfll.ShiftHandoverQuestionnaireId = q.Id    
    LEFT JOIN WorkAssignment a ON q.WorkAssignmentId = a.Id    
 LEFT OUTER JOIN ShiftHandoverQuestionnaireRead shqread ON shqread.ShiftHandoverQuestionnaireId = q.Id and shqread.UserId = @ReadByUserId    
 LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = q.WorkAssignmentId and wavg.VisibilityType = 2    
 LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId    
 WHERE @listStrWorkAssigmnet IS NULL OR a.id in (select * From IDSplitter(@listStrWorkAssigmnet))
     
 OPTION (OPTIMIZE FOR UNKNOWN) 

GRANT EXEC ON QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment TO PUBLIC
GO