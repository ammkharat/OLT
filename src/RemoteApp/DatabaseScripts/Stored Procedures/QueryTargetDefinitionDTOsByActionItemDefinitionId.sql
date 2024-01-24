IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionDTOsByActionItemDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionDTOsByActionItemDefinitionId
	END
GO

CREATE Procedure dbo.QueryTargetDefinitionDTOsByActionItemDefinitionId
	(
	@Id bigint
	)
AS

SELECT
    GapUnitValueTag.[Id] as GapUnitValueTagId,
    GapUnitValueTag.[Name] AS GapUnitValueTagName,
    GapUnitValueTag.[Description] as GapUnitValueTagDescription,
    GapUnitValueTag.[Units] as GapUnitValueTagUnits,
    GapUnitValueTag.[SiteId] as GapUnitValueTagSiteId,
    GapUnitValueTag.[Deleted] as GapUnitValueTagDeleted,
    GapUnitValueTag.[ScadaConnectionInfoId] as GapUnitValueTagScadaConnectionInfoId,
    tagConfig.[GapUnitValueDirectionId] as GapUnitValueTagDirection,

    TargetTag.[Id] as TargetTagId,
    TargetTag.[Name] AS TargetTagName,
    TargetTag.[Description] as TargetTagDescription,
    TargetTag.[Units] as TargetTagUnits,
    TargetTag.[SiteId] as TargetTagSiteId,
    TargetTag.[Deleted] as TargetTagDeleted,
    TargetTag.[ScadaConnectionInfoId] as TargetTagScadaConnectionInfoId,
    tagConfig.[TargetDirectionId] as TargetTagDirection,

    targetDefinition.Id AS TargetDefinitionId,
    targetDefinition.Name,
    targetDefinition.Description,
    targetDefinition.TargetCategoryID,
    targetDefinition.ScheduleId,
    targetDefinition.TargetDefinitionStatusID,
    targetDefinition.PriorityId,
    targetDefinition.OperationalModeId,
    targetDefinition.IsActive,
    targetDefinition.TargetValueTypeId,
    targetDefinition.TargetDefinitionValue,
    targetDefinition.GapUnitValue,
    targetDefinition.NeverToExceedMin,
    targetDefinition.MinValue,
    targetDefinition.MaxValue,
    targetDefinition.NeverToExceedMax,  
    floc.FullHierarchy,
    tag.Name AS TagName,
    targetDefinition.RequiresApproval,
    s.StartDateTime,
    s.EndDateTime,
    s.FromTime,
    s.ToTime,
    targetDefinition.LastModifiedUserId,
    lastModifiedUser.LastName AS LastModifiedLastName,
    lastModifiedUser.FirstName AS LastModifiedFirstName,
    lastModifiedUser.UserName AS LastModifiedUserName,
      workAssignment.Name AS WorkAssignmentName

FROM 
    ActionItemDefinitionTargetDefinition actionItemDefinitionTargetDefinition
    INNER JOIN TargetDefinition targetDefinition 
        ON targetDefinition.Id = actionItemDefinitionTargetDefinition.TargetDefinitionId
    INNER JOIN TargetDefinitionReadWriteTagConfiguration tagConfig
        ON targetDefinition.Id = tagConfig.[TargetDefinitionId] 
    LEFT OUTER JOIN Tag GapUnitValueTag
        ON tagConfig.GapUnitValueTagId = GapUnitValueTag.[Id] 
    LEFT OUTER JOIN Tag TargetTag
        ON tagConfig.TargetTagId = TargetTag.[Id] 
    INNER JOIN FunctionalLocation floc
        ON targetDefinition.FunctionalLocationID = floc.Id
    INNER JOIN Tag tag
        ON targetDefinition.TagID = tag.Id 
    INNER JOIN Schedule s
        ON targetDefinition.ScheduleId = s.Id
    INNER JOIN [User] lastModifiedUser
        ON targetDefinition.LastModifiedUserId = lastModifiedUser.Id
   LEFT OUTER JOIN WorkAssignment workAssignment
        ON targetDefinition.WorkAssignmentId = WorkAssignment.[Id] and WorkAssignment.Deleted = 0
WHERE
    actionItemDefinitionTargetDefinition.ActionItemDefinitionId = @Id AND
    targetDefinition.Deleted = 0
GO

GRANT EXEC ON QueryTargetDefinitionDTOsByActionItemDefinitionId TO PUBLIC
GO 