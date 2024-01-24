IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDTOsByFlocsForShiftOrResponseRequired')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDTOsByFlocsForShiftOrResponseRequired
	END
GO

CREATE Procedure dbo.QueryActionItemDTOsByFlocsForShiftOrResponseRequired
	(
		@CsvFlocIds VARCHAR(MAX),
		@ShiftStartDateTime DATETIME = NULL,
		@ShiftEndDateTime DATETIME = NULL,
		@DateRangeBegin DATETIME,
		@AssignmentId bigint = NULL,
        @IncludeAssignmentInCondition bit,
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
    (
      ai.WorkAssignmentId is null or
	  @CsvVisibilityGroupIds is null or
	  EXISTS 
	    (
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
	and ai.deleted = 0 
	AND ai.ActionItemStatusId = 0
	AND 
    (
		(
		  ai.StartDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime 
		  OR ai.EndDateTime BETWEEN @ShiftStartDateTime AND @ShiftEndDateTime
		)
	    OR
	    (
		  ai.ResponseRequired = 1 AND ai.StartDateTime >= @DateRangeBegin
	    )        
    )
	  AND
	  (
	    @IncludeAssignmentInCondition = 0 or 
	    (ai.WorkAssignmentId = @AssignmentId or
	    (ai.WorkAssignmentId is null and @AssignmentId is null))
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
	ai.CreatedByActionItemDefinitionId as definitionid    --ayman 
from 
  ActionItem ai
  INNER JOIN Action_Item_Id_Cte ON Action_Item_Id_CTE.ActionItemId = ai.Id
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
GO

GRANT EXEC ON QueryActionItemDTOsByFlocsForShiftOrResponseRequired TO PUBLIC
GO