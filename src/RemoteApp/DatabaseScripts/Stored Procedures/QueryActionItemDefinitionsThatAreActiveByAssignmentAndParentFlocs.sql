IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionsThatAreActiveByAssignmentAndParentFlocs')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemDefinitionsThatAreActiveByAssignmentAndParentFlocs
    END
GO

CREATE Procedure [dbo].QueryActionItemDefinitionsThatAreActiveByAssignmentAndParentFlocs
    (
        @CsvFlocIds VARCHAR(MAX),
        @AssignmentId bigint = NULL,
		@EndOfDateRange datetime,
		@IncludeAssignmentInCondition bit,
		@CsvVisibilityGroupIds varchar(max)
    )
AS

WITH ActionItemDefinitionCTE (ActionItemDefinitionId)
AS
(
  SELECT 
    DISTINCT aid.Id
    FROM ActionItemDefinition aid
    INNER JOIN Schedule s ON aid.ScheduleId = s.Id
  WHERE
    aid.deleted = 0 AND
    aid.active = 1 AND
    ((@IncludeAssignmentInCondition = 1 AND ((@AssignmentId is null and aid.WorkAssignmentId is null) or (aid.WorkAssignmentId = @AssignmentId))) OR @IncludeAssignmentInCondition = 0) AND
	(s.EndDateTime is null or s.EndDateTime > @EndOfDateRange) AND
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
FROM
    ActionItemDefinition aid
    INNER JOIN ActionItemDefinitionCTE cte on cte.ActionItemDefinitionId = aid.Id
OPTION (OPTIMIZE FOR UNKNOWN)		
GO

GRANT EXEC ON QueryActionItemDefinitionsThatAreActiveByAssignmentAndParentFlocs TO PUBLIC
GO