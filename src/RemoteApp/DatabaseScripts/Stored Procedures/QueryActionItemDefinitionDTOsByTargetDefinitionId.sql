IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionDTOsByTargetDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionDTOsByTargetDefinitionId
	END
GO

CREATE Procedure dbo.QueryActionItemDefinitionDTOsByTargetDefinitionId
(
    @Id bigint
)
AS
SELECT
	fl.FullHierarchy,
	aid.Id AS ActionItemDefinitionId,
	aid.ActionItemDefinitionStatusId, 
	aid.Name,
	aid.SourceId,
	aid.Active,
	aid.LastModifiedUserId,
	lastModifiedUser.LastName AS LastModifiedLastName,
	lastModifiedUser.FirstName AS LastModifiedFirstName,
	lastModifiedUser.Username AS LastModifiedUserName,
	aid.Description,
	aid.BusinessCategoryId,
	aid.OperationalModeId,
	aid.PriorityId,
	bc.Name as BusinessCategoryName,
	s.*,
	vg.Name as VisibilityGroupName
FROM
	ActionItemDefinition aid 
	INNER JOIN Schedule s ON aid.ScheduleId = s.Id
	INNER JOIN [User] lastModifiedUser ON aid.LastModifiedUserId = lastModifiedUser.Id
	INNER JOIN ActionItemDefinitionFunctionalLocation aidfl ON aid.Id = aidfl.ActionItemDefinitionId
	INNER JOIN FunctionalLocation fl ON aidfl.FunctionalLocationId = fl.Id
	INNER JOIN ActionItemDefinitionTargetDefinition aidtd ON aidtd.ActionItemDefinitionId = aid.Id
	LEFT OUTER JOIN BusinessCategory bc on bc.Id = aid.BusinessCategoryId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = aid.WorkAssignmentId and wavg.VisibilityType = 2
    LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
WHERE
	aid.deleted = 0 AND
	aidtd.TargetDefinitionId = @Id 
GO

GRANT EXEC ON QueryActionItemDefinitionDTOsByTargetDefinitionId TO PUBLIC
GO