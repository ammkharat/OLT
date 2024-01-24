IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN24Id')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormGN24Id
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormGN24Id
(
    @FormGN24Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN24Approval approval
WHERE FormGN24Id = @FormGN24Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormGN24Id TO PUBLIC
GO