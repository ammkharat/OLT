IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionDTOsByActionItemDefIDs')
	BEGIN
		DROP Procedure [dbo].QueryActionItemDefinitionDTOsByActionItemDefIDs
	END
GO

Create Procedure [dbo].[QueryActionItemDefinitionDTOsByActionItemDefIDs]
    (
        @CsvDefIds VARCHAR(MAX),
		@CsvVisibilityGroupIds varchar(max)
    )
AS

WITH ActionItemDefinitionCte (ActionItemDefinitionId)
AS
(
  SELECT 
    DISTINCT aid.Id
  FROM
    dbo.ActionItemDefinition aid
    INNER JOIN ActionItemDefinitionFunctionalLocation aidfl ON aid.Id = aidfl.ActionItemDefinitionId
    INNER JOIN Schedule s ON aid.ScheduleId = s.Id
	inner join IDSplitter(@CsvDefIds) aidf on aid.Id = aidf.ID
  WHERE
    aid.deleted = 0  AND
	(
      aid.WorkAssignmentId is null or
	  @CsvVisibilityGroupIds is null or
	  EXISTS 
	    (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		where wavg.WorkAssignmentId = aid.WorkAssignmentId and
		      wavg.VisibilityType = 2
	    )
	)
  
)
SELECT
    fl.FullHierarchy,
    aid.Id AS ActionItemDefinitionId,
    aid.ActionItemDefinitionStatusId, 
    aid.[Name],
    aid.SourceId,
	aid.Active,
    aid.LastModifiedUserId AS LastModifiedUserId,
    lastModifiedUser.LastName AS LastModifiedLastName,
    lastModifiedUser.FirstName AS LastModifiedFirstName,
    lastModifiedUser.Username AS LastModifiedUserName,
    aid.[Description],
    aid.BusinessCategoryId,
    aid.OperationalModeId,
    aid.PriorityId,
	bc.[Name] as BusinessCategoryName,
    s.*,
	vg.[Name] as VisibilityGroupName,
		aidcfg.Reading
FROM
    ActionItemDefinition aid
    INNER JOIN ActionItemDefinitionCte cte ON cte.ActionItemDefinitionId = aid.Id 
    INNER JOIN Schedule s ON aid.ScheduleId = s.Id
    INNER JOIN [User] lastModifiedUser ON aid.LastModifiedUserId = lastModifiedUser.Id
    INNER JOIN ActionItemDefinitionFunctionalLocation aidfl ON aid.Id = aidfl.ActionItemDefinitionId
    INNER JOIN FunctionalLocation fl ON aidfl.FunctionalLocationId = fl.Id
	LEFT OUTER JOIN BusinessCategory bc on bc.Id = aid.BusinessCategoryId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = aid.WorkAssignmentId and wavg.VisibilityType = 2
    LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
	left outer join ActionItemDefinitionCustomFieldGroup aidcfg on aidcfg.ActionItemDefinitionId = aid.Id
ORDER BY
    ActionItemDefinitionId
OPTION (OPTIMIZE FOR UNKNOWN)	
