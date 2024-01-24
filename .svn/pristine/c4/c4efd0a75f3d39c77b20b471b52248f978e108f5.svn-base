IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormApprovalsByFormMontrealCsdId')
    BEGIN
        DROP Procedure [dbo].QueryFormApprovalsByFormMontrealCsdId
    END
GO

CREATE Procedure [dbo].QueryFormApprovalsByFormMontrealCsdId
(
    @FormMontrealCsdId bigint
)
AS

SELECT approval.* 
FROM 
	FormMontrealCsdApproval approval
WHERE FormMontrealCsdId = @FormMontrealCsdId
ORDER BY approval.DisplayOrder ASC
GO

GRANT EXEC ON QueryFormApprovalsByFormMontrealCsdId TO PUBLIC
GO