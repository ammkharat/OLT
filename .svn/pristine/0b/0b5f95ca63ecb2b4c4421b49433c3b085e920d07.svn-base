IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByOvertimeFormId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByOvertimeFormId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByOvertimeFormId
(
    @OvertimeFormId bigint
)
AS

SELECT approval.*, 1 as ShouldBeEnabledBehaviourId, cast(1 as bit) as Enabled
FROM 
	OvertimeFormApproval approval
WHERE OvertimeFormId = @OvertimeFormId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByOvertimeFormId TO PUBLIC
GO