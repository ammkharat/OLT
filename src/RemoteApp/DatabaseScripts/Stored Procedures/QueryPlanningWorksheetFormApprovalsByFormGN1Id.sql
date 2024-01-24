IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPlanningWorksheetFormApprovalsByFormGN1Id')
    BEGIN
        DROP Procedure [dbo].QueryPlanningWorksheetFormApprovalsByFormGN1Id
    END
GO

CREATE Procedure [dbo].QueryPlanningWorksheetFormApprovalsByFormGN1Id
(
    @FormGN1Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN1PlanningWorksheetApproval approval
WHERE FormGN1Id = @FormGN1Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryPlanningWorksheetFormApprovalsByFormGN1Id TO PUBLIC
GO