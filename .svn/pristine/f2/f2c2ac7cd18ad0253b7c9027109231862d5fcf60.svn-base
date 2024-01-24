IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDTOsByParentFlocsAndAssignmentAndDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemDTOsByParentFlocsAndAssignmentAndDateRange
    END
GO  
    
CREATE Procedure dbo.QueryActionItemDTOsByParentFlocsAndAssignmentAndDateRange    
 (    
  @CsvFlocIds VARCHAR(MAX),    
  @StartOfDateRange DATETIME,    
  @EndOfDateRange DATETIME,    
  @WorkAssignmentId bigint = NULL,    
  @UseWorkAssignment bit,    
  @CsvVisibilityGroupIds varchar(max)    
 )    
AS    
    
WITH Action_Item_Id_Cte (ActionItemId)    
AS    
(    
select distinct ai.id    
  from     
    dbo.ActionItem ai    
  WHERE     
   ai.deleted = 0 AND    
 (ai.StartDateTime >= @StartOfDateRange and ai.StartDateTime < @EndOfDateRange)    
 AND    
   (    
    (@UseWorkAssignment = 1 AND ai.WorkAssignmentId = @WorkAssignmentId or (ai.WorkAssignmentId is null and @WorkAssignmentId is null))    
    OR (@UseWorkAssignment = 0)    
   )    
 AND    
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
    )    
 AND    
 (    
   EXISTS    
      (    
        -- Floc of Action Item matches one of the passed in flocs    
        select aifl.ActionItemId From IDSplitter(@CsvFLOCIds) ids    
        INNER JOIN ActionItemFunctionalLocation aifl ON ids.Id = aifl.FunctionalLocationId    
        WHERE aifl.ActionItemId = ai.Id    
      )    
      OR EXISTS    
      (    
        -- Floc of Action Item  is child of one of the passed in flocs (look down the floc tree from my selected flocs)    
        select aifl.ActionItemId from FunctionalLocationAncestor a    
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
        INNER JOIN ActionItemFunctionalLocation aifl ON a.Id = aifl.FunctionalLocationId    
        WHERE aifl.ActionItemId = ai.Id      
      )    
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
 bc.[Name] as BusinessCategoryName,    
 ai.EndDateTime,    
 ai.LastModifiedUserId,    
 u.Username,    
 ai.createdByScheduleTypeId,    
 fl.FullHierarchy,    
 fl.Description as FunctionalLocationDescription,    
 ai.ResponseRequired,    
 ai.[Name],    
 wa.[Name] as WorkAssignmentName,    
 wa.Id as WorkAssignmentId,    
 vg.Name as VisibilityGroupName, 
B.Id as definitionid,
 aidcfg.Reading, 
 ai.visibilitygroupids,  
 ai.CreatedByActionItemDefinitionId as DefinitionId    
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
OPTION (OPTIMIZE FOR UNKNOWN) 

GRANT EXEC ON QueryActionItemDTOsByParentFlocsAndAssignmentAndDateRange TO PUBLIC  