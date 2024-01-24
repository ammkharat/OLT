IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionDTOsByFLOCIDs')
    BEGIN
        DROP PROCEDURE [dbo].QueryTargetDefinitionDTOsByFLOCIDs
    END
GO

CREATE Procedure [dbo].QueryTargetDefinitionDTOsByFLOCIDs
    (
        @IDs varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
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
    TargetTag.[ScadaConnectionInfoId] as TargetTagScadaConnectionInfoId,
    TargetTag.[Deleted] as TargetTagDeleted,
    tagConfig.[TargetDirectionId] as TargetTagDirection,

    targetDefinition.Id AS TargetDefinitionId,
    targetDefinition.Name,
    targetDefinition.Description,
    targetDefinition.TargetCategoryID,
    targetDefinition.ScheduleId,
    targetDefinition.TargetDefinitionStatusID,
    targetDefinition.PriorityId,
    targetDefinition.IsActive,
    targetDefinition.TargetValueTypeId,
    targetDefinition.TargetDefinitionValue,
    targetDefinition.GapUnitValue,
    targetDefinition.OperationalModeId,
    floc.FullHierarchy,
    tag.Name AS TagName,
    tag.ScadaConnectionInfoId as TagScadaConnectionInfoId,
    targetDefinition.RequiresApproval,
    targetDefinition.NeverToExceedMin,
    targetDefinition.MinValue,
    targetDefinition.MaxValue,
    targetDefinition.NeverToExceedMax,
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
    INNER JOIN FunctionalLocation floc
        ON targetDefinition.FunctionalLocationID = floc.Id
    INNER JOIN Tag tag 
        ON tag.Id = targetDefinition.TagID
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
    targetDefinition.Deleted = 0 AND
    (s.EndDateTime is null or (s.EndDateTime <= @ToDate AND s.EndDateTime >= @FromDate)) AND
    (
        EXISTS
        (
            -- Floc of target alert matches one of the passed in flocs
            select ids.Id
            from IDSplitter(@Ids) ids
            where ids.Id = floc.Id
        )
        OR EXISTS
        (
            -- Floc of target alert is child of one of the passed in flocs (look down the floc tree from my selected flocs)
            select ids.Id
            from FunctionalLocationAncestor a
            inner join IDSplitter(@Ids) ids on ids.Id = a.AncestorId
            where a.Id = floc.Id
        )
    )
ORDER BY FunctionalLocationID
OPTION (OPTIMIZE FOR UNKNOWN)   
GO

GRANT EXEC ON QueryTargetDefinitionDTOsByFLOCIDs TO PUBLIC
GO