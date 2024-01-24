IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRescuePlanFormApprovalsByFormGN1Id')
    BEGIN
        DROP Procedure [dbo].QueryRescuePlanFormApprovalsByFormGN1Id
    END
GO

CREATE Procedure [dbo].QueryRescuePlanFormApprovalsByFormGN1Id
(
    @FormGN1Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN1RescuePlanApproval approval
WHERE FormGN1Id = @FormGN1Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryRescuePlanFormApprovalsByFormGN1Id TO PUBLIC
GO