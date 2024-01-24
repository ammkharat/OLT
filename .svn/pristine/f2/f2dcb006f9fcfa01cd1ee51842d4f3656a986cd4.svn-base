IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN6Id')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormGN6Id
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormGN6Id
(
    @FormGN6Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN6Approval approval
WHERE FormGN6Id = @FormGN6Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormGN6Id TO PUBLIC
GO