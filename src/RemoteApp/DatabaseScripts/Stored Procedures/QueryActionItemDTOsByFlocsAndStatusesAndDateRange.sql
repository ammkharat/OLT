IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDTOsByFlocsAndStatusesAndDateRange')  
 BEGIN  
  DROP PROCEDURE [dbo].QueryActionItemDTOsByFlocsAndStatusesAndDateRange  
 END  
GO  
  
CREATE Procedure dbo.QueryActionItemDTOsByFlocsAndStatusesAndDateRange  
 (  
  @CsvFlocIds VARCHAR(MAX),  
  @CsvStatusIds VARCHAR(MAX),  
  @StartOfDateRange DATETIME,  
  @EndOfDateRange DATETIME = NULL,  
  @WorkAssignmentId bigint = NULL,  
        @IncludeWorkAssignmentInCondition bit,  
  @CsvVisibilityGroupIds varchar(max)  
 )  
AS  
  
WITH Action_Item_Id_Cte (ActionItemId)  
AS  
(  
select distinct ai.id  
  from   
    dbo.ActionItem ai  
 INNER JOIN ActionItemFunctionalLocation aifl ON ai.Id = aifl.ActionItemId  
  WHERE   
   ai.deleted = 0 AND   
    EXISTS (SELECT * FROM IDSplitter(@CsvStatusIds) WHERE Id = ai.ActionItemStatusId) AND  
   (  
      ai.WorkAssignmentId is null or  
   @CsvVisibilityGroupIds is null or  
   EXISTS (  
  select wavg.Id  
  from WorkAssignmentVisibilityGroup wavg  
  inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId  
  where wavg.WorkAssignmentId = ai.WorkAssignmentId and  
        wavg.VisibilityType = 2  
   )  
    ) AND  
   (  
    EXISTS  
      (  
        -- Floc of Action Item matches one of the passed in flocs  
        select * From IDSplitter(@CsvFLOCIds) ids  
        WHERE aifl.FunctionalLocationId = ids.Id  
      )  
      OR EXISTS  
      (  
        -- Floc of Action Item  is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
        select * from FunctionalLocationAncestor a  
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid  
        WHERE aifl.FunctionalLocationId = a.Id    
      ) 
      -- Action Items Created at Level 1 or 2  was not visible at level 2,3 or 3,4 and so on whithin same hierarchy  ... 
      --Release no 4.29, Developed by Amit Shukla Date 29/Sept/2017 
      OR EXISTS  
      (  
        -- Floc of Action Item  is Parent of one of the passed in flocs (look down the floc tree from my selected flocs)  
        select * from FunctionalLocationAncestor a  
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.id  
        WHERE aifl.FunctionalLocationId = a.ancestorid    
      )  
    ) AND  
    (  
        (ai.EndDateTime IS NULL AND @EndOfDateRange IS NULL AND ai.StartDateTime >= @StartOfDateRange)  
        OR  
        (ai.EndDateTime IS NULL AND @EndOfDateRange IS NOT NULL AND ai.StartDateTime <= @EndOfDateRange)  
        OR  
        (@EndOfDateRange IS NOT NULL AND ai.StartDateTime <= @EndOfDateRange AND ai.EndDateTime >= @StartOfDateRange)  
        OR  
        (@EndOfDateRange IS NULL AND ai.StartDateTime >= @StartOfDateRange)  
    ) AND  
    (  
       @IncludeWorkAssignmentInCondition = 0 or   
       (ai.WorkAssignmentId = @WorkAssignmentId or  
       (ai.WorkAssignmentId is null and @WorkAssignmentId is null))  
   )  
)  
select  
 ai.Id,  
 ai.ActionItemStatusId,  
 ai.PriorityId,  
 ai.Description,  
 ai.StartDateTime,  
 ai.SourceId,  
 ai.BusinessCategoryId,  
 bc.Name as BusinessCategoryName,  
 ai.EndDateTime,  
 ai.LastModifiedUserId,  
 u.Username,  
 ai.createdByScheduleTypeId,  
 fl.FullHierarchy,  
 fl.Description as FunctionalLocationDescription,  
 ai.ResponseRequired,  
 ai.Name,  
 wa.Name as WorkAssignmentName,  
 wa.Id as WorkAssignmentId,  
 vg.Name as VisibilityGroupName,  
 B.Id as definitionid,
 aidcfg.Reading,
 ai.visibilitygroupids   
from   
  ActionItem ai  
  INNER JOIN Action_Item_Id_Cte ON Action_Item_Id_Cte.ActionItemId = ai.Id  
  INNER JOIN [User] u on ai.LastModifiedUserId = u.Id  
  INNER JOIN ActionItemFunctionalLocation aifl on ai.Id = aifl.ActionItemId  
  INNER JOIN FunctionalLocation fl on aifl.FunctionalLocationId = fl.Id   
  INNER JOIN BusinessCategory bc on bc.id = ai.BusinessCategoryId  
  LEFT OUTER JOIN WorkAssignment wa on wa.id = ai.WorkAssignmentId  
  LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = ai.WorkAssignmentId and wavg.VisibilityType = 2  
  LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId  
  Left Outer Join ActionItemDefinition B On B.Id = ai.CreatedByActionItemDefinitionId    
  left outer join ActionItemDefinitionCustomFieldGroup aidcfg on aidcfg.ActionItemDefinitionId = ai.CreatedByActionItemDefinitionId
--ayman apply the date range  
where ai.StartDateTime >= @StartOfDateRange and ai.StartDateTime <= @EndOfDateRange  
OPTION (OPTIMIZE FOR UNKNOWN)   


GO

GRANT EXEC ON QueryActionItemDTOsByFlocsAndStatusesAndDateRange TO PUBLIC
GO 