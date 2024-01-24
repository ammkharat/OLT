IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormGN75AId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormGN75AId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormGN75AId
(
    @FormGN75AId bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	FormGN75AApproval approval
WHERE FormGN75AId = @FormGN75AId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormGN75AId TO PUBLIC
GO