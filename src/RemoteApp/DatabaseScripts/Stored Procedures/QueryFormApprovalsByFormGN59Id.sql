IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN59Id')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormGN59Id
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormGN59Id
(
    @FormGN59Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN59Approval approval
WHERE FormGN59Id = @FormGN59Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormGN59Id TO PUBLIC
GO