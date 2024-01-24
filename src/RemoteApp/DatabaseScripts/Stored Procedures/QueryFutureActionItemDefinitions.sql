IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFutureActionItemDefinitions')
    BEGIN
        DROP PROCEDURE [dbo].QueryFutureActionItemDefinitions
    END
GO

CREATE Procedure [dbo].QueryFutureActionItemDefinitions
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
        @CsvVisibilityGroupIds VARCHAR(max)
    )
AS

WITH ActionItemDefinitionCTE (ActionItemDefinitionId, EveryShift)
AS
(
  SELECT 
    DISTINCT aid.Id , s.EveryShift
    FROM ActionItemDefinition aid
    INNER JOIN Schedule s ON aid.ScheduleId = s.Id
  WHERE
    aid.deleted = 0 AND
    ((s.EndDateTime is null and s.StartDateTime <= @EndOfDateRange) or (s.StartDateTime <= @EndOfDateRange AND s.EndDateTime >= @StartOfDateRange)) AND
    (
      aid.WorkAssignmentId is null or
      @CsvVisibilityGroupIds is null or
      EXISTS (
        select wavg.Id
        from WorkAssignmentVisibilityGroup wavg
        inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
        where wavg.WorkAssignmentId = aid.WorkAssignmentId and 
              wavg.VisibilityType = 2
        )
    )
    AND 
    (
        EXISTS
        (
            -- one of the query flocs is one of the action item def'n flocs
            select Id
            from 
                IDSplitter(@CsvFlocIds) QueryIds
                inner join ActionItemDefinitionFunctionalLocation aidfl 
                    on aidfl.FunctionalLocationId = QueryIds.Id
            WHERE
                aidfl.ActionItemDefinitionId = aid.Id 
        )
        OR
        EXISTS
        (
        -- one of the query flocs is a parent of one of the action item def'n flocs 
        select Relationship.Id
        from 
            FunctionalLocationAncestor Relationship
            inner join IDSplitter(@CsvFlocIds) QueryIds 
                on Relationship.AncestorId = QueryIds.Id
            inner join ActionItemDefinitionFunctionalLocation aidfl 
                on aidfl.FunctionalLocationId = Relationship.Id
        WHERE
            aidfl.ActionItemDefinitionId = aid.Id 
        )
    )
)
SELECT
    aid.*
    ,cte.EveryShift  
FROM
    ActionItemDefinition aid
    INNER JOIN ActionItemDefinitionCTE cte on cte.ActionItemDefinitionId = aid.Id
OPTION (OPTIMIZE FOR UNKNOWN)       
GO

GRANT EXEC ON QueryFutureActionItemDefinitions TO PUBLIC
GO