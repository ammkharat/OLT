 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAssociatedTargetDefinitionDTOsByParentId')
    BEGIN
        DROP PROCEDURE [dbo].QueryAssociatedTargetDefinitionDTOsByParentId
    END
GO

CREATE Procedure [dbo].QueryAssociatedTargetDefinitionDTOsByParentId
    (
        @ParentId bigint
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
    targetDefinition.TargetValueTypeId,
    targetDefinition.TargetDefinitionStatusID,
    targetDefinition.PriorityId,
    targetDefinition.OperationalModeId,
    targetDefinition.IsActive,
    targetDefinition.TargetDefinitionValue,
    targetDefinition.GapUnitValue,
    targetDefinition.NeverToExceedMin,
    targetDefinition.MinValue,
    targetDefinition.MaxValue,
    targetDefinition.NeverToExceedMax,
        
    floc.FullHierarchy,
    tag.Name as TagName,
    tag.ScadaConnectionInfoId as TagScadaConnectionInfoId,
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
    TargetDefinition targetDefinition
    INNER JOIN TargetDefinitionAssociation targetDefinitionAssociation 
        ON targetDefinition.Id = targetDefinitionAssociation.ChildTargetDefinitionId
    INNER JOIN FunctionalLocation floc
        ON targetDefinition.FunctionalLocationID = floc.Id
    INNER JOIN Tag tag
        ON targetDefinition.TagID = tag.Id
    INNER JOIN Schedule s
        ON targetDefinition.ScheduleId = s.Id
    INNER JOIN [User] lastModifiedUser
        ON targetDefinition.LastModifiedUserId = lastModifiedUser.Id
    LEFT OUTER JOIN TargetDefinitionReadWriteTagConfiguration tagConfig
        ON targetDefinition.Id = tagConfig.[TargetDefinitionId] and tagConfig.Deleted = 0
    LEFT OUTER JOIN Tag GapUnitValueTag
        ON tagConfig.GapUnitValueTagId = GapUnitValueTag.[Id] and GapUnitValueTag.Deleted = 0
    LEFT OUTER JOIN Tag TargetTag
        ON tagConfig.TargetTagId = TargetTag.[Id] and TargetTag.Deleted = 0
   LEFT OUTER JOIN WorkAssignment workAssignment
        ON targetDefinition.WorkAssignmentId = WorkAssignment.[Id] and WorkAssignment.Deleted = 0
WHERE
    targetDefinitionAssociation.ParentTargetDefinitionId = @ParentId AND
    targetDefinition.Deleted = 0
ORDER BY targetDefinition.Id
GO

GRANT EXEC ON QueryAssociatedTargetDefinitionDTOsByParentId TO PUBLIC
GO