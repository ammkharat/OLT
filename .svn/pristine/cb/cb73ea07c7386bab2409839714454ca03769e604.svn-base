IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN7Id')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormGN7Id
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormGN7Id
(
    @FormGN7Id bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN7Approval approval
WHERE FormGN7Id = @FormGN7Id
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormGN7Id TO PUBLIC
GO